using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Globalization;

namespace Reports
{
    public partial class UCEnterSWATMinutes : UserControl, UserControls.IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		public string UserTypeID;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;


		/// <summary>
		/// Constructor.
		/// </summary>
		public UCEnterSWATMinutes()
		{
			InitializeComponent();
		}

		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                //dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.TrackerConfigOutofSync += new VWA4Common.TrackerDetectorEventHandler(trackerDetector_TrackerConfigOutofSync);
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
			lTitle1.ForeColor = Color.Black;
			lDateRange.ForeColor = Color.Black;
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

		/// <summary>
		/// Load the SWAT notes data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the SWAT Notes.
		/// </summary>
		public void LoadData()
		{
			//bSave.Enabled = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Enter SWAT Notes available"));
			bSave.Enabled = VWA4Common.GlobalSettings.EnterSWATNotesAvailable;
			Initialized = false;
			// Null out fields
			rgRateWeeklyPart.SelectedIndex = -1;
			rgRateProgressGoals.SelectedIndex = -1;
			teTop10ReviewNotes.Text = "";
			teWhatCanWeDo.Text = "";
			teKeySuccess.Text = "";
			teAwardRecipient.Text = "";
			teAwardReason.Text = "";
			UserTypeID = "";
			tePartAward.Text = "";
			//
			// Load Date Range
			//
			lDateRange.Text = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"))
				+ " to " + DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).AddDays(6).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
			//
			// Load SWAT minutes for current week
			//
			string sql = "SELECT * FROM SWATMinutes WHERE (WeekStart >= #"
				+ DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).ToString("yyyy/MM/dd 00:00:00") + "#) AND (WeekStart < #"
				+ DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).AddDays(7).ToString("yyyy/MM/dd 00:00:00") + "#) AND (SiteID = "
				+ VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ")"
				;
			DataTable dt_result = VWA4Common.DB.Retrieve(sql);
			if (dt_result.Rows.Count > 0)
			{ // An entry for this week exists - load it
				DataRow row = dt_result.Rows[0]; // should only be one!
				if (row["Top10Review"].ToString() != "")
					teTop10ReviewNotes.Text = row["Top10Review"].ToString();
				if (row["GoalsReview"].ToString() != "")
					teWhatCanWeDo.Text = row["GoalsReview"].ToString();
				if (row["KeySuccess"].ToString() != "")
					teKeySuccess.Text = row["KeySuccess"].ToString();
				if (row["AwardReason"].ToString() != "")
					teAwardReason.Text = row["AwardReason"].ToString();
				if (row["AwardUserID"].ToString() != "")
				{
					string sql2 = "SELECT * FROM UserType WHERE (TypeID = '"
						+ row["AwardUserID"].ToString() + "')";
					DataTable dt_result2 = VWA4Common.DB.Retrieve(sql2);
					if (dt_result2.Rows.Count > 0)
					{
						DataRow row2 = dt_result2.Rows[0];
						teAwardRecipient.Text = row2["TypeName"].ToString();
						UserTypeID = row2["TypeID"].ToString();
					}
				}
				if (row["AwardType"].ToString() != "")
					tePartAward.Text = row["AwardType"].ToString();
				if ((int.Parse(row["ParticipationRating"].ToString()) > 0) &&
					(int.Parse(row["ParticipationRating"].ToString()) < 6))
				{
					rgRateWeeklyPart.SelectedIndex = int.Parse(row["ParticipationRating"].ToString()) - 1;
				}
				if ((int.Parse(row["GoalsRating"].ToString()) > 0) &&
						(int.Parse(row["GoalsRating"].ToString()) < 6))
				{
					rgRateProgressGoals.SelectedIndex = int.Parse(row["GoalsRating"].ToString()) - 1;
				}
                _CurrentID = int.Parse(row["ID"].ToString());
                btnPrint.Show();
			}
            else
                btnPrint.Hide();
			// initialize button states
			bCancel.Hide();
			bSave.Hide();
            
			lTitle1.Text = "(for " + VWA4Common.GlobalSettings.CurrentSiteName + ")";
			Initialized = true;
		}

		public void SaveData()
		{
			// Save the current edited data

			// initialize button states
			bCancel.Hide();
			bSave.Hide();
            btnPrint.Hide();
		}

		public bool ValidateData()
		{ return true; }


		/// Event Handlers

		private void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}

		void dbDetector_PathChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void trackerDetector_WeekChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void dbDetector_DBDataChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}

        void trackerDetector_TrackerConfigOutofSync(object sender, EventArgs e)
		{
            ucTreeView1.Reload();
            //ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
            //            "User", "0"); ;
		}

		private void ultraTextEditor1_BeforeEditorButtonDropDown(object sender, Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventArgs e)
		{
			this.ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
						"User", "0");
			//this.ucTreeView1.Visible = true;
			//this.ucTreeView1.Focus();
			//this.ucTreeView1.BringToFront();
		}
		
		private void ucTreeView1_TreeViewIDChanged(object sender, UserControls.UCTreeView.TreeViewEventArgs e)
		{
			UserTypeID = e.ID;
			teAwardRecipient.Text = e.Name;
			teAwardRecipient.CloseEditorButtonDropDowns();
		}

		private void rgRateWeeklyPart_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				bCancel.Show();
				bSave.Show();

                btnPrint.Hide();
			}
		}

		private void teTop10ReviewNotes_TextChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				bCancel.Show();
				bSave.Show();

                btnPrint.Hide();
			}
		}

        private int _CurrentID = -1;
		private void bSave_Click(object sender, EventArgs e)
		{
			// First check to see if there is already a record for this site/date

				//
			// Load SWAT minutes for current week
			//
			string sql = "SELECT * FROM SWATMinutes WHERE (WeekStart >= #"
				+ DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).ToString("yyyy/MM/dd 00:00:00") + "#) AND (WeekStart < #"
				+ DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).AddDays(7).ToString("yyyy/MM/dd 00:00:00") + "#) AND (SiteID = "
				+ VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ")"
				;
			DataTable dt_result = VWA4Common.DB.Retrieve(sql);
			if (dt_result.Rows.Count > 0)
			{ // An entry for this week exists - update it
				DataRow row = dt_result.Rows[0];
                _CurrentID = int.Parse(row["ID"].ToString());
				sql = "UPDATE SWATMinutes SET "
					+ " SiteID=" + VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ","
					+ " WeekStart=#" + VWA4Common.GlobalSettings.StartDateOfSelectedWeek + "#,"
					+ " AwardUserID='" + UserTypeID + "',"
					+ " AwardType='" + tePartAward.Text + "',"
					+ " ParticipationRating=" + (rgRateWeeklyPart.SelectedIndex + 1).ToString() + ","
					+ " GoalsRating=" + (rgRateProgressGoals.SelectedIndex + 1).ToString() + ","
					+ " Top10Review='" + teTop10ReviewNotes.Text + "',"
					+ " GoalsReview='" + teWhatCanWeDo.Text + "',"
					+ " KeySuccess='" + teKeySuccess.Text + "',"
					+ " AwardReason='" + teAwardReason.Text + "'"
					+ " WHERE ID=" + row["ID"].ToString();
				VWA4Common.DB.Update(sql);
			}
			else
			{ // No entry - insert one
				sql = "INSERT INTO SWATMinutes (SiteID,WeekStart,AwardUserID,"
					+ "AwardType,ParticipationRating,GoalsRating,Top10Review,"
					+ "GoalsReview,KeySuccess,AwardReason)"
					+ " VALUES('"
					+ VWA4Common.GlobalSettings.CurrentSiteID.ToString()
					+ "',#" + VWA4Common.GlobalSettings.StartDateOfSelectedWeek + "#"
					+ ",'" + UserTypeID + "'"
					+ ",'" + tePartAward.Text + "'"
					+ "," + (rgRateWeeklyPart.SelectedIndex + 1).ToString()
					+ "," + (rgRateProgressGoals.SelectedIndex + 1).ToString()
					+ ",'" + teTop10ReviewNotes.Text + "'"	
					+ ",'" + teWhatCanWeDo.Text + "'"
					+ ",'" + teKeySuccess.Text + "'"
					+ ",'" + teAwardReason.Text + "'"
					+ ")"
					;
				//sql = sql.Replace("\'", "\'\'");
                _CurrentID = VWA4Common.DB.Insert(sql);

			}
			bCancel.Hide();
			bSave.Hide();
			// Check the task complete
			VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
			utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "enterswatminutes");

            btnPrint.Visible = true;
			//commonEvents.TaskSheetKey = "dashboard";
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show(this, "Are you sure you want to cancel your changes?", "Cancel changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                DialogResult.OK)
            {
                bCancel.Hide();
                bSave.Hide();
                btnPrint.Hide();
                LoadData();
                //commonEvents.TaskSheetKey = "dashboard";
            }
		}

		private void ucTreeView1_Leave(object sender, EventArgs e)
		{
			teAwardRecipient.CloseEditorButtonDropDowns();
			if (ucTreeView1.ID == "")
			{
				UserTypeID = "";
				teAwardRecipient.Text = "";
			}
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			//bSave.Enabled = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Enter SWAT Notes available"));
			bSave.Enabled = VWA4Common.GlobalSettings.EnterSWATNotesAvailable;
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter SWAT Notes")))
				commonEvents.TaskSheetKey = "dashboard";
		}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_CurrentID > 0)
            {
                frmReportViewer frm = new frmReportViewer("SWAT Notes");
                frm.PrintSWATNote(_CurrentID);
            }
        }
	}
}
