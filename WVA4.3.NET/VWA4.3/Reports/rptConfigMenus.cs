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
    /// Summary description for rptConfigMenus.
    /// </summary>
    public partial class rptConfigMenus : DataDynamics.ActiveReports.ActiveReport
    {
        private UserControls.ReportParameters _InputParameters;
        private string _ReportType, _TrackerID, _TrackerName, _ParentMenuID = "", _ParentMenuName = "";
        public rptConfigMenus(UserControls.ReportParameters parameters, string type, string trackerID, string trackerName) : 
            this(parameters, type, trackerID, trackerName, "0", "")
        {
        }
        public rptConfigMenus(UserControls.ReportParameters parameters, string type, string trackerID, string trackerName,
            string menuID, string menuName)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _ReportType = type;
            _TrackerID = trackerID;
            _TrackerName = trackerName;
            _ParentMenuID = menuID;
            _ParentMenuName = menuName;
        }

        private int j = 0;
        private DataDynamics.ActiveReports.SubReport GetSubReport()
        {
            DataDynamics.ActiveReports.SubReport subrep = new DataDynamics.ActiveReports.SubReport();
            subrep.Name = string.Format("Subreport{0}", j);
            subrep.Height = 0.1F;
            subrep.Left = 0F;
            subrep.Width = 6.8F;
            subrep.Top = 2 * j * 0.1F;
            j++;
            this.detail.Controls.Add(subrep);
            return subrep;
        }
        
        private void rptConfigMenus_ReportStart(object sender, EventArgs e)
        {
            if (_ParentMenuID == "0")
            {
                if (_ReportType == "User")
                    txtTrackerMenu.Text = "Team Member Buttons (" + _TrackerName + ")";
                else if (_ReportType == "BEO")
                    txtTrackerMenu.Text = "Event Order Buttons (" + _TrackerName + ")";
                else
                    txtTrackerMenu.Text = _ReportType + " Buttons (" + _TrackerName + ")";

            }
            else
                groupHeader1.Visible = false;
            
            string leftjoin = "", menuType = "", name = _ReportType;
            switch (_ReportType)
            {
                case "Food":
                    leftjoin = " LEFT JOIN " + _ReportType + "Type ON Tracker" + _ReportType + "Buttons.TypeID = " + _ReportType + "Type.TypeID ";
                    break;
                case "Container":
                    leftjoin = " LEFT JOIN " + _ReportType + "Type ON Tracker" + _ReportType + "Buttons.TypeID = " + _ReportType + "Type.TypeID ";
                    break;
                case "UserQuestion":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 6 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                case "Station":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 1 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                case "Disposition":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 2 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                case "Daypart":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 3 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                case "BEO":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 4 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                case "PrePost":
                    menuType = " AND (TrackerQuestionMenus.MenuType = 5 OR TrackerQuestionMenus.MenuType = 0) AND ParentMenuID <> 0";
                    name = "Question";
                    break;
                default:
                    menuType = "";
                    break;
            }
            
            // create and populate original DataTable 
            //Dataset to hold data
            DataTable menuDataTable = new DataTable();
            //Enabled field doesn't have any sense here
            string sql = @"SELECT MenuID, ParentMenuID, MenuName, SpanishMenuName FROM Tracker" +
                name + "Menus " +
                " WHERE ParentMenuID = " + _ParentMenuID + " AND TermID = '" + _TrackerID + "' " +menuType +
                " ORDER BY Rank DESC, MenuName;";
            menuDataTable = VWA4Common.DB.Retrieve(sql);
            
            GetSubReport().Report = new rptConfigButtons(_InputParameters, _ReportType, _TrackerID, _ParentMenuID, _ParentMenuName);
            if (menuDataTable != null && menuDataTable.Rows.Count > 0)
                foreach (DataRow row in menuDataTable.Rows)
                {
                    string menuname = row["MenuName"].ToString();
                    if (_ParentMenuID == "0" && (_ReportType == "UserQuestion" || _ReportType == "Station" || _ReportType == "Disposition" ||
                                _ReportType == "Daypart" || _ReportType == "BEO" || _ReportType == "PrePost")) //hide top menu names
                        menuname = "";
                    GetSubReport().Report = new rptConfigMenus(_InputParameters, _ReportType, _TrackerID, _TrackerName,
                        row["MenuID"].ToString(), (_ParentMenuName == "" ? "" : _ParentMenuName + "\\") + menuname);
                }
            
            this.Document.Printer.Landscape = false;
            this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }
    }
}
