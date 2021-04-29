
namespace PremiereSolutionProject.Presentation_Layer
{
    partial class frmContractManagement
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
            this.btnCreateContract = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddServicePackage = new System.Windows.Forms.Button();
            this.cbxServicePackages = new System.Windows.Forms.ComboBox();
            this.dgvViewServices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(793, 630);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 34);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnCreateContract
            // 
            this.btnCreateContract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateContract.Location = new System.Drawing.Point(474, 531);
            this.btnCreateContract.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateContract.Name = "btnCreateContract";
            this.btnCreateContract.Size = new System.Drawing.Size(175, 34);
            this.btnCreateContract.TabIndex = 28;
            this.btnCreateContract.Text = "Create New Contract";
            this.btnCreateContract.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Services";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Service package";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Contract Management";
            // 
            // btnAddServicePackage
            // 
            this.btnAddServicePackage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddServicePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServicePackage.Location = new System.Drawing.Point(246, 531);
            this.btnAddServicePackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddServicePackage.Name = "btnAddServicePackage";
            this.btnAddServicePackage.Size = new System.Drawing.Size(184, 34);
            this.btnAddServicePackage.TabIndex = 33;
            this.btnAddServicePackage.Text = "Add Service Package";
            this.btnAddServicePackage.UseVisualStyleBackColor = true;
            // 
            // cbxServicePackages
            // 
            this.cbxServicePackages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxServicePackages.FormattingEnabled = true;
            this.cbxServicePackages.Location = new System.Drawing.Point(110, 149);
            this.cbxServicePackages.Margin = new System.Windows.Forms.Padding(4);
            this.cbxServicePackages.Name = "cbxServicePackages";
            this.cbxServicePackages.Size = new System.Drawing.Size(339, 24);
            this.cbxServicePackages.TabIndex = 29;
            // 
            // dgvViewServices
            // 
            this.dgvViewServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewServices.Location = new System.Drawing.Point(110, 247);
            this.dgvViewServices.Margin = new System.Windows.Forms.Padding(4);
            this.dgvViewServices.Name = "dgvViewServices";
            this.dgvViewServices.RowHeadersWidth = 62;
            this.dgvViewServices.Size = new System.Drawing.Size(680, 184);
            this.dgvViewServices.TabIndex = 27;
            // 
            // frmContractManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(908, 677);
            this.Controls.Add(this.btnAddServicePackage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbxServicePackages);
            this.Controls.Add(this.btnCreateContract);
            this.Controls.Add(this.dgvViewServices);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmContractManagement";
            this.Text = "frmCreateContract";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateContract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddServicePackage;
        private System.Windows.Forms.ComboBox cbxServicePackages;
        private System.Windows.Forms.DataGridView dgvViewServices;
    }
}