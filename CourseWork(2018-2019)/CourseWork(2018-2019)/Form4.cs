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
        int[] kodeTravel = new int[0];
        int[] amountTour = new int[0];
        int[] costOfTour = new int[0];
        int[] newcostOfTour = new int[0];
        string[] kClient = new string[0];
        string[] newkClient = new string[0];
        string[] kTour = new string[0];
        string[] newkTour = new string[0];
        string[] typeOfTour = new string[0];
        string[] newtypeOfTour = new string[0];
        char[] d = { '#' };
        int amountOfRows1 = 0;
        int amountOfRows2 = 0;
        int newTravel = 1;
        int newStr = 0;
        int amountMainRows = 0;
        string[] fio = new string[0];
        string[] newfio = new string[0];
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
            total();
        }
        private void LoadTravel()
        {
            string[] client = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            string[] tour = File.ReadAllLines("tour.txt", Encoding.GetEncoding(1251));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            amountOfRows1 = client.Length;
            amountOfRows2 = tour.Length;
            Array.Resize(ref kClient, amountOfRows1);
            Array.Resize(ref newkClient, amountOfRows1);
            Array.Resize(ref fio, amountOfRows1);
            Array.Resize(ref newfio, amountOfRows1);
            Array.Resize(ref kTour, amountOfRows2);
            Array.Resize(ref newkTour, amountOfRows2);
            Array.Resize(ref typeOfTour, amountOfRows2);
            Array.Resize(ref newtypeOfTour, amountOfRows2);
            Array.Resize(ref costOfTour, amountOfRows2);
            Array.Resize(ref newcostOfTour, amountOfRows2);
            textBox1.Text = newTravel.ToString();
            for (int i = 0; i < amountOfRows1; i++)
            {
                string[] kodeCl = client[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kClient[i] = kodeCl[0];
                newkClient[i] = kodeCl[0];
                fio[i] = kodeCl[1];
                newfio[i] = kodeCl[1];
                comboBox1.Items.Add(kClient[i] + " " + fio[i]);
            }
            for (int i = 0; i < amountOfRows2; i++)
            {
                string[] kodeTour = tour[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kTour[i] = kodeTour[0];
                newkTour[i] = kodeTour[0];
                typeOfTour[i] = kodeTour[1];
                newtypeOfTour[i] = kodeTour[1];
                costOfTour[i] = int.Parse(kodeTour[2]);
                newcostOfTour[i] = int.Parse(kodeTour[2]);
                comboBox2.Items.Add(kTour[i] + " " + typeOfTour[i]);
            }
        }
        private void DataGV()
        {

            dataGridView2.Rows.Clear();
            string[] travel = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            amountMainRows = travel.Length;
            Array.Resize(ref kodeTravel, amountMainRows);
            Array.Resize(ref amountTour, amountMainRows);
            Array.Resize(ref newcostOfTour, amountMainRows);
            if (amountOfRows1 > amountOfRows2)
            {
                Array.Resize(ref newkTour, amountOfRows1);
                Array.Resize(ref newtypeOfTour, amountOfRows1);
            }
            if (amountOfRows1 < amountOfRows2)
            {
                Array.Resize(ref newkClient, amountOfRows2);
                Array.Resize(ref newfio, amountOfRows2);
            }
            for (int i = 0; i < amountMainRows; i++)
            {
                string[] values = travel[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                amountTour[i] = int.Parse(values[6]);
                kodeTravel[i] = int.Parse(values[0]);
                newkClient[i] = values[1];
                newfio[i] = values[2];
                newkTour[i] = values[3];
                newtypeOfTour[i] = values[4];
                newcostOfTour[i] = int.Parse(values[5]);
            }
            for (int i = 0; i < amountMainRows; i++)
            {
                dataGridView2.Rows.Add(kodeTravel[i], newkClient[i], newfio[i], newkTour[i], newtypeOfTour[i], newcostOfTour[i],amountTour[i]);
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                newStr = dataGridView2.CurrentRow.Index;
                int numOfCl = int.Parse(dataGridView2.Rows[newStr].Cells[1].Value.ToString());
                string kodCl = kClient[numOfCl - 1];
                int index = Array.IndexOf(kClient, kodCl);
                comboBox1.SelectedIndex = index;
                int numOfTour = int.Parse(dataGridView2.Rows[newStr].Cells[3].Value.ToString());
                string kodT = kTour[numOfTour - 1];
                int ind = Array.IndexOf(kTour, kodT);
                comboBox2.SelectedIndex = ind;
                textBox1.Text = dataGridView2.Rows[newStr].Cells[0].Value.ToString();
                textBox3.Text = dataGridView2.Rows[newStr].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e) //добавить
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                int selIndexCl = comboBox1.SelectedIndex;
                int selIndexTour = comboBox2.SelectedIndex;
                int newTravel = dataGridView2.RowCount + 1;
                textBox1.Text = newTravel.ToString();
                int cost = 0;
                int amount = 0;
                string total = "";
                cost = int.Parse(textBox2.Text);
                amount = int.Parse(textBox3.Text);
                total = (cost * amount).ToString();
                dataGridView2.Rows.Add(newTravel, kClient[selIndexCl], fio[selIndexCl],
                kTour[selIndexTour], typeOfTour[selIndexTour], textBox2.Text, textBox3.Text,total);
            }
            else
            {
                MessageBox.Show("Не все данные были выбраны!");
            }
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

        private void button4_Click(object sender, EventArgs e) //сохранить
        {
            int countStr = dataGridView2.Rows.Count;
            string[] saveTravel = new string[countStr];
            for (int i = 0; i < countStr; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    saveTravel[i] += dataGridView2.Rows[i].Cells[j].Value + "#"; File.WriteAllLines("travel.txt", saveTravel, Encoding.GetEncoding(1251));
                }
            }
            MessageBox.Show("Данные успешно сохранены!");
        }
        private void total()//Подсчет итоговой суммы
        {
            int cost = 0;
            int amount = 0;
            string total = "";
            for (int i = 0; i < amountMainRows; i++)
            {
                cost = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                amount = int.Parse(dataGridView2.Rows[i].Cells[6].Value.ToString());
                total = (cost * amount).ToString();
                dataGridView2.Rows[i].Cells[7].Value = total;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            textBox2.Text = costOfTour[index].ToString();
        }
    }
}
