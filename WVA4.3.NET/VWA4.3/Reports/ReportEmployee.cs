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
    public partial class ReportEmployee : Form
    {
        public ReportEmployee()
        {
            InitializeComponent();
            this.ucLowParticipationParameters1.SetEmployee();
        }

        private void ucLowParticipationParameters1_HideParams(object sender, UserControls.UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
        }

        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.viewer1.Document = m_rptEmployee.Document;
            this.Cursor = Cursors.Default;
        }
        private rptEmployee m_rptEmployee;
        private rptEmployeeException m_rptEmployeeException;

        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;
                m_rptEmployee = new rptEmployee(repParams);
                m_rptEmployee.Run();
                if (bool.Parse(ucLowParticipationParameters1.ReportParameters["ShowEmployeeSub"].ParamValue))
                {
                    m_rptEmployeeException = new rptEmployeeException(repParams);
                    m_rptEmployeeException.Run();
                    m_rptEmployee.Document.Pages.AddRange(m_rptEmployeeException.Document.Pages);
                }
                viewer1.Document = m_rptEmployee.Document;
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
                if (m_rptEmployee == null)
                    launchReport();
                this.pdfExport1.Export(m_rptEmployee.Document, dlg.FileName);
            }
        }
    }
}
