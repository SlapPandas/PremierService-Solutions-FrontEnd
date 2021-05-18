using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PremiereSolutionProject.BLL;

namespace PremiereSolutionProject.PL
{
    public partial class frmManageEmployee : Form
    {
        public frmManageEmployee()
        {
            InitializeComponent();
        }

        #region Declarations

        List<Employee> employees = new List<Employee>();
        Employee employee = new MaintenanceEmployee();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageEmployee_Load(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            BuildDGVStyle();
            PopulateComboBox();
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            UpdateFields(dgvEmployee.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Delete The Employee?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ServiceManager serviceManager = new ServiceManager();
                serviceManager.UpdateEmployeestate(employees[dgvEmployee.CurrentCell.RowIndex].Id, false);
                RefreshDGVAndList();
                UpdateFields(dgvEmployee.CurrentCell.RowIndex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to update The Employee?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(dgvEmployee.CurrentCell.RowIndex, txtNationalID.Text, txtEmai.Text, txtContactNumber.Text) && checkValidNationalId(txtNationalID.Text) && checkValidContactNumber(txtContactNumber.Text) && checkValidEmail(txtEmai.Text))
                {
                    UpdateSpecificEmployee();
                    employee.UpdateEmployee(employees[dgvEmployee.CurrentCell.RowIndex]);
                    RefreshDGVAndList();
                    UpdateFields(dgvEmployee.CurrentCell.RowIndex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Insert The Employee?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(-1, txtNationalID.Text, txtEmai.Text, txtContactNumber.Text) && checkValidNationalId(txtNationalID.Text) && checkValidContactNumber(txtContactNumber.Text) && checkValidEmail(txtEmai.Text))
                {
                    AddNewEmployee();
                    employee.InsertEmployee(employees[employees.Count - 1]);
                    RefreshDGVAndList();
                    UpdateFields(dgvEmployee.CurrentCell.RowIndex);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BruteSearch(txtSearch.Text);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            txtSearch.Text = "";
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        #endregion

        #region Methods

        private void PopulateComboBox()
        {
            for (int i = 0; i < 9; i++)
            {
                cmbProvince.Items.Add(GetProvince(i + ""));
            }
        }

        private Province GetProvince(string input)
        {
            Province province = (Province)1;

            switch (input)
            {
                case "0":
                    province = (Province)0;
                    break;
                case "1":
                    province = (Province)1;
                    break;
                case "2":
                    province = (Province)2;
                    break;
                case "3":
                    province = (Province)3;
                    break;
                case "4":
                    province = (Province)4;
                    break;
                case "5":
                    province = (Province)5;
                    break;
                case "6":
                    province = (Province)6;
                    break;
                case "7":
                    province = (Province)7;
                    break;
                case "8":
                    province = (Province)8;
                    break;
                default:
                    province = (Province)1;
                    break;
            }
            return province;
        }

        private void BuildDGVStyle()
        {
            dgvEmployee.ForeColor = Color.Black;
        }

        private void RefreshDGVAndList()
        {
            employees = employee.SelectAllEmpployees();
            List<Employee> bindList = employees;
            bindingSource = new BindingSource(bindList, null);
            dgvEmployee.DataSource = bindingSource;
        }

        private void RefreshDGVAndListWithoutListRefresh()
        {
            List<Employee> bindList = employees;
            bindingSource = new BindingSource(bindList, null);
            dgvEmployee.DataSource = bindingSource;
        }

        private void UpdateFields(int index)
        {
            if (index <= dgvEmployee.RowCount - 2)
            {
                if (index >= dgvEmployee.RowCount - 2)
                {
                    index = employees.Count - 1;
                }
                txtEmployeeID.Text = employees[index].Id;
                txtFirstname.Text = employees[index].FirstName;
                txtSurname.Text = employees[index].Surname;
                txtContactNumber.Text = employees[index].ContactNumber;
                txtNationalID.Text = employees[index].NationalIDnumber;
                cbmDepartment.SelectedIndex = cbmDepartment.FindStringExact(employees[index].Department);
                cmbEmployed.SelectedIndex = GetIntFromBool(employees[index].Employed);
                txtStreetName.Text = employees[index].Address.StreetName;
                txtSuburb.Text = employees[index].Address.Suburb;
                txtCity.Text = employees[index].Address.City;
                cmbProvince.SelectedItem = employees[index].Address.Province;
                txtPostalCode.Text = employees[index].Address.Postalcode;
                txtEmai.Text = employees[index].Email;
                txtEmployeedDate.Text = employees[index].RegistrationDate.ToString("yyy/MM/dd");
                cmbActive.SelectedIndex = GetIntFromBool(employees[index].Employed);
            }
        }

        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }

        private int GetIntFromBool(bool input)
        {
            if (input == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void UpdateSpecificEmployee()
        {
            switch (employees[dgvEmployee.CurrentCell.RowIndex].GetType().Name)
            {
                case "CallCenterEmployee":
                    employees[dgvEmployee.CurrentCell.RowIndex] = new CallCenterEmployee(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(employees[dgvEmployee.CurrentCell.RowIndex].Address.AddressID, txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text);
                    break;
                case "MaintenanceEmployee":
                    employees[dgvEmployee.CurrentCell.RowIndex] = new MaintenanceEmployee(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(employees[dgvEmployee.CurrentCell.RowIndex].Address.AddressID, txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text);
                    break;
                case "ServiceManager":
                    employees[dgvEmployee.CurrentCell.RowIndex] = new ServiceManager(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(employees[dgvEmployee.CurrentCell.RowIndex].Address.AddressID, txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text);
                    break;
            }
        }

        private void AddNewEmployee() 
        {
            switch (cbmDepartment.Text)
            {
                case "Call Center":
                    employees.Add(new CallCenterEmployee(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text));
                    break;
                case "Maintenance":
                    employees.Add(new MaintenanceEmployee(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text));
                    break;
                case "Service Manager":
                    employees.Add(new ServiceManager(employees[dgvEmployee.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, employees[dgvEmployee.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex), cbmDepartment.Text));
                    break;
            }
        }

        private void BruteSearch(string id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    List<Employee> temp = new List<Employee>();
                    temp.Add(employees[i]);
                    employees = temp;
                    break;
                }
            }
            RefreshDGVAndListWithoutListRefresh();
        }

        private void ClearFields()
        {
                txtEmployeeID.Text = "";
                txtFirstname.Text = "";
                txtSurname.Text = "";
                txtContactNumber.Text = "";
                txtNationalID.Text = "";
                cbmDepartment.SelectedIndex = -1;
                cmbEmployed.SelectedIndex = -1;
                txtStreetName.Text = "";
                txtSuburb.Text = "";
                txtCity.Text = "";
                cmbProvince.SelectedIndex = -1;
                txtPostalCode.Text = "";
                txtEmai.Text = "";
                txtEmployeedDate.Text = "";
                cmbActive.SelectedIndex = -1;
        }

        private bool CheckForDuplicates(int excluded, string nationalId, string email, string contactNumber)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (i != excluded)
                {
                    if ((employees[i].NationalIDnumber == nationalId || employees[i].Email == email || employees[i].ContactNumber == contactNumber) && employees[i].Employed == true)
                    {
                        MessageBox.Show("Please ensure that the ID number, email address or contact number does not exist in the system already.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkValidNationalId(string id)
        {
            if (id.Length == 13)
            {
                return true;
            }
            MessageBox.Show("Please ensure that the ID number contains only 13 digits.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool checkValidContactNumber(string id)
        {
            if (id.Length == 10)
            {
                return true;
            }
            MessageBox.Show("Please ensure that the contact number only has 10 digits.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool checkValidEmail(string id)
        {
            EmailAddressAttribute email = new EmailAddressAttribute();
            if (email.IsValid(id))
            {
                return true;
            }
            MessageBox.Show("Please ensure that the email is valid.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        #endregion
    }
}
