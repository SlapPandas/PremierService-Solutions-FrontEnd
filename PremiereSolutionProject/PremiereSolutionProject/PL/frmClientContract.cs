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
        public frmClientContract(frmDashboard _dashForm):this()
        {
            dashForm = _dashForm;
        }
        frmDashboard dashForm;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<Contract> contractList;
        List<ServicePackage> packages;
        List<Service> services;
        BindingSource bs = new BindingSource();
        BindingSource bss = new BindingSource();
        ServicePackage package;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            //bool available;
            //if (cbx.Checked == true)
            //{
            //    available = true;
            //}
            string pLvl = cbxPriorityLevel.Text + "," + nudNoOfDays.Value;
            IndividualClient myclient = (IndividualClient)dashForm.callInfo.Client;
            

           // Contract cont = new Contract(dtpStartDate.Value, dtpEndDate.Value, dashForm.callInfo.Client, packages, true, cbxPriorityLevel.Text, 0.00, "Contract");
            //double price = cont.CalculateContractPrice(cont);
           // cont = new Contract(dtpStartDate.Value, dtpEndDate.Value, dashForm.callInfo.Client, packages, true, pLvl, price, "Contract");
            
            //TODO: This is not working, I have no idea why :(
            Contract cont = new Contract(dtpStartDate.Value, dtpEndDate.Value, myclient, packages, true, pLvl, "Contract");
            cont.LinkClientToContract(cont);
        }

        private void frmClientContract_Load(object sender, EventArgs e)
        {
            try
            {
                Contract myContract = new Contract();
                dtpEndDate.Value = DateTime.Today.AddDays(1);   //to not have it as the same day as default
                //to not be able to register a contract if there is no client ID entered
                btnCreate.Enabled = txtClientID.Text == "" ? false : true;

                cbxContractName.DropDownStyle = ComboBoxStyle.DropDownList;
                cbxPriorityLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                dgvServicePackages.ForeColor = Color.Black;
                dgvServices.ForeColor = Color.Black;

                //packages = new ServicePackage().SelectAllServicePackage();
                contractList = myContract.SelectAllContracts();
                services = new Service().SelectAllServices();
                List<string> cont = new List<string>();

                // contract = new List<Contract>();

                foreach (Contract item in contractList)
                {
                    cbxContractName.Items.Add(item.ContractID.ToString());
                }
                //foreach (var item in contract)
                //{
                //    cbxPriorityLevel.Items.Add(item.PriorityLevel.ToString());
                //}
                cbxPriorityLevel.Items.Add("Platinum");
                cbxPriorityLevel.Items.Add("Gold");
                cbxPriorityLevel.Items.Add("Silver");
                cbxPriorityLevel.Items.Add("Bronze");
                cbxContractName.ValueMember = null;
                cbxContractName.SelectedIndex = -1;
                if (dashForm.callInfo != null)
                {
                    txtClientID.Text = dashForm.callInfo.Client.Id;
                }
                //RefreshDGV();
                //RefreshDGVServices();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
            
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

        private void cbxContractName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract myContract = new Contract();
            packages = null;
            packages = myContract.GetOfferedContractByID(cbxContractName.Text).PackageList;
            RefreshDGV();
        }

        private void dgvServicePackages_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (bs.Current != null)
                {
                    
                    packages = new ServicePackage().SelectAllServicePackage();
                    foreach (ServicePackage item in packages)
                    {
                        if (item.PackageID == dgvServicePackages.CurrentCell.RowIndex)
                        {
                            services = item.ServiceList;
                            RefreshDGVServices();
                        }
                    }
                    // UpdateData();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }
        string prio = "";
        private void cbxPriorityLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbxPriorityLevel.SelectedItem.ToString())
            {
                case "Platinum":
                    prio = "Platinum";
                    nudNoOfDays.Maximum = 2;
                    nudNoOfDays.Minimum = 1;
                    break;
                case "Gold":
                    prio = "Gold";
                    nudNoOfDays.Maximum = 4;
                    nudNoOfDays.Minimum = 3;
                    break;
                case "Silver":
                    prio = "Silver";
                    nudNoOfDays.Maximum = 6;
                    nudNoOfDays.Minimum = 5;
                    break;
                case "Bronze":
                    prio = "Bronze";
                    nudNoOfDays.Maximum = 8;
                    nudNoOfDays.Minimum = 7;
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void nudNoOfDays_ValueChanged(object sender, EventArgs e)
        {
            //switch (prio)
            //{
            //    case "Platinum":
            //        nudNoOfDays
            //        break;
            //    case "Gold":
            //        prio = "Gold";
            //        nudNoOfDays.Value = 4;
            //        break;
            //    case "Silver":
            //        prio = "Silver";
            //        nudNoOfDays.Value = 6;
            //        break;
            //    case "Bronze":
            //        prio = "Bronze";
            //        nudNoOfDays.Value = 8;
            //        break;
            //    default:
            //        // code block
            //        break;
            //}
        }

        private void btnExiting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = txtClientID.Text == "" ? false : true;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End date can't be same as start date.");
                dtpEndDate.Focus();
            }
        }

        private void cbxPriorityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvServicePackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Service myService = new Service();

            foreach (ServicePackage item in packages)
            {
                if (item.PackageID == int.Parse(dgvServicePackages.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    services = myService.SelectServiceListInServicePackage(item);
                    RefreshDGVServices();
                }
            }
        }
    }
}
