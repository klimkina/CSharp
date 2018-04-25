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
	public partial class UCDatabaseInfo : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
		private VWA4Common.TrackerDetector trackerDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;


		/// <summary>
		/// Constructor.
		/// </summary>
		public UCDatabaseInfo()
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
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
			}
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.TrackerConfigOutofSync += new VWA4Common.TrackerDetectorEventHandler(trackerDetector_TrackerConfigOutofSync);
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
			Initialized = false;
			LoadDBInfo(VWA4Common.AppContext.DBPathName);
			LoadLicenseInfo();
			Initialized = true;
		}


		public void SaveData()
		{
			// Save the current edited data
		}

		public bool ValidateData()
		{ return true; }


		/// Event Handlers

		void dbDetector_PathChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		void trackerDetector_TrackerConfigOutofSync(object sender, EventArgs e)
		{
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void lBrowseDB_Click(object sender, EventArgs e)
		{
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select DataBase";
            fd.Filter = "DB (*.MDB)|*.mdb|" +
                        "All files (*.*)|*.*";
            // InitialDirectory = current database directory
            if (VWA4Common.AppContext.DBPathName != "")
            { // a database is open - use its path as initial
				fd.InitialDirectory = Path.GetDirectoryName(VWA4Common.AppContext.DBPathName);
            }
            else
            { // no database is open - use the standard database directory
                fd.InitialDirectory = VWA4Common.GlobalSettings.DatabaseDir;
            }
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
				LoadDBInfo(fd.FileName);
            }
        }

		private bool LoadDBInfo(string dbpathname)
		{
			// Null out fields
			FileInfo dbfile = new FileInfo(dbpathname);
			if (dbfile.Exists)
			{
				lFileSize.Text = dbfile.Length.ToString("###,###,##0") + " bytes";
				lFullpath.Text = dbfile.FullName.ToString();
				VWA4Common.GlobalClasses.VWDBStats dbstats =
					new VWA4Common.GlobalClasses.VWDBStats();
				VWA4Common.GlobalSettings.GetDBStats(dbpathname, dbstats);

				lDBVersion.Text = dbstats.DBVersion;

				lNumSites.Text = dbstats.NumSites.ToString();
				lNumFoodTypes.Text = dbstats.NumFoodTypes.ToString();
				lNumLossTypes.Text = dbstats.NumLossTypes.ToString();
				lNumUserTypes.Text = dbstats.NumUserTypes.ToString();
				lNumReports.Text = dbstats.NumReports.ToString();
				lNumDETs.Text = dbstats.NumDETs.ToString();

				if (dbstats.FoodWasteClassUsed) lFoodWasteClassesUsed.Text = "Yes";
				else lFoodWasteClassesUsed.Text = "No";
				if (dbstats.NonFoodWasteClassUsed) lNonFoodWasteClassesUsed.Text = "Yes";
				else lNonFoodWasteClassesUsed.Text = "No";

				// TODO: Waste Classes loading

				return true;
			}
			return false;
		}

		private void LoadLicenseInfo()
		{
			lMaxSitesAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofSites.ToString();
			lMaxFoodTypesAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString();
			lMaxLossTypesAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString();
			lMaxUserTypesAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString();
			lMaxReportsAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofReports.ToString();
			lMaxDETsAllowed.Text = VWA4Common.GlobalSettings.MaxNumberofDETs.ToString();
		}
	}
}
