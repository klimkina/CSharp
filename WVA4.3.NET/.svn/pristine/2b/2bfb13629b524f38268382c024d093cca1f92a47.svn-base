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
    /// Summary description for rptBudgetActualComparison.
    /// </summary>
    public partial class rptBudgetActualComparison : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        public rptBudgetActualComparison(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }
        private DataDynamics.ActiveReports.TextBox[] txtSalesBudget;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostBudget;
        private DataDynamics.ActiveReports.TextBox[] txtMealCountBudget;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPointsBudget;
        private DataDynamics.ActiveReports.TextBox[] txtSales;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCost;
        private DataDynamics.ActiveReports.TextBox[] txtMealCount;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPoints;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWasteAmount;
        private DataDynamics.ActiveReports.TextBox[] txtFoodWastePercentage;
        private DataDynamics.ActiveReports.TextBox[] txtSalesChanges;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostChanges;
        private DataDynamics.ActiveReports.TextBox[] txtMealCountChanges;
        private DataDynamics.ActiveReports.TextBox[] txtFoodCostPointsChanges;
        private void InitCells(int numMonths)
        {
            int i;

            txtSalesBudget = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCostBudget = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtMealCountBudget = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCostPointsBudget = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtSales = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCost = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtMealCount = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCostPoints = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodWasteAmount = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodWastePercentage = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtSalesChanges = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCostChanges = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtMealCountChanges = new DataDynamics.ActiveReports.TextBox[numMonths];
            txtFoodCostPointsChanges = new DataDynamics.ActiveReports.TextBox[numMonths];

            for (i = 0; i < numMonths; i++)
            {
                txtSalesBudget[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostBudget[i] = new DataDynamics.ActiveReports.TextBox();
                txtMealCountBudget[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPointsBudget[i] = new DataDynamics.ActiveReports.TextBox();
                txtSales[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCost[i] = new DataDynamics.ActiveReports.TextBox();
                txtMealCount[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPoints[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWasteAmount[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodWastePercentage[i] = new DataDynamics.ActiveReports.TextBox();
                txtSalesChanges[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostChanges[i] = new DataDynamics.ActiveReports.TextBox();
                txtMealCountChanges[i] = new DataDynamics.ActiveReports.TextBox();
                txtFoodCostPointsChanges[i] = new DataDynamics.ActiveReports.TextBox();
            }

            // 
            // txtSales
            // 
            for (i = 0; i < numMonths; i++)
            {
                txtSalesBudget[i].Border.BottomColor = System.Drawing.Color.Black;
                txtSalesBudget[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesBudget[i].Border.LeftColor = System.Drawing.Color.Black;
                txtSalesBudget[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesBudget[i].Border.RightColor = System.Drawing.Color.Black;
                txtSalesBudget[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesBudget[i].Border.TopColor = System.Drawing.Color.Black;
                txtSalesBudget[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesBudget[i].Height = 0.1875F;
                txtSalesBudget[i].Left = 1F + i * 0.625F;
                txtSalesBudget[i].Name = "txtSalesBudget" + i;
                txtSalesBudget[i].Style = "font-size: 8pt; ";
                txtSalesBudget[i].Text = null;
                txtSalesBudget[i].Top = 0.19F;
                txtSalesBudget[i].Width = 0.625F;
                txtSalesBudget[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtSalesBudget[i]);

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
                txtSales[i].Top = 1.13F;
                txtSales[i].Width = 0.625F;
                txtSales[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtSales[i]);

                txtSalesChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtSalesChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtSalesChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtSalesChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtSalesChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtSalesChanges[i].Height = 0.1875F;
                txtSalesChanges[i].Left = 1F + i * 0.625F;
                txtSalesChanges[i].Name = "txtSalesChanges" + i;
                txtSalesChanges[i].Style = "font-size: 8pt; ";
                txtSalesChanges[i].Text = null;
                txtSalesChanges[i].Top = 2.44F;
                txtSalesChanges[i].Width = 0.625F;
                txtSalesChanges[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtSalesChanges[i]);
            }

            // 
            // txtFoodCost
            // 
            for (i = 0; i < numMonths; i++)
            {
                txtFoodCostBudget[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostBudget[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostBudget[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostBudget[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostBudget[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostBudget[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostBudget[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostBudget[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostBudget[i].Height = 0.1875F;
                txtFoodCostBudget[i].Left = 1F + i * 0.625F;
                txtFoodCostBudget[i].Name = "txtFoodCostBudget" + i;
                txtFoodCostBudget[i].Style = "font-size: 8pt; ";
                txtFoodCostBudget[i].Text = null;
                txtFoodCostBudget[i].Top = 0.38F;
                txtFoodCostBudget[i].Width = 0.625F;
                txtFoodCostBudget[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodCostBudget[i]);

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
                txtFoodCost[i].Top = 1.31F;
                txtFoodCost[i].Width = 0.625F;
                txtFoodCost[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodCost[i]);

                txtFoodCostChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostChanges[i].Height = 0.1875F;
                txtFoodCostChanges[i].Left = 1F + i * 0.625F;
                txtFoodCostChanges[i].Name = "txtFoodCostChanges" + i;
                txtFoodCostChanges[i].Style = "font-size: 8pt; ";
                txtFoodCostChanges[i].Text = null;
                txtFoodCostChanges[i].Top = 2.63F;
                txtFoodCostChanges[i].Width = 0.625F;
                txtFoodCostChanges[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodCostChanges[i]);
            }

            // 
            // txtMealCount
            // 
            for (i = 0; i < numMonths; i++)
            {
                txtMealCountBudget[i].Border.BottomColor = System.Drawing.Color.Black;
                txtMealCountBudget[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountBudget[i].Border.LeftColor = System.Drawing.Color.Black;
                txtMealCountBudget[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountBudget[i].Border.RightColor = System.Drawing.Color.Black;
                txtMealCountBudget[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountBudget[i].Border.TopColor = System.Drawing.Color.Black;
                txtMealCountBudget[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountBudget[i].Height = 0.1875F;
                txtMealCountBudget[i].Left = 1F + i * 0.625F;
                txtMealCountBudget[i].Name = "txtMealCountBudget" + i;
                txtMealCountBudget[i].Style = "font-size: 8pt; ";
                txtMealCountBudget[i].Text = null;
                txtMealCountBudget[i].Top = 0.56F;
                txtMealCountBudget[i].Width = 0.625F;
                txtMealCountBudget[i].OutputFormat = "#,##0.";
                this.detail.Controls.Add(txtMealCountBudget[i]);

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
                txtMealCount[i].Top = 1.5F;
                txtMealCount[i].Width = 0.625F;
                txtMealCount[i].OutputFormat = "#,##0.";
                this.detail.Controls.Add(txtMealCount[i]);

                txtMealCountChanges[i].Border.BottomColor = System.Drawing.Color.Black;
                txtMealCountChanges[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountChanges[i].Border.LeftColor = System.Drawing.Color.Black;
                txtMealCountChanges[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountChanges[i].Border.RightColor = System.Drawing.Color.Black;
                txtMealCountChanges[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountChanges[i].Border.TopColor = System.Drawing.Color.Black;
                txtMealCountChanges[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtMealCountChanges[i].Height = 0.1875F;
                txtMealCountChanges[i].Left = 1F + i * 0.625F;
                txtMealCountChanges[i].Name = "txtMealCountChanges" + i;
                txtMealCountChanges[i].Style = "font-size: 8pt; ";
                txtMealCountChanges[i].Text = null;
                txtMealCountChanges[i].Top = 2.81F;
                txtMealCountChanges[i].Width = 0.625F;
                txtMealCountChanges[i].OutputFormat = "#,##0.";
                this.detail.Controls.Add(txtMealCountChanges[i]);
            }

            // 
            // txtFoodCostPoints
            // 
            for (i = 0; i < numMonths; i++)
            {
                txtFoodCostPointsBudget[i].Border.BottomColor = System.Drawing.Color.Black;
                txtFoodCostPointsBudget[i].Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsBudget[i].Border.LeftColor = System.Drawing.Color.Black;
                txtFoodCostPointsBudget[i].Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsBudget[i].Border.RightColor = System.Drawing.Color.Black;
                txtFoodCostPointsBudget[i].Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsBudget[i].Border.TopColor = System.Drawing.Color.Black;
                txtFoodCostPointsBudget[i].Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
                txtFoodCostPointsBudget[i].Height = 0.1875F;
                txtFoodCostPointsBudget[i].Left = 1F + i * 0.625F;
                txtFoodCostPointsBudget[i].Name = "txtFoodCostPointsBudget" + i;
                txtFoodCostPointsBudget[i].Style = "font-size: 8pt; ";
                txtFoodCostPointsBudget[i].Text = null;
                txtFoodCostPointsBudget[i].Top = 0.75F;
                txtFoodCostPointsBudget[i].Width = 0.625F;
                txtFoodCostPointsBudget[i].OutputFormat = _InputParameters["FinancialMode"].ParamValue == "Points" ? "#,##0.##%" : "$#,##0.##";
                this.detail.Controls.Add(txtFoodCostPointsBudget[i]);

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
                txtFoodCostPoints[i].Top = 1.69F;
                txtFoodCostPoints[i].Width = 0.625F;
                txtFoodCostPoints[i].OutputFormat = txtFoodCostPointsBudget[i].OutputFormat;
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
                txtFoodCostPointsChanges[i].Top = 3F;
                txtFoodCostPointsChanges[i].Width = 0.625F;
                txtFoodCostPointsChanges[i].OutputFormat = txtFoodCostPointsBudget[i].OutputFormat;
                this.detail.Controls.Add(txtFoodCostPointsChanges[i]);
            }

            // 
            // txtFoodWasteAmount
            // 
            for (i = 0; i < numMonths; i++)
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
                txtFoodWasteAmount[i].Top = 1.88F;
                txtFoodWasteAmount[i].Width = 0.625F;
                txtFoodWasteAmount[i].OutputFormat = "$#,##0";
                this.detail.Controls.Add(txtFoodWasteAmount[i]);
            }

            // 
            // txtFoodWastePercentage
            // 
            for (i = 0; i < numMonths; i++)
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
                txtFoodWastePercentage[i].Top = 2.06F;
                txtFoodWastePercentage[i].Width = 0.625F;
                txtFoodWastePercentage[i].OutputFormat = "#,##0.##%";
                this.detail.Controls.Add(txtFoodWastePercentage[i]);
            }

            line1.X2 = 0.3F + 0.625F * (numMonths + 1);
            line2.X1 = 0.3F + 0.625F * (numMonths + 1);
            line2.X2 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;
            line3.X1 = 0.3F + 0.625F * (numMonths + 1);
            line3.X2 = 0.3F + 0.625F * (numMonths + 1);
            line4.X1 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;
            line4.X2 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;
            line7.X1 = 0.3F + 0.625F * (numMonths + 1);
            line7.X2 = 0.3F + 0.625F * (numMonths + 1);
            line8.X1 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;
            line8.X2 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;
            line9.X1 = 0.3F + 0.625F * (numMonths + 1);
            line9.X2 = 0.3F + 0.625F * (numMonths + 1) + 0.88F;

            hdrTotal.Left = 0.3F + 0.625F * (numMonths + 1);

            txtTotalSalesBudget.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCostBudget.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalMealCountBudget.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCostPointsBudget.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalSales.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCost.Left = 0.3F + 0.625F * (numMonths + 1);

            txtTotalMealCount.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCostPoints.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodWastePercentage.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodWasteAmount.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalSalesChanges.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCostChanges.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalMealCountChanges.Left = 0.3F + 0.625F * (numMonths + 1);
            txtTotalFoodCostPointsChanges.Left = 0.3F + 0.625F * (numMonths + 1);
        }
        private void SetupHeader(DateTime start, DateTime end)
        {
            DateTime temp = start;
            string format = "MMM";
            if (start.Year != end.AddDays(-1).Year)
                format = "MMM yyyy";
            hdrJan.Text = start.ToString(format, System.Globalization.CultureInfo.CurrentCulture);

            temp = temp.AddMonths(1);
            if (temp < end)
            {
                hdrFeb.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrMar.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrApr.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrMay.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrJun.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrJul.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrAug.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrSep.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrOct.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrNov.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }
            if (temp < end)
            {
                hdrDec.Text = temp.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddMonths(1);
            }

        }
        private void rptBudgetActualComparison_ReportStart(object sender, EventArgs e)
        {
            int numMonths = int.Parse(_InputParameters["NumberOfMonths"].ParamValue);
            InitCells(numMonths);
            string format = " IIF( Sales = 0, 0, FoodCost/Sales)", formatBudget = " IIF(SalesBudg = 0, 0, FoodCostBudg/SalesBudg)";
            if (_InputParameters["FinancialMode"].ParamValue == "Points")
            {
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Food Points";
                hdrFoodCostPointsBudget.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Food Points";
                hdrFoodCostPointsChanges.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Food Points";
            }
            else 
            {
                hdrFoodCostPoints.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";
                hdrFoodCostPointsBudget.Text = //VWA4Common.VWACommon.WasteProfile[0] +
					"CPM";
                hdrFoodCostPointsChanges.Text = //VWA4Common.VWACommon.WasteProfile[0] + 
					"CPM";

                format = " IIF(MealCount = 0, 0, FoodCost/MealCount)";
                formatBudget = " IIF(MealCountBudg = 0, 0, FoodCostBudg/MealCountBudg)";
                txtTotalFoodCostPointsBudget.OutputFormat = "$#,##0.00";
                txtTotalFoodCostPoints.OutputFormat = "$#,##0.00";
                txtTotalFoodCostPointsChanges.OutputFormat = "$#,##0.00";
            }

            DateTime start, end;
            start = DateTime.Parse(DateTime.Parse(_InputParameters["PeriodStartDate"].ParamValue).ToString("yyyy/MM/" + "01 00:00:00"));
            end = start.AddMonths(numMonths);
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
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else //if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select, selectWaste;
            select = "SELECT SUM(FoodCostBudget) AS FoodCostBudg, " +
                        " SUM(FoodRevenueBudget) AS SalesBudg, " +
                        " SUM(MealCountBudget) AS MealCountBudg, " +
                        formatBudget + " AS PointsBudg, " +
                        " SUM(FoodCostActual) AS FoodCost, " +
                        " SUM(FoodRevenueActual) AS Sales, " +
                        " SUM(MealCountActual) AS MealCount, " +
                        format + " AS Points, " +
                        " Format(PeriodStartDate, 'yyyy/mm') AS Period FROM Financials " +
                        where +
                        " GROUP BY Format(PeriodStartDate, 'yyyy/mm') " +
                        " ORDER BY Format(PeriodStartDate, 'yyyy/mm') ";
            selectWaste = "SELECT SUM(WasteCost) as Waste, Format([Weights.Timestamp], 'yyyy/mm') AS Period" +
                         " FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
                         whereWaste +
                         " GROUP BY Format([Weights.Timestamp], 'yyyy/mm') " +
                         " ORDER BY Format([Weights.Timestamp], 'yyyy/mm')";

            DataTable dt, dtWaste;
            dt = VWA4Common.DB.Retrieve(select);
            dtWaste = VWA4Common.DB.Retrieve(selectWaste);

            SetupHeader(start, end);
            if (dt.Rows.Count > 0 || dtWaste.Rows.Count > 0)
            {
                int i, finance = 0, data = 0;
                DateTime financeStart = DateTime.Now.AddYears(20),
                    column = start.AddDays(1), dataStart = DateTime.Now.AddYears(20);
                if (dt.Rows.Count > 0)
                    financeStart = DateTime.Parse(dt.Rows[0]["Period"].ToString() + "/01 00:00:00");
                if (dtWaste.Rows.Count > 0)
                    dataStart = DateTime.Parse(dtWaste.Rows[0]["Period"].ToString() + "/01 00:00:00");
                double totalFoodCostPointsBudget = 0, totalSalesBudget = 0, totalFoodCostBudget = 0, totalMealCountBudget = 0;
                double totalSales = 0, totalFoodCost = 0, totalMealCount = 0, totalFoodCostPoints = 0, totalFoodWasteAmount = 0, totalFoodWastePercentage = 0;
                double totalFoodCostPointsChanges = 0;
                for (i = 0; i < numMonths; i++)
                {

                    if (financeStart > column || finance >= dt.Rows.Count) // no data
                    {
                        txtSalesBudget[i].Text = "-";
                        txtFoodCostBudget[i].Text = "-";
                        txtMealCountBudget[i].Text = "-";
                        txtFoodCostPointsBudget[i].Text = "-";
                        txtSales[i].Text = "-";
                        txtFoodCost[i].Text = "-";
                        txtMealCount[i].Text = "-";
                        txtFoodCostPoints[i].Text = "-";
                        txtSalesChanges[i].Text = "-";
                        txtFoodCostChanges[i].Text = "-";
                        txtMealCountChanges[i].Text = "-";
                        txtFoodCostPointsChanges[i].Text = "-";
                    }
                    else
                    {
                        double res = 0;
                        double.TryParse(dt.Rows[finance]["SalesBudg"].ToString(), out res);
                        txtSalesBudget[i].Value = res;
                        double.TryParse(dt.Rows[finance]["FoodCostBudg"].ToString(), out res);
                        txtFoodCostBudget[i].Value = res;
                        double.TryParse(dt.Rows[finance]["MealCountBudg"].ToString(), out res);
                        txtMealCountBudget[i].Value = res;
                        double.TryParse(dt.Rows[finance]["PointsBudg"].ToString(), out res);
                        txtFoodCostPointsBudget[i].Value = res;
                        double.TryParse(dt.Rows[finance]["Sales"].ToString(), out res);
                        txtSales[i].Value = res;
                        double.TryParse(dt.Rows[finance]["FoodCost"].ToString(), out res);
                        txtFoodCost[i].Value = res;
                        double.TryParse(dt.Rows[finance]["MealCount"].ToString(), out res);
                        txtMealCount[i].Value = res;
                        double.TryParse(dt.Rows[finance]["Points"].ToString(), out res);
                        txtFoodCostPoints[i].Value = res;

                        txtSalesChanges[i].Value = (double)txtSales[i].Value - (double)txtSalesBudget[i].Value;
                        txtFoodCostChanges[i].Value = (double)txtFoodCost[i].Value - (double)txtFoodCostBudget[i].Value;
                        txtMealCountChanges[i].Value = (double)txtMealCount[i].Value - (double)txtMealCountBudget[i].Value;
                        txtFoodCostPointsChanges[i].Value = (double)txtFoodCostPoints[i].Value - (double)txtFoodCostPointsBudget[i].Value;

                        totalSalesBudget += (double)txtSalesBudget[i].Value;
                        totalFoodCostBudget += (double)txtFoodCostBudget[i].Value;
                        totalMealCountBudget += (double)txtMealCountBudget[i].Value;

                        totalSales += (double)txtSales[i].Value;
                        totalFoodCost += (double)txtFoodCost[i].Value;
                        totalMealCount += (double)txtMealCount[i].Value;
                        totalFoodCostPoints += (double)txtFoodCostPoints[i].Value;

                        finance++;
                        if (finance < dt.Rows.Count)
                            financeStart = DateTime.Parse(dt.Rows[finance]["Period"].ToString() + "/01 00:00:00");
                    }
                    if (dataStart > column || data >= dtWaste.Rows.Count) // no data
                    {

                        txtFoodWasteAmount[i].Text = "-";
                        txtFoodWastePercentage[i].Text = "-";
                    }
                    else
                    {
                        txtFoodWasteAmount[i].Value = double.Parse(dtWaste.Rows[data]["Waste"].ToString());
                        if (txtFoodCost[i].Text != "-" && (double)txtFoodCost[i].Value != 0)
                        {
                            txtFoodWastePercentage[i].Value =
                                    (double)txtFoodWasteAmount[i].Value / (double)txtFoodCost[i].Value;
                        }
                        else
                            txtFoodWastePercentage[i].Text = "-";

                        totalFoodWasteAmount += (double)txtFoodWasteAmount[i].Value;
                        data++;
                        if (data < dtWaste.Rows.Count)
                            dataStart = DateTime.Parse(dtWaste.Rows[data]["Period"].ToString() + "/01 00:00:00");
                    }

                    column = column.AddMonths(1);
                }


                if (dt.Rows.Count > 0)
                {
                    txtTotalSalesBudget.Value = totalSalesBudget;
                    if (totalSalesBudget > 0 && _InputParameters["FinancialMode"].ParamValue == "Points")
                        totalFoodCostPointsBudget = totalFoodCostBudget / totalSalesBudget;

                    txtTotalFoodCostBudget.Value = totalFoodCostBudget;

                    txtTotalMealCountBudget.Value = totalMealCountBudget;
                    if (totalMealCountBudget > 0 && _InputParameters["FinancialMode"].ParamValue == "CPM")
                        totalFoodCostPointsBudget = totalFoodCostBudget / totalMealCountBudget;

                    txtTotalFoodCostPointsBudget.Value = totalFoodCostPointsBudget;

                    txtTotalSales.Value = totalSales;
                    if (totalSales > 0 && _InputParameters["FinancialMode"].ParamValue == "Points")
                        totalFoodCostPoints = totalFoodCost / totalSales;
                    txtTotalSalesChanges.Value = totalSales - totalSalesBudget;


                    txtTotalFoodCost.Value = totalFoodCost;
                    txtTotalFoodCostChanges.Value = totalFoodCost - totalFoodCostBudget;


                    txtTotalMealCount.Value = totalMealCount;
                    if (totalMealCount > 0 && _InputParameters["FinancialMode"].ParamValue == "CPM")
                        totalFoodCostPoints = totalFoodCost / totalMealCount;
                    txtTotalMealCountChanges.Value = totalMealCount - totalMealCountBudget;


                    txtTotalFoodCostPoints.Value = totalFoodCostPoints;
                    totalFoodCostPointsChanges = totalFoodCostPoints - totalFoodCostPointsBudget;

					if (totalFoodCostPointsChanges > 0)
						txtTotalFoodCostPointsChanges.Value = totalFoodCostPointsChanges;
					else txtTotalFoodCostPointsChanges.Value = "";
                }

                if (dtWaste.Rows.Count > 0)
                {
                    if (totalFoodWasteAmount > 0)
                    {
                        txtTotalFoodWasteAmount.Value = totalFoodWasteAmount;
                        if (totalFoodCost > 0)
                            totalFoodWastePercentage = totalFoodWasteAmount / totalFoodCost;
                    }
                    if (totalFoodWastePercentage > 0)
                        txtTotalFoodWastePercentage.Value = totalFoodWastePercentage;
                }

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
