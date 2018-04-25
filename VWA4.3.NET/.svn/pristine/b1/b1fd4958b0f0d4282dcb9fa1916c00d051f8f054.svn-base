using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Reports
{
    /// <summary>
    /// Summary description for rptEvent.
    /// </summary>
    public partial class rptEvent : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        public rptEvent(UserControls.ReportParameters InputParameters)
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

        string _ClientID;
        // save current record's CLient ID
        private void rptEvent_FetchData(object sender, FetchEventArgs eArgs)
        {
            _ClientID = Fields["Client"].Value.ToString();
        }

        private DataTable _ChartData;
        private int typeCatalog = 0;
        
        private void rptEvent_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            _ChartData = VWA4Common.DB.Retrieve("SELECT TypeCatalogID FROM Sites WHERE ID = " +  _InputParameters["SiteID"].ParamValue);
            if (_ChartData.Rows.Count > 0)
            {
                DateTime start, end;
                start = DateTime.Parse(DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
                end = DateTime.Parse(DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
                string where = "WHERE EventDate >= #" + start +
                    "# AND EventDate < #" + end + "#";
                typeCatalog = int.Parse(_ChartData.Rows[0]["TypeCatalogID"].ToString());

                string select = "";
                if (typeCatalog != 0)
                    where = "(" + where + ") AND " +
                     " TypeID IN (SELECT TypeID FROM BEOSubTypes WHERE TypeCatalogID = " + typeCatalog +
                     " AND Enabled = true)";
                if (typeCatalog == 0)
                    select = @"SELECT DISTINCT Client, ClientName FROM BEOType " +
                     " LEFT JOIN EventClients ON BEOType.Client = EventClients.ID " +
                     where +
                     " ORDER BY ClientName";
                else
                    select = @"SELECT DISTINCT Client, ClientName FROM BEOType " +
                     " LEFT JOIN EventClients ON BEOType.Client = EventClients.ID " +
                     where +
                     " ORDER BY ClientName";
                _ChartData = VWA4Common.DB.Retrieve(select);
                this.DataSource = _ChartData;

                txtSite.Text = _InputParameters["SiteID"].DisplayValue;
                txtPeriods.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy");

                if (_ChartData.Rows.Count > 0)
                {
                    SetLogo();
                    lblTitle.Text = "Event Report";
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
        }

        private void detail_Format(object sender, EventArgs e)
        {
            string where = "";
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
            {
                where += " WHERE (" + _InputParameters["Filter"].ParamValue + ") ";
                where = Regex.Replace(where, @"\[?Weights\.Timestamp\]?", "EventDate");
            }
            else
            { 
                DateTime start, end;
                start = DateTime.Parse(DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
                end = DateTime.Parse(DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("yyyy/MM/dd hh:mm:ss"));
                where = "WHERE EventDate >= #" + start + "# AND EventDate < #" + end + "#";
            }

            if (typeCatalog != 0)
                    where = "(" + where + ") AND " +
                     " Weights.BEOTypeID IN (SELECT TypeID FROM BEOSubTypes WHERE TypeCatalogID = " + typeCatalog +
                     " AND Enabled = true)";
            if (_ClientID != "0")
                where += " AND Client = " + _ClientID + " ";

            string select = "SELECT * FROM ((((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                " LEFT OUTER JOIN LossType ON Weights.LossTypeID = LossType.TypeID)" +
                " LEFT OUTER JOIN DispositionType ON Weights.DispositionTypeID = DispositionType.TypeID)" +
                " LEFT OUTER JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID)" +
                " LEFT OUTER JOIN UserType ON Weights.UserTypeID = UserType.TypeID)" +
                " LEFT JOIN BEOType ON Weights.BEOTypeID = BEOType.TypeID)" +
                where + "ORDER BY BEOType.TypeName";

            rptEventSub rpt = new rptEventSub();
            rpt._ChartData = VWA4Common.DB.Retrieve(select);
            this.subEvents.Report = rpt;
        }
    }
}
