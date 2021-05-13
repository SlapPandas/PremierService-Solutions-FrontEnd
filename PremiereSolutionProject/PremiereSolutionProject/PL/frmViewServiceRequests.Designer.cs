﻿
namespace PremiereSolutionProject.PL
{
    partial class frmViewServiceRequests
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
            this.dgvViewAllServiceReq = new System.Windows.Forms.DataGridView();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServiceRequestID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCallId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPriorityLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbClosed = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAllServiceReq)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service Requests";
            // 
            // dgvViewAllServiceReq
            // 
            this.dgvViewAllServiceReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewAllServiceReq.Location = new System.Drawing.Point(215, 67);
            this.dgvViewAllServiceReq.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViewAllServiceReq.Name = "dgvViewAllServiceReq";
            this.dgvViewAllServiceReq.RowHeadersWidth = 62;
            this.dgvViewAllServiceReq.RowTemplate.Height = 28;
            this.dgvViewAllServiceReq.Size = new System.Drawing.Size(587, 177);
            this.dgvViewAllServiceReq.TabIndex = 2;
            this.dgvViewAllServiceReq.Click += new System.EventHandler(this.dgvViewAllServiceReq_Click);
            // 
            // btnForward
            // 
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Location = new System.Drawing.Point(583, 260);
            this.btnForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(91, 33);
            this.btnForward.TabIndex = 12;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackward.Location = new System.Drawing.Point(342, 260);
            this.btnBackward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(91, 33);
            this.btnBackward.TabIndex = 13;
            this.btnBackward.Text = "<";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Location = new System.Drawing.Point(711, 260);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(91, 33);
            this.btnEnd.TabIndex = 14;
            this.btnEnd.Text = ">>";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(215, 260);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 33);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "<<";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 30);
            this.btnExit.TabIndex = 111;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(821, 480);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(202, 34);
            this.btnDelete.TabIndex = 113;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 321);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "Service Request Id";
            // 
            // txtServiceRequestID
            // 
            this.txtServiceRequestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceRequestID.Location = new System.Drawing.Point(215, 341);
            this.txtServiceRequestID.Margin = new System.Windows.Forms.Padding(4);
            this.txtServiceRequestID.Name = "txtServiceRequestID";
            this.txtServiceRequestID.ReadOnly = true;
            this.txtServiceRequestID.Size = new System.Drawing.Size(201, 21);
            this.txtServiceRequestID.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(818, 333);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 117;
            this.label2.Text = "Closed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 397);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 119;
            this.label4.Text = "Call Id";
            // 
            // txtCallId
            // 
            this.txtCallId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCallId.Location = new System.Drawing.Point(215, 417);
            this.txtCallId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCallId.Name = "txtCallId";
            this.txtCallId.ReadOnly = true;
            this.txtCallId.Size = new System.Drawing.Size(201, 21);
            this.txtCallId.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(818, 397);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 121;
            this.label5.Text = "Priority Level";
            // 
            // txtPriorityLevel
            // 
            this.txtPriorityLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriorityLevel.Location = new System.Drawing.Point(821, 417);
            this.txtPriorityLevel.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriorityLevel.Name = "txtPriorityLevel";
            this.txtPriorityLevel.ReadOnly = true;
            this.txtPriorityLevel.Size = new System.Drawing.Size(201, 21);
            this.txtPriorityLevel.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(506, 321);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 123;
            this.label6.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(509, 343);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(201, 95);
            this.txtDescription.TabIndex = 124;
            this.txtDescription.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(55)))), ((int)(((byte)(84)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(215, 479);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(201, 35);
            this.btnUpdate.TabIndex = 112;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbClosed
            // 
            this.cmbClosed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClosed.FormattingEnabled = true;
            this.cmbClosed.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cmbClosed.Location = new System.Drawing.Point(821, 352);
            this.cmbClosed.Name = "cmbClosed";
            this.cmbClosed.Size = new System.Drawing.Size(202, 21);
            this.cmbClosed.TabIndex = 125;
            // 
            // frmViewServiceRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1136, 591);
            this.Controls.Add(this.cmbClosed);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPriorityLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCallId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceRequestID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.dgvViewAllServiceReq);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmViewServiceRequests";
            this.Text = "View Service Requests";
            this.Load += new System.EventHandler(this.frmViewServiceRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAllServiceReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvViewAllServiceReq;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServiceRequestID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCallId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriorityLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbClosed;
    }
}