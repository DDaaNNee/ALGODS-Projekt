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
        CsvParser csvParser;
        Building building;
        Elevator elevator;
        List<Person> listOfPeopleToFloor;
        string path;

        /// <summary>
        /// Form initialization
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideAfterRunningLabels();
            HideWhileRunningLabels();
            ShowBeforeRunning();
            csvParser = new CsvParser();
            listOfPeopleToFloor = new List<Person>();
            btn_RunThroughSim.Enabled = false;
            btn_StepByStep.Enabled = false;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            btn_RunThroughSim.Enabled = true;
            btn_StepByStep.Enabled = true;
            HideBeforeRunning();
            HideAfterRunningLabels();
            ShowWhileRunningLabels();
            lb_PeopleOnFloors.Items.Clear();
            OpenFileDialog openFileDiag = new OpenFileDialog();
            DialogResult result = openFileDiag.ShowDialog();
            path = openFileDiag.FileName;

            building = new Building();
            building.CreateTenFloors();
            elevator = new Elevator(building.GetFloors());

            csvParser.ParseTextToArray(path);
        }

        private void btn_RunThroughSim_Click(object sender, EventArgs e)
        {
            try
            {
                HideWhileRunningLabels();
                while (building.CheckIfSimulationCompleted() == false)
                {
                    lb_PeopleOnFloors.Items.Clear();
                    lb_PeopleInElevator.Items.Clear();

                    building.PopulateFloors(csvParser.GetCurrentTimeParsedListPerson());
                    building.StartElevator(elevator);

                    lbl_CurrentFloorNumber_UPDATE.Text = elevator.GetCurrentFloor().ToString();
                    lbl_ElevatorState_UPDATE.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
                    lbl_ElapsedTime_UPDATE.Text = elevator.GetElevatorRuntime().ToString();

                    lb_PeopleOnFloors.Items.Clear();
                    lb_PeopleInElevator.Items.Clear();
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
                    string currentPeople = "";
                    foreach (Person p in elevator.GetCurrentPassagers())
                    {
                        currentPeople += p.End_floor + ", ";
                    }
                    lb_PeopleInElevator.Items.Add(currentPeople);

                }
                btn_RunThroughSim.Enabled = false;
                btn_StepByStep.Enabled = false;
                MessageBox.Show("Simulation complete!");
                elevator.CalculateTotalTime();
                ShowAfterRunningLabels();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, please try again!");
            }
        }

        private void btn_StepByStep_Click(object sender, EventArgs e)
        {
            try
            {
                lb_PeopleOnFloors.Items.Clear();
                lb_PeopleInElevator.Items.Clear();

                building.PopulateFloors(csvParser.GetCurrentTimeParsedListPerson());
                building.StartElevator(elevator);

                lbl_ElevatorState_UPDATE.Text = elevator.GetCurrentElevatorDirection().ToString();

                if (building.CheckIfSimulationCompleted() == true)
                {
                    MessageBox.Show("Simulation complete!");
                    elevator.CalculateTotalTime();
                    HideWhileRunningLabels();
                    ShowAfterRunningLabels();
                }

                else
                {
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
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, please try again!");
            }
        }

        /// <summary>
        /// Changes all of the appropriate labels to the correct texts.
        /// </summary>
        #region Labels

        public void HideAfterRunningLabels()
        {
            lbl_PathToFile.Hide();
            lbl_PathToFile_UPDATE.Hide();
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
            lbl_PeopleWithLowestTotalTime.Hide();
            lbl_PeopleWithLowestTotalTime_UPDATE.Hide();
            lbl_HighestTimeTaken.Hide();
            lbl_HighestTimeTaken_UPDATE.Hide();
            lbl_PeopleWithHighestTotalTime.Hide();
            lbl_PeopleWithHighestTotalTime_UPDATE.Hide();
        }

        public void ShowAfterRunningLabels()
        {
            lbl_PathToFile.Show();
            lbl_PathToFile_UPDATE.Show();
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
            lbl_PeopleWithLowestTotalTime.Show();
            lbl_PeopleWithLowestTotalTime_UPDATE.Show();
            lbl_HighestTimeTaken.Show();
            lbl_HighestTimeTaken_UPDATE.Show();
            lbl_PeopleWithHighestTotalTime.Show();
            lbl_PeopleWithHighestTotalTime_UPDATE.Show();
            lbl_PathToFile_UPDATE.Text ="''" + path + "''";
            lbl_TotalNumOfPassengers_UPDATE.Text = elevator.CalculateTotalNumberOfPeople().ToString();
            lbl_AverageCompTime_UPDATE.Text = elevator.CalculateAverageCompletionTime().ToString();
            lbl_AverageWaitTime_UPDATE.Text = elevator.CalculateAverageWaitingTime().ToString();
            lbl_TotalTime_UPDATE.Text = (elevator.GetElevatorRuntime() + 10).ToString();
            lbl_LeastTimeTaken_UPDATE.Text = elevator.GetShortestCompletionTime().ToString();
            lbl_PeopleWithLowestTotalTime_UPDATE.Text = elevator.CountPeopleShortestTime().ToString();
            lbl_HighestTimeTaken_UPDATE.Text = elevator.GetLongestCompletionTime().ToString();
            lbl_PeopleWithHighestTotalTime_UPDATE.Text = elevator.CountPeopleLongestTime().ToString();
        }
        public void HideWhileRunningLabels()
        {
            lbl_floor0.Hide();
            lbl_floor1.Hide();
            lbl_floor2.Hide();
            lbl_floor3.Hide();
            lbl_floor4.Hide();
            lbl_floor5.Hide();
            lbl_floor6.Hide();
            lbl_floor7.Hide();
            lbl_floor8.Hide();
            lbl_floor9.Hide();
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
            lbl_floor0.Show();
            lbl_floor1.Show();
            lbl_floor2.Show();
            lbl_floor3.Show();
            lbl_floor4.Show();
            lbl_floor5.Show();
            lbl_floor6.Show();
            lbl_floor7.Show();
            lbl_floor8.Show();
            lbl_floor9.Show();
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
            lbl_floor0.Hide();
            lbl_floor1.Hide();
            lbl_floor2.Hide();
            lbl_floor3.Hide();
            lbl_floor4.Hide();
            lbl_floor5.Hide();
            lbl_floor6.Hide();
            lbl_floor7.Hide();
            lbl_floor8.Hide();
            lbl_floor9.Hide();
            lbl_PeopleInElevator.Hide();
            lbl_PeopleOnFloors.Hide();
            lb_PeopleInElevator.Hide();
            lb_PeopleOnFloors.Hide();
        }

        public void HideBeforeRunning()
        {
            lbl_floor0.Hide();
            lbl_floor1.Hide();
            lbl_floor2.Hide();
            lbl_floor3.Hide();
            lbl_floor4.Hide();
            lbl_floor5.Hide();
            lbl_floor6.Hide();
            lbl_floor7.Hide();
            lbl_floor8.Hide();
            lbl_floor9.Hide();
        }
        #endregion
    }
}
