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
    public partial class frmContractManagement : Form
    {
        public frmContractManagement()
        {
            InitializeComponent();
        }

        #region Declarations

        List<ServicePackage> package;
        List<Service> service;
        BindingSource bs = new BindingSource();

        #endregion

        #region Events
        private void btnAddServicePackage_Click(object sender, EventArgs e)
        {
            lbxPackages.Items.Add(cbxServicePackages.SelectedItem.ToString());
        }
        
        private void frmContractManagement_Load(object sender, EventArgs e)
        {
            FormatListView();
            dgvViewServices.ForeColor = Color.Black;
            package = new ServicePackage().SelectAllServicePackage();
            foreach (ServicePackage item in package)
            {
                cbxServicePackages.Items.Add(item.PackageName);
            }
        }

        private void cbxServicePackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxServicePackages.SelectedIndex == -1)
            {
                lblServicesInPackage.Text = "Services";
                dgvViewServices.Rows.Clear();
                dgvViewServices.Refresh();
            }
            else
            {
                lblServicesInPackage.Text = "Services in " + cbxServicePackages.SelectedItem.ToString();
                package = new ServicePackage().SelectAllServicePackage();
                foreach (ServicePackage item in package)
                {
                    if (item.PackageName == cbxServicePackages.SelectedItem.ToString())
                    {
                        service = item.ServiceList;
                        RefreshDGV();
                    }
                }
            }  
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            if (lbxPackages.Items.Count > 0)
            {
                Contract cont = new Contract(DateTime.Now, DateTime.Now, package, null, 0.00, null);
                cont.InsertContract(cont); 
                FormatListView();
            }
            else
            {
                MessageBox.Show("A contract cannot be created without any packages in it.", "Nothing selected", MessageBoxButtons.OK);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxPackages.SelectedIndex == -1)
            {
                MessageBox.Show("Make sure to select a service package to remove.", "Nothing selected", MessageBoxButtons.OK);
            }
            else
            {
                lbxPackages.Items.RemoveAt(lbxPackages.SelectedIndex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            cbxServicePackages.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to cancel creating this contract?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Methods

        private void RefreshDGV()
        {
            bs.DataSource = service;
            dgvViewServices.DataSource = null;
            dgvViewServices.DataSource = bs;
        }

        private void FormatListView()
        {
            lvwAllContracts.Clear();
            Contract contract = new Contract();
            List<Contract> allContracts = contract.SelectActiveContracts();

            lvwAllContracts.View = View.Details;
            lvwAllContracts.Columns.Add("Contract ID");
            lvwAllContracts.Columns.Add("Start");
            lvwAllContracts.Columns.Add("End");

            foreach (var cont in allContracts)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = cont.ContractID;
                lvi.SubItems.Add(cont.StartTime.ToShortDateString());
                lvi.SubItems.Add(cont.EndTime.ToShortDateString());
                lvwAllContracts.Items.Add(lvi);
            }

            lvwAllContracts.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAllContracts.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAllContracts.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAllContracts.FullRowSelect = true;
        }

        #endregion

    }
}
