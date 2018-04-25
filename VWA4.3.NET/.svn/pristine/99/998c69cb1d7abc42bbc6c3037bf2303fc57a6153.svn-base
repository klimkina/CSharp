using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4
{
	public partial class frmLicenseInfo : Form
	{

		public frmLicenseInfo()
		{
			InitializeComponent();
			lLicense_IDstring.Text = VWA4Common.Security.LicenseManager.GetValue("LicenseID");
			lExpirationDate.Text = VWA4Common.Security.LicenseManager.GetValue("ExpirationDate");
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		private void bDone_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void bCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lLicense_IDstring.Text);

		}

		private void button1_Click(object sender, EventArgs e)
		{
			SetTestModeLicenseValues f = new SetTestModeLicenseValues(false);
			f.ShowDialog();
		}
	}
}
