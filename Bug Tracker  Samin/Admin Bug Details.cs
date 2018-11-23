using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker__Samin
{
    public partial class Bug_Details : Form
    {
        public UserSessionModel session { get; set; }
        public Bug_Details(UserSessionModel sm)
        {
            InitializeComponent();
            fillComboBox();
            fillDevComboBox();
        }

        void fillComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D2MOLFD;Initial Catalog=Bug Detector Samin;Integrated Security=True");
                con.Open();
                SqlCommand sda = new SqlCommand("Select Name from Bugs", con);
                sda.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sc = new SqlDataAdapter(sda);
                sc.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Name"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void fillDevComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D2MOLFD;Initial Catalog=Bug Detector Samin;Integrated Security=True");
                con.Open();
                SqlCommand sda = new SqlCommand("Select Username from Login where Role='developer'", con);
                sda.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sc = new SqlDataAdapter(sda);
                sc.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["Username"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D2MOLFD;Initial Catalog=Bug Detector Samin;Integrated Security=True");
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("Select * from Bugs where Name ='" + comboBox1.Text + "'", con);
            sqlCmd.ExecuteNonQuery();
            SqlDataReader sdr;
            sdr = sqlCmd.ExecuteReader();
            while (sdr.Read())
            {
                string description = (string)sdr["Description"].ToString();
                richTextBox1.Text = description;

                string solution = (string)sdr["Solution"].ToString();
                richTextBox2.Text = solution;
                string status = "";
                Bug_Detector_SaminEntities bte = new Bug_Detector_SaminEntities();
                var item = bte.Bugs.Where(a => a.Name == comboBox1.Text).SingleOrDefault();
                textBox1.Text = item.IssueStatus;
                comboBox2.Text = item.AnsweredBy;
                byte[] arr = item.Pic;
                MemoryStream ms = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms);
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bug_Detector_SaminEntities bte = new Bug_Detector_SaminEntities();
                var data = bte.Bugs.Where(a => a.Name == comboBox1.Text).SingleOrDefault();
                data.Description = richTextBox1.Text;
                data.AnsweredBy = comboBox2.Text;
                data.IssueStatus = textBox1.Text;
                bte.Entry(data).State = EntityState.Modified;
                bte.SaveChanges();
                MessageBox.Show("Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
