namespace VWAUpdater
{
    partial class Main
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
            this.pnlDownloadProgress = new System.Windows.Forms.Panel();
            this.lblPercentComplete = new System.Windows.Forms.Label();
            this.prgUpload = new System.Windows.Forms.ProgressBar();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tmrDoUploads = new System.Windows.Forms.Timer(this.components);
            this.lblTotalUpdates = new System.Windows.Forms.Label();
            this.pnlDownloadProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlDownloadProgress
            // 
            this.pnlDownloadProgress.Controls.Add(this.lblPercentComplete);
            this.pnlDownloadProgress.Controls.Add(this.prgUpload);
            this.pnlDownloadProgress.Location = new System.Drawing.Point(12, 217);
            this.pnlDownloadProgress.Name = "pnlDownloadProgress";
            this.pnlDownloadProgress.Size = new System.Drawing.Size(600, 37);
            this.pnlDownloadProgress.TabIndex = 12;
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblPercentComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPercentComplete.Location = new System.Drawing.Point(545, 7);
            this.lblPercentComplete.Name = "lblPercentComplete";
            this.lblPercentComplete.Size = new System.Drawing.Size(52, 23);
            this.lblPercentComplete.TabIndex = 11;
            this.lblPercentComplete.Text = "0%";
            this.lblPercentComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgUpload
            // 
            this.prgUpload.Location = new System.Drawing.Point(0, 7);
            this.prgUpload.Name = "prgUpload";
            this.prgUpload.Size = new System.Drawing.Size(539, 23);
            this.prgUpload.TabIndex = 10;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 25);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(597, 157);
            this.txtOutput.TabIndex = 13;
            // 
            // tmrDoUploads
            // 
            this.tmrDoUploads.Enabled = true;
            this.tmrDoUploads.Interval = 1000;
            this.tmrDoUploads.Tick += new System.EventHandler(this.tmrDoUploads_Tick);
            // 
            // lblTotalUpdates
            // 
            this.lblTotalUpdates.AutoSize = true;
            this.lblTotalUpdates.Location = new System.Drawing.Point(12, 6);
            this.lblTotalUpdates.Name = "lblTotalUpdates";
            this.lblTotalUpdates.Size = new System.Drawing.Size(35, 13);
            this.lblTotalUpdates.TabIndex = 14;
            this.lblTotalUpdates.Text = "label1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 266);
            this.Controls.Add(this.lblTotalUpdates);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.pnlDownloadProgress);
            this.Controls.Add(this.btnCancel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advantage Update Utility";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlDownloadProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDownloadProgress;
        private System.Windows.Forms.Label lblPercentComplete;
        private System.Windows.Forms.ProgressBar prgUpload;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Timer tmrDoUploads;
        private System.Windows.Forms.Label lblTotalUpdates;
    }
}