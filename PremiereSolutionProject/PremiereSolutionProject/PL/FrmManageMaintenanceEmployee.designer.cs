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
            this.btnGive = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.dgvHave = new System.Windows.Forms.DataGridView();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(12, 79);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 62;
            this.dgvEmployee.Size = new System.Drawing.Size(854, 181);
            this.dgvEmployee.TabIndex = 83;
            this.dgvEmployee.SelectionChanged += new System.EventHandler(this.dgvEmployee_SelectionChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(395, 432);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 82;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(376, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 23);
            this.btnSearch.TabIndex = 81;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(199, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 20);
            this.txtSearch.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 24);
            this.label1.TabIndex = 79;
            this.label1.Text = "Manage Maintenance Employee";
            // 
            // btnGive
            // 
            this.btnGive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGive.Location = new System.Drawing.Point(395, 331);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(75, 23);
            this.btnGive.TabIndex = 86;
            this.btnGive.Text = "-->";
            this.btnGive.UseVisualStyleBackColor = true;
            this.btnGive.Click += new System.EventHandler(this.btnGive_Click);
            // 
            // btnTake
            // 
            this.btnTake.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTake.Location = new System.Drawing.Point(395, 382);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(75, 23);
            this.btnTake.TabIndex = 87;
            this.btnTake.Text = "<--";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(112, 461);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(643, 96);
            this.txtDescription.TabIndex = 88;
            this.txtDescription.Text = "";
            // 
            // dgvHave
            // 
            this.dgvHave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHave.Location = new System.Drawing.Point(491, 274);
            this.dgvHave.Name = "dgvHave";
            this.dgvHave.RowHeadersWidth = 62;
            this.dgvHave.Size = new System.Drawing.Size(264, 181);
            this.dgvHave.TabIndex = 90;
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.Location = new System.Drawing.Point(112, 274);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.RowHeadersWidth = 62;
            this.dgvAvailable.Size = new System.Drawing.Size(264, 181);
            this.dgvAvailable.TabIndex = 89;
            this.dgvAvailable.SelectionChanged += new System.EventHandler(this.dgvAvailable_SelectionChanged);
            // 
            // FrmManageMaintenanceEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(878, 575);
            this.Controls.Add(this.dgvHave);
            this.Controls.Add(this.dgvAvailable);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnGive);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "FrmManageMaintenanceEmployee";
            this.Text = "Manage Maintenance Employees";
            this.Load += new System.EventHandler(this.FrmManageMaintenanceEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.DataGridView dgvHave;
        private System.Windows.Forms.DataGridView dgvAvailable;
    }
}