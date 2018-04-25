using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Globalization;

namespace UserControls
{
	public partial class UCManageBaselines : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
		VWA4Common.CommonEvents commonEvents = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageBaselines()
		{
			InitializeComponent();
		}

		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                //dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
                //dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.WeekChanged += new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
            }
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
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
			pTaskHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
			lTitle1.ForeColor = Color.Black;
		}

        public int AutoRun(string param)
        {
            return 0;
        }

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
		/// Load the Baselines data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Baselines.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			//
			// What is the mode of Baselining Waste Data?
			//
			// Recalculate everything
			VWA4Common.GlobalSettings.InvalidateBaseline();
			// Initialize Baseline relative to the mode
			SetBaselineWasteMethod(VWA4Common.GlobalSettings.BaselineWasteMethod,true);
				//
			// Load Baseline Financial Data
			//
			tActFoodCost.EditValue = "$" + decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodCost_Stipulated).ToString("#####0.00");
			tBudFoodCost.EditValue = "$" + decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyBudgetedFoodCost_Stipulated).ToString("#####0.00");
			tActFoodRevenue.EditValue = "$" + decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyActualFoodRevenue_Stipulated).ToString("#####0.00");
			tBudFoodRevenue.EditValue = "$" + decimal.Parse(VWA4Common.GlobalSettings.BaselineMonthlyBudgetedFoodRevenue_Stipulated).ToString("#####0.00");
			tActMealCount.EditValue = VWA4Common.GlobalSettings.BaselineMonthlyActualMealCount_Stipulated;
			tBudMealCount.EditValue = VWA4Common.GlobalSettings.BaselineMonthlyBudgetedMealCount_Stipulated;
			bCancel.Hide();
			bSave.Hide();
			lTitle1.Text = "(for " + VWA4Common.GlobalSettings.CurrentSiteName + ")";
			Initialized = true;
		}


		public void SaveData()
		{
			// Saving Baseline Waste Data depends on Save Method
			if (bComputeAve.Checked)
			{
				if (rgComputeMethod.SelectedIndex == 0) VWA4Common.GlobalSettings.BaselineWasteMethod = "Average";
				else VWA4Common.GlobalSettings.BaselineWasteMethod = "Maximum";
				VWA4Common.GlobalSettings.BaselineStartDate = deStartDate.DateTime.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
				RadioGroupItem rgi = rgNumWeeks.Properties.Items[rgNumWeeks.SelectedIndex];
				VWA4Common.GlobalSettings.BaselineNumberofWeeks = rgi.Value.ToString();
				// SAR 021110
				if (VWA4Common.GlobalSettings.BaselineComputeMethod == "Average")
				{
					rgComputeMethod.SelectedIndex = 0;
				}
				else
				{
					rgComputeMethod.SelectedIndex = 1;
				}
			}
			else
			{
				VWA4Common.GlobalSettings.BaselineWasteMethod = "Stipulated";
				VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Stipulated = tWasteCost.EditValue.ToString();
				VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans_Stipulated = tWasteTrans.EditValue.ToString();
			}
			// Save Baseline Financial Data
			VWA4Common.GlobalSettings.BaselineMonthlyActualFoodCost_Stipulated = tActFoodCost.EditValue.ToString().Replace("$", "");
			VWA4Common.GlobalSettings.BaselineMonthlyBudgetedFoodCost_Stipulated = tBudFoodCost.EditValue.ToString().Replace("$", "");
			VWA4Common.GlobalSettings.BaselineMonthlyActualFoodRevenue_Stipulated = tActFoodRevenue.EditValue.ToString().Replace("$", "");
			VWA4Common.GlobalSettings.BaselineMonthlyBudgetedFoodRevenue_Stipulated = tBudFoodRevenue.EditValue.ToString().Replace("$", "");
			VWA4Common.GlobalSettings.BaselineMonthlyActualMealCount_Stipulated = tActMealCount.EditValue.ToString();
			VWA4Common.GlobalSettings.BaselineMonthlyBudgetedMealCount_Stipulated = tBudMealCount.EditValue.ToString();
			bCancel.Hide();
			bSave.Hide();
		}

		public bool ValidateData()
		{ return true; }

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



		public void SetBaselineWasteMethod(string method, bool rgupdate)
		{
			if (rgupdate)
			{
				int ii = 0;
				foreach (RadioGroupItem item in rgNumWeeks.Properties.Items)
				{
					if (item.Value.ToString() == VWA4Common.GlobalSettings.BaselineNumberofWeeks)
					{
						rgNumWeeks.SelectedIndex = ii;
					}
					ii++;
				}
			}
			if (method == "Computed")
			{
				// Set method selection buttons
				bComputeAve.Checked = true;
				if (VWA4Common.GlobalSettings.BaselineComputeMethod == "Average")
				{
					rgComputeMethod.SelectedIndex = 0;
				}
				else
				{
					rgComputeMethod.SelectedIndex = 1;
				}
				lStartDate.Visible = true;
				lNumWeeks.Visible = true;
				deStartDate.Visible = true;
				deStartDate.DateTime = DateTime.Parse(VWA4Common.GlobalSettings.BaselineStartDate);
				rgNumWeeks.Visible = true;
				// set up value fields
				tWasteCost.Visible = false;
				tWasteTrans.Visible = false;
				lWasteCost.Show();
				lWasteTrans.Show();
				//// Calculate values and set
				//sql = "SELECT SUM(WasteCost) AS wastecost, COUNT(*) AS ntrans FROM Weights WHERE ((Timestamp >= #"
				//+ VWA4Common.GlobalSettings.BaselineStartDate + "#) AND (Timestamp < #"
				//+ DateTime.Parse(VWA4Common.GlobalSettings.BaselineStartDate).AddDays(7 *
				//    int.Parse(VWA4Common.GlobalSettings.BaselineNumberofWeeks)).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"))
				//+ " 00:00:00#))";
				//DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
				//DataRow thisRow = dt_wcost.Rows[0];
				//decimal wastecost = 0.0M;
				//if (thisRow["wastecost"].ToString() != "")
				//    wastecost = decimal.Parse(thisRow["wastecost"].ToString());
				//int ntrans = (int)thisRow["ntrans"];
				//lWasteCost.Text = "$" + wastecost.ToString("####0.00");
				VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Derived = null;
				lWasteCost.Text = "$" + VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Derived;
				//lWasteTrans.Text = ntrans.ToString();
				VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans_Derived = null;
				lWasteTrans.Text = VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans_Derived;
			}
			else // Stipulated
			{
				// hide compute method stuff
				bStipulate.Checked = true;
				lStartDate.Visible = false;
				lNumWeeks.Visible = false;
				deStartDate.Visible = false;
				rgNumWeeks.Visible = false;
				// set up value fields
				tWasteCost.Visible = true;
				tWasteCost.EditValue = "$" + VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Stipulated;
				tWasteTrans.Visible = true;
				tWasteTrans.EditValue = VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans_Stipulated;
				lWasteCost.Hide();
				lWasteTrans.Hide();
			}
			bCancel.Show();
			bSave.Show();

		}


		/// <summary>
		/// Validate Cost for a textbox control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tActFoodCost_Validating(object sender, CancelEventArgs e)
		{
			// First, Strip off the $ if there is one.
			string editvalue = (sender as TextEdit).EditValue.ToString();
			editvalue = editvalue.Replace("$", "");
			decimal dresult;
			// Now see if we have a valid decimal value
			if (decimal.TryParse(editvalue, out dresult))
			{ // successful - valid
				(sender as TextEdit).EditValue =
					"$ " + dresult.ToString("####0.00");
				bCancel.Show();
				bSave.Show();
			}
			else
			{ // failed - go back to old value
				MessageBox.Show("'" + (sender as TextEdit).EditValue.ToString() + "' is not a valid currency value.");
				e.Cancel = true;
			}
			
		}

		/// <summary>
		/// Validate integer for a textbox control
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tActMealCount_Validating(object sender, CancelEventArgs e)
		{
			int iresult;
			if (int.TryParse((sender as TextEdit).EditValue.ToString(), out iresult))
			{ // successful - valid
				(sender as TextEdit).EditValue =
					 iresult.ToString("#####0");
				bCancel.Show();
				bSave.Show();
			}
			else
			{ // failed - go back to old value
				MessageBox.Show("'" + (sender as TextEdit).EditValue.ToString() + "' is not a valid count value.");
				e.Cancel = true;
			}
		}

		private void bStipulate_Click(object sender, EventArgs e)
		{
				SetBaselineWasteMethod("Stipulate",false);
		}

		private void bComputeAve_Click(object sender, EventArgs e)
		{
			SetBaselineWasteMethod("Computed", false);
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			SaveData();
		}

		private void deStartDate_DateTimeChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.BaselineStartDate
							= deStartDate.DateTime.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
				SetBaselineWasteMethod("Computed",false);
			}
		}

		private void rgNumWeeks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				RadioGroupItem rgi = rgNumWeeks.Properties.Items[rgNumWeeks.SelectedIndex];
				VWA4Common.GlobalSettings.BaselineNumberofWeeks
					= rgi.Value.ToString();
				SetBaselineWasteMethod("Computed",false);
			}
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			CloseSheet();
		}
		private void CloseSheet()
		{
			bCancel.Hide();
			bSave.Hide();
			commonEvents.TaskSheetKey = "dashboard";
		}
		private void tActFoodRevenue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == Keys.Enter.ToString())
			{
				DevExpress.XtraEditors.TextEdit te = (DevExpress.XtraEditors.TextEdit)sender;
				te.DoValidate();
			}
		}
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // || !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Baselines")))
				CloseSheet();
		}

		private void rgComputeMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rgComputeMethod.SelectedIndex == 0)
			{
				VWA4Common.GlobalSettings.BaselineComputeMethod = "Average";
			}
			else
			{
				VWA4Common.GlobalSettings.BaselineComputeMethod = "Maximum";
			}
			VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Derived = null;
			lWasteCost.Text = "$" + VWA4Common.GlobalSettings.BaselineWeeklyWasteCost_Derived;
			lWasteTrans.Text = VWA4Common.GlobalSettings.BaselineWeeklyWasteTrans_Derived;
		}

	}
}
