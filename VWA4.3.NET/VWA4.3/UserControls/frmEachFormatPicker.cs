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
	public partial class frmEachFormatPicker : Form
	{
		bool showDelete = false;
		string msgtag = ".";
		private string _EachFormatID;
		public string EachFormatID
		{
			get
			{
				return _EachFormatID;
			}
		}


		public frmEachFormatPicker(string foodtypeid, bool showdelete)
		{
			InitializeComponent();
			Init(foodtypeid);
			showDelete = showdelete;
			bDelete.Visible = showDelete;
			bDelete.Enabled = false;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		public frmEachFormatPicker(string foodtypeid)
		{
			InitializeComponent();
			Init(foodtypeid);
			bDelete.Visible = false;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		public void Init(string foodtypeid)
		{
			bDone.Hide();
			lType.Text = "Select Each Format Type";
			string rettypename = "";
			string whereclause = "";
			if (VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food", foodtypeid, out rettypename))
			{
			lType.Text += " for " + rettypename + ""; // Add the type name if not empty
			whereclause = " WHERE FoodTypeID = '"+ foodtypeid + "' ";
				msgtag = " for Selected Food Type!";
			}
			// Load up the Listview
			// Set the control's View property to 'Details'
			ulvEachFormats.View = UltraListViewStyle.Details;

			// Set some properties so that SubItems (and their respective
			// columns) are visible by default in the views that support
			// columns, and also, make the column names and sub-item
			// values not appear in tooltips by default.
			ulvEachFormats.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
			ulvEachFormats.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
			//ulvSessions.ViewSettingsTiles.SubItemsVisibleByDefault = true;
			ulvEachFormats.ItemSettings.SubItemsVisibleInToolTipByDefault = false;

			// Add columns in listview
			ulvEachFormats.MainColumn.Text = "Each Format Type";
			ulvEachFormats.MainColumn.DataType = typeof(System.String);
			UltraListViewSubItemColumn subItemColumn = null;
			subItemColumn = ulvEachFormats.SubItemColumns.Add("Quantity");
			subItemColumn.DataType = typeof(System.Decimal);
			subItemColumn.Text = "Quantity";
			subItemColumn = ulvEachFormats.SubItemColumns.Add("WeightMultiplier");
			subItemColumn.DataType = typeof(System.Decimal);
			subItemColumn.Text = "Per";
			subItemColumn = ulvEachFormats.SubItemColumns.Add("WeightUnits");
			subItemColumn.DataType = typeof(System.String);
			subItemColumn.Text = "Weight Units";
			subItemColumn = ulvEachFormats.SubItemColumns.Add("Description");
			subItemColumn.DataType = typeof(System.String);
			subItemColumn.Text = "Description";

			// Get all Each formats for this food type and add them to list view control collection
			string sql = @"SELECT * FROM EachFormats " + whereclause + " ORDER BY SortOrder ASC";
			DataTable dteachfmt = new DataTable();
			dteachfmt = VWA4Common.DB.Retrieve(sql);
			if (dteachfmt.Rows.Count > 0)
			{
				foreach (DataRow row in dteachfmt.Rows)
				{

					string eachformatid = row["ID"].ToString();
					string eachformatname = row["EachFormatName"].ToString();
					decimal eachquantity = decimal.Parse(row["EachQuantity"].ToString());
					decimal wtmultiplier = decimal.Parse(row["WtMultiplier"].ToString());
					int unitswtid = int.Parse(row["UnitsWtID"].ToString());
					// Get UnitsWt info
					string wtunitsname = "";
					string uniquename = "";
					string displayfullname = "";
					string displayabbreviatedname = "";
					decimal conversionfactor = 0;
					string description = "";
					VWA4Common.GlobalSettings.GetWtUnitsDataFromID(unitswtid, out wtunitsname,
						out displayfullname, out displayabbreviatedname, out conversionfactor,
						out description);


					UltraListViewItem item = ulvEachFormats.Items.Add(eachformatid, eachformatname);
					item.SubItems["Quantity"].Value = eachquantity;
					item.SubItems["WeightMultiplier"].Value = wtmultiplier;
					item.SubItems["WeightUnits"].Value = wtunitsname;
					item.SubItems["Description"].Value = description;
					// could add hidden column for uniquename if we need to use it
				}
			}
		}
		private void frmEachFormatPicker_Shown(object sender, EventArgs e)
		{
			if (ulvEachFormats.Items.Count == 0)
			{
				MessageBox.Show("No Each Formats defined" + msgtag);
				DialogResult = DialogResult.Cancel;
			}

		}


		private void ulvEachFormats_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			bDelete.Enabled = true;
			bDone.Show();
		}

		private void ulvEachFormats_DoubleClick(object sender, EventArgs e)
		{
			_EachFormatID = ulvEachFormats.SelectedItems[0].Key.ToString();
			// Find the trans item with this key
			VWA4Common.GlobalSettings.frmEachFormats_FormatIDSelected = _EachFormatID;
			DialogResult = DialogResult.OK;
		}


		private void bDone_Click(object sender, EventArgs e)
		{
			_EachFormatID = ulvEachFormats.SelectedItems[0].Key.ToString();
			VWA4Common.GlobalSettings.frmEachFormats_FormatIDSelected = _EachFormatID;
				
			DialogResult = DialogResult.OK;
		}


		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			VWA4Common.DB.Delete("DELETE FROM EachFormats WHERE ID = " 
				+ ulvEachFormats.SelectedItems[0].Key.ToString());
			UltraListViewItem uitem = ulvEachFormats.SelectedItems[0];
			ulvEachFormats.Items.Remove(uitem);
			ulvEachFormats.Update();
			bDelete.Enabled = false;
			bDone.Visible = false;
		}


	}
}
