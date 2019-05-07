using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork_2018_2019_
{
    public partial class Form4 : Form
    {
        int[] kodTravel = new int[0];
        int[] amountTour = new int[0];
        int[] kClient = new int[0];
        int[] kTour = new int[0];
        string[] dateS = new string[0];
        string[] typeOfTour= new string[0];
        char[] d = { '#' };
        int kTravel = 0;
        int newStr = 0;
        string[] fio = new string[0];
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadTravel();
            DataGV();
        }
        private void LoadTravel()
        {
            string[] travel = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            kTravel = travel.Length;
            Array.Resize(ref kodTravel, kTravel);
            Array.Resize(ref kClient, kTravel);
            Array.Resize(ref kTour, kTravel);
            Array.Resize(ref dateS, kTravel);
            Array.Resize(ref amountTour, kTravel);
            Array.Resize(ref fio, kTravel);
            Array.Resize(ref typeOfTour, kTravel);
            for (int i = 0; i < kTravel; i++)
            {
                string[] splitTravel = travel[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kodTravel[i] = int.Parse(splitTravel[0]);
                kClient[i] = int.Parse(splitTravel[1]);
                fio[i] = splitTravel[2];
                kTour[i] = int.Parse(splitTravel[3]);
                typeOfTour[i] = splitTravel[4];
                dateS[i] = splitTravel[5];
                amountTour[i] = int.Parse(splitTravel[6]);
            }
        }
        private void DataGV()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < kTravel; i++)
            {
                int num = Array.IndexOf(kClient, kClient[i]);
                string surname = fio[num];
                num = Array.IndexOf(kTour, kTour[i]);
                string tour = typeOfTour[num];
                dataGridView2.Rows.Add(kodTravel[i], kClient[i],surname, kTour[i],tour, dateS[i], amountTour[i]);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                newStr = dataGridView2.CurrentRow.Index;
                string indexStr = (newStr + 1).ToString();
                dataGridView2.Rows[newStr].Cells[0].Value = indexStr;
                textBox1.Text = dataGridView2.Rows[newStr].Cells[0].Value.ToString();
                textBox2.Text = dataGridView2.Rows[newStr].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.Rows[newStr].Cells[2].Value.ToString();
                textBox4.Text = dataGridView2.Rows[newStr].Cells[4].Value.ToString();

            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateS[newStr] = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            amountTour[newStr] = int.Parse(textBox4.Text);
            DataGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
