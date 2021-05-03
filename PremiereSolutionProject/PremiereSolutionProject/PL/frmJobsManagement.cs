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

    public partial class frmJobsManagement : Form
    {
        Job JB = new Job();
        int indexrow;

        public frmJobsManagement()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmJobsManagement_Load(object sender, EventArgs e)
        {
            //var myList = new List<List<PremiereSolutionProject.BLL.Job>>()
            //{
            //    JB.SelectPendngJobs(),
            //    JB.SelectInProgressJobs(),
            //    JB.SelectFinishedJobs()
            //};

            //ListViewItem[] lItem = myList.Select(
            //                               X => new ListViewItem(X.ToArray())
            //                         ).ToArray();
            //lstJobTracker.Items.AddRange(lItem);
            //

            //dgvJobs.DataSource = JB.SelectAllJobs(); //Displaying all jobs
        }

        private void dgvJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //indexrow = e.RowIndex;

            //DataGridViewRow row = dgvJobs.Rows[indexrow]; //Allowing the selected datagrid row to show in the textboxes

            //txtJobID.Text = row.Cells[0].Value.ToString();
            //txtAddressID.Text = row.Cells[1].Value.ToString();
            //cbxCurrentState.Text = row.Cells[2].Value.ToString(); //Need to identify the number as a state
            //rtbNotes.Text = row.Cells[3].Value.ToString();
            //txtServiceReqID.Text = row.Cells[4].Value.ToString();
            //rtbAssignedTechnicians.Text = row.Cells[5].Value.ToString(); // 2 Questions: Can a list show in a cell? Based on 1 - how?
            //cbxSpecialisationID.Text = row.Cells[6].Value.ToString(); //Need to identify the number as a specialisation
            //nudEmployees.Value = int.Parse(row.Cells[7].Value.ToString());
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            //JB.DeleteJob(Job); //Need to parse a job object to the delete method to delete
        }

        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            //JB.UpdateJob(Job); //Need to parse a job object to update
        }
    }
}
