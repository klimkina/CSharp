using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class UCDeleteUser : UserControl, IVWAUserControlBase 
	{

		public bool Initialized;
		public string UserTypeID;
		VWA4Common.CommonEvents commonEvents = null;

		/// <summary>
		/// Constructor
		/// </summary>
		public UCDeleteUser()
		{
			InitializeComponent();
		}
		
		public void Init(DateTime firstDayOfWeek)
		{
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

		public void LoadData()
		{
			Initialized = false;
			clearData();
			teUser.Focus();
			bCancel.Hide();
			bDelete.Hide();
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

		private void bCancel_Click(object sender, EventArgs e)
		{
			clearData();
			bCancel.Hide();
			bDelete.Hide();
		}

		private void clearData()
		{
			Initialized = false;
			// Clear data here
			teUser.Clear();
			Initialized = true;
		}

		private void ultraTextEditor1_BeforeEditorButtonDropDown(object sender, Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventArgs e)
		{
			this.ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
						"User", "0");
		}

		private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			UserTypeID = e.ID;
			teUser.Text = e.Name;
			teUser.CloseEditorButtonDropDowns();
		}

		private void ucTreeView1_Leave(object sender, EventArgs e)
		{
			teUser.CloseEditorButtonDropDowns();
			if (ucTreeView1.ID == "")
			{
				UserTypeID = "";
				teUser.Text = "";
			}
		}


		private void teUser_ValueChanged(object sender, EventArgs e)
		{
			if ((Initialized) && (teUser.Text != ""))
			{
				bCancel.Show();
				bDelete.Show();
			}
		}

		private void ucTreeView1_Load(object sender, EventArgs e)
		{

		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			// Delete this user from all Trackers
			string sql = "DELETE FROM TrackerUserButtons WHERE TypeID='" + UserTypeID + "'";
			VWA4Common.DB.Delete(sql);
			// Disable this user from the Master Types
			sql = "UPDATE UserType SET Enabled=false WHERE TypeID='" + UserTypeID + "'";
			VWA4Common.DB.Update(sql);
			// Disable this user from the Master Types
			sql = "UPDATE UserSubTypes SET Enabled=false WHERE TypeID='" + UserTypeID + "'";
			VWA4Common.DB.Update(sql);
			// Note that Trackers need reloading
            VWA4Common.GlobalSettings.TrackerConfigOutofSync = true;
			//
			clearData();
			// hide the buttons
			bCancel.Hide();
			bDelete.Hide();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			clearData();
			bCancel.Hide();
			bDelete.Hide();
			commonEvents.TaskSheetKey = "dashboard";
		}
	}
}
