using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VWA4Common;

namespace UserControls
{
	public partial class UCManageEachFormats : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;

		private DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;

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
		public UCManageEachFormats()
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
			ComboBoxItem cbi = (ComboBoxItem)cbWtUnits.SelectedItem;
			LoadWeightUnits();
			NewEachFormat();
		}


		public void SaveData()
		{

		}

		public bool ValidateData()
		{ return true; }


		/// 
		/// Support Methods
		/// 

		/// <summary>
		/// Load up the cbWtUnits combo box.
		/// </summary>
		/// <returns>Count of wt units loaded in cbWtUnits.</returns>
		private int LoadWeightUnits()
		{
			cbWtUnits.Items.Clear();
			string sql = @"SELECT * FROM UnitsWeight ORDER BY DisplayFullName ASC";
			DataTable wtDataTable = new DataTable();
			wtDataTable = VWA4Common.DB.Retrieve(sql);
			int n = 0;
			int si = -1;
			foreach (DataRow row in wtDataTable.Rows)
			{
				// Only load DETs that are legal within  this configuration
				int wtid = (int)row["ID"];
				// Add the item
				cbWtUnits.Items.Add(new ComboBoxItem(row["DisplayFullName"].ToString(), wtid));
				if (row["UniqueName"].ToString() == "Pound") si = n;
				n++;
			}
			// Initialize to no selection
			cbWtUnits.SelectedIndex = si;
			return cbWtUnits.Items.Count;
		}

		private void dbDetector_UserLogin(object sender, LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Waste Data")))
				CloseTaskSheet();
		}
		private void CloseTaskSheet()
		{
			commonEvents.TaskSheetKey = "dashboard";
		}


		//*******
		private void ChooseFood_Click(object sender, EventArgs e)
		{
			frmAllTypesPicker frmat = new frmAllTypesPicker("food",	"Choose Food Type");
			if (frmat.ShowDialog() == DialogResult.OK)
			{
				lFoodEach_TypeID.Text = frmat.TypeID;
				lFoodEach_TypeName.Text = frmat.TypeName;
			}
		}

		private void ucTrackercb_TrackerChanged(object sender, UCTrackerPicker.TrackerEventArgs e)
		{
		}

		private void bNew_Click(object sender, EventArgs e)
		{
			NewEachFormat();
		}

		private void NewEachFormat()
		{
			txtEachName.Text = "(Enter name here)";
			lFoodEach_TypeID.Text = "";
			lFoodEach_TypeName.Text = "";
			LoadWeightUnits();
			ceWtMultiplier.Value = 1;
			ceEachQuantity.Value = 1;
			txtDescription.Text = "";
			bSave.Enabled = false;
		}

		private bool ReadytoSave()
		{
			if ((txtEachName.Text != "(Enter name here)")
				&& (lFoodEach_TypeID.Text != "")
				&& (cbWtUnits.SelectedIndex >= 0)
				&& (ceWtMultiplier.Value > 0)
				&& (ceEachQuantity.Value > 0)) return true;
			return false;
		}

		private void bOpen_Click(object sender, EventArgs e)
		{
			OpenEachFormat();
		}
		
		private void OpenEachFormat()
		{
			frmEachFormatPicker frme = new frmEachFormatPicker("",true);
			if (frme.ShowDialog() == DialogResult.OK)
			{
				string selectedeachformatname = "";
				string foodtypename = "";
				decimal eachquantity = 0;
				decimal wtmultiplier = 0;
				int unitswtid = 0;
				int order = 0;
				string description = "";
				string foodtypeid = "";
				VWA4Common.GlobalSettings.GetEachFormatDataFromID(int.Parse(frme.EachFormatID),
					out selectedeachformatname, out eachquantity, out wtmultiplier, out unitswtid,
					out order, out description, out foodtypeid);
				txtEachName.Text = selectedeachformatname;
				lFoodEach_TypeID.Text = foodtypeid;
				if (VWA4Common.GlobalSettings.GetTypeNameFromTypeID(
					"food", foodtypeid, out foodtypename)) lFoodEach_TypeName.Text = foodtypename;
				ceWtMultiplier.Value = wtmultiplier;
				ceEachQuantity.Value = eachquantity;
				txtDescription.Text = description;
				SetIndexforWtUnitsComboBox(unitswtid);
				bSave.Enabled = false;
			}
		}

		private bool SetIndexforWtUnitsComboBox(int unitswtid)
		{
			ComboBoxItem cbi = (ComboBoxItem)cbWtUnits.SelectedItem;
			for (int i = 0; i < cbWtUnits.Items.Count; i++)
			{
				cbi = (ComboBoxItem) cbWtUnits.Items[i];
				if (cbi.ID == unitswtid)
				{
					// This is the one
					cbWtUnits.SelectedIndex = i;
					return true;
				}
			}
			cbWtUnits.SelectedIndex = 0;
			return true;
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			SaveEachFormat();
			NewEachFormat();
		}

		private void SaveEachFormat()
		{
			VWA4Common.DB.Insert("INSERT INTO EachFormats (FoodTypeID, EachFormatName, EachQuantity, WtMultiplier, " +
				" UnitsWtID, SortOrder, Description) VALUES( '" +
				lFoodEach_TypeID.Text + "', '" +
				txtEachName.Text + "', " +
				ceEachQuantity.Value.ToString() + ", " +
				ceWtMultiplier.Value.ToString() + ", " +
				((ComboBoxItem)cbWtUnits.Items[cbWtUnits.SelectedIndex]).ID.ToString() + ", 0, '" +
				txtDescription.Text + "'" +
				 ")");

		}

		private void txtEachName_TextChanged(object sender, EventArgs e)
		{
			bSave.Enabled = ReadytoSave();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

	
	
	
	
	}
}
