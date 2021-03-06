using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.Chart;
using System.Data;
using System.Windows.Forms;

namespace Reports
{
    /// <summary>
    /// Summary description for rptCrossTab.
    /// </summary>
    public partial class rptCrossTab : DataDynamics.ActiveReports.ActiveReport
    {

        private UserControls.ReportParameters _InputParameters;
        public rptCrossTab(UserControls.ReportParameters parameters)
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
            for (int i = 0; i < 1; i++)// bars used only for 2 series
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
                for (int i = 0; i < 1; i++)// bars used only for 2 series
                {
                    DataDynamics.ActiveReports.Chart.Series s = this.chartControl1.Series[i];
                    s.AxisX.LabelFont.Angle = -1;
                    s.AxisY.LabelFont.Angle = 45;
                    s.AxisX.TitleFont.Angle = -90;
                    s.AxisY.TitleFont.Angle = 0;
                    s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                    s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                    s.ChartArea.SwapAxesDirection = true;
                    
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

        private void rptCrossTab_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            DataTable _ChartData = new DataTable();
            string criteria, top = "", title = " $", end = "";
            string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                where += " AND (" + _InputParameters["Filter"].ParamValue + ")";
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
            {
                criteria = "SUM(Weight - NItems*ContainerWeight)";
                this.chartControl1.Series[0].AxisY.Title = "Waste, lbs.";
                this.chartControl1.Series[0].Marker.Label.Format = "{Value:#} lbs";
                title = " ";
                end = " lbs";
            }
            else
            {
                criteria = "SUM(WasteCost)";
                this.chartControl1.Series[0].AxisY.Title = "Waste ($)";
            }
            this.chartControl1.Series[0].AxisX.Title = _InputParameters["CrossTabOn"].DisplayValue + " Type";
            if (int.Parse(_InputParameters["NumShown"].ParamValue) > 0)
                top = " TOP " + _InputParameters["NumShown"].ParamValue;
            string select = @"SELECT Name, TypeID, Waste FROM(" +
                    "SELECT " + top + " " + _InputParameters["CrossTabOn"].ParamValue + "Type.TypeName AS Name, " + _InputParameters["CrossTabOn"].ParamValue +
                    "TypeID as TypeID, " + criteria + " AS Waste " +
                    " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    ((_InputParameters["CrossTabOn"].ParamValue == "Loss") ? "" :
                    " INNER JOIN " + _InputParameters["CrossTabOn"].ParamValue + "Type ON Weights." + _InputParameters["CrossTabOn"].ParamValue +
                    "TypeID = " + _InputParameters["CrossTabOn"].ParamValue + "Type.TypeID") +
                    (isWasteClassesUsed && (_InputParameters["CrossTabOn"].ParamValue != "Food") ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY Weights." + _InputParameters["CrossTabOn"].ParamValue + "TypeID, " + _InputParameters["CrossTabOn"].ParamValue + "Type.TypeName " +
                    " ORDER BY " + criteria + " DESC)" + 
                    " ORDER BY Waste " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " ASC;" : " DESC;");


            _ChartData = VWA4Common.DB.Retrieve(select);
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            if (_ChartData.Rows.Count > 0)
            {
                //if (_InputParameters["IsPie"].ParamValue.ToLower().Equals("true"))
                //{
                //    Legend l = new Legend();
                //    Title ltitle = new Title();
                //    ltitle.Text = "Legend";
                //    l.Header = ltitle;

                //    Series s = new Series();
                //    s.Type = ChartType.Doughnut3D;
                //    bool isPercent = false;

                //    double total = 0.00;
                //    string ww = bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "Weights" : "Waste";
                //    foreach (DataRow r in _ChartData.Rows)
                //    {
                //        total += Convert.ToDouble(r[ww]);
                //    }
                //    foreach (DataRow r in _ChartData.Rows)
                //    {
                //        DataPoint dp = new DataPoint();

                //        LegendItem li = new LegendItem();
                //        li.Text = r["Name"].ToString();
                //        li.Style = StdLegendMarker.Area;
                //        li.Marker = new Marker(10, MarkerStyle.Square, new DataDynamics.ActiveReports.Chart.Graphics.Backdrop(Color.Black), new DataDynamics.ActiveReports.Chart.Graphics.Line(Color.Black), new LabelInfo());

                //        //l.LegendItems.Add(li);

                //        dp.XValue = r["Name"].ToString();
                //        if (isPercent)
                //        {
                //            //percent
                //            //Math.Round((decimal)((Convert.ToDouble(r[ww]) / total) * 100), 0).ToString() + "%";
                //            dp.YValues = new DoubleArray(new double[] { Convert.ToDouble(Math.Round((decimal)((Convert.ToDouble(r[ww]) / total) * 100), 2)) });
                //        }
                //        else
                //        {
                //            //value
                //            dp.YValues = new DoubleArray(new double[] { Convert.ToDouble(Math.Round((decimal)Convert.ToDouble(r[ww]), 2)) });
                //        }

                //        dp.DisplayInLegend = true;
                //        dp.IsEmpty = false;
                //        dp.LegendText = r["Name"].ToString();

                //        s.Points.Add(dp);
                //    }

                //    s.Properties["ExplodeFactor"] = 0.0F;
                //    s.Properties["HoleSize"] = 0.0F;
                //    s.Properties["OutsideLabels"] = false;
                //    s.Properties["StartAngle"] = 0.0f;
                //    s.ColorPalette = ColorPalette.Cascade;

                //    Marker m = new Marker();
                //    m.Label.Font.Color = System.Drawing.Color.Black;
                //    m.Label.Alignment = Alignment.Left;
                //    m.Size = 2;
                //    m.Style = MarkerStyle.None;
                //    s.Marker = m;

                //    DataDynamics.ActiveReports.Chart.Graphics.Line line = new DataDynamics.ActiveReports.Chart.Graphics.Line(Color.Black, 0);
                //    l.Border = new DataDynamics.ActiveReports.Chart.Border(line, 0, Color.Black);

                //    this.chartControl1.Legends.Add(l);

                //    this.chartControl1.Series.Clear();
                //    l.DockArea = this.chartControl1.ChartAreas[0];
                //    l.Alignment = Alignment.TopRight;
                //    l.LabelsFont = new FontInfo(Color.Black, new Font("Arial", 9F));
                //    s.Legend = l;
                //    this.chartControl1.Series.Add(s);

                //    Title t = new Title();
                //    t.Name = _InputParameters["CrossTabReport"].DisplayValue;
                //    t.Text = string.Format("{0} - {1}", _InputParameters["CrossTabReport"].DisplayValue, _InputParameters["CrossTabOn"].DisplayValue);
                //    t.Border.Line.Style = DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None;
                //    t.Border.Line.Weight = 0;
                //    t.Alignment = Alignment.Center;
                //    this.chartControl1.Titles.Add(t);
                //    this.chartControl1.ChartAreas[0].Projection.ProjectionType = DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal;
                //}
                //else
                //{
                    double max = double.Parse(_ChartData.Compute("Max(Waste)", "").ToString());
                    int step = 1; double temp = max;
                    for (step = 1; temp > 1; step *= 10)
                        temp = temp / 10;
                    step = step / 100 * (int)(1 + max * 10 / step);
                    this.chartControl1.ChartAreas[0].Axes["AxisY"].MajorTick.Step = step;

                    this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));
                    this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));

                    SetHorizontal();
                    lblTitle.Text = "Detail report for " + _InputParameters["CrossTabReport"].DisplayValue + " by " + _InputParameters["CrossTabOn"].DisplayValue;
                    if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                        this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                    txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                    SetLogo();
                    this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
                    if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                        txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                    this.chartControl1.DataSource = _ChartData;
                    this.chartControl1.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);
                    DataTable totalTable = VWA4Common.DB.Retrieve(@"SELECT " + criteria +
                            " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                            " WHERE [Weights.Timestamp] >= #" + _InputParameters["StartDate"].ParamValue +
                            "# AND [Weights.Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "# AND " +
                            " SiteID = " + _InputParameters["SiteID"].ParamValue);
                    double total = 0;
                    if (totalTable.Rows[0][0].ToString() != "")
                        total = double.Parse(totalTable.Rows[0][0].ToString());
                    this.chartControl1.Titles["Title"].Text = "Date: " + DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy") + " - " +
                        DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy") + Environment.NewLine +
                        " Grand total:" + title + total.ToString("0") + end + Environment.NewLine +
                        "Filtered total:" + title + double.Parse(_ChartData.Compute("SUM(Waste)", "").ToString()).ToString("0") + end;
                    this.chartControl1.Series[0].ValueMembersY = "Waste";
                    this.chartControl1.Series[0].ValueMemberX = "Name";
                    Set3D();
                //}
            }
            else // don't show report if no data
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {      
                    this.chartControl1.Visible = false;
                    this.chartControl1.Height = 0;
                    lblWarning.Text = "No data found for: " + _InputParameters["Filter"].DisplayValue;
                }
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom);  
        }
    }
}
