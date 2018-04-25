using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmNewSession : Form
	{
		bool bdoneclicked = false;

		public frmNewSession()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			bDone.Hide();	// Can't be done until a Tracker is chosen
			updateProductUI();
			ucTrackercb.Init();
			deTransactionDate.DateTime = DateTime.Now;
		}

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


		private void bDone_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.SessionTracker_TermIDSelected = ucTrackercb.TrackerID;
			VWA4Common.GlobalSettings.SessionTracker_TermNameSelected = ucTrackercb.TrackerName;
			VWA4Common.GlobalSettings.SessionDataFromDate_DateSelected =
				deTransactionDate.DateTime.ToShortDateString() + " 12:00:00";
			//VWA4Common.GlobalSettings.SessionSiteID = ucTrackercb.Site;
			bdoneclicked = true;
			DialogResult = DialogResult.OK;
		}

		private void lCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void frmNewSession_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!bdoneclicked) DialogResult = DialogResult.Cancel;
			else DialogResult = DialogResult.OK;
		}

		private void ucTrackercb_TrackerChanged(object sender, UCTrackerPicker.TrackerEventArgs e)
		{
			checkDone();
		}

		private void checkDone()
		{
			bDone.Visible =
				((ucTrackercb.TrackerID != "") && (deTransactionDate.Text != ""));
		}

		private void deTransactionDate_DateTimeChanged(object sender, EventArgs e)
		{
			checkDone();
		}

		private void bYesterday_Click(object sender, EventArgs e)
		{
			deTransactionDate.DateTime = DateTime.Now.AddDays(-1);
		}

		private void bToday_Click(object sender, EventArgs e)
		{
			deTransactionDate.DateTime = DateTime.Now;
		}



		private void adjustDate(int dayofweek)
		{
			int delta = (int)DateTime.Now.DayOfWeek - dayofweek;
			if (delta > 0)
			{
				// Just subtract 
				deTransactionDate.DateTime = DateTime.Now.AddDays(-delta);
			}
			else
			{
				// subtract 
				deTransactionDate.DateTime = DateTime.Now.AddDays(-delta - 7);
			}
		}
		
		private void bMonday_Click(object sender, EventArgs e)
		{
			adjustDate(1);
		}

		private void bTuesday_Click(object sender, EventArgs e)
		{
			adjustDate(2);
		}

		private void bWednesday_Click(object sender, EventArgs e)
		{
			adjustDate(3);
		}

		private void bThursday_Click(object sender, EventArgs e)
		{
			adjustDate(4);
		}

		private void bFriday_Click(object sender, EventArgs e)
		{
			adjustDate(5);
		}

		private void bSaturday_Click(object sender, EventArgs e)
		{
			adjustDate(6);
		}

		private void bSunday_Click(object sender, EventArgs e)
		{
			adjustDate(0);
		}

	}
}
