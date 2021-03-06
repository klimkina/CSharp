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
    /// Summary description for rptLowReport.
    /// </summary>
    public partial class rptEmployee : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        public rptEmployee(UserControls.ReportParameters InputParameters)
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
        private void rptEmployee_ReportStart(object sender, EventArgs e)
        {
            this._iRow = 0;

            //Dataset to hold data
            DataTable _ChartData = new DataTable();
            string criteria;
            if (bool.Parse(_InputParameters["IsOrderByWeight"].ParamValue))
            {
                criteria = " SUM(Weight - NItems*ContainerWeight) ";
                txtOrder.Text = "Total weight";
            }
            else
            {
                criteria = " COUNT(*) ";
                txtOrder.Text = "Total number of transactions";
            }
            string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if(_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                where += " AND (" + _InputParameters["Filter"].ParamValue + ")";
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else //if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = @"SELECT UserType.TypeID, UserType.TypeName AS Name, COUNT(*) AS WasteCount, SUM(Weight - NItems*ContainerWeight) AS WasteWeight  " +
                            " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                            " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID)" +
                            (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                            where +
                            " GROUP BY UserType.TypeID, UserType.TypeName  " +
                            " ORDER BY " + criteria + " DESC;";


            _ChartData = VWA4Common.DB.Retrieve(select);
            
            this.DataSource = _ChartData;
            this.DataMember = _ChartData.TableName;
            this.txtFilter.Text = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_InputParameters["Filter"].DisplayValue);
            if (this.txtFilter.Text != "")
                this.txtFilter.Text = "Filters used: " + this.txtFilter.Text;
            txtPeriod.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy");
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            else
                this.lblTitle.Text = "Total Waste by Employee";
            txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            SetLogo();
            if (_ChartData.Rows.Count <= 0)
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                    txtError.Text = "No Data for this period";
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = true;
            //this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
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
