using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class UCAddUser : UserControl, IVWAUserControlBase 
	{
		public bool Initialized;

		VWA4Common.CommonEvents commonEvents = null;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change

		/// <summary>
		/// Constructor
		/// </summary>
		public UCAddUser()
		{
			InitializeComponent();
		}

		public void Init(DateTime firstDayOfWeek)
		{
            _IsActive = true;
			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
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

		public void LoadData()
		{
			Initialized = false;
			clearData();
			bCancel.Hide();
			bSave.Hide();
			initUserNameLabels();
			initAllLabels();
			if (teUserName1.Visible) teUserName1.Focus();
			Initialized = true;
		}

		public void SaveData()
		{
		}

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

		private void initAllLabels()
		{
			hideLabels();
			int n = checkLimits();
			if (n-- > 0)
			{
				l1.Show();
				teUserName1.Show();
				ltitle.Show();
			}
			else lError.Show();
			//
			if (n-- > 0)
			{
				l2.Show();
				teUserName2.Show();
			}
			if (n-- > 0)
			{
				l3.Show();
				teUserName3.Show();
			}
			if (n-- > 0)
			{
				l4.Show();
				teUserName4.Show();
			}
			if (n-- > 0)
			{
				l5.Show();
				teUserName5.Show();
			}
			if (n-- > 0)
			{
				l6.Show();
				teUserName6.Show();
			}
			if (n-- > 0)
			{
				l7.Show();
				teUserName7.Show();
			}
			if (n-- > 0)
			{
				l8.Show();
				teUserName8.Show();
			}
			if (n-- > 0)
			{
				l9.Show();
				teUserName9.Show();
			}
			if (n-- > 0)
			{
				l10.Show();
				teUserName10.Show();
			}
		}

		private void hideLabels()
		{
			lError.Hide();
			ltitle.Hide();
			l1.Hide();
			teUserName1.Hide();
			l2.Hide();
			teUserName2.Hide();
			l3.Hide();
			teUserName3.Hide();
			l4.Hide();
			teUserName4.Hide();
			l5.Hide();
			teUserName5.Hide();
			l6.Hide();
			teUserName6.Hide();
			l7.Hide();
			teUserName7.Hide();
			l8.Hide();
			teUserName8.Hide();
			l9.Hide();
			teUserName9.Hide();
			l10.Hide();
			teUserName10.Hide();
		}
		
		private void clearData()
		{
			Initialized = false;
			teUserName1.Text = "";
			teUserName1.Appearance.ForeColor = Color.Black;
			teUserName2.Text = "";
			teUserName2.Appearance.ForeColor = Color.Black;
			teUserName3.Text = "";
			teUserName3.Appearance.ForeColor = Color.Black;
			teUserName4.Text = "";
			teUserName4.Appearance.ForeColor = Color.Black;
			teUserName5.Text = "";
			teUserName5.Appearance.ForeColor = Color.Black;
			teUserName6.Text = "";
			teUserName6.Appearance.ForeColor = Color.Black;
			teUserName7.Text = "";
			teUserName7.Appearance.ForeColor = Color.Black;
			teUserName8.Text = "";
			teUserName8.Appearance.ForeColor = Color.Black;
			teUserName9.Text = "";
			teUserName9.Appearance.ForeColor = Color.Black;
			teUserName10.Text = "";
			teUserName10.Appearance.ForeColor = Color.Black;
			teUserName1.Focus();
			Initialized = true;
		}

		/// <summary>
		/// Check # of User types currently enabled, and return the # of user types that can be added.
		/// </summary>
		/// <returns>Number of user types that can legally be added currently.</returns>
		private int checkLimits()
		{
			// Get the number of User types currently enabled.
			//
			return VWA4Common.GlobalSettings.MaxNumberofUserTypes - numUsersinUse();
		}
		
		private void initUserNameLabels()
		{
			lLicensedMax.Text = "Licensed Maximum Number of Users:  " + VWA4Common.GlobalSettings.MaxNumberofUserTypes.ToString();
			lNumberUsersinUse.Text = "Number of Users Currently in Use:  " + numUsersinUse().ToString();

		}

		private int numUsersinUse()
		{
			DataTable dt = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM UserType WHERE Enabled = TRUE");
			int numUserTypes = (int)dt.Rows[0][0];
			return numUserTypes;
		}


		private void bSave_Click(object sender, EventArgs e)
		{
			Initialized = false;
			
			bool errors = false;
			// teUserName1
			if (teUserName1.Text != "")
				if (!SaveUser(teUserName1.Text))
				{ // not unique and not saved
					teUserName1.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName1.Text = "";
				}
			// teUserName2
			if (teUserName2.Text != "")
				if (!SaveUser(teUserName2.Text))
				{ // not unique and not saved
					teUserName2.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName2.Text = "";
				}
			// teUserName3
			if (teUserName3.Text != "")
				if (!SaveUser(teUserName3.Text))
				{ // not unique and not saved
					teUserName3.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName3.Text = "";
				}
			// teUserName4
			if (teUserName4.Text != "")
				if (!SaveUser(teUserName4.Text))
				{ // not unique and not saved
					teUserName4.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName4.Text = "";
				}
			// teUserName5
			if (teUserName5.Text != "")
				if (!SaveUser(teUserName5.Text))
				{ // not unique and not saved
					teUserName5.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName5.Text = "";
				}
			// teUserName6
			if (teUserName6.Text != "")
				if (!SaveUser(teUserName6.Text))
				{ // not unique and not saved
					teUserName6.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName6.Text = "";
				}
			// teUserName7
			if (teUserName7.Text != "")
				if (!SaveUser(teUserName7.Text))
				{ // not unique and not saved
					teUserName7.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName7.Text = "";
				}
			// teUserName8
			if (teUserName8.Text != "")
				if (!SaveUser(teUserName8.Text))
				{ // not unique and not saved
					teUserName8.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName8.Text = "";
				}
			// teUserName9
			if (teUserName9.Text != "")
				if (!SaveUser(teUserName9.Text))
				{ // not unique and not saved
					teUserName9.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName9.Text = "";
				}
			// teUserName10
			if (teUserName10.Text != "")
				if (!SaveUser(teUserName10.Text))
				{ // not unique and not saved
					teUserName10.Appearance.ForeColor = Color.Red;
					errors = true;
				}
				else
				{ // saved
					teUserName10.Text = "";
				}
			///
			if (errors)
			{ // Inform User
				MessageBox.Show("Some User names (red) were not unique and could not be saved.");
			}
			else
			{ // All is well - back to start state
				clearData();
				initUserNameLabels();
				initAllLabels();
				bCancel.Hide();
				bSave.Hide();
			}
			Initialized = true;
		}

		private bool SaveUser(string username)
		{
			// First check to see if string is blank
			if (username == "") return false;
			// First check to see if there is already a user type with this name
			if (VWA4Common.Utilities.CheckTypeNameUnique(username.Trim(),
				 "UserType", 0))
			{ // unique - proceed to add
				// First get the category to put it in
				int parentcatid = VWA4Common.Utilities.GetQuickAddCategory("UserCategory", "(Quick Add User Types)");
				// Get a new TypeID
				string newtypeid = VWA4Common.Utilities.GetNewTypeID("ZUS_", "UserType");
				// Add the new type
				string sql = "INSERT INTO UserType(TypeID,CatID,TypeName,ReportTypeName,SpanishTypeName,ModifiedDate,Description)"
					+ " VALUES('" + newtypeid + "'," + parentcatid.ToString() + ","
					+ "'" + username + "','" + username + "','" + username + "',"
					+ "#" + DateTime.Now.ToShortDateString() + "#,"
					+ "'Quick-added " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "')";
				int id = VWA4Common.DB.Insert(sql);

				// Add to all the active Trackers
				AddUsertoAllTrackers(newtypeid, username);
                VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
				return true;
			}
			else
			{ // not unique 
				return false;
			}
		}

		private void AddUsertoAllTrackers(string usertypeid, string usertypename)
		{
			// Iterate through the Terminals and add the provided user for each
			string sql = "SELECT * FROM Terminals WHERE (Active=true)";
			DataTable dt_terminals = VWA4Common.DB.Retrieve(sql);
			foreach (DataRow rowterm in dt_terminals.Rows)
			{
				// Find the root MenuID
				string sqll = "SELECT MenuID FROM TrackerUserMenus WHERE (TermID='"
					+ rowterm["TermID"].ToString() + "') AND (ParentMenuID=0)";
				DataTable dt_trkrmenus = VWA4Common.DB.Retrieve(sqll);
				DataRow drt = dt_trkrmenus.Rows[0];
				// Insert a User into the TrackerUserButtons table
				sqll = "INSERT INTO TrackerUserButtons(TypeID,MenuID,TermID,ButtonName,SpanishButtonName)"
					+ " VALUES('" + usertypeid + "'," + drt["MenuID"].ToString() + ",'" + rowterm["TermID"].ToString() + "','"
					+ usertypename + "','" + usertypename + "')";
				VWA4Common.DB.Insert(sqll);
			}
				
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			clearData();
			bCancel.Hide();
			bSave.Hide();
		}

		private void teUserName_TextChanged(object sender, EventArgs e)
		{
			if ((Initialized) && ((((Infragistics.Win.UltraWinEditors.UltraTextEditor)sender).Text != "")
				&& (((Infragistics.Win.UltraWinEditors.UltraTextEditor)sender).Text != " ")))
			{
				bCancel.Show();
				bSave.Show();
			}
		}

		private void teUserName1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == (System.Char)Keys.Back) || (e.KeyChar == (System.Char)Keys.Delete)) return;
			if ((((Infragistics.Win.UltraWinEditors.UltraTextEditor)sender).Text == ""))
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
					(e.KeyChar == "_"[0])) return;
				e.Handled = true;
			}
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			CloseSheet();
		}
		private void CloseSheet()
		{
			clearData();
			bCancel.Hide();
			bSave.Hide();
			commonEvents.TaskSheetKey = "dashboard";
		}
		private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Quick Add/Remove Users")))
				CloseSheet();
		}
	}
}
