using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

            System.Timers.Timer testTimer = new System.Timers.Timer();
            testTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnStartElevator);
            testTimer.Interval = 5000;
            testTimer.Enabled = true;

            for (int i = 0; i < 100; i++)
            {
                cb_numOfFloors.Items.Add(i);
            }
        }

        // Denna metod behöver sannolikt felhantering
        // Implementera loop för att uppdatera listbox1 & 2
        private void btn_play_Click(object sender, EventArgs e)
        {
            lb_PeopleOnFloors.Items.Clear();
            OpenFileDialog openFileDiag = new OpenFileDialog();
            DialogResult result = openFileDiag.ShowDialog();
            string path = openFileDiag.FileName;
            int selectedNumberOfFloors = Convert.ToInt32(cb_numOfFloors.SelectedItem);
            
            //if (selectedNumberOfFloors != 0)
            //{
            //    elevator = new Elevator(selectedNumberOfFloors);
            //    building.CreateFloor(csvParser.ParseCsvToListOfPerson(path, selectedNumberOfFloors));
            //}
            //else
            //{
            //    elevator = new Elevator();
            //    building.CreateFloor(csvParser.ParseCsvToListOfPerson(path));
            //}

            if (selectedNumberOfFloors != 0)
            {
                building = new Building();
                building.CreateFloor(csvParser.ParseCsvToListOfPerson(path, selectedNumberOfFloors));
            }
            else
            {
                building = new Building();
                building.CreateFloor(csvParser.ParseCsvToListOfPerson(path));
            }

            foreach (string item in building.UpdateInformation())
            {
                lb_PeopleOnFloors.Items.Add(item);
            }


            building.StartElevator();
            lbl_CurrentFloorNumber.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
            lbl_ElevatorState.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime.Text = elevator.GetElevatorRuntime().ToString();

            string test = "";
            foreach (Person p in elevator.GetCurrentFloor().GetPeopleOnFloor())
            {
                test += p.End_floor;
            }
            MessageBox.Show(test);
        }

        public void OnStartElevator(object source, ElapsedEventArgs e)
        {

        }
    }
}
