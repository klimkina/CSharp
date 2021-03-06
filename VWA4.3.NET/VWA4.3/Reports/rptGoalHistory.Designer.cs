namespace Reports
{
	/// <summary>
	/// Summary description for rptGoalListbyCompletion.
	/// </summary>
    partial class rptGoalHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptGoalHistory));
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.phGoalList = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.pfGoalList = new DataDynamics.ActiveReports.PageFooter();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 4.09375F;
            this.detail.Name = "detail";
            // 
            // phGoalList
            // 
            this.phGoalList.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo});
            this.phGoalList.Height = 0.4166667F;
            this.phGoalList.Name = "phGoalList";
            // 
            // lblTitle
            // 
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "background-color: IndianRed; color: White; font-size: 16pt; font-weight: bold; te" +
                "xt-align: center; vertical-align: middle";
            this.lblTitle.Text = "Single Goal History";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 7F;
            // 
            // imgLogo
            // 
            this.imgLogo.Height = 0.3125F;
            this.imgLogo.HyperLink = null;
            this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
            this.imgLogo.Left = 0F;
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLogo.Top = 0F;
            this.imgLogo.Width = 0.625F;
            // 
            // pfGoalList
            // 
            this.pfGoalList.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.imgLeanPath});
            this.pfGoalList.Height = 0.3749999F;
            this.pfGoalList.Name = "pfGoalList";
            // 
            // imgLeanPath
            // 
            this.imgLeanPath.Height = 0.3125F;
            this.imgLeanPath.HyperLink = null;
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 6.375F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0F;
            this.imgLeanPath.Width = 0.625F;
            // 
            // rptGoalHistory
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.989584F;
            this.Sections.Add(this.phGoalList);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pfGoalList);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptGoalHistory_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

        private DataDynamics.ActiveReports.PageHeader phGoalList;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.PageFooter pfGoalList;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
	}
}
