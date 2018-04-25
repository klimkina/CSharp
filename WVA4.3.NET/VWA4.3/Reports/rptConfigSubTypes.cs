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
    /// Summary description for rptConfigSubTypes.
    /// </summary>
    public partial class rptConfigSubTypes : DataDynamics.ActiveReports.ActiveReport
    {
        public UserControls.ReportParameters _InputParameters;
        private string _ReportType, _TypeCatalogID, _CatID, _CatName;
        public rptConfigSubTypes(UserControls.ReportParameters parameters, string type, 
            string catID, string catName,string typeCatalog)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;

            _ReportType = type;
            _TypeCatalogID = typeCatalog;
            _CatID = catID;
            _CatName = catName.Replace("(", "").Replace(")", "");
        }

        private void rptConfigSubTypes_ReportStart(object sender, EventArgs e)
        {
            string sql, typeFields = "", join = "";
            switch(_ReportType)
            {
                case "Food": 
                    typeFields = ", VolumeWeight, VolumeUnits, VolumeUnitType";
                    if (_TypeCatalogID != "" && _TypeCatalogID != "0")
                        typeFields += ", FoodCost AS Cost";
                    txtCostLabel.Text = "Cost:";
                    txtVolumeWeight.Text = "Volume Weight:";
                    txtCost.DataField = "Cost";
                    txtEnabledLabel.Text = "Enabled:";
                    txtEnabled.DataField = "Enabled";
                    break;
                case "Loss":
                    typeFields = ", OverproductionFlag, TrimWasteFlag, HandlingFlag";
                    txtCostLabel.Text = "Flags:";
                    txtVolumeWeight.Text = "Enabled:";
                    txtCost.OutputFormat = "";
                    txtWeight.DataField = "Enabled"; txtWeight.OutputFormat = "";
                    txtEnabledLabel.Visible = false; txtEnabled.Visible = false; txtMaleRatioLabel.Visible = false; txtMaleRatio.Visible = false;
                    break;
                case "Container": 
                    typeFields = ", Volume, VolumeUnitType";
                    if (_TypeCatalogID != "" && _TypeCatalogID != "0")
                        typeFields += ", ContainerTareWeight AS TareWeight, ContainerCost AS Cost";
                    else
                        typeFields += ", TareWeight, Cost";
                    txtCostLabel.Text = "Tare Weight:";
                    txtCost.DataField = "TareWeight";
                    txtCost.OutputFormat = "#0.00 lb";
                    txtVolumeWeight.Text = "Volume:";
                    //txtWeight.DataField = "ClientName";
                    //txtWeight.OutputFormat = "";
                    txtEventDateLabel.Text = "Cost: ";
                    txtEventDate.DataField = "Cost";
                    txtEventDate.OutputFormat = "$#,##0.00";
                    txtEnabledLabel.Text = "Enabled:";
                    txtEnabled.DataField = "Enabled";
                    break;
                case "BEO":
                    typeFields = ", EventDate, GuestCount, MRatio, ClientName, BEONumber";
                    txtCostLabel.Text = "Event Order #:";
                    txtCost.DataField = "BEONumber";
                    txtCost.OutputFormat = "#0";
                    txtVolumeWeight.Text = "Client:";
                    txtWeight.DataField = "ClientName";
                    txtWeight.OutputFormat = "";
                    txtEventDateLabel.Text = "Event Date: ";
                    txtGuestCountLabel.Text = "Guest Count:  ";
                    txtMaleRatioLabel.Text = "M/F Ratio:  ";
                    txtEnabledLabel.Text = "Enabled:";
                    txtEnabled.DataField = "Enabled";
                    join = " LEFT JOIN EventClients ON BEOType.Client = EventClients.ID ";
                    break;
                case "User":
                case "Station": 
                case "Disposition":
                case "Daypart":
                    typeFields = "";
                    txtCostLabel.Text = "Enabled:";
                    txtCost.DataField = "Enabled";
                    txtCost.OutputFormat = "";
                    txtVolumeWeight.Visible = false; txtWeight.Visible = false; txtGuestCountLabel.Visible = false; txtGuestCount.Visible = false;
                    txtEnabledLabel.Visible = false; txtEnabled.Visible = false; txtMaleRatioLabel.Visible = false; txtMaleRatio.Visible = false;
                    break;
                default:
                    MessageBox.Show("Report Type was not recognized");
                    return;

            }
            if (_TypeCatalogID == "" || _TypeCatalogID == "0")
                sql = "SELECT * FROM " + _ReportType + "Type " + join + " WHERE CatID = " + _CatID +
                    " ORDER BY Rank, TypeName";
            else
                sql = "SELECT " + _ReportType + "SubTypes.Enabled, " + _ReportType + "SubTypes.TypeID, " +
                    " TypeName, ReportTypeName, SpanishTypeName, ModifiedDate" + typeFields +
                    " FROM (" + _ReportType + "SubTypes INNER JOIN " + _ReportType + "Type ON " + _ReportType + "Type.TypeID = " + _ReportType + "SubTypes.TypeID) " +
                    join +
                    " WHERE CatID = " + _CatID + " AND TypeCatalogID = " + _TypeCatalogID +
                    " ORDER BY Rank, TypeName";
            DataTable dt = VWA4Common.DB.Retrieve(sql);

            txtMenu.Text = "(" + _CatName + ")";
            this.DataSource = dt;

            DataTable subCat = VWA4Common.DB.Retrieve("SELECT * FROM " + _ReportType +
                "Category WHERE ParentCatID = " + _CatID + " ORDER BY Rank, CatName");
            int i = 0;
            if (subCat != null)
                foreach (DataRow row in subCat.Rows)
                {
                    DataDynamics.ActiveReports.SubReport subrep = new DataDynamics.ActiveReports.SubReport();
                    subrep.Name = string.Format("Subreport{0}", i);
                    subrep.Height = 0.1F;
                    subrep.Left = 0F;
                    subrep.Width = 7F;
                    subrep.Top = 2 * i * 0.1F;
                    subrep.Report = new rptConfigSubTypes(_InputParameters, _ReportType, row["CatID"].ToString(),
                        _CatName + "\\" + row["CatName"].ToString(), _TypeCatalogID);
                    this.groupFooter1.Controls.Add(subrep);
                    i++;
                }
            this.Document.Printer.Landscape = false;
            this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (_ReportType == "Food" || _ReportType == "Container")
                txtWeight.Text = _output;
            else if(_ReportType == "Loss")
                txtCost.Text = _output;
        }

        private string _output = "";
        private void rptConfigSubTypes_FetchData(object sender, FetchEventArgs eArgs)
        {
            _output = "";
            if(_ReportType == "Food")
            {
                if (Fields["VolumeUnitType"].Value != null && Fields["VolumeUnitType"].Value.ToString() != "" && Fields["VolumeUnitType"].Value.ToString() != "0")
                {
                    DataTable dt = VWA4Common.DB.Retrieve("SELECT DisplayFullName FROM UnitsVolume WHERE ID = " +
                        Fields["VolumeUnitType"].Value.ToString());
                    string res = "";
                    if (dt != null && dt.Rows.Count > 0)
                        res = dt.Rows[0][0].ToString();
                    _output = decimal.Parse(Fields["VolumeWeight"].Value.ToString()).ToString("0.00") + "lbs / " +
                        decimal.Parse(Fields["VolumeUnits"].Value.ToString()).ToString("0") + res;
                }
            }
            else if(_ReportType == "Loss")
            {
                
                _output = ((bool)Fields["OverproductionFlag"].Value ? "Overproduction" : "");
                if(_output == "")
                    _output = ((bool)Fields["TrimWasteFlag"].Value ? "TrimWaste" : "");
                else
                    _output += ((bool)Fields["TrimWasteFlag"].Value ? ", TrimWaste" : "");
                if(_output == "")
                    _output = ((bool)Fields["HandlingFlag"].Value ? "Handling" : "");
                else
                    _output += ((bool)Fields["HandlingFlag"].Value ? ", Handling" : "");
            }
            else if(_ReportType == "Container")
            {
                if (Fields["VolumeUnitType"].Value != null && Fields["VolumeUnitType"].Value.ToString() != ""  && Fields["VolumeUnitType"].Value.ToString() != "0")
                {
                    string displayName = "";
                    DataTable dt = VWA4Common.DB.Retrieve("SELECT DisplayFullName FROM UnitsVolume WHERE ID = " +
                        Fields["VolumeUnitType"].Value.ToString());
                    if (dt != null && dt.Rows.Count > 0)
                        displayName = dt.Rows[0][0].ToString();
                    _output = decimal.Parse(Fields["Volume"].Value.ToString()).ToString("0.00") + " " + displayName;
                }
            }
        }
    }
}
