using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace VU_Portal
{
    public partial class Form5 : Form
    {
        public static Form5 instance;
        public System.Windows.Forms.Label lab1;
        public Form5()
        {
            InitializeComponent();
            instance = this;
            lab1 = label2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.Show();
            this.Hide();
            Form8.instance.lab1.Text = lab1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                string qryy = "SELECT * FROM Student where ID_NO='" + lab1.Text + "'";
                SqlCommand cmd3 = new SqlCommand(qryy, con1);
                con1.Open();
                using (SqlDataReader drr = cmd3.ExecuteReader())
                {
                    if (drr.Read() == true)
                    {

                        if (drr["Status"].ToString() == "Confirm")
                        {
                            MessageBox.Show("You already Purchase a Resource");
                        }
                        else
                        { 
                            Form2 form = new Form2();
                            form.Show();
                            this.Hide();
                            Form2.instance.lab1.Text = lab1.Text;
                        }
                    }
                }
            }






        

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form5 ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
