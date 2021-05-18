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

        public frmJobsManagement()
        {
            InitializeComponent();
        }

        #region Declarations

        List<Job> jobs = new List<Job>();
        Job job = new Job();

        #endregion

        #region Events

        private void frmJobsManagement_Load(object sender, EventArgs e)
        {
            GenerateDGV();
            PopulateComboBox();
            RefreshDGVAndListForJobs();
        }

        private void dgvViewJob_SelectionChanged(object sender, EventArgs e)
        {
            UpdateFields(dgvViewJob.CurrentCell.RowIndex);
            RefreshDGVAndListForEmployees(dgvViewJob.CurrentCell.RowIndex);
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            if (dgvViewJob.CurrentCell.RowIndex <= jobs.Count - 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure to Delete The job?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    job.DeleteJob(jobs[dgvViewJob.CurrentCell.RowIndex]);
                    RefreshDGVAndListForJobs();
                    UpdateFields(dgvViewJob.CurrentCell.RowIndex);
                    RefreshDGVAndListForEmployees(dgvViewJob.CurrentCell.RowIndex);
                }
            }
            else
            {
                MessageBox.Show("selected item can not be deleted");
            }
            
        }

        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            if (dgvViewJob.CurrentCell.RowIndex <= jobs.Count - 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure to Update The job?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    jobs[dgvViewJob.CurrentCell.RowIndex].JobNotes = txtNotes.Text;
                    jobs[dgvViewJob.CurrentCell.RowIndex].JobState = GetJobState(cbxCurrentState.SelectedIndex+"");
                    jobs[dgvViewJob.CurrentCell.RowIndex].EmployeesNeeded = (int)nudEmployees.Value;
                    job.UpdateJob(jobs[dgvViewJob.CurrentCell.RowIndex]);
                    RefreshDGVAndListForJobs();
                    UpdateFields(dgvViewJob.CurrentCell.RowIndex);
                    RefreshDGVAndListForEmployees(dgvViewJob.CurrentCell.RowIndex);
                }
            }
            else
            {
                MessageBox.Show("selected item can not be deleted");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private void GenerateDGV()
        {
            dgvViewJob.ColumnCount = 10;
            dgvViewJob.Columns[0].Name = "ID";
            dgvViewJob.Columns[1].Name = "Current state";
            dgvViewJob.Columns[2].Name = "Number of Employees needed";
            dgvViewJob.Columns[3].Name = "Specilization";
            dgvViewJob.Columns[4].Name = "Priority Level";
            dgvViewJob.Columns[5].Name = "StreetnName";
            dgvViewJob.Columns[6].Name = "Suburb";
            dgvViewJob.Columns[7].Name = "City";
            dgvViewJob.Columns[8].Name = "Province";
            dgvViewJob.Columns[9].Name = "Postal code";

            dgvEmployees.ColumnCount = 2;
            dgvEmployees.Columns[0].Name = "ID";
            dgvEmployees.Columns[1].Name = "Name";

            dgvViewJob.ForeColor = Color.Black;
            dgvEmployees.ForeColor = Color.Black;
        }
        private void PopulateComboBox()
        {
            for (int i = 0; i < 3; i++)
            {
                cbxCurrentState.Items.Add(GetJobState(i + ""));
            }
        }
        private JobState GetJobState(string input)
        {
            JobState jobState = (JobState)1;

            switch (input)
            {
                case "0":
                    jobState = (JobState)0;
                    break;
                case "1":
                    jobState = (JobState)1;
                    break;
                case "2":
                    jobState = (JobState)2;
                    break;
                default:
                    jobState = (JobState)1;
                    break;
            }
            return jobState;
        }
        private void RefreshDGVAndListForJobs()
        {
            if (dgvViewJob.Rows.Count != 0)
            {
                dgvViewJob.Rows.Clear();
            }
            jobs = job.SelectAllJobs();
            foreach (var item in jobs)
            {
                string[] row = { item.JobID.ToString(), item.JobState.ToString(), item.EmployeesNeeded.ToString(), item.Specialisation.SpecialisationName, item.PriorityLevel, item.JobAddress.StreetName, item.JobAddress.Suburb, item.JobAddress.City, item.JobAddress.Province.ToString(), item.JobAddress.Postalcode.ToString() };
                dgvViewJob.Rows.Add(row);
            }
        }
        private void RefreshDGVAndListForEmployees(int index)
        {
            if (index <= jobs.Count - 1)
            {
                if (dgvEmployees.Rows.Count != 0)
                {
                    dgvEmployees.Rows.Clear();
                }
                foreach (var item in jobs[index].Employee)
                {
                    string[] row = { item.Id.ToString(), item.FirstName + " " + item.Surname };
                    dgvEmployees.Rows.Add(row);
                }
            }
        }
        private void UpdateFields(int index)
        {
            if (index <= jobs.Count - 1)
            {
                txtNotes.Text = jobs[index].JobNotes;
                cbxCurrentState.SelectedItem = jobs[index].JobState;
                nudEmployees.Value = jobs[index].EmployeesNeeded;
            }

        }

        #endregion

        private void cbxCurrentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)jobs[dgvViewJob.CurrentCell.RowIndex].JobState > cbxCurrentState.SelectedIndex)
            {
                MessageBox.Show("you can not select a previous state");
                cbxCurrentState.SelectedIndex = (int)jobs[dgvViewJob.CurrentCell.RowIndex].JobState;
            }
        }
    }
}
