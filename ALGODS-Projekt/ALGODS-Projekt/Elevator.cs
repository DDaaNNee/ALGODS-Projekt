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
        Floor _currentFloor;
        int elevatorRuntime;
        
        public Elevator(List<Floor> allFloors, int numOfFloors = 10)
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
            listOfFloors = allFloors;
            elevatorRuntime = 0;
            try
            {
                _currentFloor = listOfFloors.First();
            }
            catch (Exception)
            {
                
            }
        }

        public void AddPersonToElevator()
        {
            foreach (Person p in GetCurrentFloor().GetPeopleOnFloor().ToList())
            {            
                if (currentPeople.Count <= 9)
                {
                    currentPeople.Add(p);
                }
            }
        }

        public void RemovePersonFromElevator()
        {
            foreach (Person p in GetCurrentPassagers().ToList())
            {
                if (p.End_floor == GetCurrentFloor().GetFloorNumber())
                {
                    currentPeople.Remove(p);
                }
            }
        }

        public void RemovePeopleFromFloor()
        {
            foreach (Person p in GetCurrentFloor().GetPeopleOnFloor().ToList())
            {
                for (int i = 0; i < GetCurrentPassagers().Count; i++)
                {
                    if (p == GetCurrentPassagers()[i])
                    {
                        GetCurrentFloor().GetPeopleOnFloor().Remove(p);
                    }
                }

            }
        }

        // Flytta hissen en våning uppåt eller en våning nedåt.
        public void MoveElevator(Direction.DirectionEnum currentDirection = Direction.DirectionEnum.Up)
        {
            if(currentDirection == Direction.DirectionEnum.Up && _currentFloor.GetFloorNumber() < 9)
            {
                _currentFloor.ChangeFloorNumber(_currentFloor.GetFloorNumber() + 1);
                elevatorRuntime += 10;
            }
            else if (currentDirection == Direction.DirectionEnum.Down && _currentFloor.GetFloorNumber() > 0)
            {
                _currentFloor.ChangeFloorNumber(_currentFloor.GetFloorNumber() - 1);
                elevatorRuntime += 10;
            }
        }

        public int GetElevatorRuntime()
        {
            return elevatorRuntime;
        }

        // Öka passagerares System_time med 10
        public void IncreaseSystemTime()
        {
            foreach (Person passenger in currentPeople)
            {
                passenger.System_time = passenger.System_time + 10;
            }
        }

        public List<Person> GetCurrentPassagers()
        {
            return currentPeople;
        }

        public Floor GetCurrentFloor()
        {
            return _currentFloor;
        }

        public Direction.DirectionEnum GetCurrentElevatorDirection()
        {
            return currentDirection;
        }




        // Metod för att sortera passagerarna i currentPeople så att listan snabbare kan sökas igenom efter personer som ska gå av?


    }
}
