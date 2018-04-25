using System;
using System.Net;
using System.Configuration;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LMan4.com.licensemanager4web;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win;
using LMan4.Updates;

namespace LMan4
{
	public partial class Form1 : Form
	{
	    private LicenseManagerWebService licenseService = LicenseUtility.GetWebService();
        private int currentLicenseId = -1;

        private UltraListView ulvActivations = new UltraListView();

        private string _InitialDirectory = Application.ExecutablePath;

        public Form1()
        {
            InitializeComponent();

            setTestMode();
            populateProducts();

			/// Main tab (Product Indep)
            this.cbProduct.SelectedIndex = 0;
			cbAllowedWasteClasses.SelectedIndex = 0;
			lblCreateDate.Text = "";
			lblLicenseRecordId.Text = "";
			rbCPULic.Checked = true;
            ulvActivations.Width = this.pnlActivations.Width;
            ulvActivations.Height = this.pnlActivations.Height;
            ulvActivations.ItemDoubleClick += new ItemDoubleClickEventHandler(ulvActivations_ItemDoubleClick);
            this.pnlActivations.Controls.Add(ulvActivations);
            //populate client drop down list
            this.populateClients();
			/// Sites,Users tab
			cbDefaultUserLevel.SelectedIndex = 1;
			nmNumberOfSites.Value = 1;
			txtManagerPassword.Text = "Manager";
			txtAdministratorPassword.Text = "Super";
			/// Database Configuration tab
			// Delphi
			chkUseConfiguratorIfInstalled.Checked = true;
			chkManageTypesAvailable.Checked = true;
			chkManageTrackersAvailable.Checked = true;
			chkManageSitesAvailable.Checked = true;
			chkManageEventTypes.Checked = true;
			// .NET
			chkAddUsers.Checked = true;
			ChkManageBaselinesAvailable.Checked = true;
			chkManageEventClientsAvailable.Checked = true;
			chkManageEventOrdersAvailable.Checked = true;
			chkManageFoodCostAdjustmentsAvailable.Checked = true;
			chkManagePreferencesAvailable.Checked = true;
			chkRemoveUsers.Checked = true;
			///Limits
			nmTrackerLimit.Value = 1;
			nmFoodTypeLimit.Value = 100;
			nmLossTypeLimit.Value = 25;
			nmUserTypeLimit.Value = 500;
			/// Tracker Management
			chkUpdateTrackerAvailable.Checked = true;
			chkImportDataAvailable.Checked = true;
			chkManageRecurringTransactionsAvailable.Checked = true;
			/// AMWT
			// Include Manage DET
			chkIncludeDET.Checked = true;
			chkConfigureStationAvailable.Checked = true;
			chkConfigureDaypartAvailable.Checked = true;
			chkDispositionEntryAvailable.Checked = true;
			chkConfigurePrePostAvailable.Checked = true;
			// Include Enter Log Sheet Data
			chkEnterLogSheetData.Checked = true;
			chkStationEntryAvailable.Checked = true;
			chkDaypartEntryAvailable.Checked = true;
			chkDispositionEntryAvailable.Checked = true;
			chkPrePostEntryAvailable.Checked = true;
			//
			chkIncludeManageForms.Checked = true;
			//Limits
			nmDETLimit.Value = 25;
			/// Tasks
			chkAdvancedMenuAvailable.Checked = true;
			chkEnterMonthlyFinancialsAvailable.Checked = true;
			chkEnterSWATNotesAvailable.Checked = true;
			/// Reporting
			chkManageReportSettingsShortcutShown.Checked = true;
			chkAddNewReportsAvailable.Checked = true;
			chkAddNewReportCollectionAvailable.Checked = true;
			chkCloneReportAvailable.Checked = true;
			chkCreateSaveNewReports.Checked = true;
			nmReportLimits.Value = 25;
			/// About
			chkSupportEmailAddressShown.Checked = true;
			chkSupportPhoneNumberShown.Checked = true;
			chkSupportWebSiteShown.Checked = true;

            this.autoSelectTextboxes();
        }

        private void autoSelectTextboxes()
        {
            this.txtGeneratedBy.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtProductVersionName.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtManagerPassword.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtAdministratorPassword.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtSupportEmailAddress.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtSupportPhoneNumber.GotFocus += new EventHandler(textbox_GotFocus);
            this.txtSupportWebSiteURL.GotFocus += new EventHandler(textbox_GotFocus);

            this.txtGeneratedBy.Click += new EventHandler(textbox_GotFocus);
            this.txtProductVersionName.Click += new EventHandler(textbox_GotFocus);
            this.txtManagerPassword.Click += new EventHandler(textbox_GotFocus);
            this.txtAdministratorPassword.Click += new EventHandler(textbox_GotFocus);
            this.txtSupportEmailAddress.Click += new EventHandler(textbox_GotFocus);
            this.txtSupportPhoneNumber.Click += new EventHandler(textbox_GotFocus);
            this.txtSupportWebSiteURL.Click += new EventHandler(textbox_GotFocus);
        }

        void textbox_GotFocus(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        
		private void chkUseDelphiConfiguratorIfInstalled_Click(object sender, EventArgs e)
		{
			if (!chkUseConfiguratorIfInstalled.Checked)
			{
				chkManageTypesAvailable.Checked = false;
				chkManageTrackersAvailable.Checked = false;
				chkManageSitesAvailable.Checked = false;
				chkManageEventTypes.Checked = false;
				groupBox7.Enabled = false;
			}
			else
			{
				groupBox7.Enabled = true;
				chkManageTypesAvailable.Checked = true;
				chkManageTrackersAvailable.Checked = true;
				chkManageSitesAvailable.Checked = true;
				chkManageEventTypes.Checked = true;
			}
		}

		private void bCheckAll_Click(object sender, EventArgs e)
		{
			// .NET
			chkAddUsers.Checked = true;
			ChkManageBaselinesAvailable.Checked = true;
			chkManageEventClientsAvailable.Checked = true;
			chkManageEventOrdersAvailable.Checked = true;
			chkManageFoodCostAdjustmentsAvailable.Checked = true;
			chkManagePreferencesAvailable.Checked = true;
			chkRemoveUsers.Checked = true;

		}

		private void bUnCheckAll_Click(object sender, EventArgs e)
		{
			// .NET
			chkAddUsers.Checked = false;
			ChkManageBaselinesAvailable.Checked = false;
			chkManageEventClientsAvailable.Checked = false;
			chkManageEventOrdersAvailable.Checked = false;
			chkManageFoodCostAdjustmentsAvailable.Checked = false;
			chkManagePreferencesAvailable.Checked = false;
			chkRemoveUsers.Checked = false;
		}

		private void chkIncludeDET_CheckedChanged(object sender, EventArgs e)
		{
			if (chkIncludeDET.Checked)
			{
				chkConfigureStationAvailable.Checked = true;
				chkConfigureDaypartAvailable.Checked = true;
				chkDispositionEntryAvailable.Checked = true;
				chkConfigurePrePostAvailable.Checked = true;
				groupBox10.Enabled = true;
			}
			else
			{
				chkConfigureStationAvailable.Checked = false;
				chkConfigureDaypartAvailable.Checked = false;
				chkConfigureDispositionAvailable.Checked = false;
				chkConfigurePrePostAvailable.Checked = false;
				groupBox10.Enabled = false;
			}
		}

		private void chkEnterLogSheetData_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEnterLogSheetData.Checked)
			{
				chkStationEntryAvailable.Checked = true;
				chkDaypartEntryAvailable.Checked = true;
				chkDispositionEntryAvailable.Checked = true;
				chkPrePostEntryAvailable.Checked = true;
				groupBox11.Enabled = true;
				chkIncludeDET.Checked = true;
				chkIncludeDET.Enabled = true;
			}
			else
			{
				chkStationEntryAvailable.Checked = false;
				chkDaypartEntryAvailable.Checked = false;
				chkDispositionEntryAvailable.Checked = false;
				chkPrePostEntryAvailable.Checked = false;
				groupBox11.Enabled = false;
				chkIncludeDET.Checked = false;
				chkIncludeDET.Enabled = false;
			}
		}


		private void chkSupportEmailAddressShown_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSupportEmailAddressShown.Checked)
			{
				txtSupportEmailAddress.Text = "support@leanpath.com";
				txtSupportEmailAddress.Enabled = true;
			}
			else txtSupportEmailAddress.Enabled = false;
		}

		private void chkSupportPhoneNumberShown_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSupportPhoneNumberShown.Checked)
			{
				txtSupportPhoneNumber.Text = "(503) 620-6512";
				txtSupportPhoneNumber.Enabled = true;
			}
			else txtSupportPhoneNumber.Enabled = false;
		}

		private void chkSupportWebSiteShown_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSupportWebSiteShown.Checked)
			{
				txtSupportWebSiteURL.Text = "http://www.leanpath.com";
				txtSupportWebSiteURL.Enabled = true;
			}
			else txtSupportWebSiteURL.Enabled = false;
		}


        private void populateProducts()
        {
            // 
            this.cbProduct.Items.Clear();
            this.cbProduct.Items.Add("ValuWaste Advantage 4.3");
            this.cbProduct.Items.Add("ValuWaste Advantage 4.2");
            //this.cbProduct.Items.Add("WasteProfiler");)
            this.cbProduct.Items.Add("WasteLogger 1");
        }

        void ulvActivations_ItemDoubleClick(object sender, ItemDoubleClickEventArgs e)
        {
            if (ulvActivations.SelectedItems.Count > 0)
            {
                if (this.currentLicenseId != -1)
                {
					LMan4.com.licensemanager4web.License l = licenseService.GetLicenseById(this.currentLicenseId);
					LMan4.com.licensemanager4web.LicenseFeaturesParams lf = licenseService.GetLicenseFeatureParams(this.currentLicenseId);
					LMan4.com.licensemanager4web.Activation a = licenseService.GetActivationById(Convert.ToInt32(ulvActivations.SelectedItems[0].Key));

                    AddActivation frm = new AddActivation(l, lf, a);
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please select and existing license record, or save current record before creating an activation record.", "Error");
                }
            }
        }

        private void btnViewActivationRecord_Click(object sender, EventArgs e)
        {
            if (ulvActivations.SelectedItems.Count > 0)
            {
                if (this.currentLicenseId != -1)
                {
					LMan4.com.licensemanager4web.License l = licenseService.GetLicenseById(this.currentLicenseId);
                    LMan4.com.licensemanager4web.LicenseFeaturesParams lf = licenseService.GetLicenseFeatureParams(this.currentLicenseId);
                    LMan4.com.licensemanager4web.Activation a = licenseService.GetActivationById(Convert.ToInt32(ulvActivations.SelectedItems[0].Key));

                    AddActivation frm = new AddActivation(l, lf, a);
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please select and existing license record, or save current record before creating an activation record.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a Activation record, or double click a Activation record to view/edit.", "Error");
            }
        }
        
        private void populateClients()
        {
            this.ddlClients.Items.Clear();
            this.ddlSites.Items.Clear();

            this.ddlClients.DisplayMember = "ClientName";
            this.ddlClients.ValueMember = "ID";

            foreach (Client c in licenseService.GetAllClients())
            {
                this.ddlClients.Items.Add(c);
            }            
            this.ddlClients.Items.Insert(0, new Client { ID = -1, ClientName = "New Client" }); 

            this.ddlClients.SelectedIndexChanged += new EventHandler(ddlClients_SelectedIndexChanged);

            this.ddlClients.SelectedIndex = 0;
        }

        void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlSites.Items.Clear();

            this.ddlSites.DisplayMember = "SiteName";
            this.ddlSites.ValueMember = "ID";

            foreach(Site s in licenseService.GetAllSitesByClientId((this.ddlClients.SelectedItem as Client).ID))
            {
                this.ddlSites.Items.Add(s);
            }

            this.ddlSites.Items.Insert(0, new Site { ID = -1, SiteName = "New Site" });

            this.ddlSites.SelectedIndex = 0;

            //this.ddlSites.SelectedIndexChanged += new EventHandler(ddlSites_SelectedIndexChanged);
        }

        void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Make appropriate show/hide decisions
			if (cbProduct.SelectedIndex == 0)
			{
				if (tabLMan4.TabPages[3].Name == "tabTrackerMgmt") return;
				tabLMan4.TabPages.Insert(3, tabTrackerMgmt);
			}
			else if (cbProduct.SelectedIndex == 1)
			{
				tabLMan4.TabPages.Remove(tabTrackerMgmt);
			}
		}     

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //generate non activated license file
            if (this.currentLicenseId >= 0)
            {
                LicenseFeaturesParams p = licenseService.GetLicenseFeatureParams(this.currentLicenseId);

                LicenseUtility.GenerateLicense(p);
            }
            else
            {
                MessageBox.Show("Please save current license, or load a license before generating a license file.", "Error");
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //VWALicenseManager.GetVWALicenseManager().LoadLicense(dlg.FileName);
            LoadLicense ll = new LoadLicense();
            ll.FormClosing += new FormClosingEventHandler(ll_FormClosing);
            ll.ShowDialog();
        }

        void ll_FormClosing(object sender, FormClosingEventArgs e)
        {
            if((sender as LoadLicense).LicenseId > 0){
                this.currentLicenseId = (sender as LoadLicense).LicenseId;
                this.populateForm(true);
            }                
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            LoadLicense ll = new LoadLicense();
            ll.FormClosing += new FormClosingEventHandler(ll_FormClosingLoadSettings);
            ll.ShowDialog();
        }

        void ll_FormClosingLoadSettings(object sender, FormClosingEventArgs e)
        {
            this.currentLicenseId = (sender as LoadLicense).LicenseId;
            if (this.currentLicenseId != -1)
            {
                this.populateForm(false);
                this.currentLicenseId = -1;
                this.populateClients();
            }
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            errorMessage = "";
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(emailAddress))
                return true;

            errorMessage = "e-mail address must be valid e-mail address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        public bool ValidPhoneNumber(string phoneNumber, out string errorMessage)
        {
            errorMessage = "";
            if (!Regex.Match(phoneNumber, @"^(?[1-9]\d{2})?-?[1-9]\d{2}-?\d{4}$").Success)
            {

                errorMessage = "Phone number must be valid phone number format.\n" +
                   "For example 503-333-3333 ";
                return false;
            }
            return true;
        }

        public bool ValidWebURL(string webURL, out string errorMessage)
        {
            errorMessage = "";
            // Also mark URLs that don't start with http:// as valid
            Regex RgxUrl = new Regex(@"^(((h|H?)(t|T?)(t|T?)(p|P?)(s|S?))\://)?(www.|[a-zA-Z0-9].)[a-zA-Z0-9\-\.]+\.[a-zA-Z]*$");
            if (RgxUrl.IsMatch(webURL))
                return true;

            errorMessage = "Web URL must be valid URL format.\n" +
               @"For example www.geekpedia.com or http://www.geekpedia.com ";
            return false;
        }

        private void tabProductIndep_Validating(object sender, CancelEventArgs e)
        {
            //Validate_tabProductIndep();
        }

        private bool Validate_tabProductIndep()
        {
            bool bStatus = true;
            
            if (txtGeneratedBy.Text == "(enter person name)" || txtGeneratedBy.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtGeneratedBy, "Not valid Generated User");
                bStatus = false;
            }
            else
               errorProvider.SetError(txtGeneratedBy, "");

            //string strCode = GenerateActivationCode();
            //if (strCode == "")
            //{
            //    errorProvider.SetError(txtActivationCode4, "Not valid Activation Code");
            //    bStatus = false;
            //}
            //else
            //{
            //    if (strCode != txtActivationCode1.Text + txtActivationCode2.Text + txtActivationCode3.Text + txtActivationCode4.Text)
            //        SetActivationCode(strCode);
            //    errorProvider.SetError(txtActivationCode4, "");
            //}
            if (txtLicenseSerialNumber.Text == "(enter serial number)" || txtLicenseSerialNumber.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtLicenseSerialNumber, "Not valid Serial Number");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtLicenseSerialNumber, "");

            if (!rbSiteLic.Checked && !rbCPULic.Checked)
                errorProvider.SetError(rbCPULic, "Choose Site or CPU ID");
            else
            {
                errorProvider.SetError(rbCPULic, "");
            }
            
            if (cbExpirationWarningsMode.SelectedItem == null)
            {
                errorProvider.SetError(cbExpirationWarningsMode, "Pick Expiration Warning Mode");
                bStatus = false;
            }
            else
                errorProvider.SetError(cbExpirationWarningsMode, "");

            if (cbExpirationWarningsFrequency.SelectedItem == null)
            {
                errorProvider.SetError(cbExpirationWarningsFrequency, "Pick Expiration Warning Frequency");
                bStatus = false;
            }
            else
                errorProvider.SetError(cbExpirationWarningsFrequency, "");

            if (cbAllowedWasteClasses.SelectedItem == null)
            {
                errorProvider.SetError(cbAllowedWasteClasses, "Not valid Allowed Waste Classes");
                bStatus = false;
            }
            else
                errorProvider.SetError(cbAllowedWasteClasses, "");

            if (txtProductVersionName.Text == "(enter  name)" || txtProductVersionName.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtProductVersionName, "Not valid Product Version");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtProductVersionName, "");

            return bStatus;
        }

        private void tabSitesUsers_Validating(object sender, CancelEventArgs e)
        {
            Validate_tabSitesUsers();
        }
        
        private bool Validate_tabSitesUsers()
        {
            bool bStatus = true;
            if (cbDefaultUserLevel.Text == "(pick level)")
            {
                errorProvider.SetError(cbDefaultUserLevel, "Not valid Default User Level");
                bStatus = false;
            }
            else 
                errorProvider.SetError(cbDefaultUserLevel, "");
            if (txtManagerPassword.Text == "(enter password)" || txtManagerPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtManagerPassword, "Not valid Manager Password");
                bStatus = false;
            }
            else 
                errorProvider.SetError(txtManagerPassword, "");
            if (txtAdministratorPassword.Text == "(enter password)" || txtAdministratorPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtAdministratorPassword, "Not valid Administrator Password");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtAdministratorPassword, "");
            return bStatus;
        }

        private void tabAbout_Validating(object sender, CancelEventArgs e)
        {
            Validate_tabAbout();
        }

        private bool Validate_tabAbout()
        {
            bool bStatus = true;
            string error = "";
            if (chkSupportEmailAddressShown.Checked)
            {
                if (txtSupportEmailAddress.Text == "(enter email address)" || txtSupportEmailAddress.Text.Trim().Length == 0 ||
                    !ValidEmailAddress(txtSupportEmailAddress.Text, out error))
                {
                    errorProvider.SetError(txtSupportEmailAddress, "Not valid Email");
                    bStatus = false;
                }
                else
                    errorProvider.SetError(txtSupportEmailAddress, "");
            }
            else
            {
                errorProvider.SetError(txtSupportEmailAddress, "");
                txtSupportEmailAddress.Text = "";
            }

            if (chkSupportPhoneNumberShown.Checked)
            {
                if (txtSupportPhoneNumber.Text == "(enter phone number)" || txtSupportPhoneNumber.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(txtSupportPhoneNumber, "Not valid Phone Number");
                    bStatus = false;
                }
                else
                    errorProvider.SetError(txtSupportPhoneNumber, "");
            }
            else 
            {
                txtSupportPhoneNumber.Text = "";
                errorProvider.SetError(txtSupportPhoneNumber, "");
            }

            if (chkSupportWebSiteShown.Checked)
            {
                if (txtSupportWebSiteURL.Text == "(enter URL)" || txtSupportWebSiteURL.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(txtSupportWebSiteURL, "Not valid Web URL");
                    bStatus = false;
                }
                else
                    errorProvider.SetError(txtSupportWebSiteURL, "");
            }
            else
            {
                errorProvider.SetError(txtSupportWebSiteURL, "");
                txtSupportWebSiteURL.Text = "";
            }

            return bStatus;
        }
        
        private void cbProduct_Validating(object sender, CancelEventArgs e)
        {
            Validate_cbProduct();
        }

        private bool Validate_cbProduct()
        {
            bool bStatus = true;
            if (cbProduct.Text == "(select Product)")
            {
                errorProvider.SetError(cbProduct, "Not valid Product Name");
                bStatus = false;
            }
            else
                errorProvider.SetError(cbProduct, "");

            return bStatus;
        }

        private bool ValidateForm()
        {
            bool bValidProduct = Validate_cbProduct();
            bool bValidProductIndep = Validate_tabProductIndep();
            bool bValidSitesUsers = Validate_tabSitesUsers();
            bool bValidtabAbout = Validate_tabAbout();
            if (!bValidProduct || !bValidProductIndep || !bValidSitesUsers || !bValidtabAbout)
            {
                MessageBox.Show("Please enter valid data");
                return false;
            }
            return true;
        }

        private void btnAddActivationRecord_Click(object sender, EventArgs e)
        {
            if (this.currentLicenseId != -1)
            {
                LMan4.com.licensemanager4web.License l = licenseService.GetLicenseById(this.currentLicenseId);
                LMan4.com.licensemanager4web.LicenseFeaturesParams lf = licenseService.GetLicenseFeatureParams(this.currentLicenseId);
                AddActivation frm = new AddActivation(l, lf);
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();               
            }
            else
            {
                MessageBox.Show("Please select and existing license record, or save current record before creating an activation record.");
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.populateActivations();
        }        

        private int setFrequency(string unit)
        {
            for (int i = 0; i < this.cbExpirationWarningsFrequency.Items.Count; i++)
            {
                if (this.cbExpirationWarningsFrequency.Items[i].ToString().ToLower().Equals(unit.ToLower()))
                {
                    return i;
                }
            }
            return 0;
        }

        private int getProduct(int product)
        {
            switch (this.cbProduct.SelectedIndex)
            {
                case 0:
                    return 1;
                case 1:
                    return 3;
                default:
                    return 1;
            }
        }

        private int setProduct(int product)
        {
            switch (product)
            {
                case 1:
                    return 0;
                case 3:
                    return 1;
                default:
                    return 0;
            }
        }

        private void populateForm(bool loadActivations)
        {
            try
            {
                //populate form from selected license id
                LicenseFeaturesParams p = licenseService.GetLicenseFeatureParams(this.currentLicenseId);

                this.ddlClients.Items.Clear();
                this.ddlClients.Items.Add(new Client { ID = p.ClientID, ClientName = p.ClientName });
                this.ddlClients.SelectedIndex = 0;

                this.ddlSites.Items.Clear();
                this.ddlSites.Items.Add(new Site { ID = p.SiteID, SiteName = p.SiteName, ClientID = p.ClientID });
                this.ddlSites.SelectedIndex = 0;

                this.ulvActivations.Items.Clear();

                this.cbProduct.SelectedIndex = this.setProduct(p.Product);

                if (p.LicenseType.Equals(LicenseType.CPU))
                    rbCPULic.Checked = true;
                else
                    rbSiteLic.Checked = true;
                this.txtGeneratedBy.Text = p.GeneratedBy;
                this.lblCreateDate.Text = string.Format("{0} {1}", p.GeneratedDate.ToLongDateString(), p.GeneratedDate.ToShortTimeString());
                this.txtLicenseSerialNumber.Text = p.LicenseKey;
                this.lblLicenseRecordId.Text = p.LicenseID.ToString();
                this.dtExpirationDate.Value = p.ExpirationDate;
                this.dtExpirationWarningsBeginDate.Value = p.ExpirationWarningStartDate;
                this.cbExpirationWarningsMode.SelectedIndex = (int)p.ExpirationWarningsMode;
                this.nmExpirationWarningsFrequency.Value = p.ExpirationWarningsFrequency;
                this.cbExpirationWarningsFrequency.SelectedIndex = this.setFrequency(p.ExpirationWarningsUnit);
                this.cbAllowedWasteClasses.SelectedIndex = (int)p.AllowedWasteClassses;
                this.txtProductVersionName.Text = p.ProductVersionName;
                this.nmNumberOfSites.Value = p.NumberOfSites;
                this.cbDefaultUserLevel.SelectedIndex = (int)p.DefaultUserLevel;
                this.txtManagerPassword.Text = p.ManagerPassword;
                this.txtAdministratorPassword.Text = p.AdministratorPassword;
                this.chkUseConfiguratorIfInstalled.Checked = p.UseConfigurator;
                this.chkManageTypesAvailable.Checked = p.ManageTypesAvailable;
                this.chkManageTrackersAvailable.Checked = p.ManageTrackers;
                this.chkManageSitesAvailable.Checked = p.ManageSites;
                this.chkManageEventTypes.Checked = p.ManageEventTypes;
                this.chkManageEventClientsAvailable.Checked = p.ManageEventClients;
                this.chkManageEventOrdersAvailable.Checked = p.ManageEventOrders;
                this.chkManagePreferencesAvailable.Checked = p.ManagePreferences;
                this.ChkManageBaselinesAvailable.Checked = p.ManageBaselines;
                this.chkManageFoodCostAdjustmentsAvailable.Checked = p.FoodCostAdjustments;
                this.chkAddUsers.Checked = p.AddUsers;
                this.chkRemoveUsers.Checked = p.RemoveUsers;
                this.nmTrackerLimit.Value = p.TrackerLimit;
                this.nmFoodTypeLimit.Value = p.FoodTypeLimit;
                this.nmLossTypeLimit.Value = p.LossTypeLimit;
                this.nmUserTypeLimit.Value = p.UserTypeLimit;
                this.chkUpdateTrackerAvailable.Checked = p.UpdateTracker;
                this.chkImportDataAvailable.Checked = p.ImportWasteData;
                this.chkManageRecurringTransactionsAvailable.Checked = p.RecurringTransactionsAvailable;
                this.chkIncludeDET.Checked = p.ManageDataEntryTemplates;
                this.chkConfigureStationAvailable.Checked = p.ConfigureStationEntry;
                this.chkConfigureDaypartAvailable.Checked = p.ConfigureDaypartEntry;
                this.chkConfigureDispositionAvailable.Checked = p.ConfigureDispositionEntry;
                this.chkConfigurePrePostAvailable.Checked = p.ConfigurePrePostEntry;
                this.chkEnterLogSheetData.Checked = p.EnterLogSheetData;
                this.chkStationEntryAvailable.Checked = p.StationEntry;
                this.chkDaypartEntryAvailable.Checked = p.DaypartEntry;
                this.chkDispositionEntryAvailable.Checked = p.DispositionEntry;
                this.chkPrePostEntryAvailable.Checked = p.PrePostEntry;
                this.chkIncludeManageForms.Checked = p.ManageLogForms;
                this.nmDETLimit.Value = p.DetLimits;
                this.chkAdvancedMenuAvailable.Checked = p.AdvancedMenuAvailable;
                this.chkEnterMonthlyFinancialsAvailable.Checked = p.EnterFinancialsAvailable;
                this.chkEnterSWATNotesAvailable.Checked = p.EnterSWATNotesAvailable;
                this.chkManageReportSettingsShortcutShown.Checked = p.ManageReportsSettingsShortcut;
                this.chkAddNewReportsAvailable.Checked = p.AddNewReport;
                this.chkAddNewReportCollectionAvailable.Checked = p.AddNewCollection;
                this.chkCloneReportAvailable.Checked = p.Clone;
                this.chkCreateSaveNewReports.Checked = p.AddNewReport;
                this.nmReportLimits.Value = p.ReportLimits;
                this.chkSupportEmailAddressShown.Checked = p.ShowSupportEmailAddress;
                this.chkSupportPhoneNumberShown.Checked = p.ShowSupportPhoneNumber;
                this.chkSupportWebSiteShown.Checked = p.ShowSupportWebSiteURL;
                this.txtSupportEmailAddress.Text = p.SupportEmailAddress;
                this.txtSupportPhoneNumber.Text = p.SupportPhoneNumber;
                this.txtSupportWebSiteURL.Text = p.SupportWebSiteURL;

                //load activation records
                if (loadActivations)
                    this.populateActivations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populateActivations()
        {            
            ulvActivations.Items.Clear();
            ulvActivations.SubItemColumns.Clear();
            ulvActivations.SelectedItems.Clear();

            ulvActivations.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.None;
            ulvActivations.ViewSettingsDetails.ImageSize = Size.Empty;
            ulvActivations.ViewSettingsDetails.FullRowSelect = true;
            ulvActivations.View = UltraListViewStyle.Details;
            ulvActivations.ViewSettingsList.MultiColumn = false;
            ulvActivations.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvActivations.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvActivations.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvActivations.ItemSettings.SelectionType = SelectionType.Single;
            ulvActivations.ItemSettings.AllowEdit = DefaultableBoolean.False;

            UltraListViewMainColumn mainColumn = ulvActivations.MainColumn;
            mainColumn.Text = "Activation ID";
            mainColumn.DataType = typeof(Int32);
            mainColumn.Width = 90;

            UltraListViewSubItemColumn cExpirationDate = new UltraListViewSubItemColumn();
            cExpirationDate.Text = "Expiration Date";
            cExpirationDate.Width = 60;
            cExpirationDate.VisibleInDetailsView = DefaultableBoolean.True;
            cExpirationDate.DataType = typeof(String);

            UltraListViewSubItemColumn cIsActivated = new UltraListViewSubItemColumn();
            cIsActivated.Text = "Activated";
            cIsActivated.Width = 50;
            cIsActivated.VisibleInDetailsView = DefaultableBoolean.True;
            cIsActivated.DataType = typeof(String);

            UltraListViewSubItemColumn cIsEnabled = new UltraListViewSubItemColumn();
            cIsEnabled.Text = "Enabled";
            cIsEnabled.Width = 30;
            cIsEnabled.VisibleInDetailsView = DefaultableBoolean.True;
            cIsEnabled.DataType = typeof(String);

            ulvActivations.SubItemColumns.Add(cExpirationDate);
            ulvActivations.SubItemColumns.Add(cIsActivated);
            ulvActivations.SubItemColumns.Add(cIsEnabled);
            
            Activation[] acts = licenseService.GetActivationsByLicenseId(this.currentLicenseId);

            for (int i = 0; i < acts.Length; i++)
            {
                UltraListViewItem item = ulvActivations.Items.Add(acts[i].ID.ToString(), acts[i].ActivationCode);
                item.SubItems[0].Value = acts[i].ExpirationDate.ToShortDateString();
                item.SubItems[1].Value = acts[i].IsActivated;
                item.SubItems[2].Value = acts[i].Enabled;
            }
        }

        private void btnSaveLicenseRecord_Click(object sender, EventArgs e)
        {
            //save license to web service
            LicenseFeaturesParams p = new LicenseFeaturesParams();

            p.LicenseKey = this.txtLicenseSerialNumber.Text;
            p.ClientName = this.ddlClients.Text;
            p.SiteName = this.ddlSites.Text;
            p.ClientID = this.ddlClients.SelectedItem != null ? Convert.ToInt32((this.ddlClients.SelectedItem as Client).ID) : -1;
            p.SiteID = this.ddlSites.SelectedItem != null ? Convert.ToInt32((this.ddlSites.SelectedItem as Site).ID) : -1;
            p.GeneratedBy = this.txtGeneratedBy.Text;
            p.GeneratedDate = DateTime.Now;
            p.LicenseType = this.rbCPULic.Checked ? LicenseType.CPU : LicenseType.Site;
            p.ExpirationDate = this.dtExpirationDate.Value;
            p.ExpirationWarningStartDate = this.dtExpirationWarningsBeginDate.Value;
            p.ExpirationWarningsMode = this.getExpirationWarningType();
            p.ExpirationWarningsFrequency = Convert.ToInt32(nmExpirationWarningsFrequency.Value);
            p.ExpirationWarningsUnit = this.cbExpirationWarningsFrequency.Text;
            p.AllowedWasteClassses = this.getAllowedWasteClasses();
            p.ProductVersionName = this.txtProductVersionName.Text;
            p.NumberOfSites = (int)this.nmNumberOfSites.Value;
            p.DefaultUserLevel = this.getDefaultUserLevel();
            p.ManagerPassword = this.txtManagerPassword.Text;
            p.AdministratorPassword = this.txtAdministratorPassword.Text;
            p.UseConfigurator = this.chkUseConfiguratorIfInstalled.Checked;
            p.ManageTypesAvailable = this.chkManageTypesAvailable.Checked;
            p.ManageTrackers = this.chkManageTrackersAvailable.Checked;
            p.ManageSites = this.chkManageSitesAvailable.Checked;
            p.ManageEventTypes = this.chkManageEventTypes.Checked;
            p.ManageEventClients = this.chkManageEventClientsAvailable.Checked;
            p.ManageEventOrders = this.chkManageEventOrdersAvailable.Checked;
            p.ManagePreferences = this.chkManagePreferencesAvailable.Checked;
            p.ManageBaselines = this.ChkManageBaselinesAvailable.Checked;
            p.FoodCostAdjustments = this.chkManageFoodCostAdjustmentsAvailable.Checked;
            p.AddUsers = this.chkAddUsers.Checked;
            p.RemoveUsers = this.chkRemoveUsers.Checked;
            p.TrackerLimit = Convert.ToInt32(this.nmTrackerLimit.Value);
            p.FoodTypeLimit = Convert.ToInt32(this.nmFoodTypeLimit.Value);
            p.LossTypeLimit = Convert.ToInt32(this.nmLossTypeLimit.Value);
            p.UserTypeLimit = Convert.ToInt32(this.nmUserTypeLimit.Value);
            p.UpdateTracker = this.chkUpdateTrackerAvailable.Checked;
            p.ImportWasteData = this.chkImportDataAvailable.Checked;
            p.RecurringTransactionsAvailable = this.chkManageRecurringTransactionsAvailable.Checked;
            p.ManageDataEntryTemplates = this.chkIncludeDET.Checked;
            p.ConfigureStationEntry = this.chkConfigureStationAvailable.Checked;
            p.ConfigureDaypartEntry = this.chkConfigureDaypartAvailable.Checked;
            p.ConfigureDispositionEntry = this.chkConfigureDispositionAvailable.Checked;
            p.ConfigurePrePostEntry = this.chkConfigurePrePostAvailable.Checked;
            p.EnterLogSheetData = this.chkEnterLogSheetData.Checked;
            p.StationEntry = this.chkStationEntryAvailable.Checked;
            p.DaypartEntry = this.chkDaypartEntryAvailable.Checked;
            p.DispositionEntry = this.chkDispositionEntryAvailable.Checked;
            p.PrePostEntry = this.chkPrePostEntryAvailable.Checked;
            p.ManageLogForms = this.chkIncludeManageForms.Checked;
            p.DetLimits = Convert.ToInt32(this.nmDETLimit.Value);
            p.AdvancedMenuAvailable = this.chkAdvancedMenuAvailable.Checked;
            p.EnterFinancialsAvailable = this.chkEnterMonthlyFinancialsAvailable.Checked;
            p.EnterSWATNotesAvailable = this.chkEnterSWATNotesAvailable.Checked;
            p.ManageReportsSettingsShortcut = this.chkManageReportSettingsShortcutShown.Checked;
            p.AddNewReport = this.chkAddNewReportsAvailable.Checked;
            p.AddNewCollection = this.chkAddNewReportCollectionAvailable.Checked;
            p.Clone = this.chkCloneReportAvailable.Checked;
            //double "new reports checkbox";
            p.ReportLimits = Convert.ToInt32(this.nmReportLimits.Value);
            p.ShowSupportEmailAddress = this.chkSupportEmailAddressShown.Checked;
            p.ShowSupportPhoneNumber = this.chkSupportPhoneNumberShown.Checked;
            p.ShowSupportWebSiteURL = this.chkSupportWebSiteShown.Checked;
            p.SupportEmailAddress = this.txtSupportEmailAddress.Text;
            p.SupportPhoneNumber = this.txtSupportPhoneNumber.Text;
            p.SupportWebSiteURL = this.txtSupportWebSiteURL.Text;
            p.Product = this.getProduct(cbProduct.SelectedIndex);
            p.ExtendedExpirationDate = p.ExpirationDate;

            string response = string.Empty;
            if (this.currentLicenseId == -1 || this.currentLicenseId == 0)
            {
                string result = licenseService.CreateLicense(p);
                if (Int32.TryParse(result, out this.currentLicenseId))
                    response = "Success";
                else
                    response = result;
            }
            else
            {
                p.LicenseID = this.currentLicenseId;
                response = licenseService.SaveLicense(p);
            }                       

            MessageBox.Show(response);
        }

        private DefaultUserLevelType getDefaultUserLevel()
        {
            switch (this.cbDefaultUserLevel.SelectedIndex)
            {
                case 0:
                    return DefaultUserLevelType.User;
                case 1:
                    return DefaultUserLevelType.Manager;
                case 2:
                    return DefaultUserLevelType.Administrator;
                default:
                    return DefaultUserLevelType.User;
            }    
        }

        private AllowedWasteClassesType getAllowedWasteClasses()
        {
            switch (this.cbAllowedWasteClasses.SelectedIndex)
            {
                case 0:
                    return AllowedWasteClassesType.Food;
                case 1:
                    return AllowedWasteClassesType.NonFood;
                case 2:
                    return AllowedWasteClassesType.AllWasteClasses;
                default:
                    return AllowedWasteClassesType.Food;
            }
        }

        private ExpirationWarningType getExpirationWarningType()
        {
            switch (this.cbExpirationWarningsMode.SelectedIndex)
            {
                case 0:
                    return ExpirationWarningType.OnProgramStart;
                case 1:
                    return ExpirationWarningType.OnProgramExit;
                case 2:
                    return ExpirationWarningType.OnProgramStartAndExit;
                case 3:
                    return ExpirationWarningType.DuringOperation;
                default:
                    return ExpirationWarningType.OnProgramStart;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LicenseUtility.TestMode = !LicenseUtility.TestMode;
            setTestMode();

            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = Application.StartupPath;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    string err = string.Empty;
            //    VWA4Common.Security.LicenseManager.LoadLicense(ofd.FileName, out err);
            //    SetTestModeLicenseValues frmTestValues = new SetTestModeLicenseValues(false);
            //    frmTestValues.ShowDialog();
            //}
        }

        private void setTestMode()
        {
            if(LicenseUtility.TestMode)
            {
                button2.ForeColor = Color.Green;
                this.Text = "LeanPath License Manager - Using Test Database";
                button2.Text = "Using Test Database";
            }
            else
            {
                button2.ForeColor = Color.Red;
                this.Text = "LeanPath License Manager - Using Production Database";
                button2.Text = "Using Production Database";
            }
            licenseService = LicenseUtility.GetWebService();
        }

	    private void button1_Click(object sender, EventArgs e)
        {
            ManageClientsSites frmMs = new ManageClientsSites();
            frmMs.FormClosing += new FormClosingEventHandler(frmMs_FormClosing);

            frmMs.ShowDialog();
        }

        void frmMs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.populateClients();
		}

		private void txtProductVersionName_Enter(object sender, EventArgs e)
		{
			txtProductVersionName.Select();
			txtProductVersionName.SelectAll();
		}

        private void btnManageUpdates_Click(object sender, EventArgs e)
        {
            //frmManageUpdates frm = new frmManageUpdates();
            var frm = new ManageUpdatesNew();
            frm.ShowDialog();
        }
	}
}
