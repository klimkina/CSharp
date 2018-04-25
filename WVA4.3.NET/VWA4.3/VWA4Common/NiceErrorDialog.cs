using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4Common
{
	public partial class NiceErrorDialog : Form
	{
		public NiceErrorDialog(string errorleadin, string errormessage, string bok_text, string bcancel_text, string menutext)
		{
			InitializeComponent();
			lErrorLeadin.Text = errorleadin;
			lErrorMessage.Text = errormessage;
			this.Text = menutext;
			bOK.Text = bok_text;
			bCancel.Text = bcancel_text;

		}

		public NiceErrorDialog(string errorleadin, string errormessage, string bok_text, string bcancel_text)
		{
			InitializeComponent();
			lErrorLeadin.Text = errorleadin;
			lErrorMessage.Text = errormessage;
			this.Text = VWA4Common.GlobalSettings.ProductName;
			bOK.Text = bok_text;
			bCancel.Text = bcancel_text;

		}

		private void bOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

	}
}
