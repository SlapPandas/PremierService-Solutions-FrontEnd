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
    public partial class frmClientContract : Form
    {
        #region Declarations

        frmDashboard dashForm;
        List<Contract> contractList;
        List<ServicePackage> packages;
        List<Service> services;
        Client myClient;

        #endregion

        public frmClientContract()
        {
            InitializeComponent();
        }

        public frmClientContract(frmDashboard _dashForm):this()
        {
            dashForm = _dashForm;
        }

        private void frmClientContract_Load(object sender, EventArgs e)
        {
            try
            {
                Contract myContract = new Contract();
                contractList = myContract.SelectAllContracts();
                services = new Service().SelectAllServices();

                //to not be able to register a contract if there is no client ID entered
                btnCreate.Enabled = txtClientID.Text == "" ? false : true;
                
                if (dashForm.callInfo != null)
                {
                    txtClientID.Text = dashForm.callInfo.Client.Id;
                }

                InitializeElementsOnForm();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }   
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string pLvl = cbxPriorityLevel.Text + "," + nudNoOfDays.Value;
            Client cl = dashForm.callInfo.Client;

            DateTime startdateTime = dtpStartDate.Value;
            DateTime enddateTime = dtpEndDate.Value;

            if (cl.GetClientType(cl) == "IndividualClient")
            {
                IndividualClient ind = (IndividualClient)cl;
                Contract cont = new Contract(startdateTime, enddateTime, ind, null, packages, pLvl, "Recurring");
                cont.LinkClientToContract(cont);
            }
            if (cl.GetClientType(cl) == "BusinessClient")
            {
                BusinessClient bus = (BusinessClient)cl;
                Contract cont = new Contract(startdateTime, enddateTime, null, bus, packages, pLvl, "Recurring");
                cont.LinkClientToContract(cont);
            }
            
        }

        private void cbxContractName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract myContract = new Contract();
            packages = null;
            packages = myContract.GetOfferedContractByID(cbxContractName.Text).PackageList;
            RefreshDGV();
        }
        
        private void cbxPriorityLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbxPriorityLevel.SelectedItem.ToString())
            {
                case "Platinum":
                    nudNoOfDays.Maximum = 2;
                    nudNoOfDays.Minimum = 1;
                    break;
                case "Gold":
                    nudNoOfDays.Maximum = 4;
                    nudNoOfDays.Minimum = 3;
                    break;
                case "Silver":
                    nudNoOfDays.Maximum = 6;
                    nudNoOfDays.Minimum = 5;
                    break;
                case "Bronze":
                    nudNoOfDays.Maximum = 8;
                    nudNoOfDays.Minimum = 7;
                    break;
                default:
                    nudNoOfDays.Maximum = 8;
                    nudNoOfDays.Minimum = 1;
                    break;
            }
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = txtClientID.Text == "" ? false : true;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End date can't be same as start date.");
                dtpEndDate.Focus();
            }
        }

        private void dgvServicePackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Service myService = new Service();
            try
            {
                foreach (ServicePackage item in packages)
                {
                    if (item.PackageID == int.Parse(dgvServicePackages.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        services = myService.SelectServiceListInServicePackage(item);
                        RefreshDGVServices();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please click on the Service PackageID to view the services in that Service Package.");
            }      
        }

        private void btnExiting_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnVerifyClient_Click(object sender, EventArgs e)
        {
            dashForm.callInfo.Client.VerifyClientContract(txtClientID.Text);
        }

        #region Methods
        private void InitializeElementsOnForm()
        {
            cbxPriorityLevel.Items.Add("Platinum");
            cbxPriorityLevel.Items.Add("Gold");
            cbxPriorityLevel.Items.Add("Silver");
            cbxPriorityLevel.Items.Add("Bronze");
            cbxContractName.ValueMember = null;
            cbxContractName.SelectedIndex = -1;

            foreach (Contract item in contractList)
            {
                cbxContractName.Items.Add(item.ContractID.ToString());
            }

            dgvServicePackages.ForeColor = Color.Black;
            dgvServices.ForeColor = Color.Black;

            cbxContractName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPriorityLevel.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpEndDate.Value = DateTime.Today.AddDays(1);   //to not have it as the same day as default
        }

        private void RefreshDGV()
        {
            dgvServicePackages.Rows.Clear();
            dgvServicePackages.Refresh();
            List<ServicePackage> bindingList = packages;
            var source = new BindingSource(bindingList, null);
            dgvServicePackages.DataSource = source;

        }

        private void RefreshDGVServices()
        {
            dgvServices.Rows.Clear();
            dgvServices.Refresh();
            List<Service> bindingList = services;
            var source = new BindingSource(bindingList, null);
            dgvServices.DataSource = source;
        }
        #endregion

    }
}
