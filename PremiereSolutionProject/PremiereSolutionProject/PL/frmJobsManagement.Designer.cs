
namespace PremiereSolutionProject.PL
{
    partial class frmJobsManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobsManagement));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxCurrentState = new System.Windows.Forms.ComboBox();
            this.btnUpdateJob = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudEmployees = new System.Windows.Forms.NumericUpDown();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTechnician = new System.Windows.Forms.Button();
            this.btnRemoveTechnician = new System.Windows.Forms.Button();
            this.lstPending = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstJobs = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbxAvailTech = new System.Windows.Forms.ListBox();
            this.cbxSpecialisation = new System.Windows.Forms.ComboBox();
            this.lbxCurrentAssignedTech = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jobs Management";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(38, 396);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "Current Job State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(824, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Current Assigned Technicians";
            // 
            // cbxCurrentState
            // 
            this.cbxCurrentState.FormattingEnabled = true;
            this.cbxCurrentState.Items.AddRange(new object[] {
            "Pending",
            "In Progress",
            "Finished"});
            this.cbxCurrentState.Location = new System.Drawing.Point(213, 393);
            this.cbxCurrentState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCurrentState.Name = "cbxCurrentState";
            this.cbxCurrentState.Size = new System.Drawing.Size(232, 24);
            this.cbxCurrentState.TabIndex = 63;
            // 
            // btnUpdateJob
            // 
            this.btnUpdateJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateJob.Location = new System.Drawing.Point(293, 704);
            this.btnUpdateJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateJob.Name = "btnUpdateJob";
            this.btnUpdateJob.Size = new System.Drawing.Size(152, 28);
            this.btnUpdateJob.TabIndex = 109;
            this.btnUpdateJob.Text = "Update Job";
            this.btnUpdateJob.UseVisualStyleBackColor = true;
            this.btnUpdateJob.Click += new System.EventHandler(this.btnUpdateJob_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(963, 716);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 28);
            this.btnExit.TabIndex = 110;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(40, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "Jobs Trackings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(36, 533);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 17);
            this.label7.TabIndex = 115;
            this.label7.Text = "Specialisation Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(36, 589);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 117;
            this.label8.Text = "No. of employees";
            // 
            // nudEmployees
            // 
            this.nudEmployees.Location = new System.Drawing.Point(213, 587);
            this.nudEmployees.Name = "nudEmployees";
            this.nudEmployees.Size = new System.Drawing.Size(70, 22);
            this.nudEmployees.TabIndex = 118;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(213, 441);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(232, 66);
            this.rtbNotes.TabIndex = 120;
            this.rtbNotes.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(36, 441);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 119;
            this.label9.Text = "Notes";
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteJob.Location = new System.Drawing.Point(477, 704);
            this.btnDeleteJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(152, 28);
            this.btnDeleteJob.TabIndex = 123;
            this.btnDeleteJob.Text = "Delete Job";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(520, 400);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 126;
            this.label2.Text = "Available Technicians";
            // 
            // btnAddTechnician
            // 
            this.btnAddTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTechnician.Location = new System.Drawing.Point(733, 487);
            this.btnAddTechnician.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTechnician.Name = "btnAddTechnician";
            this.btnAddTechnician.Size = new System.Drawing.Size(48, 27);
            this.btnAddTechnician.TabIndex = 129;
            this.btnAddTechnician.Text = ">>";
            this.btnAddTechnician.UseVisualStyleBackColor = true;
            this.btnAddTechnician.Click += new System.EventHandler(this.btnAddTechnician_Click);
            // 
            // btnRemoveTechnician
            // 
            this.btnRemoveTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTechnician.Location = new System.Drawing.Point(733, 555);
            this.btnRemoveTechnician.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveTechnician.Name = "btnRemoveTechnician";
            this.btnRemoveTechnician.Size = new System.Drawing.Size(48, 27);
            this.btnRemoveTechnician.TabIndex = 130;
            this.btnRemoveTechnician.Text = "<<";
            this.btnRemoveTechnician.UseVisualStyleBackColor = true;
            this.btnRemoveTechnician.Click += new System.EventHandler(this.btnRemoveTechnician_Click);
            // 
            // lstPending
            // 
            this.lstPending.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstPending.HideSelection = false;
            this.lstPending.Location = new System.Drawing.Point(41, 262);
            this.lstPending.Name = "lstPending";
            this.lstPending.Size = new System.Drawing.Size(968, 97);
            this.lstPending.TabIndex = 131;
            this.lstPending.UseCompatibleStateImageBehavior = false;
            this.lstPending.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            this.columnHeader2.Width = 100;
            // 
            // lstJobs
            // 
            this.lstJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lstJobs.HideSelection = false;
            this.lstJobs.Location = new System.Drawing.Point(43, 65);
            this.lstJobs.Name = "lstJobs";
            this.lstJobs.Size = new System.Drawing.Size(966, 150);
            this.lstJobs.TabIndex = 134;
            this.lstJobs.UseCompatibleStateImageBehavior = false;
            this.lstJobs.View = System.Windows.Forms.View.Details;
            this.lstJobs.SelectedIndexChanged += new System.EventHandler(this.lstJobs_SelectedIndexChanged);
            this.lstJobs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstJobs_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "State";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Notes";
            this.columnHeader8.Width = 160;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Service Request ID";
            this.columnHeader10.Width = 90;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "No Employees";
            this.columnHeader11.Width = 145;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Priority level";
            this.columnHeader12.Width = 90;
            // 
            // lbxAvailTech
            // 
            this.lbxAvailTech.FormattingEnabled = true;
            this.lbxAvailTech.ItemHeight = 16;
            this.lbxAvailTech.Location = new System.Drawing.Point(505, 426);
            this.lbxAvailTech.Name = "lbxAvailTech";
            this.lbxAvailTech.Size = new System.Drawing.Size(189, 180);
            this.lbxAvailTech.TabIndex = 141;
            // 
            // cbxSpecialisation
            // 
            this.cbxSpecialisation.FormattingEnabled = true;
            this.cbxSpecialisation.Location = new System.Drawing.Point(213, 533);
            this.cbxSpecialisation.Name = "cbxSpecialisation";
            this.cbxSpecialisation.Size = new System.Drawing.Size(232, 24);
            this.cbxSpecialisation.TabIndex = 142;
            // 
            // lbxCurrentAssignedTech
            // 
            this.lbxCurrentAssignedTech.FormattingEnabled = true;
            this.lbxCurrentAssignedTech.ItemHeight = 16;
            this.lbxCurrentAssignedTech.Location = new System.Drawing.Point(832, 426);
            this.lbxCurrentAssignedTech.Name = "lbxCurrentAssignedTech";
            this.lbxCurrentAssignedTech.Size = new System.Drawing.Size(189, 180);
            this.lbxCurrentAssignedTech.TabIndex = 143;
            // 
            // frmJobsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1067, 757);
            this.Controls.Add(this.lbxCurrentAssignedTech);
            this.Controls.Add(this.cbxSpecialisation);
            this.Controls.Add(this.lbxAvailTech);
            this.Controls.Add(this.lstJobs);
            this.Controls.Add(this.lstPending);
            this.Controls.Add(this.btnRemoveTechnician);
            this.Controls.Add(this.btnAddTechnician);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudEmployees);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateJob);
            this.Controls.Add(this.cbxCurrentState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmJobsManagement";
            this.Text = "Job Management";
            this.Load += new System.EventHandler(this.frmJobsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxCurrentState;
        private System.Windows.Forms.Button btnUpdateJob;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudEmployees;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeleteJob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTechnician;
        private System.Windows.Forms.Button btnRemoveTechnician;
        private System.Windows.Forms.ListView lstPending;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lstJobs;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListBox lbxAvailTech;
        private System.Windows.Forms.ComboBox cbxSpecialisation;
        private System.Windows.Forms.ListBox lbxCurrentAssignedTech;
    }
}