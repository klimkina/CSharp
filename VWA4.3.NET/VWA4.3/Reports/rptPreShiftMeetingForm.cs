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
    /// Summary description for rptPreShiftMeetingForm.
    /// </summary>
    public partial class rptPreShiftMeetingForm : DataDynamics.ActiveReports.ActiveReport
    {

        public rptPreShiftMeetingForm(UserControls.ReportParameters InputParameters)
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

        private void rptPreShiftMeetingForm_ReportStart(object sender, EventArgs e)
        {
            string where = " WHERE [Weights.Timestamp] >= #" + _InputParameters["StartDate"].ParamValue +
                    "# AND [Weights.Timestamp] < #" + _InputParameters["EndDate"].ParamValue + "# AND " +
                    " SiteID = " + _InputParameters["SiteID"].ParamValue;

			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? "" : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where = (where == "" ? VWA4Common.VWACommon.GetWasteClasses() : "(" + where + ") AND (" + VWA4Common.VWACommon.GetWasteClasses() + ")");

            string select = @"SELECT COUNT(*) as TransNum, UserTypeID, TypeName " +
                    " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID)" +
                    (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") +
                    where +
                    " GROUP BY UserTypeID, TypeName " +
                    " ORDER BY COUNT(*) DESC";
            DataTable dt = VWA4Common.DB.Retrieve(select);
            txtPeriods.Text = DateTime.Parse(_InputParameters["StartDate"].ParamValue).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(_InputParameters["EndDate"].ParamValue).ToString("MM/dd/yyyy");
            txtPeriod.Text = txtPeriods.Text;
            txtDate.Text = DateTime.Parse(_InputParameters["SWATDate"].ParamValue).ToString("MM/dd/yyyy");
            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            SetLogo();
            lblTitle.Text = "Staff Mtg. Agenda";
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            if (_InputParameters["SubTitle"] != null)
                txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            if (_InputParameters["Filter"].ParamValue != "")
                this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;

            if (dt.Rows.Count > 0)
            {
                txtEmpTransactions.Text = dt.Rows[0]["TypeName"].ToString();
                dt = VWA4Common.DB.Retrieve("SELECT SUM(Weight - NItems*ContainerWeight) as Weight, UserTypeID, TypeName " +
                    " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " INNER JOIN UserType ON Weights.UserTypeID = UserType.TypeID" +
                    where +
                    " GROUP BY UserTypeID, TypeName " +
                    " ORDER BY SUM(Weight) DESC");
                txtEmpWeight.Text = dt.Rows[0]["TypeName"].ToString();

                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) as Waste, Count(*) as TransNum " +
                    " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " + where);
                double wasteCost = 0;
                double.TryParse(dt.Rows[0]["Waste"].ToString(), out wasteCost);
                txtWasteCost.Value = wasteCost;
                txtTransactions.Text = dt.Rows[0]["TransNum"].ToString();
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost), FoodTypeID, TypeName " +
                    " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " INNER JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " +
                    where +
                    " GROUP BY FoodTypeID, TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");
                txtMostWasted.Text = dt.Rows[0]["TypeName"].ToString();
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost), LossTypeID, TypeName " +
                    " FROM (Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " INNER JOIN LossType ON Weights.LossTypeID = LossType.TypeID " +
                    where +
                    " GROUP BY LossTypeID, TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");
                txtReason.Text = dt.Rows[0]["TypeName"].ToString();
            }
            else
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {
                    txtWasteCost.Text = "No Data";
                    txtTransactions.Text = "No Data";
                    txtMostWasted.Text = "No Data";
                    txtReason.Text = "No Data";
                    txtEmpTransactions.Text = "No Data";
                    txtEmpWeight.Text = "No Data";
                    txtWasteCost.ForeColor = Color.Red;
                    txtTransactions.ForeColor = Color.Red;
                    txtMostWasted.ForeColor = Color.Red;
                    txtReason.ForeColor = Color.Red;
                    txtEmpTransactions.ForeColor = Color.Red;
                    txtEmpWeight.ForeColor = Color.Red;
                    imgLogo.Visible = false;
                    lblWarning.Text = "Warning: No Data\n";
                    lblWarning.ForeColor = Color.Red;
                    imgLogo.Visible = false;
                    lblWarning.Text = "Warning: No Data\n";
                }
                else
                    this.Cancel();
            }
            this.Document.Printer.Landscape = false;
            //this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }

    }
}
