using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinListView;

namespace UserControls
{
	public partial class frmOpenDETemplate : Form
	{
		public frmOpenDETemplate()
		{
			InitializeComponent();
			Init();
		}

		private int _DETID = 0;

		public int DETID
		{
			get
			{
				return _DETID;
			}
		}

		public int _Count = 0;
		public int Count
		{
			get
			{
				return _Count;
			}
		}
		private void Init()
		{
			bDone.Hide();
			bDelete.Hide();
			updateProductUI();
			// Load up the Listview

			// Set the control's View property to 'Details'
			ulvDETemplates.View = UltraListViewStyle.Details;

			// Set some properties so that SubItems (and their respective
			// columns) are visible by default in the views that support
			// columns, and also, make the column names and sub-item
			// values not appear in tooltips by default.
			ulvDETemplates.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
			ulvDETemplates.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
			//ulvSessions.ViewSettingsTiles.SubItemsVisibleByDefault = true;
			ulvDETemplates.ItemSettings.SubItemsVisibleInToolTipByDefault = false;

			// Add columns in listview
			ulvDETemplates.MainColumn.Text = "Template Name";
			ulvDETemplates.MainColumn.DataType = typeof(System.String);
			ulvDETemplates.MainColumn.Width = 100;
			UltraListViewSubItemColumn subItemColumn = null;
			subItemColumn = ulvDETemplates.SubItemColumns.Add("Description");
			subItemColumn.DataType = typeof(System.String);
			subItemColumn.Text = "Description";
			subItemColumn = ulvDETemplates.SubItemColumns.Add("ID");
			subItemColumn.DataType = typeof(System.Int32);
			subItemColumn.Text = "ID";
			subItemColumn.VisibleInDetailsView = DefaultableBoolean.False;

			// Get all manual data entry sessions and add them to list view control collection
			string sql = @"SELECT * FROM DataEntryTemplates ORDER BY DETName ASC";
			DataTable dtdet = new DataTable();
			dtdet = VWA4Common.DB.Retrieve(sql);
			_Count = dtdet.Rows.Count;
			if (dtdet.Rows.Count > 0)
			{
				foreach (DataRow row in dtdet.Rows)
				{
					string detname = row["DETName"].ToString();
					string description = row["DETDescription"].ToString();
					string detID = row["ID"].ToString();

					UltraListViewItem item = ulvDETemplates.Items.Add(detID, detname);
					item.SubItems["Description"].Value = description;
					item.SubItems["ID"].Value = detID;
				}
			}

		}

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


		private void ulvSessions_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			bDone.Show();
			bDelete.Show();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			_DETID = int.Parse(ulvDETemplates.SelectedItems[0].Key.ToString());
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			_DETID = 0;
			DialogResult = DialogResult.Cancel;
		}

		private void ulvDETemplates_ItemDoubleClick(object sender, ItemDoubleClickEventArgs e)
		{
			_DETID = int.Parse(ulvDETemplates.SelectedItems[0].Key.ToString());
			DialogResult = DialogResult.OK;
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void tsmDeleteDET_Click(object sender, EventArgs e)
		{
			UltraListViewItem anItem = ulvDETemplates.ActiveItem;
			if (MessageBox.Show(anItem.Text + " will be deleted permanently - are you sure?", "Confirm Delete Template",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string sql = "DELETE FROM DataEntryTemplates WHERE ID=" + anItem.SubItems["ID"].Value.ToString();
				VWA4Common.DB.Delete(sql);
				ulvDETemplates.ActiveItem.Visible = false;
			}
			
		}

		private void ulvDETemplates_MouseDown(object sender, MouseEventArgs e)
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


	}
}
