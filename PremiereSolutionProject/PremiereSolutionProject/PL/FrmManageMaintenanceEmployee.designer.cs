namespace PremiereSolutionProject.PL
{
    partial class FrmManageMaintenanceEmployee
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
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoxAvailable = new System.Windows.Forms.ListBox();
            this.lstBoxHave = new System.Windows.Forms.ListBox();
            this.btnGive = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(35, 83);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 62;
            this.dgvEmployee.Size = new System.Drawing.Size(484, 92);
            this.dgvEmployee.TabIndex = 83;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(225, 380);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 82;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(212, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 23);
            this.btnSearch.TabIndex = 81;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(35, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 20);
            this.txtSearch.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 24);
            this.label1.TabIndex = 79;
            this.label1.Text = "Manage Maintenance Employee";
            // 
            // lstBoxAvailable
            // 
            this.lstBoxAvailable.FormattingEnabled = true;
            this.lstBoxAvailable.Location = new System.Drawing.Point(81, 243);
            this.lstBoxAvailable.Name = "lstBoxAvailable";
            this.lstBoxAvailable.Size = new System.Drawing.Size(120, 160);
            this.lstBoxAvailable.TabIndex = 84;
            // 
            // lstBoxHave
            // 
            this.lstBoxHave.FormattingEnabled = true;
            this.lstBoxHave.Location = new System.Drawing.Point(321, 243);
            this.lstBoxHave.Name = "lstBoxHave";
            this.lstBoxHave.Size = new System.Drawing.Size(120, 160);
            this.lstBoxHave.TabIndex = 85;
            // 
            // btnGive
            // 
            this.btnGive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGive.Location = new System.Drawing.Point(225, 279);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(75, 23);
            this.btnGive.TabIndex = 86;
            this.btnGive.Text = "-->";
            this.btnGive.UseVisualStyleBackColor = true;
            // 
            // btnTake
            // 
            this.btnTake.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTake.Location = new System.Drawing.Point(225, 330);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(75, 23);
            this.btnTake.TabIndex = 87;
            this.btnTake.Text = "<--";
            this.btnTake.UseVisualStyleBackColor = true;
            // 
            // FrmManageMaintenanceEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(536, 466);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnGive);
            this.Controls.Add(this.lstBoxHave);
            this.Controls.Add(this.lstBoxAvailable);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "FrmManageMaintenanceEmployee";
            this.Text = "Manage Maintenance Employees";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxAvailable;
        private System.Windows.Forms.ListBox lstBoxHave;
        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.Button btnTake;
    }
}