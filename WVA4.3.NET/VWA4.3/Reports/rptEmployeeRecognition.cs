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
    /// Summary description for rptEmployeeRecognition.
    /// </summary>
    public partial class rptEmployeeRecognition : DataDynamics.ActiveReports.ActiveReport
    {
        public rptEmployeeRecognition(UserControls.ReportParameters InputParameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = InputParameters;
        }

        private UserControls.ReportParameters _InputParameters;

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

        private DataTable _ChartData;
        private void rptEmployeeRecognition_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            _ChartData = new DataTable();

            string select = @"SELECT WeekStart, AwardUserID, AwardType, AwardReason, TypeName AS UserName " +
                                " FROM SWATMinutes INNER JOIN UserType ON SWATMinutes.AwardUserID = UserType.TypeID " +
                                " WHERE SiteID = " +_InputParameters["SiteID"].ParamValue +
                                " AND WeekStart >= #" + _InputParameters["StartDate"].ParamValue + 
                                "# AND WeekStart < #" + _InputParameters["EndDate"].ParamValue + "#" +
                                " ORDER BY WeekStart ASC";
            _ChartData = VWA4Common.DB.Retrieve(select);
			this.DataSource = _ChartData;
			txtSite.Text = _InputParameters["SiteID"].DisplayValue;
			txtPeriods.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
                
            if (_ChartData.Rows.Count > 0)
            {
                SetLogo();
                lblTitle.Text = "Employee Recognition";
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
                    gpTable.Visible = false;
					imgLogo.Visible = false;
                    lblWarning.Text = "Warning: No Data\n";
					lblWarning.ForeColor = Color.Red;
                }
                else
                    this.Cancel();
            }

            this.Document.Printer.Landscape = false;
            //this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }

    }
}
