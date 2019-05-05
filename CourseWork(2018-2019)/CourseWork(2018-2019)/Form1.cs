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
    public partial class Form1 : Form
    {
        int[] kodTravel = new int[0];
        int[] amountTour = new int[0];
        int[] kClient = new int[0];
        int[] kTour = new int[0];
        string[] dateS = new string[0];
        char[] d = { '#' };
        int kTravel = 0;
        int newStr = 0;
        public Form1()
        {
            InitializeComponent();
        }
		private void Form1_Load(object sender, EventArgs e)
		{
            LoadTravel();
            DataGV();
        }
		private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.ShowDialog();
        }
		private void button2_Click(object sender, EventArgs e)
		{
			Form form3 = new Form3();
			form3.ShowDialog();
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
            for (int i = 0; i < kTravel; i++)
            {
                string[] splitTravel = travel[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kodTravel[i] = int.Parse(splitTravel[0]);
                kClient[i] = int.Parse(splitTravel[1]);
                kTour[i] = int.Parse(splitTravel[2]);
                dateS[i] = splitTravel[3];
                amountTour[i] = int.Parse(splitTravel[4]);
            }
        }
        private void DataGV()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < kTravel; i++)
            {
                dataGridView1.Rows.Add(kodTravel[i], kClient[i],kTour[i],dateS[i],amountTour[i]);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//Изменить
        {
            dateS[newStr] = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            amountTour[newStr] = int.Parse(textBox4.Text);
            DataGV();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                newStr = dataGridView1.CurrentRow.Index;
                string indexStr = (newStr + 1).ToString();
                dataGridView1.Rows[newStr].Cells[0].Value = indexStr;
                textBox1.Text = dataGridView1.Rows[newStr].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[newStr].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[newStr].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[newStr].Cells[4].Value.ToString();
                
            }
            catch { }
        }
    }
}
