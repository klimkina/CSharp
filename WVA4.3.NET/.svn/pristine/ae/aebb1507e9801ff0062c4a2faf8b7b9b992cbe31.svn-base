using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class ViewErrors : Form
    {
        public ViewErrors()
        {
            InitializeComponent();
			updateProductUI();
			this.WindowState = FormWindowState.Maximized;
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
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		
		private void ucViewWeights1_Canceled(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FilterTransfers(ArrayList transferData)
        {
            ucViewWeights1.AddTransfersFilter(transferData);
            
        }
    }
}
