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
    public partial class frmBusinessContact : Form
    {
        public frmBusinessContact()
        {
            InitializeComponent();
        }

        #region Declarations

        frmDashboard dashForm;
        List<BusinessClient> businessClientList = new List<BusinessClient>();
        BusinessClient myBusinessclient = new BusinessClient();
        List<BusinessClientEmployees> businessEmployeeList = new List<BusinessClientEmployees>();
        BusinessClientEmployees myBusinessEmployee = new BusinessClientEmployees();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        public frmBusinessContact(frmDashboard _dashForm) : this()
        {
            dashForm = _dashForm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to update "+ businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].FirstName + " " + businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Surname + "?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex] = new BusinessClientEmployees(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Id, txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                myBusinessEmployee.UpdateBusinessClientEmployee(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex]);
                RefreshDGVAndList();
            }
        }

        private void frmBusinessContact_Load(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            BuildDGVStyle();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to insert a new business contact for " + businessClientList[dgvExistingBusinesses.CurrentCell.RowIndex].BusinessName  + "? ", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                businessEmployeeList.Add(new BusinessClientEmployees(txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text));
                myBusinessEmployee.InsertBusinessClientEmployee(businessEmployeeList[businessEmployeeList.Count-1]);
                RefreshDGVAndList();
                UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
            }
        }

        private void dgvExistingEmployees_SelectionChanged(object sender, EventArgs e)
        {
            UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure to delete "+ businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].FirstName + " " + businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Surname + " for " + businessClientList[dgvExistingBusinesses.CurrentCell.RowIndex].BusinessName + "?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex] = new BusinessClientEmployees(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Id, txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                myBusinessEmployee.DeleteBusinessClientEmployee(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex]);
                RefreshDGVAndList();
                UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
            }
        }

        private void dgvExistingBusinesses_SelectionChanged(object sender, EventArgs e)
        {
            UpdateBusinessIDField(dgvExistingBusinesses.CurrentCell.RowIndex);
            UpdateDGVBusinessEmployee();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        #endregion

        #region Methods

        private void UpdateBusinessIDField(int index)
        {
            if (index <= dgvExistingBusinesses.RowCount - 2)
            {
                txtBusinessID.Text = businessClientList[index].Id.ToString();
            }
        }

        private void UpdateFields(int index)
        {
            if (index >= businessEmployeeList.Count)
            {
                index = 0;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }


            if (index <= dgvExistingEmployees.RowCount - 2 && businessEmployeeList.Count > 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                txtName.Text = businessEmployeeList[index].FirstName;
                txtSurname.Text = businessEmployeeList[index].Surname;
                txtDepartment.Text = businessEmployeeList[index].Department;
                txtContactNumber.Text = businessEmployeeList[index].Contactnumber;
                txtEmail.Text = businessEmployeeList[index].Email;
            }
            else
            {
                ClearTextBoxes();
            }
        }

        private void BuildDGVStyle()
        {
            dgvExistingBusinesses.ForeColor = Color.Black;
            dgvExistingEmployees.ForeColor = Color.Black;
        }

        private void RefreshDGVAndList()
        {
            businessClientList = myBusinessclient.SelectAllBusinessClients();
            List<BusinessClient> bindList = businessClientList;
            bindingSource = new BindingSource(bindList, null);
            dgvExistingBusinesses.DataSource = bindingSource;
        }

        private void UpdateDGVBusinessEmployee()
        {
            businessEmployeeList.Clear();
            businessEmployeeList = myBusinessEmployee.SelectAllBusinessClientEmployeesByBusinessName(txtBusinessID.Text);
            List<BusinessClientEmployees> bindList = businessEmployeeList;
            bindingSource = new BindingSource(bindList, null);
            dgvExistingEmployees.DataSource = bindingSource;
        }

        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtDepartment.Text = "";
            txtContactNumber.Text = "";
        }

        #endregion

    }
}
