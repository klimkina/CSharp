using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace UserControls
{
    public partial class UCConfigParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
		private string[] _SectionNames = { "Database Statistics", "Site Info", "Master Type Catalog", 
                                           "Sub Type Catalogs", 
                                           "Food Types", "Loss Types", "Container Types", "User Types", "Station Types", 
                                           "Disposition Types", "Daypart Types", "Event Order Types", 
                                           "Tracker Infos" };
        private string[] _ParamNames = { "Database Statistics", "Site Info", "Master Type Catalog", 
                                           "Sub Type Catalogs", 
                                           "Food Types", "Loss Types", "Container Types", "User Types", "Station Types", 
                                           "Disposition Types", "Daypart Types", "Event Order Types", 
                                           "Tracker Infos" };
        private string[] _ParamTypes = { "Boolean", "Boolean", "Boolean", 
                                           "String", 
                                           "Boolean", "Boolean", "Boolean", "Boolean", "Boolean", 
                                           "Boolean", "Boolean", "Boolean", 
                                           "String" };
        private string[] _DefaultValues = { "True", "True", "True", 
                                           "", 
                                           "True", "True", "True", "True", "True", 
                                           "True", "True", "True", 
                                           "" };
        private string[] _DisplayValues = { "True", "True", "True", 
                                           "", 
                                           "True", "True", "True", "True", "True", 
                                           "True", "True", "True", 
                                           "" };
        
        public UCConfigParameters()
        {
            InitializeComponent();
        }
       
		public void InitDefault()
        {
			LoadSettings();
			_ParamTable.Clear();
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
            }
        }
        public void HashLoad(Hashtable paramlist)
        {
			object[] strFind = new object[1];
            foreach (string name in _ParamNames)
            {
                ReportParameter param = (ReportParameter)paramlist[name];
                if (param != null)
                {
                    param = (ReportParameter)paramlist[name];
                    _ParamTable[name] = param;
                    if (name == "Sub Type Catalogs")
					{
                        foreach (DataRow row in _HierarchicalDataSet.Tables["SubTypeCatalogs"].Rows)
                        {
                            row[" "] = false;
                        }
                        if (param.ParamValue != "")
                        {
                            string[] strs = param.ParamValue.Split(',');
                            
                            foreach (string str in strs)
                            {
                                strFind[0] = str;
                                _HierarchicalDataSet.Tables["SubTypeCatalogs"].Rows.Find(strFind)[" "] = true;
                            }
                        }
                        else 
                        {
                            strFind[0] = name;
                            _HierarchicalDataSet.Tables["Level1"].Rows.Find(strFind)[" "] = false;
                        }
					}
                    else if (name == "Tracker Infos")
					{
                        foreach (DataRow row in _HierarchicalDataSet.Tables["Trackers"].Rows)
                        {
                            row[" "] = false;
                        }
                        if (param.ParamValue != "")
                        {
                            string[] strs = param.ParamValue.Split(',');
                            
                            foreach (string str in strs)
                            {
                                strFind[0] = str;
                                _HierarchicalDataSet.Tables["Trackers"].Rows.Find(strFind)[" "] = true;
                            }
                        }
                        else
                        {
                            strFind[0] = name;
                            _HierarchicalDataSet.Tables["Level1"].Rows.Find(strFind)[" "] = false;
                        }
					}
					else
					{
						strFind[0] = name;
						_HierarchicalDataSet.Tables["Level1"].Rows.Find(strFind)[" "] = bool.Parse(param.ParamValue);
					}
                }
            }
			_HierarchicalDataSet.AcceptChanges();
			ultraGrid1.Refresh();
        }
        public bool IsValid()
        {
			ultraGrid1.UpdateData();
			foreach (DataTable table in _HierarchicalDataSet.Tables)
				foreach (DataRow row in table.Rows)
					if (row[" "].ToString() != "" && (bool)row[" "])
						return true;
            return false;
        }
        public string GetValue(string name)
        {
			string res = "";
            switch (name)
            {
				case "Database Statistics":
				case "Site Info":
				case "Master Type Catalog":
				case "IsSubTypeCatalogs":
                case "Food Types":
				case "Loss Types":
				case "Container Types":
                case "User Types":
				case "Station Types":
				case "Disposition Types":
				case "Daypart Types":
				case "Event Order Types":
					object[] strFind = new object[1];
					strFind[0] = name;
					return _HierarchicalDataSet.Tables["Level1"].Rows.Find(strFind)[" "].ToString();
				case "Sub Type Catalogs":
					foreach (DataRow row in _HierarchicalDataSet.Tables["SubTypeCatalogs"].Rows)
					{
						if ((bool)row[" "])
						{
							res += (res == "" ? "" : ", ") + row["ID"];
						}
					}
					return res;
				case "Tracker Infos":
					foreach (DataRow row in _HierarchicalDataSet.Tables["Trackers"].Rows)
					{
						if ((bool)row[" "])
						{
							res += (res == "" ? "" : ", ") + row["TermID"];
						}
					}
					return res;
                default:
                    return "";
            }
        }
        public void AddItem(ReportParameter param)
        {
            _ParamTable.Add(param.Name, param);
        }
        public void DeleteItem(string name)
        {
            _ParamTable.Remove(name);
        }
        public ReportParameter GetItem(string name)
        {
			string res = "", display = "";
            switch (name)
            {
				case "Database Statistics":
				case "Site Info":
				case "Master Type Catalog":
				case "IsSubTypeCatalogs":
                case "Food Types":
				case "Loss Types":
				case "Container Types":
                case "User Types":
				case "Station Types":
				case "Disposition Types":
				case "Daypart Types":
				case "Event Order Types":
					object[] strFind = new object[1];
					strFind[0] = name;
					res = _HierarchicalDataSet.Tables["Level1"].Rows.Find(strFind)[" "].ToString();
					return new ReportParameter(name, res, res, "Boolean");
				case "Sub Type Catalogs":
					foreach (DataRow row in _HierarchicalDataSet.Tables["SubTypeCatalogs"].Rows)
					{
						if (row[" "].ToString() != "" && (bool)row[" "])
						{
							res += (res == "" ? "" : ", ") + row["ID"];
							display += (display == "" ? "" : ", ") + row["TypeCatalogName"];
						}
					}
					return new ReportParameter(name, res, display, "String");
				case "Tracker Infos":
					foreach (DataRow row in _HierarchicalDataSet.Tables["Trackers"].Rows)
					{
						if (row[" "].ToString() != "" && (bool)row[" "])
						{
							res += (res == "" ? "" : ", ") + row["TermID"];
							display += (display == "" ? "" : ", ") + row["TermName"];
						}
					}
					return new ReportParameter(name, res, display, "String");
                default:
                    return null;
            }
        }

        private IDictionaryEnumerator _ParamTableEnum;
        public ReportParameter GetFirst()
        {
            _ParamTableEnum = _ParamTable.GetEnumerator();
            return ((ReportParameter)_ParamTableEnum.Current);
        }
        public ReportParameter GetNext()
        {
            if (_ParamTableEnum == null)
                _ParamTableEnum = _ParamTable.GetEnumerator();
            else
                _ParamTableEnum.MoveNext();
            return ((ReportParameter)_ParamTableEnum.Current);
        }
        public string GetNameList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.Name;
                else
                    res += ", " + param.Name;
            }
            return res;
        }
        public string GetValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.ParamValue;
                else
                    res += ", " + param.ParamValue;
            }
            return res;
        }
        public string GetDisplayValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.DisplayValue;
                else
                    res += ", " + param.DisplayValue;
            }
            return res;
        }
        private void SetValues()
        {
			ultraGrid1.UpdateData();
            foreach (string name in _ParamNames)
            {
                ReportParameter param = GetItem(name);
                if (param != null)
                    _ParamTable[name] = param;
            }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public Hashtable ParamList
        {
            get
            {
                SetValues();
                return _ParamTable;
            }
            set { this.HashLoad(value); }
        }
		private DataSet _HierarchicalDataSet = null;
		private void LoadSettings()
		{
			_HierarchicalDataSet = new DataSet("HierarchicalDataSet");
			DataTable level1 = new DataTable("Level1");
			level1.Columns.Add(" ", typeof(Boolean));
			level1.Columns.Add("Section", typeof(String));
			level1.Columns.Add("SectionID", typeof(int));
			int i = 0;
			foreach (string str in _SectionNames)
			{
				DataRow row = level1.NewRow();
				row[" "] = true;
				row["Section"] = str;
				row["SectionID"] = i++;
				level1.Rows.Add(row);
				
			}
			DataColumn[] Keys = new DataColumn[1];
			Keys[0] = level1.Columns["Section"];
			level1.PrimaryKey = Keys;

			_HierarchicalDataSet.Tables.Add(level1);
			_HierarchicalDataSet.Tables[0].TableName = "Level1";

			DataTable subTypeCatalogs = VWA4Common.DB.Retrieve("SELECT ID, TypeCatalogName, 3 AS SectionID FROM TypeCatalogs");
			subTypeCatalogs.Columns.Add(" ", typeof(Boolean));
			foreach (DataRow row in subTypeCatalogs.Rows)
				row[" "] = true;
			DataColumn[] Keys2 = new DataColumn[1];
			Keys2[0] = subTypeCatalogs.Columns["ID"];
			subTypeCatalogs.PrimaryKey = Keys2;

			_HierarchicalDataSet.Tables.Add(subTypeCatalogs);
			_HierarchicalDataSet.Relations.Add("SubTypeCatalogs", level1.Columns["SectionID"], subTypeCatalogs.Columns["SectionID"]);
			_HierarchicalDataSet.Tables[1].TableName = "SubTypeCatalogs";
			DataTable trackers = VWA4Common.DB.Retrieve("SELECT TermID, TermName, 12 AS SectionID FROM Terminals");
			trackers.Columns.Add(" ", typeof(Boolean));
			foreach (DataRow row in trackers.Rows)
				row[" "] = true;
			DataColumn[] Keys3 = new DataColumn[1];
			Keys3[0] = trackers.Columns["TermID"];
			trackers.PrimaryKey = Keys3;

			_HierarchicalDataSet.Tables.Add(trackers);
			_HierarchicalDataSet.Relations.Add("Trackers", level1.Columns["SectionID"], trackers.Columns["SectionID"]);
			_HierarchicalDataSet.Tables[2].TableName = "Trackers";

			ultraGrid1.DataSource = _HierarchicalDataSet;
		}

		VWAGridUtils.CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new VWAGridUtils.CheckBoxOnHeader_CreationFilter();
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			////////////////////////// ADD Checkboxes //////////////////////////////
			this.ultraGrid1.CreationFilter = aCheckBoxOnHeader_CreationFilter;

			// set band properties 
			this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
			this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGrid1.DisplayLayout.CaptionAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

			this.ultraGrid1.DisplayLayout.Override.FilterUIType = FilterUIType.HeaderIcons;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridBand aBand in e.Layout.Bands)
			{
				// enable checkbox column
				aBand.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
				foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in aBand.Columns)
					col.CellActivation = Activation.ActivateOnly;
				aBand.Columns[" "].CellActivation = Activation.AllowEdit;
				aBand.Override.RowAppearance.ForeColorDisabled = Color.Black;
				aBand.Columns[" "].Header.VisiblePosition = 0;
				aBand.ColHeadersVisible = false;

				if (aBand.Key == "Level1")
				{
				    aBand.Columns["SectionID"].Hidden = true;
					aBand.Override.RowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				    aBand.Override.RowAppearance.BackColor = Color.LightBlue;
					aBand.Override.ExpansionIndicator = ShowExpansionIndicator.Never;
					aBand.Columns["Section"].Width = 100;
				}
				else if(aBand.Key == "SubTypeCatalogs")
				{
					aBand.Columns["SectionID"].Hidden = true;
				    aBand.Columns["ID"].Hidden = true;
					//aBand.Columns["TypeCatalogName"].Header.Caption = "Sub Type Catalog Name";
				    aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
				
				}
				else if (aBand.Key == "Trackers")
				{
					aBand.Columns["SectionID"].Hidden = true;
					aBand.Columns["TermID"].Hidden = true;
					//aBand.Columns["TermName"].Header.Caption = "Terminal Name";
					aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
				}
			}

			// set other layout properties 
			e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			e.Layout.Override.CellAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
			e.Layout.Override.RowAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
			e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
		}

		private void ultraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			if (e.Row.Cells.Exists("Section") && (e.Row.Cells["Section"].Value.ToString() == "Sub Type Catalogs" ||
				e.Row.Cells["Section"].Value.ToString() == "Tracker Infos"))
				e.Row.Expanded = true;
		}

		private void ultraGrid1_CellChange(object sender, CellEventArgs e)
		{
			//   Use the BeforeEnterEditMode event to position the edit controls    
			UltraGridCell objCell = this.ultraGrid1.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 
			if (objCell.IsDataCell && objCell.Band.Key == "Level1") // change cost for weights
			{
				if (objCell.Column.Key == " ")
				{
					UltraGridChildBand band = null;
					if (objCell.Row.Cells["Section"].Value.ToString() == "Sub Type Catalogs")
						band = objCell.Row.ChildBands["SubTypeCatalogs"];
					else if(objCell.Row.Cells["Section"].Value.ToString() == "Tracker Infos")
						band = objCell.Row.ChildBands["Trackers"];
					if (band != null)
					{
						foreach (UltraGridRow row in band.Rows)
							row.Cells[" "].Value = !(bool)objCell.Value;
						ultraGrid1.UpdateData();
						ultraGrid1.Refresh();
					}
				}
			}
			
		}
    }
}
