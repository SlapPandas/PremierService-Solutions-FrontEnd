using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiereSolutionProject.Presentation_Layer
{
    public partial class frmCallCenter : Form
    {
        public frmCallCenter()
        {
            
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnServiceRequest_Click(object sender, EventArgs e)
        {
        }
    }
}
