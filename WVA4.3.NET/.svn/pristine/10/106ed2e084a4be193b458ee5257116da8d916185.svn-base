using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

namespace UserControls
{
	public partial class UCManageAdjustments : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
        private VWA4Common.DBDetector dbDetector = null;
        private VWA4Common.TrackerDetector trackerDetector = null; // subscribe for db change

		VWA4Common.CommonEvents commonEvents = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageAdjustments()
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
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.TrackerConfigOutofSync += new VWA4Common.TrackerDetectorEventHandler(trackerDetector_TrackerConfigOutofSync);
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
		}

		private string _DBPath = "";
        public string DBPath
        {
            get { return _DBPath; }
            set { _DBPath = value; }
        }
        private VWADiscounts m_VWADiscounts;
        private WeightsData m_VWAWeightsData;
		/// <summary>
		/// Load the Food Cost Adjustsments (Discounts) Data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Discounts table.
		/// </summary>
		public void LoadData()
		{
			//if (_DBPath == "")
			//    _DBPath = VWA4Common.AppContext.WasteConnectionString;
			//else if (_DBPath == VWA4Common.AppContext.WasteConnectionString && m_VWADiscounts.DBExists)
			//    return;// do not load DB again
			Initialized = false;
            m_VWADiscounts = new VWADiscounts();
            if (m_VWADiscounts.DBExists)
            {
                //   Clear previouse settings if any
                if (this.ultraGrid1.DisplayLayout != null)
                    this.ultraGrid1.DisplayLayout.ValueLists.Clear();
                this.ultraGrid1.Rows.ColumnFilters.ClearAllFilters();
                //   Populate a value list with the names and IDs
                PopulateNamesValueLists();

                this.ultraGrid1.Text = "";
                // use datasource depending on mode
                this.ultraGrid1.DataSource = m_VWADiscounts.GetDiscountTable();


                this.ultraGrid1.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
                this.ucTreeView1.ShowPrice = true;
                HideEditControls();
                
            }
            else
            {   // load empty not editable grid
                this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            }
		}

        
		public void SaveData()
		{
            try
            {
                if (this.ultraGrid1.ActiveRow != null && 
                    (this.ultraGrid1.ActiveRow.Cells["LossTypeID"].Value.ToString() == "" || 
                    this.ultraGrid1.ActiveRow.Cells["FoodTypeID"].Value.ToString() == ""))
                    this.ultraGrid1.ActiveRow.Delete(false);
                this.ultraGrid1.UpdateData();
                m_VWADiscounts.UpdateData();
                //dbDetector.FoodAdjustmentsChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error Saving data: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            SaveData();
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
            if (this.IsActive)
            {
                LoadData();
                ucTreeView1.Reload();
            }
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

        private void PopulateNamesValueLists()
        {
            DataTable ds;
            m_VWAWeightsData = new WeightsData();

            
            if (!this.ultraGrid1.DisplayLayout.ValueLists.Exists("FoodTypeIDNames"))
            {
                ValueList objValueList = this.ultraGrid1.DisplayLayout.ValueLists.Add("FoodTypeIDNames");

                ds = m_VWAWeightsData.FoodType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                //objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.ultraGrid1.DisplayLayout.ValueLists.Exists("LossTypeIDNames"))
            {
                ValueList objValueList = this.ultraGrid1.DisplayLayout.ValueLists.Add("LossTypeIDNames");

                ds = m_VWAWeightsData.LossType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (m_VWADiscounts.DBExists)
            {
                e.Layout.Bands[0].Columns["LossTypeID"].Header.Caption = "Loss Type";
                e.Layout.Bands[0].Columns["LossTypeID"].SortIndicator = SortIndicator.Ascending;
                e.Layout.Bands[0].Columns["FoodTypeID"].Header.Caption = "Waste Type";
                e.Layout.Bands[0].Columns["FoodTypeID"].SortIndicator = SortIndicator.Ascending;
                e.Layout.Bands[0].Columns["FoodCostDiscount"].Header.Caption = "Discount";
                e.Layout.Bands[0].Columns["FoodCostDiscount"].SortIndicator = SortIndicator.Ascending;
                e.Layout.Bands[0].Columns["ID"].Hidden = true;
                e.Layout.Bands[0].Columns["FakeID"].Hidden = true;

                e.Layout.Bands[0].Columns["FoodCostDiscount"].CellActivation = Activation.AllowEdit;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].Style =
                    Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegativeWithSpin;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].MaskInput = "{double:3.2:c}%";
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].MaxValue = 1000000;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].DefaultCellValue = 1;

                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodCostDiscount"].Format = "0.00%";

                e.Layout.Bands[0].Columns["FoodTypeID"].ValueList = this.ultraGrid1.DisplayLayout.ValueLists["FoodTypeIDNames"];
                e.Layout.Bands[0].Columns["LossTypeID"].ValueList = this.ultraGrid1.DisplayLayout.ValueLists["LossTypeIDNames"];
                e.Layout.Bands[0].Columns["FoodTypeID"].SortComparer = new MySortComparer();
                e.Layout.Bands[0].Columns["LossTypeID"].SortComparer = new MySortComparer();

                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["LossTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodTypeID"].CellActivation = Activation.ActivateOnly;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["FoodTypeID"].EditorControl = ultraTextEditor1;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["LossTypeID"].CellActivation = Activation.ActivateOnly;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns["LossTypeID"].EditorControl = ultraTextEditor1;

                ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Enter, UltraGridAction.NextRow, 0, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
                ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Delete, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
                ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Back, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));

                ultraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
                ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            }
        }

        private void HideEditControls()
        {
            this.ucTreeView1.Visible = false;
            this.ultraTextEditor1.Visible = false;
        }

        private class MySortComparer : IComparer
        {
            internal MySortComparer()
            {
            }

            int IComparer.Compare(object x, object y)
            {

                // Passed in objects are cells. So you have to typecast them to UltraGridCell objects first.
                UltraGridCell xCell = (UltraGridCell)x;
                UltraGridCell yCell = (UltraGridCell)y;

                // Do your own comparision between the values of xCell and yCell and return a negative
                // number if xCell is less than yCell, positive number if xCell is greater than yCell,
                // and 0 if xCell and yCell are equal.

                // Following code does an case-insensitive compare of the values converted to string.
                string text1 = xCell.Text;
                string text2 = yCell.Text;

                return String.Compare(text1, text2, true);

            }
        }

        private void ultraGrid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.ultraGrid1.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell    
            if (objCell.IsDataCell)
            {
                CellUIElement objCellUIElement = (CellUIElement)objCell.GetUIElement(this.ultraGrid1.ActiveRowScrollRegion, this.ultraGrid1.ActiveColScrollRegion);
                if (objCellUIElement == null) { return; }
                //   Get the size and location of the cell    
                int left = objCellUIElement.RectInsideBorders.Location.X + this.ultraGrid1.Location.X;
                int top = objCellUIElement.RectInsideBorders.Location.Y + this.ultraGrid1.Location.Y;
                int width = objCellUIElement.RectInsideBorders.Width;
                int height = objCellUIElement.RectInsideBorders.Height;
                //   The edit control we will use depends on which column we are editing    
                //   The values of the identity fields are not very useful to the end user.    
                //   Let's display the name in these columns instead,    
                //   using the intrisic ComboBox control    
                if (Regex.IsMatch(objCell.Column.Key, "TypeID"))
                {
                    //   Set the date picker's size and location equal to the active cell's size and location        
                    this.ucTreeView1.SetBounds(left, top, ucTreeView1.Width, ucTreeView1.Height);
                    //   Set the value  
                    this.ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
                        Regex.Replace(objCell.Column.Key, "TypeID", ""),
                        objCell.Value.ToString());
                }
                else if (objCell.Column.Key == "FoodCostDiscount")
                {
                    decimal value = cellValue(objCell.Value.ToString());
                    if (value != 0)
                    {
                        objCell.Value = value * 100m;
                    }
                }
            }
        }

        private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.ultraGrid1.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
			//if (VWA4Common.VWACommon.IsAllowEditVersion() && Regex.IsMatch(objCell.Column.Key, "TypeID"))
				if (Regex.IsMatch(objCell.Column.Key, "TypeID"))
				{
                objCell.SetValue(e.ID, true);
                ultraTextEditor1.CloseEditorButtonDropDowns();
            }
        }

        void trackerDetector_TrackerConfigOutofSync(object sender, EventArgs e)
        {
            ucTreeView1.Reload();
            //ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
            //            "User", "0"); ;
        }

        //private int _LastID = 1;
        private void ultraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            if (this.ultraGrid1.ActiveRow.Cells["LossTypeID"].Value.ToString() == "")
                this.ultraGrid1.ActiveRow.Cells["LossTypeID"].Selected = true;
            else if (this.ultraGrid1.ActiveRow.Cells["FoodTypeID"].Value.ToString() == "")
                this.ultraGrid1.ActiveRow.Cells["FoodTypeID"].Selected = true;
            if (this.ultraGrid1.ActiveRow.Cells["ID"].Value.ToString() == "" && this.ultraGrid1.ActiveRow.Cells["FakeID"].Value.ToString() == "")
                this.ultraGrid1.ActiveRow.Cells["FakeID"].Value = 1;
        }
        
        private void ultraGrid1_BeforeRowUpdate(object sender, CancelableRowEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridRow row = this.ultraGrid1.ActiveRow;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (row == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 
            if (row.Cells["FoodTypeID"].Value.ToString() == "" || row.Cells["LossTypeID"].Value.ToString() == "")
            {
                e.Cancel = true;
                return; // let user to change food/loss type
            }
            DataTable ds = (DataTable)this.ultraGrid1.DataSource;
            //DataColumn[] keys = new DataColumn[1];
            //keys[0] = ds.Columns["FoodTypeID"];

            //ds.PrimaryKey = keys;
            
            DataRow[] foundRows = ds.Select("FoodTypeID = '" + row.Cells["FoodTypeID"].Value.ToString() + " ' AND LossTypeID = '" +
                row.Cells["LossTypeID"].Value.ToString() + "'");
            if (foundRows.Length > 0)
            {
                if (foundRows.Length == 1 && (foundRows[0]["ID"].ToString() == row.Cells["ID"].Value.ToString()) 
                    && row.Cells["FakeID"].Value.ToString() != "")
                    return; //this is row update
                MessageBox.Show("This Combination of " + //VWA4Common.VWACommon.WasteProfile + 
					"Food and Loss already exists!", "Data Entry Error");
                //row.Selected = true;
                e.Cancel = true;
                return; // let user to change food/loss type
            }
            //this.ultraGrid1.UpdateData();
                
        }

        private void ultraGrid1_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;
            if (activeCell == null) return;
            if (activeCell.IsDataCell && activeCell.Column.Key == "FoodCostDiscount")
            {
                decimal value = cellValue(activeCell.Text);
                activeCell.Value = value / 100m;
            }
        }

        private decimal cellValue(string cellValue)
        {
            decimal value = 0;
            decimal.TryParse(cellValue.Replace("%", "").Replace("_", ""), out value);
            return value;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this Adjustment?", "Delete Ajustment", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == 
                DialogResult.OK)
            {
                ultraGrid1.DeleteSelectedRows(false);
            }
        }
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Food Cost Adjustments")))
				commonEvents.TaskSheetKey = "dashboard";
		}
	}
}
