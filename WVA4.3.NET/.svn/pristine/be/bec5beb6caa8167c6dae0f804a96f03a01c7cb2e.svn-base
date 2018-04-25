using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinExplorerBar;

namespace UserControls
{
	public partial class UCManagePrefs : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		VWA4Common.CommonEvents commonEvents = null;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
		private VWA4Common.TrackerDetector trackerDetector = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManagePrefs()
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
			if (trackerDetector == null)
			{
				trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			ultraExplorerBar1.GroupSettings.Style = GroupStyle.SmallImagesWithText;
			ultraExplorerBar1.ImageListSmall = ItemSmallCheckBoxes;
			_IsActive = true;
		}

		/// <summary>
		/// Update the Task List Appearance based on current settings
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
			// Other stuff
			label1.BackColor = Color.LightBlue;
			label1.ForeColor = Color.Black;
			lSitePrefTitle.BackColor = Color.LightBlue;
			lSitePrefTitle.ForeColor = Color.Black;
			// Internal task explorer
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.BackColor =
				VWA4Common.GlobalSettings.ProductMenuBackgroundColor;
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.BackColor2 =
				VWA4Common.GlobalSettings.ProductMenuBackgroundColor;
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.ForeColor =
				VWA4Common.GlobalSettings.ProductTaskBarFontColor;
			ultraExplorerBar1.Appearance.BackColor =
				VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
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
			tPrimaryUserName.Text = VWA4Common.GlobalSettings.PrimaryUserName;
			tPrimaryUserEmail.Text = VWA4Common.GlobalSettings.PrimaryUserEmail;
			cbFirstDayofWeek.SelectedIndex = VWA4Common.Utilities.GetIndexfromDayName(
				VWA4Common.GlobalSettings.FirstDayOfWeek);
			rgActiveSyncTransfers.SelectedIndex = bool.Parse(VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn) ? 1 : 0;
			rgHideDisabledTasks.SelectedIndex = int.Parse(VWA4Common.GlobalSettings.HideDisabledTasks);
			cbCycleTime.SelectedIndex = VWA4Common.GlobalSettings.CycleTime - 1;
			// (SAR) Add ActiveSync control prefs 10/27/09
			tActiveSyncFolder.Visible = (rgActiveSyncTransfers.Properties.Items[rgActiveSyncTransfers.SelectedIndex].Value.ToString().ToLower()
								== "true");
			lActiveSyncTrackerTransferFolder.Visible = tActiveSyncFolder.Visible;
			tActiveSyncFolder.Text = VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder;
            nWeightImportThreshold.Value = decimal.Parse(VWA4Common.GlobalSettings.WeightImportThreshold);
            if (nWeightImportThreshold.Value == 0)
                nWeightImportThreshold.ForeColor = Color.Gray;
            nCostImportThreshold.Value = decimal.Parse(VWA4Common.GlobalSettings.CostImportThreshold);
            if (nCostImportThreshold.Value == 0)
                nCostImportThreshold.ForeColor = Color.Gray;
			lSitePrefTitle.Text = "Site Preferences for " +
				VWA4Common.GlobalSettings.CurrentSiteName;
			//pbTest.Image = Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream);
			
			CheckLabels();
			LoadTaskBarData();
			

			Initialized = true;
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

		private class mGroupItemTag
		{
			public int ID;
			public string UniqueName;
			public int ParentID;
			public int Rank;
			public bool Expanded;
			public bool Enabled;

			public mGroupItemTag(int id, string uniquename, int parentid, int rank, bool expanded, bool enabled)
			{
				ID = id;
				UniqueName = uniquename;
				ParentID = parentid;
				Rank = rank;
				Expanded = expanded;
				Enabled = enabled;
			}
		}

		///
		/// Task Bar Setup
		///

		private void LoadTaskBarData()
		{
			ultraExplorerBar1.Groups.Clear();
			// Assume the DB table is properly initialized
			//
			// Add Groups and Items (for those Groups that we find)
			//
			DataTable dtGroups = VWA4Common.DB.Retrieve("SELECT * FROM TaskItems WHERE ParentID = 0 ORDER BY Rank");
			foreach (DataRow row in dtGroups.Rows)
			{
				// Add the next group
				UltraExplorerBarGroup aGroup = new UltraExplorerBarGroup();
				aGroup = ultraExplorerBar1.Groups.Add();
				aGroup.Text = row["DisplayName"].ToString();
				string sssss = row["UniqueName"].ToString();
				bool grpenabled = bool.Parse(row["Enabled"].ToString());
				//aGroup.Expanded = bool.Parse(row["Expanded"].ToString());
				aGroup.Key = sssss;
				aGroup.Settings.AllowDrag = Infragistics.Win.DefaultableBoolean.True;
				int gpid = (int)row["ID"];
				
				aGroup.Tag = new mGroupItemTag(gpid, sssss, int.Parse(row["ParentID"].ToString()), 
					int.Parse(row["Rank"].ToString()), bool.Parse(row["Expanded"].ToString()), grpenabled);
				
				// Add Items under this Group
				DataTable dtItems = VWA4Common.DB.Retrieve("SELECT * FROM TaskItems WHERE ParentID = "
					+ gpid.ToString() + " ORDER BY Rank");
				foreach (DataRow irow in dtItems.Rows)
				{
					UltraExplorerBarItem anItem = new UltraExplorerBarItem();
					anItem.Checked = bool.Parse(irow["Enabled"].ToString());
					if ((!anItem.Checked && ((int.Parse(VWA4Common.GlobalSettings.HideDisabledTasks) == 2)
						&& !VWA4Common.GlobalSettings.IsSuper))
					  || !anItem.Checked && ((int.Parse(VWA4Common.GlobalSettings.HideDisabledTasks) == 1)
						&& (!VWA4Common.GlobalSettings.IsLogged && !VWA4Common.GlobalSettings.IsSuper))
						)
					{
						/// NOT going to show this task to the current user
						// So just don't add it
					}
					else
					{
						/// AM going to show this task to the current user
						anItem.Text = irow["DisplayName"].ToString();
						anItem.Key = irow["UniqueName"].ToString();
						anItem.Settings.AllowDragMove = ItemDragStyle.WithinAndAcrossGroups;
						if (anItem.Checked)
						{
							anItem.Settings.AppearancesSmall.Appearance.Image = 1;
						}
						else
						{
							anItem.Settings.AppearancesSmall.Appearance.Image = 0;
						}
						anItem.Tag = new mGroupItemTag(int.Parse(irow["ID"].ToString()), anItem.Key, int.Parse(irow["ParentID"].ToString()),
							int.Parse(irow["Rank"].ToString()), bool.Parse(irow["Expanded"].ToString()), anItem.Checked);
						// Add the Item to its group
						aGroup.Items.Add(anItem);
					}
				}
				if (grpenabled)
				{
					aGroup.Settings.AppearancesSmall.HeaderAppearance.FontData.Strikeout = Infragistics.Win.DefaultableBoolean.False;
					aGroup.Settings.AppearancesSmall.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
				}

				else
				{
					aGroup.Settings.AppearancesSmall.HeaderAppearance.FontData.Strikeout = Infragistics.Win.DefaultableBoolean.True;
					aGroup.Settings.AppearancesSmall.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
				}
			}
			ultraExplorerBar1.Groups.ExpandAll();
			ultraExplorerBar1.ActiveItem = null;
			this.ultraExplorerBar1.Update();
		}
		
		/// Event Handlers
		
		
		/// <summary>
		/// Code (from Infragistics) to show how to see if the item or the image was clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_MouseDown(object sender, MouseEventArgs e)
		{
			Infragistics.Win.UIElement lastElementEntered = ultraExplorerBar1.UIElement.LastElementEntered;
			Infragistics.Win.ImageUIElement imgUIElement;
			if (lastElementEntered is Infragistics.Win.ImageUIElement)
			{
				imgUIElement = (Infragistics.Win.ImageUIElement)lastElementEntered;
			}
			else
			{
				imgUIElement = (Infragistics.Win.ImageUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.ImageUIElement));
			}
			// The actual subsequent Click event will use this property value
			// to determine how to act.
			if (imgUIElement == null)
			{
				//MessageBox.Show("Item Clicked");
				VWA4Common.AppContext.TaskItemImageClicked = false;
			}
			else
			{
				//MessageBox.Show("Image Clicked");
				VWA4Common.AppContext.TaskItemImageClicked = true;
			}
		}


		private void ultraExplorerBar1_GroupClick(object sender, GroupEventArgs e)
		{
			UltraExplorerBarGroup anGroup = e.Group;
			mGroupItemTag tag = (mGroupItemTag) anGroup.Tag;
			string sql = "";
			try
			{
				// First need to make sure the user can change this Group
				if (VWA4Common.GlobalSettings.IsSuper
				  || VWA4Common.GlobalSettings.IsLogged)
				{
					if (anGroup.Items.Count == 0)
					{
						if (MessageBox.Show("No Tasks under this Group - Remove this Group permanently from the Task Bar?",
						   "No Tasks in Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							// Delete the Group
							sql = "DELETE FROM TaskItems WHERE ID=" + tag.ID + ";";
							VWA4Common.DB.Delete(sql);
							/// Update the local Taskbar
							LoadTaskBarData();
							/// Update the real Taskbar
							// UCTaskList is listening to week start event, so cause it to fire & reload
							trackerDetector.FireWeekStart();
							return;
						}
					}
					// If we get here, user just wants to rename the Group
					/// allow the current user to rename this Group
					/// Get current enabled setting
					sql = "SELECT * FROM TaskItems WHERE (ParentID = 0) AND UniqueName = '" + e.Group.Key + "';";
					DataTable dtGroups = VWA4Common.DB.Retrieve(sql);
					DataRow irow = dtGroups.Rows[0];
					bool enablesetting = bool.Parse(irow["Enabled"].ToString());
					int grpID = int.Parse(irow["ID"].ToString());

					/// Text was clicked, so change the name
					VWA4Common.DialogGet1LineofText dtb = new VWA4Common.DialogGet1LineofText(
						"Please type in the new Task Group Name below:",
						e.Group.Text, "Change Task Group Name", enablesetting, "Show Group in Task Bar");
					if (dtb.ShowDialog() == DialogResult.OK)
					{
						e.Group.Text = dtb.sNewText;
						bool grpenabled = dtb.bNewEnabled;
						dtb.Dispose();
						if (grpenabled)
							e.Group.Settings.AppearancesSmall.Appearance.FontData.Strikeout = Infragistics.Win.DefaultableBoolean.False;
						else
							e.Group.Settings.AppearancesSmall.Appearance.FontData.Strikeout = Infragistics.Win.DefaultableBoolean.True;
						// Update database with new name
						sql = "UPDATE TaskItems SET DisplayName = '"
						+ e.Group.Text + "', Uniquename = '" + e.Group.Text.ToLower() + "', Enabled = " + grpenabled.ToString() + " WHERE ID = " + grpID.ToString() + ";";
						VWA4Common.DB.Update(sql);
						if (!grpenabled)
						{
							sql = "UPDATE TaskItems SET Enabled = false WHERE ParentID = " + grpID.ToString()
								+ ";";
							VWA4Common.DB.Update(sql);
						}
						/// Update the local Taskbar
						LoadTaskBarData();
						/// Update the real Taskbar
						// UCTaskList is listening to week start event, so cause it to fire & reload
						trackerDetector.FireWeekStart();
					}
				}
				else
				{
					/// disallow the current user from checking or unchecking this Group
				}
			}
			finally
			{
				LoadTaskBarData();
			}
		}


		private void ultraExplorerBar1_ItemClick(object sender, ItemEventArgs e)
		{
			UltraExplorerBarItem anItem = e.Item;
			mGroupItemTag tag = (mGroupItemTag)anItem.Tag;
			string sql = "";
			try
			{
				// First need to make sure the user can change this Task
				// First, check whether the image or the text was clicked
				if (VWA4Common.AppContext.TaskItemImageClicked)
				{
					/// IMAGE was clicked - change the image
					// First need to make sure the user can change it
					if (VWA4Common.GlobalSettings.IsSuper
					  || VWA4Common.GlobalSettings.IsLogged)
					{
						/// allow the current user to check or uncheck this task

						anItem.Settings.AppearancesSmall.Appearance.Image =
							((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0) ? 1 : 0;
						if ((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0)
						{
							// Change Item to Not Enabled
							anItem.Checked = false;
							sql = "UPDATE TaskItems SET Enabled = false WHERE UniqueName = '" + anItem.Key + "';";
						}
						else
						{
							// Change Item to Enabled
							anItem.Checked = true;
							sql = "UPDATE TaskItems SET Enabled = true WHERE UniqueName = '" + anItem.Key + "';";
						}
						// Update Database
						VWA4Common.DB.Update(sql);
						commonEvents.UpdateProductUI = true;
						/// Update the Taskbar
						// UCTaskList is listening to week start event, so cause it to fire & reload
						trackerDetector.FireWeekStart();
					}
					else
					{
						/// disallow the current user from checking or unchecking this task
					}
				}
				else
				{
					/// Text was clicked, so change the name
					// First need to make sure the user can change it
					if (VWA4Common.GlobalSettings.IsSuper
					  || VWA4Common.GlobalSettings.IsLogged)
					{
						if (!anItem.Checked)
						{
							if (MessageBox.Show("This Task is currently disabled - Remove this Task permanently from the Task Bar?",
								"Disabled Task Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								// Delete the Task
								sql = "DELETE FROM TaskItems WHERE ID=" + tag.ID + ";";
								VWA4Common.DB.Delete(sql);

								/// Update the real Taskbar
								// UCTaskList is listening to week start event, so cause it to fire & reload
								trackerDetector.FireWeekStart();
								return;
							}
						}
						// If we get here, user just wants to rename the Group
						/// allow the current user to rename this task
						VWA4Common.DialogGet1LineofText dtb = new VWA4Common.DialogGet1LineofText(
											"Please type in the new Task Name below:",
											e.Item.Text, "Change Task Name");
						if (dtb.ShowDialog() == DialogResult.OK)
						{
							e.Item.Text = dtb.sNewText;
							dtb.Dispose();
							// Update database with new name
							sql = "UPDATE TaskItems SET DisplayName = '"
							+ e.Item.Text + "' WHERE UniqueName = '" + anItem.Key + "';";
							VWA4Common.DB.Update(sql);

							/// Update the Taskbar
							// UCTaskList is listening to week start event, so cause it to fire & reload
							trackerDetector.FireWeekStart();
						}
					}
					else
					{
						/// disallow the current user from checking or unchecking this task
					}
				}
			}
			finally
			{
				LoadTaskBarData();
			}
		}

		private void bHideAllTasks_Click(object sender, EventArgs e)
		{
			foreach (UltraExplorerBarGroup anGroup in ultraExplorerBar1.Groups)
			{
				foreach (UltraExplorerBarItem anItem in anGroup.Items)
				{
					anItem.Settings.AppearancesSmall.Appearance.Image = 0;
					anItem.Checked = false;
					// Update Database
					string sql = "UPDATE TaskItems SET Enabled = false WHERE UniqueName = '" + anItem.Key + "';";
					VWA4Common.DB.Update(sql);
				}
			}
			/// Update the Taskbar
			// UCTaskList is listening to week start event, so cause it to fire & reload
			trackerDetector.FireWeekStart();
		}

		private void bShowAllTasks_Click(object sender, EventArgs e)
		{
			foreach (UltraExplorerBarGroup anGroup in ultraExplorerBar1.Groups)
			{
				foreach (UltraExplorerBarItem anItem in anGroup.Items)
				{
					anItem.Settings.AppearancesSmall.Appearance.Image = 1;
					anItem.Checked = true;
					// Update Database
					string sql = "UPDATE TaskItems SET Enabled = true WHERE UniqueName = '" + anItem.Key + "';";
					VWA4Common.DB.Update(sql);
				}
			}
			/// Update the Taskbar
			// UCTaskList is listening to week start event, so cause it to fire & reload
			trackerDetector.FireWeekStart();
		}


			//public enum TaskSheetNamesInit
			//{
			//    ImportWaste,
			//    WeeklyReports,
			//   // Upload Waste not a task
			//    ReviewReports,
			//    ViewWaste,
			//    PrintSWAT,
			//    EnterSWATMinutes,
			//    PrintPreShift,
			//    EnterWasteData,
			//    ManageEventOrders,
			//    EnterFinancials,
			//    // "Other"			   
			//    ManageReports,
			//   // Manage Types
			//   // Manage Trackers
			//    PaperUIMgr,
			//    ManageAdjustments,
			//    BaselineMgr,
			//    ManageEventClients,
			//    AddUser,
			//    DeleteUser,
			//    // Compress Database
			//   // Log Off/On
			//   // Exit
			//   Dashboard,
			//    CustomReports, //mila added
			//    StoredReports,
			//    TransferConfig,
			//    ManagePreferences,
			//    DatabaseInfo,
			//    SetReportOptions,
			//    SetDisplayOptions
			//}

		private void bInitializeTaskBar_Click(object sender, EventArgs e)
		{
			// Warning dialog
			if (MessageBox.Show("Delete All Groups and Tasks from TaskBar, and Reload Defaults?",
				"TaskBar Initialization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{ // Return
				return;
			}
			// Otherwise, proceed
			int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
			int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;
			VWA4Common.ProgressDialog.ShowProgressDialog("Building Default TaskBar.", "", "", pd_left, pd_top);
			// Load TaskBar from Defaults
			//
			// Start over in TaskItems
			string sql = "DELETE FROM TaskItems;";
				VWA4Common.DB.Delete(sql);
			
			string groupsql1 = "INSERT INTO TaskItems(ParentID,UniqueName,DisplayName,Rank,Expanded,Enabled) VALUES(";
			string groupsql2 = ",true,true);";
			string groupsql;

			VWA4Common.ProgressDialog.SetLeadin("Adding Groups and Items...");
			VWA4Common.ProgressDialog.SetStatus("Track Group", 10);
			///**************
			/// Group: Track
			groupsql = groupsql1
				+ "0,'track','Track',"
				+ "0" + groupsql2;
			int gid = VWA4Common.DB.Insert(groupsql);
			int tid = 0;
			// Track Items
			if (VWA4Common.GlobalSettings.ImportWasteDataAvailable)
			{
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ImportWaste) + "','"
					+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ImportWaste) + "',"
					+ "0" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Track Items
			if (VWA4Common.GlobalSettings.AMWTAvailable)
			{
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.EnterWasteLogs) + "','"
					+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.EnterWasteLogs) + "',"
					+ "1" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Track Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.WeeklyReports) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.WeeklyReports) + "',"
				+ "2" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);	
			// Track Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ "uploadwastedata" + "','"
				+ "Upload Waste Data" + "',"
				+ "3" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);

			VWA4Common.ProgressDialog.SetStatus("Review Group", 15);
			///**************
			/// Group: Review
			groupsql = groupsql1
				+ "0,'review','Review',"
				+ "1" + groupsql2;
			gid = VWA4Common.DB.Insert(groupsql);
			// Review Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ReviewReports) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ReviewReports) + "',"
				+ "0" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);
			// Review Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ViewWaste) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ViewWaste) + "',"
				+ "1" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);

			VWA4Common.ProgressDialog.SetStatus("Discuss Group", 20);
			///**************
			/// Group: Discuss
			groupsql = groupsql1
				+ "0,'discuss','Discuss',"
				+ "2" + groupsql2;
			gid = VWA4Common.DB.Insert(groupsql);
			// Discuss Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.PrintSWAT) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.PrintSWAT) + "',"
				+ "0" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);
			// Discuss Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.EnterSWATMinutes) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.EnterSWATMinutes) + "',"
				+ "1" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);
			// Discuss Items
			groupsql = groupsql1
				+ gid.ToString() + ",'"
				+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.PrintPreShift) + "','"
				+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.PrintPreShift) + "',"
				+ "2" + groupsql2;
			tid = VWA4Common.DB.Insert(groupsql);

			VWA4Common.ProgressDialog.SetStatus("Other Group", 25);
			///**************
			/// Group: Other
			groupsql = groupsql1
				+ "0,'other','Other',"
				+ "3" + groupsql2;
			gid = VWA4Common.DB.Insert(groupsql);
			// Other Items
			if (VWA4Common.GlobalSettings.ManageReportsAvailable)
			{
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageReports) + "','"
					+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageReports) + "',"
					+ "0" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Other Items
			if (VWA4Common.GlobalSettings.AMWTAvailable && VWA4Common.GlobalSettings.ManageDETsAvailable)
			{
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageDETemplates) + "','"
					+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageDETemplates) + "',"
					+ "1" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Other Items
			if (VWA4Common.GlobalSettings.AMWTAvailable && VWA4Common.GlobalSettings.ManageLogFormsAvailable)
			{
				groupsql = groupsql1
							+ gid.ToString() + ",'"
							+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageLogForms) + "','"
							+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageLogForms) + "',"
							+ "2" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Other Items
			if (VWA4Common.GlobalSettings.ManageEventOrdersAvailable)
			{
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageEventOrders) + "','"
					+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageEventOrders) + "',"
					+ "3" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			// Other Items
			if (VWA4Common.GlobalSettings.EnterFinancialsAvailable)
			{
				groupsql = groupsql1
								+ gid.ToString() + ",'"
								+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.EnterFinancials) + "','"
								+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.EnterFinancials) + "',"
								+ "4" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
			}
			///******************************************
			VWA4Common.ProgressDialog.SetHideProgressNow(true);

			///******************************************
			///******************************************
			if (MessageBox.Show("Default Groups and Tasks Loaded into TaskBar.  Load Optional Tasks?",
				"TaskBar Initialization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{

				///
				/// Continue - add the optional tasks as well
				/// 
				VWA4Common.ProgressDialog.SetHideProgressNow(false);
				VWA4Common.ProgressDialog.SetStatus("Optional Tasks", 45);
				// Optional Items
				if (VWA4Common.GlobalSettings.ManageTypesAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ "managetypes" + "','"
						+ "Manage Types" + "',"
						+ "6" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.ManageSitesAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ "managesites" + "','"
						+ "Manage Sites" + "',"
						+ "7" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.ManageTrackersAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ "managetrackers" + "','"
						+ "Manage Trackers" + "',"
						+ "8" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.RecurringTransactionsAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageRecurringTransactions) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageRecurringTransactions) + "',"
						+ "9" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.FoodCostAdjustmentsAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageFoodCostAdjustments) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageFoodCostAdjustments) + "',"
						+ "10" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.ManageBaselinesAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.BaselineMgr) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.BaselineMgr) + "',"
						+ "11" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.ManageEventClientsAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.ManageEventClients) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.ManageEventClients) + "',"
						+ "12" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.AddUsersAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.AddUsers) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.AddUsers) + "',"
						+ "13" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				if (VWA4Common.GlobalSettings.RemoveUsersAvailable)
				{
					groupsql = groupsql1
						+ gid.ToString() + ",'"
						+ TaskSheets.GetTaskSheetUniqueName(TaskSheetNames.RemoveUsers) + "','"
						+ TaskSheets.GetTaskSheetDisplayName(TaskSheetNames.RemoveUsers) + "',"
						+ "14" + groupsql2;
					tid = VWA4Common.DB.Insert(groupsql);
				}
				// Optional Items
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ "compressdatabase" + "','"
					+ "Compress Database" + "',"
					+ "15" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);
				// Optional Items
				groupsql = groupsql1
					+ gid.ToString() + ",'"
					+ "exitvwa" + "','"
					+ "Exit " + VWA4Common.GlobalSettings.ProductName + "',"
					+ "16" + groupsql2;
				tid = VWA4Common.DB.Insert(groupsql);

			}
			VWA4Common.ProgressDialog.SetStatus("Loading TaskBar", 65);
			LoadTaskBarData();
			/// Update the Taskbar
			VWA4Common.ProgressDialog.SetStatus("Loading TaskBar", 75);
			// UCTaskList is listening to week start event, so cause it to fire & reload
			trackerDetector.FireWeekStart();
			VWA4Common.ProgressDialog.SetStatus("Loading TaskBar", 95);
			VWA4Common.ProgressDialog.CloseProgressForm();
		}

		private void bNewGroup_Click(object sender, EventArgs e)
		{
			VWA4Common.DialogGet1LineofText dtb = new VWA4Common.DialogGet1LineofText(
				"Please type in the new Task Group Name below:",
				"[New Group Name]", "Set Task Group Name", true, "Show Group in Task Bar");
			if (dtb.ShowDialog() == DialogResult.OK)
			{
				string sql = "INSERT INTO TaskItems(ParentID,UniqueName,DisplayName,Rank,Expanded,Enabled)"
					+ " VALUES(0,'" + dtb.sNewText.ToLower() + "','" + dtb.sNewText + "',1000,true,"
					+ dtb.bNewEnabled.ToString() + ");";
				int id = VWA4Common.DB.Insert(sql);

				LoadTaskBarData();
				/// Update the Taskbar
				// UCTaskList is listening to week start event, so cause it to fire & reload
				trackerDetector.FireWeekStart();
			}
		}

		
		/// 
		/// Drag/Drop Logic
		/// 

		private void ultraExplorerBar1_GroupDropped(object sender, GroupDroppedEventArgs e)
		{
			int grouprankcnt = 0;
			// Reorder Groups
			foreach (UltraExplorerBarGroup aGroup in ultraExplorerBar1.Groups)
			{
				mGroupItemTag atag = (mGroupItemTag)aGroup.Tag;
				atag.Rank = grouprankcnt++;
				string sql = "UPDATE TaskItems SET Rank =" + atag.Rank.ToString() + " WHERE ID=" + atag.ID + ";";
				VWA4Common.DB.Update(sql);
			}
			/// Update the Taskbar
			// UCTaskList is listening to week start event, so cause it to fire & reload
			trackerDetector.FireWeekStart();

		}

		private void ultraExplorerBar1_ItemDragging(object sender, CancelableItemEventArgs e)
		{
			e.Cancel = false;
		}
		
		private void ultraExplorerBar1_ItemDragOver(object sender, ItemDragOverEventArgs e)
		{
			if (e.DragAction == Infragistics.Win.UltraWinExplorerBar.ItemDragAction.Move)
			{
				e.AllowDrop = true;
			}
		}

		private void ultraExplorerBar1_ItemDropped(object sender, ItemDroppedEventArgs e)
		{
			// Iterate through Groups
			foreach (UltraExplorerBarGroup aGroup in ultraExplorerBar1.Groups)
			{
				mGroupItemTag agtag = (mGroupItemTag)aGroup.Tag;
				int itemrankcnt = 0;
				// Reorder Items in the Group
				foreach (UltraExplorerBarItem anItem in aGroup.Items)
				{
					mGroupItemTag atag = (mGroupItemTag)anItem.Tag;
					atag.Rank = itemrankcnt++;
					string sql = "UPDATE TaskItems SET Rank =" + atag.Rank.ToString() 
						+ ", ParentID = " + agtag.ID + " WHERE ID=" + atag.ID + ";";
					VWA4Common.DB.Update(sql);
				}
			}
			/// Update the Taskbar
			// UCTaskList is listening to week start event, so cause it to fire & reload
			trackerDetector.FireWeekStart();
		}

		///
		/// Misc Event Handlers
		//


		private void rgHideDisabledTasks_SelectedIndexChanged(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.RadioGroup rg = (DevExpress.XtraEditors.RadioGroup)sender;
			int index = rg.SelectedIndex;

			switch (index)
			{
				case 0:
					{
						VWA4Common.GlobalSettings.HideDisabledTasks = "0";
						break;
					}
				case 1:
					{
						VWA4Common.GlobalSettings.HideDisabledTasks = "1";
						break;
					}
				case 2:
					{
						VWA4Common.GlobalSettings.HideDisabledTasks = "2";
						break;
					}
			}
			LoadTaskBarData();
		}



		private void CheckLabels()
		{
			/// Need to Show or NOT show Task Bar setup based on whether we're logged in as Administrator
			if (!VWA4Common.GlobalSettings.IsSuper)
			{
				lTaskBarAdmin.Hide();
				bNewGroup.Hide();
				bInitializeTaskBar.Hide();
				ultraLabel3.Hide();
				rgHideDisabledTasks.Hide();
			}
			else
			{
				lTaskBarAdmin.Show();
				bNewGroup.Show();
				bInitializeTaskBar.Show();
				ultraLabel3.Show();
				rgHideDisabledTasks.Show();
			}
		}
		
		private void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			if (this.Visible)
				LoadData();
		}
		
		private void tPrimaryUserName_AfterExitEditMode(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.PrimaryUserName = tPrimaryUserName.Text;
			}
		}

		private void tPrimaryUserEmail_AfterExitEditMode(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.PrimaryUserEmail = tPrimaryUserEmail.Text;
			}
		}


		private void cbFirstDayofWeek_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.FirstDayOfWeek =
								cbFirstDayofWeek.Items[cbFirstDayofWeek.SelectedIndex].ToString();
			}
		}

		private void rgActiveSyncTransfers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn =
							rgActiveSyncTransfers.Properties.Items[rgActiveSyncTransfers.SelectedIndex].Value.ToString();
			}
			tActiveSyncFolder.Visible = (rgActiveSyncTransfers.Properties.Items[rgActiveSyncTransfers.SelectedIndex].Value.ToString().ToLower()
											== "true");
			lActiveSyncTrackerTransferFolder.Visible = tActiveSyncFolder.Visible;
		}

		private void tActiveSyncFolder_AfterExitEditMode(object sender, EventArgs e)
		{
			if (Initialized)
			{
				VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder = tActiveSyncFolder.Text;
			}

		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void cbCycleTime_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Cycle time changed - set it
			if (Initialized)
			{
				VWA4Common.GlobalSettings.CycleTime =
								int.Parse(cbCycleTime.Items[cbCycleTime.SelectedIndex].ToString());
				// test code only
				//label2.Text = "Previous cycle start date: " + VWA4Common.GlobalSettings.PreviousCycleStartDate(
				//    DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek));
			}
		}
		///
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // || !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Preferences")))
				commonEvents.TaskSheetKey = "dashboard";
			CheckLabels();
			LoadTaskBarData();
		}

        private void nWeightImportThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (nWeightImportThreshold.Value == 0)
                nWeightImportThreshold.ForeColor = Color.Gray;
            else
                nWeightImportThreshold.ForeColor = Color.Black;
            if (Initialized)
            {
                VWA4Common.GlobalSettings.WeightImportThreshold =
                            nWeightImportThreshold.Value.ToString();
            }
        }

        private void nCostImportThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (nCostImportThreshold.Value == 0)
                nCostImportThreshold.ForeColor = Color.Gray;
            else
                nCostImportThreshold.ForeColor = Color.Black;
            if (Initialized)
            {
                VWA4Common.GlobalSettings.CostImportThreshold =
                            nCostImportThreshold.Value.ToString();
            }
        }


	}
}
