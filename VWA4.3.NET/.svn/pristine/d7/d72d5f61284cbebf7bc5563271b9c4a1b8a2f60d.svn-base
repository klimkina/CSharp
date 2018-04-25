using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;

namespace UserControls
{
	public partial class UCManageDETemplates : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		VWA4Common.GlobalClasses.DataEntryTemplate DETMem = null;
		UltraExplorerBarItem ultra1_CurrItem = null;
		UltraExplorerBarItem ultra2_CurrItem = null;


		class ComboBoxItem
		{
			public string Name;
			public string sID;
			public ComboBoxItem(string Name, string key)
			{
				this.Name = Name;
				this.sID = key;
			}
			// override ToString() function
			public override string ToString()
			{
				return this.Name;
			}
		}
		ComboBoxItem cbi = null;
		
		
		private class mFItemTag
		{
			public string TypeID;
			public int Backcolor;
			public int Forecolor;
			public bool Visible;
			public string CTDefaultMode;
			public bool IsChecked;

			public mFItemTag(string typeID, int backcolor, int forecolor, bool ischecked)
			{
				TypeID = typeID;
				Backcolor = backcolor;
				Forecolor = forecolor;
				CTDefaultMode = "";
				IsChecked = false;
			}
			public mFItemTag(string typeID, int backcolor, int forecolor, string ctdefaultmode, bool ischecked)
			{
				TypeID = typeID;
				Backcolor = backcolor;
				Forecolor = forecolor;
				CTDefaultMode = ctdefaultmode;
				IsChecked = false;
			}
		}

		private string allheaderitemtypes = "User,Wastemode,Food,Loss,Container,Station,Disposition,Daypart,EventOrder";
		private string allheaderitemnames = "User Type,Waste Mode,Food Type,Loss Type,Container Type,Station Type,Disposition Type,Daypart Type,Event Order Type";
		private string alltransactionitemtypes = "Timestamp,User,Wastemode,Food,Loss,Container,Station,Disposition,Daypart,EventOrder";

		private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageDETemplates()
		{
			InitializeComponent();
		}
		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			Initialized = false;
			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}

			// Combo box init
			initComboBoxes(false);
			
			hideConfigUI();
			InitProductUI();
			DETMem = null;
			_IsActive = true;
		}
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			InitProductUI();
		}

		void initComboBoxes(bool settodefaults)
		{
			//// Transaction Timestamp
			//cbTimestampPrefill.Items.Clear();
			//cbTimestampPrefill.Items.Add(new ComboBoxItem(
			//    "Current Date/Time", "Auto"));
			//cbTimestampPrefill.Items.Add(new ComboBoxItem(
			//    "Previous Saved Transaction", "Prev"));
			//cbTimestampPrefill.Items.Add(new ComboBoxItem(
			//    "Session Start Time", "Sess"));
			//cbTimestampPrefill.Items.Add(new ComboBoxItem(
			//    "Null Value", "Null"));
			//// Waste Mode pre-fill
			//cbWasteModePrefill.Items.Clear();
			//cbWasteModePrefill.Items.Add(new ComboBoxItem(
			//    "List (Tracker) Default", "Auto"));
			//cbWasteModePrefill.Items.Add(new ComboBoxItem(
			//    "Previous Saved Transaction", "Prev"));
			//cbWasteModePrefill.Items.Add(new ComboBoxItem(
			//    "Header Waste Mode Setting", "Form"));
			//cbWasteModePrefill.Items.Add(new ComboBoxItem(
			//"Null Value", "Null"));
			
			// Initial Quantity Mode
			cbQuantityDefaultMode.Items.Clear();
			cbQuantityDefaultMode.Items.Add(new ComboBoxItem(
				"Item Mode", "Each"));
			cbQuantityDefaultMode.Items.Add(new ComboBoxItem(
				"Volume Mode", "Vol"));
			cbQuantityDefaultMode.Items.Add(new ComboBoxItem(
				" Weight Mode", "Wt"));
			cbQuantityDefaultMode.Items.Add(new ComboBoxItem(
				"Mode from Previous Saved Transaction", "Prev"));

			// Formset Waste Mode Setting
			cbFormSet_Wastemode.Items.Clear();
			cbFormSet_Wastemode.Items.Add(new ComboBoxItem(
				"Pre-consumer Waste", "Pre"));
			cbFormSet_Wastemode.Items.Add(new ComboBoxItem(
				"Post-consumer Waste", "Post"));
			cbFormSet_Wastemode.Items.Add(new ComboBoxItem(
				"Intermediate Waste", "Int"));

			if (settodefaults)
			{
				//cbTimestampPrefill.SelectedIndex = 0;
				//cbWasteModePrefill.SelectedIndex = 0;
				cbQuantityDefaultMode.SelectedIndex = 0;
				cbFormSet_Wastemode.SelectedIndex = 1;
			}
			else
			{
				//cbTimestampPrefill.SelectedIndex = -1;
				//cbWasteModePrefill.SelectedIndex = -1;
				cbQuantityDefaultMode.SelectedIndex = -1;
				cbFormSet_Wastemode.SelectedIndex = -1;
			}
		}
	
		void InitProductUI()
		{
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;

		}

		public int AutoRun(string param)
		{
			Initialized = true;
			pInitialLoad.Location = VWA4Common.Utilities.CenterControlonBackgroundControl(
				this, pInitialLoad);
			pInitialLoad.Top -= 30;
			pInitialLoad.Show();
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
		/// <summary>
		/// Standard Load Data method.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			pLoaded.Hide();


		}


		public void SaveData()
		{

		}

		public bool ValidateData()
		{ return true; }

		///		
		/// Event Handlers and supporting routines
		///		



        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Waste Data")))
				CloseTaskSheet();
		}
		private void CloseTaskSheet()
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void hideConfigUI()
		{
			panel3.Hide();
			panel4.Hide();
			panel5.Hide();

			bCloseTemplate.Hide();
			bSave.Hide();
		}





		private void bOpenTemplate_Click(object sender, EventArgs e)
		{
			DETMem = new VWA4Common.GlobalClasses.DataEntryTemplate();
			// Prompt user for opening a template (listbox)
			frmOpenDETemplate opendet = new frmOpenDETemplate();
			
			if (opendet._Count <= 0)
			{
				MessageBox.Show("No Data Entry Templates configured!");
				return;
			}

			if (opendet.ShowDialog() == DialogResult.OK)
			{
				// Open the template
				if (DETLoad(opendet.DETID))
				{
					// Successful in opening the DET
					pInitialLoad.Hide();
					initGeneralSettingsUI();
					initHeaderUI();
					initTransactionUI();
					bCloseTemplate.Show();
					bSave.Show();
					pLoaded.Show();
					bLoadSettings.Show();
				}
				else
				{
					MessageBox.Show("Error occurred attempting to open Data Entry Template!");
				}

			}
			else
			{
				DETMem = null;
			}
			
		}

		private void bLoadSettings_Click(object sender, EventArgs e)
		{
			// Prompt user for opening a template (listbox)
			frmOpenDETemplate opendet = new frmOpenDETemplate();

			if (opendet._Count <= 0)
			{
				MessageBox.Show("No Data Entry Templates configured!");
				return;
			}

			if (opendet.ShowDialog() == DialogResult.OK)
			{
				// Load the template
				if (DETLoad(opendet.DETID, true))
				{
					// Successful in opening the DET
					pInitialLoad.Hide();
					initGeneralSettingsUI();
					initHeaderUI();
					initTransactionUI();
					bCloseTemplate.Show();
					bSave.Show();
					bLoadSettings.Show();
					pLoaded.Show();
				}
				else
				{
					MessageBox.Show("Error occurred attempting to open Data Entry Template!");
				}

			}
		}



		private void initGeneralSettingsUI()
		{
			tDETName.Text = DETMem.DETName;
			tDescription.Text = DETMem.DETDescription;
			// Init the combo boxes
			//cbTimestampPrefill.SelectedIndex = findComboBoxItembyKey(cbTimestampPrefill, DETMem.Timestamp_NTPrefill);
			//if (cbTimestampPrefill.SelectedIndex < 0) cbTimestampPrefill.Text = "";
			//cbWasteModePrefill.SelectedIndex = findComboBoxItembyKey(cbWasteModePrefill, DETMem.Wastemode_CTDefaultMode);
			//if (cbWasteModePrefill.SelectedIndex < 0) cbWasteModePrefill.Text = "";
			//cbQuantityDefaultMode.SelectedIndex = findComboBoxItembyKey(cbQuantityDefaultMode, DETMem.Quantity_CTDefaultMode);
			if (cbQuantityDefaultMode.SelectedIndex < 0) cbQuantityDefaultMode.Text = "";
			//
			VWA4Common.GlobalClasses.VWDBStats dbStats = new VWA4Common.GlobalClasses.VWDBStats();
			VWA4Common.GlobalSettings.GetDBStats(dbStats);
			if (VWA4Common.GlobalSettings.MaxNumberofDETs <= dbStats.NumDETs)
			{ // Cannot create a new template - so disable ability to do that
				bNewTemplate.Enabled = false;
			}
			else bNewTemplate.Enabled = true;

			panel3.Show();
		}

		private int findComboBoxItembyKey(ComboBox cb, string key)
		{
			ComboBoxItem cbi = null;
			for (int i = 0; i < cb.Items.Count; i++)
			{
				cbi = (ComboBoxItem) cb.Items[i];
				if (cbi.sID.ToLower() == key.ToLower()) return i;
			}
			return -1;
		}


		private void initHeaderUI()
		{
			pFormsetDetails1.Hide();
			pFormsetDetails2.Hide();
			ultraExplorerBar1.Groups.Clear();
			string[] tokens;
			int i;
			/// Initialize Explorer Bar from DB
			/// Just one Group
			UltraExplorerBarGroup aGroup = new UltraExplorerBarGroup();
			aGroup = ultraExplorerBar1.Groups.Add();
			aGroup.Text = "Header Fields";
			/// Add Items under this Group
			// go through display order and add items in that order first
			if (DETMem.FormSet_displayorder != "")
			{
				tokens = DETMem.FormSet_displayorder.Split(new Char[] { ',' });
				//****
				for (i = 0; i < tokens.Length; i++)
				{
					string s = tokens[i].Trim();
					UltraExplorerBarItem itemtoadd = setFormSetVars(s, false, true);
					((mFItemTag)itemtoadd.Tag).IsChecked = true;
					// Add the Item to the group
					itemtoadd.Settings.AppearancesSmall.Appearance.Image = 1;
					aGroup.Items.Add(itemtoadd);

				}
			}

			/// Now add the items that were NOT in the displayorder
			tokens = allheaderitemtypes.Split(new Char[] { ',' });
			string[] tokens2 = allheaderitemnames.Split(new Char[] { ',' });
			for (i = 0; i < tokens.Length; i++)
			{
				string s = tokens[i].Trim().ToLower();
				if (!isFormsetTypeinDisplayOrder(DETMem.FormSet_displayorder,s))
				{
					UltraExplorerBarItem itemtoadd = setFormSetVars(s, false, false);
					((mFItemTag)itemtoadd.Tag).IsChecked = false;
					// Add the Item to the group
					itemtoadd.Settings.AppearancesSmall.Appearance.Image = 0;
					aGroup.Items.Add(itemtoadd);

				}
			}
			ultraExplorerBar1.Groups.ExpandAll();
			ultraExplorerBar1.GroupSettings.ShowExpansionIndicator =
					Infragistics.Win.DefaultableBoolean.False;
			ultraExplorerBar1.ActiveItem = null;
			this.ultraExplorerBar1.Update();
			// Set the overall header settings
			switch (DETMem.FormSet_Wastemode.ToLower())
			{
				case "pre":
					{
						cbFormSet_Wastemode.SelectedIndex = 0;
						break;
					}
				case "post":
					{
						cbFormSet_Wastemode.SelectedIndex = 1;
						break;
					}
				case "int":
					{
						cbFormSet_Wastemode.SelectedIndex = 2;
						break;
					}
			}
			lFAreaBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_BackColor);
			pFormsetDetails2.Show();
			panel4.Show();
		}

		private bool isFormsetTypeinDisplayOrder(string displayorder, string type)
		{
			string [] tokens = displayorder.Split(new Char[] { ',' });
			for (int i = 0; i < tokens.Length; i++)
			{
				string s = tokens[i].Trim().ToLower();
				if (type.ToLower() == s) return true;
			}
			return false;
		}
		
		private UltraExplorerBarItem setFormSetVars(string key, bool istransaction, bool indisplayorder)
		{
			UltraExplorerBarItem anItem = new UltraExplorerBarItem();
			//************
			//************ SWITCH HERE
			//************
			if (key.ToLower() == "beo") key = "eventorder";
			switch (key.ToLower())
			{
				case "timestamp":
					{
						anItem.Text = "Timestamp";
						anItem.Key = "Timestamp";
						//if (indisplayorder) anItem.Checked = true;
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						/// Must be a transaction for Timestamp - doesn't appear in Formset
						//if (istransaction)
						anItem.Tag = new mFItemTag("", 0, 0,
							DETMem.Timestamp_NTPrefill, checkthis);
						break;
					}
				case "wastemode":
					{
						anItem.Text = "Waste Mode";
						anItem.Key = "Wastemode";
						//if (indisplayorder) anItem.Checked = true;
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("", 
								DETMem.FormSet_Wastemode_BackColor, 
								DETMem.FormSet_Wastemode_ForeColor,
								DETMem.Wastemode_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_Wastemode, 0, 0, checkthis);
						}
						break;
					}
				case "user":
					{
						anItem.Text = "User Type";
						anItem.Key = "User";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("", 
								DETMem.UserType_BackColor, 
								DETMem.UserType_ForeColor, 
								DETMem.User_CTDefaultMode,checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_UserType,
								DETMem.FormSet_UserType_BackColor,
								DETMem.FormSet_UserType_ForeColor, checkthis);
						}
						break;
					}
				case "food":
					{
						anItem.Text = "Food Type";
						anItem.Key = "Food";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.FoodType_BackColor,
								DETMem.FoodType_ForeColor, 
								DETMem.FoodType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_FoodType,
								DETMem.FormSet_FoodType_BackColor,
								DETMem.FormSet_FoodType_ForeColor, checkthis);
						}
						break;
					}
				case "loss":
					{
						anItem.Text = "Loss Type";
						anItem.Key = "Loss";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.LossType_BackColor,
								DETMem.LossType_ForeColor, 
								DETMem.LossType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_LossType,
								DETMem.FormSet_LossType_BackColor,
								DETMem.FormSet_LossType_ForeColor, checkthis);
						}
						break;
					}
				case "container":
					{
						anItem.Text = "Container Type";
						anItem.Key = "Container";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.ContainerType_BackColor,
								DETMem.ContainerType_ForeColor, 
								DETMem.ContainerType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_FoodType,
								DETMem.FormSet_ContainerType_BackColor,
								DETMem.FormSet_ContainerType_ForeColor, checkthis);
						}
						break;
					}
				case "station":
					{
						anItem.Text = "Station Type";
						anItem.Key = "Station";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.StationType_BackColor,
								DETMem.StationType_ForeColor, 
								DETMem.StationType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_StationType,
								DETMem.FormSet_StationType_BackColor,
								DETMem.FormSet_StationType_ForeColor, checkthis);
						}
						break;
					}
				case "disposition":
					{
						anItem.Text = "Disposition Type";
						anItem.Key = "Disposition";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.DispositionType_BackColor,
								DETMem.DispositionType_ForeColor, 
								DETMem.DispositionType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_DispositionType,
								DETMem.FormSet_DispositionType_BackColor,
								DETMem.FormSet_DispositionType_ForeColor, checkthis);
						}
						break;
					}
				case "daypart":
					{
						anItem.Text = "Daypart Type";
						anItem.Key = "Daypart";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.DaypartType_BackColor,
								DETMem.DaypartType_ForeColor, 
								DETMem.DaypartType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_DaypartType,
								DETMem.FormSet_DaypartType_BackColor,
								DETMem.FormSet_DaypartType_ForeColor, checkthis);
						}
						break;
					}
				case "eventorder":
					{
						anItem.Text = "Event Order Type";
						anItem.Key = "EventOrder";
						bool checkthis = false;
						if (indisplayorder) checkthis = true;
						if (istransaction)
						{
							anItem.Tag = new mFItemTag("",
								DETMem.EventOrderType_BackColor,
								DETMem.EventOrderType_ForeColor, 
								DETMem.EventOrderType_CTDefaultMode, checkthis);
						}
						else
						{
							anItem.Tag = new mFItemTag(DETMem.FormSet_EventOrderType,
								DETMem.FormSet_EventOrderType_BackColor,
								DETMem.FormSet_EventOrderType_ForeColor, checkthis);
						}
						break;
					}
			}

			// Initialize Other Settings
			anItem.Settings.AllowDragMove = ItemDragStyle.WithinGroupOnly;
			if (((mFItemTag)anItem.Tag).IsChecked)
			{
				anItem.Settings.AppearancesSmall.Appearance.Image = 1;
			}
			else
			{
				anItem.Settings.AppearancesSmall.Appearance.Image = 0;
			}
			return anItem;
		}

		
		private void initTransactionUI()
		{
			pTransDetails1.Hide();
			pTransDetails2.Hide();
			ultraExplorerBar2.Groups.Clear();
			string[] tokens;
			int i;
			/// Initialize Explorer Bar from DB
			/// Just one Group
			UltraExplorerBarGroup aGroup = new UltraExplorerBarGroup();
			aGroup = ultraExplorerBar2.Groups.Add();
			aGroup.Text = "Transaction Fields";
			/// Add Items under this Group
			// go through display order and add items in that order first
			if (DETMem.Transaction_displayorder != "")
			{
				tokens = DETMem.Transaction_displayorder.Split(new Char[] { ',' });
				//****
				for (i = 0; i < tokens.Length; i++)
				{
					string s = tokens[i].Trim();
					// disallow unlicensed dimensions
					if (((!VWA4Common.GlobalSettings.StationEntryAvailable) ||
					(!VWA4Common.GlobalSettings.ConfigureStationEntryAvailable)) && (s.ToLower() == "station")) continue;
					if (((!VWA4Common.GlobalSettings.DispositionEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable)) && (s.ToLower() == "disposition")) continue;
					if (((!VWA4Common.GlobalSettings.DaypartEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable)) && (s.ToLower() == "daypart")) continue;
					if (((!VWA4Common.GlobalSettings.PrePostEntryAvailable) ||
						(!VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable)) && (s.ToLower() == "wastemode")) continue;
				
					UltraExplorerBarItem itemtoadd = setFormSetVars(s, true, true);
					((mFItemTag)itemtoadd.Tag).IsChecked = true;
					// Add the Item to the group
					itemtoadd.Settings.AppearancesSmall.Appearance.Image = 1;
					aGroup.Items.Add(itemtoadd);
				}
			}
			
			/// Now add the items that were NOT in the displayorder
			tokens = alltransactionitemtypes.Split(new Char[] { ',' });
			for (i = 0; i < tokens.Length; i++)
			{
				string s = tokens[i].Trim().ToLower();
				// disallow unlicensed dimensions
				if (((!VWA4Common.GlobalSettings.StationEntryAvailable) ||
				(!VWA4Common.GlobalSettings.ConfigureStationEntryAvailable)) && (s.ToLower() == "station")) continue;
				if (((!VWA4Common.GlobalSettings.DispositionEntryAvailable) ||
					(!VWA4Common.GlobalSettings.ConfigureDispositionEntryAvailable)) && (s.ToLower() == "disposition")) continue;
				if (((!VWA4Common.GlobalSettings.DaypartEntryAvailable) ||
					(!VWA4Common.GlobalSettings.ConfigureDaypartEntryAvailable)) && (s.ToLower() == "daypart")) continue;
				if (((!VWA4Common.GlobalSettings.PrePostEntryAvailable) ||
					(!VWA4Common.GlobalSettings.ConfigurePrePostEntryAvailable)) && (s.ToLower() == "wastemode")) continue;
				if (!isFormsetTypeinDisplayOrder(DETMem.Transaction_displayorder, s))
				{
					UltraExplorerBarItem itemtoadd = setFormSetVars(s, false, false);
					((mFItemTag)itemtoadd.Tag).IsChecked = false;
					// Add the Item to the group
					itemtoadd.Settings.AppearancesSmall.Appearance.Image = 0;
					aGroup.Items.Add(itemtoadd);

				}
			}
			ultraExplorerBar2.Groups.ExpandAll();
			ultraExplorerBar2.GroupSettings.ShowExpansionIndicator =
				Infragistics.Win.DefaultableBoolean.False;
			ultraExplorerBar2.ActiveItem = null;
			this.ultraExplorerBar2.Update();
			// Set the overall transaction settings
			//cbxTimestamp_TransShow.Checked =
			//    DETMem.Timestamp_TransShow;
			//cbxUser_TShow.Checked =
			//    DETMem.User_TShow;
			cbxUserNotes_TShow.Checked =
				DETMem.UserNotes_TShow;
			lTAreaBackcolor.BackColor =
				Color.FromArgb(DETMem.Transaction_BackColor);
			lQuantityBackColorpicker.BackColor =
				Color.FromArgb(DETMem.Quantity_BackColor);
			lQuantityForeColorpicker.BackColor =
				Color.FromArgb(DETMem.Quantity_ForeColor);
			lUserNotesBackColorpicker.BackColor =
				Color.FromArgb(DETMem.UserNotes_BackColor);
			lUserNotesForeColorpicker.BackColor =
				Color.FromArgb(DETMem.UserNotes_ForeColor);
			pTransDetails2.Show();
			
		//•	“Wt” => Weight mode
		//•	“Each” => Each mode
		//•	“Vol” => Volume mode
		//•	“Prev” => Use mode from previous transaction
			switch (DETMem.Quantity_CTDefaultMode.ToLower())
			{
				case "each":
					{
						cbQuantityDefaultMode.SelectedIndex = 0;
						break;
					}
				case "vol":
					{
						cbQuantityDefaultMode.SelectedIndex = 1;
						break;
					}
				case "prev":
					{
						cbQuantityDefaultMode.SelectedIndex = 3;
						break;
					}
				default:
					{
						cbQuantityDefaultMode.SelectedIndex = 2;
						break;
					}
			}
			panel5.Show();
		}


		public bool DETLoad(int DET_ID)
		{
			return DETLoad(DET_ID, false);

		}

		
		public bool DETLoad(int DET_ID, bool loadtocurrent)
		{
			VWA4Common.GlobalClasses.DataEntryTemplate detmem = new VWA4Common.GlobalClasses.DataEntryTemplate();
			string es = VWA4Common.GlobalSettings.DETConfigCheck(DET_ID, detmem);
			if (es != "")
			{ // Problem with license limits
				MessageBox.Show(es, "Data Entry Template Error");
				return false;
			}
			//************
			// Data Entry Template is within license limits
			//************
			if (DET_ID != 0)
			{
				// The DataEntryTemplates table has an entry for the FormSet - load it

				string sql = "SELECT * FROM DataEntryTemplates  WHERE ID = "
					+ DET_ID.ToString();
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					if (!loadtocurrent)
					{
						DETMem.DETID = int.Parse(dr["ID"].ToString());
						/// 
						DETMem.DETName = dr["DETName"].ToString();
					}
					DETMem.DETDescription = dr["DETDescription"].ToString();
					DETMem.FormSet_displayorder = dr["FormSet_displayorder"].ToString();
					DETMem.FormSet_BackColor = int.Parse(dr["FormSet_BackColor"].ToString());
					/// 
					DETMem.FormSet_Wastemode = dr["FormSet_Wastemode"].ToString();
					DETMem.FormSet_Wastemode_BackColor = int.Parse(dr["FormSet_Wastemode_BackColor"].ToString());
					DETMem.FormSet_Wastemode_ForeColor = int.Parse(dr["FormSet_Wastemode_ForeColor"].ToString());
					DETMem.FormSet_UserType = dr["FormSet_UserType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user", DETMem.FormSet_UserType, out DETMem.FormSet_UserTypeName);
					DETMem.FormSet_UserType_BackColor = int.Parse(dr["FormSet_UserType_BackColor"].ToString());
					DETMem.FormSet_UserType_ForeColor = int.Parse(dr["FormSet_UserType_ForeColor"].ToString());
					DETMem.FormSet_FoodType = dr["FormSet_FoodType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", DETMem.FormSet_FoodType, out DETMem.FormSet_FoodTypeName);
					DETMem.FormSet_FoodType_BackColor = int.Parse(dr["FormSet_FoodType_BackColor"].ToString());
					DETMem.FormSet_FoodType_ForeColor = int.Parse(dr["FormSet_FoodType_ForeColor"].ToString());
					DETMem.FormSet_LossType = dr["FormSet_LossType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss", DETMem.FormSet_LossType, out DETMem.FormSet_LossTypeName);
					DETMem.FormSet_LossType_BackColor = int.Parse(dr["FormSet_LossType_BackColor"].ToString());
					DETMem.FormSet_LossType_ForeColor = int.Parse(dr["FormSet_LossType_ForeColor"].ToString());
					DETMem.FormSet_ContainerType = dr["FormSet_ContainerType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", DETMem.FormSet_ContainerType, out DETMem.FormSet_ContainerTypeName);
					DETMem.FormSet_ContainerType_BackColor = int.Parse(dr["FormSet_ContainerType_BackColor"].ToString());
					DETMem.FormSet_ContainerType_ForeColor = int.Parse(dr["FormSet_ContainerType_ForeColor"].ToString());
					DETMem.FormSet_StationType = dr["FormSet_StationType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station", DETMem.FormSet_StationType, out DETMem.FormSet_StationTypeName);
					DETMem.FormSet_StationType_BackColor = int.Parse(dr["FormSet_StationType_BackColor"].ToString());
					DETMem.FormSet_StationType_ForeColor = int.Parse(dr["FormSet_StationType_ForeColor"].ToString());
					DETMem.FormSet_DispositionType = dr["FormSet_DispositionType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition", DETMem.FormSet_DispositionType, out DETMem.FormSet_DispositionTypeName);
					DETMem.FormSet_DispositionType_BackColor = int.Parse(dr["FormSet_DispositionType_BackColor"].ToString());
					DETMem.FormSet_DispositionType_ForeColor = int.Parse(dr["FormSet_DispositionType_ForeColor"].ToString());
					DETMem.FormSet_DaypartType = dr["FormSet_DaypartType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart", DETMem.FormSet_DaypartType, out DETMem.FormSet_DaypartTypeName);
					DETMem.FormSet_DaypartType_BackColor = int.Parse(dr["FormSet_DaypartType_BackColor"].ToString());
					DETMem.FormSet_DaypartType_ForeColor = int.Parse(dr["FormSet_DaypartType_ForeColor"].ToString());
					DETMem.FormSet_EventOrderType = dr["FormSet_EventorderType"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder", DETMem.FormSet_EventOrderType, out DETMem.FormSet_EventOrderTypeName);
					DETMem.FormSet_EventOrderType_BackColor = int.Parse(dr["FormSet_EventorderType_BackColor"].ToString());
					DETMem.FormSet_EventOrderType_ForeColor = int.Parse(dr["FormSet_EventorderType_ForeColor"].ToString());
					///
					DETMem.Transaction_displayorder = dr["Transaction_displayorder"].ToString();
					DETMem.Transaction_BackColor = int.Parse(dr["Transaction_BackColor"].ToString());
					DETMem.Quantity_CTDefaultMode = dr["Quantity_CTDefaultMode"].ToString();
					DETMem.Quantity_BackColor = int.Parse(dr["Quantity_BackColor"].ToString());
					DETMem.Quantity_ForeColor = int.Parse(dr["Quantity_Forecolor"].ToString());
					DETMem.UserNotes_TShow = bool.Parse(dr["UserNotes_TShow"].ToString());
					DETMem.UserNotes_BackColor = int.Parse(dr["UserNotes_BackColor"].ToString());
					DETMem.UserNotes_ForeColor = int.Parse(dr["UserNotes_Forecolor"].ToString());
					///
					DETMem.Timestamp_NTPrefill = dr["Timestamp_NTPrefill"].ToString();
					DETMem.Timestamp_TFormat = dr["Timestamp_TFormat"].ToString();
					DETMem.Timestamp_BackColor = int.Parse(dr["Timestamp_BackColor"].ToString());
					DETMem.Timestamp_ForeColor = int.Parse(dr["Timestamp_Forecolor"].ToString());
					DETMem.Wastemode_CTDefaultMode = dr["Wastemode_CTDefaultMode"].ToString();
					DETMem.User_CTDefaultMode = dr["User_CTDefaultMode"].ToString();
					DETMem.UserType_BackColor = int.Parse(dr["UserType_BackColor"].ToString());
					DETMem.UserType_ForeColor = int.Parse(dr["UserType_ForeColor"].ToString());
					DETMem.FoodType_CTDefaultMode = dr["FoodType_CTDefaultMode"].ToString();
					DETMem.FoodType_BackColor = int.Parse(dr["FoodType_BackColor"].ToString());
					DETMem.FoodType_ForeColor = int.Parse(dr["FoodType_ForeColor"].ToString());
					DETMem.LossType_CTDefaultMode = dr["LossType_CTDefaultMode"].ToString();
					DETMem.LossType_BackColor = int.Parse(dr["LossType_BackColor"].ToString());
					DETMem.LossType_ForeColor = int.Parse(dr["LossType_ForeColor"].ToString());
					DETMem.ContainerType_CTDefaultMode = dr["ContainerType_CTDefaultMode"].ToString();
					DETMem.ContainerType_BackColor = int.Parse(dr["ContainerType_BackColor"].ToString());
					DETMem.ContainerType_ForeColor = int.Parse(dr["ContainerType_ForeColor"].ToString());
					DETMem.StationType_CTDefaultMode = dr["StationType_CTDefaultMode"].ToString();
					DETMem.StationType_BackColor = int.Parse(dr["StationType_BackColor"].ToString());
					DETMem.StationType_ForeColor = int.Parse(dr["StationType_ForeColor"].ToString());
					DETMem.DispositionType_CTDefaultMode = dr["DispositionType_CTDefaultMode"].ToString();
					DETMem.DispositionType_BackColor = int.Parse(dr["DispositionType_BackColor"].ToString());
					DETMem.DispositionType_ForeColor = int.Parse(dr["DispositionType_ForeColor"].ToString());
					DETMem.DaypartType_CTDefaultMode = dr["DaypartType_CTDefaultMode"].ToString();
					DETMem.DaypartType_BackColor = int.Parse(dr["DaypartType_BackColor"].ToString());
					DETMem.DaypartType_ForeColor = int.Parse(dr["DaypartType_ForeColor"].ToString());
					DETMem.EventOrderType_CTDefaultMode = dr["EventOrderType_CTDefaultMode"].ToString();
					DETMem.EventOrderType_BackColor = int.Parse(dr["EventOrderType_BackColor"].ToString());
					DETMem.EventOrderType_ForeColor = int.Parse(dr["EventOrderType_ForeColor"].ToString());
					return true;
				}
				else
				{
					// The DataEntryTemplates table has NO entry for the FormSet - so indicate

					return false;
				}
			}
			return false;
		}

		private void bNewTemplate_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalClasses.VWDBStats dbStats = new VWA4Common.GlobalClasses.VWDBStats();
			VWA4Common.GlobalSettings.GetDBStats(dbStats);
			if (VWA4Common.GlobalSettings.MaxNumberofDETs <= dbStats.NumDETs)
			{ // Cannot create a new template - exceeds license limits
				MessageBox.Show("Data Entry Template Maximum Limit Reached or Exceeded!\n"
					+ " - Licensed limit is " + VWA4Common.GlobalSettings.MaxNumberofDETs.ToString()
					+ "DETs\n - Database currently contains " + dbStats.NumDETs.ToString(),
						"Data Entry Template Creation Error");
				return;
			}
			Initialized = false;
			initComboBoxes(true);

			DETMem = new VWA4Common.GlobalClasses.DataEntryTemplate();

			DETMem.DETID = 0;
			DETMem.DETName = "(Template Name)";
			DETMem.DETDescription = "";
			DETMem.FormSet_displayorder = "";
			DETMem.FormSet_BackColor = 0xd1b48c;
			///
			DETMem.FormSet_Wastemode = "Post";
			DETMem.FormSet_Wastemode_BackColor = 0xf6e9e3;
			DETMem.FormSet_Wastemode_ForeColor = -16777216;
			DETMem.FormSet_UserType = "";
			DETMem.FormSet_UserTypeName = "";
			DETMem.FormSet_UserType_BackColor = 0xf6e9e3;
			DETMem.FormSet_UserType_ForeColor = -16777216;
			DETMem.FormSet_FoodType = "";
			DETMem.FormSet_FoodTypeName = "";
			DETMem.FormSet_FoodType_BackColor = 0xf6e9e3;
			DETMem.FormSet_FoodType_ForeColor = -16777216;
			DETMem.FormSet_LossType = "";
			DETMem.FormSet_LossTypeName = "";
			DETMem.FormSet_LossType_BackColor = 0xf6e9e3;
			DETMem.FormSet_LossType_ForeColor = -16777216;
			DETMem.FormSet_ContainerType = "";
			DETMem.FormSet_ContainerTypeName = "";
			DETMem.FormSet_ContainerType_BackColor = 0xf6e9e3;
			DETMem.FormSet_ContainerType_ForeColor = -16777216;
			DETMem.FormSet_StationType = "";
			DETMem.FormSet_StationTypeName = "";
			DETMem.FormSet_StationType_BackColor = 0xf6e9e3;
			DETMem.FormSet_StationType_ForeColor = -16777216;
			DETMem.FormSet_DispositionType = "";
			DETMem.FormSet_DispositionTypeName = "";
			DETMem.FormSet_DispositionType_BackColor = 0xf6e9e3;
			DETMem.FormSet_DispositionType_ForeColor = -16777216;
			DETMem.FormSet_DaypartType = "";
			DETMem.FormSet_DaypartTypeName = "";
			DETMem.FormSet_DaypartType_BackColor = 0xf6e9e3;
			DETMem.FormSet_DaypartType_ForeColor = -16777216;
			DETMem.FormSet_EventOrderType = "";
			DETMem.FormSet_EventOrderTypeName = "";
			DETMem.FormSet_EventOrderType_BackColor = 0xf6e9e3;
			DETMem.FormSet_EventOrderType_ForeColor = -16777216;
			///
			DETMem.Transaction_displayorder = "";
			DETMem.Transaction_BackColor = 0xef807f;
			DETMem.Quantity_CTDefaultMode = "Each";
			DETMem.Quantity_BackColor = 0xf6e9e3;
			DETMem.Quantity_ForeColor = -16777216;
			DETMem.UserNotes_TShow = false;
			DETMem.UserNotes_BackColor = 0xf6e9e3;
			DETMem.UserNotes_ForeColor = -16777216;
			///
			DETMem.Timestamp_NTPrefill = "Auto";
			DETMem.Timestamp_TFormat = "";
			DETMem.Timestamp_BackColor = 0xf6e9e3;
			DETMem.Timestamp_ForeColor = -16777216;
			DETMem.Wastemode_CTDefaultMode = "Auto";
			DETMem.Wastemode_BackColor = 0xf6e9e3;
			DETMem.Wastemode_ForeColor = -16777216;
			DETMem.User_CTDefaultMode = "Null";
			DETMem.UserType_BackColor = 0xf6e9e3;
			DETMem.UserType_ForeColor = -16777216;
			DETMem.FoodType_CTDefaultMode = "Null";
			DETMem.FoodType_BackColor = 0xf6e9e3;
			DETMem.FoodType_ForeColor = -16777216;
			DETMem.LossType_CTDefaultMode = "Null";
			DETMem.LossType_BackColor = 0xf6e9e3;
			DETMem.LossType_ForeColor = -16777216;
			DETMem.ContainerType_CTDefaultMode = "Null";
			DETMem.ContainerType_BackColor = 0xf6e9e3;
			DETMem.ContainerType_ForeColor = -16777216;
			DETMem.StationType_CTDefaultMode = "Null";
			DETMem.StationType_BackColor = 0xf6e9e3;
			DETMem.StationType_ForeColor = -16777216;
			DETMem.DispositionType_CTDefaultMode = "Null";
			DETMem.DispositionType_BackColor = 0xf6e9e3;
			DETMem.DispositionType_ForeColor = -16777216;
			DETMem.DaypartType_CTDefaultMode = "Null";
			DETMem.DaypartType_BackColor = 0xf6e9e3;
			DETMem.DaypartType_ForeColor = -16777216;
			DETMem.EventOrderType_CTDefaultMode = "Null";
			DETMem.EventOrderType_BackColor = 0xf6e9e3;
			DETMem.EventOrderType_ForeColor = -16777216;
			
			Initialized = true;

			pInitialLoad.Hide();
			initGeneralSettingsUI();
			initHeaderUI();
			initTransactionUI();
			bCloseTemplate.Show();
			bSave.Show();
			pLoaded.Show();
		}

		private void bCloseTemplate_Click(object sender, EventArgs e)
		{
			pLoaded.Hide();
			bCloseTemplate.Hide();
			hideConfigUI();
			pInitialLoad.Show();
		}
		/// <summary>
		/// Explorer Bar stuff
		/// </summary>
		private bool ultra1_TaskItemImageClicked;
		private bool ultra2_TaskItemImageClicked;
		private UltraExplorerBarItem ultra1_curritem = null;
		private UltraExplorerBarItem ultra2_curritem = null;

		/// <summary>
		/// Process click on Header/Formset item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_ItemClick(object sender, ItemEventArgs e)
		{
			UltraExplorerBarItem anItem = e.Item;
			ultra1_curritem = anItem;

			mFItemTag tag = (mFItemTag)anItem.Tag;
			ultra1_curritem = anItem;
			if (ultra1_TaskItemImageClicked)
			{ // Image was clicked - change the image
				anItem.Settings.AppearancesSmall.Appearance.Image =
					((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0) ? 1 : 0;
				if ((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0)
				{
					// Change Item to Not Enabled
					//anItem.Checked = false;
					tag.IsChecked = false;
				}
				else
				{
					// Change Item to Enabled
					//anItem.Checked = true;
					tag.IsChecked = true;
				}
			}
			/// Item is selected now, so show its data
			if (anItem.Key.ToLower() == "wastemode")
			{
				lFTypeIDTitle.Hide();
				lFTypeName.Hide();
				lFTypeID.Hide();
			}
			else
			{
				lFTypeIDTitle.Show();
				lFTypeName.Show();
				lFTypeID.Show();
			}			
			lFTypeIDTitle.Text = anItem.Text + ":";
			if (anItem.Key.ToLower() == "beo") anItem.Key = "eventorder";
			switch (anItem.Key.ToLower())
			{
				case "wastemode":
					{
						lFTypeID.Text = "";
						lFTypeName.Text = "";
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_Wastemode_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_Wastemode_ForeColor);
						break;
					}
				case "user":
					{
						lFTypeID.Text = DETMem.FormSet_UserType;
						lFTypeName.Text = DETMem.FormSet_UserTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_UserType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_UserType_ForeColor);
						break;
					}
				case "food":
					{
						lFTypeID.Text = DETMem.FormSet_FoodType;
						lFTypeName.Text = DETMem.FormSet_FoodTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_FoodType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_FoodType_ForeColor);
						break;
					}
				case "loss":
					{
						lFTypeID.Text = DETMem.FormSet_LossType;
						lFTypeName.Text = DETMem.FormSet_LossTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_LossType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_LossType_ForeColor);
						break;
					}
				case "container":
					{
						lFTypeID.Text = DETMem.FormSet_ContainerType;
						lFTypeName.Text = DETMem.FormSet_ContainerTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_ContainerType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_ContainerType_ForeColor);
						break;
					}
				case "station":
					{
						lFTypeID.Text = DETMem.FormSet_StationType;
						lFTypeName.Text = DETMem.FormSet_StationTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_StationType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_StationType_ForeColor);
						break;
					}
				case "disposition":
					{
						lFTypeID.Text = DETMem.FormSet_DispositionType;
						lFTypeName.Text = DETMem.FormSet_DispositionTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_DispositionType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_DispositionType_ForeColor);
						break;
					}
				case "daypart":
					{
						lFTypeID.Text = DETMem.FormSet_DaypartType;
						lFTypeName.Text = DETMem.FormSet_DaypartTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_DaypartType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_DaypartType_ForeColor);
						break;
					}
				case "eventorder":
					{
						lFTypeID.Text = DETMem.FormSet_EventOrderType;
						lFTypeName.Text = DETMem.FormSet_EventOrderTypeName;
						lFBackcolor.BackColor = Color.FromArgb(DETMem.FormSet_EventOrderType_BackColor);
						lFForecolor.BackColor = Color.FromArgb(DETMem.FormSet_EventOrderType_ForeColor);
						break;
					}
			}
			lFBackcolor.Update();
			lFForecolor.Update();
			pFormsetDetails1.Show();

		}
		/// <summary>
		/// Process click on Transaction item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar2_ItemClick(object sender, ItemEventArgs e)
		{
			UltraExplorerBarItem anItem = e.Item;
			ultra2_curritem = anItem;
			mFItemTag tag = (mFItemTag)anItem.Tag;
			ultra2_curritem = anItem;
			if (ultra2_TaskItemImageClicked)
			{ // Image was clicked - change the image
				anItem.Settings.AppearancesSmall.Appearance.Image =
					((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0) ? 1 : 0;
				if ((int)anItem.Settings.AppearancesSmall.Appearance.Image == 0)
				{
					// Change Item to Not Enabled
					//anItem.Checked = false;
					tag.IsChecked = false;
				}
				else
				{
					// Change Item to Enabled
					//anItem.Checked = true;
					tag.IsChecked = true;
				}
			}
			/// Item is selected now, so show its data
			string thistype = anItem.Key.ToLower();
			initTransComboBox(thistype);
			if (thistype == "beo") thistype = "eventorder";
			switch (thistype)
			{
				case "wastemode":
					{
						lCTDefaultModeTitle.Text = "Waste Mode pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.Wastemode_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.Wastemode_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.Wastemode_CTDefaultMode);
						break;
					}
				case "timestamp":
					{
						lCTDefaultModeTitle.Text = "Timestamp pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.Timestamp_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.Timestamp_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.Timestamp_NTPrefill);
						break;
					}
				case "user":
					{
						lCTDefaultModeTitle.Text = "User Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.UserType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.UserType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.User_CTDefaultMode);
						break;
					}
				case "food":
					{
						lCTDefaultModeTitle.Text = "Food Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.FoodType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.FoodType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.FoodType_CTDefaultMode);
						break;
					}
				case "loss":
					{
						lCTDefaultModeTitle.Text = "Loss Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.LossType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.LossType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.LossType_CTDefaultMode);
						break;
					}
				case "container":
					{
						lCTDefaultModeTitle.Text = "Container Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.ContainerType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.ContainerType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.ContainerType_CTDefaultMode);
						break;
					}
				case "station":
					{
						lCTDefaultModeTitle.Text = "Station Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.StationType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.StationType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.StationType_CTDefaultMode);
						break;
					}
				case "disposition":
					{
						lCTDefaultModeTitle.Text = "Disposition Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.DispositionType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.DispositionType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.DispositionType_CTDefaultMode);
						break;
					}
				case "daypart":
					{
						lCTDefaultModeTitle.Text = "Daypart Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.DaypartType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.DaypartType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.DaypartType_CTDefaultMode);
						break;
					}
				case "eventorder":
					{
						lCTDefaultModeTitle.Text = "Event Order Type pre-filled from:";
						lTBackcolor.BackColor = Color.FromArgb(DETMem.EventOrderType_BackColor);
						lTForecolor.BackColor = Color.FromArgb(DETMem.EventOrderType_ForeColor);
						cbCTDefaultMode.SelectedIndex = findComboBoxItembyKey(cbCTDefaultMode,
							DETMem.EventOrderType_CTDefaultMode);
						break;
					}
			}
			lTBackcolor.Update();
			lTForecolor.Update();
			pTransDetails1.Show();

		}

		private void initTransComboBox(string type)
		{
			cbCTDefaultMode.Items.Clear();
			cbCTDefaultMode.Text = "";
			if (type == "timestamp")
			{
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"None", "Null"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Previous", "Prev"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Current Date/Time", "Auto"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Session Start Date/Time", "Sess"));
				return;
			}
			if (type == "user")
			{
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"None", "Null"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Previous", "Prev"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Form Specific Default", "Form"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"User Entering Data", "Sess"));
				return;
			}
			if ((type == "station") || (type == "disposition") || (type == "daypart")
				 || (type == "wastemode"))
			{
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"None", "Null"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Previous", "Prev"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Form Specific Default", "Form"));
				cbCTDefaultMode.Items.Add(new ComboBoxItem(
					"Type List", "Auto"));
				return;
			}
			// if event order, food, loss, or container
			cbCTDefaultMode.Items.Add(new ComboBoxItem(
				"None", "Null"));
			cbCTDefaultMode.Items.Add(new ComboBoxItem(
				"Previous", "Prev"));
			cbCTDefaultMode.Items.Add(new ComboBoxItem(
				"Form Specific Default", "Form"));

		}


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
				ultra1_TaskItemImageClicked = false;
			}
			else
			{
				//MessageBox.Show("Image Clicked");
				ultra1_TaskItemImageClicked = true;
			}
		}
		private void ultraExplorerBar2_MouseDown(object sender, MouseEventArgs e)
		{
			Infragistics.Win.UIElement lastElementEntered = ultraExplorerBar2.UIElement.LastElementEntered;
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
				ultra2_TaskItemImageClicked = false;
			}
			else
			{
				//MessageBox.Show("Image Clicked");
				ultra2_TaskItemImageClicked = true;
			}
		}

		private void lFType_Click(object sender, EventArgs e)
		{
			
			frmAllTypesPicker frmat = new frmAllTypesPicker(ultra1_curritem.Key,
				"Choose " + ultra1_curritem.Text);
			if (frmat.ShowDialog() == DialogResult.OK)
			{
				lFTypeID.Text = frmat.TypeID;
				lFTypeName.Text = frmat.TypeName;
				string key = ultra1_curritem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
				{
					case "user":
						{
							DETMem.FormSet_UserType = frmat.TypeID;
							DETMem.FormSet_UserTypeName = frmat.TypeName;
							break;
						}
					case "food":
						{
							DETMem.FormSet_FoodType = frmat.TypeID;
							DETMem.FormSet_FoodTypeName = frmat.TypeName;
							break;
						}
					case "loss":
						{
							DETMem.FormSet_LossType = frmat.TypeID;
							DETMem.FormSet_LossTypeName = frmat.TypeName;
							break;
						}
					case "container":
						{
							DETMem.FormSet_ContainerType = frmat.TypeID;
							DETMem.FormSet_ContainerTypeName = frmat.TypeName;
							break;
						}
					case "station":
						{
							DETMem.FormSet_StationType = frmat.TypeID;
							DETMem.FormSet_StationTypeName = frmat.TypeName;
							break;
						}
					case "disposition":
						{
							DETMem.FormSet_DispositionType = frmat.TypeID;
							DETMem.FormSet_DispositionTypeName = frmat.TypeName;
							break;
						}
					case "daypart":
						{
							DETMem.FormSet_DaypartType = frmat.TypeID;
							DETMem.FormSet_DaypartTypeName = frmat.TypeName;
							break;
						}
					case "eventorder":
						{
							DETMem.FormSet_EventOrderType = frmat.TypeID;
							DETMem.FormSet_EventOrderTypeName = frmat.TypeName;
							break;
						}
				}
			
			}
		}

		private void lFBackcolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				string key = ultra1_CurrItem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
				{
					case "wastemode":
						{
							DETMem.FormSet_Wastemode_BackColor = cd.Color.ToArgb();
							break;
						}
					case "user":
						{
							DETMem.FormSet_UserType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "food":
						{
							DETMem.FormSet_FoodType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "loss":
						{
							DETMem.FormSet_LossType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "container":
						{
							DETMem.FormSet_ContainerType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "station":
						{
							DETMem.FormSet_StationType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "disposition":
						{
							DETMem.FormSet_DispositionType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "daypart":
						{
							DETMem.FormSet_DaypartType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "eventorder":
						{
							DETMem.FormSet_EventOrderType_BackColor = cd.Color.ToArgb();
							break;
						}
				}
				lFBackcolor.BackColor = cd.Color;
			}
			
		}

		private void lFForecolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				string key = ultra1_CurrItem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
				{
					case "wastemode":
						{
							DETMem.FormSet_Wastemode_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "user":
						{
							DETMem.FormSet_UserType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "food":
						{
							DETMem.FormSet_FoodType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "loss":
						{
							DETMem.FormSet_LossType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "container":
						{
							DETMem.FormSet_ContainerType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "station":
						{
							DETMem.FormSet_StationType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "disposition":
						{
							DETMem.FormSet_DispositionType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "daypart":
						{
							DETMem.FormSet_DaypartType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "eventorder":
						{
							DETMem.FormSet_EventOrderType_ForeColor = cd.Color.ToArgb();
							break;
						}
				}
				lFForecolor.BackColor = cd.Color;
			}
		}

		private void cbCTDefaultMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			//
			ComboBoxItem cbi = ((ComboBoxItem) cbCTDefaultMode.Items[cbCTDefaultMode.SelectedIndex]);
				string key = ultra2_CurrItem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
			{
				case "timestamp":
					{
						DETMem.Timestamp_NTPrefill = cbi.sID;
						break;
					}
				case "wastemode":
					{
						DETMem.Wastemode_CTDefaultMode = cbi.sID;
						break;
					}
				case "user":
					{
						DETMem.User_CTDefaultMode = cbi.sID;
						break;
					}
				case "food":
					{
						DETMem.FoodType_CTDefaultMode = cbi.sID;
						break;
					}
				case "loss":
					{
						DETMem.LossType_CTDefaultMode = cbi.sID;
						break;
					}
				case "container":
					{
						DETMem.ContainerType_CTDefaultMode = cbi.sID;
						break;
					}
				case "station":
					{
						DETMem.StationType_CTDefaultMode = cbi.sID;
						break;
					}
				case "disposition":
					{
						DETMem.DispositionType_CTDefaultMode = cbi.sID;
						break;
					}
				case "daypart":
					{
						DETMem.DaypartType_CTDefaultMode = cbi.sID;
						break;
					}
				case "eventorder":
					{
						DETMem.EventOrderType_CTDefaultMode = cbi.sID;
						break;
					}
			}
		}

		private void lTBackcolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				string key = ultra2_CurrItem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
				{
					case "timestamp":
						{
							DETMem.Timestamp_BackColor = cd.Color.ToArgb();
							break;
						}
					case "wastemode":
						{
							DETMem.Wastemode_BackColor = cd.Color.ToArgb();
							break;
						}
					case "user":
						{
							DETMem.UserType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "food":
						{
							DETMem.FoodType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "loss":
						{
							DETMem.LossType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "container":
						{
							DETMem.ContainerType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "station":
						{
							DETMem.StationType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "disposition":
						{
							DETMem.DispositionType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "daypart":
						{
							DETMem.DaypartType_BackColor = cd.Color.ToArgb();
							break;
						}
					case "eventorder":
						{
							DETMem.EventOrderType_BackColor = cd.Color.ToArgb();
							break;
						}
				}
				lTBackcolor.BackColor = cd.Color;
			}
		}

		private void lTForecolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				string key = ultra2_CurrItem.Key.ToLower();
				if (key == "beo") key = "eventorder";
				switch (key)
				{
					case "timestamp":
						{
							DETMem.Timestamp_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "wastemode":
						{
							DETMem.Wastemode_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "user":
						{
							DETMem.UserType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "food":
						{
							DETMem.FoodType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "loss":
						{
							DETMem.LossType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "container":
						{
							DETMem.ContainerType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "station":
						{
							DETMem.StationType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "disposition":
						{
							DETMem.DispositionType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "daypart":
						{
							DETMem.DaypartType_ForeColor = cd.Color.ToArgb();
							break;
						}
					case "eventorder":
						{
							DETMem.EventOrderType_ForeColor = cd.Color.ToArgb();
							break;
						}
				}
				lTForecolor.BackColor = cd.Color;
			}
		}

		private void lFAreaBackcolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lFAreaBackcolor.BackColor = cd.Color;
				DETMem.FormSet_BackColor = cd.Color.ToArgb();
			}
		}

		private void lTAreaBackcolor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lTAreaBackcolor.BackColor = cd.Color;
				DETMem.Transaction_BackColor = cd.Color.ToArgb();
			}
		}

		private void lQuantityBackColorpicker_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lQuantityBackColorpicker.BackColor = cd.Color;
				DETMem.Quantity_BackColor = cd.Color.ToArgb();
			}
		}

		private void lQuantityForeColorpicker_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lQuantityForeColorpicker.BackColor = cd.Color;
				DETMem.Quantity_ForeColor = cd.Color.ToArgb();
			}
		}
		private void lUserNotesBackColorpicker_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lUserNotesBackColorpicker.BackColor = cd.Color;
				DETMem.UserNotes_BackColor = cd.Color.ToArgb();
			}
		}

		private void lUserNotesForeColorpicker_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				lUserNotesForeColorpicker.BackColor = cd.Color;
				DETMem.UserNotes_ForeColor = cd.Color.ToArgb();
			}
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			if (DETMem != null)
			{
				DialogResult dr = MessageBox.Show("Save Current Changes to " + tDETName.Text + "?", "Manage Data Entry Templates",
					MessageBoxButtons.YesNoCancel);
				if (dr == DialogResult.Cancel) return;
				if (dr == DialogResult.Yes)
				{
					SaveDET();
				}
			}
			commonEvents.TaskSheetKey = "dashboard";
		}
		
		private void bSave_Click(object sender, EventArgs e)
		{
			SaveDET();
		}
		/// <summary>
		/// Save this Template.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveDET()
		{
			// Prepare
			// Formset display order
			string formset_displayorder = "";
			for (int i = 0; i < ultraExplorerBar1.Groups[0].Items.Count; i++)
			{
				//if (ultraExplorerBar1.Groups[0].Items[i].Checked)
				if (((mFItemTag)ultraExplorerBar1.Groups[0].Items[i].Tag).IsChecked)
				{
					if (formset_displayorder != "") formset_displayorder += ",";
					// add to displayorder
					formset_displayorder += ultraExplorerBar1.Groups[0].Items[i].Key.ToLower();
				}
			}
			// Transaction display order
			string transaction_displayorder = "";
			for (int i = 0; i < ultraExplorerBar2.Groups[0].Items.Count; i++)
			{
				//if (ultraExplorerBar2.Groups[0].Items[i].Checked)
				if (((mFItemTag)ultraExplorerBar2.Groups[0].Items[i].Tag).IsChecked)
				{
					if (transaction_displayorder != "") transaction_displayorder += ",";
					// add to displayorder
					transaction_displayorder += ultraExplorerBar2.Groups[0].Items[i].Key.ToLower();
				}
			}
			//// Session display order
			//string session_displayorder = "";
			//for (int i = 0; i < ultraExplorerBar1.Groups[0].Items.Count; i++)
			//{
			//    if (ultraExplorerBar1.Groups[0].Items[i].Checked)
			//    {
			//        if (session_displayorder != "") session_displayorder += ",";
			//        // add to displayorder
			//        session_displayorder += ultraExplorerBar1.Groups[0].Items[i].Key.ToLower();
			//    }
			//}

			//
			string sql = "INSERT INTO DataEntryTemplates(DETName, DETDescription,"
				+ " Quantity_CTDefaultMode, Quantity_BackColor, Quantity_ForeColor, "
				+ " FormSet_displayorder, FormSet_Backcolor, FormSet_Wastemode,"
				+ " FormSet_Wastemode_BackColor, FormSet_Wastemode_ForeColor,"
				+ " FormSet_UserType, FormSet_UserType_Backcolor, FormSet_UserType_Forecolor,"
				+ " FormSet_FoodType, FormSet_FoodType_Backcolor, FormSet_FoodType_Forecolor,"
				+ " FormSet_LossType, FormSet_LossType_Backcolor, FormSet_LossType_Forecolor,"
				+ " FormSet_ContainerType, FormSet_ContainerType_Backcolor, FormSet_ContainerType_Forecolor,"
				+ " FormSet_StationType, FormSet_StationType_Backcolor, FormSet_StationType_Forecolor,"
				+ " FormSet_DispositionType, FormSet_DispositionType_Backcolor, FormSet_DispositionType_Forecolor,"
				+ " FormSet_DaypartType, FormSet_DaypartType_Backcolor, FormSet_DaypartType_Forecolor,"
				+ " FormSet_EventorderType, FormSet_EventorderType_Backcolor, FormSet_EventorderType_Forecolor,"
				+ " Transaction_displayorder, Transaction_Backcolor, UserNotes_TShow,"
				+ " UserNotes_Backcolor, UserNotes_Forecolor,"
				+ " Timestamp_NTPrefill, Timestamp_TFormat,"
				+ " Timestamp_BackColor, Timestamp_ForeColor,"
				+ " Wastemode_CTDefaultMode, Wastemode_BackColor, Wastemode_ForeColor,"
				+ " User_CTDefaultMode, UserType_Backcolor, UserType_Forecolor,"
				///
				+ " FoodType_CTDefaultMode, FoodType_Backcolor, FoodType_Forecolor,"
				+ " LossType_CTDefaultMode, LossType_Backcolor, LossType_Forecolor,"
				+ " ContainerType_CTDefaultMode, ContainerType_Backcolor, ContainerType_Forecolor,"
				+ " StationType_CTDefaultMode, StationType_Backcolor, StationType_Forecolor,"
				+ " DispositionType_CTDefaultMode, DispositionType_Backcolor, DispositionType_Forecolor,"
				+ " DaypartType_CTDefaultMode, DaypartType_Backcolor, DaypartType_Forecolor,"
				+ " EventorderType_CTDefaultMode, EventorderType_Backcolor, EventorderType_Forecolor)"
				+ " VALUES('" + tDETName.Text + "','" + tDescription.Text + "','"
				+ DETMem.Quantity_CTDefaultMode + "'," + DETMem.Quantity_BackColor.ToString() + ","
				+ DETMem.Quantity_ForeColor.ToString() + ",'"
				+ formset_displayorder + "',"
				+ DETMem.FormSet_BackColor.ToString() + ",'"
				+ DETMem.FormSet_Wastemode + "'," + DETMem.FormSet_Wastemode_BackColor.ToString() + ","
				+ DETMem.FormSet_Wastemode_ForeColor + ",'"
				+ DETMem.FormSet_UserType + "'," + DETMem.FormSet_UserType_BackColor.ToString() + ","
				+ DETMem.FormSet_UserType_ForeColor + ",'"
				+ DETMem.FormSet_FoodType + "'," + DETMem.FormSet_FoodType_BackColor.ToString() + ","
				+ DETMem.FormSet_FoodType_ForeColor + ",'"
				+ DETMem.FormSet_LossType + "'," + DETMem.FormSet_LossType_BackColor.ToString() + ","
				+ DETMem.FormSet_LossType_ForeColor + ",'"
				+ DETMem.FormSet_ContainerType + "'," + DETMem.FormSet_ContainerType_BackColor.ToString() + ","
				+ DETMem.FormSet_ContainerType_ForeColor + ",'"
				+ DETMem.FormSet_StationType + "'," + DETMem.FormSet_StationType_BackColor.ToString() + ","
				+ DETMem.FormSet_StationType_ForeColor + ",'"
				+ DETMem.FormSet_DispositionType + "'," + DETMem.FormSet_DispositionType_BackColor.ToString() + ","
				+ DETMem.FormSet_DispositionType_ForeColor + ",'"
				+ DETMem.FormSet_DaypartType + "'," + DETMem.FormSet_DaypartType_BackColor.ToString() + ","
				+ DETMem.FormSet_DaypartType_ForeColor + ",'"
				+ DETMem.FormSet_EventOrderType + "'," + DETMem.FormSet_EventOrderType_BackColor.ToString() + ","
				+ DETMem.FormSet_EventOrderType_ForeColor + ",'"
				+ transaction_displayorder + "'," + DETMem.Transaction_BackColor.ToString() + ","
				+ DETMem.UserNotes_TShow.ToString() + "," + DETMem.UserNotes_BackColor.ToString() + ","
				+ DETMem.UserNotes_ForeColor.ToString() + ",'"
				+ DETMem.Timestamp_NTPrefill + "','" + DETMem.Timestamp_TFormat + "',"
				+ DETMem.Timestamp_BackColor.ToString() + "," + DETMem.Timestamp_ForeColor.ToString() + ",'"
				+ DETMem.Wastemode_CTDefaultMode + "'," + DETMem.Wastemode_BackColor.ToString() + ","
				+ DETMem.Wastemode_ForeColor.ToString() + ",'"
				+ DETMem.User_CTDefaultMode + "'," + DETMem.UserType_BackColor + ","
				+ DETMem.UserType_ForeColor + ",'"
				///
				+ DETMem.FoodType_CTDefaultMode + "'," + DETMem.FoodType_BackColor + "," + DETMem.FoodType_ForeColor + ",'"
				+ DETMem.LossType_CTDefaultMode + "'," + DETMem.LossType_BackColor + "," + DETMem.LossType_ForeColor + ",'"
				+ DETMem.ContainerType_CTDefaultMode + "'," + DETMem.ContainerType_BackColor + "," + DETMem.ContainerType_ForeColor + ",'"
				+ DETMem.StationType_CTDefaultMode + "'," + DETMem.StationType_BackColor + "," + DETMem.StationType_ForeColor + ",'"
				+ DETMem.DispositionType_CTDefaultMode + "'," + DETMem.DispositionType_BackColor + "," + DETMem.DispositionType_ForeColor + ",'"
				+ DETMem.DaypartType_CTDefaultMode + "'," + DETMem.DaypartType_BackColor + "," + DETMem.DaypartType_ForeColor + ",'"
				+ DETMem.EventOrderType_CTDefaultMode + "'," + DETMem.EventOrderType_BackColor + "," + DETMem.EventOrderType_ForeColor + ")"
				;
			int newdetid = VWA4Common.DB.Insert(sql);
			// If this is an edited Data Entry Template...
			if (DETMem.DETID != 0)
			{
				//// Do a Read of the current and new DETs to see what's up
				//DataTable dt_olddet = VWA4Common.DB.Retrieve("SELECT * FROM DataEntryTemplates WHERE ID=" + DETMem.DETID.ToString());
				//DataTable dt_newdet = VWA4Common.DB.Retrieve("SELECT * FROM DataEntryTemplates WHERE ID=" + newdetid.ToString());
				// Change weights records to new Data Entry Template
				sql = "UPDATE Weights SET DETID=" + newdetid.ToString() + " WHERE DETID="
					+ DETMem.DETID.ToString();
				VWA4Common.DB.Update(sql);
				// Delete the old Data Entry Template
				sql = "DELETE FROM DataEntryTemplates WHERE ID=" + DETMem.DETID.ToString();
				VWA4Common.DB.Delete(sql);
				//DataTable dt_olddetafterdelete = VWA4Common.DB.Retrieve("SELECT * FROM DataEntryTemplates WHERE ID=" + DETMem.DETID.ToString());
				//    MessageBox.Show("Old DET Record Count before delete = " + dt_olddet.Rows.Count.ToString() 
				//        + " (ID=" + DETMem.DETID.ToString() +") \n"
				//        + "New DET Record Count = " + dt_newdet.Rows.Count.ToString()
				//                + " (ID=" + newdetid.ToString() + ") \n"
				//+ "Old DET Record Count after delete = " + dt_olddetafterdelete.Rows.Count.ToString());
				DETMem.DETID = newdetid;
			}  // if not, then no weight records to modify, nor old Data Entry Templates to delete
		}


		private void cbxUserNotes_TShow_CheckedChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				DETMem.UserNotes_TShow = cbxUserNotes_TShow.Checked;
				lUserNotesBackColor.Visible = cbxUserNotes_TShow.Checked;
				lUserNotesForeColor.Visible = cbxUserNotes_TShow.Checked;
				lUserNotesBackColorpicker.Visible = cbxUserNotes_TShow.Checked;
				lUserNotesForeColorpicker.Visible = cbxUserNotes_TShow.Checked;
			}
		}

		private void cbFormSet_Wastemode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
				DETMem.FormSet_Wastemode = ((ComboBoxItem)cbFormSet_Wastemode.Items[cbFormSet_Wastemode.SelectedIndex]).sID;
		}

		private void cbQuantityDefaultMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Initialized)
			{
				//•	“Wt” => Weight mode
				//•	“Each” => Each mode
				//•	“Vol” => Volume mode
				//•	“Prev” => Use mode from previous transaction
				switch (cbQuantityDefaultMode.SelectedIndex)
				{
					case 0:
						{
							DETMem.Quantity_CTDefaultMode = "each";
							break;
						}
					case 1:
						{
							DETMem.Quantity_CTDefaultMode = "vol";
							break;
						}
					case 3:
						{
							DETMem.Quantity_CTDefaultMode = "prev";
							break;
						}
					default:
						{
							DETMem.Quantity_CTDefaultMode = "wt";
							break;
						}
				}
			}
		}
		private void ultraExplorerBar2_Click(object sender, EventArgs e)
		{
			ultra2_CurrItem = ultraExplorerBar2.ActiveItem;
		}

		private void ultraExplorerBar1_Click(object sender, EventArgs e)
		{
			ultra1_CurrItem = ultraExplorerBar1.ActiveItem;
		}

		private void tDETName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == (System.Char)Keys.Back) || (e.KeyChar == (System.Char)Keys.Delete)) return;
			if ((((TextBox)sender).Text == ""))
			{ // this is the first character - must be letter
				if (char.IsLetter(e.KeyChar)) return;
				e.Handled = true;
			}
			else
			{ // we already have the beginnings of a name
				if (char.IsLetterOrDigit(e.KeyChar) ||
					(e.KeyChar == (System.Char)Keys.Space) ||
					(e.KeyChar == "."[0]) ||
					(e.KeyChar == ","[0]) ||
					(e.KeyChar == "-"[0]) ||
					(e.KeyChar == "$"[0]) ||
					(e.KeyChar == "%"[0]) ||
					(e.KeyChar == "/"[0]) ||
					(e.KeyChar == "^"[0]) ||
					(e.KeyChar == "*"[0]) ||
					(e.KeyChar == ">"[0]) ||
					(e.KeyChar == "<"[0]) ||
					(e.KeyChar == "{"[0]) ||
					(e.KeyChar == "}"[0]) ||
					(e.KeyChar == "~"[0]) ||
					(e.KeyChar == "@"[0]) ||
					(e.KeyChar == "!"[0]) ||
					(e.KeyChar == "#"[0]))
				return;
				e.Handled = true;
			}

		}



	}
}
