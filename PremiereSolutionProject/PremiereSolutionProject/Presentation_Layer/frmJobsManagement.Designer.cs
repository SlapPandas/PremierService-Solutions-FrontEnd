
namespace PremiereSolutionProject.Presentation_Layer
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceReqID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssignedTechnician = new System.Windows.Forms.TextBox();
            this.cbxJobStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateJob = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jobs Management";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(59, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(937, 245);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Service Request ID";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Job ID";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Assigned Technician";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Job Status";
            this.columnHeader4.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(57, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Service Request ID";
            // 
            // txtServiceReqID
            // 
            this.txtServiceReqID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceReqID.Location = new System.Drawing.Point(256, 380);
            this.txtServiceReqID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtServiceReqID.Name = "txtServiceReqID";
            this.txtServiceReqID.Size = new System.Drawing.Size(229, 26);
            this.txtServiceReqID.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(57, 446);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Job ID";
            // 
            // txtJobID
            // 
            this.txtJobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobID.Location = new System.Drawing.Point(256, 440);
            this.txtJobID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(229, 26);
            this.txtJobID.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(535, 446);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Job Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(535, 386);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = "Assigned Technician";
            // 
            // txtAssignedTechnician
            // 
            this.txtAssignedTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedTechnician.Location = new System.Drawing.Point(734, 380);
            this.txtAssignedTechnician.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAssignedTechnician.Name = "txtAssignedTechnician";
            this.txtAssignedTechnician.Size = new System.Drawing.Size(229, 26);
            this.txtAssignedTechnician.TabIndex = 59;
            // 
            // cbxJobStatus
            // 
            this.cbxJobStatus.FormattingEnabled = true;
            this.cbxJobStatus.Items.AddRange(new object[] {
            "Pending",
            "In Progress",
            "Completed"});
            this.cbxJobStatus.Location = new System.Drawing.Point(734, 446);
            this.cbxJobStatus.Name = "cbxJobStatus";
            this.cbxJobStatus.Size = new System.Drawing.Size(229, 28);
            this.cbxJobStatus.TabIndex = 63;
            // 
            // btnUpdateJob
            // 
            this.btnUpdateJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateJob.Location = new System.Drawing.Point(417, 518);
            this.btnUpdateJob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateJob.Name = "btnUpdateJob";
            this.btnUpdateJob.Size = new System.Drawing.Size(204, 46);
            this.btnUpdateJob.TabIndex = 109;
            this.btnUpdateJob.Text = "Update Job";
            this.btnUpdateJob.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(964, 616);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 35);
            this.btnExit.TabIndex = 110;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmJobsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1101, 665);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateJob);
            this.Controls.Add(this.cbxJobStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAssignedTechnician);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtJobID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServiceReqID);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmJobsManagement";
            this.Text = "frmJobManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceReqID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssignedTechnician;
        private System.Windows.Forms.ComboBox cbxJobStatus;
        private System.Windows.Forms.Button btnUpdateJob;
        private System.Windows.Forms.Button btnExit;
    }
}