using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCSWATParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "SWATDate", "SiteID"};
        private string[] _ParamTypes = { "DateTime", "Number"};
        
        public UCSWATParameters()
        {
            InitializeComponent(); 
        }


		public void InitRunTime()
		{
			InitDefault();
		}

        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        
        public void InitDefault()
        {
            _ParamTable.Clear();

            if (dbDetector == null)
            {
                dbDetector = VWA4Common.DBDetector.GetDBDetector();
                dbDetector.SiteChanged += new VWA4Common.DBDetectorEventHandler(dbDetector_SiteChanged);
            }

            this.dtSelectedWeek.Value = DateTime.Now;
            _ParamTable.Add("SWATDate", new ReportParameter("SWATDate", VWA4Common.VWACommon.DateToString(DateTime.Now), VWA4Common.VWACommon.DateToString(DateTime.Now), "DateTime"));
            _ParamTable.Add("SiteID", new ReportParameter("SiteID", VWA4Common.GlobalSettings.CurrentSiteID.ToString(), VWA4Common.GlobalSettings.CurrentSiteName, "Number"));
        }
        private void DisplayHashValues()
        {
            dtSelectedWeek.Value = DateTime.Parse(((ReportParameter)_ParamTable["SWATDate"]).ParamValue.ToString());
            ucSiteChooser1.SiteID = ((ReportParameter)_ParamTable["SiteID"]).DisplayValue.ToString();
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
                case "SWATDate":
                    return VWA4Common.VWACommon.DateToString(dtSelectedWeek.Value);
                case "SiteID":
                    return ucSiteChooser1.SiteID.ToString();
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
                case "SWATDate":
                    return new ReportParameter(name, VWA4Common.VWACommon.DateToString(dtSelectedWeek.Value), VWA4Common.VWACommon.DateToString(dtSelectedWeek.Value), "DateTime");
                case "SiteID":
                    return new ReportParameter(name, this.ucSiteChooser1.SiteID, this.ucSiteChooser1.SiteName, "Number");
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
        public void SetPreShiftMeeting()
        {
            this.label1.Text = "Meeting Date:";
            this.label1.Visible = true;
            dtSelectedWeek.Visible = true;
        }
        public void SetSWAT()
        {
            this.label1.Text = "SWAT Date:";
            this.label1.Visible = true;
            dtSelectedWeek.Visible = true;
        }
        public void SetSWATNotes()
        {
            this.label1.Text = "SWAT Week:";
            this.label1.Visible = true;
            dtSelectedWeek.Visible = true;
        }
        public void SetSWATNotesStart(DateTime dt)
        {
            dtSelectedWeek.Value = dt;
        }
        public void SetEmployeeRecognition()
        {
            this.label1.Visible = false;
            dtSelectedWeek.Visible = false;
        }
        void dbDetector_SiteChanged(object sender, EventArgs e)
        {
            ucSiteChooser1.SiteID = VWA4Common.GlobalSettings.CurrentSiteID.ToString();
        }
    }
}
