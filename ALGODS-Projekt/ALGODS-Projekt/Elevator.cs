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
        int currentFloor;
        

        // Två konstruktorer: en för en "default" byggnad med 10 floors, och en med ett specificerat antal våningar utifrån användar-input.
        public Elevator()
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
            listOfFloors = new List<Floor>(10);
            currentFloor = 0;
        }

        public Elevator(int numOfFloors)
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
            listOfFloors = new List<Floor>(numOfFloors);
            currentFloor = 0;
        }

        public void AddPerson(Person person)
        {
            if (person.GetDirection(person.Start_floor, person.End_floor) == currentDirection && currentPeople.Count <= 9)
            {
                currentPeople.Add(person);
            }
        }
        
        // Flytta hissen en våning uppåt eller en våning nedåt.
        public void MoveElevator()
        {
            if(currentDirection == Direction.DirectionEnum.Up && currentFloor < 9)
            {
                currentFloor = currentFloor + 1;
            }
            else if (currentDirection == Direction.DirectionEnum.Down && currentFloor > 0)
            {
                currentFloor = currentFloor - 1;           
            }
        }

        // Öka passagerares System_time med 1
        public void IncreaseSystemTime()
        {
            foreach (Person passenger in currentPeople)
            {
                passenger.System_time = passenger.System_time + 1;
            }
        }




        // Metod för att sortera passagerarna i currentPeople så att listan snabbare kan sökas igenom efter personer som ska gå av?


    }
}
