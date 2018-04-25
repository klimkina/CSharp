using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class SmartDateTimePicker : System.Windows.Forms.DateTimePicker
    {
        public SmartDateTimePicker()
        {
            InitializeComponent();
        }

        public new DateTime Value { 
            set {
                dateTimePicker1.Value = value;
                dateTimePicker2.Value = value;
            } 
            get {
                //dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                //    dateTimePicker1.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);
                return new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second); 
            } 
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // catch pressing tab key
            if (keyData == Keys.Tab)
                if (dateTimePicker2.Focused == true)
                {
                    SetEnterPressed();
                    return true;
                }
            return base.ProcessCmdKey(ref msg, keyData); 
        }

        public delegate void EnterPressedEventHandler(object sender, EventArgs e);
        private EnterPressedEventHandler enterPressed;
        public event EnterPressedEventHandler EnterPressed
        {
            add { enterPressed += value; }
            remove { enterPressed -= value; }
        }
        public void SetEnterPressed()
        {
            OnEnterPressed(EventArgs.Empty);
        }
        protected virtual void OnEnterPressed(EventArgs e)
        {
            if (enterPressed != null)
                enterPressed(this, e);
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            // catch pressing enter key means user finished input
            if (sender != null)
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
                    SetEnterPressed();
        }

        public delegate void ValueChangedEventHandler(object sender, VWA4Common.VWACommon.DateEventArgs e);
        private ValueChangedEventHandler valueChanged;
        public new event ValueChangedEventHandler ValueChanged
        {
            add { valueChanged += value; }
            remove { valueChanged -= value; }
        }
        public void SetValueChanged()
        {
            OnValueChanged(new VWA4Common.VWACommon.DateEventArgs(new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second)));
        }
        protected void OnValueChanged(VWA4Common.VWACommon.DateEventArgs e)
        {
            if (valueChanged != null)
                valueChanged(this, e);
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            SetValueChanged();
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            SetValueChanged();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetValueChanged();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SetValueChanged();
        }
    }
}
