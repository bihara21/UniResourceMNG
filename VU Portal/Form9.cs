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
    public partial class Form9 : Form
    {
        public static Form9 instance;
        public System.Windows.Forms.Label lab1;
        public Form9()
        {
            InitializeComponent();
            instance = this;
            lab1 = label4;


            //Purchasing History
            String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bihara Numanshi\OneDrive\Documents\VU Portal.mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT ID_NO,Status,Resource FROM Student";

            SqlDataAdapter da = new SqlDataAdapter(qry, conString);
            DataSet ds = new DataSet();

            da.Fill(ds, "Student");
            dataGridView1.DataSource = ds.Tables["Student"];





            //resource availability
            string query = "SELECT Resource_Name,Quantity FROM Resource";

            SqlDataAdapter re = new SqlDataAdapter(query, conString);
            DataSet rr = new DataSet();

            re.Fill(rr, "Student");
            dataGridView2.DataSource = rr.Tables["Student"];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1.instance.tb1.Text = "set by Form9 ";
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
