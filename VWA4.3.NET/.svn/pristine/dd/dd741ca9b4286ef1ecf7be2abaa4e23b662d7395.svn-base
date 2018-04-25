using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using System.Windows.Forms;

namespace Reports
{
    /// <summary>
    /// Summary description for rptEventSub.
    /// </summary>
    public partial class rptEventSub : DataDynamics.ActiveReports.ActiveReport
    {
        //private UserControls.ReportParameters _InputParameters;
        public rptEventSub()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //_InputParameters = InputParameters;
        }

        public DataTable _ChartData;

        private int _iRow;
        private void rptEventSub_ReportStart(object sender, EventArgs e)
        {
            _iRow = 0;
            if (_ChartData.Rows.Count <= 0)
                this.Cancel();
            else
                this.DataSource = _ChartData;
            this.Document.Printer.Landscape = true;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            // Check _iRow value to see if we need to highlight the row or not.
            if (this._iRow % 2 == 0)
                this.detail.BackColor = Color.Transparent;
            else
                this.detail.BackColor = Color.LightYellow;

            
            txtEONum.Visible = (_iRow == 0);
            txtEventName.Visible = (_iRow == 0);
            txtDate.Visible = (_iRow == 0);
            txtGuestCount.Visible = (_iRow == 0);
            
            this._iRow++;
        }

        private void gpEvents_Format(object sender, EventArgs e)
        {
            this._iRow = 0;
        }
    }
}
