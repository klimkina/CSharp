using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Reports
{
    public partial class UCReportSerie : UserControl, UserControls.IVWAUserControlBase
    {
        DataTable _Reports = new DataTable();
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
        private VWA4Common.CommonEvents commonEvents = null;

        public UCReportSerie()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
            _Reports = VWA4Common.VWADBUtils.MemorizedReports();
            ultraGrid2.DataSource = _Reports;
            LoadReportSerie(VWA4Common.GlobalSettings.CurrentSiteID);
        }

        public void Init(DateTime firstDayOfWeek) //display
        {
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                //dbDetector.WeekChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_WeekChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
            }
            if(trackerDetector == null)
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

			// Security related
			btnAddReport.Enabled = VWA4Common.GlobalSettings.AddNewReportAvailable; 
			btnDeleteReport.Enabled = VWA4Common.GlobalSettings.AddNewReportAvailable;
			btnCloneReport.Enabled = VWA4Common.GlobalSettings.CloneReportAvailable;
			btnAddReportSet.Enabled = VWA4Common.GlobalSettings.AddNewCollectionAvailable;;
			btnDeleteReportSet.Enabled = VWA4Common.GlobalSettings.AddNewCollectionAvailable;
		}


		public void SaveData()
        {
            SaveReportSeries();
            SaveReports();
        }
        public bool ValidateData()
        { 
            return true; 
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
            SaveReportSeries();
            SaveReports();
            _IsActive = false;
        }

        private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ConfigXML"].Hidden = true;
            e.Layout.Bands[0].Columns["ID"].Hidden = true;
            e.Layout.Bands[0].Columns["Title"].Width = 284;
            e.Layout.Bands[0].Columns["Title"].SortIndicator = SortIndicator.Ascending;
            e.Layout.Bands[0].Columns["Title"].Header.Caption = "Report Name";

            e.Layout.Bands[0].Columns["CreatedDate"].Header.Caption = "Created On";
            e.Layout.Bands[0].Columns["CreatedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["CreatedDate"].EditorControl = ultraCalendarCombo1;
            e.Layout.Bands[0].Columns["ModifiedDate"].Header.Caption = "Modified On";
            e.Layout.Bands[0].Columns["ModifiedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["ModifiedDate"].EditorControl = ultraCalendarCombo1;

            e.Layout.Bands[0].Columns["CreatedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[0].Columns["ModifiedDate"].CellActivation = Activation.Disabled;

            this.ultraGrid2.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.FilterUIType = FilterUIType.HeaderIcons;
            //this.ultraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.ultraGrid2.DisplayLayout.Override.ActiveRowAppearance.Reset();
            this.ultraGrid2.DisplayLayout.Override.ActiveCellAppearance.Reset();
            this.ultraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Default;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            e.Layout.Bands[0].Columns["Title"].CellActivation = Activation.AllowEdit;
            e.Layout.Bands[0].Columns["ReportType"].CellActivation = Activation.ActivateOnly;
        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.ShowDialog();
            LoadData();
        }

        private void btnDeleteReport_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in ultraGrid2.Selected.Rows)
            {
                row.Selected = false;
                int id = int.Parse(row.Cells["ID"].Value.ToString());
                VWA4Common.DB.Delete("DELETE * FROM ReportParam WHERE ReportMemorized = " + id);
                VWA4Common.DB.Delete("DELETE * FROM ReportSet WHERE ReportMemorized = " + id);
                VWA4Common.DB.Delete("DELETE * FROM ReportMemorized WHERE ID = " + id);
            }
            LoadData();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.ActiveRow != null)
            {
                int id = int.Parse(this.ultraGrid2.ActiveRow.Cells["ID"].Value.ToString());
                frmReportViewer frm = new frmReportViewer();
                frm.View(id);
                frm.ShowDialog();

                LoadData();
                foreach(UltraGridRow row in this.ultraGrid2.Rows)
                    if(row.Cells["ID"].Value.ToString() == id.ToString())
                    {
                        row.Activate();
                        break;
                    }
            }        
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.ActiveRow != null)
            {
                int id = int.Parse(this.ultraGrid2.ActiveRow.Cells["ID"].Value.ToString());
                this.Cursor = Cursors.WaitCursor;
                frmReportViewer frm = new frmReportViewer();
                frm.Print(id);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCloneReport_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.ActiveRow != null)
            {
                int id = int.Parse(this.ultraGrid2.ActiveRow.Cells["ID"].Value.ToString());
                string reportType = this.ultraGrid2.ActiveRow.Cells["ReportType"].Value.ToString();
                UserControls.MemorizedReports frm = new UserControls.MemorizedReports(this.ultraGrid2.ActiveRow.Cells["ReportType"].Value.ToString(), true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + frm.ID).Rows.Count > 0)
                        VWA4Common.DB.Delete("DELETE FROM ReportParam WHERE ReportMemorized = " + frm.ID); // delete previous params
                    if(reportType != "View Waste")
                    {
                        DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + id);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            VWA4Common.DB.Insert("INSERT INTO ReportParam (ParamName, ParamValue, ParamDisplayValue, ParamType, " +
                                " ParamValueType, AssignType, GlobalName, ReportMemorized) VALUES( '" +
                                dt.Rows[i]["ParamName"] + "', '" +
                                dt.Rows[i]["ParamValue"] + "', '" +
                                dt.Rows[i]["ParamDisplayValue"] + "', '" +
                                dt.Rows[i]["ParamType"] + "', '" +
                                dt.Rows[i]["ParamValueType"] + "', '" +
                                dt.Rows[i]["AssignType"] + "', '" +
                                dt.Rows[i]["GlobalName"] + "', " +
                                frm.ID + ")");
                        }
                    }
                    else
                    {
                        byte[] bt = System.Text.Encoding.Unicode.GetBytes(this.ultraGrid1.ActiveRow.Cells["ConfigXML"].Value.ToString());
                        MemoryStream stream = new MemoryStream(bt, 0, bt.Length);
                        VWA4Common.VWADBUtils.SaveXMLConfig(frm.ID, "View Waste", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
                    }
                    LoadData();
                }
            }
        }

        //private void ucSiteChooser1_SiteChanged(object sender, UserControls.UCSiteChooser.SiteEventArgs e)
        //{
        //    LoadReportSerie(e.SiteID);
        //}

        private DataSet _ReportSeries;
        private void LoadReportSerie(int siteID)
        {
            try
            {
                _ReportSeries = new DataSet();
                _ReportSeries.Tables.Add(VWA4Common.DB.Retrieve("SELECT * FROM ReportSeries WHERE SiteID = " + siteID));
                _ReportSeries.Tables[0].TableName = "ReportSeries";
                _ReportSeries.Tables.Add(VWA4Common.DB.Retrieve("SELECT * FROM ReportSeries LEFT JOIN " +
                    " (ReportSet LEFT JOIN ReportMemorized ON ReportSet.ReportMemorized = ReportMemorized.ID ) " +
                    " ON ReportSet.SerieID = ReportSeries.ID   WHERE ReportSeries.SiteID = " + siteID + " OR ReportSeries.SiteID = 0 ORDER BY [Order]"));
                _ReportSeries.Tables[1].TableName = "ReportSet";
                _ReportSeries.Relations.Add(new DataRelation("ReportSet", _ReportSeries.Tables["ReportSeries"].Columns["ID"],
                    _ReportSeries.Tables["ReportSet"].Columns["SerieID"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report Collections Initialization error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ultraGrid1.DataSource = _ReportSeries;
            ultraGrid1.Refresh();
            ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
            ultraGrid2.Refresh();
            ultraGrid2.Rows.Refresh(RefreshRow.ReloadData);
        }

        private void btnMapParams_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.Band.Key == "ReportSet")
            {
                int id = int.Parse(this.ultraGrid2.ActiveRow.Cells["ID"].Value.ToString());
                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportMappedParam WHERE ReportSet = " + id);
                if (dt.Rows.Count <= 0) // if there are no mapped parameters then insert from ReportParam
                {
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized IN " +
                        "(SELECT ReportMemorized FROM ReportSet WHERE ID = " + id + ")");
                    foreach (DataRow row in dt.Rows)
                        VWA4Common.DB.Insert("INSERT INTO ReportMappedParam " +
                            "(ParamName, ParamValue, ParamDisplayValue, ParamType, ParamValueType, AssignType, GlobalName, ReportSet)" +
                            "VALUES('" + row["ParamName"] + "', '" + row["ParamValue"] + "', '" + row["ParamDisplayValue"] + "', '" + row["ParamType"] +
                            "', '" + row["ParamValueType"] + "', '" + row["AssignType"] + "', '" + row["GlobalName"] + "'," + id + ")");
                }
                frmMapParameters frm = new frmMapParameters(id);
                frm.ShowDialog();
            }
            else
                MessageBox.Show(null,"Choose report to map parameters", "Choose Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int _MinSerieID = -1;
        private void btnAddReportSet_Click(object sender, EventArgs e)
        {
            frmAddReportSerie frm = new frmAddReportSerie();
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow row = _ReportSeries.Tables["ReportSeries"].NewRow();
                row["ID"] = _MinSerieID;
                _MinSerieID--;
                row["SiteID"] = VWA4Common.GlobalSettings.CurrentSiteID;
                row["SerieName"] = frm.SerieName;
                row["CreatedDate"] = DateTime.Now;
                row["ModifiedDate"] = DateTime.Now;
                _ReportSeries.Tables["ReportSeries"].Rows.Add(row);
                ultraGrid1.Refresh();
            }
        }

        private void btnDeleteReportSet_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in ultraGrid1.Selected.Rows)
            {
                row.Selected = false;
                DataRow delrow = ((DataRowView)row.ListObject).Row;
                if (delrow.Table.TableName == "ReportSeries")
                {
                    if (int.Parse(delrow["ID"].ToString()) >= 0)
                    {
                        VWA4Common.DB.Delete("DELETE * FROM ReportSet WHERE SerieID = " + delrow["ID"]);
                        VWA4Common.DB.Delete("DELETE * FROM ReportSeries WHERE ID = " + delrow["ID"]);
                    }
                }
                else if (int.Parse(delrow["ReportSet.ID"].ToString()) >= 0)
                {
                    VWA4Common.DB.Delete("DELETE * FROM ReportSet WHERE ID = " + delrow["ReportSet.ID"]);
                    SetModifiedDate(delrow["ReportSeries.ID"].ToString());
                }

                delrow.Delete();
                //_ReportSeries.Tables[row.Band.Key].Rows.Remove(delrow);
            }
            ultraGrid1.Refresh();
        }

        private void btnViewReportSet_Click(object sender, EventArgs e)
        {
            SetReportOrder();
            frmReportViewer frmReports = new frmReportViewer();
            frmReportViewer frmViewWaste = new frmReportViewer();
            bool isReports = false;
            int nViewWaste = 0;
            this.Cursor = Cursors.WaitCursor;
            
            bool isWeekly = false;

            //get the count of selected rows and drop each starting at the dropIndex
            foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
            {
                isWeekly = Regex.IsMatch(aRow.Cells["SerieName"].Value.ToString(), "weekly", RegexOptions.IgnoreCase);
                if (aRow.Band.Key == "ReportSet")
                {
                    
                    int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                    if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                    {
                        frmViewWaste.AddPDF(id);
                        nViewWaste++;
                    }
                    else
                    {
                        frmReports.AddLoadParameters(id, isWeekly);
                        isReports = true;
                    }
                }
                else
                {
                    DataView view = _ReportSeries.Tables["ReportSet"].DefaultView;
                    view.RowFilter = "ReportSeries.ID = " + aRow.Cells["ID"].Value;
                    view.Sort = "Order";
                    foreach (DataRowView viewRow in view)
                    {
                        if (viewRow["ReportMemorized.ID"].ToString() != "")
                        {
                            int id = int.Parse(viewRow["ReportMemorized.ID"].ToString());
                            if (viewRow["ReportType"].ToString() == "View Waste")
                            {
                                frmViewWaste.AddPDF(id);
                                nViewWaste++;
                            }
                            else
                            {
                                frmReports.AddLoadParameters(id, isWeekly);
                                isReports = true;
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
            if (isReports)
            {
                frmReports.SetTitle(ultraGrid1.Rows[0].Cells["SerieName"].Value.ToString());
                frmReports.View();
                frmReports.Show();
            }
            if (nViewWaste > 0)
            {
                if (nViewWaste > 1)
                {
                    DialogResult result = ShowSavePDF();
                    if (result == DialogResult.Cancel)
                        return;
                    string fileName = this.saveFileDialog1.FileName;
                    frmViewWaste.ShowPDF(fileName);
                }
                else
                {
                    frmViewWaste.View();
                    frmViewWaste.Show();
                }
            }

            // set task checkboxes
            VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
            utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "reviewreports");
        }

        private void btnPrintReportSet_Click(object sender, EventArgs e)
        {
            SetReportOrder();
            //get the count of selected rows and drop each starting at the dropIndex
            this.Cursor = Cursors.WaitCursor;
            frmReportViewer frmReports = new frmReportViewer();
            frmReportViewer frmViewWaste = new frmReportViewer();
            bool isViewWaste = false, isReports = false;
            foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
            {
                if (aRow.Band.Key == "ReportSet")
                {
                    int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                    if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                    {
                        frmViewWaste.AddPrint(id);
                        isViewWaste = true;
                    }
                    else
                    {
                        frmReports.AddPrint(id);
                        isReports = true;
                    }
                    
                }
                else
                {
                    DataView view = _ReportSeries.Tables["ReportSet"].DefaultView;
                    view.RowFilter = "ReportSeries.ID = " + aRow.Cells["ID"].Value;
                    view.Sort = "Order";
                    foreach (DataRowView viewRow in view)
                    {
                        int id = int.Parse(viewRow["ReportMemorized.ID"].ToString());
                        if (viewRow["ReportType"].ToString() == "View Waste")
                        {
                            frmViewWaste.AddPrint(id);
                            isViewWaste = true;
                        }
                        else
                        {
                            frmReports.AddPrint(id);
                            isReports = true;
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
            if(isReports)
                frmReports.Print();
            if(isViewWaste)
                frmViewWaste.Print();
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ID"].Hidden = true;
            e.Layout.Bands[0].Columns["SiteID"].Hidden = true;
            
            e.Layout.Bands[0].Columns["SerieName"].Header.Caption = "Collection Name";
            e.Layout.Bands[1].Columns["ReportSeries.ID"].Hidden = true;
            e.Layout.Bands[1].Columns["Order"].Hidden = true;
            e.Layout.Bands[1].Columns["Expression"].Hidden = true;
            e.Layout.Bands[1].Columns["SerieID"].Hidden = true;
            e.Layout.Bands[1].Columns["ConfigXML"].Hidden = true;
            e.Layout.Bands[1].Columns["ReportMemorized.ID"].Hidden = true;
            e.Layout.Bands[1].Columns["SerieName"].Hidden = true;
            e.Layout.Bands[1].Columns["SiteID"].Hidden = true;
            e.Layout.Bands[1].Columns["ReportSet.ID"].Hidden = true;
            e.Layout.Bands[1].Columns["ReportMemorized"].Hidden = true;
            e.Layout.Bands[1].Columns["Title"].Header.Caption = "Report Name";
            e.Layout.Bands[1].Columns["ReportType"].Header.Caption = "Report Type";
            e.Layout.Bands[1].Columns["Title"].CellActivation = Activation.ActivateOnly;

            e.Layout.Bands[0].Columns["CreatedDate"].Header.Caption = "Created On";
            e.Layout.Bands[0].Columns["CreatedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["CreatedDate"].EditorControl = ultraCalendarCombo1;
            e.Layout.Bands[0].Columns["ModifiedDate"].Header.Caption = "Modified On";
            e.Layout.Bands[0].Columns["ModifiedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["ModifiedDate"].EditorControl = ultraCalendarCombo1;

            e.Layout.Bands[0].Columns["CreatedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[0].Columns["ModifiedDate"].CellActivation = Activation.Disabled;

            e.Layout.Bands[1].Columns["ReportMemorized.CreatedDate"].Header.Caption = "Created On";
            e.Layout.Bands[1].Columns["ReportMemorized.CreatedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[1].Columns["ReportMemorized.CreatedDate"].EditorControl = ultraCalendarCombo1;
            e.Layout.Bands[1].Columns["ReportMemorized.ModifiedDate"].Header.Caption = "Modified On";
            e.Layout.Bands[1].Columns["ReportMemorized.ModifiedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[1].Columns["ReportMemorized.ModifiedDate"].EditorControl = ultraCalendarCombo1;

            e.Layout.Bands[1].Columns["ReportMemorized.CreatedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[1].Columns["ReportMemorized.ModifiedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[1].Columns["ReportSeries.CreatedDate"].Hidden = true;
            e.Layout.Bands[1].Columns["ReportSeries.ModifiedDate"].Hidden = true;

            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance.Reset();
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance.Reset();
            this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Default;
            //e.Layout.Override.ExpansionIndicator = ShowExpansionIndicator.Always;
            e.Layout.Override.FilterUIType = FilterUIType.HeaderIcons;
            ultraGrid1.AllowDrop = true;
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            //e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

            e.Layout.Bands[0].Columns["SerieName"].CellActivation = Activation.AllowEdit;
            e.Layout.Bands[1].Columns["ReportType"].CellActivation = Activation.Disabled;
        }

        private void ultraGrid2_SelectionDrag(object sender, CancelEventArgs e)
        {
            ultraGrid2.DoDragDrop(ultraGrid2.Selected.Rows, DragDropEffects.Move);
        }

        private void ultraGrid1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            UltraGrid grid = sender as UltraGrid;
            Point pointInGridCoords = grid.PointToClient(new Point(e.X, e.Y));
            if (pointInGridCoords.Y < 20)
                // Scroll up.
                this.ultraGrid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp);
            else if (pointInGridCoords.Y > grid.Height - 20)
                // Scroll down.
                this.ultraGrid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown);
        }
        private int _MinSetID = -1;
        private void ultraGrid1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                int dropIndex;

                //Get the position on the grid where the dragged row(s) are to be dropped.
                //get the grid coordinates of the row (the drop zone)
                UIElement uieOver = ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(ultraGrid1.PointToClient(new Point(e.X, e.Y)));

                //get the row that is the drop zone/or where the dragged row is to be dropped
                UltraGridRow ugrOver = uieOver.GetContext(typeof(UltraGridRow), true) as UltraGridRow;

                if (ugrOver != null)
                {
                    dropIndex = ugrOver.Index;    //index/position of drop zone in grid

                    //get the dragged row(s)which are to be dragged to another position in the grid
                    SelectedRowsCollection SelRows = (SelectedRowsCollection)e.Data.GetData(typeof(SelectedRowsCollection)) as SelectedRowsCollection;
                    //get the count of selected rows and drop each starting at the dropIndex
                    if (SelRows.Count > 0)
                    {
                        if (SelRows[0].Band.Key == "ReportSet")
                            foreach (UltraGridRow aRow in SelRows)
                            {
                                string serieID = aRow.Cells["ReportSeries.ID"].Value.ToString();
                                DataRow dataRow = ((DataRowView)aRow.ListObject).Row;
                                if (ugrOver.Band.Key == "ReportSeries")
                                {
                                    dataRow["ReportSeries.ID"] = ugrOver.Cells["ID"].Value;
                                    dataRow["SerieName"] = ugrOver.Cells["SerieName"].Value;
                                    dataRow["SiteID"] = ugrOver.Cells["SiteID"].Value;
                                    
                                }
                                else
                                {
                                    dataRow["ReportSeries.ID"] = ugrOver.ParentRow.Cells["ID"].Value;
                                    dataRow["SerieName"] = ugrOver.ParentRow.Cells["SerieName"].Value;
                                    dataRow["SiteID"] = ugrOver.ParentRow.Cells["SiteID"].Value;
                                }
                                dataRow["SerieID"] = dataRow["ReportSeries.ID"];
                                SetModifiedDate(dataRow["SerieID"].ToString());
                                ultraGrid1.Rows.Move(aRow, dropIndex);
                                if (dataRow["SerieID"].ToString() == serieID) //serie ID didn't changed
                                    aRow.ParentCollection.Move(aRow, dropIndex);
                            }
                        else if(SelRows[0].Band.Key != "ReportSeries")
                            foreach (UltraGridRow aRow in SelRows)
                            {
                                DataRow row = _ReportSeries.Tables["ReportSet"].NewRow();
                                row["ReportSet.ID"] = _MinSetID;
                                _MinSetID--;
                                if (ugrOver.Band.Key == "ReportSeries")
                                {
                                    row["ReportSeries.ID"] = ugrOver.Cells["ID"].Value;
                                    row["SerieName"] = ugrOver.Cells["SerieName"].Value;
                                    row["SiteID"] = ugrOver.Cells["SiteID"].Value;
                                }
                                else
                                {
                                    row["ReportSeries.ID"] = ugrOver.ParentRow.Cells["ID"].Value;
                                    row["SerieName"] = ugrOver.ParentRow.Cells["SerieName"].Value;
                                    row["SiteID"] = ugrOver.ParentRow.Cells["SiteID"].Value;
                                }
                                SetModifiedDate(row["ReportSeries.ID"].ToString());
                                row["ReportMemorized"] = aRow.Cells["ID"].Value;
                                row["ReportMemorized.ID"] = aRow.Cells["ID"].Value;
                                row["ReportType"] = aRow.Cells["ReportType"].Value;
                                row["Order"] = -1;
                                row["Expression"] = "";
                                row["SerieID"] = row["ReportSeries.ID"];
                                row["ConfigXML"] = aRow.Cells["ConfigXML"].Value;
                                row["Title"] = aRow.Cells["Title"].Value;
                                _ReportSeries.Tables["ReportSet"].Rows.Add(row);
                            }
                        ultraGrid1.Refresh();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during drag&drop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraGrid1_SelectionDrag(object sender, CancelEventArgs e)
        {
            ultraGrid1.DoDragDrop(ultraGrid1.Selected.Rows, DragDropEffects.Move);
        }

        private void SetReportOrder()
        {
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            //IEnumerable enumerator = band.GetRowEnumerator(GridRowType.DataRow);

            foreach (UltraGridRow row in band.GetRowEnumerator(GridRowType.DataRow))
            {
                int i = 1;
                foreach(UltraGridRow childRow in row.ChildBands[0].Rows)
                {
                    DataRow datarow = ((DataRowView)childRow.ListObject).Row;
                    if (datarow["Order"].ToString() != i.ToString())
                        datarow["Order"] = i;
                    i++;
                }
            }
        }
        private void SaveReportSeries()
        {
            SetReportOrder();
            
            foreach (DataRow row in _ReportSeries.Tables["ReportSeries"].Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    int id = VWA4Common.DB.Insert("INSERT INTO ReportSeries (SerieName, SiteID, CreatedDate, ModifiedDate) " +
                        "VALUES('" + row["SerieName"] + "'," + row["SiteID"] + ", #" + VWA4Common.VWACommon.DateToString(DateTime.Now) + "#, #" + VWA4Common.VWACommon.DateToString(DateTime.Now) + "#)");
                    DataView view = _ReportSeries.Tables["ReportSet"].DefaultView;
                    view.RowFilter = "ReportSeries.ID = " + row["ID"];
                    foreach (DataRowView viewRow in view)
                    {
                        viewRow["ReportSeries.ID"] = id;
                        //viewRow["SerieID"] = id;
                    }
                    row["ID"] = id;
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    VWA4Common.DB.Update("UPDATE ReportSeries SET SerieName = '" + row["SerieName"] + "', SiteID = " + row["SiteID"] +
                        ", ModifiedDate = #"+ VWA4Common.VWACommon.DateToString(DateTime.Now) + "#" +
                        " WHERE ReportSeries.ID = " + row["ID"]);
                }
            }
            _ReportSeries.Tables["ReportSeries"].AcceptChanges();

            foreach (DataRow row in _ReportSeries.Tables["ReportSet"].Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    row["ReportSet.ID"] = VWA4Common.DB.Insert("INSERT INTO ReportSet (ReportMemorized, [Order], Expression, SerieID) " +
                        " VALUES( " + row["ReportMemorized.ID"] + "," + row["Order"] + ", '" + row["Expression"] + "', " + row["SerieID"] + ")");
                }

                else if (row.RowState == DataRowState.Modified)
                {
                    VWA4Common.DB.Update("UPDATE ReportSet SET ReportMemorized = " + row["ReportMemorized.ID"] +
                        ", [Order] = " + row["Order"] + ", Expression = '" + row["Expression"] + "', SerieID =" + row["SerieID"] +
                        " WHERE ID = " + row["ReportSet.ID"]);
                }
            }
            _ReportSeries.Tables["ReportSet"].AcceptChanges();

            ultraGrid1.Refresh();
            ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
        }

        private void SaveReports()
        {
            ultraGrid2.UpdateData();
            //foreach (DataRow row in _Reports.Rows)
            //{
            //    if (row.RowState == DataRowState.Modified)
            //    {
            //        VWA4Common.DB.Update("UPDATE ReportMemorized SET Title = '" + row["Title"] + "'" +
            //            " WHERE ID = " + row["ID"]);
            //    }
            //}
            //_Reports.AcceptChanges();

            //ultraGrid1.Refresh();
            //ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
        }

        private DialogResult ShowSavePDF()
        {
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "Portable Document Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            return this.saveFileDialog1.ShowDialog(this);
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            DialogResult result = ShowSavePDF();
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            SetReportOrder();
            frmReportViewer frmReports = new frmReportViewer();
            frmReportViewer frmViewWaste = new frmReportViewer();
            bool isViewWaste = false, isReports = false;
            this.Cursor = Cursors.WaitCursor;

            //get the count of selected rows and drop each starting at the dropIndex
            foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
            {
                if (aRow.Band.Key == "ReportSet")
                {
                    int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                    if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                    {
                        frmViewWaste.AddPDF(id);
                        isViewWaste = true;
                    }
                    else
                    {
                        frmReports.AddPDF(id);
                        isReports = true;
                    }
                }
                else
                {
                    DataView view = _ReportSeries.Tables["ReportSet"].DefaultView;
                    view.RowFilter = "ReportSeries.ID = " + aRow.Cells["ID"].Value;
                    view.Sort = "Order";
                    foreach (DataRowView viewRow in view)
                    {
                        int id = int.Parse(viewRow["ReportMemorized.ID"].ToString());
                        if (viewRow["ReportType"].ToString() == "View Waste")
                        {
                            frmViewWaste.AddPDF(id);
                            isViewWaste = true;
                        }
                        else
                        {
                            frmReports.AddPDF(id);
                            isReports = true;
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
            
            if (isViewWaste)
            {
                if (isReports)
                {
                    result = ShowSavePDF();
                    if (result == DialogResult.Cancel)
                        return;
                }
                frmViewWaste.ShowPDF(this.saveFileDialog1.FileName);
            }
            if (isReports)
            {
                frmReports.ShowPDF(fileName);
            }
        }

        void dbDetector_PathChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        void trackerDetector_WeekChanged(object sender, EventArgs e)
        {
            //TODO: what to do if week changed?
        }
        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            LoadReportSerie(VWA4Common.GlobalSettings.CurrentSiteID); ;
        }

        private void btnPDFReport_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.ActiveRow != null)
            {
                DialogResult result = ShowSavePDF();
                if (result == DialogResult.Cancel)
                    return;
                string fileName = this.saveFileDialog1.FileName;

                int id = int.Parse(this.ultraGrid2.ActiveRow.Cells["ID"].Value.ToString());
                this.Cursor = Cursors.WaitCursor;
                frmReportViewer frm = new frmReportViewer();
                frm.ShowPDF(id, fileName);
                this.Cursor = Cursors.Default;
            }
        }

        private void ultraGrid2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            btnViewReport_Click(sender, e);
        }

        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            btnViewReportSet_Click(sender, e);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            commonEvents.TaskSheetKey = "dashboard";
        }

        private void ultraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            if (this.ultraGrid1.DataSource is DataSet)
            {
                DataRowView drv = (DataRowView)e.Row.ListObject;
                DataRow row = drv.Row;

                VWA4Common.DB.Update("UPDATE ReportMemorized SET Title = '" + row["Title"] + "', ModifiedDate = #" + 
                    VWA4Common.VWACommon.DateToString(DateTime.Now) + " #" +
                    " WHERE ID = " + row["ID"]);

                DataView view = _ReportSeries.Tables["ReportSet"].DefaultView;
                view.RowFilter = "ReportMemorized.ID = " + row["ID"];
                
                foreach (DataRowView viewRow in view)
                {
                    viewRow["Title"] = row["Title"];
                }
                
            }
            _Reports.AcceptChanges();

            ultraGrid1.Refresh();
            ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);

        }

        private void ultraGrid2_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            if (ultraGrid2.Selected.Rows.Count > 0 && (ModifierKeys != Keys.Shift) && (ModifierKeys != Keys.Control))
            {
                if(e.NewSelections.Rows.Count > 0) //clear selection before add
                    ultraGrid2.Selected.Rows.Clear();
            }
        }

        private void SetModifiedDate(string id)
        {
            foreach(Infragistics.Win.UltraWinGrid.UltraGridRow row in ultraGrid1.Rows)
                if (row.Cells["ID"].Value.ToString() == id)
                {
                    row.Cells["ModifiedDate"].Value = DateTime.Now;
                    break;
                }
            VWA4Common.DB.Update("UPDATE ReportSeries SET ModifiedDate = #" + VWA4Common.VWACommon.DateToString(DateTime.Now) +
                " # WHERE ID = " + id); 
        }
    }
}
