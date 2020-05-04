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
        List<string> currentList;
        List<Person> listPerson;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public CsvParser()
        {
        }

        /// <summary>
        /// Reads a selected text file and stores it's information in an array of strings.
        /// This array then gets edited in order to remove incorrect values and saved as a new string array.
        /// </summary>
        /// <param name="pathToFile">The path to our selected file.</param>
        public void ParseTextToArray(string pathToFile)
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

        /// <summary>
        /// Method that uses the already parsed text, saved as a "List<String> currentList" variable, then copies the first ten values into a new "List<string> currentTimeList".
        /// We then remove the first ten values from the stored in currentList in order to not input the same values multiple times.
        /// After that, the method checks for punctuation, this includes commas, or "r", which indicates a new row, and skips adding these values to the "List<Person> listPerson",
        /// which our method returns upon executing. Also checks if the persons end floor is the same as their starting floor, 
        /// and if that is the case, skips adding them into our person list "listPerson".
        /// </summary>
        /// <returns>List<Person> containing all of our specified times people. Ex: At T0, our method will return a list of people waiting for the elevator at any floor, at T0. </returns>
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
                        else if (i != Convert.ToInt32(char.GetNumericValue(c)))
                        {
                            int test = Convert.ToInt32(char.GetNumericValue(c));
                            if (test != -1)
                            {
                                listPerson.Add(new Person(i, test));
                            }
                            else
                            {
                                throw new InvalidDataException();
                            }
                            
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return listPerson;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("The file contains invalid data, please try again!");
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// </summary>
        /// <returns>Returns our currentList variable</returns>
        public List<string> GetCurrList()
        {
            return currentList;
        }

        /// <summary>
        /// </summary>
        /// <returns>Returns our listPerson variable</returns>
        public List<Person> GetListPerson()
        {
            return listPerson;
        }
    }


}
