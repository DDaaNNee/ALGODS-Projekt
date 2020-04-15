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
                                if (char.GetNumericValue(item) != -1)
                                {
                                    Person person = new Person(floorCounter, Convert.ToInt32(char.GetNumericValue(item)));
                                    personList.Add(person);
                                }
                            }
                            floorCounter++;
                        }
                    }
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
