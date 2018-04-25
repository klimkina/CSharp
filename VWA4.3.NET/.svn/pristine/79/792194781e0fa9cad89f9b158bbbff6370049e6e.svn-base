using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace UserControls
{
    public partial class UCTreeView : UserControl
    {
        private string _currTypeCatalog, _currType, _currID;
        private string[] _ReportTypes = VWA4Common.VWACommon.ReportTypes;

        private bool _ShowCheckBox;
        private bool _ShowPrice = false;
        private bool _ShowDisabled = false;
        private bool _ShowBEONumber = true;

        public bool ShowBEONumber
        {
            get { return _ShowBEONumber; }
            set
            {
                if (_ShowBEONumber != value)
                {
                    _ShowBEONumber = value;
                    ReloadTree();
                }
            }
        }

        public bool ShowDisabled
        {
            get { return _ShowDisabled; }
            set 
            {
                if (_ShowDisabled != value)
                {
                    _ShowDisabled = value;
                    ReloadTree();
                }
            }
        }

        public UCTreeView(bool showCheckBox)
            : this(showCheckBox, false)
        { }

        public UCTreeView(bool showCheckBox, bool showNames)
        {
            InitializeComponent();
            _ShowCheckBox = showCheckBox;
            _ShowAllNames = showNames;
            _currTypeCatalog = "0"; //master by default
            _currType = ""; 
        }
        public UCTreeView()
            : this(false, false)
        { }
        private int CalculateLevel(DataTable v_DataTable)
        {

            int highestLevel = 0;

            // pass all rows in DataTable 
            foreach (DataRow thisRow in v_DataTable.Rows)
            {
                int intLevel = 0;
                // recursively look up the tree and count the levels 
                int parentID = int.Parse(thisRow["ParentCatID"].ToString());
                while (!(parentID == 0))
                {

                    // find parent 
                    DataRow parentRow;
                    object[] strFind = new object[1];
                    strFind[0] = parentID;
                    parentRow = v_DataTable.Rows.Find(strFind);

                    // set to look for parent or throw error if no parent found 
                    if (parentRow == null)
                    {
                        MessageBox.Show("No Parent Found for " + parentID.ToString());
                        parentID = 0;
                    }
                    else
                    {
                        parentID = int.Parse(parentRow["ParentCatID"].ToString());
                        intLevel = intLevel + 1;
                    }

                }

                // apply level to this row and set Highest Level 
                thisRow["Level"] = intLevel;
                if (intLevel > highestLevel)
                    highestLevel = intLevel;

            }
            // return Highest Level to caller 
            return highestLevel;

        }

        private DataSet CreateHierarchicalDataSet(DataTable v_DataTable, int v_highestLevel, DataTable subDataTable)
        {

            // declare a new DataSet 
            DataSet hierarchicalDataSet = new DataSet("HierarchicalDataSet");

            // pass DataTable for each hierarchical level 
            for (int intLevel = 0; intLevel <= v_highestLevel; intLevel++)
            {

                // pass DataTable and extract rows for this level 
                DataRow[] levelDataRows;
                levelDataRows = v_DataTable.Select("Level=" + intLevel.ToString());

                // test to see if any rows were selected 
                if ((levelDataRows != null))
                {

                    // create a new data table and add the rows and columns 
                    DataTable levelDataTable = new DataTable();
                    levelDataTable = v_DataTable.Clone();
                    levelDataTable.TableName = "Level" + intLevel.ToString();

                    foreach (DataRow dataRow in levelDataRows)
                    {

                        DataRow newDataRow = levelDataTable.NewRow();
                        foreach (DataColumn dataColumn in v_DataTable.Columns)
                        {
                            newDataRow[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                        }
                        levelDataTable.Rows.Add(newDataRow);
                    }

                    // create a primary key and add to the data table 
                    DataColumn[] Keys = new DataColumn[1];
                    Keys[0] = levelDataTable.Columns["CatID"];
                    levelDataTable.PrimaryKey = Keys;

                    // add table to DataSet 
                    hierarchicalDataSet.Tables.Add(levelDataTable);
                    ///////////////////////// Add leaves  ////////////////////////////////////////////////
                    DataTable detailsDataTable = new DataTable();
                    detailsDataTable = subDataTable.Clone();
                    detailsDataTable.TableName = "Type" + intLevel.ToString();
                    string cats = "";
                    foreach (DataRow dataRow in levelDataRows)
                    {
                        if (cats == "")
                            cats = "CatID=" + dataRow.ItemArray[0];
                        else
                            cats += "OR CatID=" + dataRow.ItemArray[0];
                    }
                    DataRow[] detailsDataRows;
                    detailsDataRows = subDataTable.Select(cats);
                    foreach (DataRow dataRow in detailsDataRows)
                    {

                        DataRow newDataRow = detailsDataTable.NewRow();
                        foreach (DataColumn dataColumn in subDataTable.Columns)
                        {
                            newDataRow[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                        }
                        detailsDataTable.Rows.Add(newDataRow);
                    }
                    detailsDataTable.Columns.Add(" ", typeof(bool));
                    detailsDataTable.AcceptChanges();

                    hierarchicalDataSet.Tables.Add(detailsDataTable);
                    hierarchicalDataSet.Relations.Add("Type" + intLevel, levelDataTable.Columns["CatID"], detailsDataTable.Columns["CatID"]);
                    ///////////////////////// End Add leaves  ////////////////////////////////////////////////
                    // if this is >= level 1 then create and add relationship 
                    if (intLevel >= 1)
                    {
                        int intParentLevel = intLevel - 1;
                        string strThisLevel = "Level" + intLevel.ToString();
                        string strParentLevel = "Level" + intParentLevel.ToString();
                        DataRelation relLevel = new DataRelation(strThisLevel, hierarchicalDataSet.Tables[strParentLevel].Columns["CatID"],
                            hierarchicalDataSet.Tables[strThisLevel].Columns["ParentCatID"]);
                        hierarchicalDataSet.Relations.Add(relLevel);
                    }

                }
            }

            return hierarchicalDataSet;
        }

        private DataSet StationDataSet, FoodDataSet, LossDataSet, DispositionDataSet, ContainerDataSet, DaypartDataSet, BEODataSet;
        private DataSet this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Station":
                        return StationDataSet;
                    case "Food":
                        return FoodDataSet;
                    case "Loss":
                        return LossDataSet;
                    case "Disposition":
                        return DispositionDataSet;
                    case "Container":
                        return ContainerDataSet;
                    case "Daypart":
                        return DaypartDataSet;
                    case "BEO":
                        return BEODataSet;
                    default:
                        return null;
                }
            }
            set
            {
                switch (name)
                {
                    case "Station":
                        StationDataSet = value;
                        break;
                    case "Food":
                        FoodDataSet = value;
                        break;
                    case "Loss":
                        LossDataSet = value;
                        break;
                    case "Disposition":
                        DispositionDataSet = value;
                        break;
                    case "Container":
                        ContainerDataSet = value;
                        break;
                    case "Daypart":
                        DaypartDataSet = value;
                        break;
                    case "BEO":
                        BEODataSet = value;
                        break;
                    default:
                        break;
                }
            }
        }
        private DataSet _HierarchicalDataSet = null;
        public void LoadTree(string name)
        {
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            ultraGrid1.UpdateData();
            if (VWA4Common.VWACommon.NotNullOrEmpty(name))
            {
                //translate incorrect names
                if(name == "DayPart")
                    name = "Daypart";
                if (name == "EO" || name == "EventOrder")
                    name = "BEO";

                _currType = name; //remember what radiobutton was checked
                _HierarchicalDataSet = null;
                _HierarchicalDataSet = this[name];
                if (_HierarchicalDataSet == null)
                {
                    // create and populate original DataTable 
                    //Dataset to hold data
                    DataTable typeDataTable = new DataTable();
                    DataTable catDataTable = new DataTable();

                    string price = "";
                    if ((name == "Food") || (name == "Container"))
                    {
                        if ((_currTypeCatalog == "0") || (_currTypeCatalog == ""))
                            price = ", Cost";
                        else
                            price = ", " + name + "Cost AS Cost";
                    }
                    
                    string sql = @"SELECT CInt(CatID) as CatID, CInt(ParentCatID) as ParentCatID, CatName, SpanishCatName FROM "
                        + name + "Category ORDER BY Rank DESC, CatName;";
                    catDataTable = VWA4Common.DB.Retrieve(sql);

                    if ((_currTypeCatalog == "0") || (_currTypeCatalog == ""))
                        sql = @"SELECT CInt(CatID) as CatID, TypeID, TypeName, SpanishTypeName, "
                            + "ReportTypeName " + price + (name == "BEO" ? ", BEONumber " : "") +
                            " FROM " + name + "Type" + (_ShowDisabled ? "" : " WHERE Enabled = true") +  " ORDER BY Rank, TypeName;";
                    else
                        sql = @"SELECT CInt(CatID) as CatID, " + name + "SubTypes.TypeID, TypeName, SpanishTypeName, "
                        + " ReportTypeName " + price + (name == "BEO" ? ", BEONumber " : "") +
                        " FROM " + name + "SubTypes "
                        + " INNER JOIN " + name + "Type ON " + name + "SubTypes.TypeID = " + name + "Type.TypeID"
                        + " WHERE TypeCatalogID = " + _currTypeCatalog
                        + (_ShowDisabled ? "" : " AND " + name + "SubTypes.Enabled = true") + " ORDER BY Rank, TypeName;";
                    typeDataTable = VWA4Common.DB.Retrieve(sql);

                    DataColumn[] catkeys = new DataColumn[1];
                    catkeys[0] = catDataTable.Columns["CatID"];
                    catDataTable.PrimaryKey = catkeys;
                    DataTable originalDataTable = catDataTable;

                    // add "level" column to originalDataTable 
                    DataColumn levelColumn = new DataColumn("Level");
                    levelColumn.DataType = typeof(int);
                    originalDataTable.Columns.Add(levelColumn);

                    // calculate hierarchy level 
                    int highestLevel = CalculateLevel(originalDataTable);

                    // build Hierarchical DataSet 
                    _HierarchicalDataSet = CreateHierarchicalDataSet(originalDataTable, highestLevel, typeDataTable);
                    this[name] = _HierarchicalDataSet;
                    
                }
                // bind Hierarchical DataSet to Tree UltraGrid 
                ultraGrid1.DataSource = _HierarchicalDataSet;
                ultraGrid1.Text = "Select " + name + " Type:";
            }
        }

        public void UnloadTree()
        {
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            ultraGrid1.UpdateData();
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            this.ultraGrid1.Layouts.Clear();
        }
        public void Reload()
        { 
            UnloadTree();
            StationDataSet = FoodDataSet = LossDataSet = DispositionDataSet = ContainerDataSet = DaypartDataSet = BEODataSet = null;
            InitTreeView(_currTypeCatalog, _currType, _currID);
        }
        VWAGridUtils.CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new VWAGridUtils.CheckBoxOnHeader_CreationFilter();
        private bool _ShowAllNames;

        public bool ShowAllNames
        {
            get { return _ShowAllNames; }
            set { _ShowAllNames = value; }
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ////////////////////////// ADD Checkboxes //////////////////////////////////

            // Tells the WinGrid to use your custom Creation Filter
            if (_ShowCheckBox)
                this.ultraGrid1.CreationFilter = aCheckBoxOnHeader_CreationFilter;
            
            ////////////////////////// END ADD Checkboxes //////////////////////////////
            // set band properties 
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.CaptionAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            this.ultraGrid1.DisplayLayout.Override.FilterUIType = FilterUIType.HeaderIcons;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand aBand in e.Layout.Bands)
            {
                aBand.Columns["CatID"].Hidden = true;
                if (!Regex.IsMatch(aBand.Key, "Type"))
                {
                    aBand.Columns["ParentCatID"].Hidden = true;
                    aBand.Columns["Level"].Hidden = true;
                    aBand.ColHeadersVisible = false;
                    aBand.Override.RowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    aBand.Override.RowAppearance.BackColor = Color.LightBlue;
                }
                else
                {
                    aBand.Columns["TypeID"].Hidden = true;
                    aBand.Columns["ReportTypeName"].Hidden = !_ShowAllNames;
                    aBand.Columns["SpanishTypeName"].Hidden = !_ShowAllNames;
                    aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
                    // enable checkbox column
                    aBand.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in aBand.Columns)
                        col.CellActivation = Activation.ActivateOnly;
                    aBand.Columns[" "].CellActivation = Activation.AllowEdit;
                    aBand.Override.RowAppearance.ForeColorDisabled = Color.Black;
                    if (!_ShowCheckBox)
                        aBand.Columns[" "].Hidden = true;
                    if (aBand.Columns.Exists("Cost"))
                    {
                        if (!_ShowPrice)
                            aBand.Columns["Cost"].Hidden = true;
                        else
                            aBand.Columns["Cost"].CellActivation = Activation.ActivateOnly;
                    }
                    if (aBand.Columns.Exists("BEONumber"))
                    {
                        if (!_ShowBEONumber)
                            aBand.Columns["BEONumber"].Hidden = true;
                        else
                        {
                            aBand.Columns["BEONumber"].CellActivation = Activation.ActivateOnly;
                            aBand.Columns["BEONumber"].Header.Caption = "EO Number";
                        }
                    }
                }
            }

            // set other layout properties 
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.CellAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.RowAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;
            if(VWA4Common.VWACommon.IsAllowEditVersion())
                this.ultraGrid1.AllowDrop = true;
        }
        // show expanded rows
        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            // attempt to turn off expansion indicator 
            if (e.Row.Cells.Exists("ParentCatID") && e.Row.Cells["ParentCatID"].Value.ToString() == "0")
                    e.Row.Expanded = true;
        }
        private void AddFilter(ref string oldFilter, string newFilter)
        {
            AddFilter(ref oldFilter, newFilter, " OR ");
        }
        private void AddFilter(ref string oldFilter, string newFilter, string expr)
        {
            if (oldFilter == "" || oldFilter == null)
            {
                if (newFilter != null && newFilter != "")
                    oldFilter = newFilter;
            }
            else
                if (newFilter != null && newFilter != "")
                    if (expr == " AND ")
                        oldFilter = "(" + oldFilter + ") " + expr + " (" + newFilter + ")";
                    else
                        oldFilter += expr + newFilter;

        }
        private void AddDisplayFilter(ref string oldFilter, string newFilter, string name)
        {
            if (oldFilter == "" || oldFilter == null)
            {
                if (newFilter != null && newFilter != "")
                    if (name == "BEO")
                        oldFilter = "Event Order" + "Type = " + newFilter;
                    else
                        oldFilter = name + "Type = " + newFilter;
            }
            else
                if (newFilter != null && newFilter != "")
                    oldFilter = oldFilter + ", " + newFilter;
        }
        private string GetDataSetFilters(DataSet data, string name, ref string strDisplayFilter)
        {
            string filter = "", displayFilter = "";
            if (data != null)
            {
                foreach (DataTable table in data.Tables)
                    if (table.Columns[" "] != null)//this is leaf
                        foreach (DataRow row in table.Rows)
                            if (row.ItemArray[row.ItemArray.Length - 1].ToString().ToLower() == "true")
                            {
                                AddFilter(ref filter, "Weights." + name + "TypeID = '" + row.ItemArray[1] + "'");
                                AddDisplayFilter(ref displayFilter, row.ItemArray[2].ToString(), name);
                            }
            }
            AddFilter(ref strDisplayFilter, displayFilter, " AND ");
            return filter;
        }
        public string GetTreeFilters()
        {
            return GetTreeFilters(_currType);
        }
        public string GetTreeFilters(string name)
        {
            string str = "";
            return GetTreeFilters(name, ref str);
        }
        public string GetTreeFilters(ref string strDisplayFilter)
        {
            return GetTreeFilters(_currType, ref strDisplayFilter);
        }
        public string GetTreeFilters(string name, ref string strDisplayFilter)
        {
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode); // to perform last changes
            return GetDataSetFilters(this[name], name, ref strDisplayFilter);
        }
        public string GetAllTreeFilters()
        {
            string str = "";
            return GetAllTreeFilters(ref str);
        }
        public string GetAllTreeFilters(ref string strDisplayFilter)
        {
            return GetAllTreeFilters(ref strDisplayFilter, "");
        }
        public string GetAllTreeFilters(string exclude)
        {
            string str = "";
            return GetAllTreeFilters(ref str, exclude);
        }
        public string GetAllTreeFilters(ref string strDisplayFilter, string exclude)
        {
            string filter = "";
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode); // to perform last changes
            foreach(string name in _ReportTypes)
                if(name != exclude)
                    AddFilter(ref filter, GetDataSetFilters(this[name], name, ref strDisplayFilter), " AND ");
            return filter;
        }

        private void SetDataSetFilters(string name, string filter)
        {
            List<string> nameFilter = VWA4Common.VWACommon.ExtractNameFilter(name, filter);
            
            LoadTree(name);
            DataSet data = this[name];

            if (data != null)
            {
                foreach (DataTable table in data.Tables)
                    if (table.Columns[" "] != null)//this is leaf
                        foreach (DataRow row in table.Rows)
                            row[" "] = nameFilter.IndexOf(row["TypeID"].ToString()) >= 0;
            }

        }
        public void SetTreeFilters(string filter)
        {
            string reportType = _currType;
            foreach (string name in _ReportTypes)
                SetDataSetFilters(name, filter);
            if(VWA4Common.VWACommon.NotNullOrEmpty(reportType))
                LoadTree(reportType);
            else
                UnloadTree();
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            this.ultraGrid1.Layouts.Clear();
        }
        
        private string GetTreeViewID()
        {
            return GetTreeViewCell("TypeID");
        }
        private string GetTreeViewName()
        {
            return GetTreeViewCell("TypeName");
        }
        private double GetTreeViewCost()
        {
            string cost = GetTreeViewCell("Cost");
            if (cost != "")
                return double.Parse(GetTreeViewCell("Cost"));
            else
                return 0;
        }
        private string GetTreeViewCell(string cellName)
        {
            if (this.ultraGrid1.ActiveRow != null)
                if (Regex.IsMatch(this.ultraGrid1.ActiveRow.Band.Key, "Type") && this.ultraGrid1.ActiveRow.Band.Columns.Exists(cellName))
                    return this.ultraGrid1.ActiveRow.Cells[cellName].Value.ToString();
            return "";
        }
        /// <summary>
        /// Primary initializer method for the TreeView user control.
        /// </summary>
        /// <param name="typeCatalog">"0" => Master ; or GlobalSettings.CurrentTypeCatalogID.ToString()</param>
		/// <param name="type">"Food" ; "Loss" ; "Container" ; "Station" ; "Disposition" ; "Daypart"</param>
        /// <param name="id">TypeID to select after initializing.</param>
		public void InitTreeView(string typeCatalog, string type, string id)
        {
            bool reload = false, idchanged = false;
            typeCatalog.Trim();
            if ((_currTypeCatalog == "0" || _currTypeCatalog == "") && (typeCatalog == "0" || typeCatalog == ""))
            { } //they are equal
            else if (_currTypeCatalog != typeCatalog)
            {
                _currTypeCatalog = typeCatalog;
                UnloadTree();
                StationDataSet = FoodDataSet = LossDataSet = DispositionDataSet = ContainerDataSet = DaypartDataSet = BEODataSet = null;
                reload = true;
            }
            if (_currType != type.Trim())
            {
                _currType = type.Trim();
                reload = true;
            }
            if(_currID != id.Trim())
            {
                _currID = id.Trim();
                idchanged = true;
            }
            
            if(reload || this[_currType] == null)
                LoadTree(_currType);
            if (reload || idchanged)//seek in the current tree
                    SetTreeViewID();
        }
        private void SetTreeViewID()
        {
            if (ultraGrid1.Rows.Count > 0)
                if (_currID != null && _currID != "")
                {
                    foreach (UltraGridRow row in ultraGrid1.Rows)
                        if (row.ChildBands == null)
                        {
                            if (row.Cells["TypeID"].Value.ToString() == _currID)
                            {
                                row.Activate();
                                return;
                            }
                        }
                        else
                            foreach (UltraGridChildBand band in row.ChildBands)
                                if (FindTreeViewID(band))
                                    return;
                }
                
        }
        private bool FindTreeViewID(UltraGridChildBand band)
        {
            if(band.Rows.Count > 0)
                foreach(UltraGridRow row in band.Rows)
                    if (row.ChildBands == null)
                    {
                        if (row.Cells["TypeID"].Value.ToString() == _currID)
                        {
                            row.Activate();
                            return true;
                        }
                    }
                    else
                        foreach (UltraGridChildBand childband in row.ChildBands)
                            if (FindTreeViewID(childband))
                                  return true;
            return false;
        }
        
        public string ID
        {
            get { return GetTreeViewID(); }
            set 
            {
                if (_currID != value)
                {
                    _currID = value;
                    SetTreeViewID();
                }
                if (_currID == "")
                    ultraGrid1.ActiveRow = null;
            }
        }
        public string TypeCatalogID
        {
            set
            {
                if ((_currTypeCatalog == "0" || _currTypeCatalog == "") && (value == "0" || value == ""))
                { } //they are equal
                else if (value != _currTypeCatalog)
                {
                    _currTypeCatalog = value;
                    ReloadTree();
                }
            }
            get { return _currTypeCatalog; }
        }
        public string TypeName
        {
            get { return _currType; }
            set
            {
                if (_currType != value || (this[_currType] == null))
                {
                    _currType = value;
                    LoadTree(_currType);
                }
            }
        }
        public double Cost
        {
            get { return GetTreeViewCost(); }
        }
        public string DisplayID
        {
            get { return GetTreeViewCell("TypeName"); }
        }
        public bool EnableCheckboxes
        {
            get { return _ShowCheckBox; }
            set { _ShowCheckBox = value; }
        }
        public void HideNames()
        {
            _ShowAllNames = false;
            if (ultraGrid1.DisplayLayout != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand aBand in ultraGrid1.DisplayLayout.Bands)
                {
                    if (Regex.IsMatch(aBand.Key, "Type"))
                    {
                        aBand.Columns["ReportTypeName"].Hidden = _ShowAllNames;
                        aBand.Columns["SpanishTypeName"].Hidden = _ShowAllNames;
                    }
                }
            }
        }
        public bool ShowPrice
        {
            get { return _ShowPrice; }
            set { _ShowPrice = value; }
        }
        private void ultraGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender != null)
                SetTreeViewIDChanged();
        }

        public class TreeViewEventArgs : EventArgs
        {
            private string _ID;
            private string _Name;
            private string _TypeCatalogID;
            private string _CatID;
            private double _Cost;

            public double Cost
            {
                get { return _Cost; }
                set { _Cost = value; }
            }

            public string CatID
            {
                get { return _CatID; }
                set { _CatID = value; }
            }
            public string TypeCatalogID
            {
                get { return _TypeCatalogID; }
                set { _TypeCatalogID = value; }
            }
            public string ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            public TreeViewEventArgs(string id)
                : this(id, "", "0", "0", 0)
            {
            }
            public TreeViewEventArgs(string id, string name, string typeCatalog, string catID, double cost)
            {
                _ID = id;
                _Name = name;
                _TypeCatalogID = typeCatalog;
                _CatID = catID;
                _Cost = cost;
            }
        }
        public delegate void TreeViewIDChangedEventHandler(object sender, TreeViewEventArgs e);
        private TreeViewIDChangedEventHandler treeViewIDChanged;
        public event TreeViewIDChangedEventHandler TreeViewIDChanged
        {
            add { treeViewIDChanged += value; }
            remove { treeViewIDChanged -= value; }
        }
        public void SetTreeViewIDChanged()
        {
            string id = GetTreeViewID();
            if (id == "")
                SetTreeViewIDNotChosen();
            else if (id != _currID)
            {
                OnTreeViewIDChanged(new TreeViewEventArgs(id, GetTreeViewName(), _currTypeCatalog, GetTreeViewCell("CatID"), GetTreeViewCost()));
                _currID = id;
            }
        }
        protected virtual void OnTreeViewIDChanged(TreeViewEventArgs e)
        {
            if (treeViewIDChanged != null)
                treeViewIDChanged(this, e);
        }

        public delegate void TreeViewIDNotChosenEventHandler(object sender, EventArgs e);
        private TreeViewIDNotChosenEventHandler treeViewIDNotChosen;
        public event TreeViewIDNotChosenEventHandler TreeViewIDNotChosen
        {
            add { treeViewIDNotChosen += value; }
            remove { treeViewIDNotChosen -= value; }
        }
        public void SetTreeViewIDNotChosen()
        {
            OnTreeViewIDNotChosen(EventArgs.Empty);
        }
        protected virtual void OnTreeViewIDNotChosen(EventArgs e)
        {
            if (treeViewIDNotChosen != null)
                treeViewIDNotChosen(this, e);
        }

        private void ultraGrid1_AfterCellActivate(object sender, EventArgs e)
        {
            if ((e as MouseEventArgs).Location.X < 284 && (e as MouseEventArgs).Location.X > 37)
            {
                SetTreeViewIDChanged();
                if (_ShowCheckBox && this.ultraGrid1.ActiveRow != null)
                {
                    if (Regex.IsMatch(this.ultraGrid1.ActiveRow.Band.Key, "Type"))
                        this.ultraGrid1.ActiveRow.Cells[" "].Value = this.ultraGrid1.ActiveRow.Cells[" "].Value.ToString() == "" || !(bool)this.ultraGrid1.ActiveRow.Cells[" "].Value;
                }
            }            
        }
        public void SaveTree()
        {
            ultraGrid1.Update();
            foreach (DataTable table in _HierarchicalDataSet.Tables)
                if (Regex.IsMatch(table.TableName, "Type"))
                    foreach (DataRow row in table.Rows)
                        if (row.RowState == DataRowState.Added)
                            VWA4Common.DB.Update("UPDATE BEOType SET CatID = " + row["CatID"] + " WHERE TypeID = '" + row["TypeID"] + "'");
        }
        public string SelectedCat()
        {
            string catID = "0";
            if (ultraGrid1.Selected.Rows.Count > 0)
            {
                catID = ultraGrid1.Selected.Rows[0].Cells["CatID"].Value.ToString();
            }
            else //root by default
            {
                catID = this._HierarchicalDataSet.Tables["Level0"].Rows[0]["CatID"].ToString();
            }
            return catID;
        }
        public void InsertDrag(DataRow row)
        {
            DataTable newDataTable;
            string catID = "0";
            if (ultraGrid1.Selected.Rows.Count > 0)
            {
                newDataTable = Regex.IsMatch(ultraGrid1.Selected.Rows[0].Band.Key, "Type") ? this._HierarchicalDataSet.Tables[ultraGrid1.Selected.Rows[0].Band.Key] :
                    this._HierarchicalDataSet.Tables["Type" + ultraGrid1.Selected.Rows[0].Cells["Level"].Value.ToString()];
                catID = ultraGrid1.Selected.Rows[0].Cells["CatID"].Value.ToString();
            }
            else //root by default
            {
                newDataTable = this._HierarchicalDataSet.Tables["Type0"];
                catID = this._HierarchicalDataSet.Tables["Level0"].Rows[0]["CatID"].ToString();
            }
            DataRow newDataRow = newDataTable.NewRow();
            foreach (DataColumn dataColumn in newDataTable.Columns) //init from input
            {
                if (dataColumn.ColumnName != " ")
                    newDataRow[dataColumn.ColumnName] = row[dataColumn.ColumnName];
            }
            newDataRow["CatID"] = catID;
            newDataTable.Rows.Add(newDataRow);
            
            //ultraGrid1.Selected.Rows.Clear();
            //UltraGridRow aRow = ultraGrid1.DisplayLayout.Bands["Type0"].AddNew();
            //foreach (UltraGridCell cell in aRow.Cells) //init from input
            //{
            //    if (cell.Column.Key != " ")
            //        cell.Value = row[cell.Column.Key];
            //}
            //aRow.Selected = true;
            //ultraGrid1.DoDragDrop(aRow, DragDropEffects.Move);
        }
        private void ultraGrid1_SelectionDrag(object sender, CancelEventArgs e)
        {
            ultraGrid1.DoDragDrop(ultraGrid1.Selected.Rows, DragDropEffects.Move);
        }

        private void ultraGrid1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            UltraGrid grid = sender as UltraGrid;
            // Get the position on the grid where the dragged row(s) are to be dropped.
            //get the grid coordinates of the row (the drop zone)
            UIElement uieOver = ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(ultraGrid1.PointToClient(new Point(e.X, e.Y)));

            //get the row that is the drop zone/or where the dragged row is to be dropped
            UltraGridRow ugrOver = uieOver.GetContext(typeof(UltraGridRow), true) as UltraGridRow;
            if (!Regex.IsMatch(ugrOver.Band.Key, "Type"))//parent row
                ugrOver.Expanded = true;

            Point pointInGridCoords = grid.PointToClient(new Point(e.X, e.Y));
            if (pointInGridCoords.Y < 20)
                // Scroll up.
                this.ultraGrid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp);
            else if (pointInGridCoords.Y > grid.Height - 20)
                // Scroll down.
                this.ultraGrid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown);
        }

        private void ultraGrid1_DragDrop(object sender, DragEventArgs e)
        {
            int dropIndex;

            // Get the position on the grid where the dragged row(s) are to be dropped.
            //get the grid coordinates of the row (the drop zone)
            UIElement uieOver = ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(ultraGrid1.PointToClient(new Point(e.X, e.Y)));

            //get the row that is the drop zone/or where the dragged row is to be dropped
            UltraGridRow ugrOver = uieOver.GetContext(typeof(UltraGridRow), true) as UltraGridRow;
            if (ugrOver != null)
            {
                dropIndex = ugrOver.Index;    //index/position of drop zone in grid
                string catID = ugrOver.Cells["CatID"].Value.ToString();
                //if it is leaf - get it's table, if it is level - get it's leaf table
                DataTable newDataTable = Regex.IsMatch(ugrOver.Band.Key, "Type") ? this._HierarchicalDataSet.Tables[ugrOver.Band.Key] : 
                    this._HierarchicalDataSet.Tables["Type" + ugrOver.Cells["Level"].Value.ToString()];
                //get the dragged row(s)which are to be dragged to another position in the grid
                SelectedRowsCollection SelRows = (SelectedRowsCollection)e.Data.GetData (typeof(SelectedRowsCollection)) as SelectedRowsCollection;
                //get the count of selected rows and drop each starting at the dropIndex
                for(int i = SelRows.Count -1; i >=0; i--) // go from bottom to delete rows from one table and insert to another
                {
                    UltraGridRow aRow = SelRows[i];
                    if(!aRow.Cells["CatID"].Value.ToString().Equals(catID))
                    {
                        DataRow newDataRow = newDataTable.NewRow();
                        foreach (DataColumn dataColumn in newDataTable.Columns)
                        {
                            newDataRow[dataColumn.ColumnName] = aRow.Cells[dataColumn.ColumnName].Value;
                        }
                        newDataRow["CatID"] = catID;
                        newDataTable.Rows.Add(newDataRow);
                        aRow.Delete(false);
                    }
                    else
                        //move the selected row(s) to the drop zone
                        ultraGrid1.Rows.Move(aRow, dropIndex);
                }
            }
        }
        public class TreeLeaveEventArgs : EventArgs
        {
            private string _TreeLeave;
            public string TreeFilter
            {
                get { return _TreeLeave; }
                set { _TreeLeave = value; }
            }
            public TreeLeaveEventArgs(string filter)
            {
                _TreeLeave = filter;
            }

        }
        public delegate void TreeLeaveEventHandler(object sender, TreeLeaveEventArgs e);
        private TreeLeaveEventHandler treeLeave;
        public event TreeLeaveEventHandler TreeLeave
        {
            add { treeLeave += value; }
            remove { treeLeave -= value; }
        }
        public void SetTreeLeave()
        {
            OnTreeLeave(new TreeLeaveEventArgs(GetAllTreeFilters()));
        }
        protected virtual void OnTreeLeave(TreeLeaveEventArgs e)
        {
            if (treeLeave != null)
                treeLeave(this, e);
        }

        private void ultraGrid1_Leave(object sender, EventArgs e)
        {
            if (sender != null)
                SetTreeLeave();
        }

        public void Clear()
        {
            _currType = "";
            if(_ShowCheckBox)
                foreach (string name in _ReportTypes)
                    SetDataSetFilters(name, "");
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            this.ultraGrid1.Layouts.Clear();
        }

        private void ReloadTree()
        {
            UnloadTree();
            StationDataSet = FoodDataSet = LossDataSet = DispositionDataSet = ContainerDataSet = DaypartDataSet = BEODataSet = null;
            LoadTree(_currType);
        }
    }
}
