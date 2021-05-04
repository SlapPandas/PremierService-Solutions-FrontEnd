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
            List<Specialisation> sp = new Specialisation().SelectSpecialisationList();
            foreach (Specialisation item in sp)
            {
                cbxSpecializations.Items.Add(item.SpecialisationName.ToString());
            }
            RefreshDGV();
            //List<string> prov = new Province().ToString();
            //foreach (Province item in prov)
            //{
            //    cbxSpecializations.Items.Add(item.SpecialisationName.ToString());
            //}
        }

        private void RefreshDGV()
        {
            bs.DataSource = me;
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = bs;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    throw new FormatException("No city");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }
                if (string.IsNullOrWhiteSpace(txtEmai.Text))
                {
                    throw new FormatException("No email");
                }
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    throw new FormatException("No employee id");
                }
                if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                {
                    throw new FormatException("No first name");
                }
                if (string.IsNullOrWhiteSpace(cbxProvince.Text))
                {
                    throw new FormatException("No provinfce");
                }
                if (string.IsNullOrWhiteSpace(cbxSpecializations.Text))
                {
                    throw new FormatException("No specialisation");
                }
                if (string.IsNullOrWhiteSpace(txtNationalID.Text))
                {
                    throw new FormatException("No national id");
                }
                if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
                {
                    throw new FormatException("No postal code");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No street name");
                }
                if (string.IsNullOrWhiteSpace(txtSuburb.Text))
                {
                    throw new FormatException("No suburb");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No surname");
                }
                else
                {
                    bool available;
                    if (cbxAvailable.Checked == true)
                    {
                        available = true;
                    }
                    Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cbxProvince.SelectedIndex, txtPostalCode.Text);
                   // MaintenanceEmployee me = new MaintenanceEmployee(txtFirstname.Text,txtSurname.Text,address,txtContactNumber.Text,txtEmai.Text,txtNationalID.Text,DateTime.Now(),,available,);
                    //me.(bc);

                    MessageBox.Show("Successfully updated business client", "Yay");
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

        private void UpdateData()
        {
            
            foreach (Specialisation item in cbxSpecializations.Items)
            {
                if (item.SpecialisationName == selectedMe.Specialisations.ToString())
                {
                    cbxSpecializations.SelectedItem = item.SpecialisationName;
                    break;
                }
            }

            foreach (Address item in cbxProvince.Items)
            {
                if (item.Province == selectedMe.Address.Province)
                {
                    cbxProvince.SelectedItem = item.Province;
                    break;
                }
            }

            txtStreetName.Text = selectedMe.Address.ToString(); ;
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
