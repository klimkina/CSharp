using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmTransactionViewer : Form
	{
		//UCTransactionViewer transview;
		public frmTransactionViewer()
		{
			InitializeComponent();
		}
		public frmTransactionViewer(int transactionid)
		{
			InitializeComponent();
			updateProductUI();
			ucTransactionViewer0.Hide();
			ucTransactionViewer0.LoadData(transactionid);
			ucTransactionViewer0.Show();
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


		private void bClose_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{
					VWA4Common.Utilities.printUserControl(this, "Transaction Details", ucTransactionViewer0.Left + 3, 
				pFormHdr.Bottom + 28, ucTransactionViewer0.Width, ucTransactionViewer0.Height - panel2.Height);
		
		}

	}
}
