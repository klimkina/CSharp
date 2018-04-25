namespace Reports
{
    /// <summary>
    /// Summary description for rptWeeklyTabular.
    /// </summary>
    partial class rptWeeklyTabular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptWeeklyTabular));
            DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource1 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtPreconsumer = new DataDynamics.ActiveReports.TextBox();
            this.txtSite = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtWeekStart = new DataDynamics.ActiveReports.TextBox();
            this.txtInter = new DataDynamics.ActiveReports.TextBox();
            this.txtTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtPre = new DataDynamics.ActiveReports.TextBox();
            this.txtPost = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblFooter = new DataDynamics.ActiveReports.TextBox();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.lblWarning = new DataDynamics.ActiveReports.TextBox();
            this.gpWeeklyTabular = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.lblPost = new DataDynamics.ActiveReports.Label();
            this.lblTotal = new DataDynamics.ActiveReports.Label();
            this.lblInter = new DataDynamics.ActiveReports.Label();
            this.lblPre = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.txtInterTotal = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.txtNumOfWeeks = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalTotal = new DataDynamics.ActiveReports.TextBox();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.txtInterAvg = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalAvg = new DataDynamics.ActiveReports.TextBox();
            this.txtPreTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtPostTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtPreAvg = new DataDynamics.ActiveReports.TextBox();
            this.txtPostAvg = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreconsumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfWeeks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle,
            this.txtPreconsumer,
            this.txtSite});
            this.pageHeader.Height = 0.875F;
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
            this.lblTitle.Left = 0.0625F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: White; text-align: center; font-weight: bold; background-color: IndianRed;" +
                " font-size: 16pt; vertical-align: middle; ";
            this.lblTitle.Text = "Weekly Totals Report";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 6.875F;
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
            this.imgLogo.Left = 0.0625F;
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
            this.txtSubTitle.Left = 0.0625F;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Style = "text-align: center; ";
            this.txtSubTitle.Text = null;
            this.txtSubTitle.Top = 0.3125F;
            this.txtSubTitle.Width = 6.875F;
            // 
            // txtPreconsumer
            // 
            this.txtPreconsumer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPreconsumer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreconsumer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPreconsumer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreconsumer.Border.RightColor = System.Drawing.Color.Black;
            this.txtPreconsumer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreconsumer.Border.TopColor = System.Drawing.Color.Black;
            this.txtPreconsumer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreconsumer.Height = 0.1875F;
            this.txtPreconsumer.Left = 0.6875F;
            this.txtPreconsumer.Name = "txtPreconsumer";
            this.txtPreconsumer.Style = "text-decoration: underline; text-align: center; font-weight: bold; font-size: 12p" +
                "t; ";
            this.txtPreconsumer.Text = "Pre-Consumer Food Waste";
            this.txtPreconsumer.Top = 0.6875F;
            this.txtPreconsumer.Width = 6.25F;
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
            this.txtSite.Left = 0.6875F;
            this.txtSite.Name = "txtSite";
            this.txtSite.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtSite.Text = "Site";
            this.txtSite.Top = 0.5F;
            this.txtSite.Width = 6.25F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtWeekStart,
            this.txtInter,
            this.txtTotal,
            this.txtPre,
            this.txtPost});
            this.detail.Height = 0.2083333F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtWeekStart
            // 
            this.txtWeekStart.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWeekStart.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekStart.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWeekStart.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekStart.Border.RightColor = System.Drawing.Color.Black;
            this.txtWeekStart.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekStart.Border.TopColor = System.Drawing.Color.Black;
            this.txtWeekStart.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekStart.DataField = "dDate";
            this.txtWeekStart.Height = 0.1875F;
            this.txtWeekStart.Left = 0.75F;
            this.txtWeekStart.Name = "txtWeekStart";
            this.txtWeekStart.OutputFormat = resources.GetString("txtWeekStart.OutputFormat");
            this.txtWeekStart.Style = "";
            this.txtWeekStart.Text = null;
            this.txtWeekStart.Top = 0F;
            this.txtWeekStart.Width = 1.125F;
            // 
            // txtInter
            // 
            this.txtInter.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInter.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInter.Border.RightColor = System.Drawing.Color.Black;
            this.txtInter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInter.Border.TopColor = System.Drawing.Color.Black;
            this.txtInter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInter.DataField = "InterWaste";
            this.txtInter.Height = 0.1875F;
            this.txtInter.Left = 1.9375F;
            this.txtInter.Name = "txtInter";
            this.txtInter.OutputFormat = resources.GetString("txtInter.OutputFormat");
            this.txtInter.Style = "text-align: right; ";
            this.txtInter.Text = null;
            this.txtInter.Top = 0F;
            this.txtInter.Width = 1.125F;
            // 
            // txtTotal
            // 
            this.txtTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotal.DataField = "TotalWaste";
            this.txtTotal.Height = 0.1875F;
            this.txtTotal.Left = 5.5F;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat");
            this.txtTotal.Style = "text-align: right; ";
            this.txtTotal.Text = null;
            this.txtTotal.Top = 0F;
            this.txtTotal.Width = 1.125F;
            // 
            // txtPre
            // 
            this.txtPre.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPre.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPre.Border.RightColor = System.Drawing.Color.Black;
            this.txtPre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPre.Border.TopColor = System.Drawing.Color.Black;
            this.txtPre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPre.DataField = "PreWaste";
            this.txtPre.Height = 0.1875F;
            this.txtPre.Left = 3.125F;
            this.txtPre.Name = "txtPre";
            this.txtPre.OutputFormat = resources.GetString("txtPre.OutputFormat");
            this.txtPre.Style = "text-align: right; ";
            this.txtPre.Text = null;
            this.txtPre.Top = 0F;
            this.txtPre.Width = 1.125F;
            // 
            // txtPost
            // 
            this.txtPost.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPost.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPost.Border.RightColor = System.Drawing.Color.Black;
            this.txtPost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPost.Border.TopColor = System.Drawing.Color.Black;
            this.txtPost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPost.DataField = "PostWaste";
            this.txtPost.Height = 0.1875F;
            this.txtPost.Left = 4.3125F;
            this.txtPost.Name = "txtPost";
            this.txtPost.OutputFormat = resources.GetString("txtPost.OutputFormat");
            this.txtPost.Style = "text-align: right; ";
            this.txtPost.Text = null;
            this.txtPost.Top = 0F;
            this.txtPost.Width = 1.125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblFooter,
            this.lblDB,
            this.imgLeanPath,
            this.lblWarning});
            this.pageFooter.Height = 0.6354167F;
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
            this.lblFooter.Left = 0.125F;
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Style = "font-size: 8pt; ";
            this.lblFooter.Text = null;
            this.lblFooter.Top = 0F;
            this.lblFooter.Width = 5.875F;
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
            this.lblDB.Left = 0.125F;
            this.lblDB.Name = "lblDB";
            this.lblDB.Style = "font-size: 8pt; ";
            this.lblDB.Text = null;
            this.lblDB.Top = 0.21875F;
            this.lblDB.Width = 5.875F;
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
            this.imgLeanPath.Height = 0.4375F;
            this.imgLeanPath.Image = ((System.Drawing.Image)(resources.GetObject("imgLeanPath.Image")));
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 6.125F;
            this.imgLeanPath.LineWeight = 0F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.1875F;
            this.imgLeanPath.Width = 0.6875F;
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
            this.lblWarning.Left = 0.125F;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Style = "font-size: 8pt; ";
            this.lblWarning.Text = null;
            this.lblWarning.Top = 0.4375F;
            this.lblWarning.Width = 5.875F;
            // 
            // gpWeeklyTabular
            // 
            this.gpWeeklyTabular.ColumnGroupKeepTogether = true;
            this.gpWeeklyTabular.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.lblPost,
            this.lblTotal,
            this.lblInter,
            this.lblPre,
            this.line1});
            this.gpWeeklyTabular.Height = 0.21875F;
            this.gpWeeklyTabular.Name = "gpWeeklyTabular";
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.75F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.label1.Text = "Week";
            this.label1.Top = 0F;
            this.label1.Width = 1.125F;
            // 
            // lblPost
            // 
            this.lblPost.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPost.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPost.Border.RightColor = System.Drawing.Color.Black;
            this.lblPost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPost.Border.TopColor = System.Drawing.Color.Black;
            this.lblPost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPost.Height = 0.1875F;
            this.lblPost.HyperLink = null;
            this.lblPost.Left = 4.3125F;
            this.lblPost.Name = "lblPost";
            this.lblPost.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.lblPost.Text = "Post-Consumer";
            this.lblPost.Top = 0F;
            this.lblPost.Width = 1.125F;
            // 
            // lblTotal
            // 
            this.lblTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.RightColor = System.Drawing.Color.Black;
            this.lblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Border.TopColor = System.Drawing.Color.Black;
            this.lblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTotal.Height = 0.1875F;
            this.lblTotal.HyperLink = null;
            this.lblTotal.Left = 5.5F;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.lblTotal.Text = "Total";
            this.lblTotal.Top = 0F;
            this.lblTotal.Width = 1.125F;
            // 
            // lblInter
            // 
            this.lblInter.Border.BottomColor = System.Drawing.Color.Black;
            this.lblInter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInter.Border.LeftColor = System.Drawing.Color.Black;
            this.lblInter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInter.Border.RightColor = System.Drawing.Color.Black;
            this.lblInter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInter.Border.TopColor = System.Drawing.Color.Black;
            this.lblInter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblInter.Height = 0.1875F;
            this.lblInter.HyperLink = null;
            this.lblInter.Left = 1.9375F;
            this.lblInter.Name = "lblInter";
            this.lblInter.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.lblInter.Text = "Intermediate";
            this.lblInter.Top = 0F;
            this.lblInter.Width = 1.125F;
            // 
            // lblPre
            // 
            this.lblPre.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPre.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPre.Border.RightColor = System.Drawing.Color.Black;
            this.lblPre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPre.Border.TopColor = System.Drawing.Color.Black;
            this.lblPre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPre.Height = 0.1875F;
            this.lblPre.HyperLink = null;
            this.lblPre.Left = 3.125F;
            this.lblPre.Name = "lblPre";
            this.lblPre.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.lblPre.Text = "Pre-Consumer";
            this.lblPre.Top = 0F;
            this.lblPre.Width = 1.125F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.6875F;
            this.line1.LineWeight = 2F;
            this.line1.Name = "line1";
            this.line1.Top = 0.1875F;
            this.line1.Width = 6F;
            this.line1.X1 = 0.6875F;
            this.line1.X2 = 6.6875F;
            this.line1.Y1 = 0.1875F;
            this.line1.Y2 = 0.1875F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.txtInterTotal,
            this.line2,
            this.txtNumOfWeeks,
            this.txtTotalTotal,
            this.label3,
            this.label5,
            this.txtInterAvg,
            this.txtTotalAvg,
            this.txtPreTotal,
            this.txtPostTotal,
            this.txtPreAvg,
            this.txtPostAvg,
            this.line3});
            this.groupFooter1.Height = 0.78125F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.75F;
            this.label6.Name = "label6";
            this.label6.Style = "font-weight: bold; vertical-align: middle; ";
            this.label6.Text = "Total ";
            this.label6.Top = 0.0625F;
            this.label6.Width = 1.125F;
            // 
            // txtInterTotal
            // 
            this.txtInterTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInterTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInterTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtInterTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtInterTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterTotal.DataField = "InterWaste";
            this.txtInterTotal.Height = 0.1875F;
            this.txtInterTotal.Left = 1.9375F;
            this.txtInterTotal.Name = "txtInterTotal";
            this.txtInterTotal.OutputFormat = resources.GetString("txtInterTotal.OutputFormat");
            this.txtInterTotal.Style = "text-align: right; font-weight: bold; ";
            this.txtInterTotal.SummaryGroup = "gpWeeklyTabular";
            this.txtInterTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtInterTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtInterTotal.Text = null;
            this.txtInterTotal.Top = 0.0625F;
            this.txtInterTotal.Width = 1.125F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0.6875F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 6F;
            this.line2.X1 = 0.6875F;
            this.line2.X2 = 6.6875F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // txtNumOfWeeks
            // 
            this.txtNumOfWeeks.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumOfWeeks.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumOfWeeks.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumOfWeeks.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumOfWeeks.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumOfWeeks.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumOfWeeks.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumOfWeeks.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumOfWeeks.CanShrink = true;
            this.txtNumOfWeeks.DataField = "wDate";
            this.txtNumOfWeeks.Height = 0.1875F;
            this.txtNumOfWeeks.Left = 1.9375F;
            this.txtNumOfWeeks.Name = "txtNumOfWeeks";
            this.txtNumOfWeeks.Style = "color: Black; text-align: right; font-weight: bold; ";
            this.txtNumOfWeeks.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.txtNumOfWeeks.SummaryGroup = "gpWeeklyTabular";
            this.txtNumOfWeeks.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtNumOfWeeks.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtNumOfWeeks.Text = null;
            this.txtNumOfWeeks.Top = 0.3125F;
            this.txtNumOfWeeks.Width = 1.125F;
            // 
            // txtTotalTotal
            // 
            this.txtTotalTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalTotal.DataField = "TotalWaste";
            this.txtTotalTotal.Height = 0.1875F;
            this.txtTotalTotal.Left = 5.5F;
            this.txtTotalTotal.Name = "txtTotalTotal";
            this.txtTotalTotal.OutputFormat = resources.GetString("txtTotalTotal.OutputFormat");
            this.txtTotalTotal.Style = "text-align: right; font-weight: bold; ";
            this.txtTotalTotal.SummaryGroup = "gpWeeklyTabular";
            this.txtTotalTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtTotalTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtTotalTotal.Text = null;
            this.txtTotalTotal.Top = 0.0625F;
            this.txtTotalTotal.Width = 1.125F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.75F;
            this.label3.Name = "label3";
            this.label3.Style = "font-weight: bold; vertical-align: middle; ";
            this.label3.Text = "# of Weeks";
            this.label3.Top = 0.3125F;
            this.label3.Width = 1.125F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.75F;
            this.label5.Name = "label5";
            this.label5.Style = "font-weight: bold; vertical-align: middle; ";
            this.label5.Text = "Weekly Average";
            this.label5.Top = 0.5625F;
            this.label5.Width = 1.125F;
            // 
            // txtInterAvg
            // 
            this.txtInterAvg.Border.BottomColor = System.Drawing.Color.Black;
            this.txtInterAvg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterAvg.Border.LeftColor = System.Drawing.Color.Black;
            this.txtInterAvg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterAvg.Border.RightColor = System.Drawing.Color.Black;
            this.txtInterAvg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterAvg.Border.TopColor = System.Drawing.Color.Black;
            this.txtInterAvg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtInterAvg.DataField = "InterWaste";
            this.txtInterAvg.Height = 0.1875F;
            this.txtInterAvg.Left = 1.9375F;
            this.txtInterAvg.Name = "txtInterAvg";
            this.txtInterAvg.OutputFormat = resources.GetString("txtInterAvg.OutputFormat");
            this.txtInterAvg.Style = "text-align: right; font-weight: bold; ";
            this.txtInterAvg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
            this.txtInterAvg.SummaryGroup = "gpWeeklyTabular";
            this.txtInterAvg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtInterAvg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtInterAvg.Text = null;
            this.txtInterAvg.Top = 0.5625F;
            this.txtInterAvg.Width = 1.125F;
            // 
            // txtTotalAvg
            // 
            this.txtTotalAvg.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalAvg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalAvg.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalAvg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalAvg.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalAvg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalAvg.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalAvg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalAvg.DataField = "TotalWaste";
            this.txtTotalAvg.Height = 0.1875F;
            this.txtTotalAvg.Left = 5.5F;
            this.txtTotalAvg.Name = "txtTotalAvg";
            this.txtTotalAvg.OutputFormat = resources.GetString("txtTotalAvg.OutputFormat");
            this.txtTotalAvg.Style = "text-align: right; font-weight: bold; ";
            this.txtTotalAvg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
            this.txtTotalAvg.SummaryGroup = "gpWeeklyTabular";
            this.txtTotalAvg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtTotalAvg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtTotalAvg.Text = null;
            this.txtTotalAvg.Top = 0.5625F;
            this.txtTotalAvg.Width = 1.125F;
            // 
            // txtPreTotal
            // 
            this.txtPreTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPreTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPreTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtPreTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtPreTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreTotal.DataField = "PreWaste";
            this.txtPreTotal.Height = 0.1875F;
            this.txtPreTotal.Left = 3.125F;
            this.txtPreTotal.Name = "txtPreTotal";
            this.txtPreTotal.OutputFormat = resources.GetString("txtPreTotal.OutputFormat");
            this.txtPreTotal.Style = "text-align: right; font-weight: bold; ";
            this.txtPreTotal.SummaryGroup = "gpWeeklyTabular";
            this.txtPreTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtPreTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtPreTotal.Text = null;
            this.txtPreTotal.Top = 0.0625F;
            this.txtPreTotal.Width = 1.125F;
            // 
            // txtPostTotal
            // 
            this.txtPostTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPostTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPostTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtPostTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtPostTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostTotal.DataField = "PostWaste";
            this.txtPostTotal.Height = 0.1875F;
            this.txtPostTotal.Left = 4.3125F;
            this.txtPostTotal.Name = "txtPostTotal";
            this.txtPostTotal.OutputFormat = resources.GetString("txtPostTotal.OutputFormat");
            this.txtPostTotal.Style = "text-align: right; font-weight: bold; ";
            this.txtPostTotal.SummaryGroup = "gpWeeklyTabular";
            this.txtPostTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtPostTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtPostTotal.Text = null;
            this.txtPostTotal.Top = 0.0625F;
            this.txtPostTotal.Width = 1.125F;
            // 
            // txtPreAvg
            // 
            this.txtPreAvg.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPreAvg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreAvg.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPreAvg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreAvg.Border.RightColor = System.Drawing.Color.Black;
            this.txtPreAvg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreAvg.Border.TopColor = System.Drawing.Color.Black;
            this.txtPreAvg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPreAvg.DataField = "PreWaste";
            this.txtPreAvg.Height = 0.1875F;
            this.txtPreAvg.Left = 3.125F;
            this.txtPreAvg.Name = "txtPreAvg";
            this.txtPreAvg.OutputFormat = resources.GetString("txtPreAvg.OutputFormat");
            this.txtPreAvg.Style = "text-align: right; font-weight: bold; ";
            this.txtPreAvg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
            this.txtPreAvg.SummaryGroup = "gpWeeklyTabular";
            this.txtPreAvg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtPreAvg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtPreAvg.Text = null;
            this.txtPreAvg.Top = 0.5625F;
            this.txtPreAvg.Width = 1.125F;
            // 
            // txtPostAvg
            // 
            this.txtPostAvg.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPostAvg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostAvg.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPostAvg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostAvg.Border.RightColor = System.Drawing.Color.Black;
            this.txtPostAvg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostAvg.Border.TopColor = System.Drawing.Color.Black;
            this.txtPostAvg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPostAvg.DataField = "PostWaste";
            this.txtPostAvg.Height = 0.1875F;
            this.txtPostAvg.Left = 4.3125F;
            this.txtPostAvg.Name = "txtPostAvg";
            this.txtPostAvg.OutputFormat = resources.GetString("txtPostAvg.OutputFormat");
            this.txtPostAvg.Style = "text-align: right; font-weight: bold; ";
            this.txtPostAvg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
            this.txtPostAvg.SummaryGroup = "gpWeeklyTabular";
            this.txtPostAvg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtPostAvg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtPostAvg.Text = null;
            this.txtPostAvg.Top = 0.5625F;
            this.txtPostAvg.Width = 1.125F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0.6875F;
            this.line3.LineWeight = 3F;
            this.line3.Name = "line3";
            this.line3.Top = 0.25F;
            this.line3.Width = 6F;
            this.line3.X1 = 0.6875F;
            this.line3.X2 = 6.6875F;
            this.line3.Y1 = 0.25F;
            this.line3.Y2 = 0.25F;
            // 
            // rptWeeklyTabular
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
            this.PrintWidth = 6.947917F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.gpWeeklyTabular);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptWeeklyTabular_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreconsumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfWeeks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.GroupHeader gpWeeklyTabular;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.TextBox lblFooter;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.TextBox lblWarning;
        private DataDynamics.ActiveReports.TextBox txtSite;
        private DataDynamics.ActiveReports.TextBox txtPreconsumer;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label lblPost;
        private DataDynamics.ActiveReports.Label lblTotal;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.TextBox txtInterTotal;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.TextBox txtNumOfWeeks;
        private DataDynamics.ActiveReports.TextBox txtTotalTotal;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.TextBox txtInterAvg;
        private DataDynamics.ActiveReports.TextBox txtTotalAvg;
        private DataDynamics.ActiveReports.TextBox txtWeekStart;
        private DataDynamics.ActiveReports.TextBox txtInter;
        private DataDynamics.ActiveReports.TextBox txtTotal;
        private DataDynamics.ActiveReports.Label lblInter;
        private DataDynamics.ActiveReports.Label lblPre;
        private DataDynamics.ActiveReports.TextBox txtPre;
        private DataDynamics.ActiveReports.TextBox txtPost;
        private DataDynamics.ActiveReports.TextBox txtPreTotal;
        private DataDynamics.ActiveReports.TextBox txtPostTotal;
        private DataDynamics.ActiveReports.TextBox txtPreAvg;
        private DataDynamics.ActiveReports.TextBox txtPostAvg;
    }
}
