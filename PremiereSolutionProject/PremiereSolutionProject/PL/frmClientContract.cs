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
        private List<Contract> contract;
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

            Contract cont = new Contract(dtpStartDate.Value, dtpEndDate.Value, dashForm.callInfo.Client, packages, true, cbxPriorityLevel.Text, 0.00, "Contract");
            double price = cont.CalculateContractPrice(cont);
            cont = new Contract(dtpStartDate.Value, dtpEndDate.Value, dashForm.callInfo.Client, packages, true, pLvl, price, "Contract");
            cont.InsertContract(cont);
        }

        private void frmClientContract_Load(object sender, EventArgs e)
        {
            packages = new ServicePackage().SelectAllServicePackage();
            contract = new Contract().SelectAllContracts();
            services = new Service().SelectAllServices();
            List<string> cont = new List<string>();
            
            // contract = new List<Contract>();

            foreach (Contract item in contract)
            {
                cbxContractName.Items.Add(item.ContractType.ToString());
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
            txtClientID.Text = dashForm.callInfo.Client.Id;
            RefreshDGV();
            RefreshDGVServices();
        }

        private void RefreshDGV()
        {
            bs.DataSource = packages;
            dgvServicePackages.DataSource = null;
            dgvServicePackages.DataSource = bs;
            
        }

        private void RefreshDGVServices()
        {
            bss.DataSource = services;
            dgvServices.DataSource = null;
            dgvServices.DataSource = bss;
            
        }

        private void cbxContractName_SelectedIndexChanged(object sender, EventArgs e)
        {
            contract = new Contract().SelectAllContracts();
            foreach (Contract item in contract)
            {
                if (item.ContractType == cbxContractName.SelectedItem.ToString())
                {
                    packages = item.PackageList;
                    RefreshDGV();
                }
            }
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
    }
}
