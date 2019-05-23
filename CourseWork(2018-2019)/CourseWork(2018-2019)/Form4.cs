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
        int amount1 = 0;
        int amount2 = 0;
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
            amount1 = client.Length;
            amount2 = tour.Length;
            Array.Resize(ref kClient, amount1);
            Array.Resize(ref fio, amount1);
            Array.Resize(ref kTour, amount2);
            Array.Resize(ref typeOfTour, amount2);
            Array.Resize(ref costOfTour, amount2);
            Array.Resize(ref newcostOfTour, amount2);
            textBox1.Text = newTravel.ToString();
            for (int i = 0; i < amount1; i++)
            {
                string[] kodeCl = client[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kClient[i] = kodeCl[0];
                fio[i] = kodeCl[1];
                comboBox1.Items.Add(kClient[i] + " " + fio[i]);
            }
            for (int i = 0; i < amount2; i++)
            {
                string[] kodeTour = tour[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kTour[i] = kodeTour[0];
                typeOfTour[i] = kodeTour[1];
                costOfTour[i] = int.Parse(kodeTour[2]);
                comboBox2.Items.Add(kTour[i] + " " + typeOfTour[i]);
            }
            string[] travel = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            amountMainRows = travel.Length;
            Array.Resize(ref kodeTravel, amountMainRows);
            Array.Resize(ref amountTour, amountMainRows);
            Array.Resize(ref newkTour, amountMainRows);
            Array.Resize(ref newkClient, amountMainRows);
            Array.Resize(ref newcostOfTour, amountMainRows);
            dataGridView2.Rows.Clear();
            if (amount1 > amount2)
            {
                Array.Resize(ref newkTour, amount1);
                Array.Resize(ref typeOfTour, amount1);
            }
            if (amount1 < amount2)
            {
                Array.Resize(ref newkClient, amount2);
                Array.Resize(ref fio, amount2);
            }
            for (int i = 0; i < amountMainRows; i++)
            {
                string[] values = travel[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                amountTour[i] = int.Parse(values[4]);
                kodeTravel[i] = int.Parse(values[0]);
                newkClient[i] = values[1];
                newkTour[i] = values[2];
                newcostOfTour[i] = int.Parse(values[3]);
            }
        }
        private void DataGV()
        {
            for (int i = 0; i < amountMainRows; i++)
            {
                dataGridView2.Rows.Add(kodeTravel[i], newkClient[i], newkTour[i], newcostOfTour[i],amountTour[i]);
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

                int numOfTour = int.Parse(dataGridView2.Rows[newStr].Cells[2].Value.ToString());
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
                dataGridView2.Rows.Add(newTravel, kClient[selIndexCl],
                kTour[selIndexTour], textBox2.Text, textBox3.Text,total);
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
                for (int j = 0; j < 6; j++)
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
                cost = int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                amount = int.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                total = (cost * amount).ToString();
                dataGridView2.Rows[i].Cells[5].Value = total;
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
