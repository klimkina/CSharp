using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmWasteModePicker : Form
	{
		private int _IsPreconsumer;
		public int IsPreconsumer
		{
			get
			{
				return _IsPreconsumer;
			}
		}

		private string _WasteModeName;
		public string WasteModeName
		{
			get
			{
				return _WasteModeName;
			}
		}

		public frmWasteModePicker()
		{
			InitializeComponent();
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
			// Form background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Form header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


		private void bDone_Click(object sender, EventArgs e)
		{
			_WasteModeName =
				rgWasteMode.Properties.Items[rgWasteMode.SelectedIndex].Description;
			_IsPreconsumer =
				int.Parse(rgWasteMode.Properties.Items[rgWasteMode.SelectedIndex].Value.ToString());
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void rgWasteMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			bDone.Show();
		}
	}
}
