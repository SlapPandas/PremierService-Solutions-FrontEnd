using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using PremiereSolutionProject.BLL;

namespace PremiereSolutionProject.PL
{
    public partial class frmDashboard : Form
    {
        public Call callInfo;
        public frmDashboard()
        {
            InitializeComponent();

            //Lijani: 
            //I added this thread to run alongside the main thread to assign pending jobs 'automatically' every 5 minutes
            Thread th = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Now assigning jobs..");
                    ServiceRequest sr = new ServiceRequest();
                    sr.AssignPendingJobs();
                    Console.WriteLine("Jobs have been assigned..");
                    Thread.Sleep(300000);
                }
            });
            th.Start();

            CustomizeDesign();
        }

        #region Main functioning

        private void CustomizeDesign()
        {
            pnlCallCenterSubmenu.Visible = false;
            pnlServiceDeptSubMenu.Visible = false;
            pnlClientMaintainSubMenu.Visible = false;
            pnlContractMaintSubMenu.Visible = false;
            pnlServiceSubMenu.Visible = false;
        }
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

            if (pnlServiceSubMenu.Visible == true)
            {
                pnlServiceSubMenu.Visible = false;
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
        #endregion

        #region Main buttons
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


        private void btnServiceManager_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlServiceSubMenu);
        }

        private void btnErrorHandling_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmErrorHandling());
            HideSubMenu();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        #endregion

        #region btnCallCenterSubMenu
        private void btnCall_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCallCenter(this));
            HideSubMenu();
        }

        private void btnCreateServiceRequest_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmServiceRequest(this));
            HideSubMenu();
        }

        private void btnClientInformation_Click(object sender, EventArgs e)
        {
            openChildForm(new frmClientInfo());
            HideSubMenu();
        }

        #endregion

        #region btnServiceDeptSubMenu
        private void btnViewServiceReq_Click(object sender, EventArgs e)
        {
            openChildForm(new frmViewServiceRequests());
            HideSubMenu();
        }

        

        private void btnJobManagement_Click(object sender, EventArgs e)
        {
            openChildForm(new frmJobsManagement());
            HideSubMenu();
        }

        #endregion

        #region btnContractMaintenanceSubMenu
        private void btnServicePackageManage_Click(object sender, EventArgs e)
        {
            openChildForm(new frmServicePackageManagement());
            HideSubMenu();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            openChildForm(new frmServiceManagement());
            HideSubMenu();
        }

        private void btnContractInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new frmContractManagement());
            HideSubMenu();
        }

        #endregion

        #region btnClientMaintainSubMenu
        private void btnIndiClient_Click(object sender, EventArgs e)
        {
            openChildForm(new frmIndividualClient());
            HideSubMenu();
        }

        private void btnBusinessClient_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBusinessClient());
            HideSubMenu();
        }

        private void btnBusinessContact_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBusinessContact());
            HideSubMenu();
        }

        private void btnClientContract_Click(object sender, EventArgs e)
        {
            openChildForm(new frmClientContract());
            HideSubMenu();
        }

        private void btnBusinessContact_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmBusinessContact(this));
            HideSubMenu();
        }

        private void btnClientContract_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmClientContract(this));
            HideSubMenu();
        }
        #endregion

        #region btnClientSatisSubMenu
 
        private void btnFollowRequest_Click(object sender, EventArgs e)
        {
            //Code
            HideSubMenu();
        }

        private void btnViewClientData_Click(object sender, EventArgs e)
        {
            openChildForm(new frmClientInfo());
            HideSubMenu();
        }
        #endregion

        #region Service Manager SubMenu

        private void btnEscalate_Click(object sender, EventArgs e)
        {
            openChildForm(new frmEscalateJobs());
            HideSubMenu();
        }

        private void btnManageEmp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageEmployee());
            HideSubMenu();
        }
        private void btnManageSpecialisation_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageSpecialisation());
            HideSubMenu();
        }

        private void btnManageME_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FrmManageMaintenanceEmployee());
            HideSubMenu();
        }

        private void btnAssignNewEmp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAssignNewEmployee());
            HideSubMenu();
        }


        #endregion

        private void btnClientSatisfaction_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/ClientSatisfaction/index.php");
        }
    }
}
