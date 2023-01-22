using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VU_Portal
{
    public partial class Form7 : Form
    {
        public static Form7 instance;
        public System.Windows.Forms.Label lab1;
        public Form7()
        {
            InitializeComponent();
            instance = this;
            lab1 = label3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form7 ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && (radioButton1.Checked == false || radioButton2.Checked == false || radioButton3.Checked == false || radioButton4.Checked == false))
            {
                MessageBox.Show("Enter the Student ID No Who had Purchased the Resource & Select the Resource Type");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    
                    SqlConnection restock = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                    string re = "update Student set Status= NULL , Resource=NULL where ID_NO='" + textBox1.Text + "'";
                    SqlCommand stock = new SqlCommand(re, restock);

                    string upd = "update Resource set Quantity=(Quantity+1) where Resource_Name='" + radioButton1.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(upd, restock);

                    try
                    {
                        restock.Open();
                        stock.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Restock '" + radioButton1.Text + "'");


                    }
                    catch (SqlException es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    SqlConnection restock = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                    string re = "update Student set Status=NULL , Resource=NULL where ID_NO='" + textBox1.Text + "'";
                    SqlCommand stock = new SqlCommand(re, restock);

                    string upd = "update Resource set Quantity=(Quantity+1) where Resource_Name='" + radioButton2.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(upd, restock);

                    try
                    {
                        restock.Open();
                        stock.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Restock '" + radioButton2.Text + "'");

                    }
                    catch (SqlException es)
                    {
                        MessageBox.Show(es.Message);
                    }

                }
                else if (radioButton3.Checked == true)
                {
                    SqlConnection restock = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                    string re = "update Student set Status=NULL , Resource=NULL where ID_NO='" + textBox1.Text + "'";
                    SqlCommand stock = new SqlCommand(re, restock);

                    string upd = "update Resource set Quantity=(Quantity+1) where Resource_Name='" + radioButton3.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(upd, restock);

                    try
                    {
                        restock.Open();
                        stock.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Restock '" + radioButton3.Text + "'");


                    }
                    catch (SqlException es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                else if (radioButton4.Checked == true)
                {
                    SqlConnection restock = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                    string re = "update Student set Status= NULL , Resource=NULL where ID_NO='" + textBox1.Text + "'";
                    SqlCommand stock = new SqlCommand(re, restock);

                    string upd = "update Resource set Quantity=(Quantity+1) where Resource_Name='" + radioButton4.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(upd, restock);

                    try
                    {
                        restock.Open();
                        stock.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Restock '" + radioButton4.Text + "'");


                    }
                    catch (SqlException es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                else
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
            Form6.instance.lab1.Text = lab1.Text;
        }
    }
}
