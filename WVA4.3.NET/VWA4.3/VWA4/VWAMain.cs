using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.AppStyling.Runtime;
using System.Reflection;
using Reports;
using UserControls;
using System.IO;
using Ionic.Zip;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using VWA4.com.leanpath.activate;
using VWA4Common.Security;
using System.Globalization;
//using System.Threading;

namespace VWA4
{
    public partial class VWAMain : Form
    {
        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        //  It all starts here.
        //******************************************************************************
        //******************************************************************************
		private bool checkAutoUpdate;

		public VWAMain()
		{
            //for globalization
            //CultureInfo en = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = en;

			InitializeComponent();

			VWA4Common.GlobalSettings.Initialized = true;
			// Set up the event handler for the Task Explorer
			this.ucTaskList1.TaskListCommandEvent 
				+= new UCTaskList.TaskListCommandEventHandler(ucTaskList1_TaskListCommandEvent);

			bool vadselected = false;
			bool configinitialized = false;
			string errspot = "";
			string vad = "";

			//*****************************************************************************
			// Get the AppSettings section.
			//*****************************************************************************
			try
			{
				// Open App.Config of executable
				System.Configuration.Configuration config =
				  ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
				// Go through the keys...look for the VAD
				foreach (string key in ConfigurationManager.AppSettings)
				{
					if (key == "VirtualApplicationDirectory")
					{
						vad = ConfigurationManager.AppSettings[key];
						configinitialized = true;
					}
				}
				///************************************************************************* 
				///************************************************************************* 
				/// Didn't find the key...so we have to start as a first time install
				///************************************************************************* 
				///************************************************************************* 
				if (!configinitialized)
				{
					/// We have to decide on VAD location or we can't proceed!
					while (!vadselected)
					{
						/// Give user a chance to retarget VAD
						if (MessageBox.Show(this, "Use standard Application Directory?  \n(" 
							+ Path.GetDirectoryName(Application.ExecutablePath) + ")"
							+ "\n\nClick 'No' if you need to choose an alternate Application Directory.\n"
							+ "IMPORTANT: The Application Directory must have read/write permissions enabled\n"
							+ " for all users who will be using "
							+ VWA4Common.GlobalSettings.ProductName + ".",
							"ValuWaste Advantage 4", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
							== DialogResult.No)
						{ // User wants a VAD
							FolderBrowserDialog fbd = new FolderBrowserDialog();
							fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
							if (fbd.ShowDialog() == DialogResult.OK)
							{
								// User selected a directory
								vad = fbd.SelectedPath;
								vadselected = true;
							}
						}
						else vadselected = true;
					}
					// Add the VAD Application Setting.
					errspot = "Before config.AppSettings";	/////////////////////////
					AppSettingsSection appSettings = config.AppSettings;
					appSettings.Settings.Add("VirtualApplicationDirectory", vad);
					// Save the configuration file.
					errspot = "Before config.Save";			/////////////////////////
					config.Save(ConfigurationSaveMode.Modified);
					// Force a reload of a changed section.
					errspot = "After config.Save - before RefreshSection";	/////////
					ConfigurationManager.RefreshSection("appSettings");
				}
				/// 
				/// Set the VirtualAppDir Globals and Create the main subdirectories
				/// 
				VWA4Common.GlobalSettings.VirtualAppDir = vad;
				if (!Directory.Exists(VWA4Common.GlobalSettings.ArchiveDir))
				{
					errspot = "Before trying to create ArchiveDir";	/////////////////
					Directory.CreateDirectory(VWA4Common.GlobalSettings.ArchiveDir);
				}
				if (!Directory.Exists(VWA4Common.GlobalSettings.DatabaseDir))
				{
					errspot = "Before trying to create DatabaseDir";	/////////////
					Directory.CreateDirectory(VWA4Common.GlobalSettings.DatabaseDir);
				}
				errspot = "After creating ArchiveDir and DatabaseDir";	/////////////
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message + "\n\n(" + errspot + ")","ValuWaste Advantage 4");
			}
		} // end of VWAMain()


        private VWA4Common.DBDetector dbDetector = null;
        VWA4Common.TrackerDetector trackerDetector = null;
        private VWA4Common.CommonEvents commonEvents = null;

		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		/// <summary>
        /// Main Initialization - on loading of main program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		///************************************************************************* 
		private void VWAMain_Load(object sender, EventArgs e)
		{
			string errmsg = null;
			try
			{
				Application.DoEvents();
				/// Set up all event handlers 
				dbDetector = VWA4Common.DBDetector.GetDBDetector();
				dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
				dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
				dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
				if (trackerDetector == null)
				{
					trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();    // Get instance of event generator
					trackerDetector.WeekChanged += 
						new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
				}
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.TaskDataChanged += 
					new VWA4Common.CommonEventsEventHandler(commonEvents_TaskDataChanged);
				commonEvents.ShowTaskSheet +=
					new VWA4Common.ShowTaskSheetEventsEventHandler(commonEvents_ShowTaskSheet);
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
				commonEvents.HideTaskList += new VWA4Common.HideTaskListEventHandler(commonEvents_HideTaskList);
				
				//
				// Detailed Startup procedure - License code driven
			// License code file must be in place in the application directory
				//
				///
				/// Initialize Global variables
				/// 
				// InitLicenseProperties();

				//
				// Get expiration date from the license file and make sure the license covers today's date
				//

				bool done = false;
				bool done2 = false;
				bool activated = false;
				bool shutdown = false;

				///************************************************************************* 
				///************************************************************************* 
				/// Check for test mode
				///************************************************************************* 
				///************************************************************************* 

				testingToolStripMenuItem.Visible = VWA4Common.GlobalSettings.TestMenuFileExists;
				if (VWA4Common.GlobalSettings.TestModeFileExists)
				{
					///**********************************************
					///**********************************************
					/// TEST MODE
					/// Initialize License Properties
					/// 
					LoadConfigSettings();
				}
				else
				{

					///**********************************************
					///**********************************************
					/// NORMAL STARTUP
					/// Normal startup with license
					///
					while (!done)
					{
						/// Start by assuming we have an installed license, ready to load
						while (!VWA4Common.Security.LicenseManager.LoadLicense(
							VWA4Common.GlobalSettings.VirtualAppDir + "\\vw4license.txt", out errmsg))
						{
							// License error
							if (MessageBox.Show("License did not load. (" + errmsg + ")\n\n"
								+ "Install new license now?", "LeanPath Licensing System", MessageBoxButtons.YesNo)
								== DialogResult.Yes)
							{
								VWA4Common.GlobalSettings.InstallLicense();
							}
							else
							{
								// User chose not to install new license - shut down now
								MessageBox.Show("Cannot proceed without installing a valid license - exiting application now.\nContact LeanPath customer support for assistance.", "LeanPath Licensing System");
								done = true;
								shutdown = true;
								break;
							}
						}
						///
						/// License file is in place, and Globals should now be loaded
						/// Ready to check license settings
						///
						// Is license file properly activated?
						//
						/// Let's see if the Activation code in the license file 
						/// is correct for this CPU and License file
						if (shutdown) break;
						while (!done2)
						//while (!VWA4Common.Security.LicenseManager.ValidateLicense())
						{
							if (!VWA4Common.Security.LicenseManager.ValidateLicense())
							{/// Need to Activate the file
								/// 
								VWA4Common.Security.Activation afrm = new VWA4Common.Security.Activation();
								if (afrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
								{
									/// We reactivated
									activated = true;
								}
								else
								{
									activated = false;
									done2 = true;
								}
							}
							else
							{
								activated = true;
								done2 = true;
							}
						}
						///**********************************************
						///**********************************************
						/// File is now activated
						/// 
						/// Expiration Date logic
						/// 
						if (activated && (DateTime.Now > VWA4Common.GlobalSettings.ExpirationDate))
						{ // License is expired
							if (MessageBox.Show("Installed license file has expired. Attempt to reactivate now?"
								, "ValuWaste Advantage 4",MessageBoxButtons.YesNo)
								== System.Windows.Forms.DialogResult.Yes)
							{ /// Let's reactivate! 
								VWA4Common.Security.Activation afrm = new VWA4Common.Security.Activation();
								if (afrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
								{
									/// We reactivated
									activated = true;
									done = true;
									break;
								}
							}
							else
							{ /// Let's NOT... give user a chance to load a new license file, or curtains...
								if (!(MessageBox.Show("Load a different license file now?", "ValuWaste Advantage 4", MessageBoxButtons.YesNo)
								== System.Windows.Forms.DialogResult.Yes))
								{
									// User chose not to install new license - shut down now
									MessageBox.Show("Cannot proceed without installing a valid license - exiting application now.\nContact LeanPath customer support for assistance.", "LeanPath Licensing System");
									done = true;
									shutdown = true;
								}
								else
								{
									VWA4Common.GlobalSettings.InstallLicense();
								}
							}
						}
						else
						{
							if (activated)
								/// This is the finish line.
								done = true;
							else
							{
								// Not activated - start over
								// License error
								if (MessageBox.Show("License did not activate successfully (" + errmsg + ")\n\n"
									+ "Install a different license now?", "LeanPath Licensing System", MessageBoxButtons.YesNo)
									== DialogResult.Yes)
								{
									VWA4Common.GlobalSettings.InstallLicense();
								}
								else
								{
									// User chose not to install new license - shut down now
									MessageBox.Show("Cannot proceed without installing a valid license - exiting application now.\nContact LeanPath customer support for assistance.", "LeanPath Licensing System");
									done = true;
									shutdown = true;
								}

							}
						}

					}  // If !done at this point, start over....

					///**********************************************
					///**********************************************
					/// DONE!!! We have started up successfully



					/// Port the following...
					//logToolStripMenuItem.Text = (VWA4Common.SecurityManager.IsLogged ? "Log Off " + (VWA4Common.SecurityManager.IsSuper ? "Administrator" : "Manager") : "Login");
					//if (VWA4Common.SecurityManager.IsLogged)
					//    AddDBManagerMenus();
				} ///**** end of NOT TestMode (normal startup sequence)

				if (shutdown)
				{
					Application.Exit();
					return;
				} 

				///**********************************************
				///**********************************************
				///*****  Set additional globals here (post-
				///*****     license load)
				///**********************************************
				///**********************************************
				// Set User level from license default
				switch (VWA4Common.GlobalSettings.DefaultUserLevel.ToLower())
				{
					case "user":
						{
							VWA4Common.GlobalSettings.UserLevel = 0;
							break;
						}
					case "manager":
						{
							VWA4Common.GlobalSettings.UserLevel = 1;
							break;
						}
					case "administrator":
						{
							VWA4Common.GlobalSettings.UserLevel = 2;
							break;
						}
				}

                #region check for updates

                //check for updates)
                //get or set application id
                var applicationId = UpdateData.ApplicationId;
                if (applicationId.Equals(Guid.Empty))
                {
                    applicationId = Guid.NewGuid();
                    UpdateData.ApplicationId = applicationId;
                }

                try
                {
                    var version = Properties.Settings.Default.ApplicationVersionKey;
                    var updateService = new UpdateManager { Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1") };
                    var updateSeriesIds = updateService.CheckForUpdates(version, applicationId);
                    if (updateSeriesIds.Length > 0)
                    {
                        var messages = new List<Update>();
                        foreach (var g in updateSeriesIds)
                        {
                            messages.AddRange(updateService.GetAllMessageUpdatesInSeriesById(g));
                        }

                        if (messages.Count > 0)
                        {
                            //update message
                            foreach (var update in messages)
                            {
                                var frmMessage = new frmUpdateMessage(update);
                                frmMessage.ShowDialog();
                                updateService.CompleteUpdate(applicationId, update.Id);
                            }
                        }

                        if (updateService.InstallUpdatesInSeriesByIds(updateSeriesIds))
                        {
                            //there are hotfix updates available
                            if (MessageBox.Show("There are updates available. Would you like to update?", "Advantage Update Utility", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                            {
                                var p = new System.Diagnostics.Process { StartInfo = { FileName = @"VWAUpdater.exe", UseShellExecute = true } };
                                p.StartInfo.Arguments = string.Format("{0}", applicationId);
                                foreach (var s in updateSeriesIds)
                                {
                                    p.StartInfo.Arguments += string.Format(" {0}", s);
                                }
                                p.Start();
                                
                                Application.Exit(); 
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    //unable to connect or some other error, keep loading app
                }

                #endregion

                // Misc inits
                this.Text = VWA4Common.GlobalSettings.ProductName;
                VWA4Common.SplashScreen.ShowSplashScreen();
                VWA4Common.SplashScreen.SetHideSplashNow(false);

				///**********************************************
				///**********************************************
				///*************** Start Database Opening Processing
				///**********************************************
				///**********************************************
				/// Retrieve pathname of last opened database file
				///  and attempt to reopen
				bool lastchance = false;
				done = false;
				if (File.Exists(VWA4.Properties.Settings.Default.LastDBPathName))
				{ // A database file is available - try to open it
					if (OpenDatabase(VWA4.Properties.Settings.Default.LastDBPathName)) done = true;
					else done = false;
				}
				/// If database is successfully opened, skip the following section
				// Give user the opportunity to open a valid database file.
				//  if user cancels, they get a message and one more chance.
				//  if user provides a file, but it is invalid format, then
				//   they get repeated chances to open a valid file.
				VWA4Common.SplashScreen.SetHideSplashNow(true);
				while (!done)
				{
					if (!OpenDatabase(""))
					{ // No file was successfully opened
						if (VWA4Common.Errors.ErrorString.Error != "")
							MessageBox.Show(VWA4Common.Errors.ErrorString.Error, VWA4Common.GlobalSettings.ProductName);
						/// Allow changing values if in Test Mode
						if (VWA4Common.GlobalSettings.TestModeFileExists)
						{
							SetTestModeLicenseValues f = new SetTestModeLicenseValues();
							f.ShowDialog();
						}

						if (!lastchance)
						{
							MessageBox.Show("Please select a valid database pathname for "
							+ VWA4Common.GlobalSettings.ProductName + ".");
							// todo: Allow user a choice to try again or cancel to exit program.
							lastchance = true;
						}
						else
						{
							MessageBox.Show("No "
							+ VWA4Common.GlobalSettings.ProductName
							+ " database is available - exiting application now...");
							Environment.Exit(0);
						}
					}
					else
					{ // We have a successful open DB file (and verified)
						lastchance = false;
						// Set it in the config file for next restart
						VWA4.Properties.Settings.Default.LastDBPathName =
							VWA4Common.AppContext.DBPathName;
						VWA4.Properties.Settings.Default.Save();
						done = true;
					}
				}
				//**********************************************
				//**********************************************
				//**********************************************
				// If we make it to here, a database is now open
				//**********************************************
				//**********************************************
				//**********************************************
				// Expiration warnings here.
				VWA4Common.GlobalSettings.ExpirationWarningMessage(VWA4Common.Security.Types.ExpirationWarningType.OnProgramStart);

                VWA4Common.SplashScreen.SetHideSplashNow(false);


				//johnny - hack to change "Rankings" reports to "Close-Up View" reports to stop error
				//change all at once
				//VWA4Common.DB.Update(string.Format("update ReportMemorized set ReportType='Close-Up View' where ReportType='Rankings'"));
				//
				// Set Globals for communicating with Delphi configurator via the database
				// 
				//if (expDate < DateTime.Now)//check program expiration date
				//{
				//    ClearGlobalVarsforDelphiCommunication();
				//    //MessageBox.Show("Your license has expired. Please update your license");
				//    System.Environment.Exit(-1);//exit application
				//}
				//else
				//CheckGlobalsForDelphiCommunication();
				//Turn off config functions until login
				//ClearGlobalVarsforDelphiCommunication();

				//
				// todo: (SAR) Load any Global variables that are needed immediately
				// Need a SiteID
				//
				int sid = VWA4Common.GlobalSettings.CurrentSiteID;  // Getting it makes sure it's set
				//
				// Init the version
				// todo: clean this up (naming) to show that it's really Advantage version (it is used to supply the version saved
				//			in Transfer records, which before came only from Trackers)
				//
				///Assembly assem = Assembly.GetExecutingAssembly();
				///string verstr = assem.GetName().Version.ToString();
				///VWA4Common.GlobalSettings.TrackerSWVersion = verstr;

				//// Set global parameters according to the license code
				//SetSessionFeatures("0");
				VWA4Common.SplashScreen.SetStatus("Loading Task List...", 15);

				// Populate and Initialize the Task Explorer (from database)
				// 
                ucTaskList1.Init(System.DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None));
				ucTaskList1.LoadData();
				//
				/// 
				///Instantiate and store into our dictionary all various task sheets.
				///
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...", 25);
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Dashboard", 25);
				TaskSheets.AddTaskSheet(TaskSheetNames.Dashboard, 
					(IVWAUserControlBase)new UserControls.UCDashBoard(), 
					"dashboard", "Dashboard");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ViewWaste", 25);
				TaskSheets.AddTaskSheet(TaskSheetNames.ViewWaste, 
					(IVWAUserControlBase)new UserControls.UCViewWeights(), 
					"viewwastedata", "View Transactions");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ImportWaste", 30);
				TaskSheets.AddTaskSheet(TaskSheetNames.ImportWaste, 
					(IVWAUserControlBase)new UserControls.UCImportTransactions(), 
					"importwastedata", "Import Waste Data");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...PaperUIMgr", 30);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageRecurringTransactions, 
					(IVWAUserControlBase)new UserControls.UCMemTransBuilder(), 
					"paperuimanager", "Manage Recurring Transactions");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ReviewReports", 35);
				TaskSheets.AddTaskSheet(TaskSheetNames.ReviewReports, 
					(IVWAUserControlBase)new Reports.UCWeeklyReports(false), 
					"reviewreports", "Review Reports");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ManageReports", 35);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageReports, 
					(IVWAUserControlBase)new Reports.UCReportSerie(), 
					"managereports", "Manage Reports");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...BaselineMgr", 40);
				TaskSheets.AddTaskSheet(TaskSheetNames.BaselineMgr, 
					(IVWAUserControlBase)new UserControls.UCManageBaselines(), 
					"baselinemgr", "Manage Baselines");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...PrintSWAT", 40);
				TaskSheets.AddTaskSheet(TaskSheetNames.PrintSWAT, 
					(IVWAUserControlBase)new Reports.UCReportViewer("SWAT Agenda"), 
					"printswatform", "Print SWAT Form");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...PrintPreShift", 45);
				TaskSheets.AddTaskSheet(TaskSheetNames.PrintPreShift, 
					(IVWAUserControlBase)new Reports.UCReportViewer("Staff Mtg. Agenda"), 
					"printmeetingscript", "Print Pre-shift Notes");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...WeeklyReports", 45);
				TaskSheets.AddTaskSheet(TaskSheetNames.WeeklyReports, 
					(IVWAUserControlBase)new Reports.UCWeeklyReports(), 
					"printweeklyreports", "Print Weekly Reports");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...EnterFinancials", 50);
				TaskSheets.AddTaskSheet(TaskSheetNames.EnterFinancials, 
					(IVWAUserControlBase)new UserControls.UCEnterFinancialData(), 
					"entermonthlyfinancials", "Enter Monthly Financials");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...EnterSWATMinutes", 50);
				// mila: UCEnterSWATMinutes should come from Reports Project, not UserControls!
				TaskSheets.AddTaskSheet(TaskSheetNames.EnterSWATMinutes, 
					(IVWAUserControlBase)new Reports.UCEnterSWATMinutes(), 
					"enterswatminutes", "Enter SWAT Notes");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...AddUser", 55);
				TaskSheets.AddTaskSheet(TaskSheetNames.AddUsers, 
					(IVWAUserControlBase)new UserControls.UCAddUser(),
					"adduser", "Add User");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...DeleteUser", 55);
				TaskSheets.AddTaskSheet(TaskSheetNames.RemoveUsers, 
					(IVWAUserControlBase)new UserControls.UCDeleteUser(), 
					"deleteuser", "Delete User");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...TransferConfig", 65);
				TaskSheets.AddTaskSheet(TaskSheetNames.TransferConfig, 
					(IVWAUserControlBase)new UserControls.UCConfigTransfer(),
					"transferconfig", "Update Tracker");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ManagePreferences", 65);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManagePreferences, 
					(IVWAUserControlBase)new UserControls.UCManagePrefs(),
					"managepreferences", "Set Preferences");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...DatabaseInfo", 65);
				TaskSheets.AddTaskSheet(TaskSheetNames.DatabaseInfo, 
					(IVWAUserControlBase)new UserControls.UCDatabaseInfo(), 
					"databaseinfo", "Show Database Info");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ManageAdjustments", 70);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageFoodCostAdjustments, 
					(IVWAUserControlBase)new UserControls.UCManageAdjustments(),
					"manageadjustments", "Manage Food Cost Adjustments");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ManageEventClients", 70);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageEventClients, 
					(IVWAUserControlBase)new UserControls.UCManageEventClients(),
					"manageeventclients", "Manage Event Clients available");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...ManageEventOrders", 75);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageEventOrders, 
					(IVWAUserControlBase)new UserControls.UCManageEventOrders(),
					"manageeventorders", "Manage Event Orders");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...SetReportOptions", 75);
				TaskSheets.AddTaskSheet(TaskSheetNames.SetReportOptions, 
					(IVWAUserControlBase)new UserControls.UCSetReportOptions(),
					"setreportoptions", "Set Report Options");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...SetDisplayOptions", 75);
				TaskSheets.AddTaskSheet(TaskSheetNames.SetDisplayOptions, 
					(IVWAUserControlBase)new UserControls.UCSetDisplayOptions(),
					"setdisplayoptions", "Set Display Options");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Manage Forms", 75);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageLogForms, 
					(IVWAUserControlBase)new Reports.UCManageForms(),
					"manageforms", "Manage Log Forms");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Enter Log Sheet Data", 80);
				TaskSheets.AddTaskSheet(TaskSheetNames.EnterWasteLogs, 
					(IVWAUserControlBase)new UserControls.UCEnterWasteLogs(),
					"enterwastelogs", "Enter Log Sheet Data");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Manage Data Entry Templates", 83);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageDETemplates,
					(IVWAUserControlBase)new UserControls.UCManageDETemplates(),
					"managedetemplates", "Manage Data Entry Templates");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Manage Each Formats", 83);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageEachFormats,
					(IVWAUserControlBase)new UserControls.UCManageEachFormats(),
					"manageeachformats", "Manage Data Each Formats");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Manage Tags", 84);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageTags,
					(IVWAUserControlBase)new UserControls.UCManageTags(),
					"managetags", "Manage Tags");
				VWA4Common.SplashScreen.SetStatus("Loading Task Sheets...Manage Goals", 84);
				TaskSheets.AddTaskSheet(TaskSheetNames.ManageGoals,
					(IVWAUserControlBase)new UserControls.UCManageGoals(),
					"managegoals", "Manage Goals");
				/// /////////////////////////////////////////////////////////////////////////////////////////
				VWA4Common.SplashScreen.SetStatus("Loading Tasks to Menu Bar...", 85);

				LoadTaskstoMenuBar();

				EnableorDisableDelphiMenus();

				//VWA4Common.GlobalSettings.ProductType = 3; // todo: Remove - just for debug

				VWA4Common.SplashScreen.SetStatus("Loading Dashboard Data...", 88);

				//show the dashboard task sheet
				ShowTaskSheet(TaskSheetNames.Dashboard);

				//
				// todo: process alerts/messages

				//
				// todo: Display alerts/messages

				//************************
				// INITIALIZATION COMPLETE
				//************************
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Encountered During Program Startup: " + ex.Message + "\n\n(" + 
					VWA4Common.SplashScreen.LastStatus + ")");
			}
			
			finally
			{
				VWA4Common.SplashScreen.CloseForm();
				this.TopMost = false;
			}
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
			pFarRight.BackColor = VWA4Common.GlobalSettings.ProductHeaderBackgroundColor;
			//int indexer = VWA4Common.GlobalSettings.ProductType == 3 ? 1 : 0;
			//Bitmap bmp = (Bitmap) imageList32.Images[indexer];
			//    IntPtr Hicon = bmp.GetHicon();
			//Icon icon = new Icon(typeof(VWAMain), "Resources.WL");
			
			Icon icnTask;
            Stream st;
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			// Enumerate the assembly's manifest resources
			//foreach (string resourceName in a.GetManifestResourceNames())
			//{
			//    MessageBox.Show(resourceName);
			//}
			//Bitmap blp = new Bitmap(typeof(VWAMain), "VWA4.Resources.WL.ico");
			if (VWA4Common.GlobalSettings.ProductType == 3)
				st = a.GetManifestResourceStream("VWA4.Resources.WL.ico");
			else
				st = a.GetManifestResourceStream("VWA4.Resources.VW.ico");

            icnTask = new System.Drawing.Icon(st);
			this.Icon = icnTask;
			VWA4Common.GlobalSettings.ProductIcon = this.Icon;

			/// sample code for icon stuff:
				//    // Create a Bitmap object from an image file.
				//Bitmap myBitmap = new Bitmap(@"c:\FakePhoto.jpg");

				//// Draw myBitmap to the screen.
				//e.Graphics.DrawImage(myBitmap, 0, 0);

				//// Get an Hicon for myBitmap.
				//IntPtr Hicon = myBitmap.GetHicon();

				//// Create a new icon from the handle. 
				//Icon newIcon = Icon.FromHandle(Hicon);

				//// Set the form Icon attribute to the new icon.
				//this.Icon = newIcon;

				//// You can now destroy the icon, since the form creates
				//// its own copy of the icon accessible through the Form.Icon property.
				//DestroyIcon(newIcon.Handle);
		///***********
			/// Tasks Menus Related
			///***********
			LoadTaskstoMenuBar();
			
			///***********
			/// Configurator Related
			///***********
			if (!VWA4Common.GlobalSettings.ConfiguratorAvailable)
			{
				manageTypesMenuItem.Visible = false;
				manageTrackersMenuItem.Visible = false;
				manageSitesMenuItem.Visible = false;
			}
			else
			{
				manageTypesMenuItem.Visible = VWA4Common.GlobalSettings.ManageTypesAvailable;
				manageTrackersMenuItem.Visible = VWA4Common.GlobalSettings.ManageTrackersAvailable;
				manageSitesMenuItem.Visible = VWA4Common.GlobalSettings.ManageSitesAvailable;
			}
			/// 
			manageEventClientsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageEventClientsAvailable;
			manageReportsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageReportsAvailable;
			manageBaselinesToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageBaselinesAvailable;
			manageFoodCostAdjustmentsToolStripMenuItem.Visible =
				VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable;
			/// 
			setPreferencesToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManagePreferencesAvailable;
			manageBaselinesToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageBaselinesAvailable;
			manageRecurringTransactionsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.RecurringTransactionsAvailable;
			/// 
			AdvancedtoolStripMenuItem1.Visible = VWA4Common.GlobalSettings.AdvancedMenuAvailable;
			manageReportsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageReportsAvailable;

		}

		/// <summary>
		/// Testing only - initialize license variables
		/// </summary>
		/// 
		private bool LoadConfigSettings()
		{
			try
			{
				Configuration config =
					ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath) as Configuration;
				config.GetSection("userSettings");

				VWA4Common.GlobalSettings.MaxNumberofDETs = VWA4.Properties.Settings.Default.tMaxNumberofDETs;
				VWA4Common.GlobalSettings.MaxNumberofFoodTypes = VWA4.Properties.Settings.Default.tMaxNumberofFoodTypes;
				VWA4Common.GlobalSettings.MaxNumberofLossTypes = VWA4.Properties.Settings.Default.tMaxNumberofLossTypes;
				VWA4Common.GlobalSettings.MaxNumberofReports = VWA4.Properties.Settings.Default.tMaxNumberofReports;
				VWA4Common.GlobalSettings.MaxNumberofSites = VWA4.Properties.Settings.Default.tMaxNumberofSites;
				VWA4Common.GlobalSettings.MaxNumberofTrackers = VWA4.Properties.Settings.Default.tMaxNumberofTrackers;
				VWA4Common.GlobalSettings.MaxNumberofUserTypes = VWA4.Properties.Settings.Default.tMaxNumberofUserTypes;

				VWA4Common.GlobalSettings.AddUsersAvailable = VWA4.Properties.Settings.Default.tAddUsersAvailable;
				VWA4Common.GlobalSettings.AdvancedMenuAvailable = VWA4.Properties.Settings.Default.tAdvancedMenuAvailable;
				VWA4Common.GlobalSettings.AMWTAvailable = VWA4.Properties.Settings.Default.tAMWTAvailable;
				VWA4Common.GlobalSettings.ConfiguratorAvailable = VWA4.Properties.Settings.Default.tConfiguratorAvailable;
				VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable = VWA4.Properties.Settings.Default.tConfigureDaypartEntryAvailable;
				VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable = VWA4.Properties.Settings.Default.tConfigureDispositionEntryAvailable;
				VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable = VWA4.Properties.Settings.Default.tConfigurePrePostEntryAvailable;
				VWA4Common.GlobalSettings.ConfigureStationEntryAvailable = VWA4.Properties.Settings.Default.tConfigureStationEntryAvailable;
				VWA4Common.GlobalSettings.DaypartEntryAvailable = VWA4.Properties.Settings.Default.tDaypartEntryAvailable;
				VWA4Common.GlobalSettings.DispositionEntryAvailable = VWA4.Properties.Settings.Default.tDispositionEntryAvailable;
				VWA4Common.GlobalSettings.EnterFinancialsAvailable = VWA4.Properties.Settings.Default.tEnterFinancialsAvailable;
				VWA4Common.GlobalSettings.EnterSWATNotesAvailable = VWA4.Properties.Settings.Default.tEnterSWATNotesAvailable;
				VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable = VWA4.Properties.Settings.Default.tFoodCostAdjustmentsAvailable;
				VWA4Common.GlobalSettings.ImportWasteDataAvailable = VWA4.Properties.Settings.Default.tImportWasteDataAvailable;
				VWA4Common.GlobalSettings.ManageBaselinesAvailable = VWA4.Properties.Settings.Default.tManageBaselinesAvailable;
				VWA4Common.GlobalSettings.ManageDETsAvailable = VWA4.Properties.Settings.Default.tManageDETsAvailable;
				VWA4Common.GlobalSettings.ManageEventClientsAvailable = VWA4.Properties.Settings.Default.tManageEventClientsAvailable;
				VWA4Common.GlobalSettings.ManageEventOrdersAvailable = VWA4.Properties.Settings.Default.tManageEventOrdersAvailable;
				VWA4Common.GlobalSettings.ManagePreferencesAvailable = VWA4.Properties.Settings.Default.tManagePreferencesAvailable;
				VWA4Common.GlobalSettings.ManageLogFormsAvailable = VWA4.Properties.Settings.Default.tManagePrintFormsAvailable;
				VWA4Common.GlobalSettings.ManageReportsAvailable = VWA4.Properties.Settings.Default.tManageReportsSettingsAvailable;
				VWA4Common.GlobalSettings.ManageSitesAvailable = VWA4.Properties.Settings.Default.tManageSitesAvailable;
				VWA4Common.GlobalSettings.ManageTrackersAvailable = VWA4.Properties.Settings.Default.tManageTrackersAvailable;
				VWA4Common.GlobalSettings.ManageTypesAvailable = VWA4.Properties.Settings.Default.tManageTypesAvailable;
				VWA4Common.GlobalSettings.PrePostEntryAvailable = VWA4.Properties.Settings.Default.tPrePostEntryAvailable;
				VWA4Common.GlobalSettings.RecurringTransactionsAvailable = VWA4.Properties.Settings.Default.tRecurringTransactionsAvailable;
				VWA4Common.GlobalSettings.RemoveUsersAvailable = VWA4.Properties.Settings.Default.tRemoveUsersAvailable;
				VWA4Common.GlobalSettings.StationEntryAvailable = VWA4.Properties.Settings.Default.tStationEntryAvailable;
				VWA4Common.GlobalSettings.UpdateTrackerAvailable = VWA4.Properties.Settings.Default.tUpdateTrackerAvailable;

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Encountered During Program Startup: " + ex.Message + "\n\n(" +
					VWA4Common.SplashScreen.LastStatus + ")");
				return false;
			}
		}

		private void initMinimumLicensePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			initMinimumLicenseProperties();
		}
		private void initMinimumLicenseProperties()
		{
			// Limits
			VWA4Common.GlobalSettings.MaxNumberofSites = 1;
			VWA4Common.GlobalSettings.MaxNumberofFoodTypes = 1;
			VWA4Common.GlobalSettings.MaxNumberofLossTypes = 1;
			VWA4Common.GlobalSettings.MaxNumberofUserTypes = 1;
			VWA4Common.GlobalSettings.MaxNumberofDETs = 1;
			VWA4Common.GlobalSettings.MaxNumberofReports = 1;
			VWA4Common.GlobalSettings.MaxNumberofTrackers = 1;
			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			VWA4Common.GlobalSettings.AddUsersAvailable = false;
			VWA4Common.GlobalSettings.AMWTAvailable = false;
			VWA4Common.GlobalSettings.AdvancedMenuAvailable = false;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = false;
			VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigureStationEntryAvailable = false;
			VWA4Common.GlobalSettings.DaypartEntryAvailable = false;
			VWA4Common.GlobalSettings.DispositionEntryAvailable = false;
			VWA4Common.GlobalSettings.PrePostEntryAvailable = false;
			VWA4Common.GlobalSettings.StationEntryAvailable = false;
			VWA4Common.GlobalSettings.EnterFinancialsAvailable = false;
			VWA4Common.GlobalSettings.EnterSWATNotesAvailable = false;
			VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable = false;
			VWA4Common.GlobalSettings.ImportWasteDataAvailable = false;
			VWA4Common.GlobalSettings.ManageBaselinesAvailable = false;
			VWA4Common.GlobalSettings.ManageDETsAvailable = false;
			VWA4Common.GlobalSettings.ManageEventClientsAvailable = false;
			VWA4Common.GlobalSettings.ManageEventOrdersAvailable = false;
			VWA4Common.GlobalSettings.ManagePreferencesAvailable = false;
			VWA4Common.GlobalSettings.ManageLogFormsAvailable = false;
			VWA4Common.GlobalSettings.ManageReportsAvailable = false;
			VWA4Common.GlobalSettings.ManageSitesAvailable = false;
			VWA4Common.GlobalSettings.ManageTrackersAvailable = false;
			VWA4Common.GlobalSettings.ManageTypesAvailable = false;
			VWA4Common.GlobalSettings.RecurringTransactionsAvailable = false;
			VWA4Common.GlobalSettings.RemoveUsersAvailable = false;
			VWA4Common.GlobalSettings.UpdateTrackerAvailable = false;
		}

		private void initEdgeLicensePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			initEdgeLicenseProperties();
		}
		private void initEdgeLicenseProperties()
		{
			// Limits
			VWA4Common.GlobalSettings.MaxNumberofSites = 1;
			VWA4Common.GlobalSettings.MaxNumberofFoodTypes = 52;
			VWA4Common.GlobalSettings.MaxNumberofLossTypes = 7;
			VWA4Common.GlobalSettings.MaxNumberofUserTypes = 86;
			VWA4Common.GlobalSettings.MaxNumberofDETs = 2;
			VWA4Common.GlobalSettings.MaxNumberofReports = 26;
			VWA4Common.GlobalSettings.MaxNumberofTrackers = 2;
			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			VWA4Common.GlobalSettings.AddUsersAvailable = false;
			VWA4Common.GlobalSettings.AMWTAvailable = false;
			VWA4Common.GlobalSettings.AdvancedMenuAvailable = true;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = false;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = false;
			VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable = false;
			VWA4Common.GlobalSettings.ConfigureStationEntryAvailable = false;
			VWA4Common.GlobalSettings.DaypartEntryAvailable = false;
			VWA4Common.GlobalSettings.DispositionEntryAvailable = false;
			VWA4Common.GlobalSettings.PrePostEntryAvailable = false;
			VWA4Common.GlobalSettings.StationEntryAvailable = false;
			VWA4Common.GlobalSettings.EnterFinancialsAvailable = false;
			VWA4Common.GlobalSettings.EnterSWATNotesAvailable = false;
			VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable = false;
			VWA4Common.GlobalSettings.ImportWasteDataAvailable = false;
			VWA4Common.GlobalSettings.ManageBaselinesAvailable = false;
			VWA4Common.GlobalSettings.ManageDETsAvailable = false;
			VWA4Common.GlobalSettings.ManageEventClientsAvailable = false;
			VWA4Common.GlobalSettings.ManageEventOrdersAvailable = false;
			VWA4Common.GlobalSettings.ManagePreferencesAvailable = false;
			VWA4Common.GlobalSettings.ManageLogFormsAvailable = false;
			VWA4Common.GlobalSettings.ManageReportsAvailable = false;
			VWA4Common.GlobalSettings.ManageSitesAvailable = false;
			VWA4Common.GlobalSettings.ManageTrackersAvailable = false;
			VWA4Common.GlobalSettings.ManageTypesAvailable = false;
			VWA4Common.GlobalSettings.RecurringTransactionsAvailable = false;
			VWA4Common.GlobalSettings.RemoveUsersAvailable = false;
			VWA4Common.GlobalSettings.UpdateTrackerAvailable = false;
		}
		
		
		
		private void initBeyondLicensePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			initMaxLicenseProperties();
		}

		private void initMaxLicenseProperties()
		{
			// Limits
			VWA4Common.GlobalSettings.MaxNumberofSites = 1000;
			VWA4Common.GlobalSettings.MaxNumberofFoodTypes = 1000;
			VWA4Common.GlobalSettings.MaxNumberofLossTypes = 1000;
			VWA4Common.GlobalSettings.MaxNumberofUserTypes = 1000;
			VWA4Common.GlobalSettings.MaxNumberofDETs = 1000;
			VWA4Common.GlobalSettings.MaxNumberofReports = 1000;
			VWA4Common.GlobalSettings.MaxNumberofTrackers = 1000;
			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			VWA4Common.GlobalSettings.AddUsersAvailable = true;
			VWA4Common.GlobalSettings.AMWTAvailable = true;
			VWA4Common.GlobalSettings.AdvancedMenuAvailable = true;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = true;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = true;
			VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable = true;
			VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable = true;
			VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable = true;
			VWA4Common.GlobalSettings.ConfigureStationEntryAvailable = true;
			VWA4Common.GlobalSettings.DaypartEntryAvailable = true;
			VWA4Common.GlobalSettings.DispositionEntryAvailable = true;
			VWA4Common.GlobalSettings.PrePostEntryAvailable = true;
			VWA4Common.GlobalSettings.StationEntryAvailable = true;
			VWA4Common.GlobalSettings.EnterFinancialsAvailable = true;
			VWA4Common.GlobalSettings.EnterSWATNotesAvailable = true;
			VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable = true;
			VWA4Common.GlobalSettings.ImportWasteDataAvailable = true;
			VWA4Common.GlobalSettings.ManageBaselinesAvailable = true;
			VWA4Common.GlobalSettings.ManageDETsAvailable = true;
			VWA4Common.GlobalSettings.ManageEventClientsAvailable = true;
			VWA4Common.GlobalSettings.ManageEventOrdersAvailable = true;
			VWA4Common.GlobalSettings.ManagePreferencesAvailable = true;
			VWA4Common.GlobalSettings.ManageLogFormsAvailable = true;
			VWA4Common.GlobalSettings.ManageReportsAvailable = true;
			VWA4Common.GlobalSettings.ManageSitesAvailable = true;
			VWA4Common.GlobalSettings.ManageTrackersAvailable = true;
			VWA4Common.GlobalSettings.ManageTypesAvailable = true;
			VWA4Common.GlobalSettings.RecurringTransactionsAvailable = true;
			VWA4Common.GlobalSettings.RemoveUsersAvailable = true;
			VWA4Common.GlobalSettings.UpdateTrackerAvailable = true;
		}


		private void saveTestLicensePropertiesToConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveTestLicensePropertiestoConfig();
		}
		private void saveTestLicensePropertiestoConfig()
		{
			// Limits
			SetTestModeLicenseValues f = new SetTestModeLicenseValues();
			f.ShowDialog();
		}

		/// <summary>
		/// Reset the Product UI and related settings as they currently are defined.
		/// </summary>
		void resetProductUI()
		{
			//if (VWA4Common.GlobalSettings.ProductType == 1)
			//{
				// VWA4 Mode
				ucHeader1.resetHeader(VWA4Common.GlobalSettings.ProductType,
					VWA4Common.GlobalSettings.ProductHeaderBackgroundColor);
			//}
			//else
			//{
			//    ucHeader1.resetHeader(VWA4Common.GlobalSettings.ProductType,
			//        VWA4Common.GlobalSettings.ProductHeaderBackgroundColor,
			//        false, false);
			//}
			ucFooter1.resetFooter(VWA4Common.GlobalSettings.ProductFooterBackgroundColor,
				bool.Parse(VWA4Common.GlobalSettings.FooterShortcutsOn),
				bool.Parse(VWA4Common.GlobalSettings.FooterSettingsOn),
				bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn),
				bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn));
			menuStrip1.BackColor =
				VWA4Common.GlobalSettings.ProductMenuBackgroundColor;
			this.Text = VWA4Common.GlobalSettings.ProductName;
			commonEvents.UpdateProductUI = true;
		}

        public void FeatureMessage(string featuretype)
        {
            MessageBox.Show(featuretype + "\nis not supported by the current "
			+ VWA4Common.GlobalSettings.ProductName + " license/user level.\n"
                + "Please contact LeanPath Customer Support for more information.",
				VWA4Common.GlobalSettings.ProductName + " Feature Not Available");
        }

        void dbDetector_PathChanged(object sender, EventArgs e)
        {
        }
       void dbDetector_DBDataChanged(object sender, EventArgs e)
        {
        }
        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
        }

        void commonEvents_TaskDataChanged(object sender, EventArgs e)
        {
            ucTaskList1.LoadData();
        }
	///
	/// Menu Bar Initialization for Tasks Menu Item
	/// 
		private class mItemTag
		{
			public string UniqueName;
			public int ParentID;
			public int Rank;
			public bool Expanded;
			public bool Enabled;

			public mItemTag(string uniquename, int parentid, int rank, bool expanded, bool enabled)
			{
				UniqueName = uniquename;
				ParentID = parentid;
				Rank = rank;
				Expanded = expanded;
				Enabled = enabled;
			}
		}

		// Reload Menu Bar when Week Change event occurs
		void trackerDetector_WeekChanged(object sender, EventArgs e)
		{
			LoadTaskstoMenuBar();
		}
   
		void LoadTaskstoMenuBar()
		{
			tasksToolStripMenuItem.DropDownItems.Clear();
			DataTable dtItems = VWA4Common.DB.Retrieve("SELECT * FROM TaskItems WHERE ParentID <> 0 ORDER BY Rank");
			// Add the items in alphabetical order
			foreach (DataRow irow in dtItems.Rows)
			{
				ToolStripMenuItem tsitem = new ToolStripMenuItem();
				tsitem.Text = irow["DisplayName"].ToString();
				tsitem.Tag = new mItemTag(irow["UniqueName"].ToString(),
					int.Parse(irow["ParentID"].ToString()),
					int.Parse(irow["Rank"].ToString()),
					bool.Parse(irow["Expanded"].ToString()),
					bool.Parse(irow["Enabled"].ToString())
					);
				// If Disabled, make it strikeout
				if (!bool.Parse(irow["Enabled"].ToString()) && VWA4Common.GlobalSettings.IsSuper)
				{
					Font fnt = tsitem.Font;
					fnt	= new Font(fnt, FontStyle.Strikeout);
					tsitem.Font = fnt;
				} else 
				{
					if ((!bool.Parse(irow["Enabled"].ToString()) && VWA4Common.GlobalSettings.IsLogged))
					{
						tsitem.ForeColor = Color.FromArgb(5, 96, 172);
					}
					else
						if (!bool.Parse(irow["Enabled"].ToString())) break;
				}
				if (((mItemTag)tsitem.Tag).Enabled)
					tsitem.Click += new EventHandler(tasksToolStripMenuItem_Click);
				tasksToolStripMenuItem.DropDownItems.Add(tsitem);

			}
		}

		private void tasksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Handle any Tasks > item click
			ToolStripMenuItem snder = (ToolStripMenuItem) sender;
			mItemTag tag = (mItemTag)snder.Tag;
			launchTask(tag.UniqueName.ToLower());
			if (checkAutoUpdate)
			{
				if (bool.Parse(VWA4Common.GlobalSettings.AutoUpdateTrackers))
				{
					commonEvents.TaskSheetKey = TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.TransferConfig);
				}
			}
			checkAutoUpdate = false;
		}

		private void launchTask(string uniquename)
		{
			VWA4Common.GlobalSettings.ExpirationWarningMessage(VWA4Common.Security.Types.ExpirationWarningType.DuringOperation);
			checkAutoUpdate = false;
			switch (uniquename)
			{
				///********************************************
				/// Tasks that are NOT controlled via licensing
				///********************************************
				case "compressdatabase":
					zipDatabaseToolStripMenuItem_Click(this, EventArgs.Empty);
					break;
				case "customreports":
					this.ShowTaskSheet(TaskSheetNames.CustomReports);
					break;
				case "dashboard":
					this.ShowTaskSheet(TaskSheetNames.Dashboard);
					break;
				case "databaseinfo":
					ShowTaskSheet(TaskSheetNames.DatabaseInfo);
					break;
				//case "printpreshiftnotes": .......OLD - obsolete
				case "exitvwa":
					Close();
					break;
				case "managegoals":
					this.ShowTaskSheet(TaskSheetNames.ManageGoals);
					break;
				case "managetags":
					this.ShowTaskSheet(TaskSheetNames.ManageTags);
					break;
				case "printmeetingscript":
					this.ShowTaskSheet(TaskSheetNames.PrintPreShift);
					break;
				case "printswatform":
					this.ShowTaskSheet(TaskSheetNames.PrintSWAT);
					break;
				case "printweeklyreports":
					this.ShowTaskSheet(TaskSheetNames.WeeklyReports);
					break;
				case "reviewreports":
					this.ShowTaskSheet(TaskSheetNames.ReviewReports);
					break;
				case "setdisplayoptions":
					ShowTaskSheet(TaskSheetNames.SetDisplayOptions);
					break;
				case "storedreports":
					this.ShowTaskSheet(TaskSheetNames.StoredReports);
					break;
				case "uploadwastedata":
					VWA4Common.UploadViaHTML upl = new VWA4Common.UploadViaHTML();
					upl.ShowDialog();
					break;
				case "viewwastedata":
					this.ShowTaskSheet(TaskSheetNames.ViewWaste);
					break;
				///********************************************
				/// Tasks that ARE controlled via licensing
				///********************************************
				case "adduser":
					if (VWA4Common.GlobalSettings.AddUsersAvailable)
						//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
						this.ShowTaskSheet(TaskSheetNames.AddUsers);
					else
						FeatureMessage("Add/Remove Users");
					break;
				case "baselinemgr":
					if (VWA4Common.GlobalSettings.ManageBaselinesAvailable)
						ShowTaskSheet(TaskSheetNames.BaselineMgr);
					else
						FeatureMessage("Manage Baselines");
					break;
				case "deleteuser":
					if (VWA4Common.GlobalSettings.RemoveUsersAvailable)
						//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
						this.ShowTaskSheet(TaskSheetNames.RemoveUsers);
					else
						FeatureMessage("Add/Remove Users");
					break;
				case "entermonthlyfinancials":
					if (VWA4Common.GlobalSettings.EnterFinancialsAvailable)
						this.ShowTaskSheet(TaskSheetNames.EnterFinancials);
					else
						FeatureMessage("Enter Financials");
					break;
				//case "enterswatnotes": ..........OLD - obsolete
				case "enterswatminutes":
					if (VWA4Common.GlobalSettings.EnterSWATNotesAvailable)
						ShowTaskSheet(TaskSheetNames.EnterSWATMinutes);
					else
						FeatureMessage("Enter SWAT Notes");
					break;
				//case "enterwastedata":
				//    if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Enter Waste Data"]))
				//        this.ShowTaskSheet(TaskSheetNames.EnterWasteData);
				//    else
				//        FeatureMessage("Enter Waste Data");
				//    break;
				case "enterwastelogs":
					if (VWA4Common.GlobalSettings.AMWTAvailable)
					{
						if (VWA4Common.GlobalSettings.GetDETCount() > 0)
							ShowTaskSheet(TaskSheetNames.EnterWasteLogs);
						else
						{
							MessageBox.Show("No Data Entry Templates are defined - use Manage Data Entry Templates\n"
								+ "to add at least one template before selecting Enter Waste Logs", "Enter Waste Logs");
						}
					}
					else
						FeatureMessage("Enter Waste Logs");
					break;
				case "importwastedata":
					if (VWA4Common.GlobalSettings.ImportWasteDataAvailable)
						//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Import Data"]))
						this.ShowTaskSheet(TaskSheetNames.ImportWaste);
					else
						FeatureMessage("Import Waste Data");
					break;
				case "manageadjustments":
					if (VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable)
						ShowTaskSheet(TaskSheetNames.ManageFoodCostAdjustments);
					else
						FeatureMessage("Manage Food Cost Adjustments");
					break;
				case "managedetemplates":
					if (VWA4Common.GlobalSettings.ManageDETsAvailable)
						ShowTaskSheet(TaskSheetNames.ManageDETemplates);
					else
						FeatureMessage("Manage Data Entry Templates");
					break;
				case "manageeachformats":
					if (VWA4Common.GlobalSettings.ManageDETsAvailable)
						this.ShowTaskSheet(TaskSheetNames.ManageEachFormats);
					else
						FeatureMessage("Manage Each Formats");
					break;
				case "manageeventclients":
					if (VWA4Common.GlobalSettings.ManageEventClientsAvailable)
						this.ShowTaskSheet(TaskSheetNames.ManageEventClients);
					else
						FeatureMessage("Manage Event Clients");
					break;
				case "manageeventorders":
					if (VWA4Common.GlobalSettings.ManageEventOrdersAvailable)
						//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Event Orders"]))
						this.ShowTaskSheet(TaskSheetNames.ManageEventOrders);
					else
						FeatureMessage("Manage Event Orders");
					break;
                case "manageforms":
					if (VWA4Common.GlobalSettings.ManageLogFormsAvailable)
						ShowTaskSheet(TaskSheetNames.ManageLogForms);
					else
						FeatureMessage("Manage Forms");
                    break;
				case "managepreferences":
					if (VWA4Common.GlobalSettings.ManagePreferencesAvailable)
						ShowTaskSheet(TaskSheetNames.ManagePreferences);
					else
						FeatureMessage("Manage Preferences");
					break;
				case "managereports":
					if (VWA4Common.GlobalSettings.ManageReportsAvailable)
						this.ShowTaskSheet(TaskSheetNames.ManageReports);
					else
						FeatureMessage("Manage Event Orders");
					break;
				case "managesites":
					if (VWA4Common.GlobalSettings.ManageSitesAvailable)
					{
						this.Hide();
						VWA4Common.Utilities.launchDelphi(1, VWA4Common.GlobalSettings.IsSuper,
							//VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes"));
								"-1");
					this.Show();
						// Note that Trackers need reloading
						VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
						dbDetector.DBInvalidate = true; // fire (cause) the event
						checkAutoUpdate = true;
					}
					else
						FeatureMessage("Manage Sites");
					break;
				case "managetrackers":
					if (VWA4Common.GlobalSettings.ManageTrackersAvailable)
					{
						this.Hide();
						VWA4Common.Utilities.launchDelphi(3, VWA4Common.GlobalSettings.IsSuper,
							//VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes"));
							"-1");
						this.Show();
						// Note that Trackers need reloading
						VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
						dbDetector.DBInvalidate = true; // fire (cause) the event
						checkAutoUpdate = true;
					}
					else
						FeatureMessage("Manage Trackers");
					break;
				case "managetypes":
					if (VWA4Common.GlobalSettings.ManageTypesAvailable)
					{
						this.Hide();
						VWA4Common.Utilities.launchDelphi(2, VWA4Common.GlobalSettings.IsSuper,
							//VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes"));
							"-1");
						this.Show();
						// Note that Trackers need reloading
						VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
						dbDetector.DBInvalidate = true; // fire (cause) the event
						checkAutoUpdate = true;
					}
					else
						FeatureMessage("Manage Types");
					break;
				case "paperuimanager":
					if (VWA4Common.GlobalSettings.RecurringTransactionsAvailable)
						ShowTaskSheet(TaskSheetNames.ManageRecurringTransactions);
					else
						FeatureMessage("Manage Recurring Transactions");
					break;
				case "setreportoptions":
					if (VWA4Common.GlobalSettings.ManageReportsAvailable)
						ShowTaskSheet(TaskSheetNames.SetReportOptions);
					else
						FeatureMessage("Manage Reports");
					break;
				case "transferconfig":
					if (VWA4Common.GlobalSettings.UpdateTrackerAvailable)
						ShowTaskSheet(TaskSheetNames.TransferConfig);
					else
						FeatureMessage("Update Tracker");
					break;
				default:
					break;
			}
		}


        /// <summary>
        /// Open Database menu command event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool done = false;
			// Give user the opportunity to open a valid database file.
			//  if user cancels, they get a message and one more chance.
			//  if user provides a file, but it is invalid format, then
			//   they get repeated chances to open a valid file.
			while (!done)
			{
				if (!OpenDatabase(""))
				{ // No file was successfully opened
					if (VWA4Common.Errors.ErrorString.Error != "")
						MessageBox.Show(VWA4Common.Errors.ErrorString.Error, VWA4Common.GlobalSettings.ProductName);
					return;
				}
				else
				{ // We have a successful open DB file (unverified)
					// DB is valid - set up
					// Set it in the config file for next restart
					VWA4.Properties.Settings.Default.LastDBPathName =
						VWA4Common.AppContext.DBPathName;
					VWA4.Properties.Settings.Default.Save();
					// Reinitialize key data from new database
					VWA4Common.GlobalSettings.StartDateOfSelectedWeek = null;
					VWA4Common.GlobalSettings.FirstDayOfWeek = null;
					VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn = null;
					VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder = null;
					VWA4Common.GlobalSettings.InvalidateBaseline();
					VWA4Common.DBDetector.GetDBDetector().DBPath = VWA4Common.AppContext.DBPathName;
					// CheckGlobalsForDelphiCommunication();
					done = true;
				}
			}
			// Update everything on the screen when changing task sheets
			ucHeader1.LoadData();
			ucFooter1.LoadData();
			ucTaskList1.LoadData();
			// Navigate to dashboard
			commonEvents.TaskSheetKey = "dashboard";
		}

		/// <summary>
		/// Open specified database file, or browse for a new database.
		/// Check database for validity, and return false if database cannot be opened
		/// either because of not being a valid VW4 database, or because current license limits
		/// do not allow opening this particular file.
		/// </summary>
		/// <param name="dbpathname">Database pathname to open.  If blank, present a
		/// file picker and let user select database.</param>
		/// <returns>true if new database has been opened; false if not.</returns>
		private bool OpenDatabase(string dbpathname)
		{
			string saveDBPathName = VWA4Common.AppContext.DBPathName;
			try
			{
			if (dbpathname == "")
			{ /// let user select the new database
				if (BrowseAndSetDatabaseFile())
				{
					// New database was set
					// Now validate it
					if (ValidDatabaseFile(VWA4Common.AppContext.DBPathName))
					{ // File is good; check limits
						if (DBLimitsinRange(VWA4Common.AppContext.DBPathName))
						{
							//notify other controls that db was changed
							VWA4Common.DBDetector.GetDBDetector().DBPath = VWA4Common.AppContext.DBPathName;
							return true;
						}
					}
					
				}
				// Restore and return not successful
				VWA4Common.AppContext.DBPathName = saveDBPathName;
				return false;
			}
			
			/// Set database according to dppathname
			// Now validate it
			if (ValidDatabaseFile(dbpathname))
			{ // File is good; check limits
				if (DBLimitsinRange(dbpathname))
				{
					// Set and return success
					VWA4Common.AppContext.DBPathName = dbpathname;
					//notify other controls that db was changed
					VWA4Common.DBDetector.GetDBDetector().DBPath = VWA4Common.AppContext.DBPathName;
					return true;
				}
			}
			return false;
			}
			catch
			{
				// Restore and return not successful
				VWA4Common.AppContext.DBPathName = saveDBPathName;
				return false;
			}
		}

        /// <summary>
        /// Present a file picker to open a specified database file.
        /// </summary>
        /// <returns></returns>
        private bool BrowseAndSetDatabaseFile()
        {
			VWA4Common.Errors.ErrorString.Clear();
			OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select DataBase";
            fd.Filter = "DB (*.MDB)|*.mdb|" +
                        "All files (*.*)|*.*";
            // InitialDirectory = current database directory
            if ((VWA4Common.AppContext.DBPathName != "") && (VWA4Common.AppContext.DBPathName != null))
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
				this.TopMost = true;
				// Set it in the Application context property
                VWA4Common.AppContext.DBPathName = fd.FileName;
				this.TopMost = false;
				return true;
            }
			this.TopMost = false;
			return false;
        }

        /// <summary>
        /// Check the Database for being a valid VWA4 formatted DB.
        /// </summary>
        /// <returns>true if database is valid</returns>
		private bool ValidDatabaseFile(string dbpath)
		{
			string dbpathsave = VWA4Common.AppContext.DBPathName;
			VWA4Common.AppContext.DBPathName = dbpath;
			
			VWA4Common.Errors.ErrorString.Clear();
			// First, check whether this is something resembling a VWA4 db
			if (!VWA4Common.DB.TableExists("DBVersion"))
			{
				VWA4Common.Errors.ErrorString.Add("Selected file is not a valid "
					+ VWA4Common.GlobalSettings.ProductName + " database! (DBVersion Table missing)");
			VWA4Common.AppContext.DBPathName = dbpathsave;
				return false;
			}
			// It is an MDB and has the DBVersion file - assume it is a VW database
			int dbversion = 0;
			DataTable dt;
			dt = VWA4Common.DB.Retrieve("SELECT VersionNum FROM DBVersion");
			if ((dt != null && dt.Rows.Count > 0) && (int.TryParse(dt.Rows[0][0].ToString(), out dbversion)))
			{
				// If it has a valid integer, then it is a late-beta at least
				if (dbversion >= 421110)
				{
					/// Database appears to be valid VWA4 format
					VWA4Common.AppContext.DBPathName = dbpathsave;
					return true;
				}
				// Needs to be updated - give user the opportunity
				if (MessageBox.Show("Database selected needs to be upgraded.\n"
					+ "Upgrade now?", "Database Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					/// Proceed to Upgrade form
					VWA4Common.UpdateDB ufrm = new VWA4Common.UpdateDB(dbpath);
					if (ufrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						return true;
					}
				}
				VWA4Common.Errors.ErrorString.Add("Database version is invalid. ("
					+ dbversion.ToString() + ")");
				VWA4Common.AppContext.DBPathName = dbpathsave;
				return false;
			}
			VWA4Common.Errors.ErrorString.Add("Database version is invalid. ("
				+ dt.Rows[0][0].ToString() + ")");
			VWA4Common.AppContext.DBPathName = dbpathsave;
			return false;
		}

		/// <summary>
		/// Check the Database limits against current license limits.
		/// If it fails, VWA4Common.Errors.ErrorString.Error contains error string with details.
		/// </summary>
		/// <returns>false: limit check failed; true: limit check succeeded.</returns>
		private bool DBLimitsinRange(string dbpath)
		{
			VWA4Common.Errors.ErrorString.Clear();
			VWA4Common.Errors.ErrorString.Add("Cannot open selected database - it exceeds License limits as follows:");
			bool errorfound = false;
			VWA4Common.GlobalClasses.VWDBStats dbStats = new VWA4Common.GlobalClasses.VWDBStats();
			VWA4Common.GlobalSettings.GetDBStats(dbpath, dbStats);
			if (dbStats.FoodWasteClassUsed)
			{
				if (!VWA4Common.GlobalSettings.FoodWasteClassAllowed)
				{
					VWA4Common.Errors.ErrorString.Add(" Food Waste Class is used, but not allowed.");
					errorfound = true;
				}
			}
			if (dbStats.NonFoodWasteClassUsed)
			{
				if (!VWA4Common.GlobalSettings.NonFoodWasteClassAllowed)
				{
					VWA4Common.Errors.ErrorString.Add(" Non-Food Waste Class is used, but not allowed.");
					errorfound = true;
				}
			}
			if (dbStats.NumFoodTypes > VWA4Common.GlobalSettings.MaxNumberofFoodTypes)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumFoodTypes.ToString()
					+ " Food Types are enabled; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumLossTypes > VWA4Common.GlobalSettings.MaxNumberofLossTypes)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumLossTypes.ToString()
					+ " Loss Types are enabled; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumUserTypes > VWA4Common.GlobalSettings.MaxNumberofUserTypes)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumUserTypes.ToString()
					+ " User Types are enabled; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumDETs > VWA4Common.GlobalSettings.MaxNumberofDETs)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumDETs.ToString()
					+ " Data Entry Templates are used; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofDETs.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumReports > VWA4Common.GlobalSettings.MaxNumberofReports)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumReports.ToString()
					+ " Reports are defined; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofReports.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumSites > VWA4Common.GlobalSettings.MaxNumberofSites)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumSites.ToString()
					+ " Sites are defined; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofSites.ToString() + ".");
				errorfound = true;
			}

			if (dbStats.NumTrackers > VWA4Common.GlobalSettings.MaxNumberofTrackers)
			{
				VWA4Common.Errors.ErrorString.Add(" - " + dbStats.NumTrackers.ToString()
					+ " Trackers are defined; License limit is "
					+ VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString() + ".");
				errorfound = true;
			}


			if (!errorfound) VWA4Common.Errors.ErrorString.Clear();

			return !errorfound;
		}


		private bool oldValidDatabaseFile(string dbpath)
		{
			if (VWA4Common.DB.TableExists("DBVersion"))
			{
				// We're on the right track!
				// 
				// Check if DBVersion.VersionNum contains 4.0.1 as the first 4 chars
				//
				DataTable dt;
				dt = VWA4Common.DB.Retrieve("SELECT VersionNum FROM DBVersion");
				if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Substring(0, 5) == "4.0.1")
				{
					/// Pre-release database version - need to upgrade
					/// 
					if (MessageBox.Show(this, "Pre-release database format found! Do you want to upgrade it now?",
						"Upgrade Pre-release Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						// Upgrade the database
						VWA4Common.UpdateDB updb = new VWA4Common.UpdateDB();
						string errtbl = updb.UpgradetoDBv402100(dbpath);
						if (errtbl != "")
						{
							// Error was encountered
							MessageBox.Show(this, "Serious error while upgrading this database (table: " + errtbl + ")!  Please call LeanPath at (503)620-6512 for technical support.", "Fatal Database Upgrade Error");
							return false;
						}

					}
					else return false;

					// Do this after database version is validated/upgraded
					return oldCheckDBLimits(dbpath);
				}
				else
				{
					if ((dt != null && dt.Rows.Count > 0) && (int.Parse(dt.Rows[0][0].ToString()) >= 402100))
					{
						// Database is valid
						return oldCheckDBLimits(dbpath);
					}
				}
			}
			else
			{
				// Dead in the water - this is not a VWA database
				MessageBox.Show("Selected database is not a valid "
				+ VWA4Common.GlobalSettings.ProductName + " database!\n (DBVersion missing)");
			}
			return false;
		}
        private bool oldCheckDBLimits(string dbpath)
        {
            bool res = true;
			//int typeLimit = int.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Food Type Limit"));
			int typeLimit = VWA4Common.GlobalSettings.MaxNumberofFoodTypes;
			//int trackerLimit = int.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Tracker Limit"));
			int trackerLimit = VWA4Common.GlobalSettings.MaxNumberofTrackers;
			string oldDB = VWA4Common.AppContext.DBPathName;
            if (typeLimit < 0 && trackerLimit < 0)
                return true;
            VWA4Common.AppContext.DBPathName = dbpath;
            DataTable dt;
            if (typeLimit >= 0)
            {
                dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM FoodType");
                if (dt != null && dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > typeLimit)
                    res = false;
            }
            if (trackerLimit >= 0)
            {
                dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Terminals");
                if (dt != null && dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > trackerLimit)
                    res = false;
            }
            VWA4Common.AppContext.DBPathName = oldDB;
            if (!res && MessageBox.Show(this, "You are exceeding DB Limits. You must be logged in as Administrator to view this DB." + Environment.NewLine +
                "Do you want to Log in as Administrator?", "Log In", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                UserLogin(true);
				res = VWA4Common.GlobalSettings.IsLogged && VWA4Common.GlobalSettings.IsSuper;
            }
            return res;
        }
        /// <summary>
        /// Event handler for Task Explorer commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucTaskList1_TaskListCommandEvent(object sender, UCTaskList.TaskListCommandArgs e)
        {
            switch (e.CommandText)
            {
                case "maindashboard":
                    //typeName = "TaskUserControl.UCReportViewer";
                    this.ShowTaskSheet(TaskSheetNames.Dashboard);
                    break;
                case "reviewreports":
                    //typeName = "TaskUserControl.UCReportViewer";
                    this.ShowTaskSheet(TaskSheetNames.ManageReports);
                    break;
                case "customreports":
                    //typeName = "TaskUserControl.UCReportViewer";
                    this.ShowTaskSheet(TaskSheetNames.CustomReports);
                    break;
                case "storedreports":
                    //typeName = "TaskUserControl.UCReportViewer";
                    this.ShowTaskSheet(TaskSheetNames.StoredReports);
                    break;
            }
        }

        private IVWAUserControlBase _CurrSheet = null;
        /// <summary>
        /// Show a specified Task Sheet on the main screen.
        /// </summary>
        /// <param name="sheetName"></param>
        private void ShowTaskSheet(TaskSheetNames sheetName)
        {
            // Update everything on the screen when changing task sheets
			commonEvents.ShowTaskListControl = true;
			pFarRight.Show();
            ucHeader1.LoadData();
			ucFooter1.LoadData();
            ucTaskList1.LoadData();

            VWA4Common.AppContext.CurrSheetName = sheetName.ToString();

            IVWAUserControlBase sheet;
            try
            {
                if (_CurrSheet != null)
                    _CurrSheet.LeaveSheet();
                sheet = TaskSheets.GetTaskSheet(sheetName);
				//if (sheetName == TaskSheetNames.EnterWasteLogs)
				//{	
				//    ucTaskList1.Hide();
				//}
				//else
				//{	ucTaskList1.Show();
				//}
                sheet.Init(System.DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None));
                sheet.LoadData();

                Control c = (UserControl)sheet;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(c);
                c.Dock = DockStyle.Fill;
                sheet.AutoRun("");
                _CurrSheet = sheet;
				resetProductUI();

				if ((sheetName == TaskSheetNames.EnterWasteLogs) ||
					(sheetName == TaskSheetNames.ManageDETemplates) ||
					(sheetName == TaskSheetNames.ManageLogForms))
				{	// Load WasteLOGGER scheme
					ucHeader1.resetHeader(false, false);
				//    ucFooter1.resetFooter(1, Color.FromArgb(218, 224, 231), false, false, false, false);
				//    menuStrip1.BackColor = Color.FromArgb(127, 174, 65);
				//    VWA4Common.GlobalSettings.ProductType = 3;
				//    commonEvents.UpdateProductUI = true;
				}
				else
				{	// Load Standard VWA scheme
					ucHeader1.resetHeader(true, true);
				//    ucFooter1.resetFooter(1, Color.FromArgb(243, 234, 228), bool.Parse(VWA4Common.GlobalSettings.FooterShortcutsOn), 
				//        bool.Parse(VWA4Common.GlobalSettings.FooterSettingsOn), bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn), 
				//        bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn));
				//    menuStrip1.BackColor = Color.FromArgb(157, 185, 235);
				//    VWA4Common.GlobalSettings.ProductType = 1;
				//    commonEvents.UpdateProductUI = true;
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show("Error in Showing Task Sheet: \n" + ex.Message);
            }

        }


        /// <summary>
        /// Event handler to show a task sheet from elsewhere in VWA4.NET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonEvents_ShowTaskSheet(object sender, VWA4Common.TaskSheetEventArgs e)
        {
			launchTask(e.taskkey);
        }

		private void commonEvents_HideTaskList(object sender, EventArgs e)
		{
			pFarRight.Hide();
		}

        /// <summary>
        /// Dispatcher for handling explorer bar clicks, i.e. launching appropriate task sheets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucTaskList1_ExplorerBar(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            // First, check whether the image or the text was clicked
            if (VWA4Common.AppContext.TaskItemImageClicked)
            {
                /// IMAGE was clicked - change the image
                // Update the database for the item image
                string ssd = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).Date.ToString("yyyyMMdd");
                string sqll = "SELECT * FROM TaskItems ti INNER JOIN TaskStates ts ON ((ti.UniqueName = ts.TaskUniqueName)"
                    + " AND (ti.UniqueName = '"
                    + e.Item.Key + "') AND (Format(ts.WeekStartDate, 'yyyymmdd') = " + ssd + ") AND (ts.SiteID = "
                    + VWA4Common.GlobalSettings.CurrentSiteID.ToString() + "));";
                DataTable dtItemState = VWA4Common.DB.Retrieve(sqll);
                if (dtItemState.Rows.Count == 0)
                {
                    /// No rows found - this means that the current state has to be unchecked
                    // So we need to check it
                    e.Item.Settings.AppearancesSmall.Appearance.Image = 1; // set the Explorer Bar image
                    // Add an entry into the database
                    DataTable dtItem = VWA4Common.DB.Retrieve("SELECT * From TaskItems ti WHERE (ti.UniqueName = '"
                    + e.Item.Key + "');");
                    DataRow dri = dtItem.Rows[0];
                    VWA4Common.DB.Insert("INSERT INTO TaskStates (TaskChecked, WeekStartDate, TaskUniqueName, SiteID) VALUES (True,"
                        + "#" + VWA4Common.VWACommon.DateToString(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None)) + "#, '"
                        + dri["UniqueName"].ToString() + "', " + VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ");");
                }
                else
                {
                    /// A row was found - if it is currently unchecked, then check it and update the database
                    DataRow dri = dtItemState.Rows[0];
                    int tsid = (int)dri["ts.ID"];
                    if (!(bool)dri["TaskChecked"])
                    {
                        // Task is unchecked - update the entry
                        string sql = "UPDATE TaskStates SET TaskChecked = true WHERE ID = " + tsid.ToString() + ";";
                        VWA4Common.DB.Update(sql);
                        e.Item.Settings.AppearancesSmall.Appearance.Image = 1;
                    }
                    else
                    {
                        // Task is checked - update the entry
                        string sql = "UPDATE TaskStates SET TaskChecked = false WHERE ID = " + tsid.ToString() + ";";
                        VWA4Common.DB.Update(sql);
                        e.Item.Settings.AppearancesSmall.Appearance.Image = 0;
                    }

                }
                ucTaskList1.LoadData();
            }
            else
            {
                /// Text was clicked, so launch the Task (load the Task Sheet)
                //UserControls.IVWAUserControlBase ucTaskSheet;

				launchTask(e.Item.Key);
            }
        }

        private void viewWasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewWaste frm = new ViewWaste();
            frm.Show();
        }


        private void trendReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Trend");
            dlg.Show();
        }

        private void detailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Close-Up View");
            dlg.Show();
        }

        private void comparisionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Comparison");
            dlg.Show();
        }

        private void lowParticipationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Low Participation");
            dlg.Show();
        }

        private void crossTabReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Detail");
            dlg.Show();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Employee");
            dlg.Show();
        }

        private void printConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Rankings");
            dlg.Show();
        }
        private void sWATFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("SWAT Agenda");
            dlg.Show();
        }

        private void weeklyTabularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer dlg = new Reports.frmReportViewer("Weekly Tabular");
            dlg.Show();
        }

        //Now we have the task sheet instantiated, initialize it and show it
        //ucTaskSheet.LoadData();
        //todo: put UC IN controls collection
        //todo: display uc (make visible)
        //todo: store a ref in some persistent structure that we can get access to later.





        //UserControl meTuc = (UserControl)Assembly.LoadFrom("taskusercontrol.dll").CreateInstance(typeName);
        //bool isValidated = true;
        //Control found = null;
        //foreach (Control ctrl in ucDashBoard1.Controls)
        //if (ctrl is VWA4.TaskBase)
        //    if (Object.ReferenceEquals(ctrl.GetType(), meTuc.GetType()))//the same type
        //        found = ctrl;
        //    else if (ctrl.Visible)
        //    {
        //        if (((VWA4.TaskBase)ctrl).ValidateExit()) // hide all other controls 
        //            ctrl.Visible = false; 
        //        else
        //            isValidated = false;
        //    }
        //Type meTaskUserControl = meTuc.GetType();
        //PropertyInfo prop = meTaskUserControl.GetProperty("Name");
        //prop.SetValue(meTuc, "Name", null);
        //if (isValidated)
        //{
        //    if(found != null)
        //        found.Visible = true;
        //    else
        //    {
        //        meTuc.Dock = DockStyle.Fill;
        //        ucDashBoard1.Controls.Add(meTuc);
        //    }
        //}


        private void mostRecentWeightDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWA4Common.Query.SaveGlobalSetting("StartDateOfSelectedWeek", null, "DateTime", 0);
            VWA4Common.GlobalSettings.StartDateOfSelectedWeek = null;
            // Update everything on the screen

            ucHeader1.LoadData();
            ucFooter1.LoadData();
            ucTaskList1.LoadData();

        }

        private void vewEventOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControls.EditEventOrder frm = new EditEventOrder();
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Show();
        }

        /// <summary>
        /// Label click event from footer labels - launch appropriate task sheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFooter1_LabelClicked(object sender, UCFooter.LabelClickedEventArgs e)
        {
			switch (e.LabelName)
            {
				case "clicklplogo":
					VWA4Common.UploadViaHTML upl = new VWA4Common.UploadViaHTML("http://leanpath.com");
					upl.ShowDialog();
					break;
				
				case "PaperUIMgr":
					launchTask("paperuimanager");
                    break;
                case "BaselineMgr":
					launchTask("baselinemgr");
                    break;
                case "AddUser":
					//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
					launchTask("adduser");
					//else
					//    FeatureMessage("Add/Remove Users");
                    //ShowTaskSheet(TaskSheetNames.AddUser);
                    break;
                case "DeleteUser":
					//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
						launchTask("deleteuser");
					//else
					//    FeatureMessage("Add/Remove Users");
                    //ShowTaskSheet(TaskSheetNames.DeleteUser);
                    break;
				case "TransferConfig":
					launchTask("transferconfig");
					break;

				case "ManageReports":
					launchTask("managereports");
					break;

				case "CurrentDB":
					EventArgs ea = EventArgs.Empty;
					openDatabaseToolStripMenuItem_Click(this, ea);
					break;

				case "Default":
						UserLogin(false);
						LoadTaskstoMenuBar();
					break;

				case "Manager":
					dbDetector.ManagerLogin = false;
					break;

				case "Administrator":
					dbDetector.SuperLogin = false;
					break;
		
				default:
                    return;
            }
        }


        /// Options Event Routines 

		//private void hideFooterToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    if (hideFooterToolStripMenuItem.Text == "Hide Footer")
		//    {
		//        // Hide the Footer
		//        ucFooter1.Hide();
		//        hideFooterToolStripMenuItem.Text = "Show Footer";
		//    }
		//    else
		//    {
		//        // Show the Footer
		//        ucFooter1.Show();
		//        hideFooterToolStripMenuItem.Text = "Hide Footer";
		//    }
		//}
		/// <summary>
		/// Invoke Transfer Configuration / Update Tracker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void updateTrackerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			launchTask("transferconfig");
		}

		/// <summary>
		/// Invoke Add User
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
			launchTask("adduser");
			//else
			//    FeatureMessage("Add/Remove Users");
		}

		/// <summary>
		/// Invoke Remove User
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
				launchTask("deleteuser");
			//else
			//    FeatureMessage("Add/Remove Users");
		}


        private void manageTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			launchTask("managetypes");
			//this.Hide();
			//VWA4Common.Utilities.launchDelphi(2, VWA4Common.SecurityManager.IsSuper);
			//this.Show();
			//dbDetector.DBInvalidate = true; // fire (cause) the event
			if (checkAutoUpdate)
			{
				if (bool.Parse(VWA4Common.GlobalSettings.AutoUpdateTrackers))
				{
					commonEvents.TaskSheetKey = TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.TransferConfig);
				}
			}
			checkAutoUpdate = false;
		}

        private void manageTrackersToolStripMenuItem_Click(object sender, EventArgs e)
        {
			launchTask("managetrackers");
			//this.Hide();
			//VWA4Common.Utilities.launchDelphi(3, VWA4Common.SecurityManager.IsSuper);
			//this.Show();
			//dbDetector.DBInvalidate = true; // fire (cause) the event
			if (checkAutoUpdate)
			{
				if (bool.Parse(VWA4Common.GlobalSettings.AutoUpdateTrackers))
				{
					commonEvents.TaskSheetKey = TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.TransferConfig);
				}
			}
			checkAutoUpdate = false;
		}

        private void manageSitesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			launchTask("managesites");
			//this.Hide();
			//VWA4Common.Utilities.launchDelphi(1, VWA4Common.SecurityManager.IsSuper);
			//this.Show();
			//dbDetector.DBInvalidate = true; // fire (cause) the event
			if (checkAutoUpdate)
			{
				if (bool.Parse(VWA4Common.GlobalSettings.AutoUpdateTrackers))
				{
					commonEvents.TaskSheetKey = TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.TransferConfig);
				}
			}
			checkAutoUpdate = false;
		}

		private void managePreferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.ManagePreferences);
			dbDetector.DBInvalidate = true; // fire (cause) the event
		}

		/// <summary>
		/// Set Report Options
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void setReportOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.SetReportOptions);
		}
		/// <summary>
		/// Set Display Options
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void setDisplayOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.SetDisplayOptions);
			dbDetector.DBInvalidate = true; // fire (cause) the event
		}

        private void manageRecurringTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTaskSheet(TaskSheetNames.ManageRecurringTransactions);
            dbDetector.DBInvalidate = true; // fire (cause) the event
        }
		private void manageBaselinesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.BaselineMgr);
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fabout = new AboutBox();
            fabout.ShowDialog();
        }

        private void databaseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
			launchTask("databaseinfo");
        }

        private void manageFoodCostAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			launchTask("manageadjustments");
			// Mila: I don't understand why do we need invalidate here
            //dbDetector.DBInvalidate = true; // fire (cause) the event
        }
		private void manageReportsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			launchTask("managereports");
		}

        private void manageEventClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			launchTask("manageeventclients");
            dbDetector.DBInvalidate = true; // fire (cause) the event
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(logToolStripMenuItem.Text, "Login"))
            {
                UserLogin(false);
            }
            else
            {
                if (Regex.IsMatch(logToolStripMenuItem.Text, "Administrator"))
                    dbDetector.SuperLogin = false;
                else
                    dbDetector.ManagerLogin = false;
            }
        }

        private void UserLogin(bool isSuper)
        {
			//VWA4Common.frmLogin frm = new VWA4Common.frmLogin(isSuper, VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manager Password"), VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Administrator Password"));
			VWA4Common.frmLogin frm = 
				new VWA4Common.frmLogin(isSuper, VWA4Common.GlobalSettings.ManagerPassword, VWA4Common.GlobalSettings.AdministratorPassword);
			frm.ShowDialog(this);
			//if (frm.ShowDialog(this) == DialogResult.OK)
			//{
			//    //if (frm.NewPIN != "")
			//    //    VWA4Common.GlobalSettings.GetSecurityManager().SaveNewPIN(frm.IsSuper, frm.NewPIN);
			//}
        }

        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
        {
			//VWA4Common.GlobalSettings.IsLogged = e.IsLogin;
			//VWA4Common.GlobalSettings.IsSuper = e.IsSuper;
            if (e.IsLogin)
            {
				VWA4Common.GlobalSettings.UserLevel = 1;
				logToolStripMenuItem.Text = "Log Off " + (e.IsSuper ? "Administrator" : "Manager");
                //superUserLoginToolStripMenuItem.Text = Regex.Replace(superUserLoginToolStripMenuItem.Text, "Log Off", "Login");
				if (e.IsSuper) VWA4Common.GlobalSettings.UserLevel = 2;
				AddDBManagerMenus();
                // CheckGlobalsForDelphiCommunication();
            }
            else
            {
                //superUserLoginToolStripMenuItem.Text = Regex.Replace(superUserLoginToolStripMenuItem.Text, "Login", "Log Off");
				VWA4Common.GlobalSettings.UserLevel = 0;
				logToolStripMenuItem.Text = "Login";
                DeleteDBManagerMenus();
            }
        }

        private void AddDBManagerMenus()
        {
			//manageEventClientsToolStripMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Event Clients available"));
			//manageFoodCostAdjustmentsToolStripMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Food Cost Adjustments available"));
			//manageRecurringTransactionsToolStripMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Recurring Transactions enable"));
			////mila todo:
			//manageTypesMenuItem.Visible = (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Food Type Limit") == "0");
			//manageSitesMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Sites available"));
			//manageTrackersMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Trackers available"));
			//manageBaselinesToolStripMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Baselines available"));

			//setPreferencesToolStripMenuItem.Visible = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Preferences available"));
			manageEventClientsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageEventClientsAvailable;
			manageFoodCostAdjustmentsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable;
			manageRecurringTransactionsToolStripMenuItem.Visible = VWA4Common.GlobalSettings.RecurringTransactionsAvailable;
			//mila todo:
			manageTypesMenuItem.Visible = VWA4Common.GlobalSettings.ManageTypesAvailable;
			manageSitesMenuItem.Visible = VWA4Common.GlobalSettings.ManageSitesAvailable;
			manageTrackersMenuItem.Visible = VWA4Common.GlobalSettings.ManageTrackersAvailable;
			manageBaselinesToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManageBaselinesAvailable;

			setPreferencesToolStripMenuItem.Visible = VWA4Common.GlobalSettings.ManagePreferencesAvailable;
		}
        private void DeleteDBManagerMenus()
        {
            manageEventClientsToolStripMenuItem.Visible = false;
            manageFoodCostAdjustmentsToolStripMenuItem.Visible = false;
            manageRecurringTransactionsToolStripMenuItem.Visible = false;
            manageTypesMenuItem.Visible = false;
            manageSitesMenuItem.Visible = false;
            manageTrackersMenuItem.Visible = false;

            setPreferencesToolStripMenuItem.Visible = false;
        }
		private void EnableorDisableDelphiMenus()
		{
			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\" + VWA4Common.GlobalSettings.VWA4DelphiFileName))
			{
				// Disable the Advanced Menus
				manageTypesMenuItem.Enabled = false;
				manageTrackersMenuItem.Enabled = false;
				manageSitesMenuItem.Enabled = false;
			}
			else
			{
				// Disable the Advanced Menus
				manageTypesMenuItem.Enabled = true;
				manageTrackersMenuItem.Enabled = true;
				manageSitesMenuItem.Enabled = true;
			}
		}

        private void SetGlobalVarsforDelphiCommunication()
        {
            // Set the global variables that tell Delphi what functions are available based on login level
			//VWA4Common.Query.SaveGlobalSetting("ManageTypes", VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Types"), "Boolean", 0);
			//VWA4Common.Query.SaveGlobalSetting("ManageTrackers", VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Trackers"), "Boolean", 0);
			//VWA4Common.Query.SaveGlobalSetting("ManageSites", VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Sites"), "Boolean", 0);
			//VWA4Common.Query.SaveGlobalSetting("ManageEventOrders", VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Event Orders"), "Boolean", 0);
			VWA4Common.Query.SaveGlobalSetting("ManageTypes", VWA4Common.GlobalSettings.ManageTypesAvailable.ToString(), "Boolean", 0);
			VWA4Common.Query.SaveGlobalSetting("ManageTrackers", VWA4Common.GlobalSettings.ManageTrackersAvailable.ToString(), "Boolean", 0);
			VWA4Common.Query.SaveGlobalSetting("ManageSites", VWA4Common.GlobalSettings.ManageSitesAvailable.ToString(), "Boolean", 0);
			VWA4Common.Query.SaveGlobalSetting("ManageEventOrders", VWA4Common.GlobalSettings.ManageEventOrdersAvailable.ToString(), "Boolean", 0);
		}

        private void ClearGlobalVarsforDelphiCommunication()
        {
            // Clear the global variables that tell Delphi what functions are available based on login level
            VWA4Common.Query.SaveGlobalSetting("ManageTypes", "false", "Boolean", 0);
            VWA4Common.Query.SaveGlobalSetting("ManageTrackers", "false", "Boolean", 0);
            VWA4Common.Query.SaveGlobalSetting("ManageSites", "false", "Boolean", 0);
            VWA4Common.Query.SaveGlobalSetting("ManageEventOrders", "false", "Boolean", 0);
        }

        private void configurationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewer frmReport = new frmReportViewer("Configuration");
            //frmReport.HideTopPanel();
            frmReport.ShowDialog();
        }

//        private void CheckGlobalsForDelphiCommunication()
//        {
//            /// Set Globals for communicating with Delphi configurator via the database
//            /// 
//            string licenseDate = VWA4Common.GlobalSettings.LastLicenseCheckDate;
//            if (licenseDate == "" || DateTime.Parse(licenseDate) == new DateTime(0)
//                || DateTime.Parse(licenseDate) < new System.IO.FileInfo(VWA4Common.SecurityManager.GetSecurityManager().LicenseName).LastWriteTime)
//{
//                VWA4Common.GlobalSettings.LastLicenseCheckDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
//                SetGlobalVarsforDelphiCommunication();
//                // Tracker Limit
//                //string trkrlimit = VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Tracker Limit");
//                string trkrlimit = VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString();
//                VWA4Common.Query.SaveGlobalSetting("TrackerLimit", trkrlimit, "Number", 0);
//                // Type Limit
//                //string typelimit = VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Food Type Limit");
//                string typelimit = VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString();
//                VWA4Common.Query.SaveGlobalSetting("TypeLimit", typelimit, "Number", 0);
//                VWA4Common.Query.SaveGlobalSetting("LicenseFilePath", VWA4Common.SecurityManager.GetSecurityManager().LicenseName, "FilePath", 0);
//                //VWA4Common.Query.SaveGlobalSetting("LicenseExpirationDate", VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Expiration Date"), "DateTime", 0);
//                VWA4Common.Query.SaveGlobalSetting("LicenseExpirationDate", VWA4Common.GlobalSettings.ExpirationDate.ToShortDateString(), "DateTime", 0);
//}
//        }

		private static string _ZIPInitialDirectory;
		/// <summary>
		/// Compress Current Database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void zipDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_ZIPInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			try
			{
				SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
				dlg.InitialDirectory = _ZIPInitialDirectory;
				dlg.Filter = "Archive files (*.zip)|*.zip|All files (*.*)|*.*";
				dlg.Title = "Save Compressed Database As";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					this.Cursor = Cursors.WaitCursor;
					string dbPath = VWA4Common.AppContext.DBPathName;
					ZipFile zip = new ZipFile();
					ZipEntry entry = zip.AddFile(dbPath,"\\");
					entry.Comment = "Compressed using VWA4.NET (" + DateTime.Now.ToShortTimeString() + "  " + DateTime.Now.ToShortDateString() + ")";
					zip.Save(dlg.FileName);
					_ZIPInitialDirectory = new System.IO.FileInfo(dlg.FileName).DirectoryName;

				}

			} // end try
			catch (InvalidDataException)
			{
				MessageBox.Show("Error: The file being read contains invalid data.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Error:The file specified was not found.");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Error: path is a zero-length string, contains only white space, or contains one or more invalid characters");
			}
			catch (PathTooLongException)
			{
				MessageBox.Show("Error: The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.");
			}
			catch (DirectoryNotFoundException)
			{
				MessageBox.Show("Error: The specified path is invalid, such as being on an unmapped drive.");
			}
			catch (IOException)
			{
				MessageBox.Show("Error: An I/O error occurred while opening the file.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Error: path specified a file that is read-only, the path is a directory, or caller does not have the required permissions.");
			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show("Error: You must provide parameters for MyGZIP.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Compress Archive Directory
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void compressArchiveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_ZIPInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			try
			{
				SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
				dlg.InitialDirectory = _ZIPInitialDirectory;
				dlg.Filter = "Archive files (*.zip)|*.zip|All files (*.*)|*.*";
				dlg.Title = "Save Compressed Archive As";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					this.Cursor = Cursors.WaitCursor;
					string archivedirPath = VWA4Common.GlobalSettings.VirtualAppDir + "\\Archive";
					ZipFile zip = new ZipFile();
					ZipEntry entry = zip.AddDirectory(archivedirPath,"\\");
					entry.Comment = "Compressed using VWA4.NET (" + DateTime.Now.ToShortTimeString() + "  " + DateTime.Now.ToShortDateString() + ")";
					zip.Save(dlg.FileName);
					_ZIPInitialDirectory = new System.IO.FileInfo(dlg.FileName).DirectoryName;

				}

			} // end try
			catch (InvalidDataException)
			{
				MessageBox.Show("Error: The file being read contains invalid data.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Error:The file specified was not found.");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Error: path is a zero-length string, contains only white space, or contains one or more invalid characters");
			}
			catch (PathTooLongException)
			{
				MessageBox.Show("Error: The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.");
			}
			catch (DirectoryNotFoundException)
			{
				MessageBox.Show("Error: The specified path is invalid, such as being on an unmapped drive.");
			}
			catch (IOException)
			{
				MessageBox.Show("Error: An I/O error occurred while opening the file.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Error: path specified a file that is read-only, the path is a directory, or caller does not have the required permissions.");
			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show("Error: You must provide parameters for MyGZIP.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		//private static string _ZIPInitialDirectory;
		//private void zipDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    _ZIPInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//    //FileStream infile;

		//    try
		//    {
		//        SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
		//        dlg.InitialDirectory = _ZIPInitialDirectory;
		//        dlg.Filter = "Archive files (*.zip)|*.zip|All files (*.*)|*.*";
		//        dlg.Title = "Save Compressed Database As";
		//        if (dlg.ShowDialog() == DialogResult.OK)
		//        {
		//            this.Cursor = Cursors.WaitCursor;
		//            string dbPath = VWA4Common.AppContext.DBPathName;

		//            FileStream fileStreamIn = new FileStream(dbPath, FileMode.Open, FileAccess.Read);
		//            FileStream fileStreamOut = new FileStream
		//                (dlg.FileName, FileMode.Create, FileAccess.Write);
		//            ZipOutputStream zipOutStream = new ZipOutputStream(fileStreamOut);
		//            byte[] buffer = new byte[fileStreamIn.Length];
		//            ZipEntry entry = new ZipEntry(Path.GetFileName(dbPath));
		//            zipOutStream.PutNextEntry(entry);
		//            int size;
		//            do
		//            {
		//                size = fileStreamIn.Read(buffer, 0, buffer.Length);
		//                zipOutStream.Write(buffer, 0, size);
		//            } while (size > 0);
		//            zipOutStream.Close();
		//            fileStreamOut.Close();
		//            fileStreamIn.Close();


		//            _ZIPInitialDirectory = new System.IO.FileInfo(dlg.FileName).DirectoryName;

		//            this.Cursor = Cursors.Default;
		//        }

		//    } // end try
		//    catch (InvalidDataException)
		//    {
		//        MessageBox.Show("Error: The file being read contains invalid data.");
		//    }
		//    catch (FileNotFoundException)
		//    {
		//        MessageBox.Show("Error:The file specified was not found.");
		//    }
		//    catch (ArgumentException)
		//    {
		//        MessageBox.Show("Error: path is a zero-length string, contains only white space, or contains one or more invalid characters");
		//    }
		//    catch (PathTooLongException)
		//    {
		//        MessageBox.Show("Error: The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.");
		//    }
		//    catch (DirectoryNotFoundException)
		//    {
		//        MessageBox.Show("Error: The specified path is invalid, such as being on an unmapped drive.");
		//    }
		//    catch (IOException)
		//    {
		//        MessageBox.Show("Error: An I/O error occurred while opening the file.");
		//    }
		//    catch (UnauthorizedAccessException)
		//    {
		//        MessageBox.Show("Error: path specified a file that is read-only, the path is a directory, or caller does not have the required permissions.");
		//    }
		//    catch (IndexOutOfRangeException)
		//    {
		//        MessageBox.Show("Error: You must provide parameters for MyGZIP.");
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("Error: " + ex.Message);
		//    }
		//    finally
		//    {
		//        this.Cursor = Cursors.Default;
		//    }
		//}
		
		private void reactivateLicenseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.ActivateLicense(true);
		}

		private void installNewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (VWA4Common.GlobalSettings.InstallLicense())
			{
				VWA4Common.GlobalSettings.ActivateLicense(false);
			}
		}

		private void ucFooter1_Load(object sender, EventArgs e)
		{

		}
		private void lAnyNavLabel_MouseEnter(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			pb.BorderStyle = BorderStyle.FixedSingle;
		}

		private void lAnyNavLabel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			pb.BorderStyle = BorderStyle.None;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			VWA4Common.Utilities.printUserControl(this, "Dashboard", panel1.Left+4, panel1.Top+ucHeader1.Height-10, panel1.Width, panel1.Height-8);
		}

		private void licenseAgreementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowEULA se = new ShowEULA();
			se.ShowDialog();
		}

		private void enterWasteLogSheetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/// Change Screen character to WasteLogger
			
			launchTask("enterwastelogs");
		}

		private void manageFormsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			launchTask("manageforms");
		}

		private void hideTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (ucTaskList1.Visible)
			{
				commonEvents.HideTaskListControl = true;
				hideTaskbarToolStripMenuItem.Text = "Show Task List";
			}
			else
			{
				commonEvents.ShowTaskListControl = true;
				hideTaskbarToolStripMenuItem.Text = "Hide Task List";
			}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void setUIToVWA4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.ProductType = 1;
			resetProductUI();
		}

		private void setUIToWasteLOGGERToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.ProductType = 3;
			resetProductUI();
		}

		private void manageDETtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			launchTask("managedetemplates");
		}

		private void cPUIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCPUID fc = new frmCPUID();
			fc.ShowDialog();
		}

		private void upgradeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.UpdateDB udb = new VWA4Common.UpdateDB();
			udb.ShowDialog();
		}

		private void viewLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLicenseInfo fi = new frmLicenseInfo();
			fi.ShowDialog();
		}

		private void manageEachFormatsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.ManageEachFormats);
		}

		private void VWAMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			VWA4Common.GlobalSettings.ExpirationWarningMessage(VWA4Common.Security.Types.ExpirationWarningType.OnProgramExit);

		}

		private void manageTagsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.ManageTags);
		}

		private void manageGoalsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowTaskSheet(TaskSheetNames.ManageGoals);
		}

		/// Removed 2/22/11 by SAR - not used anywhere
		//private void viewSavedWasteToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    MemorizedReports dlg = new MemorizedReports();
		//    ViewWaste frm;
		//    dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		//    try
		//    {
		//        if (dlg.ShowDialog() == DialogResult.OK)
		//        {
		//            frm = new ViewWaste(dlg.ReportName);
		//        }
		//        else
		//            frm = new ViewWaste();
		//        frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		//        frm.Show();
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(null, "Error in loading report: " + ex.Message, "Project Error",
		//            MessageBoxButtons.OK, MessageBoxIcon.Error);
		//    }
		//}


    }
}
