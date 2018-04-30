using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;
using System.Data;

using System.Text.RegularExpressions;
using System.Globalization;

namespace Reports
{
    /// <summary>
    /// Summary description for rptComparisoSiteDetails.
    /// </summary>
    public partial class rptComparisonSiteDetails : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parameters"></param>
		public rptComparisonSiteDetails(UserControls.ReportParameters parameters)
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
            {
                chartControl2.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal;
            }
            else
            {
                chartControl2.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Identical;
            }
            
            for (int i = 0; i < this.chartControl2.Series.Count; i++)// bars used only for 2 series
            {
                DataDynamics.ActiveReports.Chart.Series s = this.chartControl2.Series[i];
                if (bool.Parse(_InputParameters["Is3D"].ParamValue))
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar3D;
                else
                    s.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar;
            }
        }
		private void SetHorizontal()
        {
            if (bool.Parse(_InputParameters["IsHorizontal"].ParamValue))
            {
                
                for (int i = 0; i < this.chartControl2.Series.Count; i++)// bars used only for 2 series
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

        private void AddSeries(int num, string site)
        {
            DataDynamics.ActiveReports.Chart.Series s = new DataDynamics.ActiveReports.Chart.Series();
            s.AxisX = chartControl2.ChartAreas[0].Axes["AxisX"];
            s.AxisY = chartControl2.ChartAreas[0].Axes["AxisY"];
            s.ChartArea = chartControl2.ChartAreas[0];
            s.Legend = chartControl2.Legends[0];
            s.LegendText = site;
            s.Name = "Series" + num;
            s.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar3D;
            s.Properties["Gap"] = 100f;
            s.Marker = new DataDynamics.ActiveReports.Chart.Marker(10, DataDynamics.ActiveReports.Chart.MarkerStyle.Triangle, 
                new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), new DataDynamics.ActiveReports.Chart.Graphics.Line(), 
                new DataDynamics.ActiveReports.Chart.LabelInfo(new DataDynamics.ActiveReports.Chart.Graphics.Line(), 
                    new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(), 
                    new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", 6F)), "{Value:$#,##0.}", 
                    DataDynamics.ActiveReports.Chart.Alignment.Top));

            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
                s.Marker.Label.Format = "{Value:#0} lbs";

          
            chartControl2.Series.Add(s);
            
        }

        static DataTable GetTable()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Waste_0", typeof(double));
            table.Columns.Add("Waste_1", typeof(double));

            //
            // Here we add unsorted data to the DataTable and return.
            //
            table.Rows.Add("1", 1200, 345);
            table.Rows.Add("2", 345, 0);
            table.Rows.Add("3", 567, 678);
            table.Rows.Add("4", 4353, 678);
            table.Rows.Add("5", 567, 893);
            return table;
        }

        private void rptComparisoSiteDetails_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            DataView _ChartData = new DataView();
            string criteria, top = "", title = ": $", end = "", sum = "";
            VWA4Common.VWADBUtils.CheckWeightDates();

            

            this.chartControl2.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);
            

            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
            {
                criteria = "SUM(Weight - NItems*ContainerWeight)";
                title = ": ";
                end = " lbs";
            }
            else 
            {
                criteria = "SUM(WasteCost)";
            }
            string select = "", joinSelect = "", startSelect = "", where1 = "";
            
            if (_InputParameters["Filter"].ParamValue != "")
                where1 = " WHERE (" + _InputParameters["Filter"].ParamValue + ") AND SiteID = ";
            else
                where1 = " WHERE SiteID = ";

			bool isWasteClassesUsed = false; 

            DataTable siteDataTable = new DataTable();
            DataTable dt;


            string sql = @"SELECT ID, LicensedSite " +
                        " FROM Sites " +
                        " WHERE Active = True";
            siteDataTable = VWA4Common.DB.Retrieve(sql);


            string where = "";
            double max = 0;
            int i = 0;

            foreach (DataRow row in siteDataTable.Rows)
            {
                where = where1 + row.ItemArray[0].ToString();
                startSelect += ", Waste_" + i;
                if (sum == "")
                    sum = "Waste_" + i;
                else
                    sum += " + Waste_" + i;

                // mila: we are using magical number 0.0001 instead of 0 due Active Reports bug Case 109583: Bar chart doesn't render if series has zero values.
                if (_InputParameters["ComparisionType"].DisplayValue == "Days of Week")
                {
                    select =
                        @"(SELECT " + top + " Name, Waste_" + i + " " +
                        " FROM (SELECT Name, MAX(WasteValue) AS Waste_" + i + " FROM  " +
                        " (SELECT DISTINCT Weekday(Timestamp) AS Name, Format(Timestamp,'yyyymmdd'), 0.0001 AS WasteValue  " +
                        " FROM WeightDates WHERE " +
                        " (Timestamp >= #" + _InputParameters["StartDate"].ParamValue + "# AND Timestamp < #" +
                        _InputParameters["EndDate"].ParamValue + "#) " +
                        " UNION     " +
                        " SELECT Weekday(Weights.Timestamp) AS Name, Format(Weights.Timestamp,'yyyymmdd'), " + criteria + " AS WasteValue  " +
                        " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID)  " +
                        (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                        where +
                        //" (Weights.Timestamp >= #" + _InputParameters["StartDate"].ParamValue + "# AND Weights.Timestamp < #" +
                        //_InputParameters["EndDate"].ParamValue + "#) " +
                        " GROUP BY Weekday(Weights.Timestamp), Format(Weights.Timestamp,'yyyymmdd')) " +
                        " GROUP BY Name ))  AS A" + i + " ";
                        
                        //" WHERE (A.Waste_" + i + " > 0.0001)   " +
                        //"ORDER BY Name " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " DESC;" : " ASC;");
                }
                else
                {
                    string typeComparision = "Food";
                    if (_InputParameters["ComparisionType"].DisplayValue == "Loss Categories")
                        typeComparision = "Loss";
                    else if (_InputParameters["ComparisionType"].DisplayValue == "Stations")
                        typeComparision = "Station";
                    select =
                        @"(SELECT " + top + " Name, Waste_" + i + "" +
                        " FROM ( SELECT Name, MAX(WasteValue) AS Waste_" + i + " FROM " +
                        "(SELECT DISTINCT TypeName AS Name, 0.0001 AS WasteValue FROM " + typeComparision + "Type " +
                        " UNION   " +
                        " SELECT " + typeComparision + "Type.TypeName AS Name, " + criteria + " AS WasteValue " +
                        " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                        ((typeComparision == "Loss") ? ")" :
                        " LEFT JOIN " + typeComparision + "Type ON Weights." + typeComparision + "TypeID = " + typeComparision + "Type.TypeID )") +
                        (isWasteClassesUsed && (typeComparision != "Food") ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " : "") +
                        where +
                        
                        " GROUP BY " + typeComparision + "Type.TypeName ) " +
                        " GROUP BY Name ))  AS A" + i + " ";
                        //" WHERE (A.Waste_" + i + " > 0.0001 ) " +
                        //"ORDER BY Waste_" + i + " " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " ASC;" : " DESC;");
                    
                }
                if (i == 0)
                    joinSelect = select;
                else
                    joinSelect = "(" + joinSelect + ")" + " LEFT OUTER JOIN " + select + " ON A0.Name = A" + i + ".Name";
                i++;
            }

            select = "SELECT A0.Name AS Name" + startSelect + ", SUM (" + sum + ") AS Waste_Sum FROM " + joinSelect +
                " GROUP BY A0.Name" + startSelect +
                ((_InputParameters["ComparisionType"].DisplayValue == "Days of Week") ? " ORDER BY A0.Name ASC" :
                " ORDER BY Waste_0 " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " ASC;" : " DESC;"));

            dt = VWA4Common.DB.Retrieve(select);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Name"] };

            if (_ChartData.Table == null)
                _ChartData = dt.DefaultView;
            else
                _ChartData.Table.Merge(dt, false, MissingSchemaAction.AddWithKey);

            _ChartData.Table.Columns.Add("WeekDayName");


            foreach (DataRow row in _ChartData.Table.Rows)
            {
                if (_InputParameters["ComparisionType"].DisplayValue == "Days of Week")
                    row["WeekDayName"] = VWA4Common.VWACommon.AccessDayOfWeek(row["Name"].ToString());
                else
                {
                    row["WeekDayName"] = row["Name"].ToString();
                }
                row["WeekDayName"] += ", " +
                        (bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "" : "$") + 
                        double.Parse(row["Waste_Sum"].ToString()).ToString("0.", CultureInfo.InvariantCulture) +
                        (bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "lbs" : "");
            }
            
            if (int.Parse(_InputParameters["NumShown"].ParamValue) > 0)
            {
                _ChartData.Sort = "Waste_Sum DESC";
                int top_num = int.Parse(_InputParameters["NumShown"].ParamValue);
                for(int h = _ChartData.Table.Rows.Count - 1; h >= top_num; h--)
                    _ChartData.Table.Rows.RemoveAt(h);
                if (bool.Parse(_InputParameters["IsHorizontal"].ParamValue))
                    _ChartData.Sort = "Waste_Sum ASC";
            }

            //Dataset to hold data
            this.chartControl2.DataSource = _ChartData;//GetTable().DefaultView;//

            if (dt.Rows.Count > 0)
            {
                for (int k = 0; k < siteDataTable.Rows.Count; k++)
                {
                    AddSeries(k, siteDataTable.Rows[k].ItemArray[1].ToString());

                    max = Math.Max(double.Parse(dt.Compute("Max(Waste_" + k + ")", "").ToString()), max);

                    this.chartControl2.Series[k].ValueMembersY = "Waste_" + k;
                    this.chartControl2.Series[k].ValueMemberX = "WeekDayName";
                    

                }
            }

            

        this.chartControl2.ChartAreas[0].Axes["AxisY"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);
        this.chartControl2.Series[0].AxisX.Title = Regex.Split(_InputParameters["ComparisionType"].DisplayValue, " ")[0] + " Type";


        if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
        {
            this.chartControl2.Series[0].AxisY.Title = "Waste, lbs.";
            this.chartControl2.Series[0].Marker.Label.Format = "{Value:#0} lbs";
               
        }
        else
        {
            this.chartControl2.Series[0].AxisY.Title = "Waste ($)";
        }

       

            Set3D();
            SetHorizontal();
            SetLogo();

            lblTitle.Text = "Comparison: Site Details report for " + _InputParameters["ComparisionType"].DisplayValue;
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                

            if (!Boolean.Parse(_InputParameters["IsToggleFooter"].ParamValue))
            {
                if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                    txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;

                this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            }
            
            this.Document.Printer.Landscape = true;
            this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom);
        }
    }
}