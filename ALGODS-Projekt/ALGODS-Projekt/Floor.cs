using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    public class Floor
    {
        int _floorNumber;
        List<Person> peopleWaiting;

        /// <summary>
        /// Class constructor.
        /// Sets our class variable to the variable coming through the constructor.
        /// Instanciates our peopleWaiting list.
        /// </summary>
        /// <param name="floorNumber">Takes an integer and sets our "_floorNumber" to that value</param>
        public Floor(int floorNumber)
        {
            _floorNumber = floorNumber;
            peopleWaiting = new List<Person>(50);
        }

        /// <summary>
        /// Method for checking if a specific floor object still has people waiting for the elevator left.
        /// </summary>
        /// <returns>Returns true or false based on if there are people left on the floor</returns>
        public bool StillPeopleWaiting()
        {
            while (peopleWaiting.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a "Person" object to our peopleWaiting list.
        /// </summary>
        /// <param name="person">A person object</param>
        public void AddPersonToFloor(Person person)
        {
            peopleWaiting.Add(person);
        }

        /// <summary>
        /// Removes a "Person" object from our peopleWaiting list.
        /// </summary>
        /// <param name="person">A person object</param>
        public void RemovePersonFromFloor(Person person)
        {
            peopleWaiting.Remove(person);
        }

        /// <summary>
        /// Method for accessing the peopleWaiting class variable.
        /// </summary>
        /// <returns>Returns the peopleWaiting variable</returns>
        public List<Person> GetPeopleOnFloor()
        {
            return peopleWaiting;
        }

        /// <summary>
        /// Method for accessing the _floorNumber variable.
        /// </summary>
        /// <returns>Returns the _floorNumber variable</returns>
        public int GetFloorNumber()
        {
            return _floorNumber;
        }
    }
}
