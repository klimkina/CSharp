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
    /// Summary description for rptTop5Dispositions.
    /// </summary>
    public partial class rptTop5Dispositions : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ARParameters _InputParameters;
        public rptTop5Dispositions(UserControls.ARParameters InputParameters)
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
        private void rptTop5Dispositions_ReportStart(object sender, EventArgs e)
        {
            if (_InputParameters.ParamName == "Disposition")
                this.Cancel();
            else
            {
                this._iRow = 0;
                //Dataset to hold data
                DataTable _ChartData = new DataTable();

                string sql = @"SELECT TOP 5 DispositionType.TypeName AS Name, DispositionTypeID, Sum(WasteCost) AS Waste " +
                    "FROM Weights INNER JOIN DispositionType ON Weights.DispositionTypeID = DispositionType.TypeID" +
                    _InputParameters.Where +
                    "GROUP BY Weights.DispositionTypeID, DispositionType.TypeName " +
                    "ORDER BY Sum(WasteCost) DESC;";
                _ChartData = VWA4Common.DB.Retrieve(sql);
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
