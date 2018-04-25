namespace Reports
{
    /// <summary>
    /// Summary description for rptFinancials.
    /// </summary>
    partial class rptFinancials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptFinancials));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtSite = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.txtPeriod = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.txtFilter = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle,
            this.txtSite,
            this.textBox1,
            this.textBox3,
            this.txtPeriod});
            this.pageHeader.Height = 1.375F;
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
            this.lblTitle.Text = "Financial Report";
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
            this.txtSite.Left = 1F;
            this.txtSite.Name = "txtSite";
            this.txtSite.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtSite.Text = "Site";
            this.txtSite.Top = 0.75F;
            this.txtSite.Width = 8.4375F;
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
            this.textBox1.Height = 0.1979167F;
            this.textBox1.Left = 0F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-weight: bold; ";
            this.textBox1.Text = "Facility: ";
            this.textBox1.Top = 0.75F;
            this.textBox1.Width = 1F;
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
            this.textBox3.Left = 0F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-weight: bold; ";
            this.textBox3.Text = "Period:";
            this.textBox3.Top = 0.9375F;
            this.textBox3.Width = 1F;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.RightColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.TopColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Height = 0.1875F;
            this.txtPeriod.Left = 1F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "font-weight: bold; ";
            this.txtPeriod.Text = null;
            this.txtPeriod.Top = 0.9375F;
            this.txtPeriod.Width = 5.5F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1});
            this.detail.Height = 0.09375F;
            this.detail.Name = "detail";
            // 
            // subReport1
            // 
            this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.RightColor = System.Drawing.Color.Black;
            this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.TopColor = System.Drawing.Color.Black;
            this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 0.0625F;
            this.subReport1.Left = 0F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0F;
            this.subReport1.Width = 9.4375F;
            // 
            // pageFooter
            // 
            this.pageFooter.CanShrink = true;
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtFilter,
            this.imgLeanPath,
            this.lblDB});
            this.pageFooter.Height = 0.40625F;
            this.pageFooter.Name = "pageFooter";
            // 
            // txtFilter
            // 
            this.txtFilter.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFilter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFilter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.RightColor = System.Drawing.Color.Black;
            this.txtFilter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.TopColor = System.Drawing.Color.Black;
            this.txtFilter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Height = 0.1875F;
            this.txtFilter.Left = 0F;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Style = "font-style: italic; font-size: 8pt; ";
            this.txtFilter.Text = null;
            this.txtFilter.Top = 0F;
            this.txtFilter.Width = 8.5F;
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
            this.imgLeanPath.Height = 0.3125F;
            this.imgLeanPath.Image = ((System.Drawing.Image)(resources.GetObject("imgLeanPath.Image")));
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 8.625F;
            this.imgLeanPath.LineWeight = 0F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.0625F;
            this.imgLeanPath.Width = 0.625F;
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
            this.lblDB.Top = 0.1875F;
            this.lblDB.Width = 8.5F;
            // 
            // rptFinancials
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
            this.PrintWidth = 9.479164F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptFinancials_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.TextBox txtFilter;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.TextBox txtSite;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox txtPeriod;
        private DataDynamics.ActiveReports.SubReport subReport1;
    }
}
