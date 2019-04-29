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
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
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
            for(int i=0;i< kC;i++)
            {
                dataGridView1.Rows.Add(kodClient[i], fio[i]);
            }
        }
        private void dataGridView1_SelectionChanged(object seneder, EventArgs e)
        {
            newStr = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[newStr].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[newStr].Cells[0].Value.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fio[newStr] = textBox1.Text;
            DataGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kNew = kodClient[kC - 1];
            kC++;
            Array.Resize(ref kodClient, kC);
            Array.Resize(ref fio, kC);
            kNew++;
            kodClient[kC - 1] = kNew;
            textBox1.Text = kodClient.ToString();
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fio[kC - 1]=textBox2.Text;
            DataGV();
        }
    }
}
