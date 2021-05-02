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
    public partial class frmClientInfo : Form
    {
        public frmClientInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<ServicePackage> package;
        List<Service> service;
        List<BusinessClient> bClient;
        List<IndividualClient> iClient;
        List<Call> calls;
        List<ServiceRequest> sReq;
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        private void frmClientInfo_Load(object sender, EventArgs e)
        {
            bClient = new BusinessClient().SelectAllBusinessClients();
            iClient = new IndividualClient().SelectAllIndividualClients();
            
        }
        private void RefreshDGV()
        {
            bs.DataSource = calls;
            dgvClientContractInfo.DataSource = null;
            dgvClientContractInfo.DataSource = bs;
        }
        private void RefreshDGV2()
        {
            bs.DataSource = sReq;
            dgvViewClient.DataSource = null;
            dgvViewClient.DataSource = bs;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            calls = new Call().SelectAllCallsOfClient(txtClientID.Text);
            sReq = new ServiceRequest().SelectAllServiceRequestsForClient(txtClientID.Text);
            RefreshDGV();
            RefreshDGV2();
        }
    }
}
