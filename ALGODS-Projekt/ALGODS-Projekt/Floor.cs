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


    }
}
