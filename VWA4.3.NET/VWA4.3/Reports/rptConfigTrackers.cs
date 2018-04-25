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
    /// Summary description for rptConfigTrackers.
    /// </summary>
    public partial class rptConfigTrackers : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        bool _IsFirst;
        public rptConfigTrackers(UserControls.ReportParameters parameters, bool isFirst)
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
            pageBreak1.Name = "pageBreak1";
            pageBreak1.Size = new System.Drawing.SizeF(7.125F, 0.0625F);
            pageBreak1.Top = 0F;
            pageBreak1.Width = 7.125F;
            this.groupHeader1.Controls.Add(pageBreak1);
        }

        private void rptConfigTrackers_ReportStart(object sender, EventArgs e)
        {
            if (!_IsFirst)
                AddPageBreak();
            DataTable dt = VWA4Common.DB.Retrieve("SELECT Terminals.*, LicensedSite AS SiteName, StationType.TypeName AS StationName, " +
                " DispositionType.TypeName AS DispositionName, DaypartType.TypeName AS DaypartName, " +
                " IIF(DefaultPrePostConsumerFlag = 0, 'Intermediate', IIF(DefaultPrePostConsumerFlag = 1, 'Pre consumer', 'Post consumer')) AS PrePostConsumerFlag" +
                " FROM ((((Terminals LEFT JOIN Sites on Terminals.SiteID = Sites.ID) " +
                " LEFT OUTER  JOIN StationType ON Terminals.DefaultStation = StationType.TypeID) " +
                " LEFT OUTER  JOIN DispositionType ON Terminals.DefaultDisposition = DispositionType.TypeID) " +
                " LEFT OUTER  JOIN DaypartType ON Terminals.DefaultDaypart = DaypartType.TypeID)" +
                "");

            this.DataSource = dt;

            this.Document.Printer.Landscape = false;
            this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right); 
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox32.Text = (textBox32.Text == "True" ? "Yes" : "No");
            textBox21.Text = (textBox21.Text == "True" ? "Yes" : "No");
            textBox22.Text = (textBox22.Text == "True" ? "Yes" : "No");
            textBox23.Text = (textBox23.Text == "True" ? "Yes" : "No");

            textBox26.Text = (textBox26.Text == "True" ? "Yes" : "No");
			//textBox27.Text = (textBox27.Text == "True" ? "Yes" : "No");
			//textBox28.Text = (textBox28.Text == "True" ? "Yes" : "No");

            textBox29.Text = (textBox29.Text == "" ? "None" : textBox29.Text);
            textBox30.Text = (textBox30.Text == "" ? "None" : textBox30.Text);
            textBox31.Text = (textBox31.Text == "" ? "None" : textBox31.Text);

            textBox42.Text = (textBox42.Text == "" ? "None" : textBox42.Text);
            textBox43.Text = (textBox43.Text == "" ? "None" : textBox43.Text);
            textBox44.Text = (textBox44.Text == "" ? "None" : textBox44.Text);
        }
    }
}
