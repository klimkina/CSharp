using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.Globalization;

namespace UserControls
{
	public partial class UCEnterFinancialData : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
        private VWA4Common.DBDetector dbDetector = null;
		VWA4Common.CommonEvents commonEvents = null;
		string sql;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCEnterFinancialData()
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
                dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
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
			lTaskTitle1.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
			lTaskTitle1.ForeColor = Color.Black;
		}


		/// <summary>
		/// Load the Financial Data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Financials.
		/// </summary>
		public void LoadData()
        {
			Initialized = false;
			//			
			// Initialize Data
			//	

            //OleDbConnection dbcon = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", VWA4Common.GlobalSettings.DatabaseDir));
            //OleDbDataAdapter ada = new OleDbDataAdapter(sql, dbcon);
            //DataSet ds = new DataSet();
			sql = string.Format("SELECT ID, FoodCostActual, FoodCostBudget, FoodRevenueActual, FoodRevenueBudget, MealCountActual, MealCountBudget, PeriodUniqueName, PeriodStartDate, SiteID FROM Financials where SiteID={0} ORDER BY PeriodStartDate DESC", VWA4Common.GlobalSettings.CurrentSiteID);
            ultraGrid1.DataSource = VWA4Common.DB.Retrieve(sql);

            this.lTaskTitle1.Text = string.Format("(for {0})", VWA4Common.GlobalSettings.CurrentSiteName);

            ultraGrid1.Refresh();

            //financialsTableAdapter = new UserControls.vwa40blankDataSetTableAdapters.FinancialsTableAdapter();
            //this.financialsTableAdapter.ClearBeforeFill = true;
            //financialsTableAdapter.Fill(vwa40blankDataSet.Financials);
            //Initialized = true;
            //ultraGrid1.DataSource = vwa40blankDataSet.Financials;
            //this.ultraGrid1.Rows.ColumnFilters["SiteID"].ClearFilterConditions();
            //this.ultraGrid1.Rows.ColumnFilters["SiteID"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, VWA4Common.GlobalSettings.CurrentSiteID);
            //lTaskTitle1.Text = "(for " + VWA4Common.GlobalSettings.CurrentSiteName + ")";
            //ultraGrid1.Refresh();
            Initialized = true;
		}
       
		
		public void SaveData()
        { }
        
		public bool ValidateData()
        { return true; }
        
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

		/// Event Handlers

		void dbDetector_PathChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		
		void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}

        //private void ultraGrid1_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        //{
        //    //UltraGridCell objCell = this.ultraGrid1.ActiveCell;
        //    //if (objCell == null) { return; }
        //    ////   Get the UIElement associated with the active cell, which we will    
        //    ////   need so we can get the size and location of the cell    
        //    //if (objCell.IsDataCell && objCell.Column.Key == "PeriodStartDate")
        //    //{
        //    //    // Make sure date is not in the future
        //    //    DateTime newDate = DateTime.Parse(objCell.Text);
        //    //    if (newDate > DateTime.Now)
        //    //    {
        //    //        MessageBox.Show("Future date is not allowed", "WVA Error");
        //    //        objCell.Selected = true;
        //    //        e.Cancel = true;
        //    //        return;
        //    //    }
        //    //    // Not in the future - now
        //    //    // Correct entered date to be first day of the month
        //    //    newDate = DateTime.Parse(newDate.ToString("yyyy/MM/" + "01 00:00:00"));
        //    //    DateTime firstdayofnextmonth = newDate.AddMonths(1);
        //    //    // Make sure that the month being entered does not already exist
        //    //    string sql = "SELECT * FROM Financials WHERE (PeriodStartDate >= #"
        //    //        + newDate.ToString("yyyy/MM/") + "01 00:00:00#) AND (PeriodStartDate < #"
        //    //        + firstdayofnextmonth.ToString("yyyy/MM/") + "01 00:00:00#)";
        //    //    DataTable dt_result = VWA4Common.DB.Retrieve(sql);
        //    //    if (dt_result.Rows.Count > 0)
        //    //    { // duplicate
        //    //        MessageBox.Show("Financial data already exists for specified month.");
        //    //        e.Cancel = true;
        //    //        return;
        //    //    }
        //    //    // We have passed the tests - update cell with new value
        //    //    ultraGrid1.ActiveCell.Value = newDate;
        //    //}
        //}

        //private void ultraGrid1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // catch pressing enter key means user finished input
        //    if (sender != null)
        //        if ((e.KeyChar == (System.Char)Keys.Return))
        //        {
        //            UltraGridRow objRow = this.ultraGrid1.ActiveRow;
        //            if (objRow != null)
        //            {
        //                objRow.Cells["SiteID"].Value = VWA4Common.GlobalSettings.CurrentSiteID;
        //                ((DataRowView)objRow.ListObject).Row["SiteID"] = VWA4Common.GlobalSettings.CurrentSiteID;
        //            }
        //            //ultraGrid1.UpdateData();
        //            //financialsTableAdapter.Update(vwa40blankDataSet.Financials);
        //        }
        //        else
        //        {
        //            //if (e.KeyChar == (System.Char)Keys.Delete || e.KeyChar == (System.Char)Keys.Back)
        //            //{
        //            //    if (this.ultraGrid1.Selected.Rows != null)
        //            //        foreach (UltraGridRow row in this.ultraGrid1.Selected.Rows)
        //            //            row.Delete(true);
        //            //    financialsTableAdapter.Update(vwa40blankDataSet.Financials);
        //            //}
        //        }
        //}

        private void ultraGrid1_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            UltraGridRow objRow = this.ultraGrid1.ActiveRow;
            if (objRow == null) { return; }
            if (objRow.Cells["PeriodStartDate"].Value.ToString() == "")
            {
                objRow.Delete(false);
                e.Cancel = true;
            }
        }

        private void ultraGrid1_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            /// Validation for PeriodStartDate (Date picker)
            UltraGridCell objCell = this.ultraGrid1.ActiveCell;
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell    
            if (objCell.IsDataCell && objCell.Column.Key == "PeriodStartDate" && objCell.Text.ToString()[0] != '_')
            {
                // Make sure date is not in the future
				//if (Regex.IsMatch(objCell.Text.ToString(), @"\d+\/\d+\/\d+"))
				//{
                    DateTime newDate = DateTime.Parse(objCell.Text);
                    if (objCell.Value.ToString() != "")
                    {
                        DateTime oldDate = DateTime.Parse(objCell.Value.ToString(), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                        if (oldDate.Month == newDate.Month && oldDate.Year == oldDate.Year)
                            return;
                    }
                    if (newDate > DateTime.Now)
                    {
                        MessageBox.Show("Future data is not allowed!", "Data Entry Error");
                        objCell.Selected = true;
                        e.Cancel = true;
                        return;
                    }
                    // Not in the future - now
                    // Correct entered date to be first day of the month
                    newDate = DateTime.Parse(newDate.ToString("yyyy/MM/" + "01 00:00:00"), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                    DateTime firstdayofnextmonth = newDate.AddMonths(1);
                    // Make sure that the month being entered does not already exist
                    string sql = "SELECT * FROM Financials WHERE (PeriodStartDate >= #"
                        + newDate.ToString("yyyy/MM/") + "01 00:00:00#) AND (PeriodStartDate < #"
                        + firstdayofnextmonth.ToString("yyyy/MM/") + "01 00:00:00#) AND SiteID = " + VWA4Common.GlobalSettings.CurrentSiteID;
                    DataTable dt_result = VWA4Common.DB.Retrieve(sql);
                    if (dt_result.Rows.Count > 0)
                    { // duplicate
						MessageBox.Show("Financial data already exists for specified month!", "Data Entry Error");
                        e.Cancel = true;
                        return;
                    }
                    // We have passed the tests - update cell with new value
                    ultraGrid1.ActiveCell.Value = newDate;
				//}
            }

        }

		//private void cbSite_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    if (Initialized)
		//    {
		//        ComboBoxItem cbi = (ComboBoxItem)cbSite.SelectedItem;
		//        VWA4Common.GlobalSettings.CurrentSiteID = cbi.Value;
		//        VWA4Common.DBDetector.GetDBDetector().SiteID = cbi.Value;
		//        this.ultraGrid1.Rows.ColumnFilters["SiteID"].ClearFilterConditions();
		//        this.ultraGrid1.Rows.ColumnFilters["SiteID"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, VWA4Common.GlobalSettings.CurrentSiteID);
		//        ultraGrid1.Refresh();
		//    }

		//}

		private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			if (this.ultraGrid1.Rows.ColumnFilters.Exists("SiteID"))
				this.ultraGrid1.Rows.ColumnFilters["SiteID"].ClearFilterConditions();

			this.ultraGrid1.Rows.ColumnFilters["SiteID"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, VWA4Common.GlobalSettings.CurrentSiteID);

            e.Layout.Bands[0].Columns["PeriodStartDate"].SortIndicator = SortIndicator.Descending;
            e.Layout.Bands[0].Columns["FoodCostActual"].SortIndicator = SortIndicator.None;
            e.Layout.Bands[0].Columns["FoodRevenueActual"].SortIndicator = SortIndicator.None;
            e.Layout.Bands[0].Columns["MealCountActual"].SortIndicator = SortIndicator.None;
            e.Layout.Bands[0].Columns["FoodCostBudget"].SortIndicator = SortIndicator.None;
            e.Layout.Bands[0].Columns["FoodRevenueBudget"].SortIndicator = SortIndicator.None;
            e.Layout.Bands[0].Columns["MealCountBudget"].SortIndicator = SortIndicator.None;

            ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Enter, UltraGridAction.NextRow, 0, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
			ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Delete, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
			ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Back, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));

			//if (!bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Enter Monthly Financials available")))
			if (!VWA4Common.GlobalSettings.EnterFinancialsAvailable)
				{
                this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
                this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            }
        }

		private void ultraGrid1_AfterRowsDeleted(object sender, EventArgs e)
		{
            ultraGrid1.DataSource = VWA4Common.DB.Retrieve(sql);
            ultraGrid1.Refresh();
		}

		private void updateFinancialData(decimal foodCostActual, decimal foodCostBudget, decimal foodRevenueActual, decimal foodRevenueBudget, int mealCountActual, int mealCountBudget, string periodName, DateTime periodStartDate)
		{
			string rsql = "SELECT ID, PeriodStartDate FROM Financials WHERE PeriodStartDate=#"
				+ periodStartDate.ToString() + "#";
			DataTable dt_result = VWA4Common.DB.Retrieve(rsql);
			if (dt_result.Rows.Count > 0)
			{
				// Update the row rather than insert a new one
				string usql = "UPDATE Financials SET FoodCostActual= " + foodCostActual.ToString()
					+ ", FoodCostBudget = " + foodCostBudget.ToString()
					+ ", FoodRevenueActual = " + foodRevenueActual.ToString()
					+ ", FoodRevenueBudget = " + foodRevenueBudget.ToString()
					+ ", MealCountActual = " + mealCountActual.ToString()
					+ ", MealCountBudget = " + mealCountBudget.ToString()
					+ " WHERE PeriodStartDate = #" + periodStartDate.ToString() + "#";
				VWA4Common.DB.Update(usql);
			}
			else
			{
				string isql = "INSERT into Financials (FoodCostActual, FoodCostBudget, FoodRevenueActual, FoodRevenueBudget, MealCountActual, MealCountBudget, PeriodUniqueName, PeriodStartDate, SiteID)";
				isql += string.Format(" VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', {8})", foodCostActual, foodCostBudget, foodRevenueActual, foodRevenueBudget, mealCountActual, mealCountBudget, periodName, periodStartDate, VWA4Common.GlobalSettings.CurrentSiteID);
				VWA4Common.DB.Update(isql);
			}
			ultraGrid1.Refresh();
		}

        private void deleteFinancialData(int id)
        {
            string dsql = string.Format("delete from Financials where ID={0}", id);
            VWA4Common.DB.Delete(dsql);
        }

        private void ultraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
			if (this.ultraGrid1.ActiveRow.IsAddRow) return;
			CellsCollection row = null;

            if (this.ultraGrid1.ActiveRow != null)
            {
                row = this.ultraGrid1.ActiveRow.Cells;
                row["SiteID"].Value = VWA4Common.GlobalSettings.CurrentSiteID;
                row["PeriodUniqueName"].Value = "Month";
                if (row["PeriodStartDate"].Value == null)
                {
                    MessageBox.Show("Period start date is required.");
                    return;
                }
            }

			//ultraGrid1.UpdateData();
            if (row != null)
            {
                decimal fca = row["FoodCostActual"].Value != DBNull.Value ? Convert.ToDecimal(row["FoodCostActual"].Value) : Convert.ToDecimal(0.00);
                decimal fcb = row["FoodCostBudget"].Value != DBNull.Value ? Convert.ToDecimal(row["FoodCostBudget"].Value) : Convert.ToDecimal(0.00);
                decimal fra = row["FoodRevenueActual"].Value != DBNull.Value ? Convert.ToDecimal(row["FoodRevenueActual"].Value) : Convert.ToDecimal(0.00);
                decimal frb = row["FoodRevenueBudget"].Value != DBNull.Value ? Convert.ToDecimal(row["FoodRevenueBudget"].Value) : Convert.ToDecimal(0.00);
                int mca = row["MealCountActual"].Value != DBNull.Value ? Convert.ToInt32(row["MealCountActual"].Value) : 0;
                int mcb = row["MealCountBudget"].Value != DBNull.Value ? Convert.ToInt32(row["MealCountBudget"].Value) : 0;

                this.updateFinancialData(fca, fcb, fra, frb, mca, mcb, row["PeriodUniqueName"].Value.ToString(), DateTime.Parse(row["PeriodStartDate"].Value.ToString()));
            }

			if (this.ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.Cells["ID"].Value != DBNull.Value)
            {
                ultraGrid1.DataSource = VWA4Common.DB.Retrieve(sql);
                Initialized = true;
                ultraGrid1.Refresh();
            }

			// Check the task complete
			VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
			utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "entermonthlyfinancials");
		}
		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			if (ultraGrid1.Selected.Rows.Count > 0)
			{
                foreach (UltraGridRow r in ultraGrid1.Selected.Rows)
                {
                    this.deleteFinancialData(Convert.ToInt32(r.Cells["ID"].Value));
                }
                this.ultraGrid1.DataSource = VWA4Common.DB.Retrieve(sql);
                this.ultraGrid1.Refresh();
			}
			else
			{
				MessageBox.Show("No rows selected.\nClick on the leftmost cell of a row to select it,\nand try again.", "Delete Selected Rows");
			}
		}
		private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			//if (!bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Enter Monthly Financials available")))
			if (!VWA4Common.GlobalSettings.EnterFinancialsAvailable)
			{
				this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
				this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
				this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			}
			else
			{
				this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop;
				this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
				this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			}
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Monthly Financials available")))
				commonEvents.TaskSheetKey = "dashboard";
		}
	}
}
