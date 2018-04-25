using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VWA4.com.leanpath.activate;

namespace VWA4
{
    public partial class frmUpdateMessage : Form
    {
        private readonly Update _update;

        public frmUpdateMessage(Update u)
        {
            _update = u;

            InitializeComponent();
        }

        private void frmUpdateMessage_Load(object sender, EventArgs e)
        {
            object empty = System.Reflection.Missing.Value;
            brwMessage.Navigate("about:blank");
            var doc = brwMessage.Document;
            doc.Write(_update.Message);
        }
    }
}
