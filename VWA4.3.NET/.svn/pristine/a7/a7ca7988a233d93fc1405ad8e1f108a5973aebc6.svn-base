using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Reports
{
    public partial class UCStoredReports : UserControl, UserControls.IVWAUserControlBase
    {
        DataTable _Reports = new DataTable();
        private UserControls.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
        public UCStoredReports()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
            _Reports = UserControls.VWADBUtils.MemorizedReports();
            ultraGrid1.DataSource = _Reports;
        }

        public void Init(DateTime firstDayOfWeek) //display
        {
            if (dbDetector == null)
            {
                dbDetector = UserControls.DBDetector.GetDBDetector();
                dbDetector.DBPathChanged += new UserControls.DBDetectorEventHandler(dbDetector_PathChanged);
                //dbDetector.WeekChanged += new UserControls.DBDetectorEventHandler(dbDetector_WeekChanged);
            }
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.WeekChanged += new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
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
            _IsActive = false;
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ConfigXML"].Hidden = true;
            e.Layout.Bands[0].Columns["ID"].Hidden = true;
            e.Layout.Bands[0].Columns["Title"].CellActivation = Activation.ActivateOnly;
            e.Layout.Bands[0].Columns["Title"].Width = 284;
            e.Layout.Bands[0].Columns["Title"].SortIndicator = SortIndicator.Ascending;

            e.Layout.Bands[0].Columns["CreatedDate"].Header.Caption = "Created On";
            e.Layout.Bands[0].Columns["CreatedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["CreatedDate"].EditorControl = ultraCalendarCombo1;
            e.Layout.Bands[0].Columns["ModifiedDate"].Header.Caption = "Modified On";
            e.Layout.Bands[0].Columns["ModifiedDate"].Format = "MM/dd/yy";
            e.Layout.Bands[0].Columns["ModifiedDate"].EditorControl = ultraCalendarCombo1;

            e.Layout.Bands[0].Columns["CreatedDate"].CellActivation = Activation.Disabled;
            e.Layout.Bands[0].Columns["ModifiedDate"].CellActivation = Activation.Disabled;

            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.FilterUIType = FilterUIType.HeaderIcons;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance.Reset();
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance.Reset();
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            UltraGridColumn col = e.Layout.Bands[0].Columns["ReportType"];
            e.Layout.Bands[0].SortedColumns.Add(col, false);
            this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);
        }

        void dbDetector_PathChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        void trackerDetector_WeekChanged(object sender, EventArgs e)
        {
            //TODO: what to do if week changed?
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                int id = int.Parse(this.ultraGrid1.ActiveRow.Cells["ID"].Value.ToString());
                frmReportViewer frm = new frmReportViewer();
                frm.View(id);
                frm.ShowDialog();
            }
            LoadData();
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            
            if (ultraGrid1.ActiveRow != null)
            {
                DialogResult result = ShowSavePDF();
                if (result == DialogResult.Cancel)
                    return;
                string fileName = this.saveFileDialog1.FileName;
                int id = int.Parse(this.ultraGrid1.ActiveRow.Cells["ID"].Value.ToString());
                frmReportViewer frm = new frmReportViewer();
                frm.ShowPDF(id, fileName);
                frm.ShowDialog();
            }
        }
        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            btnView_Click(sender, e);
        }

        private void ultraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                int id = int.Parse(ultraGrid1.ActiveRow.Cells["ID"].Value.ToString());
                ucViewParameters1.ReloadReport(id);
            }
        }

        private DialogResult ShowSavePDF()
        {
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "Portable Document Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            return this.saveFileDialog1.ShowDialog(this);
        }
    }
}
