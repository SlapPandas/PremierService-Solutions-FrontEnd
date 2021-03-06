using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace PremiereSolutionProject.PL
{
    public partial class frmBusinessClient : Form
    {

        public frmBusinessClient()
        {
            InitializeComponent();
        }

        #region Declarations

        List<BusinessClient> businessClients = new List<BusinessClient>();
        BusinessClient businessClient = new BusinessClient();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        private void frmBusinessClient_Load(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            BuildDGVStyle();
            PopulateComboBox();
        }

        private void dgvBusinessClients_SelectionChanged(object sender, EventArgs e)
        {
            UpdateFields(dgvBusinessClients.CurrentCell.RowIndex);
        }

        private void btnDeleteBusinessClient_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete The Client?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                businessClients[dgvBusinessClients.CurrentCell.RowIndex].Active = false;
                businessClient.RemoveClient(businessClients[dgvBusinessClients.CurrentCell.RowIndex]);
                RefreshDGVAndList();
                UpdateFields(dgvBusinessClients.CurrentCell.RowIndex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to update The Client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(dgvBusinessClients.CurrentCell.RowIndex, txtTaxNum.Text, txtContactNumber.Text) && checkValidTaxId(txtTaxNum.Text) && checkValidContactNumber(txtContactNumber.Text))
                {
                    businessClients[dgvBusinessClients.CurrentCell.RowIndex] = new BusinessClient(businessClients[dgvBusinessClients.CurrentCell.RowIndex].Id, new Address(businessClients[dgvBusinessClients.CurrentCell.RowIndex].Address.AddressID, txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, businessClients[dgvBusinessClients.CurrentCell.RowIndex].RegistrationDate, txtTaxNum.Text, txtBusinessName.Text, GetTrueFalseFromBit(cmbActive.SelectedIndex));
                    businessClient.UpdateClient(businessClients[dgvBusinessClients.CurrentCell.RowIndex]);
                    RefreshDGVAndList();
                    UpdateFields(dgvBusinessClients.CurrentCell.RowIndex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Insert The Client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(-1, txtTaxNum.Text, txtContactNumber.Text) && checkValidTaxId(txtTaxNum.Text) && checkValidContactNumber(txtContactNumber.Text))
                {
                    businessClients.Add(new BusinessClient(new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, businessClients[dgvBusinessClients.CurrentCell.RowIndex].RegistrationDate, txtTaxNum.Text, txtBusinessName.Text, GetTrueFalseFromBit(cmbActive.SelectedIndex)));
                    businessClient.InsertBusinessClient(businessClients[businessClients.Count - 1]);
                    RefreshDGVAndList();
                    UpdateFields(dgvBusinessClients.CurrentCell.RowIndex);
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            txtSearch.Text = "";
        }

        //TODO: need to figure out why the search is not working
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length >= 9)
            {
                businessClients.Clear();
                businessClients.Add(businessClient.SelectAllBusinessClientsByThereId(txtSearch.Text));
                RefreshDGVAndListWithoutReset();
            }
            else
            {
                MessageBox.Show("Please make sure to enter an ID to search for.","No ID entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearTextBoxes_Click(object sender, EventArgs e)
        {
            txtBusinessName.Text = "";
            txtCity.Text = "";
            txtContactNumber.Text = "";
            txtPostalCode.Text = "";
            txtSearch.Text = "";
            txtStreetName.Text = "";
            txtSuburb.Text = "";
            txtTaxNum.Text = "";
            cmbActive.SelectedIndex = -1;
            cmbProvince.SelectedIndex = -1;
        }

        #endregion

        #region Methods

        private void BuildDGVStyle()
        {
            dgvBusinessClients.ForeColor = Color.Black;
        }

        private void RefreshDGVAndList()
        {
            businessClients = businessClient.SelectAllBusinessClients();
            List<BusinessClient> bindList = businessClients;
            bindingSource = new BindingSource(bindList, null);
            dgvBusinessClients.DataSource = bindingSource;
        }

        private void RefreshDGVAndListWithoutReset()
        {
            List<BusinessClient> bindList = businessClients;
            bindingSource = new BindingSource(bindList, null);
            dgvBusinessClients.DataSource = bindingSource;
        }

        private void UpdateFields(int index)
        {
            if (index >= businessClients.Count)
            {
                index = 0;
            }
            if (index <= dgvBusinessClients.RowCount - 2)
            {
                txtBusinessName.Text = businessClients[index].BusinessName;
                txtTaxNum.Text = businessClients[index].TaxNumber;
                txtStreetName.Text = businessClients[index].Address.StreetName;
                txtSuburb.Text = businessClients[index].Address.Suburb;
                txtCity.Text = businessClients[index].Address.City;
                cmbProvince.SelectedItem = businessClients[index].Address.Province;
                txtPostalCode.Text = businessClients[index].Address.Postalcode;
                txtContactNumber.Text = businessClients[index].ContactNumber;
                cmbActive.SelectedIndex = GetIntFromBool(businessClients[index].Active);
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
        private bool CheckForDuplicates(int excluded, string taxNumber, string contactNumber)
        {
            for (int i = 0; i < businessClients.Count; i++)
            {
                if (i != excluded)
                {
                    if ((businessClients[i].TaxNumber == taxNumber || businessClients[i].ContactNumber == contactNumber) && businessClients[i].Active == true)
                    {
                        MessageBox.Show("Please insure that the id Number, email or contact nuber does not exist in the system already","Confirmation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            return false;

        }
        private bool checkValidTaxId(string id)
        {
            if (id.Length == 10)
            {
                return true;
            }
            MessageBox.Show("Please insure that the id Number has the correct amount of digits 13", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        private bool checkValidContactNumber(string id)
        {
            if (id.Length == 10)
            {
                return true;
            }
            MessageBox.Show("Please insure that the contact has the correct amount of digits 10","Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        #endregion
    }
}
