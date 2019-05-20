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
        int[] kClient = new int[0];
        string[] fio = new string[0];
        int[] kTour = new int[0];
        string[] tour = new string[0];
        string[] ktour = new string[0];
        int[] costOfTravel = new int[0];
        int[] amountTours = new int[0];
        char[] d = { '#' };
        int travels = 0;
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
            total();
        }
        private void LoadTotal()
        {
            string[] total = File.ReadAllLines("travel.txt", Encoding.GetEncoding(1251));
            travels = total.Length;
            Array.Resize(ref kodTravel, travels);
            Array.Resize(ref kClient, travels);
            Array.Resize(ref fio, travels);
            Array.Resize(ref kTour, travels);
            Array.Resize(ref tour, travels);
            Array.Resize(ref costOfTravel, travels);
            Array.Resize(ref amountTours, travels);
            for (int i = 0; i < travels; i++)
            {
                string[] splitTotal = total[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                kodTravel[i] = int.Parse(splitTotal[0]);
                kClient[i] = int.Parse(splitTotal[1]);
                fio[i] = splitTotal[2];
                kTour[i] = int.Parse(splitTotal[3]);
                tour[i] = splitTotal[4];
                costOfTravel[i] = int.Parse(splitTotal[5]);
                amountTours[i] = int.Parse(splitTotal[6]);
            }
        }
        private void DataGV()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < travels; i++)
            {
                dataGridView2.Rows.Add(kodTravel[i], kClient[i], fio[i],kTour[i],tour[i],costOfTravel[i],amountTours[i]);
            }
        }
        private void total()//Подсчет итоговой суммы
        {
            int cost = 0;
            int amount = 0;
            string total = "";
            for (int i = 0; i < travels; i++)
            {
                cost = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                amount = int.Parse(dataGridView2.Rows[i].Cells[6].Value.ToString());
                total = (cost * amount).ToString();
                dataGridView2.Rows[i].Cells[7].Value = total;
            }
        }
    }
}
