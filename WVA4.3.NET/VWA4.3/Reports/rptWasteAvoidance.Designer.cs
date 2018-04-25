namespace Reports
{
    /// <summary>
    /// Summary description for rptWasteAvoidance.
    /// </summary>
    partial class rptWasteAvoidance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptWasteAvoidance));
            DataDynamics.ActiveReports.Chart.ChartArea chartArea1 = new DataDynamics.ActiveReports.Chart.ChartArea();
            DataDynamics.ActiveReports.Chart.Axis axis1 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis2 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis3 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis4 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis5 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Series series1 = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Title title1 = new DataDynamics.ActiveReports.Chart.Title();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtSite = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.txtPeriod = new DataDynamics.ActiveReports.TextBox();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.txtBLDollars = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.lblMonth = new DataDynamics.ActiveReports.Label();
            this.txtDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtVariance = new DataDynamics.ActiveReports.TextBox();
            this.txtCumulative = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.txtFilter = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.ghWasteAvoidance = new DataDynamics.ActiveReports.GroupHeader();
            this.lblTitleMonth = new DataDynamics.ActiveReports.Label();
            this.lblDollars = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.txtError = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.chartControl2 = new DataDynamics.ActiveReports.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCumulative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSubTitle,
            this.txtSite,
            this.textBox1,
            this.textBox3,
            this.txtPeriod,
            this.imgLogo,
            this.lblTitle,
            this.textBox2,
            this.txtBLDollars});
            this.pageHeader.Height = 1.344167F;
            this.pageHeader.Name = "pageHeader";
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.CanShrink = true;
            this.txtSubTitle.Height = 0.1875F;
            this.txtSubTitle.Left = 0F;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Style = "text-align: center";
            this.txtSubTitle.Text = null;
            this.txtSubTitle.Top = 0.3125F;
            this.txtSubTitle.Width = 9.073F;
            // 
            // txtSite
            // 
            this.txtSite.Height = 0.1875F;
            this.txtSite.Left = 1F;
            this.txtSite.Name = "txtSite";
            this.txtSite.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 204";
            this.txtSite.Text = "Site";
            this.txtSite.Top = 0.75F;
            this.txtSite.Width = 8.073F;
            // 
            // textBox1
            // 
            this.textBox1.Height = 0.1979167F;
            this.textBox1.Left = 0F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-weight: bold";
            this.textBox1.Text = "Facility: ";
            this.textBox1.Top = 0.75F;
            this.textBox1.Width = 1F;
            // 
            // textBox3
            // 
            this.textBox3.Height = 0.1979167F;
            this.textBox3.Left = 0F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-weight: bold";
            this.textBox3.Text = "Period:";
            this.textBox3.Top = 0.9375F;
            this.textBox3.Width = 1F;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Height = 0.1875F;
            this.txtPeriod.Left = 1F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "font-weight: bold";
            this.txtPeriod.Text = null;
            this.txtPeriod.Top = 0.9375F;
            this.txtPeriod.Width = 5.5F;
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
            // lblTitle
            // 
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.625F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "background-color: Blue; color: White; font-size: 16pt; font-weight: bold; text-al" +
    "ign: center; vertical-align: middle";
            this.lblTitle.Text = "Waste Avoidance Report";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 8.448001F;
            // 
            // textBox2
            // 
            this.textBox2.Height = 0.1979167F;
            this.textBox2.Left = 0F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-weight: bold";
            this.textBox2.Text = "Baseline Value:";
            this.textBox2.Top = 1.14F;
            this.textBox2.Width = 1.093F;
            // 
            // txtBLDollars
            // 
            this.txtBLDollars.CanGrow = false;
            this.txtBLDollars.Height = 0.1875F;
            this.txtBLDollars.Left = 1.165F;
            this.txtBLDollars.Name = "txtBLDollars";
            this.txtBLDollars.OutputFormat = resources.GetString("txtBLDollars.OutputFormat");
            this.txtBLDollars.Style = "font-family: Arial; font-size: 9.75pt; font-weight: bold; text-align: left; ddo-c" +
    "har-set: 204";
            this.txtBLDollars.Text = "$";
            this.txtBLDollars.Top = 1.15F;
            this.txtBLDollars.Width = 1.115F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblMonth,
            this.txtDollars,
            this.txtVariance,
            this.txtCumulative});
            this.detail.Height = 0.1875F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // lblMonth
            // 
            this.lblMonth.DataField = "yDate";
            this.lblMonth.Height = 0.1875F;
            this.lblMonth.HyperLink = null;
            this.lblMonth.Left = 0F;
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Style = "";
            this.lblMonth.Text = "Month";
            this.lblMonth.Top = 0F;
            this.lblMonth.Width = 0.896F;
            // 
            // txtDollars
            // 
            this.txtDollars.DataField = "Dollars";
            this.txtDollars.Height = 0.1875F;
            this.txtDollars.Left = 0.9670001F;
            this.txtDollars.Name = "txtDollars";
            this.txtDollars.OutputFormat = resources.GetString("txtDollars.OutputFormat");
            this.txtDollars.Style = "font-family: Arial; font-size: 9.75pt; font-weight: normal; text-align: right; dd" +
    "o-char-set: 204";
            this.txtDollars.Text = "$";
            this.txtDollars.Top = 0F;
            this.txtDollars.Width = 0.948F;
            // 
            // txtVariance
            // 
            this.txtVariance.DataField = "Variance";
            this.txtVariance.Height = 0.1875F;
            this.txtVariance.Left = 2.068F;
            this.txtVariance.Name = "txtVariance";
            this.txtVariance.OutputFormat = resources.GetString("txtVariance.OutputFormat");
            this.txtVariance.Style = "font-family: Arial; font-size: 9.75pt; font-weight: normal; text-align: right; dd" +
    "o-char-set: 204";
            this.txtVariance.Text = "Variance";
            this.txtVariance.Top = 0F;
            this.txtVariance.Width = 1.146F;
            // 
            // txtCumulative
            // 
            this.txtCumulative.CanGrow = false;
            this.txtCumulative.DataField = "Variance";
            this.txtCumulative.Height = 0.1875F;
            this.txtCumulative.Left = 3.309F;
            this.txtCumulative.Name = "txtCumulative";
            this.txtCumulative.OutputFormat = resources.GetString("txtCumulative.OutputFormat");
            this.txtCumulative.Style = "font-family: Arial; font-size: 9.75pt; font-weight: normal; text-align: right; dd" +
    "o-char-set: 204";
            this.txtCumulative.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.txtCumulative.Text = "Cumulative";
            this.txtCumulative.Top = 0F;
            this.txtCumulative.Width = 1.053F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblDB,
            this.txtFilter,
            this.imgLeanPath});
            this.pageFooter.Height = 0.375F;
            this.pageFooter.Name = "pageFooter";
            // 
            // lblDB
            // 
            this.lblDB.Height = 0.1875F;
            this.lblDB.Left = 0F;
            this.lblDB.Name = "lblDB";
            this.lblDB.Style = "font-size: 8pt";
            this.lblDB.Text = null;
            this.lblDB.Top = 0.1875F;
            this.lblDB.Width = 8.406F;
            // 
            // txtFilter
            // 
            this.txtFilter.Height = 0.1875F;
            this.txtFilter.Left = 0F;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Style = "font-size: 8pt; font-style: italic";
            this.txtFilter.Text = null;
            this.txtFilter.Top = 0F;
            this.txtFilter.Width = 8.406F;
            // 
            // imgLeanPath
            // 
            this.imgLeanPath.Height = 0.3125F;
            this.imgLeanPath.HyperLink = null;
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 8.46F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0F;
            this.imgLeanPath.Width = 0.625F;
            // 
            // ghWasteAvoidance
            // 
            this.ghWasteAvoidance.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitleMonth,
            this.lblDollars,
            this.label7,
            this.label8});
            this.ghWasteAvoidance.Height = 0.2083333F;
            this.ghWasteAvoidance.Name = "ghWasteAvoidance";
            // 
            // lblTitleMonth
            // 
            this.lblTitleMonth.Height = 0.1875F;
            this.lblTitleMonth.HyperLink = null;
            this.lblTitleMonth.Left = 0F;
            this.lblTitleMonth.Name = "lblTitleMonth";
            this.lblTitleMonth.Style = "color: Navy; font-weight: bold; text-align: center";
            this.lblTitleMonth.Text = "Month";
            this.lblTitleMonth.Top = 0F;
            this.lblTitleMonth.Width = 0.896F;
            // 
            // lblDollars
            // 
            this.lblDollars.Height = 0.1875F;
            this.lblDollars.HyperLink = null;
            this.lblDollars.Left = 0.9670001F;
            this.lblDollars.Name = "lblDollars";
            this.lblDollars.Style = "color: Navy; font-weight: bold; text-align: center";
            this.lblDollars.Text = "Dollars";
            this.lblDollars.Top = 0F;
            this.lblDollars.Width = 0.948F;
            // 
            // label7
            // 
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = null;
            this.label7.Left = 2.068F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Navy; font-weight: bold; text-align: center";
            this.label7.Text = "Change";
            this.label7.Top = 0F;
            this.label7.Width = 1.155797F;
            // 
            // label8
            // 
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = null;
            this.label8.Left = 3.309F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Navy; font-weight: bold; text-align: center";
            this.label8.Text = "Total";
            this.label8.Top = 0F;
            this.label8.Width = 1.131577F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.CanShrink = true;
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.line1,
            this.txtError,
            this.textBox4,
            this.textBox7,
            this.chartControl2});
            this.groupFooter1.Height = 5.229667F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // label6
            // 
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = null;
            this.label6.Left = 0F;
            this.label6.Name = "label6";
            this.label6.Style = "font-family: Arial; font-size: 9.75pt; font-weight: bold; vertical-align: middle;" +
    " ddo-char-set: 204";
            this.label6.Text = "Total: ";
            this.label6.Top = 0.26F;
            this.label6.Width = 0.5F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.25F;
            this.line1.Width = 5.802F;
            this.line1.X1 = 0F;
            this.line1.X2 = 5.802F;
            this.line1.Y1 = 0.25F;
            this.line1.Y2 = 0.25F;
            // 
            // txtError
            // 
            this.txtError.CanShrink = true;
            this.txtError.Height = 0.1875F;
            this.txtError.Left = 0F;
            this.txtError.Name = "txtError";
            this.txtError.Style = "color: Red";
            this.txtError.Text = null;
            this.txtError.Top = 0F;
            this.txtError.Width = 5.802F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "Dollars";
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 1F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-family: Arial; font-size: 9.75pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 204";
            this.textBox4.SummaryGroup = "ghWasteAvoidance";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "TotalDollars";
            this.textBox4.Top = 0.26F;
            this.textBox4.Width = 0.9480002F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "Variance";
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 2.068F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "font-family: Arial; font-size: 9.75pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 204";
            this.textBox7.SummaryGroup = "ghWasteAvoidance";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "TotalVariance";
            this.textBox7.Top = 0.26F;
            this.textBox7.Width = 1.156F;
            // 
            // chartControl2
            // 
            this.chartControl2.AutoRefresh = true;
            chartArea1.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.Graphics;
            axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical;
            axis1.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), 45F);
            axis1.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1D, 1F, true);
            axis1.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis1.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelsGap = 0;
            axis2.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis2.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis2.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis2.Position = 0D;
            axis2.TickOffset = 0D;
            axis2.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis3.DisplayScale = true;
            axis3.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis3.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Black, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.Dot), 0D, 5F, true);
            axis3.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis3.Position = 0D;
            axis3.SmartLabels = false;
            axis3.StaggerLabels = true;
            axis3.Title = "Waste ($)";
            axis3.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), -90F);
            axis4.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis4.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis4.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis4.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis4.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis4.Visible = false;
            axis5.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis5.LabelsGap = 0;
            axis5.LabelsVisible = false;
            axis5.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis5.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis5.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis5.Position = 0D;
            axis5.TickOffset = 0D;
            axis5.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis5.Visible = false;
            chartArea1.Axes.AddRange(new DataDynamics.ActiveReports.Chart.AxisBase[] {
            axis1,
            axis2,
            axis3,
            axis4,
            axis5});
            chartArea1.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
            chartArea1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            chartArea1.Light = new DataDynamics.ActiveReports.Chart.Light(new DataDynamics.ActiveReports.Chart.Graphics.Point3d(10F, 40F, 20F), DataDynamics.ActiveReports.Chart.LightType.InfiniteDirectional, 0.3F);
            chartArea1.Name = "defaultArea";
            chartArea1.Projection = new DataDynamics.ActiveReports.Chart.Projection(DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal, 0.1F, 0.1F);
            chartArea1.WallXY = new DataDynamics.ActiveReports.Chart.PlaneItem(new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(System.Drawing.Color.White, ((byte)(33))));
            chartArea1.WallYZ = new DataDynamics.ActiveReports.Chart.PlaneItem(new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), ((byte)(0))));
            this.chartControl2.ChartAreas.AddRange(new DataDynamics.ActiveReports.Chart.ChartArea[] {
            chartArea1});
            this.chartControl2.ChartBorder = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            this.chartControl2.Height = 4.721F;
            this.chartControl2.Left = 0F;
            this.chartControl2.Name = "chartControl2";
            series1.AxisX = axis1;
            series1.AxisY = axis3;
            series1.ChartArea = chartArea1;
            series1.Legend = null;
            series1.LegendText = "";
            series1.Name = "Basic Week";
            series1.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            new DataDynamics.ActiveReports.Chart.KeyValuePair("Marker", new DataDynamics.ActiveReports.Chart.Marker(6, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 6F)), "{Value:$#,##0}", DataDynamics.ActiveReports.Chart.Alignment.Top)))});
            series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
            series1.ValueMembersY = null;
            series1.ValueMemberX = null;
            this.chartControl2.Series.AddRange(new DataDynamics.ActiveReports.Chart.Series[] {
            series1});
            title1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center;
            title1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title1.DockArea = chartArea1;
            title1.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title1.Name = "Title1";
            title1.Text = "Calculated Waste Avoidance ";
            this.chartControl2.Titles.AddRange(new DataDynamics.ActiveReports.Chart.Title[] {
            title1});
            this.chartControl2.Top = 0.509F;
            this.chartControl2.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting;
            this.chartControl2.Width = 9.073F;
            // 
            // rptWasteAvoidance
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.114583F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.ghWasteAvoidance);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-size: 14pt; font-weight: bold; font-style: italic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport.FetchEventHandler(this.rptWasteAvoidance_FetchData);
            this.ReportStart += new System.EventHandler(this.rptWasteAvoidance_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCumulative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.TextBox txtSite;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox txtPeriod;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.TextBox txtFilter;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.GroupHeader ghWasteAvoidance;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Label lblTitleMonth;
        private DataDynamics.ActiveReports.Label lblDollars;
        private DataDynamics.ActiveReports.Label lblMonth;
        private DataDynamics.ActiveReports.TextBox txtDollars;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.TextBox txtError;
        private DataDynamics.ActiveReports.TextBox txtVariance;
        private DataDynamics.ActiveReports.TextBox txtCumulative;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox7;
        private DataDynamics.ActiveReports.ChartControl chartControl2;
        private DataDynamics.ActiveReports.TextBox txtBLDollars;
        private DataDynamics.ActiveReports.TextBox textBox2;
    }
}
