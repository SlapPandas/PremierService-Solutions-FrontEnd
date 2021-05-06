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

            MaintenanceEmployee NewMEMP = new MaintenanceEmployee();

            foreach (MaintenanceEmployee Emp in NewMEMP.SelectAllMaintenaceEmpployees())
            {
                ListViewItem lst = new ListViewItem(new string[]
                {
                        Emp.Id,
                        Emp.FirstName,
                        Emp.Surname
                });
                lst.Tag = Emp;
                lstAvailable.Items.Add(lst);
                Availablelist.Add(Emp);
            }


            //myJob = JB.SelectAllJobs();

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

            //JB.UpdateJob(Job); //Need to parse a job object to update
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            //   lstNewAssigned.Items.Add(lstAvailable.SelectedIndices[0]);

            MainEmp = lstAvailable.SelectedItems[0].Tag as MaintenanceEmployee;

            ListViewItem lst = new ListViewItem(new string[]
                {
                        MainEmp.Id,
                        MainEmp.FirstName,
                        MainEmp.Surname
                });
            lst.Tag = MainEmp;
            lstNewAssigned.Items.Add(lst);
            lstAvailable.Items.Remove(lst);

            RemoveList.Add(MainEmp);
            Availablelist.Remove(MainEmp);

        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {

            MainEmp = lstAvailable.SelectedItems[0].Tag as MaintenanceEmployee;

            ListViewItem lst = new ListViewItem(new string[]
                {
                        MainEmp.Id,
                        MainEmp.FirstName,
                        MainEmp.Surname
                });
            lst.Tag = MainEmp;
            lstAvailable.Items.Add(lst);
            lstNewAssigned.Items.Remove(lst);
            RemoveList.Remove(MainEmp);
            Availablelist.Add(MainEmp);

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

            if (lstJobs.SelectedItems.Count > 0)
            {
                cmbSpec.Items.Clear();
                Job NewJob = lstJobs.SelectedItems[0].Tag as Job;

                rtbNotes.Text = NewJob.JobNotes;
                nudEmployees.Value = NewJob.EmployeesNeeded;

                JobState st;
                st = NewJob.JobState;

                if (st.ToString()=="Pending")
                {
                    cbxCurrentState.Text = "Pending";
                }
                if (st.ToString() == "In Progress")
                {
                    cbxCurrentState.Text = "In Progress";
                }
                if (st.ToString() == "Finshed")
                {
                    cbxCurrentState.Text = "Finished";
                }

                Specialisation newSp = NewJob.Specialisation; //Not a list of specialisations?

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstViewAssemp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
