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

        private void Form1_Load(object sender, EventArgs e)
        {
            csvParser = new CsvParser();
        }

        // Denna metod behöver sannolikt felhantering
        private void btn_play_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OpenFileDialog openFileDiag = new OpenFileDialog();
            DialogResult result = openFileDiag.ShowDialog();
            string path = openFileDiag.FileName;

            // Placeholder tills att vi har fixat så att vi får data via Floor-klassen som säger vilka Person vi har på varje floor.
            try
            {
                foreach (Person p in csvParser.ParseCsv(path))
                {
                    listBox1.Items.Add("Floor " + p.Start_floor + ": " + p.End_floor);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid file path, please try again!");
                throw;
            }
        }
    }
}
