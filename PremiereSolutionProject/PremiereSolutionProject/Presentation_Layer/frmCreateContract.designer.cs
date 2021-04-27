
namespace PremiereSolutionProject.Presentation_Layer
{
    partial class frmCreateContract
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
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxServicePackages = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dgvViewServices = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddServicePackage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(565, 641);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 35);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // cbxServicePackages
            // 
            this.cbxServicePackages.FormattingEnabled = true;
            this.cbxServicePackages.Location = new System.Drawing.Point(135, 142);
            this.cbxServicePackages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxServicePackages.Name = "cbxServicePackages";
            this.cbxServicePackages.Size = new System.Drawing.Size(418, 28);
            this.cbxServicePackages.TabIndex = 29;
            // 
            // btnCreate
            // 
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(257, 557);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(175, 35);
            this.btnCreate.TabIndex = 28;
            this.btnCreate.Text = "Create Contract";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // dgvViewServices
            // 
            this.dgvViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewServices.Location = new System.Drawing.Point(134, 229);
            this.dgvViewServices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvViewServices.Name = "dgvViewServices";
            this.dgvViewServices.RowHeadersWidth = 62;
            this.dgvViewServices.Size = new System.Drawing.Size(419, 144);
            this.dgvViewServices.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Services";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Service package";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 34);
            this.label1.TabIndex = 18;
            this.label1.Text = "Create contract";
            // 
            // btnAddServicePackage
            // 
            this.btnAddServicePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServicePackage.Location = new System.Drawing.Point(227, 415);
            this.btnAddServicePackage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddServicePackage.Name = "btnAddServicePackage";
            this.btnAddServicePackage.Size = new System.Drawing.Size(237, 35);
            this.btnAddServicePackage.TabIndex = 33;
            this.btnAddServicePackage.Text = "Add Service Package";
            this.btnAddServicePackage.UseVisualStyleBackColor = true;
            // 
            // frmCreateContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(699, 690);
            this.Controls.Add(this.btnAddServicePackage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbxServicePackages);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvViewServices);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmCreateContract";
            this.Text = "frmCreateContract";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxServicePackages;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dgvViewServices;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddServicePackage;
    }
}