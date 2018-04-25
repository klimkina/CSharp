using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using LMan4.com.licensemanager4web;
using System.Globalization;
using System.Threading;

namespace LMan4
{
    public static class LicenseUtility
    {
        public static bool TestMode { get; set; }

        public static string WebServiceUrl
        {
            get
            {
                return TestMode ? ConfigurationManager.AppSettings["LicenseManagerWebServiceUrl_Test"] : ConfigurationManager.AppSettings["LicenseManagerWebServiceUrl_Prod"];
            }
        }

        public static LicenseManagerWebService GetWebService()
        {
            return new LicenseManagerWebService { Url = WebServiceUrl, Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1") };
        }

        static LicenseUtility()
        {

        }

        private static bool saveLicenseFile(LicenseFeaturesParams p, Activation a)
        {
            //globalization
            CultureInfo en = new CultureInfo("en-US"), orig = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = en;

            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ActivationCode"] = "";
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AddNewCollectionAvailable"] = p.AddNewCollection.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AddNewReportAvailable"] = p.AddNewReport.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AddUsersAvailable"] = p.AddUsers.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AdministratorPassword"] = p.AdministratorPassword;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AdvancedMenuAvailable"] = p.AdvancedMenuAvailable.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["AMWTAvailable"] = p.EnterLogSheetData.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["CloneReportAvailable"] = p.Clone.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ConfiguratorAvailable"] = p.UseConfigurator.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ConfigureDaypartEntryAvailable"] = p.ConfigureDaypartEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ConfigureDispositionEntryAvailable"] = p.ConfigureDispositionEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ConfigurePrePostEntryAvailable"] = p.ConfigurePrePostEntry.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ConfigureStationEntryAvailable"] = p.ConfigureStationEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["CPU_ID"] = "";
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["DaypartEntryAvailable"] = p.DaypartEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["DefaultUserLevel"] = p.DefaultUserLevel.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["DispositionEntryAvailable"] = p.DispositionEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["EnterFinancialsAvailable"] = p.EnterFinancialsAvailable.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["EnterSWATNotesAvailable"] = p.EnterSWATNotesAvailable.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationDate"] = p.ExpirationDate.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationWarningsBeginDate"] = p.ExpirationWarningStartDate.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationWarningsMode"] = p.ExpirationWarningsMode.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationWarningsFrequency"] = p.ExpirationWarningsFrequency.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationWarningsUnit"] = p.ExpirationWarningsUnit;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["FoodCostAdjustmentsAvailable"] = p.FoodCostAdjustments.ToString();            
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["FoodWasteClassAllowed"] = p.AllowedWasteClassses.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ImportWasteDataAvailable"] = p.ImportWasteData.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["LicenseType"] = p.LicenseType.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageBaselinesAvailable"] = p.ManageBaselines.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageDETsAvailable"] = p.ManageDataEntryTemplates.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageEventClientsAvailable"] = p.ManageEventClients.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageEventOrdersAvailable"] = p.ManageEventOrders.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageLogFormsAvailable"] = p.ManageLogForms.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManagePreferencesAvailable"] = p.ManagePreferences.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageReportsAvailable"] = p.ManageReportsSettingsShortcut.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageSitesAvailable"] = p.ManageSites.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageTrackersAvailable"] = p.ManageTrackers.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManagerPassword"] = p.ManagerPassword;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ManageTypesAvailable"] = p.ManageTypesAvailable.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofFoodTypes"] = p.FoodTypeLimit.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofLossTypes"] = p.LossTypeLimit.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofSites"] = p.NumberOfSites.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofTrackers"] = p.TrackerLimit.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofUserTypes"] = p.UserTypeLimit.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofDETs"] = p.DetLimits.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["MaxNumberofReports"] = p.ReportLimits.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["PrePostEntryAvailable"] = p.PrePostEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ProductType"] = p.Product.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["RecurringTransactionsAvailable"] = p.RecurringTransactionsAvailable.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["RemoveUsersAvailable"] = p.RemoveUsers.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ShowSupportEmailAddress"] = p.ShowSupportEmailAddress.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ShowSupportPhoneNumber"] = p.ShowSupportPhoneNumber.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ShowSupportWebsite"] = p.ShowSupportWebSiteURL.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["StationEntryAvailable"] = p.StationEntry.ToString();
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SupportEmailAddress"] = p.SupportEmailAddress;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SupportPhoneNumber"] = p.SupportPhoneNumber;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["UpdateTrackerAvailable"] = p.UpdateTracker.ToString();
			///**************
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ClientID"] = p.ClientID.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ClientName"] = p.ClientName;
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["Generatedby"] = p.GeneratedBy;
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["GeneratedDate"] = p.GeneratedDate.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["IsActivated"] = "False";
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["LicenseID"] = p.LicenseKey;
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["LicenseRecordID"] = p.LicenseID.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ProductVersionName"] = p.ProductVersionName;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SiteID"] = p.SiteID.ToString();
            VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SiteName"] = p.SiteName;
			VWA4Common.Security.LicenseUtility.GetLicenseUtility()["SupportWebsite"] = p.SupportWebSiteURL;
			//VWA4Common.Security.LicenseUtility.GetLicenseUtility()["Create/Save New Reports"] = p.AddNewReport.ToString();

            if (a != null)
            {
                VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ActivationCode"] = a.ActivationCode;
                VWA4Common.Security.LicenseUtility.GetLicenseUtility()["IsActivated"] = a.IsActivated.ToString();
				VWA4Common.Security.LicenseUtility.GetLicenseUtility()["CPU_ID"] = a.CPUID.ToString();
                VWA4Common.Security.LicenseUtility.GetLicenseUtility()["ExpirationDate"] = p.ExtendedExpirationDate.ToString();
            }
            //globalization
            Thread.CurrentThread.CurrentCulture = orig;

            SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "License files (*.txt)|*.TXT|All files (*.*)|*.*";
            dlg.FileName = "vw4license.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                VWA4Common.Security.LicenseUtility.GetLicenseUtility().GenerateLicense(dlg.FileName);
                return true;
            }
            return false;
        }

        public static bool GenerateLicense(LicenseFeaturesParams p)
        {
            return LicenseUtility.saveLicenseFile(p, null);
        }

        public static bool GenerateLicense(LicenseFeaturesParams p, Activation a)
        {
            return LicenseUtility.saveLicenseFile(p, a);
        }

        public static DateTime CalculateWarningsBeginDate(DateTime originalExpirationDate, DateTime originalWarningsStartDate, DateTime newExpirationDate)
        {
            return newExpirationDate.Subtract(originalExpirationDate.Subtract(originalWarningsStartDate));
        }
    }
}
