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

namespace UserControls
{
    public partial class UCLowParticipationParameters : UserControl
    {
        private DayOfWeek _ReportFirstDayOfWeek;

        public DayOfWeek ReportFirstDayOfWeek
        {
            get { return _ReportFirstDayOfWeek; }
            set 
            {
                if (_ReportFirstDayOfWeek != value)
                    if (ucComparisionParameters1.Active)
                        ucComparisionParameters1.SetFirstDayOfWeek(value);
                    
                _ReportFirstDayOfWeek = value; 
            }
        }
        public UCLowParticipationParameters()
        {
            InitializeComponent();
        }

		public void InitRunTime()
		{
			pictureBox1.Image = VWA4Common.GlobalSettings.ProductIcon.ToBitmap();
			this.panelHideParams.Visible = false;
			ucBaseParameters1.InitRunTime();
			ucBaseParameters1.SetDefaultPreconsumer("Weights.[IsPreconsumer] = 1", "Waste Type = Pre-Consumer", VWA4Common.GlobalSettings.CurrentSiteID.ToString(), VWA4Common.GlobalSettings.CurrentSiteName);
			ucComparisionParameters1.InitDefault();
			ucConfigParameters1.InitDefault();
			ucCrossTabParameters1.InitDefault();
			ucDateRangeParameters1.InitDefault();
			ucDateRangePeriodParameters1.InitDefault();
			ucDetailsParameters1.InitDefault();
			ucEmployeeParameters1.InitDefault();
			ucEmployeeTransactionsParameters1.InitDefault();
			ucFinancialParameters1.InitDefault();
			ucGoalListbyCompletionParameters1.InitDefault();
			ucLowParticipation1.InitDefault();
			ucSWATParameters1.InitRunTime();
			ucTrackerComparisionParameters1.InitDefault();
			ucTrendParameters1.InitDefault();
			ucWeeklyTabularParameters1.InitDefault();
            ucGoalWeeklyStatucParameters1.InitDefault();
			ucGoalListbyCompletionParameters1.InitDefault();
		}

		private void SetDates()
        {
            if (ucBaseParameters1.Active && ucDateRangeParameters1.Active)
            {
                ucBaseParameters1.StartDate = ucDateRangeParameters1.StartDate;
                ucBaseParameters1.EndDate = ucDateRangeParameters1.EndDate;
            }
        }
        private string _ReportType;
        
        public void SetDetails()
        {
            HideAllParameters();
            _ReportType = "Close-Up View";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucDetailsParameters1.Active = true;
            ucDetailsParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(false);
            ucTreeFilter1.Title = "Choose Report Parameter: ";
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;

            ucTreeFilter1.EnableAllRadioButtons();
        }

        public void SetConfiguration()
        {
            HideAllParameters();
            _ReportType = "Configuration";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

			//ucConfigParameters1.Active = true;
			//ucConfigParameters1.Visible = true;
			//ucConfigParameters1.BringToFront();

			ucDateRangeParameters1.Active = false;
			ucDateRangeParameters1.Visible = false;
			this.groupBox1.Visible = false;
			this.groupBox1.SendToBack();

			this.ucEmpty.Visible = true;

			//ucBaseParameters1.Active = true;
			//ucBaseParameters1.Visible = true;
			//ucBaseParameters1.HideAll();

			//ucTreeFilter1.Active = false;
			//ucTreeFilter1.Visible = true;
			//ucTreeFilter1.Title = "";

			ucConfigParameters1.Active = true;
			ucConfigParameters1.Visible = true;

			//ucDateRangeParameters1.Active = true;
			//ucDateRangeParameters1.Visible = true;

			ucBaseParameters1.Active = true;
			ucBaseParameters1.Visible = true;
			ucBaseParameters1.HideAll();

			ucTreeFilter1.Active = false;
			ucTreeFilter1.Visible = false;
        }
        public void SetCrossTab()
        {
            HideAllParameters();
            _ReportType = "Detail";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucCrossTabParameters1.Active = true;
            ucCrossTabParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.DisableRadioButtonByName(ucCrossTabParameters1.CrossTabOn);
        }
        public void SetComparision()
        {
            HideAllParameters();
            _ReportType = "Comparison";
            ucComparisionParameters1.Active = true;
            ucComparisionParameters1.Visible = true;
            ucComparisionParameters1.BringToFront();

            //ucFirstDayOfWeek1.Active = false;
            //ucFirstDayOfWeek1.Visible = false;

            ucDateRangeParameters1.Visible = false;
            ucDateRangeParameters1.Active = false;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }

        
        public void SetEmployee()
        {
            HideAllParameters();
            _ReportType = "Employee";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucEmployeeParameters1.Active = true;
            ucEmployeeParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetEmployeeRecognition()
        {
            HideAllParameters();
            _ReportType = "Employee Recognition";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucSWATParameters1.SetEmployeeRecognition();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }
        public void SetEmployeeTransactions()
        {
            HideAllParameters();
            _ReportType = "Transactions by Employee";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucEmployeeTransactionsParameters1.Active = true;
            ucEmployeeTransactionsParameters1.Visible = true;

            //ucDateRangePeriodParameters1.Active = true;
            //ucDateRangePeriodParameters1.Visible = true;

            ucDateRangeParameters1.Active = false;
            ucDateRangeParameters1.Visible = false;
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";
        }
        public void SetEventOrders()
        {
            HideAllParameters();
            _ReportType = "Event Orders";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucSWATParameters1.SetEmployeeRecognition();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;

            //ucDateRangeParameters1.Active = true;
            //ucDateRangeParameters1.Visible = true;

            ucDateRangePeriodParameters1.Active = true;
            ucDateRangePeriodParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetFinancial(string reportName)
        {
            HideAllParameters();
            _ReportType = reportName;
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucFinancialParameters1.Active = true;
            ucFinancialParameters1.Visible = true;

            ucDateRangeParameters1.Active = false;
            ucDateRangeParameters1.Visible = false;
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }

        public void SetGoalWeeklyStatus()
        {
            HideAllParameters();
            _ReportType = "Goal Weekly Status";
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.GoalHideAll();
            ucBaseParameters1.ShowWasteClasses(false);

            ucGoalHistoryParameters1.Active = false;
            ucGoalHistoryParameters1.Visible = false;

            ucGoalWeeklyStatucParameters1.Active = true;
            ucGoalWeeklyStatucParameters1.Visible = true;
            
            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }

        public void SetGoalList()
        {
            HideAllParameters();
            _ReportType = "Goal List";
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.GoalHideAll();
            ucBaseParameters1.ShowWasteClasses(false);

            ucGoalHistoryParameters1.Active = false;
            ucGoalHistoryParameters1.Visible = false;

            ucGoalWeeklyStatucParameters1.Active = true;
            ucGoalWeeklyStatucParameters1.Visible = true;
            
            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }

        public void SetGoalHistory()
        {
            HideAllParameters();
            _ReportType = "Goal History";
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.GoalHideAll();
            ucBaseParameters1.ShowWasteClasses(false);

            ucGoalHistoryParameters1.Active = true;
            ucGoalHistoryParameters1.Visible = true;

            ucGoalWeeklyStatucParameters1.Active = false;
            ucGoalWeeklyStatucParameters1.Visible = false;

            this.Height = 331;

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }

        public void SetGoalProgress()
        {
            HideAllParameters();
            _ReportType = "Goal Progress";
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.GoalHideAll();
            ucBaseParameters1.ShowWasteClasses(false);

            ucGoalHistoryParameters1.Active = true;
            ucGoalHistoryParameters1.Visible = true;

            this.Height = 331;

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }

		public void SetGoalsListbyCompletionPercent()
		{
			HideAllParameters();
			_ReportType = "Goal List by Completion Percent";
			this.groupBox1.Visible = false;
			this.groupBox1.SendToBack();

			ucBaseParameters1.Active = true;
			ucBaseParameters1.Visible = true;
			ucBaseParameters1.GoalHideAll();
			ucBaseParameters1.ShowWasteClasses(false);

		    ucGoalHistoryParameters1.Active = false;
		    ucGoalHistoryParameters1.Visible = false;

		    ucGoalWeeklyStatucParameters1.Active = false;
		    ucGoalWeeklyStatucParameters1.Visible = false;

			ucGoalListbyCompletionParameters1.Active = true;
			ucGoalListbyCompletionParameters1.Visible = true;

			ucTreeFilter1.Active = false;
			ucTreeFilter1.Visible = false;
			ucTreeFilter1.Title = "";
		}

        
        public void SetLowParticipation()
        {
            HideAllParameters();
            _ReportType = "Low Participation";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;
            
            ucLowParticipation1.Active = true;
            ucLowParticipation1.Visible = true;

            //ucDateRangeParameters1.Active = true;
            //ucDateRangeParameters1.Visible = true;

            ucDateRangePeriodParameters1.Active = true;
            ucDateRangePeriodParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.HideLbs();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetPreShiftMeeting()
        {
            HideAllParameters();
            _ReportType = "Staff Mtg. Agenda";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucSWATParameters1.SetPreShiftMeeting();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }
        public void SetProducedItems()
        {
            HideAllParameters();
            _ReportType = "Produced Items";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucSWATParameters1.SetEmployeeRecognition();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;

            //ucDateRangeParameters1.Active = true;
            //ucDateRangeParameters1.Visible = true;

            ucDateRangePeriodParameters1.Active = true;
            ucDateRangePeriodParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetSWATForm()
        {
            HideAllParameters();
            _ReportType = "SWAT Agenda";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucSWATParameters1.SetSWAT();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }
        public void SetSWATNotes()
        {
            HideAllParameters();
            _ReportType = "SWAT Notes";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = true;

            ucSWATParameters1.SetSWATNotes();
            ucSWATParameters1.Active = true;
            ucSWATParameters1.Visible = true;
            ucSWATParameters1.Size = new System.Drawing.Size(566, 77);
            ucSWATParameters1.BringToFront();

            ucDateRangeParameters1.Active = false;
            ucDateRangeParameters1.Visible = false;
            this.groupBox1.Visible = false;
            this.groupBox1.SendToBack();

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Title = "";
        }
        public void SetSWATNotesStart(DateTime dt)
        {
            ucSWATParameters1.SetSWATNotesStart(dt);
        }
        public void SetTrackerComparison()
        {
            HideAllParameters();
            _ReportType = "Tracker Comparison";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucTrackerComparisionParameters1.Active = true;
            ucTrackerComparisionParameters1.Visible = true;

            //ucDateRangeParameters1.Active = true;
            //ucDateRangeParameters1.Visible = true;

            ucDateRangePeriodParameters1.Active = true;
            ucDateRangePeriodParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            SetDates();
            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetTrend()
        {
            HideAllParameters();
            _ReportType = "Trend";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucTrendParameters1.Active = true;
            ucTrendParameters1.Visible = true;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            SetDates();
            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetTransfers()
        {
            HideAllParameters();
            _ReportType = "Transfers";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            ucDateRangeParameters1.Active = true;
            ucDateRangeParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.HideAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";
        }
        public void SetWasteAvoidance()
        {
            HideAllParameters();
            _ReportType = "Waste Avoidance";
            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

           
            //ucWasteAvoidanceParameters1.Active = true;
            //ucWasteAvoidanceParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.Title = "Additional Filters:";
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;

            ucTreeFilter1.EnableAllRadioButtons();
        }
        public void SetWeeklyTabular()
        {
            HideAllParameters();
            _ReportType = "Weekly Tabular";

            //ucFirstDayOfWeek1.Active = true;
            //ucFirstDayOfWeek1.Visible = false;

            //ucDateRangeParameters1.Active = true;
            //ucDateRangeParameters1.Visible = true;

            ucDateRangePeriodParameters1.Active = true;
            ucDateRangePeriodParameters1.Visible = true;

            ucWeeklyTabularParameters1.Active = true;
            ucWeeklyTabularParameters1.Visible = true;

            ucBaseParameters1.Active = true;
            ucBaseParameters1.Visible = true;
            ucBaseParameters1.ShowAll();
            ucBaseParameters1.Hide3D();
            ucBaseParameters1.HideHorisontal();
            ucBaseParameters1.ShowWasteClasses(true);

            ucTreeFilter1.ShowCheckBoxes(true);
            ucTreeFilter1.Active = true;
            ucTreeFilter1.Visible = true;
            ucTreeFilter1.Title = "Additional Filters: ";

            ucTreeFilter1.EnableAllRadioButtons();
        }

        public void SetViewWaste()
        {
            HideAllParameters();
            _ReportType = "View Waste";
        }

        
        private void HideAllParameters()
        {
            _ReportType = "";
            _IsAdvancedFilter = false;

            ucBaseParameters1.Active = false;
            ucBaseParameters1.Visible = false;
            ucBaseParameters1.ShowWasteClasses(false);

            ucComparisionParameters1.Active = false;
            ucComparisionParameters1.Visible = false;

            ucConfigParameters1.Active = false;
            ucConfigParameters1.Visible = false;
            ucConfigParameters1.SendToBack();

            ucCrossTabParameters1.Active = false;
            ucCrossTabParameters1.Visible = false;

            ucDateRangeParameters1.Active = false;
            ucDateRangeParameters1.Visible = false;

            ucDateRangePeriodParameters1.Active = false;
            ucDateRangePeriodParameters1.Visible = false;

            ucDetailsParameters1.Active = false;
            ucDetailsParameters1.Visible = false;

            ucEmployeeParameters1.Active = false;
            ucEmployeeParameters1.Visible = false;

            ucEmployeeTransactionsParameters1.Active = false;
            ucEmployeeTransactionsParameters1.Visible = false;
            ucEmployeeTransactionsParameters1.SendToBack();

            ucFinancialParameters1.Active = false;
            ucFinancialParameters1.Visible = false;

			ucGoalListbyCompletionParameters1.Active = false;
			ucGoalListbyCompletionParameters1.Visible = false;

            ucLowParticipation1.Active = false;
            ucLowParticipation1.Visible = false;

            ucSWATParameters1.Active = false;
            ucSWATParameters1.Visible = false;
            this.ucSWATParameters1.Size = new System.Drawing.Size(251, 77);

            ucTrackerComparisionParameters1.Active = false;
            ucTrackerComparisionParameters1.Visible = false;

            ucTreeFilter1.Active = false;
            ucTreeFilter1.Visible = false;
            ucTreeFilter1.Clear();

            ucTrendParameters1.Active = false;
            ucTrendParameters1.Visible = false;

            ucWeeklyTabularParameters1.Active = false;
            ucWeeklyTabularParameters1.Visible = false;

			this.ucEmpty.Visible = false;
            this.groupBox1.Visible = true ;
        }

        public class HideEventArgs : EventArgs
        {
            private int height;
            private bool isHide;

            public bool IsHide
            {
                get { return isHide; }
                set { isHide = value; }
            }
            public int Height
            {
                get { return height; }
                set { height = value; }
            }
        }
        public void HideParameters(bool isHide)
        {
            if (isHide)
            {
                panelParams.Hide();
                panelHideParams.Show();
                popupShowHide.Items[0].Text = "Show Parameters";
                SetHide(16, false);
            }
            else
            {
                panelParams.Show();
                panelHideParams.Hide();
                popupShowHide.Items[0].Text = "Hide Parameters";
                SetHide(254, true);
            }
            shown = !isHide;
        }
        public delegate void HideEventHandler(object sender, HideEventArgs e);
        private HideEventHandler hideParams;
        public event HideEventHandler HideParams
        {
            add { hideParams += value; }
            remove { hideParams -= value; }
        }
        public void SetHide(int height, bool isHide)
        {
            HideEventArgs e = new HideEventArgs();
            e.Height = height;
            e.IsHide = isHide;
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
            HideParameters(shown);
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

        private void ucBaseParameters1_ExportPDF(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportPDF();
        }

        public delegate void ExportRTFEventHandler(object sender, EventArgs e);
        private ExportRTFEventHandler exportRTF;
        public event ExportRTFEventHandler ExportRTF
        {
            add { exportRTF += value; }
            remove { exportRTF -= value; }
        }
        public void SetExportRTF()
        {
            OnExportRTF(EventArgs.Empty);
        }
        protected virtual void OnExportRTF(EventArgs e)
        {
            if (exportRTF != null)
                exportRTF(this, e);
        }

        private void ucBaseParameters1_ExportRTF(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportRTF();
        }


        private void ucBaseParameters1_ViewReport(object sender, EventArgs e)
        {
            if (CheckControl(this))
            {
                if (sender != null)
                    SetViewReport();
            }
            else
                MessageBox.Show(this, "Not all parameters set for the report!", "Input Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool CheckControl(Control paramControl)
        {
            bool check = true;
            foreach (Control childControl in paramControl.Controls)
                if (childControl is IReportParameters)
                {
                    if (((IReportParameters)childControl).Active)
                        check &= ((IReportParameters)childControl).IsValid();
                }
                else
                    check &= CheckControl(childControl);
        
            return check;
        }

        private void ucBaseParameters1_Filter(object sender, UserControls.UCBaseParameters.FilterEventArgs e)
        {
            if (ucDateRangeParameters1.Active && !e.Empty)
            {
                if(e.StartDate != new DateTime(0))
                    ucDateRangeParameters1.StartDate = e.StartDate;
                if (e.EndDate != new DateTime(0))
                    ucDateRangeParameters1.EndDate = e.EndDate;
            }
            ucTreeFilter1.SetTreeFilter(e.ReportFilter);
            _IsAdvancedFilter = true;
        }

        private Hashtable GetControlParams(Control paramControl)
        {
            ReportParameters param = new ReportParameters();
            foreach (Control cntrl in paramControl.Controls)
                if (cntrl is IReportParameters)
                {
                    if ((cntrl as IReportParameters).Active)
                        param.AddParameters((cntrl as IReportParameters).ParamList);
                }
                else
                    param.AddParameters(GetControlParams(cntrl));

            return param.ParamList;
        }
        private void SetControlParams(Control paramControl, ReportParameters param)
        {
            foreach (Control cntrl in paramControl.Controls)
                if (cntrl is IReportParameters)
                {
                    if ((cntrl as IReportParameters).Active)
                        if (param != null)
                            (cntrl as IReportParameters).HashLoad(param.ParamList);
                        else
                            (cntrl as IReportParameters).InitDefault();
                }
                else
                    SetControlParams(cntrl, param);
               
        }
        private bool _IsAdvancedFilter = false;
        public ReportParameters ReportParameters
        {
            get
            {
                ReportParameters param = new ReportParameters();
                param.AddParameters(GetControlParams(this));
                    
                string filter = "", displayFilter = "", treeFilter = "", periodFilter = "", displayPeriod = "", displayTree = "";
                if (param["TreeFilter"] != null && VWA4Common.VWACommon.NotNullOrEmpty(param["TreeFilter"].ParamValue))
                {
                    treeFilter = param["TreeFilter"].ParamValue;
                    displayTree = param["TreeFilter"].DisplayValue;
                }

                if (param["Filter"] != null && VWA4Common.VWACommon.NotNullOrEmpty(param["Filter"].ParamValue))
                {
                    filter = param["Filter"].ParamValue;
                    displayFilter = param["Filter"].DisplayValue;
                }

                if (treeFilter != "")
                {
                    filter = Regex.Replace(filter, treeFilter.Replace("(", "\\(").Replace(")", "\\)"), "", RegexOptions.IgnoreCase);//remove tree filter from filter before join
                    filter = VWA4Common.VWACommon.RemoveEmpty(filter);

                    displayFilter = Regex.Replace(displayFilter, displayTree.Replace("(", "\\(").Replace(")", "\\)"), "", RegexOptions.IgnoreCase);//remove tree filter from filter before join;
                    displayFilter = VWA4Common.VWACommon.RemoveEmpty(displayFilter);
                }

                if (filter == "" && _ReportType != "Weekly Tabular" && !_IsAdvancedFilter)
                {
                    filter = "Weights.IsPreconsumer = 1"; // default setting to be only pre-consumer for all reports if user didn't set any filters
                    displayFilter = "Pre-Consumer Waste";
                }

                if (treeFilter != "")
                {
                    if (filter != "")
                    {
                        filter = "(" + filter + ") AND (" + treeFilter + ")";
                        displayFilter = "(" + displayFilter + ") AND (" + displayTree + ")";
                    }
                    else
                    {
                        filter = treeFilter;
                        displayFilter = displayTree;
                    }
                }

                bool isPeriodSet = (param["StartDate"] != null && VWA4Common.VWACommon.NotNullOrEmpty(param["StartDate"].ParamValue)) && 
                    param["EndDate"] != null && VWA4Common.VWACommon.NotNullOrEmpty(param["EndDate"].ParamValue);
                DateTime startDate, endDate;
                if (isPeriodSet)
                {
                    startDate = DateTime.Parse(param["StartDate"].ParamValue);
                    endDate = DateTime.Parse(param["EndDate"].ParamValue);
                    periodFilter = "[Weights.Timestamp] >= #" + VWA4Common.VWACommon.DateToString(startDate) + "# AND [Weights.Timestamp] < #" +
                        VWA4Common.VWACommon.DateToString(endDate) + "#";
                    displayPeriod = "Timestamp >= " + VWA4Common.VWACommon.DateToString(startDate) + " AND Timestamp < " +
                        VWA4Common.VWACommon.DateToString(endDate);

                    filter = VWA4Common.VWACommon.RemoveFilterPeriod(filter);
					displayFilter = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(displayFilter);
					
                
                    if(filter!= "")
                    {
                        filter = "(" + filter + ") AND (" + periodFilter + ")";
                        displayFilter = displayFilter + " AND (" + displayPeriod + ")";
                    }
                    else
                    {
                        filter = periodFilter;
                        displayFilter = displayPeriod;
                    }
                }
                //string wasteClass = ucBaseParameters1.GetWasteLevelClasses();
                //if (wasteClass != "")
                //{ 
                //}

                param["Filter"].ParamValue = filter;
                param["Filter"].DisplayValue = displayFilter;
                
                return param;
            }
            set
            {
                SetControlParams(this, value);
            }
        }

        private void ucDateRangeParameters1_StartDateChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (_ReportType == "Close-Up View" && ucBaseParameters1.StartDate != new DateTime(0))
                ucDetailsParameters1.ResetTimeFrame();

            if (ucBaseParameters1.Active)
                ucBaseParameters1.StartDate = e.Date;

            else if (_ReportType == "Staff Mtg. Agenda" || _ReportType == "SWAT Agenda")
                ucDateRangeParameters1.EndDate = e.Date.AddDays(7);
        }

        private void ucDateRangeParameters1_EndDateChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (ucBaseParameters1.Active)
                ucBaseParameters1.EndDate = e.Date;
        }

        private void ucDateRangePeriodParameters1_StartDateChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (_ReportType == "Close-Up View" && ucBaseParameters1.StartDate != new DateTime(0))
                ucDetailsParameters1.ResetTimeFrame();

            if (ucBaseParameters1.Active)
                ucBaseParameters1.StartDate = e.Date;
            
        }

        private void ucDateRangePeriodParameters1_EndDateChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (ucBaseParameters1.Active)
                ucBaseParameters1.EndDate = e.Date;
        }

        private void ucTreeFilter1_TreeFilterChanged(object sender, UserControls.UCTreeFilter.TreeFiltersEventArgs e)
        {
            ReportFirstDayOfWeek = VWA4Common.VWACommon.StringToDayOfWeek(VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(e.SiteID.ToString())));
            if (ucBaseParameters1.Active)//tree filter not set for details report
            {
                if (_ReportType != "Close-Up View")
                    ucBaseParameters1.SetTreeFilters(e.TreeFilters, e.DisplayTreeFilters, e.SiteID, e.SiteName);
                else // if (_ReportType == "Close-Up View")
                {
                    string type = "", id = "", display = "";
                    if (this.ucTreeFilter1.GetTreeItem(ref type, ref id, ref display))
                    {
                        ucDetailsParameters1.SetDetailsParams(type, id, display);
                    }
					//else
						//MessageBox.Show(this, "No parameters for detail report was chosen! Please select one of Food Type or Loss Type, etc.",
						//    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucFinancialParameters1_SiteIDChanged(object sender, UserControls.UCSiteChooser.SiteEventArgs e)
        {
            if (ucBaseParameters1.Active)//tree filter not set for details report
            {
                ucBaseParameters1.SetTreeFilters("", "", e.SiteID, e.SiteName);
            }
            ReportFirstDayOfWeek = VWA4Common.VWACommon.StringToDayOfWeek(VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(e.SiteID.ToString())));
        }

        private void ucBaseParameters1_SaveParameters(object sender, EventArgs e)
        {
            if (CheckControl(this))
            {
                ReportParameter par = ucBaseParameters1.ParamList["ReportID"] as ReportParameter;
                if (int.Parse(((ReportParameter)ucBaseParameters1.ParamList["ReportID"]).ParamValue) < 0 ||
                    (new frmSaveAs("Save Report As", "Do you want to save as a new report?", "Save As", "Save")).ShowDialog() == DialogResult.OK)
                {
                    MemorizedReports frm = new MemorizedReports(_ReportType, true);
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                        this.ReportParameters.SaveDB(frm.ID);
                    ((ReportParameter)ucBaseParameters1.ParamList["ReportID"]).ParamValue = frm.ID.ToString();
                    ((ReportParameter)ucBaseParameters1.ParamList["ReportID"]).DisplayValue = frm.ID.ToString();
                    SetTitleChanged(frm.Title, _ReportType);
                }
                else
                    this.ReportParameters.SaveDB(int.Parse(((ReportParameter)ucBaseParameters1.ParamList["ReportID"]).ParamValue));
            }
            else
                MessageBox.Show(this, "Error in input parameters: not all parameters set", "User Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ucBaseParameters1_LoadParameters(object sender, EventArgs e)
        {
            MemorizedReports dlg = new MemorizedReports(_ReportType, false);
            dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadParameters(dlg.ID);
                    ucBaseParameters1_ViewReport(sender, e); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in loading report: " + ex.Message, "Project Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int _currID = -1;
        public void ClearTitle()
        {
            SetTitleChanged("", _ReportType);
        }
        public void CorrectWeekly(ref ReportParameters parameters)
        {
            DateTime weekStart = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
            TimeSpan diff;
            ReportParameter parameter;
            foreach (String key in parameters.ParamList.Keys)
            {
                ReportParameter param = (ReportParameter)parameters.ParamList[key];
                switch (param.Name)
                {
                    case "EndDate":
                        diff = DateTime.Parse(param.ParamValue).Subtract(weekStart.AddDays(7));
                        param.ParamValue = weekStart.AddDays(7).ToString("yyyy/MM/dd HH:mm:ss");
                        param.DisplayValue = weekStart.AddDays(7).ToString("MM/dd/yyyy hh:mm:ss tt");
                        parameter = (ReportParameter)parameters.ParamList["StartDate"];
                        parameter.ParamValue = DateTime.Parse(parameter.ParamValue).Subtract(diff).ToString("yyyy/MM/dd HH:mm:ss");
                        parameter.DisplayValue = DateTime.Parse(parameter.ParamValue).Subtract(diff).ToString("MM/dd/yyyy hh:mm:ss tt");
                        break;
                    case "SWATDate": 
                        param.ParamValue = weekStart.AddDays(5).ToString("yyyy/MM/dd HH:mm:ss");
                        param.DisplayValue = weekStart.AddDays(5).ToString("MM/dd/yyyy hh:mm:ss tt");
                        break;
                    case "PeriodStartDate": //financial parameter
                        parameter = (ReportParameter)parameters.ParamList["NumberOfWeeks"];
                        if (parameter != null)
                        {
                            param.ParamValue = weekStart.AddDays(-7 * int.Parse(parameter.ParamValue)).ToString("yyyy/MM/dd HH:mm:ss");
                            param.DisplayValue = weekStart.AddDays(-7 * int.Parse(parameter.ParamValue)).ToString("MM/dd/yyyy hh:mm:ss tt");
                        }
                        break;
                    //case "Filter": //should correct himself
                    //    param.ParamValue = ;
                    //    param.DisplayValue = ;
                    //    break;

                        // User should set Recent week so report reloads
                    //case "FirstWeekStart": 
                    //    diff = DateTime.Parse(param.ParamValue).Subtract(weekStart);
                    //    param.ParamValue = weekStart.ToString("yyyy/MM/dd hh:mm:ss");
                    //    param.DisplayValue = weekStart.ToString("MM/dd/yyyy hh:mm:ss");
                    //    ReportParameter parameter2 = (ReportParameter)parameters.ParamList["SecondWeekStart"];
                    //    parameter2.ParamValue = DateTime.Parse(parameter2.ParamValue).Subtract(diff).ToString("yyyy/MM/dd hh:mm:ss");
                    //    parameter2.DisplayValue = DateTime.Parse(parameter2.ParamValue).Subtract(diff).ToString("MM/dd/yyyy hh:mm:ss");
                    //    break;
                    default: 
                        break;
                }
            }
        }
        public void LoadParameters(int id)
        {
            LoadParameters(id, false);
        }
        public void LoadParameters(int id, bool isCorrectWeekly)
        {
            try
            {
                ReportParameters parameter = new ReportParameters();
                parameter.LoadDB(id);
                if (isCorrectWeekly)
                    CorrectWeekly(ref parameter);
                this.ReportParameters = parameter;
                if (_ReportType == "Close-Up View")
                    ucTreeFilter1.SetTreeID(((ReportParameter)parameter["DetailsParameter"]).ParamValue);
                else if (parameter["TreeFilter"] != null && parameter["TreeFilter"].ParamValue != "")
                    ucBaseParameters1.SetTreeFilters(parameter["TreeFilter"].ParamValue, parameter["TreeFilter"].DisplayValue, parameter["SiteID"].ParamValue, parameter["SiteID"].DisplayValue);
                if (parameter["Filter"] != null && parameter["Filter"].ParamValue != "")
                {
                    string filter = parameter["Filter"].ParamValue, displayFilter = parameter["Filter"].DisplayValue;
                    filter = VWA4Common.VWACommon.ExtractStringPreconsumerFilter(filter, out displayFilter);
                    if(filter != "")
                        ucBaseParameters1.SetDefaultPreconsumer(filter, displayFilter, parameter["SiteID"].ParamValue, parameter["SiteID"].DisplayValue);
                
                }
                _currID = id;
                
                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportMemorized WHERE ID = " + id);
                if(dt != null && dt.Rows.Count > 0)
                    SetTitleChanged(dt.Rows[0]["Title"].ToString(), dt.Rows[0]["ReportType"].ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in loading report: " + ex.Message, "Project Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void ucFirstDayOfWeek1_FirstDayOfWeekChanged(object sender, UCFirstDayOfWeek.FirstDayOfWeekChangedEventArgs e)
        //{
        //    ucDateRangeParameters1.SetFirstDayOfWeek(e.FirstDayOfWeek);
        //}
        public bool GetTreeItem(ref string type, ref string value, ref string display)
        {
            return ucTreeFilter1.GetTreeItem(ref type, ref value, ref display);
        }

        private void ucDetailsParameters1_TimeFrameChanged(object sender, UCDetailsParameters.TimeFrameChangedEventArgs e)
        {
            ucDateRangeParameters1.StartDate = e.StartDate.AddDays(_ReportFirstDayOfWeek - e.StartDate.DayOfWeek);
            ucDateRangeParameters1.EndDate = e.EndDate.AddDays(_ReportFirstDayOfWeek - e.StartDate.DayOfWeek);
        }

        private void ucComparisionParameters1_ComparisionTypeChanged(object sender, UCComparisionParameters.ComparisionTypeChangedEventArgs e)
        {
            ucTreeFilter1.DisableRadioButtonByName(e.ComparisionType);
        }
        private void ucCrossTabParameters1_CrossTabOnChanged(object sender, UserControls.UCCrossTabParameters.CrossTabOnChangedEventArgs e)
        {
            ucTreeFilter1.DisableRadioButtonByName(e.CrossTabOn);
        }
		private void ucCrossTabParameters1_RecentWeeksChecked(object sender, UserControls.UCCrossTabParameters.RecentWeeksCheckedEventArgs e)
		{
			ucDateRangeParameters1.EndDate = e.EndDate;
			ucDateRangeParameters1.StartDate = e.StartDate;
		}

        public void SetDatesToCurrentWeek()
        {
            ucDateRangeParameters1.StartDate = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
            ucDateRangeParameters1.EndDate = ucDateRangeParameters1.StartDate.AddDays(7);
        }
        public void SetCurrentSite()
        {
            ucBaseParameters1.SetDefaultPreconsumer("IsPreconsumer = 1", "Waste Type = Pre-Consumer", VWA4Common.GlobalSettings.CurrentSiteID.ToString(), VWA4Common.GlobalSettings.CurrentSiteName);
        }

        public delegate void TitleChangedEventHandler(object sender, VWA4Common.VWACommon.TitleEventArgs e);
        private TitleChangedEventHandler titleChangedParams;
        public event TitleChangedEventHandler TitleChanged
        {
            add { titleChangedParams += value; }
            remove { titleChangedParams -= value; }
        }
        public void SetTitleChanged(string newTitle, string reportType)
        {
            VWA4Common.VWACommon.TitleEventArgs e = new VWA4Common.VWACommon.TitleEventArgs();
            e.Title = newTitle;
            e.ReportType = reportType;
            OnTitleChanged(e);
        }
        protected virtual void OnTitleChanged(VWA4Common.VWACommon.TitleEventArgs e)
        {
            if (titleChangedParams != null)
                titleChangedParams(this, e);
        }
    }
}
