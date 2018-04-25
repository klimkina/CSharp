using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace Reports
{
    /// <summary>
    /// Summary description for rptGoalList.
    /// </summary>
    public partial class rptGoalList : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;

        public rptGoalList()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public rptGoalList(UserControls.ReportParameters parameters)
        {
            InitializeComponent();
            _InputParameters = parameters;
        }

        private void rptGoalList_ReportStart(object sender, EventArgs e)
        {
            lblTitle.Text = "Goal List";
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

            const float leftInc = (float).9;
            const float topInc = (float).2;
            var left = (float)0;
            var top = (float).30;
            //detail.Controls.Add(new Label { Text = "Monitored Goals", Location = new PointF(left, top), BackColor = Color.SteelBlue, ForeColor = Color.White});
            //detail.Controls.Add(new Label { Text = "Start Date", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Target Date", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Baseline", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "52 Wk Lowest", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White});
            //detail.Controls.Add(new Label { Text = "52 Wk Highest", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White});
            //detail.Controls.Add(new Label { Text = "Days left", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White});
            //detail.Controls.Add(new Label { Text = "Avg Actual", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Gap of Avg", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Days Working", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Type", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Goal $/Lbs", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Current Wk", Location = new PointF(left += leftInc, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //detail.Controls.Add(new Label { Text = "Gap to Goal", Location = new PointF(left, top), BackColor = Color.SteelBlue, ForeColor = Color.White });
            //top += topInc;
            
            var swt = 1;
            foreach (var g in goals)
            {
                left = 0;
                var gm = GoalsDAO.DAO.getAmount(g, DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek));
                var daysLeft = DateTime.Now.Subtract(g.TargetDate).Days;
                var MaxMin = GoalsDAO.DAO.Get52WkData(g.ID);
                var avg = GoalsDAO.DAO.GetAvgActualData(g.ID);
                detail.Controls.Add(new Label { BackColor = Color.LightBlue, Text = "Monitored Goal: " + g.GoalName, Location = new PointF(left, top), Width=2 });
                detail.Controls.Add(new Label { BackColor = Color.LightBlue, Text = "Start Date: " + g.StartDate.ToShortDateString(), Location = new PointF(left += 2, top), Width = 2 });
                detail.Controls.Add(new Label { BackColor = Color.LightBlue, Text = "Target Date: " + g.TargetDate.ToShortDateString(), Location = new PointF(left += 2, top), Width = 2 });
                detail.Controls.Add(new Label { BackColor = Color.LightBlue, Text = "Baseline: " + GoalsDAO.DAO.getAmount(g, g.StartDate).BaselineWeekAmt, Location = new PointF(left += 2, top), Width = 2 });
                detail.Controls.Add(new Label { BackColor = Color.LightBlue, Text = "Goal: " + string.Format("{0}{1}{2}", g.GoalType.Equals(1) ? "$" : "", g.TargetAmount, g.GoalType.Equals(0) ? "Lbs" : ""), Location = new PointF(left += 2, top), Width = 2 });

                top += topInc;
                left = 0;

                detail.Controls.Add(new Label { Text = "52 Wk Lowest", Location = new PointF(left, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width=(float)1.33 });
                detail.Controls.Add(new Label { Text = "52 Wk Highest", Location = new PointF(left += (float)1.33, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = "Days left", Location = new PointF(left += (float)1.33, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float).66 });
                detail.Controls.Add(new Label { Text = "Avg Actual", Location = new PointF(left += (float).66, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1 });
                detail.Controls.Add(new Label { Text = "Gap of Avg", Location = new PointF(left += (float)1, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1 });
                detail.Controls.Add(new Label { Text = "Days Working", Location = new PointF(left += (float)1, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = "Type", Location = new PointF(left += (float)1.33, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = "Current Wk", Location = new PointF(left += (float)1.33, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = "Gap to Goal", Location = new PointF(left += (float)1.33, top), BackColor = Color.SteelBlue, ForeColor = Color.White, Width = (float)1.33 });

                top += topInc;
                left = 0;

                detail.Controls.Add(new Label { Text = MaxMin.Min.ToString(), Location = new PointF(left, top), Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = MaxMin.Max.ToString(), Location = new PointF(left += (float)1.33, top), Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = daysLeft < 0 ? "0" : daysLeft.ToString(), Location = new PointF(left += (float)1.33, top), Width = (float).66 });
                detail.Controls.Add(new Label { Text = avg.Avg.ToString(), Location = new PointF(left += (float).66, top), Width = (float)1 });
                detail.Controls.Add(new Label { Text = avg.GapOfAvg.ToString(), Location = new PointF(left += (float)1, top), Width = (float)1 });
                detail.Controls.Add(new Label { Text = DateTime.Now.Subtract(g.StartDate).Days.ToString(), Location = new PointF(left += (float)1, top), Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = g.GoalType.Equals(1) ? "Dollars" : "Weight", Location = new PointF(left += (float)1.33, top), Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = string.Format("{0}{1}{2}", g.GoalType.Equals(1) ? "$" : "", g.TargetAmount, g.GoalType.Equals(0) ? "Lbs" : ""), Location = new PointF(left += (float)1.33, top), Width = (float)1.33 });
                detail.Controls.Add(new Label { Text = string.Format("{0}", gm.GaptoGoal), Location = new PointF(left += (float)1.33, top), Width = (float)1.33 });

                top += topInc * 2;
            }

            foreach(var c in detail.Controls)
            {
                if (!(c is Label)) continue;
                (c as Label).Border.LeftStyle = BorderLineStyle.Solid;
                (c as Label).Border.RightStyle = BorderLineStyle.Solid;
                (c as Label).Border.TopStyle = BorderLineStyle.Solid;
                (c as Label).Border.BottomStyle = BorderLineStyle.Solid;
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
