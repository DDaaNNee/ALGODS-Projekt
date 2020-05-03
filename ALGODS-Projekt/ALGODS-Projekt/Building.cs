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
        public Building()
        {
            allFloors = new List<Floor>();
            arrivedPassengers = new List<Person>();
            totalWaitingTime = 0;
            totalCompletionTime = 0;
            peopleWithShortestTime = 0;
            peopleWithLongestTime = 0;
            currentTime = 0;
            goUp = false;
        }

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;

        // Då passagerare lämnar hissen adderas de till denna lista.
        List<Person> arrivedPassengers;

        Floor floor;

        // instansvariabler för total tidsåtgång
        int totalWaitingTime;
        int totalCompletionTime;
        int averageWaitingTime;
        int averageCompletionTime;
        int peopleWithShortestTime;
        int peopleWithLongestTime;
        int currentTime;
        bool goUp;

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

        public void PopulateFloors(List<Person> pList)
        {
            try
            {
                foreach (Person p in pList)
                {
                    for (int i = 0; i < GetFloors().Count; i++)
                    {
                        int floorInt = GetFloors()[i].GetFloorNumber();
                        if (p.Start_floor == floorInt)
                        {
                            GetFloors()[i].AddPersonToFloor(p);
                        }
                    }
                }
            }
            catch (NullReferenceException)
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

       
        // Metod för sortering av våningar efter antal väntande personer:

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

        // Samma metod men för sortering av passagerare efter deras completion-time:

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

            List<Floor> sortedFloors = SortFloorsByPeopleWaiting();

            if (elevator.GetCurrentPassagers().Count > 0 && CheckIfPeopleWaiting() == true)
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
            else if(CheckIfPeopleWaiting() == true)
            {
                int currFloorNum = elevator.GetCurrentFloor().GetFloorNumber();
                int minFloorNum = 0;
                int maxFloorNum = 9;

                if (currFloorNum == minFloorNum)
                {
                    goUp = true;
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.MoveElevator(Direction.DirectionEnum.Up);
                }
                else if (currFloorNum == maxFloorNum)
                {
                    goUp = false;
                    Console.WriteLine(elevator.GetCurrentPassagers());
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
                else if (goUp == true)
                {
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.MoveElevator(Direction.DirectionEnum.Up);
                }
                else if (goUp == false)
                {
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
            }
            else
            {
                //Klar
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

        // Metod för att räkna ut total Waiting time och Completion time:

        public void CalculateTotalTime()
        {
            foreach(Person p in arrivedPassengers)
            {
                totalWaitingTime = totalWaitingTime + p.Waiting_time;
                totalCompletionTime = totalCompletionTime + p.GetCompletionTime();
            }
        }

        // Metod för att räkna ut medelvärden (Waiting och Completion time) bland passagerare:

        public void CalculateAverageTime()
        {
            if(arrivedPassengers.Count != 0)
            {
                averageWaitingTime = (totalWaitingTime/arrivedPassengers.Count);
                averageCompletionTime = (totalCompletionTime/arrivedPassengers.Count);
            }
        }


        // Metod för att räkna ut antalet passagerare som har den längsta totala tiden samt kortaste totala tiden:

        public void CountPeopleShortestLongestTime()
        {
            // Sortera passagerare efter deras CompletionTime från högst till lägst:
            
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
