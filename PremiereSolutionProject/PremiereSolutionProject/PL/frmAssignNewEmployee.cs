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
        #region Declarations
        List<MaintenanceEmployee> myEmployee = new List<MaintenanceEmployee>();
        List<MaintenanceEmployee> allMaintenanceEmployees = new List<MaintenanceEmployee>();
        MaintenanceEmployee myMaintenanceEmployee = new MaintenanceEmployee();
        #endregion

        public frmAssignNewEmployee()
        {
            InitializeComponent();
        }

        private void frmAssignNewEmployee_Load(object sender, EventArgs e)
        {
            allMaintenanceEmployees = myMaintenanceEmployee.SelectAllMaintenaceEmpployees();
            FormatForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("The technician has already been assigned.", "Add technicians Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {
            lbxNewAssigned.Items.RemoveAt(lbxNewAssigned.SelectedIndex);
        }

        #region Methods

        private void PopulateDGV()
        {
            dgvViewEmp.Rows.Clear();
            dgvViewEmp.Refresh();
            List<MaintenanceEmployee> bindingList = allMaintenanceEmployees;
            var source = new BindingSource(bindingList, null);
            dgvViewEmp.DataSource = source;
        }

        private void FormatForm()
        {
            dgvViewEmp.ForeColor = Color.Black;
            PopulateDGV();
        }

        #endregion
    }
}
