using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCFirstDayOfWeek : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "FirstDayOfWeek", };
        private string[] _DefaultValues = { "0"};
        private string[] _DisplayValues = { "Sunday"};
        private string[] _ParamTypes = { "DayOfWeek" };
        public UCFirstDayOfWeek()
        {
            InitializeComponent();
            InitDefault();
        }

        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private VWA4Common.TrackerDetector trackerDetector = null;
        public void InitDefault()
        {
            _ParamTable.Clear();
            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                //dbDetector.FirstDayOfWeekChanged += new UserControls.DBDetectorEventHandler(dbDetector_FirstDayOfWeekChanged);
            }
            if (trackerDetector == null)
            {
                trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
                trackerDetector.FirstDayOfWeekChanged += new VWA4Common.FirstDayOfWeekDetectorEventHandler(trackerDetector_FirstDayOfWeekChanged);
            }
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
            }
            cbDayOfWeek.SelectedIndex = VWA4Common.VWACommon.FirstDayOfWeek - DayOfWeek.Sunday; // default first day of week
        }
        private void DisplayHashValues()
        {
            cbDayOfWeek.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["FirstDayOfWeek"]).ParamValue.ToString());
                    
        }
        public void HashLoad(Hashtable paramlist)
        {
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                ReportParameter param;
                if (paramlist.Contains(_ParamNames[i]))
                {
                    param = (ReportParameter)paramlist[_ParamNames[i]];
                    _ParamTable[_ParamNames[i]] = param;
                }
            }
            DisplayHashValues();
        }
        public bool IsValid()
        {
            return true;
        }
        public string GetValue(string name)
        {
            switch (name)
            {
                case "FirstDayOfWeek":
                    return cbDayOfWeek.SelectedIndex.ToString();
                default:
                    return "";
            }
        }
        public void AddItem(ReportParameter param)
        {
            _ParamTable.Add(param.Name, param);
        }
        public void DeleteItem(string name)
        {
            _ParamTable.Remove(name);
        }
        public ReportParameter GetItem(string name)
        {
            switch (name)
            {
                case "FirstDayOfWeek":
                    return new ReportParameter(name, cbDayOfWeek.SelectedIndex.ToString(), cbDayOfWeek.SelectedItem.ToString(), "DayOfWeek");
                default:
                    return null;
            }
        }

        private IDictionaryEnumerator _ParamTableEnum;
        public ReportParameter GetFirst()
        {
            _ParamTableEnum = _ParamTable.GetEnumerator();
            return ((ReportParameter)_ParamTableEnum.Current);
        }
        public ReportParameter GetNext()
        {
            if (_ParamTableEnum == null)
                _ParamTableEnum = _ParamTable.GetEnumerator();
            else
                _ParamTableEnum.MoveNext();
            return ((ReportParameter)_ParamTableEnum.Current);
        }
        public string GetNameList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.Name;
                else
                    res += ", " + param.Name;
            }
            return res;
        }
        public string GetValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.ParamValue;
                else
                    res += ", " + param.ParamValue;
            }
            return res;
        }
        public string GetDisplayValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.DisplayValue;
                else
                    res += ", " + param.DisplayValue;
            }
            return res;
        }
        private void SetValues()
        {
            foreach (string name in _ParamNames)
            {
                ReportParameter param  = GetItem(name);
                if(param != null)
                    _ParamTable[name] = param;  
            }
        }
        
        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public Hashtable ParamList
        {
            get {
                SetValues();
                return _ParamTable; 
            }
            set { this.HashLoad(value); }
        }

        public class FirstDayOfWeekChangedEventArgs : EventArgs
        {
            private DayOfWeek _FirstDayOfWeek;

            public DayOfWeek FirstDayOfWeek
            {
                get { return _FirstDayOfWeek; }
                set { _FirstDayOfWeek = value; }
            }
            
            public FirstDayOfWeekChangedEventArgs(int index)
            {
                _FirstDayOfWeek = DayOfWeek.Sunday + index;
            }

        }
        public delegate void FirstDayOfWeekChangedEventHandler(object sender, FirstDayOfWeekChangedEventArgs e);
        private FirstDayOfWeekChangedEventHandler firstDayOfWeekChanged;
        public event FirstDayOfWeekChangedEventHandler FirstDayOfWeekChanged
        {
            add { firstDayOfWeekChanged += value; }
            remove { firstDayOfWeekChanged -= value; }
        }
        public void SetFirstDayOfWeekChanged()
        {
            OnFirstDayOfWeekChanged(new FirstDayOfWeekChangedEventArgs(cbDayOfWeek.SelectedIndex));
        }
        protected virtual void OnFirstDayOfWeekChanged(FirstDayOfWeekChangedEventArgs e)
        {
            if (firstDayOfWeekChanged != null)
                firstDayOfWeekChanged(this, e);
        }
        private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null)
                SetFirstDayOfWeekChanged();
        }
        public DayOfWeek SelectedFirstDayOfWeek
        { get { return cbDayOfWeek.SelectedIndex + DayOfWeek.Sunday; } }

        void trackerDetector_FirstDayOfWeekChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < cbDayOfWeek.Items.Count; i++)
                if (cbDayOfWeek.Items[i].ToString() == VWA4Common.GlobalSettings.FirstDayOfWeek)
                {
                    cbDayOfWeek.SelectedIndex = i;
                    break;
                }
        }
    }
}
