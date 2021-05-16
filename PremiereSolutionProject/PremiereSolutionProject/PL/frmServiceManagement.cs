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
    public partial class frmServiceManagement : Form
    {
        public frmServiceManagement()
        {
            InitializeComponent();
        }

        #region Declarations

        List<Service> services;
        BindingSource bs = new BindingSource();
        Service selectedService;

        #endregion

        #region Events

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) && string.IsNullOrWhiteSpace(rtbServiceDescription.Text))
            {
                MessageBox.Show("Please fill the correct information");
            }
            else
            {
                Service service = new Service(txtServiceName.Text, rtbServiceDescription.Text);
                service.InsertService(service);
                RefreshDGV();
            }
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) && string.IsNullOrWhiteSpace(rtbServiceDescription.Text))
            {
                MessageBox.Show("Please fill the correct information");
            }
            else
            {
                Service service = new Service(selectedService.ServiceID,txtServiceName.Text, rtbServiceDescription.Text);
                service.UpdateService(service);
                RefreshDGV();
            }
        }

        private void frmServiceManagement_Load(object sender, EventArgs e)
        {            
            dgvCurrentServices.ForeColor = Color.Black;
            RefreshDGV();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            Service service = selectedService;
            service.DeleteService(service);
            RefreshDGV();
        }

        private void dgvCurrentServices_SelectionChanged(object sender, EventArgs e)
        {
            selectedService = (Service)bs.Current;
            UpdateData();
        }

        #endregion

        #region Methods

        private void UpdateData()
        {
            txtServiceName.Text = selectedService.ServiceName;
            rtbServiceDescription.Text = selectedService.ServiceDescription;
        }

        private void RefreshDGV()
        {
            services = new Service().SelectAllServices();
            bs.DataSource = services;
            dgvCurrentServices.DataSource = null;
            dgvCurrentServices.DataSource = bs;
            dgvCurrentServices.Columns[2].Width = 300;
            dgvCurrentServices.Columns[1].Width = 120;
        }

        #endregion

    }
}
