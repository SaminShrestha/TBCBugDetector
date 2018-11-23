using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker__Samin
{
    public partial class User : Form
    {
        public UserSessionModel session { get; set; }
        public User()
        {
            InitializeComponent();
        }

        public User(UserSessionModel usm)
        {
            InitializeComponent();
            session = usm;

        }

        private void addBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Add_Bug uab = new User_Add_Bug(session);
            uab.MdiParent = this;
            uab.Show();

        }

        private void viewSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Solution us = new User_Solution(session);
            this.Hide();
            us.Show();
        }
    }
}
