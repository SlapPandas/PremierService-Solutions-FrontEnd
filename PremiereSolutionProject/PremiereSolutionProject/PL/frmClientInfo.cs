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

        #region Declarations

        frmDashboard dashform;
        List<BusinessClient> businessClientList;
        List<IndividualClient> individualClientList;
        List<Call> callList;
        List<ServiceRequest> serviceRequestList;
        List<Client> myClientList;
        List<BusinessClient> searchedBusinessClientList;
        List<IndividualClient> searchedIndividualClientList;
        BindingSource bindingSource = new BindingSource();
        BindingSource bs2 = new BindingSource();

        #endregion

        #region Events

        public frmClientInfo(frmDashboard _dashform):this()
        {
            dashform = _dashform;
        }
        
        private void frmClientInfo_Load(object sender, EventArgs e)
        {
            FormatDGV();
            businessClientList = new BusinessClient().SelectAllBusinessClients();
            individualClientList = new IndividualClient().SelectAllIndividualClients();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtClientID.Text))
            {
                MessageBox.Show("Please enter a client ID");
            }
            else
            {
                try
                {
                    callList = new Call().SelectAllCallsOfClient(txtClientID.Text);
                    serviceRequestList = new ServiceRequest().SelectAllServiceRequestsForClient(txtClientID.Text);
                    myClientList = new List<Client>();
                    searchedIndividualClientList = new List<IndividualClient>();
                    searchedBusinessClientList = new List<BusinessClient>();

                    if (txtClientID.Text[0] == 'A')
                    {
                        foreach (IndividualClient item in individualClientList)
                        {
                            if (txtClientID.Text == item.Id)
                            {
                                myClientList.Add(item);
                                searchedIndividualClientList.Add(item);
                                RefreshDGVIndividualClient();
                            }
                        }
                    }
                    else if (txtClientID.Text[0] == 'B')
                    {
                        foreach (BusinessClient item in businessClientList)
                        {
                            if (txtClientID.Text == item.Id)
                            {
                                myClientList.Add(item);
                                searchedBusinessClientList.Add(item);
                                RefreshDGVBusinessClient();
                            }
                        }
                    }
                    RefreshCallDGV();
                    RefreshServiceRequestDGV();
                }
                catch (FormatException formatExcpetion)
                {
                    MessageBox.Show(formatExcpetion.Message, "Incorrect user input.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, (exception.InnerException != null) ? (exception.InnerException.ToString()) : ("Error"));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtClientID.Text))
            {
                MessageBox.Show("Please enter the client ID");
            }
            else if (dashform.callInfo.Client != null)
            {
                MessageBox.Show("Client already logged");
            }
            else if (bs2.Current == null)
            {
                MessageBox.Show("No client selected in data grid view");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add client?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Call call = new Call();
                    call.LogClientToCall(dashform.callInfo.CallID, txtClientID.Text);
                    dashform.callInfo.Client = (Client)bs2.Current;
                    this.Close();
                }
                
            }
        }

        private void btnExiting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private void RefreshCallDGV()
        {
            bindingSource.DataSource = callList;
            dgvClientContractInfo.DataSource = null;
            dgvClientContractInfo.DataSource = bindingSource;
        }
        private void RefreshServiceRequestDGV()
        {
            bindingSource.DataSource = serviceRequestList;
            dgvViewClient.DataSource = null;
            dgvViewClient.DataSource = bindingSource;
        }

        private void RefreshDGVIndividualClient()
        {
            bs2.DataSource = searchedIndividualClientList;
            dgvClientInfo.DataSource = null;
            dgvClientInfo.DataSource = bs2;
        }

        private void RefreshDGVBusinessClient()
        {
            bs2.DataSource = searchedBusinessClientList;
            dgvClientInfo.DataSource = null;
            dgvClientInfo.DataSource = bs2;
        }

        private void FormatDGV()
        {
            dgvClientInfo.ForeColor = Color.Black;
            dgvClientContractInfo.ForeColor = Color.Black;
            dgvViewClient.ForeColor = Color.Black;
        }

        #endregion
    }
}
