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
    /// Summary description for rptConfiguration.
    /// </summary>
    public partial class rptConfiguration : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        public rptConfiguration(UserControls.ReportParameters parameters)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
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
        private int _NextSubReportNumber = 0;
        private DataDynamics.ActiveReports.SubReport GetSubReport()
        {
            DataDynamics.ActiveReports.SubReport subrep = new DataDynamics.ActiveReports.SubReport();
            subrep.Name = string.Format("Subreport{0}", _NextSubReportNumber);
            subrep.Height = 0.1F;
            subrep.Left = 0F;
            subrep.Width = 6.8F;
            subrep.Top = 2*_NextSubReportNumber * 0.1F;
            _NextSubReportNumber++;
            this.detail.Controls.Add(subrep);
            return subrep;
        }
        private void rptConfiguration_ReportStart(object sender, EventArgs e)
        {
            if (_InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            txtDBName.Text = new System.IO.FileInfo(VWA4Common.AppContext.DBPathName).Name;
            //this.lblDB.Text = "Current DataBase:" + VWA4Common.AppContext.DBPathName;
            SetLogo();
            txtPeriod.Text = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
            if (bool.Parse(_InputParameters["Database Statistics"].ParamValue))
                GetSubReport().Report = new rptConfigDB(_InputParameters, _NextSubReportNumber == 1);
            if (bool.Parse(_InputParameters["Site Info"].ParamValue))
                GetSubReport().Report = new rptConfigSites(_InputParameters, _NextSubReportNumber == 1);
            if (bool.Parse(_InputParameters["Master Type Catalog"].ParamValue) || (_InputParameters["Sub Type Catalogs"].ParamValue == ""))
            {
                if (bool.Parse(_InputParameters["Food Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Food", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Loss Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Loss", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Container Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Container", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["User Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "User", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Station Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Station", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Disposition Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Disposition", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Daypart Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "Daypart", "0", "Master", _NextSubReportNumber == 1);
                if (bool.Parse(_InputParameters["Event Order Types"].ParamValue))
                    GetSubReport().Report = new rptConfigTypes(_InputParameters, "BEO", "0", "Master", _NextSubReportNumber == 1);
            }
            else
            {
                string[] typeCatalogIDs = _InputParameters["Sub Type Catalogs"].ParamValue.Split(',');
                string[] typeCatalogNames = _InputParameters["Sub Type Catalogs"].DisplayValue.Split(',');
                for (int i = 0; i < typeCatalogIDs.Length; i++)
                {

                    if (bool.Parse(_InputParameters["Food Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Food", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Loss Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Loss", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Container Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Container", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["User Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "User", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Station Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Station", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Disposition Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Disposition", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Daypart Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "Daypart", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                    if (bool.Parse(_InputParameters["Event Order Types"].ParamValue))
                    {
                        GetSubReport().Report = new rptConfigTypes(_InputParameters, "BEO", typeCatalogIDs[i], typeCatalogNames[i], _NextSubReportNumber == 1);
                    }
                }
            }
            
            if (_InputParameters["Tracker Infos"].ParamValue != "")
            {
                GetSubReport().Report = new rptConfigTrackers(_InputParameters, _NextSubReportNumber == 1);
                string[] trackers = _InputParameters["Tracker Infos"].ParamValue.Split(',');
                string[] trackerNames = _InputParameters["Tracker Infos"].DisplayValue.Split(',');
                _NextSubReportNumber++;
                for (int i = 0; i < trackers.Length; i++)
                {
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Container", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Food", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Loss", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "UserQuestion", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "User", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Station", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Disposition", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "Daypart", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "BEO", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "PrePost", trackers[i], trackerNames[i]);
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, "PaperUI", trackers[i], trackerNames[i]);

                }
            }
            this.Document.Printer.Landscape = false;
            this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right);  
        }
    }
}
