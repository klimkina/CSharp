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
    /// Summary description for rptConfigTypes.
    /// </summary>
    public partial class rptConfigTypes : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        private string _ReportType, _TypeCatalogID, _TypeCatalogName;
        bool _IsFirst;
        public rptConfigTypes(UserControls.ReportParameters parameters, string type, string id, string name, bool isFirst)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _ReportType = type;
            _TypeCatalogID = id;
            _TypeCatalogName = name;
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
            pageBreak1.Name = "pageBreak1";
            pageBreak1.Size = new System.Drawing.SizeF(7.125F, 0.0625F);
            pageBreak1.Top = 0F;
            pageBreak1.Width = 7.125F;
            this.groupHeader1.Controls.Add(pageBreak1);
        }
        private void rptConfigTypes_ReportStart(object sender, EventArgs e)
        {
            if (!_IsFirst)
                AddPageBreak();
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM " + _ReportType + "Category WHERE ParentCatID = 0 ORDER BY Rank, CatName");
            int i = 0;
            if(_ReportType == "User")
                lblTypeCatalog.Text = "Team Member Types (" + ((_TypeCatalogID == "" || _TypeCatalogID == "0") ? "Master" : _TypeCatalogName) + ")";
            else if (_ReportType == "BEO")
                lblTypeCatalog.Text = "Event Order Types (" + ((_TypeCatalogID == "" || _TypeCatalogID == "0") ? "Master" : _TypeCatalogName) + ")";
            else
                lblTypeCatalog.Text = _ReportType + " Types (" + ((_TypeCatalogID == "" || _TypeCatalogID == "0") ? "Master" : _TypeCatalogName) + ")";
            if(dt != null && dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    DataDynamics.ActiveReports.SubReport subrep = new DataDynamics.ActiveReports.SubReport();
                    subrep.Name = string.Format("Subreport{0}", i);
                    subrep.Height = 0F;
                    subrep.Left = 0F;
                    subrep.Width = 7F;
                    subrep.Top = 2* i * 0.00001F;
                    subrep.Report = new rptConfigSubTypes(_InputParameters, _ReportType,row["CatID"].ToString(),
                        row["CatName"].ToString(), _TypeCatalogID);
                    this.detail.Controls.Add(subrep);
                    i++;
                    
                }
            this.Document.Printer.Landscape = false;
            this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }
    }
}
