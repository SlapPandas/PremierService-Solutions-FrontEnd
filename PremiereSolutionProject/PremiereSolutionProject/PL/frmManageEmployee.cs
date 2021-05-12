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
    public partial class frmManageEmployee : Form
    {
        public frmManageEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    throw new FormatException("No employee identification");
                }
                if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                {
                    throw new FormatException("No employee name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No employee surname");
                }
                if (string.IsNullOrWhiteSpace(txtNationalID.Text))
                {
                    throw new FormatException("No employee national ID");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No employee Contact number");
                }
                if (string.IsNullOrWhiteSpace(txtEmai.Text))
                {
                    throw new FormatException("No employee e-mail");
                }

                else
                {
                    //Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
                   // Employee emp = new Employee(txtFirstname.Text,txtSurname.Text,null,txtContactNumber.Text,txtEmai.Text,txtNationalID.Text,DateTime.Now(),true,cbxDepartment.Text)
                    MessageBox.Show("Successfully created Employee", "Yay");
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
