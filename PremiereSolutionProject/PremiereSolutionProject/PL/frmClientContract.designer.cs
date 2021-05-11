
namespace PremiereSolutionProject.PL
{
    partial class frmClientContract
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbxPriorityLevel = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxContractName = new System.Windows.Forms.ComboBox();
            this.dgvServicePackages = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudNoOfDays = new System.Windows.Forms.NumericUpDown();
            this.btnExiting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicePackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfDays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Contract";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contract name";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Priority level";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 372);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start date";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 449);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "End date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 317);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Services";
            // 
            // dgvServices
            // 
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(322, 338);
            this.dgvServices.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RowHeadersWidth = 62;
            this.dgvServices.Size = new System.Drawing.Size(424, 159);
            this.dgvServices.TabIndex = 12;
            // 
            // btnCreate
            // 
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(55, 537);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 34);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbxPriorityLevel
            // 
            this.cbxPriorityLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxPriorityLevel.FormattingEnabled = true;
            this.cbxPriorityLevel.Location = new System.Drawing.Point(32, 259);
            this.cbxPriorityLevel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxPriorityLevel.Name = "cbxPriorityLevel";
            this.cbxPriorityLevel.Size = new System.Drawing.Size(225, 24);
            this.cbxPriorityLevel.TabIndex = 14;
            this.cbxPriorityLevel.SelectedIndexChanged += new System.EventHandler(this.cbxPriorityLevel_SelectedIndexChanged);
            this.cbxPriorityLevel.SelectedValueChanged += new System.EventHandler(this.cbxPriorityLevel_SelectedValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpStartDate.Location = new System.Drawing.Point(30, 397);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 23);
            this.dtpStartDate.TabIndex = 15;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpEndDate.Location = new System.Drawing.Point(30, 474);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 23);
            this.dtpEndDate.TabIndex = 16;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(855, 719);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 34);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxContractName
            // 
            this.cbxContractName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxContractName.FormattingEnabled = true;
            this.cbxContractName.Location = new System.Drawing.Point(30, 195);
            this.cbxContractName.Name = "cbxContractName";
            this.cbxContractName.Size = new System.Drawing.Size(225, 24);
            this.cbxContractName.TabIndex = 18;
            this.cbxContractName.SelectedIndexChanged += new System.EventHandler(this.cbxContractName_SelectedIndexChanged);
            // 
            // dgvServicePackages
            // 
            this.dgvServicePackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicePackages.Location = new System.Drawing.Point(321, 137);
            this.dgvServicePackages.Name = "dgvServicePackages";
            this.dgvServicePackages.RowHeadersWidth = 51;
            this.dgvServicePackages.Size = new System.Drawing.Size(424, 156);
            this.dgvServicePackages.TabIndex = 19;
            this.dgvServicePackages.SelectionChanged += new System.EventHandler(this.dgvServicePackages_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Service packages";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(30, 126);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(100, 23);
            this.txtClientID.TabIndex = 22;
            this.txtClientID.TextChanged += new System.EventHandler(this.txtClientID_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Client ID";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 300);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "No. Of Days:";
            // 
            // nudNoOfDays
            // 
            this.nudNoOfDays.Location = new System.Drawing.Point(32, 333);
            this.nudNoOfDays.Name = "nudNoOfDays";
            this.nudNoOfDays.Size = new System.Drawing.Size(120, 23);
            this.nudNoOfDays.TabIndex = 24;
            this.nudNoOfDays.ValueChanged += new System.EventHandler(this.nudNoOfDays_ValueChanged);
            // 
            // btnExiting
            // 
            this.btnExiting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExiting.Location = new System.Drawing.Point(702, 598);
            this.btnExiting.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnExiting.Name = "btnExiting";
            this.btnExiting.Size = new System.Drawing.Size(102, 34);
            this.btnExiting.TabIndex = 115;
            this.btnExiting.Text = "Exit";
            this.btnExiting.UseVisualStyleBackColor = true;
            this.btnExiting.Click += new System.EventHandler(this.btnExiting_Click);
            // 
            // frmClientContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(817, 645);
            this.Controls.Add(this.btnExiting);
            this.Controls.Add(this.nudNoOfDays);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvServicePackages);
            this.Controls.Add(this.cbxContractName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbxPriorityLevel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmClientContract";
            this.Load += new System.EventHandler(this.frmClientContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicePackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbxPriorityLevel;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxContractName;
        private System.Windows.Forms.DataGridView dgvServicePackages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudNoOfDays;
        private System.Windows.Forms.Button btnExiting;
    }
}