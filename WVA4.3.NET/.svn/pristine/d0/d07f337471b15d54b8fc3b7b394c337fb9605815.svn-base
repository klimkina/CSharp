using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCTrendParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "AggregatePeriod", "IsShowTrans", "IsShowTrendLines", "IsChartOnly", "IsShowEmptyWeeks", "LowTransactionLimit" };
        private string[] _DefaultValues = { "Week", "False", "True", "False", "False", "0.4" };
        private string[] _DisplayValues = { "Week", "False", "True", "False", "False", "0.4" };
        private string[] _ParamTypes = { "AggregatePeriod", "Boolean", "Boolean", "Boolean", "Boolean", "Number" };

        public UCTrendParameters()
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
            cbPeriod.SelectedIndex = 1; // week
        }
        private void DisplayHashValues()
        {
            for (int i = 0; i < cbPeriod.Items.Count; i++)
            {
                if (cbPeriod.Items[i].ToString() == ((ReportParameter)_ParamTable["AggregatePeriod"]).DisplayValue.ToString())
                {
                    cbPeriod.SelectedIndex = i;
                    break;
                }
            }
            chkNumOfTrans.Checked = bool.Parse(((ReportParameter)_ParamTable["IsShowTrans"]).ParamValue);
            chkTrendLines.Checked = bool.Parse(((ReportParameter)_ParamTable["IsShowTrendLines"]).ParamValue);
            chkWeeks.Checked = bool.Parse(((ReportParameter)_ParamTable["IsShowEmptyWeeks"]).ParamValue);
            nTransLimit.Value = decimal.Parse(((ReportParameter)_ParamTable["LowTransactionLimit"]).ParamValue)*100;
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
                case "AggregatePeriod":
                    return VWA4Common.VWACommon.GetAccessPeriod( cbPeriod.SelectedItem.ToString());
                case "IsShowTrans":
                    return chkNumOfTrans.Checked.ToString();
                case "IsShowTrendLines":
                    return chkTrendLines.Checked.ToString();
                case "IsChartOnly":
                    return "False";
                case "IsShowEmptyWeeks":
                    return chkWeeks.Checked.ToString();
                case "LowTransactionLimit":
                    return (nTransLimit.Value / 100).ToString();
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
                case "IsShowTrans":
                    return new ReportParameter(name, chkNumOfTrans.Checked.ToString(), chkNumOfTrans.Checked.ToString(), "Boolean");
                case "IsShowTrendLines":
                    return new ReportParameter(name, chkTrendLines.Checked.ToString(), chkTrendLines.Checked.ToString(), "Boolean");
                case "IsChartOnly":
                    return new ReportParameter(name, "False", "False", "Boolean");
                case "IsShowEmptyWeeks":
                    return new ReportParameter(name, chkWeeks.Checked.ToString(), chkWeeks.Checked.ToString(), "Boolean");
                case "LowTransactionLimit":
                    return new ReportParameter(name, (nTransLimit.Value / 100).ToString(), (nTransLimit.Value / 100).ToString(), "Number");
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
    }
}
