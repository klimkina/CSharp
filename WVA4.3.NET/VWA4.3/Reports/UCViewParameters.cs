using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class UCViewParameters : UserControl
    {
        public UCViewParameters()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            this.Controls.Clear();
        }
        public void ReloadReport(int reportID)
        {
            ClearControls();
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + reportID +
                " AND ParamName <> 'ReportID' ORDER BY ParamName");
            BuildView(dt, false);
        }

        public void Reload(int reportSet)
        {
            ClearControls();
            bool isReportSet = true;
            DataTable dt = VWA4Common.DB.Retrieve("SELECT ReportMappedParam.*, ReportSet.ReportMemorized AS ReportMemorized, " +
                    " ReportSet.SerieID, ReportSet.Order, OutputSetID AS OutputID" +
                    " FROM ReportMappedParam LEFT JOIN ReportSet ON ReportMappedParam.ReportSet = ReportSet.ID WHERE ReportSet = " + reportSet);
            if (dt.Rows.Count < 1)
            {
                dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized IN (SELECT ReportMemorized FROM ReportSet WHERE ID = " + reportSet + ")");
                isReportSet = false;
            }
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(null, "No stored parameters for this Report found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BuildView(dt, isReportSet);
            }
        }

        private void BuildView(DataTable dt, bool isReportSet)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                System.Windows.Forms.Label lblParamName = new System.Windows.Forms.Label();
                System.Windows.Forms.ComboBox cbSettings = new System.Windows.Forms.ComboBox();
                System.Windows.Forms.ComboBox cbGlobalVars = new System.Windows.Forms.ComboBox();
                System.Windows.Forms.Label lblFrom = new System.Windows.Forms.Label();
                System.Windows.Forms.ComboBox cbPrevReports = new System.Windows.Forms.ComboBox();
                System.Windows.Forms.ComboBox cbOutputParams = new System.Windows.Forms.ComboBox();
                UserControls.SmartDateTimePicker dtPicker = new UserControls.SmartDateTimePicker();
                // 
                // lblParamName
                // 
                lblParamName.AutoSize = true;
                lblParamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                lblParamName.Location = new System.Drawing.Point(3, 12 + i * 22);
                lblParamName.Name = "lblName" + i;
                lblParamName.Size = new System.Drawing.Size(100, 13);
                lblParamName.TabIndex = i * 10;
                lblParamName.Text = row["ParamName"].ToString();
                this.Controls.Add(lblParamName);
                // 
                // lblFrom
                // 
                lblFrom.AutoSize = true;
                lblFrom.Location = new System.Drawing.Point(126, 12 + i * 22);
                lblFrom.Name = "lblFrom" + i;
                lblFrom.Size = new System.Drawing.Size(33, 13);
                lblFrom.TabIndex = i * 10 + 4;
                lblFrom.Text = "From:";
                this.Controls.Add(lblFrom);
                // 
                // cbSettings
                // 
                cbSettings.FormattingEnabled = true;
                cbSettings.Items.AddRange(new object[] {
                    "Settings",
                    "Global Parameters"});
                cbSettings.Location = new System.Drawing.Point(167, 12 + i * 22);
                cbSettings.Name = "cbSettings" + i;
                cbSettings.Size = new System.Drawing.Size(121, 21);
                cbSettings.TabIndex = i * 10 + 1;
                cbSettings.SelectedIndex = 0;
                this.Controls.Add(cbSettings);
                if (isReportSet)
                    cbSettings.Items.Add("Output Parameters");
                bool notSettings = false;
                // 
                // cbGlobalVars
                // 
                if (row["GlobalName"].ToString() != "" )
                {
                    if(!isReportSet || row["OutputSetID"].ToString() == "")
                    {
                        cbSettings.SelectedItem = "Global Parameters";
                        cbGlobalVars.FormattingEnabled = true;
                        DataTable global = VWA4Common.DB.Retrieve("SELECT * FROM GlobalVars WHERE GVType = '" + row["ParamValueType"] + "'");
                        for (int j = 0; j < global.Rows.Count; j++)
                            cbGlobalVars.Items.Add(global.Rows[i]["GVName"]);
                        cbGlobalVars.Location = new System.Drawing.Point(294, 5);
                        cbGlobalVars.Name = "cbGlobalVars" + i;
                        cbGlobalVars.Size = new System.Drawing.Size(121, 21);
                        cbGlobalVars.TabIndex = i * 10 + 2;
                        this.Controls.Add(cbGlobalVars);
                        notSettings = true;
                    }
                    
                    // 
                    // cbPrevReports
                    // 
                    else if (int.Parse(row["OutputSetID"].ToString()) > 0)
                    {
                        cbPrevReports.FormattingEnabled = true;
                        string sql;
                        if (isReportSet)
                            sql = "SELECT ReportSet.*, ReportMemorized.Title, ReportMemorized.ReportType " +
                                " FROM ReportSet LEFT JOIN ReportMemorized ON ReportSet.ReportMemorized = ReportMemorized.ID " +
                                " WHERE ReporSerie = " + row["SerieID"] + " AND Order < " + row["Order"];
                        else
                            sql = "SELECT * FROM ReportMemorized WHERE ID = " + row["OutputID"].ToString();
                        DataTable output = VWA4Common.DB.Retrieve(sql);
                        for (int j = 0; j < output.Rows.Count; j++)
                        {
                            cbPrevReports.Items.Add(output.Rows[i]["Title"]);
                            if (output.Rows[i]["ReportSet.ID"].ToString() == row["OutputID"].ToString())
                                cbPrevReports.SelectedIndex = i;
                            //cbOutputParams.Items.Add();
                        }
                        cbPrevReports.Location = new System.Drawing.Point(294, 12 + i * 22);
                        cbPrevReports.Name = "cbPrevReports" + i;
                        cbPrevReports.Size = new System.Drawing.Size(121, 21);
                        cbPrevReports.TabIndex = i * 10 + 5;
                        this.Controls.Add(cbPrevReports);
                        // 
                        // cbOutputParams
                        // 
                        cbOutputParams.FormattingEnabled = true;
                        cbOutputParams.Location = new System.Drawing.Point(415, 12 + i * 22);
                        cbOutputParams.Name = "cbOutputParams" + i;
                        cbOutputParams.Size = new System.Drawing.Size(121, 21);
                        cbOutputParams.TabIndex = i * 10 + 6;
                        this.Controls.Add(cbOutputParams);
                        notSettings = true;
                    }
                }
                else
                {
                    switch (row["ParamValueType"].ToString())
                    {
                        case "DateTime":

                            // 
                            // dtPicker
                            // 
                            dtPicker.Location = new System.Drawing.Point(294, 12 + i * 22);
                            dtPicker.Name = "dtPicker" + i;
                            dtPicker.Size = new System.Drawing.Size(291, 20);
                            dtPicker.TabIndex = i * 10 + 7;
                            dtPicker.Value = DateTime.Parse(row["ParamValue"].ToString());
                            this.Controls.Add(dtPicker);
                            break;
                        case "Boolean":
                            System.Windows.Forms.ComboBox cbBool = new System.Windows.Forms.ComboBox();
                            cbBool.Items.AddRange(new object[] {
                            "True",
                            "False"});
                            cbBool.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbBool.Name = "cbBool" + i;
                            cbBool.Size = new System.Drawing.Size(121, 21);
                            cbBool.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbBool);
                            break;
                        case "String":
                            System.Windows.Forms.TextBox txtString = new TextBox();
                            txtString.Location = new System.Drawing.Point(294, 12 + i * 22);
                            txtString.Name = "txtString" + i;
                            txtString.Size = new System.Drawing.Size(121, 21);
                            txtString.Text = row["ParamValue"].ToString();
                            this.Controls.Add(txtString);
                            break;
                        case "Number":
                            System.Windows.Forms.NumericUpDown num = new NumericUpDown();
                            num.Location = new System.Drawing.Point(294, 12 + i * 22);
                            num.Name = "num" + i;
                            num.Size = new System.Drawing.Size(121, 21);
                            num.Text = row["ParamValue"].ToString();
                            this.Controls.Add(num);
                            break;
                        case "AggregatePeriod":
                            System.Windows.Forms.ComboBox cbAggregatePeriod = new System.Windows.Forms.ComboBox();
                            cbAggregatePeriod.Items.AddRange(new object[] {
                                "Day",
                                "Week",
                                "Month",
                                "Quarter",
                                "Year"});
                            cbAggregatePeriod.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbAggregatePeriod.Name = "cbAggregatePeriod" + i;
                            cbAggregatePeriod.Size = new System.Drawing.Size(121, 21);
                            cbAggregatePeriod.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbAggregatePeriod);
                            break;
                        case "DayOfWeek":
                            System.Windows.Forms.ComboBox cbDayOfWeek = new System.Windows.Forms.ComboBox();
                            cbDayOfWeek.Items.AddRange(new object[] {
                                DayOfWeek.Sunday.ToString(),
                                DayOfWeek.Monday.ToString(),
                                DayOfWeek.Tuesday.ToString(),
                                DayOfWeek.Wednesday.ToString(),
                                DayOfWeek.Thursday.ToString(),
                                DayOfWeek.Friday.ToString(),
                                DayOfWeek.Saturday.ToString()});
                            cbDayOfWeek.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbDayOfWeek.Name = "cbDayOfWeek" + i;
                            cbDayOfWeek.Size = new System.Drawing.Size(121, 21);
                            cbDayOfWeek.SelectedItem = row["ParamDisplayValue"].ToString();
                            this.Controls.Add(cbDayOfWeek);
                            break;
                        case "TimeFrame":
                            System.Windows.Forms.ComboBox cbTimeFrame = new System.Windows.Forms.ComboBox();
                            cbTimeFrame.Items.AddRange(new object[] {
                            "Custom",
                            "Last week - by day ",
                            "Last 2 weeks - by day ",
                            "Last 4 weeks - by week ",
                            "Last 3 months - by months ",
                            "Last year - by month ",
                            "All - by month "});
                            cbTimeFrame.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbTimeFrame.Name = "cbTimeFrame" + i;
                            cbTimeFrame.Size = new System.Drawing.Size(121, 21);
                            cbTimeFrame.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbTimeFrame);
                            break;
                        case "ComparisionPeriod":
                            System.Windows.Forms.ComboBox cbComparisionPeriod = new System.Windows.Forms.ComboBox();
                            cbComparisionPeriod.Items.AddRange(new object[] {
                            "True",
                            "False"});
                            cbComparisionPeriod.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbComparisionPeriod.Name = "cbComparisionPeriod" + i;
                            cbComparisionPeriod.Size = new System.Drawing.Size(121, 21);
                            cbComparisionPeriod.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbComparisionPeriod);
                            break;
                        case "ComparisionType":
                            System.Windows.Forms.ComboBox cbComparisionType = new System.Windows.Forms.ComboBox();
                            cbComparisionType.Items.AddRange(new object[] {
                            "Days of Week",
                            "Loss Categories",
                            "Food Categories"});
                            cbComparisionType.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbComparisionType.Name = "cbComparisionType" + i;
                            cbComparisionType.Size = new System.Drawing.Size(121, 21);
                            cbComparisionType.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbComparisionType);
                            break;
                        case "FinancialMode":
                            System.Windows.Forms.ComboBox cbFinancialMode = new System.Windows.Forms.ComboBox();
                            cbFinancialMode.Items.AddRange(new object[] {
                            "Points",
                            "CPM"});
                            cbFinancialMode.Location = new System.Drawing.Point(294, 12 + i * 22);
                            cbFinancialMode.Name = "cbFinancialMode" + i;
                            cbFinancialMode.Size = new System.Drawing.Size(121, 21);
                            cbFinancialMode.SelectedItem = row["ParamValue"].ToString();
                            this.Controls.Add(cbFinancialMode);
                            break;
                        default:
                            System.Windows.Forms.TextBox txtDefault = new TextBox();
                            txtDefault.Location = new System.Drawing.Point(294, 12 + i * 22);
                            txtDefault.Name = "txtDefault" + i;
                            txtDefault.Size = new System.Drawing.Size(121, 21);
                            txtDefault.Text = row["ParamValue"].ToString();
                            this.Controls.Add(txtDefault);
                            break;
                    }
                }
            }
        }
    }
}
