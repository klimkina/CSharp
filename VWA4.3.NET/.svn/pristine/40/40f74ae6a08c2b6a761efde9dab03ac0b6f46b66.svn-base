using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using Label = DataDynamics.ActiveReports.Label;
using TextBox = DataDynamics.ActiveReports.TextBox;

namespace Reports
{
    /// <summary>
    /// Summary description for rptGoalWeeklyStatus.
    /// </summary>
    public partial class rptGoalWeeklyStatus : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;

        public rptGoalWeeklyStatus(UserControls.ReportParameters parameters)
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

        /// <summary>
        /// Called before the report starts processing.
        /// This is where report object initialization occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rptGoalWeeklyStatus_ReportStart(object sender, EventArgs e)
        {
            lblTitle.Text = "Goal History";
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;

            var goals = GoalsDAO.DAO.GetAllGoals(VWA4Common.GlobalSettings.CurrentSiteID);
            if (goals.Count == 0) return;
            
            if (_InputParameters["RankBy"].ParamValue.Equals("Days Working"))
            {
                if (_InputParameters["RankOrder"].ParamValue.Equals("Descending"))
                    goals.Sort((g1, g2) => GoalsDAO.DAO.getAmount(g2, DateTime.Now).DaysWorking.CompareTo(GoalsDAO.DAO.getAmount(g1, DateTime.Now).DaysWorking));
                else if (_InputParameters["RankOrder"].ParamValue.Equals("Ascending"))
                    goals.Sort((g1, g2) => GoalsDAO.DAO.getAmount(g1, DateTime.Now).DaysWorking.CompareTo(GoalsDAO.DAO.getAmount(g2, DateTime.Now).DaysWorking));
            }
            else if (_InputParameters["RankBy"].ParamValue.Equals("Gap to Goal"))
            {
                if (_InputParameters["RankOrder"].ParamValue.Equals("Descending"))
                    goals.Sort((g1, g2) => Convert.ToDouble(getOnTrackAmount(g2, GoalsDAO.DAO.getAmount(g2, DateTime.Now))).CompareTo(Convert.ToDouble(getOnTrackAmount(g1, GoalsDAO.DAO.getAmount(g1, DateTime.Now)))));
                else if (_InputParameters["RankOrder"].ParamValue.Equals("Ascending"))
                    goals.Sort((g1, g2) => Convert.ToDouble(getOnTrackAmount(g1, GoalsDAO.DAO.getAmount(g1, DateTime.Now))).CompareTo(Convert.ToDouble(getOnTrackAmount(g2, GoalsDAO.DAO.getAmount(g2, DateTime.Now)))));
            }

            const float leftInc = (float) .9;
            const float topInc = (float).2;
            var left = (float) 0;
            var top = (float).30;
            detail.Controls.Add(new Label { Text = "Monitored Goals", Location = new PointF(left, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = 150 });
            detail.Controls.Add(new Label { Text = "Days Working", Location = new PointF(left += leftInc * 2, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = 150 });
            detail.Controls.Add(new Label { Text = "Type", Location = new PointF(left += leftInc * 2, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            detail.Controls.Add(new Label { Text = "Goal $/Lbs", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            detail.Controls.Add(new Label { Text = "Current Wk", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            detail.Controls.Add(new Label { Text = "Gap to Goal", Location = new PointF(left, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            top += topInc;
            var swt = 1;
            foreach(var g in goals)
            {
                left = 0;
                var gm = GoalsDAO.DAO.getAmount(g, DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek));
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = g.GoalName, Location = new PointF(left, top), Width = 150 });
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = DateTime.Now.Subtract(g.StartDate).Days.ToString(), Location = new PointF(left += leftInc * 2, top), Width = 150 });
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = g.GoalType.Equals(1) ? "Weight" : "Dollars", Location = new PointF(left += leftInc * 2, top) });
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = string.Format("{0}{1}{2}", g.GoalType.Equals(0) ? "$" : "", g.TargetAmount, g.GoalType.Equals(1) ? "Lbs" : ""), Location = new PointF(left += leftInc, top) });
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = string.Format("{0}{1}{2}", g.GoalType.Equals(0) ? "$" : "", gm.Amount, g.GoalType.Equals(1) ? "Lbs" : ""), Location = new PointF(left += leftInc, top) });
                detail.Controls.Add(new Label { BackColor = swt.Equals(1) ? Color.LightBlue : Color.WhiteSmoke, Text = string.Format("${0}", getOnTrackAmount(g, gm)), Location = new PointF(left, top) });
                top += topInc;
                swt *= -1;
            }
        }

        private string getSymbol(Goal g, GoalReportModel grm)
        {
            return grm.Amount > (decimal)0.00 ? "&loz;" : "";
        }

        private string getOnTrackBackgroundColor(Goal g, GoalReportModel grm)
        {
            string ontrack_amt;
            var real_amt = (decimal)0.00;
            var targetweeklyamount = (decimal)0.00;
            var currentweekamount = grm.Amount;
            var baselineweekamt = grm.BaselineWeekAmt;
            if (g.GoalMode == 0)
            { // Use Target percentage
                targetweeklyamount = baselineweekamt - (baselineweekamt * g.TargetPercentage / 100);
            }
            real_amt = (targetweeklyamount - currentweekamount);
            var color = getOnTrackColor(real_amt);
            return grm.Amount > (decimal)0.00 ? color : "";
        }

        private string getOnTrackColor(decimal amt)
        {
            if (amt <= -60)
            {
                return "green";
            }
            if (amt <= 0)
            {
                return "yellow";
            }
            return "red";
        }

        private string getOnTrackAmount(Goal g, GoalReportModel grm)
        {
            string ontrack_amt;
            var real_amt = (decimal)0.00;
            var targetweeklyamount = (decimal)0.00;
            var currentweekamount = grm.Amount;
            var baselineweekamt = grm.BaselineWeekAmt;
            if (g.GoalMode == 0)
            { // Use Target percentage
                targetweeklyamount = baselineweekamt - (baselineweekamt * g.TargetPercentage / 100);
            }
            real_amt = (targetweeklyamount - currentweekamount);
            real_amt = real_amt < 0 ? real_amt * -1 : real_amt;
            return currentweekamount == 0 ? "0" : string.Format("{0}", real_amt);
        }
    }
}
