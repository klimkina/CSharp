using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4
{
	public partial class frmCPUID : Form
	{
		string cpuid;
			
		public frmCPUID()
		{
			InitializeComponent();
			cpuid = VWA4Common.GlobalSettings.GetCPUID();
			//MessageBox.Show("CPU ID of this PC:  " + cpuid, "PC Hardware Information");
			lCPU_IDstring.Text = cpuid;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;

		}

		private void bDone_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void bCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(cpuid);

		}
	}
}
