using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VU_Portal
{
    public partial class Form6 : Form
    {
        public static Form6 instance;
        public System.Windows.Forms.Label lab1;
        public Form6()
        {
            InitializeComponent();
            instance = this;
            lab1 = label2;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form6 ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            this.Hide();
            Form3.instance.lab2.Text = lab1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
            this.Hide();
            Form7.instance.lab1.Text = lab1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9();
            form.Show();
            this.Hide();
            Form9.instance.lab1.Text = lab1.Text;
        }
    }
}
