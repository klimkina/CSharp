using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4
{
	public partial class ShowEULA : Form
	{
		public ShowEULA()
		{
			InitializeComponent();
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


		private void ShowEULA_Shown(object sender, EventArgs e)
		{
			rtDoc.LoadFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\VWA4.2EULA.rtf");
		}

		private void bOK_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
