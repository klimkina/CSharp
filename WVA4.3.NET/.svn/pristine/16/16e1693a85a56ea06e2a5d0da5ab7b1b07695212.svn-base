using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class UCManageEventOrders : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;
		// Buffers for holding the current Transaction's data
		string sEOTypeID;	// Holds the currenty Type ID for the EO - blank when not known yet
		string sClientID;	// Holds the ID for the currently selected client - blank when not known yet
		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageEventOrders()
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
				//dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.DBPathChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
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
			lTitle1.ForeColor = Color.Black;
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
		public void LoadData()
		{
			Initialized = false;
			// Load Data processing
			//
			// Load clients combo box
			InitClientsComboBox();

			
			lTitle1.Text = "(for " + VWA4Common.GlobalSettings.CurrentSiteName + ")";
			
			ClearSettings();
			Initialized = true;
		}

		public void SaveData()
		{
		}

		public bool ValidateData()
		{ return true; }


		///		
		/// Event Handlers and supporting routines
		///		
		private void ClearSettings()
		{
			deEODate.Text = "";
			nEONumber.Value = 0;
			ceGuestCount.Text = "";
			ceMFRatio.Text = "";
			teEventName.Text = "";
			teReportingEventName.Text = "";
			teEventDescription.Text = "";
			cbEventClient.SelectedIndex = -1;
			sClientID = "0";
			sEOTypeID = "";
			ucTreeView1.Hide();
			ckShowDisabledEOs.Hide();
			ckShowDisabledEOs.Checked = false;
			ckEOEnabled.Checked = true;
			lTreeTitle.Hide();
			nEONumber.Focus();
		}

		private void CheckReadytoSave()
		{
			// Are conditions met to enable the save button?
			if ((deEODate.Text != "") && (nEONumber.Value > 0) && (teEventName.Text != "") && (teReportingEventName.Text != ""))
			{
				bSave.Show();
			}
			else
			{
				bSave.Hide();
			}
		}
		private void InitClientsComboBox()
		{
			DataTable clientsDataTable = new DataTable();
			string sql = @"SELECT ID, ClientName FROM EventClients";
			clientsDataTable = VWA4Common.DB.Retrieve(sql);
			cbEventClient.Items.Clear();
			foreach (DataRow row in clientsDataTable.Rows)
			{
				// Put the TermName in the combobox - save the ID in the ItemData and the SiteID in Item2Data
				//cbEventClient.Items.Add(row["ClientName"]);
				cbEventClient.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row["ClientName"].ToString(),row["ID"].ToString(),""));
			}
			cbEventClient.Sorted = true;
			cbEventClient.SelectedIndex = -1;
		}

		private void cbEventClient_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				sClientID = ((VWA4Common.VWACommon.MyListBoxItem)cbEventClient.SelectedItem).ItemData;
			}
		}
	
		/// <summary>
		/// Save the data in the current form, into the database.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
		{
			Initialized = false;
			// Save the required fields
			//
			// Check TypeID
			if (sEOTypeID != "")
			{ // We have an already existing Type ID to use
				string sql = "UPDATE BEOType SET "
					+ " TypeName='" + teEventName.Text + "',"
					+ " ReportTypeName='" + teReportingEventName.Text + "',"
					+ " SpanishTypeName='" + teEventName.Text + "',"
					+ " Enabled=" + ckEOEnabled.Checked.ToString() + ","
					+ " ModifiedDate=#" + DateTime.Now.ToShortDateString() + "#,"
					+ " Description='" + teEventDescription.Text + "',"
					+ " EventDate=#" + deEODate.Text + "#,"
					+ " BEONumber='" + nEONumber.Value.ToString() + "',"	// BEONumber
					+ " GuestCount=" + ceGuestCount.Value.ToString() + ","
					+ " MRatio=" + ceMFRatio.Value.ToString() + ","
					+ " Client=" + sClientID
					+ " WHERE TypeID='" + sEOTypeID + "'";
				VWA4Common.DB.Update(sql);
			}
			else
			{ // We need to add a new record
				// Get the Quick Add Category
				int parentcatid = VWA4Common.Utilities.GetQuickAddCategory("BEOCategory", "(Manually Entered Event Orders)");

				// Get a TypeID
				sEOTypeID = GetNextEOKey();
				// 
				string sql = "INSERT INTO BEOType (TypeID,CatID,TypeName,"
					+ "ReportTypeName,SpanishTypeName,Rank,Enabled,"
					+ "ModifiedDate,Description,EventDate,BEONumber,GuestCount,MRatio,"
					+ "Client)"
					+ " VALUES('"
					+ sEOTypeID					// TypeID
					+ "'," + parentcatid.ToString()		// CatID - Manually Entered
					+ ",'" + teEventName.Text + "'"		// TypeName
					+ ",'" + teReportingEventName.Text + "'"	// ReportTypeName
					+ ",'" + teEventName.Text + "'"		// SpanishTypeName
					+ ",999999"							// Rank
					+ "," + ckEOEnabled.Checked.ToString()		// Enabled
					+ ",#" + DateTime.Now.ToShortDateString() + "#"	// ModifiedDate
					+ ",'" + teEventDescription.Text + "'"				// description
					+ ",#" + deEODate.Text + "#"				// EventDate
					+ ",'" + nEONumber.Value.ToString() + "'"	// BEONumber
					+ "," + ceGuestCount.Value.ToString()   // GuestCount
					+ "," + ceMFRatio.Value.ToString()		// MRatio
					+ "," + sClientID						// Client FK
					+ ")"
					;
				VWA4Common.DB.Insert(sql);
			}
			ClearSettings();
			Initialized = true;
		}

		/// <summary>
		/// Return a unique primary key for the BEOTypes table (for a new unique EO).
		/// </summary>
		/// <returns></returns>
		private string GetNextEOKey()
		{
			// Query for the highest TypeID that fits the pattern
			string stid = "";
			string sql = "SELECT Max(TypeID) AS TID FROM BEOType WHERE LEFT(TypeID,5) = 'ZBE_9';";
			DataTable temp = VWA4Common.DB.Retrieve(sql);
			if (temp != null && temp.Rows.Count > 0 && (temp.Rows[0]["TID"].ToString() !=""))
			{
				// We found the max Type ID
				// increment it by one
				string tsr = temp.Rows[0]["TID"].ToString().Substring(4, 9);
				int nnn = int.Parse(tsr) + 1;
				stid = "ZBE_" + nnn.ToString();
			}
			else
			{
				// No TypeID of the correct format is there, so start now
				stid = "ZBE_900000001";
			}
			return stid;
		}

		/// <summary>
		/// Load up the tree so user can pick an EO from the Type catalog.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bLoadEO_Click(object sender, EventArgs e)
		{
			lTreeTitle.Text = "Event Orders";
			ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
						"BEO", "0");
			ucTreeView1.TypeCatalogID = VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString();
			ucTreeView1.Reload();
			ucTreeView1.Show();
			lTreeTitle.Show();
			ckShowDisabledEOs.Show();
		}

		/// <summary>
		/// Load all EO data in response to the user selecting an EO from the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			Initialized = false;
			// Info from the tree itself
			sEOTypeID = e.ID;
			teEventName.Text = e.Name;
			// Now use this info to go get the rest of the info
			string sql = "SELECT * FROM BEOType WHERE TypeID='" + sEOTypeID + "'";
			DataTable temp = VWA4Common.DB.Retrieve(sql);
			if (temp != null && temp.Rows.Count > 0)
			{
				// Get the info from the record and load up the form

				deEODate.Text = temp.Rows[0]["EventDate"].ToString();
				if (deEODate.Text != "") deEODate.Text = DateTime.Parse(deEODate.Text).ToShortDateString();
				nEONumber.Value = int.Parse(temp.Rows[0]["BEONumber"].ToString());
				ceGuestCount.Text = temp.Rows[0]["GuestCount"].ToString();
				ceMFRatio.Text = temp.Rows[0]["MRatio"].ToString();
				teReportingEventName.Text = temp.Rows[0]["ReportTypeName"].ToString();
				teEventDescription.Text = temp.Rows[0]["Description"].ToString();
				sClientID = temp.Rows[0]["Client"].ToString();
				ckEOEnabled.Checked = bool.Parse(temp.Rows[0]["Enabled"].ToString());
				// Find the right Client to show in the combo box
				cbEventClient.SelectedIndex = -1;
				for (int i = 0; i < cbEventClient.Items.Count; i++)
				{
					//
					if (sClientID == ((VWA4Common.VWACommon.MyListBoxItem)cbEventClient.Items[i]).ItemData)
					{
						cbEventClient.SelectedIndex = i;
						break;
					}
				}
				bSave.Show();
			}
			else
			{
				MessageBox.Show("Error Retrieving Event Order Data!");
			}
			Initialized = true;
		}



		private void bYesterday_Click(object sender, EventArgs e)
		{
			deEODate.DateTime = DateTime.Now.AddDays(-1);
		}

		private void bToday_Click(object sender, EventArgs e)
		{
			deEODate.DateTime = DateTime.Now;
		}

		private bool nonNumberEntered;
		private void teEONumber_KeyDown(object sender, KeyEventArgs e)
		{
			nonNumberEntered = false;
			char myChar = Convert.ToChar(e.KeyCode);
			if (!Char.IsNumber(myChar)) nonNumberEntered = true;
		}

		private void teEONumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (nonNumberEntered) e.Handled = true;
		}

		private void bClearThisTransaction_Click(object sender, EventArgs e)
		{
			Initialized = false;
			ClearSettings();
			Initialized = true;
		}

		private void deEODate_EditValueChanged(object sender, EventArgs e)
		{
			CheckReadytoSave();
		}

		private void nEONumber_ValueChanged(object sender, EventArgs e)
		{
			CheckReadytoSave();
		}

		private void teEventName_EditValueChanged(object sender, EventArgs e)
		{
			CheckReadytoSave();
		}

		private void ucTreeView1_Leave(object sender, EventArgs e)
		{
			if (ucTreeView1.ID == "")
			{
				sEOTypeID = "";
			}
			ucTreeView1.Hide();
			lTreeTitle.Hide();
			ckShowDisabledEOs.Hide();
		}

		private void teReportingEventName_EditValueChanged(object sender, EventArgs e)
		{
			CheckReadytoSave();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			teReportingEventName.Text = teEventName.Text;
		}
        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
				ucTreeView1.TypeCatalogID = VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString();
                lTitle1.Text = "(for " + VWA4Common.GlobalSettings.CurrentSiteName + ")";
            }
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            commonEvents.TaskSheetKey = "dashboard";
        }

        private void ckEOEnabled_CheckedChanged(object sender, EventArgs e)
        {
            ucTreeView1.ShowDisabled = ckShowDisabledEOs.Checked;
        }
		private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // || !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Event Orders")))
				commonEvents.TaskSheetKey = "dashboard";
		}
	}
}
