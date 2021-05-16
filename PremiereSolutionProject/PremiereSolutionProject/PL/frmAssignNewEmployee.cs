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
    public partial class frmAssignNewEmployee : Form
    {
        List<Job> jobs = new List<Job>();
        List<MaintenanceEmployee> maintenanceEmployeesAvailable = new List<MaintenanceEmployee>();
        List<MaintenanceEmployee> maintenanceEmployeesHave = new List<MaintenanceEmployee>();
        Job job = new Job();
        ServiceRequest serviceRequest = new ServiceRequest();
        ServiceManager serviceManager = new ServiceManager();
        MaintenanceEmployee maintenanceEmployee = new MaintenanceEmployee();
        BindingSource bindingSource = new BindingSource();

        public frmAssignNewEmployee()
        {
            InitializeComponent();
        }

        private void GenerateDGV()
        {
            dgvAvailableTech.ColumnCount = 2;
            dgvAvailableTech.Columns[0].Name = "ID";
            dgvAvailableTech.Columns[1].Name = "Name";

            dgvAssignedTech.ColumnCount = 2;
            dgvAssignedTech.Columns[0].Name = "ID";
            dgvAssignedTech.Columns[1].Name = "Name";

            dgvViewJob.ColumnCount = 3;
            dgvViewJob.Columns[0].Name = "ID";
            dgvViewJob.Columns[1].Name = "Notes";
            dgvViewJob.Columns[2].Name = "Number of Employees needed";
            dgvViewJob.Columns[1].Width = 200;

            dgvViewJob.ForeColor = Color.Black;
            dgvAvailableTech.ForeColor = Color.Black;
            dgvAssignedTech.ForeColor = Color.Black;
        }

        private void RefreshDGVAndListForJobs()
        {
            if (dgvViewJob.Rows.Count != 0)
            {
                dgvViewJob.Rows.Clear();
            }
            jobs = job.SelectAllJobsNotFinished();
            List<Job> bindList = jobs;
            foreach (var item in bindList)
            {
                string[] row = { item.JobID.ToString(), item.JobNotes, item.EmployeesNeeded.ToString()};
                dgvViewJob.Rows.Add(row);
            }
        }

        private void frmAssignNewEmployee_Load(object sender, EventArgs e)
        {
            GenerateDGV();
            RefreshDGVAndListForJobs();
            RefreshDGVAvailable();
        }
        private void RefreshDGVEmployeesHave(int index)
        {
            maintenanceEmployeesHave = jobs[index].Employee;
            if (dgvAssignedTech.Rows.Count != 0)
            {
                dgvAssignedTech.Rows.Clear();
            }
            foreach (var item in jobs[index].Employee)
            {
                string[] row = { item.Id.ToString(), item.FirstName + " " + item.Surname };
                dgvAssignedTech.Rows.Add(row);
            }
        }
        private void RefreshDGVAvailable()
        {
            maintenanceEmployeesAvailable = serviceRequest.SelectAllAvailabeEmployees();
            if (dgvAvailableTech.Rows.Count != 0)
            {
                dgvAvailableTech.Rows.Clear();
            }
            foreach (var item in maintenanceEmployeesAvailable)
            {
                string[] row = { item.Id.ToString(), item.FirstName + " " + item.Surname };
                dgvAvailableTech.Rows.Add(row);
            }
        }

        private void dgvViewJob_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDGVEmployeesHave(dgvViewJob.CurrentCell.RowIndex);
            RefreshDGVAvailable();
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < maintenanceEmployeesHave.Count; i++)
            {
                if (maintenanceEmployeesHave[i].Id.ToString().Contains(maintenanceEmployeesAvailable[dgvAvailableTech.CurrentCell.RowIndex].Id.ToString()))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                string[] row = { maintenanceEmployeesAvailable[dgvAvailableTech.CurrentCell.RowIndex].Id.ToString(), maintenanceEmployeesAvailable[dgvAvailableTech.CurrentCell.RowIndex].FirstName + " " + maintenanceEmployeesAvailable[dgvAvailableTech.CurrentCell.RowIndex].Surname};
                dgvAssignedTech.Rows.Add(row);
                maintenanceEmployeesHave.Add(maintenanceEmployeesAvailable[dgvAvailableTech.CurrentCell.RowIndex]);
            }
        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < maintenanceEmployeesHave.Count; i++)
            {
                if (maintenanceEmployeesHave[i].Id.ToString().Contains(dgvAssignedTech.Rows[dgvAssignedTech.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                {
                    maintenanceEmployeesHave.RemoveAt(i);
                    break;
                }
            }
            dgvAssignedTech.Rows.RemoveAt(dgvAssignedTech.CurrentCell.RowIndex);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Update EmployeeList?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                jobs[dgvViewJob.CurrentCell.RowIndex].Employee = maintenanceEmployeesHave;
                serviceManager.UpdateJobEmployeeList(jobs[dgvViewJob.CurrentCell.RowIndex]);
            }
        }
    }
}
