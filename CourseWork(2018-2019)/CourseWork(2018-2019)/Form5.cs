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
    public partial class Form5 : Form
    {
        int[] kodTravel = new int[0];
        int[] kTour = new int[0];
        string[] tour = new string[0];
        int[] order = new int[0];
        int[] tickets = new int[0];
        int[] profit = new int[0];
        char[] d = { '#' };
        int allTours = 0;
        int amountTours = 0;
        public Form5()
        {
            InitializeComponent();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = true;
            dataGridView2.AutoResizeColumns();
            LoadTotal();
            DataGV();
        }
        private void LoadTotal()
        {
            string[] tours = File.ReadAllLines("tour.txt", Encoding.GetEncoding(1251));
            allTours = tours.Length;
            Array.Resize(ref kodTravel, allTours);
            Array.Resize(ref kTour, allTours);
            Array.Resize(ref tour, allTours);
            for (int i = 0; i < allTours; i++)
            {
                string[] splitTours = tours[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kTour[i] = int.Parse(splitTours[0]);
                tour[i] = splitTours[1];
            }
            string[] amount = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            amountTours = amount.Length;
            Array.Resize(ref order, amountTours);
            Array.Resize(ref tickets, amountTours);
            Array.Resize(ref profit, amountTours);
            for (int i = 0; i < amountTours; i++)
            {
                string[] splitAmount = amount[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                order[i] = int.Parse(splitAmount[2]);
                tickets[i] = int.Parse(splitAmount[4]);
                profit[i] = int.Parse(splitAmount[3]);
            }  
        }
        private void DataGV()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < allTours; i++)
            {
                int counter = 0;
                int amountTickets = 0;
                int sum = 0;
                dataGridView2.Rows.Add(kTour[i],tour[i]);
                for (int k = 0; k < amountTours; k++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == order[k].ToString())
                    {
                        counter++;
                        amountTickets += tickets[k];
                        sum = profit[k]*amountTickets;
                    } 
                    dataGridView2.Rows[i].Cells[2].Value = counter;
                    dataGridView2.Rows[i].Cells[3].Value = amountTickets;
                    dataGridView2.Rows[i].Cells[4].Value = sum;
                }
            }
        }
    }
}
