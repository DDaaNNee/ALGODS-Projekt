using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class Elevator
    {
        Direction.DirectionEnum currentDirection;
        List<Person> currentPeople;
        List<Floor> listOfFloors;
        int elevatorRuntime;
        int _currentFloor; 
        List<Person> arrivedPassengers;
        int totalWaitingTime;
        int totalCompletionTime;
        int averageWaitingTime;
        int averageCompletionTime;
        int peopleWithShortestTime;
        int peopleWithLongestTime;

        /// <summary>
        /// Class constructor.
        /// Here we instantiate all of our class variables.
        /// </summary>
        /// <param name="allFloors">Our constructor takes a "List<Floor>" object in order to compare the data inside this class with the variable.</param>
        /// <param name="numOfFloors">An integer which can be used to controll the number of floors./param>
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
        }

        /// <summary>
        /// Adds people from the current floor to our elevator, if it isn't at capacity.
        /// </summary>
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

        /// <summary>
        /// Removes each person from our elevator if their end floor is the current floor of our elevator,
        /// and adds these people to a list<person> called "arrivedPassengers", in order to keep track of times.
        /// </summary>
        public void RemovePersonFromElevator()
        {
            foreach (Floor f in listOfFloors.Where(x => x.GetFloorNumber() == _currentFloor).Take(1))
            {
                foreach (Person p in GetCurrentPassagers().ToList())
                {
                    if (p.End_floor == f.GetFloorNumber())
                    {
                        currentPeople.Remove(p);
                        arrivedPassengers.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// Removes each person from the floor from which they came, after they've entered our elevator.
        /// </summary>
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

        /// <summary>
        /// Moves our elevator up or down depending on what the current direction and current floor variables are currently set to.
        /// It also increases or decreases our _currentFloor variable and increases our elevator runtime.
        /// </summary>
        /// <param name="currentDirection"></param>
        public void MoveElevator(Direction.DirectionEnum currentDirection)
        {
            if(currentDirection == Direction.DirectionEnum.Up && _currentFloor < 9)
            {
                _currentFloor += 1;
                elevatorRuntime += 10;
            }
            else if (currentDirection == Direction.DirectionEnum.Down && _currentFloor > 0)
            {
                _currentFloor -= 1;
                elevatorRuntime += 10;
            }
        }

        /// <summary>
        /// Method for accessing elevatorRuntime variable.
        /// </summary>
        /// <returns></returns>
        public int GetElevatorRuntime()
        {
            return elevatorRuntime;
        }

        /// <summary>
        /// Method which increases each passengers system time.
        /// </summary>
        public void IncreaseSystemTime()
        {
            foreach (Person passenger in currentPeople)
            {
                passenger.System_time = passenger.System_time + 10;
            }
        }

        /// <summary>
        /// Method for accessing currentPeople variable.
        /// </summary>
        /// <returns>Returns the "currentPeople" variable</returns>
        public List<Person> GetCurrentPassagers()
        {
            return currentPeople;
        }

        /// <summary>
        /// Method for accessing _currentFloor variable.
        /// </summary>
        /// <returns>Returns the "_currentFloor" variable</returns>
        public int GetCurrentFloor()
        {
            return _currentFloor;
        }

        /// <summary>
        /// Method for accessing currentDirection variable.
        /// </summary>
        /// <returns>Returns the "currentDirection" variable</returns>
        public Direction.DirectionEnum GetCurrentElevatorDirection()
        {
            return currentDirection;
        }

        /// <summary>
        /// Method for sorting people by completion time in order to be able to see the fastest and slowest completion times.
        /// </summary>
        /// <returns>Returns a "List<Person>" object with the passengers which have arrived in order</returns>
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

        /// <summary>
        /// Method for calculating total time, this is then used in order to calculate average times.
        /// </summary>
        public void CalculateTotalTime()
        {
            foreach (Person p in arrivedPassengers)
            {
                totalWaitingTime = totalWaitingTime + p.Waiting_time;
                totalCompletionTime = totalCompletionTime + p.GetCompletionTime();
            }
        }


        /// <summary>
        /// Method for calculating average waiting time amongst finished passengers.
        /// </summary>
        /// <returns>Returns an integer with the average waiting time</returns>
        public int CalculateAverageWaitingTime()
        {
            if(arrivedPassengers.Count != 0)
            {
                averageWaitingTime = (totalWaitingTime/arrivedPassengers.Count);
            }
            return averageWaitingTime;
        }

        /// <summary>
        /// Method for calculating average completion time amongst finished passengers.
        /// </summary>
        /// <returns>Returns an integer with the average completion time</returns>
        public int CalculateAverageCompletionTime()
        {
            if (arrivedPassengers.Count != 0)
            {
                averageCompletionTime = (totalCompletionTime / arrivedPassengers.Count);
            }
            return averageCompletionTime;
        }

        /// <summary>
        /// Method for counting the number of people with the longest completion time
        /// </summary>
        /// <returns>Returns an integer with the number of people who shares the longest completion time</returns>
        public int CountPeopleLongestTime()
        {
            List<Person> sortedPassagers = SortPeopleByCompletionTime();

            foreach(Person passager in sortedPassagers)
            {
                if(passager.GetCompletionTime() == sortedPassagers[0].GetCompletionTime())
                {
                    peopleWithLongestTime++;
                }     
            }
            return peopleWithLongestTime;
        }

        /// <summary>
        /// Method for counting the number of people with the shortest completion time
        /// </summary>
        /// <returns>Returns an integer with the number of people who shares the shortest completion time</returns>
        public int CountPeopleShortestTime()
        {
            List<Person> sortedPassengers = SortPeopleByCompletionTime();

            foreach(Person passager in sortedPassengers)
            {
                if(passager.GetCompletionTime() == sortedPassengers[sortedPassengers.Count - 1].GetCompletionTime())
                {
                    peopleWithShortestTime++;
                }     
            }
            return peopleWithShortestTime;
        }

        /// <summary>
        /// Method for accessing the longest completion time
        /// </summary>
        /// <returns>Returns an integer set to the longest completion time</returns>
        public int GetLongestCompletionTime()
        {
            List<Person> sortedPassengers = SortPeopleByCompletionTime();
            return sortedPassengers[0].GetCompletionTime();
        }

        /// <summary>
        /// Method for accessing the shortest completion time
        /// </summary>
        /// <returns>Returns an integer set to the shortest completion time</returns>
        public int GetShortestCompletionTime()
        {
            List<Person> sortedPassengers = SortPeopleByCompletionTime();
            return sortedPassengers[sortedPassengers.Count - 1].GetCompletionTime();
        }

        /// <summary>
        /// Counts the number of people who have arrived to their destinations
        /// </summary>
        /// <returns>Returns an int set to the number of people who have arrived at their destinations</returns>
        public int CalculateTotalNumberOfPeople()
        {
            return arrivedPassengers.Count();
        }
    }
}
