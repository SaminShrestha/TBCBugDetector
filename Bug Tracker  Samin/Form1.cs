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

namespace Bug_Tracker__Samin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D2MOLFD;Initial Catalog=Bug Detector Samin;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Role FROM LOGIN WHERE USERNAME = '"+textBox1.Text+"' AND PASSWORD = '"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Bug_Detector_SaminEntities bds = new Bug_Detector_SaminEntities();
            if (dt.Rows[0][0].ToString() == "admin")
            {
                var item = bds.Logins.Where(a => a.Username == textBox1.Text).SingleOrDefault();
                UserSessionModel session = new UserSessionModel();
                session.UserName = item.Username;
                this.Hide();
                Admin aa = new Admin(session);
                aa.Show();
            }
            else if (dt.Rows[0][0].ToString() == "developer")
            {
                var item = bds.Logins.Where(a => a.Username == textBox1.Text).SingleOrDefault();
                UserSessionModel session = new UserSessionModel();
                session.UserName = item.Username;
                developer d = new developer(session);
                this.Hide();
                d.Show();
            }

            else if (dt.Rows[0][0].ToString() == "user")
            {
                var item = bds.Logins.Where(a => a.Username == textBox1.Text).SingleOrDefault();
                UserSessionModel session = new UserSessionModel();
                session.UserName = item.Username;
                User u = new User(session);
                this.Hide();
                u.Show();
            }

            else
            {
                MessageBox.Show("Invalid User Name or Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rr = new Register();
            rr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
