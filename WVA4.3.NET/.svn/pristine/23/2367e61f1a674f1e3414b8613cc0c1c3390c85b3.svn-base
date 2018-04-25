using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;
using VWA4Common;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace UserControls
{
	public partial class UCManageGoals : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		bool SkipSelectedIndexChangedHandler;

		private DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;
		/// 
		/// Buffers for holding the current Goal's data
		///
		Goal CurrGoal = new Goal();
		List<Goal> GoalList = new List<Goal>();
		List<TagsFoodType> TagsFoodTypeList = new List<TagsFoodType>();
		class ComboBoxItem
		{
			public string Name;
			public int ID;
			public ComboBoxItem(string Name, int ID)
			{
				this.Name = Name;
				this.ID = ID;
			}
			// override ToString() function
			public override string ToString()
			{
				return this.Name;
			}
		}
		ComboBoxItem cbi = null;

		private int CurrFilterID = 0;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageGoals()
		{
			InitializeComponent();
		}

		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			Initialized = false;
			if (dbDetector == null)
			{
				dbDetector = DBDetector.GetDBDetector();
				dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
				//dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.DBPathChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.AdjustmentsChanged += new DBDetectorEventHandler(dbDetector_AdjustmentsChanged);
				dbDetector.UserLogin += new DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			// Initialize comboboxes
			cbGoalPriority.Items.Clear();
			cbGoalPriority.Items.Add(new ComboBoxItem("Urgent Priority", 3));
			cbGoalPriority.Items.Add(new ComboBoxItem("High Priority", 2));
			cbGoalPriority.Items.Add(new ComboBoxItem("Normal Priority", 1));
			cbGoalPriority.Items.Add(new ComboBoxItem("Low Priority", 0));

			cbGoalType.Items.Clear();
			cbGoalType.Items.Add(new ComboBoxItem("Dollar Amount", 0));
			cbGoalType.Items.Add(new ComboBoxItem("Weight Amount", 1));

			cbGoalMode.Items.Clear();
			cbGoalMode.Items.Add(new ComboBoxItem("Target Percentage Change", 0));
			cbGoalMode.Items.Add(new ComboBoxItem("Target Specific Amount", 1));

			
			cbFilterType.Items.Clear();
			cbFilterType.Items.Add(new ComboBoxItem("Food Type Tag Filter", 0));
			cbFilterType.Items.Add(new ComboBoxItem("Complex Filter", 1));

			
			//InitProductUI();
			ulvGoalList.ItemSettings.SelectionType = SelectionType.Single;
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
			lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
		}

		public int AutoRun(string param)
		{
			Initialized = true;
			SkipSelectedIndexChangedHandler = true;
			/// Load things here that cause events
			SkipSelectedIndexChangedHandler = false;
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
		/// Standard Load Data method.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			lFilterID.Hide();
			lFilterName.Hide();
			///
			/// Load all the tags
			/// 
			// Load them into the list view
			initGoalControls();
			LoadGoals();
			Initialized = true;
		}

		public void SaveData()
		{
		}

		private void SaveData(Goal goal)
		{
			GoalsDAO.DAO.InsertOrUpdate(goal);
		}

		public bool ValidateData()
		{ return true; }

		/// 
		/// Support Methods
		/// 
		
		/// <summary>
		/// Load All Goals into the listview
		/// </summary>
		private void LoadGoals()
		{
			ulvGoalList.Reset();
			GoalList = GoalsDAO.DAO.GetAllGoals(VWA4Common.GlobalSettings.CurrentSiteID);
			ulvGoalList.View = UltraListViewStyle.List;
			ulvGoalList.ItemSettings.Appearance.Image = imageList1.Images[0];
			ulvGoalList.ItemSettings.SelectedAppearance.Image = imageList1.Images[1];
			ulvGoalList.ItemSettings.SelectedAppearance.FontData.Bold = DefaultableBoolean.False;
			ulvGoalList.ItemSettings.SelectedAppearance.ForeColor = Color.Black;
			ulvGoalList.ItemSettings.SelectedAppearance.BackColor = Color.MistyRose;

			ulvGoalList.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			UltraListViewMainColumn mainColumn = ulvGoalList.MainColumn;
			mainColumn.Text = "Goal Name";
			mainColumn.DataType = typeof(System.String);
			/// Load 'er up
			for (int i = 0; i < GoalList.Count; i++)
			{
				UltraListViewItem item = ulvGoalList.Items.Add(GoalList[i].ID.ToString(), GoalList[i].GoalName);
			}
			ulvGoalList.Refresh();
		}

		private void LoadCurrentGoalandUIfromDB(int goalID)
		{
			Initialized = false;
			try
			{
				CurrGoal = GoalsDAO.DAO.Load(goalID);
				// Load the editing controls
				tGoalName.Text = CurrGoal.GoalName;
				cbGoalPriority.SelectedIndex = CurrGoal.Priority;
				dtStartDate.Value = CurrGoal.StartDate;
				dtTargetDate.Value = CurrGoal.TargetDate;
				cbGoalType.SelectedIndex = CurrGoal.GoalType;
				cbGoalMode.SelectedIndex = CurrGoal.GoalMode;
				cbFilterType.SelectedIndex = CurrGoal.FilterType;
				if (CurrGoal.GoalMode == 0)
				{
					tGoalTarget.Text = CurrGoal.TargetPercentage.ToString();
				}
				else
				{
					tGoalTarget.Text = CurrGoal.TargetAmount.ToString();
				}
				if (CurrGoal.FilterType == 0)
				{
					// Tag type filter
					CurrFilterID = CurrGoal.FilterID;
					lFilterName.Text = TagsDAO.DAO.Load(CurrFilterID).TagName;
				}
				else
				{
					// Complex View Transactions filter
				}
				tDescription.Text = CurrGoal.Description;
				ckEnabled.Checked = CurrGoal.Enabled;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Data Error: " + ex.Message + "Load Current Goal");
			}
			finally
			{
				Initialized = true;
			}
		}
		
		private void loadCurrentGoalfromUI()
		{
			Initialized = false;
			CurrGoal.GoalName = tGoalName.Text;
			CurrGoal.Priority = cbGoalPriority.SelectedIndex;
			CurrGoal.StartDate = dtStartDate.Value;
			CurrGoal.TargetDate = dtTargetDate.Value;
			CurrGoal.GoalType = cbGoalType.SelectedIndex;
			CurrGoal.GoalMode = cbGoalMode.SelectedIndex;
			if (CurrGoal.GoalMode == 0)
			{
				CurrGoal.TargetPercentage = decimal.Parse(tGoalTarget.Text);
				CurrGoal.TargetAmount = -1;
			}
			else
			{
				CurrGoal.TargetAmount = decimal.Parse(tGoalTarget.Text);
				CurrGoal.TargetPercentage = -1;
			}
			CurrGoal.FilterType = cbFilterType.SelectedIndex;
			CurrGoal.FilterID = CurrFilterID;
			CurrGoal.Description = tDescription.Text;
			CurrGoal.Enabled = ckEnabled.Checked;
			CurrGoal.Site = VWA4Common.GlobalSettings.CurrentSiteID;
			Initialized = true;
		}

		private void initGoalControls()
		{
			Initialized = false;
			tGoalName.Text = string.Empty;
			cbGoalPriority.SelectedIndex = 3;
			dtStartDate.Value = VWA4Common.GlobalSettings.ForceDatetoPriorWeekStart(DateTime.Now);
			dtTargetDate.Value = dtStartDate.Value.AddDays(28);
			cbGoalType.SelectedIndex = 0;
			cbGoalMode.SelectedIndex = 0;
			changeGoalMode();
			tGoalTarget.Text = string.Empty;
			cbFilterType.Text = string.Empty;
			cbFilterType.SelectedIndex = 0;
			bChooseFilter.Enabled = true;
			lFilterID.Show();
			lFilterName.Text = string.Empty;
			lFilterName.Show();
			CurrFilterID = 0;
			tDescription.Text = string.Empty;
			ckEnabled.Checked = true;
			bGoalProgress.Enabled = false;
			Initialized = true;
		}

		private void changeGoalMode()
		{
			if (cbGoalMode.SelectedIndex == 0)
			{ // percentage change
				lPercent.Show();
				lLb.Hide();
				lDollar.Hide();
			}
			else
			{ // specific amount
				lPercent.Hide();
				if (cbGoalType.SelectedIndex == 0)
				{
					lLb.Hide();
					lDollar.Show();
				}
				else
				{
					lLb.Show();
					lDollar.Hide();
				}
			}
		}

		private bool readyToSave()
		{
			bDisplayFilter.Visible = CurrFilterID > 0;
			if (tGoalName.Text.Length < 2) return false;
			decimal result = 0;
			if (decimal.TryParse(tGoalTarget.Text, out result))
			{
				if (result < 0) return false;
			}
			else return false;
			if (CurrFilterID <= 0) return false;
			return true;
		}

		private void dbDetector_UserLogin(object sender, LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin)
				CloseTaskSheet();
		}

		void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.IsActive) LoadData();
		}

		private void CloseTaskSheet()
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void ulvGoalList_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			if (e.SelectedItems.Count > 0)
			{
				UltraListViewItem item = e.SelectedItems[0];
				int selectedGoalID = int.Parse(item.Key);
				CurrGoal = GoalsDAO.DAO.Load(selectedGoalID);
				LoadCurrentGoalandUIfromDB(selectedGoalID);
				bGoalProgress.Enabled = true;
			}
			else
			{
				initGoalControls();
			}
			bSave.Enabled = readyToSave();
			ulvGoalList.Focus();
		}

        public delegate void FilterEventHandler(object sender, UCBaseParameters.FilterEventArgs e);
        private FilterEventHandler filter;
        public event FilterEventHandler Filter
        {
            add { filter += value; }
            remove { filter -= value; }
        }
        public void SetFilter(DateTime start, DateTime end, string reportFilter)
        {
            OnFilter(new UCBaseParameters.FilterEventArgs(start, end, reportFilter));
        }
        protected virtual void OnFilter(UCBaseParameters.FilterEventArgs e)
        {
            if (filter != null)
                filter(this, e);
        }
        private string _strReportFilter = "", _strDisplayReportFilter = "";
        private string _strTreeFilters = "", _strDisplayTreeFilters = "", _siteID = "", _siteName = "";
        private string _strPreconsumerFilters = "", _strPreconsumerDisplayFilters = "";
        private DateTime _startDate, _endDate;
		private void bChooseFilter_Click(object sender, EventArgs e)
		{
			/// Add choice for advanced filter
			/// 
			// for now, just can use tags
            if(cbFilterType.SelectedIndex.Equals(0))
            {
                frmTagPicker frm = new frmTagPicker();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CurrFilterID = frm.TagSelected.ID;
                }
                bSave.Enabled = readyToSave();
            }
			else
            {
                ViewWaste frm = new ViewWaste();

                if (_startDate != new DateTime(0) && _endDate != new DateTime(0))
                    frm.AddPeriodFilter(_startDate, _endDate);


                ///SAR - Remove waste classes 010311 ; Jira VWAAMWT-240
                //string wasteClasses = GetWasteLevelClasses();
                //if (wasteClasses != "")
                //frm.AddWasteClassFilter(wasteClasses, cbWasteClasses.Text);
                frm.AddFilter(_strTreeFilters, _strDisplayTreeFilters);
                if (_siteID == "")
                {
                    _siteID = VWA4Common.GlobalSettings.CurrentSiteID.ToString();
                    _siteName = VWA4Common.GlobalSettings.CurrentSiteName.ToString();
                }
                frm.SetSiteID(_siteID, _siteName);
                frm.HideSite();
                if (_strPreconsumerFilters != "")
                    frm.SetDefaultPreconsumer(_strPreconsumerFilters, _strPreconsumerDisplayFilters);

                frm.Caption = "Filter Data for Report";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _strReportFilter = frm.GetFilters();
                    _strDisplayReportFilter = frm.GetFiltersString();
                    _startDate = VWA4Common.VWACommon.GetFilterStartDate(_strReportFilter);
                    _endDate = VWA4Common.VWACommon.GetFilterEndDate(_strReportFilter);
                    _strReportFilter = VWA4Common.VWACommon.RemoveFilterPeriod(_strReportFilter);
                    _strDisplayReportFilter = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_strDisplayReportFilter);
                    SetFilter(_startDate, _endDate, _strReportFilter);
                    _strPreconsumerFilters = VWA4Common.VWACommon.ExtractStringPreconsumerFilter(_strReportFilter, out _strPreconsumerDisplayFilters);

                    DisplayWasteClassFilter(VWA4Common.VWACommon.ExtractWasteClassFilter(_strReportFilter));
                    _strReportFilter = VWA4Common.VWACommon.RemoveWasteClassFilter(_strReportFilter);
                    _strDisplayReportFilter = VWA4Common.VWACommon.RemoveWasteClassDisplayFilter(_strDisplayReportFilter);
                }
            }
		}

        private void DisplayWasteClassFilter(string filter)
        {
            //string[] arrWasteClasses = Regex.Split(filter, "OR");
            //for (int i = 0; i < cbWasteClasses.Items.Count; i++)
            //    cbWasteClasses.SetItemChecked(i, false);
            //if (arrWasteClasses.Length == 0 || arrWasteClasses[0] == "")
            //    cbWasteClasses.SetItemChecked(0, true);
            //foreach (string wasteClass in arrWasteClasses)
            //    for (int i = 0; i < cbWasteClasses.Items.Count; i++)
            //        if (Regex.IsMatch(wasteClass, @"\s*WasteClass\s*=\s*'" + ((VWA4Common.VWACommon.MyListBoxItem)cbWasteClasses.Items[i]).ItemData + @"'\s*"))
            //            cbWasteClasses.SetItemChecked(i, true);
            //toolTipWasteClasses.SetToolTip(lblWasteClasses, cbWasteClasses.Text);
        }

		private void bNew_Click(object sender, EventArgs e)
		{
			initGoalControls();
			bSave.Enabled = false;
		}

		private void dtTargetDate_ValueChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				Initialized = false;
				dtTargetDate.Value = VWA4Common.GlobalSettings.ForceDatetoNextWeekStart(dtTargetDate.Value);
				if (dtStartDate.Value > dtTargetDate.Value)
				{
					MessageBox.Show("Target Date must be greater than Start Date!");
					dtTargetDate.Value = dtStartDate.Value.AddDays(7);
				}
				bSave.Enabled = readyToSave();
				Initialized = true;
			}
		}

		private void dtStartDate_ValueChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				Initialized = false;
				dtStartDate.Value = VWA4Common.GlobalSettings.ForceDatetoPriorWeekStart(dtStartDate.Value);
				if (dtStartDate.Value > dtTargetDate.Value)
				{
					MessageBox.Show("Start Date must be earlier than Target Date!");
					dtStartDate.Value = dtTargetDate.Value.AddDays(-7);
				}
				bSave.Enabled = readyToSave();
				Initialized = true;
			}
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			loadCurrentGoalfromUI();
			SaveData(CurrGoal);
			LoadGoals();
			bSave.Enabled = false;
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			CloseTaskSheet();
		}

		private void cbGoalMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			changeGoalMode();
			bSave.Enabled = readyToSave();
		}


		private void ckEnabled_CheckedChanged(object sender, EventArgs e)
		{
			bSave.Enabled = readyToSave();
		}

		private void tDescription_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == (System.Char)Keys.Back) || (e.KeyChar == (System.Char)Keys.Delete)) return;
			if ((((TextBox)sender).Text == ""))
			{ // this is the first character - must be letter
				if (char.IsLetter(e.KeyChar)) return;
				e.Handled = true;
			}
			else
			{ // we already have the beginnings of a name
				if (char.IsLetterOrDigit(e.KeyChar) ||
					(e.KeyChar == (System.Char)Keys.Space) ||
					(e.KeyChar == "."[0]) ||
					(e.KeyChar == ","[0]) ||
					(e.KeyChar == "-"[0]) ||
					(e.KeyChar == "$"[0]) ||
					(e.KeyChar == "%"[0]) ||
					(e.KeyChar == "/"[0]) ||
					(e.KeyChar == "^"[0]) ||
					(e.KeyChar == "*"[0]) ||
					(e.KeyChar == ">"[0]) ||
					(e.KeyChar == "<"[0]) ||
					(e.KeyChar == "{"[0]) ||
					(e.KeyChar == "}"[0]) ||
					(e.KeyChar == "~"[0]) ||
					(e.KeyChar == "@"[0]) ||
					(e.KeyChar == "!"[0]) ||
					(e.KeyChar == "#"[0]))
					return;
				e.Handled = true;
			}

		}

		private void tGoalTarget_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) )return;
			if (e.KeyChar == "."[0])
			{// it might be legal
				decimal result = -1;
				if (decimal.TryParse(tGoalTarget.Text + ".", out result))
				{
					// legal - proceed
					bSave.Enabled = readyToSave();
					return;
				}
			}
			// not legal
			e.Handled = true;
		}

		private void tGoalTarget_Validating(object sender, CancelEventArgs e)
		{
				//e.Cancel = true;
		}

		private void tGoalName_TextChanged(object sender, EventArgs e)
		{
			bSave.Enabled = readyToSave();
		}

		private void bGoalProgress_Click(object sender, EventArgs e)
		{
			if (CurrGoal.StartDate >= DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek))
			{ // Current Date can't be before the start date
				MessageBox.Show("Current selected week must be after the start date!");
				return;
			}

			int daysworking = 0;
			decimal percentcomplete = (decimal)0.0;
			decimal baselineweekamt = (decimal)0.0;
			decimal targetweeklyamount = CurrGoal.TargetAmount;
			decimal currentweekamount = 0;
			string dollarsign = "$ ";
			string lbstring = " lb";
			GoalReportModel grm = 
				GoalsDAO.DAO.getAmount(CurrGoal,
				DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek));
			percentcomplete = grm.PercentComplete;
			baselineweekamt = grm.BaselineWeekAmt;
			currentweekamount = grm.Amount;
				daysworking = grm.DaysWorking;;
			if (CurrGoal.GoalMode == 0)
			{ // Use Target percentage
				targetweeklyamount = baselineweekamt - (baselineweekamt * CurrGoal.TargetPercentage/100);
			}
			string cw_amt = string.Empty;
			string bw_amt = string.Empty;
			string tar_amt = string.Empty;
			if (CurrGoal.GoalType == 0)
			{ // Dollars
				bw_amt = "$ " + baselineweekamt.ToString("#####0.00");
				cw_amt = "$ " + currentweekamount.ToString("#####0.00");
				tar_amt = "$ " + targetweeklyamount.ToString("#####0.00");
				lbstring = "";
			}
			else
			{
				bw_amt = baselineweekamt.ToString("#####0.00") + " lb.";
				cw_amt = currentweekamount.ToString("#####0.00") + " lb.";
				tar_amt = targetweeklyamount.ToString("#####0.00") + " lb.";
				dollarsign = "";
			}
			MessageBox.Show("Goal ( " + CurrGoal.GoalName + "):\n\n"
				+ "Baseline Week: " + CurrGoal.StartDate.AddDays(-7).ToShortDateString()
				+ "\n  Baseline Week Amount: " + bw_amt
				+ "\n  Target Amount: " + tar_amt  + "\n\n"
				+ "Goal Start Date: " + CurrGoal.StartDate.ToShortDateString()
				+ "\n\n Current Week: " + DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).ToShortDateString()
				+ "\n  Current Week Amount: " + cw_amt
				+ "\n  Percent Complete: " + (percentcomplete * 100).ToString("##0.0") + " %"
				+ "\n  Days Working: " + daysworking.ToString()
				+ "\n  Gap to Goal: " + dollarsign 
				+ grm.GaptoGoal.ToString("#####0.00") + lbstring);
		}

		private void cbGoalPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			bSave.Enabled = readyToSave();
		}

		private void bDisplayFilter_Click(object sender, EventArgs e)
		{
			// if current filter is a tag type filter...

			frmShowTaggedTypes frm = new frmShowTaggedTypes(CurrFilterID);
			frm.ShowDialog();

			//else show Advanced filter code here...
		}

		private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
		{
			bSave.Enabled = readyToSave();

		}

	}
}
