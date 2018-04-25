using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LMan4.com.licensemanager4web;
using System.Globalization;

namespace LMan4
{
	public partial class AddActivation : Form
	{
		private LMan4.com.licensemanager4web.License license;
		private LMan4.com.licensemanager4web.LicenseFeaturesParams licenseFeatures;
		private LMan4.com.licensemanager4web.Activation activation;

	    private LicenseManagerWebService licenseService = LicenseUtility.GetWebService();

		public AddActivation(LMan4.com.licensemanager4web.License l, LMan4.com.licensemanager4web.LicenseFeaturesParams lf)
		{
			InitializeComponent();
            this.license = l;
            this.licenseFeatures = lf;

		    this.Text = "Add Activation Record";

            this.populateLicense();
		}

	    public override sealed string Text
	    {
	        get { return base.Text; }
	        set { base.Text = value; }
	    }

	    public AddActivation(LMan4.com.licensemanager4web.License l, LMan4.com.licensemanager4web.LicenseFeaturesParams lf, LMan4.com.licensemanager4web.Activation a)
        {
            InitializeComponent();
            this.license = l;
            this.licenseFeatures = lf;
            this.activation = a;

            this.populateLicense();
            this.populateActivation();

	        this.Text = "Edit Activation Record";
        }

        private void populateLicense()
        {
            this.lblLicenseSerialNumber.Text = license.LicenseID;
            this.lblExpirationDateBase.Text = licenseFeatures.ExpirationDate.ToShortDateString();
            this.lblExpirationWarningsStartDate.Text = licenseFeatures.ExpirationWarningStartDate.ToShortDateString();
            this.lblExpirationsWarningsMode.Text = licenseFeatures.ExpirationWarningsMode.ToString();
            this.lblExpirationWarningsFrequency.Text = string.Format("{0}{1}", licenseFeatures.ExpirationWarningsFrequency.ToString(), " - " + licenseFeatures.ExpirationWarningsUnit);
			dtExpirationDate.Value = licenseFeatures.ExpirationDate;
            dtExtendedExpirationDate.Value = licenseFeatures.ExtendedExpirationDate;
        }

        private void populateActivation()
        {
            this.txtCPUID.Text = this.activation.CPUID;
            this.lblActivationCode.Text = this.activation.ActivationCode;
            this.dtExpirationDate.Value = this.activation.ExpirationDate;
            this.chkIsEnabled.Checked = this.activation.Enabled;

            if (this.activation.CPUID != string.Empty)
            {
                this.txtCPUID.Enabled = false;
            }
        }
        
        private void btnActivationCode_Click(object sender, EventArgs e)
        {
            string res = GenerateActivationCode();
            if (res != "")
            {
                lblActivationCode.Text = res;
                this.btnActivationCode.Enabled = false;
                this.txtCPUID.Enabled = false;
            }
            else
            {
                MessageBox.Show(this, "Please enter correct CPU ID and License Serial Number", "Activation Code Generation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateActivationCode()
        {
            string res = "";
            if (txtCPUID.Text.Trim().Length > 4)
            {
                res = VWA4Common.Security.LicenseManager.GenerateActivationCode(txtCPUID.Text, license.LicenseID.ToString(),
                    dtExpirationDate.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")), dtExtendedExpirationDate.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")));
            }
            return res;
        }
        
        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Would you like to save activation before closing window?", "Save Activation", MessageBoxButtons.YesNoCancel);
            if (dr.Equals(DialogResult.Yes))
            {
                this.SaveActivation();
                Close();
            }
            else if (dr.Equals(DialogResult.No))
            {
                Close();
            }
        }

        private string SaveActivation()
        {
            ActivationParams p = new ActivationParams();
            
            p.LicenseID = license.ID;
            p.GeneratedBy = license.GeneratedBy;
            p.ExpirationDate = dtExpirationDate.Value;
            p.ExpirationWarningsBeginDate = licenseFeatures.ExpirationWarningStartDate;
            p.ExtendedExpirationDate = dtExtendedExpirationDate.Value;
            p.ActivationCode = lblActivationCode.Text;
            p.CPUID = txtCPUID.Text;
            p.Enabled = chkIsEnabled.Checked;
            p.GeneratedTime = DateTime.Now;
            p.IsActivated = false;

            if (p.CPUID != string.Empty && p.ActivationCode != string.Empty)
            {
                p.IsActivated = true;
            }        

            if (this.activation != null)
            {
                p.ID = this.activation.ID;
                return licenseService.SaveActivation(p);
            }
            else
            {
                return licenseService.AddActivation(p);
            }            
        }

        private void btnGenerateActivatedLicense_Click(object sender, EventArgs e)
        {            
            int id = Convert.ToInt32(this.SaveActivation());
            this.activation = licenseService.GetActivationById(id);

            if (this.activation.CPUID == string.Empty || this.activation.ActivationCode == string.Empty)
            {
                MessageBox.Show("You must generate an activation code before activation.", "Error");
            }
            else
            {
                if (LicenseUtility.GenerateLicense(licenseFeatures, activation))
                {
                    MessageBox.Show("Success", "Generate License File");
                    this.Close();
                }
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.SaveActivation());
            this.activation = licenseService.GetActivationById(id);
            MessageBox.Show("Success", "Save Activation");
        }

		private void bCopyCPUIDtoClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lblActivationCode.Text);
		}

		private void bCopyActivationIDtoClipboard_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lblActivationCode.Text);
		}

        private void btnAddMonth_Click(object sender, EventArgs e)
        {
            this.addMonthsToExpiratonDate(1);
        }

        private void addMonthsToExpiratonDate(int months)
        {
            this.dtExpirationDate.Value = this.dtExpirationDate.Value.AddMonths(months);
            this.dtExtendedExpirationDate.Value = this.dtExtendedExpirationDate.Value.AddMonths(months);
        }

        private void btnAddThreeMonths_Click(object sender, EventArgs e)
        {
            this.addMonthsToExpiratonDate(3);
        }

        private void btnAddSixMonths_Click(object sender, EventArgs e)
        {
            this.addMonthsToExpiratonDate(6);
        }

        private void btnAddTwelveMonths_Click(object sender, EventArgs e)
        {
            this.addMonthsToExpiratonDate(12);
        }
	}
}