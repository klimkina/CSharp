using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCReportChooser : ComboBox
    {
        /// <summary>
        /// This function receives all the windows messages for this window (form).
        /// We eat up all mouse weel events.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x20A)
            {
                //do nothing
            }
            else
                base.WndProc(ref m);
        }

        public UCReportChooser()
        {
            InitializeComponent();
        }

        //public override int SelectedIndex
        //{
        //    get
        //    {
        //        return base.SelectedIndex;
        //    }
        //    set
        //    {
        //        base.SelectedIndex = value;
        //    }
        //}
    }
}
