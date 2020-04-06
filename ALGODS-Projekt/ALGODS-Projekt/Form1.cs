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

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> floorZero = new List<int>();
            List<int> floorOne = new List<int>();
            List<int> floorTwo = new List<int>();
            List<int> floorThree = new List<int>();
            List<int> floorFour = new List<int>();
            List<int> floorFive = new List<int>();
            List<int> floorSix = new List<int>();
            List<int> floorSeven = new List<int>();
            List<int> floorEight = new List<int>();
            List<int> floorNine = new List<int>();
        }



        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            //List<int> ListOfPeople = File.ReadAllLines("C:/Users/Danne/Desktop/Test.csv").ToList();

            var csvData = new DataTable();

            using (var reader = new StreamReader(@"C:/Users/Danne/Desktop/Test.csv"))
            {
                while(!reader.EndOfStream)
                {

                }
            }
        }
    }
}
