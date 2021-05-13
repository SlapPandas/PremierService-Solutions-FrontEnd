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
        frmDashboard dashForm;
        
        
        BusinessClientEmployees selectedBce;
        BusinessClient selectedBc;
        

        List<BusinessClient> businessClientList = new List<BusinessClient>();
        BusinessClient businessclient = new BusinessClient();
        List<BusinessClientEmployees> businessEmployeeList = new List<BusinessClientEmployees>();
        BusinessClientEmployees businessEmployee = new BusinessClientEmployees();
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        
        public frmBusinessContact()
        {
            InitializeComponent();
        }
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
            

            DialogResult dr = MessageBox.Show("Are you sure to update The Business contact?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex] = new BusinessClientEmployees(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Id, txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                businessEmployee.UpdateBusinessClientEmployee(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex]);
                RefreshDGVAndList();
                //UpdateFields(dgvExistingClients.CurrentCell.RowIndex);
            }
        }

        private void frmBusinessContact_Load(object sender, EventArgs e)
        {
            
            RefreshDGVAndList();
            BuildDGVStyle();

        }
       
        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            selectedBc = (BusinessClient)bs.Current;
            UpdateDgv();
        }
        private void UpdateDgv()
        {
            
            businessEmployeeList = businessEmployee.SelectAllBusinessClientEmployees();
            
            List<BusinessClientEmployees> bindList = new List<BusinessClientEmployees>();
            
           
            foreach (var item in businessEmployeeList)
            {
                if (selectedBc.Id == item.BusinessID)
                {
                    bindList.Add(item);
                }
            }
           
            bs2 = new BindingSource(bindList, null);

            dgvExistingEmployees.DataSource = bs2;
        }
        private void UpdateData()
        {
            txtBusinessID.Text = selectedBce.BusinessID;
            txtContactNumber.Text = selectedBce.Contactnumber;
            txtDepartment.Text = selectedBce.Department;
            txtEmail.Text = selectedBce.Email;
            txtName.Text = selectedBce.FirstName;
            txtSurname.Text = selectedBce.Surname;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            DialogResult dr = MessageBox.Show("Are you sure to insert The Business contact?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex] = new BusinessClientEmployees(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Id, txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                businessEmployee.InsertBusinessClientEmployee(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex]);
                RefreshDGVAndList();
                UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                DialogResult dr = MessageBox.Show("Are you sure to update The Business contact?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex] = new BusinessClientEmployees(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex].Id, txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                    businessEmployee.DeleteBusinessClientEmployee(businessEmployeeList[dgvExistingEmployees.CurrentCell.RowIndex]);
                    RefreshDGVAndList();
                    UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
                }

           
        }

        private void dgvExistingEmployees_SelectionChanged(object sender, EventArgs e)
        {
            selectedBce = (BusinessClientEmployees)bs.Current;
            
            UpdateData();
        }

        private void BuildDGVStyle()
        {
            dgvExistingBusinesses.ForeColor = Color.Black;
            dgvExistingEmployees.ForeColor = Color.Black;
        }
        private void RefreshDGVAndList()
        {
            businessClientList = businessclient.SelectAllBusinessClients();
            
            List<BusinessClient> bindList = businessClientList;
           
            bs = new BindingSource(bindList, null);
            
            dgvExistingBusinesses.DataSource = bs;
            
        }
        private void UpdateFields(int index)
        {
            if (index <= dgvExistingEmployees.RowCount - 2)
            {
                txtBusinessID.Text = businessEmployeeList[index].Id.ToString();
                txtName.Text = businessEmployeeList[index].FirstName;
                txtSurname.Text = businessEmployeeList[index].Surname;
                txtDepartment.Text = businessEmployeeList[index].Department;
                txtContactNumber.Text = businessEmployeeList[index].Contactnumber;
                txtEmail.Text = businessEmployeeList[index].Email;
                
            }
        }

        private void dgvExistingEmployees_SelectionChanged_1(object sender, EventArgs e)
        {
            UpdateFields(dgvExistingEmployees.CurrentCell.RowIndex);
        }
    }
}
