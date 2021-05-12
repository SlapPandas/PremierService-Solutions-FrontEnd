
namespace PremiereSolutionProject.PL
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnErrorHandling = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlClientSatisSubMenu = new System.Windows.Forms.Panel();
            this.btnViewClientData = new System.Windows.Forms.Button();
            this.btnFollowRequest = new System.Windows.Forms.Button();
            this.btnClientSatisCall = new System.Windows.Forms.Button();
            this.btnClientSatis = new System.Windows.Forms.Button();
            this.pnlClientMaintainSubMenu = new System.Windows.Forms.Panel();
            this.btnBusinessContact = new System.Windows.Forms.Button();
            this.btnClientContract = new System.Windows.Forms.Button();
            this.btnBusinessClient = new System.Windows.Forms.Button();
            this.btnIndiClient = new System.Windows.Forms.Button();
            this.btnClientMaintence = new System.Windows.Forms.Button();
            this.pnlContractMaintSubMenu = new System.Windows.Forms.Panel();
            this.btnCreateContract = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnServicePackageManage = new System.Windows.Forms.Button();
            this.btnContractMaintenance = new System.Windows.Forms.Button();
            this.pnlServiceDeptSubMenu = new System.Windows.Forms.Panel();
            this.btnJobManagement = new System.Windows.Forms.Button();
            this.btnViewServiceReq = new System.Windows.Forms.Button();
            this.btnServiceDept = new System.Windows.Forms.Button();
            this.pnlCallCenterSubmenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnClientInformation = new System.Windows.Forms.Button();
            this.btnCreateServiceRequest = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnCallCenter = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.btnEscalateJobs = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pnlSideMenu.SuspendLayout();
            this.pnlClientSatisSubMenu.SuspendLayout();
            this.pnlClientMaintainSubMenu.SuspendLayout();
            this.pnlContractMaintSubMenu.SuspendLayout();
            this.pnlServiceDeptSubMenu.SuspendLayout();
            this.pnlCallCenterSubmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.AutoScroll = true;
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.pnlSideMenu.Controls.Add(this.panel2);
            this.pnlSideMenu.Controls.Add(this.btnEscalateJobs);
            this.pnlSideMenu.Controls.Add(this.btnErrorHandling);
            this.pnlSideMenu.Controls.Add(this.btnExit);
            this.pnlSideMenu.Controls.Add(this.pnlClientSatisSubMenu);
            this.pnlSideMenu.Controls.Add(this.btnClientSatis);
            this.pnlSideMenu.Controls.Add(this.pnlClientMaintainSubMenu);
            this.pnlSideMenu.Controls.Add(this.btnClientMaintence);
            this.pnlSideMenu.Controls.Add(this.pnlContractMaintSubMenu);
            this.pnlSideMenu.Controls.Add(this.btnContractMaintenance);
            this.pnlSideMenu.Controls.Add(this.pnlServiceDeptSubMenu);
            this.pnlSideMenu.Controls.Add(this.btnServiceDept);
            this.pnlSideMenu.Controls.Add(this.pnlCallCenterSubmenu);
            this.pnlSideMenu.Controls.Add(this.btnCallCenter);
            this.pnlSideMenu.Controls.Add(this.pnlLogo);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(333, 801);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // btnErrorHandling
            // 
            this.btnErrorHandling.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnErrorHandling.FlatAppearance.BorderSize = 0;
            this.btnErrorHandling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorHandling.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnErrorHandling.Image = ((System.Drawing.Image)(resources.GetObject("btnErrorHandling.Image")));
            this.btnErrorHandling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnErrorHandling.Location = new System.Drawing.Point(0, 1181);
            this.btnErrorHandling.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnErrorHandling.Name = "btnErrorHandling";
            this.btnErrorHandling.Size = new System.Drawing.Size(312, 63);
            this.btnErrorHandling.TabIndex = 7;
            this.btnErrorHandling.Text = "        Error Handling";
            this.btnErrorHandling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnErrorHandling.UseVisualStyleBackColor = true;
            this.btnErrorHandling.Click += new System.EventHandler(this.btnErrorHandling_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 1408);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(312, 55);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "    Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlClientSatisSubMenu
            // 
            this.pnlClientSatisSubMenu.Controls.Add(this.btnViewClientData);
            this.pnlClientSatisSubMenu.Controls.Add(this.btnFollowRequest);
            this.pnlClientSatisSubMenu.Controls.Add(this.btnClientSatisCall);
            this.pnlClientSatisSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientSatisSubMenu.Location = new System.Drawing.Point(0, 1035);
            this.pnlClientSatisSubMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlClientSatisSubMenu.Name = "pnlClientSatisSubMenu";
            this.pnlClientSatisSubMenu.Size = new System.Drawing.Size(312, 146);
            this.pnlClientSatisSubMenu.TabIndex = 1;
            // 
            // btnViewClientData
            // 
            this.btnViewClientData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnViewClientData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewClientData.FlatAppearance.BorderSize = 0;
            this.btnViewClientData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewClientData.ForeColor = System.Drawing.Color.LightGray;
            this.btnViewClientData.Location = new System.Drawing.Point(0, 100);
            this.btnViewClientData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewClientData.Name = "btnViewClientData";
            this.btnViewClientData.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnViewClientData.Size = new System.Drawing.Size(312, 50);
            this.btnViewClientData.TabIndex = 15;
            this.btnViewClientData.Text = "View Client Data";
            this.btnViewClientData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewClientData.UseVisualStyleBackColor = false;
            this.btnViewClientData.Click += new System.EventHandler(this.btnViewClientData_Click);
            // 
            // btnFollowRequest
            // 
            this.btnFollowRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnFollowRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFollowRequest.FlatAppearance.BorderSize = 0;
            this.btnFollowRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollowRequest.ForeColor = System.Drawing.Color.LightGray;
            this.btnFollowRequest.Location = new System.Drawing.Point(0, 50);
            this.btnFollowRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFollowRequest.Name = "btnFollowRequest";
            this.btnFollowRequest.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnFollowRequest.Size = new System.Drawing.Size(312, 50);
            this.btnFollowRequest.TabIndex = 14;
            this.btnFollowRequest.Text = "Follow Up Request";
            this.btnFollowRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFollowRequest.UseVisualStyleBackColor = false;
            this.btnFollowRequest.Click += new System.EventHandler(this.btnFollowRequest_Click);
            // 
            // btnClientSatisCall
            // 
            this.btnClientSatisCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnClientSatisCall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientSatisCall.FlatAppearance.BorderSize = 0;
            this.btnClientSatisCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientSatisCall.ForeColor = System.Drawing.Color.LightGray;
            this.btnClientSatisCall.Location = new System.Drawing.Point(0, 0);
            this.btnClientSatisCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientSatisCall.Name = "btnClientSatisCall";
            this.btnClientSatisCall.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnClientSatisCall.Size = new System.Drawing.Size(312, 50);
            this.btnClientSatisCall.TabIndex = 13;
            this.btnClientSatisCall.Text = "Call";
            this.btnClientSatisCall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientSatisCall.UseVisualStyleBackColor = false;
            this.btnClientSatisCall.Click += new System.EventHandler(this.btnClientSatisCall_Click);
            // 
            // btnClientSatis
            // 
            this.btnClientSatis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientSatis.FlatAppearance.BorderSize = 0;
            this.btnClientSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientSatis.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientSatis.Image = ((System.Drawing.Image)(resources.GetObject("btnClientSatis.Image")));
            this.btnClientSatis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientSatis.Location = new System.Drawing.Point(0, 980);
            this.btnClientSatis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientSatis.Name = "btnClientSatis";
            this.btnClientSatis.Size = new System.Drawing.Size(312, 55);
            this.btnClientSatis.TabIndex = 5;
            this.btnClientSatis.Text = "        Client Satisfaction";
            this.btnClientSatis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientSatis.UseVisualStyleBackColor = true;
            this.btnClientSatis.Click += new System.EventHandler(this.btnClientSatis_Click);
            // 
            // pnlClientMaintainSubMenu
            // 
            this.pnlClientMaintainSubMenu.Controls.Add(this.btnBusinessContact);
            this.pnlClientMaintainSubMenu.Controls.Add(this.btnClientContract);
            this.pnlClientMaintainSubMenu.Controls.Add(this.btnBusinessClient);
            this.pnlClientMaintainSubMenu.Controls.Add(this.btnIndiClient);
            this.pnlClientMaintainSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientMaintainSubMenu.Location = new System.Drawing.Point(0, 779);
            this.pnlClientMaintainSubMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlClientMaintainSubMenu.Name = "pnlClientMaintainSubMenu";
            this.pnlClientMaintainSubMenu.Size = new System.Drawing.Size(312, 201);
            this.pnlClientMaintainSubMenu.TabIndex = 1;
            // 
            // btnBusinessContact
            // 
            this.btnBusinessContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnBusinessContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBusinessContact.FlatAppearance.BorderSize = 0;
            this.btnBusinessContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusinessContact.ForeColor = System.Drawing.Color.LightGray;
            this.btnBusinessContact.Location = new System.Drawing.Point(0, 150);
            this.btnBusinessContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusinessContact.Name = "btnBusinessContact";
            this.btnBusinessContact.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnBusinessContact.Size = new System.Drawing.Size(312, 50);
            this.btnBusinessContact.TabIndex = 13;
            this.btnBusinessContact.Text = "Add Business Contact";
            this.btnBusinessContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusinessContact.UseVisualStyleBackColor = false;
            this.btnBusinessContact.Click += new System.EventHandler(this.btnBusinessContact_Click);
            // 
            // btnClientContract
            // 
            this.btnClientContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnClientContract.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientContract.FlatAppearance.BorderSize = 0;
            this.btnClientContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientContract.ForeColor = System.Drawing.Color.LightGray;
            this.btnClientContract.Location = new System.Drawing.Point(0, 100);
            this.btnClientContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientContract.Name = "btnClientContract";
            this.btnClientContract.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnClientContract.Size = new System.Drawing.Size(312, 50);
            this.btnClientContract.TabIndex = 12;
            this.btnClientContract.Text = "Client Contract";
            this.btnClientContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientContract.UseVisualStyleBackColor = false;
            this.btnClientContract.Click += new System.EventHandler(this.btnClientContract_Click);
            // 
            // btnBusinessClient
            // 
            this.btnBusinessClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnBusinessClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBusinessClient.FlatAppearance.BorderSize = 0;
            this.btnBusinessClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusinessClient.ForeColor = System.Drawing.Color.LightGray;
            this.btnBusinessClient.Location = new System.Drawing.Point(0, 50);
            this.btnBusinessClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusinessClient.Name = "btnBusinessClient";
            this.btnBusinessClient.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnBusinessClient.Size = new System.Drawing.Size(312, 50);
            this.btnBusinessClient.TabIndex = 11;
            this.btnBusinessClient.Text = "Business Client Management";
            this.btnBusinessClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusinessClient.UseVisualStyleBackColor = false;
            this.btnBusinessClient.Click += new System.EventHandler(this.btnBusinessClient_Click);
            // 
            // btnIndiClient
            // 
            this.btnIndiClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnIndiClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIndiClient.FlatAppearance.BorderSize = 0;
            this.btnIndiClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndiClient.ForeColor = System.Drawing.Color.LightGray;
            this.btnIndiClient.Location = new System.Drawing.Point(0, 0);
            this.btnIndiClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIndiClient.Name = "btnIndiClient";
            this.btnIndiClient.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnIndiClient.Size = new System.Drawing.Size(312, 50);
            this.btnIndiClient.TabIndex = 10;
            this.btnIndiClient.Text = "Individual Client Management";
            this.btnIndiClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndiClient.UseVisualStyleBackColor = false;
            this.btnIndiClient.Click += new System.EventHandler(this.btnIndiClient_Click);
            // 
            // btnClientMaintence
            // 
            this.btnClientMaintence.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientMaintence.FlatAppearance.BorderSize = 0;
            this.btnClientMaintence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientMaintence.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientMaintence.Image = ((System.Drawing.Image)(resources.GetObject("btnClientMaintence.Image")));
            this.btnClientMaintence.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientMaintence.Location = new System.Drawing.Point(0, 724);
            this.btnClientMaintence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientMaintence.Name = "btnClientMaintence";
            this.btnClientMaintence.Size = new System.Drawing.Size(312, 55);
            this.btnClientMaintence.TabIndex = 4;
            this.btnClientMaintence.Text = "         Client Maintenance";
            this.btnClientMaintence.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientMaintence.UseVisualStyleBackColor = true;
            this.btnClientMaintence.Click += new System.EventHandler(this.btnClientMaintence_Click);
            // 
            // pnlContractMaintSubMenu
            // 
            this.pnlContractMaintSubMenu.Controls.Add(this.btnCreateContract);
            this.pnlContractMaintSubMenu.Controls.Add(this.btnServices);
            this.pnlContractMaintSubMenu.Controls.Add(this.btnServicePackageManage);
            this.pnlContractMaintSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContractMaintSubMenu.Location = new System.Drawing.Point(0, 575);
            this.pnlContractMaintSubMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContractMaintSubMenu.Name = "pnlContractMaintSubMenu";
            this.pnlContractMaintSubMenu.Size = new System.Drawing.Size(312, 149);
            this.pnlContractMaintSubMenu.TabIndex = 1;
            // 
            // btnCreateContract
            // 
            this.btnCreateContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnCreateContract.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateContract.FlatAppearance.BorderSize = 0;
            this.btnCreateContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateContract.ForeColor = System.Drawing.Color.LightGray;
            this.btnCreateContract.Location = new System.Drawing.Point(0, 100);
            this.btnCreateContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateContract.Name = "btnCreateContract";
            this.btnCreateContract.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnCreateContract.Size = new System.Drawing.Size(312, 50);
            this.btnCreateContract.TabIndex = 9;
            this.btnCreateContract.Text = "Create Contract";
            this.btnCreateContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateContract.UseVisualStyleBackColor = false;
            this.btnCreateContract.Click += new System.EventHandler(this.btnContractInfo_Click);
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServices.FlatAppearance.BorderSize = 0;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.ForeColor = System.Drawing.Color.LightGray;
            this.btnServices.Location = new System.Drawing.Point(0, 50);
            this.btnServices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnServices.Name = "btnServices";
            this.btnServices.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnServices.Size = new System.Drawing.Size(312, 50);
            this.btnServices.TabIndex = 8;
            this.btnServices.Text = "Service Management";
            this.btnServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnServicePackageManage
            // 
            this.btnServicePackageManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnServicePackageManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServicePackageManage.FlatAppearance.BorderSize = 0;
            this.btnServicePackageManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicePackageManage.ForeColor = System.Drawing.Color.LightGray;
            this.btnServicePackageManage.Location = new System.Drawing.Point(0, 0);
            this.btnServicePackageManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnServicePackageManage.Name = "btnServicePackageManage";
            this.btnServicePackageManage.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnServicePackageManage.Size = new System.Drawing.Size(312, 50);
            this.btnServicePackageManage.TabIndex = 7;
            this.btnServicePackageManage.Text = "Service Package Management";
            this.btnServicePackageManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicePackageManage.UseVisualStyleBackColor = false;
            this.btnServicePackageManage.Click += new System.EventHandler(this.btnServicePackageManage_Click);
            // 
            // btnContractMaintenance
            // 
            this.btnContractMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContractMaintenance.FlatAppearance.BorderSize = 0;
            this.btnContractMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContractMaintenance.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnContractMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("btnContractMaintenance.Image")));
            this.btnContractMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContractMaintenance.Location = new System.Drawing.Point(0, 520);
            this.btnContractMaintenance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContractMaintenance.Name = "btnContractMaintenance";
            this.btnContractMaintenance.Size = new System.Drawing.Size(312, 55);
            this.btnContractMaintenance.TabIndex = 3;
            this.btnContractMaintenance.Text = "      Contract Maintenance";
            this.btnContractMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContractMaintenance.UseVisualStyleBackColor = true;
            this.btnContractMaintenance.Click += new System.EventHandler(this.btnContractMaintenance_Click);
            // 
            // pnlServiceDeptSubMenu
            // 
            this.pnlServiceDeptSubMenu.Controls.Add(this.btnJobManagement);
            this.pnlServiceDeptSubMenu.Controls.Add(this.btnViewServiceReq);
            this.pnlServiceDeptSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlServiceDeptSubMenu.Location = new System.Drawing.Point(0, 418);
            this.pnlServiceDeptSubMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlServiceDeptSubMenu.Name = "pnlServiceDeptSubMenu";
            this.pnlServiceDeptSubMenu.Size = new System.Drawing.Size(312, 102);
            this.pnlServiceDeptSubMenu.TabIndex = 1;
            // 
            // btnJobManagement
            // 
            this.btnJobManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnJobManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnJobManagement.FlatAppearance.BorderSize = 0;
            this.btnJobManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobManagement.ForeColor = System.Drawing.Color.LightGray;
            this.btnJobManagement.Location = new System.Drawing.Point(0, 50);
            this.btnJobManagement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnJobManagement.Name = "btnJobManagement";
            this.btnJobManagement.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnJobManagement.Size = new System.Drawing.Size(312, 50);
            this.btnJobManagement.TabIndex = 6;
            this.btnJobManagement.Text = "Jobs management";
            this.btnJobManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobManagement.UseVisualStyleBackColor = false;
            this.btnJobManagement.Click += new System.EventHandler(this.btnJobManagement_Click);
            // 
            // btnViewServiceReq
            // 
            this.btnViewServiceReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnViewServiceReq.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewServiceReq.FlatAppearance.BorderSize = 0;
            this.btnViewServiceReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewServiceReq.ForeColor = System.Drawing.Color.LightGray;
            this.btnViewServiceReq.Location = new System.Drawing.Point(0, 0);
            this.btnViewServiceReq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewServiceReq.Name = "btnViewServiceReq";
            this.btnViewServiceReq.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnViewServiceReq.Size = new System.Drawing.Size(312, 50);
            this.btnViewServiceReq.TabIndex = 4;
            this.btnViewServiceReq.Text = "View Service Requests";
            this.btnViewServiceReq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewServiceReq.UseVisualStyleBackColor = false;
            this.btnViewServiceReq.Click += new System.EventHandler(this.btnViewServiceReq_Click);
            // 
            // btnServiceDept
            // 
            this.btnServiceDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServiceDept.FlatAppearance.BorderSize = 0;
            this.btnServiceDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceDept.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnServiceDept.Image = ((System.Drawing.Image)(resources.GetObject("btnServiceDept.Image")));
            this.btnServiceDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServiceDept.Location = new System.Drawing.Point(0, 363);
            this.btnServiceDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnServiceDept.Name = "btnServiceDept";
            this.btnServiceDept.Size = new System.Drawing.Size(312, 55);
            this.btnServiceDept.TabIndex = 2;
            this.btnServiceDept.Text = "      Service Department";
            this.btnServiceDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceDept.UseVisualStyleBackColor = true;
            this.btnServiceDept.Click += new System.EventHandler(this.btnServiceDept_Click);
            // 
            // pnlCallCenterSubmenu
            // 
            this.pnlCallCenterSubmenu.Controls.Add(this.panel1);
            this.pnlCallCenterSubmenu.Controls.Add(this.btnClientInformation);
            this.pnlCallCenterSubmenu.Controls.Add(this.btnCreateServiceRequest);
            this.pnlCallCenterSubmenu.Controls.Add(this.btnCall);
            this.pnlCallCenterSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCallCenterSubmenu.Location = new System.Drawing.Point(0, 217);
            this.pnlCallCenterSubmenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCallCenterSubmenu.Name = "pnlCallCenterSubmenu";
            this.pnlCallCenterSubmenu.Size = new System.Drawing.Size(312, 146);
            this.pnlCallCenterSubmenu.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 146);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(0, 100);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(312, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Client Information";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(0, 50);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(312, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Create service request";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.LightGray;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(312, 50);
            this.button4.TabIndex = 1;
            this.button4.Text = "Call";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnClientInformation
            // 
            this.btnClientInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnClientInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientInformation.FlatAppearance.BorderSize = 0;
            this.btnClientInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientInformation.ForeColor = System.Drawing.Color.LightGray;
            this.btnClientInformation.Location = new System.Drawing.Point(0, 100);
            this.btnClientInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientInformation.Name = "btnClientInformation";
            this.btnClientInformation.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnClientInformation.Size = new System.Drawing.Size(312, 47);
            this.btnClientInformation.TabIndex = 3;
            this.btnClientInformation.Text = "Client Information";
            this.btnClientInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientInformation.UseVisualStyleBackColor = false;
            this.btnClientInformation.Click += new System.EventHandler(this.btnClientInformation_Click);
            // 
            // btnCreateServiceRequest
            // 
            this.btnCreateServiceRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnCreateServiceRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateServiceRequest.FlatAppearance.BorderSize = 0;
            this.btnCreateServiceRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateServiceRequest.ForeColor = System.Drawing.Color.LightGray;
            this.btnCreateServiceRequest.Location = new System.Drawing.Point(0, 50);
            this.btnCreateServiceRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateServiceRequest.Name = "btnCreateServiceRequest";
            this.btnCreateServiceRequest.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnCreateServiceRequest.Size = new System.Drawing.Size(312, 50);
            this.btnCreateServiceRequest.TabIndex = 2;
            this.btnCreateServiceRequest.Text = "Create service request";
            this.btnCreateServiceRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateServiceRequest.UseVisualStyleBackColor = false;
            this.btnCreateServiceRequest.Click += new System.EventHandler(this.btnCreateServiceRequest_Click);
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnCall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCall.FlatAppearance.BorderSize = 0;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall.ForeColor = System.Drawing.Color.LightGray;
            this.btnCall.Location = new System.Drawing.Point(0, 0);
            this.btnCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCall.Name = "btnCall";
            this.btnCall.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.btnCall.Size = new System.Drawing.Size(312, 50);
            this.btnCall.TabIndex = 1;
            this.btnCall.Text = "Call";
            this.btnCall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnCallCenter
            // 
            this.btnCallCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCallCenter.FlatAppearance.BorderSize = 0;
            this.btnCallCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallCenter.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCallCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnCallCenter.Image")));
            this.btnCallCenter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCallCenter.Location = new System.Drawing.Point(0, 162);
            this.btnCallCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCallCenter.Name = "btnCallCenter";
            this.btnCallCenter.Size = new System.Drawing.Size(312, 55);
            this.btnCallCenter.TabIndex = 1;
            this.btnCallCenter.Text = "       Call Center";
            this.btnCallCenter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCallCenter.UseVisualStyleBackColor = true;
            this.btnCallCenter.Click += new System.EventHandler(this.btnCallCenter_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(312, 162);
            this.pnlLogo.TabIndex = 1;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlChildForm.BackgroundImage = global::PremiereSolutionProject.Properties.Resources.PSSLogo;
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(333, 0);
            this.pnlChildForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(1214, 801);
            this.pnlChildForm.TabIndex = 2;
            // 
            // btnEscalateJobs
            // 
            this.btnEscalateJobs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEscalateJobs.FlatAppearance.BorderSize = 0;
            this.btnEscalateJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscalateJobs.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEscalateJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnEscalateJobs.Image")));
            this.btnEscalateJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscalateJobs.Location = new System.Drawing.Point(0, 1244);
            this.btnEscalateJobs.Margin = new System.Windows.Forms.Padding(4);
            this.btnEscalateJobs.Name = "btnEscalateJobs";
            this.btnEscalateJobs.Size = new System.Drawing.Size(312, 63);
            this.btnEscalateJobs.TabIndex = 8;
            this.btnEscalateJobs.Text = "        Service Manager";
            this.btnEscalateJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEscalateJobs.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1307);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 101);
            this.panel2.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.LightGray;
            this.button6.Location = new System.Drawing.Point(0, 50);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(312, 50);
            this.button6.TabIndex = 14;
            this.button6.Text = "Assign New Employees To A Job";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.LightGray;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(87, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(312, 50);
            this.button7.TabIndex = 13;
            this.button7.Text = "Escalate Jobs";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 801);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSideMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1258, 723);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlClientSatisSubMenu.ResumeLayout(false);
            this.pnlClientMaintainSubMenu.ResumeLayout(false);
            this.pnlContractMaintSubMenu.ResumeLayout(false);
            this.pnlServiceDeptSubMenu.ResumeLayout(false);
            this.pnlCallCenterSubmenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlCallCenterSubmenu;
        private System.Windows.Forms.Button btnClientInformation;
        private System.Windows.Forms.Button btnCreateServiceRequest;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnCallCenter;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlClientSatisSubMenu;
        private System.Windows.Forms.Button btnViewClientData;
        private System.Windows.Forms.Button btnFollowRequest;
        private System.Windows.Forms.Button btnClientSatisCall;
        private System.Windows.Forms.Button btnClientSatis;
        private System.Windows.Forms.Panel pnlClientMaintainSubMenu;
        private System.Windows.Forms.Button btnClientContract;
        private System.Windows.Forms.Button btnBusinessClient;
        private System.Windows.Forms.Button btnIndiClient;
        private System.Windows.Forms.Button btnClientMaintence;
        private System.Windows.Forms.Panel pnlContractMaintSubMenu;
        private System.Windows.Forms.Button btnCreateContract;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnServicePackageManage;
        private System.Windows.Forms.Button btnContractMaintenance;
        private System.Windows.Forms.Panel pnlServiceDeptSubMenu;
        private System.Windows.Forms.Button btnJobManagement;
        private System.Windows.Forms.Button btnViewServiceReq;
        private System.Windows.Forms.Button btnServiceDept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.Button btnBusinessContact;
        private System.Windows.Forms.Button btnErrorHandling;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnEscalateJobs;
    }
}