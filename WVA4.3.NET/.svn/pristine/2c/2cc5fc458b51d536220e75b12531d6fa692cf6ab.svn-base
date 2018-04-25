using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCDetailsParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "AggregatePeriod", "TimeFrame", "IsShowTrans", "DetailsType", "DetailsParameter", "IsChartOnly", "IsShowTrendLines", "IsShowEmptyWeeks" };
        private string[] _DefaultValues = { "Week", "Custom", "False", "Food", "", "True", "True", "False" };
        private string[] _DisplayValues = { "Week", "Custom", "False", "Food", "", "True", "True", "False" };
        private string[] _ParamTypes = { "AggregatePeriod", "TimeFrame", "Boolean", "ReportType", "ReportValue", "Boolean", "Boolean", "Boolean" };
        
        public UCDetailsParameters()
        {
            InitializeComponent();
        }

		public void InitDefault()
        {
            _ParamTable.Clear();
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
            }
            cboTimeFrame.SelectedIndex = 1; // last week by day
        }
        private void DisplayHashValues()
        {
            for (int i = 0; i < cboTimeFrame.Items.Count; i++)
            {
                if (cboTimeFrame.Items[i].ToString() == ((ReportParameter)_ParamTable["TimeFrame"]).ParamValue.ToString())
                    cboTimeFrame.SelectedIndex = i;
            }
            if (cboTimeFrame.SelectedIndex < 0)
            {
                cboTimeFrame.SelectedIndex = 0;
            }
            if (cboTimeFrame.SelectedIndex == 0)
            {
                for (int i = 0; i < cbPeriod.Items.Count; i++)
                {
                    if (cbPeriod.Items[i].ToString() == ((ReportParameter)_ParamTable["AggregatePeriod"]).ParamValue.ToString())
                        cbPeriod.SelectedIndex = i;
                }
            }
            if(cbPeriod.SelectedIndex < 0)
            {
                MessageBox.Show(null, "Error loading Period for Close-Up View report ", "Error loading parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPeriod.SelectedIndex = 0;
            }
            chkNumOfTrans.Checked = bool.Parse(((ReportParameter)_ParamTable["IsShowTrans"]).ParamValue);
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
            return ((ReportParameter)_ParamTable["DetailsType"]).ParamValue != ""&&((ReportParameter)_ParamTable["DetailsParameter"]).ParamValue != "";
        }
        public string GetValue(string name)
        {
            switch (name)
            {
                case "AggregatePeriod":
                    return VWA4Common.VWACommon.GetAccessPeriod( cbPeriod.SelectedItem.ToString());
                case "TimeFrame":
                    return cboTimeFrame.SelectedItem.ToString();
                case "IsShowTrans":
                    return chkNumOfTrans.Checked.ToString();
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
                case "AggregatePeriod":
                    return new ReportParameter(name, VWA4Common.VWACommon.GetAccessPeriod(cbPeriod.SelectedItem.ToString()), cbPeriod.SelectedItem.ToString(), "AggregatePeriod");
                case "TimeFrame":
                    return new ReportParameter(name, cboTimeFrame.SelectedItem.ToString(), cboTimeFrame.SelectedItem.ToString(), "TimeFrame");
                case "IsShowTrans":
                    return new ReportParameter(name, chkNumOfTrans.Checked.ToString(), chkNumOfTrans.Checked.ToString(), "Boolean");
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
    
        public class TimeFrameChangedEventArgs : EventArgs
        {
            private DateTime _StartDate;

            public DateTime StartDate
            {
              get { return _StartDate; }
              set { _StartDate = value; }
            }
            private DateTime _EndDate;

            public DateTime EndDate
            {
              get { return _EndDate; }
              set { _EndDate = value; }
            }

            public TimeFrameChangedEventArgs(int index)
            {
                DateTime weekStart = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
                DateTime monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);
                
                switch (index)
                {
                    case 1: // Last week - by day 
                        _StartDate = weekStart.AddDays(-7);
                        _EndDate = weekStart;
                        break;
                    case 2: // Last 2 weeks - by day 
                        _StartDate = weekStart.AddDays(-14);
                        _EndDate = weekStart;
                        break;
                    case 3: //Last 4 weeks - by week 
                        _StartDate = weekStart.AddDays(-28);
                        _EndDate = weekStart;
                        break;
                    case 4: // Last 3 months - by months
                        _StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0).AddMonths(-3);
                        _EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0); ;
                        break;
                    case 5: // Last year - by month
                        _StartDate = new DateTime(DateTime.Now.Year - 1, 1, 1, 0, 0, 0, 0); ;
                        _EndDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0); ;
                        break;
                    case 6: // All - by month 
                        _EndDate = DateTime.Now;
                        
                        string sql = "SELECT MIN(Timestamp) FROM Weights;";
                        _StartDate = DateTime.Parse(VWA4Common.DB.Retrieve(sql).Rows[0][0].ToString());
                        
                        break;
                    default:    //Custom - do nothing
                        break;
                }
            }

        }
        public delegate void TimeFrameChangedEventHandler(object sender, TimeFrameChangedEventArgs e);
        private TimeFrameChangedEventHandler timeFrameChanged;
        public event TimeFrameChangedEventHandler TimeFrameChanged
        {
            add { timeFrameChanged += value; }
            remove { timeFrameChanged -= value; }
        }
        public void SetTimeFrameChanged()
        {
            OnTimeFrameChanged(new TimeFrameChangedEventArgs(cboTimeFrame.SelectedIndex));
        }
        protected virtual void OnTimeFrameChanged(TimeFrameChangedEventArgs e)
        {
            if (timeFrameChanged != null)
                timeFrameChanged(this, e);
        }
        
        private void cboTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTimeFrame.SelectedIndex)
            {
                case 1: // Last week - by day 
                    cbPeriod.SelectedItem = "Day";
                    break;
                case 2: // Last 2 weeks - by day 
                    cbPeriod.SelectedItem = "Day";
                    break;
                case 3: //Last 4 weeks - by week 
                    cbPeriod.SelectedItem = "Week";
                    break;
                case 4: // Last 3 months - by months
                    cbPeriod.SelectedItem = "Month";
                    break;
                case 5: // Last year - by month
                    cbPeriod.SelectedItem = "Month";
                    break;
                case 6: // All - by month 
                    cbPeriod.SelectedItem = "Month";
                    break;
                default:    //Custom - do nothing
                    break;
            }
            if (sender != null && cboTimeFrame.SelectedIndex != 0)
                SetTimeFrameChanged();
        }
        public void SetDetailsParams(string type, string id, string display)
        { 
            ((ReportParameter)_ParamTable["DetailsType"]).ParamValue = type;
            ((ReportParameter)_ParamTable["DetailsType"]).DisplayValue = type;
            ((ReportParameter)_ParamTable["DetailsParameter"]).ParamValue = id;
            ((ReportParameter)_ParamTable["DetailsParameter"]).DisplayValue = display;
        }
        public void ResetTimeFrame()
        {
            cboTimeFrame.SelectedIndex = 0;
        }
    }
}
