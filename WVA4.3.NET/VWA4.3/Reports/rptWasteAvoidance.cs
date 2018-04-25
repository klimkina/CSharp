using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Reports
{
    /// <summary>
    /// Summary description for rptWasteAvoidance.
    /// </summary>
    public partial class rptWasteAvoidance : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        public rptWasteAvoidance(UserControls.ReportParameters parameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
        }

        private void Set3D()
        {
            if (bool.Parse(_InputParameters["Is3D"].ParamValue))
                chartControl2.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal;
            else
                chartControl2.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Identical;
            for (int i = 0; i < 1; i++)// bars used only for 2 series
            {
                DataDynamics.ActiveReports.Chart.Series s = this.chartControl2.Series[i];
                if (bool.Parse(_InputParameters["Is3D"].ParamValue))
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;
                else
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar2D;
            }
        }
        private void SetHorizontal()
        {
            if (bool.Parse(_InputParameters["IsHorizontal"].ParamValue))
            {
                for (int i = 0; i < 1; i++)// bars used only for 2 series
                {
                    DataDynamics.ActiveReports.Chart.Series s = this.chartControl2.Series[i];
                    s.ChartArea.SwapAxesDirection = true;
                    s.AxisX.LabelFont.Angle = 0;
                    s.AxisY.LabelFont.Angle = 45;
                    s.AxisX.TitleFont.Angle = -90;
                    s.AxisY.TitleFont.Angle = 0;
                    s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
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
        private string WeekToDate(string str)
        {
            if (this._InputParameters["WasteAvoidanceAggregatePeriod"].DisplayValue == "Year")
                return str;

            DateTime result;
            int year, week;
            if (_IsShowYear)
            {
                year = int.Parse(str.Substring(0, 4));
                week = int.Parse(str.Substring(4, str.Length - 4));
            }
            else
            {
                year = _StartDate.Year;
                week = int.Parse(str);
            }

            if (this._InputParameters["WasteAvoidanceAggregatePeriod"].DisplayValue == "Week") // put different labels for week
            {
                
                DateTime jan1 = new DateTime(year, 1, 1);

                int daysOffset = (DayOfWeek)(DayOfWeek.Parse(typeof(DayOfWeek), VWA4Common.GlobalSettings.FirstDayOfWeek)) - jan1.DayOfWeek;
                DateTime firstMonday = jan1.AddDays(daysOffset);

                var cal = CultureInfo.CurrentCulture.Calendar;
                int firstWeek = cal.GetWeekOfYear(firstMonday, new CultureInfo("en-US").DateTimeFormat.CalendarWeekRule, (DayOfWeek)(DayOfWeek.Parse(typeof(DayOfWeek), VWA4Common.GlobalSettings.FirstDayOfWeek)));

                if (firstWeek <= 1)
                {
                    week -= 1;
                }

                result = firstMonday.AddDays((week-2) * 7);
                return result.ToString("MM/dd/yyyy");

            }
            else if (this._InputParameters["WasteAvoidanceAggregatePeriod"].DisplayValue == "Month") // put different labels for months
            { 
                return week +"/" + (_IsShowYear ? year.ToString() : "");
            }
            else  // Quarter
            {
                return ((int)((week + 2) / 3)).ToString() + "/" + (_IsShowYear ? year.ToString() : "");
            }
            
        }

        private void SetPeriod()
        {
            for (int i = 0; i < this.chartControl2.Series[0].Points.Count; i++)
            {
                this.chartControl2.ChartAreas[0].Axes["AxisX"].Labels.Add(WeekToDate(this.chartControl2.Series[0].Points[i].XValue.ToString()));
            }
            
            
        }

        private DateTime _StartDate;
        private bool _IsShowYear = false;
        private int _DaysOffset = 0;
        private void rptWasteAvoidance_ReportStart(object sender, EventArgs e)
        {
            try
            {
                if (_InputParameters["Title"].ParamValue != "")
                    this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                
                txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;

                if (!Boolean.Parse(_InputParameters["IsToggleFooter"].ParamValue))
                {
                    if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                        txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                    
                    this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
                }

                txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
               
                txtSite.Text = _InputParameters["SiteID"].DisplayValue;
                if (_InputParameters["SiteID"].DisplayValue == "All Sites")
                    txtSite.Text += ": " + VWA4Common.VWACommon.GetAllSiteNames();

                DateTime start = DateTime.Parse(_InputParameters["StartDate"].ParamValue);
                DateTime end = DateTime.Parse(_InputParameters["EndDate"].ParamValue); ;
                txtPeriod.Text = start.ToString("MM/dd/yyyy") + "-" + end.ToString("MM/dd/yyyy");

                //Dataset to hold data
                DataTable _ChartData = new DataTable();
                string criteria = "";
                VWA4Common.VWADBUtils.CheckWeightDates();

                bool isDollars = bool.Parse(_InputParameters["IsDollars"].DisplayValue);
                if (!isDollars)
                {
                    criteria = "SUM(Weight - NItems*ContainerWeight)";
                    this.chartControl2.Series[0].AxisY.Title = "Waste, lbs.";
                    this.chartControl2.Series[0].Marker.Label.Format = "{Value:#0} lbs";
                    if (_InputParameters["Title"].ParamValue == "")
                        this.lblTitle.Text = "Waste Avoidance Report, Pounds";
                }
                else
                {
                    criteria = "SUM(WasteCost)";
                    this.chartControl2.Series[0].AxisY.Title = "Waste ($)";
                    if (_InputParameters["Title"].ParamValue == "")
                        this.lblTitle.Text = "Waste Avoidance Report, Dollars";
                }
                string select = "";
                string where = "";
                if (_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.AllSitesValue) 
                    where = " WHERE (SiteID = " + _InputParameters["SiteID"].ParamValue + ")";
                if (_InputParameters["Filter"].ParamValue != "") 
                {
                    if(where == "")
                        where = " WHERE (" + _InputParameters["Filter"].ParamValue + ") ";
                    else
                        where = where + " AND (" + _InputParameters["Filter"].ParamValue + ") ";
                }
                    


                double blCost = 0.0, adj = 0;
                if(isDollars)
                    Double.TryParse(VWA4Common.GlobalSettings.GetBaselineWeeklyWasteCost(_InputParameters["SiteID"].ParamValue), out blCost);
                else
                    Double.TryParse(VWA4Common.GlobalSettings.GetBaselineWeeklyWasteWeight(_InputParameters["SiteID"].ParamValue), out blCost);
                
                
                
                
                string firstDayOfWeek = VWA4Common.GlobalSettings.FirstDayOfWeek;
                if ((_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.AllSitesValue) && (_InputParameters["SiteID"].ParamValue != VWA4Common.GlobalSettings.CurrentSiteID.ToString()))
                    firstDayOfWeek = VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(_InputParameters["SiteID"].ParamValue));
                if (this._InputParameters["WasteAvoidanceAggregatePeriod"].DisplayValue == "Week")//for weekly reports adjust VWA first day of week to Access First day of week
                    _DaysOffset = (7 - VWA4Common.VWACommon.NumberOfDayOfWeek(firstDayOfWeek)) % 7;

                DateTime temp = DateTime.Now;
                if (_BaselineWeek == "")
                {
                    _BaselineWeek = VWA4Common.GlobalSettings.GetBaselineStartDate(_InputParameters["SiteID"].ParamValue);
                    DateTime.TryParse(_BaselineWeek, out temp);
                    temp = temp.AddDays(_DaysOffset);
                }

                string accessAggregate = ""; 
                switch (_InputParameters["WasteAvoidanceAggregatePeriod"].DisplayValue)
                {
                    case "Week":
                        lblTitleMonth.Text = "Week";
                        accessAggregate = "ww";
                        _BaselineWeek = CultureInfo.GetCultureInfo("en-US").Calendar.GetWeekOfYear(temp, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, 
                            DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek).ToString();
                        break;
                    case "Month":
                        lblTitleMonth.Text = "Month";
                        accessAggregate = "mm";
                        _BaselineWeek = temp.ToString("mm", CultureInfo.GetCultureInfo("en-US"));
                        break;
                    case "Quarter":
                        lblTitleMonth.Text = "Quarter";
                        accessAggregate = "q";
                        _BaselineWeek = ((int)((temp.Month + 2) / 3)).ToString();
                        break;
                    case "Year":
                        lblTitleMonth.Text = "Year";
                        accessAggregate = "yyyy";
                        _BaselineWeek = temp.ToString("yyyy", CultureInfo.GetCultureInfo("en-US"));
                        break;
                    default:
                        throw new Exception("Dev Error - Aggregate period not handled.");
                }

                if ((start.Year != end.Year) && (accessAggregate != "yyyy"))
                {
                    accessAggregate = "yyyy" + accessAggregate;
                    _BaselineWeek = temp.ToString("yyyy", CultureInfo.GetCultureInfo("en-US")) + _BaselineWeek;
                }

                select = @"SELECT  Format(Weights.Timestamp + " + _DaysOffset + ", '" + accessAggregate + "') as yDate, " + criteria + " as Dollars, " +
                    "'" + blCost + "' as Baseline, IIF(" + criteria + " <> 0,  (" + blCost.ToString("0.####", CultureInfo.GetCultureInfo("en-US")) + "-" + criteria + "), " +
                    blCost.ToString("0.####", CultureInfo.GetCultureInfo("en-US")) + ") as Variance " +
                    "FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
                    where +
                    " GROUP BY Format(Weights.Timestamp + " + _DaysOffset + ", '" + accessAggregate + "')  " +
                    " ORDER BY  Format(Weights.Timestamp + " + _DaysOffset + ", '" + accessAggregate + "') ;";

                DataTable dt = VWA4Common.DB.Retrieve(select);
                _ChartData = dt;

                

               
                if (_ChartData.Rows.Count > 0)
                {
                    this.chartControl2.DataSource = _ChartData;
                    this.DataSource = _ChartData;

                   _StartDate = start;
                   _IsShowYear = start.Year != end.Year;


                    if (isDollars)
                    {
                        lblDollars.Text = "Dollars";
                        this.chartControl2.Titles[0].Text = "Calculated Waste Avoidance, Dollars ";
                        txtBLDollars.OutputFormat = "$#,##0";
                        txtDollars.OutputFormat = "$#,##0";
                    }
                    else
                    {
                        lblDollars.Text = "Pounds";
                        this.chartControl2.Titles[0].Text = "Calculated Waste Avoidance, Pounds ";
                        txtBLDollars.OutputFormat = "#,##0lbs";
                        txtDollars.OutputFormat = "#,##0lbs";
                        txtVariance.OutputFormat = "#,##0lbs";
                        txtCumulative.OutputFormat = "#,##0lbs";
                    }

                    this.chartControl2.Series[0].ValueMembersY = "Dollars";
                    this.chartControl2.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);
                    this.chartControl2.Series[0].ValueMembersY = "Dollars";
                    this.chartControl2.Series[0].ValueMemberX = "yDate";

                    DataView view = dt.DefaultView;
                    //view.Sort = "Variance";
                    DataTable sortedTable = view.ToTable();

                    //search for minimal value
                    double cum = Double.Parse(sortedTable.Rows[0]["Variance"].ToString());
                    int min = (int)cum;
                    for (int i = 1; i < sortedTable.Rows.Count; i++)
                    {
                        cum += Double.Parse(sortedTable.Rows[i]["Variance"].ToString());
                        if (cum < min)
                            min = (int)cum;
                    }
                        
                    int max = (int)Double.Parse(sortedTable.Compute("Sum(Variance)", "").ToString());

                    this.chartControl2.ChartAreas[0].Axes["AxisY"].Max = max;
                    this.chartControl2.ChartAreas[0].Axes["AxisY"].Min = Math.Min(0, min);
                    //to show negative values below 0 axis and to force labels to the bottom of the chart in this case
                    this.chartControl2.ChartAreas[0].Axes["AxisX"].Position = 0;
                    this.chartControl2.ChartAreas[0].Axes["AxisX"].LabelsAtBottom = true;
                    
                    
                    this.chartControl2.ChartAreas[0].Axes["AxisY"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, (int)Math.Min(0, min));
                    
                }

                Set3D();
                SetHorizontal();
                SetLogo();
                SetPeriod();

                this.Document.Printer.Landscape = true;
                this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double _Cumulative = 0.0;
        private string _BaselineWeek = "";
        //private bool _BaselineStarted = false;
        private int _CalcAvoidanceBarNum = 0;

        private void detail_Format(object sender, EventArgs e)
        {
            txtCumulative.Value = _Cumulative;

            // if (!_BaselineStarted || lblMonth.Text == _BaselineWeek)
            //{
            //    txtVariance.Value = 0;
            //    txtCumulative.Value = 0;

            //    txtVariance.Text = "";
            //    txtCumulative.Text = "";


            //    if (lblMonth.Text == _BaselineWeek)
            //    {
            //       _BaselineStarted = true;
            //    }
                

            //    //this.chartControl2.Series[0].Points[_CalcAvoidanceBarNum].YValues[0] = 0.0001;
            //}
            //else
            //
                this.chartControl2.Series[0].Points[_CalcAvoidanceBarNum].YValues[0] = _Cumulative;
            
            lblMonth.Text = WeekToDate(lblMonth.Text);

            _CalcAvoidanceBarNum++;
        }

        private void rptWasteAvoidance_FetchData(object sender, FetchEventArgs eArgs)
        {
            double d = 0;
            //if(Fields["yDate"].Value != null)
            //{
            //    _BaselineStarted = String.Compare(Fields["yDate"].Value.ToString(), _BaselineWeek) >= 0;
            //}
            if (Fields["Variance"].Value != null)
            {
                Double.TryParse(Fields["Variance"].Value.ToString(), out d);
             //   if(_BaselineStarted)
                    _Cumulative += d;
            }
        }
    }
}
