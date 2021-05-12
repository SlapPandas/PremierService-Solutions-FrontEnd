
namespace PremiereSolutionProject.PL
{
    partial class frmServiceManagement
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
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCurrentServices = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.rtbServiceDescription = new System.Windows.Forms.RichTextBox();
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnUpdateService = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServices)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 109);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 70;
            this.label8.Text = "Current Services";
            // 
            // dgvCurrentServices
            // 
            this.dgvCurrentServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentServices.Location = new System.Drawing.Point(190, 109);
            this.dgvCurrentServices.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCurrentServices.Name = "dgvCurrentServices";
            this.dgvCurrentServices.RowHeadersWidth = 62;
            this.dgvCurrentServices.Size = new System.Drawing.Size(724, 178);
            this.dgvCurrentServices.TabIndex = 69;
            this.dgvCurrentServices.SelectionChanged += new System.EventHandler(this.dgvCurrentServices_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 26);
            this.label1.TabIndex = 68;
            this.label1.Text = "Service Management";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 403);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 73;
            this.label4.Text = "Service Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 335);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Service Name";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceName.Location = new System.Drawing.Point(190, 335);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(4);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(545, 21);
            this.txtServiceName.TabIndex = 71;
            // 
            // rtbServiceDescription
            // 
            this.rtbServiceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbServiceDescription.Location = new System.Drawing.Point(190, 403);
            this.rtbServiceDescription.Margin = new System.Windows.Forms.Padding(4);
            this.rtbServiceDescription.Name = "rtbServiceDescription";
            this.rtbServiceDescription.Size = new System.Drawing.Size(545, 172);
            this.rtbServiceDescription.TabIndex = 74;
            this.rtbServiceDescription.Text = "";
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnCreatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePackage.Location = new System.Drawing.Point(790, 390);
            this.btnCreatePackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(166, 29);
            this.btnCreatePackage.TabIndex = 79;
            this.btnCreatePackage.Text = "Create Service";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(13, 13);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 80;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnDeleteService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteService.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteService.Location = new System.Drawing.Point(790, 444);
            this.btnDeleteService.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(159, 29);
            this.btnDeleteService.TabIndex = 81;
            this.btnDeleteService.Text = "Delete Service";
            this.btnDeleteService.UseVisualStyleBackColor = false;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnUpdateService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateService.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateService.Location = new System.Drawing.Point(790, 335);
            this.btnUpdateService.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(158, 29);
            this.btnUpdateService.TabIndex = 82;
            this.btnUpdateService.Text = "Update Service";
            this.btnUpdateService.UseVisualStyleBackColor = false;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // frmServiceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1168, 631);
            this.Controls.Add(this.btnUpdateService);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreatePackage);
            this.Controls.Add(this.rtbServiceDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvCurrentServices);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmServiceManagement";
            this.Text = "Create Service";
            this.Load += new System.EventHandler(this.frmServiceManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvCurrentServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.RichTextBox rtbServiceDescription;
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Button btnUpdateService;
    }
}