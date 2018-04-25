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
    /// Summary description for rptConfigButtons.
    /// </summary>
    public partial class rptConfigButtons : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        private string _ReportType, _TrackerID, _MenuID = "", _MenuName = "";
        public rptConfigButtons(UserControls.ReportParameters parameters, string type, string trackerID, string menuID, string menuName)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _ReportType = type;
            _TrackerID = trackerID;
            _MenuID = menuID;
            _MenuName = menuName;
        }

        private void rptConfigButtons_ReportStart(object sender, EventArgs e)
        {
            lblMenu.Text = "(" + _MenuName.Replace("(", "").Replace(")", "") + ")";
            string leftjoin = "", buttonType = "", name = _ReportType;
            switch (_ReportType)
            {
                case "Food":
                    leftjoin = " LEFT JOIN " + name + "Type ON Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID ";
                    break;
                case "Container":
                    leftjoin = " LEFT JOIN " + name + "Type ON Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID ";
                    break;
                case "UserQuestion":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 6";name = "Question";
                    break;
                case "Station":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 1";
                    name = "Question";
                    break;
                case "Disposition":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 2";
                    name = "Question";
                    break;
                case "Daypart":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 3";
                    name = "Question";
                    break;
                case "BEO":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 4";
                    name = "Question";
                    break;
                case "PrePost":
                    buttonType = " AND TrackerQuestionButtons.ButtonType = 5";
                    name = "Question";
                    break;
                default:
                    buttonType = "";
                    break;
            }
            // create and populate original DataTable 
            //Dataset to hold data
            DataTable buttonDataTable = new DataTable();
            //Enabled field doesn't have any sense here
            string sql = @"SELECT " + (_ReportType == "PaperUI" ? "*" : "ButtonID, MenuID, Tracker" + name + "Buttons.TypeID, ButtonName, SpanishButtonName ") +
                " FROM Tracker" + name + "Buttons " + leftjoin +
                " WHERE MenuID = " + _MenuID + buttonType +
                " ORDER BY Tracker" + name + "Buttons.Rank, ButtonName;";
            buttonDataTable = VWA4Common.DB.Retrieve(sql);

            if (buttonDataTable == null || buttonDataTable.Rows.Count == 0)
            {
                this.Cancel();
            }
            else
            {
                this.DataSource = buttonDataTable;
                if (_ReportType == "PaperUI")
                {
                    textBox3.Text = "User specifies: ";
                    textBox4.Text = "Weight Units Type:";
                    textBox5.Text = "Unit Weight (Gross):";
                    textBox6.Text = "Pre/post Consumer:";
                    textBox7.Text = "Food Type: ";
                    textBox8.Text = "Loss Type: ";
                    textBox9.Text = "Container Type: ";
                    textBox10.Text = "Station Type: ";
                    textBox11.Text = "Disposition Type: ";
                    textBox12.Text = "Daypart Type: ";
                    textBox23.Text = "Units Display Name:  ";

                    textBox13.DataField = "";
                    textBox14.DataField = "UnitTypeKey";
                    textBox15.DataField = "UnitaryFoodWeight";
                    textBox16.DataField = "PrePostConsumerFlag";
                    textBox17.DataField = "FoodTypeName";
                    textBox18.DataField = "LossTypeName";
                    textBox19.DataField = "ContainerTypeName";
                    textBox20.DataField = "StationTypeName";
                    textBox21.DataField = "DispositionTypeName";
                    textBox22.DataField = "DaypartTypeName";
                    textBox24.DataField = "UnitTypeDisplayName";

                    textBox25.DataField = "FoodTypeID";
                    textBox26.DataField = "LossTypeID";
                    textBox27.DataField = "ContainerTypeID";
                    textBox28.DataField = "StationTypeID";
                    textBox29.DataField = "DispositionTypeID";
                    textBox30.DataField = "DaypartTypeID";
                }
                else
                {
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;
                    textBox12.Visible = false;
                    textBox23.Visible = false;

                    textBox13.Visible = false;
                    textBox14.Visible = false;
                    textBox15.Visible = false;
                    textBox16.Visible = false;
                    textBox17.Visible = false;
                    textBox18.Visible = false;
                    textBox19.Visible = false;
                    textBox20.Visible = false;
                    textBox21.Visible = false;
                    textBox22.Visible = false;
                    textBox24.Visible = false;

                    textBox25.Visible = false;
                    textBox26.Visible = false;
                    textBox27.Visible = false;
                    textBox28.Visible = false;
                    textBox29.Visible = false;
                    textBox30.Visible = false;

                    textBox13.OutputFormat = "";
                    textBox14.OutputFormat = "";
                    textBox15.OutputFormat = "";
                    textBox16.OutputFormat = "";
                    textBox17.OutputFormat = "";
                    textBox18.OutputFormat = "";
                    textBox19.OutputFormat = "";
                    textBox20.OutputFormat = "";
                    textBox21.OutputFormat = "";
                    textBox22.OutputFormat = "";
                    textBox24.OutputFormat = "";

                    textBox25.OutputFormat = "";
                    textBox26.OutputFormat = "";
                    textBox27.OutputFormat = "";
                    textBox28.OutputFormat = "";
                    textBox29.OutputFormat = "";
                    textBox30.OutputFormat = "";
                }
                this.Document.Printer.Landscape = false;
                this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right);
            }
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox31.Text = "(" + textBox31.Text + ")";
        }
    }
}
