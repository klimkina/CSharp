using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCNumberParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = {"Number"};
        private string[] _DefaultValues = { "0"};
        private string[] _DisplayValues = { "0"};
        private string[] _ParamTypes = { "Number"};
        public UCNumberParameters()
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
            numShown.Value = 0;
        }
        public void HashLoad(Hashtable paramlist)
        { 
            foreach(string name in _ParamNames)
            {
                ReportParameter param = (ReportParameter)paramlist[name];
                if(param != null)
                    _ParamTable.Add(param.Name, param);
                numShown.Value = int.Parse(((ReportParameter)paramlist["Number"]).ParamValue);
            }
        }
        public bool IsValid()
        {
            return numShown.Value >= 0;
        }
        public string GetValue(string name)
        {
            switch(name)
            {
                case "Number":
                    return numShown.Value.ToString();
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
            return ((ReportParameter)_ParamTable[name]);
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
                    res += ", " +param.Name;
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
            if (_ParamTable["Number"] == null)
                _ParamTable.Add("Number", new ReportParameter("Number"));
            ((ReportParameter)_ParamTable["Number"]).ParamValue = numShown.Value.ToString();
            ((ReportParameter)_ParamTable["Number"]).DisplayValue = numShown.Value.ToString();
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

