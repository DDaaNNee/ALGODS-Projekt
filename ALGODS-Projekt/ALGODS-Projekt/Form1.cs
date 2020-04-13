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
                    int counter = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line.Trim();
                        TEST_READ_FROM_FILE.Text = line;
                        //listBox1.Items.Add("Floor " + counter.ToString() + ": " + line);

                        //foreach (var item in line)
                        //{
                        //    if (item != -1 && string.IsNullOrEmpty(item.ToString()) == false)
                        //    {
                        //        Person person = new Person(counter, /*Convert.ToInt32(line[stringCounter])*/ 5);
                        //        personList.Add(person);
                        //    }
                        //}

                        for (int i = 0; i < line.Length; i++)
                        {
                            int test = Convert.ToInt32(line[i]);
                            Person person = new Person(counter, Convert.ToInt32(line[i]));
                            personList.Add(person);
                        }

                        counter++;
                    }

                    foreach (Person p in personList)
                    {
                        listBox1.Items.Add("(Start floor: " + p.Start_floor + ", End floor: " + p.End_floor + ")");
                    }

                    TOTAL_LINES.Text = ("Total number of rows: " + counter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read!");
                throw;
            }
            


        }
    }
}
