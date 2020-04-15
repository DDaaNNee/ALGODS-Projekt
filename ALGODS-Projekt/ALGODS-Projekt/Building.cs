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
            allFloors = new List<Floor>();
        }

        // Byggnaden får ett elevator-objekt vid instansiering
        Elevator elevator;

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;

        Floor floor;

        public void CreateFloor(List<Person> pList)
        {
            foreach(int startFloor in pList.Select(x=>x.Start_floor).Distinct())
            {
                floor = new Floor(startFloor);
                allFloors.Add(floor);
                
                foreach (Person p in pList.Where(x=>x.Start_floor == startFloor))
                {
                    floor.AddPerson(p);
                }
            }
        }

        public List<Floor> GetFloors()
        {
            return allFloors;
        }


    }
}
