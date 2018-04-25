using System;
using System.Collections;
using System.Text;

namespace UserControls
{
    class UCPrintParameters: IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "PrintIncludeFilter", "PrintIncludeImage", "PrintTitle", "PrintAllPages", "PrintCurrentPage", "PrintFitToPages", 
                                           "PrintPagesFrom", "PrintPagesTo" };
        private string[] _DefaultValues = { "False", "False", "", "True", "False", "0", "0", "0" };
        private string[] _ParamTypes = { "Boolean", "Boolean", "String", "Boolean", "Boolean", "Number", "Number", "Number" };

        public UCPrintParameters()
        {
            InitDefault();
        }
        public void InitDefault()
        {
            _ParamTable.Clear();
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DefaultValues[i], _ParamTypes[i]));
            }
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
        }
        public bool IsValid()
        {
            return true;
        }
        
        public string GetValue(string name)
        {
            switch (name)
            {
                case "PrintIncludeFilter":
                    return ((ReportParameter)_ParamTable["PrintIncludeFilter"]).ParamValue;
                case "PrintIncludeImage":
                    return ((ReportParameter)_ParamTable["PrintIncludeImage"]).ParamValue;
                case "PrintTitle":
                    return ((ReportParameter)_ParamTable["PrintTitle"]).ParamValue;
                case "PrintAllPages":
                    return ((ReportParameter)_ParamTable["PrintAllPages"]).ParamValue;
                case "PrintCurrentPage":
                    return ((ReportParameter)_ParamTable["PrintCurrentPage"]).ParamValue;
                case "PrintFitToPages":
                    return ((ReportParameter)_ParamTable["PrintFitToPages"]).ParamValue;
                case "PrintPagesFrom":
                    return ((ReportParameter)_ParamTable["PrintPagesFrom"]).ParamValue;
                case "PrintPagesTo":
                    return ((ReportParameter)_ParamTable["PrintPagesTo"]).ParamValue;
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
                case "PrintIncludeFilter":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintIncludeFilter"]).ParamValue, ((ReportParameter)_ParamTable["PrintIncludeFilter"]).DisplayValue, "Boolean");
                case "PrintIncludeImage":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintIncludeImage"]).ParamValue, ((ReportParameter)_ParamTable["PrintIncludeImage"]).DisplayValue, "Boolean");
                case "PrintTitle":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintTitle"]).ParamValue, ((ReportParameter)_ParamTable["PrintTitle"]).DisplayValue, "String");
                case "PrintAllPages":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintAllPages"]).ParamValue, ((ReportParameter)_ParamTable["PrintAllPages"]).DisplayValue, "Boolean");
                case "PrintCurrentPage":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintCurrentPage"]).ParamValue, ((ReportParameter)_ParamTable["PrintCurrentPage"]).DisplayValue, "Boolean");
                case "PrintFitToPages":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintFitToPages"]).ParamValue, ((ReportParameter)_ParamTable["PrintFitToPages"]).DisplayValue, "Number");
                case "PrintPagesFrom":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintPagesFrom"]).ParamValue, ((ReportParameter)_ParamTable["PrintPagesFrom"]).DisplayValue, "Number");
                case "PrintPagesTo":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["PrintPagesTo"]).ParamValue, ((ReportParameter)_ParamTable["PrintPagesTo"]).DisplayValue, "Number");
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
        

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public Hashtable ParamList
        {
            get {
                return _ParamTable; 
            }
            set { this.HashLoad(value); }
        }
    }
}
