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

        // Lägg till en "AddPerson"-metod som tar alla Person från en rad i vår CSV-fil och lägger till dom på ett Floor.
    }
}
