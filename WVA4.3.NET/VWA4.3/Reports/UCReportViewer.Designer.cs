﻿namespace Reports
{
    partial class UCReportViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			this.rtfExport1 = new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
			this.panelTop = new System.Windows.Forms.Panel();
			this.cbChooseReportType = new UserControls.UCReportChooser();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
			this.panelParams = new System.Windows.Forms.Panel();
			this.ucLowParticipationParameters1 = new UserControls.UCLowParticipationParameters();
			this.ucViewWeights1 = new UserControls.UCViewWeights();
			this.ultraGridDocumentExporter1 = new Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(this.components);
			this.panelTop.SuspendLayout();
			this.panelContent.SuspendLayout();
			this.panelParams.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtfExport1
			// 
			this.rtfExport1.EnableShapes = false;
			// 
			// panelTop
			// 
			this.panelTop.BackColor = System.Drawing.Color.White;
			this.panelTop.Controls.Add(this.cbChooseReportType);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(937, 31);
			this.panelTop.TabIndex = 0;
			// 
			// cbChooseReportType
			// 
			this.cbChooseReportType.FormattingEnabled = true;
			this.cbChooseReportType.Items.AddRange(new object[] {
            "Budget to Actual Comparison",
            "Close-Up View",
            "Comparison",
            "Comparison: Site Details", 
            "Detail",
            "Employee",
            "Employee Recognition",
            "Event Orders",
            "Financial Summary",
            "Low Participation",
            "Produced Items",
            "Staff Mtg. Agenda",
            "SWAT Agenda",
            "SWAT Notes",
            "Tabular",
            "Tracker Comparison",
            "Transactions by Employee",
            "Transfers",
            "Trend",
            "View Waste",
            "Waste Avoidance",
            "Weekly Tabular",
            "YOY Comparison",
            "Budget to Actual Comparison",
            "Goal List by Completion Percent",
            "Close-Up View",
            "Comparison",
            "Detail",
            "Employee",
            "Employee Recognition",
            "Event Orders",
            "Financial Summary",
            "Low Participation",
            "Produced Items",
            "Staff Mtg. Agenda",
            "SWAT Agenda",
            "SWAT Notes",
            "Tracker Comparison",
            "Transactions by Employee",
            "Transfers",
            "Trend",
            "View Waste",
            "Weekly Tabular",
            "YOY Comparison"});
			this.cbChooseReportType.Location = new System.Drawing.Point(153, 4);
			this.cbChooseReportType.Name = "cbChooseReportType";
			this.cbChooseReportType.Size = new System.Drawing.Size(181, 21);
			this.cbChooseReportType.TabIndex = 1;
			this.cbChooseReportType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.cbChooseReportType.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseWheel);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose Report Class:";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.viewer1);
			this.panelContent.Controls.Add(this.panelParams);
			this.panelContent.Controls.Add(this.ucViewWeights1);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 31);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(937, 465);
			this.panelContent.TabIndex = 1;
			// 
			// viewer1
			// 
			this.viewer1.BackColor = System.Drawing.Color.Transparent;
			this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer1.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
			this.viewer1.Location = new System.Drawing.Point(0, 217);
			this.viewer1.Name = "viewer1";
			this.viewer1.ReportViewer.CurrentPage = 0;
			this.viewer1.ReportViewer.MultiplePageCols = 3;
			this.viewer1.ReportViewer.MultiplePageRows = 2;
			this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
			this.viewer1.Size = new System.Drawing.Size(937, 248);
			this.viewer1.TabIndex = 2;
			this.viewer1.TableOfContents.Text = "Table Of Contents";
			this.viewer1.TableOfContents.Width = 200;
			this.viewer1.TabTitleLength = 35;
			this.viewer1.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.viewer1.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.viewer1_OnToolClick);
			// 
			// panelParams
			// 
			this.panelParams.AllowDrop = true;
			this.panelParams.Controls.Add(this.ucLowParticipationParameters1);
			this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelParams.Location = new System.Drawing.Point(0, 0);
			this.panelParams.Name = "panelParams";
			this.panelParams.Size = new System.Drawing.Size(937, 217);
			this.panelParams.TabIndex = 1;
			// 
			// ucLowParticipationParameters1
			// 
			this.ucLowParticipationParameters1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucLowParticipationParameters1.Location = new System.Drawing.Point(0, 0);
			this.ucLowParticipationParameters1.Name = "ucLowParticipationParameters1";
			this.ucLowParticipationParameters1.ReportFirstDayOfWeek = System.DayOfWeek.Sunday;
			this.ucLowParticipationParameters1.Size = new System.Drawing.Size(937, 217);
			this.ucLowParticipationParameters1.TabIndex = 0;
			this.ucLowParticipationParameters1.HideParams += new UserControls.UCLowParticipationParameters.HideEventHandler(this.ucLowParticipationParameters1_HideParams);
			this.ucLowParticipationParameters1.ViewReport += new UserControls.UCLowParticipationParameters.ViewReportEventHandler(this.ucLowParticipationParameters1_ViewReport);
			this.ucLowParticipationParameters1.ExportPDF += new UserControls.UCLowParticipationParameters.ExportPDFEventHandler(this.ucLowParticipationParameters1_ExportPDF);
			this.ucLowParticipationParameters1.ExportRTF += new UserControls.UCLowParticipationParameters.ExportRTFEventHandler(this.ucLowParticipationParameters1_ExportRTF);
			// 
			// ucViewWeights1
			// 
			this.ucViewWeights1.DBPath = "";
			this.ucViewWeights1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucViewWeights1.IsActive = false;
			this.ucViewWeights1.Location = new System.Drawing.Point(0, 0);
			this.ucViewWeights1.Mode = UserControls.UCViewWeights.DisplayMode.Weights;
			this.ucViewWeights1.Name = "ucViewWeights1";
			this.ucViewWeights1.Size = new System.Drawing.Size(937, 465);
			this.ucViewWeights1.TabIndex = 0;
			this.ucViewWeights1.TitleChanged += new UserControls.UCViewWeights.TitleChangedEventHandler(this.ucLowParticipationParameters1_TitleChanged);
			// 
			// UCReportViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelTop);
			this.Name = "UCReportViewer";
			this.Size = new System.Drawing.Size(937, 496);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelContent.ResumeLayout(false);
			this.panelParams.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
        private DataDynamics.ActiveReports.Export.Rtf.RtfExport rtfExport1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelParams;
        private UserControls.UCViewWeights ucViewWeights1;
        private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
        private UserControls.UCLowParticipationParameters ucLowParticipationParameters1;
        //private System.Windows.Forms.ComboBox comboBox1;
        private UserControls.UCReportChooser cbChooseReportType;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter ultraGridDocumentExporter1;
    }
}
