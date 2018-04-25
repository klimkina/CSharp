using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCReportParameters : UserControl
    {
        private ARParameters param;
        public UCReportParameters()
        {
            InitializeComponent();
            panelHideParams.Hide();
            cbPalette.SelectedIndex = 0;
            cbPeriod.SelectedIndex = 0;
            cbDayOfWeek.SelectedIndex = 0; //mila: set to default first day of week
            cboTimeFrame.SelectedIndex = 0;
            param = new ARParameters();
        }
        
        public DateTime StartDate
        {
            set 
            {
                if (value != new DateTime(0))
                {
                    startDate.Value = value;
                    cboTimeFrame.SelectedIndex = 0;
                }
                else
                    cboTimeFrame.SelectedIndex = 6;
            }
            get { return startDate.Value; }
        }
        public DateTime EndDate
        {
            set { endDate.Value = value; cboTimeFrame.SelectedIndex = 0; }
            get { return endDate.Value; }
        }
        
        public delegate void ViewReportEventHandler(object sender, EventArgs e);
        private ViewReportEventHandler viewReport;
        public event ViewReportEventHandler ViewReport
        {
            add { viewReport += value; }
            remove { viewReport -= value; }
        }
        public void SetViewReport()
        {
            OnViewReport(EventArgs.Empty);
        }
        protected virtual void OnViewReport(EventArgs e)
        {
            if (viewReport != null)
                viewReport(this, e);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetViewReport();
        }

        public delegate void ExportPDFEventHandler(object sender, EventArgs e);
        private ExportPDFEventHandler exportPDF;
        public event ExportPDFEventHandler ExportPDF
        {
            add { exportPDF += value; }
            remove { exportPDF -= value; }
        }
        public void SetExportPDF()
        {
            OnExportPDF(EventArgs.Empty);
        }
        protected virtual void OnExportPDF(EventArgs e)
        {
            if (exportPDF != null)
                exportPDF(this, e);
        }
        
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportPDF();
        }

        public delegate void FilterDataEventHandler(object sender, EventArgs e);
        private FilterDataEventHandler filterData;
        public event FilterDataEventHandler FilterData
        {
            add { filterData += value; }
            remove { filterData -= value; }
        }

        
        public void SetFilterData()
        {
            OnFilterData(EventArgs.Empty);
        }
        protected virtual void OnFilterData(EventArgs e)
        {
            if (filterData != null)
                filterData(this, e);
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetFilterData();
        }

        public ARParameters ReportParameter
        {
            get 
            {
                param.ColorPaletteName = cbPalette.SelectedItem.ToString();
                param.Title = txtTitle.Text;
                param.SubTitle = txtSubTitle.Text;
                param.StartDate = startDate.Value;
                param.EndDate = endDate.Value;
                param.AggregatePeriod = cbPeriod.SelectedItem.ToString();
                param.FirstDayOfWeek = DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex;
                param.ShowTransNum = chkNumOfTrans.Checked;
                param.ShowLbs = chkLbs.Checked;
                param.Is3D = chk3D.Checked;
                param.IsHorizontal = chkHorizontal.Checked;
                param.LogoPath = txtLogo.Text;
                return param;
            }
        }

        private bool shown = true;
        private void hideParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shown)
            {
                panelParams.Hide();
                panelHideParams.Show();
                popupShowHide.Items[0].Text = "Show Parameters";
            }
            else
            {
                panelParams.Show();
                panelHideParams.Hide();
                popupShowHide.Items[0].Text = "Hide Parameters";
            }
            shown = !shown;
        }

        private void cboTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimeFrame();
        }

        private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            VWA4Common.GlobalSettings.FirstDayOfWeek = (DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex).ToString();
            if (cbPeriod.SelectedItem.ToString() == "Week")
            {
                LoadTimeFrame();
            }
        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = UserControls.VWAPath.ViewWasteImagesPath;
            dlg.Filter = "Bitmap Files (*.BMP)|*.bmp|" +
                            "JPEG (*.JPG; *.JPEG; *.JPE; *.JFIF)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                            "GIF (*.GIF)|*.gif|" +
                            "TIFF (*.TIF; *.TIFF)|*.tif;*.tiff|" +
                            "PNG (*.PNG)|*.png|" +
                            "ICO (*.ICO)|*.ico|" +
                            "All Picture Files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png;*.ico|" +
                            "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtLogo.Text = dlg.FileName;
            }
        }
        private void LoadTimeFrame()
        {
            DateTime weekStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            DateTime monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);
            while (weekStart.DayOfWeek != DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex)
                weekStart = weekStart.AddDays(-1);
            switch (cboTimeFrame.SelectedIndex)
            {
                case 1: // Last week - by day 
                    cbPeriod.SelectedItem = "Day";
                    startDate.Value = weekStart.AddDays(-7);
                    endDate.Value = weekStart;
                    break;
                case 2: // Last 2 weeks - by day 
                    cbPeriod.SelectedItem = "Day";
                    startDate.Value = weekStart.AddDays(-14);
                    endDate.Value = weekStart;
                    break;
                case 3: //Last 4 weeks - by week 
                    cbPeriod.SelectedItem = "Week";
                    startDate.Value = weekStart.AddDays(-28);
                    endDate.Value = weekStart;
                    break;
                case 4: // Last 3 months - by months
                    cbPeriod.SelectedItem = "Month";
                    startDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0).AddMonths(-3);
                    endDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0); ;
                    break;
                case 5: // Last year - by month
                    cbPeriod.SelectedItem = "Month";
                    startDate.Value = new DateTime(DateTime.Now.Year - 1, 1, 1, 0, 0, 0, 0); ;
                    endDate.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0); ;
                    break;
                case 6: // All - by month 
                    cbPeriod.SelectedItem = "Month";
                    endDate.Value = DateTime.Now;
                    
                    string sql = "SELECT MIN(Timestamp) FROM Weights;";
                    startDate.Value = DateTime.Parse(VWA4Common.DB.Retrieve(sql).Rows[0][0].ToString());
                    
                    break;
                default:    //Custom - do nothing
                    break;
            }
        }
        public bool IsPeriodSet()
        {
            return cboTimeFrame.SelectedIndex != 6;
        }
        public void SetLowParticipation()
        {
            chkNumOfTrans.Text = "Show Cost of Transactions";
            chkLbs.Text = "Low Weight of Transactions";
        }
    }
}
