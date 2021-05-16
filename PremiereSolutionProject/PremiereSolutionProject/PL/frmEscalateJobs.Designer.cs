
namespace PremiereSolutionProject.PL
{
    partial class frmEscalateJobs
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
            this.dgvServiceRequests = new System.Windows.Forms.DataGridView();
            this.lblPriorityLevel = new System.Windows.Forms.Label();
            this.btnEscalateServiceRequest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServiceRequestID = new System.Windows.Forms.Label();
            this.lblCallID = new System.Windows.Forms.Label();
            this.lblClosed = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNrOfDays = new System.Windows.Forms.Label();
            this.txtServiceRequestID = new System.Windows.Forms.TextBox();
            this.txtCallID = new System.Windows.Forms.TextBox();
            this.txtClosed = new System.Windows.Forms.TextBox();
            this.txtCurrentPrio = new System.Windows.Forms.TextBox();
            this.txtCurrentDays = new System.Windows.Forms.TextBox();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.lblNewDays = new System.Windows.Forms.Label();
            this.lblNewPrio = new System.Windows.Forms.Label();
            this.txtNewPrio = new System.Windows.Forms.TextBox();
            this.numNewDays = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewDays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(418, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escalate Service Requests";
            // 
            // dgvServiceRequests
            // 
            this.dgvServiceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceRequests.Location = new System.Drawing.Point(157, 98);
            this.dgvServiceRequests.Margin = new System.Windows.Forms.Padding(2);
            this.dgvServiceRequests.Name = "dgvServiceRequests";
            this.dgvServiceRequests.ReadOnly = true;
            this.dgvServiceRequests.RowHeadersWidth = 51;
            this.dgvServiceRequests.RowTemplate.Height = 24;
            this.dgvServiceRequests.Size = new System.Drawing.Size(847, 134);
            this.dgvServiceRequests.TabIndex = 2;
            this.dgvServiceRequests.SelectionChanged += new System.EventHandler(this.dgvServiceRequests_SelectionChanged);
            // 
            // lblPriorityLevel
            // 
            this.lblPriorityLevel.AutoSize = true;
            this.lblPriorityLevel.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityLevel.Location = new System.Drawing.Point(154, 365);
            this.lblPriorityLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPriorityLevel.Name = "lblPriorityLevel";
            this.lblPriorityLevel.Size = new System.Drawing.Size(152, 16);
            this.lblPriorityLevel.TabIndex = 3;
            this.lblPriorityLevel.Text = "Current Priority Level";
            // 
            // btnEscalateServiceRequest
            // 
            this.btnEscalateServiceRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnEscalateServiceRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscalateServiceRequest.Font = new System.Drawing.Font("Microsoft Yi Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscalateServiceRequest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEscalateServiceRequest.Location = new System.Drawing.Point(660, 430);
            this.btnEscalateServiceRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEscalateServiceRequest.Name = "btnEscalateServiceRequest";
            this.btnEscalateServiceRequest.Size = new System.Drawing.Size(347, 85);
            this.btnEscalateServiceRequest.TabIndex = 110;
            this.btnEscalateServiceRequest.Text = "Escalate Service Request";
            this.btnEscalateServiceRequest.UseVisualStyleBackColor = false;
            this.btnEscalateServiceRequest.Click += new System.EventHandler(this.btnEscalateServiceRequest_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(12, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 44);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 16);
            this.label2.TabIndex = 112;
            this.label2.Text = "Current Service Requests";
            // 
            // lblServiceRequestID
            // 
            this.lblServiceRequestID.AutoSize = true;
            this.lblServiceRequestID.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceRequestID.Location = new System.Drawing.Point(154, 260);
            this.lblServiceRequestID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServiceRequestID.Name = "lblServiceRequestID";
            this.lblServiceRequestID.Size = new System.Drawing.Size(138, 16);
            this.lblServiceRequestID.TabIndex = 113;
            this.lblServiceRequestID.Text = "Service Request ID";
            // 
            // lblCallID
            // 
            this.lblCallID.AutoSize = true;
            this.lblCallID.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallID.Location = new System.Drawing.Point(154, 295);
            this.lblCallID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCallID.Name = "lblCallID";
            this.lblCallID.Size = new System.Drawing.Size(56, 16);
            this.lblCallID.TabIndex = 114;
            this.lblCallID.Text = "Call ID";
            // 
            // lblClosed
            // 
            this.lblClosed.AutoSize = true;
            this.lblClosed.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosed.Location = new System.Drawing.Point(157, 330);
            this.lblClosed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(53, 16);
            this.lblClosed.TabIndex = 115;
            this.lblClosed.Text = "Closed";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(157, 430);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(81, 16);
            this.lblDescription.TabIndex = 116;
            this.lblDescription.Text = "Description";
            // 
            // lblNrOfDays
            // 
            this.lblNrOfDays.AutoSize = true;
            this.lblNrOfDays.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNrOfDays.Location = new System.Drawing.Point(157, 398);
            this.lblNrOfDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNrOfDays.Name = "lblNrOfDays";
            this.lblNrOfDays.Size = new System.Drawing.Size(96, 16);
            this.lblNrOfDays.TabIndex = 117;
            this.lblNrOfDays.Text = "Current Days";
            // 
            // txtServiceRequestID
            // 
            this.txtServiceRequestID.Location = new System.Drawing.Point(321, 256);
            this.txtServiceRequestID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServiceRequestID.Name = "txtServiceRequestID";
            this.txtServiceRequestID.ReadOnly = true;
            this.txtServiceRequestID.Size = new System.Drawing.Size(181, 20);
            this.txtServiceRequestID.TabIndex = 118;
            // 
            // txtCallID
            // 
            this.txtCallID.Location = new System.Drawing.Point(321, 291);
            this.txtCallID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCallID.Name = "txtCallID";
            this.txtCallID.ReadOnly = true;
            this.txtCallID.Size = new System.Drawing.Size(181, 20);
            this.txtCallID.TabIndex = 119;
            // 
            // txtClosed
            // 
            this.txtClosed.Location = new System.Drawing.Point(321, 326);
            this.txtClosed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClosed.Name = "txtClosed";
            this.txtClosed.ReadOnly = true;
            this.txtClosed.Size = new System.Drawing.Size(181, 20);
            this.txtClosed.TabIndex = 120;
            // 
            // txtCurrentPrio
            // 
            this.txtCurrentPrio.Location = new System.Drawing.Point(321, 360);
            this.txtCurrentPrio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCurrentPrio.Name = "txtCurrentPrio";
            this.txtCurrentPrio.ReadOnly = true;
            this.txtCurrentPrio.Size = new System.Drawing.Size(181, 20);
            this.txtCurrentPrio.TabIndex = 122;
            // 
            // txtCurrentDays
            // 
            this.txtCurrentDays.Location = new System.Drawing.Point(321, 394);
            this.txtCurrentDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCurrentDays.Name = "txtCurrentDays";
            this.txtCurrentDays.ReadOnly = true;
            this.txtCurrentDays.Size = new System.Drawing.Size(181, 20);
            this.txtCurrentDays.TabIndex = 123;
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(321, 430);
            this.rtxtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.ReadOnly = true;
            this.rtxtDescription.Size = new System.Drawing.Size(181, 88);
            this.rtxtDescription.TabIndex = 124;
            this.rtxtDescription.Text = "";
            // 
            // lblNewDays
            // 
            this.lblNewDays.AutoSize = true;
            this.lblNewDays.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewDays.Location = new System.Drawing.Point(658, 357);
            this.lblNewDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewDays.Name = "lblNewDays";
            this.lblNewDays.Size = new System.Drawing.Size(76, 16);
            this.lblNewDays.TabIndex = 126;
            this.lblNewDays.Text = "New Days";
            // 
            // lblNewPrio
            // 
            this.lblNewPrio.AutoSize = true;
            this.lblNewPrio.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPrio.Location = new System.Drawing.Point(655, 324);
            this.lblNewPrio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPrio.Name = "lblNewPrio";
            this.lblNewPrio.Size = new System.Drawing.Size(132, 16);
            this.lblNewPrio.TabIndex = 125;
            this.lblNewPrio.Text = "New Priority Level";
            // 
            // txtNewPrio
            // 
            this.txtNewPrio.Location = new System.Drawing.Point(824, 320);
            this.txtNewPrio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPrio.Name = "txtNewPrio";
            this.txtNewPrio.Size = new System.Drawing.Size(181, 20);
            this.txtNewPrio.TabIndex = 127;
            // 
            // numNewDays
            // 
            this.numNewDays.Location = new System.Drawing.Point(824, 362);
            this.numNewDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numNewDays.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numNewDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNewDays.Name = "numNewDays";
            this.numNewDays.Size = new System.Drawing.Size(120, 20);
            this.numNewDays.TabIndex = 128;
            this.numNewDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmEscalateJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1123, 590);
            this.Controls.Add(this.numNewDays);
            this.Controls.Add(this.txtNewPrio);
            this.Controls.Add(this.lblNewDays);
            this.Controls.Add(this.lblNewPrio);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.txtCurrentDays);
            this.Controls.Add(this.txtCurrentPrio);
            this.Controls.Add(this.txtClosed);
            this.Controls.Add(this.txtCallID);
            this.Controls.Add(this.txtServiceRequestID);
            this.Controls.Add(this.lblNrOfDays);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblClosed);
            this.Controls.Add(this.lblCallID);
            this.Controls.Add(this.lblServiceRequestID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEscalateServiceRequest);
            this.Controls.Add(this.lblPriorityLevel);
            this.Controls.Add(this.dgvServiceRequests);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1156, 637);
            this.Name = "frmEscalateJobs";
            this.Text = "frmEscalateJobs";
            this.Load += new System.EventHandler(this.frmEscalateJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvServiceRequests;
        private System.Windows.Forms.Label lblPriorityLevel;
        private System.Windows.Forms.Button btnEscalateServiceRequest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServiceRequestID;
        private System.Windows.Forms.Label lblCallID;
        private System.Windows.Forms.Label lblClosed;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNrOfDays;
        private System.Windows.Forms.TextBox txtServiceRequestID;
        private System.Windows.Forms.TextBox txtCallID;
        private System.Windows.Forms.TextBox txtClosed;
        private System.Windows.Forms.TextBox txtCurrentPrio;
        private System.Windows.Forms.TextBox txtCurrentDays;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Label lblNewDays;
        private System.Windows.Forms.Label lblNewPrio;
        private System.Windows.Forms.TextBox txtNewPrio;
        private System.Windows.Forms.NumericUpDown numNewDays;
    }
}