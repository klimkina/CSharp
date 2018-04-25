using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class UCTransactionViewer : UserControl
	{
		/// Class level elements
		bool Initialized;
		int ID_Weights;
		VWA4Common.Transaction_Mem currTrans;

		/// 
		/// Buffers for holding the current Transaction's data
		///
				// Transaction calculated values for saving
		decimal dTotalFoodWeight_Calculated;
		decimal dTotalFoodCost_Calculated;
		decimal dTotalContainerCost_Calculated;
		decimal dTotalContainerWeight_Calculated;
		DateTime dtStartTimestamp_CurrTrans;
		DateTime dtSaveTimestamp_CurrTrans;


		/// <summary>
		/// Constructor.
		/// </summary>
		public UCTransactionViewer()
		{
			InitializeComponent();
		}
		
		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
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
		/// <summary>
		/// Standard Load Data method.
		/// </summary>
		public void LoadData(int id_weights)
		{
			ID_Weights = id_weights;
			LoadData();
		}
		
		public void LoadData()
		{
			Initialized = false;
			/// Load specified transaction
			string sql = "SELECT * FROM Weights WHERE ID= "
				+ ID_Weights.ToString();
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt != null && dt.Rows.Count > 0)
			{
				currTrans = new VWA4Common.Transaction_Mem();
				DataRow dr = dt.Rows[0];
				// Let's do it...
				currTrans.ID = int.Parse(dr["ID"].ToString());
				currTrans.IsPreconsumer = int.Parse(dr["IsPreconsumer"].ToString());
				currTrans.TransKey = int.Parse(dr["TransKey"].ToString());
				int.TryParse(dr["DETID"].ToString(), out currTrans.DETID);
				currTrans.Timestamp = DateTime.Parse(dr["Timestamp"].ToString());
				DateTime.TryParse(dr["StartTimestamp"].ToString(), out currTrans.StartTimestamp);
				DateTime.TryParse(dr["SaveTimestamp"].ToString(), out currTrans.SaveTimestamp);
				currTrans.Weight = decimal.Parse(dr["Weight"].ToString());
				currTrans.WasteCost = decimal.Parse(dr["WasteCost"].ToString());
				//
				currTrans.UserTypeID = dr["UserTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("user", currTrans.UserTypeID,
					out currTrans.UserTypeName);
				//
				currTrans.FoodTypeID = dr["FoodTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", currTrans.FoodTypeID,
					out currTrans.FoodTypeName);
				currTrans.FoodTypeCost = decimal.Parse(dr["FoodTypeCost"].ToString());
				currTrans.FoodTypeDiscount = decimal.Parse(dr["FoodTypeDiscount"].ToString());
				currTrans.LossTypeID = dr["LossTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("loss", currTrans.LossTypeID,
					out currTrans.LossTypeName);
				currTrans.ContainerTypeID = dr["ContainerTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container", currTrans.ContainerTypeID,
					out currTrans.ContainerTypeName);
				currTrans.ContainerWeight = decimal.Parse(dr["ContainerWeight"].ToString());
				currTrans.ContainerCost = decimal.Parse(dr["ContainerCost"].ToString());
				VWA4Common.GlobalSettings.GetContainerVolumeData(currTrans.ContainerTypeID, 
					out currTrans.ContainerTypeVolume, out currTrans.ContainerTypeVolumeUnitType);
				//
				currTrans.StationTypeID = dr["StationTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("station", currTrans.StationTypeID,
					out currTrans.StationTypeName);
				currTrans.DispositionTypeID = dr["DispositionTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("disposition", currTrans.DispositionTypeID,
					out currTrans.DispositionTypeName);
				currTrans.DaypartTypeID = dr["DaypartTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("daypart", currTrans.DaypartTypeID,
					out currTrans.DaypartTypeName);
				//
				currTrans.BEOTypeID = dr["BEOTypeID"].ToString();
				VWA4Common.GlobalSettings.GetTypeNameFromTypeID("eventorder", currTrans.BEOTypeID,
					out currTrans.BEOTypeName);
				VWA4Common.GlobalSettings.GetEventOrderEventData(currTrans.BEOTypeID,
					out currTrans.BEOTypeClientName, out currTrans.BEOTypeGuestCount, out currTrans.BEOTypeEventDate,
					out currTrans.BEOTypeBEONumber, out currTrans.BEOTypeMRatio);
				//
				currTrans.UserQuestion = dr["UserQuestion"].ToString();
				currTrans.Nitems = int.Parse(dr["Nitems"].ToString());
				currTrans.IsMemorized = int.Parse(dr["IsMemorized"].ToString());
				currTrans.IsManualInput = bool.Parse(dr["IsManualInput"].ToString());
				int.TryParse(dr["ProducedID"].ToString(), out currTrans.ProducedID);
				currTrans.UnitUniqueName = dr["UnitUniqueName"].ToString();
				decimal.TryParse(dr["UnitaryItemWeight"].ToString(), out currTrans.UnitaryItemWeight);
				decimal.TryParse(dr["WasteAmountUserEntry"].ToString(), out currTrans.WasteAmountUserEntry);
				currTrans.UnitsDisplayName = dr["UnitsDisplayName"].ToString();
				currTrans.QuantityString_DE = dr["QuantityString_DE"].ToString();
					VWA4Common.GlobalSettings.GetQuantityModeStringCodefromIsMemorized(currTrans.IsMemorized);
				decimal wasteamountuserentry = 0;
				decimal.TryParse(dr["WasteAmountUserEntry"].ToString(), out wasteamountuserentry);
			}

			updateDisplay(false);
			Initialized = true;
		}


		public void SaveData()
		{
		}

		public bool ValidateData()
		{ return true; }


		/// 
		/// Support Methods
		/// 

		private void updateDisplay(bool clear)
		{
			/// First, clear
			/// 
			lSessionFormset.Text = "";
			// Timestamp
			lCurrDate.Text = "";
			lCurrTime.Text = "";
			// Waste Quantity
			lWeight.Text = "";
			lWasteCost.Text = "";
			// User Type
			lCurrUserTypeName.Text = "";
			lCurrUserTypeID.Text = "";
			// Food Type
			lCurrFoodTypeName.Text = "";
			lCurrFoodTypeID.Text = "";
			lCurrFoodTypeCost.Text = "";
			lCurrFoodTypeVolume.Text = "";
			// Loss Reason
			lCurrLossTypeName.Text = "";
			lCurrLossTypeOverProdFlag.Text = "";
			lCurrLossTypeTrimWasteFlag.Text = "";
			lCurrLossTypeHandlingFlag.Text = "";
			// Container Type
			lCurrContainerTypeName.Text = "";
			lCurrContainerTypeID.Text = "";
			lCurrContainerTypeTareWt.Text = "";
			lCurrContainerTypeCost.Text = "";
			lCurrContainerTypeVolume.Text = "";
			// Station Type
			lCurrStationTypeName.Text = "";
			lCurrStationTypeID.Text = "";
			// Disposition Type
			lCurrDispositionTypeName.Text = "";
			lCurrDispositionTypeID.Text = "";
			// Daypart Type
			lCurrDaypartTypeName.Text = "";
			lCurrDaypartTypeID.Text = "";
			// Event Order Type
			lCurrEventOrderTypeName.Text = "";
			lCurrEventOrderTypeID.Text = "";
			lCurrEventOrderTypeClient.Text = "";
			lCurrEventOrderTypeGuestCount.Text = "";
			lCurrEventOrderTypeEventDate.Text = "";
			lCurrEventOrderTypeBEONumber.Text = "";
			lCurrEventOrderTypeMRatio.Text = "";
			// Pre/Post Type:
			lCurrPrePost.Text = "";
			// Transaction Notes
			tCurrUserNote.Text = "";

			// Transaction Elapsed Time
			lElapsedTime.Text = "";

			/// Now, load
			/// if clear, leave everything blank
			if (!clear)
			{
				// Transaction ID
				lTransactionID.Text = currTrans.ID.ToString();
				// Session/formset string
				if (currTrans.IsManualInput)
				{
					string stemp = "";
					VWA4Common.GlobalSettings.GetDETNamefromID(currTrans.DETID,
						out stemp);
					lSessionFormset.Text = "Session: " + currTrans.TransKey.ToString()
						+ "     Form Set: " + stemp;
				}
				else
				{
					string stemp = "";
					VWA4Common.GlobalSettings.GetDETNamefromID(currTrans.DETID,
						out stemp);
					lSessionFormset.Text = "Transfer ID: " + currTrans.TransKey.ToString()
						+ "     Form Set: " + stemp;
				}
				// Timestamp
				lCurrDate.Text = currTrans.Timestamp.ToString("M/d/yy");
				lCurrTime.Text = currTrans.Timestamp.ToLongTimeString();
				// Waste Quantity
				lWeight.Text = (currTrans.Weight/currTrans.Nitems).ToString("####0.00") + " lb  * " 
					+ currTrans.Nitems.ToString() + " Item(s)";
				lWasteCost.Text = "$ " + currTrans.WasteCost.ToString("####0.00");

				switch (currTrans.IsMemorized)
				{
					case 0:  // Standard Tracker Waste loop
						{
							lQuantityString.Text = "";
							lQuantityMode.Text = "Waste Loop (Tracker)";
							break;
						}
					case 1:  // Memorized Transaction on Tracker
						{
							lQuantityString.Text = "";
							lQuantityMode.Text = "Memorized (Tracker)";
							break;
						}
					case 2:  // Entered by volume on Tracker
						{
							lQuantityString.Text = "";
							lQuantityMode.Text = "Volume (Tracker)";
							break;
						}
					case 3:  // VWA Manual Entry by Weight
						{
							lQuantityString.Text = currTrans.QuantityString_DE;
							lQuantityMode.Text = "Weight (Manual)";
							break;
						}
					case 4:  //  VWA Manual Entry by Volume
						{
							lQuantityString.Text = currTrans.QuantityString_DE;
							lQuantityMode.Text = "Container Count (Manual)";
							break;
						}
					case 5:  //  VWA Manual Entry by Each
						{
							lQuantityString.Text = currTrans.QuantityString_DE;
							lQuantityMode.Text = "Item Count (Manual)";
							break;
						}

				}
				


				// User Type
				if (currTrans.UserTypeID == "")
				{
					lCurrUserTypeName.Text = "(no data)";
					label4.Hide();
				}
				else
				{
					lCurrUserTypeName.Text = currTrans.UserTypeName;
					label4.Show();
				}
				lCurrUserTypeID.Text = currTrans.UserTypeName;
				// Food Type
				lCurrFoodTypeName.Text = currTrans.FoodTypeName;
				lCurrFoodTypeID.Text = currTrans.FoodTypeID;
				lCurrFoodTypeCost.Text = "$ " + currTrans.FoodTypeCost.ToString("####0.00");
				string s = "";
				if (VWA4Common.GlobalSettings.GetFoodVolumeStringfromData(
					currTrans.FoodTypeID, out s))
				{
					lCurrFoodTypeVolume.Text = s;
				}
				else
				{
					lCurrFoodTypeVolume.Text = "(no data)";
				}
				lCurrFoodTypeDiscount.Text = currTrans.FoodTypeDiscount.ToString();
				// Loss Reason
				lCurrLossTypeName.Text = currTrans.LossTypeName;
				lCurrLossTypeID.Text = currTrans.LossTypeID;
				bool btemp1 = false;
				bool btemp2 = false;
				bool btemp3 = false;
				VWA4Common.GlobalSettings.GetLossFlags(currTrans.LossTypeID, out btemp1, out btemp2, out btemp3);
				lCurrLossTypeOverProdFlag.Text = btemp1 ? "Yes" : "No";
				lCurrLossTypeTrimWasteFlag.Text = btemp2 ? "Yes" : "No";
				lCurrLossTypeHandlingFlag.Text = btemp3 ? "Yes" : "No";
				// Container Type
				lCurrContainerTypeName.Text = currTrans.ContainerTypeName;
				lCurrContainerTypeID.Text = currTrans.ContainerTypeID;
				lCurrContainerTypeTareWt.Text = currTrans.ContainerWeight.ToString("####0.00") + " lb";
				lCurrContainerTypeCost.Text = "$ " + currTrans.ContainerCost.ToString("####0.00");
				s = "";
				if (!VWA4Common.GlobalSettings.GetContainerVolumeStringfromData(currTrans.ContainerTypeID,
					out s))
					lCurrContainerTypeVolume.Text = "(no data)";
				else
					lCurrContainerTypeVolume.Text = s;
				// Station Type
				if (currTrans.StationTypeID == "")
				{
					lCurrStationTypeName.Text = "(no data)";
					label26.Hide();
				}
				else
				{
					lCurrStationTypeName.Text = currTrans.StationTypeName;
					lCurrStationTypeID.Text = currTrans.StationTypeID;
					label26.Show();
				}
				// Disposition Type
				if (currTrans.DispositionTypeID == "")
				{
					lCurrDispositionTypeName.Text = "(no data)";
					label12.Hide();
				}
				else
				{
					lCurrDispositionTypeName.Text = currTrans.DispositionTypeName;
					lCurrDispositionTypeID.Text = currTrans.DispositionTypeID;
					label12.Show();
				}
				// Daypart Type
				if (currTrans.DaypartTypeID == "")
				{
					lCurrDaypartTypeName.Text = "(no data)";
					label15.Hide();
				}
				else
				{
					lCurrDaypartTypeName.Text = currTrans.DaypartTypeName;
					lCurrDaypartTypeID.Text = currTrans.DaypartTypeID;
					label15.Show();
				}
				// Event Order Type
				if (currTrans.BEOTypeID == "")
				{
					lCurrEventOrderTypeName.Text = "(no data)";
					lCurrEventOrderTypeID.Text ="";
					label20.Hide();
					lCurrEventOrderTypeClient.Text = "";
					label23.Hide();
					lCurrEventOrderTypeGuestCount.Text = "";
					label27.Hide();
					lCurrEventOrderTypeEventDate.Text = "";
					label34.Hide();
					lCurrEventOrderTypeBEONumber.Text = "";
					label32.Hide();
					lCurrEventOrderTypeMRatio.Text = "";
					label30.Hide();
				}
				else
				{
					lCurrEventOrderTypeName.Text = currTrans.BEOTypeName;
					lCurrEventOrderTypeID.Text = currTrans.BEOTypeID;
					label20.Show();
					lCurrEventOrderTypeClient.Text = currTrans.BEOTypeClientName;
					label23.Show();
					int itemp = 0;
					string stemp2 = "";
					DateTime dttemp = DateTime.MinValue;
					decimal dtemp = 0;
					//VWA4Common.GlobalSettings.GetEventOrderEventData(currTrans.BEOTypeID, out stemp,
					//    out itemp, out dttemp, out stemp2, out dtemp);
					lCurrEventOrderTypeGuestCount.Text = itemp.ToString();
					label27.Show();
					lCurrEventOrderTypeEventDate.Text = dttemp.ToShortDateString();
					label34.Show();
					lCurrEventOrderTypeBEONumber.Text = stemp2;
					label32.Show();
					lCurrEventOrderTypeMRatio.Text = dtemp.ToString("####0.00");
					label30.Show();
				}
				// Pre/Post Type:
				lCurrPrePost.Text = VWA4Common.GlobalSettings.GetWasteModeStringfromIsPreconsumer(
					int.Parse(currTrans.IsPreconsumer.ToString()));
				// Transaction Notes
				tCurrUserNote.Text = currTrans.UserQuestion;
				if (tCurrUserNote.Text == "")
				{
					tCurrUserNote.Hide();
					label35.Text = "(no data)";
					label35.Show();
				}
				else
				{
					label35.Hide();
					tCurrUserNote.Show();
				}
				// Transaction Elapsed Time
				if (currTrans.SaveTimestamp != DateTime.MinValue &&
					currTrans.SaveTimestamp != null &&
					currTrans.StartTimestamp != DateTime.MinValue &&
					currTrans.StartTimestamp != null)
				{
					TimeSpan ts = currTrans.SaveTimestamp.Subtract(currTrans.StartTimestamp);
					lElapsedTime.Text = ts.TotalSeconds.ToString() + " seconds";
					label39.Show();
					lStartTimestamp.Text = currTrans.StartTimestamp.ToString("M/d/yy hh:mm:ss");
					lStartTimestamp.Show();
					label47.Show();
					lSaveTimestamp.Text = currTrans.SaveTimestamp.ToString("M/d/yy hh:mm:ss");
					lSaveTimestamp.Show();
				}
				else
				{
					lElapsedTime.Text = "(no Data)";
					label39.Hide();
					lStartTimestamp.Hide();
					label47.Hide();
					lSaveTimestamp.Hide();
				}
			}
		}

		private void ultraLabl35_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}
	}


}
