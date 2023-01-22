using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace VU_Portal
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public System.Windows.Forms.Label lab1;
   
        
      
        
        public Form2()
        {
            InitializeComponent();
            instance= this;
            lab1 = label4;
            

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
            string qry = "SELECT * FROM Student where ID_NO='" + Form1.instance.tb1.Text + "'";

            SqlCommand cmd= new SqlCommand(qry, con);
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read() == true)
                {
                    Form2.instance.label6.Text = dr["Name"].ToString();
                    Form2.instance.label7.Text = dr["Course_ID"].ToString();
                }


            }
            con.Close();


            
            string qruy = "SELECT * FROM Course where Course_ID='" + label7.Text + "'";

            SqlCommand cmmd = new SqlCommand(qruy, con);
            con.Open();
            using (SqlDataReader dr1 = cmmd.ExecuteReader())
            {
                if (dr1.Read() == true)
                {
                    Form2.instance.label8.Text = dr1["Course_Name"].ToString();
                  
                }


            }
            con.Close();




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Date = dateTimePicker1.Text;

            /*if (lab1.Text!=null)
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
                    }
                }
            }*/


            

                if (comboBox1.Text != null)
                {
                    if (radioButton1.Checked == true)
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                        string qry = "insert into ResourceMNG(ID_NO,Course_ID,Unit_Name,Resource_Name,Date) values('" + Form1.instance.tb1.Text + "','" + label7.Text + "','" + comboBox1.Text + "','" + radioButton1.Text + "','" + Date + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your request sent for the confirmation.keep in touch with the Mails.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButton2.Checked == true)
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                        string qry = "insert into ResourceMNG(ID_NO,Course_ID,Unit_Name,Resource_Name,Date) values('" + Form1.instance.tb1.Text + "','" + label7.Text + "','" + comboBox1.Text + "','" + radioButton2.Text + "','" + Date + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your request sent for the confirmation.keep in touch with the Mails.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButton3.Checked == true)
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                        string qry = "insert into ResourceMNG(ID_NO,Course_ID,Unit_Name,Resource_Name,Date) values('" + Form1.instance.tb1.Text + "','" + label7.Text + "','" + comboBox1.Text + "','" + radioButton3.Text + "','" + Date + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your request sent for the confirmation.keep in touch with the Mails.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButton4.Checked == true)
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                        string qry = "insert into ResourceMNG(ID_NO,Course_ID,Unit_Name,Resource_Name,Date) values('" + Form1.instance.tb1.Text + "','" + label7.Text + "','" + comboBox1.Text + "','" + radioButton4.Text + "','" + Date + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your request sent for the confirmation.keep in touch with the Mails.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter the Unit Type & Resource Type that you want to request the Resource");

                    }
                }

            
                
            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form2 ";
           
        }
        
        private void label6_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
            Form5.instance.lab1.Text = lab1.Text;
        }
    }
}
