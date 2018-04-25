using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;

namespace Reports
{
    /// <summary>
    /// Summary description for rptFinancials.
    /// </summary>
    public partial class rptFinancials : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        private string _FinancialReportType;
        public rptFinancials(UserControls.ReportParameters parameters, string name)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _FinancialReportType = name;
        }

        public UserControls.ReportParameters OutputParameters
        {
            get
            {
                UserControls.ReportParameters output = new UserControls.ReportParameters();
                output.AddParameters(((rptLowReport)this.subReport1.Report).OutputParameters.ParamList);
                return output;
            }
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
        private void rptFinancials_ReportStart(object sender, EventArgs e)
        {
            if (_InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            else
                this.lblTitle.Text = _FinancialReportType;
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            SetLogo();
            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            DateTime start = DateTime.Parse(_InputParameters["PeriodStartDate"].ParamValue);
            txtPeriod.Text = start.ToString("MM/yyyy") + "-" + start.AddMonths(int.Parse(_InputParameters["NumberOfMonths"].ParamValue)).AddDays(-1).ToString("MM/yyyy");
            switch(_FinancialReportType)
            {
                case "Budget to Actual Comparison":
                    this.subReport1.Report = new rptBudgetActualComparison(_InputParameters);
                    break;
                case "Financial Summary" :
                    this.subReport1.Report = new rptFinancialSummary(_InputParameters);
                    break;
                case "YOY Comparison":
                    this.subReport1.Report = new rptFinancialYOYComparision(_InputParameters);
                    break;
                default:
                    MessageBox.Show(null, "Report Type not found", "Project Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
        }

        
    }
}
