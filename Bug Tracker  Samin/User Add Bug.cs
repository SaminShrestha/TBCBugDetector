using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker__Samin
{
    public partial class User_Add_Bug : Form
    {
        public UserSessionModel session { get; set; }
        Image pic;
        public User_Add_Bug(UserSessionModel usm)
        {
            InitializeComponent();
            session = usm;
        }

        private void User_Add_Bug_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png |All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pic = Image.FromFile(dialog.FileName);
                    pictureBox1.Image = pic;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("One or More Fields Are Empty");
            }
            try
            {
                MemoryStream ms = new MemoryStream();
                pic.Save(ms, pic.RawFormat);
                Bug_Detector_SaminEntities bte = new Bug_Detector_SaminEntities();
                var InsIssue = new Bug
                {
                    Name = textBox1.Text.Trim(),
                    Description = richTextBox1.Text.Trim(),
                    Pic = ms.ToArray(),
                    IssueStatus = "Pending",
                    IssueBy = session.UserName
                };
                bte.Bugs.Add(InsIssue);
                bte.SaveChanges();
                MessageBox.Show("Issue Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
