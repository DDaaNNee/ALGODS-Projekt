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
        public Elevator()
        {
            currentDirection = Direction.DirectionEnum.Up;
            currentPeople = new List<Person>(10);
        }

        public void AddPerson(Person person)
        {
            if (person.GetDirection(person.Start_floor, person.End_floor) == currentDirection && currentPeople.Count <= 9)
            {
                currentPeople.Add(person);
            }
        }
    }
}
