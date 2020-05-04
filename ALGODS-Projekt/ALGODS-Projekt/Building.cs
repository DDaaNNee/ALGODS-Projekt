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
        /// Main method used for running the simulation.
        /// The algorithm decides whether to go up or down based on where people currently standing in the elevator needs to get off.
        /// As long as there either are people waiting on any floor, or people waiting inside the elevator, the returned bool is true.
        /// </summary>
        /// <param name="elevator">Uses an elevator object in order to 
        /// access it's methods and use the same object, instead of creating a new one.</param>
        /// <param name="numFloors">An integer representing the number of floors in our building, it is possible to change this variable</param>
        public void StartElevator(Elevator elevator, int numFloors = 10)
        {
            simulationComplete = false;
            int minFloorNum = 0;
            int maxFloorNum = numFloors - 1;

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
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Up);
                    elevator.MoveElevator(Direction.DirectionEnum.Up);
                }
                else
                {
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Down);
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
                elevator.IncreaseSystemTime();
                IncreaseWaitTime();
            }
            else if(CheckIfPeopleWaiting(elevator) == true)
            {
                int currFloorNum = elevator.GetCurrentFloor();


                if (currFloorNum == minFloorNum)
                {
                    
                    goUp = true;
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Up);
                    elevator.MoveElevator(Direction.DirectionEnum.Up);

                }
                else if (currFloorNum == maxFloorNum)
                {
                    
                    goUp = false;
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Down);
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
                else if (goUp == true)
                {
                    
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Up);
                    elevator.MoveElevator(Direction.DirectionEnum.Up);

                }
                else if (goUp == false)
                {
                    elevator.AddPersonToElevator();
                    elevator.RemovePeopleFromFloor();
                    elevator.SetCurrentDirection(Direction.DirectionEnum.Down);
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

        /// <summary>
        /// Adds each person on a specific floor to our elevator, and then removes then from the floor that they were coming from.
        /// </summary>
        /// <param name="elevator">Uses an elevator object in order to 
        /// access it's methods and use the same object, instead of creating a new one</param>
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

        /// <summary>
        /// Method for checking if our elevator and all of our floors are empty or not.
        /// </summary>
        /// <returns>Returns true of false based on of there are people left</returns>
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

        /// <summary>
        /// Method for checking if the variable "simulationComplete" is true or false.
        /// </summary>
        /// <returns>Returns the value of the variable "simulationComplete"</returns>
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
