using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Reports
{
    /// <summary>
    /// Summary description for SubARTrend.
    /// </summary>
    public partial class rptARTrend : DataDynamics.ActiveReports.ActiveReport
    {
        private const double LOW_TRANS = 0.4;
        public class ARTrendOutput 
        {
            private double _TotalWaste;
            private int _TotalNumOfTrans;
            private bool _IsIncreasing;
            private double _MaxWaste;

            public double TotalWaste
            {
                set { _TotalWaste = value; }
                get { return _TotalWaste; }
            }

            public int TotalNumOfTrans
            {
                set { _TotalNumOfTrans = value; }
                get { return _TotalNumOfTrans; }
            }
            public bool IsIncreasing
            {
                set { _IsIncreasing = value; }
                get { return _IsIncreasing; }
            }
            public double MaxWaste
            {
                set { _MaxWaste = value; }
                get { return _MaxWaste; }
            }
        }
        private UserControls.ReportParameters _InputParameters;
        public UserControls.ReportParameters OutputParameters
        {
            get 
            {
                UserControls.ReportParameters output = new UserControls.ReportParameters();
                output.AddParameter("TotalWaste", _ChartData.Compute("Sum(WasteSum)", "").ToString(),
                     _ChartData.Compute("Sum(WasteSum)", "").ToString(), "Double");
                output.AddParameter("TotalNumOfTrans", _ChartData.Compute("Sum(TransNum)", "").ToString(),
                     _ChartData.Compute("Sum(TransNum)", "").ToString(), "Number");
                output.AddParameter("MaxWaste", _ChartData.Compute("Max(WasteSum)", "").ToString(),
                     _ChartData.Compute("Max(WasteSum)", "").ToString(), "Double");
                output.AddParameter("IsIncreasing", this._IsIncreasing.ToString(),
                     this._IsIncreasing.ToString(), "Boolean");
                return output; 
            }
        }
        
        public rptARTrend(UserControls.ReportParameters parameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
        }
        public rptARTrend()
            : this(new UserControls.ReportParameters())
        { }
        private bool _IsIncreasing;
        private void CreateTrend()
        {
            // calculate values
            double[] arrWaste = new double[_ChartData.Rows.Count];
            double[] arrTransNum = new double[arrWaste.GetLength(0)];
            for (int i = 0; i < arrWaste.GetLength(0); i++)
            {
                arrWaste[i] = double.Parse(_ChartData.Rows[i].ItemArray[0].ToString());
                arrTransNum[i] = double.Parse(_ChartData.Rows[i].ItemArray[1].ToString());
            }
            _IsIncreasing = VWA4Common.VWACommon.CalcTrend(ref arrWaste);
            VWA4Common.VWACommon.CalcTrend(ref arrTransNum);
            // create the series
            DataDynamics.ActiveReports.Chart.Series sWaste = new DataDynamics.ActiveReports.Chart.Series();
            DataDynamics.ActiveReports.Chart.Series sTransNum = new DataDynamics.ActiveReports.Chart.Series();
            sWaste.Type = DataDynamics.ActiveReports.Chart.ChartType.Line3D;
            sTransNum.Type = DataDynamics.ActiveReports.Chart.ChartType.Line3D;
            sWaste.Points.DataBindY(arrWaste);
            sTransNum.Points.DataBindY(arrTransNum);
            sWaste.Name = (bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "Weight" : "WasteCost") + " Trend";
            sTransNum.Name = "# of Trans Trend";
            this.chartControl1.Series.Add(sWaste);
        }
        private void Set3D()
        {
            if (bool.Parse(_InputParameters["Is3D"].ParamValue))
                chartControl1.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal;
            else
                chartControl1.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Identical; 
            for (int i = 0; i < 2; i++)// bars used only for first 2 series
            {
                DataDynamics.ActiveReports.Chart.Series s = this.chartControl1.Series[i];
                if (bool.Parse(this._InputParameters["Is3D"].ParamValue))
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
                else
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar2D;
            }
        }
        private void SetWeight()
        {
            if (bool.Parse(this._InputParameters["IsShowLbs"].ParamValue))
            {
                this.chartControl1.ChartAreas[0].Axes["AxisY"].Title = "Weight, lbs";
                
                this.chartControl1.Series[0].Marker.Label.Format = "{Value:#0.} lb";
            }
            else
            {
                this.chartControl1.ChartAreas[0].Axes["AxisY"].Title = "Waste ($)";
                this.chartControl1.Series[0].Marker.Label.Format = "${Value:#0.}";
            }
        }
        private void SetPeriod()
        {
            this.chartControl1.ChartAreas[0].Axes["AxisX"].Title = _InputParameters["AggregatePeriod"].DisplayValue;
            bool showYear = false;
            if (this._InputParameters["AggregatePeriod"].DisplayValue == "Week") // put different labels for week
            {
                DateTime startDate;
                DateTime.TryParse(this.chartControl1.Series[2].Points[0].XValue.ToString(), out startDate);
                showYear = (startDate.Year != DateTime.Parse(this.chartControl1.Series[2].Points[this.chartControl1.Series[2].Points.Count - 1].XValue.ToString()).Year);
                
                for (int i = 0; i < this.chartControl1.Series[1].Points.Count; i++)
                {
                    DateTime.TryParse(this.chartControl1.Series[2].Points[i].XValue.ToString(), out startDate);
                    this.chartControl1.ChartAreas[0].Axes[0].Labels.Add("wk" + (int.Parse(this.chartControl1.Series[1].Points[i].XValue.ToString()) - 1) + "(" +
                        startDate.ToString("MM/dd" + (showYear ? "/yy" : "")) + ")");
                }
                
            }
            if (this._InputParameters["AggregatePeriod"].DisplayValue == "Day") // put different labels for week
            {
                string temp = this.chartControl1.Series[1].Points[0].XValue.ToString();// date in format yyyymmdd
                temp = temp.Substring(0, 4) + "/" + temp.Substring(4, 2) + "/" + temp.Substring(6, 2);
                DateTime dt = DateTime.Parse(temp);// num of first week
                temp = this.chartControl1.Series[1].Points[this.chartControl1.Series[1].Points.Count - 1].XValue.ToString().Substring(0, 4);// last year
                showYear = (int.Parse(temp) != dt.Year);
                //convert every point to correct format
                for (int i = 0; i < this.chartControl1.Series[1].Points.Count; i++)
                {
                    temp = this.chartControl1.Series[1].Points[i].XValue.ToString();// date in format yyyymmdd
                    temp = temp.Substring(0, 4) + "/" + temp.Substring(4, 2) + "/" + temp.Substring(6, 2);
                    dt = DateTime.Parse(temp);
                    this.chartControl1.ChartAreas[0].Axes[0].Labels.Add((showYear ? dt.Year + "/" : "") + dt.Month + "/" + dt.Day);
                }
            }
        }
        private void SetLogo()
        {
            try
            {
                System.Drawing.Image img;
                if (_InputParameters["IsCustomLogo"] != null && bool.Parse(_InputParameters["IsCustomLogo"].ParamValue)
                    && VWA4Common.GlobalSettings.LogoUpperLeftStream != null)
                {
                    img = System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream);
                    //this.imgLogo.Height = (img.Height / img.VerticalResolution);
                    //this.imgLogo.Width = (img.Width / img.HorizontalResolution);
                    this.imgLogo.Image = img;
                }
                else
                    this.imgLogo.Visible = false;
                if (_InputParameters["IsLeanPathLogo"] != null && bool.Parse(_InputParameters["IsLeanPathLogo"].ParamValue)
                    && VWA4Common.GlobalSettings.LogoLowerRightStream != null)
                {
                    img = System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoLowerRightStream);
                    this.imgLeanPath.Image = img;
                }
                else
                    this.imgLeanPath.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error loading logo: " + ex.Message, "Error loading image from file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetHorizontal()
        {
            if (bool.Parse(_InputParameters["IsHorizontal"].ParamValue))
            {
                for (int i = 0; i < 2; i++)// bars used only for 1 serie
                {
                    DataDynamics.ActiveReports.Chart.Series s = this.chartControl1.Series[i];
                    s.ChartArea.SwapAxesDirection = true;
                    s.AxisX.LabelFont.Angle = 0;
                    s.AxisY.LabelFont.Angle = 45;
                    s.AxisX.TitleFont.Angle = -90;
                    s.AxisY.TitleFont.Angle = 0;
                    if(s.Marker != null)
                        s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                }
            }
        }
        private DataTable _ChartData;
        private void rptARTrend_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            bool isWeek = this._InputParameters["AggregatePeriod"].DisplayValue == "Week";
            _ChartData = new DataTable();
            VWA4Common.VWADBUtils.CheckWeightDates();
            //if (bool.Parse(_InputParameters["IsChartOnly"].ParamValue))
            //    _InputParameters["IsHorizontal"].ParamValue = false.ToString(); //if chart only - don't show horizontal

            string where = _InputParameters["SiteID"].ParamValue == VWA4Common.GlobalSettings.AllSitesValue ? "" : " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if (_InputParameters["Filter"].ParamValue != "")
                if(where == "")
                {
                    where = " WHERE " + _InputParameters["Filter"].ParamValue;
                }
                else
                {
                    where += " AND " + _InputParameters["Filter"].ParamValue;
                }
            string accessAggregate = _InputParameters["AggregatePeriod"].ParamValue;
            string criteria, title_top = " $", end = "";
            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
            {
                criteria = "(Weight - NItems*ContainerWeight)";
                this.chartControl1.Series[0].AxisY.Title = "Waste, lbs.";
                this.chartControl1.Series[0].Marker.Label.Format = "{Value:#} lbs";
                title_top = " ";
                end = " lbs";
            }
            else
            {
                criteria = "WasteCost";
                this.chartControl1.Series[0].AxisY.Title = "Waste ($)";
            }
            int daysOffset = 0;
            //if (this._InputParameters["AggregatePeriod"].DisplayValue == "Week")
            //    daysOffset = (7 - int.Parse(this._InputParameters["FirstDayOfWeek"].ParamValue)) % 7;
            string firstDayOfWeek = VWA4Common.GlobalSettings.FirstDayOfWeek;
            if ((_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.AllSitesValue) && (_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.CurrentSiteID.ToString()))
                firstDayOfWeek = VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(_InputParameters["SiteID"].ParamValue));
            if(isWeek)//for weekly reports adjust VWA first day of week to Access First day of week
                daysOffset = (7 - VWA4Common.VWACommon.NumberOfDayOfWeek(firstDayOfWeek)) % 7;
            string select = "";
            // order depends on horizontal or vertical design but if Chart Only then we ignore it
            bool order = bool.Parse(_InputParameters["IsHorizontal"].ParamValue) && !bool.Parse(_InputParameters["IsChartOnly"].ParamValue);

			string temp1 = _InputParameters["WasteClasses"].ParamValue.ToString();
			string temp2 = VWA4Common.VWACommon.GetWasteClasses();
			bool isWasteClassesUsed = false;// (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += " AND (" + _InputParameters["WasteClasses"].ParamValue.ToString() + " )";
			//else //if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where += " AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")";
             
            if (bool.Parse(this._InputParameters["IsShowEmptyWeeks"].ParamValue))
            {
                select = @"SELECT MAX(WasteValue) AS WasteSum, MAX(TransValue) AS TransNum, MAX(ProportionValue) AS Proportion, wDate, yDate " +
                    (isWeek ? ", dDate " : ", 0 AS dDate") +
                    " FROM (  " +
                    " SELECT SUM(" + criteria + ") as WasteValue, Count(*) as TransValue, TransValue/WasteValue as ProportionValue,  " + 
                    " Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "') as wDate, " +
                    " Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') as yDate " +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate" : "") +
                    " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "" ) +
                    where +
                    " GROUP BY Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'),  " +
                    " Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') " +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))   " : "") +
                    " UNION  (SELECT  0.0001 AS WasteValue, 0.0001 AS TransValue, 0.0001 as Proportion2,  " +
                    " Format([Timestamp] + " + daysOffset + ", '" + accessAggregate + "') as wDate, " +
                    " Format(Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') as yDate  " +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate   " : "") +
                    " FROM WeightDates   " +  
                    " WHERE [Timestamp] >= #" + _InputParameters["StartDate"].ParamValue +
                    "# AND [Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "#" +
                    " GROUP BY Format(Timestamp + " + daysOffset + ", '" + accessAggregate + "'),  " +
                    " Format(Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00')" +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))))) " : ")") +
                    " ) " +
                    " GROUP BY yDate, wDate   " +
                    (isWeek ? ", dDate " : "")+
                    " ORDER BY yDate " + (order ? " DESC;" : " ASC;");
            }
            else
                select = select = @"SELECT SUM(" + criteria + ") as WasteSum, Count(*) as TransNum, TransNum/WasteSum as Proportion, " +
                    " Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "') as wDate, " +
                    " Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') as yDate " +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))), DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate" : ", 0 AS dDate") +
                    " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " + 
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), " +
                    " Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') " +
                    (isWeek ? ", DateAdd('d', -" + (daysOffset +6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy')))) " : "") +
                    @" ORDER BY Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", '" + accessAggregate + "'), '00') " + (order ? " DESC;" : " ASC;");
            _ChartData = VWA4Common.DB.Retrieve(select);

            if (_ChartData.Rows.Count > 0)
            {
				//whatever this is it doesn't work. and was causing the january missing bug
                //foreach (DataRow row in _ChartData.Select("wDate = 1")) { } // remove "zero" weeks from selection
                //    //_ChartData.Rows.Remove(row);
                double max = double.Parse(_ChartData.Compute("Max(WasteSum)", "").ToString());
                
                this.chartControl1.ChartAreas[0].Axes["AxisY"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);

                max = double.Parse(_ChartData.Compute("Max(TransNum)", "").ToString());
               
                this.chartControl1.ChartAreas[0].Axes["AxisY2"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);

                this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));
                this.chartControl1.Series[1].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));

                this.chartControl1.DataSource = _ChartData;
                this.chartControl1.ColorPalette = VWA4Common.VWACommon.GetPalette( _InputParameters["ChartColor"].ParamValue);
                
                if (bool.Parse(_InputParameters["IsShowTrendLines"].ParamValue))
                    CreateTrend();
                Set3D();
                SetWeight();
                SetPeriod();

                if (bool.Parse(_InputParameters["IsShowTrans"].ParamValue))
                {
                    this.chartControl1.Series[1].Visible = true;
                    this.chartControl1.Series[1].AxisY.TitleFont.Angle = -90;
                    this.chartControl1.Series[1].AxisY.Title = "# of Trans";
                    this.chartControl1.Series[1].AxisY.Max = double.Parse(_ChartData.Compute("Max(Proportion)", "").ToString()) *
                            double.Parse(_ChartData.Compute("Max(WasteSum)", "").ToString()) * 1.5;
                }
                DataTable total = VWA4Common.DB.Retrieve(@"SELECT SUM(" + criteria + ") " +
                            " FROM Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey " +
                            " WHERE [Weights.Timestamp] >= #" + _InputParameters["StartDate"].ParamValue +
                            "# AND [Weights.Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "#" +
                            (_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.AllSitesValue ? (" AND SiteID = " + _InputParameters["SiteID"].ParamValue) : ""));
                double totalSum = 0; 
                if(total.Rows[0][0].ToString() != "")
                    totalSum = double.Parse(total.Rows[0][0].ToString());

                if (bool.Parse(_InputParameters["IsChartOnly"].ParamValue))
                {
                    this.chartControl1.Titles["Title"].Text = "Date: " +
                        DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " +
                        DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine +
                       "Grand total:" + title_top + totalSum.ToString("0") + end + Environment.NewLine +
                       "Filtered total:" + title_top + double.Parse(_ChartData.Compute("SUM(WasteSum)", "").ToString()).ToString("0") + end;

                    ghSubARTrend.Visible = false;
                    imgLogo.Visible = false;
                    this.chartControl1.Legends[0].Visible = false;
                    this.chartControl1.Height = 2.81F;
                    this.chartControl1.Width = 2.88F;

                    DataDynamics.ActiveReports.Chart.Title title = new DataDynamics.ActiveReports.Chart.Title();
                    title.Text = this.chartControl1.Series[1].Points.Count + "-" + _InputParameters["AggregatePeriod"].DisplayValue + " Trend";
                    //if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                    //    title.Text = _InputParameters["Title"].ParamValue;
                    title.Name = "footer";
                    title.Border = new DataDynamics.ActiveReports.Chart.Border(new DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black);
                    title.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, FontStyle.Bold));
                    title.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center;
                    title.Docking = DataDynamics.ActiveReports.Chart.DockType.Top;
                    this.chartControl1.Titles.Add(title);
                }
                else
                {
                    this.chartControl1.Titles["Title"].Text = "Date: " + DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) +
                        " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine +
                       "Grand total:" + title_top + totalSum.ToString("0") + end + Environment.NewLine +
                       "Filtered total:" + title_top + double.Parse(_ChartData.Compute("SUM(WasteSum)", "").ToString()).ToString("0") + end;
                   //" Total" + title_top + totalSum.ToString("0") + end;
                    SetHorizontal();
                    SetLogo();
                    lblTitle.Text = "Waste Trend Report for " + _InputParameters["AggregatePeriod"].DisplayValue;
                    if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                        this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                    if (_InputParameters["SubTitle"] != null)
                        txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                    if (_InputParameters["Filter"].ParamValue != "")
                        this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                    this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;

                    //string firstDayOfWeek = VWA4Common.GlobalSettings.FirstDayOfWeek;
                    //if(_InputParameters["SiteID"].ParamValue.ToString() != VWA4Common.GlobalSettings.CurrentSiteID.ToString())
                    //    firstDayOfWeek = VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(_InputParameters["SiteID"].ParamValue));

                    //daysOffset = (7 - VWA4Common.VWACommon.NumberOfDayOfWeek(firstDayOfWeek)) % 7;
                    DataTable dtTransNum = VWA4Common.DB.Retrieve(@"SELECT MAX(TransValue) AS TransNum, wDate, dDate " +
                        " FROM ( SELECT Count(*) as TransValue, Format(Weights.Timestamp +" + daysOffset + ", 'ww') as wDate,  " +
                        " Format(Weights.Timestamp + " + daysOffset + ", 'yyyyww') as yDate, " +
                        " DateAdd('d', -" + (daysOffset + 6) + 
                        "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + 
                        daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate" +      
                        " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID " + 
                        where +
                        " GROUP BY Format(Weights.Timestamp + " + daysOffset + ", 'ww'),  " +
                        " Format(Weights.Timestamp + " + daysOffset + ", 'yyyyww') " +
                        ", DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + 
                        ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + 
                        ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))   " +                    
                        " UNION   " +
                        " SELECT 0 AS TransValue, Format([Timestamp] +" + daysOffset + ", 'ww') as wDate, " +
                        " Format([Timestamp] + " + daysOffset + ", 'yyyyww') as yDate  " +
                        ", DateAdd('d', -" + (daysOffset + 6) + 
                        "-WeekDay(DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Timestamp + " + daysOffset + 
                        ", 'ww'), DateValue('1/1/' & Format(Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate   " +             
                        " FROM WeightDates    " +
                        " WHERE [Timestamp] >= #" + _InputParameters["StartDate"].ParamValue +
                        "# AND [Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "#" +
                        " GROUP BY Format(Timestamp + " + daysOffset + ", 'ww'),  Format(Timestamp + " + daysOffset + ", 'yyyyww')" +
                        ", DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(Timestamp + " + daysOffset + 
                        ", 'yyyy'))),  DateAdd('ww', Format(Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Timestamp + " + daysOffset + 
                        ", 'yyyy'))))) " +
                        " GROUP BY wDate, yDate, dDate " +
                        " ORDER BY MAX(TransValue), yDate");
                    if (dtTransNum != null && dtTransNum.Rows.Count > 0 &&
                        int.Parse(dtTransNum.Rows[0][0].ToString()) <= double.Parse(_InputParameters["LowTransactionLimit"].ParamValue) *
                        double.Parse(VWA4Common.GlobalSettings.GetBaselineWeeklyWasteTrans(_InputParameters["SiteID"].ParamValue)))
                    {
                        int weekNum;
                        lblWarning.Text += "Warning: Low Transactions for weeks: ";
                        weekNum = int.Parse(dtTransNum.Rows[0]["wDate"].ToString()) - 1;
                        if(weekNum != 0)
                            lblWarning.Text += weekNum + " - " + DateTime.Parse(dtTransNum.Rows[0]["dDate"].ToString()).ToString("MM/dd/yy");
                        
                        for (int i = 1; i < dtTransNum.Rows.Count; i++)
                            if (int.Parse(dtTransNum.Rows[i]["TransNum"].ToString()) <= double.Parse(_InputParameters["LowTransactionLimit"].ParamValue) *
                                double.Parse(VWA4Common.GlobalSettings.GetBaselineWeeklyWasteTrans(_InputParameters["SiteID"].ParamValue )))
                            {
                                lblWarning.Text += ", ";
                                weekNum = int.Parse(dtTransNum.Rows[i]["wDate"].ToString()) - 1;
                                if (weekNum != 0)
                                    lblWarning.Text += weekNum + " - " + DateTime.Parse(dtTransNum.Rows[i]["dDate"].ToString()).ToString("MM/dd/yy");
                                
                            }
                    }
                }
				VWA4Common.GlobalSettings.SubReportWasPrinted = true;
			}
            else
            {
				if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
				{
					ghSubARTrend.Visible = false;
					this.chartControl1.Visible = false;
					imgLogo.Visible = false;
					lblWarning.Text = "Warning: No Data\n";
					VWA4Common.GlobalSettings.SubReportWasPrinted = true;
				}
				else
				{
					VWA4Common.GlobalSettings.SubReportWasPrinted = false;
					this.Cancel();
				}
            }
            
			///
			/// End up here
			///
			
			this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
        }
    }
}
