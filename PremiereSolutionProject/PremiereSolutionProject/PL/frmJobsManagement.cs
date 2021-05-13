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
        Job SelectedJob = new Job();
        Specialisation special = new Specialisation();
        List <MaintenanceEmployee> MainEmp = new List<MaintenanceEmployee>();
        List<MaintenanceEmployee> myEmployee = new List<MaintenanceEmployee>();
        BindingSource bs = new BindingSource();
        List<MaintenanceEmployee> NewEmp = new List<MaintenanceEmployee>();
        JobState st;
        List<MaintenanceEmployee> ME;
        ServiceRequest SR = new ServiceRequest();
        ServiceManager SM = new ServiceManager();
        string stdOutput = "{0,-10}{1,-20}";
        Job NewJob;


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
            lbxAvailTech.Items.Add(String.Format(stdOutput,"ID","Name"));
            lbxCurrentAssignedTech.Items.Add(String.Format(stdOutput, "ID", "Name"));

            foreach (Job J in JB.SelectAllJobs())
            {
                ListViewItem lst = new ListViewItem(new string[]
                {
                    J.JobID.ToString(),
                    J.JobState.ToString(),
                    J.JobNotes,
                    J.EmployeesNeeded.ToString(),
                    J.ServiceRequestID.ToString(),
                    J.PriorityLevel
                });

                lst.Tag = J;
                lstJobs.Items.Add(lst);

                List<Job> NewJobList = new List<Job>();
                NewJobList.Add(J);
            }

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

           
            ME = SR.SelectAllAvailabeEmployees();

            foreach (MaintenanceEmployee m in ME)
            {
                lbxAvailTech.Items.Add(String.Format(stdOutput, m.FirstName, m.Id));
            }
        }

        
        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            JB.DeleteJob(SelectedJob);
            MessageBox.Show("The job has been successfully deleted", "Delete Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbxCurrentState.Text = "";
            rtbNotes.Clear();
            nudEmployees.Value = 0;
        }

        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            int jobstateindex;

            if (Enumerable.SequenceEqual(SelectedJob.Employee, NewJob.Employee))
            {
                SM.UpdateJobEmployeeList(SelectedJob);
            }

            else
            {
                MessageBox.Show("The two lists are the same. ");
            }
            
            if (myEmployee != null)
            {
                SelectedJob.Employee = myEmployee; //List of new chosen employees
            }

            if (SelectedJob.JobState != NewJob.JobState)
            {
                 jobstateindex = Array.IndexOf(Enum.GetValues(SelectedJob.JobState.GetType()), SelectedJob.JobState);
                 SM.UpdateJobState(SelectedJob.JobID,jobstateindex);
            }


            JB.UpdateJob(SelectedJob);
            MessageBox.Show("The job has been successfully updated", "Update Job", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cbxCurrentState.Text = "";
            rtbNotes.Clear();
            nudEmployees.Value = 0;
            lbxCurrentAssignedTech.Items.Clear();

            
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            if (lbxAvailTech.SelectedItem != null)
            {
                lbxCurrentAssignedTech.Items.Add(lbxAvailTech.SelectedItem);
                SelectedJob.Employee.Add(lbxAvailTech.SelectedItem as MaintenanceEmployee); //Need to get listbox items added to the list of type maintenance employee
                
                
                lbxAvailTech.Items.RemoveAt(lbxAvailTech.SelectedIndex);               
            }
            else
            {
                MessageBox.Show("The technician has already been newly assigned", "Add technicians Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {

            if (lbxCurrentAssignedTech.SelectedItem != null)
            {
                lbxAvailTech.Items.Add(lbxCurrentAssignedTech.SelectedItem);
                lbxCurrentAssignedTech.Items.RemoveAt(lbxCurrentAssignedTech.SelectedIndex);
                SelectedJob.Employee.Remove(lbxCurrentAssignedTech.SelectedItem as MaintenanceEmployee);
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

        private void lstJobs_MouseClick(object sender, MouseEventArgs e)
        {
            lbxCurrentAssignedTech.Items.Clear();

            if (lstJobs.SelectedItems.Count > 0)
            {
                NewJob = lstJobs.SelectedItems[0].Tag as Job; //Creates a job object of the current job 

                SelectedJob.JobID = NewJob.JobID;

                SelectedJob.JobAddress = NewJob.JobAddress;

                SelectedJob.ServiceRequestID = NewJob.ServiceRequestID;
                                
                SelectedJob.Employee = NewJob.Employee;

                foreach (MaintenanceEmployee m in NewJob.Employee)
                {
                    lbxCurrentAssignedTech.Items.Add(String.Format(stdOutput, m.FirstName, m.Id));
                }

                rtbNotes.Text = NewJob.JobNotes; // Gets the notes of the current job
                SelectedJob.JobNotes = NewJob.JobNotes;

                nudEmployees.Value = NewJob.EmployeesNeeded; //Number of current job employees needed
                SelectedJob.EmployeesNeeded = NewJob.EmployeesNeeded;
               
                st = NewJob.JobState; //Gets the current job state
                SelectedJob.JobState = st;
               


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

                SelectedJob.Specialisation = NewJob.Specialisation;
                cbxSpecialisation.Text = NewJob.Specialisation.SpecialisationName;

                NewEmp = NewJob.Employee; //Maintenance Employee List 
                SelectedJob.Employee = NewEmp;

                foreach (Employee ME in NewEmp)
                {
                    ListViewItem lst = new ListViewItem(new string[]
                     {
                            ME.Id,
                            ME.FirstName
                     });
                }

                SelectedJob.PriorityLevel = NewJob.PriorityLevel;
            }
            else
            {
                MessageBox.Show("No record was selected ", "Jobs", MessageBoxButtons.OK);
            }
        }
    }
}
