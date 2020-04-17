using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    class CsvParser
    {
        public CsvParser()
        {

        }

        // Implementera så att listan fortsätts att läsas efter första 10, men att den ska pausa eller liknande efter varje "numberOfFloors"
        public List<Person> ParseCsv(string pathToFile, int numberOfFloors = 10)
        {
            List<Person> personList = new List<Person>();
            try
            {
                using (var reader = new StreamReader(pathToFile))
                {
                    int floorCounter = 0;
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (floorCounter < numberOfFloors)
                        {
                            line.Trim();
                            foreach (var item in line)
                            {
                                // Problemet just nu: chars läses bara av som ett värde, dvs "-1" blir "1", vilket gör att den lägger till
                                // de tomma våningarna i personList.
                                /*int val = (int)char.GetNumericValue(item);*/
                                if (/*val != -1*/(int)Char.GetNumericValue(item) == -1)
                                {
                                    Person person = new Person(floorCounter, item);
                                    personList.Add(person);
                                }
                            }
                            floorCounter++;
                        }
                    }
                    //while ((line = reader.ReadLine()) != null)
                    //{
                    //    if (floorCounter < numberOfFloors)
                    //    {
                    //        for (int i = 0; i < line.Length; i++)
                    //        {
                    //            if ((int)Char.GetNumericValue(line[i]) == -1)
                    //            {
                    //                i += 1;
                    //            }
                    //            else
                    //            {
                    //                Person person = new Person(floorCounter, (int)Char.GetNumericValue(line[i]));
                    //                personList.Add(person);
                    //            }
                    //        }
                    //        floorCounter++;

                    //    }
                    //}
                }
                return personList;
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read!");
                throw;
            }
        }
    }
}
