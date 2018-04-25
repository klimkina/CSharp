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
    /// Summary description for rptLowReport.
    /// </summary>
    public partial class rptEmployeeException : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        public rptEmployeeException(UserControls.ReportParameters InputParameters)
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
        private int _iRow;
        private void rptEmployeeException_ReportStart(object sender, EventArgs e)
        {
            this._iRow = 0;

            //Dataset to hold data
            DataTable _ChartData = new DataTable();
            string where =  " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if(_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                where = where + " AND " + _InputParameters["Filter"].ParamValue;
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = @"SELECT UserType.TypeName AS Name, UserType.TypeID, MAX(WasteValue) AS Waste " +
                            " FROM  " +
							" (SELECT DISTINCT TypeID, UserType.TypeName, UserType.Enabled, 0 as WasteValue  " + 
                            " FROM UserType UNION " +
							" SELECT UserType.TypeID, UserType.TypeName, UserType.Enabled, COUNT(*) AS WasteValue  " +
                            " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID)" +
                            " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID )" +
                            (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                            where +
							" GROUP BY UserType.TypeID, UserType.TypeName, UserType.Enabled) WHERE UserType.Enabled=true " +
                            " GROUP BY UserType.TypeName, UserType.TypeID  HAVING MAX(WasteValue) = 0  " +
                            " ORDER BY UserType.TypeName;";

            _ChartData = VWA4Common.DB.Retrieve(select);
            if (_ChartData.Rows.Count > 0)
            {
                this.DataSource = _ChartData;
                this.DataMember = _ChartData.TableName;
                if (!Boolean.Parse(_InputParameters["IsToggleFooter"].ParamValue))
                {
                    this.txtFilter.Text = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_InputParameters["Filter"].DisplayValue);
                    if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                    {
                        this.txtFilter.Text = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_InputParameters["Filter"].DisplayValue);
                        if (this.txtFilter.Text != "")
                            this.txtFilter.Text = "Filters used: " + this.txtFilter.Text;
                    }

                    this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
                }
                txtPeriod.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
                if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                    this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                else
                    this.lblTitle.Text = "Employee Exception Report";
                txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                SetLogo();
            }
            else
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                    txtError.Text = "No Data for this period";
                else
                    this.Cancel();
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
            this._iRow++;
            this.lblRank.Text = this._iRow.ToString(System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
