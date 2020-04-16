using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class Building
    {

        public Building(Elevator elev)
        {
            elevator = elev;
            allFloors = new List<Floor>();
            arrivedPassengers = new List<Person>();
            totalWaitTime = 0;
        }

        // Byggnaden får ett elevator-objekt vid instansiering
        Elevator elevator;

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;
        List<Person> arrivedPassengers;


        Floor floor;

        int totalWaitTime;
        int totalSystemTime;
        int averageWaitTime;




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

        public bool PeopleLeft()
        {
            int numFloorsWithPeople = 0;

            foreach (Floor f in allFloors)
            {
                if (f.GetPeopleOnFloor().Count > 0)
                {
                    numFloorsWithPeople++;
                }
            }
            if (numFloorsWithPeople > 0)
            {
                return true;
            }
            return false;
        }

        public void AddRemovePeople()
        {
            // tar detta bort personer från hissen eller från nuvarande våning? Kan ha fattat fel, men RemovePerson() tar väl bort en person som  väntar på våningen?
            foreach (Person pDeparting in elevator.GetCurrentPassagers())
            {
                if (pDeparting.End_floor == elevator.GetCurrentFloor().GetFloorNumber())
                {
                    elevator.GetCurrentFloor().RemovePerson(pDeparting);
                }
            }
            foreach (Person pArriving in elevator.GetCurrentFloor().GetPeopleOnFloor())
            {
                if (pArriving.GetDirection(pArriving.Start_floor, pArriving.End_floor) == elevator.GetCurrentElevatorDirection())
                {
                    elevator.AddPerson(pArriving);
                }
            }
        }

        public void IncreaseWaitTime()
        {
            foreach (Floor floor in allFloors)
            {
                foreach (Person pWaiting in floor.GetPeopleOnFloor())
                {
                    pWaiting.Waiting_time += 10;
                }
            }
        }

        public string UpdateInformation()
        {
            string rowInListbox = "";
            foreach (Floor f in GetFloors())
            {
                rowInListbox = "Floor " + f.GetFloorNumber();

                foreach (Person p in f.GetPeopleOnFloor())
                {
                    if (p == f.GetPeopleOnFloor().Last())
                    {
                        rowInListbox += p.End_floor;
                    }
                    else
                    {
                        rowInListbox += p.End_floor + ", ";
                    }
                }
            }
            return rowInListbox;
        }


        public void StartElevator(int numFloors = 10)
        {
            do
            {
                
                PeopleLeft();
                AddRemovePeople();
                if (elevator.GetCurrentFloor().GetFloorNumber() == numFloors - 1)
                {
                    elevator.MoveElevator(Direction.DirectionEnum.Down);
                }
                else if (elevator.GetCurrentFloor().GetFloorNumber() == 0)
                {
                    elevator.MoveElevator(Direction.DirectionEnum.Up);
                }

                elevator.IncreaseSystemTime();
                IncreaseWaitTime();



            }
            while (PeopleLeft() == true);
        }

    }
}
