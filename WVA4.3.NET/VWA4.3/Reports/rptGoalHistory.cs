using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;
using VWA4Common.DataObject;
using VWA4Common.DAO;
using Label = DataDynamics.ActiveReports.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace Reports
{
	/// <summary>
	/// rptGoalListbyCompletion - Goals List by Completion Percentage Report.
	/// Supports Goals functionality.
	/// </summary>
	public partial class rptGoalHistory : DataDynamics.ActiveReports.ActiveReport
	{
		private UserControls.ReportParameters _InputParameters;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parameters"></param>
        public rptGoalHistory(UserControls.ReportParameters parameters)
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
        private void rptGoalHistory_ReportStart(object sender, EventArgs e)
		{
		    var startDate = DateTime.Parse(_InputParameters["StartDate"].ParamValue);
		    var endDate = DateTime.Parse(_InputParameters["EndDate"].ParamValue);
            lblTitle.Text = "Single Goal History";
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;

		    var goal = GoalsDAO.DAO.Load(Convert.ToInt32(_InputParameters["GoalId"].ParamValue));
            if (goal == null) return;

		    detail.Controls.Add(new Label
		                            {Text = "Date: " + DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek)});
            
		    var ts = endDate.Subtract(startDate);
            const float leftInc = (float).9;
            const float topInc = (float).2;
            var left = (float)0;
            var top = (float).25;

		    detail.Controls.Add(new Label {Text = goal.GoalName, Location = new PointF(left + (leftInc * 3), top), Alignment = TextAlignment.Center, Font = new Font(FontFamily.GenericSerif, 11, FontStyle.Bold)});
		    top += topInc;

            detail.Controls.Add(new Label { Text = "Progress", Location = new PointF(left, top) });
            detail.Controls.Add(new Label { Text = "Target $", Location = new PointF(left += leftInc, top) });
            detail.Controls.Add(new Label { Text = "Actual $", Location = new PointF(left += leftInc, top) });
            detail.Controls.Add(new Label { Text = "On Track", Location = new PointF(left += leftInc, top) });
            top += topInc;
            for(var i = ts.Days; i >= 7; i -= 7)
            {
                var gm = GoalsDAO.DAO.getAmount(goal, DateTime.Now.AddDays(i*-1));
                left = 0;
                detail.Controls.Add(new Label { Text = DateTime.Now.AddDays(i * -1).ToString("M/dd/yy"), Location = new PointF(left, top) });
                detail.Controls.Add(new Label { Text = getTargetAmount(goal, gm).ToString(), Location = new PointF(left += leftInc, top) });
                detail.Controls.Add(new Label { Text = getActualAmount(goal, gm), Location = new PointF(left += leftInc, top) });
                detail.Controls.Add(new Label { Text = getOnTrackAmount(goal, gm), Location = new PointF(left += leftInc, top), BackColor = getOnTrackBackgroundColor(goal, gm), ForeColor = Color.White });
                top += topInc;
            }
        }

        private string getSymbol(Goal g, GoalReportModel grm)
        {
            return grm.Amount > (decimal)0.00 ? "&loz;" : "";
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
                targetweeklyamount = Math.Round((baselineweekamt - g.TargetAmount) / weeks, 1);
            }
            return Math.Round(targetweeklyamount, 2);
        }

        private string getActualAmount(Goal g, GoalReportModel grm)
        {
            string cw_amt;
            var currentweekamount = grm.Amount;
            if (g.GoalType == 0)
            { // Dollars
                cw_amt = "$ " + currentweekamount.ToString("#####0.00");
            }
            else
            {
                cw_amt = currentweekamount.ToString("#####0.00") + " lb.";
            }

            return currentweekamount == 0 ? "" : cw_amt;
        }

        private string getOnTrackAmount(Goal g, GoalReportModel grm)
        {
            string ontrack_amt;
            var real_amt = (decimal) 0.00;
            var targetweeklyamount = (decimal) 0.00;
            var currentweekamount = grm.Amount;
            var baselineweekamt = grm.BaselineWeekAmt;
            if (g.GoalMode == 0)
            { // Use Target percentage
                targetweeklyamount = baselineweekamt - (baselineweekamt * g.TargetPercentage / 100);
            }
            real_amt = (targetweeklyamount - currentweekamount);
            var color = getOnTrackColor(real_amt);
            real_amt = real_amt < 0 ? real_amt*-1 : real_amt;
            if (g.GoalType == 0)
            { // Dollars
                ontrack_amt = "$ " + real_amt.ToString("####0.00");
            }
            else
            {
                ontrack_amt = real_amt.ToString("####0.00") + " lb.";
            }
            return currentweekamount == 0 ? "" : string.Format("{0}", ontrack_amt);
            //return currentweekamount == 0 ? "" : string.Format("<div'><font color='{0}'>{1}</font></div>", color, ontrack_amt);
        }

        private Color getOnTrackBackgroundColor(Goal g, GoalReportModel grm)
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
            return grm.Amount > (decimal)0.00 ? color : Color.White;
        }

        private Color getOnTrackColor(decimal amt)
        {
            if(amt <= -60)
            {
                return Color.Green;
            }
            if(amt <= 0)
            {
                return Color.Yellow;
            }
            return Color.Red;
        }
	}
}
