namespace Reports
{
    partial class ReportConfiguration
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
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.ucLowParameters1 = new UserControls.UCLowParameters();
            this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.viewer1.Location = new System.Drawing.Point(0, 231);
            this.viewer1.Name = "viewer1";
            this.viewer1.ReportViewer.CurrentPage = 0;
            this.viewer1.ReportViewer.MultiplePageCols = 3;
            this.viewer1.ReportViewer.MultiplePageRows = 2;
            this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.viewer1.Size = new System.Drawing.Size(1059, 223);
            this.viewer1.TabIndex = 1;
            this.viewer1.TableOfContents.Text = "Table Of Contents";
            this.viewer1.TableOfContents.Width = 200;
            this.viewer1.TabTitleLength = 35;
            this.viewer1.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // ucLowParameters1
            // 
            this.ucLowParameters1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLowParameters1.Location = new System.Drawing.Point(0, 0);
            this.ucLowParameters1.Name = "ucLowParameters1";
            this.ucLowParameters1.Size = new System.Drawing.Size(1059, 231);
            this.ucLowParameters1.TabIndex = 0;
            this.ucLowParameters1.ExportPDF += new UserControls.UCLowParameters.ExportPDFEventHandler(this.ucLowParameters1_ExportPDF);
            this.ucLowParameters1.ViewReport += new UserControls.UCLowParameters.ViewReportEventHandler(this.ucLowParameters1_ViewReport);
            this.ucLowParameters1.HideParams += new UserControls.UCLowParameters.HideEventHandler(this.ucLowParameters1_HideParams);
            // 
            // ReportConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 454);
            this.Controls.Add(this.viewer1);
            this.Controls.Add(this.ucLowParameters1);
            this.Name = "ReportConfiguration";
            this.Text = "ReportConfiguration";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCLowParameters ucLowParameters1;
        private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
        private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
    }
}