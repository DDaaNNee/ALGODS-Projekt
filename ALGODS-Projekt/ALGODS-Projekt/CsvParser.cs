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
        public List<Person> ParseCsvToListOfPerson(string pathToFile, int numberOfFloors = 10)
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
                            //Problemet just nu: chars läses bara av som ett värde, dvs "-1" blir "1", vilket gör att den lägger till
                            //de tomma våningarna i personList.
                            foreach (var item in line)
                            {
                                int itemIndex = 0;
                                itemIndex = line.IndexOf(item);
                                // Fungerar inte alls som tänkt
                                if (line[itemIndex].ToString() == "-" && line[itemIndex + 1].ToString() == "1")
                                {
                                    continue;
                                }
                                else if (char.GetNumericValue(item) != -1 /*&& item !=  '-'*/)
                                {
                                    Person person = new Person(floorCounter, Convert.ToInt32(char.GetNumericValue(item)));
                                    personList.Add(person);
                                }
                            }
                            floorCounter++;
                        }
                     }
                    return personList;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("The file could not be read!");
                throw;
            }
        }

        public string ParseCsvToString(string pathToFile, int numberOfFloors = 10)
        {
            using (var reader = new StreamReader(pathToFile))
            {
                string allText = reader.ReadToEnd();
                return allText;
            }
        }

        public string EditText(string parcedCsvToString)
        {
            string fixedText = "";
            foreach (char item in parcedCsvToString)
            {
                if (item.ToString() != "-1")
                {
                    fixedText += item;
                }
            }
            return fixedText;
        }

        public List<Person> TestEdit(List<Person> pList)
        {
            List<Person> editedpList = new List<Person>();

            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].End_floor.ToString() == "-" || pList[i].End_floor.ToString()[0] != '-')
                {
                    i++;
                }
                else
                {
                    editedpList.Add(pList[i]);
                }
            }
            return editedpList;
        }
    }
}
