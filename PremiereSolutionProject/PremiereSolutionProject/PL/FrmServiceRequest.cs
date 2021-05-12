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
    public partial class FrmServiceRequest : Form
    {
        public FrmServiceRequest()
        {
            InitializeComponent();
        }

        public FrmServiceRequest(frmDashboard _dashform):this()
        {
            dashform = _dashform;
        }
        frmDashboard dashform;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<string> specList;       
        List<Specialisation> spec;
        private void FrmServiceRequest_Load(object sender, EventArgs e)
        {
            try
            {
                specList = new List<string>();
                spec = new Specialisation().SelectSpecialisationList();
                foreach (Specialisation item in spec)
                {
                    cbxSpecialisation.Items.Add(item.SpecialisationName);
                }
                lblCallID.Text = dashform.callInfo.CallID.ToString();
                List<IndividualClient> ic = new IndividualClient().SelectAllIndividualClients();
                List<BusinessClient> bc = new BusinessClient().SelectAllBusinessClients();
                List<Client> cl = dashform.callInfo.Client.SelectAllClients();
                string clientName = "";
                if (dashform.callInfo.Client.Id[0] == 'A')
                {
                    foreach (IndividualClient item in ic)
                    {
                        if (dashform.callInfo.Client.Id == item.Id)
                        {
                            clientName = item.FirstName;
                        }
                    }
                }
                else if (dashform.callInfo.Client.Id[0] == 'B')
                {
                    foreach (BusinessClient item in bc)
                    {
                        if (dashform.callInfo.Client.Id == item.Id)
                        {
                            clientName = item.BusinessName;
                        }
                    }
                }
                if (dashform.callInfo.Client != null)
                {
                    lblClientName.Text = clientName;
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          

            try
            {
                
                if (nudNumberOfPeople.Value == 0)
                {
                    throw new FormatException("Number of employees cant be 0");
                }

                else
                {
                    lbxSpecialisations.Items.Add(cbxSpecialisation.SelectedItem.ToString() + "," + nudNumberOfPeople.Value.ToString());
                    specList.Add(cbxSpecialisation.SelectedItem.ToString() + "," + nudNumberOfPeople.Value.ToString());

                    
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbxSpecialisations.Items.RemoveAt(lbxSpecialisations.SelectedIndex);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ServiceRequest srE = new ServiceRequest();
            ServiceRequest sr = new ServiceRequest(richTextBox1.Text, dashform.callInfo.CallID, specList, srE.service_OnInitialization);
            Action action = sr.service_OnInitialization;
            sr.CreateServiceRequest(sr);
        }
    }
}
