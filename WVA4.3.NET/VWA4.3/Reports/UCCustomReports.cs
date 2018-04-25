using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class UCCustomReports : UserControl, UserControls.IVWAUserControlBase
    {
        string _SelectedLabelText = "";
        public UCCustomReports()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
        }

        public void Init(DateTime firstDayOfWeek) //display
        {
            _IsActive = true;
        }

        public void SaveData()
        {

        }
        public bool ValidateData()
        {
            return true;
        }

        public int AutoRun(string param)
        {
            return 0;
        }

        private bool _IsActive = false;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public void LeaveSheet()
        {
            _IsActive = false;
        }

        private void SetLabelsColor()
        {
            foreach (Control cntrl in panelCenter.Controls)
                if (cntrl is Label)
                {
                    ((Label)cntrl).BackColor = System.Drawing.Color.White;
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            _SelectedLabelText = ((Label)sender).Text;
            SetLabelsColor();
            ((Label)sender).BackColor = System.Drawing.Color.Beige;
            
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            frmReportViewer frm = new frmReportViewer(((Label)sender).Text);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportViewer frm = new frmReportViewer(_SelectedLabelText);
            frm.ShowDialog();
        }
    }
}
