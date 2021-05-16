
namespace PremiereSolutionProject.PL
{
    partial class frmAssignNewEmployee
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
            this.dgvViewJob = new System.Windows.Forms.DataGridView();
            this.btnRemoveTechnician = new System.Windows.Forms.Button();
            this.btnAddTechnician = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvAvailableTech = new System.Windows.Forms.DataGridView();
            this.dgvAssignedTech = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableTech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedTech)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(423, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assign Employees To A Job";
            // 
            // dgvViewJob
            // 
            this.dgvViewJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewJob.Location = new System.Drawing.Point(12, 89);
            this.dgvViewJob.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViewJob.Name = "dgvViewJob";
            this.dgvViewJob.RowHeadersWidth = 51;
            this.dgvViewJob.RowTemplate.Height = 24;
            this.dgvViewJob.Size = new System.Drawing.Size(1113, 185);
            this.dgvViewJob.TabIndex = 1;
            this.dgvViewJob.SelectionChanged += new System.EventHandler(this.dgvViewJob_SelectionChanged);
            // 
            // btnRemoveTechnician
            // 
            this.btnRemoveTechnician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTechnician.Location = new System.Drawing.Point(549, 458);
            this.btnRemoveTechnician.Name = "btnRemoveTechnician";
            this.btnRemoveTechnician.Size = new System.Drawing.Size(81, 52);
            this.btnRemoveTechnician.TabIndex = 146;
            this.btnRemoveTechnician.Text = "<<";
            this.btnRemoveTechnician.UseVisualStyleBackColor = true;
            this.btnRemoveTechnician.Click += new System.EventHandler(this.btnRemoveTechnician_Click);
            // 
            // btnAddTechnician
            // 
            this.btnAddTechnician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTechnician.Location = new System.Drawing.Point(549, 376);
            this.btnAddTechnician.Name = "btnAddTechnician";
            this.btnAddTechnician.Size = new System.Drawing.Size(81, 49);
            this.btnAddTechnician.TabIndex = 145;
            this.btnAddTechnician.Text = ">>";
            this.btnAddTechnician.UseVisualStyleBackColor = true;
            this.btnAddTechnician.Click += new System.EventHandler(this.btnAddTechnician_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(664, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 16);
            this.label3.TabIndex = 144;
            this.label3.Text = "New Assigned Technicians";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(244, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 143;
            this.label2.Text = "Available Technicians";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 41);
            this.btnExit.TabIndex = 142;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgvAvailableTech
            // 
            this.dgvAvailableTech.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableTech.Location = new System.Drawing.Point(247, 376);
            this.dgvAvailableTech.Name = "dgvAvailableTech";
            this.dgvAvailableTech.RowHeadersWidth = 62;
            this.dgvAvailableTech.Size = new System.Drawing.Size(264, 181);
            this.dgvAvailableTech.TabIndex = 147;
            // 
            // dgvAssignedTech
            // 
            this.dgvAssignedTech.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignedTech.Location = new System.Drawing.Point(667, 376);
            this.dgvAssignedTech.Name = "dgvAssignedTech";
            this.dgvAssignedTech.RowHeadersWidth = 62;
            this.dgvAssignedTech.Size = new System.Drawing.Size(264, 181);
            this.dgvAssignedTech.TabIndex = 148;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(555, 555);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 149;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmAssignNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1136, 590);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvAssignedTech);
            this.Controls.Add(this.dgvAvailableTech);
            this.Controls.Add(this.btnRemoveTechnician);
            this.Controls.Add(this.btnAddTechnician);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvViewJob);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAssignNewEmployee";
            this.Text = "Assign New Employee";
            this.Load += new System.EventHandler(this.frmAssignNewEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableTech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedTech)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvViewJob;
        private System.Windows.Forms.Button btnRemoveTechnician;
        private System.Windows.Forms.Button btnAddTechnician;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvAvailableTech;
        private System.Windows.Forms.DataGridView dgvAssignedTech;
        private System.Windows.Forms.Button btnUpdate;
    }
}