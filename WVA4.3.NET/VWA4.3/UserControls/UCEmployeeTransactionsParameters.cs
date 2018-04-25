using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace UserControls
{
    public partial class UCEmployeeTransactionsParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "EmployeeMode", "PeriodStartDate", "NumberOfWeeks"};
        private string[] _DefaultValues = { "Transactions", DateTime.Now.ToString(), "2"};
        private string[] _DisplayValues = { "", DateTime.Now.ToString(), "2"};
        private string[] _ParamTypes = { "String", "DateTime", "Number"};
        public UCEmployeeTransactionsParameters()
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
            
            dtPeriodStart.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
            numOfWeeks.Value = 2;
        }

        private void DisableAllRadio()
        {
            radioTransactions.Checked = false;
            radioCosts.Checked = false;
            radioWeights.Checked = false;
        }
        private string GetCheckedRadio()
        {
            foreach (RadioButton ctrl in this.panel1.Controls)
            {
                if (ctrl.Checked)
                    return ctrl.Name.Replace("radio", "");
            }
            return "Transactions";
        }
        private void DisplayHashValues()
        {
            DisableAllRadio();
            switch (((ReportParameter)_ParamTable["EmployeeMode"]).ParamValue)
            { 
                case "Transactions":
                    radioTransactions.Checked = true;
                    break;
                case "Costs":
                    radioCosts.Checked = true;
                    break;
                case "Weights":
                    radioWeights.Checked = true;
                    break;
                default:
                    radioTransactions.Checked = true;
                    break;
            }
            dtPeriodStart.Value = DateTime.Parse(((ReportParameter)_ParamTable["PeriodStartDate"]).ParamValue);
            numOfWeeks.Value = int.Parse(((ReportParameter)_ParamTable["NumberOfWeeks"]).ParamValue);
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
                case "EmployeeMode":
                    return GetCheckedRadio();
                case "PeriodStartDate":
                    return this.dtPeriodStart.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));
                case "NumberOfWeeks":
                    return numOfWeeks.Value.ToString();
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
                case "EmployeeMode":
                    return new ReportParameter(name, GetCheckedRadio(), GetCheckedRadio(), "String");
                case "PeriodStartDate":
                    return new ReportParameter(name, this.dtPeriodStart.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")), this.dtPeriodStart.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")), "DateTime");
                case "NumberOfWeeks":
                    return new ReportParameter(name, numOfWeeks.Value.ToString(), numOfWeeks.Value.ToString(), "Number");
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