using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4Common
{
	public partial class DialogGet1LineofText : Form
	{
		public string sNewText = "";
		public bool bNewEnabled = false;

		public DialogGet1LineofText(string prompt, string textboxinitial, string menutext)
		{
			InitializeComponent();
			this.lPrompt.Text = prompt;
			this.tUserText.Text = textboxinitial;
			this.Text = menutext;
			checkBox1.Hide();
		}

		public DialogGet1LineofText(string prompt, string textboxinitial, string menutext,
			bool enabled, string enabledtext)
		{
			InitializeComponent();
			this.lPrompt.Text = prompt;
			this.tUserText.Text = textboxinitial;
			this.Text = menutext;
			checkBox1.Checked = enabled;
			checkBox1.Text = enabledtext;
			checkBox1.Show();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			sNewText = tUserText.Text;
			bNewEnabled = checkBox1.Checked;
			this.DialogResult = DialogResult.Cancel;
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			sNewText = tUserText.Text;
			bNewEnabled = checkBox1.Checked;
			this.DialogResult = DialogResult.OK;
		}

		private void tUserText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == "\r")
			{
				sNewText = tUserText.Text;
				bNewEnabled = checkBox1.Checked;
				this.DialogResult = DialogResult.OK;
			}
		}

	}
}
