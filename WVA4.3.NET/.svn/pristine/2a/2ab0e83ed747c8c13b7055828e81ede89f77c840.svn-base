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
    public partial class ReportComparision : Form
    {
        public ReportComparision()
        {
            InitializeComponent();
        }

        private void ReportComparision_Load(object sender, EventArgs e)
        {
            this.ucLowParticipationParameters1.SetComparision();
        }

        private void ucLowParticipationParameters1_HideParams(object sender, UserControls.UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
        }

        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.viewer1.Document = m_rptComparision.Document;
            this.Cursor = Cursors.Default;
        }
        private rptComparision m_rptComparision;
        
        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                m_rptComparision = new rptComparision(ucLowParticipationParameters1.ReportParameters);
                m_rptComparision.Run();
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
                if (m_rptComparision == null)
                    launchReport();
                this.pdfExport1.Export(m_rptComparision.Document, dlg.FileName);
            }
        }
    }
}
