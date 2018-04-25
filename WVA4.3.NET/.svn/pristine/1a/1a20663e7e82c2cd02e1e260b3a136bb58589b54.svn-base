using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmEnterLogProperties : Form
	{
		private Color _SessionBackColor;
		public Color SessionBackColor
		{
			get
			{
				return _SessionBackColor;
			}
		}
		private bool _ShowDataEntryBorders;
		public bool ShowDataEntryBorders
		{
			get
			{
				return _ShowDataEntryBorders;
			}
		}

		private string _DateFormat;
		public string DateFormat
		{
			get
			{
				return _DateFormat;
			}
		}
		private string _TimeFormat;
		public string TimeFormat
		{
			get
			{
				return _TimeFormat;
			}
		}

		public frmEnterLogProperties(Color sessionBackColor, bool bordersOn, string dateformat,
			string timeformat)
		{
			InitializeComponent();
			_SessionBackColor = sessionBackColor;
			_ShowDataEntryBorders = bordersOn;
			lFAreaBackcolor.BackColor = _SessionBackColor;
			ckBorders.Checked = bordersOn;
			if (dateformat.ToLower() == "short") cbDateFormat.SelectedIndex = 0;
			else cbDateFormat.SelectedIndex = 1;
			if (timeformat.ToLower() == "short") cbTimeFormat.SelectedIndex = 0;
			else cbTimeFormat.SelectedIndex = 1;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		private void lFAreaBackcolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				_SessionBackColor = cd.Color;
				lFAreaBackcolor.BackColor = cd.Color;
			}

		}

		private void bDone_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void ckBorders_CheckedChanged(object sender, EventArgs e)
		{
			_ShowDataEntryBorders = ckBorders.Checked;
		}

		private void cbDateFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDateFormat.SelectedIndex == 0) _DateFormat = "short";
			else _DateFormat = "long";
		}

		private void cbTimeFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTimeFormat.SelectedIndex == 0) _TimeFormat = "short";
			else _TimeFormat = "long";

		}
	}
}
