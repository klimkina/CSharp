using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCReportList : UserControl, IVWAUserControlBase
    {
        public UCReportList()
        {
            InitializeComponent();
        }

        public void LoadData()
        { }
        public void SaveData()
        { }
        public bool ValidateData()
        { return true; }
        public void Init(DateTime firstDayOfWeek)
        {
            _IsActive = true;
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
    }
}
