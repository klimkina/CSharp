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
    /// Summary description for rptWeeklyTabular.
    /// </summary>
    public partial class rptWeeklyTabular : DataDynamics.ActiveReports.ActiveReport
    {

        public rptWeeklyTabular(UserControls.ReportParameters InputParameters)
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

        private void HideColumn(string columnName)
        {
            switch (columnName)
            {
                case "Inter":
                    lblInter.Visible = false;
                    txtInter.Visible = false;
                    txtInterAvg.Visible = false;
                    txtInterTotal.Visible = false;
                    break;
                case "Pre":
                    lblPre.Visible = false;
                    txtPre.Visible = false;
                    txtPreAvg.Visible = false;
                    txtPreTotal.Visible = false;
                    break;
                case "Post":
                    lblPost.Visible = false;
                    txtPost.Visible = false;
                    txtPostAvg.Visible = false;
                    txtPostTotal.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void MoveColumnsLeft()
        {
			int hiddencols = 0;
			if (!lblInter.Visible)
				hiddencols++;
			if (!lblPre.Visible)
				hiddencols++;
			if (!lblPost.Visible)
				hiddencols++;
			if (!lblInter.Visible)
            {
                lblPre.Left -= 1.19F;
                txtPre.Left -= 1.19F;
                txtPreAvg.Left -= 1.19F;
                txtPreTotal.Left -= 1.19F;
            }
			if (lblPost.Visible)
            {
				lblPost.Left -= 1.19F * hiddencols;
				txtPost.Left -= 1.19F * hiddencols;
				txtPostAvg.Left -= 1.19F * hiddencols;
				txtPostTotal.Left -= 1.19F * hiddencols;
            }

			lblTotal.Left -= 1.19F * hiddencols;
			txtTotal.Left -= 1.19F * hiddencols;
			txtTotalAvg.Left -= 1.19F * hiddencols;
			txtTotalTotal.Left -= 1.19F * hiddencols;

			line1.X2 -= 1.19F * hiddencols;
			line2.X2 -= 1.19F * hiddencols;
			line3.X2 -= 1.19F * hiddencols;
        }

        private DataTable _ChartData;
        private void rptWeeklyTabular_ReportStart(object sender, EventArgs e)
        {
            //Dataset to hold data
            _ChartData = new DataTable();

            string where = "", temp = "", text = "", total = "";
            // 0 - Post consumer waste, 1 - Pre consumer waste, 2 - Intermediate waste    
            // if we need to set IsPreconsumer filter
            if (!(bool.Parse(_InputParameters["IsPreConsumer"].ParamValue) &&
                bool.Parse(_InputParameters["IsPostConsumer"].ParamValue) && bool.Parse(_InputParameters["IsIntermediate"].ParamValue)))
            {
                if (bool.Parse(_InputParameters["IsIntermediate"].ParamValue))
                {
                    total = "IsPreconsumer = 0";
                    text = "Intermediate";
                }
                else 
                {
                    HideColumn("Inter");
                }
                if (bool.Parse(_InputParameters["IsPreConsumer"].ParamValue))
                {
                    temp = "IsPreconsumer = 1";
                    if (text == "")
                        text = "Pre-Consumer";
                    else
                        text = text + ", Pre-Consumer";
                }
                else
                {
                    HideColumn("Pre");
                }
                
                if (total != "" && temp != "")
                    total = total + " OR " + temp;
                else if (temp != "")
                    total = temp;
                temp = "";

                if (bool.Parse(_InputParameters["IsPostConsumer"].ParamValue))
                {
                    temp = "IsPreconsumer = 2";
                    if (text == "")
                        text = "Post-Consumer";
                    else
                        text = text + ", Post-Consumer ";
                }
                else
                {
                    HideColumn("Post");
                }
				MoveColumnsLeft();
                if (total != "" && temp != "")
                    total = total + " OR " + temp;
                else if (temp != "")
                    total = temp;
                temp = "";
                if (text != "")
                    text = text + " ";
            }
            
            if (_InputParameters["Filter"].ParamValue != "")
                temp = _InputParameters["Filter"].ParamValue;
            if (where != "" && temp != "")
                where = " WHERE (" + where + ") AND (" + temp + ")";
            else if(temp != "")
                where = " WHERE " + temp;
            else if (where != "")
                    where = " WHERE " + where;
            if(where != "")
                where += " AND SiteID = " + _InputParameters["SiteID"].ParamValue;
            else
                where = " WHERE SiteID = " + _InputParameters["SiteID"].ParamValue;
			bool isWasteClassesUsed = false; // (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1") || (_InputParameters["WasteClasses"].ParamValue.ToString() != "");
			//if (_InputParameters["WasteClasses"].ParamValue.ToString() != "")
			//    where += (where == "" ? " WHERE " : " AND (") + _InputParameters["WasteClasses"].ParamValue.ToString() + (where == "" ? "" : " )");
			//else // if (VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") != "-1")
			//    where += (where == "" ? " WHERE " + VWA4Common.VWACommon.GetWasteClasses() : " AND (") + VWA4Common.VWACommon.GetWasteClasses() + (where == "" ? "" : " )");

            string firstDayOfWeek = VWA4Common.GlobalSettings.FirstDayOfWeek;
            if (_InputParameters["SiteID"].ParamValue.ToString() != VWA4Common.GlobalSettings.CurrentSiteID.ToString())
                firstDayOfWeek = VWA4Common.GlobalSettings.GetFirstDayOfWeek(int.Parse(_InputParameters["SiteID"].ParamValue));

            int daysOffset = (7 - VWA4Common.VWACommon.NumberOfDayOfWeek(firstDayOfWeek)) % 7;
            //int daysOffset = (7 - int.Parse(this._InputParameters["FirstDayOfWeek"].ParamValue)) % 7;
            if (bool.Parse(_InputParameters["IsShowLbs"].ParamValue))
            {
                txtInter.OutputFormat = "#,##0 lbs";
                txtInterAvg.OutputFormat = "#,##0 lbs";
                txtInterTotal.OutputFormat = "#,##0 lbs";

                txtPre.OutputFormat = "#,##0 lbs";
                txtPreAvg.OutputFormat = "#,##0 lbs";
                txtPreTotal.OutputFormat = "#,##0 lbs";

                txtPost.OutputFormat = "#,##0 lbs";
                txtPostAvg.OutputFormat = "#,##0 lbs";
                txtPostTotal.OutputFormat = "#,##0 lbs";

                txtTotal.OutputFormat = "#,##0 lbs";
                txtTotalAvg.OutputFormat = "#,##0 lbs";
                txtTotalTotal.OutputFormat = "#,##0 lbs";
            }
            string criteria = !bool.Parse(_InputParameters["IsShowLbs"].ParamValue) ? "WasteCost" : "Weight - NItems*ContainerWeight";
            if (total != "")
                total = "IIF(" + total + ", " + criteria + ", 0)";
            else
                total = criteria;
            string select = @"SELECT SUM(IIF(IsPreconsumer = 0, " + criteria + ", 0)) AS InterWaste, " +
                " SUM(IIF(IsPreconsumer = 1, " + criteria + ", 0)) AS PreWaste, " +
                " SUM(IIF(IsPreconsumer = 2, " + criteria + ", 0)) AS PostWaste, " +
                 " SUM(" + total + ") AS TotalWaste, " +
                " Format(Weights.Timestamp + " + daysOffset + ", 'ww') as wDate, " +
                " Format(Weights.Timestamp + " + daysOffset + ", 'yyyyww') as yDate , " +
                " DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))))  as dDate " +
                " FROM ((Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey) LEFT JOIN LossType ON Weights.LossTypeID = LossType.TypeID )" +
                (isWasteClassesUsed ? " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID " : "") + 
                where +
                " GROUP BY Format(Weights.Timestamp + " + daysOffset + ", 'ww'), " +
                " Format(Weights.Timestamp + " + daysOffset + ", 'yyyyww'), " +
                " DateAdd('d', -" + (daysOffset + 6) + "-WeekDay(DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy'))),  DateAdd('ww', Format(Weights.Timestamp + " + daysOffset + ", 'ww'), DateValue('1/1/' & Format(Weights.Timestamp + " + daysOffset + ", 'yyyy')))), " +
                " Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", 'ww'), '00')" +
                " ORDER BY Format(Weights.Timestamp + " + daysOffset + ", 'yyyy') & Format(Format(Weights.Timestamp + " + daysOffset + ", 'ww'), '00') ASC;";
            _ChartData = VWA4Common.DB.Retrieve(select);

            txtSite.Text = _InputParameters["SiteID"].DisplayValue;
            lblTitle.Text = "Weekly Totals Report";
            if (_InputParameters["Title"] != null && _InputParameters["Title"].ParamValue != "")
                this.lblTitle.Text = _InputParameters["Title"].ParamValue;
            if (_InputParameters["SubTitle"] != null)
                txtSubTitle.Text = _InputParameters["SubTitle"].ParamValue;
            if (_InputParameters["Filter"].ParamValue != "")
                this.lblFooter.Text = "Filter used: " + _InputParameters["Filter"].DisplayValue;
            this.lblDB.Text = "Current DataBase:" + UserControls.VWAPath.ViewWasteDBName;
            txtPreconsumer.Text = text + "Food Waste";
            if (_ChartData.Rows.Count > 0)
            {
                this.DataSource = _ChartData;
                SetLogo();
                if (DateTime.Parse(_InputParameters["StartDate"].ParamValue).Year != DateTime.Parse(_InputParameters["EndDate"].ParamValue).Year)
                    txtWeekStart.OutputFormat = "d-MMM-yy";
            }
            else
            {
                this.DataSource = null;
                this.gpWeeklyTabular.Visible = false;
                imgLogo.Visible = false;
                lblWarning.Text = "Warning: No Data\n";
            }
            this.Document.Printer.Landscape = false;
            //this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }
        private int _iRow = 0;
        
        private void detail_Format(object sender, EventArgs e)
        {
            //if (_WeekNumber == 1) // hide "zero" week
            //    this.detail.Visible = false; 
            //else
            //{
                this.detail.Visible = true;
                // Check _iRow value to see if we need to highlight the row or not.
                if (this._iRow % 2 == 0)
                    this.detail.BackColor = Color.Transparent;
                else
                    this.detail.BackColor = Color.LightYellow;
                this._iRow++;
            //}
        }

        //int _WeekNumber;
        //// save current record's week number
        //private void rptWeeklyTabular_FetchData(object sender, FetchEventArgs eArgs)
        //{
        //    _WeekNumber = int.Parse(Fields["wDate"].Value.ToString());
        //}
    }
}
