﻿using System;
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
        int currentFloor;
        
        public Elevator()
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
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
        
    }
}