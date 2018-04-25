using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UserControls;

namespace Reports
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
            ucLowParticipationParameters1.SetDetails();
        }
        
        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.viewer1.Document = m_rptDetails.Document;
            this.Cursor = Cursors.Default;
        }

        private rptDetails m_rptDetails;

        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;
                m_rptDetails = new rptDetails(repParams);
                m_rptDetails.Run();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in launchReport: " + ex.Message, "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucLowParticipationParameters1_ExportPDF(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (m_rptDetails == null)
                    launchReport();
                this.pdfExport1.Export(m_rptDetails.Document, dlg.FileName);
            }
        }

        private void ucLowParticipationParameters1_HideParams(object sender, UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
        }
    }
}
