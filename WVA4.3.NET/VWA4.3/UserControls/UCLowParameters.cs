using System;
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
    public partial class UCLowParameters : UserControl
    {
        private ARParameters param;
        public UCLowParameters()
        {
            InitializeComponent();

            this.panelHideParams.Visible = false;
            cbPalette.SelectedIndex = 0;
            cbDayOfWeek.SelectedIndex = VWA4Common.VWACommon.FirstDayOfWeek - DayOfWeek.Sunday; //mila: set to default first day of week
            endDate.Value = VWA4Common.VWACommon.LastDayOfWeek;
            startDate.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
            param = new ARParameters();

            currTypeCatalog = "0"; // Master by Default
            // create and populate original DataTable 
            //Dataset to hold data
            DataTable siteDataTable = new DataTable();

            string sql = @"SELECT ID, LicensedSite, TypeCatalogID FROM Sites WHERE Active = true;";
            
            siteDataTable = VWA4Common.DB.Retrieve(sql);
            cboSites.Items.Add(new VWA4Common.VWACommon.MyListBoxItem("Master", "0"));
            cboSites.SelectedIndex = 0;
            foreach (DataRow row in siteDataTable.Rows)
            {
                cboSites.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(), row.ItemArray[2].ToString()));
            }
            
        }
        bool IsComparision = false;
        public void SetComparision()
        {
            IsComparision = true;
            ShowComparision();
            HideBase();
            cbComparision.SelectedIndex = 0;
            dtStartWeek.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
            dtCompareWeek.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-14);
        }
        private void ShowComparision()
        {
            lblComparision.Visible = true;
            cbComparision.Visible = true;
            chkLbs.Visible = true;
            chkRecentWeek.Visible = true;
            cbCompareWeek.Visible = true;
            dtStartWeek.Visible = true;
            dtCompareWeek.Visible = true;
            groupBox1.Text = "Set Weeks to Compare";
        }
        private void HideComparision()
        {
            lblComparision.Visible = false;
            cbComparision.Visible = false;
            chkLbs.Visible = false;
            chkRecentWeek.Visible = false;
            cbCompareWeek.Visible = false;
            dtStartWeek.Visible = false;
            dtCompareWeek.Visible = false;
        }
        bool IsCrossTab = false;
        public void SetCrossTab()
        {
            IsCrossTab = true;
            //HideBase();
            HideComparision();
            ShowCrossTab();
            cbCrossTabReport.SelectedIndex = 0;
            cbCrossTabOn.SelectedIndex = 0;
            dtStartWeek.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
            dtCompareWeek.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-14);
        }
        private void ShowCrossTab()
        {
            label1.Location = new Point(3, 13);
            numShown.Location = new Point(145, 11);
            lblCrossTabReport.Visible = true;
            lblCrossTabOn.Visible = true;
            cbCrossTabReport.Visible = true;
            cbCrossTabOn.Visible = true;
            chkLbs.Visible = true;
        }
        private void HideCrossTab()
        {
            lblCrossTabReport.Visible = false;
            lblCrossTabOn.Visible = false;
            cbCrossTabReport.Visible = false;
            cbCrossTabOn.Visible = false;
            chkLbs.Visible = false;
        }
        private void HideBase()
        {
            label1.Visible = false;
            numShown.Visible = false;
            startDate.Visible = false;
            endDate.Visible = false;
        }
        bool IsEmployee = false;
        public void SetEmployee()
        {
            IsEmployee = true;
            HideBase();
            ShowEmployee();
            endDate.Visible = true;
            startDate.Visible = true;
            endDate.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
            startDate.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-14);
            radioEmployeeTrans.Checked = true;
        }
        private void ShowEmployee()
        {
            chkExceptionShow.Visible = true;
            lblEmployeeSort.Visible = true;
            radioEmployeeTrans.Visible = true;
            radioEmployeeWeight.Visible = true;
            panelEmployee.Visible = true;
        }
        private void HideEmployee()
        {
            chkExceptionShow.Visible = false;
            lblEmployeeSort.Visible = false;
            radioEmployeeTrans.Visible = false;
            radioEmployeeWeight.Visible = false;
            panelEmployee.Visible = false;
        }

        public class HideEventArgs : EventArgs
        {
            private int height;
            public int Height
            {
                get { return height; }
                set { height = value; }
            }
        }

        public delegate void HideEventHandler(object sender, HideEventArgs e);
        private HideEventHandler hideParams;
        public event HideEventHandler HideParams
        {
            add { hideParams += value; }
            remove { hideParams -= value; }
        }
        public void SetHide(int height)
        {
            HideEventArgs e = new HideEventArgs();
            e.Height = height;
            OnHide(e);
        }
        protected virtual void OnHide(HideEventArgs e)
        {
            if (hideParams != null)
                hideParams(this, e);
        }
        private bool shown = true;
        private void hideParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shown)
            {
                panelParams.Hide();
                panelHideParams.Show();
                popupShowHide.Items[0].Text = "Show Parameters";
                SetHide(16);
            }
            else
            {
                panelParams.Show();
                panelHideParams.Hide();
                popupShowHide.Items[0].Text = "Hide Parameters";
                SetHide(214);
            }
            shown = !shown;
        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = UserControls.VWAPath.ViewWasteImagesPath;
            dlg.Filter = "Bitmap Files (*.BMP)|*.bmp|" +
                            "JPEG (*.JPG; *.JPEG; *.JPE; *.JFIF)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                            "GIF (*.GIF)|*.gif|" +
                            "TIFF (*.TIF; *.TIFF)|*.tif;*.tiff|" +
                            "PNG (*.PNG)|*.png|" +
                            "ICO (*.ICO)|*.ico|" +
                            "All Picture Files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png;*.ico|" +
                            "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtLogo.Text = dlg.FileName;
            }
        }

        private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            VWA4Common.GlobalSettings.FirstDayOfWeek = (DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex).ToString();
        }

        public delegate void ViewReportEventHandler(object sender, EventArgs e);
        private ViewReportEventHandler viewReport;
        public event ViewReportEventHandler ViewReport
        {
            add { viewReport += value; }
            remove { viewReport -= value; }
        }
        public void SetViewReport()
        {
            OnViewReport(EventArgs.Empty);
        }
        protected virtual void OnViewReport(EventArgs e)
        {
            if (viewReport != null)
                viewReport(this, e);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if(CheckParams())
                if (sender != null)
                    SetViewReport();
        }

        public delegate void ExportPDFEventHandler(object sender, EventArgs e);
        private ExportPDFEventHandler exportPDF;
        public event ExportPDFEventHandler ExportPDF
        {
            add { exportPDF += value; }
            remove { exportPDF -= value; }
        }
        public void SetExportPDF()
        {
            OnExportPDF(EventArgs.Empty);
        }
        protected virtual void OnExportPDF(EventArgs e)
        {
            if (exportPDF != null)
                exportPDF(this, e);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportPDF();
        }
        private string strReportFilter = "", strDisplayReportFilter = "";
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string strTreeFilters, strDisplayFilters = "";
            strTreeFilters = GetTreeFilters(ref strDisplayFilters);
            ViewWaste frm = new ViewWaste();
            if (!IsComparision)
                frm.AddPeriodFilter(this.startDate.Value, this.endDate.Value);
            frm.AddFilter(strTreeFilters, strDisplayFilters);
            frm.Caption = "Filter Data for Low Participation Report";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                strReportFilter = frm.GetFilters();
                strDisplayReportFilter = frm.GetFiltersString();
                if (!IsComparision)
                {
                    DateTime _startDate = VWA4Common.VWACommon.GetFilterStartDate(strReportFilter);
                    DateTime _endDate = VWA4Common.VWACommon.GetFilterEndDate(strReportFilter);
                    if (_startDate != this.startDate.Value && _startDate != new DateTime(0))
                        this.startDate.Value = _startDate;
                    if (_endDate != this.endDate.Value)
                        this.endDate.Value = _endDate;
                }
                else //remove datetime filters
                {
                    strReportFilter = VWA4Common.VWACommon.RemoveFilterPeriod(strReportFilter);
                    strDisplayReportFilter = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(strDisplayReportFilter);
                }
            }
        }

        private void cboSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            VWA4Common.VWACommon.MyListBoxItem mli = (VWA4Common.VWACommon.MyListBoxItem)cboSites.SelectedItem;
            if (mli.ItemData != currTypeCatalog)
            {
                currTypeCatalog = mli.ItemData;
                UnloadTree();
                StationDataSet = FoodDataSet = LossDataSet = DispositionDataSet = DaypartDataSet = null;
                LoadTree(currReportType);
            }
        }

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

        private string currTypeCatalog;
        private string currReportType;
        private DataSet StationDataSet, FoodDataSet, LossDataSet, DispositionDataSet, DaypartDataSet, BEODataSet;
        private void LoadTree(string name)
        {
            currReportType = name; //remember what radiobutton was checked
            DataSet hierarchicalDataSet = null;
            switch(name)
            {
                case "Station":
                    hierarchicalDataSet = StationDataSet;
                    break;
                case "Food":
                    hierarchicalDataSet = FoodDataSet;
                    break;
                case "Loss":
                    hierarchicalDataSet = LossDataSet;
                    break;
                case "Disposition":
                    hierarchicalDataSet = DispositionDataSet;
                    break;
                case "Daypart":
                    hierarchicalDataSet = DaypartDataSet;
                    break;
                case "BEO":
                    hierarchicalDataSet = BEODataSet;
                    break;
            }
            if (hierarchicalDataSet == null)
            {
                // create and populate original DataTable 
                //Dataset to hold data
                DataTable typeDataTable = new DataTable();
                DataTable catDataTable = new DataTable();

                string sql = @"SELECT CInt(CatID) as CatID, CInt(ParentCatID) as ParentCatID, CatName, SpanishCatName FROM "
                    + name + "Category;";
                catDataTable = VWA4Common.DB.Retrieve(sql);

                if ((currTypeCatalog == "0") || (currTypeCatalog == ""))
                    sql = @"SELECT CInt(CatID) as CatID, TypeID, TypeName, SpanishTypeName, "
                    + "ReportTypeName FROM " + name + "Type;";
                else
                    sql = @"SELECT CInt(CatID) as CatID, " + name + "SubTypes.TypeID, TypeName, SpanishTypeName, "
                    + " ReportTypeName FROM " + name + "SubTypes "
                    + " INNER JOIN " + name + "Type ON " + name + "SubTypes.TypeID = " + name + "Type.TypeID"
                    + " WHERE TypeCatalogID = " + currTypeCatalog
                    + " AND " + name + "SubTypes.Enabled = true;";
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
                hierarchicalDataSet = CreateHierarchicalDataSet(originalDataTable, highestLevel, typeDataTable);
                switch (name)
                {
                    case "Station":
                        StationDataSet = hierarchicalDataSet;
                        break;
                    case "Food":
                        FoodDataSet = hierarchicalDataSet;
                        break;
                    case "Loss":
                        LossDataSet = hierarchicalDataSet;
                        break;
                    case "Disposition":
                        DispositionDataSet = hierarchicalDataSet;
                        break;
                    case "Daypart":
                        DaypartDataSet = hierarchicalDataSet;
                        break;
                    case "BEO":
                        BEODataSet = hierarchicalDataSet;
                        break;
                }
                
            }
            // bind Hierarchical DataSet to Tree UltraGrid 
            ultraGrid1.DataSource = hierarchicalDataSet;
            ultraGrid1.Text = "Select " + name + " Type:";
        }

        private void UnloadTree()
        {
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            //this.ultraGrid1.ResetDisplayLayout();
            this.ultraGrid1.Layouts.Clear();
        }
        /// <summary>
        /// Creation Filter - for checkboxes in the headers
        /// </summary>
        CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new CheckBoxOnHeader_CreationFilter();
        /*
		 This CreationFilter class will create a CheckBoxUIElement in each Column Header
		 whose DataType is boolean. It will fire the HeaderCheckBoxClicked event 
		 whenever the CheckBox is clicked.
		 Note that in order to maintain the CheckState, this CreationFilter uses the 
		 Tag proprty of the Header. So if the program uses the tag for something else
		 this will not work. 
		*/
		// Implements the CreationFilter interface		
        public class CheckBoxOnHeader_CreationFilter : IUIElementCreationFilter
        {
            // This event will fire when the CheckBox is clicked. 
            public delegate void HeaderCheckBoxClickedHandler(object sender, HeaderCheckBoxEventArgs e);
            public event HeaderCheckBoxClickedHandler _CLICKED;

            public CheckBoxOnHeader_CreationFilter()
            {
                _CLICKED += new HeaderCheckBoxClickedHandler(aCheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked);
            }

            private void aCheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked(object sender, CheckBoxOnHeader_CreationFilter.HeaderCheckBoxEventArgs e)
            {
                // Check to see if the column is of type boolean.  If it is, set all the cells in that column to
                // whatever value the header checkbox is.
                if (e.Header.Column.DataType == typeof(bool))
                {
                    foreach (UltraGridRow aRow in e.Rows)
                    {
                        aRow.Cells[e.Header.Column.Index].Value = (e.CurrentCheckState == CheckState.Checked);
                    }
                }
            }

            // EventArgs used for the HeaderCheckBoxClicked event. This event has to pass in the CheckState and the ColumnHeader
            #region HeaderCheckBoxEventArgs
            public class HeaderCheckBoxEventArgs : EventArgs
            {
                private Infragistics.Win.UltraWinGrid.ColumnHeader mvarColumnHeader;
                private CheckState mvarCheckState;
                private RowsCollection mvarRowsCollection;

                public HeaderCheckBoxEventArgs(Infragistics.Win.UltraWinGrid.ColumnHeader hdrColumnHeader, CheckState chkCheckState, RowsCollection Rows)
                {
                    mvarColumnHeader = hdrColumnHeader;
                    mvarCheckState = chkCheckState;
                    mvarRowsCollection = Rows;
                }

                // Expose the rows collection for the specific row island that the header belongs to
                public RowsCollection Rows
                {
                    get
                    {
                        return mvarRowsCollection;
                    }
                }

                public Infragistics.Win.UltraWinGrid.ColumnHeader Header
                {
                    get
                    {
                        return mvarColumnHeader;
                    }
                }

                public CheckState CurrentCheckState
                {
                    get
                    {
                        return mvarCheckState;
                    }
                    set
                    {
                        mvarCheckState = value;
                    }
                }
            }
            #endregion

            private void aCheckBoxUIElement_ElementClick(Object sender, Infragistics.Win.UIElementEventArgs e)
            {
                // Get the CheckBoxUIElement that was clicked
                CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)e.Element;

                // Get the Header associated with this particular element
                Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader = (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)).GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                // Set the Tag on the Header to the new CheckState
                aColumnHeader.Tag = aCheckBoxUIElement.CheckState;

                // So that we can apply various changes only to the relevant Rows collection that the header belongs to
                HeaderUIElement aHeaderUIElement = aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)) as HeaderUIElement;
                RowsCollection hRows = aHeaderUIElement.GetContext(typeof(RowsCollection)) as RowsCollection;

                // Raise an event so the programmer can do something when the CheckState changes
                if (_CLICKED != null)
                    _CLICKED(this, new HeaderCheckBoxEventArgs(aColumnHeader, aCheckBoxUIElement.CheckState, hRows));
            }

            public bool BeforeCreateChildElements(Infragistics.Win.UIElement parent)  // Implements Infragistics.Win.IUIElementCreationFilter.BeforeCreateChildElements
            {
                // Don't need to do anything here
                return false;
            }

            public void AfterCreateChildElements(Infragistics.Win.UIElement parent) // Implements Infragistics.Win.IUIElementCreationFilter.AfterCreateChildElements
            {
                // Check for the HeaderUIElement
                if (parent is HeaderUIElement)
                {
                    // Get the HeaderBase object from the HeaderUIElement
                    Infragistics.Win.UltraWinGrid.HeaderBase aHeader = ((HeaderUIElement)parent).Header;

                    // Only put the checkbox into headers whose DataType is boolean
                    if (aHeader.Column.DataType == typeof(bool))
                    {
                        TextUIElement aTextUIElement;
                        CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)parent.GetDescendant(typeof(CheckBoxUIElement));

                        // Since the grid sometimes re-uses UIElements, we need to check to make sure 
                        // the header does not already have a CheckBoxUIElement attached to it.
                        // If it does, we just get a reference to the existing CheckBoxUIElement,
                        // and reset its properties.
                        if (aCheckBoxUIElement == null)
                        {
                            //Create a New CheckBoxUIElement
                            aCheckBoxUIElement = new CheckBoxUIElement(parent);
                        }

                        // Get the TextUIElement - this is where the text for the 
                        // Header is displayed. We need this so we can push it to the right
                        // in order to make room for the CheckBox
                        aTextUIElement = (TextUIElement)parent.GetDescendant(typeof(TextUIElement));

                        // Sanity check
                        if (aTextUIElement == null)
                            return;

                        // Get the Header and see if the Tag has been set. If the Tag is 
                        // set, we will assume it's the stored CheckState. This has to be
                        // done in order to maintain the CheckState when the grid repaints and
                        // UIElement are destroyed and recreated. 
                        Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader =
                            (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement))
                            .GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                        if (aColumnHeader.Tag == null)
                            //If the tag was nothing, this is probably the first time this 
                            //Header is being displayed, so default to Indeterminate
                            aColumnHeader.Tag = CheckState.Indeterminate;
                        else
                            aCheckBoxUIElement.CheckState = (CheckState)aColumnHeader.Tag;

                        // Hook the ElementClick of the CheckBoxUIElement
                        aCheckBoxUIElement.ElementClick += new UIElementEventHandler(aCheckBoxUIElement_ElementClick);

                        // Add the CheckBoxUIElement to the HeaderUIElement
                        parent.ChildElements.Add(aCheckBoxUIElement);

                        // Position the CheckBoxUIElement. The number 3 here is used for 3
                        // pixels of padding between the CheckBox and the edge of the Header.
                        // The CheckBox is shifted down slightly so it is centered in the header.
                        aCheckBoxUIElement.Rect = new Rectangle(parent.Rect.X + 3, parent.Rect.Y + ((parent.Rect.Height - aCheckBoxUIElement.CheckSize.Height) / 2), aCheckBoxUIElement.CheckSize.Width, aCheckBoxUIElement.CheckSize.Height);

                        // Push the TextUIElement to the right a little to make 
                        // room for the CheckBox. 3 pixels of padding are used again. 
                        aTextUIElement.Rect = new Rectangle(aCheckBoxUIElement.Rect.Right + 3, aTextUIElement.Rect.Y, parent.Rect.Width - (aCheckBoxUIElement.Rect.Right - parent.Rect.X), aTextUIElement.Rect.Height);
                    }
                    else
                    {
                        // If the column is not a boolean column, we do not want to have a checkbox in it
                        // Since UIElements can be reused by the grid, there is a chance that one of the
                        // HeaderUIElements that we added a checkbox to for a boolean column header
                        // will be reused in a column that is not boolean.  In this case, we must remove
                        // the checkbox so that it will not appear in an inappropriate column header.
                        CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)parent.GetDescendant(typeof(CheckBoxUIElement));

                        if (aCheckBoxUIElement != null)
                        {
                            parent.ChildElements.Remove(aCheckBoxUIElement);
                            aCheckBoxUIElement.Dispose();
                        }
                    }
                }
            }
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ////////////////////////// ADD Checkboxes //////////////////////////////////
            
            // Tells the WinGrid to use your custom Creation Filter
            this.ultraGrid1.CreationFilter = aCheckBoxOnHeader_CreationFilter;
            ////////////////////////// END ADD Checkboxes //////////////////////////////
            // set band properties 
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
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
                    aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
                    // enable checkbox column
                    aBand.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in aBand.Columns)
                        col.CellActivation = Activation.Disabled;     
                    aBand.Columns[" "].CellActivation = Activation.AllowEdit;
                    aBand.Override.RowAppearance.ForeColorDisabled = Color.Black;
                }
            }

            // set other layout properties 
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.CellAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.RowAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
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
                    if(table.Columns[" "] != null)//this is leaf
                        foreach (DataRow row in table.Rows)
                            if (row.ItemArray[row.ItemArray.Length - 1].ToString().ToLower() == "true")
                            {
                                AddFilter(ref filter, name + "TypeID = '" + row.ItemArray[1] + "'");
                                AddDisplayFilter(ref displayFilter, row.ItemArray[2].ToString(), name);
                            }
            }
            AddFilter(ref strDisplayFilter, displayFilter, " AND ");
            return filter;
        }
        private string GetTreeFilters()
        {
            string str = "";
            return GetTreeFilters(ref str);
        }
        private string GetTreeFilters(ref string strDisplayFilter)
        { 
            string filter = "";
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode); // to perform last changes
            if(radioStation.Enabled)
                AddFilter(ref filter, GetDataSetFilters(StationDataSet, "Station", ref strDisplayFilter), " AND ");
            if (radioFood.Enabled)
                AddFilter(ref filter, GetDataSetFilters(FoodDataSet, "Food", ref strDisplayFilter), " AND ");
            if (radioLoss.Enabled)
                AddFilter(ref filter, GetDataSetFilters(LossDataSet, "Loss", ref strDisplayFilter), " AND ");
            if (radioDisposition.Enabled)
                AddFilter(ref filter, GetDataSetFilters(DispositionDataSet, "Disposition", ref strDisplayFilter), " AND ");
            if (radioDayPart.Enabled)
                AddFilter(ref filter, GetDataSetFilters(DaypartDataSet, "Daypart", ref strDisplayFilter), " AND ");
            if (radioEventOrder.Enabled)
                AddFilter(ref filter, GetDataSetFilters(BEODataSet, "BEO", ref strDisplayFilter), " AND ");
            return filter;
        }
        // show expanded rows
        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            // attempt to turn off expansion indicator 
            try
            {
                if (e.Row.Cells["ParentCatID"].Value.ToString() == "0")
                    e.Row.Expanded = true;
            }
            catch
            { // this is leaf
            }
        }
        private void CheckedChanged(bool isChecked, string name)
        {
            ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            ultraGrid1.UpdateData();
            if (isChecked)
                LoadTree(name);
            else
                UnloadTree();

        }

        private void radioStation_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioStation.Checked, "Station");
        }

        private void radioFood_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioFood.Checked, "Food");
        }

        private void radioLoss_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioLoss.Checked, "Loss");
        }

        private void radioDisposition_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioDisposition.Checked, "Disposition");
        }

        private void radioDayPart_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioDayPart.Checked, "Daypart");
        }
        private void radioEventOrder_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioEventOrder.Checked, "BEO");
        }
        public ARParameters ReportParameters
        {
            get
            {
                param.ColorPaletteName = cbPalette.SelectedItem.ToString();
                param.Title = txtTitle.Text;
                param.SubTitle = txtSubTitle.Text;
                param.StartDate = startDate.Value;
                param.EndDate = endDate.Value;
                param.NumShown = (int)numShown.Value;
                param.FirstDayOfWeek = DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex;
                param.Is3D = chk3D.Checked;
                param.IsHorizontal = chkHorizontal.Checked;
                param.LogoPath = txtLogo.Text;
                // Comparison report parameters
                param.Comparison = cbComparision.Text;
                param.ShowLbs = chkLbs.Checked;
                param.ComparisionStart = dtStartWeek.Value;
                param.ComparisionEnd = dtCompareWeek.Value;

                string filter;
                if (!IsComparision)
                {
                    if (strReportFilter != null)
                    {
                        if (Regex.IsMatch(strReportFilter, @"\[Timestamp\][^\[]*>"))
                        {
                            strReportFilter = Regex.Replace(strReportFilter, @"(\[Timestamp\][^\[]*>.*?#)([^#]*)#",
                                "[Timestamp] >= #" + VWA4Common.VWACommon.DateToString(startDate.Value) + "#");
                            strDisplayReportFilter = Regex.Replace(strDisplayReportFilter, @"(\[Timestamp\][^\[]*>.*?#)([^#]*)#",
                                "[Timestamp] >= #" + VWA4Common.VWACommon.DateToString(startDate.Value) + "#");
                        }
                        if (Regex.IsMatch(strReportFilter, @"\[Timestamp\][^\[]*<"))
                        {
                            strReportFilter = Regex.Replace(strReportFilter, @"(\[Timestamp\][^\[]*<.*?#)([^#]*)#",
                                "[Timestamp] < #" + VWA4Common.VWACommon.DateToString(endDate.Value) + "#");
                            strDisplayReportFilter = Regex.Replace(strDisplayReportFilter, @"(\[Timestamp\][^\[]*<.*?#)([^#]*)#",
                                "[Timestamp] < #" + VWA4Common.VWACommon.DateToString(endDate.Value) + "#");
                        }
                        filter = strReportFilter;
                    }
                    else
                    {
                        filter = "[Timestamp] >= #" + VWA4Common.VWACommon.DateToString(startDate.Value) + "# AND [Timestamp] < #" +
                            VWA4Common.VWACommon.DateToString(endDate.Value) + "#";
                        strDisplayReportFilter = "Timestamp >= " + VWA4Common.VWACommon.DateToString(startDate.Value) + " AND Timestamp < " +
                            VWA4Common.VWACommon.DateToString(endDate.Value);
                    }
                }
                else if (strReportFilter != null)
                    filter = strReportFilter;
                else 
                    filter = "";
                
                AddFilter(ref filter, GetTreeFilters(ref strDisplayReportFilter), " AND ");
                param.Filter = filter;
                param.DisplayFilter = strDisplayReportFilter;
                if (IsCrossTab)
                {
                    param.ParamName = cbCrossTabReport.SelectedItem.ToString();
                    param.ParamValue = cbCrossTabOn.SelectedItem.ToString();
                    if (param.ParamName == "Event Order")
                        param.ParamName = "BEO";
                    if (param.ParamValue == "Event Order")
                        param.ParamValue = "BEO";
                }
                if (IsEmployee)
                {
                    param.IsShowSub = chkExceptionShow.Checked;
                    param.IsOrderByWeight = radioEmployeeWeight.Checked;
                }
                return param;
            }
        }

        private void chkRecentWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecentWeek.Checked)
                dtStartWeek.Value = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
        }

        private void cbCompareWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtCompareWeek.Enabled = true;
            switch (cbCompareWeek.Text)
            {
                case "None": 
                    dtCompareWeek.Enabled = false;
                    break;
                case "Previous Week": 
                    dtCompareWeek.Value = dtStartWeek.Value.AddDays(-7);
                    break;
                case "Previous Cycle Week": 
                    dtCompareWeek.Value = dtStartWeek.Value.AddDays(-7 * VWA4Common.VWACommon.NumCycleWeeks);
                    break;
                case "Previous Year": 
                    dtCompareWeek.Value = dtStartWeek.Value.AddYears(-1);
                    break;
                default: 
                    break;
            }
        }

        private void dtStartWeek_ValueChanged(object sender, EventArgs e)
        {
            cbCompareWeek_SelectedIndexChanged(sender, e);
        }

        private void cbComparision_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioLoss.Enabled = true;
                radioFood.Enabled = true;
            switch (cbComparision.Text)
            {
                case "Days of Week" : 
                    break;
                case "Loss Categories" : 
                    radioLoss.Enabled = false; 
                    break;
                case "Food Categories" :
                    radioFood.Enabled = false; 
                    break;
                default:
                    break;
            }
        }

        private void cbCrossTabReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCrossTabOn.Items.Clear();
            cbCrossTabOn.Items.AddRange(new string[]{"Food", "Loss", "Station", "Disposition", "Day Part", "Event Order"});
            cbCrossTabOn.Items.RemoveAt(cbCrossTabReport.SelectedIndex);
            if (cbCrossTabOn.SelectedIndex < 0)
                cbCrossTabOn.SelectedIndex = 0;
            ActivateRadio(cbCrossTabReport.SelectedItem.ToString());
        }
        private void cbCrossTabOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableAllRadios();
            DisableRadio(cbCrossTabOn.SelectedItem.ToString());
            StationDataSet = FoodDataSet = LossDataSet = DispositionDataSet = DaypartDataSet = BEODataSet = null;
        }
        private void EnableAllRadios()
        {
            radioFood.Enabled = true;
            radioLoss.Enabled = true;
            radioStation.Enabled = true;
            radioDisposition.Enabled = true;
            radioDayPart.Enabled = true;
            radioEventOrder.Enabled = true;
        }
        private void DisableRadio(string name)
        {
            switch (name.Trim())
            {
                case "Food":
                    radioFood.Enabled = false;
                    break;
                case "Loss":
                    radioLoss.Enabled = false;
                    break;
                case "Station":
                    radioStation.Enabled = false;
                    break;
                case "Disposition":
                    radioDisposition.Enabled = false;
                    break;
                case "Day Part":
                    radioDayPart.Enabled = false;
                    break;
                case "Event Order":
                    radioEventOrder.Enabled = false;
                    break;
                default: break;
            }
        }
        private void ActivateRadio(string name)
        {
            switch (name.Trim())
            {
                case "Food":
                    radioFood.Checked = true;
                    break;
                case "Loss":
                    radioLoss.Checked = true;
                    break;
                case "Station":
                    radioStation.Checked = true;
                    break;
                case "Disposition":
                    radioDisposition.Checked = true;
                    break;
                case "Day Part":
                    radioDayPart.Checked = true;
                    break;
                case "Event Order":
                    radioEventOrder.Checked = true;
                    break;
                default: break;
            }
        }
        private bool CheckParams()
        {
            if (!IsComparision)
            {
                if (startDate.Value >= endDate.Value)
                {
                    MessageBox.Show(this, "Error in report dates: start date should be less than end date!", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTime temp = startDate.Value;
                    startDate.Value = endDate.Value;
                    endDate.Value = temp;
                    return false;
                }
            }
            return true;
        }
    }
}
