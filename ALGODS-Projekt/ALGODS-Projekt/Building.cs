using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class Building
    {

        public Building(Floor startingFloor)
        {
            elevator = new Elevator(startingFloor);
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
                    floor.AddPersonToFloor(p);
                }
                allFloors.Add(floor);
            }
        }

        public List<Floor> GetFloors()
        {
            return allFloors;
        }

        public List<int> SortFloorsByPeopleWaiting()
        {
            List<int> orderedFloorList = new List<int>();
            foreach (Floor f in allFloors)
            {
                orderedFloorList.Add(f.GetPeopleOnFloor().Count());
            }
            for (int i = 0; i < orderedFloorList.Count - 1; i++)
            {
                for (int j = 1; j < orderedFloorList.Count; j++)
                {
                    if (orderedFloorList[i] < orderedFloorList[j])
                    {
                        int temp = orderedFloorList[i];
                        orderedFloorList[i] = orderedFloorList[j];
                        orderedFloorList[j] = temp;
                    }
                }
            }
            return orderedFloorList;
            
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
                    elevator.GetCurrentFloor().RemovePersonFromFloor(pArriving);
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
        
        // Ett försök att manuellt försöka konvertera värderna i vår CSV-fil till hur det ser ut vid olika tidpunkter.
        public string SplitIntoTime(string allTimesFromCSV, int numberOfFloors)
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

            int numberOfLines = allTimesFromCSV.Count(x => x.Equals('\n')) + 1;

            if (numberOfLines >= 0)
            {
                for (int i = 0; i < numberOfFloors; i++)
                {
                    t0 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 2)
            {
                for (int i = numberOfFloors - 1; numberOfFloors < numberOfFloors * 2; i++)
                {
                    t1 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 3)
            {
                for (int i = (numberOfFloors * 2) - 1; numberOfFloors * 2 < numberOfFloors * 3; i++)
                {
                    t2 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 4)
            {
                for (int i = numberOfFloors * 3; numberOfFloors * 3 < numberOfFloors * 4; i++)
                {
                    t3 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 5)
            {
                for (int i = numberOfFloors * 4; numberOfFloors * 4 < numberOfFloors * 5; i++)
                {
                    t4 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 6)
            {
                for (int i = numberOfFloors * 5; numberOfFloors * 5 < numberOfFloors * 6; i++)
                {
                    t5 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 7)
            {
                for (int i = numberOfFloors * 6; numberOfFloors * 6 < numberOfFloors * 7; i++)
                {
                    t6 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 8)
            {
                for (int i = numberOfFloors * 7; numberOfFloors * 7 < numberOfFloors * 8; i++)
                {
                    t7 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 9)
            {
                for (int i = numberOfFloors * 8; numberOfFloors * 8 < numberOfFloors * 9; i++)
                {
                    t8 += allTimesFromCSV[i];
                }
            }
            if (numberOfLines >= numberOfFloors * 10)
            {
                for (int i = numberOfFloors * 9; numberOfFloors * 9 < numberOfFloors * 10; i++)
                {
                    t9 += allTimesFromCSV[i];
                }
            }

            return t0;


        }

    }
}
