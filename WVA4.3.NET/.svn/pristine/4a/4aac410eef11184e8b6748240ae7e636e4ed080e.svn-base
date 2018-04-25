using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace UserControls
{
    public partial class UCDashBoard : UserControl, IVWAUserControlBase
    {
		/// Class level elements
		public bool Initialized;
		decimal wastecost_selwk;
		decimal foodwastelbs_selwk;
		decimal totalwastelbs_selwk;
		decimal containerlbs_selwk;

        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
		VWA4Common.CommonEvents commonEvents = null;

        private bool _IsActive = false;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public void LeaveSheet()
        {
            _IsActive = false;
        }

      	/// <summary>
       	/// Constructor.
       	/// </summary>
		public UCDashBoard()
        {
            InitializeComponent();
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			commonEvents.UpdateProductUIData +=
				new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
		}

		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_DBDataChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
			}
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.WeekChanged += new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
            }
			_IsActive = true;
		}
		
		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			label1.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
			lSelectedWeekStartDate.ForeColor = Color.Black;
			if (VWA4Common.GlobalSettings.DisableDashboardWarnings || VWA4Common.GlobalSettings.ProductType == 3)
				lTrackerOutofSync.Hide();
			else
				lTrackerOutofSync.Visible = VWA4Common.GlobalSettings.TrackerConfigOutofSync;

		}

		public int AutoRun(string param)
		{
			return 0;
		}
		public void SaveData()
		{ }
		public bool ValidateData()
		{ return true; }

		/// <summary>
		/// Load the Dashboard data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Dashboard.
		/// </summary>
		public void LoadData()
        {
			Initialized = false;
			//			
			// Initialize Date
			//			
			lSelectedWeekStartDate.Text =
			   DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).ToString("M/d/yy")
			   + " - " + DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).AddDays(6).ToString("M/d/yy");
			// Get data for the chart
			//
			// Baseline Waste Cost
			//
			decimal bwastecost = decimal.Parse(VWA4Common.GlobalSettings.BaselineWeeklyWasteCost);
			// We now have the baseline waste cost
			// Now get the total waste cost for this week
			//
			//string sql = "SELECT SUM(WasteCost) AS wastecost FROM Weights WHERE ((Timestamp >= #"
			//    + VWA4Common.GlobalSettings.StartDateOfSelectedWeek + "#) AND (Timestamp < #"
			//    + (DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).AddDays(7)).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"))
			//    + " 00:00:00#))";
			
            string sql = "SELECT SUM(WasteCost) AS wastecost, SUM(Weight) AS totalwastelbs, SUM(ContainerWeight*NItems) AS containerlbs, COUNT(*) as cnt FROM Weights wts "
				+ " INNER JOIN Transfers tfs ON ((wts.TransKey = tfs.TransKey)"
				+ " AND (tfs.SiteID = " + VWA4Common.GlobalSettings.CurrentSiteID.ToString()
                + ") AND (wts.Timestamp >= #"
				+ VWA4Common.GlobalSettings.StartDateOfSelectedWeek + "#) AND (wts.Timestamp < #"
                + (DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US")).AddDays(7)).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"))
				+ " 00:00:00#))";			

			DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
			DataRow thisRow = dt_wcost.Rows[0];
			if (thisRow["wastecost"].ToString() != "")
				wastecost_selwk = decimal.Parse(thisRow["wastecost"].ToString());
			else
				wastecost_selwk = 0.0M;

			if (thisRow["totalwastelbs"].ToString() != "")
				totalwastelbs_selwk = decimal.Parse(thisRow["totalwastelbs"].ToString());
			else
				totalwastelbs_selwk = 0.0M;

			if (thisRow["containerlbs"].ToString() != "")
				containerlbs_selwk = decimal.Parse(thisRow["containerlbs"].ToString());
			else
				containerlbs_selwk = 0.0M;

			foodwastelbs_selwk = totalwastelbs_selwk - containerlbs_selwk;

			// OK we have the numbers for this chart
			/// draw the waste cost chart
			//
			DataTable chartdata = new DataTable();
			chartdata.Columns.Add("Series Labels", typeof(string));
			chartdata.Columns.Add("Waste Cost", typeof(decimal));
			chartdata.Rows.Add(new Object[] { "Baseline", bwastecost });
			chartdata.Rows.Add(new Object[] { "Current Wk", wastecost_selwk });
			decimal yrangemax = Math.Max(bwastecost,wastecost_selwk) * 1.2M;
			if (yrangemax < 100) yrangemax = 100;
			//
			ultraChart1.DataSource = chartdata;
			ultraChart1.DataBind();
			ultraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom;
			ultraChart1.Axis.Y.RangeMin = 0;
			ultraChart1.Axis.Y.RangeMax = (double)yrangemax;
			if (wastecost_selwk == 0)
			{
				lNoDatachart.Show();
				pWasteEquivalency.Hide();
				if (VWA4Common.GlobalSettings.ProductType != 1)
					lPleaseTransfer.Text = "Please enter your waste data for the week of " + lSelectedWeekStartDate.Text;
				else
					lPleaseTransfer.Text = "Please import/enter your waste data for the week of " + lSelectedWeekStartDate.Text;

				if (VWA4Common.GlobalSettings.DisableDashboardWarnings)
					lPleaseTransfer.Hide();
				else
					lPleaseTransfer.Show();
			}
			else
			{
				lNoDatachart.Hide();
				pWasteEquivalency.Show();
				lPleaseTransfer.Hide();
			}
			if (bwastecost == 0)
				lnoBaselineDataChart.Show();
			else
				lnoBaselineDataChart.Hide();
			if (!lNoDatachart.Visible && !lnoBaselineDataChart.Visible)
			{ // We can show the indicator
				lwastepercent.Text = "";
				decimal increase = ((wastecost_selwk - bwastecost) / bwastecost) * 100;
				if (increase > 0)
				{
					lwastepercent.Text = "+";
					lWasteCostIncrease.Appearance.Image = 0;
				}
				else
				{
					lWasteCostIncrease.Appearance.Image = 1;
				}
				lwastepercent.Text += increase.ToString("###0.0") + "%";
				if (Math.Abs(increase) >= 0.1M) 
					lWasteCostIncrease.Show();
				else lWasteCostIncrease.Hide();
				lwastepercent.Show();
			}
			else
			{
				lwastepercent.Hide();
				lWasteCostIncrease.Hide();
			}
			// draw the financials chart
			//
			// initialization
			DataTable chartdata2 = new DataTable();
			// get financial data for prior month
			DateTime startdateofselectedweek = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
			DateTime currentmonthstart = new DateTime(startdateofselectedweek.Year, startdateofselectedweek.Month, 1, 0, 0, 0);
			DateTime priormonthstart =  currentmonthstart.AddMonths(-1);
            sql = "SELECT SUM(FoodCostActual) AS foodcost_priormo, SUM(FoodRevenueActual) AS foodrevenue_priormo,"
				+ " SUM(MealCountActual) AS mealcount_priormo FROM Financials fin "
				+ " WHERE ((fin.SiteID = " + VWA4Common.GlobalSettings.CurrentSiteID.ToString()
                + ") AND (fin.PeriodStartDate >= #"
				+ priormonthstart.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "#) AND (fin.PeriodStartDate < #"
				+ currentmonthstart.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"))
				+ " 00:00:00#))";			
			// todo: filter by period , i.e. - Month
			DataTable dt_fcost = VWA4Common.DB.Retrieve(sql);
			DataRow thisRow2 = dt_fcost.Rows[0];
			//
            decimal bfoodcost = decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodCost_Stipulated);
			decimal foodcost_priormo = 0;
			decimal bfoodcosttoplot = 0;
			decimal foodcost_priormotoplot = 0;
			decimal foodrevenue_priormotoplot = 0;
			int bmealcount = 0;
			int priormonth_mealcount = 0;
			// 
			// Calculate Food Cost Percentages
			//
			if (VWA4Common.GlobalSettings.FoodCostReportPoints)
			{ /// calculate Food cost as a percentage of Sales
			    /// Baseline
				if (decimal.TryParse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodRevenue_Stipulated, out bfoodcosttoplot))
				{ // food revenue value parses OK, is it > 0?
					if (bfoodcosttoplot > 0)
					{ // we won't be dividing by zero so we're OK so far
						if (decimal.TryParse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodCost_Stipulated, out bfoodcosttoplot))
						{ // Food cost parses OK - is it 0?
							if (bfoodcosttoplot > 0)
							{ // we have a good value! do the calculation
								bfoodcosttoplot = bfoodcosttoplot
									/ decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodRevenue_Stipulated) * 100;
							}
							else
							{ // food cost is 0 - we assume not entered
								bfoodcosttoplot = 0;
							}
						}
						else
						{ // food cost is no good
							bfoodcosttoplot = 0;
						}
					}
					else
					{ // food revenue isn't > 0 - assume it's not entered
						bfoodcosttoplot = 0;
					}
				}
				else
				{ // no valid result for food revenue - plot 0
					bfoodcosttoplot = 0;
				}
				/// Prior Month Actual
			    if (decimal.TryParse(thisRow2["foodrevenue_priormo"].ToString(),out foodrevenue_priormotoplot))
			    { // There is a good food revenue value - is it > 0?
					if (foodrevenue_priormotoplot > 0)
					{ // we won't be dividing by zero so we're OK
						if (decimal.TryParse(thisRow2["foodcost_priormo"].ToString(), out foodcost_priormotoplot))
						{ // Food cost parses OK - is it 0?
							if (foodcost_priormotoplot > 0)
							{ // we have food cost data - do the calculation
								foodcost_priormotoplot = foodcost_priormotoplot / foodrevenue_priormotoplot * 100;
							}
							else
							{ // food cost is 0 - we assume not entered
								foodcost_priormotoplot = 0;
							}
						}
						else
						{ // no valid food cost data
							foodcost_priormotoplot = 0;
						}
					}
					else
					{ // Dividing by zero means we don't have the data we need
						foodcost_priormotoplot = 0;
					}
			    }
			    else
			    { // Can't deal with the food revenue value, plot 0
					foodcost_priormotoplot = 0;
				}
				// Fix up chart stuff
				chartdata2.Columns.Add("Series Labels", typeof(string));
                chartdata2.Columns.Add(//VWA4Common.VWACommon.WasteProfile + 
					"Food Cost Points", typeof(decimal));
				chartdata2.Rows.Add(new Object[] { "Baseline", bfoodcosttoplot });
				chartdata2.Rows.Add(new Object[] { "Prior Month", foodcost_priormotoplot });
				yrangemax = 100;
				ultraChart2.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0>%";
                ultraChart2.TitleTop.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Food Cost Points";

			} // end calc Food Cost Points process
			else
			{ /// Food Cost per meal
				///
				/// Baseline
				if (int.TryParse(VWA4Common.GlobalSettings.BaselineMonthlyActualMealCount_Stipulated, out bmealcount))
				{ // meal count parses OK, is it > 0?
					if (bmealcount > 0)
					{ // we won't be dividing by zero so we're OK so far
						if (decimal.TryParse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodCost_Stipulated, out bfoodcosttoplot))
						{ // Food cost parses OK - is it 0?
							if (bfoodcosttoplot > 0)
							{ // we have a good value! do the calculation
								bfoodcosttoplot = bfoodcosttoplot / bmealcount;
							}
							else
							{ // food cost is 0 - we assume not entered
								bfoodcosttoplot = 0;
							}
						}
						else
						{ // food cost is no good
							bfoodcosttoplot = 0;
						}
					}
					else
					{ // meal count isn't > 0 - assume it's not entered
						bfoodcosttoplot = 0;
					}
				}
				else
				{ // no valid result for meal count - plot 0
					bfoodcosttoplot = 0;
				}

				/// Prior Month
				if (int.TryParse(thisRow2["mealcount_priormo"].ToString(), out priormonth_mealcount))
				{ // meal count parses OK, is it > 0?
					if (priormonth_mealcount > 0)
					{ // we won't be dividing by zero so we're OK so far
						if (decimal.TryParse(thisRow2["foodcost_priormo"].ToString(), out foodcost_priormo))
						{ // Food cost parses OK - is it 0?
							if (foodcost_priormo > 0)
							{ // we have a good value! do the calculation
								foodcost_priormotoplot = foodcost_priormo / priormonth_mealcount;
							}
							else
							{ // food cost is 0 - we assume not entered
								foodcost_priormotoplot = 0;
							}
						}
						else
						{ // food cost is no good
							foodcost_priormotoplot = 0;
						}
					}
					else
					{ // meal count isn't > 0 - assume it's not entered
						foodcost_priormotoplot = 0;
					}
				}
				else
				{ // no valid result for meal count - plot 0
					foodcost_priormotoplot = 0;
				}
				
				// Fix up chart stuff
				chartdata2.Columns.Add("Series Labels", typeof(string));
                chartdata2.Columns.Add(//VWA4Common.VWACommon.WasteProfile + 
					"Food Cost Per Meal", typeof(decimal));
				chartdata2.Rows.Add(new Object[] { "Baseline", bfoodcosttoplot });
				chartdata2.Rows.Add(new Object[] { "Prior Month", foodcost_priormotoplot });
				yrangemax = Math.Max(bfoodcosttoplot, foodcost_priormotoplot) * 1.2M;
				if (yrangemax < 2) yrangemax = 3;
				ultraChart2.Axis.Y.Labels.ItemFormatString = "$<DATA_VALUE:0.00>";
                ultraChart2.TitleTop.Text = //VWA4Common.VWACommon.WasteProfile + 
					"Food Cost Per Meal";
			}
			// indicators on or off
			if (foodcost_priormotoplot == 0)
				lNoPriorMoFoodCostData.Show();
			else
				lNoPriorMoFoodCostData.Hide();
			if (bfoodcosttoplot == 0)
				lNoBaselineFoodCostData.Show();
			else
				lNoBaselineFoodCostData.Hide();

			if (!lNoPriorMoFoodCostData.Visible && !lNoBaselineFoodCostData.Visible)
			{ // We can show the indicator
				lincreasefoodcost.Text = "";
				decimal increase = ((foodcost_priormotoplot - bfoodcosttoplot) / bfoodcosttoplot) * 100;
				if (increase > 0)
				{
					lincreasefoodcost.Text = "+";
					lindicatorfoodcost.Appearance.Image = 0;
				}
				else
				{
					lindicatorfoodcost.Appearance.Image = 1;
				}
				lincreasefoodcost.Text += increase.ToString("###0.0") + "%";
				lincreasefoodcost.Show();
				if (Math.Abs(increase) >= 0.1M)
					lindicatorfoodcost.Show();
				else
					lindicatorfoodcost.Hide();
			}
			else
			{
				lindicatorfoodcost.Hide();
				lincreasefoodcost.Hide();
			}
			///
			/// Common chart setup, post-specifics to points or CPM mode
			///
			ultraChart2.DataSource = chartdata2;
			ultraChart2.DataBind();
			ultraChart2.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom;
			ultraChart2.Axis.Y.RangeMin = 0;
			ultraChart2.Axis.Y.RangeMax = (double)yrangemax;
			//
			// Other stuff
			//
			// transaction counts

			lTransBaseline.Text = VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans;
			lTransCount.Text = thisRow["cnt"].ToString();
			// variance
			int btrans = int.Parse(VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans);
			int ctrans = (int)thisRow["cnt"];
			if (btrans == 0)
			{ // can't divide by zero
				lVariance.Text = "no baseline";
			}
			else
			{
				lVariance.Text = VWA4Common.Utilities.GetPercentage(ctrans,btrans,1) + "%";
			}

			// Weekly Waste Profile
			lTotalWasteDollars.Text = wastecost_selwk.ToString("C");
			lTotalWastelbs.Text = foodwastelbs_selwk.ToString("######0") + " lbs";
			lAnnualWasteatthisRate.Text = (wastecost_selwk * 52).ToString("C");
			// Notifications
			if (VWA4Common.GlobalSettings.DisableDashboardWarnings || VWA4Common.GlobalSettings.ProductType == 3)
				lTrackerOutofSync.Hide();
			else
				lTrackerOutofSync.Visible = VWA4Common.GlobalSettings.TrackerConfigOutofSync;

			Initialized = true;
			//
			sql = ""; // debug only
			CheckDashboardDisplayOptions();
        }

		/// <summary>
		/// Update Dashboard based on Display Options
		/// </summary>
		private void CheckDashboardDisplayOptions()
		{

			if (Initialized)
			{
				// Chart Layout adjustment
				if (bool.Parse(VWA4Common.GlobalSettings.DashboardFoodCostChartOn.ToString()))
				{ // Dual chart layout
					ultraChart1.Visible = true;
					ultraChart1.Height = 305;
					ultraChart1.Width = 327;
					ultraChart1.Left = 19;
					lwastepercent.Left = 176;
					lwastepercent.Top = 97;
					lWasteCostIncrease.Left = 251;
					lWasteCostIncrease.Top = 93;
					lNoDatachart.Height = 116;
					lNoDatachart.Width = 122;
					lNoDatachart.Left = 217;
					lNoDatachart.Top = 167;
					lnoBaselineDataChart.Left = 63;

					ultraChart2.Visible = true;

				}
				else
				{ // Single chart layout
					ultraChart1.Visible = true;
					ultraChart1.Height = 305;
					ultraChart1.Width = 500;
					ultraChart1.Left = 120;
					lwastepercent.Left = 176 + 384 - 110;
					lwastepercent.Top = 97;
					lWasteCostIncrease.Left = 251 + 384 - 110;
					lWasteCostIncrease.Top = 93;
					lNoDatachart.Height = 116;
					lNoDatachart.Width = 122;
					lNoDatachart.Left = 217 + 384 - 140;
					lNoDatachart.Top = 167;
					lnoBaselineDataChart.Left = 63 + 120;

					ultraChart2.Visible = false;
					lincreasefoodcost.Visible = false;
					lindicatorfoodcost.Visible = false;
					lNoPriorMoFoodCostData.Visible = false;
					lNoBaselineFoodCostData.Visible = false;
				}


				// Tabular layout
				if (bool.Parse(VWA4Common.GlobalSettings.DashboardParticipationSummaryOn)
					&& bool.Parse(VWA4Common.GlobalSettings.DashboardWasteSummaryOn))
				{ // Show both tables
					pWeeklyParticipation.Left = 29;
					pWeeklyParticipation.Visible = true;
					pWeeklyWasteProfile.Left = 382;
					pWeeklyWasteProfile.Visible = true;
				}
				else if (bool.Parse(VWA4Common.GlobalSettings.DashboardWasteSummaryOn))
				{ // Show only the Waste Summary
					pWeeklyWasteProfile.Left = 230;
					pWeeklyWasteProfile.Visible = true;
					pWeeklyParticipation.Visible = false;
				}
				else if (bool.Parse(VWA4Common.GlobalSettings.DashboardParticipationSummaryOn))
				{ // Show only the Participation Summary
					pWeeklyParticipation.Left = 230;
					pWeeklyParticipation.Visible = true;
					pWeeklyWasteProfile.Visible = false;
				}
				else
				{
					pWeeklyParticipation.Visible = false;
					pWeeklyWasteProfile.Visible = false;
				}

				pWasteEquivalency.Visible =
					(bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn)
					 && !lNoDatachart.Visible);
				if (pWasteEquivalency.Visible)
				{
					// Load the image
					MemoryStream imgstream;
					byte[] bt;
					if (VWA4Common.Utilities.LoadFilefromDB("WasteEquivalencyImage.img", 0, out bt) > 0)
					{ // We successfully loaded a picture file from the DB
						imgstream = new MemoryStream(bt, 0, bt.Length);
						pbWasteEquivalencyImage.Image = Image.FromStream(imgstream);
						pbWasteEquivalencyImage.Refresh();
					}
					// Load the text
					if (VWA4Common.GlobalSettings.DashboardWasteEquivalencyUnits.ToLower() == "pounds")
					{
						label6.Text =
							"Thinking of this waste weight in another way, it would add up to...";
						label8.Text =
							"...over the period of a year!";
						decimal wastelbsequiv = foodwastelbs_selwk * 52 /
							decimal.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyPounds);
						lWasteEquivalent.Text = wastelbsequiv.ToString("####0.0") 
							+ " " + VWA4Common.GlobalSettings.DashboardWasteEquivalencyObjectName + "!";

					}
					else if (VWA4Common.GlobalSettings.DashboardWasteEquivalencyUnits.ToLower() == "dollars")
					{
						label6.Text =
							"Thinking of this waste value in another way, you could purchase...";
						label8.Text =
							"...at this annual waste rate!";
						decimal wastecostequiv = wastecost_selwk * 52 /
							decimal.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyDollars);
						lWasteEquivalent.Text = wastecostequiv.ToString("####0.0") 
							+ " " + VWA4Common.GlobalSettings.DashboardWasteEquivalencyObjectName + "!";
					}
					else
					{
						pWasteEquivalency.Visible = false;
					}
				}
			}
		}

		/// Event Handlers


		private void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void dbDetector_PathChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void trackerDetector_WeekChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void dbDetector_DBDataChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}

		/// <summary>
		/// Click on label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lTrackerOutofSync_Click(object sender, EventArgs e)
		{
			if (sender != null)
				commonEvents.TaskSheetKey = "transferconfig";
		}

		///
		/// Mouse click highlighting
		///

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Maroon;
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
        }

		private void lAnyNavLabel_MouseEnter(object sender, EventArgs e)
		{
			resetlabelborders();
			
			Label lbl = (Label)sender;
			lbl.BorderStyle = BorderStyle.FixedSingle;
		}

		private void lAnyNavLabel_MouseLeave(object sender, EventArgs e)
		{
			Label lbl = (Label)sender;
			lbl.BorderStyle = BorderStyle.None;
		}

		private void resetlabelborders()
		{
			lTrackerOutofSync.BorderStyle = BorderStyle.None;
			lPleaseTransfer.BorderStyle = BorderStyle.None;
		}
		private void resetlabelcolors()
		{
			lTrackerOutofSync.ForeColor = Color.Black;
			lPleaseTransfer.ForeColor = Color.Black;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

    }
}
