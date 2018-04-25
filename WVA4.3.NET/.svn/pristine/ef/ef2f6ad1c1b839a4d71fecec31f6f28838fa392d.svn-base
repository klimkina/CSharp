using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Reports
{
    /// <summary>
    /// Summary description for rptConfigSites.
    /// </summary>
    public partial class rptConfigSites : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        bool _IsFirst;
        public rptConfigSites(UserControls.ReportParameters parameters, bool isFirst)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _IsFirst = isFirst;
        }

        private void AddPageBreak()
        {
            DataDynamics.ActiveReports.PageBreak pageBreak1 = new DataDynamics.ActiveReports.PageBreak();
            // 
            // pageBreak1
            // 
            pageBreak1.Border.BottomColor = System.Drawing.Color.Black;
            pageBreak1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.LeftColor = System.Drawing.Color.Black;
            pageBreak1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.RightColor = System.Drawing.Color.Black;
            pageBreak1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.TopColor = System.Drawing.Color.Black;
            pageBreak1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Height = 0.0625F;
            pageBreak1.Left = 0F;
            pageBreak1.Name = "pageBreakSites";
            pageBreak1.Size = new System.Drawing.SizeF(7.125F, 0.0625F);
            pageBreak1.Top = 0F;
            pageBreak1.Width = 7.125F;
            this.groupHeader1.Controls.Add(pageBreak1);
        }

		DataTable dt = null;
		private void rptConfigSites_ReportStart(object sender, EventArgs e)
		{
            if (!_IsFirst)
                AddPageBreak();
			if (bool.Parse(_InputParameters["Site Info"].ParamValue))
			{
				dt = VWA4Common.DB.Retrieve(
					"SELECT Sites.*, IIF(TypeCatalogs.TypeCatalogName IS NULL,'Master', TypeCatalogs.TypeCatalogName) AS TypeCatalogName, " +
                    " CustomerName, BUName, RegionName, DistrictName " +
					" FROM ((((Sites LEFT JOIN TypeCatalogs on Sites.TypeCatalogID = TypeCatalogs.ID) " +
                    " LEFT OUTER JOIN Customers ON Customers.ID = Sites.Customer) " +
                    " LEFT OUTER JOIN BusinessUnits ON BusinessUnits.ID = Sites.BusinessUnit) " +
                    " LEFT OUTER JOIN Regions ON Regions.ID = Sites.Region) " +
                    " LEFT OUTER JOIN Districts ON Districts.ID = Sites.District");
				this.DataSource = dt;

                this.Document.Printer.Landscape = false;
                this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right);
				//this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
			}
			else
				this.Cancel();
		}
		string _SiteID;
		private void rptConfigSites_FetchData(object sender, FetchEventArgs eArgs)
		{
			_SiteID = Fields["ID"].Value.ToString();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			//DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM GlobalVars WHERE SiteID = " + _SiteID);
			//DataColumn[] Keys = new DataColumn[1];
			//Keys[0] = dt.Columns["GVName"];
			//dt.PrimaryKey = Keys;

			int siteID = int.Parse(_SiteID);

			txtAdvancedReportFilters.Text = VWA4Common.Query.GetGlobalSetting("AdvancedFiltersOn", siteID);
			txtCycleTime.Text = VWA4Common.Query.GetGlobalSetting("CycleTime", siteID);
			txtEmptyReports.Text = VWA4Common.Query.GetGlobalSetting("ShowEmptyReports", siteID);
			txtFirstDayOfWeek.Text = VWA4Common.GlobalSettings.GetFirstDayOfWeek(siteID);
			txtFoodCostReportMode.Text = VWA4Common.Query.GetGlobalSetting("FoodCostReportPoints", siteID);
			txtPrimaryEmail.Text = VWA4Common.Query.GetGlobalSetting("PrimaryUserEmail", siteID);
			txtPrimaryUser.Text = VWA4Common.Query.GetGlobalSetting("PrimaryUserName", siteID);

            txtComputeMetod.Text = VWA4Common.GlobalSettings.GetBaselineWasteMethod(_SiteID) + " Average";
            txtAverageStart.Value = DateTime.Parse(VWA4Common.GlobalSettings.GetBaselineStartDate(_SiteID));
            txtNumOfWeeks.Text = VWA4Common.GlobalSettings.GetBaselineNumberofWeeks(_SiteID);
            txtWeeklyCost.Value = decimal.Parse(VWA4Common.GlobalSettings.GetBaselineWeeklyWasteCost(_SiteID));
            txtWeeklyTrans.Value = VWA4Common.GlobalSettings.GetBaselineWeeklyWasteTrans(_SiteID);

            txtActualFoodRevenue.Value = decimal.Parse(VWA4Common.GlobalSettings.GetBaselineMonthlyActualFoodRevenue(_SiteID));
            txtActualFoodCost.Value = decimal.Parse(VWA4Common.GlobalSettings.GetBaselineMonthlyActualFoodCost(_SiteID));
            txtActualMealCount.Value = decimal.Parse(VWA4Common.GlobalSettings.GetBaselineMonthlyActualMealCount(_SiteID));
		}
    }
}
