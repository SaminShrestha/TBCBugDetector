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
    public partial class Developer_View_Bug : Form
    {
        public UserSessionModel session { get; set; }
        public Developer_View_Bug(UserSessionModel usm)
        {
            InitializeComponent();
            session = usm;
            fillComboBox();
        }

        void fillComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D2MOLFD;Initial Catalog=Bug Detector Samin;Integrated Security=True");
                con.Open();
                SqlCommand sda = new SqlCommand("Select Name from Bugs where AnsweredBy='" + session.UserName + "'AND  IssueStatus= 'Pending'", con);
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Developer_View_Bug_Load(object sender, EventArgs e)
        {

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

                Bug_Detector_SaminEntities bte = new Bug_Detector_SaminEntities();
                var item = bte.Bugs.Where(a => a.Name == comboBox1.Text).SingleOrDefault();
                byte[] arr = item.Pic;
                MemoryStream ms = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms);
            }
            con.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
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
                data.Solution = richTextBox2.Text;
                data.IssueStatus = "On Going";
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
