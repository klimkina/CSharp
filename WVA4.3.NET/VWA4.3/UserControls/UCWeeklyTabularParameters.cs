using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCWeeklyTabularParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "SiteID", "IsPreConsumer", "IsPostConsumer", "IsIntermediate" };
        private string[] _ParamTypes = { "Number", "Boolean", "Boolean", "Boolean" };

        public UCWeeklyTabularParameters()
        {
            InitializeComponent();
        }
 
		public void InitDefault()
        {
            _ParamTable.Clear();
            if (this.ucSiteChooser1 != null && this.ucSiteChooser1.SiteID != null)
                _ParamTable.Add("SiteID", new ReportParameter("SiteID", this.ucSiteChooser1.SiteID, this.ucSiteChooser1.SiteName, "Number"));
            _ParamTable.Add("IsPreConsumer", new ReportParameter("IsPreConsumer", true.ToString(), true.ToString(), "Boolean"));
            _ParamTable.Add("IsPostConsumer", new ReportParameter("IsPostConsumer", false.ToString(), false.ToString(), "Boolean"));
            _ParamTable.Add("IsIntermediate", new ReportParameter("IsIntermediate", false.ToString(), false.ToString(), "Boolean"));
            DisplayHashValues();
        }
        private void DisplayHashValues()
        {
            if (this.ucSiteChooser1 != null && this.ucSiteChooser1.SiteID != null)
                ucSiteChooser1.SiteID = ((ReportParameter)_ParamTable["SiteID"]).DisplayValue.ToString();
            chkPre.Checked = bool.Parse(((ReportParameter)_ParamTable["IsPreConsumer"]).ParamValue);
            chkPost.Checked = bool.Parse(((ReportParameter)_ParamTable["IsPostConsumer"]).ParamValue);
            chkIntermediate.Checked = bool.Parse(((ReportParameter)_ParamTable["IsIntermediate"]).ParamValue);
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
            return chkPre.Checked || chkPost.Checked || chkIntermediate.Checked;
        }
        public string GetValue(string name)
        {
            switch (name)
            {
                case "SiteID":
                    return ucSiteChooser1.SiteID.ToString();
                case "IsPreConsumer":
                    return chkPre.Checked.ToString();
                case "IsPostConsumer":
                    return chkPost.Checked.ToString();
                case "IsIntermediate":
                    return chkIntermediate.Checked.ToString();
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
                case "SiteID":
                    return new ReportParameter(name, this.ucSiteChooser1.SiteID, this.ucSiteChooser1.SiteName, "Number");
                case "IsPreConsumer":
                    return new ReportParameter(name, chkPre.Checked.ToString(), chkPre.Checked.ToString(), "Boolean");
                case "IsPostConsumer":
                    return new ReportParameter(name, chkPost.Checked.ToString(), chkPost.Checked.ToString(), "Boolean");
                case "IsIntermediate":
                    return new ReportParameter(name, chkIntermediate.Checked.ToString(), chkIntermediate.Checked.ToString(), "Boolean");
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
    }
}
