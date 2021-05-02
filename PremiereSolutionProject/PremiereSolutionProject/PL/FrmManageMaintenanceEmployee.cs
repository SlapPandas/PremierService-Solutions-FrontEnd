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
    public partial class FrmManageMaintenanceEmployee : Form
    {
        public FrmManageMaintenanceEmployee()
        {
            InitializeComponent();
        }
        List<MaintenanceEmployee> me;
        MaintenanceEmployee me2;
        BindingSource bs = new BindingSource();
        MaintenanceEmployee selectedMe;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                me = new MaintenanceEmployee().SelectAllMaintenaceEmpployees();
                foreach (MaintenanceEmployee item in me)
                {
                    if (item.Id == txtSearch.Text)
                    {
                        me2 = item;
                        me = null;
                        me.Add(me2);
                        RefreshDGV();
                    }
                }
                RefreshDGV();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void FrmManageMaintenanceEmployee_Load(object sender, EventArgs e)
        {
            me = new MaintenanceEmployee().SelectAllMaintenaceEmpployees();
            RefreshDGV();
        }

        private void RefreshDGV()
        {
            bs.DataSource = me;
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = bs;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(txtBusinessName.Text))
        //        {
        //            throw new FormatException("No business name");
        //        }
        //        if (string.IsNullOrWhiteSpace(txtTaxNum.Text))
        //        {
        //            throw new FormatException("No tax number");
        //        }
        //        if (string.IsNullOrWhiteSpace(txtStreetName.Text))
        //        {
        //            throw new FormatException("No street name");
        //        }
        //        if (string.IsNullOrWhiteSpace(txtSuburb.Text))
        //        {
        //            throw new FormatException("No suburb");
        //        }
        //        if (string.IsNullOrWhiteSpace(txtCity.Text))
        //        {
        //            throw new FormatException("No city");
        //        }
        //        //if (string.IsNullOrWhiteSpace(cmbProvince.))
        //        //{
        //        //    throw new FormatException("No provinfce");
        //        //}
        //        if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
        //        {
        //            throw new FormatException("No postal code");
        //        }
        //        if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
        //        {
        //            throw new FormatException("No contact number");
        //        }

        //        else
        //        {

        //            Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
        //            BusinessClient bc = new BusinessClient(address, txtContactNumber.Text, DateTime.Now, txtTaxNum.Text, txtBusinessName.Text, true);
        //            bc.UpdateBusinessClient(bc);

        //            MessageBox.Show("Successfully updated business client", "Yay");
        //        }

        //    }
        //    catch (FormatException fe)
        //    {
        //        MessageBox.Show(fe.Message, "user input error");
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
        //    }
        }

        private void UpdateData()
        {
            //selectedProduct
            //foreach (Specialisation item in cbxSpecializations.Items)
            //{
            //    if (item.SpecialisationName == selectedMe.Specialisation)
            //    {
            //        cmbProvince.SelectedItem = item.Province;
            //        break;
            //    }
            //}


            txtAddress.Text = selectedMe.Address.ToString(); ;
            txtContactNumber.Text = selectedMe.ContactNumber;
            txtEmai.Text = selectedMe.Email;
            txtEmployeeID.Text = selectedMe.Id;
            txtFirstname.Text = selectedMe.FirstName;
            txtNationalID.Text = selectedMe.NationalIDnumber;
            txtSurname.Text = selectedMe.Surname;

        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            selectedMe = (MaintenanceEmployee)bs.Current;
            UpdateData();
        }
    }
}
