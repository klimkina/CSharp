using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using System.IO;

namespace Reports
{
    /// <summary>
    /// Summary description for rptForm.
    /// </summary>
    public partial class rptForm : DataDynamics.ActiveReports.ActiveReport
    {
        Formx f = new Formx();
        OleObject doc = new OleObject();

        public rptForm()
        {
            InitializeComponent();
        }

        public rptForm(Formx nf)
        {
            this.f = nf;
            InitializeComponent();
        }

        private void rptForm_ReportStart(object sender, EventArgs e)
        {
            doc.Width = 8f;
            doc.Height = 10f;
            detail.Controls.Add(doc);

            pageFooter.Height = 0f;
            pageHeader.Height = 0f;

            this.PageSettings.PaperWidth = 8f;
            this.PageSettings.PaperHeight = 10f;
            this.PageSettings.Margins.Left = 0f;
            this.PageSettings.Margins.Right = 0f;
            this.PageSettings.Margins.Top = 0f;
            this.PageSettings.Margins.Bottom = 0f;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            doc.CreateFrom(Path.Combine(f.SavePath, f.FileName));
        }
    }
}
