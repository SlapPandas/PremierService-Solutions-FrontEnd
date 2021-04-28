﻿
namespace PremiereSolutionProject.Presentation_Layer
{
    partial class frmClientSatisfaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientSatisfaction));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbClientNotes = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pcClientReport = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcClientReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Satisfaction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 248);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client ID";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(37, 286);
            this.txtClientID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(148, 26);
            this.txtClientID.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Client notes";
            // 
            // rtbClientNotes
            // 
            this.rtbClientNotes.Location = new System.Drawing.Point(418, 142);
            this.rtbClientNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbClientNotes.Name = "rtbClientNotes";
            this.rtbClientNotes.Size = new System.Drawing.Size(238, 460);
            this.rtbClientNotes.TabIndex = 7;
            this.rtbClientNotes.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 335);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Client report";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(296, 649);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(112, 35);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // pcClientReport
            // 
            this.pcClientReport.Location = new System.Drawing.Point(37, 372);
            this.pcClientReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pcClientReport.Name = "pcClientReport";
            this.pcClientReport.Size = new System.Drawing.Size(254, 230);
            this.pcClientReport.TabIndex = 9;
            this.pcClientReport.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(596, 696);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 35);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAnswer
            // 
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnswer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnswer.Image")));
            this.btnAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswer.Location = new System.Drawing.Point(36, 142);
            this.btnAnswer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(139, 45);
            this.btnAnswer.TabIndex = 12;
            this.btnAnswer.Text = "   Start Call";
            this.btnAnswer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnswer.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnd.Location = new System.Drawing.Point(198, 142);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(139, 45);
            this.btnEnd.TabIndex = 13;
            this.btnEnd.Text = "End Call";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // frmClientSatisfaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(721, 745);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pcClientReport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbClientNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClientSatisfaction";
            this.Text = "frmClientSatisfaction";
            ((System.ComponentModel.ISupportInitialize)(this.pcClientReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbClientNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pcClientReport;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnEnd;
    }
}