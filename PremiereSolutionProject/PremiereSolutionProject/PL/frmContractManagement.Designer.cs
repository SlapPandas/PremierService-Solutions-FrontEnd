
namespace PremiereSolutionProject.PL
{
    partial class frmContractManagement
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreateContract = new System.Windows.Forms.Button();
            this.lblServicesInPackage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddServicePackage = new System.Windows.Forms.Button();
            this.cbxServicePackages = new System.Windows.Forms.ComboBox();
            this.dgvViewServices = new System.Windows.Forms.DataGridView();
            this.lbxPackages = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lvwAllContracts = new System.Windows.Forms.ListView();
            this.lblCurrentContracts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(13, 13);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 29);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreateContract
            // 
            this.btnCreateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnCreateContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateContract.Font = new System.Drawing.Font("Microsoft Yi Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateContract.Location = new System.Drawing.Point(796, 459);
            this.btnCreateContract.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateContract.Name = "btnCreateContract";
            this.btnCreateContract.Size = new System.Drawing.Size(259, 99);
            this.btnCreateContract.TabIndex = 28;
            this.btnCreateContract.Text = "Create New Contract";
            this.btnCreateContract.UseVisualStyleBackColor = false;
            this.btnCreateContract.Click += new System.EventHandler(this.btnCreateContract_Click);
            // 
            // lblServicesInPackage
            // 
            this.lblServicesInPackage.AutoSize = true;
            this.lblServicesInPackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicesInPackage.Location = new System.Drawing.Point(62, 175);
            this.lblServicesInPackage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServicesInPackage.Name = "lblServicesInPackage";
            this.lblServicesInPackage.Size = new System.Drawing.Size(230, 19);
            this.lblServicesInPackage.TabIndex = 24;
            this.lblServicesInPackage.Text = "Services in Service Package";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Service package";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(426, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 33);
            this.label1.TabIndex = 18;
            this.label1.Text = "Contract Management";
            // 
            // btnAddServicePackage
            // 
            this.btnAddServicePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServicePackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServicePackage.Location = new System.Drawing.Point(66, 410);
            this.btnAddServicePackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddServicePackage.Name = "btnAddServicePackage";
            this.btnAddServicePackage.Size = new System.Drawing.Size(200, 67);
            this.btnAddServicePackage.TabIndex = 33;
            this.btnAddServicePackage.Text = "Add Service Package";
            this.btnAddServicePackage.UseVisualStyleBackColor = true;
            this.btnAddServicePackage.Click += new System.EventHandler(this.btnAddServicePackage_Click);
            // 
            // cbxServicePackages
            // 
            this.cbxServicePackages.FormattingEnabled = true;
            this.cbxServicePackages.Location = new System.Drawing.Point(66, 142);
            this.cbxServicePackages.Margin = new System.Windows.Forms.Padding(4);
            this.cbxServicePackages.Name = "cbxServicePackages";
            this.cbxServicePackages.Size = new System.Drawing.Size(300, 21);
            this.cbxServicePackages.TabIndex = 29;
            this.cbxServicePackages.SelectedIndexChanged += new System.EventHandler(this.cbxServicePackages_SelectedIndexChanged);
            // 
            // dgvViewServices
            // 
            this.dgvViewServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewServices.Location = new System.Drawing.Point(66, 198);
            this.dgvViewServices.Margin = new System.Windows.Forms.Padding(4);
            this.dgvViewServices.Name = "dgvViewServices";
            this.dgvViewServices.ReadOnly = true;
            this.dgvViewServices.RowHeadersWidth = 62;
            this.dgvViewServices.Size = new System.Drawing.Size(677, 182);
            this.dgvViewServices.TabIndex = 27;
            // 
            // lbxPackages
            // 
            this.lbxPackages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxPackages.FormattingEnabled = true;
            this.lbxPackages.ItemHeight = 18;
            this.lbxPackages.Location = new System.Drawing.Point(294, 410);
            this.lbxPackages.Name = "lbxPackages";
            this.lbxPackages.Size = new System.Drawing.Size(449, 148);
            this.lbxPackages.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 384);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Added packages";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(66, 490);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(200, 67);
            this.btnRemove.TabIndex = 36;
            this.btnRemove.Text = "Remove Service Package";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(604, 134);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(139, 56);
            this.btnClearAll.TabIndex = 37;
            this.btnClearAll.Text = "Clear all fields";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(796, 411);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(259, 40);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel creation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Yi Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(453, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 27);
            this.label4.TabIndex = 39;
            this.label4.Text = "Add a new contract";
            // 
            // lvwAllContracts
            // 
            this.lvwAllContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAllContracts.HideSelection = false;
            this.lvwAllContracts.Location = new System.Drawing.Point(796, 142);
            this.lvwAllContracts.Name = "lvwAllContracts";
            this.lvwAllContracts.Size = new System.Drawing.Size(259, 261);
            this.lvwAllContracts.TabIndex = 40;
            this.lvwAllContracts.UseCompatibleStateImageBehavior = false;
            // 
            // lblCurrentContracts
            // 
            this.lblCurrentContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentContracts.AutoSize = true;
            this.lblCurrentContracts.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentContracts.Location = new System.Drawing.Point(792, 119);
            this.lblCurrentContracts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentContracts.Name = "lblCurrentContracts";
            this.lblCurrentContracts.Size = new System.Drawing.Size(218, 19);
            this.lblCurrentContracts.TabIndex = 41;
            this.lblCurrentContracts.Text = "Current Available Contracts";
            // 
            // frmContractManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1123, 590);
            this.Controls.Add(this.lblCurrentContracts);
            this.Controls.Add(this.lvwAllContracts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxPackages);
            this.Controls.Add(this.btnAddServicePackage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbxServicePackages);
            this.Controls.Add(this.btnCreateContract);
            this.Controls.Add(this.dgvViewServices);
            this.Controls.Add(this.lblServicesInPackage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmContractManagement";
            this.Text = "frmCreateContract";
            this.Load += new System.EventHandler(this.frmContractManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateContract;
        private System.Windows.Forms.Label lblServicesInPackage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddServicePackage;
        private System.Windows.Forms.ComboBox cbxServicePackages;
        private System.Windows.Forms.DataGridView dgvViewServices;
        private System.Windows.Forms.ListBox lbxPackages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwAllContracts;
        private System.Windows.Forms.Label lblCurrentContracts;
    }
}