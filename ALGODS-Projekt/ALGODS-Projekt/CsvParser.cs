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

        public List<Person> ParseCsv(string pathToFile)
        {
            List<Person> personList = new List<Person>();
            try
            {
                //string path = "@" + pathToFile;
                //@"C:/Users/Danne/Desktop/Book1.csv"
                using (var reader = new StreamReader(pathToFile))
                {
                    int floorCounter = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line.Trim();
                        foreach (var item in line)
                        {
                            if (char.GetNumericValue(item) != -1)
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
            catch (Exception)
            {
                Console.WriteLine("The file could not be read!");
                throw;
            }
        }
    }
}
