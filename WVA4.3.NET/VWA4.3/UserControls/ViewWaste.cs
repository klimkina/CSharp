using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class ViewWaste : Form
    {
        public ViewWaste()
        {
            InitializeComponent();
			updateProductUI();
		}

        public ViewWaste(string configName)
        {
            InitializeComponent();
			updateProductUI();
			this.ucViewWeights1.ConfigReportName = configName;
        }
        public ViewWaste(UCViewWeights.DisplayMode mode)
        {
            InitializeComponent();
			updateProductUI();
			this.ucViewWeights1.Mode = mode;
            switch(mode)
            {
                case UCViewWeights.DisplayMode.Both:
                    this.Text = "View Weights and Transfers data";
                    break;
                case UCViewWeights.DisplayMode.Produced:
                    this.Text = "View Produced data";
                    break;
                case UCViewWeights.DisplayMode.ErrorWeights:
                    this.Text = "View Error Weights data";
                    break;
                case UCViewWeights.DisplayMode.ErrorProduced:
                    this.Text = "View Error Produced data";
                    break;
                default:
                    this.Text = "View Weights";
                    break;
            }
        }

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Form background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		public string Caption
        { set { this.Text = value; } }
        public string GetFilters()
        {
            DateTime now = DateTime.Now;
            return GetFilters(ref now);
        }

        public string GetFilters(ref DateTime startDate)
        {
            return ucViewWeights1.GetFilters(ref startDate);
        }
        public string GetFiltersString()
        {
            return ucViewWeights1.GetFiltersString();
        }
        private void ucViewWeights1_DataSaved(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ucViewWeights1_Canceled(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddPeriodFilter(DateTime startDate, DateTime endDate)
        {
            ucViewWeights1.AddPeriodFilter(startDate, endDate);
        }
        public void AddTypeFilter(string name, string value)
        {
            ucViewWeights1.AddTypeFilter(name, value);
        }
        public void AddFilter(string filter, string displayFilter)
        {
            ucViewWeights1.AddFilter(filter, displayFilter);
        }
        public void SetSiteID(string siteID, string siteName)
        {
            ucViewWeights1.SetSiteID(siteID, siteName);
        }
        public void SetDefaultPreconsumer(string filter, string displayFilter)
        {
            ucViewWeights1.SetDefaultPreconsumer(filter, displayFilter);
        }
		///SAR - Remove waste classes 010311 ; Jira VWAAMWT-240
		//public void AddWasteClassFilter(string filter, string displayFilter)
		//{
		//    ucViewWeights1.SetWasteClassFilter(filter, displayFilter);
		//}
        public void HideSite()
        {
            ucViewWeights1.HideSite();
        }
        public void LoadParameters(int id)
        {
            ucViewWeights1.ConfigReportID = id;
        }
        public void Print(int id)
        {
            ucViewWeights1.ConfigReportID = id;
            ucViewWeights1.PrintGrid(false);
            
        }
    }

}
