
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxCurrentState = new System.Windows.Forms.ComboBox();
            this.btnUpdateJob = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.cbxSpecialisationName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudEmployees = new System.Windows.Forms.NumericUpDown();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.lbxCurrentAssigned = new System.Windows.Forms.ListBox();
            this.lbxAvailable = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxNewAssigned = new System.Windows.Forms.ListBox();
            this.btnAddTechnician = new System.Windows.Forms.Button();
            this.btnRemoveTechnician = new System.Windows.Forms.Button();
            this.lstPending = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstInProgress = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jobs Management";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(40, 420);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "Current State";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(474, 417);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Current Assigned Technicians";
            // 
            // cbxCurrentState
            // 
            this.cbxCurrentState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxCurrentState.FormattingEnabled = true;
            this.cbxCurrentState.Items.AddRange(new object[] {
            "Pending",
            "In Progress",
            "Completed"});
            this.cbxCurrentState.Location = new System.Drawing.Point(215, 417);
            this.cbxCurrentState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCurrentState.Name = "cbxCurrentState";
            this.cbxCurrentState.Size = new System.Drawing.Size(204, 24);
            this.cbxCurrentState.TabIndex = 63;
            // 
            // btnUpdateJob
            // 
            this.btnUpdateJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateJob.Location = new System.Drawing.Point(422, 704);
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
            this.btnExit.Location = new System.Drawing.Point(913, 704);
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
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(40, 232);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "Jobs Trackings";
            // 
            // dgvJobs
            // 
            this.dgvJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(41, 65);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.RowHeadersWidth = 51;
            this.dgvJobs.RowTemplate.Height = 24;
            this.dgvJobs.Size = new System.Drawing.Size(905, 150);
            this.dgvJobs.TabIndex = 114;
            this.dgvJobs.SelectionChanged += new System.EventHandler(this.dgvJobs_SelectionChanged);
            // 
            // cbxSpecialisationName
            // 
            this.cbxSpecialisationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxSpecialisationName.FormattingEnabled = true;
            this.cbxSpecialisationName.Items.AddRange(new object[] {
            "Pending",
            "In Progress",
            "Completed"});
            this.cbxSpecialisationName.Location = new System.Drawing.Point(215, 557);
            this.cbxSpecialisationName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxSpecialisationName.Name = "cbxSpecialisationName";
            this.cbxSpecialisationName.Size = new System.Drawing.Size(204, 24);
            this.cbxSpecialisationName.TabIndex = 116;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(38, 557);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 17);
            this.label7.TabIndex = 115;
            this.label7.Text = "Specialisation Name";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(38, 618);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 117;
            this.label8.Text = "No. of employees";
            // 
            // nudEmployees
            // 
            this.nudEmployees.Location = new System.Drawing.Point(215, 616);
            this.nudEmployees.Name = "nudEmployees";
            this.nudEmployees.Size = new System.Drawing.Size(70, 22);
            this.nudEmployees.TabIndex = 118;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(215, 465);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(204, 66);
            this.rtbNotes.TabIndex = 120;
            this.rtbNotes.Text = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(38, 465);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 119;
            this.label9.Text = "Notes";
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteJob.Location = new System.Drawing.Point(236, 704);
            this.btnDeleteJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(152, 28);
            this.btnDeleteJob.TabIndex = 123;
            this.btnDeleteJob.Text = "Delete Job";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // lbxCurrentAssigned
            // 
            this.lbxCurrentAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxCurrentAssigned.FormattingEnabled = true;
            this.lbxCurrentAssigned.ItemHeight = 16;
            this.lbxCurrentAssigned.Location = new System.Drawing.Point(685, 414);
            this.lbxCurrentAssigned.Name = "lbxCurrentAssigned";
            this.lbxCurrentAssigned.Size = new System.Drawing.Size(261, 68);
            this.lbxCurrentAssigned.TabIndex = 124;
            // 
            // lbxAvailable
            // 
            this.lbxAvailable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbxAvailable.FormattingEnabled = true;
            this.lbxAvailable.ItemHeight = 16;
            this.lbxAvailable.Location = new System.Drawing.Point(476, 535);
            this.lbxAvailable.Name = "lbxAvailable";
            this.lbxAvailable.Size = new System.Drawing.Size(168, 100);
            this.lbxAvailable.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(474, 505);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 126;
            this.label2.Text = "Available Technicians";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(748, 505);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 128;
            this.label3.Text = "New Assigned Technicians";
            // 
            // lbxNewAssigned
            // 
            this.lbxNewAssigned.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbxNewAssigned.FormattingEnabled = true;
            this.lbxNewAssigned.ItemHeight = 16;
            this.lbxNewAssigned.Location = new System.Drawing.Point(751, 538);
            this.lbxNewAssigned.Name = "lbxNewAssigned";
            this.lbxNewAssigned.Size = new System.Drawing.Size(195, 100);
            this.lbxNewAssigned.TabIndex = 127;
            // 
            // btnAddTechnician
            // 
            this.btnAddTechnician.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTechnician.Location = new System.Drawing.Point(671, 547);
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
            this.btnRemoveTechnician.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTechnician.Location = new System.Drawing.Point(671, 598);
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
            this.lstPending.Location = new System.Drawing.Point(53, 273);
            this.lstPending.Name = "lstPending";
            this.lstPending.Size = new System.Drawing.Size(194, 97);
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
            // 
            // lstInProgress
            // 
            this.lstInProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lstInProgress.HideSelection = false;
            this.lstInProgress.Location = new System.Drawing.Point(330, 273);
            this.lstInProgress.Name = "lstInProgress";
            this.lstInProgress.Size = new System.Drawing.Size(194, 97);
            this.lstInProgress.TabIndex = 132;
            this.lstInProgress.UseCompatibleStateImageBehavior = false;
            this.lstInProgress.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State";
            // 
            // frmJobsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1017, 745);
            this.Controls.Add(this.lstInProgress);
            this.Controls.Add(this.lstPending);
            this.Controls.Add(this.btnRemoveTechnician);
            this.Controls.Add(this.btnAddTechnician);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxNewAssigned);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxAvailable);
            this.Controls.Add(this.lbxCurrentAssigned);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudEmployees);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxSpecialisationName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateJob);
            this.Controls.Add(this.cbxCurrentState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmJobsManagement";
            this.Text = "frmJobManagement";
            this.Load += new System.EventHandler(this.frmJobsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.ComboBox cbxSpecialisationName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudEmployees;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeleteJob;
        private System.Windows.Forms.ListBox lbxCurrentAssigned;
        private System.Windows.Forms.ListBox lbxAvailable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxNewAssigned;
        private System.Windows.Forms.Button btnAddTechnician;
        private System.Windows.Forms.Button btnRemoveTechnician;
        private System.Windows.Forms.ListView lstPending;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lstInProgress;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}