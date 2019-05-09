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
        int[] costOfTour = new int[0];
        string[] kClient = new string[0];
        string[] kTour = new string[0];
        string[] typeOfTour = new string[0];
        char[] d = { '#' };
        int amountOfRows = 0;
        int newTravel = 1;
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
        }
        private void LoadTravel()
        {
            string[] client = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            string[] tour = File.ReadAllLines("tour.txt", Encoding.GetEncoding(1251));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            amountOfRows = client.Length;
            Array.Resize(ref kodTravel, amountOfRows);
            Array.Resize(ref kClient, amountOfRows);
            Array.Resize(ref kTour, amountOfRows);
            Array.Resize(ref fio, amountOfRows);
            Array.Resize(ref typeOfTour, amountOfRows);
            Array.Resize(ref amountTour, amountOfRows);
            Array.Resize(ref costOfTour, amountOfRows);
            textBox1.Text = newTravel.ToString();
            for (int i = 0; i < amountOfRows; i++)
            {
                string[] kodeCl = client[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                string[] kodeTour = tour[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kClient[i] = kodeCl[0];
                fio[i] = kodeCl[1];
                kTour[i] = kodeTour[0];
                typeOfTour[i] = kodeTour[1];
                comboBox1.Items.Add(kClient[i] + " " + fio[i]);
                comboBox2.Items.Add(kTour[i] + " " + typeOfTour[i]);
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
             try
             {
                 newStr = dataGridView2.CurrentRow.Index;
                 string indexStr = (newStr + 1).ToString();
                 int id = newStr + 1;
                // dataGridView2.Rows[newStr].Cells[0].Value = indexStr;
                 //textBox1.Text = dataGridView2.Rows[newStr].Cells[0].Value.ToString();
                //comboBox1.SelectedIndex = int.Parse(kClient[]);
                //string[] v = new string[5];
              // string v = kClient[id];
                //comboBox1.SelectedIndex = int.Parse(v);//comboBox2.Text = dataGridView2.Rows[newStr].Cells[3].Value.ToString();
                //textBox2.Text = dataGridView2.Rows[newStr].Cells[5].Value.ToString();
                // textBox3.Text = dataGridView2.Rows[newStr].Cells[6].Value.ToString();
             }
             catch { }
        }

        private void button1_Click(object sender, EventArgs e) //добавить
        {
            if ( textBox2.Text !="" && textBox3.Text != "")
            {
                int selIndexCl = comboBox1.SelectedIndex;
                int selIndexTour = comboBox2.SelectedIndex;
                dataGridView2.Rows.Add(newTravel, kClient[selIndexCl], fio[selIndexCl],
                kTour[selIndexTour], typeOfTour[selIndexTour], textBox2.Text, textBox3.Text);
                newTravel++;
                textBox1.Text = newTravel.ToString();
            }
            else
            {
                MessageBox.Show("Не все данные были выбраны!");
            }
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

        private void button2_Click(object sender, EventArgs e)//удалить
        {
            dataGridView2.Rows.RemoveAt(newStr);
            newTravel--;
            textBox1.Text = newTravel.ToString();
        }

        private void button3_Click(object sender, EventArgs e) //изменить
        {
            dataGridView2.Rows[newStr].Cells[5].Value = textBox2.Text;
            dataGridView2.Rows[newStr].Cells[6].Value = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] saveTravel = new string[amountOfRows];
            //string[] saveOutClient = new string[amountOfRows];
            for (int i = 0; i < amountOfRows; i++)
            {
                //saveOutClient[1] += dataGridView1.Rows[i].Cells[0].Value + "#" +"\n"; File.WriteAllLines("travel.txt", saveOutClient, Encoding.GetEncoding(1251));
                for (int j = 0; j < 7; j++)
                {
                    saveTravel[i] += dataGridView2.Rows[i].Cells[j].Value + "#"; File.WriteAllLines("travel.txt", saveTravel, Encoding.GetEncoding(1251));
                }
            }
        }
    }
}
