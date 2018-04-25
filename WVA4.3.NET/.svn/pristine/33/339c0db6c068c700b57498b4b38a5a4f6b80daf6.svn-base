using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using System.Diagnostics;

namespace UserControls
{
    public partial class CustomDateTimeFilter : Form
    {
        public DateTime startDate
        { get { return dtpStart.Value; } }
        public DateTime endDate
        { get { return dtpEnd.Value; } }

        public CustomDateTimeFilter()
        {
            InitializeComponent();
            dtpEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 0);
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0).AddDays(-7);
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

        public CustomDateTimeFilter(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            dtpStart.Value = startDate;
            dtpEnd.Value = endDate;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value <= dtpEnd.Value)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
