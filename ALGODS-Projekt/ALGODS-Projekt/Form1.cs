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
        List<Person> t0;
        System.Timers.Timer testTimer = new System.Timers.Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            csvParser = new CsvParser();
            testTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnStartElevator);
            testTimer.Interval = 5000;
            

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

            // Problem med att newfloor inte faktiskt är våning noll?
            if (selectedNumberOfFloors != 0)
            {
                t0 = csvParser.ParseCsv_T0_ListOfPerson(path, selectedNumberOfFloors);
                building = new Building();
                building.CreateFloor(t0);
                elevator = new Elevator(building.GetFloors());
            }
            else
            {
                t0 = csvParser.ParseCsv_T0_ListOfPerson(path);
                building = new Building();
                building.CreateFloor(t0);
                elevator = new Elevator(building.GetFloors());
            }

            foreach (string item in building.UpdateInformation())
            {
                lb_PeopleOnFloors.Items.Add(item);
            }

            string test = "";


            string currentPeople = "";
            foreach (Person p in elevator.GetCurrentPassagers())
            {
                currentPeople += p.End_floor + ", ";
            }
            lb_PeopleInElevator.Items.Add(currentPeople);

            testTimer.Enabled = true;
            //building.StartElevator(elevator);
            lbl_CurrentFloorNumber.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
            lbl_ElevatorState.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime.Text = elevator.GetElevatorRuntime().ToString();

            //string test = "";
            //foreach (Person p in elevator.GetCurrentFloor().GetPeopleOnFloor())
            //{
            //    test += p.End_floor;
            //}
            //MessageBox.Show(test);
        }

        public void OnStartElevator(object source, ElapsedEventArgs e)
        {
            ChangeLabels();
        }

        public void ChangeLabels()
        {
            lbl_CurrentFloorNumber.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
            lbl_ElevatorState.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime.Text = elevator.GetElevatorRuntime().ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool peopleLeft = building.CheckIfPeopleWaiting();
            testTimer.Enabled = true;
            lbl_CurrentFloorNumber.Text = elevator.GetCurrentFloor().GetFloorNumber().ToString();
            lbl_ElevatorState.Text = "Going " + elevator.GetCurrentElevatorDirection().ToString();
            lbl_ElapsedTime.Text = elevator.GetElevatorRuntime().ToString();
            AddPeopleFromFloor();

            if (elevator.GetCurrentFloor().GetFloorNumber() == 10 - 1)
            {
                elevator.MoveElevator(Direction.DirectionEnum.Down);
            }
            else /*if (elevator.GetCurrentFloor().GetFloorNumber() == 0)*/
            {
                elevator.MoveElevator(Direction.DirectionEnum.Up);
            }

            elevator.IncreaseSystemTime();
            building.IncreaseWaitTime();
            peopleLeft = building.CheckIfPeopleWaiting();
        }

        public void AddPeopleFromFloor()
        {
            foreach (Person p in elevator.GetCurrentFloor().GetPeopleOnFloor())
            {
                elevator.AddPersonToElevator(p);

            }
        }
    }
}
