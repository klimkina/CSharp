using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinListView;

namespace UserControls
{
	public partial class frmOpenExistingSession : Form
	{
		public frmOpenExistingSession()
		{
			InitializeComponent();
			Init();
		}

		public void Init()
		{
			updateProductUI();
			// Load up the Listview

			// Set the control's View property to 'Details'
			ulvSessions.View = UltraListViewStyle.Details;

			// Set some properties so that SubItems (and their respective
			// columns) are visible by default in the views that support
			// columns, and also, make the column names and sub-item
			// values not appear in tooltips by default.
			ulvSessions.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
			ulvSessions.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
			//ulvSessions.ViewSettingsTiles.SubItemsVisibleByDefault = true;
			ulvSessions.ItemSettings.SubItemsVisibleInToolTipByDefault = false;

			// Add columns in listview
			ulvSessions.MainColumn.Text = "Session ID";
			ulvSessions.MainColumn.DataType = typeof(System.Int32);
			ulvSessions.MainColumn.Width = 65; 
			UltraListViewSubItemColumn subItemColumn = null;
			subItemColumn = ulvSessions.SubItemColumns.Add("DataFromDate");
			subItemColumn.DataType = typeof(System.DateTime);
			subItemColumn.Text = "Data From";
			subItemColumn.HeaderAppearance.TextHAlign = HAlign.Center;
			subItemColumn.Width = 70;
			subItemColumn = ulvSessions.SubItemColumns.Add("SessionEnd");
			subItemColumn.DataType = typeof(System.DateTime);
			subItemColumn.Text = "Last Entry";
			subItemColumn.HeaderAppearance.TextHAlign = HAlign.Center;
			subItemColumn.Width = 70;
			subItemColumn = ulvSessions.SubItemColumns.Add("TransCount");
			subItemColumn.DataType = typeof(System.Int32);
			subItemColumn.Text = "Transactions";
			subItemColumn.HeaderAppearance.TextHAlign = HAlign.Center;
			subItemColumn.Width = 70;
			subItemColumn = ulvSessions.SubItemColumns.Add("User");
			subItemColumn.DataType = typeof(System.String);
			subItemColumn.Text = "User";
			subItemColumn.HeaderAppearance.TextHAlign = HAlign.Left;
			//subItemColumn = ulvSessions.SubItemColumns.Add("SessionNotes");
			//subItemColumn.DataType = typeof(System.String);
			//subItemColumn.Text = "Session Notes";

			// Get all manual data entry sessions and add them to list view control collection
			string sql = @"SELECT * FROM Transfers WHERE ManualDESession=TRUE ORDER BY Timestamp DESC";
			DataTable dtsess = new DataTable();
			dtsess = VWA4Common.DB.Retrieve(sql);
			foreach (DataRow row in dtsess.Rows)
			{
				string sessionID = row["TransKey"].ToString();
				DateTime timestamp = DateTime.Parse(row["Timestamp"].ToString());
				DateTime sessionend;
				DateTime.TryParse(row["SessionEnd"].ToString(), out sessionend);
				string username = "";
				if (row["User"].ToString().Trim() != string.Empty)
				{
					string sql2 = @"SELECT TypeName FROM UserType WHERE TypeID = '" + row["User"].ToString() + "'";
					DataTable dtuser = new DataTable();
					dtuser = VWA4Common.DB.Retrieve(sql2);
					if (dtuser.Rows.Count > 0)
					{
						DataRow row2 = dtuser.Rows[0];
						username = row2["TypeName"].ToString();
					}
				}
				string sql3 = @"SELECT COUNT(*) FROM Weights WHERE TransKey=" + sessionID.ToString();
				DataTable dttrans = new DataTable();
				dttrans = VWA4Common.DB.Retrieve(sql3);
				string sessionnotes = row["SessionNotes"].ToString();

				UltraListViewItem item = ulvSessions.Items.Add(sessionID, sessionID);
				item.SubItems["DataFromDate"].Value = timestamp;
				item.SubItems["DataFromDate"].Appearance.TextHAlign = HAlign.Center;
				item.SubItems["SessionEnd"].Value = sessionend;
				item.SubItems["SessionEnd"].Appearance.TextHAlign = HAlign.Center;
				item.SubItems["TransCount"].Value = int.Parse(dttrans.Rows[0][0].ToString());
				item.SubItems["TransCount"].Appearance.TextHAlign = HAlign.Center;
				item.SubItems["User"].Value = username;
				//item.SubItems["SessionNotes"].Value = sessionnotes;

			}
			
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

		private void ulvSessions_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			bDone.Show();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			int sessID = int.Parse(ulvSessions.SelectedItems[0].Value.ToString());

			VWA4Common.GlobalSettings.SessionOpen = sessID;
			DialogResult = DialogResult.OK;
		}

		private void lCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}


	}
}
