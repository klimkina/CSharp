namespace Reports
{
    /// <summary>
    /// Summary description for rptEvent.
    /// </summary>
    partial class rptEvent
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEvent));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtClient = new DataDynamics.ActiveReports.TextBox();
            this.txtEvents = new DataDynamics.ActiveReports.TextBox();
            this.txtClientName = new DataDynamics.ActiveReports.TextBox();
            this.subEvents = new DataDynamics.ActiveReports.SubReport();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblFooter = new DataDynamics.ActiveReports.TextBox();
            this.lblWarning = new DataDynamics.ActiveReports.TextBox();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.txtSite = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.txtPeriods = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle});
            this.pageHeader.Height = 0.5104167F;
            this.pageHeader.Name = "pageHeader";
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: White; text-align: center; font-weight: bold; background-color: IndianRed;" +
                " font-size: 16pt; vertical-align: middle; ";
            this.lblTitle.Text = "Event Orders";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 9.4375F;
            // 
            // imgLogo
            // 
            this.imgLogo.Border.BottomColor = System.Drawing.Color.Black;
            this.imgLogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.LeftColor = System.Drawing.Color.Black;
            this.imgLogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.RightColor = System.Drawing.Color.Black;
            this.imgLogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.TopColor = System.Drawing.Color.Black;
            this.imgLogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Height = 0.3125F;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
            this.imgLogo.Left = 0F;
            this.imgLogo.LineWeight = 0F;
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLogo.Top = 0F;
            this.imgLogo.Width = 0.625F;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.CanShrink = true;
            this.txtSubTitle.Height = 0.1875F;
            this.txtSubTitle.Left = 0F;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Style = "text-align: center; ";
            this.txtSubTitle.Text = null;
            this.txtSubTitle.Top = 0.3125F;
            this.txtSubTitle.Width = 9.4375F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtClient,
            this.txtEvents,
            this.txtClientName,
            this.subEvents});
            this.detail.Height = 0.46875F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtClient
            // 
            this.txtClient.Border.BottomColor = System.Drawing.Color.Black;
            this.txtClient.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.LeftColor = System.Drawing.Color.Black;
            this.txtClient.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.RightColor = System.Drawing.Color.Black;
            this.txtClient.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.TopColor = System.Drawing.Color.Black;
            this.txtClient.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Height = 0.1979167F;
            this.txtClient.Left = 0.0625F;
            this.txtClient.Name = "txtClient";
            this.txtClient.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtClient.Text = "Client: ";
            this.txtClient.Top = 0F;
            this.txtClient.Width = 1F;
            // 
            // txtEvents
            // 
            this.txtEvents.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEvents.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEvents.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEvents.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEvents.Border.RightColor = System.Drawing.Color.Black;
            this.txtEvents.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEvents.Border.TopColor = System.Drawing.Color.Black;
            this.txtEvents.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEvents.Height = 0.1979167F;
            this.txtEvents.Left = 0.0625F;
            this.txtEvents.Name = "txtEvents";
            this.txtEvents.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtEvents.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtEvents.Text = "Events:";
            this.txtEvents.Top = 0.1875F;
            this.txtEvents.Width = 1F;
            // 
            // txtClientName
            // 
            this.txtClientName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtClientName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtClientName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientName.Border.RightColor = System.Drawing.Color.Black;
            this.txtClientName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientName.Border.TopColor = System.Drawing.Color.Black;
            this.txtClientName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientName.DataField = "ClientName";
            this.txtClientName.Height = 0.1875F;
            this.txtClientName.Left = 1.0625F;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtClientName.Text = null;
            this.txtClientName.Top = 0F;
            this.txtClientName.Width = 8.1875F;
            // 
            // subEvents
            // 
            this.subEvents.Border.BottomColor = System.Drawing.Color.Black;
            this.subEvents.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEvents.Border.LeftColor = System.Drawing.Color.Black;
            this.subEvents.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEvents.Border.RightColor = System.Drawing.Color.Black;
            this.subEvents.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEvents.Border.TopColor = System.Drawing.Color.Black;
            this.subEvents.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEvents.CloseBorder = false;
            this.subEvents.Height = 0.0625F;
            this.subEvents.Left = 0F;
            this.subEvents.Name = "subEvents";
            this.subEvents.Report = null;
            this.subEvents.ReportName = "subReport3";
            this.subEvents.Top = 0.375F;
            this.subEvents.Width = 9.5F;
            // 
            // pageFooter
            // 
            this.pageFooter.CanShrink = true;
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblFooter,
            this.lblWarning,
            this.lblDB,
            this.imgLeanPath});
            this.pageFooter.Height = 0.6458333F;
            this.pageFooter.Name = "pageFooter";
            // 
            // lblFooter
            // 
            this.lblFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.RightColor = System.Drawing.Color.Black;
            this.lblFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.TopColor = System.Drawing.Color.Black;
            this.lblFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Height = 0.1875F;
            this.lblFooter.Left = 0F;
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Style = "font-size: 8pt; ";
            this.lblFooter.Text = null;
            this.lblFooter.Top = 0F;
            this.lblFooter.Width = 8.625F;
            // 
            // lblWarning
            // 
            this.lblWarning.Border.BottomColor = System.Drawing.Color.Black;
            this.lblWarning.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.LeftColor = System.Drawing.Color.Black;
            this.lblWarning.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.RightColor = System.Drawing.Color.Black;
            this.lblWarning.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.TopColor = System.Drawing.Color.Black;
            this.lblWarning.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Height = 0.1875F;
            this.lblWarning.Left = 0F;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Style = "font-size: 8pt; ";
            this.lblWarning.Text = null;
            this.lblWarning.Top = 0.21875F;
            this.lblWarning.Width = 8.625F;
            // 
            // lblDB
            // 
            this.lblDB.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDB.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDB.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.RightColor = System.Drawing.Color.Black;
            this.lblDB.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.TopColor = System.Drawing.Color.Black;
            this.lblDB.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Height = 0.1875F;
            this.lblDB.Left = 0F;
            this.lblDB.Name = "lblDB";
            this.lblDB.Style = "font-size: 8pt; ";
            this.lblDB.Text = null;
            this.lblDB.Top = 0.4375F;
            this.lblDB.Width = 8.625F;
            // 
            // imgLeanPath
            // 
            this.imgLeanPath.Border.BottomColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.LeftColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.RightColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.TopColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Height = 0.375F;
            this.imgLeanPath.Image = ((System.Drawing.Image)(resources.GetObject("imgLeanPath.Image")));
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 8.75F;
            this.imgLeanPath.LineWeight = 0F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.25F;
            this.imgLeanPath.Width = 0.6875F;
            // 
            // txtSite
            // 
            this.txtSite.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSite.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSite.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.RightColor = System.Drawing.Color.Black;
            this.txtSite.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.TopColor = System.Drawing.Color.Black;
            this.txtSite.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Height = 0.1875F;
            this.txtSite.Left = 0.9375F;
            this.txtSite.Name = "txtSite";
            this.txtSite.Style = "font-weight: bold; ";
            this.txtSite.Text = "textBox2";
            this.txtSite.Top = 0F;
            this.txtSite.Width = 8.1875F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Height = 0.1979167F;
            this.textBox3.Left = 0.0625F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-weight: bold; ";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.Text = "Period:";
            this.textBox3.Top = 0.1875F;
            this.textBox3.Width = 0.875F;
            // 
            // txtPeriods
            // 
            this.txtPeriods.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.RightColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.TopColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Height = 0.1875F;
            this.txtPeriods.Left = 0.9375F;
            this.txtPeriods.Name = "txtPeriods";
            this.txtPeriods.Style = "font-weight: bold; ";
            this.txtPeriods.Text = "textBox4";
            this.txtPeriods.Top = 0.1875F;
            this.txtPeriods.Width = 8.1875F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 0.0625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-weight: bold; ";
            this.textBox1.Text = "Facility: ";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.875F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSite,
            this.textBox3,
            this.textBox1,
            this.txtPeriods});
            this.groupHeader1.Height = 0.3958333F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // rptEvent
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.75F;
            this.PageSettings.Margins.Left = 0.75F;
            this.PageSettings.Margins.Right = 0.75F;
            this.PageSettings.Margins.Top = 0.75F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 9.489583F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport.FetchEventHandler(this.rptEvent_FetchData);
            this.ReportStart += new System.EventHandler(this.rptEvent_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.TextBox txtSite;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox txtPeriods;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox lblFooter;
        private DataDynamics.ActiveReports.TextBox lblWarning;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.TextBox txtClient;
        private DataDynamics.ActiveReports.TextBox txtEvents;
        private DataDynamics.ActiveReports.TextBox txtClientName;
        private DataDynamics.ActiveReports.SubReport subEvents;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
    }
}
