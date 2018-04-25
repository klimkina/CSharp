using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace VWA4Common
{
	public partial class SetTestModeLicenseValues : Form
	{
		public SetTestModeLicenseValues()
		{
			InitializeComponent();
			loadLicenseValues();
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			SaveTestModeLicenseSettingstoGlobals();
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}



		private void SaveTestModeLicenseSettingstoGlobals()
		{
			int result = 0;
			//
			bool error = false;
			if (int.TryParse(tbMaxNumberofDETs.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofDETs = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofSites.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofSites = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofFoodTypes.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofFoodTypes = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofLossTypes.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofLossTypes = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofReports.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofReports = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofTrackers.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofTrackers = result;
			else error = true;
			if (int.TryParse(tbMaxNumberofUserTypes.Text, out result))
				VWA4Common.GlobalSettings.MaxNumberofUserTypes = result;
			else error = true;
			//
			if (error)
			{
				MessageBox.Show("Invalid Numeric Value Format Entered! \n (All valid values were saved)");
			}

			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			VWA4Common.GlobalSettings.AddUsersAvailable = cAddUsersAvailable.Checked;
			VWA4Common.GlobalSettings.AMWTAvailable = cAMWTAvailable.Checked;
			VWA4Common.GlobalSettings.ConfiguratorAvailable = cConfiguratorAvailable.Checked;
			VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable = cbConfigureDaypartEntryAvailable.Checked;
			VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable = cbConfigureDispositionEntryAvailable.Checked;
			VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable = cbConfigurePrePostEntryAvailable.Checked;
			VWA4Common.GlobalSettings.ConfigureStationEntryAvailable = cbConfigureStationEntryAvailable.Checked;
			VWA4Common.GlobalSettings.DaypartEntryAvailable = cDaypartEntryAvailable.Checked;
			VWA4Common.GlobalSettings.DispositionEntryAvailable = cDispositionEntryAvailable.Checked;
			VWA4Common.GlobalSettings.EnterFinancialsAvailable = cEnterFinancialsAvailable.Checked;
			VWA4Common.GlobalSettings.EnterSWATNotesAvailable = cEnterSWATNotesAvailable.Checked;
			VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable = cFoodCostAdjustmentsAvailable.Checked;
			VWA4Common.GlobalSettings.ImportWasteDataAvailable = cImportWasteDataAvailable.Checked;
			VWA4Common.GlobalSettings.ManageBaselinesAvailable = cManageBaselinesAvailable.Checked;
			VWA4Common.GlobalSettings.ManageDETsAvailable = cManageDETsAvailable.Checked;
			VWA4Common.GlobalSettings.ManageEventClientsAvailable = cManageEventClientsAvailable.Checked;
			VWA4Common.GlobalSettings.ManageEventOrdersAvailable = cManageEventOrdersAvailable.Checked;
			VWA4Common.GlobalSettings.ManagePreferencesAvailable = cManagePreferencesAvailable.Checked;
			VWA4Common.GlobalSettings.ManagePrintFormsAvailable = cManagePrintFormsAvailable.Checked;
			VWA4Common.GlobalSettings.ManageReportsSettingsAvailable = cManageReportsSettingsAvailable.Checked;
			VWA4Common.GlobalSettings.ManageSitesAvailable = cManageSitesAvailable.Checked;
			VWA4Common.GlobalSettings.ManageTrackersAvailable = cManageTrackersAvailable.Checked;
			VWA4Common.GlobalSettings.ManageTypesAvailable = cManageTypesAvailable.Checked;
			// (Max limits are above)
			VWA4Common.GlobalSettings.PrePostEntryAvailable = cPrePostEntryAvailable.Checked;
			VWA4Common.GlobalSettings.RecurringTransactionsAvailable = cRecurringTransactionsAvailable.Checked;
			VWA4Common.GlobalSettings.RemoveUsersAvailable = cRemoveUsersAvailable.Checked;
			VWA4Common.GlobalSettings.StationEntryAvailable = cStationEntryAvailable.Checked;
			VWA4Common.GlobalSettings.UpdateTrackerAvailable = cUpdateTrackerAvailable.Checked;

			// Set it in the config file for next restart
			VWA4.Properties.Settings.Default.LastDBPathName =
				VWA4Common.AppContext.DBPathName;

			// Persist values in App.Config
			VWA4.Properties.Settings.Default.tAddUsersAvailable = VWA4Common.GlobalSettings.AddUsersAvailable.ToString());
			VWA4.Properties.Settings.Default.tAMWTAvailable = VWA4Common.GlobalSettings.AMWTAvailable.ToString());
			VWA4.Properties.Settings.Default.tConfiguratorAvailable = VWA4Common.GlobalSettings.ConfiguratorAvailable.ToString());
			VWA4.Properties.Settings.Default.tConfigureDaypartEntryAvailable = VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tConfigureDispositionEntryAvailable = VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tConfigurePrePostEntryAvailable = VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tConfigureStationEntryAvailable = VWA4Common.GlobalSettings.ConfigureStationEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tDaypartEntryAvailable = VWA4Common.GlobalSettings.DaypartEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tDispositionEntryAvailable = VWA4Common.GlobalSettings.DispositionEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tEnterFinancialsAvailable = VWA4Common.GlobalSettings.EnterFinancialsAvailable.ToString());
			VWA4.Properties.Settings.Default.tEnterSWATNotesAvailable = VWA4Common.GlobalSettings.EnterSWATNotesAvailable.ToString());
			VWA4.Properties.Settings.Default.tFoodCostAdjustmentsAvailable = VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable.ToString());
			VWA4.Properties.Settings.Default.tImportWasteDataAvailable = VWA4Common.GlobalSettings.ImportWasteDataAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageBaselinesAvailable = VWA4Common.GlobalSettings.ManageBaselinesAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageDETsAvailable = VWA4Common.GlobalSettings.ManageDETsAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageEventClientsAvailable = VWA4Common.GlobalSettings.ManageEventClientsAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageEventOrdersAvailable = VWA4Common.GlobalSettings.ManageEventOrdersAvailable.ToString());
			VWA4.Properties.Settings.Default.tManagePreferencesAvailable = VWA4Common.GlobalSettings.ManagePreferencesAvailable.ToString());
			VWA4.Properties.Settings.Default.tManagePrintFormsAvailable = VWA4Common.GlobalSettings.ManagePrintFormsAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageReportsSettingsAvailable = VWA4Common.GlobalSettings.ManageReportsSettingsAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageSitesAvailable = VWA4Common.GlobalSettings.ManageSitesAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageTrackersAvailable = VWA4Common.GlobalSettings.ManageTrackersAvailable.ToString());
			VWA4.Properties.Settings.Default.tManageTypesAvailable = VWA4Common.GlobalSettings.ManageTypesAvailable.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofDETs = VWA4Common.GlobalSettings.MaxNumberofDETs.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofFoodTypes = VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofLossTypes = VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofReports = VWA4Common.GlobalSettings.MaxNumberofReports.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofSites = VWA4Common.GlobalSettings.MaxNumberofSites.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofTrackers = VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString());
			VWA4.Properties.Settings.Default.tMaxNumberofUserTypes = VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString());
			VWA4.Properties.Settings.Default.tPrePostEntryAvailable = VWA4Common.GlobalSettings.PrePostEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tRecurringTransactionsAvailable = VWA4Common.GlobalSettings.RecurringTransactionsAvailable.ToString());
			VWA4.Properties.Settings.Default.tRemoveUsersAvailable = VWA4Common.GlobalSettings.RemoveUsersAvailable.ToString());
			VWA4.Properties.Settings.Default.tStationEntryAvailable = VWA4Common.GlobalSettings.StationEntryAvailable.ToString());
			VWA4.Properties.Settings.Default.tUpdateTrackerAvailable = VWA4Common.GlobalSettings.UpdateTrackerAvailable.ToString());

			
			
			VWA4.Properties.Settings.Default.Save();


			//// Persist values in App.Config
			//System.Configuration.Configuration config =
			//  ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
			//config.AppSettings.Settings.Remove("tAddUsersAvailable");
			//config.AppSettings.Settings.Add("tAddUsersAvailable", VWA4Common.GlobalSettings.AddUsersAvailable.ToString());
			//config.AppSettings.Settings.Remove("tAMWTAvailable");
			//config.AppSettings.Settings.Add("tAMWTAvailable", VWA4Common.GlobalSettings.AMWTAvailable.ToString());
			//config.AppSettings.Settings.Remove("tConfiguratorAvailable");
			//config.AppSettings.Settings.Add("tConfiguratorAvailable", VWA4Common.GlobalSettings.ConfiguratorAvailable.ToString());
			//config.AppSettings.Settings.Remove("tConfigureDaypartEntryAvailable");
			//config.AppSettings.Settings.Add("tConfigureDaypartEntryAvailable", VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tConfigureDispositionEntryAvailable");
			//config.AppSettings.Settings.Add("tConfigureDispositionEntryAvailable", VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tConfigurePrePostEntryAvailable");
			//config.AppSettings.Settings.Add("tConfigurePrePostEntryAvailable", VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tConfigureStationEntryAvailable");
			//config.AppSettings.Settings.Add("tConfigureStationEntryAvailable", VWA4Common.GlobalSettings.ConfigureStationEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tDaypartEntryAvailable");
			//config.AppSettings.Settings.Add("tDaypartEntryAvailable", VWA4Common.GlobalSettings.DaypartEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tDispositionEntryAvailable");
			//config.AppSettings.Settings.Add("tDispositionEntryAvailable", VWA4Common.GlobalSettings.DispositionEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tEnterFinancialsAvailable");
			//config.AppSettings.Settings.Add("tEnterFinancialsAvailable", VWA4Common.GlobalSettings.EnterFinancialsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tEnterSWATNotesAvailable");
			//config.AppSettings.Settings.Add("tEnterSWATNotesAvailable", VWA4Common.GlobalSettings.EnterSWATNotesAvailable.ToString());
			//config.AppSettings.Settings.Remove("tFoodCostAdjustmentsAvailable");
			//config.AppSettings.Settings.Add("tFoodCostAdjustmentsAvailable", VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tImportWasteDataAvailable");
			//config.AppSettings.Settings.Add("tImportWasteDataAvailable", VWA4Common.GlobalSettings.ImportWasteDataAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageBaselinesAvailable");
			//config.AppSettings.Settings.Add("tManageBaselinesAvailable", VWA4Common.GlobalSettings.ManageBaselinesAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageDETsAvailable");
			//config.AppSettings.Settings.Add("tManageDETsAvailable", VWA4Common.GlobalSettings.ManageDETsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageEventClientsAvailable");
			//config.AppSettings.Settings.Add("tManageEventClientsAvailable", VWA4Common.GlobalSettings.ManageEventClientsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageEventOrdersAvailable");
			//config.AppSettings.Settings.Add("tManageEventOrdersAvailable", VWA4Common.GlobalSettings.ManageEventOrdersAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManagePreferencesAvailable");
			//config.AppSettings.Settings.Add("tManagePreferencesAvailable", VWA4Common.GlobalSettings.ManagePreferencesAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManagePrintFormsAvailable");
			//config.AppSettings.Settings.Add("tManagePrintFormsAvailable", VWA4Common.GlobalSettings.ManagePrintFormsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageReportsSettingsAvailable");
			//config.AppSettings.Settings.Add("tManageReportsSettingsAvailable", VWA4Common.GlobalSettings.ManageReportsSettingsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageSitesAvailable");
			//config.AppSettings.Settings.Add("tManageSitesAvailable", VWA4Common.GlobalSettings.ManageSitesAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageTrackersAvailable");
			//config.AppSettings.Settings.Add("tManageTrackersAvailable", VWA4Common.GlobalSettings.ManageTrackersAvailable.ToString());
			//config.AppSettings.Settings.Remove("tManageTypesAvailable");
			//config.AppSettings.Settings.Add("tManageTypesAvailable", VWA4Common.GlobalSettings.ManageTypesAvailable.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofDETs");
			//config.AppSettings.Settings.Add("tMaxNumberofDETs", VWA4Common.GlobalSettings.MaxNumberofDETs.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofFoodTypes");
			//config.AppSettings.Settings.Add("tMaxNumberofFoodTypes", VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofLossTypes");
			//config.AppSettings.Settings.Add("tMaxNumberofLossTypes", VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofReports");
			//config.AppSettings.Settings.Add("tMaxNumberofReports", VWA4Common.GlobalSettings.MaxNumberofReports.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofSites");
			//config.AppSettings.Settings.Add("tMaxNumberofSites", VWA4Common.GlobalSettings.MaxNumberofSites.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofTrackers");
			//config.AppSettings.Settings.Add("tMaxNumberofTrackers", VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString());
			//config.AppSettings.Settings.Remove("tMaxNumberofUserTypes");
			//config.AppSettings.Settings.Add("tMaxNumberofUserTypes", VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString());
			//config.AppSettings.Settings.Remove("tPrePostEntryAvailable");
			//config.AppSettings.Settings.Add("tPrePostEntryAvailable", VWA4Common.GlobalSettings.PrePostEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tRecurringTransactionsAvailable");
			//config.AppSettings.Settings.Add("tRecurringTransactionsAvailable", VWA4Common.GlobalSettings.RecurringTransactionsAvailable.ToString());
			//config.AppSettings.Settings.Remove("tRemoveUsersAvailable");
			//config.AppSettings.Settings.Add("tRemoveUsersAvailable", VWA4Common.GlobalSettings.RemoveUsersAvailable.ToString());
			//config.AppSettings.Settings.Remove("tStationEntryAvailable");
			//config.AppSettings.Settings.Add("tStationEntryAvailable", VWA4Common.GlobalSettings.StationEntryAvailable.ToString());
			//config.AppSettings.Settings.Remove("tUpdateTrackerAvailable");
			//config.AppSettings.Settings.Add("tUpdateTrackerAvailable", VWA4Common.GlobalSettings.UpdateTrackerAvailable.ToString());

			//config.Save(ConfigurationSaveMode.Modified);
			//ConfigurationManager.RefreshSection("appSettings");

		}

		private void loadLicenseValues()
		{
			tbMaxNumberofSites.Text =
				VWA4Common.GlobalSettings.MaxNumberofSites.ToString();
			tbMaxNumberofFoodTypes.Text =
				VWA4Common.GlobalSettings.MaxNumberofFoodTypes.ToString();
			tbMaxNumberofLossTypes.Text =
				VWA4Common.GlobalSettings.MaxNumberofLossTypes.ToString();
			tbMaxNumberofUserTypes.Text =
				VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString();
			tbMaxNumberofDETs.Text =
				VWA4Common.GlobalSettings.MaxNumberofDETs.ToString();
			tbMaxNumberofReports.Text =
				VWA4Common.GlobalSettings.MaxNumberofReports.ToString();
			tbMaxNumberofTrackers.Text =
				VWA4Common.GlobalSettings.MaxNumberofTrackers.ToString();

			// Switches
			/// Configurator Switches (alphabetical order!!!!)
			cAddUsersAvailable.Checked = VWA4Common.GlobalSettings.AddUsersAvailable;
			cAMWTAvailable.Checked = VWA4Common.GlobalSettings.AMWTAvailable;
			cConfiguratorAvailable.Checked = VWA4Common.GlobalSettings.ConfiguratorAvailable;
			cbConfigureDaypartEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable;
			cbConfigureDispositionEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable;
			cbConfigurePrePostEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable;
			cbConfigureStationEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureStationEntryAvailable;
			cDaypartEntryAvailable.Checked = VWA4Common.GlobalSettings.DaypartEntryAvailable;
			cDispositionEntryAvailable.Checked = VWA4Common.GlobalSettings.DispositionEntryAvailable;
			cEnterFinancialsAvailable.Checked = VWA4Common.GlobalSettings.EnterFinancialsAvailable;
			cEnterSWATNotesAvailable.Checked = VWA4Common.GlobalSettings.EnterSWATNotesAvailable;
			cFoodCostAdjustmentsAvailable.Checked = VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable;
			cImportWasteDataAvailable.Checked = VWA4Common.GlobalSettings.ImportWasteDataAvailable;
			cManageBaselinesAvailable.Checked = VWA4Common.GlobalSettings.ManageBaselinesAvailable;
			cManageDETsAvailable.Checked = VWA4Common.GlobalSettings.ManageDETsAvailable;
			cManageEventClientsAvailable.Checked = VWA4Common.GlobalSettings.ManageEventClientsAvailable;
			cManageEventOrdersAvailable.Checked = VWA4Common.GlobalSettings.ManageEventOrdersAvailable;
			cManagePreferencesAvailable.Checked = VWA4Common.GlobalSettings.ManagePreferencesAvailable;
			cManagePrintFormsAvailable.Checked = VWA4Common.GlobalSettings.ManagePrintFormsAvailable;
			cManageReportsSettingsAvailable.Checked = VWA4Common.GlobalSettings.ManageReportsSettingsAvailable;
			cManageSitesAvailable.Checked = VWA4Common.GlobalSettings.ManageSitesAvailable;
			cManageTrackersAvailable.Checked = VWA4Common.GlobalSettings.ManageTrackersAvailable;
			cManageTypesAvailable.Checked = VWA4Common.GlobalSettings.ManageTypesAvailable;
			// (Max limits loaded above)
			cPrePostEntryAvailable.Checked = VWA4Common.GlobalSettings.PrePostEntryAvailable;
			cRecurringTransactionsAvailable.Checked = VWA4Common.GlobalSettings.RecurringTransactionsAvailable;
			cRemoveUsersAvailable.Checked = VWA4Common.GlobalSettings.RemoveUsersAvailable;
			cStationEntryAvailable.Checked = VWA4Common.GlobalSettings.StationEntryAvailable;
			cUpdateTrackerAvailable.Checked = VWA4Common.GlobalSettings.UpdateTrackerAvailable;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void SetTestModeLicenseValues_Load(object sender, EventArgs e)
		{

		}

	}
}
