﻿namespace VWAUpdater
{
    partial class Download
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblPercentComplete = new System.Windows.Forms.Label();
            this.prgUpload = new System.Windows.Forms.ProgressBar();
            this.tmrDoUploads = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(357, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(12, 9);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(127, 20);
            this.lblDetails.TabIndex = 6;
            this.lblDetails.Text = "Downloading...";
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblPercentComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPercentComplete.Location = new System.Drawing.Point(438, 35);
            this.lblPercentComplete.Name = "lblPercentComplete";
            this.lblPercentComplete.Size = new System.Drawing.Size(55, 23);
            this.lblPercentComplete.TabIndex = 5;
            this.lblPercentComplete.Text = "0%";
            this.lblPercentComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgUpload
            // 
            this.prgUpload.Location = new System.Drawing.Point(12, 35);
            this.prgUpload.Name = "prgUpload";
            this.prgUpload.Size = new System.Drawing.Size(420, 23);
            this.prgUpload.TabIndex = 4;
            // 
            // tmrDoUploads
            // 
            this.tmrDoUploads.Interval = 1000;
            this.tmrDoUploads.Tick += new System.EventHandler(this.tmrDoUploads_Tick);
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 95);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblPercentComplete);
            this.Controls.Add(this.prgUpload);
            this.Name = "Download";
            this.Text = "Download";
            this.Load += new System.EventHandler(this.Download_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblPercentComplete;
        private System.Windows.Forms.ProgressBar prgUpload;
        private System.Windows.Forms.Timer tmrDoUploads;
    }
}