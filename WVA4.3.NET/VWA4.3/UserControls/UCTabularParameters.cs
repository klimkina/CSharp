using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCTabularParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "IsDaypart", "IsStation", "IsDisposition", "GroupByPeriod" };

        private string[] _ParamTypes = { "Boolean", "Boolean", "Boolean", "GroupByPeriod" };
        public UCTabularParameters()
        {
            InitializeComponent();
        }

        public void InitRunTime()
        {
            InitDefault();
        }

        //public void EnableAllSites(bool isEnable)
        //{
        //    ucSiteChooser1.EnableAllSites(isEnable);
        //}

        public void InitDefault()
        {
            _ParamTable.Clear();

        }
        private void DisplayHashValues()
        {
            cbGroupBy.SelectedIndex = 0;
            for (int i = 0; i < cbGroupBy.Items.Count; i++)
            { 
                if (cbGroupBy.Items[i].ToString() == ((ReportParameter)_ParamTable["GroupByPeriod"]).DisplayValue.ToString())
                cbGroupBy.SelectedIndex = i;
            }
            chkDaypart.Checked = bool.Parse(((ReportParameter)_ParamTable["IsDaypart"]).DisplayValue.ToString());
            chkStation.Checked = bool.Parse(((ReportParameter)_ParamTable["IsStation"]).DisplayValue.ToString());
            chkDaypart.Checked = bool.Parse(((ReportParameter)_ParamTable["IsStation"]).DisplayValue.ToString());
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
                case "GroupByPeriod":
                    return cbGroupBy.SelectedItem.ToString();
                case "IsDaypart":
                    return chkDaypart.Checked.ToString();
                case "IsStation":
                    return chkStation.Checked.ToString();
                case "IsDisposition":
                    return chkDisposition.Checked.ToString();
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
                case "GroupByPeriod":
                    return new ReportParameter(name, cbGroupBy.SelectedItem.ToString(), cbGroupBy.SelectedItem.ToString(), "GroupByPeriod");
                case "IsDaypart":
                    return new ReportParameter(name, chkDaypart.Checked.ToString(), chkDaypart.Checked.ToString(), "Boolean");
                case "IsStation":
                    return new ReportParameter(name, chkStation.Checked.ToString(), chkStation.Checked.ToString(), "Boolean");
                case "IsDisposition":
                    return new ReportParameter(name, chkDisposition.Checked.ToString(), chkDisposition.Checked.ToString(), "Boolean");
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
                ReportParameter param = GetItem(name);
                if (param != null)
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
            get
            {
                SetValues();
                return _ParamTable;
            }
            set { this.HashLoad(value); }
        }

        public void SetSiteID(int siteID)
        { 
        }
    }
}
