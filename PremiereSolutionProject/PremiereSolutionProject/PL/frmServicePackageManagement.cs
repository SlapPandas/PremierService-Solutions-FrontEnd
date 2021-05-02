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
    public partial class frmServicePackageManagement : Form
    {
        public frmServicePackageManagement()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<ServicePackage> sp;
        ServicePackage sp2;
        BindingSource bs = new BindingSource();
        ServicePackage selectedP;
        private void frmServicePackageManagement_Load(object sender, EventArgs e)
        {
            sp = new BusinessClient().SelectAllBusinessClients();
            RefreshDGV();
        }

        private void RefreshDGV()
        {
            bs.DataSource = sp;
            dgvBusinessClients.DataSource = null;
            dgvBusinessClients.DataSource = bs;

        }

        private void UpdateData()
        {
            //selectedProduct
            foreach (Address item in cmbProvince.Items)
            {
                if (item.Province == selectedP.Address.Province)
                {
                    cmbProvince.SelectedItem = item.Province;
                    break;
                }
            }


            txtBusinessName.Text = selectedP.BusinessName;
            txtCity.Text = selectedP.Address.City;
            txtContactNumber.Text = selectedP.ContactNumber;
            txtPostalCode.Text = selectedP.Address.Postalcode;
            txtSuburb.Text = selectedP.Address.Suburb;
            txtStreetName.Text = selectedP.Address.StreetName;
            txtTaxNum.Text = selectedP.TaxNumber;

        }

        private void dgvCurrentServicePackages_SelectionChanged(object sender, EventArgs e)
        {
            selectedP = (BusinessClient)bs.Current;
            UpdateData();
        }
    }
}
