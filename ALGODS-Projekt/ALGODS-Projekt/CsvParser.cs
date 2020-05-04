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
        List<string> currentList;
        List<Person> listPerson;
        public CsvParser()
        {
            currIndex = 0;
        }

        public void ParseCsvToArray(string pathToFile)
        {
            try
            {
                string[] arrOfText = File.ReadAllText(pathToFile).Split('\n');
                string[] fixedArr = arrOfText.Select(x => x.Replace("-1", "")).ToArray();
                currentList = fixedArr.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid file type!");
            }
        }

        public List<Person> GetCurrentTimeParsedListPerson()
        {
            try
            {
                listPerson = new List<Person>(10);
                List<string> currentTimeList = new List<string>();

                for (int j = 0; j < 10; j++)
                {
                    currentTimeList.Add(currentList[j]);
                }
                currentList.RemoveRange(0, 10);

                for (int i = 0; i < 10; i++)
                {
                    foreach (char c in currentTimeList[i])
                    {
                        if (char.IsPunctuation(c) == true || c.ToString() == "\r")
                        {
                            continue;
                        }
                        else
                        {
                            int test = Convert.ToInt32(char.GetNumericValue(c));
                            listPerson.Add(new Person(i, test));
                        }
                    }
                }
                currIndex += 10;
                return listPerson;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetCurrList()
        {
            return currentList;
        }

        public List<Person> GetListPerson()
        {
            return listPerson;
        }
    }


}
