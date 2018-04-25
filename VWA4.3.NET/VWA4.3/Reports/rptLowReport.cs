using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Reports
{
    /// <summary>
    /// Summary description for rptLowReport.
    /// </summary>
    public partial class rptLowReport : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        private string _TypeName;
        public rptLowReport(UserControls.ReportParameters InputParameters, string typeName)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
            _TypeName = typeName;
        }

        public UserControls.ReportParameters OutputParameters
        {
            get
            {
                UserControls.ReportParameters output = new UserControls.ReportParameters();
                output.AddParameter(_TypeName + "ThresholdLevel", _ChartData.Compute("Sum(Waste)", "").ToString(),
                     _ChartData.Compute("Sum(Waste)", "").ToString(), "Double");
                return output;
            }
        }
        private void Set3D()
        {
            if (bool.Parse(_InputParameters["Is3D"].ParamValue))
                chartControl1.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal;
            else
                chartControl1.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Identical; 
            for (int i = 0; i < 1; i++)// bars used only for 1 serie
            {
                DataDynamics.ActiveReports.Chart.Series s = this.chartControl1.Series[i];
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
                for (int i = 0; i < 1; i++)// bars used only for 1 serie
                {
                    DataDynamics.ActiveReports.Chart.Series s = this.chartControl1.Series[i];
                    s.ChartArea.SwapAxesDirection = true;
                    s.AxisX.LabelFont.Angle = 0;
                    s.AxisY.LabelFont.Angle = 45;
                    s.AxisX.TitleFont.Angle = -90;
                    s.AxisY.TitleFont.Angle = 0;
                    s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                }
            }
        }
        private int _iRow;
        DataTable _ChartData = null;
        private void rptLowReport_ReportStart(object sender, EventArgs e)
        {
            this._iRow = 0;
            
            //Dataset to hold data
            _ChartData = new DataTable();
            VWA4Common.VWADBUtils.CheckWeightDates();
            string strNoTop = "", criteria = "";
            if (int.Parse(_InputParameters["NumShown"].ParamValue) == 0)
                strNoTop = " HAVING MAX(WasteValue) = 0";

            else
                criteria = " TOP " + _InputParameters["NumShown"].ParamValue + " ";
            
            string select, where = "", dateswhere = "", typewhere = "";
            if (_InputParameters["StartDate"] != null && _InputParameters["EndDate"].ParamValue != null)
            {
                DateTime start, end;
                start = DateTime.Parse(_InputParameters["StartDate"].ParamValue);
                end = DateTime.Parse(_InputParameters["EndDate"].ParamValue);
                dateswhere = " WHERE [Timestamp] >= #" + VWA4Common.VWACommon.DateToString(start) + 
                            "# AND [Timestamp] < #" + VWA4Common.VWACommon.DateToString(end) + "#";
           
            }
            where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
            {
                where += " AND " + _InputParameters["Filter"].ParamValue;
                if (_TypeName != "TopWeighers" && _TypeName != "NonWeighers" && _TypeName != "Day")
                {
                    typewhere = VWA4Common.VWACommon.ExtractStringNameFilter(_TypeName, _InputParameters["Filter"].ParamValue);
                    if (typewhere != "")
                        typewhere = " WHERE " + typewhere.Replace(_TypeName + "TypeID", "TypeID");
                }
            }

			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            if (_TypeName == "Period")
                this.Cancel(); // mila: report is not defined!
            else
            {
                if (_TypeName == "TopWeighers")
                    select = @"SELECT Name, UserType.TypeID, Waste FROM(" +
                        "SELECT TOP 10 UserType.TypeName AS Name, UserType.TypeID, Count(*) AS Waste  " +
                        "FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID)" +
                        " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID )" +
                        (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                        where +
                        " GROUP BY UserType.TypeID, UserType.TypeName  " +
                        " ORDER BY Count(*) DESC)" +
                        " ORDER BY Waste " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " ASC;" : " DESC, Name;");
                else if (_TypeName == "NonWeighers")
                    select = @"SELECT UserType.TypeName AS Name, TypeID, MAX(WasteValue) AS Waste " + 
                        " FROM " + 
                        " (SELECT DISTINCT TypeID, UserType.TypeName, 0 as WasteValue  " +
                        " FROM UserType UNION  " +
                        " SELECT UserType.TypeID, UserType.TypeName, COUNT(*) AS WasteValue " +
                        " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                        " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID )" +
                        (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                        where +
                        " GROUP BY UserType.TypeID, UserType.TypeName) " +
                        " GROUP BY UserType.TypeName, TypeID  HAVING MAX(WasteValue) = 0 " +
                        " ORDER BY UserType.TypeName ASC";
                else if (_TypeName == "Day")
                    select = @"SELECT " + criteria + " Name, MAX(WasteValue) AS Waste " +
                        " FROM (SELECT DISTINCT Format(Timestamp,'yyyy/mm/dd') AS Name, 0 AS WasteValue " +
                        " FROM WeightDates" +
                        dateswhere +
                        " UNION " +
                        " SELECT DISTINCT Format(Weights.Timestamp,'yyyy/mm/dd') AS Name, COUNT(*) AS WasteValue " +
                        " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                        (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                        where +
                        " GROUP BY  Format(Weights.Timestamp,'yyyy/mm/dd')) " +
                        " GROUP BY  Name " + strNoTop +
                        " ORDER BY MAX(WasteValue) ASC, Name";
                else
                    select = @"SELECT " + criteria + " TypeName AS Name, TypeID, MAX(WasteValue) AS Waste FROM (" +
                    "SELECT DISTINCT TypeID, " + _TypeName + "Type.TypeName, 0 as WasteValue FROM " + _TypeName + "Type " + typewhere + " UNION " +
                    "SELECT " + _TypeName + "Type.TypeID, " + _TypeName + "Type.TypeName, COUNT(*) AS WasteValue" +
                    " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID)" +
                    ((_TypeName == "Loss") ? "" : (" INNER JOIN " + _TypeName + "Type ON Weights." + _TypeName + "TypeID = " + _TypeName + "Type.TypeID")) + ")" +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY " + _TypeName + "Type.TypeID, " + _TypeName + "Type.TypeName) " +
                    " GROUP BY TypeName, TypeID " + strNoTop +
                    " ORDER BY MAX(WasteValue) ASC, TypeName";
                _ChartData = VWA4Common.DB.Retrieve(select);
                if (_ChartData.Rows.Count > 0)
                {
                    double max = double.Parse(_ChartData.Compute("Max(Waste)", "").ToString());
                    int step = 1; double temp = max;
                    for (step = 1; temp > 1; step *= 10)
                        temp = temp / 10;
                    step = step / 100 * (int)(1 + max * 10 / step);
                    this.chartControl1.ChartAreas[0].Axes["AxisY"].MajorTick.Step = step;

                    this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));
                


                    this.DataSource = _ChartData;
                    this.DataMember = _ChartData.TableName;

                    if (_TypeName == "TopWeighers")// a lot of zero values cause chart problems
                    {
                        txtTitle.Text = "Top 10 Weighers";
                        if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                            txtTitle.Text = _InputParameters["Title"].ParamValue;
                        this.chartControl1.DataSource = _ChartData;
                        this.chartControl1.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);
                        Set3D();
                        SetHorizontal();
                    }
                    else // hide chart
                    {
                        this.chartControl1.Visible = false;
                        this.chartControl1.Height = 0f;
                        if (_TypeName == "Loss")
                            _TypeName = "Loss Reason";// to look good
                        if (_TypeName == "NonWeighers")
                            txtTitle.Text = "List of Non Weighers";
                        else
                            txtTitle.Text = _InputParameters["NumShown"].ParamValue == "0" ? _TypeName + "s with no data" : "BOTTOM " + _InputParameters["NumShown"].ParamValue 
                                + " " + _TypeName + "s with no/low data";
                    }
                   
                }
                else // don't show report if no data
                    this.Cancel();
                this.Document.Printer.Landscape = true;
                //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
            }
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            // Check _iRow value to see if we need to highlight the row or not.
            if (this._iRow % 2 == 0)
                this.detail.BackColor = Color.Transparent;
            else
                this.detail.BackColor = Color.LightYellow;
            this._iRow++;
            this.lblRank.Text = this._iRow.ToString(System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
