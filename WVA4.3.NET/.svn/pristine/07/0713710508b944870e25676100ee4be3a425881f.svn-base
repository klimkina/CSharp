using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace LMan4
{
	public partial class SetTestModeLicenseValues : Form
	{
		public SetTestModeLicenseValues(bool allowedit)
		{
			InitializeComponent();
			loadLicenseValues();
			if (!allowedit)
				SetEditMode(allowedit);
		}
		public SetTestModeLicenseValues()
		{
			InitializeComponent();
			loadLicenseValues();
		}

        private void loadLicenseValues()
        {
            dtExpirationDate.Value = DateTime.Parse(VWA4Common.Security.LicenseManager.GetValue("ExpirationDate"));
            dtExpirationWarningsBegin.Value = DateTime.Parse(VWA4Common.Security.LicenseManager.GetValue("ExpirationWarningsBeginDate"));
            switch ((VWA4Common.Security.Types.ExpirationWarningType)Enum.Parse(typeof(VWA4Common.Security.Types.ExpirationWarningType), VWA4Common.Security.LicenseManager.GetValue("ExpirationWarningsMode"), true))
            {
                case VWA4Common.Security.Types.ExpirationWarningType.OnProgramStart:
                    {
                        cbExpirationWarningsMode.SelectedIndex = 0;
                        break;
                    }
                case VWA4Common.Security.Types.ExpirationWarningType.OnProgramExit:
                    {
                        cbExpirationWarningsMode.SelectedIndex = 1;
                        break;
                    }
                case VWA4Common.Security.Types.ExpirationWarningType.OnProgramStartAndExit:
                    {
                        cbExpirationWarningsMode.SelectedIndex = 2;
                        break;
                    }
                case VWA4Common.Security.Types.ExpirationWarningType.DuringOperation:
                    {
                        cbExpirationWarningsMode.SelectedIndex = 3;
                        break;
                    }
            }

            lExpirationFrequency.Text = VWA4Common.Security.LicenseManager.GetValue("ExpirationWarningsFrequency");

            tbMaxNumberofSites.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofSites");
            tbMaxNumberofFoodTypes.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofFoodTypes");
            tbMaxNumberofLossTypes.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofLossTypes");
            tbMaxNumberofUserTypes.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofUserTypes");
            tbMaxNumberofDETs.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofDETs");
            tbMaxNumberofReports.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofReports");
            tbMaxNumberofTrackers.Text = VWA4Common.Security.LicenseManager.GetValue("MaxNumberofTrackers");

            // Switches
            /// Configurator Switches (alphabetical order!!!!)
            cAddUsersAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("AddUsersAvailable"));
            cAddNewCollectionAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("AddNewCollectionAvailable"));
            cAddNewReportAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("AddNewReportAvailable"));
            cAdvancedMenuAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("AdvancedMenuAvailable"));
            cAMWTAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("AMWTAvailable"));
            cCloneReportAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("CloneReportAvailable"));
            cConfiguratorAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfiguratorAvailable"));
            cbConfigureDaypartEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfigureDaypartEntryAvailable"));
            cbConfigureDispositionEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfigureDispositionEntryAvailable"));
            cbConfigurePrePostEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfigurePrePostEntryAvailable"));
            cbConfigureStationEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfigureStationEntryAvailable"));
            cDaypartEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("DaypartEntryAvailable"));
            cDispositionEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("DispositionEntryAvailable"));
            cEnterFinancialsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("EnterFinancialsAvailable"));
            cEnterSWATNotesAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("EnterSWATNotesAvailable"));
            cFoodCostAdjustmentsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("FoodCostAdjustmentsAvailable"));
            cImportWasteDataAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ImportWasteDataAvailable"));
            cManageBaselinesAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageBaselinesAvailable"));
            cManageDETsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageDETsAvailable"));
            cManageEventClientsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageEventClientsAvailable"));
            cManageEventOrdersAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageEventOrdersAvailable"));
            cManagePreferencesAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManagePreferencesAvailable"));
            cManagePrintFormsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ConfigureStationEntryAvailable"));
            cManageReportsSettingsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageReportsAvailable"));
            cManageSitesAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageSitesAvailable"));
            cManageTrackersAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageTrackersAvailable"));
            cManageTypesAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("ManageTypesAvailable"));
            // (Max limits loaded above)
            cPrePostEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("PrePostEntryAvailable"));
            cRecurringTransactionsAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("RecurringTransactionsAvailable"));
            cRemoveUsersAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("RemoveUsersAvailable"));
            cStationEntryAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("StationEntryAvailable"));
            cUpdateTrackerAvailable.Checked = bool.Parse(VWA4Common.Security.LicenseManager.GetValue("UpdateTrackerAvailable"));
        }

		private void SetEditMode(bool allowedit)
		{
			tbMaxNumberofSites.Enabled = allowedit;
			tbMaxNumberofFoodTypes.Enabled = allowedit;
			tbMaxNumberofLossTypes.Enabled = allowedit;
			tbMaxNumberofUserTypes.Enabled = allowedit;
			tbMaxNumberofDETs.Enabled = allowedit;
			tbMaxNumberofReports.Enabled = allowedit;
			tbMaxNumberofTrackers.Enabled = allowedit;

			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			cAddUsersAvailable.Enabled = allowedit;
			cAddNewCollectionAvailable.Enabled = allowedit;
			cAddNewReportAvailable.Enabled = allowedit;
			cAdvancedMenuAvailable.Enabled = allowedit;
			cAMWTAvailable.Enabled = allowedit;
			cCloneReportAvailable.Enabled = allowedit;
			cConfiguratorAvailable.Enabled = allowedit;
			cbConfigureDaypartEntryAvailable.Enabled = allowedit;
			cbConfigureDispositionEntryAvailable.Enabled = allowedit;
			cbConfigurePrePostEntryAvailable.Enabled = allowedit;
			cbConfigureStationEntryAvailable.Enabled = allowedit;
			cDaypartEntryAvailable.Enabled = allowedit;
			cDispositionEntryAvailable.Enabled = allowedit;
			cEnterFinancialsAvailable.Enabled = allowedit;
			cEnterSWATNotesAvailable.Enabled = allowedit;
			cFoodCostAdjustmentsAvailable.Enabled = allowedit;
			cImportWasteDataAvailable.Enabled = allowedit;
			cManageBaselinesAvailable.Enabled = allowedit;
			cManageDETsAvailable.Enabled = allowedit;
			cManageEventClientsAvailable.Enabled = allowedit;
			cManageEventOrdersAvailable.Enabled = allowedit;
			cManagePreferencesAvailable.Enabled = allowedit;
			cManagePrintFormsAvailable.Enabled = allowedit;
			cManageReportsSettingsAvailable.Enabled = allowedit;
			cManageSitesAvailable.Enabled = allowedit;
			cManageTrackersAvailable.Enabled = allowedit;
			cManageTypesAvailable.Enabled = allowedit;
			// (Max limits loaded above)
			cPrePostEntryAvailable.Enabled = allowedit;
			cRecurringTransactionsAvailable.Enabled = allowedit;
			cRemoveUsersAvailable.Enabled = allowedit;
			cStationEntryAvailable.Enabled = allowedit;
			cUpdateTrackerAvailable.Enabled = allowedit;
		}

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
