using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmEnterCurrTransTimestamp : Form
	{
		public DateTime DateSelected
		{
			get
			{
				return deTransactionDate.DateTime;
			}
		}
		public DateTime TimeSelected
		{
			get
			{
				return teTransactionTime.Time;
			}
		}

		public string DateTimeSelectedString
		{
			get
			{
				return deTransactionDate.DateTime.ToShortDateString() + " "
					+ teTransactionTime.Time.ToShortTimeString();
			}
		}

		public frmEnterCurrTransTimestamp()
		{
			InitializeComponent();
			bSave.Hide();
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		public frmEnterCurrTransTimestamp(DateTime dtprefill)
		{
			InitializeComponent();
			bSave.Hide();
			if (dtprefill.Date > DateTime.MinValue)
			{
				deTransactionDate.DateTime = dtprefill.Date;
				teTransactionTime.Time = DateTime.Parse(dtprefill.ToShortTimeString());
				bSave.Show();
			}
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		private void bYesterday_Click(object sender, EventArgs e)
		{
			deTransactionDate.DateTime = DateTime.Now.AddDays(-1);
			bSave.Show();
		}

		private void bToday_Click(object sender, EventArgs e)
		{
			deTransactionDate.DateTime = DateTime.Now;
			bSave.Show();
		}

		private void bNow_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Now;
		}

		private void b6AM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("06:00:00");
		}

		private void b9AM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("09:00:00");
		}

		private void b12AM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("12:00:00");
		}

		private void b3PM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("15:00:00");
		}

		private void b6PM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("18:00:00");
		}

		private void b9PM_Click(object sender, EventArgs e)
		{
			teTransactionTime.Time = DateTime.Parse("21:00:00");
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			// Save Date and Time
			VWA4Common.GlobalSettings.frmPicker_TimestampSelected =
				deTransactionDate.DateTime.ToShortDateString() + " "
				+ teTransactionTime.Time.ToShortTimeString();
			DialogResult = DialogResult.OK;

		}

		private void deTransactionDate_EditValueChanged(object sender, EventArgs e)
		{
			bSave.Show();
		}

	}
}
