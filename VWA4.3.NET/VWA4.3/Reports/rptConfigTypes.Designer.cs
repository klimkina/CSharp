namespace Reports
{
    /// <summary>
    /// Summary description for rptConfigTypes.
    /// </summary>
    partial class rptConfigTypes
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptConfigTypes));
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.lblTypeCatalog = new DataDynamics.ActiveReports.Label();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypeCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // lblTypeCatalog
            // 
            this.lblTypeCatalog.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTypeCatalog.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTypeCatalog.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTypeCatalog.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTypeCatalog.Border.RightColor = System.Drawing.Color.Black;
            this.lblTypeCatalog.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTypeCatalog.Border.TopColor = System.Drawing.Color.Black;
            this.lblTypeCatalog.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTypeCatalog.Height = 0.25F;
            this.lblTypeCatalog.HyperLink = null;
            this.lblTypeCatalog.Left = 0F;
            this.lblTypeCatalog.Name = "lblTypeCatalog";
            this.lblTypeCatalog.Style = "color: White; text-align: center; font-weight: bold; background-color: Salmon; fo" +
                "nt-size: 12pt; vertical-align: middle; ";
            this.lblTypeCatalog.Text = "Food Types (Master)";
            this.lblTypeCatalog.Top = 0F;
            this.lblTypeCatalog.Width = 7F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTypeCatalog});
            this.groupHeader1.Height = 0.25F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // rptConfigTypes
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.75F;
            this.PageSettings.Margins.Left = 0.75F;
            this.PageSettings.Margins.Right = 0.75F;
            this.PageSettings.Margins.Top = 0.75F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.041667F;
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptConfigTypes_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTypeCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblTypeCatalog;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
    }
}
