using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UserControls;

namespace Reports
{
    public partial class ReportLowParticipation : Form
    {
        public ReportLowParticipation()
        {
            InitializeComponent();
            this.ucLowParticipationParameters1.SetLowParticipation();
        }
        private void ucLowParticipationParameters1_HideParams(object sender, UserControls.UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
        }
        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.viewer1.Document = m_rptLowParticipation.Document;
            this.Cursor = Cursors.Default;
        }

        private rptLowParticipation m_rptLowParticipation;

        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;
                m_rptLowParticipation = new rptLowParticipation(repParams);
                
                m_rptLowParticipation.Run();
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
                if (m_rptLowParticipation == null)
                    launchReport();
                this.pdfExport1.Export(m_rptLowParticipation.Document, dlg.FileName);
            }
        }

    }
}
