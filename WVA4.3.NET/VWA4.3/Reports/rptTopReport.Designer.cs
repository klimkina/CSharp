namespace Reports
{
    /// <summary>
    /// Summary description for rptTopReport.
    /// </summary>
    partial class rptTopReport
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
            DataDynamics.ActiveReports.Chart.ChartArea chartArea1 = new DataDynamics.ActiveReports.Chart.ChartArea();
            DataDynamics.ActiveReports.Chart.Axis axis1 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis2 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis3 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis4 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis5 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource1 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptTopReport));
            DataDynamics.ActiveReports.Chart.Series series1 = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Title title1 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource2 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.lblRank = new DataDynamics.ActiveReports.Label();
            this.txtWeight = new DataDynamics.ActiveReports.TextBox();
            this.txtWaste = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.chartControl1 = new DataDynamics.ActiveReports.ChartControl();
            this.lblCost = new DataDynamics.ActiveReports.Label();
            this.lblName = new DataDynamics.ActiveReports.Label();
            this.lblTrans = new DataDynamics.ActiveReports.Label();
            this.lblWeight = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWaste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtName,
            this.lblRank,
            this.txtWeight,
            this.txtWaste});
            this.detail.Height = 0.1979167F;
            this.detail.KeepTogether = true;
            this.detail.CanGrow = true;
            this.detail.CanShrink = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtName
            // 
            this.txtName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.RightColor = System.Drawing.Color.Black;
            this.txtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.TopColor = System.Drawing.Color.Black;
            this.txtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.DataField = "Name";
            this.txtName.Height = 0.1875F;
            this.txtName.Left = 0.3125F;
            this.txtName.Name = "txtName";
            this.txtName.Style = "";
            this.txtName.Text = "textBox1";
            this.txtName.Top = 0F;
            this.txtName.Width = 1.0625F;
            // 
            // lblRank
            // 
            this.lblRank.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.RightColor = System.Drawing.Color.Black;
            this.lblRank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.TopColor = System.Drawing.Color.Black;
            this.lblRank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Height = 0.1875F;
            this.lblRank.HyperLink = null;
            this.lblRank.Left = 0F;
            this.lblRank.Name = "lblRank";
            this.lblRank.Style = "";
            this.lblRank.Text = "Rank";
            this.lblRank.Top = 0F;
            this.lblRank.Width = 0.1875F;
            // 
            // txtWeight
            // 
            this.txtWeight.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWeight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWeight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.RightColor = System.Drawing.Color.Black;
            this.txtWeight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.TopColor = System.Drawing.Color.Black;
            this.txtWeight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.DataField = "Weights";
            this.txtWeight.Height = 0.1875F;
            this.txtWeight.Left = 1.375F;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.OutputFormat = resources.GetString("txtWeight.OutputFormat");
            this.txtWeight.Style = "";
            this.txtWeight.Text = "textBox1";
            this.txtWeight.Top = 0F;
            this.txtWeight.Width = 0.8125F;
            // 
            // txtWaste
            // 
            this.txtWaste.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWaste.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWaste.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWaste.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWaste.Border.RightColor = System.Drawing.Color.Black;
            this.txtWaste.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWaste.Border.TopColor = System.Drawing.Color.Black;
            this.txtWaste.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWaste.DataField = "Waste";
            this.txtWaste.Height = 0.1875F;
            this.txtWaste.Left = 2.1875F;
            this.txtWaste.Name = "txtWaste";
            this.txtWaste.OutputFormat = resources.GetString("txtWaste.OutputFormat");
            this.txtWaste.Style = "";
            this.txtWaste.Text = "textBox1";
            this.txtWaste.Top = 0F;
            this.txtWaste.Width = 0.8125F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.CanShrink = true;
            this.groupHeader1.ColumnGroupKeepTogether = true;
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.chartControl1,
            this.lblCost,
            this.lblName,
            this.lblTrans,
            this.lblWeight});
            this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.groupHeader1.Height = 2.5F;
            this.groupHeader1.KeepTogether = true;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // chartControl1
            // 
            this.chartControl1.AutoRefresh = true;
            this.chartControl1.Border.BottomColor = System.Drawing.Color.Black;
            this.chartControl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chartControl1.Border.LeftColor = System.Drawing.Color.Black;
            this.chartControl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chartControl1.Border.RightColor = System.Drawing.Color.Black;
            this.chartControl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chartControl1.Border.TopColor = System.Drawing.Color.Black;
            this.chartControl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            chartArea1.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.Graphics;
            axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical;
            axis1.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), 45F);
            axis1.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1, 0F, false);
            axis1.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis1.SmartLabels = false;
            axis1.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelsGap = 0;
            axis2.LabelsVisible = false;
            axis2.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis2.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis2.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis2.Position = 0;
            axis2.TickOffset = 0;
            axis2.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.Visible = false;
            axis3.DisplayScale = true;
            axis3.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis3.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis3.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis3.Position = 0;
            axis3.SmartLabels = false;
            axis3.StaggerLabels = true;
            axis3.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), -90F);
            axis4.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis4.LabelsVisible = false;
            axis4.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis4.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis4.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis4.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis4.Visible = false;
            axis5.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis5.LabelsGap = 0;
            axis5.LabelsVisible = false;
            axis5.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis5.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis5.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0F, false);
            axis5.Position = 0;
            axis5.TickOffset = 0;
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
            this.chartControl1.ChartAreas.AddRange(new DataDynamics.ActiveReports.Chart.ChartArea[] {
            chartArea1});
            this.chartControl1.ChartBorder = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
	//        //oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=x;Persist Security Info=False";
	//        oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Mila\\Projects\\WVA40\\Temp\\vw" +
	//"a4_Business_db.mdb;Persist Security Info=False";
	//        oleDBDataSource1.SQL = resources.GetString("oleDBDataSource1.SQL");
	//        this.chartControl1.DataSource = oleDBDataSource1;
			//oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=x;Persist Security Info=False";
    //        oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Mila\\Projects\\WVA40\\Temp\\vw" +
    //"a4_Business_db.mdb;Persist Security Info=False";
    //        oleDBDataSource1.SQL = resources.GetString("oleDBDataSource1.SQL");
    //        this.chartControl1.DataSource = oleDBDataSource1;

            this.chartControl1.Height = 2.3125F;
            this.chartControl1.Left = 0F;
            this.chartControl1.Name = "chartControl1";
            series1.AxisX = axis1;
            series1.AxisY = axis3;
            series1.ChartArea = chartArea1;
            series1.Legend = null;
            series1.LegendText = "";
            series1.Name = "Series1";
            series1.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            new DataDynamics.ActiveReports.Chart.KeyValuePair("Marker", new DataDynamics.ActiveReports.Chart.Marker(6, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 6F)), "{Value:#.00}", DataDynamics.ActiveReports.Chart.Alignment.Top)))});
            series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
            series1.ValueMembersY = "Waste";
            series1.ValueMemberX = "Name";
            this.chartControl1.Series.AddRange(new DataDynamics.ActiveReports.Chart.Series[] {
            series1});
            title1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Top;
            title1.Backdrop = new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.Black, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
            title1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 7, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title1.DockArea = chartArea1;
            title1.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold));
            title1.Name = "footer";
            title1.Text = "Top 10 Stations";
            this.chartControl1.Titles.AddRange(new DataDynamics.ActiveReports.Chart.Title[] {
            title1});
            this.chartControl1.Top = 0F;
            this.chartControl1.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting;
            this.chartControl1.Width = 3F;
            // 
            // lblCost
            // 
            this.lblCost.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCost.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCost.Border.RightColor = System.Drawing.Color.Black;
            this.lblCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCost.Border.TopColor = System.Drawing.Color.Black;
            this.lblCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCost.Height = 0.1875F;
            this.lblCost.HyperLink = null;
            this.lblCost.Left = 2.375F;
            this.lblCost.Name = "lblCost";
            this.lblCost.Style = "color: Navy; font-weight: bold; ";
            this.lblCost.Text = "Cost, $";
            this.lblCost.Top = 2.3125F;
            this.lblCost.Visible = false;
            this.lblCost.Width = 0.64F;
            // 
            // lblName
            // 
            this.lblName.Border.BottomColor = System.Drawing.Color.Black;
            this.lblName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblName.Border.LeftColor = System.Drawing.Color.Black;
            this.lblName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblName.Border.RightColor = System.Drawing.Color.Black;
            this.lblName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblName.Border.TopColor = System.Drawing.Color.Black;
            this.lblName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblName.Height = 0.1875F;
            this.lblName.HyperLink = null;
            this.lblName.Left = 0.3125F;
            this.lblName.Name = "lblName";
            this.lblName.Style = "color: Navy; font-weight: bold; ";
            this.lblName.Text = "Employee";
            this.lblName.Top = 2.3125F;
            this.lblName.Visible = false;
            this.lblName.Width = 1F;
            // 
            // lblTrans
            // 
            this.lblTrans.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTrans.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTrans.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTrans.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTrans.Border.RightColor = System.Drawing.Color.Black;
            this.lblTrans.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTrans.Border.TopColor = System.Drawing.Color.Black;
            this.lblTrans.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTrans.Height = 0.1875F;
            this.lblTrans.HyperLink = null;
            this.lblTrans.Left = 1.3125F;
            this.lblTrans.Name = "lblTrans";
            this.lblTrans.Style = "color: Navy; font-weight: bold; ";
            this.lblTrans.Text = "Trans";
            this.lblTrans.Top = 2.3125F;
            this.lblTrans.Visible = false;
            this.lblTrans.Width = 0.4375F;
            // 
            // lblWeight
            // 
            this.lblWeight.Border.BottomColor = System.Drawing.Color.Black;
            this.lblWeight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWeight.Border.LeftColor = System.Drawing.Color.Black;
            this.lblWeight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWeight.Border.RightColor = System.Drawing.Color.Black;
            this.lblWeight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWeight.Border.TopColor = System.Drawing.Color.Black;
            this.lblWeight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWeight.Height = 0.1875F;
            this.lblWeight.HyperLink = null;
            this.lblWeight.Left = 1.75F;
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Style = "color: Navy; font-weight: bold; ";
            this.lblWeight.Text = "Weight";
            this.lblWeight.Top = 2.3125F;
            this.lblWeight.Visible = false;
            this.lblWeight.Width = 0.64F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // rptTopReport
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
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptTopReport_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWaste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblRank;
        private DataDynamics.ActiveReports.TextBox txtName;
        private DataDynamics.ActiveReports.TextBox txtWeight;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.ChartControl chartControl1;
        private DataDynamics.ActiveReports.TextBox txtWaste;
        private DataDynamics.ActiveReports.Label lblCost;
        private DataDynamics.ActiveReports.Label lblName;
        private DataDynamics.ActiveReports.Label lblTrans;
        private DataDynamics.ActiveReports.Label lblWeight;
    }
}
