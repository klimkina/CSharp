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
    /// Summary description for rptDetails.
    /// </summary>
    public partial class rptDetails : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parameters"></param>
		public rptDetails(UserControls.ReportParameters parameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
        }

		/// <summary>
		/// Get appropriate logos set up, from GlobalSettings.
		/// </summary>
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
        
		private rptARTrend _rptARTrend;

		/// <summary>
		/// Called before the report starts processing.
		/// This is where report object initialization occurs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rptDetails_ReportStart(object sender, EventArgs e)
        {
			VWA4Common.GlobalSettings.SubReportWasPrinted = false;
			if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")//add type to filter
                _InputParameters["Filter"].ParamValue = _InputParameters["DetailsType"].ParamValue + "TypeID = '" + _InputParameters["DetailsParameter"].ParamValue +"' AND (" + 
                    _InputParameters["Filter"].ParamValue + ")";
            else
                _InputParameters["Filter"].ParamValue = _InputParameters["DetailsType"].ParamValue + "TypeID = '" + _InputParameters["DetailsParameter"].ParamValue +"'";

            _rptARTrend = new rptARTrend(_InputParameters);
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            else
                this.lblTitle.Text = "Close-Up View Report for " + _InputParameters["DetailsType"].ParamValue + ": " + _InputParameters["DetailsParameter"].DisplayValue;
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            SetLogo();
            if (_InputParameters["Filter"].ParamValue != "")
                this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            this.subARTrend.Report = _rptARTrend;
            this.subReport1.Report = new rptTopReport(_InputParameters, "Food", 4);
            this.subReport2.Report = new rptTopReport(_InputParameters, "Loss", 4);
            this.subReport3.Report = new rptTopReport(_InputParameters, "Daypart", 4);
            this.subReport4.Report = new rptTopReport(_InputParameters, "Station", 4);
            this.subReport5.Report = new rptTopReport(_InputParameters, "Disposition", 4);
            this.subReport6.Report = new rptTopReport(_InputParameters, "User", 4);
            this.Document.Printer.Landscape = true;
			//if (!VWA4Common.GlobalSettings.SubReportWasPrinted && !bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
				//this.Cancel();
			this.Document.Printer.Landscape = true;
			//this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom);  
        }
    }
}
