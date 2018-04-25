using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Reports
{
    /// <summary>
    /// Summary description for rptFake.
    /// </summary>
    public partial class rptFake : DataDynamics.ActiveReports.ActiveReport
    {

        public rptFake()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void rptFake_ReportStart(object sender, EventArgs e)
        {
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
        }
    }
}
