using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Chart;
using DataDynamics.ActiveReports.Document;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace Reports
{
    /// <summary>
    /// Summary description for rptGoalProgress.
    /// </summary>
    public partial class rptGoalProgress : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;

        public rptGoalProgress(UserControls.ReportParameters parameters)
        {
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

        private void rptGoalProgress_ReportStart(object sender, EventArgs e)
        {
            this.lblReportTitle.Text = "Goal Progress";
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblReportTitle.Text = _InputParameters["Title"].ParamValue;

            var goal = GoalsDAO.DAO.Load(Convert.ToInt32(_InputParameters["GoalId"].ParamValue));
            if (goal == null) return;

            chartControl1.Series[0].AxisY.Title = goal.GoalType.Equals(0) ? "%" : "$";

            var ts = DateTime.Now.Subtract(goal.StartDate);
            var dt = new DataTable();
            dt.Columns.Add("Actual", typeof (decimal));
            dt.Columns.Add("Target", typeof (decimal));
            dt.Columns.Add("Date", typeof (DateTime));
            decimal target_display = (decimal)0.00;
            for (var i = ts.Days; i >= 7; i -= 7)
            {
                var gm = GoalsDAO.DAO.getAmount(goal, DateTime.Now.AddDays(i * -1));
                var actual = getActualAmount(goal, gm);
                target_display = getTargetAmount(goal, gm);
                if(actual.Length == 0)
                    continue;
                dt.Rows.Add(actual.Length == 0 ? "0.00" : actual, target_display, DateTime.Now.AddDays(i*-1).ToShortDateString());
            }

            chartControl1.DataSource = dt;
        }

        private decimal getTargetAmount(Goal g, GoalReportModel grm)
        {
            string cw_amt = string.Empty;
            string bw_amt = string.Empty;
            string tar_amt = string.Empty;
            var currentweekamount = grm.Amount;
            var baselineweekamt = grm.BaselineWeekAmt;
            var targetweeklyamount = baselineweekamt - g.TargetAmount;
            if (g.GoalMode == 0)
            { // Use Target percentage
                targetweeklyamount = baselineweekamt - (baselineweekamt * g.TargetPercentage / 100);
            }
            else
            {
                var weeks = Math.Round((decimal)(g.TargetDate.Subtract(g.StartDate).Days) / 7);
                targetweeklyamount = Math.Round((baselineweekamt - g.TargetAmount) / weeks, 0);
            }
            return targetweeklyamount;
        }

        private string getActualAmount(Goal g, GoalReportModel grm)
        {
            string cw_amt;
            var currentweekamount = grm.Amount;
            if (g.GoalType == 0)
            { // Dollars
                cw_amt = currentweekamount.ToString("#####0.00");
            }
            else
            {
                cw_amt = currentweekamount.ToString("#####0.00");
            }

            return currentweekamount == 0 ? "" : cw_amt;
        }
    }
}
