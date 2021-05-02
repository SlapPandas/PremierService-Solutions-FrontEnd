
namespace PremiereSolutionProject.PL
{
    partial class frmServicePackageManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCurrentServicePackages = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbxPromotionYes = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxPromotionNo = new System.Windows.Forms.CheckBox();
            this.dtpPromotionStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPromotionEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numUDPercentage = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxHelpNo = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxHelpYes = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxResponseTime = new System.Windows.Forms.ComboBox();
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvSelectServices = new System.Windows.Forms.DataGridView();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnDeletePackage = new System.Windows.Forms.Button();
            this.btnUpdatePackage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServicePackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectServices)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Package Management";
            // 
            // dgvCurrentServicePackages
            // 
            this.dgvCurrentServicePackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentServicePackages.Location = new System.Drawing.Point(181, 76);
            this.dgvCurrentServicePackages.Name = "dgvCurrentServicePackages";
            this.dgvCurrentServicePackages.RowHeadersWidth = 62;
            this.dgvCurrentServicePackages.Size = new System.Drawing.Size(452, 95);
            this.dgvCurrentServicePackages.TabIndex = 2;
            this.dgvCurrentServicePackages.SelectionChanged += new System.EventHandler(this.dgvCurrentServicePackages_SelectionChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Package Name";
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusinessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusinessName.Location = new System.Drawing.Point(143, 205);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(115, 20);
            this.txtBusinessName.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Service List";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(143, 247);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 59;
            // 
            // cbxPromotionYes
            // 
            this.cbxPromotionYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxPromotionYes.AutoSize = true;
            this.cbxPromotionYes.Location = new System.Drawing.Point(467, 205);
            this.cbxPromotionYes.Name = "cbxPromotionYes";
            this.cbxPromotionYes.Size = new System.Drawing.Size(44, 17);
            this.cbxPromotionYes.TabIndex = 60;
            this.cbxPromotionYes.Text = "Yes";
            this.cbxPromotionYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(316, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Promotion";
            // 
            // cbxPromotionNo
            // 
            this.cbxPromotionNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxPromotionNo.AutoSize = true;
            this.cbxPromotionNo.Location = new System.Drawing.Point(550, 206);
            this.cbxPromotionNo.Name = "cbxPromotionNo";
            this.cbxPromotionNo.Size = new System.Drawing.Size(40, 17);
            this.cbxPromotionNo.TabIndex = 62;
            this.cbxPromotionNo.Text = "No";
            this.cbxPromotionNo.UseVisualStyleBackColor = true;
            // 
            // dtpPromotionStart
            // 
            this.dtpPromotionStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpPromotionStart.Location = new System.Drawing.Point(470, 240);
            this.dtpPromotionStart.Name = "dtpPromotionStart";
            this.dtpPromotionStart.Size = new System.Drawing.Size(183, 20);
            this.dtpPromotionStart.TabIndex = 63;
            // 
            // dtpPromotionEnd
            // 
            this.dtpPromotionEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpPromotionEnd.Location = new System.Drawing.Point(470, 288);
            this.dtpPromotionEnd.Name = "dtpPromotionEnd";
            this.dtpPromotionEnd.Size = new System.Drawing.Size(183, 20);
            this.dtpPromotionEnd.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Promotion Start Date";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Promotion End Date";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 14);
            this.label8.TabIndex = 67;
            this.label8.Text = "Current Service Packages:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Promotion Percentage";
            // 
            // numUDPercentage
            // 
            this.numUDPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numUDPercentage.Location = new System.Drawing.Point(470, 332);
            this.numUDPercentage.Name = "numUDPercentage";
            this.numUDPercentage.Size = new System.Drawing.Size(47, 20);
            this.numUDPercentage.TabIndex = 69;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(143, 291);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(115, 21);
            this.comboBox2.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "Priority Level";
            // 
            // cbxHelpNo
            // 
            this.cbxHelpNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxHelpNo.AutoSize = true;
            this.cbxHelpNo.Location = new System.Drawing.Point(221, 334);
            this.cbxHelpNo.Name = "cbxHelpNo";
            this.cbxHelpNo.Size = new System.Drawing.Size(40, 17);
            this.cbxHelpNo.TabIndex = 74;
            this.cbxHelpNo.Text = "No";
            this.cbxHelpNo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Helpline";
            // 
            // cbxHelpYes
            // 
            this.cbxHelpYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxHelpYes.AutoSize = true;
            this.cbxHelpYes.Location = new System.Drawing.Point(143, 334);
            this.cbxHelpYes.Name = "cbxHelpYes";
            this.cbxHelpYes.Size = new System.Drawing.Size(44, 17);
            this.cbxHelpYes.TabIndex = 72;
            this.cbxHelpYes.Text = "Yes";
            this.cbxHelpYes.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 375);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 76;
            this.label11.Text = "Response Time";
            // 
            // cbxResponseTime
            // 
            this.cbxResponseTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxResponseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxResponseTime.FormattingEnabled = true;
            this.cbxResponseTime.Items.AddRange(new object[] {
            "1 Hour",
            "2 Hours",
            "24 Hours",
            "48 Hours",
            "72 Hours"});
            this.cbxResponseTime.Location = new System.Drawing.Point(143, 375);
            this.cbxResponseTime.Name = "cbxResponseTime";
            this.cbxResponseTime.Size = new System.Drawing.Size(115, 21);
            this.cbxResponseTime.TabIndex = 77;
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePackage.Location = new System.Drawing.Point(171, 488);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(101, 26);
            this.btnCreatePackage.TabIndex = 78;
            this.btnCreatePackage.Text = "Create Package";
            this.btnCreatePackage.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(603, 517);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 23);
            this.btnExit.TabIndex = 81;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(318, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Services";
            // 
            // dgvSelectServices
            // 
            this.dgvSelectServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSelectServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectServices.Location = new System.Drawing.Point(467, 373);
            this.dgvSelectServices.Name = "dgvSelectServices";
            this.dgvSelectServices.RowHeadersWidth = 62;
            this.dgvSelectServices.Size = new System.Drawing.Size(185, 80);
            this.dgvSelectServices.TabIndex = 83;
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.Location = new System.Drawing.Point(579, 339);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(74, 22);
            this.btnAddService.TabIndex = 84;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = true;
            // 
            // btnDeletePackage
            // 
            this.btnDeletePackage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeletePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePackage.Location = new System.Drawing.Point(406, 488);
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Size = new System.Drawing.Size(101, 26);
            this.btnDeletePackage.TabIndex = 85;
            this.btnDeletePackage.Text = "Delete Package";
            this.btnDeletePackage.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePackage
            // 
            this.btnUpdatePackage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePackage.Location = new System.Drawing.Point(290, 488);
            this.btnUpdatePackage.Name = "btnUpdatePackage";
            this.btnUpdatePackage.Size = new System.Drawing.Size(101, 26);
            this.btnUpdatePackage.TabIndex = 86;
            this.btnUpdatePackage.Text = "Update Package";
            this.btnUpdatePackage.UseVisualStyleBackColor = true;
            // 
            // frmServicePackageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(681, 550);
            this.Controls.Add(this.btnUpdatePackage);
            this.Controls.Add(this.btnDeletePackage);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.dgvSelectServices);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreatePackage);
            this.Controls.Add(this.cbxResponseTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbxHelpNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxHelpYes);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numUDPercentage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpPromotionEnd);
            this.Controls.Add(this.dtpPromotionStart);
            this.Controls.Add(this.cbxPromotionNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxPromotionYes);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBusinessName);
            this.Controls.Add(this.dgvCurrentServicePackages);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "frmServicePackageManagement";
            this.Text = "Create A New Service Package";
            this.Load += new System.EventHandler(this.frmServicePackageManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServicePackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCurrentServicePackages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cbxPromotionYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxPromotionNo;
        private System.Windows.Forms.DateTimePicker dtpPromotionStart;
        private System.Windows.Forms.DateTimePicker dtpPromotionEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUDPercentage;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbxHelpNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbxHelpYes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxResponseTime;
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvSelectServices;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnDeletePackage;
        private System.Windows.Forms.Button btnUpdatePackage;
    }
}