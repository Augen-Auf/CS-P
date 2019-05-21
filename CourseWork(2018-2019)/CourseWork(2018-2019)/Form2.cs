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
    public partial class Form2 : Form
    {
        int[] kodClient = new int[0];
        string[] fio = new string[0];
        char[] d = { '#' };
        int kC = 0;
        int newStr = 0;
        int indexStr = 0;
        int amountOfRows = 0;
        public Form2()
        {
            InitializeComponent();
        }
		private void Form2_Load_1(object sender, EventArgs e)
		{
			LoadClient();
			DataGV();
		}
		private void LoadClient()
        {
            string[] client = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            kC = client.Length;
            Array.Resize(ref kodClient, kC);
            Array.Resize(ref fio, kC);
            for(int i = 0;i < kC;i++)
            {
                string[] splitClient = client[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kodClient[i] = int.Parse(splitClient[0]);
                fio[i] = splitClient[1];
            }
        }
        private void DataGV()
        {
            dataGridView1.Rows.Clear();
            for (int i=0; i < kC;i++)
            {
                dataGridView1.Rows.Add(kodClient[i], fio[i]);
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                newStr = dataGridView1.CurrentRow.Index;
                indexStr = newStr + 1;
                dataGridView1.Rows[newStr].Cells[0].Value = indexStr;
                textBox1.Text = dataGridView1.Rows[newStr].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[newStr].Cells[1].Value.ToString();
            }
            catch { }
		}
		private void button1_Click(object sender, EventArgs e) //Изменить
        {
            dataGridView1.Rows[newStr].Cells[1].Value = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e) //Добавить
        {
            int newKClient = dataGridView1.RowCount + 1;
            string newFio = textBox2.Text;
            textBox1.Text = newKClient.ToString();
            dataGridView1.Rows.Add(newKClient,newFio);
        }

        private void button3_Click(object sender, EventArgs e) //Сохранить
        {
            int countStr = dataGridView1.Rows.Count;//Считает количество строк
            string[] saveClient = new string[countStr];
            string[] saveOutClient = new string[countStr];
            for (int i = 0; i < countStr; i++)
            {
                //saveOutClient[1] += dataGridView1.Rows[i].Cells[0].Value + "#" +"\n"; File.WriteAllLines("travel.txt", saveOutClient, Encoding.GetEncoding(1251));
                for (int j = 0; j < 2; j++)
                {
                    saveClient[i] += dataGridView1.Rows[i].Cells[j].Value + "#"; File.WriteAllLines("client.txt", saveClient, Encoding.GetEncoding(1251));
                }
            }
            MessageBox.Show("Данные успешно сохранены!");
        }
        private void button4_Click(object sender, EventArgs e) //Удалить
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
