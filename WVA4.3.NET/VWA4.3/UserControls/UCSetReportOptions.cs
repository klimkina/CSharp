using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UserControls
{
	public partial class UCSetReportOptions : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		VWA4Common.CommonEvents commonEvents = null;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCSetReportOptions()
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
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
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
		}
		
		/// <summary>
		/// Load the Preferences data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Preferences.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			//			
			// Load Preferences data controls
			//
			rgAdvancedReportFilters.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.AdvancedFiltersOn) ? 1 : 0;
			rgShowEmptyReports.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports) ? 0 : 1;
			rgFoodCostReportingMode.SelectedIndex = VWA4Common.GlobalSettings.FoodCostReportPoints ? 0 : 1;

            cbReportsToPrint.Items.Clear();
            cbReportsToView.Items.Clear();
			cbReportsToPrint.Items.Add(VWA4Common.GlobalSettings.ReportsToPrint);
			cbReportsToView.Items.Add(VWA4Common.GlobalSettings.ReportsToView);
            DataTable dt = VWA4Common.DB.Retrieve("SELECT DISTINCT SerieName FROM ReportSeries ORDER BY SerieName ASC");
            if(dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    cbReportsToPrint.Items.Add(row["SerieName"].ToString());
                    cbReportsToView.Items.Add(row["SerieName"].ToString());
                }
            cbReportsToPrint.SelectedIndex = 0;
            cbReportsToView.SelectedIndex = 0; 

			// Load the images
			MemoryStream imgstream;
			byte[] bt;
			if (VWA4Common.Utilities.LoadFilefromDB("UpperLeftLogo.img", VWA4Common.GlobalSettings.CurrentSiteID, out bt) > 0)
			{ // We successfully loaded a picture file from the DB
				imgstream = new MemoryStream(bt, 0, bt.Length);
				pbUpperLeftLogo.Image = Image.FromStream(imgstream);
				pbUpperLeftLogo.Refresh();
			}
			if (VWA4Common.Utilities.LoadFilefromDB("LowerRightLogo.img", VWA4Common.GlobalSettings.CurrentSiteID, out bt) > 0)
			{ // We successfully loaded a picture file from the DB
				imgstream = new MemoryStream(bt, 0, bt.Length);
				pbLowerRightLogo.Image = Image.FromStream(imgstream);
				pbLowerRightLogo.Refresh();
			}
			lSitePrefTitle.Text = "Site Preferences for " +
				VWA4Common.GlobalSettings.CurrentSiteName;
			//pbTest.Image = Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream);

			CheckLabels();

			Initialized = true;
		}
		public void SaveData()
		{ }
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
			dbDetector.DBInvalidate = true; // fire (cause) the event

		}

		/// Event Handlers

		private void CheckLabels()
		{
			bLowerRightlogo.Visible = VWA4Common.GlobalSettings.IsSuper;
			ultraLabel15.Visible = bLowerRightlogo.Visible;
			pbLowerRightLogo.Visible = bLowerRightlogo.Visible;
		}
		
		private void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) 
				commonEvents.TaskSheetKey = "dashboard";
			CheckLabels();
		}

		private void rgAdvancedReportFilters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.AdvancedFiltersOn =
								rgAdvancedReportFilters.Properties.Items[rgAdvancedReportFilters.SelectedIndex].Value.ToString();
			}
		}

		private void rgShowEmptyReports_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.ShowEmptyReports =
								rgShowEmptyReports.Properties.Items[rgShowEmptyReports.SelectedIndex].Value.ToString();
			}
		}

		private void rgFoodCostReportingMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.FoodCostReportPoints =
								(bool)rgFoodCostReportingMode.Properties.Items[rgFoodCostReportingMode.SelectedIndex].Value;
			}
		}

		private void bUpperleftlogo_Click(object sender, EventArgs e)
		{
			MemoryStream imgstream;
			getandsavelogofile("UpperLeftLogo.img", out imgstream);
			if (imgstream != null)
			{
				// Load it into the picture box
				pbUpperLeftLogo.Image = Image.FromStream(imgstream);
				pbUpperLeftLogo.Refresh();
			}
		}

		private void bLowerRightlogo_Click(object sender, EventArgs e)
		{
			MemoryStream imgstream;
			getandsavelogofile("LowerRightLogo.img", out imgstream);
			if (imgstream != null)
			{
				// Load it into the picture box
				pbLowerRightLogo.Image = Image.FromStream(imgstream);
				pbLowerRightLogo.Refresh();
			}
		}

		private void getandsavelogofile(string dbfilename, out MemoryStream imgstream)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.Title = "Select Image File";
			fd.Filter = "Image (*.GIF)|*.gif|(*.JPG)|*.jpg";
			// InitialDirectory = current database directory
			if (VWA4Common.AppContext.DBPathName != "")
			{ // a database is open - use its path as initial
				fd.InitialDirectory = Path.GetDirectoryName(VWA4Common.AppContext.DBPathName);
			}
			fd.Multiselect = false;
			if (fd.ShowDialog() == DialogResult.OK)
			{
				// A file was selected - get the file data
				byte[] filedata = VWA4Common.Utilities.ReadFile(fd.FileName);
				// Load it into the picture box
				imgstream = new MemoryStream(filedata, 0, filedata.Length);
				// Check to see if this filename/site combination already exists
				bool isNew = true;
				string sql = "SELECT ID FROM Files WHERE (Filename = '" + dbfilename + "') AND (SiteID = "
					+ VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ")";
				DataTable dt_files = VWA4Common.DB.Retrieve(sql);
				if (dt_files.Rows.Count > 0)
				{ // File entry already exists - need to update rather than insert
					isNew = false;
				}

				// attempt to load it into the database
				int id = VWA4Common.Utilities.SaveFiletoDB(dbfilename, "Image", filedata, isNew,
					VWA4Common.GlobalSettings.CurrentSiteID);
			}
			else
			{
				imgstream = null;
			}
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void pbUpperLeftLogo_Click(object sender, EventArgs e)
		{

		}

		private void ultraLabel14_Click(object sender, EventArgs e)
		{

		}

        //private void txtReportsToPrint_Leave(object sender, EventArgs e)
        //{
        //    if (Initialized)
        //    {
        //        VWA4Common.GlobalSettings.ReportsToPrint = txtReportsToPrint.Text;
        //    }
        //}

        //private void txtReportsToView_Leave(object sender, EventArgs e)
        //{
        //    if (Initialized)
        //    {
        //        VWA4Common.GlobalSettings.ReportsToView = txtReportsToView.Text;
        //    }
        //}

       
        private void cbReportsToView_Leave(object sender, EventArgs e)
        {
            if (Initialized)
            {
                VWA4Common.GlobalSettings.ReportsToView = cbReportsToView.Text;
            }
        }

        private void cbReportsToPrint_Leave(object sender, EventArgs e)
        {
            if (Initialized)
            {
                VWA4Common.GlobalSettings.ReportsToPrint = cbReportsToPrint.Text;
            }
        }

	
	}
}
