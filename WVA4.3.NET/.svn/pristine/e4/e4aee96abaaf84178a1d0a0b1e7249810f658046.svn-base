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
    public partial class UCTrackerViewer : UserControl
    {
        private string _currTerminal, _currType, _currID;
        private string[] _TrackerTypes = { "Container", "Food", "Loss", "PaperUI", "UserQuestion", "User", "Station", "Disposition", "Daypart", "BEO", "PrePost" };

        public UCTrackerViewer()
        {
            InitializeComponent();
        }
        
        private int CalculateLevel(DataTable v_DataTable)
        {

            int highestLevel = 0;

            // pass all rows in DataTable 
            foreach (DataRow thisRow in v_DataTable.Rows)
            {
                int intLevel = 0;
                // recursively look up the tree and count the levels 
                int parentID = int.Parse(thisRow["ParentMenuID"].ToString());
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
                        //MessageBox.Show("No Parent Found for " + parentID.ToString());
                        parentID = 0;
                    }
                    else
                    {
                        parentID = int.Parse(parentRow["ParentMenuID"].ToString());
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
                    Keys[0] = levelDataTable.Columns["MenuID"];
                    levelDataTable.PrimaryKey = Keys;

                    // add table to DataSet 
                    hierarchicalDataSet.Tables.Add(levelDataTable);
                    ///////////////////////// Add leaves  ////////////////////////////////////////////////
                    DataTable detailsDataTable = new DataTable();
                    detailsDataTable = subDataTable.Clone();
                    detailsDataTable.TableName = "Menu" + intLevel.ToString();
                    string cats = "";
                    foreach (DataRow dataRow in levelDataRows)
                    {
                        if (cats == "")
                            cats = "MenuID=" + dataRow.ItemArray[0];
                        else
                            cats += "OR MenuID=" + dataRow.ItemArray[0];
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
                    
                    detailsDataTable.AcceptChanges();

                    hierarchicalDataSet.Tables.Add(detailsDataTable);
					if(levelDataTable.Rows.Count > 0)
						hierarchicalDataSet.Relations.Add("Menu" + intLevel, levelDataTable.Columns["MenuID"], detailsDataTable.Columns["MenuID"]);
                    ///////////////////////// End Add leaves  ////////////////////////////////////////////////
                    // if this is >= level 1 then create and add relationship 
                    if (intLevel >= 1)
                    {
                        int intParentLevel = intLevel - 1;
                        string strThisLevel = "Level" + intLevel.ToString();
                        string strParentLevel = "Level" + intParentLevel.ToString();
                        DataRelation relLevel = new DataRelation(strThisLevel, hierarchicalDataSet.Tables[strParentLevel].Columns["MenuID"],
                            hierarchicalDataSet.Tables[strThisLevel].Columns["ParentMenuID"]);
                        hierarchicalDataSet.Relations.Add(relLevel);
                    }

                }
            }

            return hierarchicalDataSet;
        }

        private DataSet ContainerDataSet, FoodDataSet, LossDataSet, PaperUIDataSet, UserQuestionDataSet, UserDataSet,
			StationDataSet, DispositionDataSet, DaypartDataSet, BEODataSet, PrePostDataSet;
        private DataSet this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Container":
                        return ContainerDataSet;
                    case "Food":
                        return FoodDataSet;
                    case "Loss":
                        return LossDataSet;
                    case "PaperUI":
                        return PaperUIDataSet;
                    case "UserQuestion":
                        return UserQuestionDataSet;
                    case "User":
                        return UserDataSet;
					case "Station":
                        return StationDataSet;
					case "Disposition":
                        return DispositionDataSet;
					case "Daypart":
                        return DaypartDataSet;
					case "BEO":
						return BEODataSet;
					case "PrePost":
						return PrePostDataSet;
                    default:
                        return null;
                }
            }
            set
            {
                switch (name)
                {
                    case "Container":
                        ContainerDataSet = value;
                        break;
                    case "Food":
                        FoodDataSet = value;
                        break;
                    case "Loss":
                        LossDataSet = value;
                        break;
                    case "PaperUI":
                        PaperUIDataSet = value;
                        break;
                    case "UserQuestion":
                        UserQuestionDataSet = value;
                        break;
                    case "User":
                        UserDataSet = value;
                        break;
					case "Station":
						StationDataSet = value;
						break;
					case "Disposition":
						DispositionDataSet = value;
						break;
					case "Daypart":
						DaypartDataSet = value;
						break;
					case "BEO":
						BEODataSet = value;
						break;
					case "PrePost":
						PrePostDataSet = value;
						break;
                    default:
                        break;
                }
            }
        }
        private DataSet _HierarchicalDataSet = null;
        public void LoadTree(string name)
        {
			string nametransform = name;
			//switch (name.ToLower())
			//{
			//    case "userquestion":
			//        nametransform = "Question";
			//        break;
			//    case "station":
			//        nametransform = "Question";
			//        break;
			//    case "disposition":
			//        nametransform = "Question";
			//        break;
			//    case "daypart":
			//        nametransform = "Question";
			//        break;
			//    case "beo":
			//        nametransform = "Question";
			//        break;
			//    case "prepost":
			//        nametransform = "Question";
			//        break;
			//}
			ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            ultraGrid1.UpdateData();
            if (VWA4Common.VWACommon.NotNullOrEmpty(name))
            {
                _currType = name; //remember what radiobutton was checked
                _HierarchicalDataSet = null;
                _HierarchicalDataSet = this[name];

                if (_HierarchicalDataSet == null)
                {
					string buttonType = "", menuType = "", leftjoin = "", select = "";
					string typeCatalog = "0";
					switch (name.ToLower())
					{
						case "food":
							typeCatalog = VWA4Common.VWADBUtils.TypeCatalog(_currTerminal).ItemData;
							if (typeCatalog == "0")
							{
								leftjoin = " LEFT JOIN " + name + "Type ON Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID ";
								select = ", Cost";
							}
							else
							{
								leftjoin = " LEFT JOIN " + name + "SubTypes " +
									" ON Tracker" + name + "Buttons.TypeID = " + name + "SubTypes.TypeID ";
								select = ", FoodCost AS Cost";
								buttonType = " AND " + name + "SubTypes.TypeCatalogID = " + typeCatalog + " ";
							}
							break;
						case "container":
							typeCatalog = VWA4Common.VWADBUtils.TypeCatalog(_currTerminal).ItemData;
							if (typeCatalog == "0")
							{
								leftjoin = " LEFT JOIN " + name + "Type ON Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID ";
								select = ", TareWeight, Cost";
							}
							else
							{
								leftjoin = " LEFT JOIN " + name + "SubTypes " +
									" ON Tracker" + name + "Buttons.TypeID = " + name + "SubTypes.TypeID ";
								select = ", ContainerTareWeight AS TareWeight, ContainerCost AS Cost";
								buttonType = " AND " + name + "SubTypes.TypeCatalogID = " + typeCatalog + " ";
							}
							break;
						case "userquestion":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 6";
                            menuType = " AND (TrackerQuestionMenus.MenuType = 6 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						case "station":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 1";
							menuType = " AND (TrackerQuestionMenus.MenuType = 1 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						case "disposition":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 2";
                            menuType = " AND (TrackerQuestionMenus.MenuType = 2 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						case "daypart":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 3";
                            menuType = " AND (TrackerQuestionMenus.MenuType = 3 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						case "beo":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 4";
                            menuType = " AND (TrackerQuestionMenus.MenuType = 4 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						case "prepost":
							buttonType = " AND TrackerQuestionButtons.ButtonType = 5";
                            menuType = " AND (TrackerQuestionMenus.MenuType = 5 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
					nametransform = "Question";
							break;
						default:
							buttonType = "";
							menuType = "";
							break;
					}
                    // create and populate original DataTable 
                    //Dataset to hold data
                    DataTable buttonDataTable = new DataTable();
                    DataTable menuDataTable = new DataTable();
					//Enabled field doesn't have any sense here
                    string sql = @"SELECT CInt(MenuID) as MenuID, CInt(ParentMenuID) as ParentMenuID, MenuName, SpanishMenuName FROM Tracker" +
						nametransform + "Menus " +
                        " WHERE TermID = '" + _currTerminal + "' " + menuType +
                        " ORDER BY Rank DESC, MenuName;";
                    menuDataTable = VWA4Common.DB.Retrieve(sql);

					sql = @"SELECT CInt(ButtonID) as ButtonID, CInt(MenuID) as MenuID, Tracker" + nametransform + "Buttons.TypeID, ButtonName, SpanishButtonName " +
						select + " FROM Tracker" + nametransform + "Buttons " + leftjoin +
                        " WHERE TermID = '" + _currTerminal +
						"' " + buttonType +
						" ORDER BY Tracker" + nametransform + "Buttons.Rank, ButtonName;";
                    buttonDataTable = VWA4Common.DB.Retrieve(sql);

                    DataColumn[] catkeys = new DataColumn[1];
                    catkeys[0] = menuDataTable.Columns["MenuID"];
                    menuDataTable.PrimaryKey = catkeys;
                    DataTable originalDataTable = menuDataTable;

                    // add "level" column to originalDataTable 
                    DataColumn levelColumn = new DataColumn("Level");
                    levelColumn.DataType = typeof(int);
                    originalDataTable.Columns.Add(levelColumn);

                    // calculate hierarchy level 
                    int highestLevel = CalculateLevel(originalDataTable);

                    // build Hierarchical DataSet 
                    _HierarchicalDataSet = CreateHierarchicalDataSet(originalDataTable, highestLevel, buttonDataTable);
                    this[_currType] = _HierarchicalDataSet;

                }
                // bind Hierarchical DataSet to Tree UltraGrid 
                ultraGrid1.DataSource = _HierarchicalDataSet;
				ultraGrid1.Text = "Select Tracker" + (_currType == "Food" ? VWA4Common.VWACommon.WasteProfile : _currType) + ":";
				ultraGrid1.Rows.ExpandAll(true);
                //ultraGrid1.Refresh();
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
            ContainerDataSet = FoodDataSet = LossDataSet = PaperUIDataSet = UserQuestionDataSet = UserDataSet =
                StationDataSet = DispositionDataSet = DaypartDataSet = BEODataSet = PrePostDataSet = null;
            InitTreeView(_currTerminal, _currType, _currID);
        }
        
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // set band properties 
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.CaptionAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            this.ultraGrid1.DisplayLayout.Override.FilterUIType = FilterUIType.HeaderIcons;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand aBand in e.Layout.Bands)
            {
                aBand.Columns["MenuID"].Hidden = true;
                if (!Regex.IsMatch(aBand.Key, "Menu"))
                {
                    aBand.Columns["ParentMenuID"].Hidden = true;
                    aBand.Columns["Level"].Hidden = true;
                    aBand.Columns["MenuID"].Hidden = true;
                    aBand.ColHeadersVisible = false;
                    aBand.Override.RowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    aBand.Override.RowAppearance.BackColor = Color.LightBlue;
                }
                else
                {
                    aBand.Columns["MenuID"].Hidden = true;
                    aBand.Columns["ButtonID"].Hidden = true;
                    aBand.Columns["TypeID"].Hidden = true;
                    aBand.Columns["SpanishButtonName"].Hidden = true;
                    aBand.Columns["ButtonName"].Header.Caption = "Button";
                    aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in aBand.Columns)
                        col.CellActivation = Activation.ActivateOnly;
                    aBand.Override.RowAppearance.ForeColorDisabled = Color.Black;
					if (aBand.Columns.Exists("TareWeight"))
						aBand.Columns["TareWeight"].Width = 30;
                }
            }

            // set other layout properties 
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.CellAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.RowAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;
            //if (VWA4Common.VWACommon.IsAllowEditVersion())
            //    this.ultraGrid1.AllowDrop = true;
        }
        // show expanded rows
        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            // attempt to turn off expansion indicator 
            if (e.Row.Cells.Exists("ParentMenuID") && e.Row.Cells["ParentMenuID"].Value.ToString() == "0")
                e.Row.Expanded = true;
        }

        private string GetButtonID()
        {
            return GetTrackerViewerCell("ButtonID");
        }
        private string GetButtonName()
        {
            return GetTrackerViewerCell("ButtonName");
        }
		private string GetTypeID()
		{
			return GetTrackerViewerCell("TypeID");
		}

        private string GetTrackerViewerCell(string cellName)
        {
            if (this.ultraGrid1.ActiveRow != null)
                if (Regex.IsMatch(this.ultraGrid1.ActiveRow.Band.Key, "Menu") && this.ultraGrid1.ActiveRow.Band.Columns.Exists(cellName))
                    return this.ultraGrid1.ActiveRow.Cells[cellName].Value.ToString();
            return "";
        }
		public double Cost
		{
			get 
			{
				double res = 0;
				double.TryParse(GetTrackerViewerCell("Cost"), out res);
				return res;
			}
		}
		public double TareWeight
		{
			get
			{
				double res = 0;
				double.TryParse(GetTrackerViewerCell("TareWeight"), out res);
				return res;
			}
		}
        public void InitTreeView(string termID, string type, string id)
        {
            bool reload = false, idchanged = false;
            if (_currTerminal != termID)
            {
                _currTerminal = termID;
                UnloadTree();
                ContainerDataSet = FoodDataSet = LossDataSet = PaperUIDataSet = UserQuestionDataSet = UserDataSet =
                    StationDataSet = DispositionDataSet = DaypartDataSet = BEODataSet = PrePostDataSet = null;
                reload = true;
            }
            if (_currType != type.Trim())
            {
                _currType = type.Trim();
                reload = true;
            }
            if (_currID != id.Trim())
            {
                _currID = id.Trim();
                idchanged = true;
            }

            if (reload || this[_currType] == null)
                LoadTree(_currType);
            if (reload || idchanged)//seek in the current tree
				SetButtonID(_currID);
        }
        private bool SetButtonID(string id)
        {
            if (ultraGrid1.Rows.Count > 0)
                if (id != null && id != "")
                {
                    foreach (UltraGridRow row in ultraGrid1.Rows)
                        if (row.ChildBands == null)
                        {
                            if (row.Cells["ButtonID"].Value.ToString() == id)
                            {
                                row.Activate();
                                return true;
                            }
                        }
                        else
                            foreach (UltraGridChildBand band in row.ChildBands)
                                if (FindButtonID(band, id))
                                    return true;
                }
			return false;
        }
        private bool FindButtonID(UltraGridChildBand band, string id)
        {
            if (band.Rows.Count > 0)
                foreach (UltraGridRow row in band.Rows)
                    if (row.ChildBands == null)
                    {
                        if (row.Cells["ButtonID"].Value.ToString() == id)
                        {
                            row.Activate();
                            return true;
                        }
                    }
                    else
                        foreach (UltraGridChildBand childband in row.ChildBands)
                            if (FindButtonID(childband, id))
                                return true;
            return false;
        }

		private bool SetTypeID(string typeID)
		{
			if (ultraGrid1.Rows.Count > 0)
				if (typeID != null && typeID != "")
				{
					foreach (UltraGridRow row in ultraGrid1.Rows)
						if (row.ChildBands == null)
						{
							if (row.Cells["TypeID"].Value.ToString() == typeID)
							{
								row.Activate();
								return true;
							}
						}
						else
							foreach (UltraGridChildBand band in row.ChildBands)
								if (FindTypeID(band, typeID))
									return true;
				}
			return false;
		}
		private bool FindTypeID(UltraGridChildBand band, string typeID)
		{
			if (band.Rows.Count > 0)
				foreach (UltraGridRow row in band.Rows)
					if (row.ChildBands == null)
					{
						if (row.Cells["TypeID"].Value.ToString() == typeID)
						{
							row.Activate();
							return true;
						}
					}
					else
						foreach (UltraGridChildBand childband in row.ChildBands)
							if (FindTypeID(childband, typeID))
								return true;
			return false;
		}

        public string ID
        {
            get { return GetButtonID(); }
            set
            {
                if (_currID != value)
                {
					if (value != "" && !SetButtonID(value))
						MessageBox.Show("Can't find such button");
                }
				if (value == "")
                    ultraGrid1.ActiveRow = null;
				_currID = value;
            }
        }
		public string TypeID
		{
			get { return GetTypeID(); }
			set
			{
				if (GetTypeID() != value)
				{
					if (value != "" && !SetTypeID(value))
						MessageBox.Show("Can't find such button");
				}
			}
		}

        public string TermID
        {
            set
            {
                if (value != _currTerminal)
                {
                    _currTerminal = value;
                    UnloadTree();
                    ContainerDataSet = FoodDataSet = LossDataSet = PaperUIDataSet = UserQuestionDataSet = UserDataSet =
                        StationDataSet = DispositionDataSet = DaypartDataSet = BEODataSet = PrePostDataSet = null;
                    LoadTree(_currType);
                }
            }
            get { return _currTerminal; }
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
        
        public string ButtonName
        {
            get { return GetTrackerViewerCell("ButtonName"); }
        }
        
        private void ultraGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender != null)
                SetTrackerButtonChanged();
        }

        public class TrackerViewerEventArgs : EventArgs
        {
            private string _ID;
            private string _Name;
            private string _TermID;
			private string _MenuID;
			private string _TypeID;

            public string MenuID
            {
                get { return _MenuID; }
                set { _MenuID = value; }
            }
            public string TermID
            {
                get { return _TermID; }
                set { _TermID = value; }
            }
			public string ID
			{
				get { return _ID; }
				set { _ID = value; }
			}
			public string TypeID
			{
				get { return _TypeID; }
				set { _TypeID = value; }
			}
			public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            public TrackerViewerEventArgs(string id)
                : this(id, "", "0", "0", "")
            {
            }
            public TrackerViewerEventArgs(string id, string name, string term, string menuID, string TypeID)
            {
                _ID = id;
                _Name = name;
                _TermID = term;
                _MenuID = menuID;
				_TypeID = TypeID;
            }
        }
        public delegate void TrackerButtonChangedEventHandler(object sender, TrackerViewerEventArgs e);
        private TrackerButtonChangedEventHandler trackerButtonChanged;
        public event TrackerButtonChangedEventHandler TrackerButtonChanged
        {
            add { trackerButtonChanged += value; }
            remove { trackerButtonChanged -= value; }
        }
        public void SetTrackerButtonChanged()
        {
            string id = GetButtonID();
            if (id == "")
                SetTrackerButtonNotChosen();
			else if (id != _currID)
			{
				OnTrackerButtonChanged(new TrackerViewerEventArgs(id, GetButtonName(), _currTerminal, GetTrackerViewerCell("MenuID"), GetTypeID()));
				_currID = id;
			}
        }
        protected virtual void OnTrackerButtonChanged(TrackerViewerEventArgs e)
        {
            if (trackerButtonChanged != null)
                trackerButtonChanged(this, e);
        }

        public delegate void TrackerButtonNotChosenEventHandler(object sender, EventArgs e);
        private TrackerButtonNotChosenEventHandler trackerButtonNotChosen;
        public event TrackerButtonNotChosenEventHandler TrackerButtonNotChosen
        {
            add { trackerButtonNotChosen += value; }
            remove { trackerButtonNotChosen -= value; }
        }
        public void SetTrackerButtonNotChosen()
        {
            OnTrackerButtonNotChosen(EventArgs.Empty);
        }
        protected virtual void OnTrackerButtonNotChosen(EventArgs e)
        {
            if (trackerButtonNotChosen != null)
                trackerButtonNotChosen(this, e);
        }

        private void ultraGrid1_AfterCellActivate(object sender, EventArgs e)
        {
            SetTrackerButtonChanged();           
        }
        //public void SaveTree()
        //{
        //    ultraGrid1.Update();
        //    foreach (DataTable table in _HierarchicalDataSet.Tables)
        //        if (Regex.IsMatch(table.TableName, "Type"))
        //            foreach (DataRow row in table.Rows)
        //                if (row.RowState == DataRowState.Added)
        //                    VWA4Common.DB.Update("UPDATE BEOType SET CatID = " + row["CatID"] + " WHERE TypeID = '" + row["TypeID"] + "'");
        //}
        public string SelectedMenu()
        {
            string menuID = "0";
            if (ultraGrid1.Selected.Rows.Count > 0)
            {
                menuID = ultraGrid1.Selected.Rows[0].Cells["MenuID"].Value.ToString();
            }
            else //root by default
            {
                menuID = this._HierarchicalDataSet.Tables["Level0"].Rows[0]["MenuID"].ToString();
            }
            return menuID;
        }
        
        
        public delegate void TrackerViewerLeaveEventHandler(object sender, EventArgs e);
        private TrackerViewerLeaveEventHandler treeLeave;
        public event TrackerViewerLeaveEventHandler TrackerViewerLeave
        {
            add { treeLeave += value; }
            remove { treeLeave -= value; }
        }
        public void SetTrackerViewerLeave()
        {
            OnTrackerViewerLeave(EventArgs.Empty);
        }
        protected virtual void OnTrackerViewerLeave(EventArgs e)
        {
            if (treeLeave != null)
                treeLeave(this, e);
        }

        private void ultraGrid1_Leave(object sender, EventArgs e)
        {
            if (sender != null)
                SetTrackerViewerLeave();
        }

        public void Clear()
        {
            _currType = "";
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            this.ultraGrid1.Layouts.Clear();
        }
    }
}
