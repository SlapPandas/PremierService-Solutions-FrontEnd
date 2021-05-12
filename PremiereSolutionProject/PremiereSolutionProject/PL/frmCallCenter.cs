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
            Call call =  dashform.callInfo.CreateCall();
            //dashform.callInfo.LogClientToCall(dashform.callInfo.CallID,)
            dashform.callInfo = call;
            
            lblEmpName.Text = call.Employee.FirstName;
            btnEnd.Enabled = true;

        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            if (dashform.callInfo == null)
            {
                MessageBox.Show("Please accept a call first");
            }
            else
            {
                dashform.callInfo.CallNotes = rtbNotes.Text;
                dashform.callInfo.UpdateCallNotes(dashform.callInfo.CallID, rtbNotes.Text);

                new frmClientInfo(dashform).Show();
                this.Hide();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            dashform.callInfo.LogEndTimeOfCall(dashform.callInfo.CallID,rtbNotes.Text);
        }

        private void frmCallCenter_Load(object sender, EventArgs e)
        {
            btnEnd.Enabled = false;
            if (dashform.callInfo != null)
            {
                                
                 lblEmpName.Text = dashform.callInfo.Employee.FirstName;
                 rtbNotes.Text = dashform.callInfo.CallNotes;


                btnEnd.Enabled = true;      
            }
            
        }
    }
}
