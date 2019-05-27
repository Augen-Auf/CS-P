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
    public partial class Form6 : Form
    {
        char[] d = { '#' };
        int[] kClient = new int[0];
        int[] kCl = new int[0];
        string[] client = new string[0];
        int amountOfRows1 = 0;
        int amountOfRows2 = 0;
        int newStr = 0;
        int[] kTour = new int[0];
        int[] kodetour = new int[0];
        string[] tour = new string[0];
        int[] amountOfTravel = new int[0];
        int[] cost = new int[0];
        int tourL = 0;
        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            LoadMainForm();
            DataGV();
        }
        private void LoadMainForm()
        {
            string[] clients = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            amountOfRows1 = clients.Length;
            Array.Resize(ref kClient, amountOfRows1);
            Array.Resize(ref client, amountOfRows1);
            for (int i = 0; i < amountOfRows1; i++)
            {
                string[] addClient = clients[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kClient[i] = int.Parse(addClient[0]);
                client[i] = addClient[1];
            } 
        }
        private void DataGV()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < amountOfRows1; i++)
                dataGridView1.Rows.Add(kClient[i],client[i]);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string[] travels = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            string[] tours = File.ReadAllLines("tour.txt", Encoding.GetEncoding(1251));
            amountOfRows2 = travels.Length;
            tourL = tours.Length;
            Array.Resize(ref kTour, amountOfRows2);
            Array.Resize(ref tour, tourL);
            Array.Resize(ref kodetour, tourL);
            Array.Resize(ref amountOfTravel, amountOfRows2);
            Array.Resize(ref cost, amountOfRows2);
            Array.Resize(ref kCl, amountOfRows2);
            for(int k=0;k < tourL;k++)
            {
                string[] addTour = tours[k].Split(d, StringSplitOptions.RemoveEmptyEntries);
                tour[k] = addTour[1];
                kodetour[k] = int.Parse(addTour[0]);
            }
            for (int i = 0; i < amountOfRows2; i++)
            {
                string[] addTravel = travels[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kTour[i] = int.Parse(addTravel[2]);
                amountOfTravel[i] = int.Parse(addTravel[4]);
                cost[i] = int.Parse(addTravel[3]);
                kCl[i] = int.Parse(addTravel[1]);
            }
            try
            {
                newStr = dataGridView1.CurrentRow.Index;
                int numOfCl = int.Parse(dataGridView1.Rows[newStr].Cells[0].Value.ToString()); // 1/2/3/1...
                dataGridView2.Rows.Clear();
                string nameTour = "";
                for (int i = 0; i < amountOfRows2; i++)
                {   
                    if (numOfCl == kCl[i])
                    {
                        int kodTour = kTour[i];
                        for (int k = 0; k < tourL; k++)
                        {
                            if (kTour[i] == kodetour[k])
                                nameTour = tour[k];
                        }
                        int amountT = amountOfTravel[i];
                        int price = cost[i];
                        int newTravelKode = dataGridView2.RowCount + 1;
                        dataGridView2.Rows.Add(newTravelKode, kodTour,nameTour, amountT, price);
                    } 
                }
                Amount();
            }
            catch { }
        }
        private void Amount()//Подсчет количества путевок/туров
        {
            int amountOfTours = 0;
            int amountOfTickets = 0;
            int total = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            { 
                int amountOfTicket = int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                int price = int.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                amountOfTickets += amountOfTicket;
                total += price * amountOfTicket;
            }
            amountOfTours = dataGridView2.Rows.Count;
            textBox1.Text = amountOfTours.ToString();
            textBox2.Text = amountOfTickets.ToString();
            textBox3.Text = total.ToString();
        }
    }
}
