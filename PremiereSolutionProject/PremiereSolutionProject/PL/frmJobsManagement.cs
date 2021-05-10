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
        List<Job> myJob = new List<Job>();
        List<MaintenanceEmployee> myEmployee = new List<MaintenanceEmployee>();
        BindingSource bs = new BindingSource();
        Job SelectedJob;
        List<Job> NewJobList = new List<Job>();
        List<MaintenanceEmployee> NewEmp = new List<MaintenanceEmployee>();
        Employee NewEmployee;

        List<MaintenanceEmployee> Availablelist = new List<MaintenanceEmployee>();
        List<MaintenanceEmployee> RemoveList = new List<MaintenanceEmployee>();


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

            //MaintenanceEmployee NewMEMP = new MaintenanceEmployee();

            //foreach (MaintenanceEmployee Emp in NewMEMP.SelectAllMaintenaceEmpployees())
            //{
            //    ListViewItem lst = new ListViewItem(new string[]
            //    {
            //            Emp.Id,
            //            Emp.FirstName,
            //            Emp.Surname
            //    });
            //    lst.Tag = Emp;
            //    lbxAvailable.Items.Add(lst);
            //    Availablelist.Add(Emp);
            //}


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

            }

            List<MaintenanceEmployee> ME;
            ME = new MaintenanceEmployee().SelectAllMaintenaceEmpployees();
            foreach (MaintenanceEmployee m in ME)
            {
                lbxAvailTech.Items.Add(m.FirstName + ' ' + m.Id);
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

        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            if (!lbxNewAssigned.Items.Contains(lbxAvailTech.SelectedItem.ToString()))
            {
                lbxNewAssigned.Items.Add(lbxAvailTech.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("The technician has already been newly assigned", "Add technicians Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {

            lbxNewAssigned.Items.RemoveAt(lbxNewAssigned.SelectedIndex);
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
            //lstViewAssemp.Clear();
            //cbxCurrentState.Items.Clear();

           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstViewAssemp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstJobs_MouseClick(object sender, MouseEventArgs e)
        {
            lstViewAssemp.Items.Clear();
            if (lstJobs.SelectedItems.Count > 0)
            {
                cmbSpec.Items.Clear();
                Job NewJob = lstJobs.SelectedItems[0].Tag as Job;

                rtbNotes.Text = NewJob.JobNotes;
                nudEmployees.Value = NewJob.EmployeesNeeded;

                JobState st;
                st = NewJob.JobState;

                if (st.ToString() == "Pending")
                {
                    cbxCurrentState.Text = "Pending";
                }
                if (st.ToString() == "InProgress")
                {
                    cbxCurrentState.Text = "InProgress";
                }
                if (st.ToString() == "Finished")
                {
                    cbxCurrentState.Text = "Finished";
                }

                Specialisation newSp = NewJob.Specialisation;

                List<Specialisation> newSpList = NewJob.Specialisation.GetSpecialisationNames();



                foreach (Specialisation sp in newSpList)
                {
                    cmbSpec.Items.Add(sp.SpecialisationName);
                }
                cmbSpec.Text = newSpList[0].SpecialisationName;



                NewEmp = NewJob.Employee;

                foreach (Employee ME in NewEmp)
                {
                    ListViewItem lst = new ListViewItem(new string[]
                     {
                            ME.Id,
                            ME.FirstName
                     });

                    lstViewAssemp.Items.Add(lst);
                }
            }
            else
            {
                MessageBox.Show("No record was selected ", "Jobs", MessageBoxButtons.OK);
            }
        }
    }
}
