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

        CsvParser csvParser;
        Building building;
        Elevator elevator;

        private void Form1_Load(object sender, EventArgs e)
        {
            csvParser = new CsvParser();
            building = new Building();
            for (int i = 0; i < 100; i++)
            {
                cb_numOfFloors.Items.Add(i);
            }
        }

        // Denna metod behöver sannolikt felhantering
        // Implementera loop för att uppdatera listbox1 & 2
        private void btn_play_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OpenFileDialog openFileDiag = new OpenFileDialog();
            DialogResult result = openFileDiag.ShowDialog();
            string path = openFileDiag.FileName;
            
            if (cb_numOfFloors.SelectedItem != null)
            {
                elevator = new Elevator(Convert.ToInt32(cb_numOfFloors.SelectedItem));
            }
            else
            {
                elevator = new Elevator();
            }

            building.CreateFloor(csvParser.ParseCsv(path));

            listBox1.Items.Add(building.UpdateInformation());
            foreach (string item in building.UpdateInformation())
            {
                listBox1.Items.Add(item);
            }

            //foreach (Floor f in building.GetFloors())
            //{
            //    listBox1.Items.Add("Floor:" f.GetFloorNumber());
            //    foreach (Person p in f.GetPeopleOnFloor())
            //    {
            //        listBox1.Items.Add(p.End_floor);
            //    }
            //}

            foreach (Person p in elevator.GetCurrentPassagers())
            {
                listBox2.Items.Add(p.End_floor);
            }

            //building.StartElevator();

            //UpdateLists();
        }

        public void UpdateLists()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(building.UpdateInformation());
        }
    }
}
