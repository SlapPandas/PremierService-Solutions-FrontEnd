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
        public frmClientInfo(frmDashboard _dashform):this()
        {
            dashform = _dashform;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        frmDashboard dashform;
        List<ServicePackage> package;
        List<Service> service;
        List<BusinessClient> bClient;
        List<IndividualClient> iClient;
        List<Call> calls;
        List<ServiceRequest> sReq;
        List<Client> ClientList;
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
        private void RefreshDGV3()
        {
            bs.DataSource = ClientList;
            dgvClientInfo.DataSource = null;
            dgvClientInfo.DataSource = bs;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            calls = new Call().SelectAllCallsOfClient(txtClientID.Text);
            sReq = new ServiceRequest().SelectAllServiceRequestsForClient(txtClientID.Text);
            ClientList.Clear();
            if (txtClientID.Text[0] == 'A')
            {
                foreach (IndividualClient item in iClient)
                {
                    if (txtClientID.Text == item.Id)
                    {
                        ClientList.Add(item);
                    }
                }
            }
            else if (txtClientID.Text[0] == 'B')
            {
                foreach (BusinessClient item in bClient)
                {
                    if (txtClientID.Text == item.Id)
                    {
                        ClientList.Add(item);
                    }
                }
            }
            RefreshDGV();
            RefreshDGV2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashform.callInfo.LogClientToCall(dashform.callInfo.CallID, txtClientID.Text);
        }
    }
}
