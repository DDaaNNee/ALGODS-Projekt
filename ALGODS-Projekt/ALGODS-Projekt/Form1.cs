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
        private void btn_play_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OpenFileDialog openFileDiag = new OpenFileDialog();
            DialogResult result = openFileDiag.ShowDialog();
            string path = openFileDiag.FileName;
            string rowInListbox;

            building.CreateFloor(csvParser.ParseCsv(path));

            foreach (Floor f in building.GetFloors())
            {
                rowInListbox = "";
                listBox1.Items.Add("Floor " + f.GetFloorNumber());

                foreach (Person p in f.GetPeopleOnFloor())
                {
                    if (p == f.GetPeopleOnFloor().Last())
                    {
                        rowInListbox += p.End_floor;
                    }
                    else
                    {
                        rowInListbox += p.End_floor + ", ";
                    }
                }
                listBox1.Items.Add(rowInListbox);
            }
        }
    }
}
