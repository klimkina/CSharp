using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCViewWasteFilter : UserControl, IVWAUserControlBase
    {
        public UCViewWasteFilter()
        {
            InitializeComponent();
        }

        public void LoadData()
        { }
        public void SaveData()
        { }
        public void Init(DateTime firstDayOfWeek)
        {
            _IsActive = true;
        }
        public bool ValidateData()
        { return true; }
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

        public delegate void CustomFilterEventHandler(object sender, EventArgs e);
        private CustomFilterEventHandler customFilter;
        public event CustomFilterEventHandler CustomFilter
        {
            add { customFilter += value; }
            remove { customFilter -= value; }
        }
        public void SetCustomFilter()
        {
            OnCustomFilter(EventArgs.Empty);
        }
        protected virtual void OnCustomFilter(EventArgs e)
        {
            if (customFilter != null)
                customFilter(this, e);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (sender != null)
                customFilter(this, e);
        }

        public delegate void ClearFilterEventHandler(object sender, EventArgs e);
        private ClearFilterEventHandler clearFilter;
        public event ClearFilterEventHandler ClearFilter
        {
            add { clearFilter += value; }
            remove { clearFilter -= value; }
        }
        public void SetClearFilter()
        {
            OnClearFilter(EventArgs.Empty);
        }
        protected virtual void OnClearFilter(EventArgs e)
        {
            if (clearFilter != null)
                clearFilter(this, e);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (sender != null)
                clearFilter(this, e);
        }
    }
}
