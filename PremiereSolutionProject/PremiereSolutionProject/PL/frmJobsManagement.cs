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
        MaintenanceEmployee MainEmp = new MaintenanceEmployee();
        List<MaintenanceEmployee> myEmployee = new List<MaintenanceEmployee>();
        BindingSource bs = new BindingSource();
        List<MaintenanceEmployee> NewEmp = new List<MaintenanceEmployee>();
        JobState st;
        int placeholder;
        List<MaintenanceEmployee> ME;


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

           
            ME = new MaintenanceEmployee().SelectAllMaintenaceEmpployees();

            foreach (MaintenanceEmployee m in ME)
            {
                lbxAvailTech.Items.Add(m.FirstName + ' ' + m.Id);
            }
        }

        

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            JB.DeleteJob(SelectedJob);
            MessageBox.Show("The job has been successfully deleted", "Delete Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbxCurrentState.Text = "";
            rtbNotes.Clear();
            nudEmployees.Value = 0;
            lbxNewAssigned.Items.Clear();
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
                throw new FormatException("No notes written");
            }
            else if (nudEmployees.Value < 0)
            {
                throw new FormatException("Invalid Numeric Selection");
            }
            else
            {
                if (myEmployee != null)
                {
                    SelectedJob.Employee = myEmployee; //List of new chosen employees
                }
                
                JB.UpdateJob(SelectedJob);
                MessageBox.Show("The job has been successfully updated", "Update Job", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbxCurrentState.Text = "";
                rtbNotes.Clear();
                nudEmployees.Value = 0;
                lbxNewAssigned.Items.Clear();

            }    
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            if (!lbxNewAssigned.Items.Contains(lbxAvailTech.SelectedItem.ToString()))
            {
                lbxNewAssigned.Items.Add(lbxAvailTech.SelectedItem.ToString());
                myEmployee.Add(lbxAvailTech.SelectedItem as MaintenanceEmployee); //Need to get listbox items added to the list of type maintenance employee
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
                Job NewJob = lstJobs.SelectedItems[0].Tag as Job; //Creates a job object of the current job 

                //int id, Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, int empsNeeded
                //public Job(Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, string priority, int empsNeeded)

                SelectedJob.JobID = NewJob.JobID;

                SelectedJob.JobAddress = NewJob.JobAddress;

                SelectedJob.ServiceRequestID = NewJob.ServiceRequestID;

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

                    lstViewAssemp.Items.Add(lst);
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
