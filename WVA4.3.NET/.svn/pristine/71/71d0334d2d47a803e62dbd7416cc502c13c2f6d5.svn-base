using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;


namespace VWA4Common.Security
{
	public partial class Activation : Form
	{
		string cpuid;
		public Activation()
		{
			InitializeComponent();
			cpuid = VWA4Common.GlobalSettings.GetCPUID();
			//MessageBox.Show("CPU ID of this PC:  " + cpuid, "PC Hardware Information");
			lCPUID.Text = cpuid;
			lLicenseID.Text = VWA4Common.Security.LicenseManager.GetValue("LicenseID");
			tActivationID.Text = "";
            bActivateManually.Enabled = false;
		}

        void tActivateManually_TextChanged(object sender, EventArgs e)
        {
            if (bActivateManually.Text.Length > 0)
                bActivateManually.Enabled = true;
            else
                bActivateManually.Enabled = false;
        }

		private void bDone_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void bCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(cpuid);
		}

		private void bActivateManually_Click(object sender, EventArgs e)
		{
            //manual activation
			if (tActivationID.Text.Length < 10)
			{
				MessageBox.Show("Invalid Activation Code!",
						"LeanPath Licensing System");
				return;
			}

            string licenseId = LicenseManager.GetValue("LicenseID");
			/// Let's see if the Activation code is correct for this CPU and License file
            if (LicenseManager.CheckLicenseId(licenseId, tActivationID.Text) && LicenseManager.CheckCPUId(this.lCPUID.Text, tActivationID.Text))
            {
                // Activation code is valid for this license and this PC, save it and proceed
                DateTime originalExpirationDate = DateTime.Parse(LicenseManager.GetValue("ExpirationDate"), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                DateTime originalWarningsBeginDate = DateTime.Parse(LicenseManager.GetValue("ExpirationWarningsBeginDate"), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                DateTime newExpirationDate = DateTime.Parse(LicenseManager.GetExpirationDate(this.lCPUID.Text, licenseId, tActivationID.Text), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                DateTime newWarningsBeginDate = DateTime.Parse(LicenseManager.GetExpirationWarningsBeginDate(this.lCPUID.Text, this.lLicenseID.Text, tActivationID.Text), CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);

				VWA4Common.Security.LicenseManager.SetValue("ActivationCode", tActivationID.Text);
                VWA4Common.Security.LicenseManager.SetValue("ExpirationDate", newExpirationDate.ToString());
                VWA4Common.Security.LicenseManager.SetValue("ExpirationWarningsBeginDate", newWarningsBeginDate.ToString());
                VWA4Common.Security.LicenseManager.SetValue("IsActivated", "True");
                
                LicenseManager.SaveLicense();
                LicenseManager.LoadLicense();

				MessageBox.Show("License was activated successfully.", "LeanPath Licensing System");
				DialogResult = DialogResult.OK;
            }
			else
			{
				// Activation code is NOT valid for this license and/or this PC
				MessageBox.Show("License ID and/or CPU ID do not match Activation Code!\nPlease contact LeanPath Customer Support for assistance.",
				"LeanPath Licensing System");
			}
		}

		private void bActivatebyInternet_Click(object sender, EventArgs e)
		{
            //internet activation
            if (LicenseManager.ActivateLicense(Convert.ToInt32(LicenseManager.GetValue("LicenseRecordID")), cpuid))
            {
                if (LicenseManager.CheckLicenseId(LicenseManager.GetValue("LicenseID"), LicenseManager.GetValue("ActivationCode")) && LicenseManager.CheckCPUId(cpuid, LicenseManager.GetValue("ActivationCode")))
                {
                    //license id and cpu match activation code                    
                    LicenseManager.SaveLicense();
                    LicenseManager.LoadLicense();
					MessageBox.Show("License was activated successfully.", "LeanPath Licensing System");
					DialogResult = DialogResult.OK;
				}
                else
                {
                    MessageBox.Show("License ID and/or CPU ID do not match Activation Code!\nPlease contact LeanPath Customer Support for assistance.",
				        "LeanPath Licensing System");
                }
            }
            else
            {
                MessageBox.Show("Remote activation attempt was unsuccessful!\nPlease contact LeanPath Customer Support for assistance.",
					"LeanPath Licensing System");
            }           
		}

		private void bLicenseID_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lLicenseID.Text);
		}

		private void bCPUID_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(cpuid);

		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
