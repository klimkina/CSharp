using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class EditTransfer : Form
    {
        private ImportTransfer _transfer;

        public ImportTransfer Transfer
        {
            get { return _transfer; }
        }
        
        public EditTransfer(ImportTransfer transfer)
        {
            InitializeComponent();
            _transfer = transfer;
            ucEditTransfer1.Init(_transfer);
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

        private void ucEditTransfer1_CancelPressed(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ucEditTransfer1_SavePressed(object sender, UCEditTransfer.SaveEventArgs e)
        {
            _transfer = e.Transfer;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
