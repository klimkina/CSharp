using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace Reports
{
    public partial class frmEditFormFormSeries : System.Windows.Forms.Form
    {
        public FormFormSeries formFormSeries = new FormFormSeries();

        public frmEditFormFormSeries(FormFormSeries ffs)
        {
            InitializeComponent();
			updateProductUI();
			this.formFormSeries = ffs;
            this.chkEnabled.Checked = ffs.Enabled;
            this.txtNumberOfCopies.Text = ffs.NumberOfCopies.ToString();            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.formFormSeries.Enabled = chkEnabled.Checked;
            this.formFormSeries.NumberOfCopies = Convert.ToInt32(this.txtNumberOfCopies.Text);

            FormFormSeriesDAO.DAO.Update(this.formFormSeries);
            this.Close();
        }
    }
}
