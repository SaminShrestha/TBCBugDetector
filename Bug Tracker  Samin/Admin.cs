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
    public partial class Admin : Form
    {
        public UserSessionModel session { get; set; }
        public Admin(UserSessionModel sm)
        {
            InitializeComponent();
            session = sm;
        }

        private void repositoryViewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bugHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bug_Details bd = new Bug_Details(session);
            bd.MdiParent = this;
            bd.Show();
        }
    }
}
