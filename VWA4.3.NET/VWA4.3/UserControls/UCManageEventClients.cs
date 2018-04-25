using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

namespace UserControls
{
    public partial class UCManageEventClients : UserControl, IVWAUserControlBase
    {
        /// Class level elements
        public bool Initialized;
        private VWA4Common.DBDetector dbDetector = null;
        VWA4Common.CommonEvents commonEvents = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public UCManageEventClients()
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
                dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
                dbDetector.DBPathChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_PathChanged);
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
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
		}


        private DataTable _Clients;
        /// <summary>
        /// Load the Event Clients Data.  Standard method for UserControls interface.
        /// Call when loading task sheet, and whenever data has changed that would affect
        /// the Event Clients database table.
        /// </summary>
        public void LoadData()
        {
            Initialized = false;
            //			
            // Initialize Data
            //
            /// Mila - from UCEnterFinancials.cs
            _Clients = VWA4Common.DB.Retrieve("SELECT * FROM EventClients");
            Initialized = true;
            ultraGrid1.DataSource = _Clients;
            ultraGrid1.Refresh();
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
        /// Event Handlers

        void dbDetector_PathChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                LoadData();
        }

        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                LoadData();
        }

        private void bDone_Click(object sender, EventArgs e)
        {
			CloseTaskSheet();
        }

		private void CloseTaskSheet()
		{
			ultraGrid1.Update();
			commonEvents.TaskSheetKey = "dashboard";
		}

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ClientName"].Header.Caption = "Client Name";
            e.Layout.Bands[0].Columns["ClientName"].SortIndicator = SortIndicator.Ascending;
            e.Layout.Bands[0].Columns["ID"].Hidden = true;

            ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Enter, UltraGridAction.NextRow, 0, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
            ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Delete, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));
            ultraGrid1.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Back, UltraGridAction.DeleteRows, UltraGridState.InEdit, UltraGridState.Row, Infragistics.Win.SpecialKeys.All, 0));

            ultraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
        }

        
        private void ultraGrid1_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            UltraGridRow objRow = this.ultraGrid1.ActiveRow;
            if (objRow == null) { return; }
            if (objRow.Cells["ClientName"].Value.ToString() == "")
            {
                objRow.Delete(false);
                e.Cancel = true;
            }
        }

        
        private bool _FromDeleteButton = false;
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this Client?", "Delete Event Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (UltraGridRow row in ultraGrid1.Selected.Rows)
                {
                    DeleteFromTable(row);
                }
                _FromDeleteButton = true; //already deleted
                ultraGrid1.DeleteSelectedRows(false);
                _FromDeleteButton = false;
                ultraGrid1.UpdateData();
            }
        }

        private void ultraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            /// Validation for PeriodStartDate (Date picker)
            UltraGridCell objCell = this.ultraGrid1.ActiveCell;
            if (objCell == null) { return; }
            //   Get the UIElement associated with the active cell, which we will    
            //   need so we can get the size and location of the cell    
            if (objCell.IsDataCell && objCell.Column.Key == "ClientName")
            {
                // Make sure date is not in the future
                if (objCell.Text.ToString() == "")
                {
                    MessageBox.Show("Client name is not valid", "WVA Error");
                    objCell.Selected = true;
                    return;
                }
                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM EventClients WHERE ClientName = '" + objCell.Text + "'");
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ID"].ToString() != objCell.Row.Cells["ID"].Value.ToString())
                {
                    MessageBox.Show("Client with this name already exists", "WVA Error");
                    objCell.Row.Delete(false);
                    return;
                }

                ultraGrid1.UpdateData();
                
                int id = 0;
                int.TryParse(objCell.Row.Cells["ID"].Value.ToString(), out id);
                if (id > 0)
                    VWA4Common.DB.Update("UPDATE EventClients SET ClientName = '" + objCell.Value.ToString() + "'" +
                        " WHERE ID = " + this.ultraGrid1.ActiveRow.Cells["ID"].Value.ToString());
                else
                    objCell.Row.Cells["ID"].Value =
                        VWA4Common.DB.Insert("INSERT INTO EventClients (ClientName) Values('" + objCell.Value.ToString() + "')");

                
            }
        }

        private void ultraGrid1_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if(!_FromDeleteButton)
                foreach (UltraGridRow row in e.Rows)
                {
                    DeleteFromTable(row);
                }
        }

        private void DeleteFromTable(UltraGridRow row)
        {
            int id = 0;
            int.TryParse(row.Cells["ID"].Value.ToString(), out id);
            if (id > 0)
                VWA4Common.DB.Delete("DELETE FROM EventClients " +
                    " WHERE ID = " + id);
        }
		private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Manage Event Clients available")))
				CloseTaskSheet();
		}
    }
}
