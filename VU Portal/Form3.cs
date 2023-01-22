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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VU_Portal
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public System.Windows.Forms.Label lab2;
        

        public Form3()
        {
            InitializeComponent();
            instance = this;
            lab2 = label2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM ResourceMNG order by date";

            SqlDataAdapter da = new SqlDataAdapter(qry, conString);
            DataSet ds = new DataSet();

            da.Fill(ds, "ResourceMNG");
            dataGridView1.DataSource = ds.Tables["ResourceMNG"];
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form3 ";
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (textBox1.Text == null)
            { 
                MessageBox.Show("Enter the Student ID No to Continue"); 
            }
            else
            {
                String ID = textBox1.Text;
                
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                string qry = "SELECT * FROM ResourceMNG where ID_NO='" + ID + "'";

                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read() == true)
                    {   //show available quantity
                        SqlConnection conq = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                        string qryy = "SELECT * FROM Resource where Resource_Name='" + dr["Resource_Name"].ToString() + "'";

                        SqlCommand cmd3 = new SqlCommand(qryy, conq);
                        conq.Open();
                        using (SqlDataReader drr = cmd3.ExecuteReader())
                        {
                            if (drr.Read() == true)
                            {
                                
                                if (drr["Quantity"].ToString() == "0")
                                {
                                    MessageBox.Show("Can't Confirm");
                                    SqlConnection cancel = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                                    string updst = "update Student set Status='Cancel' where ID_NO='" + ID + "'";
                                    SqlCommand cmdcan = new SqlCommand(updst, cancel);

                                    try
                                    {
                                        cancel.Open();
                                        cmdcan.ExecuteNonQuery();


                                    }
                                    catch (SqlException es)
                                    {
                                        MessageBox.Show(es.Message);
                                    }
                                }
                                else
                                {   // not in quantity = 0 
                                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                                    string upd = "update Resource set Quantity=(Quantity-1) where Resource_Name='" + dr["Resource_Name"].ToString() + "'";
                                    SqlCommand cmd1 = new SqlCommand(upd, con1);

                                    try
                                    {
                                        con1.Open();
                                        cmd1.ExecuteNonQuery();
                                        MessageBox.Show("Verify the Purchased Resource:\n Reminder:Sent The Confirmation Mail to Collect the Resource", ID);
                                        
                                        
                                        //confirmation msg

                                        SqlConnection concf = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                                        string updcf = "update Student set Status='Confirm' , Resource='"+ dr["Resource_Name"].ToString() + "' where ID_NO='" + ID + "'";
                                        SqlCommand cmdcf = new SqlCommand(updcf, concf);

                                        try
                                        {
                                            concf.Open();
                                            cmdcf.ExecuteNonQuery();


                                        }
                                        catch (SqlException es)
                                        {
                                            MessageBox.Show(es.Message);
                                        }


                                    }
                                    catch (SqlException es)
                                    {
                                        MessageBox.Show(es.Message);
                                    }


                                   
                                }
                                //delete record in ResourceMNG after confirm the order
                                SqlConnection conde = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                                string del = "delete from ResourceMNG where ID_NO='" + ID + "'";
                                SqlCommand cmdde = new SqlCommand(del, conde);

                                try
                                {
                                    conde.Open();
                                    cmdde.ExecuteNonQuery();


                                }
                                catch (SqlException es)
                                {
                                    MessageBox.Show("" + es);
                                }
                            }
                        }




                    }


                }
                //con.Close();
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
            Form6.instance.lab1.Text = lab2.Text;
        }
    }
}
