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
        List<Service> services;
        BindingSource bs = new BindingSource();
        ServicePackage selectedP;
        private void frmServicePackageManagement_Load(object sender, EventArgs e)
        {
            services = new Service().SelectAllServices();
            sp = new ServicePackage().SelectAllServicePackage();
            RefreshDGV();
            lbxAvailable.Items.Add(services);
        }

        private void RefreshDGV()
        {
            bs.DataSource = sp;
            dgvCurrentServicePackages.DataSource = null;
            dgvCurrentServicePackages.DataSource = bs;

        }

        private void UpdateData()
        {
            //selectedProduct
            if (selectedP.OnPromotion == true)
            {
                cbxPromotionYes.Checked = true;
                cbxPromotionNo.Checked = false;
            }
            else
            {
                cbxPromotionNo.Checked = true;
                cbxPromotionYes.Checked = false;
            }

            lbxAdded.Items.Clear();
            lbxAdded.Items.Add(selectedP.ServiceList);

            txtPackageName.Text = selectedP.PackageName;

            dtpPromotionEnd.Value = selectedP.PromotionEndDate;
            dtpPromotionStart.Value = selectedP.PromotionStartDate;
           // numUDPercentage.Value = selectedP.PromotionPercentage;

        }

        private void dgvCurrentServicePackages_SelectionChanged(object sender, EventArgs e)
        {
            selectedP = (ServicePackage)bs.Current;
            UpdateData();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            lbxAdded.Items.Add(lbxAvailable.SelectedItem.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lbxAdded.Items.RemoveAt(lbxAdded.SelectedIndex);
        }
    }
}
