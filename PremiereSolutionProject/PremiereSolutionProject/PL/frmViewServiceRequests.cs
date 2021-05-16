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
    public partial class frmViewServiceRequests : Form
    {
        public frmViewServiceRequests()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ServiceRequest serviceRequest = new ServiceRequest();
        List<ServiceRequest> sr = new List<ServiceRequest>();
        BindingSource bs = new BindingSource();
        private void frmViewServiceRequests_Load(object sender, EventArgs e)
        {
            dgvViewAllServiceReq.ForeColor = Color.Black;            
            RefreshDGV();
        }
        private void RefreshDGV()
        {
            sr = serviceRequest.SelectAllServiceRequests();
            bs.DataSource = sr;
            dgvViewAllServiceReq.DataSource = null;
            dgvViewAllServiceReq.DataSource = bs;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dgvViewAllServiceReq.CurrentCell = dgvViewAllServiceReq.Rows[0].Cells[dgvViewAllServiceReq.CurrentCell.ColumnIndex];
            populateFields(dgvViewAllServiceReq.CurrentRow.Index);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            dgvViewAllServiceReq.CurrentCell = dgvViewAllServiceReq.Rows[(dgvViewAllServiceReq.Rows.Count-1)].Cells[dgvViewAllServiceReq.CurrentCell.ColumnIndex];
            populateFields(dgvViewAllServiceReq.CurrentRow.Index);
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (dgvViewAllServiceReq.CurrentRow.Index != 0)
            {
                dgvViewAllServiceReq.CurrentCell = dgvViewAllServiceReq.Rows[dgvViewAllServiceReq.CurrentRow.Index - 1].Cells[dgvViewAllServiceReq.CurrentCell.ColumnIndex];
                populateFields(dgvViewAllServiceReq.CurrentRow.Index);
            }          
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (dgvViewAllServiceReq.CurrentRow.Index != (dgvViewAllServiceReq.Rows.Count-1))
            {
                dgvViewAllServiceReq.CurrentCell = dgvViewAllServiceReq.Rows[dgvViewAllServiceReq.CurrentRow.Index + 1].Cells[dgvViewAllServiceReq.CurrentCell.ColumnIndex];
                populateFields(dgvViewAllServiceReq.CurrentRow.Index);
            }  
        }
        private void populateFields(int index) {
            txtServiceRequestID.Text = sr[index].ServiceRequestID.ToString();
            txtCallId.Text = sr[index].CallID.ToString();
            txtDescription.Text = sr[index].Description;
            txtPriorityLevel.Text = sr[index].PriorityLevel;
            if (sr[index].Closed)
            {
                cmbClosed.SelectedIndex = 1;
            }
            if (!sr[index].Closed)
            {
                cmbClosed.SelectedIndex = 0;
            }
            
        }

        private void dgvViewAllServiceReq_Click(object sender, EventArgs e)
        {
            populateFields(dgvViewAllServiceReq.CurrentRow.Index);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                serviceRequest.DeleteServiceRequest(sr[dgvViewAllServiceReq.CurrentRow.Index]);
                sr = serviceRequest.SelectAllServiceRequests();
                RefreshDGV();
            }
            if (dr == DialogResult.No)
            {
                MessageBox.Show("Process did not Proceed");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to update row?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                serviceRequest.UpdateServiceRequest(new ServiceRequest(sr[dgvViewAllServiceReq.CurrentRow.Index].ServiceRequestID, txtDescription.Text, txtPriorityLevel.Text));
                serviceRequest.UpdateStateOfServiceRequest(new ServiceRequest(sr[dgvViewAllServiceReq.CurrentRow.Index].ServiceRequestID, GetTrueFalseFromBit(cmbClosed.SelectedIndex)));
                sr = serviceRequest.SelectAllServiceRequests();
                RefreshDGV();
            }
            if (dr == DialogResult.No)
            {
                MessageBox.Show("Process did not Proceed");
            }
        }
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
    }
}
