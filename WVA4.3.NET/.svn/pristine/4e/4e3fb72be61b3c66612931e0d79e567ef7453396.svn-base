using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class ReportTrend : Form
    {
        public ReportTrend()
        {
            InitializeComponent();
            ucLowParticipationParameters1.SetTrend();
        }

        private ARTrend m_rptTrend;

        private void launchReport()
        {
            try
            {
                // Init Report Input Parameters
                UserControls.ReportParameters repParams = ucLowParticipationParameters1.ReportParameters;
                m_rptTrend = new ARTrend(repParams);
                //if (strReportFilter != null)
                //    m_rptTrend.InputParameters.Filter = strReportFilter;
                //m_rptTrend.InputParameters.StartDate = _StartDate;
                //m_rptTrend.InputParameters.Is3D = chk3D.Checked;
                //m_rptTrend.InputParameters.ShowLbs = chkLbs.Checked;
                //m_rptTrend.InputParameters.ShowTransNum = chkNumOfTrans.Checked;
                //m_rptTrend.InputParameters.AggregatePeriod = cbPeriod.SelectedItem.ToString();
                //m_rptTrend.InputParameters.FirstDayOfWeek = DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex;
                //m_rptTrend.InputParameters.Title = txtTitle.Text;
                //m_rptTrend.InputParameters.SubTitle = txtSubTitle.Text;
                //m_rptTrend.InputParameters.LogoPath = txtLogo.Text;
                //m_rptTrend.InputParameters.ColorPaletteName = cbPalette.SelectedItem.ToString();

                m_rptTrend.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error in launchReport: " + ex.Message, "ProjectError",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucLowParticipationParameters1_HideParams(object sender, UserControls.UCLowParticipationParameters.HideEventArgs e)
        {
            this.ucLowParticipationParameters1.Height = e.Height;
        }

        private void ucLowParticipationParameters1_ExportPDF(object sender, EventArgs e)
        {
            
            SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (m_rptTrend == null)
                    launchReport();
                this.pdfExport1.Export(m_rptTrend.Document, dlg.FileName);
            }
        }

        private void ucLowParticipationParameters1_ViewReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            launchReport();
            this.viewer1.Document = m_rptTrend.Document;
            this.Cursor = Cursors.Default;
        }

        private void ReportTrend_Load(object sender, EventArgs e)
        {
            ucLowParticipationParameters1.SetTrend();
        }
    }
}
