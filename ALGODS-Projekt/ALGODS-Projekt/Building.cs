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
        List<Floor> allFloors;
        Floor floor;
        int currentTime;
        bool goUp;
        bool simulationComplete;

        /// <summary>
        /// Class constructor.
        /// The constructor initializes some of our class variables.
        /// </summary>
        public Building()
        {
            allFloors = new List<Floor>();
            currentTime = 0;
            goUp = false;
        }

        /// <summary>
        /// Method used for adding people to our floors based on a "List<Person>" object which is provided by the inparameters of our method.
        /// </summary>
        /// <param name="pList">A "List<Person>" object</param>
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

        /// <summary>
        /// Method for creating ten floors and adding them to our floor-list.
        /// </summary>
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

        /// <summary>
        /// Method for accessing our allFloors variable.
        /// </summary>
        /// <returns>Returns our "allFloors" variable</returns>
        public List<Floor> GetFloors()
        {
            return allFloors;
        }

        /// <summary>
        /// Method for checking if our elevator and all of our floors are empty or not.
        /// </summary>
        /// <returns>Returns true of false based on of there are people left</returns>
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

        /// <summary>
        /// Method for increasing the wait time for each person on each floor.
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="numFloors"></param>
        public void StartElevator(Elevator elevator, int numFloors = 10)
        {
            simulationComplete = false;

            //List<Floor> sortedFloors = SortFloorsByPeopleWaiting();

            if (elevator.GetCurrentPassagers().Count > 0)
            {
                elevator.RemovePersonFromElevator();

                int goingUp = 0;
                int goingDown = 0;
                foreach (Person p in elevator.GetCurrentPassagers().ToList())
                {
                    if (p.End_floor > elevator.GetCurrentFloor())
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
                elevator.IncreaseSystemTime();
                IncreaseWaitTime();
            }
            else if(CheckIfPeopleWaiting(elevator) == true)
            {
                int currFloorNum = elevator.GetCurrentFloor();
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
                elevator.IncreaseSystemTime();
                IncreaseWaitTime();
            }
            else if (CheckIfPeopleWaiting(elevator) == false)
            {
                simulationComplete = true;
            }
        }

        public void AddPersonToElevator(Elevator elevator)
        {
            foreach (Floor f in allFloors.Where(x => x.GetFloorNumber() == elevator.GetCurrentFloor()).Take(1))
            {
                foreach (Person p in f.GetPeopleOnFloor())
                {
                    elevator.GetCurrentPassagers().Add(p);
                    f.RemovePersonFromFloor(p);
                }
            }
        }

        public bool CheckIfPeopleWaiting(Elevator elevat)
        {
            int peopleLeft = 0;
            foreach (Floor f in allFloors)
            {
                if (f.StillPeopleWaiting() == true)
                {
                    peopleLeft++;
                }
            }
            if (elevat.GetCurrentPassagers().Count > 0)
            {
                foreach (Person p in elevat.GetCurrentPassagers())
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

        public bool CheckIfSimulationCompleted()
        {
            if (simulationComplete == true)
            {
                return true;
            }
            return false;
        }
    }
}
