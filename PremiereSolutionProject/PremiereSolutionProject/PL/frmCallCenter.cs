using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PremiereSolutionProject.BLL;

namespace PremiereSolutionProject.PL
{
    public partial class frmCallCenter : Form
    {
        public frmCallCenter()
        {
            
            InitializeComponent();
            
        }
        public frmCallCenter(frmDashboard _dashform):this()
        {
            dashform = _dashform;
        }
        frmDashboard dashform;
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnServiceRequest_Click(object sender, EventArgs e)
        {
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {

            dashform.callInfo = new Call();
            CallCenterEmployee Emp = dashform.callInfo.GenerateRandomEmployee();
            
            lblEmpName.Text = Emp.FirstName;

        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            new frmClientInfo().Show();
            this.Hide();
        }

        
    }
}
