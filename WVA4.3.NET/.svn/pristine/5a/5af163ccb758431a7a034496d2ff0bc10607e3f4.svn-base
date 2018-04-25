using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCEmployeeParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "ShowEmployeeSub", "IsOrderByWeight" };
        private string[] _DefaultValues = { "False", "False" };
        private string[] _DisplayValues = { "False", "False" };
        private string[] _ParamTypes = { "Boolean", "Boolean" };
        public UCEmployeeParameters()
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
            DisplayHashValues();
        }
        private void DisplayHashValues()
        {
            chkExceptionShow.Checked = bool.Parse(((ReportParameter)_ParamTable["ShowEmployeeSub"]).ParamValue);
            radioEmployeeWeight.Checked = bool.Parse(((ReportParameter)_ParamTable["IsOrderByWeight"]).ParamValue);
            this.radioEmployeeTrans.Checked = !radioEmployeeWeight.Checked;
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
                case "ShowEmployeeSub":
                    return chkExceptionShow.Checked.ToString();
                case "IsOrderByWeight":
                    return radioEmployeeWeight.Checked.ToString();
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
                case "ShowEmployeeSub":
                    return new ReportParameter(name, chkExceptionShow.Checked.ToString(), chkExceptionShow.Checked.ToString(), "Boolean");
                case "IsOrderByWeight":
                    return new ReportParameter(name, radioEmployeeWeight.Checked.ToString(), radioEmployeeWeight.Checked.ToString(), "Boolean");
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
            if (_ParamTable["ShowEmployeeSub"] == null)
                _ParamTable.Add("ShowEmployeeSub", new ReportParameter("ShowEmployeeSub"));
            if (_ParamTable["IsOrderByWeight"] == null)
                _ParamTable.Add("IsOrderByWeight", new ReportParameter("IsOrderByWeight"));
            ((ReportParameter)_ParamTable["ShowEmployeeSub"]).ParamValue = chkExceptionShow.Checked.ToString();
            ((ReportParameter)_ParamTable["ShowEmployeeSub"]).DisplayValue = (chkExceptionShow.Checked ? "Yes" : "No");
            ((ReportParameter)_ParamTable["IsOrderByWeight"]).ParamValue = radioEmployeeWeight.Checked.ToString();
            ((ReportParameter)_ParamTable["IsOrderByWeight"]).DisplayValue = (radioEmployeeWeight.Checked ? "Yes" : "No");
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
