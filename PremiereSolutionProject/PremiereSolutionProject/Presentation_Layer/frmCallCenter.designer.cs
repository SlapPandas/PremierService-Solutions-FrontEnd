
namespace PremiereSolutionProject.Presentation_Layer
{
    partial class frmCallCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCallCenter));
            this.label1 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnServiceRequest = new System.Windows.Forms.Button();
            this.btnIdentiyClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Call Centre Employee Name";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(56, 420);
            this.rtbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(448, 241);
            this.rtbNotes.TabIndex = 4;
            this.rtbNotes.Text = "Notes:";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(492, 691);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 34);
            this.label4.TabIndex = 11;
            this.label4.Text = "Call Center";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 103);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnEnd
            // 
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnd.Location = new System.Drawing.Point(306, 207);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(159, 45);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "End Call";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // btnAnswer
            // 
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnswer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnswer.Image")));
            this.btnAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswer.Location = new System.Drawing.Point(71, 207);
            this.btnAnswer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(159, 45);
            this.btnAnswer.TabIndex = 0;
            this.btnAnswer.Text = "Answer Call";
            this.btnAnswer.UseVisualStyleBackColor = true;
            // 
            // btnServiceRequest
            // 
            this.btnServiceRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceRequest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnServiceRequest.Location = new System.Drawing.Point(141, 349);
            this.btnServiceRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServiceRequest.Name = "btnServiceRequest";
            this.btnServiceRequest.Size = new System.Drawing.Size(259, 35);
            this.btnServiceRequest.TabIndex = 12;
            this.btnServiceRequest.Text = "Create New Service Request";
            this.btnServiceRequest.UseVisualStyleBackColor = true;
            this.btnServiceRequest.Click += new System.EventHandler(this.btnServiceRequest_Click);
            // 
            // btnIdentiyClient
            // 
            this.btnIdentiyClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentiyClient.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIdentiyClient.Location = new System.Drawing.Point(179, 291);
            this.btnIdentiyClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIdentiyClient.Name = "btnIdentiyClient";
            this.btnIdentiyClient.Size = new System.Drawing.Size(182, 35);
            this.btnIdentiyClient.TabIndex = 13;
            this.btnIdentiyClient.Text = "Identify Client";
            this.btnIdentiyClient.UseVisualStyleBackColor = true;
            // 
            // frmCallCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(616, 740);
            this.Controls.Add(this.btnIdentiyClient);
            this.Controls.Add(this.btnServiceRequest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnAnswer);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCallCenter";
            this.Text = "Call Center";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnServiceRequest;
        private System.Windows.Forms.Button btnIdentiyClient;
    }
}