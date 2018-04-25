using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Infragistics.Documents.Report;
using Infragistics.Documents.Report.Text;
using System.Globalization;

namespace UserControls
{/*
    internal class extendedComboBox : ComboBox
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            // catch WM_KEYDOWN with TAB
            if (msg.Msg == 0x0100 && msg.WParam.ToInt32() == 9)
            {
                UltraGrid grid = ((UCViewWeights)this.Parent).gridViewWaste;

                grid.Focus();

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    grid.PerformAction(UltraGridAction.PrevCellByTab);
                else
                    grid.PerformAction(UltraGridAction.NextCellByTab);

                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Extended datetime picker which handles TAB key
    /// </summary>
    internal class extendedDateTimePicker : DateTimePicker
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            // catch WM_KEYDOWN with TAB
            if (msg.Msg == 0x0100 && msg.WParam.ToInt32() == 9)
            {
                UltraGrid grid = ((UCViewWeights)this.Parent).gridViewWaste;

                grid.Focus();

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    grid.PerformAction(UltraGridAction.PrevCellByTab);
                else
                    grid.PerformAction(UltraGridAction.NextCellByTab);

                return true;
            }

            return false;
        }
    }

    */
    public partial class UCViewWeights : UserControl, IVWAUserControlBase
    {
        public UCViewWeights()
            : this(DisplayMode.Weights)
        {
        }
        public UCViewWeights(bool isProgress)
            : this(DisplayMode.Weights)
        {
            _IsShowProgress = isProgress;
        }
        public UCViewWeights(DisplayMode mode)
        {
            this._Mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case DisplayMode.ErrorProduced: label1.Text = "View Errors in Produced data";
                    break;
                case DisplayMode.ErrorWeights: label1.Text = "View Errors in Wasted data";
                    break;
            }
        }

        private VWAWeights m_VWAWeights;
        private WeightsData m_VWAWeightsData;
        private string _ConfigReportName;
        private int _ConfigReportID = -1;
        private bool _IsSheet = false;
        public int ConfigReportID
        { set { _ConfigReportID = value; } }

        public string ConfigReportName
        { set { _ConfigReportName = value; } }
        private string _DBPath = "";

        public string DBPath
        {
            get { return _DBPath; }
            set { _DBPath = value; }
        }
        public enum DisplayMode { Weights, Both, Produced, ErrorWeights, ErrorProduced }
        private DisplayMode _Mode;
        private int _WeightsBand = 0;

        public DisplayMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null; // subscribe for db change
        private VWA4Common.CommonEvents commonEvents = null;

		/// <summary>
		///  BASIC CLASS
		/// </summary>

		public void Init(DateTime firstDayOfWeek) //display
		{
			AddPeriodFilter(firstDayOfWeek, firstDayOfWeek.AddDays(7));
			ShowHideColumnChooser(true);
			_ConfigReportID = -1;
			_ConfigReportName = "Default View";
			VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
			utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "viewwastedata");

			if (dbDetector == null)
			{
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
			}
			if (trackerDetector == null)
			{
				trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
				trackerDetector.TrackerConfigOutofSync += new VWA4Common.TrackerDetectorEventHandler(trackerDetector_TrackerConfigOutofSync);
				trackerDetector.WeekChanged += new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			_IsActive = true;
			_IsSheet = true;
			// do not show site chooser in case it is sheet
			cboSite.Visible = false;
			cboSite.Enabled = false;
			label2.Visible = false;
			_SiteID = VWA4Common.GlobalSettings.CurrentSiteID.ToString();
		}

		public void LoadData()
		{
			LoadWeightsData();
			ucTreeView1.Reload();
		}
		
		public void SaveData()
		{
			this.gridViewWaste.UpdateData();
			m_VWAWeights.UpdateData();

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

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			panel3.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			label1.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
		}


		void dbDetector_PathChanged(object sender, EventArgs e)
		{
			_ConfigReportID = -1;
			if (this.IsActive)
			{
				LoadWeightsData();
				ucTreeView1.Reload();
			}
		}
		void trackerDetector_WeekChanged(object sender, EventArgs e)
		{
			this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Clear();
			this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Add(
						new DateRangeFilterCondition(gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["MyTimestamp"], trackerDetector.WeekStart,
							trackerDetector.WeekStart.AddDays(7), "(Period)"));
			SetFilterLabel();
			if (this.IsActive)
			{
				VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
				utils.setTaskCheck(trackerDetector.WeekStart, true, "viewwastedata");
			}
			//SaveConfig(false);
		}
		void dbDetector_SiteChanged(object sender, EventArgs e)
		{
			SetCurrentSite();
		}
		private void SetCurrentSite()
		{
			for (int i = 1; i < cboSite.Items.Count; i++)
			{
				VWA4Common.VWACommon.MyListBoxItem item = cboSite.Items[i] as VWA4Common.VWACommon.MyListBoxItem;
				if (item.ItemData.ToString() == VWA4Common.GlobalSettings.CurrentSiteID.ToString())
				{
					cboSite.SelectedIndex = i;
					break;
				}
			}
		}

		void trackerDetector_TrackerConfigOutofSync(object sender, EventArgs e)
		{
			ucTreeView1.Reload();
			//ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
			//            "User", "0"); ;
		}
		
		
		
		
		private void UCViewWeights_Load(object sender, EventArgs e)
        {
            if (!_IsSheet)// || _IsActive) - loading twice first time 'view transaction' pressed
                LoadWeightsData();
        }
        private bool _IsShowProgress = true;
        private void LoadWeightsData()
        {
			try
			{
				// If the ActiveSync Tracker Mode is enabled, look for the Tracker connection.
				int pd_left = (this.Left + (ParentForm != null ? ParentForm.Left : this.Left)) + this.Width / 2;
				int pd_top = (this.Top + (ParentForm != null ? ParentForm.Top : this.Top)) + this.Height / 2;

				if (_IsShowProgress && _IsActive)
					VWA4Common.ProgressDialog.ShowProgressDialog("Looking for DataBase...", "", "", pd_left, pd_top);
				VWA4Common.ProgressDialog.SetLeadin("Loading data from DB");

				m_VWAWeights = new VWAWeights(_DBPath);
				if (m_VWAWeights.DBExists)
				{
					//   Clear previouse settings if any
					if (this.gridViewWaste.DisplayLayout != null)
						this.gridViewWaste.DisplayLayout.ValueLists.Clear();
					this.gridViewWaste.Rows.ColumnFilters.ClearAllFilters();
					//   Populate a value list with the names and IDs
					PopulateNamesValueLists();

					this.gridViewWaste.Text = "";
					// use datasource depending on mode
					switch (_Mode)
					{
						case DisplayMode.Both:
							_WeightsBand = 1;
							this.gridViewWaste.DataSource = m_VWAWeights.GetTransfersWeightsDetails();
							break;
						case DisplayMode.Produced:
							this.gridViewWaste.DataSource = m_VWAWeights.GetWeightsProducedDetails();
							break;
						case DisplayMode.ErrorWeights:
							this.gridViewWaste.DataSource = m_VWAWeights.GetErrorWeightsDetails();
							break;
						case DisplayMode.ErrorProduced:
							this.gridViewWaste.DataSource = m_VWAWeights.GetErrorWeightsProducedDetails();
							break;
						default:
							DataView dataView = m_VWAWeights.GetTransfersWeightsDetails().Tables["Weights"].DefaultView;
							if (_ParamName != null && _ParamName != "")
								dataView.RowFilter = _ParamName + "TypeID = '" + _ParamValue + "'";
							this.gridViewWaste.DataSource = dataView;
							break;
					}
					if (_Filter != null && _Filter != "")
					{
						string filter, filterDisplay = "";
						foreach (string name in VWA4Common.VWACommon.ReportTypes)
						{
							this.gridViewWaste.Rows.ColumnFilters[name + "TypeID"].FilterConditions.Clear();

							filter = VWA4Common.VWACommon.ExtractStringNameFilter(name, _Filter);
							if (filter != "")
							{
								filterDisplay = VWA4Common.VWACommon.ExtractDisplayNameFilter(name, _DisplayFilter);
								this.gridViewWaste.Rows.ColumnFilters[name + "TypeID"].FilterConditions.Add(
									new TypeIDFilterCondition(this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns[name + "TypeID"], filter,
									name, filterDisplay));
							}
						}

					}
					if (_Preconsumer != "")
					{
						this.gridViewWaste.Rows.ColumnFilters["IsPreconsumer"].FilterConditions.Add(
							new PreconsumerFilterCondition(this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["IsPreconsumer"], _Preconsumer,
							_PreconsumerDisplay));
					}
					if (_WasteClass != "")
					{
						this.gridViewWaste.Rows.ColumnFilters["WasteClass"].FilterConditions.Add(
							new WasteClassFilterCondition(this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteClass"], _WasteClass,
							_WasteClassDisplay));
					}

					//mila test
					if (_TransferData.Count > 0)
						this.gridViewWaste.Rows.ColumnFilters["TermID"].FilterConditions.Add(
							new TransfersFilterCondition(this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["TermID"], _TransferData));

					SetFilterLabel();


					this.ultraGridColumnChooser1.SourceGrid = gridViewWaste;
					this.gridViewWaste.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
					// Add default filters
					//if (_IsPeriodSet)
					//    this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Add(
					//        new DateRangeFilterCondition(gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["MyTimestamp"], _StartDate,
					//            _EndDate, "(Period)"));
					SetFilterLabel();
					//this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].ColumnFilters["NItems"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThanOrEqualTo, "0"); 

					//   Configure the date/time picker, hide it initially
					HideEditControls();
					this.ucTreeView1.ShowPrice = true;

					cboSite.Items.Add(new VWA4Common.VWACommon.MyListBoxItem("All", "0"));
					cboSite.SelectedIndex = 0;
					VWA4Common.VWACommon.MyListBoxItem[] list = VWA4Common.VWADBUtils.GetSites();
					if (list != null)
						for (int i = 0; i < list.Length; i++)
						{
							VWA4Common.VWACommon.MyListBoxItem item = list[i];
							cboSite.Items.Add(item);
							if (VWA4Common.VWACommon.NotNullOrEmpty(_SiteID) && item.ItemData == _SiteID)
								cboSite.SelectedIndex = i + 1;// first is for All Sites
						}
				}
				else
				{   // load empty not editable grid
					this.gridViewWaste.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
				}
			}
			catch (Exception ex)
			{
				if (_IsShowProgress && !VWA4Common.ProgressDialog.CancelPressed)
				{
					MessageBox.Show(this, "Error occurred! Error raised, with message : " + ex.Message, "VWA View Transactions File Error",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show(this, "Error Records encountered in data import.\nPlease contact LeanPath Customer Support.");
				}
			}
            finally
            {
                if(_IsShowProgress)
                    VWA4Common.ProgressDialog.CloseProgressForm();
            }
        }

        private void PopulateNamesValueLists()
        {
            DataTable ds;
            m_VWAWeightsData = new WeightsData();

            int nProgress = 1;
            
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++)*10);

            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("TermIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("TermIDNames");

                ds = m_VWAWeightsData.Terminals;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("SiteIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("SiteIDNames");

                ds = m_VWAWeightsData.Sites;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("TypeCatalogIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("TypeCatalogIDNames");

                ds = m_VWAWeightsData.TypeCatalogs;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());

                objValueList.ValueListItems.Add(null, "Master");
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("IsPreconsumerNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("IsPreconsumerNames");
                objValueList.ValueListItems.Add(0, "Intermediate");
                objValueList.ValueListItems.Add(1, "Pre consumer");
                objValueList.ValueListItems.Add(2, "Post consumer");
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("IsMemorizedNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("IsMemorizedNames");
                objValueList.ValueListItems.Add(0, "Tracker (Standard Loop)");
                objValueList.ValueListItems.Add(1, "Tracker (Memorized)");
                objValueList.ValueListItems.Add(2, "Tracker (Volume)");
                objValueList.ValueListItems.Add(3, "VWA/Manual (Weight)");
				objValueList.ValueListItems.Add(4, "VWA/Manual (Volume)");
				objValueList.ValueListItems.Add(5, "VWA/Manual (Items)");
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("FoodTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("FoodTypeIDNames");

                ds = m_VWAWeightsData.FoodType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                //objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("LossTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("LossTypeIDNames");

                ds = m_VWAWeightsData.LossType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("ContainerTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("ContainerTypeIDNames");

                ds = m_VWAWeightsData.ContainerType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("StationTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("StationTypeIDNames");

                ds = m_VWAWeightsData.StationType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("DispositionTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("DispositionTypeIDNames");

                ds = m_VWAWeightsData.DispositionType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("DaypartTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("DaypartTypeIDNames");

                ds = m_VWAWeightsData.DayPartType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("BEOTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("BEOTypeIDNames");

                ds = m_VWAWeightsData.BEOType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("UserTypeIDNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("UserTypeIDNames");

                ds = m_VWAWeightsData.UserType;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
            }
            
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("ProducedNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("ProducedNames");

                ds = m_VWAWeightsData.Produced;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
                //objValueList.ValueListItems.Add(0, " ");
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("UnitUniqueNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("UnitUniqueNames");

                ds = m_VWAWeightsData.UnitUniqueName;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
                //objValueList.ValueListItems.Add(0, " ");
            }
            if (!this.gridViewWaste.DisplayLayout.ValueLists.Exists("WasteClassNames"))
            {
                ValueList objValueList = this.gridViewWaste.DisplayLayout.ValueLists.Add("WasteClassNames");

                ds = m_VWAWeightsData.WasteClass;
                for (int i = 0; i < ds.Rows.Count; i++)
                    objValueList.ValueListItems.Add(ds.Rows[i].ItemArray[0], ds.Rows[i].ItemArray[1].ToString());
                objValueList.SortStyle = ValueListSortStyle.Ascending;
                //objValueList.ValueListItems.Add(0, " ");
            }
            if (VWA4Common.ProgressDialog.CancelPressed)
            {
                VWA4Common.ProgressDialog.CancelPressed = false;
                return;
            }
            else
                VWA4Common.ProgressDialog.SetStatus("Populating Names from DB", (nProgress++) * 10);
        }
        
        VWAGridUtils.CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new VWAGridUtils.CheckBoxOnHeader_CreationFilter();
        private void gridViewWaste_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (_ConfigReportID >=0 || VWA4Common.VWACommon.NotNullOrEmpty(_ConfigReportName))
                try
                {
                    MemoryStream stream = null;
                    if (_ConfigReportID >= 0)
                    {
                        stream = VWA4Common.VWADBUtils.LoadXMLConfig(_ConfigReportID, ref _ConfigReportName);
                    }
                    else if (VWA4Common.VWACommon.NotNullOrEmpty(_ConfigReportName))
                        stream = VWA4Common.VWADBUtils.LoadXMLConfig(_ConfigReportName, ref _ConfigReportID);
                    if (stream != null)
                    {
                        this.gridViewWaste.DisplayLayout.LoadFromXml(stream, PropertyCategories.All);
                        SetFilterLabel();
                        SetTitleChanged(_ConfigReportName, "View Waste");
						PopulateNamesValueLists();
                    }
                }
                catch (Exception ex)//don't show exception if we were not able to load
                {
                    string test = ex.Message;
                    MessageBox.Show("Config file is not correct. Applying default settings", "VWA View Waste Config");
                }
            LoadSettings(_ConfigReportID);
            this.gridViewWaste.CreationFilter = aCheckBoxOnHeader_CreationFilter;

            // disable key fields for editing
            e.Layout.Bands[_WeightsBand].Columns["ID"].CellActivation = Activation.NoEdit;
            e.Layout.Bands[_WeightsBand].Columns["TransKey"].CellActivation = Activation.ActivateOnly;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("WasteCost"))
            {
                e.Layout.Bands[_WeightsBand].Columns["WasteCost"].CellActivation = Activation.NoEdit;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteCost"].Style =
                    Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteCost"].MaskInput = "{currency:-9.2:c}";
                //this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteCost"].MaskDataMode  = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteCost"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                //this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteCost"].MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

            }
            else
            {
                e.Layout.Bands[_WeightsBand].Columns["FoodCost"].CellActivation = Activation.Disabled;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodCost"].Style =
                    Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("ProducedAmount"))
            {
                e.Layout.Bands[_WeightsBand].Columns["ProducedAmount"].CellActivation = 
                    (_Mode == DisplayMode.Produced || _Mode == DisplayMode.ErrorProduced ? Activation.AllowEdit : Activation.NoEdit);
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ProducedAmount"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("UnitaryItemWeight"))
            {
                e.Layout.Bands[_WeightsBand].Columns["UnitaryItemWeight"].CellActivation = Activation.AllowEdit;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UnitaryItemWeight"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositiveWithSpin;
                e.Layout.Bands[_WeightsBand].Columns["UnitaryItemWeight"].Header.Caption = "Unitary Item Weight";
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("WasteAmountUserEntry"))
            {
                e.Layout.Bands[_WeightsBand].Columns["WasteAmountUserEntry"].CellActivation = Activation.AllowEdit;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteAmountUserEntry"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin;
                e.Layout.Bands[_WeightsBand].Columns["WasteAmountUserEntry"].Header.Caption = "Waste Amount User Entry";
            }

            if (e.Layout.Bands[_WeightsBand].Columns.Exists("Weights.Timestamp"))
            {
                e.Layout.Bands[_WeightsBand].Columns["Weights.Timestamp"].Hidden = true;
                e.Layout.Bands[_WeightsBand].Columns["Weights.Timestamp"].ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("ErrorWeights.Timestamp"))
            {
                e.Layout.Bands[_WeightsBand].Columns["ErrorWeights.Timestamp"].Hidden = true;
                e.Layout.Bands[_WeightsBand].Columns["ErrorWeights.Timestamp"].ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("WeightsProduced.Timestamp"))
            {
                e.Layout.Bands[_WeightsBand].Columns["WeightsProduced.Timestamp"].Hidden = true;
                e.Layout.Bands[_WeightsBand].Columns["WeightsProduced.Timestamp"].ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
            }
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("ErrorWeightsProduced.Timestamp"))
{
                e.Layout.Bands[_WeightsBand].Columns["ErrorWeightsProduced.Timestamp"].Hidden = true;
                e.Layout.Bands[_WeightsBand].Columns["ErrorWeightsProduced.Timestamp"].ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
            }
            e.Layout.Bands[0].Columns["MyTimestamp"].Header.VisiblePosition = 1;

            if (e.Layout.Bands[_WeightsBand].Columns.Exists("NetWeight"))
            {
                e.Layout.Bands[_WeightsBand].Columns["NetWeight"].CellActivation = Activation.Disabled;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["NetWeight"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                e.Layout.Bands[_WeightsBand].Columns["NetWeight"].Header.Caption = "Net Weight";
                e.Layout.Bands[0].Columns["NetWeight"].Header.VisiblePosition = e.Layout.Bands[0].Columns["Weight"].Header.VisiblePosition + 1;
            }

            e.Layout.Bands[_WeightsBand].Columns["TypeCatalogID"].CellActivation = Activation.NoEdit;
            e.Layout.Bands[_WeightsBand].Columns["TypeCatalogName"].CellActivation = Activation.NoEdit;
            e.Layout.Bands[_WeightsBand].Columns["SiteID"].CellActivation = Activation.NoEdit;
            e.Layout.Bands[_WeightsBand].Columns["SiteName"].CellActivation = Activation.NoEdit;
            e.Layout.Bands[_WeightsBand].Columns["WasteClass"].CellActivation = Activation.NoEdit;
            //hide type catalogs and sites
            e.Layout.Bands[_WeightsBand].Columns["TypeCatalogID"].Hidden = true;
            e.Layout.Bands[_WeightsBand].Columns["TypeCatalogName"].Hidden = true;
            e.Layout.Bands[_WeightsBand].Columns["SiteID"].Hidden = true;
            e.Layout.Bands[_WeightsBand].Columns["SiteName"].Hidden = true;
            e.Layout.Bands[_WeightsBand].Columns["Transfers.Timestamp"].Hidden = true;

            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["Weight"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
            
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeCost"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeCost"].MaskInput = "{currency:-9.2:c}";
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeCost"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerWeight"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerCost"].Style =
            Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerCost"].MaskInput = "{currency:-9.2:c}";
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerCost"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["NItems"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositiveWithSpin;

            //   Hide the irrelevant columns
            //  e.Layout.Bands["Transfers"].Columns["TransKey"].Hidden = true;
            //	Resize the columns that we are interested in
            e.Layout.Bands[_WeightsBand].Columns["MyTimestamp"].Width = 150;
            InitValueLists();
            //if(e.Layout.Bands[_WeightsBand].Columns.Exists("IsPreconsumer"))
            //    e.Layout.Bands[_WeightsBand].Columns["IsPreconsumer"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["IsPreconsumerNames"];
            //if (e.Layout.Bands[_WeightsBand].Columns.Exists("UnitUniqueName"))
            //    e.Layout.Bands[_WeightsBand].Columns["UnitUniqueName"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["UnitUniqueNames"];
            //e.Layout.Bands[_WeightsBand].Columns["FoodTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["FoodTypeIDNames"];
            //e.Layout.Bands[_WeightsBand].Columns["FoodTypeID"].SortComparer = new MySortComparer();
            //if (e.Layout.Bands[_WeightsBand].Columns.Exists("LossTypeID"))
            //{
            //    e.Layout.Bands[_WeightsBand].Columns["LossTypeID"].SortComparer = new MySortComparer();
            //    e.Layout.Bands[_WeightsBand].Columns["LossTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["LossTypeIDNames"];
            //}
            //e.Layout.Bands[_WeightsBand].Columns["ContainerTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["ContainerTypeIDNames"];
            //e.Layout.Bands[_WeightsBand].Columns["ContainerTypeID"].SortComparer = new MySortComparer();
            //e.Layout.Bands[_WeightsBand].Columns["StationTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["StationTypeIDNames"];
            //e.Layout.Bands[_WeightsBand].Columns["StationTypeID"].SortComparer = new MySortComparer();
            //if (e.Layout.Bands[_WeightsBand].Columns.Exists("DispositionTypeID"))
            //{
            //    e.Layout.Bands[_WeightsBand].Columns["DispositionTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DispositionTypeIDNames"];
            //    e.Layout.Bands[_WeightsBand].Columns["DispositionTypeID"].SortComparer = new MySortComparer();
            //}
            //e.Layout.Bands[_WeightsBand].Columns["DaypartTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DaypartTypeIDNames"];
            //e.Layout.Bands[_WeightsBand].Columns["DaypartTypeID"].SortComparer = new MySortComparer();
            //if (e.Layout.Bands[_WeightsBand].Columns.Exists("BEOTypeID"))
            //{
            //    e.Layout.Bands[_WeightsBand].Columns["BEOTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["BEOTypeIDNames"];
            //    e.Layout.Bands[_WeightsBand].Columns["BEOTypeID"].SortComparer = new MySortComparer();
            //}
            //else
            //{
            //    e.Layout.Bands[_WeightsBand].Columns["EOTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["BEOTypeIDNames"];
            //    e.Layout.Bands[_WeightsBand].Columns["EOTypeID"].SortComparer = new MySortComparer();
            //}
            //e.Layout.Bands[_WeightsBand].Columns["UserTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["UserTypeIDNames"];
            //e.Layout.Bands[_WeightsBand].Columns["UserTypeID"].SortComparer = new MySortComparer();
            //e.Layout.Bands[_WeightsBand].Columns["IsMemorized"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["IsMemorizedNames"];
            //if (e.Layout.Bands[_WeightsBand].Columns.Exists("ProducedID"))
            //    e.Layout.Bands[_WeightsBand].Columns["ProducedID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["ProducedNames"];
            //e.Layout.Bands[_WeightsBand].Columns["TermID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TermIDNames"];


            //this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].Style =
            //    Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["TransKey"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("LossTypeID"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["LossTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["StationTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("DispositionTypeID"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DispositionTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DaypartTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("BEOTypeID"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["BEOTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            else
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["EOTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UserTypeID"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;


            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].CellActivation = Activation.ActivateOnly;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("LossTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["LossTypeID"].CellActivation = Activation.ActivateOnly;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["LossTypeID"].EditorControl = ultraTextEditor1;
                e.Layout.Bands[_WeightsBand].Columns["LossTypeID"].Header.Caption = "Loss";
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerTypeID"].CellActivation = Activation.ActivateOnly;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["StationTypeID"].CellActivation = Activation.ActivateOnly;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("DispositionTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DispositionTypeID"].CellActivation = Activation.ActivateOnly;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DispositionTypeID"].EditorControl = ultraTextEditor1;
                e.Layout.Bands[_WeightsBand].Columns["DispositionTypeID"].Header.Caption = "Disposition";
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DaypartTypeID"].CellActivation = Activation.ActivateOnly;
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("BEOTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["BEOTypeID"].CellActivation = Activation.ActivateOnly;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["BEOTypeID"].EditorControl = ultraTextEditor1;
                e.Layout.Bands[_WeightsBand].Columns["BEOTypeID"].Header.Caption = "Event Order";
            }
            else
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["EOTypeID"].CellActivation = Activation.ActivateOnly;
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["EOTypeID"].EditorControl = ultraTextEditor1;
                e.Layout.Bands[_WeightsBand].Columns["EOTypeID"].Header.Caption = "Event Order";
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UserTypeID"].CellActivation = Activation.ActivateOnly;

            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["TransKey"].EditorControl = ultraTransferEditor;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].EditorControl = ultraTextEditor1;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerTypeID"].EditorControl = ultraTextEditor1;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["StationTypeID"].EditorControl = ultraTextEditor1;
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DaypartTypeID"].EditorControl = ultraTextEditor1;
           
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UserTypeID"].EditorControl = ultraTextEditor1;

            //   Make the style of these two columns Edit so that the value list dropdown arrow
            //   doesn't appear, since we are displaying a custom edit control rather than use the
            //   ValueList
            //e.Layout.Bands["Transfers"].Columns["FoodTypeID"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //   We don't want to see the time portion of the date in the
            //   date columns, and we don't want to see the date portion
            //   in the time columns, so let's use the column's Format property
            //   to filter out the portions of the DateTime object that we don't want
            e.Layout.Bands[_WeightsBand].Columns["MyTimestamp"].Format = "MM/dd/yy HH:mm:ss tt";
            e.Layout.Bands[_WeightsBand].Columns["MyTimestamp"].Header.Caption = "Timestamp";
            // init colum headers
            e.Layout.Bands[_WeightsBand].Columns["TransKey"].Header.Caption = "Transfer Key";
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("IsPreconsumer"))
                e.Layout.Bands[_WeightsBand].Columns["IsPreconsumer"].Header.Caption = "Waste Type";
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("WasteCost"))
                e.Layout.Bands[_WeightsBand].Columns["WasteCost"].Header.Caption = "Food Value";
            else
                e.Layout.Bands[_WeightsBand].Columns["FoodCost"].Header.Caption = "Food Cost";
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("TotalWaste"))
            {
                e.Layout.Bands[_WeightsBand].Columns["TotalWaste"].Header.Caption = "Total Waste";
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["TotalWaste"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
            }
            e.Layout.Bands[_WeightsBand].Columns["FoodTypeID"].Header.Caption = "Food";
            e.Layout.Bands[_WeightsBand].Columns["FoodTypeCost"].Header.Caption = "Food Cost";
            
            e.Layout.Bands[_WeightsBand].Columns["ContainerTypeID"].Header.Caption = "Container";
            e.Layout.Bands[_WeightsBand].Columns["ContainerWeight"].Header.Caption = "Container Weight";
            e.Layout.Bands[_WeightsBand].Columns["ContainerCost"].Header.Caption = "Container Cost";
            e.Layout.Bands[_WeightsBand].Columns["FoodTypeCost"].Header.Caption = "Food Cost";
            e.Layout.Bands[_WeightsBand].Columns["StationTypeID"].Header.Caption = "Station";
            e.Layout.Bands[_WeightsBand].Columns["DaypartTypeID"].Header.Caption = "DayPart";
            e.Layout.Bands[_WeightsBand].Columns["UserTypeID"].Header.Caption = "Employee Name";
            e.Layout.Bands[_WeightsBand].Columns["UserQuestion"].Header.Caption = "User Question";
            e.Layout.Bands[_WeightsBand].Columns["NItems"].Header.Caption = "# of Items";
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("ProducedID"))
                e.Layout.Bands[_WeightsBand].Columns["ProducedID"].Header.Caption = "Lot #";
            e.Layout.Bands[_WeightsBand].Columns["UnitUniqueName"].Header.Caption = "Unit of Measure";
            if (e.Layout.Bands[_WeightsBand].Columns.Exists("UnitWeight"))
                e.Layout.Bands[_WeightsBand].Columns["UnitUniqueName"].Header.Caption = "Unit Weight";
            e.Layout.Bands[_WeightsBand].Columns["TermID"].Header.Caption = "Terminal Name";

            e.Layout.Bands[_WeightsBand].Columns["WasteClass"].Header.Caption = "Allowed Waste Classes";

            // You can control the appearance of the separator using the SpecialRowSeparatorAppearance
            // property.
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199);

            e.Layout.Override.RowAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent;

            //	use the same appearance for alternate rows
            e.Layout.Override.RowAlternateAppearance = e.Layout.Override.RowAppearance;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            // Do not uncomment following line - it causes RED CROSS Infragistics bug!!!
            //e.Layout.Override.CellAppearance.AlphaLevel = 150;

            e.Layout.Override.HeaderAppearance.AlphaLevel = 150;
            e.Layout.Override.HeaderAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel;

            // FILTER ROW FUNCTIONALITY RELATED ULTRAGRID SETTINGS
            // ----------------------------------------------------------------------------------
            // Enable the the filter row user interface by setting the FilterUIType to FilterRow.
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            // FilterEvaluationTrigger specifies when UltraGrid applies the filter criteria typed 
            // into a filter row. Default is OnCellValueChange which will cause the UltraGrid to
            // re-filter the data as soon as the user modifies the value of a filter cell.
            e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange;

            // By default the UltraGrid selects the type of the filter operand editor based on
            // the column's DataType. For DateTime and boolean columns it uses the column's editors.
            // For other column types it uses the Combo. You can explicitly specify the operand
            // editor style by setting the FilterOperandStyle on the override or the individual
            // columns.
            //e.Layout.Override.FilterOperandStyle = FilterOperandStyle.Combo;

            // By default UltraGrid displays user interface for selecting the filter operator. 
            // You can set the FilterOperatorLocation to hide this user interface. This
            // property is available on column as well so it can be controlled on a per column
            // basis. Default is WithOperand. This property is exposed off the column as well.
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;

            // By default the UltraGrid uses StartsWith as the filter operator. You use
            // the FilterOperatorDefaultValue property to specify a different filter operator
            // to use. This is the default or the initial filter operator value of the cells
            // in filter row. If filter operator user interface is enabled (FilterOperatorLocation
            // is not set to None) then that ui will be initialized to the value of this
            // property. The user can then change the operator as he/she chooses via the operator
            // drop down.
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals;

            // FilterOperatorDropDownItems property can be used to control the options provided
            // to the user for selecting the filter operator. By default UltraGrid bases 
            // what operator options to provide on the column's data type. This property is
            // avaibale on the column as well.
            e.Layout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Default;

            // By default UltraGrid displays a clear button in each cell of the filter row
            // as well as in the row selector of the filter row. When the user clicks this
            // button the associated filter criteria is cleared. You can use the 
            // FilterClearButtonLocation property to control if and where the filter clear
            // buttons are displayed.
            e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell;

            // Appearance of the filter row can be controlled using the FilterRowAppearance proeprty.
            e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow;

            // You can use the FilterRowPrompt to display a prompt in the filter row. By default
            // UltraGrid does not display any prompt in the filter row.
            e.Layout.Override.FilterRowPrompt = "Click here to filter data...";

            // You can use the FilterRowPromptAppearance to change the appearance of the prompt.
            // By default the prompt is transparent and uses the same fore color as the filter row.
            // You can make it non-transparent by setting the appearance' BackColorAlpha property 
            // or by setting the BackColor to a desired value.
            e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque;

            // for smart datetime filters
            e.Layout.Bands[_WeightsBand].Columns["MyTimestamp"].FilterOperandStyle = FilterOperandStyle.DropDownList;
            e.Layout.Bands[_WeightsBand].Columns["MyTimestamp"].FilterOperatorLocation = FilterOperatorLocation.Hidden;

            // By default the prompt is spread across multiple cells if it's bigger than the
            // first cell. You can confine the prompt to a particular cell by setting the
            // SpecialRowPromptField property off the band to the key of a column.
            //e.Layout.Bands[_WeightsBand].SpecialRowPromptField = e.Layout.Bands[_WeightsBand].Columns[0].Key;

            // Display a separator between the filter row other rows. SpecialRowSeparator property 
            // can be used to display separators between various 'special' rows, including for the
            // filter row. This property is a flagged enum property so it can take multiple values.
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow;

            // ----------------------------------------------------------------------------------
            // Make editable depending on program version
            //e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnBottom;
            e.Layout.Override.AllowDelete =  VWA4Common.VWACommon.IsAllowEditVersion() ? DefaultableBoolean.True : DefaultableBoolean.False;
            e.Layout.Override.AllowUpdate = VWA4Common.VWACommon.IsAllowEditVersion() ? DefaultableBoolean.True : DefaultableBoolean.False;
            // sorting properties
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // display cell text on multiple lines
            e.Layout.Override.RowSizing = RowSizing.AutoFree;
            e.Layout.Override.CellMultiLine = DefaultableBoolean.True;
            // turn row selectors on for band 0
            e.Layout.Bands[_WeightsBand].Override.RowSelectors = DefaultableBoolean.True;

            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Summaries.Count == 0) // if summary not added yet
            {
                /// SUMMARY Columns
                SummarySettings summary;

                summary = this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Summaries.Add("TimestampFrom",
                        SummaryType.Minimum,
                        this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["MyTimestamp"],
                        SummaryPosition.UseSummaryPositionColumn);
                summary.DisplayFormat = "From: {0:MM/dd/yy HH:mm:ss tt}";
                summary = this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Summaries.Add("TimestampTo",
                        SummaryType.Maximum,
                        this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["MyTimestamp"],
                        SummaryPosition.UseSummaryPositionColumn);
                summary.DisplayFormat = "To:      {0:MM/dd/yy HH:mm:ss tt}";
                // Set the tooltip on the summary settings object.
                summary.ToolTipText = string.Format("Minimum {0}.", summary.SourceColumn.Header.Caption);
                this.gridViewWaste.Rows.SummaryValues["TimestampFrom"].ToolTipText = string.Format("Minimum {0}.", summary.SourceColumn.Header.Caption);
                // Set the tooltip on the summary settings object.
                summary.ToolTipText = string.Format("Maximum {0}.", summary.SourceColumn.Header.Caption);
                this.gridViewWaste.Rows.SummaryValues["TimestampTo"].ToolTipText = string.Format("Maximum {0}.", summary.SourceColumn.Header.Caption);
                string cost = "FoodCost";
                if (e.Layout.Bands[_WeightsBand].Columns.Exists("WasteCost"))
                    cost = "WasteCost";

                string[] cost_cols;
                if (e.Layout.Bands[_WeightsBand].Columns.Exists("TotalWaste"))
                    cost_cols= new string[] { "Weight", "NetWeight", cost, "TotalWaste", "ContainerWeight", "NItems", "ProducedAmount" };
                else
                    cost_cols = new string[] { "Weight", "NetWeight", cost, "ContainerWeight", "NItems", "ProducedAmount" };
                foreach (string str in cost_cols)
                {
                    summary =
                        this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Summaries.Add(str,
                            SummaryType.Sum,
                            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns[str],
                            SummaryPosition.UseSummaryPositionColumn);

                    // Set the tooltip on the summary settings object.
                    summary.ToolTipText = string.Format("Sum of {0}.", summary.SourceColumn.Header.Caption);
                    this.gridViewWaste.Rows.SummaryValues[str].ToolTipText = string.Format("Sum of {0}s.", summary.SourceColumn.Header.Caption);
                    if (str == "WasteCost" || str == "TotalWaste" || str == "FoodCost")
                        summary.DisplayFormat = "{0:$ #######.00}";
                    else if (str == "NItems")
                        summary.DisplayFormat = "{0:#######0}";
                    else
                        summary.DisplayFormat = "{0:#######.00}";
                }
                foreach (string str in new string[] { "FoodTypeCost", "ContainerCost" })
                {
                    summary =
                        this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Summaries.Add(str,
                            SummaryType.Average,
                            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns[str],
                            SummaryPosition.UseSummaryPositionColumn);

                    // Set the tooltip on the summary settings object.
                    summary.ToolTipText = string.Format("Average {0}.", summary.SourceColumn.Header.Caption);
                    this.gridViewWaste.Rows.SummaryValues[str].ToolTipText = string.Format("Average {0}.", summary.SourceColumn.Header.Caption);
                    summary.DisplayFormat = "{0:$ #######.00}";
                }
            }
            this.gridViewWaste.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.gridViewWaste.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
          

            // Set tool tips on headers.
            foreach (UltraGridColumn col in this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns)
            {
                col.Header.ToolTipText = string.Format("Column {0}: Click to sort, right-click for edit", col.Header.Caption);
            }

            // Set tool tips on rows.
            foreach (UltraGridRow row in this.gridViewWaste.Rows)
            {
                row.ToolTipText = string.Format("Row number: {0}", row.Index + 1);
            }


            // init TRANSFER's bands if used
            if (e.Layout.Bands[_WeightsBand].Key.Equals("Transfers"))
            {
                e.Layout.Bands["Transfers"].Columns["TransKey"].CellActivation = Activation.Disabled;

                //value editors
                Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit editor = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
                editor.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
                editor.InputMask = @"4\.nn\.nn";
                editor.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                editor.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                editor.DisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                e.Layout.Bands["Transfers"].Columns["TrackerSWVersion"].EditorControl = editor;
                // Set the mask modes. This only effects columns that use EditorWithMask or derived editors.
                e.Layout.Bands["Transfers"].Columns["TrackerSWVersion"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;

                e.Layout.Bands["Transfers"].Columns["Timestamp"].Width = 150;
                e.Layout.Bands["Transfers"].Columns["Timestamp"].Format = "MM/dd/yyyy HH:mm:ss";

                //   The FoodTypeID and LossTypeID
                //   columns should display the name, not the ID.
                //   We can use a ValueList to accomplish this
                e.Layout.Bands["Transfers"].Columns["TermID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TermIDNames"];
                e.Layout.Bands["Transfers"].Columns["SiteID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["SiteIDNames"];
                e.Layout.Bands["Transfers"].Columns["TypeCatalogID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TypeCatalogIDNames"];

                e.Layout.Bands["Transfers"].Override.RowSelectors = DefaultableBoolean.True;
                // for smart datetime filters
                e.Layout.Bands["Transfers"].Columns["Timestamp"].FilterOperandStyle = FilterOperandStyle.DropDownList;
                e.Layout.Bands["Transfers"].Columns["Timestamp"].FilterOperatorLocation = FilterOperatorLocation.Hidden;
            }
            ShowHideColumnChooser(true);

            // Add default filters
            if (_IsPeriodSet)
                this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Add(
                    new DateRangeFilterCondition(gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["MyTimestamp"], _StartDate,
                        _EndDate, "(Period)"));
            SetFilterLabel();

            _ConfigReportID = -1;
        }

        private void InitValueLists()
        {
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("IsPreconsumer"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["IsPreconsumer"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["IsPreconsumerNames"];
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("UnitUniqueName"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UnitUniqueName"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["UnitUniqueNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["FoodTypeIDNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["FoodTypeID"].SortComparer = new MySortComparer();
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("LossTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["LossTypeID"].SortComparer = new MySortComparer();
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["LossTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["LossTypeIDNames"];
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["ContainerTypeIDNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ContainerTypeID"].SortComparer = new MySortComparer();
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["StationTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["StationTypeIDNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["StationTypeID"].SortComparer = new MySortComparer();
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("DispositionTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DispositionTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DispositionTypeIDNames"];
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DispositionTypeID"].SortComparer = new MySortComparer();
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DaypartTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["DaypartTypeIDNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["DaypartTypeID"].SortComparer = new MySortComparer();
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("BEOTypeID"))
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["BEOTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["BEOTypeIDNames"];
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["BEOTypeID"].SortComparer = new MySortComparer();
            }
            else
            {
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["EOTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["BEOTypeIDNames"];
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["EOTypeID"].SortComparer = new MySortComparer();
            }
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UserTypeID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["UserTypeIDNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["UserTypeID"].SortComparer = new MySortComparer();
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["IsMemorized"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["IsMemorizedNames"];
            if (this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns.Exists("ProducedID"))
                this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["ProducedID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["ProducedNames"];
            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["TermID"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["TermIDNames"];

            this.gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns["WasteClass"].ValueList = this.gridViewWaste.DisplayLayout.ValueLists["WasteClassNames"];

        }
        private void gridViewWaste_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            HideEditControls();
        }

        private void HideEditControls()
        {
            this.dtpStamp.Visible = false;
            this.ucTreeView1.Visible = false;
            this.ultraTextEditor1.Visible = false;
            this.ultraTransferEditor.Visible = false;
            this.ucEditTransfer1.Visible = false;
        }

        private void gridViewWaste_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterColRegionScroll(object sender, ColScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterColRegionSize(object sender, ColScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowRegionScroll(object sender, RowScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowRegionSize(object sender, RowScrollRegionEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_AfterRowResize(object sender, RowEventArgs e)
        {
            this.HideEditControls();
        }

        private void gridViewWaste_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell    
            if (objCell.IsDataCell)
            {
                CellUIElement objCellUIElement = (CellUIElement)objCell.GetUIElement(this.gridViewWaste.ActiveRowScrollRegion, this.gridViewWaste.ActiveColScrollRegion);
                if (objCellUIElement == null) { return; }
                //   Get the size and location of the cell    
                int left = objCellUIElement.RectInsideBorders.Location.X + this.gridViewWaste.Location.X;
                int top = objCellUIElement.RectInsideBorders.Location.Y + this.gridViewWaste.Location.Y;
                int width = objCellUIElement.RectInsideBorders.Width;
                int height = objCellUIElement.RectInsideBorders.Height;
                //   The edit control we will use depends on which column we are editing    
                //   The values of the identity fields are not very useful to the end user.    
                //   Let's display the name in these columns instead,    
                //   using the intrisic ComboBox control    
                if (objCell.Column.Key == "MyTimestamp")
                {
                    //   Set the date picker's size and location equal to the active cell's size and location        
                    this.dtpStamp.SetBounds(left, top + 5, dtpStamp.Width, dtpStamp.Height);
                    //   Set the value        
                    DateTime temp = DateTime.Parse(objCell.Value.ToString());
                    this.dtpStamp.Value = temp;
                    this.dtpStamp.Visible = true;
                    this.dtpStamp.Focus();
                    this.dtpStamp.BringToFront();
                } 
                else if (Regex.IsMatch(objCell.Column.Key, "TypeID"))
                {
                    //   Set the date picker's size and location equal to the active cell's size and location        
                    this.ucTreeView1.SetBounds(left, top, ucTreeView1.Width, ucTreeView1.Height);
                    //   Set the value  
                    this.ucTreeView1.InitTreeView( VWA4Common.VWADBUtils.TypeCatalog(objCell.Row.Cells["TermID"].Value.ToString()).ItemData,
                        Regex.Replace(objCell.Column.Key, "TypeID", ""),
                        objCell.Value.ToString());
                    //this.ucTreeView1.Visible = true;
                    //this.ucTreeView1.Focus();
                    //this.ucTreeView1.BringToFront();
                }
                else if (objCell.Column.Key == "TransKey")
                {
                    //   Set the date picker's size and location equal to the active cell's size and location        
                    this.ucEditTransfer1.SetBounds(left, top, ucEditTransfer1.Width, ucEditTransfer1.Height);
                    //   Set the value  
                    ImportTransfer transfer = new ImportTransfer();
                    transfer.DBLoad(int.Parse(objCell.Value.ToString()));
                    this.ucEditTransfer1.Init(transfer);
                    //this.ucEditTransfer1.Visible = true;
                    //this.ucEditTransfer1.Focus();
                    //this.ucEditTransfer1.BringToFront();
                }
            }
        }

        private void dtpStamp_Leave(object sender, EventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (objCell.Column.Key == "MyTimestamp" && VWA4Common.VWACommon.IsAllowEditVersion())
            {
                objCell.Value = dtpStamp.Value;
            }
        }
        //private void ucTreeView1_Leave(object sender, EventArgs e)
        //{
        //    ////   Use the BeforeEnterEditMode event to position the edit controls    
        //    //UltraGridCell objCell = this.gridViewWaste.ActiveCell;
        //    ////   This should be impossible, but its good practice to check    
        //    ////   to make sure there is an active cell before continuing    
        //    //if (objCell == null) { return; }
        //    //if (VWA4Common.VWACommon.IsAllowEditVersion() && Regex.IsMatch(objCell.Column.Key, "TypeID") && ucTreeView1.ID != null && ucTreeView1.ID != "")
        //    //{
        //    //    objCell.Value = ucTreeView1.ID;
        //    //}
        //}
        private void dtpStamp_EnterPressed(object sender, EventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (objCell.Column.Key == "MyTimestamp" && VWA4Common.VWACommon.IsAllowEditVersion())
            {
                objCell.Value = dtpStamp.Value;
            }
            dtpStamp.Visible = false;
            dtpStamp.SendToBack();
            this.gridViewWaste.Focus();
            this.gridViewWaste.ActiveCell.Selected = true;

        }
        private void dtpStamp_ValueChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (objCell.Column.Key == "MyTimestamp" && VWA4Common.VWACommon.IsAllowEditVersion())
            {
                objCell.Value = e.Date;
            }
            dtpStamp.Visible = false;
            dtpStamp.SendToBack();
            this.gridViewWaste.Focus();
            this.gridViewWaste.ActiveCell.Selected = true;

        }

        public void CreateFilter()
        {
            Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog c = new Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog(this.gridViewWaste);
            if (this.gridViewWaste.ActiveCell == null && this.gridViewWaste.Rows[0] != null)
                this.gridViewWaste.ActiveCell = this.gridViewWaste.Rows[0].Cells[0]; //default column
            else
                return;
            Infragistics.Win.UltraWinGrid.UltraGridColumn column = this.gridViewWaste.ActiveCell.Column;
            Infragistics.Win.UltraWinGrid.ColumnFilter cf = this.gridViewWaste.Rows.ColumnFilters[column];
            c.ShowDialog(cf, this.gridViewWaste.Rows);
        }

        public void ClearFilter()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand band in this.gridViewWaste.DisplayLayout.Bands)
            {
                // since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
                // will clear the filters
                band.ColumnFilters.ClearAllFilters();
            }
        }

        private void gridViewWaste_CellChange(object sender, CellEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 
            if (objCell.IsDataCell && objCell.Band.Key == "Weights") // change cost for weights
            {
                if (objCell.Column.Key == "LossTypeID")
                {
                    DataTable ds = m_VWAWeightsData.LossType;
                    DataColumn[] keys = new DataColumn[1];
                    keys[0] = ds.Columns["TypeID"];

                    ds.PrimaryKey = keys;
                    DataRow foundRow = ds.Rows.Find(objCell.Row.Cells["LossTypeID"].Value.ToString());
                    objCell.Row.Cells["OverproductionFlag"].Value = foundRow["OverproductionFlag"];
                    objCell.Row.Cells["TrimWasteFlag"].Value = foundRow["TrimWasteFlag"];
                    objCell.Row.Cells["HandlingFlag"].Value = foundRow["HandlingFlag"];
                }
                else
                {
                    WeightStruct weight = new WeightStruct();
                    int nID = int.Parse(objCell.Row.Cells["ID"].Value.ToString());

                    //   The edit control we will use depends on which column we are editing    
                    //   The values of the identity fields are not very useful to the end user.    
                    //   Let's display the name in these columns instead,    
                    //   using the intrisic ComboBox control    
                    if (objCell.Column.Key == "FoodTypeID")
                    {
                        weight = m_VWAWeightsData.GetFoodCost(nID, objCell.Column.ValueList.GetValue(objCell.Column.ValueList.SelectedItemIndex).ToString());
                        if (weight != null)
                        {
                            objCell.Row.Cells["FoodTypeCost"].SetValue(weight.FoodCost, true);
                            DataTable ds = m_VWAWeightsData.FoodType;
                            DataColumn[] keys = new DataColumn[1];
                            keys[0] = ds.Columns["TypeID"];

                            ds.PrimaryKey = keys;
                            DataRow foundRow = ds.Rows.Find(objCell.Row.Cells["FoodID"].Value.ToString());
                            objCell.Row.Cells["WasteClass"].Value = foundRow["WasteClass"];
                        }
                        else // wrong FoodTypeID
                        {
                            MessageBox.Show("This Food Type is not allowded for this Type Catalog", "WVA Error");
                            objCell.Selected = true;
                            return; // let user to change food type
                        }
                    }
                    else
                        if (objCell.Column.Key == "ContainerTypeID")
                        {
                            weight = m_VWAWeightsData.GetContainerCost(nID, objCell.Column.ValueList.GetValue(objCell.Column.ValueList.SelectedItemIndex).ToString());
                            if (weight != null)
                            {
                                objCell.Row.Cells["ContainerCost"].SetValue(weight.ContainerCost, true);
                                objCell.Row.Cells["ContainerWeight"].SetValue(weight.ContainerWeight, true);
                            }
                            else // wrong ContainerTypeID
                            {
                                MessageBox.Show("This Container Type is not allowded for this Type Catalog", "WVA Error");
                                objCell.Selected = true;
                                return; // let user to change food type
                            }
                        }

                    int nItems = int.Parse(objCell.Row.Cells["NItems"].Value.ToString());
                    string discount = "1";
                    if (objCell.Row.Cells.Exists("FoodTypeDiscount"))
                        discount = objCell.Row.Cells["FoodTypeDiscount"].Value.ToString();
                    weight = new WeightStruct(objCell.Row.Cells["FoodTypeCost"].Value.ToString(), discount, 
                        objCell.Row.Cells["Weight"].Value.ToString(), objCell.Row.Cells["ContainerCost"].Value.ToString(),
                        objCell.Row.Cells["ContainerWeight"].Value.ToString(), objCell.Row.Cells["NItems"].Value.ToString());

                    if ((objCell.Column.Key == "FoodTypeCost") || (objCell.Column.Key == "FoodTypeDiscount") || 
                        (objCell.Column.Key == "Weight") || (objCell.Column.Key == "ContainerWeight")
                        || (objCell.Column.Key == "ContainerCost") || (objCell.Column.Key == "NItems"))
                        try
                        {
                            string str = objCell.Text;
                            // remove mask symbols to retrieve editing values
                            str = Regex.Match(str, @"(\d+\,?\d+\.?\d*|\d+\.?\d*|\.\d+)").ToString();
                            if (objCell.Column.Key == "FoodTypeCost")
                                weight.FoodCost = decimal.Parse(str);
                            if (objCell.Column.Key == "Weight")
                                weight.Weight = decimal.Parse(str);
                            if (objCell.Column.Key == "ContainerCost")
                                weight.ContainerCost = decimal.Parse(str);
                            if (objCell.Column.Key == "ContainerWeight")
                                weight.ContainerWeight = decimal.Parse(str);
                            if (objCell.Column.Key == "NItems")
                            {
                                str = Regex.Match(str, @"(\d+)").ToString();
                                weight.NItems = int.Parse(str);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    if ((objCell.Column.Key == "FoodTypeID") || (objCell.Column.Key == "FoodTypeCost") || (objCell.Column.Key == "FoodTypeDiscount") 
                        || (objCell.Column.Key == "Weight")
                        || (objCell.Column.Key == "ContainerTypeID") || (objCell.Column.Key == "ContainerWeight")
                        || (objCell.Column.Key == "ContainerCost") || (objCell.Column.Key == "NItems"))
                    {
                        if(objCell.Row.Cells.Exists("WasteCost"))
                            objCell.Row.Cells["WasteCost"].SetValue(weight.WasteCost, true);
                        else
                            objCell.Row.Cells["FoodCost"].SetValue(weight.WasteCost, true);

                        objCell.Row.Cells["NetWeight"].SetValue(weight.NetWeight, true);
                    }
                }
            }
        }
        
        private PreviewSettings _Settings = null;
        private void gridViewWaste_InitializePrint(object sender, CancelablePrintEventArgs e)
        {
            SetupPrint(e);
        }
        private void LoadSettings(int reportID)
        {
            try
            {
                if (reportID >= 0)
                {
                    ReportParameters parameters = new ReportParameters();
                    parameters.LoadDB(reportID);
                    if (_Settings == null)
                        _Settings = new PreviewSettings();
                    _Settings.IncludeFilter = bool.Parse(parameters["PrintIncludeFilter"].ParamValue);
                    _Settings.IncludeImage = bool.Parse(parameters["PrintIncludeImage"].ParamValue);
                    _Settings.Title = parameters["PrintTitle"].ParamValue;
                    _Settings.AllPages = bool.Parse(parameters["PrintAllPages"].ParamValue);
                    _Settings.CurrentPage = bool.Parse(parameters["PrintCurrentPage"].ParamValue);
                    _Settings.FitToPages = int.Parse(parameters["PrintFitToPages"].ParamValue);
                    _Settings.PagesFrom = int.Parse(parameters["PrintPagesFrom"].ParamValue);
                    _Settings.PagesTo = int.Parse(parameters["PrintPagesTo"].ParamValue);
                }
                else
                    _Settings = null;
            }
            catch { }
        }
        private void SaveSettings(int reportID)
        {
            if (_Settings != null)
            {
                ReportParameters parameters = new ReportParameters();
                parameters.ParamList = new UCPrintParameters().ParamList;
                parameters["PrintIncludeFilter"].ParamValue = _Settings.IncludeFilter.ToString();
                parameters["PrintIncludeImage"].ParamValue = _Settings.IncludeImage.ToString();
                parameters["PrintTitle"].ParamValue = _Settings.Title.ToString();
                parameters["PrintAllPages"].ParamValue = _Settings.AllPages.ToString();
                parameters["PrintCurrentPage"].ParamValue = _Settings.CurrentPage.ToString();
                parameters["PrintFitToPages"].ParamValue = _Settings.FitToPages.ToString();
                parameters["PrintPagesFrom"].ParamValue = _Settings.PagesFrom.ToString();
                parameters["PrintPagesTo"].ParamValue = _Settings.PagesTo.ToString();
                parameters.SaveDB(reportID);
            }
        }
        public void PrintGrid(bool isShowDialog)
        {
            if (_Settings == null || isShowDialog)
            {
                frmPrintProperties frm = new frmPrintProperties(_ConfigReportID >= 0 ? _ConfigReportName : "Waste");
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                if (_Settings != null)
                    frm.PreviewSettings = _Settings;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this._Settings = frm.PreviewSettings;
                    if (_ConfigReportID >= 0)
                        SaveSettings(_ConfigReportID);
                }
                else
                    return;
            }

            // To print using an UltraGridPrintDocument, associate a grid with the
            // document instance. This can be done at design time as well.
            this.ultraGridPrintDocument1.Grid = this.gridViewWaste;
            
            // To show print preivew using the UltraPrintPreviewDialog, associate
            // a print document with the dialog. This can be done at design time
            // as well.
            if (_Settings.IncludeFilter && (GetFilters().Trim() != ""))
            {
                this.ultraGridPrintDocument1.Footer.BorderStyle = UIElementBorderStyle.None;
                this.ultraGridPrintDocument1.Footer.Height = 30;
                this.ultraGridPrintDocument1.Footer.Appearance.FontData.SizeInPoints = 6;
                this.ultraGridPrintDocument1.Footer.TextLeft = "Filter Used: " + GetFilters();
                this.ultraGridPrintDocument1.Footer.Appearance.TextVAlign = VAlign.Bottom;
            }
            this.ultraPrintPreviewDlg.Document = this.ultraGridPrintDocument1;

            // Call ShowDialog to show the print preview dialog.
            this.ultraPrintPreviewDlg.ShowDialog(this);
        }

        private void ultraPrintPreviewDlg_Load(object sender, EventArgs e)
        {
            try
            {
                if (_Settings != null)
                {
                    this.ultraPrintPreviewDlg.Document.DocumentName = _Settings.Title;
                    this.ultraPrintPreviewDlg.Text = "Print Preview " + _Settings.Title;
                }
                else
                    this.ultraPrintPreviewDlg.Text = "Print Preview";
                // Set the print preview document and show the window
                //ultraPrintPreviewDlg.FindForm().MdiParent = this.MdiParent;
                //ultraPrintPreviewDlg.Show();
                ultraPrintPreviewDlg.FindForm().WindowState = FormWindowState.Maximized;
                ultraPrintPreviewDlg.FindForm().TopMost = true;
            }
            catch { }
        }

        private void ultraPrintPreviewDlg_Printed(object sender, EventArgs e)
        {
            ultraPrintPreviewDlg.FindForm().TopMost = false;

            DialogResult result = MessageBox.Show("Document was successfully printed. Do you want to close Print Preview " + _Settings.Title + " window?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == result)
                this.ultraPrintPreviewDlg.Close();
        }

        private void SetupPrint(Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
        {
            //set the previewinfo values based on the values selected in
            // the controls on the form
            try
            {
                e.DefaultLogicalPageLayoutInfo.FitWidthToPages = _Settings.FitToPages;

                //				e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image = 
                if (_Settings.IncludeImage && VWA4Common.GlobalSettings.LogoUpperLeftStream != null)
                {
                    e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image =
                         System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream);
                    e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageHAlign = HAlign.Left;
                    //e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ForeColor = Color.White;
                }

                e.DefaultLogicalPageLayoutInfo.PageHeader = _Settings.Title;
        
                if (_Settings.AllPages)
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages;
                else if (_Settings.CurrentPage)
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.CurrentPage;
                else
                {
                    e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.SomePages;
                    e.PrintDocument.PrinterSettings.FromPage = _Settings.PagesFrom * Math.Max( _Settings.FitToPages, 1) - 1;
                    e.PrintDocument.PrinterSettings.ToPage = _Settings.PagesTo * Math.Max(_Settings.FitToPages, 1);
                }
            }
            catch 
            {
                e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages;
            }
            
            // hide row selector column
            e.PrintLayout.Bands[_WeightsBand].Override.RowSelectors = DefaultableBoolean.False;
            foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn col in e.PrintLayout.Bands[_WeightsBand].Columns)
                col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnMouseEnter;
            // activate key fields for editing to apply the same style for all columns
            e.PrintLayout.Bands[_WeightsBand].Columns["ID"].CellActivation = Activation.AllowEdit;
            e.PrintLayout.Bands[_WeightsBand].Columns["TransKey"].CellActivation = Activation.AllowEdit;
            e.PrintLayout.Bands[_WeightsBand].Columns["WasteCost"].CellActivation = Activation.AllowEdit;
            // --------------------------------------------------------------------------------

            // Print settings
            // --------------------------------------------------------------------------------

            e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign =
                Infragistics.Win.HAlign.Center;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 20;
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextTrimming = TextTrimming.None;

            //For Columns to be not get clipped
            e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.No;
            e.DefaultLogicalPageLayoutInfo.ColumnClipMode = ColumnClipMode.RepeatClippedColumns;
            e.PrintLayout.Override.RowSizing = RowSizing.Free;

            // Following code takes a lot of time - it resizes cells with scrolling to display their content on the page
            //foreach (UltraGridRow row in e.PrintLayout.Rows)
            //    row.PerformAutoSize();

            // Use <#> token in the string to designate page numbers.
            e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>.";
            e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40;
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right;
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True;
            e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid;
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintGrid(true);
        }
        public void SaveConfig()
        {
            SaveConfig(true);
        }
        public void SaveConfig(bool isAsk)
        {
            MemoryStream stream = new MemoryStream();
            if (_ConfigReportID > 0 && _ConfigReportName == "Default View")
            {
                this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Clear();
            }
			// save everything except ValueList
			gridViewWaste.DisplayLayout.SaveAsXml(stream, PropertyCategories.AppearanceCollection | PropertyCategories.Bands | PropertyCategories.ColScrollRegions
				| PropertyCategories.ColumnFilters | PropertyCategories.General | PropertyCategories.Groups | PropertyCategories.RowScrollRegions | PropertyCategories.SortedColumns
				| PropertyCategories.Summaries | PropertyCategories.UnboundColumns);
            if (!isAsk)
            {
                if (_ConfigReportID > 0)
                    VWA4Common.VWADBUtils.SaveXMLConfig(_ConfigReportID, "View Waste", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
            }
            else
            {
                if (_ConfigReportID > 0 &&
                    (new frmSaveAs("Save Report As", "Do you want to save as a new report?", "Save As", "Save")).ShowDialog() == DialogResult.Cancel)
                {
                    VWA4Common.VWADBUtils.SaveXMLConfig(_ConfigReportID, "View Waste", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
                }
                else
                {
                    MemorizedReports dlg = new MemorizedReports(stream);
                    dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    dlg.ShowDialog();
                    SetTitleChanged(dlg.ReportName, "View Waste");
                }
            }
        }

        private string PerformTranslation(String sInfraCondition)
        {
            return sInfraCondition;
        }
        private string PerformOperatorTranslation(FilterCondition filCondition)
        {
            string temp = " ";
            switch (filCondition.ComparisionOperator)
            {
                case FilterComparisionOperator.Equals:
                    temp = "="; break;
                case FilterComparisionOperator.GreaterThan:
                    temp = ">"; break;
                case FilterComparisionOperator.GreaterThanOrEqualTo:
                    temp = ">="; break;
                case FilterComparisionOperator.LessThan:
                    temp = "<"; break;
                case FilterComparisionOperator.LessThanOrEqualTo:
                    temp = "<="; break;
                case FilterComparisionOperator.NotEquals:
                    temp = "<>"; break;
                case FilterComparisionOperator.Like:
                    temp = " LIKE "; break;
                case FilterComparisionOperator.NotLike:
                    temp = "NOT LIKE"; break;
                default:
                    temp = filCondition.ToString();
                    temp = Regex.Replace(temp, @"\[.*?\](.*)\'.*?\'$", "$1");
                    break;
            }
            return temp;
        }

        private string PerformTranslation(FilterCondition filCondition)
        {
            string temp = "";
            // create time filter for Access
            if (filCondition.Column.Key == "MyTimestamp")
            {
                temp = filCondition.ToString();
                temp = temp.Replace("'", "#");
                temp = temp.Replace("Timestamp", "Weights.Timestamp");
            }
            //replace ' for non-text fields
            else if (filCondition.Column.Key == "ID" || filCondition.Column.Key == "TransKey" ||
                filCondition.Column.Key == "WasteCost" || filCondition.Column.Key == "FoodTypeCost" ||
                filCondition.Column.Key == "Weight" || filCondition.Column.Key == "ContainerWeight" ||
                filCondition.Column.Key == "ContainerCost" || filCondition.Column.Key == "NItems" ||
                filCondition.Column.Key == "IsManualInput" || filCondition.Column.Key == "IsMemorized" ||
                filCondition.Column.Key == "OverproductionFlag" || filCondition.Column.Key == "TrimWasteFlag" ||
                filCondition.Column.Key == "HandlingFlag" || filCondition.Column.Key == "Enabled")
            {
                temp = filCondition.ToString();
                temp = temp.Replace("'", "");
            }
            // change strings to values
            else if (filCondition.Column.Key == "ProducedID")
            {
                int i = 0;
                if (filCondition.Column.ValueList.GetValue(filCondition.CompareValue.ToString(), ref i) != null)
                {
                    temp = "[" + filCondition.Column.Key + "]";
                    temp = temp + PerformOperatorTranslation(filCondition) + "'" + filCondition.Column.ValueList.GetValue(i) + "'";
                    temp = temp.Replace("'", "");
                }
            }
            else if (filCondition.Column.Key == "IsPreconsumer")
            {
                PreconsumerFilterCondition preconsumerFilter = filCondition as PreconsumerFilterCondition;
                if (preconsumerFilter != null)
                {
                    temp = preconsumerFilter.IsPreconsumer;
                    //temp = temp.Replace(filCondition.Column.Key, "[" + filCondition.Column.Key + "]");
                }
                else
                {
                    temp = filCondition.ToString();
                    temp = temp.Replace("Waste Type", filCondition.Column.Key);
                    temp = temp.Replace("'Intermediate'", "0");
                    temp = temp.Replace("'Pre consumer'", "1");
                    temp = temp.Replace("'Post consumer'", "2");
                }
            }
            else if (filCondition.Column.Key == "WasteClass")
            {
                WasteClassFilterCondition wasteClassFilter = filCondition as WasteClassFilterCondition;
                if (wasteClassFilter != null)
                {
                    temp = wasteClassFilter.Filter;
                }
                else
                {
                    temp = filCondition.ToString();
                    temp = temp.Replace("Allowed Waste Classes", filCondition.Column.Key);
                    foreach(DataRow row in m_VWAWeightsData.WasteClass.Rows)
                        temp = temp.Replace("'" + row["DisplayFullName"].ToString() + "'", row["UniqueName"].ToString());
                }
            }
            else if (filCondition.Column.Key == "FoodTypeID" ||
                filCondition.Column.Key == "LossTypeID" || filCondition.Column.Key == "ContainerTypeID" ||
                filCondition.Column.Key == "StationTypeID" || filCondition.Column.Key == "DispositionTypeID" ||
                filCondition.Column.Key == "DaypartTypeID" || filCondition.Column.Key == "BEOTypeID" ||
                filCondition.Column.Key == "UserTypeID")
            {
                TypeIDFilterCondition typeIDFilter = filCondition as TypeIDFilterCondition;
                if (typeIDFilter != null)
                {
                    temp = typeIDFilter.Filter;
                    temp = temp.Replace(filCondition.Column.Key, "[" + filCondition.Column.Key + "]");
                }
                else 
                {
                    temp = filCondition.ToString();
                }
                //int i = 0;
                //if (filCondition.Column.ValueList.GetValue(filCondition.CompareValue.ToString(), ref i) != null)
                //{
                //    temp = "[" + filCondition.Column.Key + "]";
                //    temp = temp + PerformOperatorTranslation(filCondition) + "'" + filCondition.Column.ValueList.GetValue(i) + "'";
                //    if (filCondition.Column.Key == "IsPreconsumer" || filCondition.Column.Key == "UOMID")
                //        temp = temp.Replace("'", "");
                //}
            }
            // default
            else
                temp = filCondition.ToString();
            // change displayed column names to keys
            if (filCondition.Column.Key == "TransKey" || filCondition.Column.Key == "WasteCost" ||
                filCondition.Column.Key == "FoodTypeCost" || filCondition.Column.Key == "ContainerCost" ||
                filCondition.Column.Key == "ContainerWeight" || filCondition.Column.Key == "NetWeight" || filCondition.Column.Key == "UserQuestion" ||
                filCondition.Column.Key == "NItems" || filCondition.Column.Key == "FoodTypeID" ||
                filCondition.Column.Key == "LossTypeID" || filCondition.Column.Key == "ContainerTypeID" ||
                filCondition.Column.Key == "StationTypeID" || filCondition.Column.Key == "DispositionTypeID" ||
                filCondition.Column.Key == "DaypartTypeID" || filCondition.Column.Key == "BEOTypeID" ||
                filCondition.Column.Key == "UserTypeID")
            {
                temp = Regex.Replace(temp, @"\[.*?\]", "[" + filCondition.Column.Key + "]");
            }
            if(filCondition.Column.Key != "WasteClass" && !Regex.IsMatch(temp, @"Weights\."))
                temp = "Weights." + temp;
            if (Regex.IsMatch(temp, @"NonBlanks"))
                temp = Regex.Replace(temp, @"= '\(NonBlanks\)'", "<> NULL");
            return temp;
        }

        public string GetFilters()
        {
            DateTime now = DateTime.Now;
            return GetFilters(ref now);
        }

        public string GetFilters(ref DateTime startDate)
        {
            String sFilter = String.Empty;
            try
            {
                foreach (ColumnFilter colFil in this.gridViewWaste.Rows.ColumnFilters)
                {
                    String sColFilter = String.Empty;
                    foreach (FilterCondition filCondition in colFil.FilterConditions)
                    {
                        if (filCondition.Column.Key != "SiteID")// do not output Site filters
                        {
                            if (sColFilter != String.Empty)
                                sColFilter = sColFilter + " " + colFil.LogicalOperator + " " + PerformTranslation(filCondition) + " ";
                            else
                                sColFilter = PerformTranslation(filCondition) + " ";
                        }
                        //find start date
                        if (filCondition.Column.Key == "MyTimestamp")
                        {
                            if (Regex.Match(sColFilter, ">").Success)
                                startDate = DateTime.Parse(Regex.Replace(sColFilter, @".*>.*?#([^#]*)#.*", "$1"));
                        }
                    }
                    if (sColFilter != String.Empty)
                    {
                        if (sFilter != String.Empty)
                            sFilter = sFilter + " AND (" + sColFilter + ")";
                        else
                            sFilter = "(" + sColFilter + ")";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sFilter;
        }

        private string GetSorting()
        {
            String sSort = String.Empty;
            try
            {
                foreach (UltraGridColumn ultCol in gridViewWaste.DisplayLayout.Bands[_WeightsBand].SortedColumns)
                {
                    if (sSort != String.Empty)
                        sSort = sSort + ",";
                    if (ultCol.SortIndicator == SortIndicator.Ascending)
                        sSort = sSort + ultCol.Key;
                    else
                        sSort = sSort + ultCol.Key + " desc ";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sSort;
        }

        public string GetFiltersString()
        {
            String sFilter = String.Empty;
            try
            {
                foreach (ColumnFilter colFil in this.gridViewWaste.Rows.ColumnFilters)
                {
                    String sColFilter = String.Empty;
                    if(colFil.Column.Key == "SiteID")
                    {
                        if (colFil.FilterConditions.Count > 0)
                        {
                            SiteFilterCondition siteFil = colFil.FilterConditions[0] as SiteFilterCondition;
                            if (siteFil != null && this.cboSite.Items.Count > 0) //filtered from combobox
                            {
                                this.cboSite.SelectedIndex = 0;
                                for (int i = 1; i < cboSite.Items.Count; i++)
                                    if (((VWA4Common.VWACommon.MyListBoxItem)cboSite.Items[i]).ItemData == siteFil.SiteID)
                                    {
                                        this.cboSite.SelectedIndex = i;
                                        break;
                                    }
                            }
                            else //SiteID choosed from filter
                                if (sColFilter != String.Empty)
                                    sColFilter = sColFilter + " " + colFil.LogicalOperator + " " + PerformTranslation(colFil.FilterConditions[0].ToString()) + " ";
                                else
                                    sColFilter = PerformTranslation(colFil.FilterConditions[0].ToString()) + " ";
                        }
                        
                    }
                    else
                        foreach (FilterCondition filCondition in colFil.FilterConditions)
                        {
                            if (sColFilter != String.Empty)
                                sColFilter = sColFilter + " " + colFil.LogicalOperator + " " + PerformTranslation(filCondition.ToString()) + " ";
                            else
                                sColFilter = PerformTranslation(filCondition.ToString()) + " ";
                        }

                    if (sColFilter != String.Empty)
                    {
                        if (sFilter != String.Empty)
                            sFilter = sFilter + " AND (" + sColFilter + ")";
                        else
                            sFilter = "(" + sColFilter + ")";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sFilter;
        }

        public delegate void DataSavedEventHandler(object sender, EventArgs e);
        private DataSavedEventHandler dataSaved;
        public event DataSavedEventHandler DataSaved
        {
            add { dataSaved += value; }
            remove { dataSaved -= value; }
        }
        public void SetDataSaved()
        {
            OnDataSaved(EventArgs.Empty);
        }
        protected virtual void OnDataSaved(EventArgs e)
        {
            if (dataSaved != null)
                dataSaved(this, e);
        }

        public delegate void CanceledEventHandler(object sender, EventArgs e);
        private CanceledEventHandler canceled;
        public event CanceledEventHandler Canceled
        {
            add { canceled += value; }
            remove { canceled -= value; }
        }
        public void SetCanceled()
        {
            OnCanceled(EventArgs.Empty);
        }
        protected virtual void OnCanceled(EventArgs e)
        {
            if (canceled != null)
                canceled(this, e);
        }

        private void gridViewWaste_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {
            SetFilterLabel();
        }

        private void gridViewWaste_BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            Infragistics.Win.ValueListSortStyle sortStyle = Infragistics.Win.ValueListSortStyle.None;
            switch (e.Column.SortIndicator)
            {
                case SortIndicator.Ascending:
                    sortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
                    break;
                case SortIndicator.Descending:
                    sortStyle = Infragistics.Win.ValueListSortStyle.Descending;
                    break;
                default:
                    sortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
                    break;
            }
            e.ValueList.SortStyle = sortStyle;
            if (e.Column.Key.Equals("MyTimestamp"))
            {
                e.ValueList.ValueListItems.Clear();
                e.ValueList.ValueListItems.Add(new DateRangeFilterCondition(e.Column, "Current Week"), "Current Week");
                e.ValueList.ValueListItems.Add(new DateRangeFilterCondition(e.Column, "Last Week"), "Last Week");
                e.ValueList.ValueListItems.Add(new DateRangeFilterCondition(e.Column, "Last 2 Weeks"), "Last 2 Weeks");
                e.ValueList.ValueListItems.Add(new DateRangeFilterCondition(e.Column, "Last Month"), "Last Month");
                e.ValueList.ValueListItems.Add(new DateRangeFilterCondition(e.Column, "Last 2 Months"), "Last 2 Months");
                e.ValueList.ValueListItems.Add("(Period)", "(Period)");
                e.ValueList.ValueListItems.Add("(Custom)", "(Custom)");
                e.ValueList.SortStyle = ValueListSortStyle.None;
            }
        }

        private bool bColumnChooserVisible = true;
        private void btnColumnChooser_Click(object sender, EventArgs e)
        {
            ShowHideColumnChooser(bColumnChooserVisible);
        }
        public void ShowHideColumnChooser(bool isHide)
        {
            if (isHide)
                this.ultraGridColumnChooser1.Hide();
            else
                this.ultraGridColumnChooser1.Show();
            bColumnChooserVisible = !isHide;
            btnColumnChooser.Text = (isHide ? "Show " : "Hide ") + "Choose Columns";
        }
        private void btnSaveView_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save current changes?", "Confirm Changes",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SaveData();
                OnDataSaved(e);
                VWA4Common.VWADBUtils.MostRecents = new DateTime(0);//calculate new dates for last weights data
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(_IsSheet)
                commonEvents.TaskSheetKey = "dashboard";
            else
                OnCanceled(e);
        }

        private void SetFilterLabel()
        {
            lblFilter.Text = GetFiltersString();
            if (lblFilter.Text == "")
                lblFilter.Text = "None";
            lblFilter.Text = "Filters Applied: " + lblFilter.Text;
        }

        [Serializable]
        internal class DateRangeFilterCondition : FilterCondition, ISerializable
        {
            private DateTime _startDate;
            private DateTime _endDate;
            private string _filterName;

            internal DateRangeFilterCondition(UltraGridColumn column, DateTime startDate,
                DateTime endDate, string filterName)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _startDate = startDate;
                _endDate = endDate;
                _filterName = filterName;
            }
            internal DateRangeFilterCondition(UltraGridColumn column, string filterName)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _filterName = filterName;
                setPeriod(_filterName);
            }
            public string FilterName
            {
                get { return _filterName; }
                set { _filterName = value; }
            }
            public override string ToString()
            {
                return "[Timestamp] >= '" + _startDate + "' AND [Timestamp] < '" + _endDate + "'";
            }
            public void setPeriod(DateTime startDate, DateTime endDate)
            {
                _startDate = startDate;
                _endDate = endDate;
            }
            public void setPeriod(string filterName)
            {
                if (filterName == "Current Week" || filterName == "Last Week" || filterName == "Last 2 Weeks")
                {
                    DateTime lastDayOfWeek = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
                    while (lastDayOfWeek.DayOfWeek != VWA4Common.VWACommon.FirstDayOfWeek)
                        lastDayOfWeek = lastDayOfWeek.AddDays(-1);
                    if (filterName == "Current Week")
                        _startDate = lastDayOfWeek;
                    else if (filterName == "Last Week")
                        _startDate = lastDayOfWeek.AddDays(-7);
                    else
                        _startDate = lastDayOfWeek.AddDays(-14);
                    if (filterName == "Current Week")
                        _endDate = lastDayOfWeek.AddDays(7);
                    else
                        _endDate = lastDayOfWeek;
                }
                else if (filterName == "Last Month" || filterName == "Last 2 Months")
                {
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);
                    if (filterName == "Last Month")
                        _startDate = firstDayOfMonth.AddMonths(-1);
                    else
                        _startDate = firstDayOfMonth.AddMonths(-2);
                    _endDate = firstDayOfMonth;
                }
            }
            public override bool MeetsCriteria(UltraGridRow row)
            {
                object cellVal = row.GetCellValue(this.Column);
                try
                {
                    DateTime testDate = Convert.ToDateTime(cellVal);
                    if (testDate >= _startDate && testDate < _endDate)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected DateRangeFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _filterName = info.GetString("FilterName");
                _startDate = info.GetDateTime("StartDate");
                _endDate = info.GetDateTime("EndDate");
                if (_filterName != "Period")
                    setPeriod(_filterName);
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("StartDate", _startDate);
                info.AddValue("EndDate", _endDate);
                info.AddValue("FilterName", _filterName);
            }
        }

        private void gridViewWaste_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 

            if (objCell.Column.Key == "MyTimestamp" && objCell.Text == "(Period)")
            {
                CustomDateTimeFilter dlg = new CustomDateTimeFilter();
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    objCell.CancelUpdate(); // to prevent setting filter to 'Period'
                    this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Clear();
                    this.gridViewWaste.Rows.ColumnFilters["MyTimestamp"].FilterConditions.Add(new DateRangeFilterCondition(objCell.Column, dlg.startDate, dlg.endDate, "(Period)"));

                    SetFilterLabel();
                }
            }
        }

        private void btnLoadView_Click(object sender, EventArgs e)
        {
            MemorizedReports dlg = new MemorizedReports("View Waste", false);
            dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.gridViewWaste.DisplayLayout.LoadFromXml(dlg.ConfigXML());
                    PopulateNamesValueLists();
                    InitValueLists();
                    SetFilterLabel();
                }
            }
            catch (Exception ex)
            {
                TopMostMessageBox.Show("Error in loading report: " + ex.Message, "Project Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private DateTime _StartDate, _EndDate;
        private bool _IsPeriodSet = false;
        public void AddPeriodFilter(DateTime startDate, DateTime endDate)
        {
            _StartDate = startDate;
            _EndDate = endDate;
            _IsPeriodSet = true;
        }
        private string _ParamName, _ParamValue;
        public void AddTypeFilter(string name, string value)
        {
            _ParamName = name;
            _ParamValue = value;
            //   this.gridViewWaste.Rows.ColumnFilters[name +"TypeID"].FilterConditions.Add(
            //       Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, value);
        }
        private string _Filter = "";
        private string _DisplayFilter = "";
        public void AddFilter(string filter)
        {
            _Filter = filter;
        }
        public void AddFilter(string filter, string displayFilter)
        {
            _Filter = filter;
            _DisplayFilter = displayFilter;
        }
        private string _SiteID = "";
        private string _SiteName = "";
        public void SetSiteID(string siteID, string siteName)
        {
            _SiteID = siteID;
            _SiteName = siteName;
        }
        private string _Preconsumer = "";
        private string _PreconsumerDisplay = "";
        public void SetDefaultPreconsumer(string filter, string filterDisplay)
        {
            _Preconsumer = filter;
            _PreconsumerDisplay = filterDisplay;
        }

        private ArrayList _TransferData = new ArrayList();
        public void AddTransfersFilter(ArrayList transferData)
        {
            _TransferData.AddRange(transferData);
        }
        private string _WasteClass = "";
        private string _WasteClassDisplay = "";
        public void SetWasteClassFilter(string filter, string filterDisplay)
        {
            _WasteClass = filter;
            _WasteClassDisplay = filterDisplay;
        }
        [Serializable]
        internal class TypeIDFilterCondition : FilterCondition, ISerializable
        {
            private string[] _typeIDs;
            private string _filter;
            private string _filterType;
            private string _filterDisplay;

            internal TypeIDFilterCondition(UltraGridColumn column, string filter, string filterType, string filterDisplay)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _filter = filter;
                _filterType = filterType;
                _filterDisplay = filterDisplay;
                setTypeIDs(_filter);
            }
            public string FilterType
            {
                get { return _filterType; }
                set { _filterType = value; }
            }
            public string Filter
            {
                get { return _filter; }
                set { _filter = value; }
            }
            public string FilterDisplay
            {
                get { return _filterDisplay; }
                set { _filterDisplay = value; }
            }
            public override string ToString()
            {
                return _filterDisplay;
            }
            public void setTypeIDs(string filter)
            {
                string[] temp = filter.Split('\'');
                _typeIDs = new string[temp.Length / 2];
                for (int i = 0; i < _typeIDs.Length; i++)
                    _typeIDs[i] = temp[i * 2 + 1];
            }

            public override bool MeetsCriteria(UltraGridRow row)
            {
                object cellVal = row.GetCellValue(this.Column);
                try
                {
                    foreach(string id in _typeIDs)
                        if (cellVal.Equals(id))
                            return true;
                    
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected TypeIDFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _filterType = info.GetString("IDFilterType");
                _filter = info.GetString(_filterType + "IDFilter");
                _filterDisplay = info.GetString(_filterType + "IDFilterDisplay");
                setTypeIDs(_filter);
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("IDFilterType", _filterType);
                info.AddValue(_filterType + "IDFilter", _filter);
                info.AddValue(_filterType + "IDFilterDisplay", _filterDisplay);
            }
        }

        [Serializable]
        internal class TransfersFilterCondition : FilterCondition, ISerializable
        {
            private ArrayList _Transfers = new ArrayList();

            internal TransfersFilterCondition(UltraGridColumn column, ArrayList transfers)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _Transfers.Clear();
                _Transfers.AddRange(transfers);
            }
            
            public override string ToString()
            {
                string display = "";
                for (int i = 0; i < _Transfers.Count; i++)
                {
                    UCImportTransactions.TransferInfo transferInfo = (UCImportTransactions.TransferInfo)_Transfers[i];
                    if(display == "")
                        display = "Terminal = " + transferInfo.TermName + " AND Transfer Time = " + transferInfo.Timestamp;
                    else
                        display += " AND Terminal = " + transferInfo.TermName + " AND Transfer Time = " + transferInfo.Timestamp;
                }
                return display;
            }

            public override bool MeetsCriteria(UltraGridRow row)
            {
                DataRow rowData = ((DataRowView)row.ListObject).Row;
                try
                {
                    for (int i = 0; i < _Transfers.Count; i++)
                    {
                        UCImportTransactions.TransferInfo transferInfo = (UCImportTransactions.TransferInfo)_Transfers[i];
                        if (rowData["TermID"].ToString() == transferInfo.TermID && rowData["Transfers.Timestamp"].ToString() == transferInfo.Timestamp.ToString())
                            return true;
                    }

                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected TransfersFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _Transfers = (ArrayList)info.GetValue("Transfers", typeof(ArrayList));
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("Transfers", _Transfers, typeof(ArrayList));
            }
        }

        [Serializable]
        internal class WasteClassFilterCondition : FilterCondition, ISerializable
        {
            private string[] _WasteClasses;
            private string _filter;
            private string _filterDisplay;

            internal WasteClassFilterCondition(UltraGridColumn column, string filter, string filterDisplay)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _filter = filter;
                _filterDisplay = filterDisplay;
                setWasteClasses(_filter);
            }
            
            public string Filter
            {
                get { return _filter; }
                set { _filter = value; }
            }
            public string FilterDisplay
            {
                get { return _filterDisplay; }
                set { _filterDisplay = value; }
            }
            public override string ToString()
            {
                return _filterDisplay;
            }
            public void setWasteClasses(string filter)
            {
                string[] temp = Regex.Split(filter, "OR");
                _WasteClasses = new string[temp.Length];
                for (int i = 0; i < _WasteClasses.Length; i++)
                    _WasteClasses[i] = Regex.Replace(temp[i], @"\s*WasteClass\s*=\s*", "").Trim();
            }

            public override bool MeetsCriteria(UltraGridRow row)
            {
                object cellVal = row.GetCellValue(this.Column);
                try
                {
                    foreach (string wasteClass in _WasteClasses)
                        if (cellVal.Equals(wasteClass))
                            return true;

                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected WasteClassFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _filter = info.GetString("WasteClassFilter");
                _filterDisplay = info.GetString("WasteClassDisplay");
                setWasteClasses(_filter);
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("WasteClassFilter", _filter);
                info.AddValue("WasteClassDisplay", _filterDisplay);
            }
        }

        private void gridViewWaste_BeforeCustomRowFilterDialog(object sender, BeforeCustomRowFilterDialogEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell 
            if (Regex.IsMatch(objCell.Column.Key, "TypeID"))
            {
                e.Cancel = true;
                CustomTypeIDFilter dlg = new CustomTypeIDFilter("0",
                        Regex.Replace(objCell.Column.Key, "TypeID", ""),
                        "");
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    this.gridViewWaste.Rows.ColumnFilters[objCell.Column.Key].FilterConditions.Clear();
                    string filter, filterDisplay = "";
                    filter = dlg.GetFilters(ref filterDisplay);
                    this.gridViewWaste.Rows.ColumnFilters[objCell.Column.Key].FilterConditions.Add(new TypeIDFilterCondition(objCell.Column, filter, 
                        Regex.Replace(objCell.Column.Key, "TypeID", ""), filterDisplay));

                    SetFilterLabel();
                }
            }
        }

        private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
        {
            //   Use the BeforeEnterEditMode event to position the edit controls    
            UltraGridCell objCell = this.gridViewWaste.ActiveCell;
            //   This should be impossible, but its good practice to check    
            //   to make sure there is an active cell before continuing    
            if (objCell == null) { return; }
            if (VWA4Common.VWACommon.IsAllowEditVersion() && Regex.IsMatch(objCell.Column.Key, "TypeID"))
            {
                objCell.SetValue(e.ID, true);
                ultraTextEditor1.CloseEditorButtonDropDowns();
                gridViewWaste_CellChange(sender, new CellEventArgs(objCell));
            }
        }

        private string _currColumn = "";
        private void gridViewWaste_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            UIElement element = ((UltraGrid)sender).DisplayLayout.UIElement.ElementFromPoint(mousePoint);
            HeaderUIElement hElement = element.GetAncestor(typeof(HeaderUIElement)) as HeaderUIElement;

            if (hElement != null)
            {
                //hElement.Header.Selected = !hElement.Header.Selected;
                _currColumn = hElement.Header.Column.ToString();
                // not disabled for edit and doesn't have checkbox in the header
                if (hElement.Header.Column.CellActivation == Activation.ActivateOnly ||
                    hElement.Header.Column.CellActivation == Activation.AllowEdit && hElement.Header.Column.DataType != typeof(bool))
                {
                    remapToolStripMenuItem.Enabled = Regex.IsMatch(_currColumn, "TypeID");
                    
                    cmReplaceColumn.Show(gridViewWaste, mousePoint);
                }
            }
            else
            {
                FilterCellUIElement fcElement = element.GetAncestor(typeof(FilterCellUIElement)) as FilterCellUIElement;

                if (fcElement != null)
                {
                    _currColumn = fcElement.Column.ToString();
                    this.gridViewWaste.Rows.ColumnFilters[_currColumn].FilterConditions.Clear();
                    SetFilterLabel();
                }
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currColumn != "")
            {
                if (Regex.IsMatch(_currColumn, "TypeID"))
                {
                    CustomTypeIDFilter dlg = new CustomTypeIDFilter("0",
                            Regex.Replace(_currColumn, "TypeID", ""));
                    dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (UltraGridRow row in this.gridViewWaste.Rows)
                            if (!row.IsFilteredOut)
                                row.Cells[_currColumn].Value = dlg.TypeID();
                    }
                }
                else
                {
                    CustomReplace dlg;

                    if (gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns[_currColumn].ValueList != null)
                    {
                        dlg = new CustomReplace(_currColumn, this.gridViewWaste.DisplayLayout.ValueLists[_currColumn + "Names"]);
                    }
                    else
                    {
                        dlg = new CustomReplace(_currColumn, gridViewWaste.DisplayLayout.Bands[_WeightsBand].Columns[_currColumn].DataType);
                    }
                    dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (UltraGridRow row in this.gridViewWaste.Rows)
                            if (!row.IsFilteredOut)
                                row.Cells[_currColumn].Value = dlg.NewValue();
                    }
                }
            }
        }

        private void remapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomRemap dlg = new CustomRemap(_currColumn);
            dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string typeID = dlg.TypeID();
                foreach (UltraGridRow row in this.gridViewWaste.Rows)
                    if (!row.IsFilteredOut && row.Cells[_currColumn].Value.ToString() == typeID)
                    {
                        string next = dlg.GetNextTypeID(Double.Parse(row.Cells["Weight"].Value.ToString()));
                        if(next != "")
                            row.Cells[_currColumn].Value = next;
                    }
            }
        }

        [Serializable]
        internal class PreconsumerFilterCondition : FilterCondition, ISerializable
        {
            private string _IsPreconsumer;
            private string _IsPreconsumerDisplay;

            private string [] matches;

            internal PreconsumerFilterCondition(UltraGridColumn column, string filter,string filterDisplay)
                : base(column, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _IsPreconsumer = filter;
                _IsPreconsumerDisplay = filterDisplay;
                matches = new string[Regex.Matches(filter, "IsPreconsumer]? =\\s*(\\S+)").Count];
                int i = 0;
                foreach (Match m in Regex.Matches(filter, "IsPreconsumer]? =\\s*(\\S+)"))
                {
                    matches[i] = m.Groups[1].ToString();
                    i++;
                }
            }
            public string IsPreconsumer
            {
                get { return _IsPreconsumer; }
                set { _IsPreconsumer = value; }
            }
            public string IsPreconsumerDisplay
            {
                get { return _IsPreconsumerDisplay; }
                set { _IsPreconsumerDisplay = value; }
            }
            public override string ToString()
            {
                return _IsPreconsumerDisplay;
            }

            public override bool MeetsCriteria(UltraGridRow row)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cellVal = row.Cells["IsPreconsumer"];
                    foreach(string str in matches)
                        if (cellVal.Value.ToString() == str)
                            return true;

                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected PreconsumerFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _IsPreconsumer = info.GetString("IsPreconsumer");
                _IsPreconsumerDisplay = info.GetString("PreconsumerDisplay");
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("IsPreconsumer", _IsPreconsumer);
                info.AddValue("PreconsumerDisplay", _IsPreconsumerDisplay);
            }
        }

        [Serializable]
        internal class SiteFilterCondition : FilterCondition, ISerializable
        {
            private string _SiteID;
            private string _SiteName;

            internal SiteFilterCondition(string siteID, string siteName)
            //    : base(this.gridViewWaste., Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Custom, null)
            {
                _SiteID = siteID;
                _SiteName = siteName;
            }
            public string SiteID
            {
                get { return _SiteID; }
                set { _SiteID = value; }
            }
            public string SiteName
            {
                get { return _SiteName; }
                set { _SiteName = value; }
            }
            public override string ToString()
            {
                return "Site = " + _SiteName;
            }
           
            public override bool MeetsCriteria(UltraGridRow row)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cellVal = row.Cells["SiteID"];
                    if (cellVal.Text == _SiteID)
                        return true;

                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            protected SiteFilterCondition(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                _SiteID = info.GetString("SiteID");
                _SiteName = info.GetString("SiteName");
            }
            [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //base.GetObjectData(info, context);
                info.AddValue("SiteID", _SiteID);
                info.AddValue("SiteName", _SiteName);
            }
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gridViewWaste.Rows.ColumnFilters["SiteID"].ClearFilterConditions();
                if (cboSite.SelectedIndex > 0)
                {
                    VWA4Common.VWACommon.MyListBoxItem item = cboSite.SelectedItem as VWA4Common.VWACommon.MyListBoxItem;
                    this.gridViewWaste.Rows.ColumnFilters["SiteID"].FilterConditions.Add(new SiteFilterCondition(item.ItemData, item.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }


        #region ExportGridWithExtras
        /// <summary>
        /// Exports the grid with some extras. This requires created a report and exporting to it before publishing.
        /// </summary>
        public void CreateReportWithExtras(ref Report report)
        {
            // Create  new report. 
            if (report == null)
                report = new Report();

            // Create a Font that will be used for headers
            Infragistics.Documents.Graphics.Font headerFont = new Infragistics.Documents.Graphics.Font("Ariel", 15f);

            // Use that font to create a style
            Style headerStyle = new Style(headerFont, Infragistics.Documents.Graphics.Brushes.Black);

            // Create an Alignment object to center the headers
            TextAlignment headerAlignment = new TextAlignment(Alignment.Center, Alignment.Middle);
            report.Preferences.Printing.PaperSize = Infragistics.Documents.Report.Preferences.Printing.PaperSize.Letter;
            report.Preferences.Printing.PaperOrientation = Infragistics.Documents.Report.Preferences.Printing.PaperOrientation.Landscape;
            report.Preferences.Printing.FitToMargins = true;
			
            this.ultraGridDocumentExporter1.TargetPaperOrientation = PageOrientation.Landscape;
            this.ultraGridDocumentExporter1.TargetPaperSize = Infragistics.Documents.Report.PageSizes.Letter;
            this.ultraGridDocumentExporter1.Margins = new PageMargins(0.75f, 0.75f, 0.75f, 0.75f);

            Infragistics.Documents.Report.Section.ISection section = report.AddSection();
			section.PageAlignment.Horizontal = Alignment.Center;
            if (_Settings != null)
            {

                // Add a section before the grid and export some content to it. 
                Infragistics.Documents.Report.Section.ISectionHeader header = section.AddHeader();
                header.Height = 30;
                header.Repeat = true;
                if (_Settings.IncludeImage && VWA4Common.GlobalSettings.LogoUpperLeftStream != null)
                {
                    Bitmap bitmap = new Bitmap(System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream), new Size(30, 30));
                    header.AddImage(new Infragistics.Documents.Graphics.Image(bitmap), 0, 0);
                }
                IText text = header.AddText((_Settings.IncludeImage ? 30 : 0), 0);
                text.Style = new Infragistics.Documents.Report.Text.Style(new Infragistics.Documents.Graphics.Font("Arial", 12),
                    Infragistics.Documents.Graphics.Brushes.Black);
                text.Alignment = Infragistics.Documents.Report.TextAlignment.Center;
                text.AddContent(_Settings.Title);
                if (_Settings.IncludeFilter)
                {
                    // Footer
                    Infragistics.Documents.Report.Section.ISectionFooter footer = section.AddFooter();
                    footer.Height = 30;
                    footer.Repeat = true;
                    //footer.Background = new Infragistics.Documents.Report.Background(Infragistics.Documents.Graphics.Brushes.LightSeaGreen);

                    text = footer.AddText(0, 0);
                    text.Style = new Infragistics.Documents.Report.Text.Style(new Infragistics.Documents.Graphics.Font(
                        "Arial", 8, Infragistics.Documents.Graphics.FontStyle.Bold), Infragistics.Documents.Graphics.Brushes.Black);
                    text.Alignment = Infragistics.Documents.Report.TextAlignment.Left;
                    text.AddContent("Filter Used: " + GetFilters());
                }
            }
            // Export the grid into the report. 
            // By specifying a report here instead of a filename, the grid will be exporting into a new Section of the report.
            // If you wanted to, you could export more than one grid into the same report. Each one would be in it's own section.             
            this.ultraGridDocumentExporter1.Export(this.gridViewWaste, section);
        }

        #region Publish
        public void Publish(Report report, string fileName)
        {
            try
            {
                if (report == null)
                {
                    report = new Report();
                    this.CreateReportWithExtras(ref report);
                }
                report.Publish(fileName, Infragistics.Documents.Report.FileFormat.PDF);
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }
        #endregion //Publish
        #endregion //ExportGridWithExtras
        private void btnPDF_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "Portable Document Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;

            // If either of these two checkboxes are checked, it means that there
            // will be extra sections in the report in addition to the grid section. 
            // So we need to create a report and build the sections, then publish it. 
            Report report = new Report();
            this.CreateReportWithExtras(ref report);
            this.Publish(report, fileName);
        }

        private void ultraGridPrintDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true; //always use landscape
        }
        public void Test()
        {
            Report report = new Report();
            
            this.ConfigReportID = 8;
            this.LoadData();
            Infragistics.Documents.Report.Section.ISection section = report.AddSection();
            this.ultraGridDocumentExporter1.Export(this.gridViewWaste, section);
            this.ConfigReportID = 13;
            this.LoadData();
            section = report.AddSection();
            this.ultraGridDocumentExporter1.Export(this.gridViewWaste, section); 
            report.Publish(@"C:\Temp\mila2.pdf", Infragistics.Documents.Report.FileFormat.PDF);
            //return report;
        }
        private class MySortComparer : IComparer
        {
            internal MySortComparer()
            {
            }

            int IComparer.Compare(object x, object y)
            {

                // Passed in objects are cells. So you have to typecast them to UltraGridCell objects first.
                UltraGridCell xCell = (UltraGridCell)x;
                UltraGridCell yCell = (UltraGridCell)y;

                // Do your own comparision between the values of xCell and yCell and return a negative
                // number if xCell is less than yCell, positive number if xCell is greater than yCell,
                // and 0 if xCell and yCell are equal.

                // Following code does an case-insensitive compare of the values converted to string.
                string text1 = xCell.Text;
                string text2 = yCell.Text;

                return String.Compare(text1, text2, true);

            }
        }

        private void ucEditTransfer1_SavePressed(object sender, UCEditTransfer.SaveEventArgs e)
        {
            if (e.Transfer.Check())
                e.Transfer.DBSave(false);
            else
                MessageBox.Show(null, "Error saving new transfer data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ultraTransferEditor.CloseEditorButtonDropDowns();
        }

        private void gridViewWaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (gridViewWaste.Selected.Rows != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete all selected rows?", "Delete Selected Rows",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (UltraGridRow row in gridViewWaste.Selected.Rows)
                        {
                            row.Delete(false);
                        }
                        //gridViewWaste.Refresh();
                    }
                }
            }
        }

        private void ucEditTransfer1_CancelPressed(object sender, EventArgs e)
        {
            //ucEditTransfer1.Hide();
            //ucEditTransfer1.SendToBack();
            
            ultraTransferEditor.CloseEditorButtonDropDowns();
        }

        private void btnXMLExport_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "Extensible Markup Language Files (*.xml)|*.xml|All Files (*.*)|*.*";
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;

            // If either of these two checkboxes are checked, it means that there
            // will be extra sections in the report in addition to the grid section. 
            // So we need to create a report and build the sections, then publish it. 
            m_VWAWeights.ExportToXML(fileName, GetFilters(), _Mode);
            
        }
        public void HideSite()
        {
            cboSite.Visible = false;
            label2.Text = "Site: " + _SiteName;
        }

        public delegate void TitleChangedEventHandler(object sender, VWA4Common.VWACommon.TitleEventArgs e);
        private TitleChangedEventHandler titleChangedParams;
        public event TitleChangedEventHandler TitleChanged
        {
            add { titleChangedParams += value; }
            remove { titleChangedParams -= value; }
        }
        public void SetTitleChanged(string newTitle, string reportType)
        {
            VWA4Common.VWACommon.TitleEventArgs e = new VWA4Common.VWACommon.TitleEventArgs();
            e.Title = newTitle;
            e.ReportType = reportType;
            OnTitleChanged(e);
        }
        protected virtual void OnTitleChanged(VWA4Common.VWACommon.TitleEventArgs e)
        {
            if (titleChangedParams != null)
                titleChangedParams(this, e);
        }
    }
}