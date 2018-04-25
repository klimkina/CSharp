using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Reports
{
    /// <summary>
    /// Summary description for rptProducedItem.
    /// </summary>
    public partial class rptProducedItem : DataDynamics.ActiveReports.ActiveReport
    {

        private UserControls.ReportParameters _InputParameters;
        public rptProducedItem(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }
        private void SetLogo()
        {
            try
            {
                System.Drawing.Image img;
                if (_InputParameters["IsCustomLogo"] != null && bool.Parse(_InputParameters["IsCustomLogo"].ParamValue)
                    && VWA4Common.GlobalSettings.LogoUpperLeftStream != null)
                {
                    img = System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoUpperLeftStream);
                    //this.imgLogo.Height = (img.Height / img.VerticalResolution);
                    //this.imgLogo.Width = (img.Width / img.HorizontalResolution);
                    this.imgLogo.Image = img;
                }
                else
                    this.imgLogo.Visible = false;
                if (_InputParameters["IsLeanPathLogo"] != null && bool.Parse(_InputParameters["IsLeanPathLogo"].ParamValue)
                    && VWA4Common.GlobalSettings.LogoLowerRightStream != null)
                {
                    img = System.Drawing.Image.FromStream(VWA4Common.GlobalSettings.LogoLowerRightStream);
                    this.imgLeanPath.Image = img;
                }
                else
                    this.imgLeanPath.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error loading logo: " + ex.Message, "Error loading image from file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string _EOID, _EOName;
        // save current record's CLient ID
        private void rptProducedItem_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (Fields["TypeID"].Value != null)
            {
                _EOID = Fields["TypeID"].Value.ToString();
                _EOName = Fields["TypeName"].Value.ToString();
            }
        }

        private DataTable _ChartData;

        private void rptProducedItem_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
            {
                _InputParameters["Filter"].ParamValue = VWA4Common.VWACommon.RemoveFilterPeriod(_InputParameters["Filter"].ParamValue) ;
                _InputParameters["Filter"].DisplayValue = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_InputParameters["Filter"].DisplayValue);
            }
           
            DateTime start, end;
            start = DateTime.Parse(DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
            end = DateTime.Parse(DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
            string where = " WHERE [WeightsProduced.Timestamp] >= #" + start +
                "# AND [WeightsProduced.Timestamp] < #" + end + "# AND SiteID =" + _InputParameters["SiteID"].ParamValue;

			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = @"SELECT SUM(FoodCost), TypeID, TypeName FROM ((WeightsProduced " +
                    " LEFT OUTER JOIN BEOType ON WeightsProduced.EOTypeID = BEOType.TypeID) " +
                    " LEFT JOIN Transfers ON WeightsProduced.TransKey = Transfers.TransKey) " +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON WeightsProduced.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY TypeID, TypeName ORDER BY TypeName";
            
            _ChartData = VWA4Common.DB.Retrieve(select);
            this.DataSource = _ChartData;

            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            txtPeriods.Text = start.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " + 
                end.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));

            if (_ChartData.Rows.Count > 0)
            {
                SetLogo();
                lblTitle.Text = "Produced Items Report";
                if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                    this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                if (_InputParameters["SubTitle"] != null)
                    txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                if (_InputParameters["Filter"].ParamValue != "")
                    this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;

            }
            else
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {
                    this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
                    imgLogo.Visible = false;
                    lblWarning.Text = "Warning: No Data\n";
                    lblWarning.ForeColor = Color.Red;
                }
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (_EOID != null)
            {
                rptProducedItemSub rpt = new rptProducedItemSub(_InputParameters, _EOID, _EOName);
                this.subEvents.Report = rpt;
            }
        }
    }
}

