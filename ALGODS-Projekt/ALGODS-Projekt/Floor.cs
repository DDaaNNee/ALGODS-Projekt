using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    public class Floor
    {
        public Floor(int floorNumber)
        {
            _floorNumber = floorNumber;
            peopleWaiting = new List<Person>(50);
        }

        int _floorNumber;
        List<Person> peopleWaiting;

        // Denna metod ska kallas på i vår "Elevator"-klass för att avgöra om körningen är klar eller inte.
        public bool StillPeopleWaiting()
        {
            while (peopleWaiting.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void AddPersonToFloor(Person person)
        {
            peopleWaiting.Add(person);
        }

        public void RemovePersonFromFloor(Person person)
        {
            peopleWaiting.Remove(person);
        }

        public List<Person> GetPeopleOnFloor()
        {
            return peopleWaiting;
        }

        public int GetFloorNumber()
        {
            return _floorNumber;
        }

        public void ChangeFloorNumber(int num)
        {
            _floorNumber = num;
        }
    }
}
