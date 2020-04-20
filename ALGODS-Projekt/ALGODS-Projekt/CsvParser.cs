﻿using System;
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
                    string isSkip = "0";

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (floorCounter < numberOfFloors)
                        {
                            foreach (var item in line)
                            { 
                                int itemIndex = itemIndex = line.IndexOf(item);
                                string itemToString = item.ToString();
                                if (line[itemIndex].ToString() == "-")
                                {
                                    isSkip = "1";
                                    continue;

                                }
                                else if (isSkip == "1")
                                {
                                    isSkip = "0";
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

        public string[] ParseCsvToString(string pathToFile, int numberOfFloors = 10)
        {
            using (var reader = new StreamReader(pathToFile))
            {
                string[] allText = File.ReadAllLines(pathToFile);
                string[] fixedText = new string[allText.Count()];
                int arrIndex = 0;
                int floorCounter = 0;
                string isSkip = "0";

                foreach (string line in allText)
                {
                    if (floorCounter < numberOfFloors)
                    {
                        foreach (var item in line)
                        {
                            int itemIndex = itemIndex = line.IndexOf(item);
                            string itemToString = item.ToString();
                            if (line[itemIndex].ToString() == "-")
                            {
                                isSkip = "1";
                                continue;

                            }
                            else if (isSkip == "1")
                            {
                                isSkip = "0";
                                continue;

                            }
                            else if (char.GetNumericValue(item) != -1)
                            {
                                Person person = new Person(floorCounter, Convert.ToInt32(char.GetNumericValue(item)));
                                fixedText[arrIndex] = item.ToString();
                                arrIndex++;
                            }
                        }
                        floorCounter++;
                    }
                    
                }
                return fixedText;
            }
        }

        // {5, 2, 3, 5, 2
        //  2, 7, 9, 5}
        public string[] SplitCsvToString(string[] parsedCsvToString)
        {

        }
    }
}
