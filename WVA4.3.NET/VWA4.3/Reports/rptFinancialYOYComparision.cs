using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;


namespace Reports
{
    /// <summary>
    /// Summary description for rptFinancialSales.
    /// </summary>
    public partial class rptFinancialYOYComparision : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        public rptFinancialYOYComparision(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPointsPrior;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWasteAmountPrior;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWastePercentagePrior;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPoints;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWasteAmount;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWastePercentage;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPointsChanges;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWasteAmountChanges;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWastePercentageChanges;
        private void InitCells()
        {
            int i;
            txtFoodCostPointsPrior = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWasteAmountPrior = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWastePercentagePrior = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodCostPoints = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWasteAmount = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWastePercentage = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodCostPointsChanges = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWasteAmountChanges = new DataDynamics.ActiveReports.TextBox[12];
            txtFoodWastePercentageChanges = new DataDynamics.ActiveReports.TextBox[12];
            for (i = 0; i < 12; i++)
            {
                txtFoodCostPointsPrior[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWasteAmountPrior[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWastePercentagePrior[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPoints[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWasteAmount[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWastePercentage[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPointsChanges[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWasteAmountChanges[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWastePercentageChanges[i] = new DataDynamics.ActiveReports.TextBox();
            }
            
            // 
            // txtFoodCostPoints
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodCostPointsPrior[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostPointsPrior[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsPrior[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostPointsPrior[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsPrior[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostPointsPrior[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsPrior[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostPointsPrior[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsPrior[i].Height = 0.1875F;
                txtFoodCostPointsPrior[i].Left = 1F + i * 0.625F;
                txtFoodCostPointsPrior[i].Name = "txtFoodCostPointsPrior" + i;
                txtFoodCostPointsPrior[i].Style = "font-size: 8pt; ";
                txtFoodCostPointsPrior[i].Text = null;
                txtFoodCostPointsPrior[i].Top = 0.19F;
                txtFoodCostPointsPrior[i].Width = 0.625F;
                txtFoodCostPointsPrior[i].OutputFormat = _InputParameters["FinancialMode"].ParamValue == "Points" ? "#,##0.##%" : "$#,##0.##";
                this.detail.Controls.Add(txtFoodCostPointsPrior[i]);

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
                txtFoodCostPoints[i].Top = 0.94F;
                txtFoodCostPoints[i].Width = 0.625F;
                txtFoodCostPoints[i].OutputFormat = txtFoodCostPointsPrior[i].OutputFormat;
                this.detail.Controls.Add(txtFoodCostPoints[i]);

                txtFoodCostPointsChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostPointsChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostPointsChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostPointsChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostPointsChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsChanges[i].Height = 0.1875F;
                txtFoodCostPointsChanges[i].Left = 1F + i * 0.625F;
                txtFoodCostPointsChanges[i].Name = "txtFoodCostPointsChanges" + i;
                txtFoodCostPointsChanges[i].Style = "font-size: 8pt; ";
                txtFoodCostPointsChanges[i].Text = null;
                txtFoodCostPointsChanges[i].Top = 1.69F;
                txtFoodCostPointsChanges[i].Width = 0.625F;
                txtFoodCostPointsChanges[i].OutputFormat = txtFoodCostPointsPrior[i].OutputFormat;
                this.detail.Controls.Add(txtFoodCostPointsChanges[i]);
            }

            // 
            // txtFoodWasteAmount
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodWasteAmountPrior[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWasteAmountPrior[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountPrior[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWasteAmountPrior[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountPrior[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWasteAmountPrior[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountPrior[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWasteAmountPrior[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountPrior[i].Height = 0.1875F;
                txtFoodWasteAmountPrior[i].Left = 1F + i * 0.625F;
                txtFoodWasteAmountPrior[i].Name = "txtFoodWasteAmountPrior" + i;
                txtFoodWasteAmountPrior[i].Style = "font-size: 8pt; ";
                txtFoodWasteAmountPrior[i].Text = null;
                txtFoodWasteAmountPrior[i].Top = 0.38F;
                txtFoodWasteAmountPrior[i].Width = 0.625F;
                txtFoodWasteAmountPrior[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodWasteAmountPrior[i]);

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
                txtFoodWasteAmount[i].Top = 1.13F;
                txtFoodWasteAmount[i].Width = 0.625F;
                txtFoodWasteAmount[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodWasteAmount[i]);

                txtFoodWasteAmountChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWasteAmountChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWasteAmountChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWasteAmountChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWasteAmountChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWasteAmountChanges[i].Height = 0.1875F;
                txtFoodWasteAmountChanges[i].Left = 1F + i * 0.625F;
                txtFoodWasteAmountChanges[i].Name = "txtFoodWasteAmountChanges" + i;
                txtFoodWasteAmountChanges[i].Style = "font-size: 8pt; ";
                txtFoodWasteAmountChanges[i].Text = null;
                txtFoodWasteAmountChanges[i].Top = 1.88F;
                txtFoodWasteAmountChanges[i].Width = 0.625F;
                txtFoodWasteAmountChanges[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodWasteAmountChanges[i]);
            }

            // 
            // txtFoodWastePercentage
            // 
            for (i = 0; i < 12; i++)
            {
                txtFoodWastePercentagePrior[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWastePercentagePrior[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentagePrior[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWastePercentagePrior[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentagePrior[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWastePercentagePrior[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentagePrior[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWastePercentagePrior[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentagePrior[i].Height = 0.1875F;
                txtFoodWastePercentagePrior[i].Left = 1F + i * 0.625F;
                txtFoodWastePercentagePrior[i].Name = "txtFoodWastePercentagePrior" + i;
                txtFoodWastePercentagePrior[i].Style = "font-size: 8pt; ";
                txtFoodWastePercentagePrior[i].Text = null;
                txtFoodWastePercentagePrior[i].Top = 0.56F;
                txtFoodWastePercentagePrior[i].Width = 0.625F;
                txtFoodWastePercentagePrior[i].OutputFormat = "#,##0.##%";
                this.detail.Controls.Add(txtFoodWastePercentagePrior[i]);

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
                txtFoodWastePercentage[i].Top = 1.31F;
                txtFoodWastePercentage[i].Width = 0.625F;
                txtFoodWastePercentage[i].OutputFormat = "#,##0.##%";
                this.detail.Controls.Add(txtFoodWastePercentage[i]);

                txtFoodWastePercentageChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodWastePercentageChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentageChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodWastePercentageChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentageChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodWastePercentageChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentageChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodWastePercentageChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodWastePercentageChanges[i].Height = 0.1875F;
                txtFoodWastePercentageChanges[i].Left = 1F + i * 0.625F;
                txtFoodWastePercentageChanges[i].Name = "txtFoodWastePercentageChanges" + i;
                txtFoodWastePercentageChanges[i].Style = "font-size: 8pt; ";
                txtFoodWastePercentageChanges[i].Text = null;
                txtFoodWastePercentageChanges[i].Top = 2.06F;
                txtFoodWastePercentageChanges[i].Width = 0.625F;
                txtFoodWastePercentageChanges[i].OutputFormat = "#,##0.##%";
                this.detail.Controls.Add(txtFoodWastePercentageChanges[i]);
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
        private void rptFinancialYOYComparision_ReportStart(object sender, EventArgs e)
        {
            InitCells();
            //this._iRow = 0;

            string format = " IIF(Sales = 0, 0, FoodCost/Sales)";
            if (_InputParameters["FinancialMode"].ParamValue == "Points")
            {
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Points";
                hdrFoodCostPointsPrior.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Points";
                hdrFoodCostPointsChanges.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Points";
            }
            else 
            {
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";
                hdrFoodCostPointsPrior.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";
                hdrFoodCostPointsChanges.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";

                format = " IIF(MealCount = 0, 0, FoodCost/MealCount)";
                txtTotalFoodCostPointsPrior.OutputFormat = "$#,##0.##";
                txtTotalFoodCostPoints.OutputFormat = "$#,##0.##";
                txtTotalFoodCostPointsChanges.OutputFormat = "$#,##0.##";
            }
            DateTime start, end;
            start = DateTime.Parse(DateTime.Parse(_InputParameters["PeriodStartDate"].ParamValue).ToString("yyyy/MM/" + "01 00:00:00"));
            end = start.AddMonths(int.Parse(_InputParameters["NumberOfMonths"].ParamValue));
            string wherePrior = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue + 
                " AND PeriodStartDate >= #" + start.AddMonths(-12) +
                "# AND PeriodStartDate < #" + end.AddMonths(-12) + "#";
            string wherePriorWaste = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue +
                " AND [Weights.Timestamp] >= #" + start.AddMonths(-12) +
                "# AND [Weights.Timestamp] < #" + end.AddMonths(-12) + "#";
            string whereCurrent = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue +
                " AND PeriodStartDate >= #" + start +
                "# AND PeriodStartDate < #" + end + "#";
            string whereCurrentWaste = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue +
                " AND [Weights.Timestamp] >= #" + start +
                "# AND [Weights.Timestamp] < #" + end + "#";
            if (_InputParameters["Filter"].ParamValue != "")
            {
                wherePriorWaste += " AND " + _InputParameters["Filter"].ParamValue;
                whereCurrentWaste += " AND " + _InputParameters["Filter"].ParamValue;
            }
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//{
			//    wherePriorWaste += " AND (" + _InputParameters["WasteClasses"].ParamValue.ToString() + " )";
			//    whereCurrentWaste += " AND (" + _InputParameters["WasteClasses"].ParamValue.ToString() + " )";
			//}
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//{
			//    wherePriorWaste += " AND (" + VWA4Common.VWACommon.GetWasteClasses() + " )";
			//    whereCurrentWaste += " AND (" + VWA4Common.VWACommon.GetWasteClasses() + " )";
			//}

            string selectPrior, selectCurrent, selectPriorWaste, selectCurrentWaste;
            selectPrior = "SELECT SUM(FoodCostActual) AS FoodCost, " +
                        " SUM(FoodRevenueActual) AS Sales, " +
                        " SUM(MealCountActual) AS MealCount, " +
                        format + " AS Points, " +
                        " Format(PeriodStartDate, 'yyyy/mm') AS Period FROM Financials " +
                        wherePrior +
                        " GROUP BY Format(PeriodStartDate, 'yyyy/mm') " +
                        " ORDER BY Format(PeriodStartDate, 'yyyy/mm') ";
            selectPriorWaste = "SELECT SUM(WasteCost) as Waste, Format([Weights.Timestamp], 'yyyy/mm') AS Period" +
                         " FROM (Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey) " +
                         (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                         wherePriorWaste +
                         " GROUP BY Format([Weights.Timestamp], 'yyyy/mm') " +
                         " ORDER BY Format([Weights.Timestamp], 'yyyy/mm')";
            selectCurrent = "SELECT SUM(FoodCostActual) AS FoodCost, " +
                        " SUM(FoodRevenueActual) AS Sales, " +
                        " SUM(MealCountActual) AS MealCount, " +
                        format + " AS Points, " +
                        " Format(PeriodStartDate, 'yyyy/mm') AS Period FROM Financials " +
                        whereCurrent +
                        " GROUP BY Format(PeriodStartDate, 'yyyy/mm') " +
                        " ORDER BY Format(PeriodStartDate, 'yyyy/mm') ";
            selectCurrentWaste = "SELECT SUM(WasteCost) as Waste, Format([Weights.Timestamp], 'yyyy/mm') AS Period" +
                     " FROM (Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey) " +
                     (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                     whereCurrentWaste +
                     " GROUP BY Format([Weights.Timestamp], 'yyyy/mm') " +
                     " ORDER BY Format([Weights.Timestamp], 'yyyy/mm')";
                   
            DataTable dtPrior, dtPriorWaste, dtCurrent, dtCurrentWaste;
            dtPrior = VWA4Common.DB.Retrieve(selectPrior);
            dtPriorWaste = VWA4Common.DB.Retrieve(selectPriorWaste);
            dtCurrent = VWA4Common.DB.Retrieve(selectCurrent);
            dtCurrentWaste = VWA4Common.DB.Retrieve(selectCurrentWaste);
            SetupHeader(start, end);
            if (dtPrior.Rows.Count > 0 || dtPriorWaste.Rows.Count > 0 || dtCurrent.Rows.Count > 0 || dtCurrentWaste.Rows.Count > 0)
            {
                // set dates of start finance data and waste data
                int i, financePrior = 0, financeCurrent = 0, dataPrior = 0, dataCurrent = 0, numChanges = 0;
                DateTime financePriorStart = DateTime.Now.AddYears(20), financeCurrentStart = DateTime.Now.AddYears(20),
                    column = start.AddDays(1), dataPriorStart = DateTime.Now.AddYears(20), dataCurrentStart = DateTime.Now.AddYears(20);
                if (dtPrior.Rows.Count > 0)
                    financePriorStart = DateTime.Parse(dtPrior.Rows[0]["Period"].ToString() + "/01 00:00:00").AddMonths(12);
                if (dtPriorWaste.Rows.Count > 0)
                    dataPriorStart = DateTime.Parse(dtPriorWaste.Rows[0]["Period"].ToString() + "/01 00:00:00").AddMonths(12);
                if (dtCurrent.Rows.Count > 0)
                    financeCurrentStart = DateTime.Parse(dtCurrent.Rows[0]["Period"].ToString() + "/01 00:00:00");
                if (dtCurrentWaste.Rows.Count > 0)
                    dataCurrentStart = DateTime.Parse(dtCurrentWaste.Rows[0]["Period"].ToString() + "/01 00:00:00");
                double totalFoodWasteAmountPrior = 0, totalFoodWasteAmount = 0;
                double totalSales = 0, totalFoodCost = 0, totalMealCount = 0;
                double totalSalesPrior = 0, totalFoodCostPrior = 0, totalMealCountPrior = 0;
                for (i = 0; i < 12; i++)
                {
                    // no data for the prior year for this column
                    if (dataPriorStart > column || dataPrior >= dtPriorWaste.Rows.Count) // no data
                    {

                        txtFoodWasteAmountPrior[i].Text = "-";
                        txtFoodWastePercentagePrior[i].Text = "-";
                    }
                    else
                    {
                        txtFoodWasteAmountPrior[i].Value = double.Parse(dtPriorWaste.Rows[dataPrior]["Waste"].ToString());
                        if (financePriorStart == dataPriorStart)
                        {
                            double foodCost = 0;
                            if (dtPrior.Rows.Count > 0)
                            {
                                double.TryParse(dtPrior.Rows[dataPrior]["FoodCost"].ToString(), out foodCost);
                                double.TryParse(dtPrior.Rows[dataPrior]["Sales"].ToString(), out totalSalesPrior);
                                double.TryParse(dtPrior.Rows[dataPrior]["MealCount"].ToString(), out totalMealCountPrior);
                            }
                            totalFoodCostPrior += foodCost;

                            if (foodCost != 0)
                            {
                                txtFoodWastePercentagePrior[i].Value =
                                    (double)txtFoodWasteAmountPrior[i].Value / foodCost;
                            }
                            else
                                txtFoodWastePercentagePrior[i].Text = "-";
                        }
                        else
                            txtFoodWastePercentagePrior[i].Text = "-";
                        totalFoodWasteAmountPrior += (double)txtFoodWasteAmountPrior[i].Value;
                        dataPrior++;
                        if (dataPrior < dtPriorWaste.Rows.Count)
                            dataPriorStart = DateTime.Parse(dtPriorWaste.Rows[dataPrior]["Period"].ToString() + "/01 00:00:00").AddMonths(12);
                    }
                    // no data for the current year for this column
                    if (dataCurrentStart > column || dataCurrent >= dtCurrentWaste.Rows.Count) // no data
                    {

                        txtFoodWasteAmount[i].Text = "-";
                        txtFoodWastePercentage[i].Text = "-";
                        txtFoodWasteAmountChanges[i].Text = "-";
                        txtFoodWastePercentageChanges[i].Text = "-";
                    }
                    else
                    {
                        double foodWasteAmount = 0;
                        double.TryParse(dtCurrentWaste.Rows[dataCurrent]["Waste"].ToString(), out foodWasteAmount);
                        txtFoodWasteAmount[i].Value = foodWasteAmount;
                        if (financeCurrentStart == dataCurrentStart)
                        {
                            double foodCost = 0;
                            if (dtPrior.Rows.Count > 0)
                            {
                                double.TryParse(dtPrior.Rows[dataPrior]["FoodCost"].ToString(), out foodCost);
                                double.TryParse(dtPrior.Rows[dataPrior]["Sales"].ToString(), out totalSalesPrior);
                                double.TryParse(dtPrior.Rows[dataPrior]["MealCount"].ToString(), out totalMealCountPrior);
                            }

                            if (foodCost != 0)
                                txtFoodWastePercentage[i].Value = (double)txtFoodWasteAmount[i].Value / foodCost;
                            else
                                txtFoodWastePercentage[i].Text = "-";
                        }
                        else
                            txtFoodWastePercentage[i].Text = "-";

                        if (txtFoodWasteAmountPrior[i].Text != "-")
                        {
                            txtFoodWasteAmountChanges[i].Value = (double)txtFoodWasteAmount[i].Value - (double)txtFoodWasteAmountPrior[i].Value;
                            numChanges++;
                        }
                        else
                            txtFoodWasteAmountChanges[i].Text = "-";
                        if (txtFoodWastePercentagePrior[i].Text != "-")
                            txtFoodWastePercentageChanges[i].Value = (double)txtFoodWastePercentage[i].Value - (double)txtFoodWastePercentagePrior[i].Value;
                        else
                            txtFoodWastePercentageChanges[i].Text = "-";

                        totalFoodWasteAmount += (double)txtFoodWasteAmount[i].Value;
                        dataCurrent++;
                        if (dataCurrent < dtCurrentWaste.Rows.Count)
                            dataCurrentStart = DateTime.Parse(dtCurrentWaste.Rows[dataCurrent]["Period"].ToString() + "/01 00:00:00");
                    }
                    // no finance data for the prior year for this column
                    if (financePriorStart > column || financePrior >= dtPrior.Rows.Count) // no data
                    {
                        txtFoodCostPointsPrior[i].Text = "-";
                    }
                    else
                    {
                        double foodCostPointsPrior = 0;
                        double.TryParse(dtPrior.Rows[financePrior]["Points"].ToString(), out foodCostPointsPrior);
                        txtFoodCostPointsPrior[i].Value = foodCostPointsPrior;
                        if (_InputParameters["FinancialMode"].ParamValue == "Points" && (double)txtFoodCostPoints[i].Value > 1)
                            txtFoodCostPoints[i].ForeColor = Color.Red;
                        financePrior++;
                        if (financePrior < dtPrior.Rows.Count)
                            financePriorStart = DateTime.Parse(dtPrior.Rows[financePrior]["Period"].ToString() + "/01 00:00:00").AddMonths(12);
                    }
                    // no finance data for the current year for this column
                    if (financeCurrentStart > column || financeCurrent >= dtCurrent.Rows.Count) // no data
                    {
                        txtFoodCostPoints[i].Text = "-";
                        txtFoodCostPointsChanges[i].Text = "-";
                    }
                    else
                    {
                        double foodCostPoints = 0;
                        double.TryParse(dtCurrent.Rows[financeCurrent]["Points"].ToString(), out foodCostPoints);
                        txtFoodCostPoints[i].Value = foodCostPoints;
                        if (_InputParameters["FinancialMode"].ParamValue == "Points" && (double)txtFoodCostPoints[i].Value > 1)
                            txtFoodCostPoints[i].ForeColor = Color.Red;

                        if (txtFoodCostPointsPrior[i].Text != "-")
                            txtFoodCostPointsChanges[i].Value = (double)txtFoodCostPoints[i].Value - (double)txtFoodCostPointsPrior[i].Value;
                        else
                            txtFoodCostPointsChanges[i].Text = "-";

                        financeCurrent++;
                        if (financeCurrent < dtCurrent.Rows.Count)
                            financeCurrentStart = DateTime.Parse(dtCurrent.Rows[financeCurrent]["Period"].ToString() + "/01 00:00:00");
                    }
                    column = column.AddMonths(1);
                }


                double temp = 0, totalFoodCostPoints = 0, totalFoodCostPointsPrior = 0;
                if (totalFoodWasteAmountPrior > 0)
                {
                    txtTotalFoodWasteAmountPrior.Value = totalFoodWasteAmountPrior;
                    if (totalFoodCostPrior > 0)
                    {
                        temp = totalFoodWasteAmountPrior / totalFoodCostPrior;
                        txtTotalFoodWastePercentagePrior.Value = temp;
                    }
                }
                if (totalFoodWasteAmount > 0)
                {
                    txtTotalFoodWasteAmount.Value = totalFoodWasteAmount;
                    if (totalFoodCost > 0)
                    {
                        txtTotalFoodWastePercentage.Value = totalFoodWasteAmount / totalFoodCost;
                        txtTotalFoodWastePercentageChanges.Value = (double)txtTotalFoodWastePercentage.Value - temp;
                    }
                    txtTotalFoodWasteAmountChanges.Value = totalFoodWasteAmount - totalFoodWasteAmountPrior;
                }

                if (totalSalesPrior > 0 && _InputParameters["FinancialMode"].ParamValue == "Points")
                {
                    totalFoodCostPointsPrior = totalFoodCostPrior / totalSalesPrior;
                    txtTotalFoodCostPointsPrior.Value = totalFoodCostPointsPrior;
                }

                if (totalMealCountPrior > 0 && _InputParameters["FinancialMode"].ParamValue == "CPM")
                {
                    totalFoodCostPointsPrior = totalFoodCostPrior / totalMealCountPrior;
                    txtTotalFoodCostPointsPrior.Value = totalFoodCostPointsPrior;
                }

                if (totalSales > 0 && _InputParameters["FinancialMode"].ParamValue == "Points")
                {
                    totalFoodCostPoints = totalFoodCost / totalSales;
                    txtTotalFoodCostPoints.Value = totalFoodCostPoints;
                }

                if (totalMealCount > 0 && _InputParameters["FinancialMode"].ParamValue == "CPM")
                {
                    totalFoodCostPoints = totalFoodCost / totalMealCount;
                    txtTotalFoodCostPoints.Value = totalFoodCostPoints;
                }
                if (totalFoodCostPoints > 0 || totalFoodCostPointsPrior > 0)
                    txtTotalFoodCostPointsChanges.Value = totalFoodCostPoints - totalFoodCostPointsPrior;
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

        //private int _iRow;
        //private void detail_Format(object sender, EventArgs e)
        //{
        //    //// Check _iRow value to see if we need to highlight the row or not.
        //    //if (this._iRow % 2 == 0)
        //    //    this.detail.BackColor = Color.Transparent;
        //    //else
        //    //    this.detail.BackColor = Color.LightYellow;
        //    //this._iRow++;
        //}
    }
}
