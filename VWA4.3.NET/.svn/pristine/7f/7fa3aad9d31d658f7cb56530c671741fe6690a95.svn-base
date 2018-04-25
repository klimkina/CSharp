using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Windows.Forms;

namespace Reports
{
    /// <summary>
    /// Summary description for rptFinancialDetails.
    /// </summary>
    public partial class rptFinancialSummary : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        public rptFinancialSummary(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }
        private DataDynamics.ActiveReports.TextBox[] txtSales;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCost;
        private DataDynamics.ActiveReports.TextBox[] txtMealCount;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPoints;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWasteAmount;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWastePercentage;
        private void InitCells()
        {
            int i;
            txtSales = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodCost = new DataDynamics.ActiveReports.TextBox[12];
            txtMealCount = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodCostPoints = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWasteAmount = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWastePercentage = new DataDynamics.ActiveReports.TextBox[12];
            for (i = 0; i < 12; i++)
            {
                txtSales[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCost[i] = new DataDynamics.ActiveReports.TextBox();
                txtMealCount[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPoints[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWasteAmount[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWastePercentage[i] = new DataDynamics.ActiveReports.TextBox();
            }
            // 
            // txtSales
            // 
            for (i = 0; i < 12; i++)
            {
                txtSales[i].Border.BottomColor = System.Drawing.Color.Black;
                txtSales[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSales[i].Border.LeftColor = System.Drawing.Color.Black;
                txtSales[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSales[i].Border.RightColor = System.Drawing.Color.Black;
                txtSales[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSales[i].Border.TopColor = System.Drawing.Color.Black;
                txtSales[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSales[i].Height = 0.1875F;
                txtSales[i].Left = 1F + i * 0.625F;
                txtSales[i].Name = "txtSales" + i;
                txtSales[i].Style = "font-size: 8pt; ";
                txtSales[i].Text = null;
                txtSales[i].Top = 0F;
                txtSales[i].Width = 0.625F;
                txtSales[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtSales[i]);
            }

            // 
            // txtFoodCost
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodCost[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCost[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCost[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCost[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCost[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCost[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCost[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCost[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCost[i].Height = 0.1875F;
                txtFoodCost[i].Left = 1F + i * 0.625F;
                txtFoodCost[i].Name = "txtFoodCost" + i;
                txtFoodCost[i].Style = "font-size: 8pt; ";
                txtFoodCost[i].Text = null;
                txtFoodCost[i].Top = 0.1875F;
                txtFoodCost[i].Width = 0.625F;
                txtFoodCost[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodCost[i]);
            }

            // 
            // txtMealCount
            // 
            for (i = 0; i < 12; i++)
            {
                txtMealCount[i].Border.BottomColor = System.Drawing.Color.Black;
                txtMealCount[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCount[i].Border.LeftColor = System.Drawing.Color.Black;
                txtMealCount[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCount[i].Border.RightColor = System.Drawing.Color.Black;
                txtMealCount[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCount[i].Border.TopColor = System.Drawing.Color.Black;
                txtMealCount[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCount[i].Height = 0.1875F;
                txtMealCount[i].Left = 1F + i * 0.625F;
                txtMealCount[i].Name = "txtMealCount" + i;
                txtMealCount[i].Style = "font-size: 8pt; ";
                txtMealCount[i].Text = null;
                txtMealCount[i].Top = 0.375F;
                txtMealCount[i].Width = 0.625F;
                this.detail.Controls.Add(txtMealCount[i]);
            }
            // 
            // txtFoodCostPoints
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodCostPoints[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostPoints[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPoints[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostPoints[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPoints[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostPoints[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPoints[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostPoints[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPoints[i].Height = 0.1875F;
                txtFoodCostPoints[i].Left = 1F + i * 0.625F;
                txtFoodCostPoints[i].Name = "txtFoodCostPoints" + i;
                txtFoodCostPoints[i].Style = "font-size: 8pt; ";
                txtFoodCostPoints[i].Text = null;
                txtFoodCostPoints[i].Top = 0.625F;
                txtFoodCostPoints[i].Width = 0.625F;
                txtFoodCostPoints[i].OutputFormat = _InputParameters["FinancialMode"].ParamValue == "Points" ? "#,##0.##%" : "$#,##0.##";
                this.detail.Controls.Add(txtFoodCostPoints[i]);
            }

            // 
            // txtFoodWasteAmount
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodWasteAmount[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWasteAmount[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmount[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWasteAmount[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmount[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWasteAmount[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmount[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWasteAmount[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmount[i].Height = 0.1875F;
                txtFoodWasteAmount[i].Left = 1F + i * 0.625F;
                txtFoodWasteAmount[i].Name = "txtFoodWasteAmount" + i;
                txtFoodWasteAmount[i].Style = "font-size: 8pt; ";
                txtFoodWasteAmount[i].Text = null;
                txtFoodWasteAmount[i].Top = 0.813F;
                txtFoodWasteAmount[i].Width = 0.625F;
                txtFoodWasteAmount[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodWasteAmount[i]);
            }

            // 
            // txtFoodWastePercentage
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodWastePercentage[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWastePercentage[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentage[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWastePercentage[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentage[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWastePercentage[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentage[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWastePercentage[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentage[i].Height = 0.1875F;
                txtFoodWastePercentage[i].Left = 1F + i * 0.625F;
                txtFoodWastePercentage[i].Name = "txtFoodWastePercentage" + i;
                txtFoodWastePercentage[i].Style = "font-size: 8pt; ";
                txtFoodWastePercentage[i].Text = null;
                txtFoodWastePercentage[i].Top = 1F;
                txtFoodWastePercentage[i].Width = 0.625F;
                txtFoodWastePercentage[i].OutputFormat = "#,##0.##%";
                this.detail.Controls.Add(txtFoodWastePercentage[i]);
            }
        }
        private void SetupHeader(DateTime start, DateTime end)
        {
            string format = "MMM";
            if (start.Year != end.AddDays(-1).Year)
                format = "MMM yyyy";
            hdrJan.Text = start.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrFeb.Text = start.AddMonths(1).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrMar.Text = start.AddMonths(2).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrApr.Text = start.AddMonths(3).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrMay.Text = start.AddMonths(4).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrJun.Text = start.AddMonths(5).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrJul.Text = start.AddMonths(6).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrAug.Text = start.AddMonths(7).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrSep.Text = start.AddMonths(8).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrOct.Text = start.AddMonths(9).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrNov.Text = start.AddMonths(10).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
            hdrDec.Text = start.AddMonths(11).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }
        private void rptFinancialSummary_ReportStart(object sender, EventArgs e)
        {
            InitCells();
            string format = " IIF(Sales = 0, 0, FoodCost/Sales)";
            if (_InputParameters["FinancialMode"].ParamValue == "Points")
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Points";
            else
            {
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";
                format = " IIF(MealCount = 0, 0, FoodCost/MealCount)";
                txtTotalFoodCostPoints.OutputFormat = "$#,##0.00";
            }
            DateTime start, end;
            start = DateTime.Parse(DateTime.Parse(_InputParameters["PeriodStartDate"].ParamValue).ToString("yyyy/MM/" + "01 00:00:00"));
            end = start.AddMonths(int.Parse(_InputParameters["NumberOfMonths"].ParamValue));
            string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue + 
                " AND PeriodStartDate >= #" + start +
                "# AND PeriodStartDate < #" + end + "#";
            string whereWaste = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue +
                " AND [Weights.Timestamp] >= #" + start +
                "# AND [Weights.Timestamp] < #" + end + "#";
            if (_InputParameters["Filter"].ParamValue != "")
                whereWaste += " AND " + _InputParameters["Filter"].ParamValue;
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    whereWaste += " AND (" + _InputParameters["WasteClasses"].ParamValue.ToString() + " )";
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    whereWaste += " AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")";

            string select, selectWaste;
            select = "SELECT SUM(FoodCostActual) AS FoodCost, " +
                        " SUM(FoodRevenueActual) AS Sales, " +
                        " SUM(MealCountActual) AS MealCount, " +
                        format + " AS Points, " +
                        " Format(PeriodStartDate, 'yyyy/mm') AS Period FROM Financials " +
                        where +
                        " GROUP BY Format(PeriodStartDate, 'yyyy/mm') " +
                        " ORDER BY Format(PeriodStartDate, 'yyyy/mm') ";
            selectWaste = "SELECT SUM(WasteCost) as Waste, Format([Weights.Timestamp], 'yyyy/mm') AS Period" +
                     " FROM (Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey) " +
                     (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                     whereWaste +
                     " GROUP BY Format([Weights.Timestamp], 'yyyy/mm') " +
                     " ORDER BY Format([Weights.Timestamp], 'yyyy/mm')";
                   
            DataTable dt, dtWaste;
            dt = VWA4Common.DB.Retrieve(select);
            dtWaste = VWA4Common.DB.Retrieve(selectWaste);
            SetupHeader(start, end);
            if (dt.Rows.Count > 0 || dtWaste.Rows.Count > 0)
            {
                int i, j = 0, k = 0;
                DateTime financeStart = DateTime.Now.AddYears(20),
                    column = start.AddDays(1), dataStart = DateTime.Now.AddYears(20);
                if (dtWaste.Rows.Count > 0)
                    dataStart = DateTime.Parse(dtWaste.Rows[0]["Period"].ToString() + "/01 00:00:00");
                if (dt.Rows.Count > 0)
                    financeStart = DateTime.Parse(dt.Rows[0]["Period"].ToString() + "/01 00:00:00");
                double totalSales = 0, totalFoodCost = 0, totalMealCount = 0;
                double totalFoodWasteAmount = 0;
                for (i = 0; i < 12; i++)
                {
                    if (financeStart > column || j >= dt.Rows.Count) // no data
                    {
                        txtSales[i].Text = "-";
                        txtFoodCost[i].Text = "-";
                        txtMealCount[i].Text = "-";
                        txtFoodCostPoints[i].Text = "-";
                    }
                    else 
                    {
                        double res = 0;
                        double.TryParse(dt.Rows[j]["Sales"].ToString(), out res);
                        txtSales[i].Value = res;
                        double.TryParse(dt.Rows[j]["FoodCost"].ToString(), out res);
                        txtFoodCost[i].Value = res;
                        double.TryParse(dt.Rows[j]["MealCount"].ToString(), out res);
                        txtMealCount[i].Value = res;
                        double.TryParse(dt.Rows[j]["Points"].ToString(), out res);
                        txtFoodCostPoints[i].Value = res;

                        if (_InputParameters["FinancialMode"].ParamValue == "Points" && (double)txtFoodCostPoints[i].Value > 1)
                            txtFoodCostPoints[i].ForeColor = Color.Red;
                        totalSales += (double)txtSales[i].Value;
                        totalFoodCost += (double)txtFoodCost[i].Value;
                        totalMealCount += (double)txtMealCount[i].Value;
                        j++;
                        if (j < dt.Rows.Count)
                            financeStart = DateTime.Parse(dt.Rows[j]["Period"].ToString() + "/01 00:00:00");
                    }
                    if (dataStart > column || k >= dtWaste.Rows.Count) // no data
                    {
                        
                        txtFoodWasteAmount[i].Text = "-";
                        txtFoodWastePercentage[i].Text = "-";
                    }
                    else
                    {
                        txtFoodWasteAmount[i].Value = double.Parse(dtWaste.Rows[k]["Waste"].ToString());
                        if (txtFoodCost[i].Text != "-" && (double)txtFoodCost[i].Value != 0)
                            txtFoodWastePercentage[i].Value = (double)txtFoodWasteAmount[i].Value / (double)txtFoodCost[i].Value;
                        else
                            txtFoodWastePercentage[i].Text = "-";
                        totalFoodWasteAmount += (double)txtFoodWasteAmount[i].Value;
                        k++;
                        if (k < dtWaste.Rows.Count)
                            dataStart = DateTime.Parse(dtWaste.Rows[j]["Period"].ToString() + "/01 00:00:00");
                    }
                    column = column.AddMonths(1);
                }
                if (totalSales > 0)
                {
                    txtTotalSales.Value = totalSales;
                    if (_InputParameters["FinancialMode"].ParamValue == "Points")
                        txtTotalFoodCostPoints.Value = totalFoodCost / totalSales;
                }
                if (totalFoodCost > 0)
                {
                    txtTotalFoodCost.Value = totalFoodCost;
                    txtTotalFoodWastePercentage.Value = totalFoodWasteAmount / totalFoodCost;
                }
                if (totalMealCount > 0)
                {
                    txtTotalMealCount.Value = totalMealCount;
                    if (_InputParameters["FinancialMode"].ParamValue == "CPM")
                        txtTotalFoodCostPoints.Value = totalFoodCost / totalMealCount;
                }
                if (totalFoodWasteAmount > 0)
                    txtTotalFoodWasteAmount.Value = totalFoodWasteAmount;
                
            }
            else // don't show report if no data
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {
                    txtWarning.Text = "Warning: No Data\n";
                    txtWarning.ForeColor = Color.Red;
                }
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = true;
        }
    }
}
