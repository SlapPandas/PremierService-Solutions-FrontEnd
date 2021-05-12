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
        public frmBusinessContact(frmDashboard _dashForm) : this()
        {
            dashForm = _dashForm;
        }
        frmDashboard dashForm;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<BusinessClientEmployees> bce;
        List<BusinessClientEmployees> bceUpdate;
        BindingSource bs = new BindingSource();
        BusinessClientEmployees selectedBce;
        BusinessClient selectedBc;
        List<BusinessClient> bc;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessID.Text))
                {
                    throw new FormatException("No business id");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }
                if (string.IsNullOrWhiteSpace(txtDepartment.Text))
                {
                    throw new FormatException("No department");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    throw new FormatException("No email");
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    throw new FormatException("No first name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No sername");
                }
                else
                {

                    BusinessClientEmployees bce = new BusinessClientEmployees(txtName.Text,txtSurname.Text,txtDepartment.Text,txtContactNumber.Text,txtEmail.Text,txtBusinessID.Text);
                    bce.UpdateBusinessClientEmployee(bce);

                    MessageBox.Show("Successfully updated business client employee", "Yay");
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void frmBusinessContact_Load(object sender, EventArgs e)
        {
            dgvExistingBusinesses.ForeColor = Color.Black;
            bce = new BusinessClientEmployees().SelectAllBusinessClientEmployees();
            bc = new BusinessClient().SelectAllBusinessClients();
            RefreshDGV();
            RefreshDGV2();
        }
        private void RefreshDGV()
        {
            bs.DataSource = bc;
            dgvExistingBusinesses.DataSource = null;
            //dgvExistingBusinesses.DataSource = bs;

        }

        private void RefreshDGV2()
        {
            bs.DataSource = bce;
            dgvExistingEmployees.DataSource = null;
            dgvExistingEmployees.DataSource = bs;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            selectedBc = (BusinessClient)bs.Current;
            UpdateDgv();
        }
        private void UpdateDgv()
        {

            foreach (var item in bce)
            {
                if (selectedBc.Id == item.BusinessID)
                {
                    bceUpdate.Add(item);
                }
            }
            bs.DataSource = bceUpdate;
            dgvExistingEmployees.DataSource = null;
            dgvExistingEmployees.DataSource = bs;
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessID.Text))
                {
                    throw new FormatException("No business id");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }
                if (string.IsNullOrWhiteSpace(txtDepartment.Text))
                {
                    throw new FormatException("No department");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    throw new FormatException("No email");
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    throw new FormatException("No first name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No sername");
                }
                else
                {

                    BusinessClientEmployees bce = new BusinessClientEmployees(txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                    bce.InsertBusinessClientEmployee(bce);

                    MessageBox.Show("Successfully added business client employee", "Yay");
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessID.Text))
                {
                    throw new FormatException("No business id");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }
                if (string.IsNullOrWhiteSpace(txtDepartment.Text))
                {
                    throw new FormatException("No department");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    throw new FormatException("No email");
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    throw new FormatException("No first name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No sername");
                }
                else
                {

                    BusinessClientEmployees bce = new BusinessClientEmployees(txtName.Text, txtSurname.Text, txtDepartment.Text, txtContactNumber.Text, txtEmail.Text, txtBusinessID.Text);
                    bce.DeleteBusinessClientEmployee(bce);

                    MessageBox.Show("Successfully deleted business client employee", "Yay");
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void dgvExistingEmployees_SelectionChanged(object sender, EventArgs e)
        {
            selectedBce = (BusinessClientEmployees)bs.Current;
            
            UpdateData();
        }
    }
}
