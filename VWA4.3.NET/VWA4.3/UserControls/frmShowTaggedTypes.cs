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
	public partial class frmShowTaggedTypes : Form
	{
		List<TagsFoodType> TagsFoodTypeList = new List<TagsFoodType>();
		Tag CurrTag = null;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="tagtoload">Tag for which we want to load food types.</param>
		public frmShowTaggedTypes(int tagidtoload)
		{
			InitializeComponent();
			Init(tagidtoload);
		}

		private void Init(int tagidtoload)
		{
			updateProductUI();
			CurrTag = TagsDAO.DAO.Load(tagidtoload);
			lFormTitle.Text = "Food Types for: " + CurrTag.TagName;
			LoadTaggedFoodTypes(tagidtoload);
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

		private void LoadTaggedFoodTypes(int tagID)
		{
			TagsFoodTypeList = TagsFoodTypeDAO.DAO.GetAllByTagID(tagID);
			LoadTaggedFoodTypes();
		}

		private void LoadTaggedFoodTypes()
		{
			// Load the listview
			ulvTaggedFoodTypes.Reset();
			ulvTaggedFoodTypes.View = UltraListViewStyle.List;
			ulvTaggedFoodTypes.ItemSettings.Appearance.Image = imageList1.Images[1];

			ulvTaggedFoodTypes.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			UltraListViewMainColumn mainColumn = ulvTaggedFoodTypes.MainColumn;
			mainColumn.Text = "Food Type Name";
			mainColumn.DataType = typeof(System.String);
			/// Load 'er up
			for (int i = 0; i < TagsFoodTypeList.Count; i++)
			{
				UltraListViewItem item = new UltraListViewItem();
				ulvTaggedFoodTypes.Items.Add(TagsFoodTypeList[i].FoodTypeID, TagsFoodTypeList[i].FoodTypeName);
				//item.Tag = TagsFoodTypeList[i];
			}
			ulvTaggedFoodTypes.Refresh();
		}


		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

	}
}
