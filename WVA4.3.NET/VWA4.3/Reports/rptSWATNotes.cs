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
    /// Summary description for rptSWATNotes.
    /// </summary>
    public partial class rptSWATNotes : DataDynamics.ActiveReports.ActiveReport
    {

        public rptSWATNotes(UserControls.ReportParameters InputParameters)
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
        private void rptSWATNotes_ReportStart(object sender, EventArgs e)
        {
            DataTable dt;
            bool isEmpty = true; // indicates that no data were selected from the table
            //Dataset to hold data
            _ChartData = new DataTable();

            string firstDayOfWeek = VWA4Common.GlobalSettings.FirstDayOfWeek;
            if (_InputParameters["SiteID"].ParamValue.ToString() != VWA4Common.GlobalSettings.CurrentSiteID.ToString())
                firstDayOfWeek = VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(_InputParameters["SiteID"].ParamValue));

            int daysOffset = (7 - VWA4Common.VWACommon.NumberOfDayOfWeek(firstDayOfWeek)) % 7;
            string swatDate = DateTime.Parse(_InputParameters["SWATDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
            dt = VWA4Common.DB.Retrieve("SELECT " +
                    " DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(#" + swatDate + "# + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(#" + swatDate + "# + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(#" + swatDate + "# + " + daysOffset + ", 'yyyy'))))  as dDate ");
                    
            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            txtDate.Text = DateTime.Parse(_InputParameters["SWATDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
            if(dt.Rows.Count > 0)
                txtPeriods.Text = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " +
                    DateTime.Parse(dt.Rows[0][0].ToString()).AddDays(6).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
            else
                txtPeriods.Text = DateTime.Parse(_InputParameters["SWATDate"].ParamValue).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + " - " +
                    DateTime.Parse(_InputParameters["SWATDate"].ParamValue).AddDays(6).ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));

            dt = VWA4Common.DB.Retrieve("SELECT *, " +
                    " DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(#" + swatDate + "# + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(#" + swatDate + "# + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(#" + swatDate + "# + " + daysOffset + ", 'yyyy'))))  as dDate " +
                    " FROM SWATMinutes LEFT OUTER JOIN UserType ON SWATMinutes.AwardUserID = UserType.TypeID" +
                    " WHERE Format(WeekStart + " + daysOffset + ", 'yyyyww') = Format(#" + swatDate + "# + " + daysOffset + ", 'yyyyww') " +
                    " AND SiteID = " + _InputParameters["SiteID"].ParamValue);

            isEmpty &= (dt.Rows.Count <= 0);
            if (dt.Rows.Count > 0)
            {
                txtTop10Lists.Text = dt.Rows[0]["Top10Review"].ToString();
                txtGoals.Text = dt.Rows[0]["GoalsReview"].ToString();
                txtKeySuccess.Text = dt.Rows[0]["KeySuccess"].ToString();
                txtAward.Text = dt.Rows[0]["TypeName"].ToString() + ": " + dt.Rows[0]["AwardType"].ToString() + " for " + dt.Rows[0]["AwardReason"].ToString() + ".";

                txtGoalParticipation.Text = "Goals Participation (1 being lowest): " + dt.Rows[0]["GoalsRating"].ToString();
                txtWeeklyParticipation.Text = "Weekly Participation (1 being lowest): " + dt.Rows[0]["ParticipationRating"].ToString();
            }
                string where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue + " AND " +
                    " (Format([Weights.Timestamp] + " + daysOffset + ", 'yyyyww') = Format(#" + swatDate + "# + " + daysOffset + ", 'yyyyww'))";
                if (_InputParameters["Filter"] != null && _InputParameters["Filter"].ParamValue != "")
                    where += " AND (" + _InputParameters["Filter"].ParamValue + ")";

                string select = @"SELECT TOP 5 WasteCost, (Weight - NItems*ContainerWeight) AS NetWeight, FoodType.TypeName as FoodName, LossType.TypeName as LossName, UserType.TypeName as UserName " +
                    " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                    where +
                    " ORDER BY WasteCost DESC";
                _ChartData = VWA4Common.DB.Retrieve(select);
                isEmpty &= (_ChartData.Rows.Count <= 0);

                this.DataSource = _ChartData;
                if (_ChartData.Rows.Count <= 0)
                {
                    gpTable.Visible = false;
                    lblNoData.Text = "No Data";
                }

                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) as Waste, Count(*) as TransNum " +
                    " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                    where);
                isEmpty &= (dt.Rows.Count > 0 && dt.Rows[0]["Waste"].ToString() == "");
                double wasteCost = 0;
                if (dt.Rows.Count > 0)
                {
                    double.TryParse(dt.Rows[0]["Waste"].ToString(), out wasteCost);
                    txtWasteCost.Value = wasteCost;
                    txtTransactions.Text = dt.Rows[0]["TransNum"].ToString();
                }
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) AS Waste, FoodTypeID, FoodType.TypeName " +
                    " FROM ((((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID) " +
                    where +
                    " GROUP BY FoodTypeID, FoodType.TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");

                if (dt.Rows.Count > 0)
                {
                    txtMostWasted.Text = dt.Rows[0]["TypeName"].ToString();
                    isEmpty &= (dt.Rows[0]["Waste"].ToString() == "");
                }
                
                dt = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) AS Waste, LossTypeID, LossType.TypeName " +
                    " FROM (((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) " +
                    " LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID) " +
                    " LEFT JOIN UserType ON Weights.UserTypeID = UserType.TypeID) " +
                    where +
                    " GROUP BY LossTypeID, LossType.TypeName " +
                    " ORDER BY SUM(WasteCost) DESC;");
                
                if (dt.Rows.Count > 0)
                {
                    txtReason.Text = dt.Rows[0]["TypeName"].ToString();
                    isEmpty &= (dt.Rows[0]["Waste"].ToString() == "");
                }
                SetLogo();
                lblTitle.Text = "Stop Waste Action Team Notes";
                if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                    this.lblTitle.Text = _InputParameters["Title"].ParamValue;
                if (_InputParameters["SubTitle"] != null)
                    txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
                if (_InputParameters["Filter"].ParamValue != "")
                    this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
                this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;

            if(isEmpty)
            {
                if (bool.Parse(VWA4Common.GlobalSettings.ShowEmptyReports))
                {
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
