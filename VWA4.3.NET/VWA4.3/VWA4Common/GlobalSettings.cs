﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using System.Management;
using VWA4Common.Security;
using VWA4Common.Security.Types;
using System.Reflection;

namespace VWA4Common
{
	/// <summary>
	/// This class contains all the encapsulated global settings available to
	/// VWA4 during normal operation.
	/// 
	/// Most global settings can be altered based upon VWA4 configuration settings, e.g.
	/// the FirstDayOfWeek setting can be set by the user via an administration UI.  
	/// 
	/// Wherever possible/appropriate, the global settings are stored in the database
	/// so that anyone opening the database inherits the settings automatically.
	/// To implement this type of global setting, the code first checks the database
	/// to see if the setting's default value (embedded resource or constant)
	/// has been changed.  If it has (which means it would be found by name in the
	/// GlobalVars table), then that value is used as the setting; if not,
	/// then the built-in default is used.
	/// 
	/// For obvious performance reasons, the settings are stored in memory in encapsulated local
	/// variables, which are initialized via the above process the first time they are accessed.
	/// All subsequent accesses are made from the local variables. 
	/// 
	/// At time of this writing it is not planned to implement a sync
	/// method to execute prior to program termination.
	/// This, given the above architecture, means that any process that changes 
	/// the settings must change them in both places - 
	/// locally in the variable, and in the database (if the settings are to be persisted beyond
	/// the current session).  
	/// 
	/// 
	/// </summary>
	public static class GlobalSettings
	{
		///***********************************************************************************
		///***********************************************************************************
		//	Development/Support Methods
		///***********************************************************************************
		///***********************************************************************************


		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		//	License/Versioning Related
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************

		static public bool Initialized = false;
		
		///
		/// Load properties from License file
		///

		static public bool InstallLicense()
		{
			// 
			// Let User pick a new license file
			//
			string errmsg2 = "";
			if (VWA4Common.Security.LicenseManager.InstallNewLicense(out errmsg2))
			{ // License file copied in successfully
				MessageBox.Show("License file copied successfully!  Click OK to continue."
					, VWA4Common.GlobalSettings.ProductName);
				return VWA4Common.GlobalSettings.LoadGlobalsfromLicenseFile(out errmsg2);
			}
			else
			{ // Cancelled, or problem copying file

				if (errmsg2 != "")
				{
					MessageBox.Show("License file did not install successfully: " + errmsg2
						, VWA4Common.GlobalSettings.ProductName);
				}
				return false;
			}
		}
		
		static public bool LoadGlobalsfromLicenseFile(out string errmsg)
		{
			errmsg = "";
			if (!LicenseManager.IsInited())
			{
				errmsg = "License Manager not initialized. (LoadGlobalsfromLicenseFile)";
				return false;
			}
			try
			{
				AllowedWasteClassesType fca = (AllowedWasteClassesType)Enum.Parse(typeof(AllowedWasteClassesType), LicenseManager.GetValue("FoodWasteClassAllowed"), true);

				// AddNewCollectionAvailable
				AddNewCollectionAvailable = bool.Parse(LicenseManager.GetValue("AddNewCollectionAvailable"));
				// AddNewReportAvailable
				AddNewReportAvailable = bool.Parse(LicenseManager.GetValue("AddNewReportAvailable"));
				// AddUsersAvailable
				AddUsersAvailable = bool.Parse(LicenseManager.GetValue("AddUsersAvailable"));
				// AdministratorPassword
				AdministratorPassword = LicenseManager.GetValue("AdministratorPassword");
				// AdvancedMenuAvailable
				AdvancedMenuAvailable = bool.Parse(LicenseManager.GetValue("AdvancedMenuAvailable"));		
				
				// AMWTAvailable
				AMWTAvailable = bool.Parse(LicenseManager.GetValue("AMWTAvailable"));
				// CloneReportAvailable
				CloneReportAvailable = bool.Parse(LicenseManager.GetValue("CloneReportAvailable"));
				// ConfiguratorAvailable
				ConfiguratorAvailable = bool.Parse(LicenseManager.GetValue("ConfiguratorAvailable"));
				// ConfigureDaypartEntryAvailable
				ConfigureDaypartEntryAvailable = bool.Parse(LicenseManager.GetValue("ConfigureDaypartEntryAvailable"));
				// ConfigureDispositionEntryAvailable
				ConfigureDispositionEntryAvailable = bool.Parse(LicenseManager.GetValue("ConfigureDispositionEntryAvailable"));
				// ConfigurePrePostEntryAvailable
				ConfigurePrePostEntryAvailable = bool.Parse(LicenseManager.GetValue("ConfigurePrePostEntryAvailable"));
				// ConfigureStationEntryAvailable
				ConfigureStationEntryAvailable = bool.Parse(LicenseManager.GetValue("ConfigureStationEntryAvailable"));
				// CPU_ID
				CPU_ID = LicenseManager.GetValue("CPU_ID");
				// DaypartEntryAvailable
				DaypartEntryAvailable = bool.Parse(LicenseManager.GetValue("DaypartEntryAvailable"));
				// DefaultUserLevel
				DefaultUserLevel = LicenseManager.GetValue("DefaultUserLevel");
				// DispositionEntryAvailable
				DispositionEntryAvailable = bool.Parse(LicenseManager.GetValue("DispositionEntryAvailable"));
				// EnterFinancialsAvailable
				EnterFinancialsAvailable = bool.Parse(LicenseManager.GetValue("EnterFinancialsAvailable"));
				// EnterSWATNotesAvailable
				EnterSWATNotesAvailable = bool.Parse(LicenseManager.GetValue("EnterSWATNotesAvailable"));
				// ExpirationDate
				DateTime dt = ExpirationDate;
				DateTime.TryParse(LicenseManager.GetValue("ExpirationDate"), out dt);
				ExpirationDate = dt;
				// ExpirationWarningsBeginDate
				dt = ExpirationWarningsBeginDate;
				DateTime.TryParse(LicenseManager.GetValue("ExpirationWarningsBeginDate"), out dt);
				ExpirationWarningsBeginDate = dt;
				// ExpirationWarningsMode
				ExpirationWarningsModeString = LicenseManager.GetValue("ExpirationWarningsMode");
				// ExpirationWarningsFrequency
                ExpirationWarningsFrequency = LicenseManager.GetExpirationFrequency();
				// FoodCostAdjustmentsAvailable
				FoodCostAdjustmentsAvailable = bool.Parse(LicenseManager.GetValue("FoodCostAdjustmentsAvailable"));
				/// FoodWasteClassAllowed  (this needs to be checked!)
				FoodWasteClassAllowed = (fca == AllowedWasteClassesType.Food || fca == AllowedWasteClassesType.AllWasteClasses);
				// ImportWasteDataAvailable
				ImportWasteDataAvailable = bool.Parse(LicenseManager.GetValue("ImportWasteDataAvailable"));
				// LicenseType
				LicenseType = LicenseManager.GetValue("LicenseType") == VWA4Common.Security.Types.LicenseType.CPU.ToString() ? 2 : 1;
				// ManageBaselinesAvailable
				ManageBaselinesAvailable = bool.Parse(LicenseManager.GetValue("ManageBaselinesAvailable"));
				// ManageDETsAvailable
				ManageDETsAvailable = bool.Parse(LicenseManager.GetValue("ManageDETsAvailable"));
				// ManageEventClientsAvailable
				ManageEventClientsAvailable = bool.Parse(LicenseManager.GetValue("ManageEventClientsAvailable"));
				// ManageEventOrdersAvailable
				ManageEventOrdersAvailable = bool.Parse(LicenseManager.GetValue("ManageEventOrdersAvailable"));
				// ManageLogFormsAvailable
				ManageLogFormsAvailable = bool.Parse(LicenseManager.GetValue("ManageLogFormsAvailable"));
				// ManagePreferencesAvailable
				ManagePreferencesAvailable = bool.Parse(LicenseManager.GetValue("ManagePreferencesAvailable"));
				// ManageReportsAvailable
				ManageReportsAvailable = bool.Parse(LicenseManager.GetValue("ManageReportsAvailable"));
				// ManageSitesAvailable
				ManageSitesAvailable = bool.Parse(LicenseManager.GetValue("ManageSitesAvailable"));
				// ManageTrackersAvailable
				ManageTrackersAvailable = bool.Parse(LicenseManager.GetValue("ManageTrackersAvailable"));
				// ManagerPassword
				ManagerPassword = LicenseManager.GetValue("ManagerPassword");
				// ManageTypesAvailable
				ManageTypesAvailable = bool.Parse(LicenseManager.GetValue("ManageTypesAvailable"));
				// MaxNumberofFoodTypes
				int res = MaxNumberofFoodTypes;
				int.TryParse(LicenseManager.GetValue("MaxNumberofFoodTypes"), out res);
				MaxNumberofFoodTypes = res;
				// MaxNumberofLossTypes
				res = MaxNumberofLossTypes;
				int.TryParse(LicenseManager.GetValue("MaxNumberofLossTypes"), out res);
				MaxNumberofLossTypes = res;
				// MaxNumberofSites
				res = MaxNumberofSites;
				int.TryParse(LicenseManager.GetValue("MaxNumberofSites"), out res);
				MaxNumberofSites = res;
				// MaxNumberofTrackers
				res = MaxNumberofTrackers;
				int.TryParse(LicenseManager.GetValue("MaxNumberofTrackers"), out res);
				MaxNumberofTrackers = res;
				// MaxNumberofUserTypes
				res = MaxNumberofUserTypes;
				int.TryParse(LicenseManager.GetValue("MaxNumberofUserTypes"), out res);
				MaxNumberofUserTypes = res;
				// MaxNumberofDETs
				res = MaxNumberofDETs;
				int.TryParse(LicenseManager.GetValue("MaxNumberofDETs"), out res);
				MaxNumberofDETs = res;
				// MaxNumberofReports
				res = MaxNumberofReports;
				int.TryParse(LicenseManager.GetValue("MaxNumberofReports"), out res);
				MaxNumberofReports = res;
				/// NonFoodWasteClassAllowed (this needs to be checked!)
				NonFoodWasteClassAllowed = (fca == AllowedWasteClassesType.NonFood || fca == AllowedWasteClassesType.AllWasteClasses);
				// PrePostEntryAvailable
				PrePostEntryAvailable = bool.Parse(LicenseManager.GetValue("PrePostEntryAvailable"));
				// ProductType
				ProductType = int.Parse(LicenseManager.GetValue("ProductType"));
				// RecurringTransactionsAvailable
				RecurringTransactionsAvailable = bool.Parse(LicenseManager.GetValue("RecurringTransactionsAvailable"));
				// RemoveUsersAvailable
				RemoveUsersAvailable = bool.Parse(LicenseManager.GetValue("RemoveUsersAvailable"));
				// ShowSupportEmailAddress
				ShowSupportEmailAddress = bool.Parse(LicenseManager.GetValue("ShowSupportEmailAddress"));
				// ShowSupportPhoneNumber
				ShowSupportPhoneNumber = bool.Parse(LicenseManager.GetValue("ShowSupportPhoneNumber"));
				// ShowSupportWebsite
				ShowSupportWebsite = bool.Parse(LicenseManager.GetValue("ShowSupportWebsite"));
				// StationEntryAvailable
				StationEntryAvailable = bool.Parse(LicenseManager.GetValue("StationEntryAvailable"));
				// SupportEmailAddress
				SupportEmailAddress = LicenseManager.GetValue("SupportEmailAddress");
				// SupportPhoneNumber
				SupportPhoneNumber = LicenseManager.GetValue("SupportPhoneNumber");
				// SupportWebsite
				SupportWebsite = LicenseManager.GetValue("SupportWebsite");
				// UpdateTrackerAvailable
				UpdateTrackerAvailable = bool.Parse(LicenseManager.GetValue("UpdateTrackerAvailable"));
				errmsg = "";
				return true;
			}
			catch (Exception ex)
			{
				errmsg = "Unable to load settings from specified license file: \n" + ex.Message;
			}
			return false;
		}
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ClientID"] = p.ClientID.ToString();
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ClientName"] = p.ClientName;
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["Generatedby"] = p.GeneratedBy;
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["GeneratedDate"] = p.GeneratedDate.ToString();
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["IsActivated"] = "False";
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["LicenseID"] = p.LicenseID.ToString();
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["LicenseSerialNumber"] = p.LicenseKey;
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ProductVersionName"] = p.ProductVersionName;
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SiteID"] = p.SiteID.ToString();
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SiteName"] = p.SiteName;
		//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SupportWebsite"] = p.SupportWebSiteURL;        

		static public bool WriteGlobalstoNameValueFile(string pathname)
		{
            if (File.Exists(pathname))
            {
				File.Delete(pathname);
			}

			StreamWriter sw = File.AppendText(pathname);
			try
			{
				/// Now we can write out the new file
				//***** Header (ONE PER FILE)
				Assembly assem = Assembly.GetExecutingAssembly();
				string verstr = assem.GetName().Version.ToString();
				string scmt1 = "//*****************************";
				string scmt2 = "//";
				sw.WriteLine(scmt1);
				sw.WriteLine(scmt1);
				sw.WriteLine(scmt2 + " VALUWASTE 4 License Data Transfer File");
				sw.WriteLine(scmt1);
				sw.WriteLine(scmt1);
				//** Tracker record
				scmt1 = "//********* VWA4 version: " + verstr;
				sw.WriteLine(scmt1);
				/// Write out the name value pairs
				/// 
				scmt1 = "MaxNumberofSites, " + VWA4Common.GlobalSettings.MaxNumberofSites.ToString();
				sw.WriteLine(scmt1);
				// Limits
				//scmt1 = "xxx, " + VWA4Common.GlobalSettings.MaxNumberofSites.ToString();
				scmt1 = "MaxNumberofFoodTypes, " + VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "MaxNumberofLossTypes, " + VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "MaxNumberofUserTypes, " + VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "MaxNumberofDETs, " + VWA4Common.GlobalSettings.MaxNumberofDETs.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "MaxNumberofReports, " + VWA4Common.GlobalSettings.MaxNumberofReports.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "MaxNumberofTrackers, " + VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "AddUsersAvailable, " + VWA4Common.GlobalSettings.AddUsersAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "AMWTAvailable, " + VWA4Common.GlobalSettings.AMWTAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "AdvancedMenuAvailable, " + VWA4Common.GlobalSettings.AdvancedMenuAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ConfiguratorAvailable, " + VWA4Common.GlobalSettings.ConfiguratorAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ConfigureDaypartEntryAvailable, " + VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ConfigureDispositionEntryAvailable, " + VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ConfigurePrePostEntryAvailable, " + VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ConfigureStationEntryAvailable, " + VWA4Common.GlobalSettings.ConfigureStationEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "DaypartEntryAvailable, " + VWA4Common.GlobalSettings.DaypartEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "DispositionEntryAvailable, " + VWA4Common.GlobalSettings.DispositionEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "PrePostEntryAvailable, " + VWA4Common.GlobalSettings.PrePostEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "StationEntryAvailable, " + VWA4Common.GlobalSettings.StationEntryAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "EnterFinancialsAvailable, " + VWA4Common.GlobalSettings.EnterFinancialsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "EnterSWATNotesAvailable, " + VWA4Common.GlobalSettings.EnterSWATNotesAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "FoodCostAdjustmentsAvailable, " + VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ImportWasteDataAvailable, " + VWA4Common.GlobalSettings.ImportWasteDataAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageBaselinesAvailable, " + VWA4Common.GlobalSettings.ManageBaselinesAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageDETsAvailable, " + VWA4Common.GlobalSettings.ManageDETsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageEventClientsAvailable, " + VWA4Common.GlobalSettings.ManageEventClientsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageEventOrdersAvailable, " + VWA4Common.GlobalSettings.ManageEventOrdersAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManagePreferencesAvailable, " + VWA4Common.GlobalSettings.ManagePreferencesAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageLogFormsAvailable, " + VWA4Common.GlobalSettings.ManageLogFormsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageReportsAvailable, " + VWA4Common.GlobalSettings.ManageReportsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageSitesAvailable, " + VWA4Common.GlobalSettings.ManageSitesAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageTrackersAvailable, " + VWA4Common.GlobalSettings.ManageTrackersAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "ManageTypesAvailable, " + VWA4Common.GlobalSettings.ManageTypesAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "RecurringTransactionsAvailable, " + VWA4Common.GlobalSettings.RecurringTransactionsAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "RemoveUsersAvailable, " + VWA4Common.GlobalSettings.RemoveUsersAvailable.ToString();
				sw.WriteLine(scmt1);
				scmt1 = "UpdateTrackerAvailable, " + VWA4Common.GlobalSettings.UpdateTrackerAvailable.ToString();
				sw.WriteLine(scmt1);
			}
			finally
			{
				sw.Close();
			}
		
			return true;
		}

		static private int _UserLevel = 0;
		// 0 = User; 1 = Manager; 2 = Administrator
		static public int UserLevel
		{
			get
			{
				return _UserLevel;
			}
			set
			{
				_UserLevel = value;
			}
		}

		static public string GetUserLevelName()
		{
			switch (UserLevel)
			{
				case 0:
					return "User";
				case 1:
					return "Manager";
			}
			return "Administrator";
		}

		static public bool IsSuper
		{
			get
			{
				if (UserLevel == 2)
					return true;
				return false;
			}
		}

		static public bool IsLogged // i.e. "Manager" level - legacy name
		{
			get
			{
				return IsManager;
			}
		}


		static public bool IsManager
		{
			get
			{
				if (UserLevel == 1)
					return true;
				return false;
			}
		}


		///
		/// Licensing Globals
		///
		static private int _LicenseType = 0;
		// 0 = No License; 1 = Site License; 2 = CPU License
		static public int LicenseType
		{
			get
			{
				return _LicenseType;
			}
			set
			{
				_LicenseType = value;
			}
		}

		static private string _CPU_ID = "";
		// For CPU License Models - stores unique ID of hardware CPU
		static public string CPU_ID
		{
			get
			{
				return _CPU_ID;
			}
			set
			{
				_CPU_ID = value;
			}
		}

		//static private string _ClientSite_ID = "";
		//// 
		//static public string ClientSite_ID
		//{
		//    get
		//    {
		//        //TODO: Call License Manager to obtain
		//        return _ClientSite_ID;
		//    }
		//    set
		//    {
		//        _ClientSite_ID = value;
		//    }
		//}

		///***********************************************************************************
		///***********************************************************************************
		///  Expiration Date globals
		///***********************************************************************************
		///***********************************************************************************

		//
		/// <summary>
		/// Issue appropriate warning based on where we are at given the mode.  
		/// </summary>
		/// <param name="mode">Indicate current position in program.</param>
		/// <returns></returns>
		/// <param name="mode">True if license message was shown.</param>
		static public bool ExpirationWarningMessage(ExpirationWarningType mode)
		{
			if ((VWA4Common.AppContext.DBPathName == null) || (VWA4Common.AppContext.DBPathName == ""))return false;
			switch (mode)
			{
				case ExpirationWarningType.OnProgramStart:
					{
						if ((ExpirationWarningsModeString != "OnProgramStart") 
							&& (ExpirationWarningsModeString != "OnProgramStartAndExit")) return false;
						break;
					}
				case ExpirationWarningType.OnProgramExit:
					{
						if ((ExpirationWarningsModeString != "OnProgramExit")
							&& (ExpirationWarningsModeString != "OnProgramStartAndExit")) return false;
						break;
					}
				case ExpirationWarningType.DuringOperation:
					{
						if (ExpirationWarningsModeString != "DuringOperation") return false;
						break;
					}
			}

            DateTime ewsd = DateTime.Parse(LicenseManager.GetValue("ExpirationWarningsBeginDate"));
			if (!(DateTime.Now.Subtract(LastExpirationWarning) >= ExpirationWarningsFrequency) || DateTime.Compare(ewsd, DateTime.Now) >= 0)
				return false;

			MessageBox.Show("The installed license for this copy of \n"
				+ ProductName + " will expire " + ExpirationDate.ToShortDateString()
				+ "\nPlease contact LeanPath for information on extending the\n"
				+ "license period.", "LeanPath Licensing");
			Query.SaveGlobalSetting("LastExpirationWarning", DateTime.Now.ToString(), "datetime", 0);
			return true;
		}
		
		static public bool ActivateLicense(bool reactivate)
		{
			bool done = false;
			bool activated = false;
			/// New license must already be installed - let's see if the Activation code in the license file 
			/// is correct for this CPU and License file
			while (!done)
			{
				if (!VWA4Common.Security.LicenseManager.ValidateLicense() || reactivate)
				{/// Need to Activate the file
					VWA4Common.Security.Activation afrm = new VWA4Common.Security.Activation();
					if (afrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						/// We reactivated successfully
						activated = true;
					}
					else
					{  /// We DID NOT reactivate successfully
						MessageBox.Show("License was not activated! \n Please contact LeanPath Customer Support for assistance.",
			"LeanPath Licensing System");
						return false;
					}
				}
				else
				{ /// License is already activated
					activated = true;
				}

				/// File is now activated
				/// 
				/// Expiration Date logic
				/// 
				if (activated && (DateTime.Now > VWA4Common.GlobalSettings.ExpirationDate))
				{ // License is expired
					if (MessageBox.Show("The activated license file has expired. Attempt to reactivate now?"
						, "LeanPath Licensing System", MessageBoxButtons.YesNo)
						== System.Windows.Forms.DialogResult.Yes)
					{ /// Let's reactivate! 
						VWA4Common.Security.Activation afrm = new VWA4Common.Security.Activation();
						if (afrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
						{
							/// We reactivated
						}
					}
					else
					{ /// Let's NOT reactivate... give user a chance to load a new license file, or curtains...
						if (!(MessageBox.Show("Load a new license file now?", "LeanPath Licensing System")
						== System.Windows.Forms.DialogResult.Yes))
						{
							// User chose not to install new license - shut down now
							MessageBox.Show("Cannot proceed without installing a valid license - exiting application now.\nContact LeanPath customer support for assistance.", "LeanPath Licensing System");
							Application.Exit();
						}
					}
				}
				else
				{
					/// This is the finish line.
					done = true;
				}
			}
			return true;
		}

		static private DateTime _ExpirationDate = DateTime.MinValue;
		// Absolute date that license expires
		static public DateTime ExpirationDate
		{
			get
			{
				return _ExpirationDate;
			}
			set
			{
				_ExpirationDate = value;
			}
		}

		static private DateTime _ExpirationWarningsBeginDate = DateTime.MinValue;
		// Date that license expiration warnings begin
		static public DateTime ExpirationWarningsBeginDate
		{
			get
			{
				return _ExpirationWarningsBeginDate;
			}
			set
			{
				_ExpirationWarningsBeginDate = value;
			}
		}

		static private ExpirationWarningType _ExpirationWarningsMode = ExpirationWarningType.OnProgramStart;
		// 
		static public ExpirationWarningType ExpirationWarningsMode
		{
			get
			{
				return _ExpirationWarningsMode;
			}
			set
			{
				_ExpirationWarningsMode = value;
			}
		}
		static public string ExpirationWarningsModeString
		{
			get
			{
				switch (_ExpirationWarningsMode)
				{
					case ExpirationWarningType.OnProgramStart:
						{
							return "OnProgramStart";
						}
					case ExpirationWarningType.OnProgramExit:
						{
							return "OnProgramExit";
						}
					case ExpirationWarningType.DuringOperation:
						{
							return "DuringOperation";
						}
				}
				return "OnProgramStartAndExit";
			}
			set
			{
				switch (value)
				{
					case "OnProgramStart":
						{
							_ExpirationWarningsMode = ExpirationWarningType.OnProgramStart;
							break;
						}
					case "OnProgramExit":
						{
							_ExpirationWarningsMode = ExpirationWarningType.OnProgramExit;
							break;
						}
					case "DuringOperation":
						{
							_ExpirationWarningsMode = ExpirationWarningType.DuringOperation;
							break;
						}
					default:
						{
							_ExpirationWarningsMode = ExpirationWarningType.OnProgramStartAndExit;
							break;
						}

				}
			}

		}

		static private TimeSpan _ExpirationWarningsFrequency = TimeSpan.FromDays(1);
		// Date that license expiration warnings begin
		static public TimeSpan ExpirationWarningsFrequency
		{
			get
			{
				return _ExpirationWarningsFrequency;
			}
			set
			{
				_ExpirationWarningsFrequency = value;
			}
		}

		/// <summary>
		/// Determine if warning is in order regarding expiration based on mode, frequency,
		/// and expiration date.  Return warning message to use if so.
		/// </summary>
		/// <param name="situation">Where are we checking from?</param>
		/// <returns>empty string if no warning; otherwise contains message to issue.</returns>
		static private DateTime _LastExpirationWarning = DateTime.MinValue;
		static public DateTime LastExpirationWarning
		{
			get
			{
				if (_LastExpirationWarning == DateTime.MinValue)
					if (!DateTime.TryParse(
						Query.GetGlobalSetting("LastExpirationWarning", 0),
						out _LastExpirationWarning))
						 _LastExpirationWarning = DateTime.Now ;
				return _LastExpirationWarning;
			}
			set
			{
				_LastExpirationWarning = value;
			}
		}

		static private string _DefaultUserLevel = "Super";
		// "User", "Super" or "Manager" ?
		static public string DefaultUserLevel
		{
			get
			{
				return _DefaultUserLevel;
			}
			set
			{
				_DefaultUserLevel = value;
			}
		}

		static private string _ManagerPassword = "Manager";
		// Stores the Manager password
		static public string ManagerPassword
		{
			get
			{
				return _ManagerPassword;
			}
			set
			{
				_ManagerPassword = value;
			}
		}

		static private string _AdministratorPassword = "Super";
		// Stores the Administrator password
		static public string AdministratorPassword
		{
			get
			{
				return _AdministratorPassword;
			}
			set
			{
				_AdministratorPassword = value;
			}
		}

		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		/// Database License Limits
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************

		static private int _MaxNumberofSites = 1;
		// Stores maximum number of sites allowed in db
		static public int MaxNumberofSites
		{
			get
			{
				return _MaxNumberofSites;
			}
			set
			{
				_MaxNumberofSites = value;
			}
		}


		static private int _MaxNumberofTrackers = 1;
		// Stores maximum number of Trackers allowed in db
		static public int MaxNumberofTrackers
		{
			get
			{
				return _MaxNumberofTrackers;
			}
			set
			{
				_MaxNumberofTrackers = value;
			}
		}

		static private int _MaxNumberofFoodTypes = 1;
		// Stores maximum number of Food types allowed in db
		static public int MaxNumberofFoodTypes
		{
			get
			{
				return _MaxNumberofFoodTypes;
			}
			set
			{
				_MaxNumberofFoodTypes = value;
			}
		}

		static private int _MaxNumberofLossTypes = 1;
		// Stores maximum number of Loss Types allowed in db
		static public int MaxNumberofLossTypes
		{
			get
			{
				return _MaxNumberofLossTypes;
			}
			set
			{
				_MaxNumberofLossTypes = value;
			}
		}

		static private int _MaxNumberofUserTypes = 1;
		// Stores maximum number of User types allowed in db
		static public int MaxNumberofUserTypes
		{
			get
			{
				return _MaxNumberofUserTypes;
			}
			set
			{
				_MaxNumberofUserTypes = value;
			}
		}

		static private int _MaxNumberofDETs = 1;
		// Stores maximum number of Data Entry Templates allowed in db
		static public int MaxNumberofDETs
		{
			get
			{
				return _MaxNumberofDETs;
			}
			set
			{
				_MaxNumberofDETs = value;
			}
		}

		static private int _MaxNumberofReports = 1;
		// Stores maximum number of Reports allowed in db
		static public int MaxNumberofReports
		{
			get
			{
				return _MaxNumberofReports;
			}
			set
			{
				_MaxNumberofReports = value;
			}
		}

		static private bool _FoodWasteClassAllowed = true;
		/// Stores whether food waste class is allowed in db
		static public bool FoodWasteClassAllowed
		{
			get
			{
				return _FoodWasteClassAllowed;
			}
			set
			{
				_FoodWasteClassAllowed = value;
			}
		}

		static private bool _NonFoodWasteClassAllowed = true;
		/// Stores whether non-food waste class is allowed in db
		static public bool NonFoodWasteClassAllowed
		{
			get
			{
				return _NonFoodWasteClassAllowed;
			}
			set
			{
				_NonFoodWasteClassAllowed = value;
			}
		}

		///
		/// Methods to retrieve DB statistics from a VW database
		/// 
		static public bool GetDBStats(VWA4Common.GlobalClasses.VWDBStats dbStats)
		{
			return GetDBStats(VWA4Common.AppContext.DBPathName, dbStats);
		}
		static public bool GetDBStats(string dbpath, VWA4Common.GlobalClasses.VWDBStats dbStats)
		{
			string saveDBPathName = VWA4Common.AppContext.DBPathName;
			try
			{
				VWA4Common.AppContext.DBPathName = dbpath;
				DataTable dt;
				dt = VWA4Common.DB.Retrieve("SELECT VersionNum FROM DBVersion");
				dbStats.DBVersion = dt.Rows[0]["VersionNum"].ToString();
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Sites");
				dbStats.NumSites = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Terminals");
				dbStats.NumTrackers = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM FoodType WHERE Enabled = TRUE");
				dbStats.NumFoodTypes = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM LossType WHERE Enabled = TRUE");
				dbStats.NumLossTypes = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM UserType WHERE Enabled = TRUE");
				dbStats.NumUserTypes = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM DataEntryTemplates");
				dbStats.NumDETs = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM ReportMemorized");
				dbStats.NumReports = (int)dt.Rows[0][0];
				//
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM FoodType WHERE WasteClass = 'generic_food'");
				if ((int)dt.Rows[0][0] > 0) dbStats.FoodWasteClassUsed = true;
				else dbStats.FoodWasteClassUsed = false;
				dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM FoodType WHERE WasteClass = 'generic_nonfood'");
				if ((int)dt.Rows[0][0] > 0) dbStats.NonFoodWasteClassUsed = true;
				else dbStats.NonFoodWasteClassUsed = false;
				VWA4Common.AppContext.DBPathName = saveDBPathName;
			}
			catch
			{
				VWA4Common.AppContext.DBPathName = saveDBPathName;
				return false;
			}
			return true;
		}

		///***********************************************************************************
		///***********************************************************************************
		/// Helper Methods 
		///***********************************************************************************
		///***********************************************************************************

		static public string GetCPUID()
		{
			var mc = new ManagementClass("Win32_Processor");
			var moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				return mo.Properties["ProcessorId"].Value.ToString();
			}

			return "";
		}


		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		/// Switches affecting available (allowed) functionality
		///***********************************************************************************
		///***********************************************************************************
		///***********************************************************************************
		
		static private bool _AddNewCollectionAvailable = false;
		/// Stores switch controlling availability of Adding New Collections in .NET
		static public bool AddNewCollectionAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _AddNewCollectionAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _AddNewCollectionAvailable;
			}
			set
			{
				_AddNewCollectionAvailable = value;
			}
		}
		static public bool AddNewCollectionAvailablex
		{
			get
			{
				return _AddNewCollectionAvailable;
			}
			set
			{
				_AddNewCollectionAvailable = value;
			}
		}

		static private bool _AddNewReportAvailable = false;
		/// Stores switch controlling availability of Adding New Reports in .NET
		static public bool AddNewReportAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _AddNewReportAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _AddNewReportAvailable;
			}
			set
			{
				_AddNewReportAvailable = value;
			}
		}
		static public bool AddNewReportAvailablex
		{
			get
			{
				return _AddNewReportAvailable;
			}
			set
			{
				_AddNewReportAvailable = value;
			}
		}

		static private bool _AddUsersAvailable = false;
		/// Stores switch controlling availability of Add User Types in .NET
		static public bool AddUsersAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _AddUsersAvailable;
						}
					case 1: // "manager"
						{
							return _AddUsersAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _AddUsersAvailable;
			}
			set
			{
				_AddUsersAvailable = value;
			}
		}
		static public bool AddUsersAvailablex
		{
			get
			{
				return _AddUsersAvailable;
			}
			set
			{
				_AddUsersAvailable = value;
			}
		}

		static private bool _AdvancedMenuAvailable = false;
		/// Stores switch controlling availability of Advanced Menu in .NET
		static public bool AdvancedMenuAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _AdvancedMenuAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _AdvancedMenuAvailable;
			}
			set
			{
				_AdvancedMenuAvailable = value;
			}
		}
		static public bool AdvancedMenuAvailablex
		{
			get
			{
				return _AdvancedMenuAvailable;
			}
			set
			{
				_AdvancedMenuAvailable = value;
			}
		}

		static private bool _AMWTAvailable = false;
		/// Stores switch controlling availability of AMWT in .NET
		static public bool AMWTAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _AMWTAvailable;
						}
					case 1: // "manager"
						{
							return _AMWTAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _AMWTAvailable;
			}
			set
			{
				_AMWTAvailable = value;
			}
		}
		static public bool AMWTAvailablex
		{
			get
			{
				return _AMWTAvailable;
			}
			set
			{
				_AMWTAvailable = value;
			}
		}

		static private bool _CloneReportAvailable = false;
		/// Stores switch controlling availability of Cloning New Reports in .NET
		static public bool CloneReportAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _CloneReportAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _CloneReportAvailable;
			}
			set
			{
				_CloneReportAvailable = value;
			}
		}
		static public bool CloneReportAvailablex
		{
			get
			{
				return _CloneReportAvailable;
			}
			set
			{
				_CloneReportAvailable = value;
			}
		}

		static private bool _ConfiguratorAvailable = false;
		/// Stores switch controlling availability of overall Delphi configurator
		static public bool ConfiguratorAvailable
		{
			get
			{
				if (ConfiguratorPathName != "")
				{
					switch (UserLevel)
					{
						case 0: // "user"
							{
								return false;
							}
						case 1: // "manager"
							{
								return _ConfiguratorAvailable;
							}
						case 2: // "super"
							{
								return true;
							}
					} 
					return _ConfiguratorAvailable;
				}
				else return false;
			}
			set
			{
				_ConfiguratorAvailable = value;
			}
		}
		static public bool ConfiguratorAvailablex
		{
			get
			{
				if (ConfiguratorPathName != "")
				{
					return _ConfiguratorAvailable;
				}
				else return false;
			}
			set
			{
				_ConfiguratorAvailable = value;
			}
		}

		static private string _ConfiguratorPathName = "";
		/// Stores switch controlling availability of overall Delphi configurator
		static public string ConfiguratorPathName
		{
			get
			{
				if (_ConfiguratorPathName == "")
				{
					// Configurator PathName not yet initialized, or might not be installed
					// Try standard name
					if (File.Exists(Application.StartupPath + "\\" + "VWA4DD.exe"))
					{
						// Standard name is correct and exists - use it
						_ConfiguratorPathName = Application.StartupPath + "\\" + "VWA4DD.exe";
					}
					return _ConfiguratorPathName;
				}
				// Something is specified - double check the file
				if (!File.Exists(_ConfiguratorPathName)) _ConfiguratorPathName = "";
				return _ConfiguratorPathName;
			}
			set
			{
				_ConfiguratorPathName = value;
			}
		}

		static private bool _ConfigureDaypartEntryAvailable = false;
		/// Stores switch controlling availability of Configuring Dayparts Entry in AMWT
		static public bool ConfigureDaypartEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ConfigureDaypartEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ConfigureDaypartEntryAvailable;
			}
			set
			{
				_ConfigureDaypartEntryAvailable = value;
			}
		}
		static public bool ConfigureDaypartEntryAvailablex
		{
			get
			{
				return _ConfigureDaypartEntryAvailable;
			}
			set
			{
				_ConfigureDaypartEntryAvailable = value;
			}
		}

		static private bool _ConfigureDispositionEntryAvailable = false;
		/// Stores switch controlling availability of Configuring Disposition Entry in AMWT
		static public bool ConfigureDispositionEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ConfigureDispositionEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ConfigureDispositionEntryAvailable;
			}
			set
			{
				_ConfigureDispositionEntryAvailable = value;
			}
		}
		static public bool ConfigureDispositionEntryAvailablex
		{
			get
			{
				 return _ConfigureDispositionEntryAvailable;
			}
			set
			{
				_ConfigureDispositionEntryAvailable = value;
			}
		}

		static private bool _ConfigurePrePostEntryAvailable = false;
		/// Stores switch controlling availability of Configuring Pre/post Entry in AMWT
		static public bool ConfigurePrePostEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ConfigurePrePostEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ConfigurePrePostEntryAvailable;
			}
			set
			{
				_ConfigurePrePostEntryAvailable = value;
			}
		}
		static public bool ConfigurePrePostEntryAvailablex
		{
			get
			{
				return _ConfigurePrePostEntryAvailable;
			}
			set
			{
				_ConfigurePrePostEntryAvailable = value;
			}
		}

		static private bool _ConfigureStationEntryAvailable = false;
		/// Stores switch controlling availability of Configuring Stations Entry in AMWT
		static public bool ConfigureStationEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ConfigureStationEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ConfigureStationEntryAvailable;
			}
			set
			{
				_ConfigureStationEntryAvailable = value;
			}
		}
		static public bool ConfigureStationEntryAvailablex
		{
			get
			{
				return _ConfigureStationEntryAvailable;
			}
			set
			{
				_ConfigureStationEntryAvailable = value;
			}
		}

		static private bool _DaypartEntryAvailable = false;
		/// Stores switch controlling availability of Entering Daypart data via AMWT
		static public bool DaypartEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _DaypartEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _DaypartEntryAvailable;
			}
			set
			{
				_DaypartEntryAvailable = value;
			}
		}
		static public bool DaypartEntryAvailablex
		{
			get
			{
				return _DaypartEntryAvailable;
			}
			set
			{
				_DaypartEntryAvailable = value;
			}
		}

		static private bool _DispositionEntryAvailable = false;
		/// Stores switch controlling availability of Entering Disposition data via AMWT
		static public bool DispositionEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _DispositionEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _DispositionEntryAvailable;
			}
			set
			{
				_DispositionEntryAvailable = value;
			}
		}
		static public bool DispositionEntryAvailablex
		{
			get
			{
				 return _DispositionEntryAvailable;
			}
			set
			{
				_DispositionEntryAvailable = value;
			}
		}

		static private bool _EnterFinancialsAvailable = false;
		/// Stores switch controlling availability of Enter Financials task in .NET
		static public bool EnterFinancialsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _EnterFinancialsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _EnterFinancialsAvailable;
			}
			set
			{
				_EnterFinancialsAvailable = value;
			}
		}
		static public bool EnterFinancialsAvailablex
		{
			get
			{
				return _EnterFinancialsAvailable;
			}
			set
			{
				_EnterFinancialsAvailable = value;
			}
		}

		static private bool _EnterSWATNotesAvailable = false;
		/// Stores switch controlling availability of Enter SWAT Notes task in .NET
		static public bool EnterSWATNotesAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _EnterSWATNotesAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _EnterSWATNotesAvailable;
			}
			set
			{
				_EnterSWATNotesAvailable = value;
			}
		}
		static public bool EnterSWATNotesAvailablex
		{
			get
			{
				return _EnterSWATNotesAvailable;
			}
			set
			{
				_EnterSWATNotesAvailable = value;
			}
		}

		static private bool _FoodCostAdjustmentsAvailable = false;
		/// Stores switch controlling availability of Manage Food Cost Adjustments in .NET
		static public bool FoodCostAdjustmentsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _FoodCostAdjustmentsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _FoodCostAdjustmentsAvailable;
			}
			set
			{
				_FoodCostAdjustmentsAvailable = value;
			}
		}
		static public bool FoodCostAdjustmentsAvailablex
		{
			get
			{
				return _FoodCostAdjustmentsAvailable;
			}
			set
			{
				_FoodCostAdjustmentsAvailable = value;
			}
		}

		static private bool _ImportWasteDataAvailable = false;
		/// Stores switch controlling availability of Import Waste Data in .NET
		static public bool ImportWasteDataAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _ImportWasteDataAvailable;
						}
					case 1: // "manager"
						{
							return _ImportWasteDataAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ImportWasteDataAvailable;
			}
			set
			{
				_ImportWasteDataAvailable = value;
			}
		}
		static public bool ImportWasteDataAvailablex
		{
			get
			{
				return _ImportWasteDataAvailable;
			}
			set
			{
				_ImportWasteDataAvailable = value;
			}
		}

		static private bool _ManageBaselinesAvailable = false;
		/// Stores switch controlling availability of Manage Preferences in .NET
		static public bool ManageBaselinesAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageBaselinesAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageBaselinesAvailable;
			}
			set
			{
				_ManageBaselinesAvailable = value;
			}
		}
		static public bool ManageBaselinesAvailablex
		{
			get
			{
				return _ManageBaselinesAvailable;
			}
			set
			{
				_ManageBaselinesAvailable = value;
			}
		}

		static private bool _ManageDETsAvailable = false;
		/// Stores switch controlling availability of Manage DETs in .NET
		static public bool ManageDETsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageDETsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageDETsAvailable;
			}
			set
			{
				_ManageDETsAvailable = value;
			}
		}
		static public bool ManageDETsAvailablex
		{
			get
			{
				return _ManageDETsAvailable;
			}
			set
			{
				_ManageDETsAvailable = value;
			}
		}

		static private bool _ManageEventClientsAvailable = false;
		/// Stores switch controlling availability of Manage Event Clients in .NET
		static public bool ManageEventClientsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageEventClientsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageEventClientsAvailable;
			}
			set
			{
				_ManageEventClientsAvailable = value;
			}
		}
		static public bool ManageEventClientsAvailablex
		{
			get
			{
				return _ManageEventClientsAvailable;
			}
			set
			{
				_ManageEventClientsAvailable = value;
			}
		}

		static private bool _ManageEventOrdersAvailable = false;
		/// Stores switch controlling availability of Manage Event Orders in .NET
		static public bool ManageEventOrdersAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageEventOrdersAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageEventOrdersAvailable;
			}
			set
			{
				_ManageEventOrdersAvailable = value;
			}
		}
		static public bool ManageEventOrdersAvailablex
		{
			get
			{
				return _ManageEventOrdersAvailable;
			}
			set
			{
				_ManageEventOrdersAvailable = value;
			}
		}

		static private bool _ManagePreferencesAvailable = false;
		/// Stores switch controlling availability of Manage Preferences in .NET
		static public bool ManagePreferencesAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManagePreferencesAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManagePreferencesAvailable;
			}
			set
			{
				_ManagePreferencesAvailable = value;
			}
		}
		static public bool ManagePreferencesAvailablex
		{
			get
			{
				return _ManagePreferencesAvailable;
			}
			set
			{
				_ManagePreferencesAvailable = value;
			}
		}

		static private bool _ManagePrintFormsAvailable = false;
		/// Stores switch controlling availability of Manage Forms in .NET
		static public bool ManageLogFormsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManagePrintFormsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManagePrintFormsAvailable;
			}
			set
			{
				_ManagePrintFormsAvailable = value;
			}
		}
		static public bool ManageLogFormsAvailablex
		{
			get
			{
				return _ManagePrintFormsAvailable;
			}
			set
			{
				_ManagePrintFormsAvailable = value;
			}
		}

		static private bool _ManageReportsSettingsAvailable = false;
		/// Stores switch controlling availability of Manage Reports task in .NET
		static public bool ManageReportsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageReportsSettingsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageReportsSettingsAvailable;
			}
			set
			{
				_ManageReportsSettingsAvailable = value;
			}
		}
		static public bool ManageReportsAvailablex
		{
			get
			{
				return _ManageReportsSettingsAvailable;
			}
			set
			{
				_ManageReportsSettingsAvailable = value;
			}
		}

		static private bool _ManageSitesAvailable = false;
		/// Stores switch controlling availability of Manage Sites in Delphi configurator
		static public bool ManageSitesAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageSitesAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageSitesAvailable;
			}
			set
			{
				_ManageSitesAvailable = value;
			}
		}
		static public bool ManageSitesAvailablex
		{
			get
			{
				return _ManageSitesAvailable;
			}
			set
			{
				_ManageSitesAvailable = value;
			}
		}

		static private bool _ManageTrackersAvailable = false;
		/// Stores switch controlling availability of Manage Trackers in Delphi configurator
		static public bool ManageTrackersAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageTrackersAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _ManageTrackersAvailable;
			}
			set
			{
				_ManageTrackersAvailable = value;
			}
		}
		static public bool ManageTrackersAvailablex
		{
			get
			{
				return _ManageTrackersAvailable;
			}
			set
			{
				_ManageTrackersAvailable = value;
			}
		}

		static private bool _ManageTypesAvailable = false;
		/// Stores switch controlling availability of Manage Types in Delphi configurator
		static public bool ManageTypesAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _ManageTypesAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _ManageTypesAvailable;
			}
			set
			{
				_ManageTypesAvailable = value;
			}
		}
		static public bool ManageTypesAvailablex
		{
			get
			{
				return _ManageTypesAvailable;
			}
			set
			{
				_ManageTypesAvailable = value;
			}
		}

		static private bool _PrePostEntryAvailable = false;
		/// Stores switch controlling availability of Entering Pre/post data via AMWT
		static public bool PrePostEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _PrePostEntryAvailable;
						}
					case 1: // "manager"
						{
							return _PrePostEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _PrePostEntryAvailable;
			}
			set
			{
				_PrePostEntryAvailable = value;
			}
		}
		static public bool PrePostEntryAvailablex
		{
			get
			{
				return _PrePostEntryAvailable;
			}
			set
			{
				_PrePostEntryAvailable = value;
			}
		}

		static private bool _RecurringTransactionsAvailable = false;
		/// Stores switch controlling availability of Manage Recurring Transactions in .NET
		static public bool RecurringTransactionsAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _RecurringTransactionsAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} 
				return _RecurringTransactionsAvailable;
			}
			set
			{
				_RecurringTransactionsAvailable = value;
			}
		}
		static public bool RecurringTransactionsAvailablex
		{
			get
			{
				return _RecurringTransactionsAvailable;
			}
			set
			{
				_RecurringTransactionsAvailable = value;
			}
		}

		static private bool _RemoveUsersAvailable = false;
		/// Stores switch controlling availability of Remove User Types in .NET
		static public bool RemoveUsersAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _RemoveUsersAvailable;
						}
					case 1: // "manager"
						{
							return _RemoveUsersAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				}
				return _RemoveUsersAvailable;
			}
			set
			{
				_RemoveUsersAvailable = value;
			}
		}
		static public bool RemoveUsersAvailablex
		{
			get
			{
				return _RemoveUsersAvailable;
			}
			set
			{
				_RemoveUsersAvailable = value;
			}
		}

		static private bool _StationEntryAvailable = false;
		/// Stores switch controlling availability of Entering Station data via AMWT
		static public bool StationEntryAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return _StationEntryAvailable;
						}
					case 1: // "manager"
						{
							return _StationEntryAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _StationEntryAvailable;
			}
			set
			{
				_StationEntryAvailable = value;
			}
		}
		static public bool StationEntryAvailablex
		{
			get
			{
				return _StationEntryAvailable;
			}
			set
			{
				_StationEntryAvailable = value;
			}
		}

		static private bool _UpdateTrackerAvailable = false;
		/// Stores switch controlling availability of Update Trackers in .NET
		static public bool UpdateTrackerAvailable
		{
			get
			{
				switch (UserLevel)
				{
					case 0: // "user"
						{
							return false;
						}
					case 1: // "manager"
						{
							return _UpdateTrackerAvailable;
						}
					case 2: // "super"
						{
							return true;
						}
				} return _UpdateTrackerAvailable;
			}
			set
			{
				_UpdateTrackerAvailable = value;
			}
		}
		static public bool UpdateTrackerAvailablex
		{
			get
			{
				return _UpdateTrackerAvailable;
			}
			set
			{
				_UpdateTrackerAvailable = value;
			}
		}



		///***********************************************************************************
		///***********************************************************************************
		/// About Stuff 
		///***********************************************************************************
		///***********************************************************************************


		static private string _SupportEmailAddress = "";
		/// Stores Support Email Address
		static public string SupportEmailAddress
		{
			get
			{
				return _SupportEmailAddress;
			}
			set
			{
				_SupportEmailAddress = value;
			}
		}

		static private bool _ShowSupportEmailAddress = false;
		/// Stores Whether to Show Support Email Address
		static public bool ShowSupportEmailAddress
		{
			get
			{
				return _ShowSupportEmailAddress;
			}
			set
			{
				_ShowSupportEmailAddress = value;
			}
		}

		static private string _SupportPhoneNumber = "";
		/// Stores Support Phone Address
		static public string SupportPhoneNumber
		{
			get
			{
				return _SupportPhoneNumber;
			}
			set
			{
				_SupportPhoneNumber = value;
			}
		}

		static private bool _ShowSupportPhoneNumber = false;
		/// Stores Whether to Show Support Phone Address
		static public bool ShowSupportPhoneNumber
		{
			get
			{
				return _ShowSupportPhoneNumber;
			}
			set
			{
				_ShowSupportPhoneNumber = value;
			}
		}

		static private string _SupportWebsite = "";
		/// Stores Support Website
		static public string SupportWebsite
		{
			get
			{
				return _SupportWebsite;
			}
			set
			{
				_SupportWebsite = value;
			}
		}

		static private bool _ShowSupportWebsite = false;
		/// Stores Whether to Show Support Website
		static public bool ShowSupportWebsite
		{
			get
			{
				return _ShowSupportWebsite;
			}
			set
			{
				_ShowSupportWebsite = value;
			}
		}

		///********************************************
		///********************************************
		///********************************************
		/// Product Family/Version Globals
		///********************************************
		///********************************************
		///********************************************
		static private int _ProductType = 0;

		static private Icon _ProductIcon = null;
		static public Icon ProductIcon
		{
			get
			{
				return _ProductIcon;
			}
			set
			{
				_ProductIcon = value;
			}
		}

		/// <summary>
		/// 1 = ValuWaste Advantage; 2 = WasteProfiler; 3 = WasteLogger
		/// </summary>
		static public int ProductType
		{
			get
			{

				return _ProductType;
			}
			set
			{
				_ProductType = value;
			}
		}
		static public string ProductName
		{
			get
			{
				switch (_ProductType)
				{
					case 3:
						{
							return "WasteLOGGER";
						}
					case 2:
						{
							return "WasteProfiler";
						}
					default:
						{
							return "ValuWaste Advantage 4";
						}
				}
			}
		}
		/// 
		/// Main Form Appearance
		///
		static public Color ProductBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.FromArgb(218, 224, 231);
				else // Advantage 4
					return Color.FromArgb(243, 234, 228);
			}
		}
		/// 
		/// Menu Bar Appearance
		///
		static public Color ProductMenuBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					//return Color.FromArgb(160,201,105);
					return Color.FromArgb(127, 174, 65);
				else // Advantage 4
					return Color.FromArgb(163, 192, 244);
			}
		}
		/// 
		/// Header Appearance
		///
		static public Color ProductHeaderBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.FromArgb(218, 224, 231);
				else // Advantage 4
					return Color.FromArgb(243, 234, 228);
			}
		}
		/// 
		/// Footer Appearance
		///
		static public bool LeanPathLogoVisibleinFooter
		{
			get
			{
				return true;  // wired to visible for now
			}
		}
		static public Color ProductFooterBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.FromArgb(218, 224, 231);
				else // Advantage 4
					return Color.FromArgb(243, 234, 228);
			}
		}
		/// 
		/// Task Bar Appearance
		///
		static public Color ProductTaskBarHeaderBackgroundColor
		{
			get
			{
				return ProductMenuBackgroundColor;  // same as the menu background color
			}
		}
		static public Color ProductTaskBarFontColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.White;
				else // Advantage 4
					return Color.FromArgb(160, 82, 45); // Sienna
			}
		}
		static public Color ProductTaskBarBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.FromArgb(218, 224, 231);
				else // Advantage 4
					return Color.FromArgb(243, 234, 228);
			}
		}
		/// 
		/// Task Area Appearance
		///
		static public Color ProductTaskBackgroundColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
				{
					return Color.White;
					//return Color.FromArgb(218, 224, 231);
				}
				else // Advantage 4
				{
					return Color.White;
					//return Color.FromArgb(255, 251, 248);
				}
			}
		}
		static public Color ProductTaskHeaderBackgroundColor
		{
			get
			{
				return ProductMenuBackgroundColor; // same as the menu background color
			}
		}
		static public Color ProductTaskHeaderFontColor
		{
			get
			{
				if (_ProductType == 3) // WasteLOGGER
					return Color.FromArgb(245, 245, 245);
				else // Advantage 4
					return Color.FromArgb(160, 82, 45);
			}
		}


		///***********************************************************************************
		///***********************************************************************************
		///	Configuration Support Methods
		///***********************************************************************************
		///***********************************************************************************
		//****
		// Force reload of non-nullable values (e.g. booleans)
		//
		static public void ForceGVReload()
		{
			_TrackerConfigOutofSync = null;
			_FoodCostReportPoints = null;
			_ActiveSyncTrackerTransferFolder = null;
			_ActiveSyncTrackerTransfersOn = null;
			_AutoUpdateTrackers = null;
			WasteClassLevelofCurrentDB_Reset();
		}

		//**** DelphiFileName 
		// The filename of the Delphi configurator that is appropriate for this version of VWA4
		//   Doesn't guarantee that the file is installed!!!
		static private string _VWA4DelphiFileName;

		static public string VWA4DelphiFileName
		{
			get
			{
				if (_VWA4DelphiFileName == null || _VWA4DelphiFileName == "")
				{
					_VWA4DelphiFileName = Query.GetGlobalSetting("VWA4DelphiFileName", 0);
				}
				return _VWA4DelphiFileName;
			}
			set
			{
				_VWA4DelphiFileName = value;
				if (value != null)
					Query.SaveGlobalSetting("VWA4DelphiFileName", value, "String", 0);
			}
		}

		//**** VirtualAppDir 
		// This is where the Application Data is stored, i.e. Archive and Database subdirectories. If VirtualAppDir
		//  has been changed by the user, then it will contain a  directory of the user's choice.  Otherwise it will
		//  contain the same pathname as Application.ExecutablePath.
		static private string _VirtualAppDir;

		static public string VirtualAppDir
		{
			get
			{
				if (_VirtualAppDir == null || _VirtualAppDir == "")
				{
					_VirtualAppDir = Path.GetDirectoryName(Application.ExecutablePath);
				}
				return _VirtualAppDir;
			}
			set
			{
				if ((value != null) && (value != ""))
					_VirtualAppDir = value;
				else
					_VirtualAppDir = Path.GetDirectoryName(Application.ExecutablePath);
			}
		}

		static public string ArchiveDir
		{
			get
			{
				return VirtualAppDir + "\\Archive";
			}
		}

		static public string DatabaseDir
		{
			get
			{
				return VirtualAppDir + "\\Databases";
			}
		}
		static public bool TestMenuFileExists
		{
			get
			{
				return File.Exists(VirtualAppDir + "\\TestMenus.txt");
			}
		}
		static public bool TestModeFileExists
		{
			get
			{
				return false;
				//return File.Exists(VirtualAppDir + "\\TestMode.txt");
			}
		}

		///
		/// Debug/Special Globals
		/// 

		static public bool DisableDashboardWarnings
		{
			get
			{ return false; }
		}


		///***********************************************************************************
		///***********************************************************************************
		/// WasteLogger Waste Data Entry Globals
		///***********************************************************************************
		///***********************************************************************************

		//**** SessionTracker_TermID - Tracker (TermID) that is being used in the current Enter Waste Log Sheets Session 
		static private string _SessionTracker_TermID;
		static private string _SessionTracker_TermName;

		static public string SessionTracker_TermID
		{
			get
			{
				if ((_SessionTracker_TermID == null) || (_SessionTracker_TermID == ""))
				{
					_SessionTracker_TermID = "";
					_SessionTracker_TermName = "";
					if (SessionOpen <= 0)
					{
						// Use the frmNewSession return values
						_SessionTracker_TermID = SessionTracker_TermIDSelected;
					}
					else
					{
						string sql = "SELECT TermID FROM Transfers WHERE TransKey = "
							+ SessionOpen.ToString();
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							_SessionTracker_TermID = dr["TermID"].ToString();
						}
					}
				}
				return _SessionTracker_TermID;
			}
		}

		//**** SessionTracker_TermName - Tracker (TermID) that is being used in the current Enter Waste Log Sheets Session 

		static public string SessionTracker_TermName
		{
			get
			{
				if ((_SessionTracker_TermID == null) || (_SessionTracker_TermID == ""))
				{
					_SessionTracker_TermID = "";
					_SessionTracker_TermName = "";
					if (SessionOpen <= 0)
					{
						// Use the frmNewSession return values
						_SessionTracker_TermID = SessionTracker_TermIDSelected;
					}
					else
					{
						string sql = "SELECT TermID FROM Transfers WHERE TransKey = "
						+ SessionOpen.ToString();
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							_SessionTracker_TermID = dr["TermID"].ToString();
						}
					}
				}
				if (((_SessionTracker_TermName == null) || (_SessionTracker_TermName == "")) && (_SessionTracker_TermID != ""))
				{
					_SessionTracker_TermName = "";
					string sql = "SELECT TermName FROM Terminals WHERE TermID = '"
						+ _SessionTracker_TermID + "'"
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionTracker_TermName = dr["TermName"].ToString();
					}
				}
				return _SessionTracker_TermName;
			}
		}

		//**** SessionUser - User who is entering data in the current Enter Waste Log Sheets Session 
		static private string _SessionUserTypeID;
		static private string _SessionUserTypeName;

		static public string SessionUserTypeID
		{
			get
			{
				if ((_SessionUserTypeID == null) || (_SessionUserTypeID == ""))
				{
					_SessionUserTypeID = "";
					_SessionUserTypeName = "";
					string sql = "SELECT User FROM Transfers WHERE TransKey = "
						+ SessionOpen.ToString();
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionUserTypeID = dr["User"].ToString();
					}
				}
				return _SessionUserTypeID;
			}
			set
			{
				_SessionUserTypeID = value;
				// Set in database
				string sql = "UPDATE Transfers SET Transfers.[User] = '" + value
					+ "' WHERE  (((Transfers.[TransKey])="
					+ SessionOpen.ToString() + "));";
				VWA4Common.DB.Update(sql);
			}
		}

		static public string SessionUserName
		{
			get
			{
				if ((_SessionUserTypeID == null) || (_SessionUserTypeID == ""))
				{
					_SessionUserTypeID = "";
					_SessionUserTypeName = "";
					string sql = "SELECT User FROM Transfers WHERE TransKey = "
						+ SessionOpen.ToString();
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionUserTypeID = dr["User"].ToString();
					}
				}
				if (((_SessionUserTypeName == null) || (_SessionUserTypeName == "")) && (_SessionUserTypeID != ""))
				{
					_SessionUserTypeName = "";
					string sql = "SELECT TypeName FROM UserType Where TypeID = '"
						+ _SessionUserTypeID + "'";
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionUserTypeName = dr["TypeName"].ToString();
					}
				}

				return _SessionUserTypeName;
			}
			set
			{
				_SessionUserTypeName = value;
			}
		}

		//******* SessionSiteID
		static private string _SessionSiteID;
		static private string _SessionSiteName;
		public static int SessionSiteID
		{
			get
			{
				if ((_SessionSiteID == null) || (_SessionSiteID == ""))
				{
					_SessionSiteID = "";
					_SessionSiteName = "";
					string sql = "SELECT SiteID FROM Terminals WHERE TermID = '"
						 + SessionTracker_TermID + "'"
						 ;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionSiteID = dr["SiteID"].ToString();
					}
					else return 0;
				}
				return int.Parse(_SessionSiteID);
			}
		}

		//******* SessionSiteName
		public static string SessionSiteName
		{
			get
			{
				if (SessionSiteID == 0)
				{
					_SessionSiteName = "";
				}

				if (_SessionSiteName == null || _SessionSiteName == "")
				{
					string sql = "SELECT LicensedSite FROM Sites WHERE ID = "
						+ SessionSiteID.ToString()
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionSiteName = dr["LicensedSite"].ToString();
					}
					else _SessionSiteName = "";
				}
				return _SessionSiteName;
			}
		}

		//******* SessionTypeCatalogID
		static private string _SessionTypeCatalogID;
		public static int SessionTypeCatalogID
		{
			get
			{
				if ((_SessionTypeCatalogID == null) || (_SessionTypeCatalogID == ""))
				{
					_SessionTypeCatalogID = "0";
					string sql = "SELECT TypeCatalogID FROM Sites WHERE ID = "
						+ SessionSiteID.ToString()
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_SessionTypeCatalogID = dr["TypeCatalogID"].ToString();
					}
				}
				return int.Parse(_SessionTypeCatalogID);
			}
		}

		//******* SessionTypeCatalogName
		static private string _SessionTypeCatalogName;
		public static string SessionTypeCatalogName
		{
			get
			{
				if (SessionTypeCatalogID == 0)
				{
					_SessionTypeCatalogName = "MASTER";
				}
				else
					if ((_SessionTypeCatalogName == null) || (_SessionTypeCatalogName == ""))
					{
						_SessionTypeCatalogName = "";
						string sql = "SELECT TypeCatalogName FROM TypeCatalogs WHERE ID = "
							+ SessionTypeCatalogID.ToString()
							;
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							_SessionTypeCatalogName = dr["TypeCatalogName"].ToString();
						}
					}
				return _SessionTypeCatalogName;
			}
		}

		//**** SessDataFromDate - Data From Date/Time of the current Enter Waste Log Sheets Session
		static private string _SessDataFromDate;

		static public string SessDataFromDate
		{
			get
			{
				if ((_SessDataFromDate == null) || (_SessDataFromDate == ""))
				{
					_SessDataFromDate = DateTime.MinValue.ToShortDateString();
					string sql = "SELECT DataFromDate FROM Transfers WHERE TransKey = "
						+ SessionOpen.ToString()
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						DateTime retdate;
						DateTime.TryParse(
							dr["DataFromDate"].ToString(), out retdate);
						_SessDataFromDate = retdate.ToShortDateString();
					}
				}
				return _SessDataFromDate;
			}
		}

		static public void DeleteNullSessions()
		{
			string sql = "SELECT * FROM Transfers WHERE ManualDESession=TRUE";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			foreach (DataRow irow in dt.Rows)
			{
				sql = "SELECT ID FROM Weights Where TransKey = " + irow["TransKey"].ToString();
				DataTable dt2 = VWA4Common.DB.Retrieve(sql);
				if (dt2.Rows.Count == 0)
				{
					sql = "DELETE FROM Transfers WHERE TransKey = " +
						irow["TransKey"].ToString();
					VWA4Common.DB.Delete(sql);
				}
			}
		}

		//***** Cancel Print Progress support
		static public bool PrintViewReportsProgressCancelled;
		//***** Parameter Passing support
		static public string frmTypePicker_TypeIDSelected;
		static public string frmTypePicker_TypeNameSelected;
		static public string frmTypePicker_FoodTypeCostSelected;
		static public string frmTypePicker_ContainerTypeCostSelected;
		static public string frmTypePicker_ContainerWtSelected;
		static public string frmTypePicker_WasteModeSelected_Name;
		static public string frmTypePicker_WasteModeSelected_ID;
		static public string frmPicker_TimestampSelected;

		static public string frmUnits_UnitsMode;
		static public string frmUnits_Wt_TransWt;
		static public string frmUnits_Wt_TransMultiplier;
		static public string frmUnits_Vol_ContainerMultiplier;
		static public string frmUnits_FoodTypeID;
		static public bool frmUnits_FoodTypeIDUpdated;
		static public string frmUnits_ContainerTypeID;
		static public bool frmUnits_ContainerTypeUpdated;
		static public string frmUnits_Each_EachFormatID;
		static public string frmUnits_Each_ItemCount;

		static public string frmEachFormats_FormatIDSelected;

		static public string SessionTracker_TermIDSelected;
		static public string SessionTracker_TermNameSelected;
		static public string SessionDataFromDate_DateSelected;

		//***** Load Data Entry Template Settings
		static public bool DETLoaded;


		static public bool DETLoad(int det_ID, GlobalClasses.DataEntryTemplate detmem)
		{
			// The DataEntryTemplates table has an entry for the FormSet - load it

			string sql = "SELECT * FROM DataEntryTemplates  WHERE ID = "
				+ det_ID.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			DataRow dr = dt.Rows[0];
			if (dt.Rows.Count > 0)
			{
				detmem.DETID = int.Parse(dr["ID"].ToString());
				detmem.DETName = dr["DETName"].ToString();
				detmem.DETDescription = dr["DETDescription"].ToString();
				detmem.FormSet_displayorder = dr["FormSet_displayorder"].ToString();
				detmem.FormSet_BackColor = int.Parse(dr["FormSet_BackColor"].ToString());
				detmem.FormSet_Wastemode = dr["FormSet_Wastemode"].ToString();
				detmem.Wastemode_BackColor = int.Parse(dr["Wastemode_BackColor"].ToString());
				detmem.Wastemode_ForeColor = int.Parse(dr["Wastemode_ForeColor"].ToString());
				detmem.FormSet_UserType = dr["FormSet_UserType"].ToString();
				detmem.FormSet_UserType_BackColor = int.Parse(dr["FormSet_UserType_BackColor"].ToString());
				detmem.FormSet_UserType_ForeColor = int.Parse(dr["FormSet_UserType_ForeColor"].ToString());
				detmem.FormSet_FoodType = dr["FormSet_FoodType"].ToString();
				detmem.FormSet_FoodType_BackColor = int.Parse(dr["FormSet_FoodType_BackColor"].ToString());
				detmem.FormSet_FoodType_ForeColor = int.Parse(dr["FormSet_FoodType_ForeColor"].ToString());
				detmem.FormSet_LossType = dr["FormSet_LossType"].ToString();
				detmem.FormSet_LossType_BackColor = int.Parse(dr["FormSet_LossType_BackColor"].ToString());
				detmem.FormSet_LossType_ForeColor = int.Parse(dr["FormSet_LossType_ForeColor"].ToString());
				detmem.FormSet_ContainerType = dr["FormSet_ContainerType"].ToString();
				detmem.FormSet_ContainerType_BackColor = int.Parse(dr["FormSet_ContainerType_BackColor"].ToString());
				detmem.FormSet_ContainerType_ForeColor = int.Parse(dr["FormSet_ContainerType_ForeColor"].ToString());
				detmem.FormSet_StationType = dr["FormSet_StationType"].ToString();
				detmem.FormSet_StationType_BackColor = int.Parse(dr["FormSet_StationType_BackColor"].ToString());
				detmem.FormSet_StationType_ForeColor = int.Parse(dr["FormSet_StationType_ForeColor"].ToString());
				detmem.FormSet_DispositionType = dr["FormSet_DispositionType"].ToString();
				detmem.FormSet_DispositionType_BackColor = int.Parse(dr["FormSet_DispositionType_BackColor"].ToString());
				detmem.FormSet_DispositionType_ForeColor = int.Parse(dr["FormSet_DispositionType_ForeColor"].ToString());
				detmem.FormSet_DaypartType = dr["FormSet_DaypartType"].ToString();
				detmem.FormSet_DaypartType_BackColor = int.Parse(dr["FormSet_DaypartType_BackColor"].ToString());
				detmem.FormSet_DaypartType_ForeColor = int.Parse(dr["FormSet_DaypartType_ForeColor"].ToString());
				detmem.FormSet_EventOrderType = dr["FormSet_EventorderType"].ToString();
				detmem.FormSet_EventOrderType_BackColor = int.Parse(dr["FormSet_EventorderType_BackColor"].ToString());
				detmem.FormSet_EventOrderType_ForeColor = int.Parse(dr["FormSet_EventorderType_ForeColor"].ToString());
				///
				detmem.Transaction_displayorder = dr["Transaction_displayorder"].ToString();
				detmem.Transaction_BackColor = int.Parse(dr["Transaction_BackColor"].ToString());
				detmem.Quantity_CTDefaultMode = dr["Quantity_CTDefaultMode"].ToString();
				detmem.Quantity_BackColor = int.Parse(dr["Quantity_BackColor"].ToString());
				detmem.Quantity_ForeColor = int.Parse(dr["Quantity_ForeColor"].ToString());
				detmem.UserNotes_TShow = bool.Parse(dr["UserNotes_TShow"].ToString());
				detmem.UserNotes_BackColor = int.Parse(dr["UserNotes_BackColor"].ToString());
				detmem.UserNotes_ForeColor = int.Parse(dr["UserNotes_ForeColor"].ToString());
				///
				detmem.Timestamp_NTPrefill = dr["Timestamp_NTPrefill"].ToString();
				detmem.Timestamp_TFormat = dr["Timestamp_TFormat"].ToString();
				detmem.Timestamp_BackColor = int.Parse(dr["Timestamp_BackColor"].ToString());
				detmem.Timestamp_ForeColor = int.Parse(dr["Timestamp_ForeColor"].ToString());
				detmem.Wastemode_CTDefaultMode = dr["Wastemode_CTDefaultMode"].ToString();
				detmem.Wastemode_BackColor = int.Parse(dr["Wastemode_BackColor"].ToString());
				detmem.Wastemode_ForeColor = int.Parse(dr["Wastemode_ForeColor"].ToString());
				detmem.User_CTDefaultMode = dr["User_CTDefaultMode"].ToString();
				detmem.UserType_BackColor = int.Parse(dr["UserType_BackColor"].ToString());
				detmem.UserType_ForeColor = int.Parse(dr["UserType_ForeColor"].ToString());
				detmem.FoodType_CTDefaultMode = dr["FoodType_CTDefaultMode"].ToString();
				detmem.FoodType_BackColor = int.Parse(dr["FoodType_BackColor"].ToString());
				detmem.FoodType_ForeColor = int.Parse(dr["FoodType_ForeColor"].ToString());
				detmem.LossType_CTDefaultMode = dr["LossType_CTDefaultMode"].ToString();
				detmem.LossType_BackColor = int.Parse(dr["LossType_BackColor"].ToString());
				detmem.LossType_ForeColor = int.Parse(dr["LossType_ForeColor"].ToString());
				detmem.ContainerType_CTDefaultMode = dr["ContainerType_CTDefaultMode"].ToString();
				detmem.ContainerType_BackColor = int.Parse(dr["ContainerType_BackColor"].ToString());
				detmem.ContainerType_ForeColor = int.Parse(dr["ContainerType_ForeColor"].ToString());
				detmem.StationType_CTDefaultMode = dr["StationType_CTDefaultMode"].ToString();
				detmem.StationType_BackColor = int.Parse(dr["StationType_BackColor"].ToString());
				detmem.StationType_ForeColor = int.Parse(dr["StationType_ForeColor"].ToString());
				detmem.DispositionType_CTDefaultMode = dr["DispositionType_CTDefaultMode"].ToString();
				detmem.DispositionType_BackColor = int.Parse(dr["DispositionType_BackColor"].ToString());
				detmem.DispositionType_ForeColor = int.Parse(dr["DispositionType_ForeColor"].ToString());
				detmem.DaypartType_CTDefaultMode = dr["DaypartType_CTDefaultMode"].ToString();
				detmem.DaypartType_BackColor = int.Parse(dr["DaypartType_BackColor"].ToString());
				detmem.DaypartType_ForeColor = int.Parse(dr["DaypartType_ForeColor"].ToString());
				detmem.EventOrderType_CTDefaultMode = dr["EventOrderType_CTDefaultMode"].ToString();
				detmem.EventOrderType_BackColor = int.Parse(dr["EventOrderType_BackColor"].ToString());
				detmem.EventOrderType_ForeColor = int.Parse(dr["EventOrderType_ForeColor"].ToString());
				/// 
				return true;
			}
			return false;
		}

		static public string DETConfigCheck(int DET_ID, VWA4Common.GlobalClasses.DataEntryTemplate detmem)
		{
			string[] tokens;
			int i = 0;
			int errors = 0;
			VWA4Common.Errors.ErrorString.Clear();
			VWA4Common.Errors.ErrorString.Add("Selected Data Entry Template can't be used because of the following:");
			DETLoad(DET_ID, detmem);
			if (detmem.Transaction_displayorder != "")
			{
				tokens = detmem.Transaction_displayorder.Split(new Char[] { ',' });
				//****
				for (i = 0; i < tokens.Length; i++)
				{
					string s = tokens[i].Trim();
					if (((!VWA4Common.GlobalSettings.StationEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigureStationEntryAvailable)) && (s.ToLower() == "station"))
					{ // Station load is not allowed
						errors++;	// increment error count
						VWA4Common.Errors.ErrorString.Add(" - Station Type is used but not licensed.");
					}
					if (((!VWA4Common.GlobalSettings.DispositionEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable)) && (s.ToLower() == "disposition"))
					{ // disposition load is not allowed
						errors++;	// increment error count
						VWA4Common.Errors.ErrorString.Add(" - Disposition Type is used but not licensed.");
					}
					if (((!VWA4Common.GlobalSettings.DaypartEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable)) && (s.ToLower() == "daypart"))
					{ // daypart load is not allowed
						errors++;	// increment error count
						VWA4Common.Errors.ErrorString.Add(" - Daypart Type is used but not licensed.");
					}
					if (((!VWA4Common.GlobalSettings.PrePostEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable)) && (s.ToLower() == "wastemode"))
					{ // pre/post load is not allowed
						errors++;	// increment error count
						VWA4Common.Errors.ErrorString.Add(" - Waste Mode is used but not licensed.");
					}
				}

			}
			if (errors > 0)
			{
				return VWA4Common.Errors.ErrorString.Error + "\nTotal Errors: " + errors.ToString();
			}
			VWA4Common.Errors.ErrorString.Clear();
			return "";
		}

		static private int _SessionOpen;
		static public int SessionOpen	// Global that contains Session TransKey (ID) if open; 0 if not open.
		{
			get
			{
				return _SessionOpen;
			}
			set
			{
				_SessionOpen = value;
				// reset the dependent properties
				_SessionSiteID = null;
				_SessionSiteName = null;
				_SessionTypeCatalogID = null;
				_SessionTypeCatalogName = null;
				_SessDataFromDate = null;
				_SessionTracker_TermID = null;
				_SessionTracker_TermName = null;
				_SessionUserTypeID = null;
			}
		}

		/// <summary>
		/// Open an existing Data Entry Session
		/// </summary>
		static public void OpenSession(int transKey)
		{
			//
			SessionOpen = transKey;
		}


		/// <summary>
		/// Close the current Data Entry Session
		/// </summary>
		static public void CloseSession()
		{
			//
			SessionOpen = 0;
		}

		/// 
		/// Transaction Data Methods
		/// 
		//****
		static public int GetIsMemorizedfromQuantityModeStringCode(string stringcode)
		{
			switch (stringcode.ToLower())
			{
				case "wt":
					{
						return 3;
					}
				case "vol":
					{
						return 4;
					}
				case "each":
					{
						return 5;
					}
			}
			return -1;
		}

		//****
		static public string GetQuantityModeStringCodefromIsMemorized(int ismemorized)
		{
			switch (ismemorized)
			{
				case 3:
					{
						return "wt";
					}
				case 4:
					{
						return "vol";
					}
				case 5:
					{
						return "each";
					}
			}
			return "(invalid quantity mode)";
		}


		//****
		//  Weights.IsPreconsumer values:
		//		Intermediate =	0
		//		Preconsumer =	1
		//		Post consumer = 2
		static public int GetDefaultPrePostConsumerFlagfromWasteModeString(string wastemode)
		{
			switch (wastemode.ToLower())
			{
				case "int":
					{
						return 0;
					}
				case "pre":
					{
						return 1;
					}
				case "post":
					{
						return 2;
					}
			}
			return -1;
		}
	
		
		//****
		static public string GetWasteModeStringfromIsPreconsumer(int ispreconsumer)
		{
			switch (ispreconsumer)
			{
				case 0:
					{
						return "Intermediate";
					}
				case 1:
					{
						return "Pre-consumer";
					}
				case 2:
					{
						return "Post-consumer";
					}
			}
			return "(invalid waste mode)";
		}
		static public string GetWasteModeStringfromDefaultPrePostonsumer(int defaultprepostconsumer)
		{
			switch (defaultprepostconsumer)
			{
				case 2:
					{
						return "Intermediate";
					}
				case 0:
					{
						return "Pre-consumer";
					}
				case 1:
					{
						return "Post-consumer";
					}
			}
			return "(invalid waste mode)";
		}

		//****
		static public string DET_GetNewCurrDateTime(GlobalClasses.DataEntryTemplate det,
			Transaction_Mem transprev, GlobalClasses.DataEntrySession session)
		{
			string retdatetime = "";
			switch (det.Timestamp_NTPrefill)
			{
				case "Auto":
					{
						retdatetime = formatDateTime(DateTime.Now, det);
						break;
					}
				case "Prev":
					{
						if (transprev != null)
						{
							retdatetime = formatDateTime(transprev.Timestamp, det);
						}
						else
						{
							retdatetime = formatDateTime(DateTime.Now, det);
						}
						break;
					}
				case "Sess":
					{
						retdatetime = formatDateTime(session.DataFromDate, det);
						break;
					}
			}
			return retdatetime;
		}
		static public string GetToolTipTimestamp(string timestamp_NTPrefill)
		{
			switch (timestamp_NTPrefill.ToLower())
			{
				case "auto":
					{
						return "(Pre-filled from Current Date/Time Timestamp)";
						break;
					}
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Timestamp)";
						break;
					}
				case "sess":
					{
						return "(Pre-filled from the Session Default Timestamp)";
						break;
					}
			}
			return "";
		}


		static private string formatDateTime(string sdt)
		{
			return DateTime.Parse(sdt).ToShortDateString()
				+ " " + DateTime.Parse(sdt).ToShortTimeString();
		}

		static public string formatDateTime(DateTime dt, string formatstring)
		{
			return dt.ToString(formatstring);
		}

		static private string formatDateTime(DateTime dt, GlobalClasses.DataEntryTemplate det)
		{
			if (det.Timestamp_TFormat != "")
			{
				return dt.ToString(det.Timestamp_TFormat);
			}
			else
			{
				return dt.ToShortDateString() + " " +
					dt.ToShortTimeString();
			}
		}


		//****
		static public string DET_GetNewCurrUser_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retuser = "";
			switch (detmem.User_CTDefaultMode)
			{
				case "Prev":
					{
						if (prevtrans != null)
							retuser = prevtrans.UserTypeID;
						else
							retuser = "";
						break;
					}
				case "Sess":
					{
						if (prevtrans != null)
							retuser = SessionUserTypeID;
						break;
					}
				case "Form":
					{
						retuser = detmem.FormSet_UserType;
						break;
					}
			}
			return retuser;
		}

		static public string GetToolTipUser(string user_CTDefaultMode)
		{
			switch (user_CTDefaultMode.ToLower())
			{
				case "prev":
					{
						return "(Pre-filled from Previous Transaction User Type)";
						break;
					}
				case "sess":
					{
						return "(Pre-filled from the Session Default User Type)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default User Type)";
						break;
					}
			}
			return "(No Pre-fill of User Type)";
		}

		//****
		//Note that there is an inconsistency between the way two database tables define the same field.  
		//  Weights.IsPreconsumer values:
		//		Intermediate =	0
		//		Preconsumer =	1
		//		Post consumer = 2
		//  Terminals.DefaultPrePostconsumer values:
		//		Intermediate =  2
		//		Preconsumer =	0
		//		Post consumer = 1
		/// <summary>
		/// Return waste mode in Weights.IsPreconsumer format.
		/// </summary>
		static public string DET_GetNewCurrWasteModeFromDefaultPrePostConsumer(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{

			string termwastemode = ""; 
			string retwastemode = "1"; /// Init to Pre
			switch (detmem.Wastemode_CTDefaultMode)
			{
				case "Auto":
					{
						string sql = "SELECT DefaultPrePostConsumerFlag FROM Terminals WHERE TermID= '"
							+ SessionTracker_TermID + "'";
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							termwastemode = dr["DefaultPrePostConsumerFlag"].ToString();
						}
						// Convert to Weights.IsPreconsumer format
						retwastemode = "1"; /// Init to Pre
						if (termwastemode == "1")
						{
							retwastemode = "2"; /// Post
						}
						else if (termwastemode == "2")
						{
							retwastemode = "0";  /// Intermediate
						}
						break;
					}
				case "Prev":
					{
						if (prevtrans != null)
						retwastemode = prevtrans.IsPreconsumer.ToString();
						//retwastemode = GetWasteModeStringfromIsPreconsumer(prevtrans.IsPreconsumer);
						break;
					}
				case "Form":
					{
						retwastemode = 
							GetDefaultPrePostConsumerFlagfromWasteModeString(detmem.FormSet_Wastemode).ToString();
						//retwastemode = detmem.FormSet_Wastemode;
						break;
					}
			}
			return retwastemode;
		}
		static public string GetToolTipWasteMode(string wastemode_CTDefaultMode)
		{
			switch (wastemode_CTDefaultMode.ToLower())
			{
				case "auto":
					{
						return "(Pre-filled from the Tracker Default Waste Mode)";
						break;
					}
				case "prev":
					{
						return "(Pre-filled from Previous Transaction  Waste Mode)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Waste Mode)";
						break;
					}
			}
			return "(No Pre-fill of Waste Mode)";
		}



		//****
		static public string DET_GetNewCurrFood_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retfood = "";
			switch (detmem.FoodType_CTDefaultMode)
			{
				case "Prev":
					{
						if (prevtrans != null)
							retfood = prevtrans.FoodTypeID;
						break;
					}
				case "Form":
					{
						retfood = detmem.FormSet_FoodType;
						break;
					}
			}
			return retfood;
		}
		static public string GetToolTipFood(string foodType_CTDefaultMode)
		{
			switch (foodType_CTDefaultMode.ToLower())
			{
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Food Type)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Food Type)";
						break;
					}
			}
			return "(No Pre-fill of Food Type)";
		}


		//****
		static public string DET_GetNewCurrLoss_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retloss = "";
			switch (detmem.LossType_CTDefaultMode)
			{
				case "Prev":
					{
						if (prevtrans != null)
							retloss = prevtrans.LossTypeID;
						break;
					}
				case "Form":
					{
						retloss = detmem.FormSet_LossType;
						break;
					}
			}
			return retloss;
		}
		static public string GetToolTipLoss(string lossType_CTDefaultMode)
		{
			switch (lossType_CTDefaultMode.ToLower())
			{
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Loss Type)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Loss Type)";
						break;
					}
			}
			return "(No Pre-fill of Loss Type)";
		}


		//****
		static public string DET_GetNewCurrContainer_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retcontainer = "";
			switch (detmem.ContainerType_CTDefaultMode)
			{
				case "Prev":
					{
						if (prevtrans != null)
							retcontainer = prevtrans.ContainerTypeID;
						break;
					}
				case "Form":
					{
						retcontainer = detmem.FormSet_ContainerType;
						break;
					}
			}
			return retcontainer;
		}
		static public string GetToolTipContainer(string containerType_CTDefaultMode)
		{
			switch (containerType_CTDefaultMode.ToLower())
			{
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Container Type)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Container Type)";
						break;
					}
			}
			return "(No Pre-fill of Container Type)";
		}


		//****
		static public string DET_GetNewCurrStation_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retstation = "";
			switch (detmem.StationType_CTDefaultMode)
			{
				case "Auto":
					{
						string sql = "SELECT DefaultStation FROM Terminals WHERE TermID= '"
							+ SessionTracker_TermID;
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							retstation = dr["DefaultStation"].ToString();
						}
						break;
					}
				case "Prev":
					{
						if (prevtrans != null)
							retstation = prevtrans.StationTypeID;
						break;
					}
				case "Form":
					{
						retstation = detmem.FormSet_StationType;
						break;
					}
			}
			return retstation;
		}
		static public string GetToolTipStation(string station_CTDefaultMode)
		{
			switch (station_CTDefaultMode.ToLower())
			{
				case "auto":
					{
						return "(Pre-filled from the Tracker Default Station)";
						break;
					}
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Station)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Station)";
						break;
					}
			}
			return "(No Pre-fill of Station)";
		}


		//****
		static public string DET_GetNewCurrDisposition_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retdisposition = "";
			switch (detmem.DispositionType_CTDefaultMode)
			{
				case "Auto":
					{
						string sql = "SELECT DefaultDisposition FROM Terminals WHERE TermID= '"
							+ SessionTracker_TermID;
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							retdisposition = dr["DefaultDisposition"].ToString();
						}
						break;
					}
				case "Prev":
					{
						if (prevtrans != null)
							retdisposition = prevtrans.DispositionTypeID;
						break;
					}
				case "Form":
					{
						retdisposition = detmem.FormSet_DispositionType;
						break;
					}
			}
			return retdisposition;
		}
		static public string GetToolTipDisposition(string disposition_CTDefaultMode)
		{
			switch (disposition_CTDefaultMode.ToLower())
			{
				case "auto":
					{
						return "(Pre-filled from the Tracker Default Disposition)";
						break;
					}
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Disposition)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Disposition)";
						break;
					}
			}
			return "(No Pre-fill of Disposition)";
		}


		//****
		static public string DET_GetNewCurrDaypart_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string retdaypart = "";
			switch (detmem.DaypartType_CTDefaultMode)
			{
				case "Auto":
					{
						string sql = "SELECT DefaultDaypart FROM Terminals WHERE TermID= '"
							+ SessionTracker_TermID;
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						if (dt != null && dt.Rows.Count > 0)
						{
							DataRow dr = dt.Rows[0];
							retdaypart = dr["DefaultDaypart"].ToString();
						}
						break;
					}
				case "Prev":
					{
						if (prevtrans != null)
							retdaypart = prevtrans.DaypartTypeID;
						break;
					}
				case "Form":
					{
						retdaypart = detmem.FormSet_DaypartType;
						break;
					}
			}
			return retdaypart;
		}
		static public string GetToolTipDaypart(string daypart_CTDefaultMode)
		{
			switch (daypart_CTDefaultMode.ToLower())
			{
				case "auto":
					{
						return "(Pre-filled from the Tracker Default Daypart)";
						break;
					}
				case "prev":
					{
						return "(Pre-filled from Previous Transaction Daypart)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default Daypart)";
						break;
					}
			}
			return "(No Pre-fill of Daypart)";
		}

		//****
		static public string DET_GetNewCurrEventOrder_TypeID(GlobalClasses.DataEntryTemplate detmem,
			Transaction_Mem prevtrans)
		{
			string reteo = "";
			switch (detmem.EventOrderType_CTDefaultMode)
			{
				case "Prev":
					{
						if (prevtrans != null)
							reteo = prevtrans.BEOTypeID;
						break;
					}
				case "Form":
					{
						reteo = detmem.FormSet_EventOrderType;
						break;
					}
			}
			return reteo;
		}
		static public string GetToolTipEventOrder(string eventOrder_CTDefaultMode)
		{
			switch (eventOrder_CTDefaultMode.ToLower())
			{
				case "prev":
					{
						return "(Pre-filled from Previous Transaction EventOrder)";
						break;
					}
				case "form":
					{
						return "(Pre-filled from the Data Entry Template Default EventOrder)";
						break;
					}
			}
			return "(No Pre-fill of EventOrder)";
		}

		/// <summary>
		/// GetTypeNameFromTypeID
		/// </summary>
		/// <param name="typedim">What type? (food, loss, container, station, disposition,
		/// daypart, eventorder, user)</param>
		/// <param name="typeID">What typeID?</param>
		/// <param name="typename">The type Name for specified type ID.</param>
		/// <returns>True if success.</returns>
		static public bool GetTypeNameFromTypeID(string typedim, string typeID, out string typename)
		{
			typename = "";
			if (typeID == "") return false;
			//
			string sql = "SELECT TypeName FROM ";
			switch (typedim)
			{
				case "food":
					{
						sql += "FoodType";
						break;
					}
				case "loss":
					{
						sql += "LossType";
						break;
					}
				case "container":
					{
						sql += "ContainerType";
						break;
					}
				case "station":
					{
						sql += "StationType";
						break;
					}
				case "disposition":
					{
						sql += "DispositionType";
						break;
					}
				case "daypart":
					{
						sql += "DaypartType";
						break;
					}
				case "eventorder":
					{
						sql += "BEOType";
						break;
					}
				case "user":
					{
						sql += "UserType";
						break;
					}
			}
			sql += " WHERE TypeID='" + typeID + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				typename = dr["TypeName"].ToString();
				return true;
			}
			return false;
		}

		/// <summary>
		/// Retrieve volume data for a specific container type.
		/// </summary>
		/// <param name="typeid"></param>
		/// <param name="volume"></param>
		/// <param name="volumeunittype"></param>
		/// <returns>True if successful; false if data doesn't exist for given TypeID</returns>
		static public bool GetContainerVolumeData(string typeid, out decimal volume,
			out int volumeunittype)
		{
			volume = 0;
			volumeunittype = 0;
			string sql = "SELECT * FROM ContainerType WHERE TypeID = '"
				+ typeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				if (!decimal.TryParse(dr["Volume"].ToString(),
					out volume))
				{ return false; }
				if (!int.TryParse(dr["VolumeUnitType"].ToString(),
					out volumeunittype))
				{ return false; }
				if ((volume > 0) && (volumeunittype > 0))
				{ return true; }
			}
			return false;
		}
		/// <summary>
		/// Retrieve per unit cost for a specific container type.
		/// </summary>
		/// <param name="typeid">Container type id.</param>
		/// <param name="containercost">Container cost per unit.</param>
		/// <returns>True if successful; false if typeID doesn't exist.</returns>
		static public bool GetContainerCostandWeight(string typeid, out decimal containercost,
			out decimal containertareweight)
		{
			containercost = 0;
			containertareweight = -1;
			string sql = "SELECT Cost,TareWeight FROM ContainerType WHERE TypeID = '"
				+ typeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				if (!decimal.TryParse(dr["Cost"].ToString(),
					out containercost))
				{ return false; }
				if (!decimal.TryParse(dr["TareWeight"].ToString(),
					out containertareweight))
				{ return false; }
				return true;
			}
			return false;
		}

		/// <summary>
		/// Retrieve per pound cost for a specific food type.
		/// </summary>
		/// <param name="typeid"></param>
		/// <param name="foodcost"></param>
		/// <returns>True if successful; false if typeID doesn't exist.</returns>
		static public bool GetFoodCostfromType(string typeid, out decimal foodcost)
		{
			foodcost = 0;
			string sql = "SELECT Cost FROM FoodType WHERE TypeID = '"
				+ typeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				if (!decimal.TryParse(dr["Cost"].ToString(),
				out foodcost))
				{ return false; }
				return true;
			}
			return false;
		}


		/// <summary>
		/// Retrieve volume data for a specific food type.
		/// </summary>
		/// <param name="typeid"></param>
		/// <param name="volumeweight"></param>
		/// <param name="volumeunits"></param>
		/// <param name="volumeunittype"></param>
		/// <returns>True if successful; false if data doesn't exist for given TypeID</returns>
		static public bool GetFoodVolumeData(string typeid, out decimal volumeweight,
			out decimal volumeunits, out int volumeunittype)
		{
			volumeweight = 0;
			volumeunits = 0;
			volumeunittype = 0;
			string sql = "SELECT * FROM FoodType WHERE TypeID = '"
				+ typeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				if (!decimal.TryParse(dr["VolumeWeight"].ToString(),
						out volumeweight))
				{ return false; }
				if (!decimal.TryParse(dr["VolumeUnits"].ToString(),
						out volumeunits))
				{ return false; }
				if (!int.TryParse(dr["VolumeUnitType"].ToString(),
						out volumeunittype))
				{ return false; }
				if ((volumeweight > 0) && (volumeunits > 0) && (volumeunittype > 0))
				{ return true; }
			}
			return false;
		}

		/// <summary>
		/// Return English string describing volume data for specified food type.
		/// </summary>
		/// <param name="foodtypeid"></param>
		/// <param name="volumestring"></param>
		/// <returns></returns>
		static public bool GetFoodVolumeStringfromData(string foodtypeid,
			out string volumestring)
		{
			volumestring = "(missing data)";
			string sql = "SELECT * FROM FoodType WHERE TypeID = '"
				+ foodtypeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				decimal volumeweight = 0;
				decimal volumeunits = 0;
				int volumeunittype = 0;
				if (!decimal.TryParse(dr["VolumeWeight"].ToString(),
						out volumeweight)) { return false; }
				if (!decimal.TryParse(dr["VolumeUnits"].ToString(),
						out volumeunits)) { return false; }
				if (!int.TryParse(dr["VolumeUnitType"].ToString(),
						out volumeunittype)) { return false; }
				if (volumeweight <= 0 || volumeunits <= 0) { return false; }
				// We have the data - get the units
				string uniquename = "";
				string displayfullname = "";
				string displayabbreviatedname = "";
				decimal conversionfactor = 0;
				string description = "";
				GetUnitsVolumeDatafromID(volumeunittype,
					out uniquename, out displayfullname, out displayabbreviatedname,
					out conversionfactor, out description);
				// Create the string
				volumestring = volumeweight + " lb(s) per "
					+ volumeunits.ToString("####0.00") + " " + displayfullname;
				return true;
			}
			return false;
		}

		static public bool GetContainerVolumeStringfromData(string containertypeid,
			out string volumestring)
		{
			volumestring = "(missing data)";
			string sql = "SELECT * FROM ContainerType WHERE TypeID = '"
				+ containertypeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				decimal volume = 0;
				int volumeunittype = 0;
				if (!decimal.TryParse(dr["Volume"].ToString(),
						out volume)) { return false; }
				if (!int.TryParse(dr["VolumeUnitType"].ToString(),
						out volumeunittype)) { return false; }
				if (volume <= 0) { return false; }
				// We have the data - get the units
				string uniquename = "";
				string displayfullname = "";
				string displayabbreviatedname = "";
				decimal conversionfactor = 0;
				string description = "";
				GetUnitsVolumeDatafromID(volumeunittype,
					out uniquename, out displayfullname, out displayabbreviatedname,
					out conversionfactor, out description);
				// Create the string
				volumestring = volume.ToString("####0.00") + " "
					+ displayfullname;
				return true;
			}
			return false;
		}

		static public bool GetLossFlags(string losstypeid, out bool overproductionflag,
			out bool trimwasteflag, out bool handlingflag)
		{
			overproductionflag = false;
			trimwasteflag = false;
			handlingflag = false;
			string sql = "SELECT * FROM LossType WHERE TypeID = '"
				+ losstypeid.ToString() + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				overproductionflag = bool.Parse(dr["OverproductionFlag"].ToString());
				trimwasteflag = bool.Parse(dr["TrimWasteFlag"].ToString());
				handlingflag = bool.Parse(dr["HandlingFlag"].ToString());
				return true;
			}
			return false;
		}

		/// <summary>
		/// Return the Volume units data for a specific ID.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="uniquename"></param>
		/// <param name="displayfullname"></param>
		/// <param name="displayabbreviatedname"></param>
		/// <param name="conversionfactor"></param>
		/// <param name="description"></param>
		/// <returns>true if id refers to a valid Volume Unit type; 
		/// false if id doesn't match a valid Volume Unit type.</returns>
		static public bool GetUnitsVolumeDatafromID(int id,
			out string uniquename, out string displayfullname,
			out string displayabbreviatedname, out decimal conversionfactor,
			out string description)
		{
			uniquename = "";
			displayfullname = "";
			displayabbreviatedname = "";
			conversionfactor = 0;
			description = "";
			string sql = "SELECT * FROM UnitsVolume WHERE ID = "
				+ id.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				uniquename = dr["UniqueName"].ToString();
				displayfullname = dr["DisplayFullName"].ToString();
				displayabbreviatedname = dr["DisplayAbbreviatedName"].ToString();
				conversionfactor = decimal.Parse(dr["ConversionFactor"].ToString());
				description = dr["Description"].ToString();
				return true;
			}
			return false;
		}

		static public bool GetEventOrderEventData(string typeid, out string customername,
			out int guestcount, out DateTime eventdate, out string beonumber,
			out decimal mratio)
		{
			customername = "";
			guestcount = 0;
			eventdate = DateTime.MinValue;
			beonumber = "";
			mratio = 0;
			string sql = "SELECT * FROM BEOType WHERE TypeID = '"
				+ typeid + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				int iid = int.Parse(dr["Client"].ToString());
				GetEventClientNamefromID(iid, out customername);
				int.TryParse(dr["GuestCount"].ToString(),
						out guestcount);
				DateTime.TryParse(dr["EventDate"].ToString(),
						out eventdate);
				beonumber = dr["BEONumber"].ToString();
				decimal.TryParse(dr["MRatio"].ToString(),
						out mratio);
			}
			return false;
		}

		/// <summary>
		/// Get Event Client name from the EventClient.ID value.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="customername"></param>
		/// <returns></returns>
		static public bool GetEventClientNamefromID(int id, out string clientname)
		{
			clientname = "";
			string sql = "SELECT * FROM EventClients WHERE ID = "
				+ id.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				clientname = dr["ClientName"].ToString();
				return true;
			}
			return false;
		}

		static public bool GetDETNamefromID(int id, out string detname)
		{
			detname = "";
			string sql = "SELECT DETName FROM DataEntryTemplates WHERE ID = "
				+ id.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				detname = dr["DETName"].ToString();
				return true;
			}
			return false;
		}
		static public int GetDETCount()
		{
			string sql = "SELECT ID FROM DataEntryTemplates";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null)
			{
				return dt.Rows.Count;
			}
			return 0;
		}


		/// <summary>
		/// Get the name of an Each Format from its ID.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="eachformatname"></param>
		/// <returns></returns>
		static public bool GetEachFormatNameFromID(int id, out string eachformatname)
		{
			eachformatname = "";
			//
			string sql = "SELECT EachFormatName FROM EachFormats WHERE ID = "
				+ id + "";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				eachformatname = dr["EachFormatName"].ToString();
				return true;
			}
			return false;
		}


		static public bool GetEachFormatDataFromID(int id, out string eachformatname,
			out decimal eachquantity, out decimal wtmultiplier,
			out int unitswtid, out int sortorder, out string description)
		{
			string foodtypeid = "";
			return GetEachFormatDataFromID(id, out eachformatname,
				out eachquantity, out wtmultiplier,
				out unitswtid, out sortorder, out description, out foodtypeid);
		}

		/// <summary>
		/// Retrieve all data for the Each Format type ID supplied.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="eachformatname"></param>
		/// <param name="eachquantity"></param>
		/// <param name="wtmultiplier"></param>
		/// <param name="unitswtid"></param>
		/// <param name="sortorder"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		static public bool GetEachFormatDataFromID(int id, out string eachformatname,
			out decimal eachquantity, out decimal wtmultiplier,
			out int unitswtid, out int sortorder, out string description, out string foodtypeid)
		{
			eachformatname = "";
			eachquantity = 0;
			wtmultiplier = 0;
			unitswtid = 0;
			sortorder = 0;
			description = "";
			foodtypeid = "";
			//
			string sql = "SELECT * FROM EachFormats WHERE ID = "
				+ id + "";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				eachformatname = dr["EachFormatName"].ToString();
				if (!decimal.TryParse(dr["EachQuantity"].ToString(),
					out eachquantity))
				{ return false; }
				if (!decimal.TryParse(dr["WtMultiplier"].ToString(),
					out wtmultiplier))
				{ return false; }
				if (!int.TryParse(dr["UnitsWtID"].ToString(),
					out unitswtid))
				{ return false; }
				if (!int.TryParse(dr["SortOrder"].ToString(),
					out sortorder))
				{ return false; }
				description = dr["Description"].ToString();
				foodtypeid = dr["FoodTypeID"].ToString();
				//			
				return true;
			}
			return false;
		}

		static public bool GetEachFormatDefault(string foodtypeid, out int eachformatid,
			out string eachformatname)
		{

			string sql = @"SELECT * FROM EachFormats  WHERE FoodTypeID = '" + foodtypeid
				+ "' ORDER BY SortOrder ASC";
			DataTable dteachfmt = new DataTable();
			dteachfmt = VWA4Common.DB.Retrieve(sql);
			if (dteachfmt.Rows.Count > 0)
			{
				eachformatid = (int)dteachfmt.Rows[0]["ID"];
				eachformatname = dteachfmt.Rows[0]["EachFormatName"].ToString();
				return true;
			}
			eachformatid = 0;
			eachformatname = "";
			return false;
		}

		static public bool GetWtUnitsDataFromID(int id, out string uniquename,
			out string displayfullname, out string displayabbreviatedname,
			out decimal conversionfactor, out string description)
		{
			uniquename = "";
			displayfullname = "";
			displayabbreviatedname = "";
			conversionfactor = 0;
			description = "";
			//
			string sql = "SELECT * FROM UnitsWeight WHERE ID = "
				+ id + "";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				uniquename = dr["UniqueName"].ToString();
				displayfullname = dr["DisplayFullName"].ToString();
				displayabbreviatedname = dr["DisplayAbbreviatedName"].ToString();
				if (!decimal.TryParse(dr["ConversionFactor"].ToString(),
					out conversionfactor))
				{ return false; }
				description = dr["Description"].ToString();
				return true;
			}
			return false;
		}

		static public bool GetWtUnitsDataFromUniqueName(string uniquename, out int id,
			out string displayfullname, out string displayabbreviatedname,
			out decimal conversionfactor, out string description)
		{
			id = -1;
			displayfullname = "";
			displayabbreviatedname = "";
			conversionfactor = 0;
			description = "";
			//
			string sql = "SELECT * FROM UnitsWeight WHERE UniqueName = '"
				+ uniquename + "'";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				id = int.Parse(dr["ID"].ToString());
				displayfullname = dr["DisplayFullName"].ToString();
				displayabbreviatedname = dr["DisplayAbbreviatedName"].ToString();
				if (!decimal.TryParse(dr["ConversionFactor"].ToString(),
					out conversionfactor))
				{ return false; }
				description = dr["Description"].ToString();
				return true;
			}
			return false;
		}



		/// <summary>
		/// Get the weight, food cost and container cost using Volume method - all parameters supplied by
		/// caller.  NO ERROR CHECKING FOR BAD INPUT VALUES!!!
		/// </summary>
		/// <param name="vol_containermultiplier"></param>
		/// <param name="foodtypewtpervol"></param>
		/// <param name="foodvolumeunits"></param>
		/// <param name="foodtypecost"></param>
		/// <param name="containertypecost"></param>
		/// <param name="containervolume"></param>
		/// <param name="containerweight"></param>
		/// <param name="foodvolumeunituniquename"></param>
		/// <param name="containervolumeunituniquename"></param>
		/// <param name="foodwastecost"></param>
		/// <param name="containerwastecost"></param>
		/// <param name="totalcontainerweight"></param>
		/// <returns>Total net weight (food waste only - not containers); -1 if problems.</returns>
		public static decimal GetWasteWeightandCost_VolumeMethod(decimal vol_containermultiplier,
			decimal foodtypewtpervol, decimal foodvolumeunits, decimal foodtypecost,
			decimal containertypecost, decimal containervolume, decimal containerweight,
			int foodvolumeunitid, int containervolumeunitid,
			out decimal foodwastecost, out decimal containerwastecost, out decimal totalcontainerweight)
		{
			try
			{
				// calculate weight
				//  fvw = food volume weight, i.e. weight in lbs per nvu
				//  fnvu = food volume units, i.e. number of vut per lb
				//  fvutc = food volume unit type conversion factor (to cups)
				//  cv = Container volume in container volume units
				//  cvutc = container volume unit type conversion factor (to cups)
				//
				//  userentry = user-entered # of containers of waste for this entry
				//
				//  wt = (userentry * (cv * cvutc)) * (fvw / (fnvu * fvutc)
				//
				decimal fvutc = 0;
				decimal fvw = foodtypewtpervol;
				decimal fnvu = foodvolumeunits;
				decimal cv = containervolume;
				decimal cvutc = 0;
				//
				// 1) Get fvutc and cvutc from configured types
				//
				/// get food volume unit type conversion factor
				string sql = "SELECT ConversionFactor FROM UnitsVolume WHERE ID="
					+ foodvolumeunitid;
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					fvutc = decimal.Parse(dr["ConversionFactor"].ToString());
				}
				/// get container volume unit type conversion factor
				sql = "SELECT ConversionFactor FROM UnitsVolume WHERE ID="
					+ containervolumeunitid;
				dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					cvutc = decimal.Parse(dr["ConversionFactor"].ToString());
				}
				/// Make sure we have what we need to do calculation
				if ((fvutc == 0) || (cvutc == 0))
				{ // Volume Unit type not found
					foodwastecost = -1;
					containerwastecost = -1;
					totalcontainerweight = -1;
					return -1;
				}
				//
				// 2) Calculate wt
				//
				decimal wt = (vol_containermultiplier * (cv * cvutc)) * (fvw / (fnvu * fvutc));
				// ***** done with Volume-unique aspects of transaction
				//
				// Calculate food dollars
				//
				foodwastecost = wt * foodtypecost;
				//
				// Calculate container dollars (vol_containermultiplier * cost per container)
				//
				containerwastecost = vol_containermultiplier * containertypecost;
				decimal contmultiplier_roundup = Decimal.Truncate(vol_containermultiplier);
				if (contmultiplier_roundup != vol_containermultiplier)
					contmultiplier_roundup = Decimal.Round(contmultiplier_roundup + (decimal)0.5);
				totalcontainerweight = contmultiplier_roundup * containerweight;

				return wt;
			}
			catch
			{ // in case we have a math error 
				foodwastecost = -1;
				containerwastecost = -1;
				totalcontainerweight = -1;
				return -1;
			}
		}











		/// 
		/// 
		/// 
		/// 
		/// Database/Application Level Globals
		/// 
		/// 
		/// 
		/// 
		/// 

		//**** TrackerSWVersion 
		// This is used by EnterWasteData, and contains the current VWT software version.
		static private string _TrackerSWVersion;

		static public string TrackerSWVersion
		{
			get
			{
				if (_TrackerSWVersion == null)
				{
					_TrackerSWVersion = Query.GetGlobalSetting("TrackerSWVersion", CurrentSiteID);
				}
				return _TrackerSWVersion;
			}
			set
			{
				_TrackerSWVersion = value;
				if (value != null)
					Query.SaveGlobalSetting("TrackerSWVersion", value, "String", CurrentSiteID);
			}
		}

		//**** FirstDayOfWeek 
		// 
		// Built-in default
		//private const string _FirstDayOfWeekConst = "Monday";
		static private string _FirstDayOfWeek;

		static public string FirstDayOfWeek
		{
			get
			{
				if (_FirstDayOfWeek == null)
				{
					_FirstDayOfWeek = Query.GetGlobalSetting("FirstDayOfWeek", CurrentSiteID);
					TrackerDetector.GetTrackerDetector().FirstDayOfWeek = (DayOfWeek)(DayOfWeek.Parse(typeof(DayOfWeek), _FirstDayOfWeek));
					// todo: validate that the day is a member of the set of day of week names
					//if( _FirstDayOfWeek == "")
					//    _FirstDayOfWeek = _FirstDayOfWeekConst;
				}
				return _FirstDayOfWeek;
			}
			set
			{
				// todo: validate value to set here
				string old = _FirstDayOfWeek;
				_FirstDayOfWeek = value;
				if (value != null && old != value)
					TrackerDetector.GetTrackerDetector().FirstDayOfWeek = (DayOfWeek)(DayOfWeek.Parse(typeof(DayOfWeek), value));

				if (value != null)
					Query.SaveGlobalSetting("FirstDayOfWeek", value, "DateTime", CurrentSiteID);
			}
		}
		static public string GetFirstDayOfWeek(int siteID)
		{
			return Query.GetGlobalSetting("FirstDayOfWeek", siteID);
		}

		//**** PrimaryUserName
		//
		// Built-in default
		//private const string _PrimaryUserNameConst = "(Primary User Name)";
		static private string _PrimaryUserName;

		static public string PrimaryUserName
		{
			get
			{
				if (_PrimaryUserName == null)
				{
					_PrimaryUserName = Query.GetGlobalSetting("PrimaryUserName", 0);
					//if (_PrimaryUserName == "")
					//    _PrimaryUserName = _PrimaryUserNameConst;
				}
				return _PrimaryUserName;
			}
			set
			{
				_PrimaryUserName = value;
				if ((value != null) && (value != Query._ConstSettings["PrimaryUserName"].ToString()))
					Query.SaveGlobalSetting("PrimaryUserName", value, "String", 0);
			}
		}

		//**** PrimaryUserEmail
		//
		// Built-in default
		//private const string _PrimaryUserEmailConst = "(Primary User Email)";
		static private string _PrimaryUserEmail;

		static public string PrimaryUserEmail
		{
			get
			{
				if (_PrimaryUserEmail == null)
				{
					_PrimaryUserEmail = Query.GetGlobalSetting("PrimaryUserEmail", 0);
					//if (_PrimaryUserEmail == "")
					//    _PrimaryUserEmail = _PrimaryUserEmailConst;
				}
				return _PrimaryUserEmail;
			}
			set
			{
				_PrimaryUserEmail = value;
				if ((value != null) && (value != Query._ConstSettings["PrimaryUserEmail"].ToString()))
					Query.SaveGlobalSetting("PrimaryUserEmail", value, "String", 0);
			}
		}

		//**** TrackerConfigOutofSync
		// If true, then Tracker configuration has changed since the last transfer config (needs to be
		//  re-transferred)
		// Site is not taken into account.
		static private string _TrackerConfigOutofSync;

		static public bool TrackerConfigOutofSync
		{
			get
			{
				if (_TrackerConfigOutofSync == null || _TrackerConfigOutofSync == "")
				{
					string lastChange = Query.GetGlobalSetting("TrackerConfigOutofSync", 0);
					if (lastChange == "" || !Regex.IsMatch(lastChange, @"\d+\/\d+\/\d+"))
					{
						_TrackerConfigOutofSync = false.ToString();
						TrackerDetector.GetTrackerDetector().LastChanges = new DateTime(0);
						return false;
					}
					else
					{
						_TrackerConfigOutofSync = true.ToString();
						TrackerDetector.GetTrackerDetector().LastChanges = DateTime.Parse(lastChange);
						return true;
					}
				}
				else
					return bool.Parse(_TrackerConfigOutofSync);
			}
			set
			{
				DateTime lastChange = DateTime.Now;
				_TrackerConfigOutofSync = value.ToString().Trim();
				if (value)
				{
					TrackerDetector.GetTrackerDetector().LastChanges = lastChange;
					Query.SaveGlobalSetting("TrackerConfigOutofSync", lastChange.ToString("yyyy/MM/dd HH:mm:ss"), "DateTime", 0);
				}
				else
				{
					TrackerDetector.GetTrackerDetector().LastChanges = lastChange;
					Query.SaveGlobalSetting("TrackerConfigOutofSync", "", "DateTime", 0);
				}
			}
		}


		//**** Advanced filters on/off 
		// Built-in default
		private const string _AutoUpdateTrackersConst = "false";
		static private string _AutoUpdateTrackers;

		static public string AutoUpdateTrackers
		{
			get
			{
				if (_AutoUpdateTrackers == null)
				{
					_AutoUpdateTrackers = Query.GetGlobalSetting("AutoUpdateTrackers", 0);
					if (_AutoUpdateTrackers == "")
						_AutoUpdateTrackers = _AutoUpdateTrackersConst;
				}
				return _AutoUpdateTrackers;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_AutoUpdateTrackers = _AutoUpdateTrackersConst;
				}
				else
				{
					_AutoUpdateTrackers = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("AutoUpdateTrackers", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("AutoUpdateTrackers", "false", "Boolean", 0);
				}
			}
		}



		//**** Constants

		static public System.Drawing.Color BackColor_Success = System.Drawing.Color.PaleGreen;
		static public System.Drawing.Color BackColor_Failure = System.Drawing.Color.LightCoral;

		/// 
		/// Site-related Globals & Methods
		/// 

		public static void SiteChanged()
		{
			// Null out baseline values
			InvalidateBaseline();
			// todo: null out all Site-specific cached properties.
			_CurrentSiteName = null;
			_CurrentTypeCatalogID = null;
			_CurrentTypeCatalogName = null;
			_StartDateOfSelectedWeek = null;
			_FirstDayOfWeek = null;
			string x = VWA4Common.GlobalSettings.FirstDayOfWeek; // Force reload/recompute FirstDayofWeek
			_FoodCostReportPoints = null;
			_CycleTime = null;
		}

		//*******_CurrentSiteID
		static private string _CurrentSiteID;
		public static int CurrentSiteID
		{
			get
			{

	
				if (_CurrentSiteID == null)
				{
					_CurrentSiteID =
						Query.GetGlobalSetting("CurrentSiteID", 0);
					SiteChanged();
				}
				if (_CurrentSiteID == string.Empty)
				{ // Nothing is set yet - initialize to something
					string sql = "SELECT ID FROM Sites"
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					DataRow dr = dt.Rows[0];
					CurrentSiteID = (int)dr["ID"];
				}
				return int.Parse(_CurrentSiteID);
			}
			set
			{
				if (value < 0)
				{
					_CurrentSiteID =
						Query.GetGlobalSetting("CurrentSiteID", 0);
				}
				else
				{
					_CurrentSiteID = value.ToString();
					Query.SaveGlobalSetting("CurrentSiteID", _CurrentSiteID, "Number", 0);
				}
				SiteChanged();
			}
		}

		//*******_CurrentSiteName
		static private string _CurrentSiteName;
		public static string CurrentSiteName
		{
			get
			{
				if (CurrentSiteID == 0)
				{
					_CurrentSiteName = "ALL";
				}
				if (_CurrentSiteName == null)
				{
					string sql = "SELECT LicensedSite FROM Sites WHERE ID = "
						+ CurrentSiteID.ToString()
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					if (dt != null && dt.Rows.Count > 0)
					{
						DataRow dr = dt.Rows[0];
						_CurrentSiteName = dr["LicensedSite"].ToString();
					}
				}
				return _CurrentSiteName;
			}
		}


		//*******_CurrentTypeCatalogID
		static private string _CurrentTypeCatalogID;
		public static int CurrentTypeCatalogID
		{
			get
			{
				if (_CurrentTypeCatalogID == null)
				{
					string sql = "SELECT TypeCatalogID FROM Sites WHERE ID = "
						+ CurrentSiteID.ToString()
						;
					DataTable dt = VWA4Common.DB.Retrieve(sql);
					DataRow dr = dt.Rows[0];
					_CurrentTypeCatalogID = dr["TypeCatalogID"].ToString();
				}
				return int.Parse(_CurrentTypeCatalogID);
			}
		}

		//*******__CurrentTypeCatalogName
		static private string _CurrentTypeCatalogName;
		public static string CurrentTypeCatalogName
		{
			get
			{
				if (CurrentTypeCatalogID == 0)
				{
					_CurrentTypeCatalogName = "MASTER";
				}
				else
					if (_CurrentTypeCatalogName == null)
					{
						string sql = "SELECT TypeCatalogName FROM TypeCatalogs WHERE ID = "
							+ CurrentTypeCatalogID.ToString()
							;
						DataTable dt = VWA4Common.DB.Retrieve(sql);
						DataRow dr = dt.Rows[0];
						_CurrentTypeCatalogName = dr["TypeCatalogName"].ToString();
					}
				return _CurrentTypeCatalogName;
			}
		}


		///
		/// BASELINE Settings
		///  Functionality:
		///	  - In general, most of these settings are Site specific and relate to the current Site only. Thus, when
		///		the current Site is changed, the properties need to be reloaded.
		/// 
		///   - non-empty string on Stipulated settings indicates that the settings are stipulated; otherwise 
		///     they are derived.
		///   - Derived settings are computed from the baseline Starting date, averaged across the baseline number of weeks
		///     to average.
		///   - Default baseline is the first full week of data.
		///   


		public static void InvalidateBaseline()
		{
			// Null out all the derived baseline cached values, since the database (or current Site) has changed in some
			// way that could require them to need to be recalculated.
			_BaselineWeeklyWasteCost_Derived = null;
			_BaselineWeeklyWasteCost_Stipulated = null;
			_BaselineWeeklyWasteTrans_Derived = null;
			_BaselineWeeklyWasteTrans_Stipulated = null;
			_BaselineStartDate = null;
			_BaselineWasteMethod = null;
			_BaselineMonthlyActualFoodCost_Stipulated = null;
			_BaselineMonthlyActualFoodRevenue_Stipulated = null;
			_BaselineMonthlyActualMealCount_Stipulated = null;
			_BaselineMonthlyBudgetedFoodCost_Stipulated = null;
			_BaselineMonthlyBudgetedFoodRevenue_Stipulated = null;
			_BaselineMonthlyBudgetedMealCount_Stipulated = null;
		}

		//**** BaselineWasteMethod
		// Built-in default - Compute BaselineNumberofWeeks weeks from BaselineStartDate,
		//   using BaselineComputeMethod
		//private const string _BaselineWasteMethodConst = "Computed";
		static private string _BaselineWasteMethod;

		static public string BaselineWasteMethod
		{
			get
			{
				if ((_BaselineWasteMethod == null) || (_BaselineWasteMethod == ""))
				{ // Default is Computed (Derived)

					_BaselineWasteMethod =
						Query.GetGlobalSetting("BaselineWasteMethod", CurrentSiteID);
					//if (_BaselineWasteMethod == "") _BaselineWasteMethod = _BaselineWasteMethodConst;
				}
				return _BaselineWasteMethod;
			}
			set
			{
				_BaselineWasteMethod = value;
				if (value != null)
				{
					// Make sure it's a legal setting - if not, set to default
					if ((_BaselineWasteMethod != "Computed") && (_BaselineWasteMethod != "Stipulated"))
						_BaselineWasteMethod = Query._ConstSettings["BaselineWasteMethod"].ToString();
					Query.SaveGlobalSetting("BaselineWasteMethod", _BaselineWasteMethod.Trim(), "String", CurrentSiteID);
				}
			}
		}

		static public string GetBaselineWasteMethod(string siteID)
		{
			return Query.GetGlobalSetting("BaselineWasteMethod", int.Parse(siteID));
		}

		//**** BaselineComputeMethod
		// Built-in default - Average of BaselineNumberofWeeks weeks from BaselineStartDate
		//private const string _BaselineWasteMethodConst = "Average";
		static private string _BaselineComputeMethod;

		static public string BaselineComputeMethod
		{
			get
			{
				if ((_BaselineComputeMethod == null) || (_BaselineComputeMethod == ""))
				{ // Default is Computed (Derived)
					_BaselineComputeMethod =
						Query.GetGlobalSetting("BaselineComputeMethod", CurrentSiteID);
				}
				return _BaselineComputeMethod;
			}
			set
			{
				_BaselineComputeMethod = value;
				if (value != null)
				{
					// Make sure it's a legal setting - if not, set to default
					if ((_BaselineComputeMethod != "Average") && (_BaselineComputeMethod != "Maximum"))
						_BaselineComputeMethod = Query._ConstSettings["BaselineComputeMethod"].ToString();
					Query.SaveGlobalSetting("BaselineComputeMethod", _BaselineComputeMethod.Trim(), "String", CurrentSiteID);
				}
			}
		}


		//**** BaselineStartDate (date format - if not set when queried, gets set to now)
		// Built-in default
		static private string _BaselineStartDate;

		static public string BaselineStartDate
		{
			get
			{
				if ((_BaselineStartDate == null) || (_BaselineStartDate == ""))
				{
					_BaselineStartDate =
					   Query.GetGlobalSetting("BaselineStartDate", CurrentSiteID);
					if (_BaselineStartDate == "")
					{
						// Default is previous week
						DateTime dt = DateTime.Now.Date.AddDays(-7);
						while (dt.DayOfWeek.ToString() != FirstDayOfWeek)
						{
							dt = dt.AddDays(-1); // Back up to where the FirstDayOfWeek is correct}
						}
						_BaselineStartDate = dt.ToString("yyyy/MM/dd") + " 00:00:00";
						// Also set it if not already set
						Query.SaveGlobalSetting("BaselineStartDate", _BaselineStartDate, "DateTime", CurrentSiteID);
					}
				}
				return _BaselineStartDate;
			}
			set
			{
				if ((value != null) && (value != string.Empty))
				{
					DateTime dt = DateTime.Parse(value);
					while (dt.DayOfWeek.ToString() != FirstDayOfWeek)
					{
						dt = dt.AddDays(-1); // Back up to where the FirstDayOfWeek is correct}
					}
					_BaselineStartDate = dt.ToString("yyyy/MM/dd") + " 00:00:00";
					Query.SaveGlobalSetting("BaselineStartDate", _BaselineStartDate, "DateTime", CurrentSiteID);
				}
				else
				{
					_BaselineStartDate = string.Empty;
				}
			}
		}

		static public string GetBaselineStartDate(string siteID)
		{

			string baselineStartDate =
				   Query.GetGlobalSetting("BaselineStartDate", int.Parse(siteID));
			if (baselineStartDate == "")
			{
				// Default is previous week
				DateTime dt = DateTime.Now.Date.AddDays(-7);
				while (dt.DayOfWeek.ToString() != GetFirstDayOfWeek(int.Parse(siteID)))
				{
					dt = dt.AddDays(-1); // Back up to where the FirstDayOfWeek is correct}
				}
				baselineStartDate = dt.ToString("yyyy/MM/dd") + " 00:00:00";
				// Also set it if not already set
				Query.SaveGlobalSetting("BaselineStartDate", baselineStartDate, "DateTime", int.Parse(siteID));
			}
			return baselineStartDate;
		}
		//**** BaselineNumberofWeeks (integer format - if not set when queried, gets set to 1)
		// Built-in default
		static private string _BaselineNumberofWeeks;

		static public string BaselineNumberofWeeks
		{
			get
			{
				if ((_BaselineNumberofWeeks == null) || (_BaselineNumberofWeeks == ""))
				{
					// Get the value from database
					_BaselineNumberofWeeks = Query.GetGlobalSetting("BaselineNumberofWeeks", CurrentSiteID);
					if (_BaselineNumberofWeeks == "")
					{ // Not set yet in DB - set to default
						// Default is one week
						_BaselineNumberofWeeks = "1";
						Query.SaveGlobalSetting("BaselineNumberofWeeks", _BaselineNumberofWeeks, "Number", CurrentSiteID);
					}
				}
				return _BaselineNumberofWeeks;
			}
			set
			{
				if (value == null) _BaselineNumberofWeeks = null;
				else
					_BaselineNumberofWeeks = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineNumberofWeeks", _BaselineNumberofWeeks, "Number", CurrentSiteID);
			}
		}

		static public string GetBaselineNumberofWeeks(string siteID)
		{
			// Get the value from database
			string baselineNumberofWeeks = Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID));
			if (baselineNumberofWeeks == "")
			{ // Not set yet in DB - set to default
				// Default is one week
				baselineNumberofWeeks = "1";
				Query.SaveGlobalSetting("BaselineNumberofWeeks", baselineNumberofWeeks, "Number", int.Parse(siteID));
			}
			return baselineNumberofWeeks;
		}
		//**** BaselineWeeklyWasteCost 
		// Call this to to get the baseline - determines whether stipulated or derived is used
		static public string BaselineWeeklyWasteCost
		{
			get
			{
				if (BaselineWasteMethod == "Computed")
				{ // then use derived
					return BaselineWeeklyWasteCost_Derived;
				}
				else
				{ // use stipulated
					return BaselineWeeklyWasteCost_Stipulated;
				}
			}
		}
		//**** BaselineWeeklyWasteCost 
		// Call this to to get the baseline - determines whether stipulated or derived is used
		static public string GetBaselineWeeklyWasteCost(string siteID)
		{
			if (GetBaselineWasteMethod(siteID) == "Computed")
			{ // then use derived
				return CalcWeeklyBaseLineCost(siteID).ToString();
			}
			else
			{ // use stipulated
				return Query.GetGlobalSetting("BaselineWeeklyWasteCost_Stipulated", int.Parse(siteID)); ;
			}
		}


		//**** BaselineWeeklyWasteCost_Stipulated (currency format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineWeeklyWasteCost_StipulatedConst = "";
		static private string _BaselineWeeklyWasteCost_Stipulated;

		static public string BaselineWeeklyWasteCost_Stipulated
		{
			get
			{
				if (_BaselineWeeklyWasteCost_Stipulated == null)
				{
					_BaselineWeeklyWasteCost_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyWasteCost_Stipulated", CurrentSiteID);
					if (_BaselineWeeklyWasteCost_Stipulated == "")
						_BaselineWeeklyWasteCost_Stipulated = "0";
				}
				return _BaselineWeeklyWasteCost_Stipulated;
			}
			set
			{
				if (value == null) _BaselineWeeklyWasteCost_Stipulated = null;
				else
					_BaselineWeeklyWasteCost_Stipulated = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyWasteCost_Stipulated", _BaselineWeeklyWasteCost_Stipulated, "Number", CurrentSiteID);
			}
		}

		//**** BaselineWeeklyWasteCost_Derived (currency format, null => must calculate new baseline)
		// Built-in default
		static private string _BaselineWeeklyWasteCost_Derived;

		static public string BaselineWeeklyWasteCost_Derived
		{
			get
			{
				if (_BaselineWeeklyWasteCost_Derived == null)
				{

					_BaselineWeeklyWasteCost_Derived = CalcWeeklyBaseLineCost().ToString("####0.00");
				}
				return _BaselineWeeklyWasteCost_Derived;
			}
			set
			{
				_BaselineWeeklyWasteCost_Derived = null;
			}
		}

		static private decimal CalcWeeklyBaseLineCost()
		{
			return CalcWeeklyBaseLineCost(CurrentSiteID.ToString());
		}
		static private decimal CalcWeeklyBaseLineCost(string siteID)
		{
			int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID)));
			DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(siteID));
			DateTime bedt = baselineStartDate.AddDays(nwks * 7);

			if (VWA4Common.GlobalSettings.BaselineComputeMethod == "Average")
			{ // Find Average
				string sql = "SELECT SUM(WasteCost), Count(*) " +
				" FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
				" WHERE ((Weights.Timestamp >= #" + baselineStartDate.ToString("yyyy/MM/dd") + " 00:00:00#) " +
				" AND (Weights.Timestamp < #" + bedt.ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID;
				DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
				DataRow thisRow = dt_wcost.Rows[0];
				string sum = thisRow[0].ToString();
				string count = thisRow[1].ToString();
				if (sum != "")
				{
					decimal dwastecost = 0;
					decimal.TryParse(sum, out dwastecost);
					BaselineWeeklyWasteTrans_Derived = count.ToString();
					return dwastecost / nwks;
				}
				else
				{
					BaselineWeeklyWasteTrans_Derived = count.ToString();
					return 0;
				}
			}
			else
			{ // Find maximum weekly value in the range of the number of weeks from starting date
				decimal maxweeklycost = 0;
				int numtrans = 0;
				DateTime bweekstart = baselineStartDate;
				// find max weekly waste cost
				for (int i = 0; i < nwks; i++)
				{
					string sql = "SELECT SUM(WasteCost), Count(*)" +
				" FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
				" WHERE ((Weights.Timestamp >= #" + bweekstart.ToString("yyyy/MM/dd") + " 00:00:00#) " +
				" AND (Weights.Timestamp < #" + bweekstart.AddDays(7).ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID;
					DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
					if (dt_wcost.Rows.Count > 0)
					{
						DataRow thisRow = dt_wcost.Rows[0];
						if (thisRow[0] != null)
						{
							if ((thisRow[0].ToString() != "") && (decimal.Parse(thisRow[0].ToString()) > maxweeklycost))
							{
								maxweeklycost = decimal.Parse(thisRow[0].ToString());
								numtrans = int.Parse(thisRow[1].ToString());
							}
						}

						bweekstart = bweekstart.AddDays(7);
					}
				}
				BaselineWeeklyWasteTrans_Derived = numtrans.ToString();
				return maxweeklycost;
			}

		}
		//**** BaselineWeeklyWasteTrans 
		// Call this to to get the baseline - determines whether stipulated or derived is used
		static public string BaselineWeeklyWasteTrans
		{
			get
			{
				if (BaselineWasteMethod == "Computed")
				{ // then use derived
					return BaselineWeeklyWasteTrans_Derived;
				}
				else
				{ // use stipulated
					return BaselineWeeklyWasteTrans_Stipulated;
				}
			}
		}

		static public string GetBaselineWeeklyWasteTrans(string siteID)
		{
			if (GetBaselineWasteMethod(siteID) == "Computed")
			{ // then use derived
				return CalcWeeklyWasteTrans(siteID).ToString();
			}
			else
			{ // use stipulated
				return Query.GetGlobalSetting("BaselineWeeklyWasteTrans_Stipulated", int.Parse(siteID));
			}

		}

		//**** BaselineWeeklyWasteTrans_Stipulated (integer format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineWeeklyWasteTrans_StipulatedConst = "";
		static private string _BaselineWeeklyWasteTrans_Stipulated;

		static public string BaselineWeeklyWasteTrans_Stipulated
		{
			get
			{
				if (_BaselineWeeklyWasteTrans_Stipulated == null)
				{
					_BaselineWeeklyWasteTrans_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyWasteTrans_Stipulated", CurrentSiteID);
					if (_BaselineWeeklyWasteTrans_Stipulated == "")
						_BaselineWeeklyWasteTrans_Stipulated = "0";
				}
				return _BaselineWeeklyWasteTrans_Stipulated;
			}
			set
			{
				if (value == null) _BaselineWeeklyWasteTrans_Stipulated = null;
				else
					_BaselineWeeklyWasteTrans_Stipulated = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyWasteTrans_Stipulated", _BaselineWeeklyWasteTrans_Stipulated, "Number", CurrentSiteID);
			}
		}

		//**** BaselineWeeklyWasteTrans_Derived (integer format, null => must calculate new baseline)
		// Built-in default
		static private string _BaselineWeeklyWasteTrans_Derived;

		static public string BaselineWeeklyWasteTrans_Derived
		{
			get
			{
				if (BaselineComputeMethod == "Maximum")
				{ // Calculate Max
					int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(CurrentSiteID.ToString())));
					DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(CurrentSiteID.ToString()));
					DateTime bedt = baselineStartDate.AddDays(nwks * 7);
					decimal maxweeklycost = 0;
					int numtrans = 0;
					DateTime bweekstart = baselineStartDate;
					// find max weekly waste cost
					for (int i = 0; i < nwks; i++)
					{
						string sql = "SELECT SUM(WasteCost), Count(*)" +
					" FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
					" WHERE ((Weights.Timestamp >= #" + bweekstart.ToString("yyyy/MM/dd") + " 00:00:00#) " +
					" AND (Weights.Timestamp < #" + bweekstart.AddDays(7).ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + CurrentSiteID.ToString();
						DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
						DataRow thisRow = dt_wcost.Rows[0];
						if (thisRow[0].ToString().ToString() != "")
						{
							if (decimal.Parse(thisRow[0].ToString()) > maxweeklycost)
							{
								maxweeklycost = decimal.Parse(thisRow[0].ToString());
								numtrans = int.Parse(thisRow[1].ToString());
							}
						}
						bweekstart = bweekstart.AddDays(7);
					}
					_BaselineWeeklyWasteCost_Derived = maxweeklycost.ToString();
					_BaselineWeeklyWasteTrans_Derived = numtrans.ToString();
				}
				else
				{ // Calculate Average
					// Calculate the average weekly baseline number of transactions based on current settings
					//
					_BaselineWeeklyWasteTrans_Derived = CalcWeeklyWasteTrans().ToString();
				}
				return _BaselineWeeklyWasteTrans_Derived;
			}
			set
			{
				if (value == null)
				{
					_BaselineWeeklyWasteTrans_Derived = null;
				}
				else
				{
					_BaselineWeeklyWasteTrans_Derived = value;
				}
			}
		}
		static private int CalcWeeklyWasteTrans()
		{
			return CalcWeeklyWasteTrans(CurrentSiteID.ToString());
		}
		static private int CalcWeeklyWasteTrans(string siteID)
		{
			// Need to calculate the end date of the baseline period for sql
			//
			int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID)));
			DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(siteID));
			DateTime bedt = baselineStartDate.AddDays(nwks * 7);
			string sql = "SELECT Count(*) AS ntrans" +
			" FROM Weights LEFT JOIN Transfers ON Weights.TransKey = Transfers.TransKey " +
			" WHERE ((Weights.Timestamp >= #" + baselineStartDate.ToString("yyyy/MM/dd") + " 00:00:00#) " +
			" AND (Weights.Timestamp < #" + bedt.ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID; ;
			DataTable dt_trans = VWA4Common.DB.Retrieve(sql);
			DataRow thisRow = dt_trans.Rows[0];
			string result = thisRow[0].ToString();
			if (result != "")
			{
				int intrans = 0;
				int.TryParse(result.ToString(), out intrans);
				return intrans / nwks;
			}
			else return 0;
		}
		//**** BaselineMonthlyActualFoodCost_Stipulated (currency format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineMonthlyActualFoodCost_StipulatedConst = "";
		static private string _BaselineMonthlyActualFoodCost_Stipulated;

		static public string BaselineMonthlyActualFoodCost_Stipulated
		{
			get
			{
				if (_BaselineMonthlyActualFoodCost_Stipulated == null)
				{
					_BaselineMonthlyActualFoodCost_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyActualFoodCost_Stipulated", CurrentSiteID);
					if (_BaselineMonthlyActualFoodCost_Stipulated == "")
						_BaselineMonthlyActualFoodCost_Stipulated = "0";
				}
				return _BaselineMonthlyActualFoodCost_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyActualFoodCost_Stipulated = null;
				else
					_BaselineMonthlyActualFoodCost_Stipulated = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyActualFoodCost_Stipulated", _BaselineMonthlyActualFoodCost_Stipulated, "Number", CurrentSiteID);
			}
		}

		static public string GetBaselineMonthlyActualFoodCost(string siteID)
		{
			if (GetBaselineWasteMethod(siteID) == "Stipulated")
			{
				string baselineMonthlyActualFoodCost_Stipulated =
					Query.GetGlobalSetting("BaselineWeeklyActualFoodCost_Stipulated", int.Parse(siteID));
				if (baselineMonthlyActualFoodCost_Stipulated == "")
					baselineMonthlyActualFoodCost_Stipulated = "0";

				return baselineMonthlyActualFoodCost_Stipulated;
			}
			else
			{
				int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID)));
				DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(siteID));
				DateTime bedt = baselineStartDate.AddDays(nwks * 7);

				string sql = "SELECT SUM(FoodCostActual) AS foodcostactual FROM Financials WHERE ((PeriodStartDate >= #"
				+ baselineStartDate.ToString("yyyy/MM/dd") + " 00:00:00#) AND (PeriodStartDate < #"
				+ bedt.Date.ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID;
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count >= 0 && dt.Rows[0][0].ToString() != "")
				{
					decimal dres = 0;
					decimal.TryParse(dt.Rows[0][0].ToString(), out dres);
					return (dres / nwks).ToString();
				}
				else return "0";
			}
		}

		//**** BaselineMonthlyBudgetedFoodCost_Stipulated (currency format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineMonthlyBudgetedFoodCost_StipulatedConst = "";
		static private string _BaselineMonthlyBudgetedFoodCost_Stipulated;

		static public string BaselineMonthlyBudgetedFoodCost_Stipulated
		{
			get
			{
				if (_BaselineMonthlyBudgetedFoodCost_Stipulated == null)
				{
					_BaselineMonthlyBudgetedFoodCost_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyBudgetedFoodCost_Stipulated", CurrentSiteID);
					if (_BaselineMonthlyBudgetedFoodCost_Stipulated == "")
						_BaselineMonthlyBudgetedFoodCost_Stipulated = "0";
				}
				return _BaselineMonthlyBudgetedFoodCost_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyBudgetedFoodCost_Stipulated = null;
				else
					_BaselineMonthlyBudgetedFoodCost_Stipulated = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyBudgetedFoodCost_Stipulated", _BaselineMonthlyBudgetedFoodCost_Stipulated, "Number", CurrentSiteID);
			}
		}

		//**** BaselineMonthlyActualFoodRevenue_Stipulated (currency format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineMonthlyActualFoodRevenue_StipulatedConst = "";
		static private string _BaselineMonthlyActualFoodRevenue_Stipulated;

		static public string BaselineMonthlyActualFoodRevenue_Stipulated
		{
			get
			{
				if (_BaselineMonthlyActualFoodRevenue_Stipulated == null)
				{
					_BaselineMonthlyActualFoodRevenue_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyActualFoodRevenue_Stipulated", CurrentSiteID);
				}
				if (_BaselineMonthlyActualFoodRevenue_Stipulated == "")
					_BaselineMonthlyActualFoodRevenue_Stipulated = "0";
				return _BaselineMonthlyActualFoodRevenue_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyActualFoodRevenue_Stipulated = null;
				else
					_BaselineMonthlyActualFoodRevenue_Stipulated = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyActualFoodRevenue_Stipulated", _BaselineMonthlyActualFoodRevenue_Stipulated, "Number", CurrentSiteID);
			}
		}

		static public string GetBaselineMonthlyActualFoodRevenue(string siteID)
		{
			if (GetBaselineWasteMethod(siteID) == "Stipulated")
			{
				string baselineMonthlyActualFoodRevenue_Stipulated =
					Query.GetGlobalSetting("BaselineWeeklyActualFoodRevenue_Stipulated", int.Parse(siteID));
				if (baselineMonthlyActualFoodRevenue_Stipulated == "")
					baselineMonthlyActualFoodRevenue_Stipulated = "0";

				return baselineMonthlyActualFoodRevenue_Stipulated;
			}
			else
			{
				int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID)));
				DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(siteID));
				DateTime bedt = baselineStartDate.AddDays(nwks * 7);

				string sql = "SELECT SUM(FoodRevenueActual) AS revenue FROM Financials WHERE ((PeriodStartDate >= #"
				+ baselineStartDate.ToString("yyyy/MM/dd") + " 00:00:00#) AND (PeriodStartDate < #"
				+ bedt.ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID;
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count >= 0 && dt.Rows[0][0].ToString() != "")
				{
					decimal drevenue = 0;
					decimal.TryParse(dt.Rows[0][0].ToString(), out drevenue);
					return (drevenue / nwks).ToString();
				}
				else return "0";
			}
		}

		//**** BaselineMonthlyBudgetedFoodRevenue_Stipulated (currency format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineMonthlyBudgetedFoodRevenue_StipulatedConst = "";
		static private string _BaselineMonthlyBudgetedFoodRevenue_Stipulated;

		static public string BaselineMonthlyBudgetedFoodRevenue_Stipulated
		{
			get
			{
				if (_BaselineMonthlyBudgetedFoodRevenue_Stipulated == null)
				{
					_BaselineMonthlyBudgetedFoodRevenue_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyBudgetedFoodRevenue_Stipulated", CurrentSiteID);
					if (_BaselineMonthlyBudgetedFoodRevenue_Stipulated == "")
						_BaselineMonthlyBudgetedFoodRevenue_Stipulated = "0";
				}
				return _BaselineMonthlyBudgetedFoodRevenue_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyBudgetedFoodRevenue_Stipulated = null;
				else
					_BaselineMonthlyBudgetedFoodRevenue_Stipulated = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyBudgetedFoodRevenue_Stipulated", _BaselineMonthlyBudgetedFoodRevenue_Stipulated, "Number", CurrentSiteID);
			}
		}



		//**** BaselineMonthlyBudgetedMealCount_Stipulated (integer format, zero length string => no baseline)
		// Built-in default
		private const string _BaselineMonthlyBudgetedMealCount_StipulatedConst = "";
		static private string _BaselineMonthlyBudgetedMealCount_Stipulated;

		static public string BaselineMonthlyBudgetedMealCount_Stipulated
		{
			get
			{
				if (_BaselineMonthlyBudgetedMealCount_Stipulated == null)
				{
					_BaselineMonthlyBudgetedMealCount_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyBudgetedMealCount_Stipulated", CurrentSiteID);
					if (_BaselineMonthlyBudgetedMealCount_Stipulated == "")
						_BaselineMonthlyBudgetedMealCount_Stipulated = "0";
				}
				return _BaselineMonthlyBudgetedMealCount_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyBudgetedMealCount_Stipulated = null;
				else
					_BaselineMonthlyBudgetedMealCount_Stipulated = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyBudgetedMealCount_Stipulated", _BaselineMonthlyBudgetedMealCount_Stipulated, "Number", CurrentSiteID);
			}
		}

		//**** BaselineMonthlyActualMealCount_Stipulated (integer format, zero length string => no baseline)
		// Built-in default
		//private const string _BaselineMonthlyActualMealCount_StipulatedConst = "";
		static private string _BaselineMonthlyActualMealCount_Stipulated;

		static public string BaselineMonthlyActualMealCount_Stipulated
		{
			get
			{
				if (_BaselineMonthlyActualMealCount_Stipulated == null)
				{
					_BaselineMonthlyActualMealCount_Stipulated =
						Query.GetGlobalSetting("BaselineWeeklyActualMealCount_Stipulated", CurrentSiteID);
				}
				if (_BaselineMonthlyActualMealCount_Stipulated == "")
					_BaselineMonthlyActualMealCount_Stipulated = "0";
				return _BaselineMonthlyActualMealCount_Stipulated;
			}
			set
			{
				if (value == null) _BaselineMonthlyActualMealCount_Stipulated = null;
				else
					_BaselineMonthlyActualMealCount_Stipulated = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("BaselineWeeklyActualMealCount_Stipulated", _BaselineMonthlyActualMealCount_Stipulated, "Number", CurrentSiteID);
			}
		}

		static public string GetBaselineMonthlyActualMealCount(string siteID)
		{
			if (GetBaselineWasteMethod(siteID) == "Stipulated")
			{
				string baselineMonthlyActualMealCount_Stipulated =
					Query.GetGlobalSetting("BaselineWeeklyActualMealCount_Stipulated", int.Parse(siteID));
				if (baselineMonthlyActualMealCount_Stipulated == "")
					baselineMonthlyActualMealCount_Stipulated = "0";

				return baselineMonthlyActualMealCount_Stipulated;
			}
			else
			{
				int nwks = int.Parse(Query.GetGlobalSetting("BaselineNumberofWeeks", int.Parse(siteID)));
				DateTime baselineStartDate = DateTime.Parse(GetBaselineStartDate(siteID));
				DateTime bedt = baselineStartDate.AddDays(nwks * 7);

				string sql = "SELECT SUM(MealCountActual) AS mealcount FROM Financials WHERE ((PeriodStartDate >= #"
				+ baselineStartDate.ToString("yyyy/MM/dd") + " 00:00:00#) AND (PeriodStartDate < #"
				+ bedt.Date.ToString("yyyy/MM/dd") + " 00:00:00#)) AND SiteID = " + siteID;
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count >= 0 && dt.Rows[0][0].ToString() != "")
				{
					decimal dres = 0;
					decimal.TryParse(dt.Rows[0][0].ToString(), out dres);
					return (dres / nwks).ToString();
				}
				else return "0";
			}
		}
		///
		/// Reporting Settings
		/// 

		//**** FoodCostReportPoints
		// If true, then reporting is to be on points (percentage) basis
		// if false, then reporting is to be on CPM basis (cost per meal)
		// 
		// save per Site
		static private string _FoodCostReportPoints;

		static public bool FoodCostReportPoints
		{
			get
			{
				if (_FoodCostReportPoints == null)
				{
					_FoodCostReportPoints = Query.GetGlobalSetting("FoodCostReportPoints", CurrentSiteID);
				}
				bool result;
				bool.TryParse(_FoodCostReportPoints, out result);
				return result;
			}
			set
			{
				_FoodCostReportPoints = value.ToString().Trim();
				Query.SaveGlobalSetting("FoodCostReportPoints", _FoodCostReportPoints, "Number", CurrentSiteID);
			}
		}

		//**** CycleTime
		// Number of weeks in standard menu cycle (1-12)
		// 
		// save per Site
		//private const string _CycleTimeConst = "1";
		static private string _CycleTime;

		static public int CycleTime
		{
			get
			{
				if ((_CycleTime == null) || (_CycleTime == string.Empty))
				{
					_CycleTime = Query.GetGlobalSetting("CycleTime", CurrentSiteID);
					//if (_CycleTime == string.Empty) _CycleTime = _CycleTimeConst;
				}
				int result = int.Parse(_CycleTime);
				return result;
			}
			set
			{
				if ((value <= 0) || (value > 12)) { _CycleTime = Query._ConstSettings["CycleTime"].ToString(); }
				_CycleTime = value.ToString().Trim();
				Query.SaveGlobalSetting("CycleTime", _CycleTime, "Number", CurrentSiteID);
			}
		}

		//**** PreviousCycleStartDate

		public static DateTime PreviousCycleStartDate(DateTime cycleStartDate)
		{
			return cycleStartDate.AddDays(-CycleTime * 7);
		}

		//**** LogoUpperLeft
		// Built-in default
		// "" means use no logo
		// otherwise the string is relative path to the logo to use (use ".\Images")
		//private const string _LogoUpperLeftConst = "";
		static private string _LogoUpperLeft;

		static public string LogoUpperLeft
		{
			get
			{
				if (_LogoUpperLeft == null)
				{
					_LogoUpperLeft = Query.GetGlobalSetting("LogoUpperLeft", 0);
				}
				return _LogoUpperLeft;
			}
			set
			{
				if (value == null) _LogoUpperLeft = null;
				else
					_LogoUpperLeft = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("LogoUpperLeft", _LogoUpperLeft, "PathName", 0);
			}
		}

		//**** LogoUpperLeftStream
		//
		static private MemoryStream _LogoUpperLeftStream;

		static public MemoryStream LogoUpperLeftStream
		{
			get
			{
				if (_LogoUpperLeftStream == null || _LogoUpperLeft == null)
				{
					byte[] bt;
					if (Utilities.LoadFilefromDB("UpperLeftLogo.img", CurrentSiteID, out bt) > 0)
					{
						_LogoUpperLeftStream = new MemoryStream(bt, 0, bt.Length);
					}
				}
				return _LogoUpperLeftStream;
			}
		}

		//**** LogoLowerRight 
		// Built-in default
		// "" means use the embedded LeanPath logo
		// otherwise the string is relative path to the logo to use
		//private const string _LogoLowerRightConst = "";
		static private string _LogoLowerRight;

		static public string LogoLowerRight
		{
			get
			{
				if (_LogoLowerRight == null)
				{
					_LogoLowerRight = Query.GetGlobalSetting("LogoLowerRight", 0);
				}
				return _LogoLowerRight;
			}
			set
			{
				if (value == null) _LogoLowerRight = null;
				else
					_LogoLowerRight = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("LogoLowerRight", _LogoLowerRight, "PathName", 0);
			}
		}

		//**** LogoLowerRightStream
		//
		static private MemoryStream _LogoLowerRightStream;

		static public MemoryStream LogoLowerRightStream
		{
			get
			{
				if (_LogoLowerRightStream == null || _LogoLowerRight == null)
				{
					byte[] bt;
					if (Utilities.LoadFilefromDB("LowerRightLogo.img", CurrentSiteID, out bt) > 0)
					{
						_LogoLowerRightStream = new MemoryStream(bt, 0, bt.Length);
					}
				}
				return _LogoLowerRightStream;
			}
		}


		//**** Advanced filters on/off 
		// Built-in default
		//private const string _AdvancedFiltersOnConst = "true";
		static private string _AdvancedFiltersOn;

		static public string AdvancedFiltersOn
		{
			get
			{
				if (_AdvancedFiltersOn == null)
				{
					_AdvancedFiltersOn = Query.GetGlobalSetting("AdvancedFiltersOn", 0);
					//if (_AdvancedFiltersOn == "")
					//    _AdvancedFiltersOn = _AdvancedFiltersOnConst;
				}
				return _AdvancedFiltersOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_AdvancedFiltersOn = Query._ConstSettings["AdvancedFiltersOn"].ToString();
				}
				else
				{
					_AdvancedFiltersOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("AdvancedFiltersOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("AdvancedFiltersOn", "false", "Boolean", 0);
				}
			}
		}

		//**** Show Empty Reports on/off 
		// Built-in default
		//private const string _ShowEmptyReportsConst = "true";
		static private string _ShowEmptyReports;

		static public string ShowEmptyReports
		{
			get
			{
				if (_ShowEmptyReports == null)
				{
					_ShowEmptyReports = Query.GetGlobalSetting("ShowEmptyReports", 0);
					//if (_ShowEmptyReports == "")
					//    _ShowEmptyReports = _ShowEmptyReportsConst;
				}
				return _ShowEmptyReports;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_ShowEmptyReports = Query._ConstSettings["ShowEmptyReports"].ToString();
				}
				else
				{
					_ShowEmptyReports = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("ShowEmptyReports", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("ShowEmptyReports", "false", "Boolean", 0);
				}
			}
		}
		static private bool _EmptySubReportHappened = false;

		static public bool SubReportWasPrinted
		{
			get
			{
				return _EmptySubReportHappened;
			}
			set
			{
				_EmptySubReportHappened = value;
			}
		}

		//**** StartDateOfSelectedWeek 
		// Built-in default
		//private const string _StartDateOfSelectedWeekConst = "";
		static private string _StartDateOfSelectedWeek = null;

		static public string StartDateOfSelectedWeek
		{
			get
			{
				if (_StartDateOfSelectedWeek == null)
				{
					_StartDateOfSelectedWeek = Query.GetGlobalSetting("StartDateOfSelectedWeek", 0);

					// todo: if no setting, then find the first full week of data and
					//       set the start date to the first day of that week
					DateTime lastDayOfWeek;
					if (_StartDateOfSelectedWeek == null || _StartDateOfSelectedWeek == "")
					{ // No setting yet - find the first full week of data and
						//       set the start date to the first day of that week

						lastDayOfWeek = Query.GetNewestWeightDataDateTime();

						//DateTime lastDayOfWeek = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
						lastDayOfWeek.AddDays(1);
						if (_FirstDayOfWeek != null && _FirstDayOfWeek != "")
							for (int i = 0; i < 7; i++)
								if (lastDayOfWeek.DayOfWeek.ToString() != _FirstDayOfWeek)
									lastDayOfWeek = lastDayOfWeek.AddDays(-1);
								else
									break;
						_StartDateOfSelectedWeek = lastDayOfWeek.AddDays(-7).ToString("yyyy/MM/dd HH:mm:ss");
					}
					else
					{
						// Check that the FirstDayofWeek is still valid
						if (_FirstDayOfWeek != null && _FirstDayOfWeek != "")
						{ // FirstDayofWeek is still valid - make sure our date conforms to it 
							bool addweek = false;
							if (DateTime.Parse(_StartDateOfSelectedWeek).DayOfWeek.ToString() !=
								_FirstDayOfWeek)
							{ // Not the right day (Site must have changed)
								// Adjust backward until we have the right day
								DateTime firstDayOfWeek = DateTime.Parse(_StartDateOfSelectedWeek);
								for (int i = 0; i < 7; i++)
									if (firstDayOfWeek.DayOfWeek.ToString() != _FirstDayOfWeek)
									{
										firstDayOfWeek = firstDayOfWeek.AddDays(-1);
										if (firstDayOfWeek.DayOfWeek == DayOfWeek.Sunday) addweek = true;
									}
									else break;
								if (addweek)
								{ // Keep us in the same week
									firstDayOfWeek = firstDayOfWeek.AddDays(7);
								}
								_StartDateOfSelectedWeek = firstDayOfWeek.ToString("yyyy/MM/dd 00:00:00");
							}
						}
						else
						{
							_StartDateOfSelectedWeek = Regex.Replace(_StartDateOfSelectedWeek, @"(\d+):(\d+):(\d+)", "00:00:00");// always set to the beginning of the day
						}
					}
				}
				return _StartDateOfSelectedWeek;
			}
			set
			{
				// todo: validate value to set here
				try
				{
					if ((value == null) || (value == ""))
					{ // reset value to null (this will cause a Get to reinitialize)
						_StartDateOfSelectedWeek = null;
					}
					else
					{ // must be a valid value
						DateTime dt = DateTime.Parse(Regex.Replace(value, @"(\d+):(\d+):(\d+)", "00:00:00")); // always set to the beginning of the day
						while (dt.DayOfWeek.ToString() != FirstDayOfWeek)
						{
							dt = dt.AddDays(-1); // Back up to where the FirstDayOfWeek is correct}
						}
						_StartDateOfSelectedWeek = dt.ToString("yyyy/MM/dd HH:mm:ss");
						Query.SaveGlobalSetting("StartDateOfSelectedWeek", _StartDateOfSelectedWeek, "DateTime", 0);
						TrackerDetector.GetTrackerDetector().WeekStart = dt;
					}
				}
				catch
				{ }
			}
		}

		static public DateTime ForceDatetoPriorWeekStart(DateTime datetoadjust)
		{
			return ForceDatetoWeekStart(datetoadjust, true);
		}
		static public DateTime ForceDatetoNextWeekStart(DateTime datetoadjust)
		{
			return ForceDatetoWeekStart(datetoadjust, false);
		}
		/// <summary>
		/// Return a date that is normalized to have the right starting day of the week.  If the date is\
		/// already normalized, the same date passed in is passed back; if not, the date is stepped forward until
		/// the next day that matches the starting day of the week.  The time is also normalized to midnight.
		/// </summary>
		/// <param name="datetoadjust">Date to adjust.</param>
		/// <param name="forcetoprior">True => force to prior week start; false => force to next week start.</param>
		/// <returns>The new adjusted date.</returns>
		static public DateTime ForceDatetoWeekStart(DateTime datetoadjust, bool forcetoprior)
		{
			DateTime dt = DateTime.Parse(Regex.Replace(datetoadjust.ToShortDateString() + " " 
				+ datetoadjust.ToShortTimeString(), @"(\d+):(\d+):(\d+)", "00:00:00")); // always set to the beginning of the day
			int increment = forcetoprior ? -1 : 1;
			while (dt.DayOfWeek.ToString() != FirstDayOfWeek)
			{
				dt = dt.AddDays(increment); // Step forward to where the FirstDayOfWeek is correct}
			}
			return dt;
		}

		///
		/// Display Options Settings
		/// 

		//**** Footer Shortcuts on/off 
		// Built-in default
		//
		const string _FooterShortcutsOnConst = "true";
		static private string _FooterShortcutsOn;

		static public string FooterShortcutsOn
		{
			get
			{
				if (_FooterShortcutsOn == null)
				{
					_FooterShortcutsOn = Query.GetGlobalSetting("FooterShortcutsOn", 0);
					if (_FooterShortcutsOn == "")
						_FooterShortcutsOn = _FooterShortcutsOnConst;
				}
				return _FooterShortcutsOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_FooterShortcutsOn = Query.GetGlobalSetting("FooterShortcutsOn", 0).ToString();
					if (!((_FooterShortcutsOn.ToLower() == "true") || (_FooterShortcutsOn.ToLower() == "false")))
						Query.SaveGlobalSetting("FooterShortcutsOn", "false", "Boolean", 0);
				}
				else
				{
					_FooterShortcutsOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("FooterShortcutsOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("FooterShortcutsOn", "false", "Boolean", 0);
				}
			}
		}

		//**** Footer Settings on/off 
		// Built-in default
		//
		const string _FooterSettingsOnConst = "true";
		static private string _FooterSettingsOn;

		static public string FooterSettingsOn
		{
			get
			{
				if (_FooterSettingsOn == null)
				{
					_FooterSettingsOn = Query.GetGlobalSetting("FooterSettingsOn", 0);
					if (_FooterSettingsOn == "")
						_FooterSettingsOn = _FooterSettingsOnConst;
				}
				return _FooterSettingsOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_FooterSettingsOn = Query.GetGlobalSetting("FooterSettingsOn", 0).ToString();
					if (!((_FooterSettingsOn.ToLower() == "true") || (_FooterSettingsOn.ToLower() == "false")))
						Query.SaveGlobalSetting("FooterSettingsOn", "false", "Boolean", 0);
				}
				else
				{
					_FooterSettingsOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("FooterSettingsOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("FooterSettingsOn", "false", "Boolean", 0);
				}
			}
		}
		//**** Footer Database and Login Info on/off 
		// Built-in default
		//
		const string _FooterDatabaseandLoginInfoOnConst = "true";
		static private string _FooterDatabaseandLoginInfoOn;

		static public string FooterDatabaseandLoginInfoOn
		{
			get
			{
				if (_FooterDatabaseandLoginInfoOn == null)
				{
					_FooterDatabaseandLoginInfoOn = Query.GetGlobalSetting("FooterDatabaseandLoginInfoOn", 0);
					if (_FooterDatabaseandLoginInfoOn == "")
						_FooterDatabaseandLoginInfoOn = _FooterDatabaseandLoginInfoOnConst;
				}
				return _FooterDatabaseandLoginInfoOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_FooterDatabaseandLoginInfoOn = Query.GetGlobalSetting("FooterDatabaseandLoginInfoOn", 0).ToString();
					if (!((_FooterDatabaseandLoginInfoOn.ToLower() == "true") || (_FooterDatabaseandLoginInfoOn.ToLower() == "false")))
						Query.SaveGlobalSetting("FooterDatabaseandLoginInfoOn", "false", "Boolean", 0);
				}
				else
				{
					_FooterDatabaseandLoginInfoOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("FooterDatabaseandLoginInfoOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("FooterDatabaseandLoginInfoOn", "false", "Boolean", 0);
				}
			}
		}

		//**** Dashboard Food Cost Chart on/off 
		// Built-in default
		//
		const string _DashboardFoodCostChartOnConst = "false";
		static private string _DashboardFoodCostChartOn;

		static public string DashboardFoodCostChartOn
		{
			get
			{
				if (_DashboardFoodCostChartOn == null)
				{
					_DashboardFoodCostChartOn = Query.GetGlobalSetting("DashboardFoodCostChartOn", 0);
					if (_DashboardFoodCostChartOn == "")
						_DashboardFoodCostChartOn = _DashboardFoodCostChartOnConst;
				}
				return _DashboardFoodCostChartOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_DashboardFoodCostChartOn = Query.GetGlobalSetting("DashboardFoodCostChartOn", 0).ToString();
					if (!((_DashboardFoodCostChartOn.ToLower() == "true") || (_DashboardFoodCostChartOn.ToLower() == "false")))
						Query.SaveGlobalSetting("DashboardFoodCostChartOn", "false", "Boolean", 0);
				}
				else
				{
					_DashboardFoodCostChartOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("DashboardFoodCostChartOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("DashboardFoodCostChartOn", "false", "Boolean", 0);
				}
			}
		}

		//**** Dashboard Participation Summary on/off 
		// Built-in default
		//
		const string _DashboardParticipationSummaryOnConst = "true";
		static private string _DashboardParticipationSummaryOn;

		static public string DashboardParticipationSummaryOn
		{
			get
			{
				if (_DashboardParticipationSummaryOn == null)
				{
					_DashboardParticipationSummaryOn = Query.GetGlobalSetting("DashboardParticipationSummaryOn", 0);
					if (_DashboardParticipationSummaryOn == "")
						_DashboardParticipationSummaryOn = _DashboardParticipationSummaryOnConst;
				}
				return _DashboardParticipationSummaryOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_DashboardParticipationSummaryOn = Query.GetGlobalSetting("DashboardParticipationSummaryOn", 0).ToString();
					if (!((_DashboardParticipationSummaryOn.ToLower() == "true") || (_DashboardParticipationSummaryOn.ToLower() == "false")))
						Query.SaveGlobalSetting("DashboardParticipationSummaryOn", "false", "Boolean", 0);
				}
				else
				{
					_DashboardParticipationSummaryOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("DashboardParticipationSummaryOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("DashboardParticipationSummaryOn", "false", "Boolean", 0);
				}
			}
		}

		//**** 
		//**** Dashboard Waste Summary on/off 
		// Built-in default
		//
		const string _DashboardWasteSummaryOnConst = "true";
		static private string _DashboardWasteSummaryOn;

		static public string DashboardWasteSummaryOn
		{
			get
			{
				if (_DashboardWasteSummaryOn == null)
				{
					_DashboardWasteSummaryOn = Query.GetGlobalSetting("DashboardWasteSummaryOn", 0);
					if (_DashboardWasteSummaryOn == "")
						_DashboardWasteSummaryOn = _DashboardWasteSummaryOnConst;
				}
				return _DashboardWasteSummaryOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_DashboardWasteSummaryOn = Query.GetGlobalSetting("DashboardWasteSummaryOn", 0).ToString();
					if (!((_DashboardWasteSummaryOn.ToLower() == "true") || (_DashboardWasteSummaryOn.ToLower() == "false")))
						Query.SaveGlobalSetting("DashboardWasteSummaryOn", "false", "Boolean", 0);
				}
				else
				{
					_DashboardWasteSummaryOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("DashboardWasteSummaryOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("DashboardWasteSummaryOn", "false", "Boolean", 0);
				}
			}
		}

		//**** Dashboard Waste Equivalency on/off 
		// Built-in default
		//
		const string _DashboardWasteEquivalencyOnConst = "true";
		static private string _DashboardWasteEquivalencyOn;

		static public string DashboardWasteEquivalencyOn
		{
			get
			{
				if (_DashboardWasteEquivalencyOn == null)
				{
					_DashboardWasteEquivalencyOn = Query.GetGlobalSetting("DashboardWasteEquivalencyOn", 0);
					if (_DashboardWasteEquivalencyOn == "")
						_DashboardWasteEquivalencyOn = _DashboardWasteEquivalencyOnConst;
				}
				return _DashboardWasteEquivalencyOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_DashboardWasteEquivalencyOn = Query.GetGlobalSetting("DashboardWasteEquivalencyOn", 0).ToString();
					if (!((_DashboardWasteEquivalencyOn.ToLower() == "true") || (_DashboardWasteEquivalencyOn.ToLower() == "false")))
						Query.SaveGlobalSetting("DashboardWasteEquivalencyOn", "false", "Boolean", 0);
				}
				else
				{
					_DashboardWasteEquivalencyOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("DashboardWasteEquivalencyOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("DashboardWasteEquivalencyOn", "false", "Boolean", 0);
				}
			}
		}

		//**** DashboardWasteEquivalencyObject
		//
		// Built-in default
		private const string _DashboardWasteEquivalencyObjectConst = "Elephants";
		static private string _DashboardWasteEquivalencyObject;

		static public string DashboardWasteEquivalencyObjectName
		{
			get
			{
				if (_DashboardWasteEquivalencyObject == null)
				{
					_DashboardWasteEquivalencyObject = Query.GetGlobalSetting("DashboardWasteEquivalencyObject", 0);
					if (_DashboardWasteEquivalencyObject == "")
						_DashboardWasteEquivalencyObject = _DashboardWasteEquivalencyObjectConst;
				}
				return _DashboardWasteEquivalencyObject;
			}
			set
			{
				_DashboardWasteEquivalencyObject = value;
				if (value != null)
					Query.SaveGlobalSetting("DashboardWasteEquivalencyObject", value, "String", 0);
			}
		}

		//**** DashboardWasteEquivalencyUnits
		//
		// Built-in default
		private const string _DashboardWasteEquivalencyUnitsConst = "Pounds";
		static private string _DashboardWasteEquivalencyUnits;

		static public string DashboardWasteEquivalencyUnits
		{
			get
			{
				if (_DashboardWasteEquivalencyUnits == null)
				{
					_DashboardWasteEquivalencyUnits = Query.GetGlobalSetting("DashboardWasteEquivalencyUnits", 0);
					if (_DashboardWasteEquivalencyUnits == "")
						_DashboardWasteEquivalencyUnits = _DashboardWasteEquivalencyUnitsConst;
				}
				return _DashboardWasteEquivalencyUnits;
			}
			set
			{
				_DashboardWasteEquivalencyUnits = value;
				if (value != null)
					Query.SaveGlobalSetting("DashboardWasteEquivalencyUnits", value, "String", 0);
			}
		}

		//**** Waste Equivalency Dollars (currency format, zero length string => no setting)
		// Built-in default
		private const string _DashboardWasteEquivalencyDollarsConst = "10000";
		static private string _DashboardWasteEquivalencyDollars;

		static public string DashboardWasteEquivalencyDollars
		{
			get
			{
				if ((_DashboardWasteEquivalencyDollars == null) ||
					(_DashboardWasteEquivalencyDollars == ""))
				{
					_DashboardWasteEquivalencyDollars =
						Query.GetGlobalSetting("DashboardWasteEquivalencyDollars", 0);
					if (_DashboardWasteEquivalencyDollars == "")
						_DashboardWasteEquivalencyDollars = _DashboardWasteEquivalencyDollarsConst;
				}
				return _DashboardWasteEquivalencyDollars;
			}
			set
			{
				if (value == null) _DashboardWasteEquivalencyDollars = null;
				else
					_DashboardWasteEquivalencyDollars = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("DashboardWasteEquivalencyDollars", _DashboardWasteEquivalencyDollars, "Number", 0);
			}
		}

		//**** Waste Equivalency Pounds (currency format, zero length string => no setting)
		// Built-in default
		private const string _DashboardWasteEquivalencyPoundsConst = "10000";
		static private string _DashboardWasteEquivalencyPounds;

		static public string DashboardWasteEquivalencyPounds
		{
			get
			{
				if (_DashboardWasteEquivalencyPounds == null)
				{
					_DashboardWasteEquivalencyPounds =
						Query.GetGlobalSetting("DashboardWasteEquivalencyPounds", 0);
					if (_DashboardWasteEquivalencyPounds == "")
						_DashboardWasteEquivalencyPounds = _DashboardWasteEquivalencyPoundsConst;
				}
				return _DashboardWasteEquivalencyPounds;
			}
			set
			{
				if (value == null) _DashboardWasteEquivalencyPounds = null;
				else
					_DashboardWasteEquivalencyPounds = value.Replace("$", "").Trim();
				if (value != null)
					Query.SaveGlobalSetting("DashboardWasteEquivalencyPounds", _DashboardWasteEquivalencyPounds, "Number", 0);
			}
		}


		///
		/// Preferences Settings
		/// 


		//**** Hide Disabled Tasks in Task Bar Setup - Setting
		// Built-in default
		private const string _HideDisabledTasksConst = "1";
		static private string _HideDisabledTasks;

		static public string HideDisabledTasks
		{
			get
			{
				if ((_HideDisabledTasks == null) || (_HideDisabledTasks == ""))
				{
					_HideDisabledTasks =
						Query.GetGlobalSetting("HideDisabledTasks", 0);
					if (_HideDisabledTasks == "")
						_HideDisabledTasks = _HideDisabledTasksConst;
				}
				return _HideDisabledTasks;
			}
			set
			{
				if (value == null) _HideDisabledTasks = null;
				else
					_HideDisabledTasks = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("HideDisabledTasks", _HideDisabledTasks, "Number", 0);
			}
		}


		//**** ActiveSyncTrackerTransfers on/off 
		// Built-in default
		//
		static private string _ActiveSyncTrackerTransfersOn;

		static public string ActiveSyncTrackerTransfersOn
		{
			get
			{
				if (_ActiveSyncTrackerTransfersOn == null)
				{
					_ActiveSyncTrackerTransfersOn = Query.GetGlobalSetting("ActiveSyncTrackerTransfersOn", 0);
				}
				return _ActiveSyncTrackerTransfersOn;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_ActiveSyncTrackerTransfersOn = Query.GetGlobalSetting("ActiveSyncTrackerTransfersOn", 0).ToString();
					if (!((_ActiveSyncTrackerTransfersOn.ToLower() == "true") || (_ActiveSyncTrackerTransfersOn.ToLower() == "false")))
						Query.SaveGlobalSetting("ActiveSyncTrackerTransfersOn", "false", "Boolean", 0);
				}
				else
				{
					_ActiveSyncTrackerTransfersOn = value;
					if (value.ToLower() == "true")
						Query.SaveGlobalSetting("ActiveSyncTrackerTransfersOn", "true", "Boolean", 0);
					else
						Query.SaveGlobalSetting("ActiveSyncTrackerTransfersOn", "false", "Boolean", 0);
				}
			}
		}

		//**** ActiveSyncTrackerTransferFolder 
		// Built-in default
		//
		static private string _ActiveSyncTrackerTransferFolder;

		static public string ActiveSyncTrackerTransferFolder
		{
			get
			{
				if (_ActiveSyncTrackerTransferFolder == null)
				{
					_ActiveSyncTrackerTransferFolder = Query.GetGlobalSetting("ActiveSyncTrackerTransferFolder", 0);
				}
				if (_ActiveSyncTrackerTransferFolder == "")
				{
					_ActiveSyncTrackerTransferFolder = Query._ConstSettings["ActiveSyncTrackerTransferFolder"].ToString();
					Query.SaveGlobalSetting("ActiveSyncTrackerTransferFolder", _ActiveSyncTrackerTransferFolder, "String", 0);
				}
				return _ActiveSyncTrackerTransferFolder;
			}
			set
			{
				if ((value == null) || (value == ""))
				{
					_ActiveSyncTrackerTransferFolder = Query.GetGlobalSetting("ActiveSyncTrackerTransferFolder", 0).ToString();
				}
				else
				{
					_ActiveSyncTrackerTransferFolder = value;
					Query.SaveGlobalSetting("ActiveSyncTrackerTransferFolder", _ActiveSyncTrackerTransferFolder, "String", 0);
				}
			}
		}

		///
		/// Licensing Settings
		/// 

		//**** 
		// Built-in default
		private static string _LastLicenseCheckDate;
		static public string LastLicenseCheckDate
		{
			get
			{
				if (_LastLicenseCheckDate == null)
				{
					_LastLicenseCheckDate = Query.GetGlobalSetting("LastLicenseCheckDate", 0);
				}
				return _LastLicenseCheckDate;
			}
			set
			{
				if (value == null) _LastLicenseCheckDate = new DateTime(0).ToString("yyyy/MM/dd HH:mm:ss");
				else
					_LastLicenseCheckDate = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("LastLicenseCheckDate", _LastLicenseCheckDate, "DateTime", 0);
			}
		}

		//**** Current License Waste Class Level, in GlobalVars of Database
		// Built-in default
		private const string _WasteClassLevelofCurrentDBConst = "0"; // Default to Food_General
		static private string _WasteClassLevelofCurrentDB;

		static public string WasteClassLevelofCurrentDB
		{
			get
			{
				if ((_WasteClassLevelofCurrentDB == null) || (_WasteClassLevelofCurrentDB == ""))
				{
					//_WasteClassLevelofCurrentDB = UserControls.SecurityManager.GetSecurityManager()["Waste Class Level"]; // todo: load from license
					if (_WasteClassLevelofCurrentDB == "")
						_WasteClassLevelofCurrentDB = _WasteClassLevelofCurrentDBConst;
				}
				return _WasteClassLevelofCurrentDB;
			}
			set
			{
				if (value == null) _WasteClassLevelofCurrentDB = null;
				else
					_WasteClassLevelofCurrentDB = value.Trim();
				if (value != null)
					Query.SaveGlobalSetting("WasteClassLevelofCurrentDB", _WasteClassLevelofCurrentDB, "Number", 0);
			}
		}

		static public void WasteClassLevelofCurrentDB_Reset()
		{
			_WasteClassLevelofCurrentDB = _WasteClassLevelofCurrentDBConst;
		}

		///
		/// Weight Import Threshold
		/// 
		private const string _WeightImportThresholdConst = "0.00";
		private static string _WeightImportThreshold;
		static public string WeightImportThreshold
		{
			get
			{
				if (_WeightImportThreshold == null)
				{
					_WeightImportThreshold = Query.GetGlobalSetting("WeightImportThreshold", CurrentSiteID);
				}
				if (_WeightImportThreshold == "")
					_WeightImportThreshold = _WeightImportThresholdConst;
				return _WeightImportThreshold;
			}
			set
			{
				if (value == null) _WeightImportThreshold = _WeightImportThresholdConst;
				else
					_WeightImportThreshold = value;
				if (value != null)
					Query.SaveGlobalSetting("WeightImportThreshold", _WeightImportThreshold, "Number", CurrentSiteID);
			}
		}

		///
		/// Cost Import Threshold
		/// 
		private const string _CostImportThresholdConst = "0.00";
		private static string _CostImportThreshold;
		static public string CostImportThreshold
		{
			get
			{
				if (_CostImportThreshold == null)
				{
					_CostImportThreshold = Query.GetGlobalSetting("CostImportThreshold", CurrentSiteID);
				}
				if (_CostImportThreshold == "")
					_CostImportThreshold = _CostImportThresholdConst;
				return _CostImportThreshold;
			}
			set
			{
				if (value == null) _CostImportThreshold = _CostImportThresholdConst;
				else
					_CostImportThreshold = value;
				if (value != null)
					Query.SaveGlobalSetting("CostImportThreshold", _CostImportThreshold, "Number", CurrentSiteID);
			}
		}


		//**** ReportsToPrint
		// Name of Report Serie to show on "Print Weekly" screen
		const string _ReportsToPrintConst = "Weekly Printed Reports"; //default name of Print Weekly Serie
		static private string _ReportsToPrint;

		static public string ReportsToPrint
		{
			get
			{
				if (_ReportsToPrint == null)
				{
					_ReportsToPrint = Query.GetGlobalSetting("ReportsToPrint", CurrentSiteID);
				}
				if (_ReportsToPrint == "")
					_ReportsToPrint = _ReportsToPrintConst;
				return _ReportsToPrint;
			}
			set
			{
				if (_ReportsToPrint != value)
				{
					_ReportsToPrint = value;
					if (value != null)
					{
						_ReportsToPrint = _ReportsToPrint.Trim();
						Query.SaveGlobalSetting("ReportsToPrint", _ReportsToPrint, "String", CurrentSiteID);
					}
				}
			}
		}

		//**** ReportsToView
		// Name of Report Serie to show on "Review Reports" screen
		const string _ReportsToViewConst = "Weekly Review Reports"; //default name of Print Weekly Serie
		static private string _ReportsToView;

		static public string ReportsToView
		{
			get
			{
				if (_ReportsToView == null)
				{
					_ReportsToView = Query.GetGlobalSetting("ReportsToView", CurrentSiteID);
				}
				if (_ReportsToView == "")
					_ReportsToView = _ReportsToViewConst;
				return _ReportsToView;
			}
			set
			{
				if (_ReportsToView != value)
				{
					_ReportsToView = value;
					if (value != null)
					{
						_ReportsToView = _ReportsToView.Trim();
						Query.SaveGlobalSetting("ReportsToView", _ReportsToView, "String", CurrentSiteID);
					}
				}
			}
		}

		//***** Future Reach for Importing Data
		// This is the maximum number of days in the future to tolerate importation of data
		//
		private static double _DaysinFuturetoAllowImporting = 7d;
		public static double DaysinFuturetoAllowImporting
		{
			get
			{
				return _DaysinFuturetoAllowImporting;
			}
			set
			{
				_DaysinFuturetoAllowImporting = value;
			}
		}
	}
}
