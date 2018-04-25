namespace Reports
{
    /// <summary>
    /// Summary description for rptDetails.
    /// </summary>
    partial class rptDetails
    {
        private DataDynamics.ActiveReports.Detail detail;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDetails));
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.subReport1 = new DataDynamics.ActiveReports.SubReport();
			this.subReport2 = new DataDynamics.ActiveReports.SubReport();
			this.subReport3 = new DataDynamics.ActiveReports.SubReport();
			this.subReport4 = new DataDynamics.ActiveReports.SubReport();
			this.subReport5 = new DataDynamics.ActiveReports.SubReport();
			this.subReport6 = new DataDynamics.ActiveReports.SubReport();
			this.subARTrend = new DataDynamics.ActiveReports.SubReport();
			this.lblTitle = new DataDynamics.ActiveReports.Label();
			this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
			this.imgLogo = new DataDynamics.ActiveReports.Picture();
			this.pageHeader1 = new DataDynamics.ActiveReports.PageHeader();
			this.pageFooter1 = new DataDynamics.ActiveReports.PageFooter();
			this.lblFooter = new DataDynamics.ActiveReports.TextBox();
			this.lblDB = new DataDynamics.ActiveReports.TextBox();
			this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
			((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblFooter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// detail
			// 
			this.detail.CanShrink = true;
			this.detail.ColumnCount = 3;
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.subReport2,
            this.subReport3,
            this.subReport4,
            this.subReport5,
            this.subReport6,
            this.subARTrend});
			this.detail.Height = 3.71875F;
			this.detail.Name = "detail";
			// 
			// subReport1
			// 
			this.subReport1.CloseBorder = false;
			this.subReport1.Height = 0.125F;
			this.subReport1.Left = 0.0625F;
			this.subReport1.Name = "subReport1";
			this.subReport1.Report = null;
			this.subReport1.ReportName = "subReport1";
			this.subReport1.Top = 2.83125F;
			this.subReport1.Width = 2.875F;
			// 
			// subReport2
			// 
			this.subReport2.CloseBorder = false;
			this.subReport2.Height = 0.125F;
			this.subReport2.Left = 0.0625F;
			this.subReport2.Name = "subReport2";
			this.subReport2.Report = null;
			this.subReport2.ReportName = "subReport1";
			this.subReport2.Top = 2.9775F;
			this.subReport2.Width = 2.875F;
			// 
			// subReport3
			// 
			this.subReport3.CloseBorder = false;
			this.subReport3.Height = 0.125F;
			this.subReport3.Left = 0.0625F;
			this.subReport3.Name = "subReport3";
			this.subReport3.Report = null;
			this.subReport3.ReportName = "subReport1";
			this.subReport3.Top = 3.12375F;
			this.subReport3.Width = 2.875F;
			// 
			// subReport4
			// 
			this.subReport4.CloseBorder = false;
			this.subReport4.Height = 0.125F;
			this.subReport4.Left = 0.0625F;
			this.subReport4.Name = "subReport4";
			this.subReport4.Report = null;
			this.subReport4.ReportName = "subReport1";
			this.subReport4.Top = 3.27F;
			this.subReport4.Width = 2.875F;
			// 
			// subReport5
			// 
			this.subReport5.CloseBorder = false;
			this.subReport5.Height = 0.125F;
			this.subReport5.Left = 0.0625F;
			this.subReport5.Name = "subReport5";
			this.subReport5.Report = null;
			this.subReport5.ReportName = "subReport1";
			this.subReport5.Top = 3.41625F;
			this.subReport5.Width = 2.875F;
			// 
			// subReport6
			// 
			this.subReport6.CloseBorder = false;
			this.subReport6.Height = 0.125F;
			this.subReport6.Left = 0.0625F;
			this.subReport6.Name = "subReport6";
			this.subReport6.Report = null;
			this.subReport6.ReportName = "subReport1";
			this.subReport6.Top = 3.5625F;
			this.subReport6.Width = 2.875F;
			// 
			// subARTrend
			// 
			this.subARTrend.CanGrow = false;
			this.subARTrend.CanShrink = false;
			this.subARTrend.CloseBorder = false;
			this.subARTrend.Height = 2.81F;
			this.subARTrend.Left = 0.0625F;
			this.subARTrend.Name = "subARTrend";
			this.subARTrend.Report = null;
			this.subARTrend.ReportName = "subReport1";
			this.subARTrend.Top = 0F;
			this.subARTrend.Width = 2.875F;
			// 
			// lblTitle
			// 
			this.lblTitle.Height = 0.3125F;
			this.lblTitle.HyperLink = null;
			this.lblTitle.Left = 0.0625F;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Style = "background-color: IndianRed; color: White; font-size: 16pt; font-weight: bold; te" +
				"xt-align: center; vertical-align: middle";
			this.lblTitle.Text = "Detail Report for";
			this.lblTitle.Top = 0F;
			this.lblTitle.Width = 8.75F;
			// 
			// txtSubTitle
			// 
			this.txtSubTitle.CanShrink = true;
			this.txtSubTitle.Height = 0.1875F;
			this.txtSubTitle.Left = 0.0625F;
			this.txtSubTitle.Name = "txtSubTitle";
			this.txtSubTitle.Style = "text-align: center";
			this.txtSubTitle.Text = null;
			this.txtSubTitle.Top = 0.3125F;
			this.txtSubTitle.Width = 8.75F;
			// 
			// imgLogo
			// 
			this.imgLogo.Height = 0.3125F;
			this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
			this.imgLogo.Left = 0.0625F;
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
			this.imgLogo.Top = 0F;
			this.imgLogo.Width = 0.625F;
			// 
			// pageHeader1
			// 
			this.pageHeader1.CanShrink = true;
			this.pageHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle});
			this.pageHeader1.Height = 0.5104167F;
			this.pageHeader1.Name = "pageHeader1";
			// 
			// pageFooter1
			// 
			this.pageFooter1.CanShrink = true;
			this.pageFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblFooter,
            this.lblDB,
            this.imgLeanPath});
			this.pageFooter1.Height = 0.3854167F;
			this.pageFooter1.Name = "pageFooter1";
			// 
			// lblFooter
			// 
			this.lblFooter.Height = 0.1875F;
			this.lblFooter.Left = 0F;
			this.lblFooter.Name = "lblFooter";
			this.lblFooter.Style = "font-size: 8pt";
			this.lblFooter.Text = null;
			this.lblFooter.Top = 0F;
			this.lblFooter.Width = 8.0625F;
			// 
			// lblDB
			// 
			this.lblDB.Height = 0.1875F;
			this.lblDB.Left = 0F;
			this.lblDB.Name = "lblDB";
			this.lblDB.Style = "font-size: 8pt";
			this.lblDB.Text = null;
			this.lblDB.Top = 0.1875F;
			this.lblDB.Width = 8.0625F;
			// 
			// imgLeanPath
			// 
			this.imgLeanPath.Height = 0.3125F;
			this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
			this.imgLeanPath.Left = 8.1875F;
			this.imgLeanPath.Name = "imgLeanPath";
			this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
			this.imgLeanPath.Top = 0.0625F;
			this.imgLeanPath.Width = 0.625F;
			// 
			// rptDetails
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
			this.PrintWidth = 9.0625F;
			this.Sections.Add(this.pageHeader1);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.pageFooter1);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
						"l; font-size: 10pt; color: Black", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
			this.ReportStart += new System.EventHandler(this.rptDetails_ReportStart);
			((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblFooter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.SubReport subARTrend;
        private DataDynamics.ActiveReports.SubReport subReport1;
        private DataDynamics.ActiveReports.SubReport subReport2;
        private DataDynamics.ActiveReports.SubReport subReport3;
        private DataDynamics.ActiveReports.SubReport subReport4;
        private DataDynamics.ActiveReports.SubReport subReport5;
        private DataDynamics.ActiveReports.SubReport subReport6;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.PageHeader pageHeader1;
        private DataDynamics.ActiveReports.PageFooter pageFooter1;
        private DataDynamics.ActiveReports.TextBox lblFooter;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        //private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        //private DataDynamics.ActiveReports.ReportFooter reportFooter1;
    }
}
