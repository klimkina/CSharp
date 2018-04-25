using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{

	public partial class UCHeader : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
        VWA4Common.DBDetector dbDetector = null;
		VWA4Common.TrackerDetector trackerDetector = null;
		VWA4Common.CommonEvents commonEvents = null;
		Color labeltextcolor;
		class ComboBoxItem
		{
			public string Name;
			public int Value;
			public ComboBoxItem(string Name, int Value)
			{
				this.Name = Name;
				this.Value = Value;
			}
			// override ToString() function
			public override string ToString()
			{
				return this.Name;
			}
		}


		/// Constructor
		public UCHeader()
		{
			InitializeComponent();
			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
			}
			if (trackerDetector == null)
			{
				trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();    // Get instance of event generator
				trackerDetector.FirstDayOfWeekChanged += new VWA4Common.FirstDayOfWeekDetectorEventHandler(trackerDetector_FirstDayOfWeekChanged);
			}
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			Initialized = false;

		}
		private static bool _IsFirstLoad = true;
		public void LoadData()
		{
			Initialized = false;
			// Load the current week control
			dtSelectedWeek.Value = DateTime.Parse(
				VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
			// code for setting PC's current date to  StartDateOfSelectedWeek
			if (_IsFirstLoad && dtSelectedWeek.Value.AddDays(7) < DateTime.Now.AddDays(-7))
			{
				VWA4Common.GlobalSettings.StartDateOfSelectedWeek =
					VWA4Common.VWACommon.DateToString(dtSelectedWeek.Value.AddDays(7 * (int)(DateTime.Now.Subtract(dtSelectedWeek.Value).Days / 7 - 1)));
				dtSelectedWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
			}
			_IsFirstLoad = false;
			//
			// Load the Site Chooser with all the sites and choose the current one
			// 
			cbSite.Items.Clear();
			DataTable siteDataTable = new DataTable();
			int i = 0;
			int currentsite = 0;
			string sql = @"SELECT ID, LicensedSite FROM Sites WHERE Active = True";
			siteDataTable = VWA4Common.DB.Retrieve(sql);
			foreach (DataRow row in siteDataTable.Rows)
			{
				i = cbSite.Items.Add(new ComboBoxItem(row["LicensedSite"].ToString(), (int)row["ID"]));
				// Remember which item is the current site
				if ((int)row["ID"] == VWA4Common.GlobalSettings.CurrentSiteID)
				{ // this is the current site
					currentsite = i;
				}
			}
			// Initialize to the current site
			if (cbSite.Items.Count > 0) cbSite.SelectedIndex = currentsite;

			Initialized = true;
		}
		public void SaveData()
		{ }
		public bool ValidateData()
		{ return true; }

		public void Init(DateTime firstDayOfWeek)
		{
			_IsActive = true;
		}

		public int AutoRun(string param)
		{
			return 0;
		}

		private bool _IsActive = false;
		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
		}
		public void LeaveSheet()
		{
			_IsActive = false;
		}

		///
		/// Methods for reconfiguring the header on the fly
		/// 
		//
		/// <summary>
		/// Reset the header to current personality/configuration.
		/// </summary>
		/// <param name="logo">1 => show VW logo; 3 => show WL logo; otherwise, show no logo</param>
		/// <param name="backcolor">color for background of the header</param>
		/// <param name="showcurrweek">true: show current week controls; false: hide 'em.</param>
		/// <param name="showsite">true: show current site controls; false: hide 'em.</param>
		public void resetHeader(int logo, Color backcolor)
		{
			switch (logo)
			{
				case 1:
					{
						pbWL.Hide();
						pbVW.Show();
						break;
					}
				case 3:
					{
						pbWL.Show();
						pbVW.Hide();
						break;
					}
				default:
					{
						pbWL.Hide();
						pbVW.Hide();
						break;
					}
			}

			this.BackColor = backcolor;
		}
		
		public void resetHeader(bool showcurrweek, bool showsite)
		{
			if (showcurrweek)
			{
				label1.Show();
				dtSelectedWeek.Show();
				pictureBox1.Show();
				pictureBox2.Show();
			}
			else
			{
				label1.Hide();
				dtSelectedWeek.Hide();
				pictureBox1.Hide();
				pictureBox2.Hide();
			}

			if (showsite)
			{
				ultraLabel4.Show();
				cbSite.Show();
			}
			else
			{
				ultraLabel4.Hide();
				cbSite.Hide();
			}
		}

		/// <summary>
		/// Process user changing the selected week.  Let the GlobalSettings ensure coherence of this date
		/// (i.e. make sure it is on the proper FirstDayOfWeek), then reset the control to get it coherent as well.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtSelectedWeek_ValueChanged(object sender, EventArgs e)
		{
			// changed this to CloseUp event to improve performance
		}

		private void dtSelectedWeek_CloseUp(object sender, EventArgs e)
		{
			if (Initialized)
			{
				updateSelectedWeek();
			}

		}

		private void updateSelectedWeek()
		{
			if (VWA4Common.GlobalSettings.FirstDayOfWeek != null)
				VWA4Common.GlobalSettings.StartDateOfSelectedWeek = dtSelectedWeek.Value.ToString("yyyy/MM/dd HH:mm:ss");
			dtSelectedWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
		}

		/// <summary>
		/// Process the application-level changing of CurrentSiteID.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbSite_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				ComboBoxItem cbi = (ComboBoxItem)cbSite.SelectedItem;
				VWA4Common.GlobalSettings.CurrentSiteID = cbi.Value;

				VWA4Common.DBDetector.GetDBDetector().SiteID = cbi.Value;
				LoadData();
			}
		}


		void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			LoadData();
		}
		void trackerDetector_FirstDayOfWeekChanged(object sender, VWA4Common.TrackerDetector.FirstDayOfWeekEventArgs e)
		{
			dtSelectedWeek.Value = dtSelectedWeek.Value.AddDays(e.FirstDayOfWeek - dtSelectedWeek.Value.DayOfWeek);
		}


		private void pbbackward_Click(object sender, EventArgs e)
		{
			// Pull the date backward a week
			dtSelectedWeek.Value = dtSelectedWeek.Value.AddDays(-7);
			updateSelectedWeek();
		}

		private void pbforward_Click(object sender, EventArgs e)
		{
			// Advance the date forward a week
			dtSelectedWeek.Value = dtSelectedWeek.Value.AddDays(7);
			updateSelectedWeek();
		}


		private void label2_MouseDown(object sender, MouseEventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
			Label lbl = (Label)sender;
			lbl.ForeColor = Color.Red;
		}

		private void label2_MouseUp(object sender, MouseEventArgs e)
		{
			Label lbl = (Label)sender;
			lbl.ForeColor = labeltextcolor;
		}

		private void lAnyNavLabel_MouseEnter(object sender, EventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
			Label lbl = (Label)sender;
			lbl.BorderStyle = BorderStyle.FixedSingle;
		}

		private void lAnyNavLabel_MouseLeave(object sender, EventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
		}
		private void pb_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			resetlabelborders();
			pb.BorderStyle = BorderStyle.FixedSingle;
			resetlabelcolors();
		}

		private void pb_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void pb_MouseEnter(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			resetlabelborders();
			pb.BorderStyle = BorderStyle.FixedSingle;
		}

		private void pb_MouseLeave(object sender, EventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
		}
		private void resetlabelborders()
		{
			pictureBox1.BorderStyle = BorderStyle.None;
			pictureBox2.BorderStyle = BorderStyle.None;
			//lHome.BorderStyle = BorderStyle.None;
		}
		private void resetlabelcolors()
		{
			//lHome.ForeColor = labeltextcolor;
		}

		private void NoNavControl_MouseEnter(object sender, EventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
		}

		private void setToLastWeekWithDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.StartDateOfSelectedWeek = 
				VWA4Common.Query.GetNewestWeightDataDateTime().ToString();
			dtSelectedWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
		}

		private void setToThisWeekToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.StartDateOfSelectedWeek =
				DateTime.Now.ToString();
			dtSelectedWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
		}

		private void setToFirstWeekWithDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.StartDateOfSelectedWeek =
				VWA4Common.Query.GetEarliestWeightDataDateTime().ToString();
			dtSelectedWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
		}

	}
}
