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

        private void btnAddServicePackage_Click(object sender, EventArgs e)
        {
            lbxPackages.Items.Add(cbxServicePackages.SelectedItem.ToString());
        }
        List<ServicePackage> package;
        List<Service> service;
        BindingSource bs = new BindingSource();
        private void frmContractManagement_Load(object sender, EventArgs e)
        {
            dgvViewServices.ForeColor = Color.Black;
            package = new ServicePackage().SelectAllServicePackage();
            foreach (ServicePackage item in package)
            {
                cbxServicePackages.Items.Add(item.PackageName);
            }
        }

        private void cbxServicePackages_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        private void RefreshDGV()
        {
            bs.DataSource = service;
            dgvViewServices.DataSource = null;
            dgvViewServices.DataSource = bs;

        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            Contract cont = new Contract(null, DateTime.Now, DateTime.Now, package, null, 0.00, null);
            cont.InsertContract(cont);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lbxPackages.Items.RemoveAt(lbxPackages.SelectedIndex);
        }
    }
}
