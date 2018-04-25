namespace Reports
{
    partial class frmReportViewer
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
            this.ucReportViewer1 = new Reports.UCReportViewer();
            this.SuspendLayout();
            // Icon
            this.Icon = Properties.Resources.VW_appicon;
            // 
            // ucReportViewer1
            // 
            this.ucReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucReportViewer1.Name = "ucReportViewer1";
            this.ucReportViewer1.Size = new System.Drawing.Size(1098, 393);
            this.ucReportViewer1.TabIndex = 0;
            this.ucReportViewer1.TitleChanged += new UCReportViewer.TitleChangedEventHandler(this.ucReportViewer1_TitleChanged);
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 393);
            this.Controls.Add(this.ucReportViewer1);
            this.Name = "frmReportViewer";
            this.Text = "Report Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmReportViewer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private UCReportViewer ucReportViewer1;



    }
}