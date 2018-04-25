using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace VWA4
{
	public partial class SetTestModeLicenseValues : Form
	{
		public SetTestModeLicenseValues(bool allowedit)
		{
			InitializeComponent();
			loadLicenseValues();
			if (!allowedit)
				SetEditMode(allowedit);
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		public SetTestModeLicenseValues()
		{
			InitializeComponent();
			loadLicenseValues();
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			SaveTestModeLicenseSettingstoGlobals();
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}



		private void SaveTestModeLicenseSettingstoGlobals()
		{
			VWA4Common.GlobalSettings.ExpirationDate = dtExpirationDate.Value;
			VWA4Common.GlobalSettings.ExpirationWarningsBeginDate = dtExpirationWarningsBegin.Value;
			switch (cbExpirationWarningsMode.SelectedIndex)
			{
				case 0:
					{
						VWA4Common.GlobalSettings.ExpirationWarningsMode 
							= VWA4Common.Security.Types.ExpirationWarningType.OnProgramStart;
						break;
					}
				case 1:
					{
						VWA4Common.GlobalSettings.ExpirationWarningsMode 
							= VWA4Common.Security.Types.ExpirationWarningType.OnProgramExit;
						break;
					}
				case 2:
					{
						VWA4Common.GlobalSettings.ExpirationWarningsMode 
							= VWA4Common.Security.Types.ExpirationWarningType.OnProgramStartAndExit;
						break;
					}
				case 3:
					{
						VWA4Common.GlobalSettings.ExpirationWarningsMode 
							= VWA4Common.Security.Types.ExpirationWarningType.DuringOperation;
						break;
					}
			}
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
			VWA4Common.GlobalSettings.AddNewCollectionAvailable = cAddNewCollectionAvailable.Checked;
			VWA4Common.GlobalSettings.AddNewReportAvailable = cAddNewReportAvailable.Checked;
			VWA4Common.GlobalSettings.AdvancedMenuAvailable = cAdvancedMenuAvailable.Checked;
			VWA4Common.GlobalSettings.AMWTAvailable = cAMWTAvailable.Checked;
			VWA4Common.GlobalSettings.CloneReportAvailable = cCloneReportAvailable.Checked;
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
			VWA4Common.GlobalSettings.ManageLogFormsAvailable = cManagePrintFormsAvailable.Checked;
			VWA4Common.GlobalSettings.ManageReportsAvailable = cManageReportsSettingsAvailable.Checked;
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

			/// Persist values in App.Config
			VWA4.Properties.Settings.Default.tAddUsersAvailable = VWA4Common.GlobalSettings.AddUsersAvailable;
			VWA4.Properties.Settings.Default.tAMWTAvailable = VWA4Common.GlobalSettings.AMWTAvailable;
			VWA4.Properties.Settings.Default.tConfiguratorAvailable = VWA4Common.GlobalSettings.ConfiguratorAvailable;
			VWA4.Properties.Settings.Default.tConfigureDaypartEntryAvailable = VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable;
			VWA4.Properties.Settings.Default.tConfigureDispositionEntryAvailable = VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable;
			VWA4.Properties.Settings.Default.tConfigurePrePostEntryAvailable = VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable;
			VWA4.Properties.Settings.Default.tConfigureStationEntryAvailable = VWA4Common.GlobalSettings.ConfigureStationEntryAvailable;
			VWA4.Properties.Settings.Default.tDaypartEntryAvailable = VWA4Common.GlobalSettings.DaypartEntryAvailable;
			VWA4.Properties.Settings.Default.tDispositionEntryAvailable = VWA4Common.GlobalSettings.DispositionEntryAvailable;
			VWA4.Properties.Settings.Default.tEnterFinancialsAvailable = VWA4Common.GlobalSettings.EnterFinancialsAvailable;
			VWA4.Properties.Settings.Default.tEnterSWATNotesAvailable = VWA4Common.GlobalSettings.EnterSWATNotesAvailable;
			VWA4.Properties.Settings.Default.tFoodCostAdjustmentsAvailable = VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable;
			VWA4.Properties.Settings.Default.tImportWasteDataAvailable = VWA4Common.GlobalSettings.ImportWasteDataAvailable;
			VWA4.Properties.Settings.Default.tManageBaselinesAvailable = VWA4Common.GlobalSettings.ManageBaselinesAvailable;
			VWA4.Properties.Settings.Default.tManageDETsAvailable = VWA4Common.GlobalSettings.ManageDETsAvailable;
			VWA4.Properties.Settings.Default.tManageEventClientsAvailable = VWA4Common.GlobalSettings.ManageEventClientsAvailable;
			VWA4.Properties.Settings.Default.tManageEventOrdersAvailable = VWA4Common.GlobalSettings.ManageEventOrdersAvailable;
			VWA4.Properties.Settings.Default.tManagePreferencesAvailable = VWA4Common.GlobalSettings.ManagePreferencesAvailable;
			VWA4.Properties.Settings.Default.tManagePrintFormsAvailable = VWA4Common.GlobalSettings.ManageLogFormsAvailable;
			VWA4.Properties.Settings.Default.tManageReportsSettingsAvailable = VWA4Common.GlobalSettings.ManageReportsAvailable;
			VWA4.Properties.Settings.Default.tManageSitesAvailable = VWA4Common.GlobalSettings.ManageSitesAvailable;
			VWA4.Properties.Settings.Default.tManageTrackersAvailable = VWA4Common.GlobalSettings.ManageTrackersAvailable;
			VWA4.Properties.Settings.Default.tManageTypesAvailable = VWA4Common.GlobalSettings.ManageTypesAvailable;
			VWA4.Properties.Settings.Default.tMaxNumberofDETs = VWA4Common.GlobalSettings.MaxNumberofDETs;
			VWA4.Properties.Settings.Default.tMaxNumberofFoodTypes = VWA4Common.GlobalSettings.MaxNumberofFoodTypes;
			VWA4.Properties.Settings.Default.tMaxNumberofLossTypes = VWA4Common.GlobalSettings.MaxNumberofLossTypes;
			VWA4.Properties.Settings.Default.tMaxNumberofReports = VWA4Common.GlobalSettings.MaxNumberofReports;
			VWA4.Properties.Settings.Default.tMaxNumberofSites = VWA4Common.GlobalSettings.MaxNumberofSites;
			VWA4.Properties.Settings.Default.tMaxNumberofTrackers = VWA4Common.GlobalSettings.MaxNumberofTrackers;
			VWA4.Properties.Settings.Default.tMaxNumberofUserTypes = VWA4Common.GlobalSettings.MaxNumberofUserTypes;
			VWA4.Properties.Settings.Default.tPrePostEntryAvailable = VWA4Common.GlobalSettings.PrePostEntryAvailable;
			VWA4.Properties.Settings.Default.tRecurringTransactionsAvailable = VWA4Common.GlobalSettings.RecurringTransactionsAvailable;
			VWA4.Properties.Settings.Default.tRemoveUsersAvailable = VWA4Common.GlobalSettings.RemoveUsersAvailable;
			VWA4.Properties.Settings.Default.tStationEntryAvailable = VWA4Common.GlobalSettings.StationEntryAvailable;
			VWA4.Properties.Settings.Default.tUpdateTrackerAvailable = VWA4Common.GlobalSettings.UpdateTrackerAvailable;
			
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
			// Expiration stuff
			dtExpirationDate.Value = VWA4Common.GlobalSettings.ExpirationDate;
			dtExpirationWarningsBegin.Value = VWA4Common.GlobalSettings.ExpirationWarningsBeginDate;
			switch (VWA4Common.GlobalSettings.ExpirationWarningsMode)
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
			lExpirationFrequency.Text = VWA4Common.GlobalSettings.ExpirationWarningsFrequency.ToString();
			
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
			cAddUsersAvailable.Checked = VWA4Common.GlobalSettings.AddUsersAvailablex;
			cAddNewCollectionAvailable.Checked = VWA4Common.GlobalSettings.AddNewCollectionAvailablex;
			cAddNewReportAvailable.Checked = VWA4Common.GlobalSettings.AddNewReportAvailablex;
			cAdvancedMenuAvailable.Checked = VWA4Common.GlobalSettings.AdvancedMenuAvailablex;
			cAMWTAvailable.Checked = VWA4Common.GlobalSettings.AMWTAvailablex;
			cCloneReportAvailable.Checked = VWA4Common.GlobalSettings.CloneReportAvailablex;
			cConfiguratorAvailable.Checked = VWA4Common.GlobalSettings.ConfiguratorAvailablex;
			cbConfigureDaypartEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailablex;
			cbConfigureDispositionEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailablex;
			cbConfigurePrePostEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailablex;
			cbConfigureStationEntryAvailable.Checked = VWA4Common.GlobalSettings.ConfigureStationEntryAvailablex;
			cDaypartEntryAvailable.Checked = VWA4Common.GlobalSettings.DaypartEntryAvailablex;
			cDispositionEntryAvailable.Checked = VWA4Common.GlobalSettings.DispositionEntryAvailablex;
			cEnterFinancialsAvailable.Checked = VWA4Common.GlobalSettings.EnterFinancialsAvailablex;
			cEnterSWATNotesAvailable.Checked = VWA4Common.GlobalSettings.EnterSWATNotesAvailablex;
			cFoodCostAdjustmentsAvailable.Checked = VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailablex;
			cImportWasteDataAvailable.Checked = VWA4Common.GlobalSettings.ImportWasteDataAvailablex;
			cManageBaselinesAvailable.Checked = VWA4Common.GlobalSettings.ManageBaselinesAvailablex;
			cManageDETsAvailable.Checked = VWA4Common.GlobalSettings.ManageDETsAvailablex;
			cManageEventClientsAvailable.Checked = VWA4Common.GlobalSettings.ManageEventClientsAvailablex;
			cManageEventOrdersAvailable.Checked = VWA4Common.GlobalSettings.ManageEventOrdersAvailablex;
			cManagePreferencesAvailable.Checked = VWA4Common.GlobalSettings.ManagePreferencesAvailablex;
			cManagePrintFormsAvailable.Checked = VWA4Common.GlobalSettings.ManageLogFormsAvailablex;
			cManageReportsSettingsAvailable.Checked = VWA4Common.GlobalSettings.ManageReportsAvailablex;
			cManageSitesAvailable.Checked = VWA4Common.GlobalSettings.ManageSitesAvailablex;
			cManageTrackersAvailable.Checked = VWA4Common.GlobalSettings.ManageTrackersAvailablex;
			cManageTypesAvailable.Checked = VWA4Common.GlobalSettings.ManageTypesAvailablex;
			// (Max limits loaded above)
			cPrePostEntryAvailable.Checked = VWA4Common.GlobalSettings.PrePostEntryAvailablex;
			cRecurringTransactionsAvailable.Checked = VWA4Common.GlobalSettings.RecurringTransactionsAvailablex;
			cRemoveUsersAvailable.Checked = VWA4Common.GlobalSettings.RemoveUsersAvailablex;
			cStationEntryAvailable.Checked = VWA4Common.GlobalSettings.StationEntryAvailablex;
			cUpdateTrackerAvailable.Checked = VWA4Common.GlobalSettings.UpdateTrackerAvailablex;

			lConfiguratorPathNamex.Text = VWA4Common.GlobalSettings.ConfiguratorPathName;
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
			bSave.Visible = allowedit;

			lConfiguratorPathNamex.Text = VWA4Common.GlobalSettings.ConfiguratorPathName;
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
