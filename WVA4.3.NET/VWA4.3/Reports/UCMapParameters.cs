using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class UCMapParameters : UserControl
    {
        public UCMapParameters()
        {
            InitializeComponent();
        }
        private int _SiteID;
        private int _ReportSetID;
        public void LoadReport(int reportSetID)
        {
            _ReportSetID = reportSetID;
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportSet INNER JOIN ReportSeries ON ReportSet.SerieID = ReportSeries.ID " +
                " WHERE ReportSet.ID = " + reportSetID);
            if (dt.Rows.Count > 0)
            {
                _SiteID = int.Parse(dt.Rows[0]["SiteID"].ToString());
                int memorizedID = int.Parse(dt.Rows[0]["ReportMemorized"].ToString());
                dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam " +
                    " WHERE ReportMemorized = " + memorizedID);
            }
            else
                MessageBox.Show(null, "Error loading Report Set - no Report Set with such ID found", "Error loading Report Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
