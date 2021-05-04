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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<BusinessClientEmployees> bce;
        BindingSource bs = new BindingSource();
        BusinessClientEmployees selectedBce;
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
            bce = new BusinessClientEmployees().SelectAllBusinessClientEmployees();
            RefreshDGV();
        }
        private void RefreshDGV()
        {
            bs.DataSource = bce;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedBce = (BusinessClientEmployees)bs.Current;
            UpdateData();
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
    }
}
