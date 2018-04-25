using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace UserControls
{
	public partial class UCSetDisplayOptions : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		VWA4Common.CommonEvents commonEvents = null;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCSetDisplayOptions()
		{
			InitializeComponent();
		}
		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			_IsActive = true;
		}

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			pTaskHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
		}

		/// <summary>
		/// Load the Preferences data.  Standard method for UserControls interface.
		/// Call when loading task sheet, and whenever data has changed that would affect
		/// the Preferences.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			//			
			// Load Preferences data controls
			//
			rgFoodCostChart.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.DashboardFoodCostChartOn) ? 1 : 0;
			rgParticipationSummary.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.DashboardParticipationSummaryOn) ? 1 : 0;
			rgWasteSummary.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteSummaryOn) ? 1 : 0;
			rgWasteEquivalency.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn) ? 1 : 0;
			rgShortcuts.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.FooterShortcutsOn) ? 1 : 0;
			rgSettings.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.FooterSettingsOn) ? 1 : 0;
			rgDatabaseandLoginInfo.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn) ? 1 : 0;

			tWasteEquivalencyObjectName.Text = VWA4Common.GlobalSettings.DashboardWasteEquivalencyObjectName;
			rgWasteEquivalencyUnits.SelectedIndex = (VWA4Common.GlobalSettings.DashboardWasteEquivalencyUnits.ToLower()
				== "pounds") ? 1 : 0;
			tWasteEquivalencyDollars.Text = VWA4Common.GlobalSettings.DashboardWasteEquivalencyDollars;
			tWasteEquivalencyPounds.Text = VWA4Common.GlobalSettings.DashboardWasteEquivalencyPounds;
			// Load the image
			MemoryStream imgstream;
			byte[] bt;
			if (VWA4Common.Utilities.LoadFilefromDB("WasteEquivalencyImage.img", 0, out bt) > 0)
			{ // We successfully loaded a picture file from the DB
				imgstream = new MemoryStream(bt, 0, bt.Length);
				pbWasteEquivalencyImage.Image = Image.FromStream(imgstream);
				pbWasteEquivalencyImage.Refresh();
			}

			Initialized = true;
			
			CheckLabels();

		}
		public void SaveData()
		{ }
		public bool ValidateData()
		{ return true; }
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

		/// Event Handlers

		private void CheckLabels()
		{
			if (Initialized)
			{
				ultraLabel5.Visible = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString());
				tWasteEquivalencyObjectName.Visible = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString());
				ultraLabel11.Visible = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString());
				rgWasteEquivalencyUnits.Visible = bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString());
				pbWasteEquivalencyImage.Visible = rgWasteEquivalencyUnits.Visible;
				pWasteEquivalencyImage.Visible = rgWasteEquivalencyUnits.Visible;

				ultraLabel7.Visible = (bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString())
					&& ((string)rgWasteEquivalencyUnits.Properties.Items[rgWasteEquivalencyUnits.SelectedIndex].Value == "Dollars"));
				tWasteEquivalencyDollars.Visible = ultraLabel7.Visible;

				ultraLabel8.Visible = (bool.Parse(VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn.ToString())
					&& ((string)rgWasteEquivalencyUnits.Properties.Items[rgWasteEquivalencyUnits.SelectedIndex].Value == "Pounds"));
				tWasteEquivalencyPounds.Visible = ultraLabel8.Visible;
			}
		}
		
		private void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) 
				commonEvents.TaskSheetKey = "dashboard";
			CheckLabels();
		}




		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void rgFoodCostChart_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardFoodCostChartOn =
								 rgFoodCostChart.Properties.Items[rgFoodCostChart.SelectedIndex].Value.ToString();
			}
		}

		private void rgParticipationSummary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardParticipationSummaryOn =
								 rgParticipationSummary.Properties.Items[rgParticipationSummary.SelectedIndex].Value.ToString();
			}
		}

		private void rgWasteSummary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteSummaryOn =
								 rgWasteSummary.Properties.Items[rgWasteSummary.SelectedIndex].Value.ToString();
			}
		}

		private void rgWasteEquivalency_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteEquivalencyOn =
								 rgWasteEquivalency.Properties.Items[rgWasteEquivalency.SelectedIndex].Value.ToString();
			}
			CheckLabels();
		}

		private void rgShortcuts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.FooterShortcutsOn =
								 rgShortcuts.Properties.Items[rgShortcuts.SelectedIndex].Value.ToString();
				commonEvents.DisplayOptionsInvalidate = true; // fire display invalidate event to update displays
			}
		}

		private void rgSettings_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.FooterSettingsOn =
								 rgSettings.Properties.Items[rgSettings.SelectedIndex].Value.ToString();
			commonEvents.DisplayOptionsInvalidate = true; // fire display invalidate event to update displays
			}
		}

		private void rgDatabaseandLoginInfo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn =
								 rgDatabaseandLoginInfo.Properties.Items[rgDatabaseandLoginInfo.SelectedIndex].Value.ToString();
			commonEvents.DisplayOptionsInvalidate = true; // fire display invalidate event to update displays
			}
		}

		private void rgWasteEquivalencyUnits_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteEquivalencyUnits =
								rgWasteEquivalencyUnits.Properties.Items[rgWasteEquivalencyUnits.SelectedIndex].Value.ToString();
				CheckLabels();
			}
		}

		private void tWasteEquivalencyObject_AfterExitEditMode(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteEquivalencyObjectName = tWasteEquivalencyObjectName.Text;
			}
		}


		private void tWasteEquivalencyPounds_Validated(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteEquivalencyPounds = tWasteEquivalencyPounds.Text;
			}
		}
		
		private void tWasteEquivalencyDollars_Validated(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.DashboardWasteEquivalencyDollars = tWasteEquivalencyDollars.Text;
			}
		}
		
		private void bWasteEquivalencyImage_Click(object sender, EventArgs e)
		{
			MemoryStream imgstream;
			getandsavelogofile("WasteEquivalencyImage.img", out imgstream);
			if (imgstream != null)
			{
				// Load it into the picture box
				pbWasteEquivalencyImage.Image = Image.FromStream(imgstream);
				pbWasteEquivalencyImage.Refresh();
			}
		}
		private void getandsavelogofile(string dbfilename, out MemoryStream imgstream)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.Title = "Select Image File";
			fd.Filter = "Image (*.GIF)|*.gif|(*.JPG)|*.jpg";
			// InitialDirectory = current database directory
			if (VWA4Common.AppContext.DBPathName != "")
			{ // a database is open - use its path as initial
				fd.InitialDirectory = Path.GetDirectoryName(VWA4Common.AppContext.DBPathName);
			}
			fd.Multiselect = false;
			if (fd.ShowDialog() == DialogResult.OK)
			{
				// A file was selected - get the file data
				byte[] filedata = VWA4Common.Utilities.ReadFile(fd.FileName);
				// Load it into the picture box
				imgstream = new MemoryStream(filedata, 0, filedata.Length);
				// Check to see if this filename/site combination already exists
				bool isNew = true;
				string sql = "SELECT ID FROM Files WHERE (Filename = '" + dbfilename + "') AND (SiteID = 0"
					+ ")";
				DataTable dt_files = VWA4Common.DB.Retrieve(sql);
				if (dt_files.Rows.Count > 0)
				{ // File entry already exists - need to update rather than insert
					isNew = false;
				}

				// attempt to load it into the database
				int id = VWA4Common.Utilities.SaveFiletoDB(dbfilename, "Image", filedata, isNew,
					0);
			}
			else
			{
				imgstream = null;
			}
		}


		/// <summary>
		/// Validate Cost for a textbox control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDECurrency_Validating(object sender, CancelEventArgs e)
		{
			// First, Strip off the $ if there is one.
			string editvalue = (sender as TextEdit).EditValue.ToString();
			editvalue = editvalue.Replace("$", "");
			decimal dresult;
			// Now see if we have a valid decimal value
			if (decimal.TryParse(editvalue, out dresult))
			{ // successful - valid
				(sender as TextEdit).EditValue =
					"$ " + dresult.ToString("####0.00");
				//bCancel.Show();
				//bSave.Show();
			}
			else
			{ // failed - go back to old value
				MessageBox.Show("'" + (sender as TextEdit).EditValue.ToString() + "' is not a valid currency value.");
				e.Cancel = true;
			}

		}
		/// <summary>
		/// Validate Decimal Value for a textbox control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDEDecimal_Validating(object sender, CancelEventArgs e)
		{
			string editvalue = (sender as TextEdit).EditValue.ToString();
			decimal dresult;
			// Now see if we have a valid decimal value
			if (decimal.TryParse(editvalue, out dresult))
			{ // successful - valid
				return;
			}
			else
			{ // failed - go back to old value
				MessageBox.Show("'" + (sender as TextEdit).EditValue.ToString() + "' is not a valid decimal value.");
				e.Cancel = true;
			}

		}
		
		/// <summary>
		/// Initiate Validation on Enter Key
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDETextbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == Keys.Enter.ToString())
			{
				DevExpress.XtraEditors.TextEdit te = (DevExpress.XtraEditors.TextEdit)sender;
				te.DoValidate();
			}
		}

	}
}
