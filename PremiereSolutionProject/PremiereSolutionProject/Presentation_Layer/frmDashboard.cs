using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiereSolutionProject.Presentation_Layer
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            CustomizeDesign();
        }
        private void CustomizeDesign()
        {
            pnlCallCenterSubmenu.Visible = false;
            pnlServiceDeptSubMenu.Visible = false;
            pnlClientMaintainSubMenu.Visible = false;
            pnlContractMaintSubMenu.Visible = false;
            pnlClientSatisSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (pnlCallCenterSubmenu.Visible == true)
            {
                pnlCallCenterSubmenu.Visible = false;
            }

            if (pnlServiceDeptSubMenu.Visible == true)
            {
                pnlServiceDeptSubMenu.Visible = false;
            }

            if (pnlClientMaintainSubMenu.Visible == true)
            {
                pnlClientMaintainSubMenu.Visible = false;
            }

            if (pnlContractMaintSubMenu.Visible == true)
            {
                pnlContractMaintSubMenu.Visible = false;
            }

            if (pnlClientSatisSubMenu.Visible == true)
            {
                pnlClientSatisSubMenu.Visible = false;
            }
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnCallCenter_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlCallCenterSubmenu);
        }

        private void btnServiceDept_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlServiceDeptSubMenu);
        }

        private void btnContractMaintenance_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlContractMaintSubMenu);
        }

        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlClientMaintainSubMenu);
        }

        private void btnClientSatis_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlClientSatisSubMenu);
        }
        #region btnCallCenterSubMenu
        private void btnCall_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCallCenter());
            HideSubMenu();
        }

        private void btnCreateServiceRequest_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmServiceRequest());
            HideSubMenu();
        }

        private void btnClientInformation_Click(object sender, EventArgs e)
        {
            openChildForm(new frmViewClientInfo());
            HideSubMenu();
        }

        #endregion

        #region btnServiceDeptSubMenu
        private void btnJobs_Click(object sender, EventArgs e)
        {
            //Code
            HideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Code
            HideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Code
            HideSubMenu();
        }

        #endregion

        #region btnContractMaintenanceSubMenu
        private void btnCreateServicePackage_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCreateServicePackage());
            HideSubMenu();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCreateService());
            HideSubMenu();
        }

        private void btnContractInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new frmViewClientInfo());
            HideSubMenu();
        }

        #endregion

        #region btnClientMaintainSubMenu
        private void btnCreateIndiClient_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddIndividualClient());
            HideSubMenu();
        }

        private void btnCreateBusinessClient_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddBusinessClient());
            HideSubMenu();
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCreateContract());
            HideSubMenu();
        }

        #endregion

        #region btnClientSatisSubMenu
        private void btnClientSatisCall_Click(object sender, EventArgs e)
        {
            openChildForm(new frmClientSatisfaction());
            HideSubMenu();
        }

        private void btnFollowRequest_Click(object sender, EventArgs e)
        {
            //Code
            HideSubMenu();
        }

        private void btnViewClientData_Click(object sender, EventArgs e)
        {
            openChildForm(new frmViewClientInfo());
            HideSubMenu();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnlChildForm.Controls.Add(childForm);
                pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new frmClientSatisfaction());
            HideSubMenu();
        }
    }
}
