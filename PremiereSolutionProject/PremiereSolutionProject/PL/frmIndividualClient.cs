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
    public partial class frmIndividualClient : Form
    {
        
        public frmIndividualClient()
        {
            InitializeComponent(); 
        }

        #region Declarations

        List<IndividualClient> individualClients = new List<IndividualClient>();
        IndividualClient individualClient = new IndividualClient();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIndividualClient_Load(object sender, EventArgs e)
        {
            RefreshDGVAndList();
            BuildDGVStyle();
            PopulateComboBox();
        }

        private void dgvExistingClients_SelectionChanged(object sender, EventArgs e)
        {
            UpdateFields(dgvExistingClients.CurrentCell.RowIndex);
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete The Client?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                individualClients[dgvExistingClients.CurrentCell.RowIndex].Active = false;
                individualClient.RemoveClient(individualClients[dgvExistingClients.CurrentCell.RowIndex]);
                RefreshDGVAndList();
                UpdateFields(dgvExistingClients.CurrentCell.RowIndex);
            }
        }

        private void btnUpdateIndiClient_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to update The Client?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(dgvExistingClients.CurrentCell.RowIndex,txtNationalID.Text, txtEmai.Text, txtContactNumber.Text) && checkValidNationalId(txtNationalID.Text) && checkValidContactNumber(txtContactNumber.Text) && checkValidEmail(txtEmai.Text))
                {
                    individualClients[dgvExistingClients.CurrentCell.RowIndex] = new IndividualClient(individualClients[dgvExistingClients.CurrentCell.RowIndex].Id, txtFirstname.Text, txtSurname.Text, new Address(individualClients[dgvExistingClients.CurrentCell.RowIndex].Address.AddressID, txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, individualClients[dgvExistingClients.CurrentCell.RowIndex].RegistrationDate, GetTrueFalseFromBit(cmbActive.SelectedIndex));
                    individualClient.UpdateClient(individualClients[dgvExistingClients.CurrentCell.RowIndex]);
                    RefreshDGVAndList();
                    UpdateFields(dgvExistingClients.CurrentCell.RowIndex);
                }
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Insert The Client?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (!CheckForDuplicates(-1, txtNationalID.Text, txtEmai.Text, txtContactNumber.Text) && checkValidNationalId(txtNationalID.Text) && checkValidContactNumber(txtContactNumber.Text) && checkValidEmail(txtEmai.Text))
                {
                    individualClients.Add(new IndividualClient(txtFirstname.Text, txtSurname.Text, new Address(txtStreetName.Text, txtSuburb.Text, txtCity.Text, GetProvince(cmbProvince.SelectedIndex + ""), txtPostalCode.Text), txtContactNumber.Text, txtEmai.Text, txtNationalID.Text, DateTime.Now, GetTrueFalseFromBit(cmbActive.SelectedIndex)));
                    individualClient.InsertIndividualClient(individualClients[individualClients.Count - 1]);
                    RefreshDGVAndList();
                    UpdateFields(dgvExistingClients.CurrentCell.RowIndex);
                }
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            individualClients.Clear();
            individualClients.Add(individualClient.SelectAllIndividualClientByThereId(txtSearch.Text));
            RefreshDGVAndListWithoutReset();
            
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            RefreshDGVAndList();
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
            dgvExistingClients.ForeColor = Color.Black;
        }
        private void RefreshDGVAndList()
        {
            individualClients = individualClient.SelectAllIndividualClients();
            List<IndividualClient> bindList = individualClients;
            bindingSource = new BindingSource(bindList, null);
            dgvExistingClients.DataSource = bindingSource;
        }
        private void RefreshDGVAndListWithoutReset()
        {
            List<IndividualClient> bindList = individualClients;
            bindingSource = new BindingSource(bindList, null);
            dgvExistingClients.DataSource = bindingSource;
        }
        private void UpdateFields(int index)
        {
            if (index >= individualClients.Count)
            {
                index = 0;
            }
            if (index <= dgvExistingClients.RowCount - 2)
            {
                txtID.Text = individualClients[index].Id;
                txtFirstname.Text = individualClients[index].FirstName;
                txtSurname.Text = individualClients[index].Surname;
                txtNationalID.Text = individualClients[index].NationalIDnumber;
                txtContactNumber.Text = individualClients[index].ContactNumber;
                txtEmai.Text = individualClients[index].Email;
                txtStreetName.Text = individualClients[index].Address.StreetName;
                txtSuburb.Text = individualClients[index].Address.Suburb;
                txtCity.Text = individualClients[index].Address.City;
                cmbProvince.SelectedItem = individualClients[index].Address.Province;
                txtPostalCode.Text = individualClients[index].Address.Postalcode;
                txtDate.Text = individualClients[index].RegistrationDate.ToString("yyy/MM/dd");
                cmbActive.SelectedIndex = GetIntFromBool(individualClients[index].Active);
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
        private bool CheckForDuplicates(int excluded,string nationalId, string email, string contactNumber)
        {
            for (int i = 0; i < individualClients.Count; i++)
            {
                if (i != excluded)
                {
                    if ((individualClients[i].NationalIDnumber == nationalId || individualClients[i].Email == email || individualClients[i].ContactNumber == contactNumber) && individualClients[i].Active == true)
                    {
                        MessageBox.Show("please insure that the id Number, email or contact nuber does not exist in the system already");
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
            MessageBox.Show("please insure that the id Number has the correct amount of digits 13");
            return false;
        }
        private bool checkValidContactNumber(string id)
        {
            if (id.Length == 10)
            {
                return true;
            }
            MessageBox.Show("please insure that the contact has the correct amount of digits 10");
            return false;
        }
        private bool checkValidEmail(string id)
        {
            EmailAddressAttribute email = new EmailAddressAttribute();
            if (email.IsValid(id))
            {
                return true;
            }
            MessageBox.Show("please insure that the email is valid");
            return false;
        }
        private void ClearFields()
        {
            txtNationalID.Text = "";
            txtFirstname.Text = "";
            txtSurname.Text = "";
            txtContactNumber.Text = "";
            txtEmai.Text = "";
            txtDate.Text = "";
            txtStreetName.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            cmbActive.SelectedIndex = -1;
            cmbProvince.SelectedIndex = -1;
        }

        #endregion


    }
}
