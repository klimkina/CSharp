namespace Reports
{
    /// <summary>
    /// Summary description for rptComparision.
    /// </summary>
    partial class rptComparision
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
            DataDynamics.ActiveReports.Chart.ChartArea chartArea1 = new DataDynamics.ActiveReports.Chart.ChartArea();
            DataDynamics.ActiveReports.Chart.Axis axis1 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis2 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis3 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis4 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Axis axis5 = new DataDynamics.ActiveReports.Chart.Axis();
            DataDynamics.ActiveReports.Chart.Legend legend1 = new DataDynamics.ActiveReports.Chart.Legend();
            DataDynamics.ActiveReports.Chart.Title title1 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Title title2 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Series series1 = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Series series2 = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Title title3 = new DataDynamics.ActiveReports.Chart.Title();
            DataDynamics.ActiveReports.Chart.Title title4 = new DataDynamics.ActiveReports.Chart.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptComparision));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.chartControl1 = new DataDynamics.ActiveReports.ChartControl();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.txtFilter = new DataDynamics.ActiveReports.TextBox();
            this.lblWarning = new DataDynamics.ActiveReports.TextBox();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle});
            this.pageHeader.Height = 0.5F;
            this.pageHeader.Name = "pageHeader";
            // 
            // lblTitle
            // 
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "background-color: Blue; color: White; font-size: 16pt; font-weight: bold; text-al" +
    "ign: center; vertical-align: middle";
            this.lblTitle.Text = "Comparison Report for";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 9.4375F;
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
            this.txtSubTitle.Width = 9.4375F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.chartControl1});
            this.detail.Height = 5.624503F;
            this.detail.Name = "detail";
            // 
            // chartControl1
            // 
            this.chartControl1.AutoRefresh = true;
            chartArea1.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.Graphics;
            axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical;
            axis1.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F), 45F);
            axis1.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1D, 1F, true);
            axis1.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis1.Title = "Day of Week";
            axis1.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.LabelsGap = 0;
            axis2.LabelsVisible = false;
            axis2.Line = new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None);
            axis2.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis2.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis2.Position = 0D;
            axis2.TickOffset = 0D;
            axis2.TitleFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis2.Visible = false;
            axis3.DisplayScale = true;
            axis3.LabelFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            axis3.MajorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Black, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.Dot), 0D, 5F, true);
            axis3.MinorTick = new DataDynamics.ActiveReports.Chart.Tick(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0D, 0F, false);
            axis3.Position = 0D;
            axis3.SmartLabels = false;
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
            chartArea1.WallXY = new DataDynamics.ActiveReports.Chart.PlaneItem(new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(System.Drawing.Color.White, ((byte)(56))));
            chartArea1.WallYZ = new DataDynamics.ActiveReports.Chart.PlaneItem(new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), ((byte)(0))));
            this.chartControl1.ChartAreas.AddRange(new DataDynamics.ActiveReports.Chart.ChartArea[] {
            chartArea1});
            this.chartControl1.ChartBorder = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            this.chartControl1.Height = 5.5625F;
            this.chartControl1.Left = 0.0625F;
            legend1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Top;
            legend1.Backdrop = new DataDynamics.ActiveReports.Chart.BackdropItem(System.Drawing.Color.White, ((byte)(128)));
            legend1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(), 0, System.Drawing.Color.Black);
            legend1.DockArea = chartArea1;
            title1.Backdrop = new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, null, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched);
            title1.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
            title1.DockArea = null;
            title1.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title1.Name = "";
            title1.Text = "";
            legend1.Footer = title1;
            title2.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 2), 0, System.Drawing.Color.Black);
            title2.DockArea = null;
            title2.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title2.Name = "";
            title2.Text = "Legend";
            legend1.Header = title2;
            legend1.LabelsFont = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            legend1.Name = "defaultLegend";
            this.chartControl1.Legends.AddRange(new DataDynamics.ActiveReports.Chart.Legend[] {
            legend1});
            this.chartControl1.Name = "chartControl1";
            series1.AxisX = axis1;
            series1.AxisY = axis3;
            series1.ChartArea = chartArea1;
            series1.Legend = legend1;
            series1.LegendText = "";
            series1.Name = "Basic Week";
            series1.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            new DataDynamics.ActiveReports.Chart.KeyValuePair("Marker", new DataDynamics.ActiveReports.Chart.Marker(6, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 6F)), "{Value:$#,##0}", DataDynamics.ActiveReports.Chart.Alignment.Top)))});
            series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
            series1.ValueMembersY = null;
            series1.ValueMemberX = null;
            series2.AxisX = axis1;
            series2.AxisY = axis3;
            series2.ChartArea = chartArea1;
            series2.Legend = legend1;
            series2.LegendText = "";
            series2.Name = "ComparisionWeek";
            series2.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            new DataDynamics.ActiveReports.Chart.KeyValuePair("Marker", new DataDynamics.ActiveReports.Chart.Marker(6, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 6F)), "{Value:$#,##0}", DataDynamics.ActiveReports.Chart.Alignment.Top)))});
            series2.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
            series2.ValueMembersY = null;
            series2.ValueMemberX = null;
            this.chartControl1.Series.AddRange(new DataDynamics.ActiveReports.Chart.Series[] {
            series1,
            series2});
            title3.DockArea = chartArea1;
            title3.Name = "Title1";
            title4.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center;
            title4.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Black, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None));
            title4.DockArea = null;
            title4.Docking = DataDynamics.ActiveReports.Chart.DockType.Bottom;
            title4.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F));
            title4.Name = "footer";
            title4.Text = "DB";
            this.chartControl1.Titles.AddRange(new DataDynamics.ActiveReports.Chart.Title[] {
            title3,
            title4});
            this.chartControl1.Top = 0F;
            this.chartControl1.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting;
            this.chartControl1.Width = 9.3125F;
            // 
            // pageFooter
            // 
            this.pageFooter.CanShrink = true;
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.imgLeanPath,
            this.txtFilter,
            this.lblWarning,
            this.lblDB});
            this.pageFooter.Height = 0.5625F;
            this.pageFooter.Name = "pageFooter";
            // 
            // txtFilter
            // 
            this.txtFilter.Height = 0.1875F;
            this.txtFilter.Left = 0F;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Style = "font-family: Microsoft Sans Serif; font-size: 8pt; font-style: normal; ddo-char-s" +
    "et: 204";
            this.txtFilter.Text = null;
            this.txtFilter.Top = 0.1875F;
            this.txtFilter.Width = 8.4375F;
            // 
            // lblWarning
            // 
            this.lblWarning.Height = 0.1875F;
            this.lblWarning.Left = 0F;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Style = "color: Red; font-family: Microsoft Sans Serif; font-size: 10pt; font-style: norma" +
    "l; font-weight: bold; ddo-char-set: 204";
            this.lblWarning.Text = null;
            this.lblWarning.Top = 0F;
            this.lblWarning.Width = 8.4375F;
            // 
            // lblDB
            // 
            this.lblDB.Height = 0.1875F;
            this.lblDB.Left = 0F;
            this.lblDB.Name = "lblDB";
            this.lblDB.Style = "font-size: 8pt";
            this.lblDB.Text = null;
            this.lblDB.Top = 0.375F;
            this.lblDB.Width = 8.437F;
            // 
            // imgLogo
            // 
            this.imgLogo.Height = 0.3125F;
            this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
            this.imgLogo.Left = 0F;
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLogo.Top = 0F;
            this.imgLogo.Width = 0.625F;
            // 
            // imgLeanPath
            // 
            this.imgLeanPath.Height = 0.3125F;
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 8.625F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.0625F;
            this.imgLeanPath.Width = 0.625F;
            // 
            // rptComparision
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
            this.PrintWidth = 9.46875F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-size: 14pt; font-weight: bold; font-style: italic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptComparision_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ChartControl chartControl1;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.TextBox txtFilter;
        private DataDynamics.ActiveReports.TextBox lblWarning;
        private DataDynamics.ActiveReports.TextBox lblDB;
    }
}