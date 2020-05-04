using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class Elevator
    {
        // Instance variables:

        Direction.DirectionEnum currentDirection;
        List<Person> currentPeople;
        List<Floor> listOfFloors;
        //Floor _currentFloor;
        int elevatorRuntime;
        int _currentFloor;
        
        // Då passagerare lämnar hissen adderas de till denna lista.
        List<Person> arrivedPassengers;
        int totalWaitingTime;
        int totalCompletionTime;
        int averageWaitingTime;
        int averageCompletionTime;
        int peopleWithShortestTime;
        int peopleWithLongestTime;

        // Constructor:

        public Elevator(List<Floor> allFloors, int numOfFloors = 10)
        {
            arrivedPassengers = new List<Person>();
            totalWaitingTime = 0;
            totalCompletionTime = 0;
            peopleWithShortestTime = 0;
            peopleWithLongestTime = 0;
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
            listOfFloors = allFloors;
            elevatorRuntime = 0;
            _currentFloor = 0;
            try
            {
                //Floor firstFloor = listOfFloors.First();
                //_currentFloor = listOfFloors.First();
            }
            catch (Exception)
            {
                
            }
        }

        // Methods:

        public void AddPersonToElevator()
        {
            foreach (Floor f in listOfFloors.Where(x => x.GetFloorNumber() == _currentFloor).Take(1))
            {
                foreach (Person p in f.GetPeopleOnFloor().ToList())
                {
                    if (currentPeople.Count <= 9)
                    {
                        currentPeople.Add(p);
                    }
                }
            }
        }

        public void RemovePersonFromElevator()
        {
            foreach (Floor f in listOfFloors.Where(x => x.GetFloorNumber() == _currentFloor).Take(1))
            {
                foreach (Person p in GetCurrentPassagers().ToList())
                {
                    if (p.End_floor == f.GetFloorNumber())
                    {
                        currentPeople.Remove(p);
                        // Lägg till person som går av i lista för personer som kommit fram:
                        arrivedPassengers.Add(p);
                    }
                }
            }
        }

        public void RemovePeopleFromFloor()
        {
            foreach (Floor f in listOfFloors.Where(x => x.GetFloorNumber() == _currentFloor).Take(1))
            {
                foreach (Person p in f.GetPeopleOnFloor().ToList())
                {
                    for (int i = 0; i < GetCurrentPassagers().Count; i++)
                    {
                        if (p == GetCurrentPassagers()[i])
                        {
                            f.GetPeopleOnFloor().Remove(p);
                        }
                    }

                }
            }
        }

        // Flytta hissen en våning uppåt eller en våning nedåt.
        public void MoveElevator(Direction.DirectionEnum currentDirection = Direction.DirectionEnum.Up)
        {
            if(currentDirection == Direction.DirectionEnum.Up && _currentFloor < 9)
            {
                //_currentFloor.ChangeFloorNumber(_currentFloor.GetFloorNumber() + 1);
                _currentFloor += 1;
                elevatorRuntime += 10;
            }
            else if (currentDirection == Direction.DirectionEnum.Down && _currentFloor > 0)
            {
                //_currentFloor.ChangeFloorNumber(_currentFloor.GetFloorNumber() - 1);
                _currentFloor -= 1;
                elevatorRuntime += 10;
            }
        }

        public int GetElevatorRuntime()
        {
            return elevatorRuntime;
        }

        
        // Increase the system time for passagers:

        public void IncreaseSystemTime()
        {
            foreach (Person passenger in currentPeople)
            {
                passenger.System_time = passenger.System_time + 10;
            }
        }

        // Methods for returning instance variables:

        public List<Person> GetCurrentPassagers()
        {
            return currentPeople;
        }

        public int GetCurrentFloor()
        {
            return _currentFloor;
        }

        public Direction.DirectionEnum GetCurrentElevatorDirection()
        {
            return currentDirection;
        }



        // Same method as SortFloorsByPeopleWaiting but for sorting arrived passagers by their completion time:

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
