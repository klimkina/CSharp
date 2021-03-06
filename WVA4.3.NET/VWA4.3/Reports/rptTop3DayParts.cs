using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Reports
{
    /// <summary>
    /// Summary description for rptTop3DayParts.
    /// </summary>
    public partial class rptTop3DayParts : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ARParameters _InputParameters;
        public rptTop3DayParts(UserControls.ARParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            // Check _iRow value to see if we need to highlight the row or not.
            if (this._iRow % 2 == 0)
                this.Detail.BackColor = Color.Transparent;
            else
                this.Detail.BackColor = Color.LightYellow;
            this._iRow++;
            this.lblRank.Text = this._iRow.ToString(System.Globalization.CultureInfo.CurrentCulture);
        }
        private int _iRow;
        private void rptTop3DayParts_ReportStart(object sender, EventArgs e)
        {
            //Set row count to 0.
            this._iRow = 0;
            if (_InputParameters.ParamName == "Daypart")
                this.Cancel();
            else
            {
                //Dataset to hold data
                DataTable _ChartData = new DataTable();
                string select =
                    @"SELECT TOP 5 DispositionType.TypeName AS Name, DispositionTypeID, Sum(WasteCost) AS Waste " +
                    "FROM Weights INNER JOIN DispositionType ON Weights.DispositionTypeID = DispositionType.TypeID" +
                    _InputParameters.Where +
                    "GROUP BY Weights.DispositionTypeID, DispositionType.TypeName " +
                    "ORDER BY Sum(WasteCost) DESC;";
                _ChartData = VWA4Common.DB.Retrieve(select);
                if (_ChartData.Rows.Count > 0)
                {
                    this.chartControl1.DataSource = _ChartData;
                    this.chartControl1.ColorPalette = _InputParameters.ColorPalette;
                    this.DataSource = _ChartData;
                }
            }
        }
    }
}
