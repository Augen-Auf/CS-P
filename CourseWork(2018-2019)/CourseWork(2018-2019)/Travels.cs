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
    public partial class Travels : Form
    {
        int[] kodeTravel = new int[0];
        int[] amountTour = new int[0];
        int[] costOfTour = new int[0];
        int[] totalSum = new int[0];
        int[] newcostOfTour = new int[0];
        string[] kClient = new string[0];
        string[] newkClient = new string[0];
        string[] fio = new string[0];
        string[] newfio = new string[0];
        string[] kTour = new string[0];
        string[] newkTour = new string[0];
        string[] typeOfTour = new string[0];
        string[] newtypeOfTour = new string[0];
        char[] d = { '#' };
        int amount1 = 0;
        int amount2 = 0;
        int newStr = 0;
        int amountMainRows = 0;
        public Travels()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            LoadTravel();
            DataGV();
           
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
            Array.Resize(ref newtypeOfTour, amountMainRows);
            Array.Resize(ref newkClient, amountMainRows);
            Array.Resize(ref newfio, amountMainRows);
            Array.Resize(ref newcostOfTour, amountMainRows);
            Array.Resize(ref totalSum, amountMainRows);
            dataGridView2.Rows.Clear();
            for (int i = 0; i < amountMainRows; i++)
            {
                string[] values = travel[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                amountTour[i] = int.Parse(values[4]);
                kodeTravel[i] = int.Parse(values[0]);
                newkClient[i] = values[1];
                newkTour[i] = values[2];
                newcostOfTour[i] = int.Parse(values[3]);
                totalSum[i] = int.Parse(values[5]);
            }
        }
        private void DataGV()
        {
            for (int i = 0; i < amountMainRows; i++)
            {   
                for (int j = 0; j < amount1; j++)
                {
                    for(int h=0;h<amount2;h++)
                    {
                        if (newkTour[i] == kTour[h])
                            newtypeOfTour[i] = typeOfTour[h];
                    }
                    if (newkClient[i] == kClient[j] && newtypeOfTour[i]!= null)
                    {
                        newfio[i] = fio[j];
                        dataGridView2.Rows.Add(kodeTravel[i], newkClient[i], newfio[i], newkTour[i], newtypeOfTour[i], 
                            newcostOfTour[i], amountTour[i],totalSum[i]);
                    }
                }
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
            int indexStr = newStr + 1;
            textBox1.Text = indexStr.ToString();
            for (int n = newStr; n < dataGridView2.RowCount; n++)
            {
                dataGridView2.Rows[n].Cells[0].Value = n + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e) //изменить
        {
            int selIndexCl = comboBox1.SelectedIndex;
            int selIndexTour = comboBox2.SelectedIndex;
            dataGridView2.Rows[newStr].Cells[6].Value = textBox3.Text;
            dataGridView2.Rows[newStr].Cells[3].Value = kTour[selIndexTour];
            dataGridView2.Rows[newStr].Cells[4].Value = typeOfTour[selIndexTour];
            dataGridView2.Rows[newStr].Cells[1].Value = kClient[selIndexCl];
            dataGridView2.Rows[newStr].Cells[2].Value = fio[selIndexCl];
            dataGridView2.Rows[newStr].Cells[5].Value = textBox2.Text;
            int profit = int.Parse(textBox2.Text) * int.Parse(textBox3.Text);
            dataGridView2.Rows[newStr].Cells[7].Value = profit;
        }

        private void button4_Click(object sender, EventArgs e) //сохранить
        {
           
                string[] total = new string[0];
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    Array.Resize(ref total, total.Length + 1);
                    total[i] += dataGridView2.Rows[i].Cells[0].Value.ToString() + "#" +
                    dataGridView2.Rows[i].Cells[1].Value.ToString() + "#" +
                    dataGridView2.Rows[i].Cells[3].Value.ToString() + "#" +
                    dataGridView2.Rows[i].Cells[5].Value.ToString() + "#" +
                    dataGridView2.Rows[i].Cells[6].Value.ToString() + "#" +
                    dataGridView2.Rows[i].Cells[7].Value.ToString();
                }
                File.WriteAllLines("travel.txt", total, Encoding.GetEncoding(1251));
            MessageBox.Show("Данные успешно сохранены!");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            textBox2.Text = costOfTour[index].ToString();
        }
    }
}
