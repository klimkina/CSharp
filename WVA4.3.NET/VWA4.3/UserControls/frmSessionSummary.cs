using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmSessionSummary : Form
	{
		private int SessionID;

		public frmSessionSummary(int sessionID)
		{
			InitializeComponent();
			SessionID = sessionID;
			updateProductUI();
			CalculateSessionSummary();
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

		public void CalculateSessionSummary()
		{
			decimal wastecost = 0;
			decimal wasteweight = 0;
			int numtrans = 0;
			// Get Session Data
			string sql = "SELECT SUM(WasteCost) AS wastecost, SUM(Weight) AS totalwastelbs, SUM(ContainerWeight*NItems) AS containerlbs, COUNT(*) as cnt FROM Weights wts "
				+ " WHERE (wts.TransKey = " + SessionID.ToString() + ")";

			DataTable dt_wcost = VWA4Common.DB.Retrieve(sql);
			DataRow thisRow = dt_wcost.Rows[0];
			if (thisRow["wastecost"].ToString() != "")
				wastecost = decimal.Parse(thisRow["wastecost"].ToString());
			else
				wastecost = 0.0M;

			if (thisRow["totalwastelbs"].ToString() != "")
				wasteweight = decimal.Parse(thisRow["totalwastelbs"].ToString());
			else
				wasteweight = 0.0M;

			numtrans = int.Parse(thisRow["cnt"].ToString());

			// Update labels
			lSession.Text =  SessionID.ToString();
			lWasteCost.Text = wastecost.ToString("C");
			lWasteWeight.Text = wasteweight.ToString("######0") + " lbs";
			lWasteTransactions.Text = numtrans.ToString();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
