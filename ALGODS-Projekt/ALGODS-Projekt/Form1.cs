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

namespace ALGODS_Projekt // Gruppmedlemmar: Daniel Pettersson, Nils Nyrén, Kaspar Visnapuu, Lowe Ekström, Mattias Holmström, Vilgot Holdar
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
        List<Person> listOfPeopleToFloor;
        string path;
        System.Timers.Timer testTimer = new System.Timers.Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            HideAfterRunningLabels();
            HideWhileRunningLabels();
            ShowBeforeRunning();
            csvParser = new CsvParser();
            listOfPeopleToFloor = new List<Person>();

            //testTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnStartElevator);
            //testTimer.Interval = 5000;

            for (int i = 1; i <= 50; i++)
            {
                cb_numOfFloors.Items.Add(i);
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            try
            {
                HideBeforeRunning();
                ShowWhileRunningLabels();
                lb_PeopleOnFloors.Items.Clear();
                OpenFileDialog openFileDiag = new OpenFileDialog();
                DialogResult result = openFileDiag.ShowDialog();
                path = openFileDiag.FileName;

                building = new Building();
                building.CreateTenFloors();
                elevator = new Elevator(building.GetFloors());

                csvParser.ParseCsvToArray(path);

                //foreach (string item in building.UpdateInformation())
                //{
                //    lb_PeopleOnFloors.Items.Add(item);
                //}

                //testTimer.Enabled = true;
                //lbl_CurrentFloorNumber_UPDATE.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
                //lbl_ElevatorState_UPDATE.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
                //lbl_ElapsedTime_UPDATE.Text = elevator.GetElevatorRuntime().ToString();

                //string currentPeople = "";
                //foreach (Person p in elevator.GetCurrentPassagers())
                //{
                //    currentPeople += p.End_floor + ", ";
                //}
                //lb_PeopleInElevator.Items.Add(currentPeople);
            }
            catch (NullReferenceException)
            {
                //Application.Restart();
                //Environment.Exit(0);
            }
        }

        public void OnStartElevator(object source, ElapsedEventArgs e)
        {
            ChangeLabels();
        }

        public void ChangeLabels()
        {
            lbl_CurrentFloorNumber_UPDATE.Text = elevator.GetCurrentFloor().ToString();
            lbl_ElevatorState_UPDATE.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime_UPDATE.Text = elevator.GetElevatorRuntime().ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //building.StartElevator(elevator);
            //lbl_CurrentFloorNumber_UPDATE.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
            //lbl_ElevatorState_UPDATE.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            //lbl_ElapsedTime_UPDATE.Text = elevator.GetElevatorRuntime().ToString();
            //lb_PeopleOnFloors.Items.Clear();
            //building.PopulateFloors(csvParser.GetCurrentTimeParsedListPerson(csvParser.ParseCsvToArray(path)));
            //foreach (string item in building.UpdateInformation())
            //{
            //    lb_PeopleOnFloors.Items.Add(item);
            //}
            //lb_PeopleInElevator.Items.Clear();

            lb_PeopleOnFloors.Items.Clear();
            lb_PeopleInElevator.Items.Clear();

            building.StartElevator(elevator);
            building.PopulateFloors(csvParser.GetCurrentTimeParsedListPerson());

            //if (building.CheckIfSimulationCompleted() == true)
            //{
            //    MessageBox.Show("Simulation complete!");
            //    HideWhileRunningLabels();
            //    ShowAfterRunningLabels();
            //}

            foreach (Floor f in building.GetFloors())
            {
                string text = "";
                if (f.GetPeopleOnFloor().Count > 0)
                {
                    foreach (Person p in f.GetPeopleOnFloor())
                    {
                        text += p.End_floor + ", ";
                    }
                }
                else
                {
                    text += " ";
                }
                text += "\n";
                lb_PeopleOnFloors.Items.Add(text);
            }

            testTimer.Enabled = true;
            lbl_CurrentFloorNumber_UPDATE.Text = elevator.GetCurrentFloor().ToString();
            lbl_ElevatorState_UPDATE.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime_UPDATE.Text = elevator.GetElevatorRuntime().ToString();

            string currentPeople = "";
            foreach (Person p in elevator.GetCurrentPassagers())
            {
                currentPeople += p.End_floor + ", ";
            }
            lb_PeopleInElevator.Items.Add(currentPeople);
        }
         


        public void HideAfterRunningLabels()
        {
            lbl_TotalNumOfPassengers.Hide();
            lbl_TotalNumOfPassengers_UPDATE.Hide();
            lbl_TotalTime.Hide();
            lbl_TotalTime_UPDATE.Hide();
            lbl_AverageWaitTime.Hide();
            lbl_AverageWaitTime_UPDATE.Hide();
            lbl_AverageCompTime.Hide();
            lbl_AverageCompTime_UPDATE.Hide();
            lbl_LeastTimeTaken.Hide();
            lbl_LeastTimeTaken_UPDATE.Hide();
            lbl_HighestTimeTaken.Hide();
            lbl_HighestTimeTaken_UPDATE.Hide();
        }

        public void ShowAfterRunningLabels()
        {
            lbl_TotalNumOfPassengers.Show();
            lbl_TotalNumOfPassengers_UPDATE.Show();
            lbl_TotalTime.Show();
            lbl_TotalTime_UPDATE.Show();
            lbl_AverageWaitTime.Show();
            lbl_AverageWaitTime_UPDATE.Show();
            lbl_AverageCompTime.Show();
            lbl_AverageCompTime_UPDATE.Show();
            lbl_LeastTimeTaken.Show();
            lbl_LeastTimeTaken_UPDATE.Show();
            lbl_HighestTimeTaken.Show();
            lbl_HighestTimeTaken_UPDATE.Show();
        }

        public void HideWhileRunningLabels()
        {
            lbl_PeopleInElevator.Hide();
            lbl_PeopleOnFloors.Hide();
            lb_PeopleInElevator.Hide();
            lb_PeopleOnFloors.Hide();
            lbl_CurrentFloorNumber.Hide();
            lbl_CurrentFloorNumber_UPDATE.Hide();
            lbl_ElevatorState.Hide();
            lbl_ElevatorState_UPDATE.Hide();
            lbl_ElapsedTime.Hide();
            lbl_ElapsedTime_UPDATE.Hide();
        }

        public void ShowWhileRunningLabels()
        {
            lbl_PeopleInElevator.Show();
            lbl_PeopleOnFloors.Show();
            lb_PeopleInElevator.Show();
            lb_PeopleOnFloors.Show();
            lb_PeopleInElevator.Show();
            lb_PeopleOnFloors.Show();
            lbl_CurrentFloorNumber.Show();
            lbl_CurrentFloorNumber_UPDATE.Show();
            lbl_ElevatorState.Show();
            lbl_ElevatorState_UPDATE.Show();
            lbl_ElapsedTime.Show();
            lbl_ElapsedTime_UPDATE.Show();
        }

        public void ShowBeforeRunning()
        {
            lbl_PeopleInElevator.Hide();
            lbl_PeopleOnFloors.Hide();
            lb_PeopleInElevator.Hide();
            lb_PeopleOnFloors.Hide();
            lbl_ChooseNumOfFloors.Show();
            cb_numOfFloors.Show();
        }

        public void HideBeforeRunning()
        {
            lbl_ChooseNumOfFloors.Hide();
            cb_numOfFloors.Hide();
        }
    }
}
