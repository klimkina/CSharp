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
    /// Summary description for rptProducedItemSub.
    /// </summary>
    public partial class rptProducedItemSub : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        private string _EOID, _EOName;
        public rptProducedItemSub(UserControls.ReportParameters InputParameters, string eoID, string eoName)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
            _EOID = eoID;
            _EOName = eoName;
        }

        public DataTable _ChartData;

        private int _iRow;
        private void rptProducedItemSub_ReportStart(object sender, EventArgs e)
        {
            _iRow = 0;
            string where = "";
            DateTime start, end;
            start = DateTime.Parse(DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
            end = DateTime.Parse(DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));

            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                where += " WHERE (" + _InputParameters["Filter"].ParamValue + ")" +
                    (_EOID == "" ? " AND (EOTypeID = '' OR EOTypeID IS NULL)" : "AND EOTypeID = '" + _EOID + "' ") +
                    " AND [WeightsProduced.Timestamp] >= #" + start +
                    "# AND [WeightsProduced.Timestamp] < #" + end + "# AND SiteID =" + _InputParameters["SiteID"].ParamValue;
            else
                where = (_EOID == "" ? " WHERE (EOTypeID = '' OR EOTypeID IS NULL) AND " : " WHERE EOTypeID = '" + _EOID + "' AND ") +
                    " [WeightsProduced.Timestamp] >= #" + start +
                    "# AND [WeightsProduced.Timestamp] < #" + end + "# AND SiteID =" + _InputParameters["SiteID"].ParamValue;

			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = "SELECT SUM(Weights.Weight - Weights.NItems*Weights.ContainerWeight) AS Waste, WeightsProduced.ID, " +
                //" SUM(IIF(WeightsProduced.IsMemorized = 1, (WeightsProduced.Weight - WeightsProduced.ContainerWeight * WeightsProduced.NItems), WeightsProduced.Weight)) AS ProducedWeight, " +
                " SUM(WeightsProduced.Weight - WeightsProduced.ContainerWeight * WeightsProduced.NItems) AS Produced, " +
                " BEOType.GuestCount AS GuestCount, WeightsProduced.Timestamp AS PDate, WeightsProduced.UnitUniqueName AS UOM, " +
                " FoodType.TypeName AS FoodName, Produced - Waste AS AmountUsed, " +
                (_EOID == "" ? " '' AS GuestUOM, " : " IIF((Produced - Waste) > 0, GuestCount/(Produced - Waste), '') AS GuestUOM, ") +
                " ProducedAmount, SUM(WasteAmountUserEntry) AS WasteEntry, WeightsProduced.UnitsDisplayName AS UDN, ProducedAmount - WasteEntry AS UsedEntry " +
                " FROM ((((WeightsProduced LEFT JOIN Weights ON Weights.ProducedID = WeightsProduced.ID)  " +
                " LEFT JOIN FoodType ON WeightsProduced.FoodTypeID = FoodType.TypeID)  " +
                " LEFT JOIN Transfers ON WeightsProduced.TransKey = Transfers.TransKey) " +
                " LEFT OUTER JOIN BEOType ON WeightsProduced.EOTypeID = BEOType.TypeID)   " +
                (isWasteClassesUsed ? " LEFT JOIN FoodType ON WeightsProduced.FoodTypeID = FoodType.TypeID " : "") +
                where +
                " GROUP BY WeightsProduced.ID, BEOType.GuestCount, WeightsProduced.Timestamp, " +
                "WeightsProduced.UnitUniqueName, FoodType.TypeName, ProducedAmount, WasteAmountUserEntry, WeightsProduced.UnitsDisplayName " +
                "ORDER BY WeightsProduced.Timestamp";
            _ChartData = VWA4Common.DB.Retrieve(select);

            if (_ChartData.Rows.Count <= 0)
                this.Cancel();
            else
            {
                this.DataSource = _ChartData;
                txtEventOrder.Text = _EOName;
                if (_EOName == "")
                    txtEventOrder.Text = "No Event Orders";
            }
            this.Document.Printer.Landscape = true;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            // Check _iRow value to see if we need to highlight the row or not.
            if (this._iRow % 2 == 0)
                this.detail.BackColor = Color.Transparent;
            else
                this.detail.BackColor = Color.LightYellow;
            //if (txtUDN.Text == "")
            //{
            //    //txtProducedEntry.Text = "";
            //    txtWastedEntry.Text = "";
            //    txtUsedEntry.Text = "";
            //}
            //else if (txtUsedEntry.Text == "" && txtProducedEntry.Text != "")
            //    txtUsedEntry.Text = txtProducedEntry.Text; 
            if (txtUsed.Text != "" && double.Parse(txtUsed.Text) < 0)
                txtUsed.ForeColor = Color.Red;
            else
                txtUsed.ForeColor = Color.Black;
            this._iRow++;
        }
    }
}
