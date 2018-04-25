using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCWasteAvoidanceParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "FirstDayOfWeek", "FirstWeekStart", "SecondWeekStart", "ComparisionType", 
                                           "IsRecent", "ComparisionPeriod", "NumShown"};
        private string[] _DefaultValues = { "0", DateTime.Now.ToString(), DateTime.Now.ToString(), "Days of Week", "False", "User Select", "0" };
        private string[] _DisplayValues = { "Sunday", DateTime.Now.ToString(), DateTime.Now.ToString(), "Days of Week", "False", "User Select", "0" };
        private string[] _ParamTypes = { "DayOfWeek", "DateTime", "DateTime", "ComparisionType", "Boolean", "ComparisionPeriod", "Number" };

        public UCWasteAvoidanceParameters()
        {
            InitializeComponent();
            InitDefault();
        }
        
        public void InitDefault()
        {
            _ParamTable.Clear();
            //for (int i = 0; i < _ParamNames.Length; i++)
            //{
            //    _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
            //}
            //cbComparision.SelectedIndex = 0;
            //cbCompareWeek.SelectedIndex = 0;
            //cbDayOfWeek.SelectedIndex = VWA4Common.VWACommon.FirstDayOfWeek - DayOfWeek.Sunday; // default first day of week
            //dtStartWeek.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
            //dtCompareWeek.Value = dtStartWeek.Value.AddDays(-7);
            //((ReportParameter)_ParamTable["FirstWeekStart"]).ParamValue = VWA4Common.VWACommon.DateToString(dtStartWeek.Value);
            //((ReportParameter)_ParamTable["FirstWeekStart"]).DisplayValue = VWA4Common.VWACommon.DateToString(dtStartWeek.Value);
            //((ReportParameter)_ParamTable["SecondWeekStart"]).ParamValue = VWA4Common.VWACommon.DateToString(dtCompareWeek.Value);
            //((ReportParameter)_ParamTable["SecondWeekStart"]).DisplayValue = VWA4Common.VWACommon.DateToString(dtCompareWeek.Value);
        }
        private void DisplayHashValues()
        {
            //dtStartWeek.Value           = DateTime.Parse(((ReportParameter)_ParamTable["FirstWeekStart"]).ParamValue);
            //dtCompareWeek.Value         = DateTime.Parse(((ReportParameter)_ParamTable["SecondWeekStart"]).ParamValue);
            //cbDayOfWeek.SelectedIndex   = int.Parse(((ReportParameter)_ParamTable["FirstDayOfWeek"]).ParamValue);
            //cbComparision.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["ComparisionType"]).ParamValue);
            //cbCompareWeek.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["ComparisionPeriod"]).ParamValue);
            //chkRecentWeek.Checked       = bool.Parse(((ReportParameter)_ParamTable["IsRecent"]).ParamValue);
            //numShown.Value = int.Parse(((ReportParameter)_ParamTable["NumShown"]).ParamValue.ToString());

            //SetRecentWeek();
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
                //case "FirstDayOfWeek": 
                //    return cbDayOfWeek.SelectedIndex.ToString();
                //case "FirstWeekStart":
                //    return dtStartWeek.Value.ToString("yyyy/MM/dd");
                //case "SecondWeekStart":
                //    return dtCompareWeek.Value.ToString("yyyy/MM/dd");
                //case "ComparisionType":
                //    return cbComparision.SelectedIndex.ToString();
                //case "IsRecent":
                //    return chkRecentWeek.Checked.ToString();
                //case "ComparisionPeriod":
                //    return cbCompareWeek.SelectedIndex.ToString();
                //case "NumShown":
                //    return numShown.Value.ToString();
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
                //case "FirstDayOfWeek":
                //    return new ReportParameter(name, cbDayOfWeek.SelectedIndex.ToString(), cbDayOfWeek.SelectedItem.ToString(), "DayOfWeek");
                //case "FirstWeekStart":
                //    return new ReportParameter(name, dtStartWeek.Value.ToString("yyyy/MM/dd"), dtStartWeek.Value.ToString("MM/dd/yyyy"), "DateTime");
                //case "SecondWeekStart":
                //    return new ReportParameter(name, dtCompareWeek.Value.ToString("yyyy/MM/dd"), dtCompareWeek.Value.ToString("MM/dd/yyyy"), "DateTime");
                //case "ComparisionType":
                //    return new ReportParameter(name, cbComparision.SelectedIndex.ToString(), cbComparision.SelectedItem.ToString(), "ComparisionType");
                //case "IsRecent":
                //    return new ReportParameter(name, chkRecentWeek.Checked.ToString(), chkRecentWeek.Checked.ToString(), "Boolean");
                //case "ComparisionPeriod":
                //    return new ReportParameter(name, cbCompareWeek.SelectedIndex.ToString(), cbCompareWeek.SelectedItem.ToString(), "ComparisionPeriod");
                //case "NumShown":
                //    return new ReportParameter(name, numShown.Value.ToString(), numShown.Value.ToString(), "Number");
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
        //private void SetRecentWeek()
        //{
        //    if (chkRecentWeek.Checked)
        //    {
        //        DateTime weekStart = VWA4Common.VWACommon.LastDayOfWeek.AddDays(-7);
        //        dtStartWeek.Value = weekStart.AddDays(DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex - weekStart.DayOfWeek);
        //    }
        //}
        //private void chkRecentWeek_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetRecentWeek();
        //    cbCompareWeek_SelectedIndexChanged(sender, e);
        //}

        //private void cbCompareWeek_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    dtCompareWeek.Enabled = true;
        //    switch (cbCompareWeek.Text)
        //    {
        //        case "None":
        //            dtCompareWeek.Enabled = false;
        //            break;
        //        case "Previous Week":
        //            dtCompareWeek.Value = dtStartWeek.Value.AddDays(-7);
        //            break;
        //        case "Previous Cycle":
        //            dtCompareWeek.Value = VWA4Common.GlobalSettings.PreviousCycleStartDate(dtStartWeek.Value);
        //            break;
        //        case "Previous Year":
        //            dtCompareWeek.Value = dtStartWeek.Value.AddYears(-1);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void dtStartWeek_ValueChanged(object sender, EventArgs e)
        //{
        //    cbCompareWeek_SelectedIndexChanged(sender, e);
        //    if (dtCompareWeek.Value == dtStartWeek.Value)
        //        dtCompareWeek.Value = dtStartWeek.Value.AddDays(-7);
        //}

        //private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dtStartWeek.Value.DayOfWeek != DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex)
        //        dtStartWeek.Value = dtStartWeek.Value.AddDays(DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex - dtStartWeek.Value.DayOfWeek);
        //    if (dtCompareWeek.Value.DayOfWeek != DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex)
        //        dtCompareWeek.Value = dtCompareWeek.Value.AddDays(DayOfWeek.Sunday + cbDayOfWeek.SelectedIndex - dtCompareWeek.Value.DayOfWeek);
        //}
    
        //public class ComparisionTypeChangedEventArgs : EventArgs
        //{
        //    private string _ComparisionType;

        //    public string ComparisionType
        //    {
        //        get { return _ComparisionType; }
        //        set { _ComparisionType = value; }
        //    }

        //    public ComparisionTypeChangedEventArgs(string name)
        //    {
        //        _ComparisionType = Regex.Match(name, "^(\\w+)").Value;
        //    }

        //}
        //public delegate void ComparisionTypeChangedEventHandler(object sender, ComparisionTypeChangedEventArgs e);
        //private ComparisionTypeChangedEventHandler comparisionTypeChanged;
        //public event ComparisionTypeChangedEventHandler ComparisionTypeChanged
        //{
        //    add { comparisionTypeChanged += value; }
        //    remove { comparisionTypeChanged -= value; }
        //}
        //public void SetComparisionTypeChanged()
        //{
        //    OnComparisionTypeChanged(new ComparisionTypeChangedEventArgs(cbComparision.SelectedItem.ToString()));
        //}
        //protected virtual void OnComparisionTypeChanged(ComparisionTypeChangedEventArgs e)
        //{
        //    if (comparisionTypeChanged != null)
        //        comparisionTypeChanged(this, e);
        //}
        
        //private void cbComparision_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (sender != null)
        //        SetComparisionTypeChanged();
        //}

        //public void SetFirstDayOfWeek(DayOfWeek first)
        //{
        //    cbDayOfWeek.SelectedIndex = VWA4Common.VWACommon.NumberOfDayOfWeek(first.ToString());
        //}
    }
}
