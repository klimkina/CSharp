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
    /// Summary description for rptSWATForm.
    /// </summary>
    public partial class rptSWATForm : DataDynamics.ActiveReports.ActiveReport
    {

        public rptSWATForm(UserControls.ReportParameters InputParameters)
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
        private void rptSWATForm_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            _ChartData = new DataTable();

            string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
            if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                where += " AND (" + _InputParameters["Filter"].ParamValue + ")";

			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = @"SELECT TOP 5 WasteCost, (Weight - NItems*ContainerWeight) AS NetWeight, FoodType.TypeName as FoodName, LossType.TypeName as LossName, UserType.TypeName as UserName " +
                " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                where +
                " ORDER BY WasteCost DESC";
            _ChartData = VWA4Common.DB.Retrieve(select);
            this.DataSource = _ChartData;

            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            txtDate.Text = DateTime.Parse(_InputParameters["SWATDate"].ParamValue).ToString("MM/dd/yyyy");
            txtPeriods.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy");

            if (_ChartData.Rows.Count > 0)
            {
                DataTable dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) as Waste, Count(*) as TransNum " +
                    " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                    where);
                double wasteCost = 0;
                if (dt.Rows.Count > 0)
                {
                    double.TryParse(dt.Rows[0]["Waste"].ToString(), out wasteCost);
                    txtWasteCost.Value = wasteCost;
                    txtTransactions.Text = dt.Rows[0]["TransNum"].ToString();
                }
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost), FoodTypeID, FoodType.TypeName " +
                    " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                    where +
                    " GROUP BY FoodTypeID, FoodType.TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");
                if (dt.Rows.Count > 0)
                    txtMostWasted.Text = dt.Rows[0]["TypeName"].ToString();
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost), LossTypeID, LossType.TypeName " +
                    " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    where +
                    " GROUP BY LossTypeID, LossType.TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");
                if (dt.Rows.Count > 0)
                    txtReason.Text = dt.Rows[0]["TypeName"].ToString();
                SetLogo();
                lblTitle.Text = "Stop Waste Action Team Notes";
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
                    gpResize.Visible = false;
                    lblNoData.Text = "No Data";

                    txtWasteCost.Text = "No Data";
                    txtTransactions.Text = "No Data";
                    txtMostWasted.Text = "No Data";
                    txtReason.Text = "No Data";
                    txtWasteCost.ForeColor = Color.Red;
                    txtTransactions.ForeColor = Color.Red;
                    txtMostWasted.ForeColor = Color.Red;
                    txtReason.ForeColor = Color.Red;
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
