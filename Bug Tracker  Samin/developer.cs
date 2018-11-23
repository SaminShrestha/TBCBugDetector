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
    public partial class developer : Form
    {
        public UserSessionModel session { get; set; }
        public developer(UserSessionModel usm)
        {
            InitializeComponent();
            session = usm;
        }

        private void viewBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Developer_View_Bug dv = new Developer_View_Bug(session);
            dv.MdiParent = this;
            dv.Show();
        }
    }
}
