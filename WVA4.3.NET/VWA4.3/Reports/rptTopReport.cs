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
    /// Summary description for rptTopReport.
    /// </summary>
    public partial class rptTopReport : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        private string _TypeName;
        private int _TopCount;
        public rptTopReport(UserControls.ReportParameters InputParameters, string typeName, int topCount)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
            _TypeName = typeName;
            _TopCount = topCount;
        }
        private void SetWeight()
        {
            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
            {
                this.chartControl1.ChartAreas[0].Axes["AxisY"].Title = "Weight, lbs";
                this.chartControl1.Series[0].Marker.Label.Format = "{Value:#.} lb";
            }
            else
            {
                this.chartControl1.ChartAreas[0].Axes["AxisY"].Title = "Waste ($)";
                this.chartControl1.Series[0].Marker.Label.Format = "${Value:#.}";
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
                    if (s.Marker != null)
                        s.Marker.Label.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right;
                }
            }
        }
      
        private int _iRow;
        private void rptTopReport_ReportStart(object sender, EventArgs e)
        {
            this._iRow = 0;
            if (_InputParameters["DetailsType"] != null && _InputParameters["DetailsType"].ParamValue == _TypeName)//hide subreport if ReportType is the same as ParamType
                this.Cancel();
            else
            {
                //Dataset to hold data
                DataTable _ChartData = new DataTable();

                string criteria = bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "(Weight - NItems*ContainerWeight)" : "WasteCost";
                string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
                if (_InputParameters["Filter"].ParamValue != "")
                    where += " AND " + _InputParameters["Filter"].ParamValue;
				bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
				//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
				//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
				//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
				//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

                string subselect = "SELECT TOP " + _TopCount + " " + _TypeName + "Type.TypeName AS Name, " + _TypeName +
                    "TypeID as TypeID, Count(*) AS TransNum, Sum(WasteCost) AS Waste, Sum(Weight - NItems*ContainerWeight) AS Weights " +
                    " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID)" +
                    ((_TypeName == "Loss") ? "" : (" INNER JOIN " + _TypeName + "Type ON Weights." + _TypeName +
                    "TypeID = " + _TypeName + "Type.TypeID")) + ")" +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY Weights." + _TypeName + "TypeID, " + _TypeName + "Type.TypeName " +
                    " ORDER BY Sum(" + criteria + ") DESC";
                string select =
                    @"SELECT * FROM (" + subselect + ") ORDER BY Waste " + (bool.Parse(_InputParameters["IsHorizontal"].ParamValue) ? " ASC;" : " DESC;");
                _ChartData = VWA4Common.DB.Retrieve(select);
                criteria = bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "Weights" : "Waste";
				if (_ChartData.Rows.Count > 0)
				{
					double max = double.Parse(_ChartData.Compute("Max(Waste)", "").ToString());
					
                    this.chartControl1.ChartAreas[0].Axes["AxisY"].MajorTick.Step = VWA4Common.VWACommon.GetStep((int)max, 0);

					this.chartControl1.Series[0].Marker.Label.Font = new DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, new System.Drawing.Font("Arial", (_ChartData.Rows.Count > 20) ? 6F : 8F));


					this.DataSource = VWA4Common.DB.Retrieve(subselect);
					this.DataMember = _ChartData.TableName;
					this.chartControl1.DataSource = _ChartData;
					this.chartControl1.Series[0].ValueMembersY = criteria;
					this.chartControl1.ColorPalette = VWA4Common.VWACommon.GetPalette(_InputParameters["ChartColor"].ParamValue);
					this.chartControl1.Titles["footer"].Text = "TOP " + _TopCount + " " + _TypeName + (_TypeName == "Loss" ? "es" : "s");
					SetWeight();
					Set3D();
					SetHorizontal();
					if (_TypeName == "User")
					{
						DataDynamics.ActiveReports.TextBox txtTransNum = new DataDynamics.ActiveReports.TextBox();
						detail.Controls.Add(txtTransNum);
						txtWaste.Width = 0.64F;
						txtWeight.Width = txtWaste.Width;
						txtTransNum.Width = 0.44F;
						txtTransNum.Height = txtWaste.Height;
						txtTransNum.Top = txtWaste.Top;
						txtTransNum.Left = txtWeight.Left;
						txtWeight.Left = txtWeight.Left + 0.44F;
						txtWaste.Left = txtWeight.Left + 0.64F;
						txtTransNum.DataField = "TransNum";
						lblName.Visible = true;
						lblTrans.Visible = true;
						lblWeight.Visible = true;
						lblCost.Visible = true;
					}
					VWA4Common.GlobalSettings.SubReportWasPrinted = true;
				}
				else // don't show report if no data
				{
					this.Cancel();
				}
				//oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + VWA4Common.AppContext.DBPathName
			  //   + ";Persist Security Info=False"; 
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
