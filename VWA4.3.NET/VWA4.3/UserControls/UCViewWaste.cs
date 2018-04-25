using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

// DEPRECATED
namespace UserControls
{/*
    internal class extendedComboBox : ComboBox
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            // catch WM_KEYDOWN with TAB
            if (msg.Msg == 0x0100 && msg.WParam.ToInt32() == 9)
            {
                UltraGrid grid = ((UCViewWaste)this.Parent).gridViewWaste;

                grid.Focus();

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    grid.PerformAction(UltraGridAction.PrevCellByTab);
                else
                    grid.PerformAction(UltraGridAction.NextCellByTab);

                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Extended datetime picker which handles TAB key
    /// </summary>
    internal class extendedDateTimePicker : DateTimePicker
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            // catch WM_KEYDOWN with TAB
            if (msg.Msg == 0x0100 && msg.WParam.ToInt32() == 9)
            {
                UltraGrid grid = ((UCViewWaste)this.Parent).gridViewWaste;

                grid.Focus();

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    grid.PerformAction(UltraGridAction.PrevCellByTab);
                else
                    grid.PerformAction(UltraGridAction.NextCellByTab);

                return true;
            }

            return false;
        }
    }

    */
    public partial class UCViewWaste : UserControl, IVWAUserControlBase
    {
        public UCViewWaste(): this(DisplayMode.Weights)
        {
        }

        public UCViewWaste(DisplayMode mode)
        {
            this.mode = mode;
            InitializeComponent();
        }

        private VWAWeights m_VWAWeights;
        private WeightsData m_VWAWeightsData;
        private string configfileName;
        public string ConfigFileName
        { set { configfileName = value; } }

        public enum DisplayMode { Weights, Both }
        private DisplayMode mode;

        private void UCViewWaste_Load(object sender, EventArgs e)
        {
            m_VWAWeights = new VWAWeights();
            if (m_VWAWeights.DBExists)
            {
                //   Populate a value list with the names and IDs of the space ports
                PopulateNamesValueLists();

                this.gridViewWaste.Text = "";
                // use datasource depending on mode
                switch (mode)
                { 
                    case DisplayMode.Both:
                        this.gridViewWaste.DataSource = m_VWAWeights.GetTransfersWeightsDetails();
                        break;
                    default:
                        this.gridViewWaste.DataSource = m_VWAWeights.GetTransfersWeightsDetails().Tables["Weights"];
                        break;
                }

                this.gridViewWaste.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
                // Add default filters
                //this.gridViewWaste.DisplayLayout.Bands["Weights"].ColumnFilters["NItems"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThanOrEqualTo, "0"); 

                //   Configure the date/time picker, hide it initially
                this.dtpStamp.Visible = false;
            }
            else
            {   // load empty not editable grid
                this.gridViewWaste.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            }
        }

        private void PopulateNamesValueLists()
        {
            DataTable ds;
            m_VWAWeightsData = new WeightsData();
            
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("TermNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("TermNames");

                ds = m_VWAWeightsData.Terminals;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("SiteNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("SiteNames");

                ds = m_VWAWeightsData.Sites;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("TypeCatalogNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("TypeCatalogNames");

                ds = m_VWAWeightsData.TypeCatalogs;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());

                objValueList.ValueListItems.Add(null, "Master");
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("PreconsumerNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("PreconsumerNames");
                objValueList.ValueListItems.Add(0, "Post consumer");
                objValueList.ValueListItems.Add(1, "Pre consumer");
                objValueList.ValueListItems.Add(2, "Intermediate");
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("FoodNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("FoodNames");

                ds = m_VWAWeightsData.FoodType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("LossNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("LossNames");

                ds = m_VWAWeightsData.LossType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("ContainerNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("ContainerNames");

                ds = m_VWAWeightsData.ContainerType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("StationNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("StationNames");

                ds = m_VWAWeightsData.StationType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("DispositionNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("DispositionNames");

                ds = m_VWAWeightsData.DispositionType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("DaypartNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("DaypartNames");

                ds = m_VWAWeightsData.DayPartType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("BEONames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("BEONames");

                ds = m_VWAWeightsData.BEOType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("UserNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("UserNames");

                ds = m_VWAWeightsData.UserType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
        }

        private void gridViewWaste_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if ((configfileName != null) && (!configfileName.Equals("")))
                try {
                    this.gridViewWaste.DisplayLayout.LoadFromXml(configfileName);
                    if (sender != null)
                        filterChanged(this, e);
                }
                catch (Exception)//don't show exception if we were not able to load
                {
                    MessageBox.Show("Config file is not correct. Applying default settings", "VWA View Waste Config");
                }
            // disable key fields for editing
            e.Layout.Bands["Weights"].Columns["ID"].CellActivation = Activation.Disabled;
            e.Layout.Bands["Weights"].Columns["TransKey"].CellActivation = Activation.Disabled;
            e.Layout.Bands["Weights"].Columns["WasteCost"].CellActivation = Activation.Disabled;

            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["Weight"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["WasteCost"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["FoodTypeCost"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["ContainerCost"].Style =
            Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["NItems"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositiveWithSpin;
            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["ProducedID"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;

            //   Hide the irrelevant columns
            //e.Layout.Bands["Transfers"].Columns["TransKey"].Hidden = true;
            //	Resize the columns that we are interested in
            e.Layout.Bands["Weights"].Columns["Timestamp"].Width = 150;

            e.Layout.Bands["Weights"].Columns["IsPreconsumer"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["PreconsumerNames"];
            e.Layout.Bands["Weights"].Columns["FoodTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["FoodNames"];
            e.Layout.Bands["Weights"].Columns["LossTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["LossNames"];
            e.Layout.Bands["Weights"].Columns["ContainerTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["ContainerNames"];
            e.Layout.Bands["Weights"].Columns["StationTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["StationNames"];
            e.Layout.Bands["Weights"].Columns["DispositionTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DispositionNames"];
            e.Layout.Bands["Weights"].Columns["DaypartTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DaypartNames"];
            e.Layout.Bands["Weights"].Columns["BEOTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["BEONames"];
            e.Layout.Bands["Weights"].Columns["UserTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["UserNames"];

            this.gridViewWaste.DisplayLayout.Bands["Weights"].Columns["FoodTypeID"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;

            //   Make the style of these two columns Edit so that the value list dropdown arrow
            //   doesn't appear, since we are displaying a custom edit control rather than use the
            //   ValueList
            //e.Layout.Bands["Transfers"].Columns["FoodTypeID"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //   We don't want to see the time portion of the date in the
            //   date columns, and we don't want to see the date portion
            //   in the time columns, so let's use the column's Format property
            //   to filter out the portions of the DateTime object that we don't want
            e.Layout.Bands["Weights"].Columns["Timestamp"].Format = "MM/dd/yyyy HH:mm:ss";

            // init colum headers
            e.Layout.Bands["Weights"].Columns["TransKey"].Header.Caption = "Transfer Key";
            e.Layout.Bands["Weights"].Columns["WasteCost"].Header.Caption = "Waste Cost";
            e.Layout.Bands["Weights"].Columns["FoodTypeID"].Header.Caption = "Food Type";
            e.Layout.Bands["Weights"].Columns["FoodTypeCost"].Header.Caption = "Food Type Cost";
            e.Layout.Bands["Weights"].Columns["LossTypeID"].Header.Caption = "Loss Type";
            e.Layout.Bands["Weights"].Columns["ContainerTypeID"].Header.Caption = "Container Type";
            e.Layout.Bands["Weights"].Columns["ContainerWeight"].Header.Caption = "Container Weight";
            e.Layout.Bands["Weights"].Columns["ContainerCost"].Header.Caption = "Container Cost";
            e.Layout.Bands["Weights"].Columns["FoodTypeCost"].Header.Caption = "Food Type Cost";
            e.Layout.Bands["Weights"].Columns["StationTypeID"].Header.Caption = "Station Type";
            e.Layout.Bands["Weights"].Columns["DispositionTypeID"].Header.Caption = "Disposition Type";
            e.Layout.Bands["Weights"].Columns["DaypartTypeID"].Header.Caption = "DayPart Type";
            e.Layout.Bands["Weights"].Columns["BEOTypeID"].Header.Caption = "Event Order Type";
            e.Layout.Bands["Weights"].Columns["UserTypeID"].Header.Caption = "User Type";
            e.Layout.Bands["Weights"].Columns["UserQuestion"].Header.Caption = "User Question";
            e.Layout.Bands["Weights"].Columns["NItems"].Header.Caption = "Number of Items";
            e.Layout.Bands["Weights"].Columns["ProducedID"].Header.Caption = "Number of Produced Items";
            e.Layout.Bands["Weights"].Columns["UnitUniqueName"].Header.Caption = "Unit of Measure";

            // You can control the appearance of the separator using the SpecialRowSeparatorAppearance
            // property.
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199);

            e.Layout.Override.RowAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;

            //	use the same appearance for alternate rows
            e.Layout.Override.RowAlternateAppearance = e.Layout.Override.RowAppearance;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            e.Layout.Override.CellAppearance.AlphaLevel = 150;

            e.Layout.Override.HeaderAppearance.AlphaLevel = 150;
            e.Layout.Override.HeaderAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel;

            // FILTER ROW FUNCTIONALITY RELATED ULTRAGRID SETTINGS
            // ----------------------------------------------------------------------------------
            // Enable the the filter row user interface by setting the FilterUIType to FilterRow.
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            // FilterEvaluationTrigger specifies when UltraGrid applies the filter criteria typed 
            // into a filter row. Default is OnCellValueChange which will cause the UltraGrid to
            // re-filter the data as soon as the user modifies the value of a filter cell.
            e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange;

            // By default the UltraGrid selects the type of the filter operand editor based on
            // the column's DataType. For DateTime and boolean columns it uses the column's editors.
            // For other column types it uses the Combo. You can explicitly specify the operand
            // editor style by setting the FilterOperandStyle on the override or the individual
            // columns.
            //e.Layout.Override.FilterOperandStyle = FilterOperandStyle.Combo;

            // By default UltraGrid displays user interface for selecting the filter operator. 
            // You can set the FilterOperatorLocation to hide this user interface. This
            // property is available on column as well so it can be controlled on a per column
            // basis. Default is WithOperand. This property is exposed off the column as well.
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;

            // By default the UltraGrid uses StartsWith as the filter operator. You use
            // the FilterOperatorDefaultValue property to specify a different filter operator
            // to use. This is the default or the initial filter operator value of the cells
            // in filter row. If filter operator user interface is enabled (FilterOperatorLocation
            // is not set to None) then that ui will be initialized to the value of this
            // property. The user can then change the operator as he/she chooses via the operator
            // drop down.
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals;

            // FilterOperatorDropDownItems property can be used to control the options provided
            // to the user for selecting the filter operator. By default UltraGrid bases 
            // what operator options to provide on the column's data type. This property is
            // avaibale on the column as well.
            e.Layout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Default;

            // By default UltraGrid displays a clear button in each cell of the filter row
            // as well as in the row selector of the filter row. When the user clicks this
            // button the associated filter criteria is cleared. You can use the 
            // FilterClearButtonLocation property to control if and where the filter clear
            // buttons are displayed.
            e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell;
            
            // Appearance of the filter row can be controlled using the FilterRowAppearance proeprty.
            e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow;

            // You can use the FilterRowPrompt to display a prompt in the filter row. By default
            // UltraGrid does not display any prompt in the filter row.
            e.Layout.Override.FilterRowPrompt = "Click here to filter data...";

            // You can use the FilterRowPromptAppearance to change the appearance of the prompt.
            // By default the prompt is transparent and uses the same fore color as the filter row.
            // You can make it non-transparent by setting the appearance' BackColorAlpha property 
            // or by setting the BackColor to a desired value.
            e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque;

            // By default the prompt is spread across multiple cells if it's bigger than the
            // first cell. You can confine the prompt to a particular cell by setting the
            // SpecialRowPromptField property off the band to the key of a column.
            //e.Layout.Bands["Weights"].SpecialRowPromptField = e.Layout.Bands["Weights"].Columns[0].Key;
            
            // Display a separator between the filter row other rows. SpecialRowSeparator property 
            // can be used to display separators between various 'special' rows, including for the
            // filter row. This property is a flagged enum property so it can take multiple values.
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow;

            // ----------------------------------------------------------------------------------
            //e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnBottom;
            e.Layout.Override.AllowDelete = DefaultableBoolean.True;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.True;
            // sorting properties
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // display cell text on multiple lines
            e.Layout.Override.RowSizing = RowSizing.AutoFree;
            e.Layout.Override.CellMultiLine = DefaultableBoolean.True;
            // turn row selectors on for band 0
            e.Layout.Bands["Weights"].Override.RowSelectors = DefaultableBoolean.True;

            // init transfer's bands if used
            if (e.Layout.Bands[0].Key.Equals("Transfers"))
            {
                e.Layout.Bands["Transfers"].Override.RowSelectors = DefaultableBoolean.True;
                e.Layout.Bands["Transfers"].Columns["TransKey"].CellActivation = Activation.Disabled;

                //value editors
                Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit editor = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
                editor.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
                editor.InputMask = @"4\.nn\.nn";
                editor.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                editor.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                editor.DisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                
                e.Layout.Bands["Transfers"].Columns["TrackerSWVersion"].EditorControl = editor;
                // Set the mask modes. This only effects columns that use EditorWithMask or derived editors.
                e.Layout.Bands["Transfers"].Columns["TrackerSWVersion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                
                e.Layout.Bands["Transfers"].Columns["Timestamp"].Width = 150;
                e.Layout.Bands["Transfers"].Columns["Timestamp"].Format = "MM/dd/yyyy HH:mm:ss";

                //   The FoodTypeID and LossTypeID
                //   columns should display the name, not the ID.
                //   We can use a ValueList to accomplish this
                e.Layout.Bands["Transfers"].Columns["TermID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TermNames"];
                e.Layout.Bands["Transfers"].Columns["SiteID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["SiteNames"];
                e.Layout.Bands["Transfers"].Columns["TypeCatalogID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TypeCatalogNames"];
            }
        }

        private void gridViewWaste_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            //this.cboFoodName.Visible = false;
            this.dtpStamp.Visible = false;
        }

        private void HideEditControls()
        {
            //this.cboFoodName.Visible = false;
            this.dtpStamp.Visible = false;
        }

        private void gridViewWaste_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterColRegionScroll(object sender, ColScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterColRegionSize(object sender, ColScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowRegionScroll(object sender, RowScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowRegionSize(object sender, RowScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowResize(object sender, RowEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell    
            if (objCell.IsDataCell)
            {
                CellUIElement objCellUIElement = (CellUIElement)objCell.GetUIElement(this.gridViewWaste.ActiveRowScrollRegion, this.gridViewWaste.ActiveColScrollRegion);
                if (objCellUIElement == null) { return; }
                //   Get the size and location of the cell    
                int left = objCellUIElement.RectInsideBorders.Location.X + this.gridViewWaste.Location.X;
                int top = objCellUIElement.RectInsideBorders.Location.Y + this.gridViewWaste.Location.Y;
                int width = objCellUIElement.RectInsideBorders.Width;
                int height = objCellUIElement.RectInsideBorders.Height;
                //   The edit control we will use depends on which column we are editing    
                //   The values of the identity fields are not very useful to the end user.    
                //   Let's display the name in these columns instead,    
                //   using the intrisic ComboBox control    
                if (objCell.Column.Key == "FoodTypeID")
                {
                    /*
                    //   Set the combobox's size and location equal to the active cell's size and location        
                    this.cboFoodName.SetBounds(left, top, width, height);
                    //   Using the cell's value, select the appropriate item in the combobox        
                    this.cboFoodName.SelectedValue = objCell.Value;
                    //   Show the combobox control over the cell, and give it focus        
                    cboFoodName.Visible = true;
                    cboFoodName.Focus();
                    cboFoodName.BringToFront();

                    //   Set the Cancel parameter to true so we don't actually go into edit mode        
                    //e.Cancel = true; */
                }
                else
                    if (objCell.Column.Key == "Timestamp")
                    {
                        //   Set the date picker's size and location equal to the active cell's size and location        
                        this.dtpStamp.SetBounds(left, top, dtpStamp.Width, dtpStamp.Height);
                        //   Set the value        
                        DateTime temp = DateTime.Parse(objCell.Value.ToString());
                        this.dtpStamp.Value = temp;
                        this.dtpStamp.Visible = true;
                        this.dtpStamp.Focus();
                        this.dtpStamp.BringToFront();
                        //   Set the Cancel parameter to true so we don't actually go into edit mode        
                        //e.Cancel = true;
                    }
            }
        }

        private void dtpStamp_Leave(object sender, EventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (objCell.Column.Key == "Timestamp")
            {
                objCell.Value = dtpStamp.Value;
            }
        }

        private void dtpStamp_EnterPressed(object sender, EventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (objCell.Column.Key == "Timestamp")
            {
                objCell.Value = dtpStamp.Value;
            }
            dtpStamp.Visible = false;
            dtpStamp.SendToBack();
            this.gridViewWaste.Focus();
            this.gridViewWaste.ActiveCell.Selected = true;
            
        }

        public void CreateFilter()
        {
            Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog c = new Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog(this.gridViewWaste);
            if (this.gridViewWaste.ActiveCell == null)
                this.gridViewWaste.ActiveCell = this.gridViewWaste.Rows[0].Cells[0]; //default column
            Infragistics.Win.UltraWinGrid.UltraGridColumn column = this.gridViewWaste.ActiveCell.Column;
            Infragistics.Win.UltraWinGrid.ColumnFilter cf = this.gridViewWaste.Rows.ColumnFilters[column];
            c.ShowDialog(cf, this.gridViewWaste.Rows);
        }

        public void ClearFilter()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand band in this.gridViewWaste.DisplayLayout.Bands)
            {
                // since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
                // will clear the filters
                band.ColumnFilters.ClearAllFilters();
            }
        }

        public void LoadData()
        { }

        public void SaveData()
        {
            this.gridViewWaste.UpdateData();
            m_VWAWeights.UpdateData();

        }

        public void Init(DateTime firstDayOfWeek)
        {
            _IsActive = true;
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
            _IsActive = false;
        }
        
        private void gridViewWaste_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int n = e.Row.Index;
            //WeightStruct[] weight = new WeightStruct[10];
        }
      
        private void gridViewWaste_CellChange(object sender, CellEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 

            if (objCell.IsDataCell && objCell.Band.Key == "Weights") // change cost for weights
            {
                WeightStruct weight = new WeightStruct();
                int nID = int.Parse(objCell.Row.Cells["ID"].Value.ToString());

                //   The edit control we will use depends on which column we are editing    
                //   The values of the identity fields are not very useful to the end user.    
                //   Let's display the name in these columns instead,    
                //   using the intrisic ComboBox control    
                if (objCell.Column.Key == "FoodTypeID")
                {
                    weight = m_VWAWeightsData.GetFoodCost(nID, objCell.Column.ValueList.GetValue(objCell.Column.ValueList.SelectedItemIndex).ToString());
                    if (weight != null)
                        objCell.Row.Cells["FoodTypeCost"].SetValue(weight.FoodCost, true);
                    else // wrong FoodTypeID
                    {
                        MessageBox.Show("This Food Type is not allowded for this Type Catalog", "WVA Error");
                        objCell.Selected = true;
                        return; // let user to change food type
                    }
                }
                else
                    if (objCell.Column.Key == "ContainerTypeID")
                    {
                        weight = m_VWAWeightsData.GetContainerCost(nID, objCell.Column.ValueList.GetValue(objCell.Column.ValueList.SelectedItemIndex).ToString());
                        if (weight != null)
                        {
                            objCell.Row.Cells["ContainerCost"].SetValue(weight.ContainerCost, true);
                            objCell.Row.Cells["ContainerWeight"].SetValue(weight.ContainerWeight, true);
                        }
                        else // wrong ContainerTypeID
                        {
                            MessageBox.Show("This Container Type is not allowded for this Type Catalog", "WVA Error");
                            objCell.Selected = true;
                            return; // let user to change food type
                        }
                    }
                
                int nItems = int.Parse(objCell.Row.Cells["NItems"].Value.ToString());
                string discount = "1";
                if (objCell.Row.Cells.Exists("FoodTypeDiscount"))
                    discount = objCell.Row.Cells["FoodTypeDiscount"].Value.ToString();
                weight = new WeightStruct(objCell.Row.Cells["FoodTypeCost"].Value.ToString(), discount,
                    objCell.Row.Cells["Weight"].Value.ToString(), objCell.Row.Cells["ContainerCost"].Value.ToString(),
                    objCell.Row.Cells["ContainerWeight"].Value.ToString(), objCell.Row.Cells["NItems"].Value.ToString());

                if ((objCell.Column.Key == "FoodTypeCost") || (objCell.Column.Key == "Weight") || (objCell.Column.Key == "ContainerWeight")
                    || (objCell.Column.Key == "ContainerCost") || (objCell.Column.Key == "NItems"))
                try
                {
                    string str = objCell.Text; 
                    // remove mask symbols to retrieve editing values
                    str = Regex.Match(str, @"(\d+\,?\d+\.?\d*|\d+\.?\d*|\.\d+)").ToString();
                    if (objCell.Column.Key == "FoodTypeCost")
                        weight.FoodCost = decimal.Parse(str);
                    if (objCell.Column.Key == "Weight")
                        weight.Weight = decimal.Parse(str);
                    if (objCell.Column.Key == "ContainerCost")
                        weight.ContainerCost = decimal.Parse(str);
                    if (objCell.Column.Key == "ContainerWeight")
                        weight.ContainerWeight = decimal.Parse(str);
                    if (objCell.Column.Key == "NItems") 
                    {
                        str = Regex.Match(str, @"(\d+)").ToString();
                        nItems = int.Parse(str);
                    }
                } catch(Exception)
                {
                    return;
                }
                if ((objCell.Column.Key == "FoodTypeID") || (objCell.Column.Key == "FoodTypeCost") || (objCell.Column.Key == "Weight")
                    || (objCell.Column.Key == "ContainerTypeID") || (objCell.Column.Key == "ContainerWeight")
                    || (objCell.Column.Key == "ContainerCost") || (objCell.Column.Key == "NItems"))
                {
                    
                    objCell.Row.Cells["WasteCost"].SetValue(weight.WasteCost * nItems, true);
                }
            }
        }

        

        public void SaveConfig()
        {
            SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = UserControls.VWAPath.ViewWasteConfigPath;
            dlg.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.gridViewWaste.DisplayLayout.SaveAsXml(dlg.FileName);
            }
        }

        #region ShowCustomColumnChooserDialog

        // CustomColumnChooser is defined in this project in CustomColumnChooser.cs file.
        private CustomColumnChooser customColumnChooserDialog = null;

        public void ShowCustomColumnChooserDialog()
        {
            if (null == this.customColumnChooserDialog || this.customColumnChooserDialog.IsDisposed)
            {
                this.customColumnChooserDialog = new CustomColumnChooser();
                this.customColumnChooserDialog.Grid = this.gridViewWaste;
            }

            this.customColumnChooserDialog.Show();
        }

        #endregion // ShowCustomColumnChooserDialog

        private string PerformTranslation(String sInfraCondition) 
        { 
            return sInfraCondition; 
        } 

        public string GetFilters() 
        {
            String sFilter = String.Empty; 
            try { 
                foreach (ColumnFilter colFil in this.gridViewWaste.Rows.ColumnFilters) 
                {
                    foreach (FilterCondition filCondition in colFil.FilterConditions)
                    {
                        if (sFilter != String.Empty)
                            sFilter = sFilter + " AND " + PerformTranslation(filCondition.ToString()) + " ";
                        else
                            sFilter = PerformTranslation(filCondition.ToString()) + " ";
                    }
                }
            } 
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); 
            }
            
            return sFilter;
        }

        private string GetSorting() 
        {   
            String sSort = String.Empty; 
            try 
            {
                foreach (UltraGridColumn ultCol in gridViewWaste.DisplayLayout.Bands["Weights"].SortedColumns)
                {
                    if (sSort != String.Empty)
                        sSort = sSort + ",";
                   if (ultCol.SortIndicator == SortIndicator.Ascending)
                        sSort = sSort + ultCol.Key;
                    else
                        sSort = sSort + ultCol.Key + " desc ";
                    
                }
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
            return sSort;
        } 

        public string GetFiltersString()
        {
            String sFilter = this.GetFilters();
            if (sFilter.Equals(""))
                sFilter = "None";
            return sFilter;
        }

        public delegate void FilterChangedEventHandler(object sender, EventArgs e);
        private FilterChangedEventHandler filterChanged;
        public event FilterChangedEventHandler FilterChanged
        {
            add { filterChanged += value; }
            remove { filterChanged -= value; }
        }
        public void SetFilterChanged()
        {
            OnFilterChanged(EventArgs.Empty);
        }
        protected virtual void OnFilterChanged(EventArgs e)
        {
            if (filterChanged != null)
                filterChanged(this, e);
        }

        private void gridViewWaste_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {
            if (sender != null)
                filterChanged(this, e);
        }

        private void gridViewWaste_BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            Infragistics.Win.ValueListSortStyle sortStyle = Infragistics.Win.ValueListSortStyle.None;   
            switch (e.Column.SortIndicator)   
            {   
                case SortIndicator.Ascending:  
                    sortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue;  
                    break;       
                case SortIndicator.Descending:  
                    sortStyle = Infragistics.Win.ValueListSortStyle.DescendingByValue;  
                    break;  
            }  
            e.ValueList.SortStyle = sortStyle;
        }

        private PreviewSettings _Settings;
        private void gridViewWaste_InitializePrint(object sender, CancelablePrintEventArgs e)
        {
            SetupPrint(e);
        }
        
        public void PrintGrid()
        {
            frmPrintProperties frm = new frmPrintProperties("Waste");
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._Settings = frm.PreviewSettings;

                // To print using an UltraGridPrintDocument, associate a grid with the
                // document instance. This can be done at design time as well.
                this.ultraGridPrintDocument1.Grid = this.gridViewWaste;

                // To show print preivew using the UltraPrintPreviewDialog, associate
                // a print document with the dialog. This can be done at design time
                // as well.
                if (_Settings.IncludeFilter && (GetFilters().Trim() != ""))
                {
                    this.ultraGridPrintDocument1.Footer.BorderStyle = UIElementBorderStyle.None;
                    this.ultraGridPrintDocument1.Footer.Height = 30;
                    this.ultraGridPrintDocument1.Footer.Appearance.FontData.SizeInPoints = 6;
                    this.ultraGridPrintDocument1.Footer.TextLeft = "Filter Used: " + GetFilters();
                    this.ultraGridPrintDocument1.Footer.Appearance.TextVAlign = VAlign.Bottom;
                }
                this.ultraPrintPreviewDlg.Document = this.ultraGridPrintDocument1;

                // Call ShowDialog to show the print preview dialog.
                this.ultraPrintPreviewDlg.ShowDialog(this);
            }
        }

        private void ultraPrintPreviewDlg_Load(object sender, EventArgs e)
        {
            try
            {
                this.ultraPrintPreviewDlg.Document.DocumentName = _Settings.Title;
                this.ultraPrintPreviewDlg.Text = "Print Preview " + _Settings.Title;
            }
            catch { }
        }

        private void ultraPrintPreviewDlg_Printed(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Document was successfully printed. Do you want to close Print Preview " + _Settings.Title + " window?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == result)
                this.ultraPrintPreviewDlg.Close();
        }

        private void SetupPrint(Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
        {
            //set the previewinfo values based on the values selected in
            // the controls on the form
            try
            {
                e.DefaultLogicalPageLayoutInfo.FitWidthToPages = _Settings.FitToPages;

                //				e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image = 
                if (_Settings.IncludeImage)
                {
                    e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image =
                        Image.FromFile(VWAPath.ViewWasteBackgroundImage);
                    e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageHAlign = HAlign.Left;
                }

                e.DefaultLogicalPageLayoutInfo.PageHeader = _Settings.Title;
                
                if (_Settings.AllPages)
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages;
                else if (_Settings.CurrentPage)
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.CurrentPage;
                else
                {
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.SomePages;
                    e.PrintDocument.PrinterSettings.FromPage = _Settings.PagesFrom * Math.Max(_Settings.FitToPages, 1) - 1;
                    e.PrintDocument.PrinterSettings.ToPage = _Settings.PagesTo * Math.Max(_Settings.FitToPages, 1);
                }
            }
            catch
            {
                e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages;
            }
            
            // hide row selector column
            e.PrintLayout.Bands["Weights"].Override.RowSelectors = DefaultableBoolean.False;
            // activate key fields for editing to apply the same style for all columns
            e.PrintLayout.Bands["Weights"].Columns["ID"].CellActivation = Activation.AllowEdit;
            e.PrintLayout.Bands["Weights"].Columns["TransKey"].CellActivation = Activation.AllowEdit;
            e.PrintLayout.Bands["Weights"].Columns["WasteCost"].CellActivation = Activation.AllowEdit;
            // --------------------------------------------------------------------------------

            // Print settings
            // --------------------------------------------------------------------------------

            e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign =
                Infragistics.Win.HAlign.Center;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 20;

            //For Columns to be not get clipped
            e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.No;
            e.DefaultLogicalPageLayoutInfo.ColumnClipMode = ColumnClipMode.RepeatClippedColumns;
            e.PrintLayout.Override.RowSizing = RowSizing.Free;

            // Following code takes a lot of time - it resizes cells with scrolling to display their content on the page
            //foreach (UltraGridRow row in e.PrintLayout.Rows)
            //    row.PerformAutoSize();

            // Use <#> token in the string to designate page numbers.
            e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>.";
            e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40;
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right;
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True;
            e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid;
        }
    }
}