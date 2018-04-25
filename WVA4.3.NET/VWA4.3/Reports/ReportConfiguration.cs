using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Reports
{
    public partial class ReportConfiguration : Form
    {
        public ReportConfiguration()
        {
            InitializeComponent();
            this.ucLowParameters1.Height = 214;
        }

        private void ReportConfiguration_Load(object sender, EventArgs e)
        {
            
        }

        private void ucLowParameters1_HideParams(object sender, UserControls.UCLowParameters.HideEventArgs e)
        {
            this.ucLowParameters1.Height = e.Height;
        }

        private void ucLowParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            //this.viewer1.Document = m_rptConfiguration.Document;
            this.Cursor = Cursors.Default;
        }
        //private rptConfiguration m_rptConfiguration;

        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                //UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;
                //m_rptConfiguration = new rptConfiguration(repParams);
                //m_rptConfiguration.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in launchReport: " + ex.Message, "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ucLowParameters1_ExportPDF(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    if (m_rptConfiguration == null)
            //        launchReport();
            //    this.pdfExport1.Export(m_rptConfiguration.Document, dlg.FileName);
            //}
        }
    }
}
