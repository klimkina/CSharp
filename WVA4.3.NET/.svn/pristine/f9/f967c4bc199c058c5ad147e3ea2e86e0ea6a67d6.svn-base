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
    public partial class rptFormSeries : DataDynamics.ActiveReports.ActiveReport
    {
        private FormSeries formSeries = new FormSeries();
        private List<FormFormSeries> formformSeries = new List<FormFormSeries>();

        public rptFormSeries()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public rptFormSeries(FormSeries fs)
        {
            this.formSeries = fs;
            this.formformSeries = FormFormSeriesDAO.DAO.GetAllByFormSeriesId(fs.Id);
            InitializeComponent();
        }

        public rptFormSeries(List<FormFormSeries> ffs)
        {
            this.formformSeries = ffs;
            InitializeComponent();
        }

        private void rptFormSeries_ReportEnd(object sender, EventArgs e)
        {
            //remove this reports page
            this.Document.Pages.RemoveAt(this.Document.Pages.Count - 1);
            this.Document.Print();
        }

        private void rptFormSeries_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperWidth = 8f;
            this.PageSettings.PaperHeight = 10f;
            this.PageSettings.Margins.Left = 0f;
            this.PageSettings.Margins.Right = 0f;
            this.PageSettings.Margins.Top = 0f;
            this.PageSettings.Margins.Bottom = 0f;

            pageFooter.Height = 0f;
            pageHeader.Height = 0f;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            foreach (FormFormSeries ffs in formformSeries)
            {
                rptForm frm = new rptForm(FormDAO.DAO.Load(ffs.FormId));
                frm.Run();

                this.Document.Pages.AddRange(frm.Document.Pages);                
            }            
        }
    }
}
