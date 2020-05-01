using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGODS_Projekt
{
    class CsvParser
    {
        int currIndex;
        public CsvParser()
        {
            currIndex = 0;
        }

        // Implementera så att listan fortsätts att läsas efter första 10, men att den ska pausa eller liknande efter varje "numberOfFloors"
        public List<Person> ParseCsv_T0_ListOfPerson(string pathToFile, int numberOfFloors = 10)
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
                                else if (char.GetNumericValue(item) != -1)
                                {
                                    Person person = new Person(floorCounter, Convert.ToInt32(char.GetNumericValue(item)));
                                    personList.Add(person);
                                }
                                currIndex = line.IndexOf(item);
                            }
                            floorCounter++;
                        }
                    }
                    return personList;
                }
            }

            catch (Exception)
            {
                MessageBox.Show("The file could not be read!");
                return null;
            }
        }

        public List<string> ParseCsvReadAllLines(string pathToFile)
        {
            List<string> allText = File.ReadAllLines(pathToFile).ToList();
            List<string> parsedText = new List<string>();
            for (int i = 0; i < allText.Count; i++)
            {
                parsedText.Add(allText[i]);
            }

            return parsedText;
        }

        public string[] ParseCsvToArray(string pathToFile)
        {
            string[] arrOfText = File.ReadAllText(pathToFile).Split('\n');
            string[] fixedArr = arrOfText.Select(x => x.Replace("-1", "")).ToArray();
            return fixedArr;
        }
    }


}
