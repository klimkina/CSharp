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
    /// Summary description for rptTrackerComparison.
    /// </summary>
    public partial class rptTrackerComparison : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        public rptTrackerComparison(UserControls.ReportParameters parameters)
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
                    if (s.Marker != null)
                        s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                }
            }
        }
        private DataTable _ChartData;
        private void rptTrackerComparison_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            _ChartData = new DataTable();
            VWA4Common.VWADBUtils.CheckWeightDates();

            string where = " WHERE Transfers.SiteID = " + _InputParameters["SiteID"].ParamValue;
            if (_InputParameters["Filter"].ParamValue != "")
                where += " AND " + _InputParameters["Filter"].ParamValue;
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1" || (_InputParameters["WasteClasses"].ParamValue.ToString() != ""));
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

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
            
            
            // order depends on horizontal or vertical design but if Chart Only then we ignore it
            bool order = bool.Parse(_InputParameters["IsHorizontal"].ParamValue) && !bool.Parse(_InputParameters["IsChartOnly"].ParamValue);

            string select = @"SELECT SUM(" + criteria + ") as WasteSum, Count(*) as TransNum, TransNum/WasteSum as Proportion, " +
                    " TermName " +
                    " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN Terminals ON Transfers.TermID = Terminals.TermID) " +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY TermName " +
                    @" ORDER BY TermName " + (order ? " DESC;" : " ASC;");
            _ChartData = VWA4Common.DB.Retrieve(select);

            if (_ChartData.Rows.Count > 0)
            {
                double max = double.Parse(_ChartData.Compute("Max(WasteSum)", "").ToString());
                
                this.chartControl1.ChartAreas[0].Axes["AxisY"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);

                max = double.Parse(_ChartData.Compute("Max(TransNum)", "").ToString());
                
                this.chartControl1.ChartAreas[0].Axes["AxisY2"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);

                this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));
                this.chartControl1.Series[1].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));
                //this.chartControl1.Series[0].Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Top;
                //this.chartControl1.Series[1].Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Bottom;

                this.chartControl1.DataSource = _ChartData;
                this.chartControl1.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);

                Set3D();
                SetWeight();

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
                            "# AND [Weights.Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "# AND " +
                            " SiteID = " + _InputParameters["SiteID"].ParamValue);
                double totalSum = 0;
                if (total.Rows[0][0].ToString() != "")
                    totalSum = double.Parse(total.Rows[0][0].ToString());

                
                this.chartControl1.Titles["Title"].Text = "Date: " + DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) +
                    " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + Environment.NewLine +
                   "Grand total:" + title_top + totalSum.ToString("0") + end + Environment.NewLine +
                   "Filtered total:" + title_top + double.Parse(_ChartData.Compute("SUM(WasteSum)", "").ToString()).ToString("0") + end;
                //" Total" + title_top + totalSum.ToString("0") + end;
                SetHorizontal();
                SetLogo();
                lblTitle.Text = "Tracker Comparision Report for " + _InputParameters["SiteID"].DisplayValue + " Site";
                if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                    this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                if (_InputParameters["SubTitle"] != null)
                    txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                if (_InputParameters["Filter"].ParamValue != "")
                    this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
                
            }
            else
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {
                    ghSubARTrend.Visible = false;
                    this.chartControl1.Visible = false;
                    imgLogo.Visible = false;
                    lblWarning.Text = "Warning: No Data\n";
                }
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
        }
    }
}
