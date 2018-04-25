using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Reports
{
    /// <summary>
    /// Summary description for ARTrend.
    /// </summary>
    public partial class ARTrend : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;

        public ARTrend():this(new UserControls.ReportParameters())
        {
        }
        public ARTrend(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }
        private rptARTrend _rptARTrend;
        public UserControls.ReportParameters OutputParameters
        {
            get
            {
                return _rptARTrend.OutputParameters;
            }
        }
        private void ARTrend_ReportStart(object sender, EventArgs e)
        {
            _rptARTrend = new rptARTrend(_InputParameters);
            this.subARTrend.Report = _rptARTrend;
        }
    }
}
