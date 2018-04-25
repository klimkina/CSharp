using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmEventOrderPicker : Form
	{
		private string _TypeIDSelected = "";
		public string TypeIDSelected
		{
			get
			{
				return _TypeIDSelected;
			}
		}

		private string _TypeNameSelected = "";
		public string TypeNameSelected
		{
			get
			{
				return _TypeNameSelected;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public frmEventOrderPicker()
		{
			InitializeComponent();
			Init();
		}

		void Init()
		{
			lFormTitle.Text = "Select Event Order";
			ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
					"BEO", "0");
			ucTreeView1.TypeCatalogID = VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString();
			ucTreeView1.Reload();
			ucTreeView1.Show();
			updateProductUI();
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

		/// <summary>
		/// Load all EO data in response to the user selecting an EO from the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			// Info from the tree itself
			_TypeIDSelected = e.ID;
			_TypeNameSelected = e.Name;
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}




	}
}
