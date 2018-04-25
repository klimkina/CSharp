using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCHelp : UserControl
    {
        public UCHelp()
        {
            InitializeComponent();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Wait till help downloads all necessary components!", "Loading Help",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
