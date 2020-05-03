using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ALGODS_Projekt
{
    class Building
    {
        // Constructor
        public Building()
        {
            allFloors = new List<Floor>();
            arrivedPassengers = new List<Person>();
            totalWaitingTime = 0;
            totalCompletionTime = 0;
            peopleWithShortestTime = 0;
            peopleWithLongestTime = 0;
            currentTime = 0;
        }

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;

        // Då passagerare lämnar hissen adderas de till denna lista.
        List<Person> arrivedPassengers;

        Floor floor;

        // instance variables for total time
        int totalWaitingTime;
        int totalCompletionTime;
        int averageWaitingTime;
        int averageCompletionTime;
        int peopleWithShortestTime;
        int peopleWithLongestTime;
        int currentTime;

        // Just nu kör den varje floor utan att ta hänsyn till hur många floors vi vill att den ska skapa.
        public void CreateFloor(List<Person> pList)
        {
            try
            {
                foreach(int startFloor in pList.Select(x=>x.Start_floor).Distinct())
                {
                    floor = new Floor(startFloor);
                    foreach (Person p in pList.Where(x=>x.Start_floor == startFloor))
                    {
                        floor.AddPersonToFloor(p);
                    }
                    allFloors.Add(floor);
                }
            }
            catch (Exception)
            {
            }
        }

        public void CreateTenFloors()
        {
            if (currentTime == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    floor = new Floor(i);
                    allFloors.Add(floor);
                }
            }

        }

        public Floor GetStartingFloor()
        {
            Floor startingFloor = allFloors.Min();
            return startingFloor;
        }

        public List<Floor> GetFloors()
        {
            return allFloors;
        }

        // Method for sorting floors by number of waiting people:

        public List<Floor> SortFloorsByPeopleWaiting()
        {
            List<Floor> orderedFloorList = new List<Floor>();
            orderedFloorList = allFloors;
            for (int i = 0; i < orderedFloorList.Count; i++)
            {
                for (int j = 0; j < orderedFloorList.Count; j++)
                {
                    if (orderedFloorList[i].GetPeopleOnFloor().Count > orderedFloorList[j].GetPeopleOnFloor().Count)
                    {
                        Floor temp = orderedFloorList[i];
                        orderedFloorList[i] = orderedFloorList[j];
                        orderedFloorList[j] = temp;
                    }
                }
            }
            return orderedFloorList;
        }

        // Same method as above but for sorting arrived passagers by their completion time:

        public List<Person> SortPeopleByCompletionTime()
        {
            List<Person> orderedPeople = new List<Person>();
            orderedPeople = arrivedPassengers;

            for(int i = 0; i < orderedPeople.Count; i++)
            {
                for(int j = 0; j < orderedPeople.Count; j++)
                {
                    if(orderedPeople[i].GetCompletionTime() > orderedPeople[j].GetCompletionTime())
                    {
                        Person temp = orderedPeople[i];
                        orderedPeople[i] = orderedPeople[j];
                        orderedPeople[j] = temp;
                    }
                }
            }
            return orderedPeople;
        }
        
  

        public bool PeopleLeft()
        {
            int numFloorsWithPeople = 0;

            foreach (Floor f in allFloors)
            {
                if (f.GetPeopleOnFloor().Count > 0)
                {
                    numFloorsWithPeople++;
                }
            }
            if (numFloorsWithPeople > 0)
            {
                return true;
            }
            return false;
        }

        public void IncreaseWaitTime()
        {
            foreach (Floor floor in allFloors)
            {
                foreach (Person pWaiting in floor.GetPeopleOnFloor())
                {
                    pWaiting.Waiting_time += 10;
                }
            }
        }

        public List<string> UpdateInformation()
        {
            List<string> allPeopleStartList = new List<string>();
            foreach (Floor f in GetFloors())
            {
                string rowInList = "";
                //allPeopleStartList.Add("Floor " + f.GetFloorNumber() + ": ");

                foreach (Person p in f.GetPeopleOnFloor())
                {
                    if (p == f.GetPeopleOnFloor().Last())
                    {
                        rowInList += p.End_floor.ToString();
                    }
                    else
                    {
                        rowInList += p.End_floor.ToString() + ", ";
                    }
                }
                allPeopleStartList.Add(rowInList);
            }
            return allPeopleStartList;
        }

        public void AddRemovePeople(Elevator elevator)
        {

            foreach (Person pDeparting in elevator.GetCurrentPassagers().ToList())
            {
                if (pDeparting.End_floor == elevator.GetCurrentFloor().GetFloorNumber())
                {
                    elevator.GetCurrentPassagers().Remove(pDeparting);
                    // Lägger till en person som går av på våningen i en lista för alla personer som ankommit till sin destination:
                    arrivedPassengers.Add(pDeparting);
                }
            }
            foreach (Person pArriving in elevator.GetCurrentFloor().GetPeopleOnFloor().ToList())
            {
                if (pArriving.GetDirection(pArriving.Start_floor, pArriving.End_floor) == elevator.GetCurrentElevatorDirection() && pArriving.End_floor != elevator.GetCurrentFloor().GetFloorNumber())
                {
                    elevator.GetCurrentPassagers().Add(pArriving);
                    elevator.GetCurrentFloor().RemovePersonFromFloor(pArriving);
                }
            }
        }

        // La till så att hissen ska röra sig mot den våningen där flest personer väntar. (Ta bort om det inte funkar).
        public void StartElevator(Elevator elevator, int numFloors = 10)
        {
            bool peopleLeft = CheckIfPeopleWaiting();
            //while (peopleLeft == true)
            //{

            List<Floor> sortedFloors = SortFloorsByPeopleWaiting();

            if (elevator.GetCurrentPassagers().Count > 0)
            {
                elevator.RemovePersonFromElevator();

                int goingUp = 0;
                int goingDown = 0;
                foreach (Person p in elevator.GetCurrentPassagers().ToList())
                {
                    if (p.End_floor > elevator.GetCurrentFloor().GetFloorNumber())
                    {
                        goingUp++;
                    }
                    else
                    {
                        goingDown++;
                    }
                }
                if (goingUp > goingDown)
                {
                    elevator.MoveElevator(Direction.DirectionEnum.Up);
                }
                else
                {
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
            }
            else
            {
                elevator.MoveElevator(Direction.DirectionEnum.Down);
                elevator.AddPersonToElevator();
                elevator.RemovePeopleFromFloor();
            }


            //if (elevator.GetCurrentFloor().GetFloorNumber() == numFloors - 1 || elevator.GetCurrentFloor().GetFloorNumber() > sortedFloors[0].GetFloorNumber() )
            //{
            //    elevator.MoveElevator(Direction.DirectionEnum.Down);
            //}
            //else /*if (elevator.GetCurrentFloor().GetFloorNumber() == 0 || elevator.GetCurrentFloor().GetFloorNumber() < sortedFloors[0].GetFloorNumber())*/
            //{
            //    elevator.MoveElevator(Direction.DirectionEnum.Up);
            //}

            elevator.IncreaseSystemTime();
            IncreaseWaitTime();
            peopleLeft = CheckIfPeopleWaiting();
            //}
        }

        public void AddPersonToElevator(Elevator elevator)
        {
            foreach (Person pArriving in elevator.GetCurrentFloor().GetPeopleOnFloor())
            {
                elevator.GetCurrentPassagers().Add(pArriving);
                elevator.GetCurrentFloor().RemovePersonFromFloor(pArriving);
            }
        }

        public bool CheckIfPeopleWaiting()
        {
            int peopleLeft = 0;
            foreach (Floor f in allFloors)
            {
                if (f.StillPeopleWaiting() == true)
                {
                    peopleLeft++;
                }
            }
            if (peopleLeft > 0)
            {
                return true;
            }
            return false;
        }

        // Method for calculating total waiting time and completion time:

        public void CalculateTotalTime()
        {
            foreach(Person p in arrivedPassengers)
            {
                totalWaitingTime = totalWaitingTime + p.Waiting_time;
                totalCompletionTime = totalCompletionTime + p.GetCompletionTime();
            }
        }

        
        // Method for calculating averages (waiting and completion time) amongst passagers:

        public void CalculateAverageTime()
        {
            if(arrivedPassengers.Count != 0)
            {
                averageWaitingTime = (totalWaitingTime/arrivedPassengers.Count);
                averageCompletionTime = (totalCompletionTime/arrivedPassengers.Count);
            }
        }


        
        // Method for counting the number of passagers with the longest and shortest completion time: 

        public void CountPeopleShortestLongestTime()
        {
            
            // Sorting passagers by their completion time from highest to lowest:

            List<Person> sortedPassagers = SortPeopleByCompletionTime();

            foreach(Person passager in sortedPassagers)
            {
                if(passager.GetCompletionTime() == sortedPassagers[0].GetCompletionTime())
                {
                    peopleWithLongestTime++;
                }
                else if(passager.GetCompletionTime() == sortedPassagers[sortedPassagers.Count-1].GetCompletionTime())
                {
                    peopleWithShortestTime++;
                }
            }
        }
    }
}
