using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class frmSaveAs : Form
    {
        public frmSaveAs(string title, string message, string btnOkName, string btnCancelName)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = title;
			updateProductUI();
			lblMessage.Text = message;
            btnOk.Text = btnOkName;
            btnCancel.Text = btnCancelName;
            pIcon.Size = SystemIcons.Question.Size;
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

        private void pIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Question, 0, 0);

        }
        
    }
}
