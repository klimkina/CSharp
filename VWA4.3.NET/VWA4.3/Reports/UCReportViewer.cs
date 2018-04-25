using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Documents.Report;
using System.IO;

namespace Reports
{
    public partial class UCReportViewer : UserControl, UserControls.IVWAUserControlBase
    {
		private VWA4Common.CommonEvents commonEvents = null;
		private bool _progressCancelled;
		private string _ReportType;

        public string ReportType
        {
            get { return _ReportType; }
            set 
            { 
                _ReportType = value;
                switch (_ReportType)//for old report type name's compatibility
                {
                    case "Rankings":
                        _ReportType = "Close-Up View";
                        break;
                    case "Pre-Shift Meeting":
                        _ReportType = "Staff Mtg. Agenda";
                        break;
                    case "SWAT Form":
                        _ReportType = "SWAT Agenda";
                        break;
                    default:
                        break;
                }
            }
        }
        private int _ReportID = -1;

        public UCReportViewer()
        {
            InitializeComponent();
		}

		public void InitReportViewerRunTime()
		{

			cbChooseReportType.Items.Clear();
			cbChooseReportType.Items.Add("Budget to Actual Comparison");
			cbChooseReportType.Items.Add("Close-Up View");
			cbChooseReportType.Items.Add("Comparison");
			cbChooseReportType.Items.Add("Detail");
			cbChooseReportType.Items.Add("Employee");
			cbChooseReportType.Items.Add("Employee Recognition");
			cbChooseReportType.Items.Add("Event Orders");
			cbChooseReportType.Items.Add("Financial Summary");
			cbChooseReportType.Items.Add("Goal List by Completion Percent");
            cbChooseReportType.Items.Add("Goal History");
		    cbChooseReportType.Items.Add("Goal Weekly Status");
		    cbChooseReportType.Items.Add("Goal Progress");
		    cbChooseReportType.Items.Add("Goal List");
			cbChooseReportType.Items.Add("Low Participation");
			cbChooseReportType.Items.Add("Produced Items");
			cbChooseReportType.Items.Add("Staff Mtg. Agenda");
			cbChooseReportType.Items.Add("SWAT Agenda");
			cbChooseReportType.Items.Add("SWAT Notes");
			cbChooseReportType.Items.Add("Tracker Comparison");
			cbChooseReportType.Items.Add("Transactions by Employee");
			cbChooseReportType.Items.Add("Transfers");
			cbChooseReportType.Items.Add("Trend");
			cbChooseReportType.Items.Add("View Waste");
			cbChooseReportType.Items.Add("Waste Avoidance");
			cbChooseReportType.Items.Add("Weekly Tabular");
			cbChooseReportType.Items.Add("YOY Comparison");

			cbChooseReportType.SelectedIndex = 0;
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			commonEvents.ProgressCancelled +=
				new VWA4Common.ProgressCancelledEventHandler(commonEvents_CancelProgress);
			_progressCancelled = false;
		}

        private string _TaskName = "";
        public UCReportViewer(string name)
        {
             InitializeComponent();

            _TaskName = name;
			//switch (name)
			//{ 
			//    case "SWAT Form":
			//        SetReportType("SWAT Form");
			//        dt = VWA4Common.DB.Retrieve("SELECT ID FROM ReportMemorized WHERE Title = 'Default SWAT'");
			//        if (dt.Rows.Count > 0)
			//            ucLowParticipationParameters1.LoadParameters(int.Parse(dt.Rows[0]["ID"].ToString()));
			//        break;
			//    case "Pre-Shift Meeting":
			//        SetReportType("Pre-Shift Meeting");
			//        dt = VWA4Common.DB.Retrieve("SELECT ID FROM ReportMemorized WHERE Title = 'Default Pre-Shift Meeting'");
			//        if (dt.Rows.Count > 0)
			//            ucLowParticipationParameters1.LoadParameters(int.Parse(dt.Rows[0]["ID"].ToString()));
			//        break;
			//    default:
			//        MessageBox.Show(null, "Unknown Report Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//        break;
			//}
			_progressCancelled = false;
		}
		private void commonEvents_CancelProgress(object sender, EventArgs e)
		{
			_progressCancelled = true;
		}
		public void SetReportType(string name)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;

			ucLowParticipationParameters1.InitRunTime();

			ReportType = name;

            cbChooseReportType.SelectedItem = ReportType;
            switch (ReportType)
            {
                case "Budget to Actual Comparison":
                    this.ucLowParticipationParameters1.SetFinancial("Budget to Actual Comparison");
                    break;
                case "Configuration":
                    this.ucLowParticipationParameters1.SetConfiguration();
                    break;
                case "Comparison":
                    this.ucLowParticipationParameters1.SetComparision();
                    break;
                case "Detail":
                    this.ucLowParticipationParameters1.SetCrossTab();
                    break;
                case "Employee":
                    this.ucLowParticipationParameters1.SetEmployee();
                    break;
                case "Employee Recognition":
                    this.ucLowParticipationParameters1.SetEmployeeRecognition();
                    break;
                case "Event Orders":
                    this.ucLowParticipationParameters1.SetEventOrders();
                    break;
                case "Financial Summary":
                    this.ucLowParticipationParameters1.SetFinancial("Financial Summary");
                    break;
				case "Goal List by Completion Percent":
					this.ucLowParticipationParameters1.SetGoalsListbyCompletionPercent();
					break;
                case "Goal History":
                    ucLowParticipationParameters1.SetGoalHistory();
                    break;
                case "Goal List":
                    ucLowParticipationParameters1.SetGoalList();
                    break;
                case "Goal Weekly Status":
                    ucLowParticipationParameters1.SetGoalWeeklyStatus();
                    break;
                case "Goal Progress":
                    ucLowParticipationParameters1.SetGoalProgress();
                    break;
                case "Low Participation":
                    this.ucLowParticipationParameters1.SetLowParticipation();
                    break;
                case "Staff Mtg. Agenda":
                    this.ucLowParticipationParameters1.SetPreShiftMeeting();
                    break;
                case "Produced Items":
                    this.ucLowParticipationParameters1.SetProducedItems();
                    break;
                case "Close-Up View":
                    this.ucLowParticipationParameters1.SetDetails();
                    break;
                case "SWAT Agenda":
                    this.ucLowParticipationParameters1.SetSWATForm();
                    break;
                case "SWAT Notes":
                    this.ucLowParticipationParameters1.SetSWATNotes();
                    break;
                case "Tracker Comparison":
                    this.ucLowParticipationParameters1.SetTrackerComparison();
                    break;
                case "Transactions by Employee":
                    this.ucLowParticipationParameters1.SetEmployeeTransactions();
                    break;
                case "Transfers":
                    this.ucLowParticipationParameters1.SetTransfers();
                    break;
                case "Trend":
                    this.ucLowParticipationParameters1.SetTrend();
                    break;
				//case "Waste Avoidance":
				//    this.ucLowParticipationParameters1.SetWasteAvoidance();
				//    break;
                case "Weekly Tabular":
                    this.ucLowParticipationParameters1.SetWeeklyTabular();
                    break;
                case "View Waste":
                    this.ucLowParticipationParameters1.SetViewWaste();
                    break;
                case "YOY Comparison":
                    this.ucLowParticipationParameters1.SetFinancial("YOY Comparison");
                    break;
                case "Form":
                    this.ucLowParticipationParameters1.Visible = false;
                    break;
                default:
                    MessageBox.Show(this, "Error in loading report parameters: Unknown report type", "ProjectError",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            ucLowParticipationParameters1.ReportParameters = null;
        }
        private void ucLowParticipationParameters1_HideParams(object sender, UserControls.UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
            this.panelParams.Height = e.Height;
            this.cbChooseReportType.Enabled = e.IsHide;
        }
        public void HideTop()
        {
            this.panelParams.Height = 0;
            this.panelTop.Height = 0;
            this.cbChooseReportType.Enabled = false;
        }
        public void SmallTop()
        {
            this.ucLowParticipationParameters1.HideParameters(true);
            this.panelTop.Height = 0;
            this.cbChooseReportType.Enabled = false;
        }
        public void HideTopPanel()
        {
            this.panelTop.Height = 0;
            this.cbChooseReportType.Enabled = false;
        }
        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            startReport();
            this.viewer1.Document = m_rptMainReport.Document;
        }
        private void startReport()
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.Cursor = Cursors.Default;
        }
		//private DataDynamics.ActiveReports.ActiveReport3 m_rptMainReport = null;
		//private DataDynamics.ActiveReports.ActiveReport3 m_rptSubReport;
		//private DataDynamics.ActiveReports.ActiveReport3 m_rptBanchReport = null;

		private DataDynamics.ActiveReports.ActiveReport m_rptMainReport = null;
		private DataDynamics.ActiveReports.ActiveReport m_rptSubReport;
		private DataDynamics.ActiveReports.ActiveReport m_rptBanchReport = null;

        private void launchReport()
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			try
            {
                // Init Report Input Parameters
                UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;

                switch (ReportType)
                {
                    case "Budget to Actual Comparison":
                        m_rptMainReport = new rptFinancials(repParams, ReportType);
                        break;
					case "Close-Up View":
						m_rptMainReport = new rptDetails(repParams);
						break;
					case "Configuration":
                        m_rptMainReport = new rptConfiguration(repParams);
                        break;
                    case "Comparison":
                        m_rptMainReport = new rptComparision(repParams);
                        break;
                    case "Detail":
                        m_rptMainReport = new rptCrossTab(repParams);
                        break;
                    case "Employee":
                        m_rptMainReport = new rptEmployee(repParams);
                        m_rptMainReport.Run();
                        if (bool.Parse(repParams["ShowEmployeeSub"].ParamValue))
                        {
                            m_rptSubReport = new rptEmployeeException(repParams);
                            m_rptSubReport.Run();
                            m_rptMainReport.Document.Pages.AddRange(m_rptSubReport.Document.Pages);
                        }
                        break;
                    case "Employee Recognition":
                        m_rptMainReport = new rptEmployeeRecognition(repParams);
                        break;
                    case "Event Orders":
                        m_rptMainReport = new rptEvent(repParams);
                        break;
                    case "Financial Summary":
                        m_rptMainReport = new rptFinancials(repParams, ReportType);
                        break;
					case "Form":
						m_rptMainReport = new rptFormSeries();
						break;
					case "Goal List by Completion Percent":
						m_rptMainReport = new rptGoalListbyCompletion(repParams);
						break;
                    case "Goal History":
                        m_rptMainReport = new rptGoalHistory(repParams);
                        break;
                    case "Goal List":
                        m_rptMainReport = new rptGoalList(repParams);
                        break;
                    case "Goal Weekly Status":
                        m_rptMainReport = new rptGoalWeeklyStatus(repParams);
                        break;
                    case "Goal Progress":
                        m_rptMainReport = new rptGoalProgress(repParams);
                        break;
					case "Low Participation":
                        m_rptMainReport = new rptLowParticipation(repParams);
                        break;
                    case "Produced Items":
                        m_rptMainReport = new rptProducedItem(repParams);
                        break;
                    case "Staff Mtg. Agenda":
                        m_rptMainReport = new rptPreShiftMeetingForm(repParams);
                        break;
                    case "SWAT Agenda":
                        m_rptMainReport = new rptSWATForm(repParams);
                        break;
                    case "SWAT Notes":
                        m_rptMainReport = new rptSWATNotes(repParams);
                        break;
                    case "Tracker Comparison":
                        m_rptMainReport = new rptTrackerComparison(repParams);
                        break;
                    case "Transactions by Employee":
                        m_rptMainReport = new rptEmployeeTransactions(repParams);
                        break;
                    case "Transfers":
                        m_rptMainReport = new rptTransfers(repParams);
                        break;
                    case "Trend":
                        m_rptMainReport = new rptARTrend(repParams);
                        break;
                    case "Waste Avoidance":
                        //m_rptMainReport = new rptWasteAvoidance(repParams);
                        break;
                    case "Weekly Tabular":
                        m_rptMainReport = new rptWeeklyTabular(repParams);
                        break;
                    case "YOY Comparison":
                        m_rptMainReport = new rptFinancials(repParams, ReportType);
                        break;
                    default:
                        MessageBox.Show(this, "Error in launchReport: Unknown report type", "ProjectError",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                if (ReportType != "Employee")
                    m_rptMainReport.Run();
                if (m_rptBanchReport == null)
                    m_rptBanchReport = new DataDynamics.ActiveReports.ActiveReport();
                m_rptBanchReport.Document.Pages.AddRange(m_rptMainReport.Document.Pages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in launchReport: " + ex.Message, "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ucLowParticipationParameters1_ExportPDF(object sender, EventArgs e)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			try
            {
                SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
                //dlg.InitialDirectory = Application.StartupPath;
                dlg.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (m_rptMainReport == null || m_rptMainReport.Document.Pages.Count <= 0)
                        launchReport();
                    // the fonts collection of pages is not filling correctly
                    // use the following code before exporting as workaround
                    foreach (DataDynamics.ActiveReports.Document.Page p in m_rptMainReport.Document.Pages)
                    {

                        ((IList)p.Fonts).Add(p.Font.Clone());

                        ((IList)p.Fonts).Add(p.Font.Clone());

                    }
                    this.pdfExport1.Export(m_rptMainReport.Document, dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in Export to PDF: " + ex.Message + Environment.NewLine +
                "Please send generated NewRDF.RDF file to developers", "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_rptMainReport.Document.Save(Application.StartupPath + "\\NewRDF.RDF"); //save failed report for investigation
            }
        }

        public bool EnableShapes { get; set; }
        private void ucLowParticipationParameters1_ExportRTF(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
                //dlg.InitialDirectory = Application.StartupPath;
                dlg.Filter = "RTF files (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (m_rptMainReport == null || m_rptMainReport.Document.Pages.Count <= 0)
                        launchReport();
                    FileStream fs = File.OpenWrite(dlg.FileName);
                    System.IO.MemoryStream s = new System.IO.MemoryStream();

                    rtfExport1.Export(m_rptMainReport.Document, s);

                    fs.Write(s.ToArray(), 0, (int)s.Length);

                    fs.Close();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in Export to RTF: " + ex.Message + Environment.NewLine +
                "Please send generated NewRDF.RDF file to developers", "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_rptMainReport.Document.Save(Application.StartupPath + "\\NewRDF.RDF"); //save failed report for investigation

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetReportType(cbChooseReportType.SelectedItem.ToString());
            if (cbChooseReportType.SelectedItem.ToString() != "View Waste")
            {
                this.ucViewWeights1.Visible = false;
                this.ucViewWeights1.SendToBack();
                this.panelParams.Visible = true;
                this.panelParams.Size = new System.Drawing.Size(937, 217);
                this.viewer1.Visible = true;
                this.viewer1.Document.Pages.Clear();
            }
            else
            {
                ReportType = "View Waste";
                this.panelParams.Visible = false;
                this.panelParams.Size = new System.Drawing.Size(0, 0);
                this.viewer1.Visible = false;
                this.ucViewWeights1.Visible = true;
                this.ucViewWeights1.BringToFront();
            }
            m_rptMainReport = null;
            //m_rptBanchReport = null;
            this.ucLowParticipationParameters1.ClearTitle();
                
        }

        public void AddLoadParameters(int id)
        {
            AddLoadParameters(id, false);
        }
        public void AddLoadParameters(int id, bool isCorrectWeekly)
        {
            
            ReportType = VWA4Common.DB.Retrieve("SELECT ReportType FROM ReportMemorized WHERE ID = " + id).Rows[0]["ReportType"].ToString();

            _ReportID = id;
            cbChooseReportType.SelectedItem = ReportType;
            if (ReportType != "View Waste")
            {
                ucLowParticipationParameters1.LoadParameters(id, isCorrectWeekly);
                startReport();
            }
            else
            {
                ucViewWeights1.ConfigReportID = id;
                ucViewWeights1.LoadData();
            }
        }
        public void View(int id)
        {
            View(id, false);
        }
        public void View(int id, bool isCorrectWeekly)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddLoadParameters(id, isCorrectWeekly);
            
            if (ReportType == "View Waste")
                this.ucViewWeights1.LoadData();
            else
                this.viewer1.Document = m_rptMainReport.Document;
        }
        public void View()
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			if (m_rptBanchReport != null)
            {
                this.viewer1.Document = m_rptBanchReport.Document;
                HideTop();
            }
            else
                this.ucViewWeights1.LoadData();
        }

        public void AddPrint(int id)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddPrint(id, false);
        }
        public void AddPrint(int id, bool isCorrectWeekly)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddLoadParameters(id, isCorrectWeekly);
            if (ReportType == "View Waste")
            {
                this.ucViewWeights1.ConfigReportID = id;
                this.ucViewWeights1.LoadData();
                this.ucViewWeights1.CreateReportWithExtras(ref report);
            }
        }

        Infragistics.Documents.Report.Report report = null;
        public void AddPDF(int id)
        {
            AddPDF(id, false);
        }
        public void AddPDF(int id, bool isCorrectWeekly)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddLoadParameters(id, isCorrectWeekly);
            if (ReportType == "View Waste")
            {
                this.ucViewWeights1.ConfigReportID = id;
                this.ucViewWeights1.LoadData();
                this.ucViewWeights1.CreateReportWithExtras(ref report);
            }
        }
        public void Print(int id)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddLoadParameters(id);
            if (ReportType == "View Waste")
            {
                this.ucViewWeights1.ConfigReportID = id;
                this.ucViewWeights1.LoadData();
                this.ucViewWeights1.PrintGrid(true);
            }
            else
                m_rptMainReport.Document.Print();

        }
        public void Print()
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			if (m_rptBanchReport != null)
                m_rptBanchReport.Document.Print();
            else
            {
                //
				if (!Directory.Exists(Path.GetDirectoryName(VWA4Common.GlobalSettings.VirtualAppDir) + "\\Temp\\"))
					Directory.CreateDirectory(Path.GetDirectoryName(VWA4Common.GlobalSettings.VirtualAppDir) + "\\Temp\\");
                string fileName =
					Path.GetDirectoryName(VWA4Common.GlobalSettings.VirtualAppDir) + "\\Temp\\" + "ViewWaste_" + DateTime.Now.ToString("yy-MM-dd_hh-mm") + ".pdf";
                this.ucViewWeights1.Publish(report, fileName);
            }
        }
        public void ShowPDF(string fileName)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			if (m_rptBanchReport != null)
            {
                this.pdfExport1.Export(m_rptBanchReport.Document, fileName);
                System.Diagnostics.Process.Start(fileName);
            }
            else
                this.ucViewWeights1.Publish(report, fileName);
        }
        public void ShowPDF(int id, string fileName)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			AddLoadParameters(id);
            if (ReportType == "View Waste")
                this.ucViewWeights1.Publish(null, fileName);
            else
            {
                this.pdfExport1.Export(m_rptMainReport.Document, fileName);
                System.Diagnostics.Process.Start(fileName);
            }
        }

        public void PrintSWATNote(int id)
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM SWATMinutes WHERE ID = " + id);
            if (dt != null && dt.Rows.Count > 0)
            {
                ucLowParticipationParameters1.SetSWATNotesStart(DateTime.Parse(dt.Rows[0]["WeekStart"].ToString()));
                startReport();
                m_rptMainReport.Document.Print();
            }

        }

        public void Test()
        {
            this.ucViewWeights1.Test();
        }

        /// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
            
			DataTable dt;
			switch (_TaskName)
			{
                case "SWAT Agenda":
                    SetReportType("SWAT Agenda");
					dt = VWA4Common.DB.Retrieve("SELECT ID FROM ReportMemorized WHERE Title = 'Default SWAT Agenda'");
					if (dt.Rows.Count > 0)
						ucLowParticipationParameters1.LoadParameters(int.Parse(dt.Rows[0]["ID"].ToString()));
					break;
                case "Staff Mtg. Agenda":
                    SetReportType("Staff Mtg. Agenda");
                    dt = VWA4Common.DB.Retrieve("SELECT ID FROM ReportMemorized WHERE Title = 'Default Staff Mtg. Agenda'");
					if (dt.Rows.Count > 0)
						ucLowParticipationParameters1.LoadParameters(int.Parse(dt.Rows[0]["ID"].ToString()));
					break;
				default:
					break;
			}
			SmallTop();
            startReport();
            if(m_rptMainReport != null && m_rptMainReport.Document != null)
                this.viewer1.Document = m_rptMainReport.Document;
            //LoadWeightsData();
        }
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;

        public void Init(DateTime firstDayOfWeek) //display
        {
            //AddPeriodFilter(firstDayOfWeek, firstDayOfWeek.AddDays(7));
            //ShowHideColumnChooser(true);
            //_ConfigReportName = "Default View";
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
            _IsActive = true;
        }

        public void SaveData()
        {
            //this.gridViewWaste.UpdateData();
            //m_VWAWeights.UpdateData();

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
        private void UpdateView()
        {
			if (_progressCancelled) return;
			if (VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled) return;
			ucLowParticipationParameters1.SetDatesToCurrentWeek();
            ucLowParticipationParameters1.SetCurrentSite();
            if (_ReportID < 0 && (ReportType == "SWAT Agenda" || ReportType == "Staff Mtg. Agenda"))
            {
                if (m_rptMainReport != null)
                {
                    startReport();
                    this.viewer1.Document = m_rptMainReport.Document;
                }
            }
        }
        private void dbDetector_PathChanged(object sender, EventArgs e)
        {
            UpdateView();
        }
        private void trackerDetector_WeekChanged(object sender, EventArgs e)
        {
            UpdateView();
        }
        private void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void viewer1_OnToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
        {
            if (e.Tool.Caption == "&Print...")
            {
                if (_TaskName == "SWAT Agenda")
                {
                    VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                    utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "printswatform");
                }
                else if (_TaskName == "Staff Mtg. Agenda")
                {
                    VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                    utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "printmeetingscript");
                }
            }

        }

        public delegate void TitleChangedEventHandler(object sender, VWA4Common.VWACommon.TitleEventArgs e);
        private TitleChangedEventHandler titleChangedParams;
        public event TitleChangedEventHandler TitleChanged
        {
            add { titleChangedParams += value; }
            remove { titleChangedParams -= value; }
        }
        public void SetTitleChanged(VWA4Common.VWACommon.TitleEventArgs e)
        {
            OnTitleChanged(e);
        }
        protected virtual void OnTitleChanged(VWA4Common.VWACommon.TitleEventArgs e)
        {
            if (titleChangedParams != null)
                titleChangedParams(this, e);
        }

        private void ucLowParticipationParameters1_TitleChanged(object sender, VWA4Common.VWACommon.TitleEventArgs e)
        {
            if (sender != null)
                SetTitleChanged(e);
        }

        void comboBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //comboBox1.Hide();
        }

        public void DisposeReports()
        {
            try
            {
                if (m_rptMainReport != null && m_rptMainReport.Document != null)
                {
                    m_rptMainReport.Document.Dispose();
                    //m_rptMainReport.Document = null;
                    m_rptMainReport.Dispose();
                    m_rptMainReport = null;
                }
                if (m_rptSubReport != null && m_rptSubReport.Document != null)
                {
                    m_rptSubReport.Document.Dispose();
                    //m_rptSubReport.Document = null;
                    m_rptSubReport.Dispose();
                    m_rptSubReport = null;
                }
                if (m_rptBanchReport != null && m_rptBanchReport.Document != null)
                {
                    m_rptBanchReport.Document.Dispose();
                    //m_rptBanchReport.Document = null;
                    m_rptBanchReport.Dispose();
                    m_rptBanchReport = null;
                }
                GC.Collect();
            }
            catch(Exception)
            {
            }
        }
    }
}
