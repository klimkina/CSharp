using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Net;
using System.Threading;

namespace Reports
{
    public partial class UCWeeklyReports : UserControl, UserControls.IVWAUserControlBase
    {
        DataTable _WeeklyReports = new DataTable();
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
        private VWA4Common.CommonEvents commonEvents = null;
        private bool _IsWeekly;
		private bool _progressCancelled;
        public UCWeeklyReports():this(true)
        {
            
        }
        /// <summary>
        /// Constructor for printing weekly reports or reviewing reports.
        /// </summary>
        /// <param name="isWeekly">Review Reports = false; Print Weekly Reports = true</param>
		public UCWeeklyReports(bool isWeekly) 
        {
            InitializeComponent();
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			commonEvents.ProgressCancelled +=
				new VWA4Common.ProgressCancelledEventHandler(commonEvents_CancelProgress);
            _IsWeekly = isWeekly;
            if (_IsWeekly)
                btnPrintReportSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            else
            {
                btnViewReportSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.label3.Text = (_IsWeekly ? "Print" : "Review") + " Weekly Reports";
                this.lblSerieName.Text = "Report Collection named '" + (_IsWeekly ? VWA4Common.GlobalSettings.ReportsToPrint : VWA4Common.GlobalSettings.ReportsToView) + "' is displayed here.";
            }
        }

		private void commonEvents_CancelProgress(object sender, EventArgs e)
		{
			_progressCancelled = true;
		}

		/// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
         
         	_progressCancelled = false;
			if (LoadWeeklyReports(VWA4Common.GlobalSettings.CurrentSiteID))
                ultraGrid1.DataSource = _WeeklyReports;
            else
                ultraGrid1.DataSource = null;
            ultraGrid1.Refresh();
            ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
        }
        private bool LoadWeeklyReports(int siteID)
        {
            try
            {
                string serieName = (_IsWeekly ? VWA4Common.GlobalSettings.ReportsToPrint : VWA4Common.GlobalSettings.ReportsToView);

                this.lblSerieName.Text = "Report Collection named '" + serieName + "' is displayed here.";

                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportSeries WHERE SiteID = " + siteID +
                    " AND SerieName = '" + serieName + "'");
                if (dt.Rows.Count == 1)
                {
                    _WeeklyReports = VWA4Common.DB.Retrieve("SELECT * FROM ReportSeries LEFT JOIN " +
                        " (ReportSet LEFT JOIN ReportMemorized ON ReportSet.ReportMemorized = ReportMemorized.ID ) " +
                        " ON ReportSet.SerieID = ReportSeries.ID   WHERE ReportSeries.SiteID = " + siteID + " AND SerieName = '" + serieName + "' ORDER BY [Order]");
                }
                else if (dt.Rows.Count < 1)
                {
                    MessageBox.Show(null, "Create Report Collection called '" + serieName + "' in Report Manager.",
                        "No Weekly Reports found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    MessageBox.Show(null, "More than 1 Weekly Reports found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report Collections Initialization error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public void Init(DateTime firstDayOfWeek) //display
        {
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                //dbDetector.WeekChanged += new UserControls.DBDetectorEventHandler(dbDetector_WeekChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
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

        public void SaveData()
        {
            
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
			VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled = false;
			_IsActive = false;
        }

        void dbDetector_PathChanged(object sender, EventArgs e)
        {
            if (_IsActive)
                LoadData();
        }
        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            if (_IsActive)
                LoadData();
        }
        void trackerDetector_WeekChanged(object sender, EventArgs e)
        {
            //TODO: what to do if week changed?
        }
		
		
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			InitProductUI();
		}
		void InitProductUI()
		{
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			label3.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			panel2.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			panel4.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
		}
	
		
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ReportSeries.ID"].Hidden = true;
            e.Layout.Bands[0].Columns["Order"].Hidden = true;
            e.Layout.Bands[0].Columns["Expression"].Hidden = true;
            e.Layout.Bands[0].Columns["SerieID"].Hidden = true;
            e.Layout.Bands[0].Columns["ConfigXML"].Hidden = true;
            e.Layout.Bands[0].Columns["ReportMemorized.ID"].Hidden = true;
            e.Layout.Bands[0].Columns["SerieName"].Hidden = true;
            e.Layout.Bands[0].Columns["SiteID"].Hidden = true;
            e.Layout.Bands[0].Columns["ReportSet.ID"].Hidden = true;
            e.Layout.Bands[0].Columns["ReportMemorized"].Hidden = true;
            e.Layout.Bands[0].Columns["Title"].Header.Caption = "Report Title";
            e.Layout.Bands[0].Columns["ReportType"].Header.Caption = "Report Type";
            e.Layout.Bands[0].Columns["ReportSeries.CreatedDate"].Hidden = true;
            e.Layout.Bands[0].Columns["ReportSeries.ModifiedDate"].Hidden = true;

            e.Layout.Bands[0].Columns["ReportMemorized.CreatedDate"].Header.Caption = "Created On";
            e.Layout.Bands[0].Columns["ReportMemorized.CreatedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["ReportMemorized.CreatedDate"].EditorControl = ultraCalendarCombo1;
            e.Layout.Bands[0].Columns["ReportMemorized.ModifiedDate"].Header.Caption = "Modified On";
            e.Layout.Bands[0].Columns["ReportMemorized.ModifiedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["ReportMemorized.ModifiedDate"].EditorControl = ultraCalendarCombo1;

            e.Layout.Bands[0].Columns["ReportMemorized.CreatedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[0].Columns["ReportMemorized.ModifiedDate"].CellActivation = Activation.Disabled;

            e.Layout.Bands[0].Columns["Title"].CellActivation = Activation.ActivateOnly;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance.Reset();
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance.Reset();
            this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Default;
            e.Layout.Override.FilterUIType = FilterUIType.HeaderIcons;
            ultraGrid1.AllowDrop = true;
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

        }

        private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                int id = int.Parse(this.ultraGrid1.ActiveRow.Cells["ReportMemorized"].Value.ToString());
                frmReportViewer frm = new frmReportViewer();
                frm.View(id, true);
                frm.ShowDialog();
            }
            LoadData();
        }

        //private void GenerateViewReports()
        //{
        //    frmReportViewer frmReports = new frmReportViewer();
        //    frmReportViewer frmViewWaste = new frmReportViewer();
        //    bool isReports = false;
        //    int nViewWaste = 0;
        //    pf.Visible = true;
        //    pf.Value = 0;
        //    //get the count of selected rows and drop each starting at the dropIndex
        //    if (ultraGrid1.Selected.Rows.Count > 0)
        //    {
        //        pf.Maximum = ultraGrid1.Selected.Rows.Count;
        //        foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
        //        {

        //            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
        //            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
        //            {
        //                frmViewWaste.AddPDF(id);
        //                nViewWaste++;
        //            }
        //            else
        //            {
        //                frmReports.AddLoadParameters(id, true);
        //                isReports = true;
        //            }

        //            pf.PerformStep();
        //        }
        //    }
        //    else
        //    {
        //        pf.Maximum = ultraGrid1.Rows.Count;
        //        foreach (UltraGridRow aRow in ultraGrid1.Rows)
        //        {

        //            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
        //            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
        //            {
        //                frmViewWaste.AddPDF(id);
        //                nViewWaste++;
        //            }
        //            else
        //            {
        //                frmReports.AddLoadParameters(id, true);
        //                isReports = true;
        //            }

        //            pf.PerformStep();
        //        }
        //    }
        //    if (isReports)
        //    {
        //        frmReports.SetTitle(ultraGrid1.Rows[0].Cells["SerieName"].Value.ToString());
        //        frmReports.View();
        //        frmReports.Show();
        //    }
        //    if (nViewWaste > 0)
        //    {
        //        if (nViewWaste > 1)
        //        {
        //            DialogResult result = ShowSavePDF();
        //            if (result == DialogResult.Cancel)
        //                return;
        //            string fileName = this.saveFileDialog1.FileName;
        //            frmViewWaste.ShowPDF(fileName);
        //        }
        //        else
        //        {
        //            frmViewWaste.View();
        //            frmViewWaste.Show();
        //        }
        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnViewReportSet_Click(object sender, EventArgs e)
        {
			VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled = false;
			try
            {
                //pf = new VWA4Common.ProgressForm();
                //pf.SetupAndShow(this.ParentForm, "Showing Reports", "Creating Report List...", true, true);
                int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
                int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;

                

                VWA4Common.ProgressDialog.ShowProgressDialog("Looking for Reports' Names.", "", "", pd_left, pd_top);
                frmReportViewer frmReports = new frmReportViewer();
                frmReportViewer frmViewWaste = new frmReportViewer();
                int nRows = 0, nReports = 1;

                if (ultraGrid1.Selected.Rows.Count > 0)
                    nRows = ultraGrid1.Selected.Rows.Count;
                else
                    nRows = ultraGrid1.Rows.Count;


                btnViewReportSet.Enabled = false;

                
                VWA4Common.ProgressDialog.SetLeadin("Report List created");
                
                VWA4Common.ProgressDialog.SetLeadin("Report List created");
                bool isReports = false;
                int nViewWaste = 0;

                double progressTick = (nRows > 0 ? 100 / nRows : 1);
                VWA4Common.ProgressDialog.SetLeadin("Generating Reports");
                try
                {

                    VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                    //get the count of selected rows and drop each starting at the dropIndex
                    if (ultraGrid1.Selected.Rows.Count > 0)
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
                        {
                            if (_progressCancelled)
                            {
                                btnViewReportSet.Enabled = true;
                                return;
                            }
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPDF(id);
                                nViewWaste++;
                            }
                            else
                            {
                                frmReports.AddLoadParameters(id, true);
                                isReports = true;
                            }
                            nReports++;
                        }
                    }
                    else
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Rows)
                        {
							if (_progressCancelled)
                            {
                                btnViewReportSet.Enabled = true;
                                return;
                            }
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPDF(id);
                                nViewWaste++;
                            }
                            else
                            {
                                frmReports.AddLoadParameters(id, true);
                                isReports = true;
                            }
                            nReports++;
                        }
                    }
                }
                finally
                {
                    FinishProgress();
                    btnViewReportSet.Enabled = true;
                }
                //FinishProgress();
                
                //btnViewReportSet.Enabled = true;

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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!_IsWeekly)
            {
                //set checkbox in task
                VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "reviewreports");
            }
        }

        private void btnPrintReportSet_Click(object sender, EventArgs e)
        {
			VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled = false;
			//get the count of selected rows and drop each starting at the dropIndex
            //this.Cursor = Cursors.WaitCursor;
            try
            {
                //pf = new VWA4Common.ProgressForm();
                //pf.SetupAndShow(this.ParentForm, "Printing Reports", "Creating Report List...", true, true);
                int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
                int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;

                

                VWA4Common.ProgressDialog.ShowProgressDialog("Looking for Reports' Names.", "", "", pd_left, pd_top);

                frmReportViewer frmReports = new frmReportViewer();
                frmReportViewer frmViewWaste = new frmReportViewer();

                VWA4Common.ProgressDialog.SetLeadin("Report List created");
                VWA4Common.ProgressDialog.SetLeadin("Report List inited");
                bool isViewWaste = false, isReports = false;

                btnPrintReportSet.Enabled = false;

                int nRows = 0, nReports = 1;

                if (ultraGrid1.Selected.Rows.Count > 0)
                    nRows = ultraGrid1.Selected.Rows.Count;
                else
                    nRows = ultraGrid1.Rows.Count;

                double progressTick = (nRows > 0 ? 100 / nRows : 1);
                VWA4Common.ProgressDialog.SetLeadin("Generating Reports");
                try
                {
                    if (ultraGrid1.Selected.Rows.Count > 0)
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
                        {
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                            if (VWA4Common.ProgressDialog.CancelPressed)
                            {
                                VWA4Common.ProgressDialog.CancelPressed = false;

                                btnPrintReportSet.Enabled = true;
                                return;
                            }

                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPrint(id);
                                isViewWaste = true;
                            }
                            else
                            {
                                frmReports.AddPrint(id, true);
                                isReports = true;
                            }
                            nReports++;

                        }
                    }
                    else
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Rows)
                        {
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));

                            if (VWA4Common.ProgressDialog.CancelPressed)
                            {
                                VWA4Common.ProgressDialog.CancelPressed = false;

                                btnPrintReportSet.Enabled = true;
                                return;
                            }

                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPrint(id);
                                isViewWaste = true;
                            }
                            else
                            {
                                frmReports.AddPrint(id, true);
                                isReports = true;
                            }
                            nReports++;
                        }
                    }

                    //FinishProgress();

                    
                }
                finally
                {
                    FinishProgress();
                    btnPrintReportSet.Enabled = true;
                }

                //this.Cursor = Cursors.Default;
                if (isReports)
                    frmReports.Print();
                if (isViewWaste)
                    frmViewWaste.Print();
                if (_IsWeekly)
                {
                    //set checkbox in task
                    VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                    utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "printweeklyreports");
                }
                
                
			}
			catch (Exception ex)
			{
				//Note cancellation throws an exception
				MessageBox.Show(ex.Message);
			}
        
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            DialogResult result = ShowSavePDF();
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            try
            {
                //pf = new VWA4Common.ProgressForm();
                //pf.SetupAndShow(this.ParentForm, "Converting Reports to PDF", "Creating Report List...", true, true);
                int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
                int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;

                
                VWA4Common.ProgressDialog.ShowProgressDialog("Looking for Reports' Names.", "", "", pd_left, pd_top);
                VWA4Common.ProgressDialog.SetLeadin("Report List created");

                frmReportViewer frmReports = new frmReportViewer();
                frmReportViewer frmViewWaste = new frmReportViewer();
                bool isViewWaste = false, isReports = false;
                //this.Cursor = Cursors.WaitCursor;

                btnPDF.Enabled = false;

                int nRows = 0, nReports = 1;

                if (ultraGrid1.Selected.Rows.Count > 0)
                    nRows = ultraGrid1.Selected.Rows.Count;
                else
                    nRows = ultraGrid1.Rows.Count;

                double progressTick = (nRows > 0 ? 100 / nRows : 1);
                VWA4Common.ProgressDialog.SetLeadin("Generating Reports");
                try
                {
                    //get the count of selected rows and drop each starting at the dropIndex
                    if (ultraGrid1.Selected.Rows.Count > 0)
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Selected.Rows)
                        {
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                            if (VWA4Common.ProgressDialog.CancelPressed)
                            {
                                VWA4Common.ProgressDialog.CancelPressed = false;
                                
                                btnPDF.Enabled = true;
                                return;
                            }
                            
                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPDF(id);
                                isViewWaste = true;
                            }
                            else
                            {
                                frmReports.AddPDF(id, true);
                                isReports = true;
                            }
                            nReports++;
                        }
                    }
                    else
                    {
                        foreach (UltraGridRow aRow in ultraGrid1.Rows)
                        {
                            VWA4Common.ProgressDialog.SetStatus("Generating report " + nReports + " of " + nRows, (int)(nReports * progressTick));
                            if (VWA4Common.ProgressDialog.CancelPressed)
                            {
                                VWA4Common.ProgressDialog.CancelPressed = false;
                                
                                btnPDF.Enabled = true;
                                return;
                            }
                            
                            int id = int.Parse(aRow.Cells["ReportMemorized.ID"].Value.ToString());
                            if (aRow.Cells["ReportType"].Value.ToString() == "View Waste")
                            {
                                frmViewWaste.AddPDF(id);
                                isViewWaste = true;
                            }
                            else
                            {
                                frmReports.AddPDF(id, true);
                                isReports = true;
                            }
                            nReports++;
                        }
                    }
                    
                }
                finally
                {
                    FinishProgress();
                    btnPDF.Enabled = true;
                }
                //this.Cursor = Cursors.Default;
                //FinishProgress();
                //btnPDF.Enabled = true;
                
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
			catch (Exception ex)
			{
				//Note cancellation throws an exception
				MessageBox.Show(ex.Message);
			}
        }

        private void FinishProgress()
        {
            VWA4Common.ProgressDialog.CloseProgressForm();
        }
        private DialogResult ShowSavePDF()
        {
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "Portable Document Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            return this.saveFileDialog1.ShowDialog(this);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            commonEvents.TaskSheetKey = "dashboard";
        }

        //private void ultraGrid1_AfterRowActivate(object sender, EventArgs e)
        //{
        //    if (ultraGrid1.ActiveRow != null)
        //    {
        //        int id = int.Parse(ultraGrid1.ActiveRow.Cells["ReportSet.ID"].Value.ToString());
        //        ucViewParameters1.Reload(id);
        //    }
        //}
    }
}
