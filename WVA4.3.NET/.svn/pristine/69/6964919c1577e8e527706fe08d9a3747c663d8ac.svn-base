using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors;

namespace UserControls
{
    public partial class UCMemTransBuilder : UserControl, IVWAUserControlBase
    {
		/// Class level elements
		VWA4Common.CommonEvents commonEvents = null;
		bool CloninginProcess;
		bool Initialized;
		TreeListColumn columnMBID;
        TreeListColumn columnMBName;
        TreeListColumn columnMBSpanishName;
        TreeListColumn columnMBMenuType;
		string sMBSpanishName;
		string sFoodTypeID;
		string sLossReasonID;
		string sContainerTypeID;
		string sStationTypeID;
		string sDispositionTypeID;
		string sDaypartTypeID;
		string sFoodTypeName;
		string sLossReasonName;
		string sContainerTypeName;
		string sStationTypeName;
		string sDispositionTypeName;
		string sDaypartTypeName;
		string sUserDefinedAnswer;
		string sPrePostConsumerFlag;
		string sCurrentTermName;
		string sCurrentTermID;
		string sCurrentSiteID;
		string sCurrentTypeCatalogID;
        enum AddMode
        {
            NoAddModeSelected = 0, InitialFocusing, EditingMTName, SelectingItemorWeight, SpecifyingUnitsInfo,
            SelectingRequiredTypes, SelectingOptionalTypes, EditingSavedNode
        };
        int addMode;
        enum NodeChanged
        {
            NotChanged = 0, Changed
        };
		bool currentNodeSaved;  // Tracks whether the current node selected is saved or in the process of being added
		
		int nodeChanged;
		List<string> list_weightdisplaynames = new List<string>();
		List<decimal> list_weightconversionfactors = new List<decimal>();
		List<int> list_prepostconsumer = new List<int>();

        private VWA4Common.TrackerDetector trackerDetector = null; // subscribe for db change
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change

        private DataSet dataSet = new DataSet();

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCMemTransBuilder()
        {
            InitializeComponent();
			ucTreeView1.EnableCheckboxes = false;
            ucTreeView1.ShowAllNames = false;
			CloninginProcess = false;
        }

		///		
		/// Interface methods for User Controls
		///		
		public void Init(DateTime firstDayOfWeek)
		{

			columnMBID = mtTreelist.Columns[1];
			columnMBName = mtTreelist.Columns[0];
			columnMBSpanishName = mtTreelist.Columns[2];
			columnMBMenuType = mtTreelist.Columns[3];
			// Load the Weight Units type combobox
			cbWeightUnitType.Items.Clear();
			cbWeightUnitType.Items.Add("Pound");
			list_weightdisplaynames.Add("lb");
			list_weightconversionfactors.Add((decimal)1.0);
			cbWeightUnitType.Items.Add("Kilogram");
			list_weightdisplaynames.Add("kg");
			list_weightconversionfactors.Add((decimal)2.2046226218);
			cbWeightUnitType.Items.Add("Gram");
			list_weightdisplaynames.Add("g");
			list_weightconversionfactors.Add((decimal)0.0022046226218);
			cbWeightUnitType.Items.Add("Milligram");
			list_weightdisplaynames.Add("mg");
			list_weightconversionfactors.Add((decimal)0.0000022046226218);
			cbWeightUnitType.Items.Add("Ounce");
			list_weightdisplaynames.Add("oz");
			list_weightconversionfactors.Add((decimal)0.0625);
			// Load the Pre/Post Consumer combobox
			cbPrePostConsumer.Items.Clear();
			cbPrePostConsumer.Items.Add("Pre Consumer Waste");
			list_prepostconsumer.Add(1);
			cbPrePostConsumer.Items.Add("Post Consumer Waste");
			list_prepostconsumer.Add(2);
			cbPrePostConsumer.Items.Add("Intermediate Waste");
			list_prepostconsumer.Add(0);
			// Init MT's
			clearMTinfo();
			// Initialize tree state
			Initialized = true; // need to execute the Tracker changed handler - initialize
			ucTrackercb.Init();  // Load up the Tracker selector combo box
			InitializeDataSet();
			//InitializeUI();
			//ultraTree1.SetDataBinding(this.dataSet, null);

			if (trackerDetector == null)
			{
				trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
				trackerDetector.TrackerConfigOutofSync += new VWA4Common.TrackerDetectorEventHandler(trackerDetector_TrackerConfigOutofSync);
			}
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

		public void LoadData()
        {
            if (VWA4Common.GlobalSettings.TrackerConfigOutofSync)
                ucTreeView1.Reload();
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


        /// <summary>
        /// Initialize the user control's data.
        /// New version using DevExpress tree control.
        /// </summary>
        public void InitializeDataSet()
        {
			Initialized = false;
			addMode = (int)AddMode.NoAddModeSelected;
            TreeListNode rmNode;
            TreeListNode rbNode;
            mtTreelist.ClearNodes();
			// Check to see if we have no MT's yet - ie is there a main menu?
			//  if not, add one and get rid of any other menus and buttons,
			//  which would be spurious.

			DataTable dtRootMenuNodes = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIMenus WHERE ParentMenuID=0"
				+ " AND TermID='" + ucTrackercb.TrackerID + "'"
						   + " ORDER BY Rank ASC, MenuName ASC"
						   );
			if (dtRootMenuNodes.Rows.Count == 0)
			{
				// if we don't have any menus, then there can't be any buttons - make sure
				VWA4Common.DB.Delete("DELETE FROM TrackerPaperUIButtons WHERE MenuID = 0"				
					+ " AND TermID='" + ucTrackercb.TrackerID + "'");
				// Create a Main Menu
				string sql = "INSERT INTO TrackerPaperUIMenus (TermID,ParentMenuID,MenuName,SpanishMenuName,Rank) "
					+ " VALUES('" + ucTrackercb.TrackerID + "',0,'(Main Menu)','(Main Menu)',0)";
			    int mmid = VWA4Common.DB.Insert(sql);
				TreeListNode mNode;
				mNode = mtTreelist.AppendNode(new object[] { "", 0, "", 1 }, 0);
                mNode.SetValue(columnMBID, mmid);
                mNode.SetValue(columnMBName, "(Main Menu)");
                mNode.SetValue(columnMBSpanishName, "");
				return;
			}
            // Add the root menu nodes and populate their children
            mtTreelist.BeginUnboundLoad();
            dtRootMenuNodes = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIMenus WHERE ParentMenuID=0"
                + " AND TermID='" + ucTrackercb.TrackerID + "'"
                           + " ORDER BY Rank ASC, MenuName ASC"
                           );
            foreach (DataRow row in dtRootMenuNodes.Rows)
            {
                rmNode = mtTreelist.AppendNode(new object[] { "", 0, "", 1 }, -1);
                //rmNode = mtTreelist.AppendNode(null, -1);
                //rmNode.ParentNode
                rmNode.SetValue(columnMBID, row["MenuID"]);
                rmNode.SetValue(columnMBName, row["MenuName"]);
                if (row["SpanishMenuName"].ToString() != "")
                    rmNode.SetValue(columnMBSpanishName, row["SpanishMenuName"]);
                else
                    rmNode.SetValue(columnMBSpanishName, row["MenuName"]);
                rmNode.SetValue(columnMBMenuType, 1);
                /// Populate children of each new node
                PopulateMenuNodeChildren(rmNode);
            }

            // Add the root button nodes
            DataTable dtRootButtonNodes = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIButtons WHERE MenuID=0"
                + " AND TermID='" + ucTrackercb.TrackerID + "'"
                + " ORDER BY Rank ASC, ButtonName ASC"
                           );
            foreach (DataRow row in dtRootButtonNodes.Rows)
            {
                //rbNode = mtTreelist.AppendNode(new object[] { "", 0, "", 0 }, -1);
                rbNode = mtTreelist.AppendNode(null, -1);
                rbNode.SetValue(columnMBID, row["ButtonID"]);
                rbNode.SetValue(columnMBName, row["ButtonName"]);
				if (row["SpanishButtonName"].ToString() != "")
                    rbNode.SetValue(columnMBSpanishName, row["SpanishButtonName"]);
                else
                    rbNode.SetValue(columnMBSpanishName, row["ButtonName"]);
                rbNode.SetValue(columnMBMenuType, 0);
            }
            mtTreelist.EndUnboundLoad();
            mtTreelist.ExpandAll();

            _AllowFocus = true;
			Initialized = true;
		}

        /// <summary>
        /// Populate the children of the supplied node in the Memorized Transaction menu/button hierarchy.
        /// Use the TrackerPaperUIMenus and TrackerPaperUIButtons tables.
        /// </summary>
        /// <param name="parentnode">Parent node (fully formed).</param>
        public void PopulateMenuNodeChildren(TreeListNode parentnode)
        {
            List<string> mrecname = new List<string>();
            List<string> mrecspanishname = new List<string>();
            List<int> mrecID = new List<int>();
            List<string> brecname = new List<string>();
            List<string> brecspanishname = new List<string>();
            List<int> brecID = new List<int>();
            TreeListNode mNode;
            TreeListNode bNode;
            // Not root node - the MenuID of the parent is in the node
            int pnodeMenuID = (int)parentnode.GetValue(columnMBID);
            string pnodeName = (string)parentnode.GetValue(columnMBName);
            string pnodeSpanishName = (string)parentnode.GetValue(columnMBSpanishName);
            //
            /// Process Menu Nodes 
            //
            // First, get children menus of the supplied Node, and 
            //
            // Iterate through the child menus of the supplied node
            // Save to local dynamic lists since ADO can't handle recursive
            //
            DataTable dtChildren = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIMenus WHERE ParentMenuID="
                + pnodeMenuID.ToString() + " ORDER BY Rank ASC, MenuName ASC"
                );
            int mcount = dtChildren.Rows.Count;
            foreach (DataRow row in dtChildren.Rows)
            {
                mrecID.Add((int)row["MenuID"]);
				mrecname.Add(row["MenuName"].ToString());
				if (row["SpanishMenuName"].ToString() != "")
					mrecspanishname.Add(row["SpanishMenuName"].ToString());
                else
					mrecspanishname.Add(row["MenuName"].ToString());                
            }
            // Now add the menus to the tree control
            //
            for (int i = 0; i < mcount; i++)
            {
                mNode = mtTreelist.AppendNode(new object[] { "", 0, "", 1 }, parentnode);
                mNode.SetValue(columnMBID, mrecID[i]);
                mNode.SetValue(columnMBName, mrecname[i]);
                mNode.SetValue(columnMBSpanishName, mrecspanishname[i]);
                /// Recurse using new node - each menu can have other menus or buttons
                PopulateMenuNodeChildren(mNode);
            }
            /// Process buttons
            dtChildren = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIButtons WHERE MenuID="
                + pnodeMenuID.ToString() + " ORDER BY Rank ASC, ButtonName ASC"
                );
            int bcount = dtChildren.Rows.Count;
            foreach (DataRow row in dtChildren.Rows)
            {
                brecID.Add((int)row["ButtonID"]);
				brecname.Add(row["ButtonName"].ToString());
                if (row["SpanishButtonName"].ToString() != "")
					brecspanishname.Add(row["SpanishButtonName"].ToString());
                else
					brecspanishname.Add(row["ButtonName"].ToString());
            }
            //
            // Now add the buttons to the tree control
            //
            for (int i = 0; i < bcount; i++)
            {
                bNode = mtTreelist.AppendNode(new object[] { "", 0, "", 0 }, parentnode);
                bNode.SetValue(columnMBID, brecID[i]);
                bNode.SetValue(columnMBName, brecname[i]);
                bNode.SetValue(columnMBSpanishName, brecspanishname[i]);
            }
        }


        /// <summary>
        /// Process change of selected node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtTreelist_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if ((e.Node != null) && (!CloninginProcess))
            {
            // Is it a menu or button selected now?
                if ((int)e.Node.GetValue(columnMBMenuType) == 1)
                { /// It's a menu
                    manageMTSelectState("menu");
					if (e.Node.Level <= 0)
					{ // Main Menu
						bDeleteMenu.Hide();
						mtTreelist.HideEditor();
					}
					else
					{ // not Main Menu
						bDeleteMenu.Show();
					}
					// Fill out the menu info
					LoadandFillMenuInfo((int)e.Node.GetValue(columnMBID));
                }
                else
                { /// It's a button
                    // If node is new, return now
					if (addMode <= (int)AddMode.EditingMTName) return;
					// Check to see if the current node is unfinished
					if ((int)mtTreelist.Selection[0].GetValue(columnMBID) == 0)
					{ // unfinished - may need to delete it
                        if (addMode > (int)AddMode.InitialFocusing)
                        { // We are past the first stage, so delete it
                            TreeListNode node = mtTreelist.Selection[0];
                            mtTreelist.DeleteNode(node);
                            mtTreelist.Update();
                        }
                        else 
                        {
                            // Set the MT Name & State
                            lMTName.Text = (string)e.Node.GetValue(columnMBName);
                            sMBSpanishName = (string)e.Node.GetValue(columnMBSpanishName);
                            
                            // Fill out the MT info
                            LoadandFillMTinfo((int)e.Node.GetValue(columnMBID));
                        }
                        

						// else - we tolerate the initial focus change
					}
                    else
                        LoadandFillMTinfo((int)e.Node.GetValue(columnMBID));
                           
                    manageMTSelectState("button");
					bAddButton.Hide();
                } 
            }
			bClearType.Hide();
        }


		private void mtTreelist_ShowingEditor(object sender, CancelEventArgs e)
		{
			if (mtTreelist.FocusedNode.Level <= 0)
			{
				e.Cancel = true;
			}
		}

		//private void mtTreelist_MouseClick(object sender, MouseEventArgs e)
		//{
		//    TreeListHitInfo hi = mtTreelist.CalcHitInfo(new Point(e.X, e.Y));
		//    TreeListNode node = hi.Node;
		//    if (node != null)
		//    {
		//        if (node.Level == 0)
		//        {
		//            mtTreelist.HideEditor();
		//        }
		//    }
		//}


		/// <summary>
		/// Change the cell appearance based on characteristics of the node, e.g. if it
		/// is a menu or a button type node.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mtTreelist_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
		{
			Brush foreBrush;
			if (e.Node.GetValue(columnMBMenuType) != null && (int)e.Node.GetValue(columnMBMenuType) == 1)
			{

				foreBrush = new SolidBrush(Color.Red);
				// painting node value
				e.Graphics.DrawString(e.CellText, e.Appearance.Font, foreBrush, e.Bounds,
				  e.Appearance.GetStringFormat());

				// prohibiting default painting
				e.Handled = true;
			}
			else e.Handled = false;
		}
        
        

		/// <summary>
		/// Fill out the UI info for the menu specified.
		/// </summary>
		/// <param name="MenuID"></param>
		private void LoadandFillMenuInfo(int MenuID)
		{
			clearMTinfo();
            DataTable dtMenuinfo = VWA4Common.DB.Retrieve(
                  "SELECT * FROM TrackerPaperUIMenus WHERE MenuID="
                + MenuID.ToString()
                );
			if (dtMenuinfo.Rows.Count == 1)
			{ // We found the row in the DB - fill the UI
				DataRow row = dtMenuinfo.Rows[0];
				if ((row["SpanishMenuName"].ToString() != ""))
					tbMTSpanishName.Text = row["SpanishMenuName"].ToString();
				else
					tbMTSpanishName.Text = row["MenuName"].ToString();
				lMTName.Text = row["MenuName"].ToString();
				sMBSpanishName = row["SpanishMenuName"].ToString();
			}
			nodeChanged = (int)NodeChanged.NotChanged;
			addMode = (int)AddMode.EditingSavedNode;
		}

        /// <summary>
        /// Fill out the memorized transaction info in the UI, based on the currently selected
        /// MT button.
        /// </summary>
        /// <param name="ButtonID"></param>
        private void LoadandFillMTinfo(int ButtonID)
        {
            clearMTinfo();
            // Get the info from the database
            DataTable dtMTinfo = VWA4Common.DB.Retrieve(
                  "SELECT * FROM TrackerPaperUIButtons WHERE ButtonID="
                + ButtonID.ToString()
                );
            if (dtMTinfo.Rows.Count == 1)
            { // We found the row in the DB - fill the UI
                /// MT Basic info
                DataRow row = dtMTinfo.Rows[0];
				lMTName.Text = row["ButtonName"].ToString();
				if (row["SpanishButtonName"].ToString() != "")
					tbMTSpanishName.Text = row["SpanishButtonName"].ToString();
                else
					tbMTSpanishName.Text = row["ButtonName"].ToString();
                //
				sMBSpanishName = tbMTSpanishName.Text;
				string lcstr = row["UnitTypeKey"].ToString();
                if (lcstr.ToLower() == "item")
                { /// Item type MT
                    // Basic stuff
                    bItem.Checked = true;
                    lWeightUnitType.Show();
                    lWeightUnits2.Show();
                    lWeightUnits2.Text = "Pound";
                    cbWeightUnitType.Hide();
                    lUnitTypeDisplayName2.Hide();
                    tUnitTypeDisplayName2.Show();
					tUnitTypeDisplayName2.Text = row["UnitTypeDisplayName"].ToString();
                    lUnitWeight.Show();
                    tUnitWeight.Show();
                    tUnitWeight.Text = ((decimal)row["UnitaryFoodWeight"]).ToString("####0.000");
					lUnitsTag.Show();
					lUnitsTag.Text = "lb";
                }
                else
                { /// Weight type MT
                    // Basic stuff
                    // cbWeightUnitType.Text = "(select units of weight)";
					bWeight.Checked = true;
                    lWeightUnitType.Show();
                    lWeightUnits2.Hide();
                    //lWeightUnits2.Text = "Pound";
                    cbWeightUnitType.Show();
					cbWeightUnitType.SelectedIndex = cbWeightUnitType.Items.IndexOf(row["UnitTypeKey"].ToString());
					//cbWeightUnitType.Text = row["UnitTypeKey"].ToString();
                    //int idx = list_weightdisplaynames.IndexOf(cbWeightUnitType.Text);
                    lUnitTypeDisplayName2.Show();
                    lUnitTypeDisplayName2.Text = list_weightdisplaynames[cbWeightUnitType.SelectedIndex];
                    tUnitTypeDisplayName2.Hide();
					//tUnitTypeDisplayName2.Text = row["UnitTypeDisplayName"].ToString();
                    lUnitWeight.Hide();
					tUnitWeight.Hide();
					tUnitWeight.Text = ((decimal)row["UnitaryFoodWeight"]).ToString("####0.000");
					lUnitsTag.Hide();
					lUnitsTag.Text = lUnitTypeDisplayName2.Text;
                }

                /// Types info
				lFoodType.Text = row["FoodTypeName"].ToString();
				sFoodTypeName = lFoodType.Text;
				sFoodTypeID = row["FoodTypeID"].ToString();
				lLossReason.Text = row["LossTypeName"].ToString();
				sLossReasonName = lLossReason.Text;
				sLossReasonID = row["LossTypeID"].ToString();
				lContainerType.Text = row["ContainerTypeName"].ToString();
				sContainerTypeName = lContainerType.Text;
				sContainerTypeID = row["ContainerTypeID"].ToString();

				if ((row["StationTypeName"].ToString()!= ""))
				{
					lStation.Text = row["StationTypeName"].ToString();
					sStationTypeName = lStation.Text;
					sStationTypeID = row["StationTypeID"].ToString();
                }
                else
                {
                    lStation.Text = "(not specified)";
					sStationTypeName = "";
                    sStationTypeID = "";
                }
				if ((row["DispositionTypeName"].ToString() != ""))
                {
					lDisposition.Text = row["DispositionTypeName"].ToString();
					sDispositionTypeName = lDisposition.Text;
					sDispositionTypeID = row["DispositionTypeID"].ToString();
                }
                else
                {
                    lDisposition.Text = "(not specified)";
					sDispositionTypeName = "";
                    sDispositionTypeID = "";
                }
				if ((row["DaypartTypeName"].ToString() != ""))
                {
                    lDaypart.Text = row["DaypartTypeName"].ToString();
					sDaypartTypeName = lDaypart.Text;
					sDaypartTypeID = row["DaypartTypeID"].ToString();
                }
                else
                {
                    lDaypart.Text = "(not specified)";
					sDaypartTypeName = "";
                    sDaypartTypeID = "";
                }
                switch ((int)row["PrePostConsumerFlag"])
                {
                    case 0:
                        { // Intermediate waste
							cbPrePostConsumer.SelectedIndex = 2;
							//cbPrePostConsumer.Text = "Intermediate Waste";
                            sPrePostConsumerFlag = "0";
                            break;
                        }
                    case 1:
                        { // Pre consumer waste
							cbPrePostConsumer.SelectedIndex = 0;
							//cbPrePostConsumer.Text = "Pre-consumer Waste";
                            sPrePostConsumerFlag = "1";
                            break;
                        }
                    case 2:
                        { // Post consumer waste
							cbPrePostConsumer.SelectedIndex = 1;
							cbPrePostConsumer.Text = "Post-consumer Waste";
                            sPrePostConsumerFlag = "2";
                            break;
                        }
                }
				//if ((row["UserDefinedQuestionButton"].ToString()!= ""))
				//{
				//    lUserDefinedAns.Text = row["UserDefinedQuestionButton"].ToString();
				//    sUserDefinedAnswer = lUserDefinedAns.Text;
				//}
				//else
				//{
				//    lUserDefinedAns.Text = "(not specified)";
				//    sUserDefinedAnswer = "";
				//}
			}
            else
            { // No row - must not be saved yet
            }
			/// Init to food type selection
			bFoodType.Checked = true;
			ucTreeView1.TypeName = "Food";
			ucTreeView1.LoadTree("Food");
			// Check for Food or Waste labels

			//if (int.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes").ToString())
			//    <= 99999)
				lTreeTitle.Text = "Food Types";
			//else
			//    lTreeTitle.Text = "Waste Types";
			// Undirty things
			//bSave.Hide();
			bSave.Enabled = true;
			bCancel.Hide();
			nodeChanged = (int)NodeChanged.NotChanged;
			addMode = (int)AddMode.EditingSavedNode;
			lMTName.Show();
		}

		
		/// <summary>
        /// Check the save state of the current MT.  If it is ready to save, then
        /// return true.
        /// </summary>
        /// <returns></returns>
        private bool checkMTReadytoSave()
        {
			if ((mtTreelist.FocusedNode != null) &&
				(int)mtTreelist.FocusedNode.GetValue(columnMBMenuType) == 1) return false;
            if (addMode == (int)AddMode.EditingMTName) return false;
            
            return checkRequiredFilledOut();
        }

		/// <summary>
		/// Check the state of the required MT parameters - are they adequately filled out?
		/// If so, return true.
		/// </summary>
		/// <returns></returns>
		private bool checkRequiredFilledOut()
		{
			if (sFoodTypeName == "") return false;
			if (sLossReasonName == "") return false;
			if (sContainerTypeName == "") return false;
			return true;
		}

        private void clearMTinfo()
        {
            lFoodType.Text = "";
			sFoodTypeName = "";
			sFoodTypeID = "";
            lLossReason.Text = "";
			sLossReasonName = "";
			sLossReasonID = "";
            lContainerType.Text = "";
			sContainerTypeName = "";
			sContainerTypeID = "";
            lStation.Text = "";
			sStationTypeName = "";
			sStationTypeID = "";
            lDisposition.Text = "";
			sDispositionTypeName = "";
			sDispositionTypeID = "";
            lDaypart.Text = "";
			sDaypartTypeName = "";
			sDaypartTypeID = "";
			cbPrePostConsumer.SelectedIndex = 0;
			//lUserDefinedAns.Text = "";
			sUserDefinedAnswer = "";
			lMTName.Hide();
        }

		/// <summary>
		/// Call this only when you know the node is either a menu, or a button that is already
		/// filled out, i.e. the addMode is not in an intermediate state.
		/// </summary>
		/// <param name="newstate"></param>
        private void manageMTSelectState(string newstate)
        {
            // Change state to the new state
            switch (newstate)
            {
                case "menu":
                    { // Menu is selected
                        lMTName.Text = "";
                        lUserSpecifies.Hide();
                        bItem.Hide();
                        bWeight.Hide();
						
						lWeightUnitType.Hide();
						lUnitTypeDisplayName2.Hide();
						cbWeightUnitType.Hide();
						tUnitTypeDisplayName2.Hide();
						tUnitWeight.Hide();
						lUnitsTag.Hide();

						lOptional.Hide();
						lRequired.Hide();

						lWeightUnits2.Hide();
						lUnitTypeDisplayName.Hide();
                        lUnitWeight.Hide();
                        bFoodType.Hide();
                        lFoodType.Hide();
                        bLossReason.Hide();
                        lLossReason.Hide();
                        bContainerType.Hide();
                        lContainerType.Hide();
                        bStation.Hide();
                        lStation.Hide();
                        bDisposition.Hide();
                        lDisposition.Hide();
                        bDaypart.Hide();
                        lDaypart.Hide();
                        lPrePostConsumer.Hide();

						cbPrePostConsumer.Hide();

						//bUserDefinedAns.Hide();
						//lUserDefinedAns.Hide();

						if (mtTreelist.Selection[0].Level == 0)
							tbMTSpanishName.Hide();
						else
							tbMTSpanishName.Show();
						lMTSpanishName.Visible = tbMTSpanishName.Visible;

                        bSave.Hide();
                        bCancel.Hide();
                        bAddButton.Show();
                        bAddMenu.Show();
						bCloneButton.Hide();
                        bDeleteButton.Hide();
                        bDeleteMenu.Show();
                        ucTreeView1.Hide();
						lTreeTitle.Hide();
                        return;
                    }
                case "button":
                    { // Button is selected
						if (addMode == (int)AddMode.InitialFocusing)
						{ // Building a new transaction
							lMTName.Text = mtTreelist.Selection[0].GetValue(columnMBName).ToString();
							sMBSpanishName = mtTreelist.Selection[0].GetValue(columnMBSpanishName).ToString();
							lUserSpecifies.Hide();
							bItem.Hide();
							bWeight.Hide();
							bItem.Checked = false;
							bWeight.Checked = false;
							//
							lWeightUnitType.Hide();
							lUnitTypeDisplayName2.Hide();
							cbWeightUnitType.Hide();
							tUnitTypeDisplayName2.Hide();
							tUnitWeight.Hide();
							lUnitsTag.Hide();
							//
							lOptional.Hide();
							lRequired.Hide();
							//
							lWeightUnits2.Hide();
							lUnitTypeDisplayName.Hide();
							lUnitWeight.Hide();
							bFoodType.Hide();
							lFoodType.Hide();
							bLossReason.Hide();
							lLossReason.Hide();
							bContainerType.Hide();
							lContainerType.Hide();
							bStation.Hide();
							lStation.Hide();
							bDisposition.Hide();
							lDisposition.Hide();
							bDaypart.Hide();
							lDaypart.Hide();
							lPrePostConsumer.Hide();

							cbPrePostConsumer.Hide();
							return;
						}
		
						//lMTName.Text = "";
						//sMBSpanishName = "";
                        lUserSpecifies.Show();
                        bItem.Show();
                        bWeight.Show();

						// I think these are handled elsewhere when data is loaded
						//lWeightUnits2.Hide();
						//lWeightUnitType.Hide();
						//lUnitTypeDisplayName2.Hide();
						//cbWeightUnitType.Hide();
						//tUnitTypeDisplayName2.Hide();
						//tUnitWeight.Hide();
						//lUnitsTag.Hide();

						lUnitTypeDisplayName.Show();
                        lUnitWeight.Show();
						lRequired.Show();
						bFoodType.Show();
                        lFoodType.Show();
                        bLossReason.Show();
                        lLossReason.Show();
                        bContainerType.Show();
                        lContainerType.Show();
						lOptional.Show();
						bStation.Show();
                        lStation.Show();
                        bDisposition.Show();
                        lDisposition.Show();
                        bDaypart.Show();
                        lDaypart.Show();
                        lPrePostConsumer.Show();

						cbPrePostConsumer.Show();

						//bUserDefinedAns.Show();
						//lUserDefinedAns.Show();
                        lMTSpanishName.Show();
                        tbMTSpanishName.Show();

                        //bSave.Show();
                        //bCancel.Show();
                        bAddButton.Hide();
						if (!CloninginProcess) bCloneButton.Show();
						else bCloneButton.Hide();
                        bAddMenu.Hide();
                        bDeleteButton.Show();
                        bDeleteMenu.Hide();
						ucTreeView1.Show();
						lTreeTitle.Show();
                        break;
                    }
            }
        }

        
        private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
        {
            //todo: check tree type and init correct label
            switch (ucTreeView1.TypeName)
            {
                case "Food":
					sFoodTypeName = e.Name;
					sFoodTypeID = e.ID;
					lFoodType.Text = e.Name;
					break;
                case "Loss":
					sLossReasonName = e.Name;
					sLossReasonID = e.ID;
					lLossReason.Text = e.Name;
					break;
                case "Container":
					sContainerTypeName = e.Name;
					sContainerTypeID = e.ID;
					lContainerType.Text = e.Name;
					break;
                case "Station":
					sStationTypeName = e.Name;
					sStationTypeID = e.ID;
					lStation.Text = e.Name;
					break;
                case "Disposition":
					sDispositionTypeName = e.Name;
					sDispositionTypeID = e.ID;
					lDisposition.Text = e.Name;
					break;
                case "Daypart":
					sDaypartTypeName = e.Name;
					sDaypartTypeID = e.ID;
					lDaypart.Text = e.Name;
					break;
            }
			if (checkMTReadytoSave()) { bSave.Show(); bSave.Enabled = true; bCancel.Show(); 
				changeAddMode((int)AddMode.SelectingOptionalTypes); }
		}

		/// <summary>
		/// Process changing of a Tracker - need to reload MT's.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucTrackercb_TrackerChanged(object sender, UCTrackerPicker.TrackerEventArgs e)
		{
			if (Initialized)
			{
				sCurrentTermName = e.TermName;
				sCurrentTermID = e.TermID;
				sCurrentSiteID = e.SiteID;
				DataTable dtSites = VWA4Common.DB.Retrieve("SELECT TypeCatalogID from Sites WHERE ID = "
					+ sCurrentSiteID.ToString());
				// todo: add error check if SiteID is not found here
				DataRow row = dtSites.Rows[0];
				sCurrentTypeCatalogID = ((int)row["TypeCatalogID"]).ToString();
				InitializeDataSet();
			}
		}

        /// <summary>
        /// Add a menu.
        /// Assumptions: Current selected node is a menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddMenu_Click(object sender, EventArgs e)
        {
            // Add a menu under the currently selected menu
            //
            // Add the database record
            TreeListNode currentnode = mtTreelist.Selection[0];
            int parentmenuID = (int)currentnode.GetValue(columnMBID); // MenuID of current node
            string sql = "INSERT INTO TrackerPaperUIMenus (TermID,ParentMenuID,MenuName)"
                + "VALUES(" + ucTrackercb.TrackerID + "," + parentmenuID.ToString() + ",'NewMenuName')";
            int newmenuID = VWA4Common.DB.Insert(sql);
            // Insert a new child node into the treelist control
            TreeListNode newnode = mtTreelist.AppendNode(null,mtTreelist.Selection[0]);
            newnode.SetValue(columnMBID, newmenuID);
            newnode.SetValue(columnMBName, "NewMenuName");
            newnode.SetValue(columnMBSpanishName, "");
            newnode.SetValue(columnMBMenuType, 1);
            mtTreelist.SetFocusedNode(newnode);
            mtTreelist.ShowEditor();
			addMode = (int)AddMode.NoAddModeSelected;
		}

        /// <summary>
        /// Delete a menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDeleteMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this Menu?", "Delete Menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Delete the currently selected menu
                TreeListNode currentnode = mtTreelist.Selection[0];
                // Promote any child menus/buttons
                PromoteChildren(currentnode);
                // Delete the database record
                int menuID = (int)currentnode.GetValue(columnMBID); // MenuID of current node
                currentnode = currentnode.ParentNode;
                int newmenuID = (int)currentnode.GetValue(columnMBID); // MenuID of the parent node
                string sql = "DELETE FROM TrackerPaperUIMenus WHERE MenuID=" + menuID.ToString();
                VWA4Common.DB.Delete(sql);
                // Reinitialize the tree's data set
                InitializeDataSet();
                // Set the current node to the new parent
                currentnode = mtTreelist.FindNodeByFieldValue("mbID", newmenuID);
                if (currentnode != null)
                    mtTreelist.SetFocusedNode(currentnode);
            }
        }

        /// <summary>
        /// Promote child menus and buttons.
        /// </summary>
        /// <param name="currentparentmenunode"></param>
        private void PromoteChildren(TreeListNode currentparentmenunode)
        {
            TreeListNode newparentmenunode = currentparentmenunode.ParentNode;            
            int currentparentmenuID = (int)currentparentmenunode.GetValue(columnMBID); // MenuID of current parent node
            int newparentmenuID = (int)newparentmenunode.GetValue(columnMBID); // MenuID of new parent node
            // Update the Menus 
            string sql = "UPDATE TrackerPaperUIMenus SET ParentMenuID=" + newparentmenuID.ToString()
                + " WHERE ParentMenuID=" + currentparentmenuID.ToString();
            VWA4Common.DB.Update(sql);
            // Update the Buttons
            sql = "UPDATE TrackerPaperUIButtons SET MenuID=" + newparentmenuID.ToString()
                + " WHERE MenuID=" + currentparentmenuID.ToString();
            VWA4Common.DB.Update(sql);
        }

		private bool _AllowFocus = true;
        /// <summary>
        /// Add a button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddButton_Click(object sender, EventArgs e)
        {
            // Add a button under the currently selected menu
            //
			//// Add the database record
			//TreeListNode currentnode = mtTreelist.Selection[0];
			//int parentmenuID = (int)currentnode.GetValue(columnMBID); // MenuID of current node
			//string sql = "INSERT INTO TrackerPaperUIButtons (TermID,MenuID,ButtonName)"
			//    + "VALUES(" + ucTrackercb.TrackerID + "," + parentmenuID.ToString() + ",\"NewButtonName\")";
			//int newbuttonID = VWA4Common.DB.Insert(sql);
			clearMTinfo();
			changeAddMode((int)AddMode.InitialFocusing);
			manageMTSelectState("button");
            // Insert a new child node into the treelist control
            TreeListNode newnode = mtTreelist.AppendNode(null, mtTreelist.Selection[0]);
            newnode.SetValue(columnMBID, 0);
            newnode.SetValue(columnMBName, "NewButtonName");
            newnode.SetValue(columnMBSpanishName, "");
            newnode.SetValue(columnMBMenuType, 0);
            mtTreelist.SetFocusedNode(newnode);
            mtTreelist.ShowEditor();
			changeAddMode((int)AddMode.EditingMTName); // after focusednode event
			bCancel.Show();
			bSave.Show();
			bSave.Enabled = false;

			_AllowFocus = false;
		}

		/// <summary>
		/// Clone a button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bCloneButton_Click(object sender, EventArgs e)
		{
			CloninginProcess = true;
			// Insert a new child node into the treelist control
			TreeListNode newnode = mtTreelist.AppendNode(null, mtTreelist.Selection[0].ParentNode);
			newnode.SetValue(columnMBID, 0);
			string save_mtname = lMTName.Text + "_Clone";
			sMBSpanishName += "_Clone";
			tbMTSpanishName.Text = sMBSpanishName;
			newnode.SetValue(columnMBName, save_mtname);
			newnode.SetValue(columnMBSpanishName, sMBSpanishName);
			newnode.SetValue(columnMBMenuType, 0);
			mtTreelist.SetFocusedNode(newnode);
			mtTreelist.ShowEditor();
			changeAddMode((int)AddMode.EditingMTName);
			manageMTSelectState("button");
			bCancel.Show();
			bSave.Show();
			bSave.Enabled = true;
			lMTName.Text = save_mtname;
			CloninginProcess = false;

		}


        /// <summary>
        /// Delete a button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this Button?", "Delete Button", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Delete the currently selected button
                TreeListNode currentnode = mtTreelist.Selection[0];
                TreeListNode parentnode = currentnode.ParentNode;
                // Delete the database record
                int buttonID = (int)currentnode.GetValue(columnMBID); // ButtonID of current node
                int menuID = (int)parentnode.GetValue(columnMBID); // MenuID of parent node
                string sql = "DELETE FROM TrackerPaperUIButtons WHERE ButtonID=" + buttonID.ToString();
                VWA4Common.DB.Delete(sql);
                // Reinitialize the tree's data set
                InitializeDataSet();
                // Set the current node to the new parent
                // todo: handle case where a button and menu have the same ID (not a big deal)
                currentnode = mtTreelist.FindNodeByFieldValue("mbID", menuID);
                if (currentnode != null)
                    mtTreelist.SetFocusedNode(currentnode);
            }
        }


        /// <summary>
        /// Handle the Changing of the Spanish name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMTSpanishName_EditValueChanged(object sender, EventArgs e)
        {
			if ((int)mtTreelist.Selection[0].GetValue(columnMBMenuType) == 1)
			{ // it's a menu so save to the database right away
				string sql = "UPDATE TrackerPaperUIMenus SET SpanishMenuName='"
					+ tbMTSpanishName.Text + "' WHERE MenuID="
					+ mtTreelist.Selection[0].GetValue(columnMBID);
				VWA4Common.DB.Update(sql);
			}
			else
			{ // it's a button so we just dirty the node state and show the buttons
				nodeChanged = (int)NodeChanged.Changed;  // dirty the node state
				if (checkMTReadytoSave())
				{ // Ready to save
					bCancel.Show();
					bSave.Show();
					bSave.Enabled = true;
				}
			}
        }

        //                                                   
        ///
        /// Mode switch event handlers.
        ///
        //                                                   
        private void bItem_Clicked(object sender, EventArgs e)
        {
            // Change mode to Item
            // Was weight before
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node state
  
            // Initialize controls

			selectItemorWeightMode("item");
			
			// if we're partway through an add,  advance it
			if (addMode == (int)AddMode.SelectingItemorWeight)
            {
                // Next step in an add
				addMode = (int)AddMode.SpecifyingUnitsInfo;
            }
			if (checkMTReadytoSave())
			{
				bSave.Show(); bCancel.Show(); bSave.Enabled = true;
			};
        }

        private void bWeight_Clicked(object sender, EventArgs e)
        {
            // Change mode to Weight
            // was Item before
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node state

			// Initialize controls

			selectItemorWeightMode("weight");
			
			if (addMode == (int)AddMode.SelectingItemorWeight)
			{
				// Next step in an add
				addMode = (int)AddMode.SpecifyingUnitsInfo;
			}
			if (checkMTReadytoSave())
			{
				bSave.Show(); bCancel.Show(); bSave.Enabled = true;
			};
        }


		private void bItem_CheckedChanged(object sender, EventArgs e)
		{
			if (((CheckButton)sender).Checked)
			{
				((CheckButton)sender).ForeColor = Color.Black;
			}
			else
			{
				((CheckButton)sender).ForeColor = Color.Gray;
			}
		}

		private void cbWeightUnitType_SelectedIndexChanged(object sender, EventArgs e)
		{
			//int idx = list_weightdisplaynames.IndexOf(cbWeightUnitType.Text);
			if (cbWeightUnitType.SelectedIndex >= 0)
			{
				lUnitTypeDisplayName2.Text = list_weightdisplaynames[cbWeightUnitType.SelectedIndex];
				tUnitTypeDisplayName2.Text = lUnitTypeDisplayName2.Text;
				lWeightUnits2.Text = cbWeightUnitType.Text;  // may use the label for saving?
				tUnitWeight.Text = list_weightconversionfactors[cbWeightUnitType.SelectedIndex].ToString();
			}
			if (addMode == (int)AddMode.SpecifyingUnitsInfo)
			{ // We are in the add process - move things forward
				changeAddMode((int)AddMode.SelectingRequiredTypes);
			}
			else
				if (checkMTReadytoSave())
				{ // Ready to save
					bCancel.Show();
					bSave.Show();
					bSave.Enabled = true;
				}
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node state
		}


		private void cbPrePostConsumer_SelectedIndexChanged(object sender, EventArgs e)
		{
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node state
			if (checkMTReadytoSave())
			{ // Ready to save
				bCancel.Show();
				bSave.Show();
				bSave.Enabled = true;
			}
		}


        /// <summary>
        /// Handle the edit of a menu or button name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtTreelist_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            // A Name has been changed
            // Is it a menu or button selected now?
            if ((int)e.Node.GetValue(columnMBMenuType) == 1)
            { // It's a menu
                // change Spanish name
				tbMTSpanishName.Text = (string)e.Node.GetValue(columnMBName);

				int menuID = (int)e.Node.GetValue(columnMBID); // MenuID of current node
				string sql = "UPDATE TrackerPaperUIMenus SET MenuName='" + e.Value.ToString() + "',"
					+ " SpanishMenuName='" + tbMTSpanishName.Text + "'"
					+ " WHERE MenuID=" + menuID.ToString();
					VWA4Common.DB.Update(sql);
			}
            else
            { // It's a button
                lMTName.Text = (string)e.Value;
                // What we do depends on the addMode
				if (addMode == (int)AddMode.EditingMTName)
                {
                    // go to the next step
                    lMTName.Show();
                    lUserSpecifies.Show();
                    bItem.Show();
                    bWeight.Show();
                    bItem.Checked = true;
					changeAddMode((int)AddMode.SelectingItemorWeight);
					//addMode = (int)AddMode.SelectingItemorWeight;
                }
				// change Spanish name
				tbMTSpanishName.Text = (string)e.Node.GetValue(columnMBName);
				int buttonID = (int)e.Node.GetValue(columnMBID); // ButtonID of current node
				string sql = "UPDATE TrackerPaperUIButtons SET ButtonName='" + e.Value.ToString() + "',"
					+ " SpanishButtonName='" + tbMTSpanishName.Text + "'"
					+ " WHERE ButtonID=" + buttonID.ToString();
				VWA4Common.DB.Update(sql);
			}
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node state
        }

		/// <summary>
		/// Handle a change of a MT text field.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tUnitWeight_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
		{
			if (addMode == (int)AddMode.SpecifyingUnitsInfo)
			{ // We are in the add process - move things forward
				changeAddMode((int)AddMode.SelectingRequiredTypes);
			}
			else
				if (checkMTReadytoSave())
				{ // Ready to save
					bCancel.Show();
					bSave.Show();
					bSave.Enabled = true;
				}
			nodeChanged = (int)NodeChanged.Changed;
		}

		private void changeAddMode(int newaddmode)
		{ 
			switch (newaddmode)
			{
				case (int)AddMode.InitialFocusing:
					{
						bAddButton.Hide();
						bAddMenu.Hide();
						bCloneButton.Hide();
						bDeleteButton.Hide();
						bDeleteMenu.Hide();
						break;
					}
				case (int)AddMode.EditingMTName:
					{
						bAddButton.Hide();
						bAddMenu.Hide();
						bCloneButton.Hide();
						bDeleteButton.Hide();
						bDeleteMenu.Hide();
						break;
					}

				case (int)AddMode.SelectingRequiredTypes:
					{
						bAddButton.Hide();
						bCloneButton.Hide();
						bAddMenu.Hide();
						bDeleteButton.Hide();
						bDeleteMenu.Hide();
						lUserSpecifies.Show();
						bItem.Show();
						bWeight.Show();
						lUnitTypeDisplayName.Show();
						lUnitWeight.Show();
						lRequired.Show();
						bFoodType.Show();
						lFoodType.Show();
						bLossReason.Show();
						lLossReason.Show();
						bContainerType.Show();
						lContainerType.Show();
						cbPrePostConsumer.SelectedIndex = 0;
						lPrePostConsumer.Show();
						cbPrePostConsumer.Show();
						lMTSpanishName.Show();
						tbMTSpanishName.Show();
						ucTreeView1.TypeName = "Food";
						ucTreeView1.LoadTree("Food");
						lTreeTitle.Text = "Food Types";
						ucTreeView1.Show();

						break;
					}
				case (int)AddMode.SelectingOptionalTypes:
					{
						bAddButton.Hide();
						bCloneButton.Hide();
						bAddMenu.Hide();
						bDeleteButton.Hide();
						bDeleteMenu.Hide();
						lUserSpecifies.Show();
						bItem.Show();
						bWeight.Show();
						lWeightUnitType.Show();
						lUnitTypeDisplayName.Show();
						//if (bItem.Checked)
						//{ // Item Mode
						//    selectItemorWeightMode("item");
						//}
						//else
						//{ // Weight mode
						//    selectItemorWeightMode("weight");
						//}
						lRequired.Show();
						bFoodType.Show();
						lFoodType.Show();
						bLossReason.Show();
						lLossReason.Show();
						bContainerType.Show();
						lContainerType.Show();
						lOptional.Show();
						bStation.Show();
						lStation.Show();
						bDisposition.Show();
						lDisposition.Show();
						bDaypart.Show();
						lDaypart.Show();
						lPrePostConsumer.Show();
						cbPrePostConsumer.Show();
						lMTSpanishName.Show();
						tbMTSpanishName.Show();
						ucTreeView1.TypeName = "Station";
						ucTreeView1.LoadTree("Station");
						lTreeTitle.Text = "Stations";
						bStation.Checked = true;
						break;
					}
				case (int)AddMode.EditingSavedNode:
					{
						//bSave.Visible = false;
						bSave.Enabled = false;
						bCancel.Visible = false;
						break;
					}
			}
			addMode = newaddmode;
		}

		private void selectItemorWeightMode(string mode)
		{
			// invariant
			lWeightUnitType.Show();
			lUnitTypeDisplayName.Show();
			// mode-dependent
			if (mode.ToLower() == "item")
			{ // Item mode
				lWeightUnits2.Text = "Pound";
				tUnitTypeDisplayName2.Text = "Items";
				tUnitWeight.Text = "1.0";
				lUnitsTag.Text = "lb";
				cbWeightUnitType.Hide();
				lWeightUnits2.Show();
				lUnitWeight.Show();
				tUnitWeight.Show();
				lUnitsTag.Show();
				lUnitTypeDisplayName2.Hide();
				tUnitTypeDisplayName2.Show();
			}
			else
			{ // Weight Mode
				cbWeightUnitType.SelectedIndex = 0;
				cbWeightUnitType.Show();
				lUnitTypeDisplayName2.Text = list_weightdisplaynames[0];
				tUnitTypeDisplayName2.Text = lUnitTypeDisplayName2.Text;
				lWeightUnits2.Hide();
				lUnitWeight.Hide();
				tUnitWeight.Hide();
				lUnitsTag.Hide();
				lUnitTypeDisplayName2.Show();
				tUnitTypeDisplayName2.Hide();
			}

		}

        //todo: make the same for all buttons
        private void bFoodType_Click(object sender, EventArgs e)
        {
			//ucTreeView1.TypeName = "Food";
			ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
						"Food", "0");
			//ucTreeView1.LoadTree("Food");
			ucTreeView1.Refresh();
			lTreeTitle.Text = "Food Types";
			bClearType.Hide();
		}
        private void bLossReason_Click(object sender, EventArgs e)
        {
            ucTreeView1.TypeName = "Loss";
			ucTreeView1.LoadTree("Loss");
			lTreeTitle.Text = "Loss Reasons";
			bClearType.Hide();
		}

        private void bContainerType_Click(object sender, EventArgs e)
        {
            ucTreeView1.TypeName = "Container";
			ucTreeView1.LoadTree("Container");
			lTreeTitle.Text = "Container Types";
			bClearType.Hide();
		}

        private void bStation_Click(object sender, EventArgs e)
        {
            ucTreeView1.TypeName = "Station";
			ucTreeView1.LoadTree("Station");
			lTreeTitle.Text = "Stations";
			bClearType.Show();
		}

        private void bDisposition_Click(object sender, EventArgs e)
        {
            ucTreeView1.TypeName = "Disposition";
			ucTreeView1.LoadTree("Disposition");
			lTreeTitle.Text = "Dispositions";
			bClearType.Show();
		}


        private void bDaypart_Click(object sender, EventArgs e)
        {
            ucTreeView1.TypeName = "Daypart";
			ucTreeView1.LoadTree("Daypart");
			lTreeTitle.Text = "Dayparts";
			bClearType.Show();
		}

		private void bClearType_Click(object sender, EventArgs e)
		{
			switch (ucTreeView1.TypeName)
			{
				case "Station":
					{
						lStation.Text = "(not specified)";
						sStationTypeID = "";
						sStationTypeName = "";
						bClearType.Hide();
						break;
					}
				case "Disposition":
					{
						lDisposition.Text = "(not specified)";
						sDispositionTypeID = "";
						sDispositionTypeName = "";
						bClearType.Hide();
						break;
					}
				case "Daypart":
					{
						lDaypart.Text = "(not specified)";
						sDaypartTypeID = "";
						sDaypartTypeName = "";
						bClearType.Hide();
						break;
					}
			}
		}


		private void bUserDefinedAns_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// A type's setting has changed.  Handle both the case of adding and modifying.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TypeName_TextChanged(object sender, EventArgs e)
		{
			if (addMode == (int)AddMode.SelectingRequiredTypes)
			{
				if (checkRequiredFilledOut())
				{
					// go to next add step
					changeAddMode((int)AddMode.SelectingOptionalTypes);
				}
			}
			nodeChanged = (int)NodeChanged.Changed;  // dirty the node
			if (checkMTReadytoSave())
			{
				bCancel.Show();
				bSave.Show();
				bSave.Enabled = true;
			}
			if ((ucTreeView1.TypeName == "Station") ||
				(ucTreeView1.TypeName == "Disposition") ||
				(ucTreeView1.TypeName == "Daypart"))
				bClearType.Show();
			else
				bClearType.Hide();

		}

		/// <summary>
		/// Save the current MT.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
		{
			// Assume things are ready to save to the database
			// Add the database record
			TreeListNode currentnode = mtTreelist.Selection[0];
			int parentmenuID = (int)(currentnode.ParentNode).GetValue(columnMBID); // MenuID of current node
			int prepostindex = cbPrePostConsumer.Items.IndexOf(cbPrePostConsumer.Text);
			string sprepostID = list_prepostconsumer[prepostindex].ToString();
			string sunittypekey;
			if (bItem.Checked)
			{ // UItem mode
				sunittypekey = "Item";
			}
			else
			{ // Weight mode
				sunittypekey = cbWeightUnitType.Text;
			}
			DataTable dtFoodType;
			DataTable dtContainerType;
			if (sCurrentTypeCatalogID == "0")
			{ // Master Type Catalog
				dtFoodType = VWA4Common.DB.Retrieve("SELECT Cost as FoodTypeCost FROM FoodType WHERE TypeID='" 
				+ sFoodTypeID + "'");
				dtContainerType = VWA4Common.DB.Retrieve("Select Cost as ContainerTypeCost, TareWeight as ContainerWeight "
				+ "FROM ContainerType WHERE TypeID='" 
				+ sContainerTypeID + "'");
			}
			else
			{ // SubType Catalog
				dtFoodType = VWA4Common.DB.Retrieve("SELECT FoodCost as FoodTypeCost FROM FoodSubTypes WHERE TypeID='" 
				+ sFoodTypeID + "'");
				dtContainerType = VWA4Common.DB.Retrieve("Select ContainerCost as ContainerTypeCost, ContainerTareWeight as ContainerWeight "
				+ "FROM ContainerSubTypes WHERE TypeID='" 
				+ sContainerTypeID + "'");
			}
            if (dtFoodType.Rows.Count > 0 && dtContainerType.Rows.Count > 0)
            {
                DataRow drf = dtFoodType.Rows[0];
                DataRow drc = dtContainerType.Rows[0];

                // Check to make sure the net weight is positive
                if ((decimal)drc["ContainerWeight"] >= decimal.Parse(tUnitWeight.Text) && (bItem.Checked))
                {
                    // Net weight of this transaction would be zero or negative - not allowed
                    MessageBox.Show("Net Weight of this transaction is negative or zero!\nEither increase the gross weight or select a lighter container.");
                    return;
                }



                ///
                /// Do we Save a new record or update the existing record?
                ///
                if (addMode == (int)AddMode.EditingSavedNode)
                { // We are updating, not adding
                    string sql = "UPDATE TrackerPaperUIButtons SET "
                        + " SpanishButtonName='" + tbMTSpanishName.Text + "',"
                        + " UnitTypeKey='" + sunittypekey + "',"
                        + " UnitTypeDisplayName='" + tUnitTypeDisplayName2.Text + "',"
                        + " UnitaryFoodWeight=" + tUnitWeight.Text + ","
                        + " PrePostConsumerFlag=" + sprepostID + ","
                        + " FoodTypeName='" + sFoodTypeName.Replace("'", "''") + "',"
                        + " FoodTypeID='" + sFoodTypeID + "',"
                        + " FoodTypeCost=" + ((decimal)drf["FoodTypeCost"]).ToString("####0.000") + ","
                        + " LossTypeName='" + sLossReasonName + "',"
                        + " LossTypeID='" + sLossReasonID + "',"
                        + " ContainerTypeName='" + sContainerTypeName + "',"
                        + " ContainerTypeID='" + sContainerTypeID + "',"
                        + " ContainerWeight=" + ((decimal)drc["ContainerWeight"]).ToString("####0.000") + ","
                        + " ContainerCost=" + ((decimal)drc["ContainerTypeCost"]).ToString("####0.000") + ","
                        + " StationTypeName='" + sStationTypeName + "',"
                        + " StationTypeID='" + sStationTypeID + "',"
                        + " DispositionTypeName='" + sDispositionTypeName + "',"
                        + " DispositionTypeID='" + sDispositionTypeID + "',"
                        + " DaypartTypeName='" + sDaypartTypeName + "',"
                        + " DaypartTypeID='" + sDaypartTypeID + "',"
                        + " UserDefinedQuestionButton='" + sUserDefinedAnswer + "'"
                        + " WHERE ButtonID=" + ((int)currentnode.GetValue(columnMBID)).ToString();
                    ;
                    VWA4Common.DB.Update(sql);
                    nodeChanged = (int)NodeChanged.NotChanged;
                    bSave.Hide();
                    bCancel.Hide();
                }
                else
                { // We are adding, so insert a new record

                    string sql = "INSERT INTO TrackerPaperUIButtons (TermID,MenuID,ButtonName,"
                        + "SpanishButtonName,UnitTypeKey,UnitTypeDisplayName,UnitaryFoodWeight,"
                        + "PrePostConsumerFlag,FoodTypeName,FoodTypeID,FoodTypeCost,LossTypeName,LossTypeID,"
                        + "ContainerTypeName,ContainerTypeID,ContainerWeight,ContainerCost,"
                        + "StationTypeName,StationTypeID,DispositionTypeName,DispositionTypeID,"
                        + "DaypartTypeName,DaypartTypeID,UserDefinedQuestionButton)"
                        + " VALUES('"
                        + ucTrackercb.TrackerID							// TermID
                        + "'," + parentmenuID.ToString()				// MenuID
                        + ",'" + currentnode.GetValue(columnMBName) + "'"		// ButtonName
                        + ",'" + tbMTSpanishName.Text + "'"					// SpanishButtonName
                        + ",'" + sunittypekey + "'"						// UnitTypeKey
                        + ",'" + tUnitTypeDisplayName2.Text + "'"				// UnitTypeDisplayName
                        + "," + tUnitWeight.Text								// UnitaryFoodWeight
                        + "," + sprepostID			// PrePostConsumerFlag
                        + ",'" + sFoodTypeName + "'"
                        + ",'" + sFoodTypeID + "'," + ((decimal)drf["FoodTypeCost"]).ToString("####0.000")
                        + ",'" + sLossReasonName + "','" + sLossReasonID + "'"
                        + ",'" + sContainerTypeName + "','" + sContainerTypeID + "',"
                        + ((decimal)drc["ContainerWeight"]).ToString("####0.000")
                        + "," + ((decimal)drc["ContainerTypeCost"]).ToString("####0.000")
                        + ",'" + sStationTypeName + "','" + sStationTypeID + "'"
                        + ",'" + sDispositionTypeName + "','" + sDispositionTypeID + "'"
                        + ",'" + sDaypartTypeName + "','" + sDaypartTypeID + "'"
                        + ",'" + sUserDefinedAnswer + "'"
                        + ")"
                        ;
                    //sql = sql.Replace("\'", "\'\'");
                    int newbuttonID = VWA4Common.DB.Insert(sql);
                    currentnode.SetValue(columnMBID, newbuttonID);
                    nodeChanged = (int)NodeChanged.NotChanged;
                    changeAddMode((int)AddMode.EditingSavedNode);

                }
            }
			mtTreelist.SetFocusedNode(mtTreelist.Nodes.FirstNode);
			VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
			_AllowFocus = true;
		}

		/// <summary>
		/// Cancel the current MT.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bCancel_Click(object sender, EventArgs e)
		{
			// Just go back to null state
			InitializeDataSet();
			_AllowFocus = true;
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			CloseTaskSheet();
		}

		private void CloseTaskSheet()
		{
			InitializeDataSet();

			_AllowFocus = true;
			commonEvents.TaskSheetKey = "dashboard";
		}
		void trackerDetector_TrackerConfigOutofSync(object sender, EventArgs e)
        {
            ucTreeView1.Reload();
		}

		private void mtTreelist_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
		{
			e.CanFocus = _AllowFocus;
		}
        private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && this.IsActive && !e.IsLogin)// || !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Recurring Transactions")))
				CloseTaskSheet();
		}

        private void mtTreelist_DragDrop(object sender, DragEventArgs e)
        {
            return;
        }

        private void mtTreelist_Leave(object sender, EventArgs e)
        {
            TreeListNode focusedNode = mtTreelist.FocusedNode;
            if (!bAddButton.Visible)// we are adding a button
            { // It's a button
                lMTName.Text = mtTreelist.FocusedNode.GetValue(columnMBName).ToString();
                // What we do depends on the addMode
                if (addMode == (int)AddMode.EditingMTName)
                {
                    // go to the next step
                    lMTName.Show();
                    lUserSpecifies.Show();
                    bItem.Show();
                    bWeight.Show();
                    bItem.Checked = true;
                    addMode = (int)AddMode.SelectingItemorWeight;
                }
                // change Spanish name
                tbMTSpanishName.Text = (string)focusedNode.GetValue(columnMBName);
                int buttonID = (int)focusedNode.GetValue(columnMBID); // ButtonID of current node
                string sql = "UPDATE TrackerPaperUIButtons SET ButtonName='" + lMTName.Text + "',"
                    + " SpanishButtonName='" + tbMTSpanishName.Text + "'"
                    + " WHERE ButtonID=" + buttonID.ToString();
                VWA4Common.DB.Update(sql);
            }
            nodeChanged = (int)NodeChanged.NotChanged;  // dirty the node state
        }

		private void Handler_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == (System.Char)Keys.Back) || (e.KeyChar == (System.Char)Keys.Delete)) return;

			if ((e.KeyChar == "'"[0]) ||
				(e.KeyChar == ","[0]) ||
				(e.KeyChar == "\""[0]) ) e.Handled = true;
		}



    }
}
