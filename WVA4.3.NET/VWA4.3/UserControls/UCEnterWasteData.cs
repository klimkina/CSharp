using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;

namespace UserControls
{
	public partial class UCEnterWasteData : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		private DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;
		// Buffers for holding the current Transaction's data
		string sUserTypeName;
		string sUserTypeID;
		string sFoodTypeName;
		string sFoodTypeID;
		string sFoodTypeCost;
		string sLossReasonName;
		string sLossReasonID;
		string sContainerTypeName;
		string sContainerTypeID;
		string sContainerCost;
		//string sSingleContainerWt;
		string sTotalTareWt;
		
		string sStationTypeName;
		string sStationTypeID;
		string sDispositionTypeName;
		string sDispositionTypeID;
		string sDaypartTypeName;
		string sDaypartTypeID;

		string sEventOrderName;
		string sEventOrderTypeID;

		string sDiscount;
		string sProducedAmount;

        decimal _WasteCost = 0;
        decimal nSingleContainerWt = 0;

		bool bReadyWasteCalc;

		List<int> list_prepostconsumer = new List<int>();

		TreeListColumn columnMBID;
		TreeListColumn columnMBName;
		TreeListColumn columnMBSpanishName;
		TreeListColumn columnMBMenuType;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCEnterWasteData()
		{
			InitializeComponent();
			commonEvents = VWA4Common.CommonEvents.GetEvents();
		}
		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			if (dbDetector == null)
			{
				dbDetector = DBDetector.GetDBDetector();
				//dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.DBPathChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
                //dbDetector.AdjustmentsChanged += new DBDetectorEventHandler(dbDetector_AdjustmentsChanged);
				dbDetector.UserLogin += new DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}

			ucTrackercb.Init();  // Load up the Tracker selector combo box
			// Load the Pre/Post Consumer combobox
			cbPrePostConsumer.Items.Clear();
			cbPrePostConsumer.Items.Add("Pre Consumer Waste");
			list_prepostconsumer.Add(1);
			cbPrePostConsumer.Items.Add("Post Consumer Waste");
			list_prepostconsumer.Add(2);
			cbPrePostConsumer.Items.Add("Intermediate Waste");
			list_prepostconsumer.Add(0);
			cbPrePostConsumer.Text = "";
			// Init the MTtree control
			columnMBID = mtTreelist.Columns[1];
			columnMBName = mtTreelist.Columns[0];
			columnMBSpanishName = mtTreelist.Columns[2];
			columnMBMenuType = mtTreelist.Columns[3];
			mtTreelist.Hide();
			// Initial state mgmt
			tbUserNote.Hide();
			tbEventOrder.Hide();
			cbPrePostConsumer.Hide();
			cdProducedAmt.Hide();
			//if (!bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) bEventOrder.Hide();
			//if (!bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"])) bEventOrder.Hide();
			lLb.Hide();
			ClearLabels();
            ClearButtons();
			ClearSettings();
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
		public void LoadData()
		{
			Initialized = false;
			// Load Data processing
			ucTrackerViewer1.Clear();
			ucTrackerViewer1.Hide();
			ucTreeView1.Hide();
			CalculateWaste();
			Initialized = true;
			//ucTrackerViewer1.TermID = "30134";
			//ucTrackerViewer1.LoadTree("Container");
		}


		public void SaveData()
		{
		}

		public bool ValidateData()
		{ return true; }


		///		
		/// Event Handlers and supporting routines
		///		

		
		/// Update the Waste Calculations
		private void CalculateWaste()
		{
			// Check for a possible discount
			if ((sFoodTypeID != "") && (sLossReasonID != ""))
			{
				// Food Type and Loss Reason are specified - check to see if there's an associated discount
				DataTable dtDiscounts = VWA4Common.DB.Retrieve(
					"SELECT * FROM Discounts WHERE (FoodTypeID='"
					+ sFoodTypeID + "') AND (LossTypeID='" + sLossReasonID + "')");
				if (dtDiscounts.Rows.Count > 0)
				{ // There is a discount - set it
					DataRow row = dtDiscounts.Rows[0];
					sDiscount = ((decimal)row["FoodCostDiscount"]).ToString("###0.0000");
					lFoodWasteDisc1.Text = sDiscount;
				}
				else
				{ // No discount
					lFoodWasteDisc1.Text = "(none)";
				}
			}
			else
			{ // not enough info for finding out if there's a discount
				lFoodWasteDisc1.Text = "n/a";
			}

			// See if we have enough data to do a calculation
			if ((sFoodTypeCost != "") && (cdTransactionWt.Text != "") && (sContainerTypeID != ""))
			{
				// We can calculate the food waste value
				decimal discount = 1;
                decimal containerCost = 0;
				if (sDiscount != "")
				{ // need to update the discount
					discount = decimal.Parse(sDiscount);
				}
                // See if the Container Cost is available for a calculation
                if (sContainerTypeID == "")
                { // Container is not selected yet
                    lContainerCost.Text = "n/a";
                    lTotalTareWt.Text = "n/a";
                }
                else
                { // Container is selected
					containerCost = (Decimal.Parse(sContainerCost)) * ((Decimal.Parse(neTransMultiplier.Value.ToString())));
                    lContainerCost.Text = "$ " + containerCost.ToString("####0.00");
                    lSingleContainerWt.Text = nSingleContainerWt.ToString("####0.00");
                    lTotalTareWt.Text = (nSingleContainerWt* (Decimal.Parse(neTransMultiplier.Value.ToString()))).ToString("#####0.00");
					sTotalTareWt = lTotalTareWt.Text;
                }
				//
				// ****
				//
                int nItems = int.Parse(neTransMultiplier.Value.ToString());
				decimal grosswt = decimal.Parse(cdTransactionWt.Text) * nItems;
				decimal netwt = grosswt	- (decimal.Parse(sTotalTareWt));
				if (netwt > 0)
				{
                    // good to calculate
                    WeightStruct weight = new WeightStruct(decimal.Parse(sFoodTypeCost), discount, grosswt, 
                        decimal.Parse(lContainerCost.Text.Replace("$", "")), nSingleContainerWt, 
                        nItems);
                    _WasteCost = weight.WasteCost;
                    
					lFoodWasteCost.Text = "$ " + (_WasteCost - containerCost).ToString("####0.00");
					lFoodWasteWeight.Text = netwt.ToString("####0.00") + " lb";
					bReadyWasteCalc = true;
				}
				else
				{ // Not good - not enough weight to overcome the tare weight
					lFoodWasteCost.Text = "(negative net wt)";
					lFoodWasteWeight.Text = "0 lb";
				}
			}
			else
			{
				lFoodWasteCost.Text = "n/a";
				lFoodWasteWeight.Text = "n/a";
                _WasteCost = 0;
			}
			
			

			/// Transaction filled out enough to be save-able?
			if (bReadyWasteCalc && (sTotalTareWt != "") && (deTransactionDate.Text != "") && (cdTransactionWt.Text != "")
				&& (cbPrePostConsumer.Text != "") && (sUserTypeID != ""))
			{ // Show the button - we can save the transaction now
                if (bool.Parse(SecurityManager.GetSecurityManager()["Enter Waste Data"]))
                    bSave.Show();
                else
                    MessageBox.Show("You have no permissions to Enter Waste Data");
			}
			else
			{ // Not save-able - hide the button
				bSave.Hide();
			}
		}


		private void ucTrackerViewer1_TrackerButtonChanged(object sender, UCTrackerViewer.TrackerViewerEventArgs e)
        {
			
			//MessageBox.Show("Button choosed: " + e.Name);
			//ucTrackerViewer1.LoadTree("Food");
			string typename = ucTrackerViewer1.TypeName;

			// Determine Selected Type and process accordingly
			switch (typename.ToLower())
			{
				case "user":
					{
						lUserType.Text = e.Name;
						sUserTypeName = e.Name;
						sUserTypeID = e.TypeID;
						break;
					}
				case "food":
					{
						lFoodType.Text = e.Name;
						sFoodTypeName = e.Name;
						sFoodTypeID = e.TypeID;
						sFoodTypeCost = ucTrackerViewer1.Cost.ToString();
						break;
					}
				case "loss":
					{
						lLossReason.Text = e.Name;
						sLossReasonName = e.Name;
						sLossReasonID = e.TypeID;
						break;
					}
				case "container":
					{
						lContainerType.Text = e.Name;
						sContainerTypeName = e.Name;
						sContainerTypeID = e.TypeID;
						sContainerCost = ucTrackerViewer1.Cost.ToString();
                        lContainerCost.Text = (decimal.Parse(sContainerCost)).ToString("#####0.00");
                        nSingleContainerWt = Convert.ToDecimal(ucTrackerViewer1.TareWeight);
						//sSingleContainerWt = ucTrackerViewer1.TareWeight.ToString("#####0.00");
                        lSingleContainerWt.Text = nSingleContainerWt.ToString("#####0.00");
						sTotalTareWt = (nSingleContainerWt * (Decimal.Parse(neTransMultiplier.Value.ToString()))).ToString("#####0.00");
                        lTotalTareWt.Text = (nSingleContainerWt * (Decimal.Parse(neTransMultiplier.Value.ToString()))).ToString("#####0.00");
						break;
					}
				case "station":
					{
						lStation.Text = e.Name;
						sStationTypeName = e.Name;
						sStationTypeID = e.TypeID;
						break;
					}
				case "disposition":
					{
						lDisposition.Text = e.Name;
						sDispositionTypeName = e.Name;
						sDispositionTypeID = e.TypeID;
						break;
					}
				case "daypart":
					{
						lDaypart.Text = e.Name;
						sDaypartTypeName = e.Name;
						sDaypartTypeID = e.TypeID;
						break;
					}
				case "userquestion":
					{
						lUserNote.Text = e.Name;
						tbUserNote.Text = e.Name;
						break;
					}
			}
			CalculateWaste();
        }

		private void bUserType_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("User");
			ucTrackerViewer1.Show();
            
			ucTreeView1.Hide();
			lTreeTitle.Text = "Users";
			if ((sUserTypeID != null) && (sUserTypeID != "")) ucTrackerViewer1.TypeID = sUserTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bFoodType_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Food");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
            lTreeTitle.Text = VWACommon.WasteProfile + " Types";
			if ((sFoodTypeID != null) && (sFoodTypeID != "")) ucTrackerViewer1.TypeID = sFoodTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bLossReason_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Loss");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Loss Types";
			if ((sLossReasonID != null) && (sLossReasonID != "")) ucTrackerViewer1.TypeID = sLossReasonID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bContainerType_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Container");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Container Types";
			if ((sContainerTypeID != null) && (sContainerTypeID != "")) ucTrackerViewer1.TypeID = sContainerTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bStation_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Station");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Stations";
			if ((sStationTypeID != null) && (sStationTypeID != "")) ucTrackerViewer1.TypeID = sStationTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bDisposition_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Disposition");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Dispositions";
			if ((sDispositionTypeID != null) && (sDispositionTypeID != "")) ucTrackerViewer1.TypeID = sDispositionTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bDaypart_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("Daypart");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Dayparts";
			if ((sDaypartTypeID != null) && (sDaypartTypeID != "")) ucTrackerViewer1.TypeID = sDaypartTypeID;
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lPrePost.Show();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bPrePost_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.Clear();
			ucTrackerViewer1.Hide();
			ucTreeView1.Hide();
			lTreeTitle.Text = "";
			
			cbPrePostConsumer.Show();
			lPrePost.Hide();
			
			tbUserNote.Hide();
			tbEventOrder.Hide();
			lUserNote.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}

		private void bUserDefined_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			//ucTrackerViewer1.TermID = ucTrackercb.TrackerID;
			ucTrackerViewer1.LoadTree("UserQuestion");
			ucTrackerViewer1.Show();
			ucTreeView1.Hide();
			lTreeTitle.Text = "Predefined User Notes";
			
			tbUserNote.Show();
			lUserNote.Hide();
			
			tbEventOrder.Hide();
			cbPrePostConsumer.Hide();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lPrePost.Show();
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}
		private void bEventOrder_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			ucTrackerViewer1.Clear();
			ucTrackerViewer1.Hide();
			lTreeTitle.Text = "Event Orders";
			ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
						"BEO", "0");
			ucTreeView1.Show();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			lEventOrder.Hide();
			
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			lPrePost.Show();
			lUserNote.Show();
			lProducedAmt.Show();
			cdProducedAmt.Hide();
			lLb.Hide();
		}


		private void bProducedAmount_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			ucTrackerViewer1.Clear();
			ucTrackerViewer1.Hide();
			lTreeTitle.Text = "";
			ucTreeView1.Hide();
			tbEventOrder.Hide();
			//if (bool.Parse(VWA4Common.GlobalSettings.ftEventOrderManagement)) lEventOrder.Show();
			lEventOrder.Visible = bool.Parse(SecurityManager.GetSecurityManager()["Manage Event Orders"]);
			cbPrePostConsumer.Hide();
			tbUserNote.Hide();
			lPrePost.Show();
			lUserNote.Show();

			lProducedAmt.Hide();
			cdProducedAmt.Show();
			lLb.Show();
		}


		private void ucTrackercb_TrackerChanged(object sender, UCTrackerPicker.TrackerEventArgs e)
		{
			mtTreelist.Hide();
			ucTreeView1.Hide();
			ucTrackerViewer1.TermID = e.TermID;
			ClearLabels();
            ClearButtons();
			ClearSettings();
		}
        private void ClearButtons()
        {
            if (bUserType.Checked)
            {
                bUserType.Checked = false;
                bUserType.Refresh();
            } 
            else if (bFoodType.Checked)
            {
                bFoodType.Checked = false;
                bFoodType.Refresh();
            }
            else if (bLossReason.Checked)
            {
                bLossReason.Checked = false;
                bLossReason.Refresh();
            }
            else if (bContainerType.Checked)
            {
                bContainerType.Checked = false;
                bContainerType.Refresh();
            }
            else if (bStation.Checked)
            {
                bStation.Checked = false;
                bStation.Refresh();
            }
            else if (bDisposition.Checked)
            {
                bDisposition.Checked = false;
                bDisposition.Refresh();
            }
            else if (bDaypart.Checked)
            {
                bDaypart.Checked = false;
                bDaypart.Refresh();
            }
            else if (bPrePost.Checked)
            {
                bPrePost.Checked = false;
                bPrePost.Refresh();
            }
            else if (bUserDefined.Checked)
            {
                bUserDefined.Checked = false;
                bUserDefined.Refresh();
            }
            else if (bEventOrder.Checked)
            {
                bEventOrder.Checked = false;
                bEventOrder.Refresh();
            }
            else if (bProducedAmount.Checked)
            {
                bProducedAmount.Checked = false;
                bProducedAmount.Refresh();
            }
            
            //bUserType.Appearance.Reset();
        }
		private void ClearLabels()
		{
			lFoodType.Text = "";
			lFoodWasteCost.Text = "";
			lFoodWasteDisc1.Text = "";
			lLossReason.Text = "";
			lContainerCost.Text = "";
			lContainerType.Text = "";
            lTotalTareWt.Text = "";
            lSingleContainerWt.Text = "";
			lDaypart.Text = "";
			lDisposition.Text = "";
			lPrePost.Text = "";
			lStation.Text = "";
			lUserType.Text = "";
			lEventOrder.Text = "";
			//lTreeTitle.Text = "";
			lProducedAmt.Text = "";

			lFoodWasteCost.Text = "n/a";
			lContainerCost.Text = "n/a";
			lFoodWasteDisc1.Text = "n/a";
			lFoodWasteWeight.Text = "n/a";
			lSingleContainerWt.Text = "n/a";
			lTotalTareWt.Text = "n/a";
			lMTButtonName.Text = "";

            ucTrackerViewer1.Clear();
            ucTrackerViewer1.Hide();
            ucTreeView1.Hide();
            lTreeTitle.Text = "";

            _WasteCost = 0;
		}

		private void ClearSettings()
		{
			bReadyWasteCalc = false;
			sUserTypeName = "";
			sUserTypeID = "";
			sFoodTypeName = "";
			sFoodTypeID = "";
			sLossReasonName = "";
			sLossReasonID = "";
			sContainerTypeName = "";
			sContainerTypeID = "";
			//sSingleContainerWt = "";
            nSingleContainerWt = 0;
			sTotalTareWt = "";
			sContainerCost = "";

			sStationTypeName = "";
			sStationTypeID = "";
			sDispositionTypeName = "";
			sDispositionTypeID = "";
			sDaypartTypeName = "";
			sDaypartTypeID = "";

			lUserNote.Text = "";
			lPrePost.Text = "";
			lEventOrder.Text = "";
			tbUserNote.Text = "";
			tbEventOrder.Text = "";

			sDiscount = "";

			sProducedAmount = "";

			cdTransactionWt.Text = "";
			neTransMultiplier.Value = 1;
			cdProducedAmt.Value = 0;

            deTransactionDate.Text = "";
            teTransactionTime.Time = DateTime.Parse("12:00:00");
		}

		private void bClearThisTransaction_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			ucTrackerViewer1.Hide();
			ClearLabels();
            ClearButtons();
			ClearSettings();
			deTransactionDate.Text = "";
			teTransactionTime.Time = DateTime.Parse("12:00:00");
			cdTransactionWt.Text = "";
			cdProducedAmt.Hide();
			cbPrePostConsumer.Hide();
			tbEventOrder.Hide();
			tbUserNote.Hide();
			lProducedAmt.Text = "";
		}

		private void bYesterday_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			deTransactionDate.DateTime = DateTime.Now.AddDays(-1);
		}

		private void bToday_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			deTransactionDate.DateTime = DateTime.Now;
		}

		private void bNow_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Now;
		}

		private void b6AM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("06:00:00");
		}

		private void b9AM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("09:00:00");
		}

		private void b12AM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("12:00:00");
		}

		private void b3PM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("15:00:00");
		}

		private void b6PM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("18:00:00");
		}

		private void b9PM_Click(object sender, EventArgs e)
		{
			mtTreelist.Hide();
			teTransactionTime.Time = DateTime.Parse("21:00:00");
		}

		private void cbPrePostConsumer_SelectedIndexChanged(object sender, EventArgs e)
		{
			lPrePost.Text = cbPrePostConsumer.Text;
			CalculateWaste();
		}

		private void tbUserNote_TextChanged(object sender, EventArgs e)
		{
			lUserNote.Text = tbUserNote.Text;
		}

		private void tbEventOrder_TextChanged(object sender, EventArgs e)
		{
			lEventOrder.Text = tbEventOrder.Text;
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			CloseTaskSheet();
		}

		private void CloseTaskSheet()
		{
			ClearLabels();
			ClearButtons();
			ClearSettings();
			commonEvents.TaskSheetKey = "dashboard";
		}
		private void ultraNumericEditor2_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
			int offset;

			if (e.Button.Key == "Minus")
				offset = -1;
			else if (e.Button.Key == "Plus")
				offset = 1;
			else
				return;

			decimal newValue = 0;

			try
			{
				object value = e.Button.Editor.Value;

				newValue = Convert.ToDecimal(e.Button.Editor.Value);

				newValue += offset;
			}
			catch { }

			EditorWithMask maskEditor = e.Button.Editor as EditorWithMask;

			if (newValue < 1)
				newValue = 1;

			e.Button.Editor.Value = newValue;


			if (maskEditor != null)
				maskEditor.SelectAll();

		}

		private void cdTransactionWt_EditValueChanged(object sender, EventArgs e)
		{
			CalculateWaste();
		}

		private void neTransMultiplier_ValueChanged(object sender, EventArgs e)
		{
			CalculateWaste();
		}

		private void deTransactionDate_EditValueChanged(object sender, EventArgs e)
		{
			CalculateWaste();
		}


		private void cdProducedAmt_ValueChanged(object sender, EventArgs e)
		{
			lProducedAmt.Text = cdProducedAmt.Value.ToString() + " lb";
			sProducedAmount = cdProducedAmt.Value.ToString();
		}


        ImportTransfer _Transfer = null;
		/// <summary>
		/// Save the Transaction to the waste data stream.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
		{
            
			/// todo: Mila - hook up the saving of this waste data transaction here
			/// 
            try
            {
                if (cdProducedAmt.Value > 0 && (cdTransactionWt.Value - decimal.Parse(lTotalTareWt.Text) * (int)neTransMultiplier.Value) > cdProducedAmt.Value)
                {
                    MessageBox.Show(this, "Produced amount can't be less than wasted amount", "Produced Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    //prepare data for save
                    DateTime transferDate = DateTime.Parse(deTransactionDate.DateTime.ToString("yyyy/MM/dd") + " " + teTransactionTime.Time.ToString("HH:mm:ss"));
                    decimal discount = 1;
                    if (!decimal.TryParse(sDiscount, out discount))
                        discount = 1;
                    DataTable temp = VWA4Common.DB.Retrieve(@"SELECT TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName, " +
                        " Sites.ID AS SiteID, Sites.LicensedSite AS SiteName " +
                        " FROM (Sites LEFT JOIN Terminals ON Terminals.SiteID = Sites.ID) " +
                        " LEFT OUTER JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID" +
                        " WHERE Terminals.TermID = '" + ucTrackercb.TrackerID.Trim() + "'");
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
                    //open transaction
                    //System.Data.OleDb.OleDbConnection _connTransaction;
                    //OleDbTransaction _transaction;
                    //_connTransaction = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                    //_connTransaction.Open();
                    //_transaction = _connTransaction.BeginTransaction();

                    // create transfer for data
                    if (_Transfer == null)
                    {
                        _Transfer = new ImportTransfer(transferDate, ucTrackercb.TrackerID, ucTrackercb.TrackerName,
                            VWA4Common.GlobalSettings.TrackerSWVersion, int.Parse(siteID), siteName, int.Parse(typeCatalogID), typeCatalogName, false);
                        //save transfer to DB
                        //_Transfer.Check();
                        _Transfer.DBSave(true);//_connTransaction, _transaction, true);
                    }
                    int nItems = (int)neTransMultiplier.Value;
                    //create data record
                    ImportWeight rec = new ImportWeight(_Transfer.TransKey, transferDate, VWACommon.ConvertIsPreconsumer(lPrePost.Text),
                        decimal.Parse(cdTransactionWt.Text) * nItems,
                        _WasteCost, sFoodTypeID, decimal.Parse(sFoodTypeCost), discount,
                        sLossReasonID, sContainerTypeID, nSingleContainerWt, decimal.Parse(lContainerCost.Text.Replace("$", "")), 
                        sStationTypeID, sDispositionTypeID,
                        sDaypartTypeID, sEventOrderTypeID, sUserTypeID, lUserNote.Text,
                        nItems, true, 4, "Pound", "", -1, "", "", cdProducedAmt.Value);
                    rec.Check();
                    if (rec.IsCorrect() && rec.IsWarning() ||
                                        MessageBox.Show(null, rec.ErrorMsg + Environment.NewLine + rec.WarningMsg + Environment.NewLine +
                                        "Do you want to save this record anyway?",
                                        "VWA Enter Waste Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        //save data to DB
                        rec.DBSave(true);//_connTransaction, _transaction, true);
                        //set checkbox in task
                        VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                        utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "enterwastedata");
                    }

                    //close transaction
                    //_transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occurred! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //_transaction.Rollback();
            }
            finally
            {
                //if (_connTransaction != null && _connTransaction.State != ConnectionState.Closed)
                //        _connTransaction.Close();
            }

			// When saved correctly, clear the waste data amount and number of items.
            lTotalTareWt.Text = "";
			cdTransactionWt.Text = "";
			neTransMultiplier.Value = 1;
			bSave.Hide();
		}


		///***********************************************************************************************
		///***********************************************************************************************
		///***********************************************************************************************
		///***********************************************************************************************
		/// Memorized Transaction Logic follows:
		///***********************************************************************************************
		///***********************************************************************************************
		///***********************************************************************************************
		///***********************************************************************************************

	
		private void bPreLoadfromRecurring_Click(object sender, EventArgs e)
		{
			// If the MT tree control is already showing, hide it
			if (mtTreelist.Visible)
			{
				mtTreelist.Hide();
				return;
			}
			// Lose the Tracker viewer
			ucTrackerViewer1.Hide();
			lTreeTitle.Text = "";

			// Load the MT tree control
			InitializeDataSet();
			// Show the MT tree control
			mtTreelist.Show();

			// What else should we disable while the MTtreelist is active?

		}

		/// <summary>
		/// Initialize the user control's data.
		/// New version using DevExpress tree control.
		/// </summary>
		public void InitializeDataSet()
		{
			Initialized = false;
			TreeListNode rmNode;
			TreeListNode rbNode;
			mtTreelist.ClearNodes();
			// Check to see if we have no MT's yet - ie is there a main menu?
			//  if not, add one and get rid of any other menus and buttons,
			//  which would be spurious.

			DataTable dtRootMenuNodes = VWA4Common.DB.Retrieve("SELECT * FROM TrackerPaperUIMenus WHERE ParentMenuID=0"
				+ " AND TermID=\"" + ucTrackercb.TrackerID + "\""
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
				+ " AND TermID=\"" + ucTrackercb.TrackerID + "\""
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
				+ " AND TermID=\"" + ucTrackercb.TrackerID + "\""
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
			Initialized = false;
			if (e.Node != null)
			{
				// Is it a menu or button selected now?
				if ((int)e.Node.GetValue(columnMBMenuType) == 1)
				{ /// It's a menu - can't select it
					//manageMTSelectState("menu");
					e.Node.Selected = false;
				}
				else
				{ /// It's a button - now we can load its info
					// Fill out the MT info
					LoadandFillMTinfo((int)e.Node.GetValue(columnMBID));
				}
			}
			Initialized = true;
			CalculateWaste();
		}

		/// <summary>
		/// Fill out the memorized transaction info in the UI, based on the currently selected
		/// MT button.
		/// </summary>
		/// <param name="ButtonID"></param>
		private void LoadandFillMTinfo(int ButtonID)
		{
			ClearSettings();
            ClearLabels();
            ClearButtons();
			// Get the info from the database
			DataTable dtMTinfo = VWA4Common.DB.Retrieve(
				  "SELECT * FROM TrackerPaperUIButtons WHERE ButtonID="
				+ ButtonID.ToString()
				);
			if (dtMTinfo.Rows.Count == 1)
			{ // We found the row in the DB - fill the UI
				DataRow row = dtMTinfo.Rows[0];
				string lcstr = row["UnitTypeKey"].ToString();
				if (lcstr.ToLower() == "item")
				{ /// Item type MT

					lMTButtonName.Text = "(" + row["UnitTypeDisplayName"].ToString() + ")";
					cdTransactionWt.Value = (decimal)row["UnitaryFoodWeight"];
				}
				else
				{ /// Weight type MT
					
					lMTButtonName.Text = "";
				}

				/// Types info
				lFoodType.Text = row["FoodTypeName"].ToString();
				sFoodTypeName = lFoodType.Text;
				sFoodTypeID = row["FoodTypeID"].ToString();
				sFoodTypeCost = row["FoodTypeCost"].ToString();
				lLossReason.Text = row["LossTypeName"].ToString();
                //lFoodWasteDisc1.Text = row["LossTypeName"].ToString();
				sLossReasonName = lLossReason.Text;
				sLossReasonID = row["LossTypeID"].ToString();
				lContainerType.Text = row["ContainerTypeName"].ToString();
				sContainerTypeName = lContainerType.Text;
				sContainerTypeID = row["ContainerTypeID"].ToString();
				//sSingleContainerWt = row["ContainerWeight"].ToString();
                nSingleContainerWt = decimal.Parse(row["ContainerWeight"].ToString());
                lSingleContainerWt.Text = row["ContainerWeight"].ToString();
				sContainerCost = row["ContainerCost"].ToString();
                
				if (sContainerCost == "") sContainerCost = "0";

				if ((row["StationTypeName"].ToString() != ""))
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
							//sPrePostConsumerFlag = "0";
							break;
						}
					case 1:
						{ // Pre consumer waste
							cbPrePostConsumer.SelectedIndex = 0;
							//cbPrePostConsumer.Text = "Pre-consumer Waste";
							//sPrePostConsumerFlag = "1";
							break;
						}
					case 2:
						{ // Post consumer waste
							cbPrePostConsumer.SelectedIndex = 1;
							//cbPrePostConsumer.Text = "Post-consumer Waste";
							//sPrePostConsumerFlag = "2";
							break;
						}
				}
				lPrePost.Text = cbPrePostConsumer.Text;
				mtTreelist.Hide();
			}
			else
			{ // No row - must not be saved yet
				// this won't happen...
				MessageBox.Show("Data for this Recurring Transaction is unavailable.");
			}
		}

		private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			sEventOrderTypeID = e.ID;
			sEventOrderName = e.Name;
			lEventOrder.Text = e.Name;
		}

		private void ucTreeView1_Leave(object sender, EventArgs e)
		{
			if (ucTreeView1.ID == "")
			{
				sEventOrderTypeID = "";
				sEventOrderName = "";
				lEventOrder.Text = "";
			}
			ucTreeView1.Hide();

		}
		private void dbDetector_UserLogin(object sender, LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Waste Data")))
				CloseTaskSheet();
		}
        //private void dbDetector_AdjustmentsChanged(object sender, EventArgs e)
        //{
        //    CalculateWaste();
        //}
	}
}
