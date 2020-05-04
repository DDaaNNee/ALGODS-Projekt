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
            currentTime = 0;
            goUp = false;
        }

        // Instance variables:

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;
        Floor floor;
        int currentTime;
        bool goUp;


        // Methods:

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

                if (f.GetPeopleOnFloor().Count > 0)
                {
                    foreach (Person p in f.GetPeopleOnFloor())
                    {
                        rowInList += p.End_floor.ToString() + ", ";
                    }
                }
                else
                {
                    rowInList = " ";
                }
                allPeopleStartList.Add(rowInList);
            }
            return allPeopleStartList;
        }


        // Används denna metod?
        public void AddRemovePeople(Elevator elevator)
        {

            foreach (Person pDeparting in elevator.GetCurrentPassagers().ToList())
            {
                if (pDeparting.End_floor == elevator.GetCurrentFloor().GetFloorNumber())
                {
                    elevator.GetCurrentPassagers().Remove(pDeparting);                 
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

        

        
        


        
        
    }
}
