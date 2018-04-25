using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class EditEventOrder : Form
    {
        public EditEventOrder()
        {
            InitializeComponent();
        }
        public EditEventOrder(string id)
        {
            InitializeComponent();
            ucEditEventOrder1.Init("0", id);
        }

        private void ucEditEventOrder1_CancelPressed(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ucEditEventOrder1_SavePressed(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
