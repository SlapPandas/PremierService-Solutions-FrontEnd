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
    public partial class frmIndividualClient : Form
    {
        public frmIndividualClient()
        {
            InitializeComponent();
            
        }

        List<IndividualClient> ic;
        IndividualClient ic2;
        BindingSource bs = new BindingSource();
        IndividualClient selectedIc;

        private void frmAddIndividualClient_Load(object sender, EventArgs e)
        {
            ic = new IndividualClient().SelectAllIndividualClients();
            RefreshDGV();
        }
        private void RefreshDGV()
        {
            bs.DataSource = ic;
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = bs;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    throw new FormatException("No client identification");
                }
                if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                {
                    throw new FormatException("No client name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No client surname");
                }
                if (string.IsNullOrWhiteSpace(txtNationalID.Text))
                {
                    throw new FormatException("No client national ID");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No client address");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No client Contact number");
                }
                if (string.IsNullOrWhiteSpace(txtEmai.Text))
                {
                    throw new FormatException("No client e-mail");
                }

                else
                {
                    Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
                    IndividualClient ic = new IndividualClient(txtFirstname.Text, txtSurname.Text, address, txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, DateTime.Now, true);
                    ic.InsertIndividualClient(ic);
                    MessageBox.Show("Successfully created client", "Yay");
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

        private void btnUpdateIndiClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    throw new FormatException("No client identification");
                }
                if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                {
                    throw new FormatException("No client name");
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    throw new FormatException("No client surname");
                }
                if (string.IsNullOrWhiteSpace(txtNationalID.Text))
                {
                    throw new FormatException("No client national ID");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No client address");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No client Contact number");
                }
                if (string.IsNullOrWhiteSpace(txtEmai.Text))
                {
                    throw new FormatException("No client e-mail");
                }

                else
                {
                    Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
                    IndividualClient ic = new IndividualClient(txtFirstname.Text, txtSurname.Text, address, txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, DateTime.Now, true);
                    ic.UpdateClient(ic);
                    MessageBox.Show("Successfully created client", "Yay");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ic = new IndividualClient().SelectAllIndividualClients();
                foreach (IndividualClient item in ic)
                {
                    if (item.Id == txtSearch.Text)
                    {
                        ic2 = item;
                        ic = null;
                        ic.Add(ic2);
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

        private void UpdateData()
        {
            //selectedProduct
            foreach (Address item in cmbProvince.Items)
            {
                if (item.Province == selectedIc.Address.Province)
                {
                    cmbProvince.SelectedItem = item.Province;
                    break;
                }
            }


            txtCity.Text = selectedIc.Address.City;
            txtContactNumber.Text = selectedIc.ContactNumber;
            txtEmai.Text = selectedIc.Email;
            txtFirstname.Text = selectedIc.FirstName;
            txtID.Text = selectedIc.Id;
            txtNationalID.Text = selectedIc.NationalIDnumber;
            txtPostalCode.Text = selectedIc.Address.Postalcode;
            txtSuburb.Text = selectedIc.Address.Suburb;
            txtStreetName.Text = selectedIc.Address.StreetName;
            txtSurname.Text = selectedIc.Surname;
            
           
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            selectedIc = (IndividualClient)bs.Current;
            UpdateData();
        }
    }
}
