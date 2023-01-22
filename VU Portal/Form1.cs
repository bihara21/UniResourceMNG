using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace VU_Portal
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public TextBox tb1;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand("select * from Student where ID_NO= @ID_NO and Password= @Password ", con);
                cmd.Parameters.AddWithValue("@ID_NO", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form5 form = new Form5();
                    form.Show();
                    this.Hide();
                    Form5.instance.lab1.Text = textBox1.Text;


                }

                else
                {
                    SqlCommand cmdd = new SqlCommand("select * from Teacher where Teacher_ID= @Teacher_ID and Password= @Password ", con);
                    cmdd.Parameters.AddWithValue("@Teacher_ID", textBox1.Text);
                    cmdd.Parameters.AddWithValue("@Password", textBox2.Text);
                    SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                    DataTable dtt = new DataTable();

                    daa.Fill(dtt);
                    if (dtt.Rows.Count > 0)
                    {
                        Form6 form = new Form6();
                        form.Show();
                        this.Hide();
                        Form6.instance.lab1.Text = textBox1.Text;



                    }

                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }








                }
            }

            else
            {
                MessageBox.Show("Enter Relevant Values");
            }
           
        }
    }
}
