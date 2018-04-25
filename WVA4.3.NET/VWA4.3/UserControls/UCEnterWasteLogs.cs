using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors;
using VWA4Common;

namespace UserControls
{
	public partial class UCEnterWasteLogs : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		bool SkipSelectedIndexChangedHandler;
		private Dictionary<string, VWA4Common.Transaction_Mem> transactions_listview;
		
		private DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;
		private int spacing = 6;
		private int formheaderleftindent = 16;
		private BorderStyle borderstyle;
		private string dateFormat;
		private string timeFormat;
		private bool LongDateFormat
		{
			get
			{
				return dateFormat == "long";
			}
		}
		private bool LongTimeFormat
		{
			get
			{
				return timeFormat == "long";
			}
		}
		private int defaultTemplate;
		
		/// 
		/// Buffers for holding the current Transaction's data
		///
		VWA4Common.Transaction_Mem CurrTrans = null;
		VWA4Common.Transaction_Mem PrevTrans = null;

		GlobalClasses.DataEntrySession Sess_Current = null;
		
		// Flags
		bool bQuantityGood;
		bool bEditingSavedTrans_CurrTrans;
		bool bDirty_CurrTrans; // Current Transaction has been modified

        //// Volume mode
		decimal dVol_ContainerMultiplier;

        //// Each mode
		int iEach_EachFormatID;
		decimal dEach_ItemQuantity;
		
		/// Cursor for redrawing task screen

		Point cursor;
		Point lastbottomright;
		Point farthesbottomright;
		Point cursorsave_trans_upperleft;
		int cursorsave_trans_bottom;
		int cursorsave_trans_farthestright;
		/// 
		ImportTransfer _Transfer = null;
		//decimal _WasteCost = 0;

		class ComboBoxItem
		{
			public string Name;
			public int ID;
			public ComboBoxItem(string Name, int ID)
			{
				this.Name = Name;
				this.ID = ID;
			}
			// override ToString() function
			public override string ToString()
			{
				return this.Name;
			}
		}
		ComboBoxItem cbi = null;
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public UCEnterWasteLogs()
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
				dbDetector = DBDetector.GetDBDetector();
				//dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.DBPathChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.AdjustmentsChanged += new DBDetectorEventHandler(dbDetector_AdjustmentsChanged);
				dbDetector.UserLogin += new DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}

			//InitProductUI();
			ulvTransactions.ItemSettings.SelectionType = SelectionType.Single;
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
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
		}

		//void InitProductUI()
		//{
		//    panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
		//    lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
		//    this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
		//}

		public int AutoRun(string param)
		{
			Initialized = true;
			SkipSelectedIndexChangedHandler = true;
			if (LoadDETemplates() == 0)
			{
				MessageBox.Show("No Data Entry Templates defined! \nPlease use Manage Data Entry Templates to create one.");
			}
			SkipSelectedIndexChangedHandler = false;
			pInitialLoad.Location = VWA4Common.Utilities.CenterControlonBackgroundControl(
				this, pInitialLoad);
			pInitialLoad.Top -= 30;
			pInitialLoad.Show();
			///// If Session is aleady in progress, then resume it
			////  if not, then go the the null (closed) session state. 
			//if (VWA4Common.GlobalSettings.SessionOpen > 0)
			//{
			//    // Session is already open - resume it
			//    showSession(false);
			//}
			//else
			//{
			//    // Show null session
			//    showSession(true);

			//}
			lFormChooserLeadin.Visible = false;
			cbDETemplates.Visible = false;
			bSetFormSetAsDefault.Visible = false;
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
			VWA4Common.GlobalSettings.DeleteNullSessions();
			CloseCurrSession();
			_IsActive = false;
		}
		/// <summary>
		/// Standard Load Data method.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			CurrTrans = new Transaction_Mem();
			PrevTrans = new Transaction_Mem();
			Sess_Current = new GlobalClasses.DataEntrySession();
			pInitialLoad.Hide();
			hideSession();
			hideCurrTrans();
			hideDETDefaults();
			hideTransactionPanel();
			cbDETemplates.Text = "";
			/// Init special properties
			string bs = VWA4Common.Query.GetGlobalSetting("EnterLogSheetBorderStyle",0);
			if (bs != "") borderstyle = bs.ToLower() == "none" ? BorderStyle.None : System.Windows.Forms.BorderStyle.FixedSingle;
			else borderstyle = System.Windows.Forms.BorderStyle.None;
			string sbc = VWA4Common.Query.GetGlobalSetting("EnterLogSheetSessionBackColor", 0);
			if (sbc != "") pSessionKey.BackColor = Color.FromArgb(int.Parse(sbc));
			string df = VWA4Common.Query.GetGlobalSetting("EnterLogSheetDateFormat", 0);
			dateFormat = df.ToLower() == "long" ? "long" : "short";
			string tf = VWA4Common.Query.GetGlobalSetting("EnterLogSheetTimeFormat", 0);
			timeFormat = tf.ToLower() == "long" ? "long" : "short";
			string dt = VWA4Common.Query.GetGlobalSetting("EnterLogSheetDefaultTemplate", 0);
			defaultTemplate = dt == "" ? 0 : int.Parse(dt);
			bNewSession.Left = pSessionKey.Right + spacing;
			bNewSession.Top = pSessionKey.Top + 1;
    
		}


		public void SaveData()
		{

		}

		public bool ValidateData()
		{ return true; }

		
		/// 
		/// Support Methods
		/// 

		private void bDone_Click(object sender, EventArgs e)
		{
			lFormChooserLeadin.Visible = false;
			cbDETemplates.Visible = false;
			bSetFormSetAsDefault.Visible = false;

			VWA4Common.Query.SaveGlobalSetting("EnterLogSheetBorderStyle", pSessionKey.BorderStyle.ToString(),
				"string", 0);
			VWA4Common.Query.SaveGlobalSetting("EnterLogSheetSessionBackColor", pSessionKey.BackColor.ToArgb().ToString(),
				"int", 0);
			VWA4Common.Query.SaveGlobalSetting("EnterLogSheetDateFormat", dateFormat,
				"string", 0);
			VWA4Common.Query.SaveGlobalSetting("EnterLogSheetTimeFormat", timeFormat,
				"string", 0);
			VWA4Common.Query.SaveGlobalSetting("EnterLogSheetDefaultTemplate", defaultTemplate.ToString(),
				"string", 0);
			commonEvents.TaskSheetKey = "dashboard";
		}

		private int LoadDETemplates()
		{
			cbDETemplates.Items.Clear();
			//
			// Load the Form Set combo box
			//
			string sql = @"SELECT ID, DETName FROM DataEntryTemplates ORDER BY DETName ASC";
			DataTable detDataTable = new DataTable();
			detDataTable = VWA4Common.DB.Retrieve(sql);
			int n = 0;
			int sid = 0;
			foreach (DataRow row in detDataTable.Rows)
			{
				// Only load DETs that are legal within  this configuration
				int detid = (int)row["ID"];
				// skip adding this DET if it is outside allowed limits
				VWA4Common.GlobalClasses.DataEntryTemplate detmem = new GlobalClasses.DataEntryTemplate();
				if (VWA4Common.GlobalSettings.DETConfigCheck(detid, detmem) != "") break;
				{// Add the item
					if (detid == defaultTemplate) sid = n;
					cbDETemplates.Items.Add(new ComboBoxItem(row["DETName"].ToString(), detid));
					n++;
				}
			}
			// Initialize to no selection
			if (cbDETemplates.Items.Count == 0)
			{
				SkipSelectedIndexChangedHandler = true;
				// Nullify anySessions - must have at least one form set
				showSession(true);
				SkipSelectedIndexChangedHandler = false;
			}
			cbDETemplates.SelectedIndex = sid;
			return cbDETemplates.Items.Count;
		}
		
		//private bool GetSession()
		//{
		//    ///
		//    /// Ask user if they want to start a new session or open existing session
		//    /// 
		//    if (MessageBox.Show(this, "Start New Data Entry Session?\n (Click 'No' to Open a Prior Session)",
		//        "Log Sheet Data Entry", MessageBoxButtons.YesNo) == DialogResult.No)
		//    {
		//        ///
		//        /// Open an existing session
		//        /// 
		//        frmOpenExistingSession opensess = new frmOpenExistingSession();
		//        if (opensess.ShowDialog() == DialogResult.Cancel)
		//            {
		//                // User Cancelled - Show Null screen
		//                _Transfer = null;
		//                return false;
		//            }
		//            else
		//            {
		//                // OK we're set with Session to continue
		//                //
		//                _Transfer = new ImportTransfer(VWA4Common.GlobalSettings.SessionOpen, true);
		//            }
		//    }
		//    else
		//    {
		//        ///
		//        /// Start a new session
		//        /// 
		//        // Choose Virtual Tracker
		//        frmNewSession newsess = new frmNewSession();
		//        if (newsess.ShowDialog() == DialogResult.Cancel)
		//        {
		//            // User Cancelled - Show Null screen
		//            _Transfer = null;
		//            return false;
		//        }
		//        else
		//        {
		//            // OK we're set with new Session to start
		//            DateTime dtsessstart = DateTime.Now;
		//            //
		//            // Get a new Session ID - by creating a new transfer record for the data
		//            // 
		//            if (_Transfer == null)
		//            {
		//                DateTime nowdate = DateTime.Now;
		//                DateTime datafromdate;
		//                DateTime.TryParse(VWA4Common.GlobalSettings.SessionDataFromDate_DateSelected,
		//                    out datafromdate);
		//                _Transfer = new ImportTransfer(
		//                    nowdate, datafromdate, nowdate,
		//                    VWA4Common.GlobalSettings.SessionTracker_TermIDSelected,
		//                    VWA4Common.GlobalSettings.SessionTracker_TermNameSelected, "", VWA4Common.GlobalSettings.SessionSiteID,
		//                    VWA4Common.GlobalSettings.SessionSiteName, VWA4Common.GlobalSettings.SessionTypeCatalogID,
		//                    VWA4Common.GlobalSettings.SessionTypeCatalogName, false, true,
		//                    VWA4Common.GlobalSettings.SessionUserTypeID);
		//                //_Transfer = new ImportTransfer(dtsessstart, VWA4Common.GlobalSettings.SessionTracker_TermIDSelected,
		//                //    VWA4Common.GlobalSettings.SessionTracker_TermNameSelected, "", VWA4Common.GlobalSettings.SessionSiteID,
		//                //    VWA4Common.GlobalSettings.SessionSiteName, VWA4Common.GlobalSettings.SessionTypeCatalogID,
		//                //    VWA4Common.GlobalSettings.SessionTypeCatalogName, false);
		//                //save transfer to DB
		//                int sessid = _Transfer.DBSave(true);//_connTransaction, _transaction, true);
		//                VWA4Common.GlobalSettings.OpenSession(sessid);
		//            }
		//        }

		//    }
		//    if (cbDETemplates.Items.Count > 0)
		//        {
		//            cbDETemplates.SelectedIndex = 1;
		//        }
		//    return true;  // User didn't cancel
		//}

		///***************************************
		///***************************************
		///***************************************
		/// Dynamic Control Rendering
		///***************************************
		///***************************************
		///***************************************


		/// <summary>
		/// Paint the session block.
		/// Call this when showing a session for the first time after opening or creating.  Once this has been
		/// called for a session, call repaintSession() to repaint it.
		/// </summary>
		/// <param name="nullsess"></param>
		/// true: null out the session and show the block with no session open; false: paint the session block
		/// with the settings of the current open session.
		/// <returns></returns>
		private void showSession(bool nullsess)
		{
			// Based on the database settings for the current session, build a session block
			// 
			LoadDETemplates();
			pSessionKey.Left = 12;
			pSessionKey.Top = panel1.Bottom + 10;
			pSessionKey.Show();
			bNewSession.Left = pSessionKey.Right + spacing;
			bNewSession.Top = pSessionKey.Top + 1;
			bOpenSession.Left = bNewSession.Left;
			bOpenSession.Top = bNewSession.Bottom + spacing;
			bCloseSession.Left = bNewSession.Left;
			bCloseSession.Top = bOpenSession.Bottom + spacing;
			if (!nullsess)
			{
				// A session is open
				bOpenSession.Show();
				bNewSession.Show();
				lFormChooserLeadin.Show();
				cbDETemplates.Show();
				/// Initialize Session Labels
				lSessID.Text = _Transfer.TransKey.ToString();
				lSessID.Show();

				lSessDataFromDateleadin.Show();
				lSessDataFromDate.Text = _Transfer.DataFromDate.ToString("M/d/yy");
				lSessDataFromDate.Show();
				lSessStartDateTimeleadin.Show();
				lSessStartDateTime.Text = _Transfer.Timestamp.ToString("M/d/yy h:mm tt");
				lSessStartDateTime.Show();
				lSessTrackerNameleadin.Show();
				lSessTrackerName.Text = VWA4Common.GlobalSettings.SessionTracker_TermName;
				lSessTrackerName.Show();
				lSessDEUserTypeleadin.Show();
				if (VWA4Common.GlobalSettings.SessionUserTypeID != "")
					lSessDEUserType.Text = VWA4Common.GlobalSettings.SessionUserName;
				else	lSessDEUserType.Text = "(Click to set)";
				lSessDEUserType.Show();

				bCloseSession.Show();
				bSessSummary.Show();
			}
			else
			{
				// User cancelled - no session to show
				hideDETDefaults();
				hideCurrTrans();
				hideTransactionPanel();
				bDone.Show();
				lSessDataFromDateleadin.Hide();
				lSessTrackerNameleadin.Hide();
				lSessDEUserTypeleadin.Hide();
				lSessStartDateTimeleadin.Hide();
				lSessDataFromDate.Hide();
				lSessID.Text = "(none)";
				lSessStartDateTime.Text = "";
				lSessTrackerName.Text = "";
				lSessDEUserType.Text = "";
				//bOpenSession.Show();
				//bNewSession.Show();
				lFormChooserLeadin.Hide();
				cbDETemplates.Hide();
				lSessID.Text = "(none)";
				//bCloseSession.Hide();
				pInitialLoad.Show();
			}
			//if (cbDETemplates.Items.Count > 0) cbDETemplates.SelectedIndex = 0;

		}

		/// <summary>
		/// After showSession has been called for an open session, use repaintSession to just repaint it,
		/// e.g. if a resize window occurs.
		/// </summary>
		private void repaintSession()
		{
			pSessionKey.Left = 12;
			pSessionKey.Top = panel1.Bottom + 16;
			pSessionKey.Show();
			bNewSession.Left = pSessionKey.Right + spacing;
			bNewSession.Top = pSessionKey.Top + 1;
			bOpenSession.Left = bNewSession.Left;
			bOpenSession.Top = bNewSession.Bottom + spacing;
			bCloseSession.Left = bNewSession.Left;
			bCloseSession.Top = bOpenSession.Bottom + spacing;
		}


		/// <summary>
		/// Show the current form set default/header fields at the current cursor position as determined relative
		/// to the location of the Session content.
		/// Initially this was referred to as "header" or "form set"; now it is referred to as "defaults".
		/// </summary>
		/// <param name="formSetID"></param>
		/// <returns></returns>
        private bool showDETDefaults(int detID)
		{
			// Based on the database settings for the current form set, build a form set header
			// 
			// Hide DETDefaults to begin with
			hideDETDefaults();
			resetfarthestbottomright();
			// Init
			bool formsetisnull = true;  // does the formset have anything to show?
			pFormHeader.Left = bNewSession.Right + spacing;
			pFormHeader.Top = pSessionKey.Top;
			pFormHeader.Height = pSessionKey.Height;
			pFormHeader.Width = 136;
			cursor.X = pFormHeader.Left + formheaderleftindent;
			cursor.Y = pFormHeader.Top + 24;
			// Load the current form set into our curr trans buffer
			GlobalClasses.DataEntryTemplate detmem = new GlobalClasses.DataEntryTemplate();
			if (VWA4Common.GlobalSettings.DETLoad(detID, detmem))
			{	// it loaded OK
				CurrTrans.DET = detmem;
				// Starting at the right edge of the session panel, show Form Set control panels in the order
				// dictated by the database
				//
				// Split the Form set display order string up and iterate through to build the UI segment
				string[] tokens = CurrTrans.DET.FormSet_displayorder.Split(new Char[] { ',' });
				int i;
				for (i = 0; i < tokens.Length; i++)
				{
					string s = tokens[i].Trim();
					// Process the current line based on the field type
					//************
					//************ SWITCH HERE
					//************
					if (s == "beo") s = "eventorder";
					switch (s.ToLower())
					{
						case "wastemode":
							{
								///*** Get the text
								if (CurrTrans.DET.FormSet_Wastemode.ToLower() == "int")
								{
									lFormPrePost.Text = "Intermediate";
								}
								else if (CurrTrans.DET.FormSet_Wastemode.ToLower() == "pre")
								{
									lFormPrePost.Text = "Pre-consumer";
								}
								else if (CurrTrans.DET.FormSet_Wastemode.ToLower() == "post")
								{
									lFormPrePost.Text = "Post-consumer";
								}
								else lFormPrePost.Text = "(unknown)";
								///*** Manage Cursor
								pFormPrePost.Location = cursor;
								pFormPrePost.Show();
								if ((pFormPrePost.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormPrePost.Height + spacing;
									pFormPrePost.Location = cursor;
									cursor.X = pFormPrePost.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormPrePost.Right + spacing;
								}
					
								pFormPrePost.Show();
								lastbottomright.X = pFormPrePost.Right;
								lastbottomright.Y = pFormPrePost.Bottom;
								adjustfarthestbottomright(pFormPrePost);
								formsetisnull = false;
								break;
							}
						case "user":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM UserType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_UserType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormUserType.Text = dr["TypeName"].ToString();
								} else 	lFormUserType.Text = "(unknown)";
								///*** Manage Cursor
								pFormUserType.Location = cursor;
								pFormUserType.Show();
								if ((pFormUserType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormUserType.Height + spacing;
									pFormUserType.Location = cursor;
									cursor.X = pFormUserType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormUserType.Right + spacing;
								}
								pFormUserType.Show();
								lastbottomright.X = pFormUserType.Right;
								lastbottomright.Y = pFormUserType.Bottom;
								adjustfarthestbottomright(pFormUserType);
								formsetisnull = false;
								break;
							}
						case "food":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM FoodType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_FoodType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormFoodType.Text = dr["TypeName"].ToString();
								}
								else lFormFoodType.Text = "(unknown)";
								///*** Manage Cursor
								pFormFoodType.Location = cursor;
								pFormFoodType.Show();
								if ((pFormFoodType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormFoodType.Height + spacing;
									pFormFoodType.Location = cursor;
									cursor.X = pFormFoodType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormFoodType.Right + spacing;
								}
								pFormFoodType.Show();
								lastbottomright.X = pFormFoodType.Right;
								lastbottomright.Y = pFormFoodType.Bottom;
								adjustfarthestbottomright(pFormFoodType);
								formsetisnull = false;
								break;
							}
						case "loss":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM LossType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_LossType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormLossType.Text = dr["TypeName"].ToString();
								}
								else lFormLossType.Text = "(unknown)";
								///*** Manage Cursor
								pFormLossType.Location = cursor;
								pFormLossType.Show();
								if ((pFormLossType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormLossType.Height + spacing;
									pFormLossType.Location = cursor;
									cursor.X = pFormLossType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormLossType.Right + spacing;
								}
								pFormLossType.Show();
								lastbottomright.X = pFormLossType.Right;
								lastbottomright.Y = pFormLossType.Bottom;
								adjustfarthestbottomright(pFormLossType);
								formsetisnull = false;
								break;
							}
						case "container":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM ContainerType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_ContainerType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormContainerType.Text = dr["TypeName"].ToString();
								}
								else lFormContainerType.Text = "(unknown)";
								///*** Manage Cursor
								pFormContainerType.Location = cursor;
								pFormContainerType.Show();
								if ((pFormContainerType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormContainerType.Height + spacing;
									pFormContainerType.Location = cursor;
									cursor.X = pFormContainerType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormContainerType.Right + spacing;
								}
								pFormContainerType.Show();
								lastbottomright.X = pFormContainerType.Right;
								lastbottomright.Y = pFormContainerType.Bottom;
								adjustfarthestbottomright(pFormContainerType);
								formsetisnull = false;
								break;
							}
						case "station":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM StationType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_StationType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormStationType.Text = dr["TypeName"].ToString();
								}
								else lFormStationType.Text = "(unknown)";
								///*** Manage Cursor
								pFormStationType.Location = cursor;
								pFormStationType.Show();
								if ((pFormStationType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormStationType.Height + spacing;
									pFormStationType.Location = cursor;
									cursor.X = pFormStationType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									//cursor.X = pFormStationType.Right + spacing;
									cursor.X = pFormStationType.Left + pFormStationType.Width + spacing;
								}
								pFormStationType.Show();
								lastbottomright.X = pFormStationType.Right;
								lastbottomright.Y = pFormStationType.Bottom;
								adjustfarthestbottomright(pFormStationType);
								formsetisnull = false;
								break;
							}
						case "disposition":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM DispositionType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_DispositionType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormDispositionType.Text = dr["TypeName"].ToString();
								}
								else lFormDispositionType.Text = "(unknown)";
								///*** Manage Cursor
								pFormDispositionType.Location = cursor;
								pFormDispositionType.Show();
								if ((pFormDispositionType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormDispositionType.Height + spacing;
									pFormDispositionType.Location = cursor;
									cursor.X = pFormDispositionType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormDispositionType.Right + spacing;
								}
								pFormDispositionType.Show();
								lastbottomright.X = pFormDispositionType.Right;
								lastbottomright.Y = pFormDispositionType.Bottom;
								adjustfarthestbottomright(pFormDispositionType);
								formsetisnull = false;
								break;
							}
						case "daypart":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM DaypartType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_DaypartType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormDaypartType.Text = dr["TypeName"].ToString();
								}
								else lFormDaypartType.Text = "(unknown)";
								///*** Manage Cursor
								pFormDaypartType.Location = cursor;
								pFormDaypartType.Show();
								if ((pFormDaypartType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormDaypartType.Height + spacing;
									pFormDaypartType.Location = cursor;
									cursor.X = pFormDaypartType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormDaypartType.Right + spacing;
								}
								pFormDaypartType.Show();
								lastbottomright.X = pFormDaypartType.Right;
								lastbottomright.Y = pFormDaypartType.Bottom;
								adjustfarthestbottomright(pFormDaypartType);
								formsetisnull = false;
								break;
							}
						case "eventorder":
							{
								///*** Get the text
								///***
								string sql = "SELECT TypeName FROM BEOType WHERE TypeID= '"
									+ CurrTrans.DET.FormSet_EventOrderType + "'";
								DataTable dt = VWA4Common.DB.Retrieve(sql);
								if (dt != null && dt.Rows.Count > 0)
								{
									DataRow dr = dt.Rows[0];
									lFormEventOrderType.Text = dr["TypeName"].ToString();
								}
								else lFormEventOrderType.Text = "(unknown)";
								///*** Manage Cursor
								pFormEventOrderType.Location = cursor;
								pFormEventOrderType.Show();
								if ((pFormEventOrderType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = pFormHeader.Left + formheaderleftindent;
									cursor.Y += pFormEventOrderType.Height + spacing;
									pFormEventOrderType.Location = cursor;
									cursor.X = pFormEventOrderType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pFormEventOrderType.Right + spacing;
								}
								pFormEventOrderType.Show();
								lastbottomright.X = pFormEventOrderType.Right;
								lastbottomright.Y = pFormEventOrderType.Bottom;
								adjustfarthestbottomright(pFormEventOrderType);
								formsetisnull = false;
								break;
							}

					}
				}

				pFormHeader.Width = farthesbottomright.X - pFormHeader.Left + 16;
				pFormHeader.Height = farthesbottomright.Y - pFormHeader.Top;
				if (farthesbottomright.Y != pSessionKey.Bottom) pFormHeader.Height += spacing;
				if (pSessionKey.Bottom < pFormHeader.Bottom) cursorsave_trans_upperleft.Y = pFormHeader.Bottom;
				else cursorsave_trans_upperleft.Y = pSessionKey.Bottom;
				if (!formsetisnull) pFormHeader.Show();
				return true;
			}
			else
			{
				MessageBox.Show("Data Entry Template did not load (Processing Defaults) - check database!");
			}
			hideTransactionPanel();
			return false;
		}

		/// <summary>
		/// Initialize Current Transaction variables based on specified form set.
		/// </summary>
		/// <param name="detID">ID of current data entry template</param>
		private void initCurrTrans_Fields()
		{

			bQuantityGood = false;
			CurrTrans.Weight = 0;

			ComboBoxItem cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			CurrTrans.DETID = cbi.ID;
			//**** Waste mode
			string defaultprepostwastemode = VWA4Common.GlobalSettings.DET_GetNewCurrWasteModeFromDefaultPrePostConsumer(CurrTrans.DET, PrevTrans);
			//Note that there is an inconsistency between the way two database tables define the same field.  This code maps that correctly - 
			//  Weights.IsPreconsumer values:
			//		Intermediate =	0
			//		Preconsumer =	1
			//		Post consumer = 2
			//  Terminals.DefaultPrePostconsumer values:
			//		Intermediate =  2
			//		Preconsumer =	0
			//		Post consumer = 1
			/// Here we are depending on getting Weights.IsPreconsumer format
            CurrTrans.IsPreconsumer = int.Parse(defaultprepostwastemode);
			// Quantity - clear
			lCurrQuantityLeadin.Text = "Quantity:";

			//**** Timestamp
			string ts = GlobalSettings.DET_GetNewCurrDateTime(CurrTrans.DET, PrevTrans, Sess_Current);
			CurrTrans.Timestamp = DateTime.Parse(ts);
			
			//**** User
			CurrTrans.UserTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrUser_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user",
                CurrTrans.UserTypeID, out CurrTrans.UserTypeName);
			//**** Food
			CurrTrans.FoodTypeCost = 0;
			CurrTrans.FoodTypeDiscount = 0;
			CurrTrans.FoodTypeVolumeUnits = 0;
			CurrTrans.FoodTypeVolumeUnitType = 0;
			CurrTrans.FoodTypeVolumeWeight = 0;
			CurrTrans.FoodTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrFood_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food",
				CurrTrans.FoodTypeID, out CurrTrans.FoodTypeName);
			VWA4Common.GlobalSettings.GetFoodCostfromType(CurrTrans.FoodTypeID, out CurrTrans.FoodTypeCost);
			//**** Loss
			CurrTrans.LossTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrLoss_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss",
				CurrTrans.LossTypeID, out CurrTrans.LossTypeName);
			//**** Container
			CurrTrans.ContainerCost = 0;
			CurrTrans.ContainerWeight = 0;
			CurrTrans.ContainerTypeVolume = 0;
			CurrTrans.ContainerTypeVolumeUnitType = 0;
			CurrTrans.ContainerTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrContainer_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container",
				CurrTrans.ContainerTypeID, out CurrTrans.ContainerTypeName);
			decimal ccost = 0;
			//VWA4Common.GlobalSettings.GetContainerCostandWeight(sContainerTypeID_CurrTrans,
			//    out ccost, out dSingleContainerWt_Curr);
			//sContainerTypeCost_CurrTrans = ccost.ToString();
			//sSingleContainerWt_CurrTrans = dSingleContainerWt_Curr.ToString();

			//**** Station
			CurrTrans.StationTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrStation_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station",
				CurrTrans.StationTypeID, out CurrTrans.StationTypeName);
			//**** Disposition
			CurrTrans.DispositionTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrDisposition_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition",
				CurrTrans.DispositionTypeID, out CurrTrans.DispositionTypeName);
			//**** Daypart
			CurrTrans.DaypartTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrDaypart_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart",
				CurrTrans.DaypartTypeID, out CurrTrans.DaypartTypeName);
			//**** EventOrder
			CurrTrans.BEOTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrEventOrder_TypeID(CurrTrans.DET, PrevTrans);
			VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder",
				CurrTrans.BEOTypeID, out CurrTrans.BEOTypeName);

		}

		/// 
		/// Cursor management support methods
		/// 

		private void updateBottomandRightBounds(Control control)
		{
			if (cursorsave_trans_bottom < control.Bottom)
				cursorsave_trans_bottom = control.Bottom;
			if (cursorsave_trans_farthestright < control.Right)
				cursorsave_trans_farthestright = control.Right;
		}

		private void resetfarthestbottomright()
		{
			farthesbottomright.X = pSessionKey.Right;
			farthesbottomright.Y = pSessionKey.Bottom;
		}
		private void adjustfarthestbottomright(Control control)
		{
			if (control.Right > farthesbottomright.X)
				farthesbottomright.X = control.Right;
			if (control.Bottom > farthesbottomright.Y)
				farthesbottomright.Y = control.Bottom;
		}

		/// <summary>
		/// Show the current (or a new, restarted) Transaction at the cursor location. 
		/// </summary>
		/// <param name="det">Current Data Entry Template (must be loaded/ not null).</param>
		/// <param name="init">If true, initialize as a new transaction; if false, 
		/// just redraw using the saved global current transaction parameters.  The latter
		/// means that the current transaction is being edited.</param>
		private void showCurrTrans(GlobalClasses.DataEntryTemplate det, bool init)
		{
			// Based on the database settings for the current form set, build a current transaction UI block
			// 
			// Starting at the right edge of the previous transaction timestamp, show control panels in the order
			// dictated by the database
			//
			// Based on the database settings for the current form set, build a form set header
			// 
			// Hide Form Set to begin with
			hideCurrTrans();
			hideTransactionPanel();
			// Init
			if (init)
			{
				/// Initialize 				
				/// Load transactions
				cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
				// Open the item the user clicked on
				loadTransactionList(CurrTrans.DET, cursor.X, cursor.Y, true); // do this here to get PrevTrans loaded before...
				if (ulvTransactions.Items.Count > 0)
				{
					loadPrevTransaction(int.Parse(ulvTransactions.Items[0].Key));
				}
				// ...initializing the current transaction, which can depend on prev trans
				initCurrTrans_Fields(); /// Clear the current trans if we're initializing}
			}
			bClearCurrTrans.Visible = init;
			bSaveandNewCurrTrans.Show();
			bSaveandNewCurrTrans.Enabled = false;
			bEditingSavedTrans_CurrTrans = !init;	// This signifies whether the trans is new or reloaded from DB
			bDirty_CurrTrans = false;				// Can't be dirty yet in any case
			CurrTrans.StartTimestamp = DateTime.Now;
			
			// Position management
			pTransaction.Left = pSessionKey.Left;
			pTransaction.Top = cursorsave_trans_upperleft.Y + 12;
			pTransaction.Width = farthesbottomright.X - pTransaction.Left;
			pTransaction.Height = 105;
			cursor.X = pTransaction.Left + 16;
			cursor.Y = pTransaction.Top + 24;
	
				initDETSettings(det);
				int startingX = cursor.X;
				int startingY = cursor.Y;
				int startingX_Fields = startingX;
				/// ****************************
				/// ****************************
				/// Quantity initialization here
				/// ****************************
				/// ****************************
				if (init)
				{
					/// Initialize to null
					lCurrQuantity.Text = "";
				}
				else
				{
					/// Load UI from current transaction globals
					lCurrQuantity.Text = CurrTrans.QuantityString_DE;
				}
				///*** Manage Cursor
				// Curr Quantity panel is a special case - gets rendered first, on the top line
				pCurrQuantity.Location = cursor;
				pCurrQuantity.Show();
				cursor.X = pCurrQuantity.Right + spacing;
				pCurrQuantity.Show();
				updateBottomandRightBounds(pCurrTimestamp);
				adjustfarthestbottomright(pCurrTimestamp);
				///
				/// Starting at the right edge of the last panel, show Current Transaction panels in the order
				/// dictated by the database
				///
				// Split the Transaction display order string up and iterate through to build the UI segment
				string[] tokens = det.Transaction_displayorder.Split(new Char[] { ',' });
				int i;
				for (i = 0; i < tokens.Length; i++)
				{
					string s = tokens[i].Trim();
					// Process the current line based on the field type
					//************
					//************ SWITCH HERE
					//************
					if (s == "beo") s = "eventorder";
					switch (s.ToLower())
					{
						case "timestamp":
							{
								///*** Get the text
								///***
								/// Initialize per Formset setting
								if (LongDateFormat)
								{
									lCurrDateTime.Text = CurrTrans.Timestamp.ToLongDateString() + " ";
								}
								else
								{
									lCurrDateTime.Text = CurrTrans.Timestamp.ToShortDateString() + " ";
								}
								if (LongTimeFormat)
								{
									lCurrDateTime.Text += CurrTrans.Timestamp.ToLongTimeString();
								}
								else
								{
									lCurrDateTime.Text += CurrTrans.Timestamp.ToShortTimeString();
								}
								CurrTrans.Timestamp = DateTime.Parse(lCurrDateTime.Text);
								///***
								string sss = "Click to Enter Timestamp\n";
								sss += VWA4Common.GlobalSettings.GetToolTipTimestamp(det.Timestamp_NTPrefill);
								
								toolTip1.SetToolTip(pCurrTimestamp, sss);
								toolTip1.SetToolTip(lCurrDateTime, sss);
								
								///*** Manage Cursor
								pCurrTimestamp.Location = cursor;
								if ((pCurrTimestamp.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrTimestamp.Bottom + spacing;
									pCurrTimestamp.Location = cursor;
									cursor.X = pCurrTimestamp.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrTimestamp.Right + spacing;
								}
								pCurrTimestamp.Show();
								lastbottomright.X = pCurrTimestamp.Right;
								lastbottomright.Y = pCurrTimestamp.Bottom;
								updateBottomandRightBounds(pCurrTimestamp);
								adjustfarthestbottomright(pCurrTimestamp);
								break;
							}
						case "user":
							{
								///*** Get the text
								///***
								string typeid = "";
								string typename = "";
								if (init)
								{
									/// Initialize per Formset setting
									typeid = GlobalSettings.DET_GetNewCurrUser_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user", typeid, out typename);
									lCurrUserType.Text = typename;
									CurrTrans.UserTypeName = typename;
									CurrTrans.UserTypeID = typeid;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrUserType.Text = CurrTrans.UserTypeName;
								}
								///***
								string sss = "Click to Enter User\n";
								sss += VWA4Common.GlobalSettings.GetToolTipUser(det.User_CTDefaultMode);

								toolTip1.SetToolTip(pCurrUserType, sss);
								toolTip1.SetToolTip(lCurrUserType, sss);
								///*** Manage Cursor
								pCurrUserType.Location = cursor;
								pCurrUserType.Show();
								if ((pCurrUserType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrUserType.Bottom + spacing;
									pCurrUserType.Location = cursor;
									cursor.X = pCurrUserType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrUserType.Right + spacing;
								}
								pCurrUserType.Show();
								lastbottomright.X = pCurrUserType.Right;
								lastbottomright.Y = pCurrUserType.Bottom;
								updateBottomandRightBounds(pCurrUserType);
								adjustfarthestbottomright(pCurrUserType);
								break;
							}

						case "wastemode":
							{
								///*** Get the text
								///***
								string defaultprepostwastemode = "";
								if (init)
								{
									/// Initialize per Formset setting
									defaultprepostwastemode = VWA4Common.GlobalSettings.DET_GetNewCurrWasteModeFromDefaultPrePostConsumer(det, PrevTrans);
									//Note that there is an inconsistency between the way two database tables define the same field.  This code maps that correctly - 
									//  Weights.IsPreconsumer values:
									//		Intermediate =	0
									//		Preconsumer =	1
									//		Post consumer = 2
									//  Terminals.DefaultPrePostconsumer values:
									//		Intermediate =  2
									//		Preconsumer =	0
									//		Post consumer = 1
									/// Here we are depending on getting Weights.IsPreconsumer format
									CurrTrans.IsPreconsumer = int.Parse(defaultprepostwastemode);
									lCurrPrePost.Text =
										VWA4Common.GlobalSettings.GetWasteModeStringfromIsPreconsumer(CurrTrans.IsPreconsumer);
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrPrePost.Text = 
										VWA4Common.GlobalSettings.GetWasteModeStringfromIsPreconsumer(
										CurrTrans.IsPreconsumer);
								}
								/// Load from current saved transaction
								///***
								string sss = "Click to Enter Waste Mode\n";
								sss += VWA4Common.GlobalSettings.GetToolTipWasteMode(det.Wastemode_CTDefaultMode);

								toolTip1.SetToolTip(pCurrPrePost, sss);
								toolTip1.SetToolTip(lCurrPrePost, sss);
								///*** Manage Cursor
								pCurrPrePost.Location = cursor;
								pCurrPrePost.Show();
								if ((pCurrPrePost.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrPrePost.Bottom + spacing;
									pCurrPrePost.Location = cursor;
									cursor.X = pCurrPrePost.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrPrePost.Right + spacing;
								}
								pCurrPrePost.Show();
								lastbottomright.X = pCurrPrePost.Right;
								lastbottomright.Y = pCurrPrePost.Bottom;
								updateBottomandRightBounds(pCurrPrePost);
								adjustfarthestbottomright(pCurrPrePost);
								break;
							}
						case "food":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.FoodTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrFood_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food",	CurrTrans.FoodTypeID,
										out CurrTrans.FoodTypeName);
									lCurrFoodType.Text = CurrTrans.FoodTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrFoodType.Text = CurrTrans.FoodTypeName;
								}
								///***
								string sss = "Click to Enter Food\n";
								sss += VWA4Common.GlobalSettings.GetToolTipFood(det.FoodType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrFoodType, sss);
								toolTip1.SetToolTip(lCurrFoodType, sss);
								///*** Manage Cursor
								pCurrFoodType.Location = cursor;
								pCurrFoodType.Show();
								if ((pCurrFoodType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrFoodType.Bottom + spacing;
									pCurrFoodType.Location = cursor;
									cursor.X = pCurrFoodType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrFoodType.Right + spacing;
								}
								pCurrFoodType.Show();
								lastbottomright.X = pCurrFoodType.Right;
								lastbottomright.Y = pCurrFoodType.Bottom;
								updateBottomandRightBounds(pCurrFoodType);
								adjustfarthestbottomright(pCurrFoodType);
								break;
							}
						case "loss":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.LossTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrLoss_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss", CurrTrans.LossTypeID, 
										out CurrTrans.LossTypeName);
									lCurrLossType.Text = CurrTrans.LossTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrLossType.Text = CurrTrans.LossTypeName;
								}
								///***
								string sss = "Click to Enter Loss\n";
								sss += VWA4Common.GlobalSettings.GetToolTipLoss(det.LossType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrLossType, sss);
								toolTip1.SetToolTip(lCurrLossType, sss);
								///*** Manage Cursor
								pCurrLossType.Location = cursor;
								pCurrLossType.Show();
								if ((pCurrLossType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrLossType.Bottom + spacing;
									pCurrLossType.Location = cursor;
									cursor.X = pCurrLossType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrLossType.Right + spacing;
								}
								pCurrLossType.Show();
								lastbottomright.X = pCurrLossType.Right;
								lastbottomright.Y = pCurrLossType.Bottom;
								updateBottomandRightBounds(pCurrLossType);
								adjustfarthestbottomright(pCurrLossType);
								break;
							}
						case "container":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.ContainerTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrContainer_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", CurrTrans.ContainerTypeID, 
										out CurrTrans.ContainerTypeName);
									VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
										out CurrTrans.ContainerCost, out CurrTrans.ContainerWeight);
									lCurrContainerType.Text = CurrTrans.ContainerTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrContainerType.Text = CurrTrans.ContainerTypeName;
								}
								///***
								string sss = "Click to Enter Container\n";
								sss += VWA4Common.GlobalSettings.GetToolTipLoss(det.ContainerType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrContainerType, sss);
								toolTip1.SetToolTip(lCurrContainerType, sss);
								///*** Manage Cursor
								pCurrContainerType.Location = cursor;
								pCurrContainerType.Show();
								if ((pCurrContainerType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrContainerType.Bottom + spacing;
									pCurrContainerType.Location = cursor;
									cursor.X = pCurrContainerType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrContainerType.Right + spacing;
								}
								pCurrContainerType.Show();
								lastbottomright.X = pCurrContainerType.Right;
								lastbottomright.Y = pCurrContainerType.Bottom;
								updateBottomandRightBounds(pCurrContainerType);
								adjustfarthestbottomright(pCurrContainerType);
								break;
							}
						case "station":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.StationTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrStation_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station", CurrTrans.StationTypeID, out CurrTrans.StationTypeName);
									lCurrStationType.Text = CurrTrans.StationTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrStationType.Text = CurrTrans.StationTypeName;
								}
								///***
								string sss = "Click to Enter Station\n";
								sss += VWA4Common.GlobalSettings.GetToolTipStation(det.StationType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrStationType, sss);
								toolTip1.SetToolTip(lCurrStationType, sss);
								///*** Manage Cursor
								pCurrStationType.Location = cursor;
								pCurrStationType.Show();
								if ((pCurrStationType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrStationType.Bottom + spacing;
									pCurrStationType.Location = cursor;
									cursor.X = pCurrStationType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrStationType.Right + spacing;
								}
								pCurrStationType.Show();
								lastbottomright.X = pCurrStationType.Right;
								lastbottomright.Y = pCurrStationType.Bottom;
								updateBottomandRightBounds(pCurrStationType);
								adjustfarthestbottomright(pCurrStationType);
								break;
							}
						case "disposition":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.DispositionTypeName = VWA4Common.GlobalSettings.DET_GetNewCurrDisposition_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition", CurrTrans.DispositionTypeID, out CurrTrans.DispositionTypeName);
									lCurrDispositionType.Text = CurrTrans.DispositionTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrDispositionType.Text = CurrTrans.DispositionTypeName;
								}
								///***
								string sss = "Click to Enter Disposition\n";
								sss += VWA4Common.GlobalSettings.GetToolTipDisposition(det.DispositionType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrDispositionType, sss);
								toolTip1.SetToolTip(lCurrDispositionType, sss);
								///*** Manage Cursor
								pCurrDispositionType.Location = cursor;
								pCurrDispositionType.Show();
								if ((pCurrDispositionType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrDispositionType.Bottom + spacing;
									pCurrDispositionType.Location = cursor;
									cursor.X = pCurrDispositionType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrDispositionType.Right + spacing;
								}
								pCurrDispositionType.Show();
								lastbottomright.X = pCurrDispositionType.Right;
								lastbottomright.Y = pCurrDispositionType.Bottom;
								updateBottomandRightBounds(pCurrDispositionType);
								adjustfarthestbottomright(pCurrDispositionType);
								break;
							}
						case "daypart":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.DaypartTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrDaypart_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart", CurrTrans.DaypartTypeID, out CurrTrans.DaypartTypeName);
									lCurrDaypartType.Text = CurrTrans.DaypartTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrDaypartType.Text = CurrTrans.DaypartTypeName;
								}
								///***
								string sss = "Click to Enter Daypart\n";
								sss += VWA4Common.GlobalSettings.GetToolTipDaypart(det.DaypartType_CTDefaultMode);

								toolTip1.SetToolTip(pCurrDaypartType, sss);
								toolTip1.SetToolTip(lCurrDaypartType, sss);
								///*** Manage Cursor
								pCurrDaypartType.Location = cursor;
								pCurrDaypartType.Show();
								if ((pCurrDaypartType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrDaypartType.Bottom + spacing;
									pCurrDaypartType.Location = cursor;
									cursor.X = pCurrDaypartType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrDaypartType.Right + spacing;
								}
								pCurrDaypartType.Show();
								lastbottomright.X = pCurrDaypartType.Right;
								lastbottomright.Y = pCurrDaypartType.Bottom;
								updateBottomandRightBounds(pCurrDaypartType);
								adjustfarthestbottomright(pCurrDaypartType);
								break;
							}
						case "eventorder":
							{
								///*** Get the text
								///***
								if (init)
								{
									/// Initialize per Formset setting
									CurrTrans.BEOTypeID = VWA4Common.GlobalSettings.DET_GetNewCurrEventOrder_TypeID(det, PrevTrans);
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder", CurrTrans.BEOTypeID, out CurrTrans.BEOTypeName);
									lCurrEventOrderType.Text = CurrTrans.BEOTypeName;
								}
								else
								{
									/// Load UI from current transaction globals
									lCurrEventOrderType.Text = CurrTrans.BEOTypeName;
								}
								///*** Manage Cursor
								pCurrEventOrderType.Location = cursor;
								pCurrEventOrderType.Show();
								if ((pCurrEventOrderType.Right + spacing) > (cbDETemplates.Right))
								{ // go down a line
									cursor.X = startingX_Fields;
									cursor.Y = pCurrEventOrderType.Bottom + spacing;
									pCurrEventOrderType.Location = cursor;
									cursor.X = pCurrEventOrderType.Right + spacing;
								}
								else
								{ // go over to the right of the current control
									cursor.X = pCurrEventOrderType.Right + spacing;
								}
								pCurrEventOrderType.Show();
								lastbottomright.X = pCurrEventOrderType.Right;
								lastbottomright.Y = pCurrEventOrderType.Bottom;
								updateBottomandRightBounds(pCurrEventOrderType);
								adjustfarthestbottomright(pCurrEventOrderType);
								break;
							}
					}
				}
				/// Curr UserNote
				if (init)
				{
					/// Initialize to null
					tCurrUserNote.Text = "";
				}
				else
				{
					/// Load UI from current transaction globals
					/// (already loaded)
				}
				if (det.UserNotes_TShow)
				{
					pCurrUserNote.Location = cursor;
					pCurrUserNote.Show();
					///*** Manage Cursor
					if ((pCurrUserNote.Right + spacing) > (cbDETemplates.Right))
					{ // go down a line
						cursor.X = startingX_Fields;
						cursor.Y = pCurrUserNote.Bottom + spacing;
						pCurrUserNote.Location = cursor;
						pCurrEventOrderType.Location = cursor;
						cursor.X = pCurrEventOrderType.Right + spacing;
					}
					else
					{ // go over to the right of the current control
						cursor.X = pCurrEventOrderType.Right + spacing;
					}
					pCurrUserNote.Show();
					lastbottomright.X = pCurrUserNote.Right;
					lastbottomright.Y = pCurrUserNote.Bottom;
					updateBottomandRightBounds(pCurrUserNote);
					adjustfarthestbottomright(pCurrUserNote);
				}
				/// Manage background panel
				/// 
				pTransaction.Width = farthesbottomright.X - pTransaction.Left + 16;
				pTransaction.Height = farthesbottomright.Y - pTransaction.Top + spacing;
				pTransaction.Show();

				/// Manage Restart/Save Buttons
				bClearCurrTrans.Left = pSessionKey.Left + spacing;
				bClearCurrTrans.Top = pTransaction.Bottom + spacing + 5;
				bSaveandNewCurrTrans.Left = bClearCurrTrans.Right + 170;
				bSaveandNewCurrTrans.Top = bClearCurrTrans.Top - (bSaveandNewCurrTrans.Height 
					- bClearCurrTrans.Height)/2 ;
				bClearCurrTrans.Visible = true;
				checkTransReadytoSave();
				//****
				loadTransactionList(CurrTrans.DET, cursor.X, cursor.Y);
		}

		private void initDETSettings(GlobalClasses.DataEntryTemplate det)
		{

			pFormHeader.BackColor = Color.FromArgb(det.FormSet_BackColor);
			pFormUserType.BackColor = Color.FromArgb(det.FormSet_UserType_BackColor);
			pFormUserType.ForeColor = Color.FromArgb(det.FormSet_UserType_ForeColor);
			pFormFoodType.BackColor = Color.FromArgb(det.FormSet_FoodType_BackColor);
			pFormFoodType.ForeColor = Color.FromArgb(det.FormSet_FoodType_ForeColor);
			pFormLossType.BackColor = Color.FromArgb(det.FormSet_LossType_BackColor);
			pFormLossType.ForeColor = Color.FromArgb(det.FormSet_LossType_ForeColor);
			pFormContainerType.BackColor = Color.FromArgb(det.FormSet_ContainerType_BackColor);
			pFormContainerType.ForeColor = Color.FromArgb(det.FormSet_ContainerType_ForeColor);
			pFormStationType.BackColor = Color.FromArgb(det.FormSet_StationType_BackColor);
			pFormStationType.ForeColor = Color.FromArgb(det.FormSet_StationType_ForeColor);
			pFormDispositionType.BackColor = Color.FromArgb(det.FormSet_DispositionType_BackColor);
			pFormDispositionType.ForeColor = Color.FromArgb(det.FormSet_DispositionType_ForeColor);
			pFormDaypartType.BackColor = Color.FromArgb(det.FormSet_DaypartType_BackColor);
			pFormDaypartType.ForeColor = Color.FromArgb(det.FormSet_DaypartType_ForeColor);
			pFormEventOrderType.BackColor = Color.FromArgb(det.FormSet_EventOrderType_BackColor);
			pFormEventOrderType.ForeColor = Color.FromArgb(det.FormSet_EventOrderType_ForeColor);

			pTransaction.BackColor = Color.FromArgb(det.Transaction_BackColor);
			pCurrTimestamp.BackColor = Color.FromArgb(det.Timestamp_BackColor);
			pCurrTimestamp.ForeColor = Color.FromArgb(det.Timestamp_ForeColor);
			pCurrQuantity.BackColor = Color.FromArgb(det.Quantity_BackColor);
			pCurrQuantity.ForeColor = Color.FromArgb(det.Quantity_ForeColor);
			pCurrUserNote.BackColor = Color.FromArgb(det.UserNotes_BackColor);
			pCurrUserNote.ForeColor = Color.FromArgb(det.UserNotes_ForeColor);
			pCurrUserType.BackColor = Color.FromArgb(det.UserType_BackColor);
			pCurrUserType.ForeColor = Color.FromArgb(det.UserType_ForeColor);
			pCurrFoodType.BackColor = Color.FromArgb(det.FoodType_BackColor);
			pCurrFoodType.ForeColor = Color.FromArgb(det.FoodType_ForeColor);
			pCurrLossType.BackColor = Color.FromArgb(det.LossType_BackColor);
			pCurrLossType.ForeColor = Color.FromArgb(det.LossType_ForeColor);
			pCurrContainerType.BackColor = Color.FromArgb(det.ContainerType_BackColor);
			pCurrContainerType.ForeColor = Color.FromArgb(det.ContainerType_ForeColor);
			pCurrStationType.BackColor = Color.FromArgb(det.StationType_BackColor);
			pCurrStationType.ForeColor = Color.FromArgb(det.StationType_ForeColor);
			pCurrDispositionType.BackColor = Color.FromArgb(det.DispositionType_BackColor);
			pCurrDispositionType.ForeColor = Color.FromArgb(det.DispositionType_ForeColor);
			pCurrDaypartType.BackColor = Color.FromArgb(det.DaypartType_BackColor);
			pCurrDaypartType.ForeColor = Color.FromArgb(det.DaypartType_ForeColor);
			pCurrEventOrderType.BackColor = Color.FromArgb(det.EventOrderType_BackColor);
			pCurrEventOrderType.ForeColor = Color.FromArgb(det.EventOrderType_ForeColor);
		}


		/// <summary>
		/// Simply repaint the current transaction as is.  Does not affect screen contents
		/// or global variables.  Can produce new screen layout if screen size changed.
		/// </summary>
		private void repaintCurrTrans()
		{
			if (VWA4Common.GlobalSettings.SessionOpen <= 0) return;  // if no open session, nothing to do here
				// Hide Form Set to begin with
			hideCurrTrans();
			hideTransactionPanel();
			cursor = cursorsave_trans_upperleft;
			// Init
			int spacing = 6;

			// Position management
			pTransaction.Left = pSessionKey.Left;
			pTransaction.Top = cursorsave_trans_upperleft.Y + 12;
			pTransaction.Width = farthesbottomright.X - pTransaction.Left;
			pTransaction.Height = 105;
			cursor.X = pTransaction.Left + 16;
			cursor.Y = pTransaction.Top + 24;

			int startingX = cursor.X;
			int startingY = cursor.Y;
			int startingX_Fields = startingX;

			/// Quantity panel
			///*** Manage Cursor
			// Curr Quantity panel is a special case - gets rendered first, on the top line
			pCurrQuantity.Location = cursor;
			pCurrQuantity.Show();
			cursor.X = pCurrQuantity.Right + spacing;
			pCurrQuantity.Show();
			updateBottomandRightBounds(pCurrTimestamp);
			adjustfarthestbottomright(pCurrTimestamp);
			///
			/// Starting at the right edge of the last panel, show Current Transaction panels in the order
			/// dictated by the database
			///
			// Split the Transaction display order string up and iterate through to build the UI segment
			string[] tokens = CurrTrans.DET.Transaction_displayorder.Split(new Char[] { ',' });
			int i;
			for (i = 0; i < tokens.Length; i++)
			{
				string s = tokens[i].Trim();
				// Process the current line based on the field type
				//************
				//************ SWITCH HERE
				//************
				if (s == "beo") s = "eventorder";
				switch (s.ToLower())
				{
					case "timestamp":
						{
							///*** Manage Cursor
							pCurrTimestamp.Location = cursor;
							if ((pCurrTimestamp.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrTimestamp.Bottom + spacing;
								pCurrTimestamp.Location = cursor;
								cursor.X = pCurrTimestamp.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrTimestamp.Right + spacing;
							}
							pCurrTimestamp.Show();
							lastbottomright.X = pCurrTimestamp.Right;
							lastbottomright.Y = pCurrTimestamp.Bottom;
							updateBottomandRightBounds(pCurrTimestamp);
							adjustfarthestbottomright(pCurrTimestamp);
							break;
						}
					case "user":
						{
							///*** Manage Cursor
							pCurrUserType.Location = cursor;
							pCurrUserType.Show();
							if ((pCurrUserType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrUserType.Bottom + spacing;
								pCurrUserType.Location = cursor;
								cursor.X = pCurrUserType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrUserType.Right + spacing;
							}
							pCurrUserType.Show();
							lastbottomright.X = pCurrUserType.Right;
							lastbottomright.Y = pCurrUserType.Bottom;
							updateBottomandRightBounds(pCurrUserType);
							adjustfarthestbottomright(pCurrUserType);
							break;
						}
					case "wastemode":
						{
							///*** Manage Cursor
							pCurrPrePost.Location = cursor;
							pCurrPrePost.Show();
							if ((pCurrPrePost.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrPrePost.Bottom + spacing;
								pCurrPrePost.Location = cursor;
								cursor.X = pCurrPrePost.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrPrePost.Right + spacing;
							}
							pCurrPrePost.Show();
							lastbottomright.X = pCurrPrePost.Right;
							lastbottomright.Y = pCurrPrePost.Bottom;
							updateBottomandRightBounds(pCurrPrePost);
							adjustfarthestbottomright(pCurrPrePost);
							break;
						}
					case "food":
						{
							///*** Manage Cursor
							pCurrFoodType.Location = cursor;
							pCurrFoodType.Show();
							if ((pCurrFoodType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrFoodType.Bottom + spacing;
								pCurrFoodType.Location = cursor;
								cursor.X = pCurrFoodType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrFoodType.Right + spacing;
							}
							pCurrFoodType.Show();
							lastbottomright.X = pCurrFoodType.Right;
							lastbottomright.Y = pCurrFoodType.Bottom;
							updateBottomandRightBounds(pCurrFoodType);
							adjustfarthestbottomright(pCurrFoodType);
							break;
						}
					case "loss":
						{
							///*** Manage Cursor
							pCurrLossType.Location = cursor;
							pCurrLossType.Show();
							if ((pCurrLossType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrLossType.Bottom + spacing;
								pCurrLossType.Location = cursor;
								cursor.X = pCurrLossType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrLossType.Right + spacing;
							}
							pCurrLossType.Show();
							lastbottomright.X = pCurrLossType.Right;
							lastbottomright.Y = pCurrLossType.Bottom;
							updateBottomandRightBounds(pCurrLossType);
							adjustfarthestbottomright(pCurrLossType);
							break;
						}
					case "container":
						{
							///*** Manage Cursor
							pCurrContainerType.Location = cursor;
							pCurrContainerType.Show();
							if ((pCurrContainerType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrContainerType.Bottom + spacing;
								pCurrContainerType.Location = cursor;
								cursor.X = pCurrContainerType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrContainerType.Right + spacing;
							}
							pCurrContainerType.Show();
							lastbottomright.X = pCurrContainerType.Right;
							lastbottomright.Y = pCurrContainerType.Bottom;
							updateBottomandRightBounds(pCurrContainerType);
							adjustfarthestbottomright(pCurrContainerType);
							break;
						}
					case "station":
						{
							///*** Manage Cursor
							pCurrStationType.Location = cursor;
							pCurrStationType.Show();
							if ((pCurrStationType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrStationType.Bottom + spacing;
								pCurrStationType.Location = cursor;
								cursor.X = pCurrStationType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrStationType.Right + spacing;
							}
							pCurrStationType.Show();
							lastbottomright.X = pCurrStationType.Right;
							lastbottomright.Y = pCurrStationType.Bottom;
							updateBottomandRightBounds(pCurrStationType);
							adjustfarthestbottomright(pCurrStationType);
							break;
						}
					case "disposition":
						{
							///*** Manage Cursor
							pCurrDispositionType.Location = cursor;
							pCurrDispositionType.Show();
							if ((pCurrDispositionType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrDispositionType.Bottom + spacing;
								pCurrDispositionType.Location = cursor;
								cursor.X = pCurrDispositionType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrDispositionType.Right + spacing;
							}
							pCurrDispositionType.Show();
							lastbottomright.X = pCurrDispositionType.Right;
							lastbottomright.Y = pCurrDispositionType.Bottom;
							updateBottomandRightBounds(pCurrDispositionType);
							adjustfarthestbottomright(pCurrDispositionType);
							break;
						}
					case "daypart":
						{
							///*** Manage Cursor
							pCurrDaypartType.Location = cursor;
							pCurrDaypartType.Show();
							if ((pCurrDaypartType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrDaypartType.Bottom + spacing;
								pCurrDaypartType.Location = cursor;
								cursor.X = pCurrDaypartType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrDaypartType.Right + spacing;
							}
							pCurrDaypartType.Show();
							lastbottomright.X = pCurrDaypartType.Right;
							lastbottomright.Y = pCurrDaypartType.Bottom;
							updateBottomandRightBounds(pCurrDaypartType);
							adjustfarthestbottomright(pCurrDaypartType);
							break;
						}
					case "eventorder":
						{
							///*** Manage Cursor
							pCurrEventOrderType.Location = cursor;
							pCurrEventOrderType.Show();
							if ((pCurrEventOrderType.Right + spacing) > (cbDETemplates.Right))
							{ // go down a line
								cursor.X = startingX_Fields;
								cursor.Y = pCurrEventOrderType.Bottom + spacing;
								pCurrEventOrderType.Location = cursor;
								cursor.X = pCurrEventOrderType.Right + spacing;
							}
							else
							{ // go over to the right of the current control
								cursor.X = pCurrEventOrderType.Right + spacing;
							}
							pCurrEventOrderType.Show();
							lastbottomright.X = pCurrEventOrderType.Right;
							lastbottomright.Y = pCurrEventOrderType.Bottom;
							updateBottomandRightBounds(pCurrEventOrderType);
							adjustfarthestbottomright(pCurrEventOrderType);
							break;
						}
				}
			}
			/// Curr UserNote
			if (CurrTrans.DET.UserNotes_TShow)
			{
				///*** Manage Cursor
				pCurrUserNote.Location = cursor;
				pCurrUserNote.Show();
				if ((pCurrUserNote.Right + spacing) > (cbDETemplates.Right))
				{ // go down a line
					cursor.X = startingX_Fields;
					cursor.Y = pCurrUserNote.Bottom + spacing;
					pCurrUserNote.Location = cursor;
					pCurrUserNote.Location = cursor;
					cursor.X = pCurrUserNote.Right + spacing;
				}
				else
				{ // go over to the right of the current control
					cursor.X = pCurrEventOrderType.Right + spacing;
				}
				pCurrUserNote.Show();
				lastbottomright.X = pCurrUserNote.Right;
				lastbottomright.Y = pCurrUserNote.Bottom;
				updateBottomandRightBounds(pCurrUserNote);
				adjustfarthestbottomright(pCurrUserNote);
			}
			/// Manage background panel
			/// 
			pTransaction.Width = farthesbottomright.X - pTransaction.Left + 16;
			pTransaction.Height = farthesbottomright.Y - pTransaction.Top + 16;
			pTransaction.Show();
			/// Manage Restart/Save Buttons
			bClearCurrTrans.Left = pSessionKey.Left + spacing;
			bClearCurrTrans.Top = pTransaction.Bottom + spacing + 5;
			bSaveandNewCurrTrans.Left = bClearCurrTrans.Right + 70;
			bSaveandNewCurrTrans.Top = bClearCurrTrans.Top - (bSaveandNewCurrTrans.Height
				- bClearCurrTrans.Height) / 2;
			bClearCurrTrans.Visible = true;
			checkTransReadytoSave();
			//****
			loadTransactionList(CurrTrans.DET, cursor.X, cursor.Y);
		}



		private void showTransactionPanel()
		{
			if (VWA4Common.GlobalSettings.SessionOpen <= 0) return;  // if no open session, nothing to do here
			pTransactionList.Hide();

			pTransactionList.Top = bClearCurrTrans.Bottom + 8;
			pTransactionList.Left = pTransaction.Left;
			pTransactionList.Height = pBottomPanel.Top - 6 - pTransactionList.Top;
			pTransactionList.Width = pBottomPanel.Right - 15 - pTransactionList.Left;
			pTransactionList.Show();
			ulvTransactions.ItemSettings.SelectionType = SelectionType.Single;

		}
		private void hideTransactionPanel()
		{
			pTransactionList.Hide();
		}

		/// <summary>
		/// Load the current transaction variables.
		/// UI labels are loaded elsewhere - see showCurrTrans();
		/// </summary>
		/// <param name="ID">ID of the transaction to load.</param>
		/// <returns></returns>
		private bool loadCurrTransaction(int ID)
		{
			try
			{
				//
				// Get the Transactions from the database
				//
				string sql = "SELECT * FROM Weights WHERE ID = "
					+ ID.ToString();
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					CurrTrans.ID = int.Parse(dr["ID"].ToString());
					CurrTrans.IsPreconsumer = int.Parse(dr["IsPreconsumer"].ToString());
					CurrTrans.TransKey = int.Parse(dr["TransKey"].ToString());
					CurrTrans.Timestamp = DateTime.Parse(dr["Timestamp"].ToString());
					CurrTrans.Weight = decimal.Parse(dr["Weight"].ToString());
					CurrTrans.WasteCost = decimal.Parse(dr["WasteCost"].ToString());
					CurrTrans.FoodTypeID = dr["FoodTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", CurrTrans.FoodTypeID,
						out CurrTrans.FoodTypeName);
					CurrTrans.FoodTypeCost = Decimal.Parse(dr["FoodTypeCost"].ToString());
					CurrTrans.FoodTypeDiscount = decimal.Parse(dr["FoodTypeDiscount"].ToString());
					CurrTrans.LossTypeID = dr["LossTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss", CurrTrans.LossTypeID,
						out CurrTrans.LossTypeName);
					CurrTrans.ContainerTypeID = dr["ContainerTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", CurrTrans.ContainerTypeID,
						out CurrTrans.ContainerTypeName);
					CurrTrans.ContainerWeight = decimal.Parse(dr["ContainerWeight"].ToString());
					CurrTrans.StationTypeID = dr["StationTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station", CurrTrans.StationTypeID,
						out CurrTrans.StationTypeName);
					CurrTrans.DispositionTypeID = dr["DispositionTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition", CurrTrans.DispositionTypeID,
						out CurrTrans.DispositionTypeName);
					CurrTrans.DaypartTypeID = dr["DaypartTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart", CurrTrans.DaypartTypeID,
						out CurrTrans.DaypartTypeName);
					CurrTrans.BEOTypeID = dr["BEOTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder", CurrTrans.BEOTypeID,
						out CurrTrans.BEOTypeName);
					CurrTrans.UserTypeID = dr["UserTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user", CurrTrans.UserTypeID,
						out CurrTrans.UserTypeName);
					CurrTrans.UserQuestion = dr["UserQuestion"].ToString();
					tCurrUserNote.Text = CurrTrans.UserQuestion;
					CurrTrans.Nitems = int.Parse(dr["Nitems"].ToString());
					CurrTrans.IsMemorized = int.Parse(dr["IsMemorized"].ToString());
					CurrTrans.QuantityString_DE =
						VWA4Common.GlobalSettings.GetQuantityModeStringCodefromIsMemorized(CurrTrans.IsMemorized);
					decimal wasteamountuserentry = 0;
					decimal.TryParse(dr["WasteAmountUserEntry"].ToString(), out wasteamountuserentry);
					
					switch (CurrTrans.QuantityString_DE.ToLower())
					{
						case "wt":
							{
								//CurrTrans.Weight = wasteamountuserentry;
								//CurrTrans.Nitems = int.Parse(dr["Nitems"].ToString());
								break;
							}
						case "vol":
							{
								dVol_ContainerMultiplier = wasteamountuserentry;
								break;
							}
						case "each":
							{
								CurrTrans.EachFormatID_DE = int.Parse(dr["EachFormatID_DE"].ToString());
								dEach_ItemQuantity = wasteamountuserentry;
								break;
							}
					}
					
					DateTime.TryParse(dr["StartTimestamp"].ToString(), out CurrTrans.StartTimestamp);
					int.TryParse(dr["DETID"].ToString(), out CurrTrans.DETID);
					CurrTrans.DET.DETID = CurrTrans.DETID;
					DateTime.TryParse(dr["SaveTimestamp"].ToString(), out CurrTrans.SaveTimestamp);
					CurrTrans.QuantityString_DE = dr["QuantityString_DE"].ToString();
				}

				bQuantityGood = true;
				return true;
			}
			catch (Exception e)
			{
				if (e.Message != null)
				{
					MessageBox.Show("Failed to load transaction...Check database!\n" + e.Message);
				}
				return false;
			}
		}

		/// <summary>
		/// Load the prev transaction instance.
		/// </summary>
		/// <param name="ID">ID of the transaction to load.</param>
		/// <returns></returns>
		private bool loadPrevTransaction(int ID)
		{
			PrevTrans = new Transaction_Mem();
			try
			{
				//
				// Get the Transactions from the database
				//
				string sql = "SELECT * FROM Weights WHERE ID = "
					+ ID.ToString();
				DataTable dt = VWA4Common.DB.Retrieve(sql);
				if (dt != null && dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					PrevTrans.ID = int.Parse(dr["ID"].ToString());
					PrevTrans.IsPreconsumer = int.Parse(dr["IsPreconsumer"].ToString());
					PrevTrans.TransKey = int.Parse(dr["TransKey"].ToString());
					PrevTrans.Timestamp = DateTime.Parse(dr["Timestamp"].ToString());
					PrevTrans.WasteCost = decimal.Parse(dr["WasteCost"].ToString());
					PrevTrans.FoodTypeID = dr["FoodTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", PrevTrans.FoodTypeID,
						out PrevTrans.FoodTypeName);
					PrevTrans.FoodTypeCost = Decimal.Parse(dr["FoodTypeCost"].ToString());
					PrevTrans.FoodTypeDiscount = decimal.Parse(dr["FoodTypeDiscount"].ToString());
					PrevTrans.LossTypeID = dr["LossTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss", PrevTrans.LossTypeID,
						out PrevTrans.LossTypeName);
					PrevTrans.ContainerTypeID = dr["ContainerTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", PrevTrans.ContainerTypeID,
						out PrevTrans.ContainerTypeName);
					PrevTrans.ContainerWeight = decimal.Parse(dr["ContainerWeight"].ToString());
					PrevTrans.StationTypeID = dr["StationTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station", PrevTrans.StationTypeID,
						out PrevTrans.StationTypeName);
					PrevTrans.DispositionTypeID = dr["DispositionTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition", PrevTrans.DispositionTypeID,
						out PrevTrans.DispositionTypeName);
					PrevTrans.DaypartTypeID = dr["DaypartTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart", PrevTrans.DaypartTypeID,
						out PrevTrans.DaypartTypeName);
					PrevTrans.BEOTypeID = dr["BEOTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder", PrevTrans.BEOTypeID,
						out PrevTrans.BEOTypeName);
					PrevTrans.UserTypeID = dr["UserTypeID"].ToString();
					VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user", PrevTrans.UserTypeID,
						out PrevTrans.UserTypeName);
					PrevTrans.UserQuestion = dr["UserQuestion"].ToString();
					//tCurrUserNote.Text = PrevTrans.UserQuestion;
					PrevTrans.Nitems = int.Parse(dr["Nitems"].ToString());
					PrevTrans.IsMemorized = int.Parse(dr["IsMemorized"].ToString());
					PrevTrans.QuantityString_DE =
						VWA4Common.GlobalSettings.GetQuantityModeStringCodefromIsMemorized(PrevTrans.IsMemorized);
					decimal wasteamountuserentry = 0;
					decimal.TryParse(dr["WasteAmountUserEntry"].ToString(), out wasteamountuserentry);

					switch (PrevTrans.QuantityString_DE.ToLower())
					{
						case "wt":
							{
								PrevTrans.Weight = wasteamountuserentry;
								PrevTrans.Nitems = int.Parse(dr["Nitems"].ToString());
								break;
							}
						case "vol":
							{
								dVol_ContainerMultiplier = wasteamountuserentry;
								break;
							}
						case "each":
							{
								PrevTrans.EachFormatID_DE = int.Parse(dr["EachFormatID_DE"].ToString());
								dEach_ItemQuantity = wasteamountuserentry;
								break;
							}
					}

					DateTime.TryParse(dr["StartTimestamp"].ToString(), out PrevTrans.StartTimestamp);
					int.TryParse(dr["DETID"].ToString(), out PrevTrans.DETID);
				//	PrevTrans.DET.DETID = PrevTrans.DETID;
					DateTime.TryParse(dr["SaveTimestamp"].ToString(), out PrevTrans.SaveTimestamp);
					PrevTrans.QuantityString_DE = dr["QuantityString_DE"].ToString();
				}

				return true;
			}
			catch (Exception e)
			{
				if (e.Message != null)
				{
					MessageBox.Show("Failed to load transaction...Check database!\n" + e.Message);
				}
				return false;
			}
		}

		/// <summary>
		/// Load the Transaction list for the current session.
		/// </summary>
		/// <param name="det"></param>
		private void loadTransactionList(GlobalClasses.DataEntryTemplate det, int sessiontransleft, int sessiontranstop)
		{
			loadTransactionList(CurrTrans.DET, cursor.X, cursor.Y, false);
		}

		/// <summary>
		/// Load the Transaction list for the current session.
		/// </summary>
		/// <param name="det"></param>
		private void loadTransactionList(GlobalClasses.DataEntryTemplate det, int sessiontransleft, int sessiontranstop, bool noshow)
		{
			hideTransactionPanel();
			transactions_listview = new Dictionary<string, VWA4Common.Transaction_Mem>();
			ulvTransactions.Reset();
			pTransactionList.Left = sessiontransleft;
			pTransactionList.Top = sessiontranstop;
			pTransactionList.Width = 700;
			//
			// Set the control's View property to 'Details'
			ulvTransactions.View = UltraListViewStyle.Details;
			ulvTransactions.ItemSettings.Appearance.Image = imageList1.Images[0];

			// Set some properties so that SubItems (and their respective
			// columns) are visible by default in the views that support
			// columns, and also, make the column names and sub-item
			// values not appear in tooltips by default.
			ulvTransactions.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
			ulvTransactions.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
			ulvTransactions.ViewSettingsDetails.FullRowSelect = true;
			//ulvSessions.ViewSettingsTiles.SubItemsVisibleByDefault = true;
			ulvTransactions.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			lTransWindowTitle.Text = "Session " + lSessID.Text + " Transactions for " + cbDETemplates.Text;
			/// Add the columns based on Transaction Settings
			/// 
			// Main Column
			UltraListViewMainColumn mainColumn = ulvTransactions.MainColumn;
			mainColumn.Text = "ID";
			mainColumn.DataType = typeof(System.Int32);
			mainColumn.Width = 80;
			UltraListViewSubItemColumn subItemColumn = null;
			subItemColumn = ulvTransactions.SubItemColumns.Add("Quantity");
			subItemColumn.DataType = typeof(System.String);
			subItemColumn.Text = "Quantity";

			// go through display order
			string[] tokens = det.Transaction_displayorder.Split(new Char[] { ',' });
			int i;
			//****
			for (i = 0; i < tokens.Length; i++)
			{
				string s = tokens[i].Trim();
				//************
				//************ SWITCH HERE
				//************
				switch (s.ToLower())
				{
					case "timestamp":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("Timestamp");
							subItemColumn.DataType = typeof(System.DateTime);
							subItemColumn.Text = "Timestamp";
							break;
						}
					case "user":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("UserType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "User";
							break;
						}
					case "wastemode":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("WasteMode");
							subItemColumn.DataType = typeof(System.Int32);
							subItemColumn.Text = "Waste Mode";
							break;
						}
					case "food":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("FoodType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Food Type";
							break;
						}
					case "loss":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("LossType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Loss Reason";
							break;
						}
					case "container":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("ContainerType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Container Type";
							break;
						}
					case "station":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("StationType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Station";
							break;
						}
					case "disposition":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("DispositionType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Disposition";
							break;
						}
					case "daypart":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("DaypartType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Daypart";
							break;
						}
					case "eventorder":
						{
							subItemColumn = ulvTransactions.SubItemColumns.Add("EventOrderType");
							subItemColumn.DataType = typeof(System.String);
							subItemColumn.Text = "Event Order";
							break;
						}
				}
			}
			///
			//
			// Get the Transactions from the database
			//
			string sql = "SELECT * FROM Weights WHERE (TransKey = "
				+ VWA4Common.GlobalSettings.SessionOpen.ToString() + ") AND (DETID = "
				+ det.DETID.ToString() + ") ORDER BY SaveTimestamp ASC";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					VWA4Common.Transaction_Mem trans = new VWA4Common.Transaction_Mem();
					// Fill in the memory Transaction
					trans.ID = int.Parse(dr["ID"].ToString());
					trans.IsPreconsumer = int.Parse(dr["IsPreconsumer"].ToString());
					trans.TransKey = int.Parse(dr["TransKey"].ToString());
					trans.Timestamp = DateTime.Parse(dr["Timestamp"].ToString());
					trans.Weight = decimal.Parse(dr["Weight"].ToString());
					trans.WasteCost = decimal.Parse(dr["WasteCost"].ToString());
					trans.FoodTypeID = dr["FoodTypeID"].ToString();
					trans.FoodTypeCost = decimal.Parse(dr["FoodTypeCost"].ToString());
					trans.FoodTypeDiscount = decimal.Parse(dr["FoodTypeDiscount"].ToString());
					trans.LossTypeID = dr["LossTypeID"].ToString();
					trans.ContainerTypeID = dr["ContainerTypeID"].ToString();
					trans.ContainerWeight = decimal.Parse(dr["ContainerWeight"].ToString());
					trans.ContainerCost = decimal.Parse(dr["ContainerCost"].ToString());
					trans.StationTypeID = dr["StationTypeID"].ToString();
					trans.DispositionTypeID = dr["DispositionTypeID"].ToString();
					trans.DaypartTypeID = dr["DaypartTypeID"].ToString();
					trans.BEOTypeID = dr["BEOTypeID"].ToString();
					trans.UserTypeID = dr["UserTypeID"].ToString();
					trans.UserQuestion = dr["UserQuestion"].ToString();
					trans.Nitems = int.Parse(dr["Nitems"].ToString());
					trans.IsManualInput = bool.Parse(dr["IsManualInput"].ToString());
					trans.IsMemorized = int.Parse(dr["IsMemorized"].ToString());
					trans.UnitUniqueName = dr["UnitUniqueName"].ToString();
					int.TryParse(dr["ProducedID"].ToString(), out trans.ProducedID);
					decimal.TryParse(dr["UnitaryItemWeight"].ToString(), out trans.UnitaryItemWeight);
					decimal.TryParse(dr["WasteAmountUserEntry"].ToString(), out trans.WasteAmountUserEntry);
					trans.UnitsDisplayName = dr["UnitsDisplayName"].ToString();
					DateTime.TryParse(dr["StartTimestamp"].ToString(), out trans.StartTimestamp);
					int.TryParse(dr["DETID"].ToString(), out trans.DETID);
					DateTime.TryParse(dr["SaveTimestamp"].ToString(), out trans.SaveTimestamp);
					trans.QuantityString_DE = dr["QuantityString_DE"].ToString();
					//
					// Add to Listview collection
					string transid = trans.ID.ToString();
					UltraListViewItem item = ulvTransactions.Items.Add(transid, transid);
					//
					// Add to dictionary
					transactions_listview.Add(transid, trans);
					//item.SubItems["Timestamp"].Value = trans.Timestamp;
					//string ret = "";
					//VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user",
					//    trans.UserTypeID, out ret);
					//item.SubItems["User"].Value = ret;
					item.SubItems["Quantity"].Value = trans.QuantityString_DE;
					//

					// 
					// Add the column data
					//
					for (i = 0; i < tokens.Length; i++)
					{

						string s = tokens[i].Trim();
						//************
						//************ SWITCH HERE
						//************
						switch (s.ToLower())
						{
							case "timestamp":
								{
									item.SubItems["Timestamp"].Value = trans.Timestamp;
									break;
								}
							case "user":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user",
									trans.UserTypeID, out retname);
									item.SubItems["UserType"].Value = retname;
									break;
								}
							case "wastemode":
								{
									item.SubItems["WasteMode"].Value =
										VWA4Common.GlobalSettings.GetWasteModeStringfromIsPreconsumer(
									trans.IsPreconsumer);
									break;
								}
							case "food":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food",
									trans.FoodTypeID, out retname);
									item.SubItems["FoodType"].Value = retname;
									break;
								}
							case "loss":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss",
									trans.LossTypeID, out retname);
									item.SubItems["LossType"].Value = retname;
									break;
								}
							case "container":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container",
									trans.ContainerTypeID, out retname);
									item.SubItems["ContainerType"].Value = retname;
									break;
								}
							case "station":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station",
									trans.StationTypeID, out retname);
									item.SubItems["StationType"].Value = retname;
									break;
								}
							case "disposition":
								{
									string retname = "";
									item.SubItems["DispositionType"].Value =
										VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition",
										trans.DispositionTypeID, out retname);
									item.SubItems["DispositionType"].Value = retname;
									break;
								}
							case "daypart":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart",
									trans.DaypartTypeID, out retname);
									item.SubItems["DaypartType"].Value = retname;
									break;
								}
							case "eventorder":
								{
									string retname = "";
									VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder",
									trans.BEOTypeID, out retname);
									item.SubItems["EventOrderType"].Value = retname;
									break;
								}
						}
					} // end for loop

				} // end foreach loop
			}
			cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			if (ulvTransactions.Items.Count > 0)
			{
				ulvTransactions.MainColumn.Sorting = Sorting.Descending;
				//if (ulvTransactions.Items[0].Key != "")
				//    loadPrevTransaction(int.Parse(ulvTransactions.Items[0].Key)); /// why was this commented out?
				if (noshow)
				{
					hideTransactionPanel();
				}
				else
				{
					showTransactionPanel();
				}
			}
			else
			{
				hideTransactionPanel();
				PrevTrans = null;
			}
		}

		private void hideSession()
		{
			pSessionKey.Hide();
			bNewSession.Hide();
			bOpenSession.Hide();
			bCloseSession.Hide();
			bSessSummary.Hide();
		}

		private void hideDETDefaults()
		{
			// Hide all FormSet controls
			pFormHeader.Hide();
			pFormUserType.Hide();
			pFormFoodType.Hide();
			pFormLossType.Hide();
			pFormContainerType.Hide();
			pFormStationType.Hide();
			pFormDispositionType.Hide();
			pFormDaypartType.Hide();
			pFormEventOrderType.Hide();
			pFormPrePost.Hide();
		}
		
		private void hideCurrTrans()
		{
			// Hide all Current Transaction controls
			pTransaction.Hide();
			pCurrUserType.Hide();
			pCurrFoodType.Hide();
			pCurrLossType.Hide();
			pCurrContainerType.Hide();
			pCurrStationType.Hide();
			pCurrDispositionType.Hide();
			pCurrDaypartType.Hide();
			pCurrEventOrderType.Hide();
			pCurrPrePost.Hide();
			pCurrTimestamp.Hide();
			pCurrQuantity.Hide();
			pCurrUserNote.Hide();
			bClearCurrTrans.Hide();
			bSaveandNewCurrTrans.Hide();
			bSaveandNewCurrTrans.Enabled = false;
		}
		
		///		
		/// Event Handlers and supporting routines
		///		



		private void dbDetector_UserLogin(object sender, LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Waste Data")))
				CloseTaskSheet();
		}
		private void CloseTaskSheet()
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		//private void btemp_Click(object sender, EventArgs e)
		//{

		//    frmTypePicker tp = new frmTypePicker("30149", "food");
		//    tp.ShowDialog();
		//    CurrTrans.FoodTypeID = VWA4Common.GlobalSettings.frmTypePicker_TypeIDSelected;
		//    CurrTrans.FoodTypeName = VWA4Common.GlobalSettings.frmTypePicker_TypeNameSelected;
		//    return;
		//}

		/// <summary>
		/// Open an existing session.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bOpenSession_Click(object sender, EventArgs e)
		{
			frmOpenExistingSession opensess = new frmOpenExistingSession();
			if (opensess.ShowDialog() == DialogResult.Cancel)
			{
				// User Cancelled - no change	
			}
			else
			{
				// OK we're set with Session to continue
				//
			//	LoadDETemplates();
				pInitialLoad.Hide();
				hideDETDefaults();
				hideCurrTrans();
				hideTransactionPanel();
				// OK we're set with Session to continue
				//
				_Transfer = new ImportTransfer(VWA4Common.GlobalSettings.SessionOpen, true);
				_Transfer.DBLoad(VWA4Common.GlobalSettings.SessionOpen);
				lFormChooserLeadin.Visible = true;
				cbDETemplates.Visible = true;
				bSetFormSetAsDefault.Visible = true;
				initSessionData(Sess_Current);
				showSession(false);
				//cbFormSet.SelectedIndex = -1;
				//cbFormSet.Text = "";
			}

		}

		private void initSessionData(GlobalClasses.DataEntrySession sesstoinit)
		{

			sesstoinit.TransKey = _Transfer.TransKey;
			sesstoinit.Timestamp = _Transfer.Timestamp;
			sesstoinit.StartDateTime = sesstoinit.Timestamp;
			sesstoinit.TermID = _Transfer.TermID;
			sesstoinit.SiteID = _Transfer.SiteID;
			sesstoinit.TypeCatalogID = _Transfer.TypeCatalogID;
			sesstoinit.IsPrior = _Transfer.IsPrior;
			sesstoinit.SessionEnd = _Transfer.SessionEnd;
			sesstoinit.UserTypeID = _Transfer.User;
			sesstoinit.SessionNotes = _Transfer.SessionNotes;
			sesstoinit.ManualDESession = _Transfer.IsManualDESession;
			sesstoinit.DataFromDate = _Transfer.DataFromDate;

			sesstoinit.TermName = _Transfer.TermName;
		}

		/// <summary>
		/// Start a New Session
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bNewSession_Click(object sender, EventArgs e)
		{
			///
			/// Start a new session
			/// 
			if (sender == bNewSession_initialscreen) LoadDETemplates();
			DateTime sessstartdate = DateTime.Now;
			// Choose Virtual Tracker
			frmNewSession newsess = new frmNewSession();
			if (newsess.ShowDialog() == DialogResult.Cancel)
			{
				// User Cancelled - no change
				return;
			}
			else
			{
				DateTime datafromdate;
				DateTime.TryParse(VWA4Common.GlobalSettings.SessionDataFromDate_DateSelected,
					out datafromdate);
				// OK we're set with new Session to start
				//
				pInitialLoad.Hide();
				// Get a new Session ID - by creating a new transfer record for the data
				// 
				//if (_Transfer == null)
				//{
					_Transfer = new ImportTransfer(sessstartdate, datafromdate, sessstartdate,
						VWA4Common.GlobalSettings.SessionTracker_TermIDSelected,
						VWA4Common.GlobalSettings.SessionTracker_TermNameSelected, "", VWA4Common.GlobalSettings.SessionSiteID,
						VWA4Common.GlobalSettings.SessionSiteName, VWA4Common.GlobalSettings.SessionTypeCatalogID,
						VWA4Common.GlobalSettings.SessionTypeCatalogName, false, true,
						VWA4Common.GlobalSettings.SessionUserTypeID);
					//save transfer to DB
					int sessid = _Transfer.DBSave(true);//_connTransaction, _transaction, true);
					if (sessid > 0)
					{
						VWA4Common.GlobalSettings.OpenSession(sessid);
						initSessionData(Sess_Current);
						showSession(false);
						//bCloseSession.Show();
						//bSessSummary.Show();
						//bOpenSession.Show();
						//bNewSession.Show();
						//pSessionKey.Show();
						lFormChooserLeadin.Visible = true;
						cbDETemplates.Visible = true;
						bSetFormSetAsDefault.Visible = true;
					}
					else
					{
						hideSession();
						pInitialLoad.Show();
						_Transfer = null;
						return; // Error
					}
				//}
			}

			/// Initialize New Session Labels
			lSessID.Text = _Transfer.TransKey.ToString();

			lSessDataFromDateleadin.Show();
			lSessDataFromDate.Text = _Transfer.DataFromDate.ToString("M/d/yy"); // VWA4Common.GlobalSettings.SessDataFromDate;
			lSessStartDateTimeleadin.Show();
			lSessDataFromDate.Show();
			lSessStartDateTime.Text = sessstartdate.ToString("M/d/yy");
			lSessTrackerNameleadin.Show();
			lSessTrackerName.Text = _Transfer.TermName; // VWA4Common.GlobalSettings.SessionTracker_TermName;
			lSessDEUserType.Text = _Transfer.User; // VWA4Common.GlobalSettings.SessionUserName;
			if (lSessDEUserType.Text == "") lSessDEUserType.Text = "(Click to set)";
			lSessDEUserTypeleadin.Show();

			lFormChooserLeadin.Show();
			//cbDETemplates.SelectedIndex = -1;
			//cbDETemplates.SelectedIndex = defaultTemplate;

			cbDETemplates.Show();

			/// Clear Listview
			ulvTransactions.Items.Clear();
			hideTransactionPanel();
		}

		private void bCloseSession_Click(object sender, EventArgs e)
		{
			CloseCurrSession();
		}

		private void CloseCurrSession()
		{
			_Transfer = null;
			string sql = "SELECT ID FROM Weights WHERE TransKey = " + VWA4Common.GlobalSettings.SessionOpen.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{ // Not a null session - update it


				// Save Session End Time
				sql = "UPDATE Transfers SET SessionEnd = #" + DateTime.Now.ToString()
					+ "# WHERE TransKey = " + VWA4Common.GlobalSettings.SessionOpen.ToString();
				VWA4Common.DB.Update(sql);
			}
			else
			{// Clean up any transfers with zero records
				sql = "DELETE FROM Transfers WHERE TransKey = " +
					VWA4Common.GlobalSettings.SessionOpen.ToString();
				VWA4Common.DB.Delete(sql);
			}
			VWA4Common.GlobalSettings.SessionOpen = 0;
			_Transfer = null;
			showSession(true);
			hideDETDefaults();
			hideCurrTrans();
			hideTransactionPanel();
			hideSession();
			pInitialLoad.Show();
		}

		private void cbFormSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!SkipSelectedIndexChangedHandler && Initialized && cbDETemplates.SelectedIndex >= 0 && VWA4Common.GlobalSettings.SessionOpen > 0)
			{
				ComboBoxItem cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
				showDETDefaults(cbi.ID);
				cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
				// Open a new blank current transaction
				showCurrTrans(CurrTrans.DET, true);
			}
		}

	
		private void bSaveCurrTrans_Click(object sender, EventArgs e)
		{
			SaveCurrentTransaction(false);
		}
		private void bSaveandCloseCurrTrans_Click(object sender, EventArgs e)
		{
			SaveCurrentTransaction(true);
		}


		/// <summary>
		/// Save the current Transaction.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveCurrentTransaction(bool closesession)
		{
			string failmsg = "";
			if (!calculateWaste(out failmsg))	// Make sure the waste calculation is up to date
			{ MessageBox.Show("Error in Waste calculation!\n" + failmsg); return; }
			//
			// need to access Form Set ID later
			ComboBoxItem cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			// Prep Quantity mode
			decimal wasteamountuserentry = 0;
			decimal unitaryitemweight = 0;
			switch (CurrTrans.IsMemorized)
			{
				case 3: // wt
					{
						wasteamountuserentry = CurrTrans.Weight;
						unitaryitemweight = 1; // lbs always
						break;
					}
				case 4: // vol
					{
						wasteamountuserentry = dVol_ContainerMultiplier;
						unitaryitemweight = -1; // not used - weight calculated from container
						break;
					}
				case 5: // each
					{
						wasteamountuserentry = dEach_ItemQuantity;
						unitaryitemweight = -1; // not used - weight calculated from each format
						break;
					}
			}
			/// Prep
			/// 
			CurrTrans.UserQuestion = tCurrUserNote.Text;
			
			// Prep data entry timestamp
			CurrTrans.SaveTimestamp = DateTime.Now;
			// Update the Transfer SessionEnd variable
			_Transfer.SessionEnd = CurrTrans.SaveTimestamp;

			string sql = "UPDATE Transfers SET SessionEnd=#" + _Transfer.SessionEnd.ToString()
				+ "# WHERE TransKey=" + _Transfer.TransKey.ToString();
			VWA4Common.DB.Insert(sql);
			//_Transfer.DBSave(false);

			///
			///prepare data for save
			///
			DataTable temp = VWA4Common.DB.Retrieve(@"SELECT TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName, " +
				" Sites.ID AS SiteID, Sites.LicensedSite AS SiteName " +
				" FROM (Sites LEFT JOIN Terminals ON Terminals.SiteID = Sites.ID) " +
				" LEFT OUTER JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID" +
				" WHERE Terminals.TermID = '" + VWA4Common.GlobalSettings.SessionTracker_TermID + "'");
			string siteID = "0", siteName = "", typeCatalogID = "0", typeCatalogName = "";
			if (temp != null && temp.Rows.Count > 0)
			{
				siteID = temp.Rows[0]["SiteID"].ToString();
				siteName = temp.Rows[0]["SiteName"].ToString();
				typeCatalogID = temp.Rows[0]["TypeCatalogID"].ToString();
				typeCatalogName = temp.Rows[0]["TypeCatalogName"].ToString();
				if (typeCatalogID == "")
				{
					typeCatalogID = "0";
					typeCatalogName = "(Master Type Catalog)";
				}
			}
			CurrTrans.dTotalWasteCost = CurrTrans.dTotalFoodCost + CurrTrans.dTotalContainerCost;
			CurrTrans.dTransactionWt = CurrTrans.dTotalFoodWeight + CurrTrans.dTotalContainerWeight;
			decimal dcontainerwttouse;
			decimal dtotalweighttouse;
			
			
			//if (sQuantityMode_CurrTrans.ToLower() == "wt")
			if (CurrTrans.IsMemorized == 3) // Weight manually entered mode
			{
				dtotalweighttouse = CurrTrans.dTransactionWt;
			    dcontainerwttouse = CurrTrans.ContainerWeight;
			}
			else
			{
				dtotalweighttouse = CurrTrans.dTransactionWt;
				dcontainerwttouse = CurrTrans.dTotalContainerWeight;
			}
			/// This is a new transaction
			///create data record
			ImportWeight rec = new ImportWeight(_Transfer.TransKey,
				CurrTrans.Timestamp, //DateTime.Parse(lCurrDateTime.Text),
				CurrTrans.IsPreconsumer,
				dtotalweighttouse /* * nItems? */ , CurrTrans.WasteCost,
				
				CurrTrans.FoodTypeID, CurrTrans.FoodTypeCost, CurrTrans.dDiscount,
				CurrTrans.LossTypeID, CurrTrans.ContainerTypeID, dcontainerwttouse,
				CurrTrans.ContainerCost,
				CurrTrans.StationTypeID, CurrTrans.DispositionTypeID,
				CurrTrans.DaypartTypeID, CurrTrans.BEOTypeID, CurrTrans.UserTypeID,
				CurrTrans.UserQuestion, CurrTrans.Nitems, true,
				CurrTrans.IsMemorized,
				"Pound", "lb", -1, wasteamountuserentry.ToString(),
				unitaryitemweight.ToString(), 0, CurrTrans.DETID, CurrTrans.StartTimestamp, 
				CurrTrans.SaveTimestamp, CurrTrans.QuantityString_DE, iEach_EachFormatID);
			rec.Check();
			if (rec.IsCorrect())
			{//save data to DB
				if (bEditingSavedTrans_CurrTrans)
				{
					/// We are saving an edited record from the database
					/// So here we delete the old one prior to save; the new one
					/// will have appropriate data and become the new previous transaction.
					sql = "DELETE FROM Weights WHERE ID = " + CurrTrans.ID.ToString();
					VWA4Common.DB.Delete(sql);
				}
				CurrTrans.ID= rec.DBSave(true);//_connTransaction, _transaction, true);

				/// Finish filling out the in-memory Transaction and add to listview
				/// 
				CurrTrans.TransKey = _Transfer.TransKey;
				CurrTrans.IsManualInput = true;
				// Get UnitsDisplayName
				int id = -1;
				string displayfullname = "";
				decimal conversionfactor = 0;
				string description = "";
				VWA4Common.GlobalSettings.GetWtUnitsDataFromUniqueName(CurrTrans.UnitUniqueName,
					out id, out displayfullname,
					out CurrTrans.UnitsDisplayName, // this is what we need
					out conversionfactor,
					out description);
				CurrTrans.ProducedID = -1;
				CurrTrans.UnitaryItemWeight = unitaryitemweight;
				CurrTrans.WasteAmountUserEntry = wasteamountuserentry;
				// Add to Listview collection
				UltraListViewItem item = ulvTransactions.Items.Add(CurrTrans.ID.ToString(), CurrTrans.ID.ToString());

				///// Create in-memory Transaction and add to listview
				///// 
				///// Save to Transaction collection and listview
				///// 
				//VWA4Common.Transaction_Mem trans = new VWA4Common.Transaction_Mem();
				// Fill in the memory Transaction
				//trans.ID = transid;
				//trans.IsPreconsumer = iWasteModeID_CurrTrans;
				//trans.TransKey = _Transfer.TransKey;
				//trans.Timestamp = DateTime.Parse(lCurrDateTime.Text + " " + lCurrTime.Text);
				//trans.Weight = dTransactionWt_CurrTrans;
				//trans.WasteCost = dWasteCost_CurrTrans;
				//trans.FoodTypeID = sFoodTypeID_CurrTrans;
				//trans.FoodTypeCost = decimal.Parse(sFoodTypeCost_CurrTrans);
				//trans.FoodTypeDiscount = discount;
				//trans.LossTypeID = sLossTypeID_CurrTrans;
				//trans.ContainerTypeID = sContainerTypeID_CurrTrans;
				//trans.ContainerWeight = dSingleContainerWt_Curr;
				//trans.ContainerCost = decimal.Parse(sContainerTypeCost_CurrTrans.Replace("$", ""));
				//trans.StationTypeID = sStationTypeID_CurrTrans;
				//trans.DispositionTypeID = sDispositionTypeID_CurrTrans;
				//trans.DaypartTypeID = sDaypartTypeID_CurrTrans;
				//trans.BEOTypeID = sEventOrderTypeID_CurrTrans;
				//trans.UserTypeID = sUserTypeID_CurrTrans;
				//trans.UserQuestion = tCurrUserNote.Text;
				//trans.Nitems = nItems_CurrTrans;
				//trans.IsManualInput = true;
				///// Encode IsMemorized new values
				//trans.IsMemorized =
				//    VWA4Common.GlobalSettings.GetIsMemorizedfromQuantityModeStringCode(sQuantityMode_CurrTrans);
				//trans.UnitUniqueName = "Pound";
				//trans.StartTimestamp = dtStartTimestamp_CurrTrans;
				//trans.DETID = cbi.ID;
				//trans.SaveTimestamp = dtSaveTimestamp_CurrTrans;
				//trans.QuantityString_DE = lCurrQuantity.Text;
				//
				//// Add to Listview collection
				//UltraListViewItem item = ulvTransactions.Items.Add(trans.ID.ToString(), trans.ID.ToString());			 

				// Put in must have column data
				item.SubItems["Quantity"].Value = CurrTrans.QuantityString_DE;

				// go through display order
				string[] tokens = CurrTrans.DET.Transaction_displayorder.Split(new Char[] { ',' });
				int i;
				//****
				// 
				// Add the column data
				//
				for (i = 0; i < tokens.Length; i++)
				{

					string s = tokens[i].Trim();
					//************
					//************ SWITCH HERE
					//************
					switch (s.ToLower())
					{
						case "timestamp":
							{
								item.SubItems["Timestamp"].Value = CurrTrans.Timestamp;
								break;
							}
						case "user":
							{
								string ret = "";
								VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user",
									CurrTrans.UserTypeID, out ret);
								item.SubItems["UserType"].Value = ret;
								break;
							}
						
						case "wastemode":
							{
								item.SubItems["WasteMode"].Value = 
									VWA4Common.GlobalSettings.GetWasteModeStringfromIsPreconsumer(CurrTrans.IsPreconsumer);
								break;
							}
						case "food":
							{
								item.SubItems["FoodType"].Value = CurrTrans.FoodTypeName;
								break;
							}
						case "loss":
							{
								item.SubItems["LossType"].Value = CurrTrans.LossTypeName;
								break;
							}
						case "container":
							{
								item.SubItems["ContainerType"].Value = CurrTrans.ContainerTypeName;
								break;
							}
						case "station":
							{
								item.SubItems["StationType"].Value = CurrTrans.StationTypeName;
								break;
							}
						case "disposition":
							{
								item.SubItems["DispositionType"].Value = CurrTrans.DispositionTypeName;
								break;
							}
						case "daypart":
							{
								item.SubItems["DaypartType"].Value = CurrTrans.DaypartTypeName;
								break;
							}
						case "eventorder":
							{
								item.SubItems["EventOrderType"].Value = CurrTrans.BEOTypeName;
								break;
							}
					}
				} // end for loop

			}
			else
			{
				MessageBox.Show(this, rec.ErrorMsg + Environment.NewLine + rec.WarningMsg + Environment.NewLine,
				"Enter Waste Log Data", MessageBoxButtons.OK);
				return;
			}
			hideTransactionPanel();
			hideCurrTrans();
			if (closesession) CloseCurrSession();
			else
			{
				/// Advance to new Curr Trans and show this as Prev Trans
				showCurrTrans(CurrTrans.DET, true);
				cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			}
		}

		/// <summary>
		/// Clear the current transaction to standard values.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bClearCurrTrans_Click(object sender, EventArgs e)
		{
			/// OK show the screen - showCurrTrans will take care of any additional initialization
			showCurrTrans(CurrTrans.DET, true);
		}
		private void ClearCurrTrans()
		{
			cbi = (ComboBoxItem) cbDETemplates.SelectedItem;
			// Flags
			 bQuantityGood = false;
			 bEditingSavedTrans_CurrTrans = false;
			 bDirty_CurrTrans = false;
			 // Must have transaction data
			CurrTrans.Timestamp = DateTime.MinValue;
			CurrTrans.IsPreconsumer = -1;
			CurrTrans.WasteCost = -1;
			CurrTrans.Nitems = -1;
			CurrTrans.dDiscount = 1;

			// Weight mode
			CurrTrans.Weight = 0;

			// Volume mode
			dVol_ContainerMultiplier = 0;

			// Each mode
			iEach_EachFormatID = 0;
			dEach_ItemQuantity = 0;

			// Required Types
			CurrTrans.UserTypeID = "";
			CurrTrans.UserTypeName = "";
			CurrTrans.FoodTypeID = "";
			CurrTrans.FoodTypeName = "";
			CurrTrans.FoodTypeCost = 0;
			CurrTrans.dDiscount = 1;
			CurrTrans.LossTypeID = "";
			CurrTrans.LossTypeName = "";
			CurrTrans.ContainerTypeID = "";
			CurrTrans.ContainerTypeName = "";
			CurrTrans.ContainerCost = 0;
			CurrTrans.ContainerWeight = 0;

			// Optional Types
			CurrTrans.StationTypeID = "";
			CurrTrans.StationTypeName = "";
			CurrTrans.DispositionTypeID = "";
			CurrTrans.DispositionTypeName = "";
			CurrTrans.DaypartTypeID = "";
			CurrTrans.DaypartTypeName = "";
			CurrTrans.BEOTypeID = "";
			CurrTrans.BEOTypeName = "";

		}

		/// 
		/// Event handlers for manual filling of current transaction
		/// 
		//*******
		private void ChooseTimestamp_Click(object sender, EventArgs e)
		{
			frmEnterCurrTransTimestamp frm = new frmEnterCurrTransTimestamp(CurrTrans.Timestamp);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				// a new Date/Time was entered
				CurrTrans.Timestamp = DateTime.Parse(frm.DateTimeSelectedString);
				lCurrDateTime.Text = CurrTrans.Timestamp.ToString();
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseUser_Session_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "user");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				VWA4Common.GlobalSettings.SessionUserTypeID = 
					tp.TypeIDSelected;
				VWA4Common.GlobalSettings.SessionUserName = 
					VWA4Common.GlobalSettings.frmTypePicker_TypeNameSelected;
				lSessDEUserType.Text = tp.TypeNameSelected;
			}
		}


		//*******
		private void ChooseUser_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "user");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.UserTypeID = tp.TypeIDSelected;
				CurrTrans.UserTypeName = tp.TypeNameSelected;
				lCurrUserType.Text = CurrTrans.UserTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseFood_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "food");
		
			//frmTypePicker tp = new frmTypePicker(VWA4Common.GlobalSettings.SessionTracker_TermID, "food");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.FoodTypeID = tp.TypeIDSelected;
				CurrTrans.FoodTypeName = tp.TypeNameSelected;
				CurrTrans.FoodTypeCost = decimal.Parse(tp.FoodCostofSelectedFoodType.ToString());
				lCurrFoodType.Text = CurrTrans.FoodTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseLoss_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "loss");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.LossTypeID = tp.TypeIDSelected;
				CurrTrans.LossTypeName = tp.TypeNameSelected;
				lCurrLossType.Text = CurrTrans.LossTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseContainer_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "container");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				//if ((lCurrQuantity.Text == "")
				
				if ((lCurrQuantity.Text == "") ||
					((CurrTrans.dTotalFoodWeight > 0) && (CurrTrans.dTotalFoodWeight > decimal.Parse(tp.ContainerWtofSelectedContainerType.ToString()))) || (CurrTrans.dTotalFoodWeight == 0)
					)
				{
					CurrTrans.ContainerTypeID = tp.TypeIDSelected;
					CurrTrans.ContainerTypeName = tp.TypeNameSelected;
					CurrTrans.ContainerCost = decimal.Parse(tp.ContainerCostofSelectedContainerType.ToString());
					CurrTrans.ContainerWeight = (decimal.Parse(tp.ContainerWtofSelectedContainerType.ToString()));
					lCurrContainerType.Text = CurrTrans.ContainerTypeName;
					checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
					repaintCurrTrans();
				}
				else
				{
					MessageBox.Show("Container chosen weighs more than total weight entered!\n Please pick a container than weighs less than the total - can't have negative net (food waste) weight.");
				}
			}
		}


		//*******
		private void ChooseStation_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "station");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.StationTypeID = tp.TypeIDSelected;
				CurrTrans.StationTypeName = tp.TypeNameSelected;
				lCurrStationType.Text = CurrTrans.StationTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseDisposition_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "disposition");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.DispositionTypeID = tp.TypeIDSelected;
				CurrTrans.DispositionTypeName = tp.TypeNameSelected;
				lCurrDispositionType.Text = CurrTrans.DispositionTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseDaypart_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(Sess_Current.TermID, "daypart");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.DaypartTypeID = tp.TypeIDSelected;
				CurrTrans.DaypartTypeName = tp.TypeNameSelected;
				lCurrDaypartType.Text = CurrTrans.DaypartTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseEventOrder_Click(object sender, EventArgs e)
		{
			frmEventOrderPicker tp = new frmEventOrderPicker();
			if (tp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.BEOTypeID = tp.TypeIDSelected;
				CurrTrans.BEOTypeName = tp.TypeNameSelected;
				lCurrEventOrderType.Text = CurrTrans.BEOTypeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}

		//*******
		private void ChooseWasteMode_Click(object sender, EventArgs e)
		{
			frmWasteModePicker wp = new frmWasteModePicker();
			if (wp.ShowDialog() == DialogResult.OK)
			{
				CurrTrans.IsPreconsumer = wp.IsPreconsumer;
				lCurrPrePost.Text = wp.WasteModeName;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}


		private void ChooseQuantity_Click(object sender, EventArgs e)
		{
			frmEnterTransUnits tu;
			bQuantityGood = false;
			int ismemorized = 0;
			if ((2 <= CurrTrans.IsMemorized) && (CurrTrans.IsMemorized <= 5))
				ismemorized = CurrTrans.IsMemorized;
			else
			{
				cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
				GlobalClasses.DataEntryTemplate detmem = new GlobalClasses.DataEntryTemplate();
				VWA4Common.GlobalSettings.DETLoad(cbi.ID,detmem);
				ismemorized = VWA4Common.GlobalSettings.GetIsMemorizedfromQuantityModeStringCode(
					detmem.Quantity_CTDefaultMode);
			}
			switch (ismemorized)
			{
				case 3: // "wt": // Weight
					{
						decimal dwttopass = CurrTrans.Weight;
						if (dwttopass > 0) dwttopass = CurrTrans.Weight/CurrTrans.Nitems;
						// Set Quantity Mode to wt in Quantity picker, init food and container types
						tu = new frmEnterTransUnits(CurrTrans.FoodTypeID,
							CurrTrans.ContainerTypeID, dwttopass,
							CurrTrans.Nitems, CurrTrans.ContainerWeight);	// Init to Weight Mode
						break;
					}
				case 4: // "vol": // Volume
					{
						// Set Volume Mode to wt in Quantity picker, init food and container types
						tu = new frmEnterTransUnits(CurrTrans.FoodTypeID,
							CurrTrans.ContainerTypeID, dVol_ContainerMultiplier, CurrTrans.Weight, CurrTrans.ContainerWeight);	// Init to Volume Mode
						break;
					}
				case 5: // "each": // Each
					{
						// Set Each Mode to wt in Quantity picker, init food and container types
						tu = new frmEnterTransUnits(CurrTrans.FoodTypeID,
							CurrTrans.ContainerTypeID, CurrTrans.EachFormatID_DE,
							dEach_ItemQuantity, CurrTrans.Weight, CurrTrans.ContainerWeight);	// Init to Each Mode
						break;
					}
				default: // Probably blank Quantity mode if you get here
					{
			
						// Set Quantity Mode to wt in Quantity picker, init food and container types
						tu = new frmEnterTransUnits(CurrTrans.FoodTypeID,
							CurrTrans.ContainerTypeID, CurrTrans.Weight,
							0, CurrTrans.ContainerWeight);	// Init to Weight Mode
						break;
					}
			}
			/// show the dialog and process results
			if (tu.ShowDialog() == DialogResult.OK)
			{
				// Units are good - update the display
				switch (tu.UnitsMode.ToLower())
				{
					case "wt": // Weight
						{
							lCurrQuantityLeadin.Text = "Quantity (Weight Specified):";
							CurrTrans.Nitems = tu.NItems;
							CurrTrans.Weight = tu.GrossWeight;
							CurrTrans.dTotalFoodWeight = tu.GrossWeight;
							//* CurrTrans.Nitems;
							lCurrQuantity.Text = CurrTrans.Weight.ToString("####0.0") + " lb(s)"; 
							iEach_EachFormatID = 0;
							break;
						}
					case "vol": // Volume
						{
							string sQuantityMode_CurrTrans = "";
							lCurrQuantityLeadin.Text = "Quantity (Containers Specified):";
							dVol_ContainerMultiplier = 
								decimal.Parse(VWA4Common.GlobalSettings.frmUnits_Vol_ContainerMultiplier);
							sQuantityMode_CurrTrans = VWA4Common.GlobalSettings.frmUnits_Vol_ContainerMultiplier
								+ " ";
							string retname = "";
							VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container",
								VWA4Common.GlobalSettings.frmUnits_ContainerTypeID, out retname);
							sQuantityMode_CurrTrans += retname + "(s)";
							lCurrQuantity.Text = sQuantityMode_CurrTrans;
							//				
							CurrTrans.FoodTypeID = VWA4Common.GlobalSettings.frmUnits_FoodTypeID;
							VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", CurrTrans.FoodTypeID,
								out CurrTrans.FoodTypeName);
							decimal foodcost = 0;
							VWA4Common.GlobalSettings.GetFoodCostfromType(CurrTrans.FoodTypeID, out  foodcost);
							CurrTrans.FoodTypeCost = foodcost;
							//				
							CurrTrans.ContainerTypeID = VWA4Common.GlobalSettings.frmUnits_ContainerTypeID;
							VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", CurrTrans.ContainerTypeID,
								out CurrTrans.ContainerTypeName);
							decimal sccost = 0;
							decimal scwt = 0;
							VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
								out sccost, out scwt);
							CurrTrans.ContainerCost = sccost;
							CurrTrans.ContainerWeight = scwt;
							//				
							lCurrFoodType.Text = CurrTrans.FoodTypeName;
							lCurrContainerType.Text = CurrTrans.ContainerTypeName;
							iEach_EachFormatID = 0;
							break;
						}
					case "each": // Each
						{
							string sQuantityMode_CurrTrans = "";
							lCurrQuantityLeadin.Text = "Quantity (Count Specified):";
							dEach_ItemQuantity = decimal.Parse(VWA4Common.GlobalSettings.frmUnits_Each_ItemCount);
							sQuantityMode_CurrTrans = VWA4Common.GlobalSettings.frmUnits_Each_ItemCount
								+ " ";
							string retname = "";
							iEach_EachFormatID = int.Parse(VWA4Common.GlobalSettings.frmUnits_Each_EachFormatID);
							VWA4Common.GlobalSettings.GetEachFormatNameFromID(
								iEach_EachFormatID, out retname);
							sQuantityMode_CurrTrans += retname + "(s)";
							lCurrQuantity.Text = sQuantityMode_CurrTrans;
							CurrTrans.FoodTypeID = VWA4Common.GlobalSettings.frmUnits_FoodTypeID;
							VWA4Common.GlobalSettings.GetTypeNameFromTypeID(
								"food", CurrTrans.FoodTypeID, out CurrTrans.FoodTypeName);
							decimal fc;
							VWA4Common.GlobalSettings.GetFoodCostfromType(CurrTrans.FoodTypeID, out  fc);
							CurrTrans.FoodTypeCost = fc;
							lCurrFoodType.Text = CurrTrans.FoodTypeName;
							break;
						}
					
				}

				CurrTrans.IsMemorized = VWA4Common.GlobalSettings.GetIsMemorizedfromQuantityModeStringCode(
					tu.UnitsMode);
				CurrTrans.QuantityString_DE = lCurrQuantity.Text;
				bQuantityGood = true;
				checkTransReadytoSave(true);	// Check whether to show save trans button, plus dirty the trans
				repaintCurrTrans();
			}
		}
	
		/// <summary>
		/// Check whether the current transaction is ready to save - turn on the save button if so.
		/// </summary>
		/// <returns>True if the current transaction is ready to save; false if incomplete.
		/// Ready to save is when the timestamp, quantity, and required types are supplied.</returns>
		private bool checkTransReadytoSave(bool dirtytrans)
		{
			bDirty_CurrTrans = dirtytrans;
			return checkTransReadytoSave();
		}
		//***
		private bool checkTransReadytoSave()
		{
			bSaveandNewCurrTrans.Show();
			bSaveandNewCurrTrans.Enabled = false;
			// hmmm, where to start?  Must have transaction quantity legal...
			if (!bQuantityGood) return false; // Quantity isn't done
			if (CurrTrans.Timestamp == DateTime.MinValue) return false; // No Timestamp
			if (CurrTrans.UserTypeID == "") return false; // No User Type
			if (CurrTrans.FoodTypeID == "") return false; // No Food Type
			if (CurrTrans.LossTypeID == "") return false; // No Loss Type
			if (CurrTrans.ContainerTypeID == "") return false; // No Container Type
			if (CurrTrans.IsPreconsumer < 0) return false; // No Pre/Post/Intermediate selection
			
			/// fall through to here if no problems are found
			// Calculate Waste cost etc.

			bSaveandNewCurrTrans.Show();
			bSaveandNewCurrTrans.Enabled = true;
			return true;
		}

		/// <summary>
		/// Calculate the waste values based on current situation of the globals.
		/// Check carefully and make this a robust, easy to call method.
		/// </summary>
		/// <returns>True if calculation was successful; false if not enough data available to
		/// do the calculation.</returns>
		private bool calculateWaste(out string failmsg)
		{
			failmsg = "";
			/// Local variables
			// calculated:
			decimal totalfoodwastecost_calculated = -1;
			decimal totalcontainerwastecost_calculated = -1;
			decimal totalcontainerweight_calculated = -1;
			decimal totalfoodweight_calculated = -1;
			
			// inputs to calculations:
			//  shared variables:
			decimal foodtypecost = 0;
			decimal containertypecost = 0;
			decimal containertareweight = 0;
			
			// Volume variables
			decimal volume_container = 0;
			int volumeunittype_container = 0;
			decimal volumeweight_food = 0;
			decimal volumeunits_food = 0;
			int volumeunittype_food = 0;

			// Each variables
			string eachformatname = "";
			decimal eachquantity = 0;
			decimal wtmultiplier = 0;
			int unitswtid = 0;
			int order = 0;
			string description = "";
			string uniquename_wtunits = "";
			string displayfullname_wtunit = "";
			string displayabbreviatedname_wtunit = "";
			decimal conversionfactor_wtunit = 0;
			string description_wtunit = "";
			/// Verify we have what we need to do the calculation as we go
			if (CurrTrans.IsMemorized < 3) return false; // Quantity mode not properly specified
			/// Check Food Type and Loss Reason specified 
			if ((CurrTrans.FoodTypeID == "") || (CurrTrans.LossTypeID == ""))
			{
				failmsg = "Food and Loss types are not both specified.";
				return false; }  // Food and Loss not both specified - they are required
			/// Get Food Type cost
			if (!VWA4Common.GlobalSettings.GetFoodCostfromType(CurrTrans.FoodTypeID,
				out foodtypecost))
			{
				failmsg = "No Food cost specified.";
				return false; 
			} // No Food cost
			CurrTrans.FoodTypeCost = foodtypecost;

			/// Get Container Type cost
			if (!VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
				out containertypecost, out containertareweight))
			{
				failmsg = "No Container cost specified.";
				return false; 
			} // No Container cost
				CurrTrans.ContainerWeight = containertareweight;

			/// Food Type and Loss Reason are specified - check to see if there's an associated discount
			CurrTrans.dDiscount = 1; // No discount is 1 multiplier
			DataTable dtDiscounts = VWA4Common.DB.Retrieve(
				"SELECT * FROM Discounts WHERE (FoodTypeID='"
				+ CurrTrans.FoodTypeID + "') AND (LossTypeID='" + CurrTrans.LossTypeID + "')");
			if (dtDiscounts.Rows.Count > 0)
			{ // There is a discount - set it
				DataRow row = dtDiscounts.Rows[0];
				CurrTrans.dDiscount = decimal.Parse(row["FoodCostDiscount"].ToString());
			}
			else
			{ // No discount
				// lFoodWasteDisc1.Text = "(none)";
			}
			/// 
			/// See if we have enough data to do a waste data calculation

			switch (CurrTrans.IsMemorized)
			{
				case 3: // "wt":
					{
						if ((CurrTrans.Weight <= 0) ||
							(CurrTrans.Nitems < 1))
						{ // Required data not specified yet

							failmsg = "Required data not specified yet.";
							return false;
						}
						///
						/// We have what we need - Do the calculation
						/// 
						// also need the tare weight and cost
						VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
							out containertypecost, out containertareweight);
						totalcontainerwastecost_calculated = containertypecost * CurrTrans.Nitems;
						totalcontainerweight_calculated = containertareweight * CurrTrans.Nitems;
						totalfoodweight_calculated = CurrTrans.Weight - totalcontainerweight_calculated;
						totalfoodwastecost_calculated = totalfoodweight_calculated * foodtypecost
							* CurrTrans.dDiscount;
						break;
					}
				case 4: // "vol":
					{
						CurrTrans.Nitems = 1;
						// Get Food Type volume data
						if (!VWA4Common.GlobalSettings.GetFoodVolumeData(CurrTrans.FoodTypeID,
							out volumeweight_food, out volumeunits_food, out volumeunittype_food))
						{ // Food Type doesn't have volume data
							failmsg = "Food Type doesn't have volume data.";
							return false;
						}
						// Food Type Has volume data
						// 
						// Now check container type has volume data
						if (!VWA4Common.GlobalSettings.GetContainerVolumeData(CurrTrans.ContainerTypeID,
							out volume_container, out volumeunittype_container))
						{ // Container Type doesn't have volume data
							failmsg = "Container Type doesn't have volume data.";
							return false;
						}
						// Container Type has volume data
						// also need the tare weight and cost
						VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
							out containertypecost, out containertareweight);
						//
						// Now check the user specified values are set
						//
						if (dVol_ContainerMultiplier <= 0)
						{ // Required data not specified yet
							failmsg = "Required volume data not specified yeta.";
							return false;
						}
						///
						/// We have what we need - Do the calculation
						/// 
						totalfoodwastecost_calculated = -1;
						totalcontainerwastecost_calculated = -1;
						totalfoodweight_calculated =
							VWA4Common.GlobalSettings.GetWasteWeightandCost_VolumeMethod(
							dVol_ContainerMultiplier, volumeweight_food, volumeunits_food,
							foodtypecost * CurrTrans.dDiscount, containertypecost, volume_container,
							containertareweight, volumeunittype_food,
							volumeunittype_container, out totalfoodwastecost_calculated, 
							out totalcontainerwastecost_calculated, out totalcontainerweight_calculated);
						if (totalfoodweight_calculated < 0)
						{
							failmsg = "Calculated food weight is less than zero.";
							return false; // Error in calculation
						}
						/// if we make it to here the calculation is done
						/// and ready to go...
						break;
					}
				case 5: // "each":
					{
						CurrTrans.Nitems = 1;
						// Globals:
						//int iEach_EachFormatID;
						//decimal dEach_ItemCount;
						// Get the required each format data
						if (!VWA4Common.GlobalSettings.GetEachFormatDataFromID(iEach_EachFormatID,
							out eachformatname, out eachquantity, out wtmultiplier, out unitswtid,
							out order, out description))
						{
							failmsg = "Each format data is missing.";
							return false;
						} // Probably the each format doesn't exist
						// Get the required weight units data
						if (!VWA4Common.GlobalSettings.GetWtUnitsDataFromID(unitswtid,
							out uniquename_wtunits, out displayfullname_wtunit,
							out displayabbreviatedname_wtunit, out conversionfactor_wtunit,
							out description_wtunit))
						{
							failmsg = "Each format data is missing.";
							return false;
						} // Units type doesn't exist
						/// Should be ready to calculate
						/// 
						/// totalfoodweight = eachquantity * wtmultiplier * conversionfactor_wtunit
						///                      * dEach_ItemQuantity;
						/// totalwastecost = foodweight * foodtypecost;
						totalfoodweight_calculated =
							eachquantity * wtmultiplier * conversionfactor_wtunit * dEach_ItemQuantity;
						totalfoodwastecost_calculated = totalfoodweight_calculated * foodtypecost
							* CurrTrans.dDiscount;
						// also need the tare weight and cost
						VWA4Common.GlobalSettings.GetContainerCostandWeight(CurrTrans.ContainerTypeID,
							out containertypecost, out containertareweight);
						totalcontainerwastecost_calculated = containertypecost * CurrTrans.Nitems;
						totalcontainerweight_calculated = containertareweight * CurrTrans.Nitems;
						break;
					}
			}

			/// Set the globals
			/// 
			CurrTrans.dTotalFoodWeight = totalfoodweight_calculated;
			CurrTrans.dTotalFoodCost = totalfoodwastecost_calculated;
			
			CurrTrans.dTotalContainerCost = totalcontainerwastecost_calculated;
			CurrTrans.dTotalContainerWeight = totalcontainerweight_calculated;
			CurrTrans.dTotalWasteCost = totalfoodwastecost_calculated
				+ totalcontainerwastecost_calculated;
			CurrTrans.WasteCost = CurrTrans.dTotalWasteCost;
			if (CurrTrans.dTotalFoodWeight <= 0)
			{
				failmsg = "Total Food weight is less than zero ("
					+ CurrTrans.dTotalFoodWeight.ToString() + ")\nCheck selected container weight.";
				return false;
			}
			return true;
		}


		private void ulvTransactions_DoubleClick(object sender, EventArgs e)
		{
			itemLoader();
		}

		
		private void tsmShowDetailsTrans_Click(object sender, EventArgs e)
		{
			string itemkey = ulvTransactions.SelectedItems[0].Key;
			frmTransactionViewer transviewer = new frmTransactionViewer(
				int.Parse(itemkey));
			transviewer.Show();
		}

		private void tsmOpenTrans_Click(object sender, EventArgs e)
		{
			itemLoader();
		}
		
		private void itemLoader()
		{
			if (ulvTransactions.SelectedItems.Count <= 0) return;
			
			string itemkey = ulvTransactions.SelectedItems[0].Key;
			// Find the trans item with this key
			VWA4Common.Transaction_Mem trans = new VWA4Common.Transaction_Mem();
			transactions_listview.TryGetValue(itemkey, out trans);
			cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			if (loadCurrTransaction(trans.ID))
			{
				// Open the item the user clicked on
				showCurrTrans(CurrTrans.DET, false);
			}
			else
			{
				// Open the item the user clicked on
				showCurrTrans(CurrTrans.DET, true);
			}
		}

		private void tsmDeleteTrans_Click(object sender, EventArgs e)
		{
			itemDeleter();
		}

		private void itemDeleter()
		{
			string itemkey = ulvTransactions.SelectedItems[0].Key;

			string sql = "DELETE FROM Weights WHERE ID = " + itemkey;
			VWA4Common.DB.Delete(sql);
			/// Initialize 				
			/// Load transactions
			cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			// Open the item the user clicked on
			loadTransactionList(CurrTrans.DET, cursor.X, cursor.Y);
		}


		private void lFormChooserLeadin_Click(object sender, EventArgs e)
		{

		}

		private void UCEnterWasteLogs_Resize(object sender, EventArgs e)
		{
			if (Initialized)
			{
				repaintSession();
				cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
				showDETDefaults(cbi.ID);
				repaintCurrTrans();
			}
		}

		private void ulvTransactions_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{	// Change this to false if you want to maintain
				// the existing selection.
				//bool clearExisting = false;
				Point cursorPos = new Point(e.X, e.Y);
				UltraListView listView = sender as UltraListView;
				// Use the UltraListView's 'ItemFromPoint' method to hit test for an
				// UltraListViewItem. Note that we specify true for the 'selectableAreaOnly'
				// parameter, so that we only get a hit when the cursor is over the text
				// or image area of the item.
				UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);
				// If we got a reference to an item, populate the context menu
				// accordingly and return
				if (itemAtPoint != null)
				{
					//this.ulvMethodsList.ContextMenuStrip = null;
					Infragistics.Win.ISelectionManager selectionManager =
						listView as Infragistics.Win.ISelectionManager;
					selectionManager.SelectItem(itemAtPoint, true);
					itemAtPoint.Activate();
					contextMenuStrip1.Enabled = true;
				}
				else
				{
					contextMenuStrip1.Enabled = false;
					//this.ulvMethodsList.ContextMenuStrip = cmsListViewStyle;
				}
			}

		}

		private void bSessSummary_Click(object sender, EventArgs e)
		{
			frmSessionSummary frm = new frmSessionSummary(VWA4Common.GlobalSettings.SessionOpen);
			frm.ShowDialog();
		}

		private void ulvTransactions_MouseDown_1(object sender, MouseEventArgs e)
		{
			UltraListViewSubItem cell = ulvTransactions.SubItemFromPoint(e.X, e.Y);
			if (cell != null)
			{
				ulvTransactions.SelectedItems.Clear();
				ulvTransactions.SelectedItems.Add(cell.Item);
			}

		}

		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmEnterLogProperties frme = new frmEnterLogProperties(pSessionKey.BackColor,
				pSessionKey.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle, dateFormat, timeFormat);
			if (frme.ShowDialog() == DialogResult.OK)
			{
				pSessionKey.BackColor = frme.SessionBackColor;
				if (frme.ShowDataEntryBorders)
					SetDataEntryBorders(BorderStyle.FixedSingle);
				else
					SetDataEntryBorders(System.Windows.Forms.BorderStyle.None);
				dateFormat = frme.DateFormat;
				timeFormat = frme.TimeFormat;
			}
		}

		private void SetDataEntryBorders(BorderStyle borderstyle)
		{
			pSessionKey.BorderStyle = borderstyle;
			pFormContainerType.BorderStyle = borderstyle;
			pFormDaypartType.BorderStyle = borderstyle;
			pFormDispositionType.BorderStyle = borderstyle;
			pFormEventOrderType.BorderStyle = borderstyle;
			pFormFoodType.BorderStyle = borderstyle;
			pFormHeader.BorderStyle = borderstyle;
			pFormLossType.BorderStyle = borderstyle;
			pFormPrePost.BorderStyle = borderstyle;
			pFormStationType.BorderStyle = borderstyle;
			pFormUserType.BorderStyle = borderstyle;
			pCurrContainerType.BorderStyle = borderstyle;
			pCurrDaypartType.BorderStyle = borderstyle;
			pCurrDispositionType.BorderStyle = borderstyle;
			pCurrEventOrderType.BorderStyle = borderstyle;
			pCurrFoodType.BorderStyle = borderstyle;
			pCurrLossType.BorderStyle = borderstyle;
			pCurrPrePost.BorderStyle = borderstyle;
			pCurrQuantity.BorderStyle = borderstyle;
			pCurrStationType.BorderStyle = borderstyle;
			pCurrTimestamp.BorderStyle = borderstyle;
			pCurrUserNote.BorderStyle = borderstyle;
			pCurrUserType.BorderStyle = borderstyle;
			pTransactionList.BorderStyle = borderstyle;
			pTransaction.BorderStyle = borderstyle;


		}

		private void bSetFormSetAsDefault_Click(object sender, EventArgs e)
		{
			cbi = (ComboBoxItem)cbDETemplates.SelectedItem;
			defaultTemplate = cbi.ID;
		}

	}
}
