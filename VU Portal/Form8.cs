using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace VU_Portal
{
    public partial class Form8 : Form
    {
        public static Form8 instance;
        public System.Windows.Forms.Label lab1;
        int num=0;
        public Form8()
        {
            InitializeComponent();
            instance = this;
            lab1 = label3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
            Form5.instance.lab1.Text =lab1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            num++;
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
            string confq = "SELECT * FROM Student where ID_NO='" + lab1.Text + "'";

            SqlCommand cmmdc = new SqlCommand(confq, con);
            con.Open();
            using (SqlDataReader drc = cmmdc.ExecuteReader())
            {
                if (drc.Read() == true)
                {
                    if (drc["Status"].ToString() == "Confirm")
                    {
                        if (num.ToString() == "1")
                        {
                            label1.Text = "Your Request is Confirm to Collect";
                        }
                        else
                        {
                            label1.Text ="Please HandOver the Resource within 30 Days.";
                        }
                    }
                    else if (drc["Status"].ToString() == "Cancel")
                    {   if (num.ToString() == "1")
                        {
                            label1.Text = "Your Request is Cancelled";
                            SqlConnection restock = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                            string re = "update Student set Status= NULL where ID_NO='" + lab1.Text + "'";
                            SqlCommand stock = new SqlCommand(re, restock);
                            try
                            {
                                restock.Open();
                                stock.ExecuteNonQuery();

                            }
                            catch (SqlException es)
                            {
                                MessageBox.Show(es.Message);
                            }
                        }
                        else
                        {
                            label1.Text = "No Resources to Collect";
                        }
                    }
                    else
                    {
                       label1.Text="Your Request is Pending";
                    }

                }


            }
            con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
            Form1.instance.tb1.Text = "set by Form8 ";
        }
    }
}
