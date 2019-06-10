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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
		private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Clients();
            form2.ShowDialog();
        }
		private void button2_Click(object sender, EventArgs e)
		{
			Form form3 = new Tours();
			form3.ShowDialog();
		}
        private void button5_Click(object sender, EventArgs e)
        {
            Form form4 = new Travels();
            form4.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form form5 = new Total();
            form5.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form form6 = new Info();
            form6.ShowDialog();
        }
    }
}
