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
            arrivedPassengers = new List<Person>();
            totalWaitingTime = 0;
            totalCompletionTime = 0;
            peopleWithShortestTime = 0;
            peopleWithLongestTime = 0;
        }

        // Byggnaden får ett elevator-objekt vid instansiering
        Elevator elevator;

        // Våningar - En lista med Floor-objekt?
        List<Floor> allFloors;

        // Då passagerare lämnar hissen adderas de till denna lista.
        List<Person> arrivedPassengers;


        Floor floor;

        // instansvariabler för total tidsåtgång
        int totalWaitingTime;
        int totalCompletionTime;
        int averageWaitingTime;
        int averageCompletionTime;
        int peopleWithShortestTime;
        int peopleWithLongestTime;

        // Just nu kör den varje floor utan att ta hänsyn till hur många floors vi vill att den ska skapa.
        public void CreateFloor(List<Person> pList)
        {
            foreach(int startFloor in pList.Select(x=>x.Start_floor).Distinct())
            {
                floor = new Floor(startFloor);                
                foreach (Person p in pList.Where(x=>x.Start_floor == startFloor))
                {
                    floor.AddPerson(p);
                }
                allFloors.Add(floor);
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
                    elevator.GetCurrentPassagers().Remove(pDeparting);
                    // Lägger till en person som går av på våningen i en lista för alla personer som ankommit till sin destination:
                    arrivedPassengers.Add(pDeparting);
                }
            }
            foreach (Person pArriving in elevator.GetCurrentFloor().GetPeopleOnFloor())
            {
                if (pArriving.GetDirection(pArriving.Start_floor, pArriving.End_floor) == elevator.GetCurrentElevatorDirection())
                {
                    elevator.GetCurrentPassagers().Add(pArriving);
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

        public List<string> UpdateInformation()
        {
            List<string> allPeopleStartList = new List<string>();
            foreach (Floor f in GetFloors())
            {
                string rowInList = "";
                allPeopleStartList.Add("Floor " + f.GetFloorNumber() + ": ");

                foreach (Person p in f.GetPeopleOnFloor())
                {
                    if (p == f.GetPeopleOnFloor().Last())
                    {
                        rowInList += p.End_floor.ToString();
                    }
                    else
                    {
                        rowInList += p.End_floor.ToString() + ", ";
                    }
                }
                allPeopleStartList.Add(rowInList);
            }
            return allPeopleStartList;
        }


        public void StartElevator(int numFloors = 10)
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

            Console.Read();

        }

        // Metod för att räkna ut total Waiting time och Completion time:

        public void CalculateTotalTime()
        {
            foreach(Person p in arrivedPassengers)
            {
                totalWaitingTime = totalWaitingTime + p.Waiting_time;
                totalCompletionTime = totalCompletionTime + p.GetCompletionTime();
            }
        }

        // Metod för att räkna ut medelvärden (Waiting och Completion time) bland passagerare:

        public void CalculateAverageTime()
        {
            if(arrivedPassengers.Count != 0)
            {
                averageWaitingTime = (totalWaitingTime/arrivedPassengers.Count);
                averageCompletionTime = (totalCompletionTime/arrivedPassengers.Count);
            }
        }


        // Metod för att räkna ut antalet passagerare som har den längsta totala tiden samt kortaste totala tiden:
        public void CountPeopleShortestLongestTime()
        {
            // Här behövs en metod för att sortera passagerare i arrivedPassengers efter deras CompletionTime från lägst till högst.
            //sort(arrivedPassengers); 

            foreach(Person passager in arrivedPassengers)
            {
                if(passager.GetCompletionTime() == arrivedPassengers[0].GetCompletionTime())
                {
                    peopleWithShortestTime++;
                }
                else if(passager.GetCompletionTime() == arrivedPassengers[arrivedPassengers.Count-1].GetCompletionTime())
                {
                    peopleWithLongestTime++;
                }
            }
        }
        
        public void SplitIntoTime(string allTimesFromCSV, int numberOfFloors)
        {
            List<string> test = new List<string>();
            string t0 = "";
            string t1 = "";
            string t2 = "";
            string t3 = "";
            string t4 = "";
            string t5 = "";
            string t6 = "";
            string t7 = "";
            string t8 = "";
            string t9 = "";

            for (int i = 0; i < numberOfFloors; i++)
            {

            }
            for (int i = numberOfFloors; numberOfFloors < numberOfFloors * 2; i++)
            {

            }
            for (int i = numberOfFloors * 2; numberOfFloors * 2 < numberOfFloors * 3; i++)
            {

            }
            for (int i = numberOfFloors * 3; numberOfFloors * 3 < numberOfFloors * 4; i++)
            {

            }
            for (int i = numberOfFloors * 4; numberOfFloors * 4 < numberOfFloors * 5; i++)
            {

            }
        }

    }
}
