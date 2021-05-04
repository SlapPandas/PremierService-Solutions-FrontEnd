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
        MaintenanceEmployee MainEmp = new MaintenanceEmployee();
        int indexrow;
        int Index;
        List<Job> myJob = new List<Job>();
        List<MaintenanceEmployee> myEmployee = new List<MaintenanceEmployee>();
        BindingSource bs = new BindingSource();
        Job SelectedJob;
        List<Job> NewJobList = new List<Job>();


        public frmJobsManagement()
        {
            InitializeComponent();
            RefreshDGV();
            lbxAvailable.Items.Add(myEmployee);
        }

        private void RefreshDGV()
        {
            bs.DataSource = myJob;
            dgvJobs.DataSource = null;
            dgvJobs.DataSource = bs;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmJobsManagement_Load(object sender, EventArgs e)
        {

            foreach (Job J in JB.SelectAllJobs())
            {
                ListViewItem lst = new ListViewItem(new string[]
                {
                    J.JobID.ToString(),
                    J.JobState.ToString(),
                    J.JobNotes,
                  //  J.Specialisation.GetSpecialisationNames, Into another ListView
                    J.EmployeesNeeded.ToString(),
                    J.ServiceRequestID.ToString(),
                    J.PriorityLevel
                });

                lst.Tag = J;
                lstJobs.Items.Add(lst);

                NewJobList.Add(J);
            }


            myJob = JB.SelectAllJobs();
            dgvJobs.DataSource = myJob;

            myEmployee = MainEmp.SelectAllMaintenaceEmpployees();

            foreach (Job j in JB.SelectAllJobs())
            {
                ListViewItem lsty = new ListViewItem(new string[]
                {
                    j.JobID.ToString(),
                    j.JobState.ToString()
                });

                lstPending.Items.Add(lsty);
            }


            foreach (Job j in JB.SelectInProgressJobs())
            {
                ListViewItem lst = new ListViewItem(new string[]
                {
                    j.JobID.ToString(),
                    j.JobState.ToString()
                });

                //    lstInProgress.Items.Add(lst);
                //}

                //foreach (Job j in JB.SelectFinishedJobs())
                //{
                //    ListViewItem lst = new ListViewItem(new string[]
                //    {
                //        j.JobID.ToString(),
                //        j.JobState.ToString()
                //    });

                //    lstCompleted.Items.Add(lst);
                //}

            }
        }

        

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {

            //JB.DeleteJob(Job); //Need to parse a job object to the delete method to delete
            MessageBox.Show("Successfully deleted the job.");
        }

        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            //Validation that none off the fields are empty
            if (string.IsNullOrEmpty(cbxCurrentState.Text)) 
            {
                throw new FormatException("No State Chosen ");
            }
            else if (string.IsNullOrEmpty(rtbNotes.Text))
            {
                throw new FormatException("No State written");
            }
            else if (nudEmployees.Value < 0)
            {
                throw new FormatException("Invalid Numeric Selection");
            }
            else if (lbxCurrentAssigned.Items.Count == 0)
            {
                throw new FormatException("There are no current employees.");
            }


            //JB.UpdateJob(Job); //Need to parse a job object to update
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            lbxNewAssigned.Items.Add(lbxAvailable.SelectedItem.ToString());
        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {
            lbxCurrentAssigned.Items.RemoveAt(lbxCurrentAssigned.SelectedIndex);
        }

        public void UpdateJob()
        {
            //cbxCurrentState.Text = SelectedJob.JobState;
            //rtbNotes.Text = SelectedJob.JobNotes;
            //cbxSpecialisationName = SelectedJob.Specialisation;
            //nudEmployees.Value = SelectedJob.EmployeesNeeded;
            //lbxCurrentAssigned.Items.Add();


        }

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            SelectedJob = (Job)bs.Current;
            UpdateJob();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //if (lstJobs.SelectedItems.Count > 0 )
            //{
            //    Job NewJob = lstJobs.SelectedItems[0].Tag as Job;

            //    List<Specialisation> newSpList = new List<Specialisation>();

            //    List<Employee> NewEmp = new List<Employee>();

            //    newSpList.Add(NewJob[l);
            //}
            //else
            //{
            //    MessageBox.Show("No record wass selected ", "Jobs",MessageBoxButtons.OK);
            //}
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
