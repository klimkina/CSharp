using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class frmAddReportSerie : Form
    {
        private string _Name = "";
        public string SerieName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public frmAddReportSerie()
        {
            InitializeComponent();
			updateProductUI();
			if (_Name != "")
                txtName.Text = _Name;
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

        private void button1_Click(object sender, EventArgs e)
        {
            _Name = txtName.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
