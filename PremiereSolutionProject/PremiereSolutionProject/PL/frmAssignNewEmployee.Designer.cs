
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
            this.dgvViewEmp = new System.Windows.Forms.DataGridView();
            this.lbxAvailTech = new System.Windows.Forms.ListBox();
            this.btnRemoveTechnician = new System.Windows.Forms.Button();
            this.btnAddTechnician = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbxNewAssigned = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(252, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assign Employees To A Job";
            // 
            // dgvViewEmp
            // 
            this.dgvViewEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewEmp.Location = new System.Drawing.Point(64, 75);
            this.dgvViewEmp.Name = "dgvViewEmp";
            this.dgvViewEmp.RowHeadersWidth = 51;
            this.dgvViewEmp.RowTemplate.Height = 24;
            this.dgvViewEmp.Size = new System.Drawing.Size(765, 156);
            this.dgvViewEmp.TabIndex = 1;
            // 
            // lbxAvailTech
            // 
            this.lbxAvailTech.FormattingEnabled = true;
            this.lbxAvailTech.ItemHeight = 16;
            this.lbxAvailTech.Location = new System.Drawing.Point(194, 324);
            this.lbxAvailTech.Name = "lbxAvailTech";
            this.lbxAvailTech.Size = new System.Drawing.Size(189, 132);
            this.lbxAvailTech.TabIndex = 148;
            // 
            // btnRemoveTechnician
            // 
            this.btnRemoveTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTechnician.Location = new System.Drawing.Point(422, 405);
            this.btnRemoveTechnician.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveTechnician.Name = "btnRemoveTechnician";
            this.btnRemoveTechnician.Size = new System.Drawing.Size(48, 27);
            this.btnRemoveTechnician.TabIndex = 146;
            this.btnRemoveTechnician.Text = "<<";
            this.btnRemoveTechnician.UseVisualStyleBackColor = true;
            this.btnRemoveTechnician.Click += new System.EventHandler(this.btnRemoveTechnician_Click);
            // 
            // btnAddTechnician
            // 
            this.btnAddTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTechnician.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTechnician.Location = new System.Drawing.Point(422, 337);
            this.btnAddTechnician.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTechnician.Name = "btnAddTechnician";
            this.btnAddTechnician.Size = new System.Drawing.Size(48, 27);
            this.btnAddTechnician.TabIndex = 145;
            this.btnAddTechnician.Text = ">>";
            this.btnAddTechnician.UseVisualStyleBackColor = true;
            this.btnAddTechnician.Click += new System.EventHandler(this.btnAddTechnician_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(518, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 144;
            this.label3.Text = "New Assigned Technicians";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(205, 294);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 143;
            this.label2.Text = "Available Technicians";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(790, 550);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 28);
            this.btnExit.TabIndex = 142;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbxNewAssigned
            // 
            this.lbxNewAssigned.FormattingEnabled = true;
            this.lbxNewAssigned.ItemHeight = 16;
            this.lbxNewAssigned.Location = new System.Drawing.Point(511, 324);
            this.lbxNewAssigned.Name = "lbxNewAssigned";
            this.lbxNewAssigned.Size = new System.Drawing.Size(194, 132);
            this.lbxNewAssigned.TabIndex = 147;
            // 
            // frmAssignNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(894, 591);
            this.Controls.Add(this.lbxAvailTech);
            this.Controls.Add(this.lbxNewAssigned);
            this.Controls.Add(this.btnRemoveTechnician);
            this.Controls.Add(this.btnAddTechnician);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvViewEmp);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmAssignNewEmployee";
            this.Text = "Assign New Employee";
            this.Load += new System.EventHandler(this.frmAssignNewEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvViewEmp;
        private System.Windows.Forms.ListBox lbxAvailTech;
        private System.Windows.Forms.Button btnRemoveTechnician;
        private System.Windows.Forms.Button btnAddTechnician;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lbxNewAssigned;
    }
}