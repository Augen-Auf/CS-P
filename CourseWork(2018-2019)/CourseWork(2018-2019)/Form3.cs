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
	public partial class Form3 : Form
	{
		int[] kodTour = new int[0];
		string[] tour = new string[0];
		int[] cost = new int[0];
		char[] d = { '#' };
		int kT = 0;
		int newStr = 0;
		public Form3()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Form3_Load(object sender, EventArgs e)
		{
			LoadTour();
			DataGV();
		}
		private void LoadTour()
		{
			string[] typeOfTour = File.ReadAllLines("tour.txt", Encoding.GetEncoding(1251));
			kT = typeOfTour.Length;
			Array.Resize(ref kodTour, kT);
			Array.Resize(ref tour, kT);
			Array.Resize(ref cost, kT);
			for (int i = 0; i < kT; i++)
			{
				string[] splitTour = typeOfTour[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
				kodTour[i] = int.Parse(splitTour[0]);
				tour[i] = splitTour[1];
				cost[i] = int.Parse(splitTour[2]);

			}
		}
		private void DataGV()
		{
			dataGridView1.Rows.Clear();
			for (int i = 0; i < kT; i++)
			{
				dataGridView1.Rows.Add(kodTour[i], tour[i], cost[i]);
			}
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
            }
            catch { }
		}

		private void button1_Click(object sender, EventArgs e)
		{
            dataGridView1.Rows[newStr].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[newStr].Cells[2].Value = textBox3.Text;
        }

		private void button2_Click(object sender, EventArgs e)
		{
            int newKTour = dataGridView1.RowCount + 1;
            string newTypeOfTour = textBox2.Text;
            int newDays = int.Parse(textBox3.Text);
            textBox1.Text = newKTour.ToString();
            dataGridView1.Rows.Add(newKTour, newTypeOfTour, newDays);
        }

		private void button3_Click(object sender, EventArgs e)
		{
            int countStr = dataGridView1.Rows.Count;
            string[] saveTour = new string[countStr];
            for (int i = 0; i < countStr; i++)
                for (int j = 0; j < 3; j++)
                    saveTour[i] += dataGridView1.Rows[i].Cells[j].Value + "#"; File.WriteAllLines("tour.txt", saveTour, Encoding.GetEncoding(1251));
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
