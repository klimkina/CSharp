using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace UserControls
{
	public partial class frmTagPicker : Form
	{
		List<Tag> TagList = new List<Tag>();

		private Tag _TagSelected = new Tag();

		public Tag TagSelected
		{
			get { return _TagSelected; }
		}

		public frmTagPicker()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			updateProductUI();
			lFormTitle.Text = "Choose Food Type Tag";
			LoadTags();
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

		private void LoadTags()
		{
			TagList = TagsDAO.DAO.GetAllTags();
			ulvTagList.Reset();
			ulvTagList.View = UltraListViewStyle.List;
			ulvTagList.ItemSettings.Appearance.Image = imageList1.Images[0];
			ulvTagList.ItemSettings.SelectedAppearance.Image = imageList1.Images[1];
			ulvTagList.ItemSettings.SelectedAppearance.FontData.Bold = DefaultableBoolean.False;
			ulvTagList.ItemSettings.SelectedAppearance.ForeColor = Color.Black;
			ulvTagList.ItemSettings.SelectedAppearance.BackColor = Color.MistyRose;

			ulvTagList.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			UltraListViewMainColumn mainColumn = ulvTagList.MainColumn;
			mainColumn.Text = "Tag Name";
			mainColumn.DataType = typeof(System.String);
			/// Load 'er up
			for (int i = 0; i < TagList.Count; i++)
			{
				UltraListViewItem item = ulvTagList.Items.Add(TagList[i].ID.ToString(), TagList[i].TagName);
				//item.Tag = TagList[i];
			}
			ulvTagList.Refresh();
		}

		private void ulvTagList_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			
			_TagSelected = TagsDAO.DAO.Load(int.Parse(e.SelectedItems[0].Key));
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}


	}
}
