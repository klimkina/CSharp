using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Chart;
using DataDynamics.ActiveReports.Chart.Graphics;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;
using VWA4Common.DataObject;
using VWA4Common.DAO;

namespace Reports
{
	/// <summary>
	/// rptGoalListbyCompletion - Goals List by Completion Percentage Report.
	/// Supports Goals functionality.
	/// </summary>
	public partial class rptGoalListbyCompletion : DataDynamics.ActiveReports.ActiveReport
	{
		List<Goal> goalList;
		
		private UserControls.ReportParameters _InputParameters;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parameters"></param>
		public rptGoalListbyCompletion(UserControls.ReportParameters parameters)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_InputParameters = parameters;
		}


		private rptGoalListbyCompletion _rptGoalList;
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
		private void rptGoalListbyCompletion_ReportStart(object sender, EventArgs e)
		{
		    this.txtTable.Html = "";
		    this.txtTable.Text = "";

			lblTitle.Text = "Goals Completion Percentage";
			if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
				this.lblTitle.Text = _InputParameters["Title"].ParamValue;

            if(_InputParameters["ReportMode"].ParamValue == "0")
            {
                this.lblTitle.Text = "Goals Completion Percentage";
                chartControl1.Series[0].Marker = new Marker {Label = {Format = "{Value}%", Alignment = Alignment.TopRight}};
            }
            else if(_InputParameters["ReportMode"].ParamValue == "1")
            {
                this.lblTitle.Text = "Goals Days Working";
                chartControl1.Series[0].Marker = new Marker { Label = { Format = "{Value}", Alignment = Alignment.TopRight } };
            }
            else if (_InputParameters["ReportMode"].ParamValue == "2")
            {
                this.lblTitle.Text = "Goals Complete Percentage and Days Working";
            }
            
		    var li = new LegendItem
		                 {
		                     Backdrop =
		                         new Backdrop(BackdropStyle.Solid, Color.OrangeRed, Color.OrangeRed, GradientType.Horizontal,
		                                      HatchStyle.Horizontal, null, PicturePutStyle.Stretched),
                                              Text = getLengend()
		                 };
		    chartControl1.Legends[0].LegendItems.Add(li);
		    chartControl1.Series[0].AxisX.Position = 0.01;

		    var allGoals = new List<Goal>();
            if (Convert.ToInt32(_InputParameters["ReportMode"].ParamValue) < 2)
            {
                allGoals = GoalsDAO.DAO.GetAllGoals(VWA4Common.GlobalSettings.CurrentSiteID);
                var data = new List<string>();
                var dummydata = new List<string>();
                foreach (var goal in allGoals)
                {
                    var g = GoalsDAO.DAO.getAmount(goal, DateTime.Parse(_InputParameters["ReportDate"].ParamValue));
                    chartControl1.Series[0].AxisX.Labels.Add(goal.GoalName);
                    data.Add(getData(g, _InputParameters["ReportMode"].ParamValue));
                    dummydata.Add(string.Empty);
                }

                //set data source of chart
                chartControl1.Series[0].AxisX.Title = "";
                chartControl1.Series[0].AxisY.Title = "";
                try
                {
                    chartControl1.Series[0].Points.DataBindY(data);
                }
                catch (Exception)
                {
                }

                if (_InputParameters["ReportMode"].ParamValue == "0")
                {
                    //do days working
                    var html = "";
                    html = string.Format("<table width='100%' border='1'><tr><td>&nbsp;</td>");
                    foreach(var goal in allGoals)
                    {
                        html += string.Format("<td align='center'>{0}</td>", goal.GoalName);
                    }
                    html += "</tr>";
                    html += "<tr><td align='center'>Days</td>";
                    foreach(var goal in allGoals)
                    {
                        var g = GoalsDAO.DAO.getAmount(goal, DateTime.Parse(_InputParameters["ReportDate"].ParamValue));
                        html += string.Format("<td align='center'>{0}</td>", getData(g, "1"));
                    }
                    html += "</tr></table>";

                    txtTable.Html = html;
                }
                else if(_InputParameters["ReportMode"].ParamValue == "1")
                {
                    //do percentage
                    var html = "";
                    html = string.Format("<table width='100%' border='1'><tr><td>&nbsp;</td>");
                    foreach (var goal in allGoals)
                    {
                        html += string.Format("<td align='center'>{0}</td>", goal.GoalName);
                    }
                    html += "</tr>";
                    html += "<tr><td align='center'>Completion %</td>";
                    foreach (var goal in allGoals)
                    {
                        var g = GoalsDAO.DAO.getAmount(goal, DateTime.Parse(_InputParameters["ReportDate"].ParamValue));
                        html += string.Format("<td align='center'>{0}%</td>", getData(g, "0"));
                    }
                    html += "</tr></table>";

                    txtTable.Html = html;
                }
            }
            else
            {
                chartControl1.Legends[0].LegendItems.Clear();
                chartControl1.Legends[0].LegendItems.Add(new LegendItem
                                                             {
                                                                 Backdrop =
                                                                     new Backdrop(BackdropStyle.Solid, Color.OrangeRed,
                                                                                  Color.OrangeRed, GradientType.Horizontal,
                                                                                  HatchStyle.Horizontal, null,
                                                                                  PicturePutStyle.Centered),
                                                                 Text = "Comp %"
                                                             });
                chartControl1.Legends[0].LegendItems.Add(new LegendItem
                                                             {
                                                                 Backdrop =
                                                                     new Backdrop(BackdropStyle.Solid, Color.Green,
                                                                                  Color.Green, GradientType.Horizontal,
                                                                                  HatchStyle.Horizontal, null,
                                                                                  PicturePutStyle.Centered),
                                                                 Text = "Days"
                                                             });

                var series = (Series) chartControl1.Series[0].Clone();
                chartControl1.Series.Add(series);
                var percentData = new List<string>();
                var daysData = new List<string>();
                var dummydata = new List<string>();
                foreach (var goal in GoalsDAO.DAO.GetAllGoals(VWA4Common.GlobalSettings.CurrentSiteID))
                {
                    var g = GoalsDAO.DAO.getAmount(goal, DateTime.Parse(_InputParameters["ReportDate"].ParamValue));
                    chartControl1.Series[0].AxisX.Labels.Add(goal.GoalName);
                    var perc = getData(g, "0");
                    percentData.Add(perc.Equals("0") ? "0.01" : perc);
                    perc = getData(g, "1");
                    daysData.Add(perc.Equals("0") ? "0.01" : perc);
                    dummydata.Add(string.Empty);
                }
                chartControl1.Series[0].AxisX.Title = "";
                chartControl1.Series[0].AxisY.Title = "";

                if (_InputParameters["ReportMode"].ParamValue == "2")
                {
                    chartControl1.Series[0].Marker = new Marker { Label = { Format = "{Value}%", Alignment = Alignment.Right } };
                    chartControl1.Series[1].Marker = new Marker { Label = { Format = "{Value}", Alignment = Alignment.Right } };
                }

                try
                {
                    chartControl1.Series[0].Points.DataBindY(percentData);
                    chartControl1.Series[1].Points.DataBindY(daysData);
                }
                catch (Exception ex)
                {
                    string test = ex.Message;
                }
            }
		}

        private string getLengend()
        {
            switch (_InputParameters["ReportMode"].ParamValue)
            {
                case "0":
                    return "% Complete";
                case "1":
                    return "Days Working";
                case "2":
                    return "";
            }
            return "";
        }

        private string getData(GoalReportModel g, string reportMode)
        {
            switch (reportMode)
            {
                case "0":
                    return string.Format("{0}", Math.Round(g.PercentComplete, 0) * 100);
                case "1":
                    return g.DaysWorking.ToString();
                case "2":
                    break;
            }
            return string.Empty;
        }
	}
}
