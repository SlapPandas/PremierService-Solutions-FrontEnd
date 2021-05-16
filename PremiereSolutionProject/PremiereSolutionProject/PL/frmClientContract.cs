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
        public frmClientContract()
        {
            InitializeComponent();
        }

        #region Declarations

        frmDashboard dashForm;
        Contract contract = new Contract();
        List<Contract> contracts = new List<Contract>();
        BindingSource bindingSource = new BindingSource();

        #endregion

        #region Events

        public frmClientContract(frmDashboard _dashForm):this()
        {
            dashForm = _dashForm;
        }

        private void frmClientContract_Load(object sender, EventArgs e)
        {
            BuildForm();
            BuildContractListAndFillConboBox();
        }

        private void cbxPriorityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMinMaxCounter(cbxPriorityLevel.SelectedItem.ToString());
        }

        private void cbxContractName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGVServicePackedges(cbxContractName.SelectedIndex);
            RefreshDGVServices(cbxContractName.SelectedIndex, 0);
        }

        private void dgvServicePackages_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDGVServices(cbxContractName.SelectedIndex, dgvServicePackages.CurrentCell.RowIndex);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!contract.ClientHasAvtive(dashForm.callInfo.Client.Id))
            {
                Client client = new IndividualClient();
                if (dashForm.callInfo.Client.Id[0] == 'A')
                {
                    client = new IndividualClient();
                    client.Id = dashForm.callInfo.Client.Id;
                }
                if (dashForm.callInfo.Client.Id[0] == 'B')
                {
                    client = new BusinessClient();
                    client.Id = dashForm.callInfo.Client.Id;
                }
                contracts[cbxContractName.SelectedIndex].Client = client;
                contracts[cbxContractName.SelectedIndex].PriorityLevel = contract.FormatPriorityForDataUse(cbxPriorityLevel.Text,(int)nudNoOfDays.Value);
                contract.LinkClientToContract(contracts[cbxContractName.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Client Already Has Active Contract");
            }
        }

        private void btnExiting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private void BuildForm()
        {
            txtId.Text = dashForm.callInfo.Client.Id;
            txtCallId.Text = dashForm.callInfo.CallID.ToString();

            cbxPriorityLevel.Items.Add("Platinum");
            cbxPriorityLevel.Items.Add("Gold");
            cbxPriorityLevel.Items.Add("Silver");
            cbxPriorityLevel.Items.Add("Bronze");

            dgvServicePackages.ForeColor = Color.Black;
            dgvServices.ForeColor = Color.Black;
        }

        private void SetMinMaxCounter(string name)
        {
            switch (name)
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

        private void BuildContractListAndFillConboBox()
        {
            contracts = contract.SelectActiveContracts();
            foreach (var item in contracts)
            {
                cbxContractName.Items.Add(item.ContractID);
            }
        }

        private void RefreshDGVServicePackedges(int contractIndex)
        {
            bindingSource = new BindingSource(contracts[contractIndex].PackageList, null);
            dgvServicePackages.DataSource = bindingSource;
        }

        private void RefreshDGVServices(int contractIndex, int packedgeIndex)
        {
            bindingSource = new BindingSource(contracts[contractIndex].PackageList[packedgeIndex].ServiceList, null);
            dgvServices.DataSource = bindingSource;
        }

        #endregion
    }
}
