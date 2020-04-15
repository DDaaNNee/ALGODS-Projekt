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
        BindingSource binding;

        private void Form1_Load(object sender, EventArgs e)
        {
            csvParser = new CsvParser();
            elevator = new Elevator();
            building = new Building(elevator);
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
            string rowInListbox = "";
            binding = new BindingSource();
            binding.DataSource = building.UpdateInformation();
            listBox1.DataSource = binding;

            if (cb_numOfFloors.SelectedItem != null)
            {
                building.CreateFloor(csvParser.ParseCsv(path, Convert.ToInt32(cb_numOfFloors.SelectedItem)));
            }
            else
            {
                building.CreateFloor(csvParser.ParseCsv(path));
            }           

            foreach (Person p in elevator.GetCurrentPassagers())
            {
                listBox2.Items.Add(p.End_floor);
            }

            building.StartElevator();
        }

        public void UpdateLists()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(building.UpdateInformation());
        }
    }
}
