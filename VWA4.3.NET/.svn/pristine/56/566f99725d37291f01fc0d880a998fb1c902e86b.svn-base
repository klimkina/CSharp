using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace UserControls
{
    public partial class UCFooter : UserControl, IVWAUserControlBase
    {
		/// Class level elements
		VWA4Common.DBDetector dbDetector = null;
		VWA4Common.CommonEvents commonEvents = null;
		Color labeltextcolor;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCFooter()
        {
            InitializeComponent();
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
                dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
            }
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			commonEvents.DisplayOptionsChanged += new VWA4Common.DisplayOptionsChangedEventHandler(commonEvents_DisplayOptionsChanged);
			//labeltextcolor = lAddUsers.ForeColor;
        }


		///		
		/// Interface methods for User Controls
		///		


        public void Init(DateTime firstDayOfWeek)
        {
            _IsActive = true;
        }

		public void LoadData()
		{
			// Load the current Database control
			lCurrentDB.Text = System.IO.Path.GetFileName(VWA4Common.AppContext.DBPathName);

			//lTransferConfiguration.Hide();
			//lManageRecurringTransactions.Hide();
			
			//// Manage Baselines 
			//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Baselines"]))
			//    lManageBaselines.Show();
			//else
			//    lManageBaselines.Hide();
			//// Quick Add/Remove Users
			//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
			//{
			//    lAddUsers.Show();
			//    lRemoveUsers.Show();
			//}
			//else
			//{
			//    lAddUsers.Hide();
			//    lRemoveUsers.Hide();
			//}
			CheckLabels();
			CheckDisplayState();
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

		///
		/// Methods for reconfiguring the footer on the fly
		/// 
		//
		/// <summary>
		/// Reset the header to current personality/configuration.
		/// </summary>
		/// <param name="backcolor">color for background of the header</param>
		/// <param name="showcurrweek">true: show current week controls; false: hide 'em.</param>
		/// <param name="showsite">true: show current site controls; false: hide 'em.</param>
		public void resetFooter(Color backcolor, bool showshortcuts, bool showsettings,
			bool showcurruser, bool showcurrdatabase)
		{
			panel5.Visible = VWA4Common.GlobalSettings.LeanPathLogoVisibleinFooter;

			this.BackColor = backcolor;

			if (showshortcuts)
			{
				pictureBox1.Show();
				label1.Show();
				panel3.Show();
			}
			else
			{
				pictureBox1.Hide();
				label1.Hide();
				panel3.Hide();
			}

			if (showsettings)
			{
				pictureBox2.Show();
				label2.Show();
				panel4.Show();
			}
			else
			{
				pictureBox2.Hide();
				label2.Hide();
				panel4.Hide();
			}
			if (showcurruser)
			{
				lblCurrentUser.Show();
				lblUser.Show();
			}
			else
			{
				lblCurrentUser.Hide();
				lblUser.Hide();
			}
			if (showcurrdatabase)
			{
				label5.Show();
				lCurrentDB.Show();
			}
			else
			{
				label5.Hide();
				lCurrentDB.Hide();
			}
		}
	
		///
		/// Event logic
		///  Main subscribes to LabelClicked event to launch the appropriate task.
		/// 

		private void CheckLabels()
		{
			bManageRecurringTransactions.Visible = VWA4Common.GlobalSettings.RecurringTransactionsAvailable;
			//bManageRecurringTransactions.Visible = VWA4Common.SecurityManager.IsLogged && bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Recurring Transactions"]);
			bTransferConfiguration.Visible =
				bTransferConfiguration.Visible = VWA4Common.GlobalSettings.UpdateTrackerAvailable;
			//bTransferConfiguration.Visible =
			//    VWA4Common.SecurityManager.IsLogged && bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Manage Trackers"]);
			bManageReports.Visible = VWA4Common.GlobalSettings.ManageReportsAvailable;
			bAddUsers.Visible = VWA4Common.GlobalSettings.AddUsersAvailable;
			bRemoveUsers.Visible = VWA4Common.GlobalSettings.RemoveUsersAvailable;
			
			//if (bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Quick Add/Remove Users"]))
			//{
			//    bAddUsers.Show();
			//    bRemoveUsers.Show();
			//}
			//else
			//{
			//    bAddUsers.Hide();
			//    bRemoveUsers.Hide();
			//}

			lblUser.Text = VWA4Common.GlobalSettings.GetUserLevelName();  //(VWA4Common.SecurityManager.IsLogged ? (VWA4Common.SecurityManager.IsSuper ? "Administrator" : "Manager") : "Default");
		}



		public class LabelClickedEventArgs : EventArgs
        {
            private string _LabelName;

            public string LabelName
            {
                get { return _LabelName; }
                set { _LabelName = value; }
            }

            public LabelClickedEventArgs(string name)
            {
                _LabelName = name;
            }

        }
        public delegate void LabelClickedEventHandler(object sender, LabelClickedEventArgs e);
        private LabelClickedEventHandler labelClicked;
        public event LabelClickedEventHandler LabelClicked
        {
            add { labelClicked += value; }
            remove { labelClicked -= value; }
        }
        public void SetLabelClicked(string name)
        {
            OnLabelClicked(new LabelClickedEventArgs(name));
        }
        protected virtual void OnLabelClicked(LabelClickedEventArgs e)
        {
            if (labelClicked != null)
                labelClicked(this, e);
        }

		/// Event handlers
		/// 
		/// Dispatch tasks based on label clicks

		private void commonEvents_DisplayOptionsChanged(object sender, EventArgs e)
		{
			CheckDisplayState();
		}

		private void CheckDisplayState()
		{
			// Shortcuts container, icons Shown or not
			pictureBox1.Visible = bool.Parse(VWA4Common.GlobalSettings.FooterShortcutsOn.ToString());
			label1.Visible = pictureBox1.Visible;
			panel3.Visible = pictureBox1.Visible;

			// Settings  container, icons Shown or not
			pictureBox2.Visible = bool.Parse(VWA4Common.GlobalSettings.FooterSettingsOn.ToString());
			label2.Visible = pictureBox2.Visible;
			panel4.Visible = pictureBox2.Visible;
			// Database and Login Info Shown or not
			lCurrentDB.Visible = bool.Parse(VWA4Common.GlobalSettings.FooterDatabaseandLoginInfoOn.ToString());
			label5.Visible = lCurrentDB.Visible;
			lblCurrentUser.Visible = lCurrentDB.Visible;
			lblUser.Visible = lCurrentDB.Visible;
		}

		private void TransferConfig_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("TransferConfig");
			resetlabelborders();
			resetlabelcolors();
		}
		
		private void ManagePaperUI_Click(object sender, EventArgs e)
        {

            if (sender != null)
                SetLabelClicked("PaperUIMgr");
			resetlabelborders();
			resetlabelcolors();
		}
		private void lManageReports_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("ManageReports");
			resetlabelborders();
			resetlabelcolors();
		}

        private void lManageSites_Click(object sender, EventArgs e)
        {
            VWA4Common.Utilities.launchDelphi(1,VWA4Common.GlobalSettings.IsSuper,
				"-1");
	        dbDetector.DBInvalidate = true; // fire (cause) the event
			resetlabelborders();
			resetlabelcolors();
		}

        private void lManageTypes_Click(object sender, EventArgs e)
        {
			VWA4Common.Utilities.launchDelphi(2, VWA4Common.GlobalSettings.IsSuper,
				"-1");
            dbDetector.DBInvalidate = true; // fire (cause) the event
			resetlabelborders();
			resetlabelcolors();
		}

        private void lManageTrackers_Click(object sender, EventArgs e)
        {
			VWA4Common.Utilities.launchDelphi(3, VWA4Common.GlobalSettings.IsSuper,
				"-1"); 
			dbDetector.DBInvalidate = true; // fire (cause) the event
			resetlabelborders();
			resetlabelcolors();
		}

		private void lManageBaselines_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("BaselineMgr");
			resetlabelborders();
			resetlabelcolors();
		}

		private void lDeleteUser_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("DeleteUser");
			resetlabelborders();
			resetlabelcolors();
		}

		private void lAddUser_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("AddUser");
			resetlabelborders();
			resetlabelcolors();
		}
		
		private void lCurrentDB_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked("CurrentDB");
			resetlabelborders();
			resetlabelcolors();
		}
		private void lblUser_Click(object sender, EventArgs e)
		{
			if (sender != null)
				SetLabelClicked(lblUser.Text);
			resetlabelborders();
			resetlabelcolors();
		}

		///
		/// Mouse click highlighting
		///

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Red;
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = labeltextcolor;
        }

        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
        {
			CheckLabels();
        }

		private void lAnyNavLabel_MouseEnter(object sender, EventArgs e)
		{
			resetlabelborders();
			
			Label lbl = (Label)sender;
			lbl.BorderStyle = BorderStyle.FixedSingle;
			//lbl.ForeColor = Color.FromArgb(60, 158, 158);
		}

		private void lAnyNavLabel_MouseLeave(object sender, EventArgs e)
		{
			resetlabelborders();
		}


		private void pbLPLogo_MouseEnter(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			resetlabelborders();
			resetlabelcolors();
			pb.BorderStyle = BorderStyle.FixedSingle;
		}

		private void pbLPLogo_MouseLeave(object sender, EventArgs e)
		{
			resetlabelborders();
			resetlabelcolors();
		}

		private void resetlabelborders()
		{
			//lAddUsers.BorderStyle = BorderStyle.None;
			//lRemoveUsers.BorderStyle = BorderStyle.None;
			//lTransferConfiguration.BorderStyle = BorderStyle.None;
			//lManageReports.BorderStyle = BorderStyle.None;
			//lManageRecurringTransactions.BorderStyle = BorderStyle.None;
			lCurrentDB.BorderStyle = BorderStyle.None;
			lblUser.BorderStyle = BorderStyle.None;
			pbLPLogo.BorderStyle = BorderStyle.None;
		}
		private void resetlabelcolors()
		{
			//lAddUsers.ForeColor = labeltextcolor;
			//lRemoveUsers.ForeColor = labeltextcolor;
			//lTransferConfiguration.ForeColor = labeltextcolor;
			//lManageReports.ForeColor = labeltextcolor;
			//lManageRecurringTransactions.ForeColor = labeltextcolor;
			lCurrentDB.ForeColor = labeltextcolor;
			lblUser.ForeColor = labeltextcolor;
		}

		private void pbLPLogo_Click(object sender, EventArgs e)
		{
			if (sender != null) System.Diagnostics.Process.Start("http://client.leanpath.com");
				//SetLabelClicked("clicklplogo");
			resetlabelborders();
			resetlabelcolors();
		}

		private void ControlNoNav_MouseEnter(object sender, EventArgs e)
		{
			resetlabelcolors();
			resetlabelborders();
		}

    }
}
