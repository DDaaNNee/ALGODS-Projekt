using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGODS_Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Person> personList;
        List<Floor> floorList;

        private void Form1_Load(object sender, EventArgs e)
        {
            personList = new List<Person>();
        }



        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btn_play_Click(object sender, EventArgs e)
        {

            try
            {
                using (var reader = new StreamReader(@"C:/Users/Danne/Desktop/Book1.csv"))
                {
                    int floorCounter = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line.Trim();
                        TEST_READ_FROM_FILE.Text = line;

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

                    foreach (Person p in personList)
                    {
                        listBox1.Items.Add(GetPeopleOnSameFloor(p));
                    }
                    TOTAL_LINES.Text = ("Total number of rows: " + floorCounter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read!");
                throw;
            }
        }

        public string GetPeopleOnSameFloor(Person person)
        {
            string test = "";
            List<Person> sameFloorPeople = new List<Person>();
            foreach (Person p in personList)
            {
                if (person.Start_floor == p.Start_floor)
                {
                    sameFloorPeople.Add(p);
                }
            }

            foreach (Person sameFloor in sameFloorPeople)
            {
                test = test + sameFloor.End_floor;
            }

            return "Floor " + person.Start_floor + " :" + test;
        }
    }
}
