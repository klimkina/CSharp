namespace Reports
{
    partial class ReportCrossTab
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
            this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.ucLowParticipationParameters1 = new UserControls.UCLowParticipationParameters();
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.viewer1.Location = new System.Drawing.Point(0, 217);
            this.viewer1.Name = "viewer1";
            this.viewer1.ReportViewer.CurrentPage = 0;
            this.viewer1.ReportViewer.MultiplePageCols = 3;
            this.viewer1.ReportViewer.MultiplePageRows = 2;
            this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.viewer1.Size = new System.Drawing.Size(932, 361);
            this.viewer1.TabIndex = 3;
            this.viewer1.TableOfContents.Text = "Table Of Contents";
            this.viewer1.TableOfContents.Width = 200;
            this.viewer1.TabTitleLength = 35;
            this.viewer1.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // ucLowParticipationParameters1
            // 
            this.ucLowParticipationParameters1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLowParticipationParameters1.Location = new System.Drawing.Point(0, 0);
            this.ucLowParticipationParameters1.Name = "ucLowParticipationParameters1";
            this.ucLowParticipationParameters1.Size = new System.Drawing.Size(932, 217);
            this.ucLowParticipationParameters1.TabIndex = 2;
            this.ucLowParticipationParameters1.ExportPDF += new UserControls.UCLowParticipationParameters.ExportPDFEventHandler(this.ucLowParticipationParameters1_ExportPDF);
            this.ucLowParticipationParameters1.ViewReport += new UserControls.UCLowParticipationParameters.ViewReportEventHandler(this.ucLowParticipationParameters1_ViewReport);
            this.ucLowParticipationParameters1.HideParams += new UserControls.UCLowParticipationParameters.HideEventHandler(this.ucLowParticipationParameters1_HideParams);
            // 
            // ReportTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 578);
            this.Controls.Add(this.viewer1);
            this.Controls.Add(this.ucLowParticipationParameters1);
            this.Name = "ReportCrossTab";
            this.Text = "Report Detail";
            this.ResumeLayout(false);

        }

        #endregion

        private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
        private UserControls.UCLowParticipationParameters ucLowParticipationParameters1;
        private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
    }
}