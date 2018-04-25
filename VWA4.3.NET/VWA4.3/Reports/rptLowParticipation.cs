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
    /// Summary description for rptLowParticipation.
    /// </summary>
    public partial class rptLowParticipation : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        public rptLowParticipation(UserControls.ReportParameters parameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
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
        private void rptLowParticipation_ReportStart(object sender, EventArgs e)
        {
            if (_InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            else
                this.lblTitle.Text = "Low Participation Report";
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                txtFilter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            SetLogo();
            this.subReport1.Report = new rptLowReport(_InputParameters, "TopWeighers");
            this.subReport2.Report = new rptLowReport(_InputParameters, "NonWeighers");
            this.subReport3.Report = new rptLowReport(_InputParameters, "Station");
            this.subReport4.Report = new rptLowReport(_InputParameters, "Loss");
            this.subReport5.Report = new rptLowReport(_InputParameters, "Food");
            this.subReport6.Report = new rptLowReport(_InputParameters, "Disposition");
            this.subReport7.Report = new rptLowReport(_InputParameters, "Daypart");
            this.subReport8.Report = new rptLowReport(_InputParameters, "Day");
            this.subReport9.Report = new rptLowReport(_InputParameters, "Period");
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
        }

    }
}
