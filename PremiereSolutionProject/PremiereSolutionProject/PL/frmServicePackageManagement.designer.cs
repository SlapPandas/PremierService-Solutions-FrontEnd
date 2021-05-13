
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
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnDeletePackage = new System.Windows.Forms.Button();
            this.btnUpdatePackage = new System.Windows.Forms.Button();
            this.lbxAvailable = new System.Windows.Forms.ListBox();
            this.lbxAdded = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServicePackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Package Management";
            // 
            // dgvCurrentServicePackages
            // 
            this.dgvCurrentServicePackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentServicePackages.Location = new System.Drawing.Point(141, 101);
            this.dgvCurrentServicePackages.Name = "dgvCurrentServicePackages";
            this.dgvCurrentServicePackages.RowHeadersWidth = 62;
            this.dgvCurrentServicePackages.Size = new System.Drawing.Size(782, 95);
            this.dgvCurrentServicePackages.TabIndex = 2;
            this.dgvCurrentServicePackages.SelectionChanged += new System.EventHandler(this.dgvCurrentServicePackages_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Package Name";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName.Location = new System.Drawing.Point(152, 230);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(115, 20);
            this.txtPackageName.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "Service Price";
            // 
            // cbxPromotionYes
            // 
            this.cbxPromotionYes.AutoSize = true;
            this.cbxPromotionYes.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPromotionYes.Location = new System.Drawing.Point(140, 315);
            this.cbxPromotionYes.Name = "cbxPromotionYes";
            this.cbxPromotionYes.Size = new System.Drawing.Size(51, 20);
            this.cbxPromotionYes.TabIndex = 60;
            this.cbxPromotionYes.Text = "Yes";
            this.cbxPromotionYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 61;
            this.label5.Text = "Promotion";
            // 
            // cbxPromotionNo
            // 
            this.cbxPromotionNo.AutoSize = true;
            this.cbxPromotionNo.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPromotionNo.Location = new System.Drawing.Point(201, 315);
            this.cbxPromotionNo.Name = "cbxPromotionNo";
            this.cbxPromotionNo.Size = new System.Drawing.Size(45, 20);
            this.cbxPromotionNo.TabIndex = 62;
            this.cbxPromotionNo.Text = "No";
            this.cbxPromotionNo.UseVisualStyleBackColor = true;
            // 
            // dtpPromotionStart
            // 
            this.dtpPromotionStart.Location = new System.Drawing.Point(200, 342);
            this.dtpPromotionStart.Name = "dtpPromotionStart";
            this.dtpPromotionStart.Size = new System.Drawing.Size(183, 20);
            this.dtpPromotionStart.TabIndex = 63;
            // 
            // dtpPromotionEnd
            // 
            this.dtpPromotionEnd.Location = new System.Drawing.Point(200, 377);
            this.dtpPromotionEnd.Name = "dtpPromotionEnd";
            this.dtpPromotionEnd.Size = new System.Drawing.Size(183, 20);
            this.dtpPromotionEnd.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 16);
            this.label6.TabIndex = 65;
            this.label6.Text = "Promotion Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Promotion End Date";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 54);
            this.label8.TabIndex = 67;
            this.label8.Text = "Current Service Packages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "Promotion Percentage";
            // 
            // numUDPercentage
            // 
            this.numUDPercentage.Location = new System.Drawing.Point(200, 417);
            this.numUDPercentage.Name = "numUDPercentage";
            this.numUDPercentage.Size = new System.Drawing.Size(47, 20);
            this.numUDPercentage.TabIndex = 69;
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnCreatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePackage.Location = new System.Drawing.Point(684, 491);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(228, 31);
            this.btnCreatePackage.TabIndex = 78;
            this.btnCreatePackage.Text = "Create Package";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 30);
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
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(448, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 16);
            this.label12.TabIndex = 82;
            this.label12.Text = "Services Available";
            // 
            // btnAddService
            // 
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.Location = new System.Drawing.Point(657, 272);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(61, 42);
            this.btnAddService.TabIndex = 84;
            this.btnAddService.Text = ">>";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnDeletePackage
            // 
            this.btnDeletePackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnDeletePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePackage.Location = new System.Drawing.Point(39, 491);
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Size = new System.Drawing.Size(228, 31);
            this.btnDeletePackage.TabIndex = 85;
            this.btnDeletePackage.Text = "Delete Package";
            this.btnDeletePackage.UseVisualStyleBackColor = false;
            this.btnDeletePackage.Click += new System.EventHandler(this.btnDeletePackage_Click);
            // 
            // btnUpdatePackage
            // 
            this.btnUpdatePackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnUpdatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePackage.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePackage.Location = new System.Drawing.Point(365, 491);
            this.btnUpdatePackage.Name = "btnUpdatePackage";
            this.btnUpdatePackage.Size = new System.Drawing.Size(228, 31);
            this.btnUpdatePackage.TabIndex = 86;
            this.btnUpdatePackage.Text = "Update Package";
            this.btnUpdatePackage.UseVisualStyleBackColor = false;
            this.btnUpdatePackage.Click += new System.EventHandler(this.btnUpdatePackage_Click);
            // 
            // lbxAvailable
            // 
            this.lbxAvailable.FormattingEnabled = true;
            this.lbxAvailable.Location = new System.Drawing.Point(455, 241);
            this.lbxAvailable.Name = "lbxAvailable";
            this.lbxAvailable.Size = new System.Drawing.Size(121, 212);
            this.lbxAvailable.TabIndex = 87;
            // 
            // lbxAdded
            // 
            this.lbxAdded.FormattingEnabled = true;
            this.lbxAdded.Location = new System.Drawing.Point(802, 241);
            this.lbxAdded.Name = "lbxAdded";
            this.lbxAdded.Size = new System.Drawing.Size(121, 212);
            this.lbxAdded.TabIndex = 88;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(799, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 90;
            this.label14.Text = "Added";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(657, 391);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(61, 42);
            this.btnRemove.TabIndex = 84;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(152, 272);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(115, 20);
            this.txtPrice.TabIndex = 91;
            // 
            // frmServicePackageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1136, 591);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbxAdded);
            this.Controls.Add(this.lbxAvailable);
            this.Controls.Add(this.btnUpdatePackage);
            this.Controls.Add(this.btnDeletePackage);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreatePackage);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPackageName);
            this.Controls.Add(this.dgvCurrentServicePackages);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "frmServicePackageManagement";
            this.Text = "Create A New Service Package";
            this.Load += new System.EventHandler(this.frmServicePackageManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentServicePackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCurrentServicePackages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnDeletePackage;
        private System.Windows.Forms.Button btnUpdatePackage;
        private System.Windows.Forms.ListBox lbxAvailable;
        private System.Windows.Forms.ListBox lbxAdded;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtPrice;
    }
}