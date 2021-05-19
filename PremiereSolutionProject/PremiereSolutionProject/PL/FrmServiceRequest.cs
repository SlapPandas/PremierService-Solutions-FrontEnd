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

        #region Declarations

        frmDashboard dashform;
        List<string> specList;
        List<Specialisation> spec;

        #endregion

        #region Events

        public FrmServiceRequest(frmDashboard _dashform):this()
        {
            dashform = _dashform;
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
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
                MessageBox.Show(fe.Message, "User input is incorect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxSpecialisation.Text))
            {
                MessageBox.Show("Please make sure is a specialisations selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cbxSpecialisation.Items.Remove(cbxSpecialisation.SelectedIndex);
                string temp = cbxSpecialisation.SelectedItem.ToString() + "," + nudNumberOfPeople.Value.ToString();
                string temp2;
                string nameCheck = temp.Remove(temp.Length - 2);
                bool notInside = true;                
                List<String> tempList = new List<string>();
                List<String> tempNameList = new List<string>();
                tempList = lbxSpecialisations.Items.Cast<String>().ToList();
                foreach (var item in tempList)
                {
                    temp2 = temp.Remove(temp.Length - 2);
                    tempNameList.Add(temp2);
                }
                foreach (var item in tempNameList)
                {
                    if (nameCheck == item)
                    {
                        notInside = false;
                    }
                }
                if (notInside)
                {
                    lbxSpecialisations.Items.Add(temp);
                }
                else
                {
                    MessageBox.Show("Service already exsits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lbxSpecialisations.Items.RemoveAt(lbxSpecialisations.SelectedIndex);
            }
            catch 
            {
                MessageBox.Show("Please select a serice to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure the information is correct?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if ((lbxSpecialisations.Items.Count == 0) || string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("Please fill in all the fields correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    specList = lbxSpecialisations.Items.Cast<string>().ToList();
                    ServiceRequest srE = new ServiceRequest();
                    ServiceRequest sr = new ServiceRequest(richTextBox1.Text, dashform.callInfo.CallID, specList, srE.service_OnInitialization);
                    Action action = sr.service_OnInitialization;
                    sr.CreateServiceRequest(sr);
                    richTextBox1.Clear();
                    lbxSpecialisations.Items.Clear();
                    cbxSpecialisation.Text = "";
                    nudNumberOfPeople.Value = 1;
                }
                
            }            
        }

        private void lbxSpecialisations_Click(object sender, EventArgs e)
        {
            if (lbxSpecialisations.SelectedIndex != -1)
            {
                string selectedItemName = lbxSpecialisations.SelectedItem.ToString();
            }
            else
            {
                lbxSpecialisations.SelectedIndex = lbxSpecialisations.Items.Count - 1;
                string selectedItemName = lbxSpecialisations.SelectedItem.ToString();
            }
        }

        #endregion


    }
}
