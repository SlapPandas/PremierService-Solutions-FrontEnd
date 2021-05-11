using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PremiereSolutionProject.PL
{
    public partial class frmBusinessClient : Form
    {
        public frmBusinessClient()
        {
            InitializeComponent();
        }
        List<BusinessClient> bc;
        BusinessClient bc2;
        BindingSource bs = new BindingSource();
        BusinessClient selectedBc;

        private void frmAddBusinessClient_Load(object sender, EventArgs e)
        {
            dgvBusinessClients.ForeColor = Color.Black;
            bc = new BusinessClient().SelectAllBusinessClients();
            RefreshDGV();
            cmbProvince.Items.Add("North_West");
            cmbProvince.Items.Add("Gauteng");
            cmbProvince.Items.Add("Western_Cape");
            cmbProvince.Items.Add("Eastern_Cape");
            cmbProvince.Items.Add("Free_State");
            cmbProvince.Items.Add("Northern_Cape");
            cmbProvince.Items.Add("Mpumalanga");
            cmbProvince.Items.Add("Limpopo");
            cmbProvince.Items.Add("Kwazulu_Natal");
            //btnDeleteClient.Enabled = false;
        }
        private void RefreshDGV()
        {
            bs.DataSource = bc;
            dgvBusinessClients.DataSource = null;
            dgvBusinessClients.DataSource = bs;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessName.Text))
                {
                    throw new FormatException("No business name");
                }
                if (string.IsNullOrWhiteSpace(txtTaxNum.Text))
                {
                    throw new FormatException("No tax number");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No street name");
                }
                if (string.IsNullOrWhiteSpace(txtSuburb.Text))
                {
                    throw new FormatException("No suburb");
                }
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    throw new FormatException("No city");
                }
                //if (string.IsNullOrWhiteSpace(cmbProvince.))
                //{
                //    throw new FormatException("No provinfce");
                //}
                if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
                {
                    throw new FormatException("No postal code");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }

                else
                {
                    
                    Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
                    BusinessClient bc = new BusinessClient(address, txtContactNumber.Text, DateTime.Now, txtTaxNum.Text, txtBusinessName.Text, true);
                    bc.InsertBusinessClient(bc);

                    MessageBox.Show("Successfully created business client", "Yay");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessName.Text))
                {
                    throw new FormatException("No business name");
                }
                if (string.IsNullOrWhiteSpace(txtTaxNum.Text))
                {
                    throw new FormatException("No tax number");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No street name");
                }
                if (string.IsNullOrWhiteSpace(txtSuburb.Text))
                {
                    throw new FormatException("No suburb");
                }
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    throw new FormatException("No city");
                }
                //if (string.IsNullOrWhiteSpace(cmbProvince.))
                //{
                //    throw new FormatException("No provinfce");
                //}
                if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
                {
                    throw new FormatException("No postal code");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }

                else
                {

                    Address address = new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, (Province)cmbProvince.SelectedIndex, txtPostalCode.Text);
                    BusinessClient bc = new BusinessClient(address, txtContactNumber.Text, DateTime.Now, txtTaxNum.Text, txtBusinessName.Text, true);
                    bc.UpdateBusinessClient(bc);

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bc = new BusinessClient().SelectAllBusinessClients();
                foreach (BusinessClient item in bc)
                {
                    if (item.Id == txtSearch.Text)
                    {
                        bc2 = item ;
                        bc = null;
                        bc.Add(bc2);
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

            foreach (var item in cmbProvince.Items)
            {
                if (item.ToString() == selectedBc.Address.Province.ToString())
                {
                    cmbProvince.SelectedItem = item.ToString();
                    break;
                }
            }


            txtBusinessName.Text = selectedBc.BusinessName;
            txtCity.Text = selectedBc.Address.City;
            txtContactNumber.Text = selectedBc.ContactNumber;
            txtPostalCode.Text = selectedBc.Address.Postalcode;
            txtSuburb.Text = selectedBc.Address.Suburb;
            txtStreetName.Text = selectedBc.Address.StreetName;
            txtTaxNum.Text = selectedBc.TaxNumber;
           
        }

        private void dgvBusinessClients_SelectionChanged(object sender, EventArgs e)
        {
            selectedBc = (BusinessClient)bs.Current;
            UpdateData();
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {

        }
    }

        
}
