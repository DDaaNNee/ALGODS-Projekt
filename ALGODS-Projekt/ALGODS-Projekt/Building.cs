using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class Building
    {

        public Building()
        {
            elevator = new Elevator();
        }

        // Byggnaden får ett elevator-objekt vid instansiering
        Elevator elevator;

        // Våningar - En lista med Floor-objekt?
        List<Floor> floors;

        Floor floor;

        public void CreateFloors(List<Person> pList)
        {
            foreach(int startFloor in pList.Select(x=>x.Start_floor).Distinct())
            {
                floor = new Floor(startFloor);
                foreach (Person p in pList)
                {
                    //floor.AddPerson(p);
                }
            }
        }


    }
}
