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
    public partial class frmEscalateJobs : Form
    {
        public frmEscalateJobs()
        {
            InitializeComponent();
        }

        #region Declarations

        ServiceRequest myServiceRequest = new ServiceRequest();
        List<ServiceRequest> serviceRequestList = new List<ServiceRequest>();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        private void frmEscalateJobs_Load(object sender, EventArgs e)
        {
            FormatForm();
        }

        private void dgvServiceRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (serviceRequestList.Count > 0)
            {
                PopulateFields(dgvServiceRequests.CurrentCell.RowIndex);
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEscalateServiceRequest_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtCurrentDays.Text) > (int)numNewDays.Value || txtCurrentDays.Text == "1")
            {
                ServiceManager myServiceManager = new ServiceManager();
                myServiceManager.EscalateServiceRequest((int)numNewDays.Value, serviceRequestList[dgvServiceRequests.CurrentCell.RowIndex]);
                PopulateDGV();
            }
            else
            {
                MessageBox.Show("The new days need to be less than the previous days.", "Invalid entry");
            }
            
        }
        #endregion

        #region Methods

        private void FormatForm()
        {
            txtNewPrio.Text = "Special";
            numNewDays.Value = 1;
            FormatDGV();
            PopulateDGV();
        }

        private void FormatDGV()
        {
            dgvServiceRequests.ForeColor = Color.Black;
        }

        private void PopulateDGV()
        {
            dgvServiceRequests.Rows.Clear();
            serviceRequestList = myServiceRequest.SelectAllServiceRequests();
            bindingSource = new BindingSource(serviceRequestList,null);
            dgvServiceRequests.DataSource = bindingSource;
        }

        private void PopulateFields(int index)
        {
            if (index >= serviceRequestList.Count)
            {
                index = 0;
            }

            if (index <= dgvServiceRequests.RowCount - 2 && serviceRequestList.Count > 0)
            {
                txtServiceRequestID.Text = serviceRequestList[index].ServiceRequestID.ToString();
                txtCallID.Text = serviceRequestList[index].CallID.ToString();
                txtClosed.Text = serviceRequestList[index].Closed.ToString();
                txtCurrentDays.Text = serviceRequestList[index].PriorityLevel[3].ToString();
                txtCurrentPrio.Text = DeterminePriorityLevel(serviceRequestList[index].PriorityLevel);
                rtxtDescription.Text = serviceRequestList[index].Description;
            }
        }

        private string DeterminePriorityLevel(string priorityLevel)
        {
            switch (priorityLevel.Substring(0,3).ToLower())
            {
                case "pla":
                    return "Platinum";
                case "gol":
                    return "Gold";
                case "sil":
                    return "Silver";
                case "bro":
                    return "Bronze";
                case "spe":
                    return "Special";
                default:
                    return "Invalid";
            }
        }

        #endregion

    }
}
