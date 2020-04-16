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
        Floor currentFloor;
        
        public Elevator(int numOfFloors = 10)
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
            listOfFloors = new List<Floor>(numOfFloors);
            currentFloor = new Floor(0);

        }

        public void AddPerson(Person person)
        {
            if (person.GetDirection(person.Start_floor, person.End_floor) == currentDirection && currentPeople.Count <= 9)
            {
                currentPeople.Add(person);
            }
        }
        
        // Flytta hissen en våning uppåt eller en våning nedåt.
        public void MoveElevator(Direction.DirectionEnum currentDirection = Direction.DirectionEnum.Up)
        {
            if(currentDirection == Direction.DirectionEnum.Up && currentFloor.GetFloorNumber() < 9)
            {
                currentFloor.ChangeFloorNumber(currentFloor.GetFloorNumber() + 1);
            }
            else if (currentDirection == Direction.DirectionEnum.Down && currentFloor.GetFloorNumber() > 0)
            {
                currentFloor.ChangeFloorNumber(currentFloor.GetFloorNumber() - 1);           
            }
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
            return currentFloor;
        }

        public Direction.DirectionEnum GetCurrentElevatorDirection()
        {
            return currentDirection;
        }




        // Metod för att sortera passagerarna i currentPeople så att listan snabbare kan sökas igenom efter personer som ska gå av?


    }
}
