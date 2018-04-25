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
    public partial class UCDateRangePeriodParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "StartDate", "EndDate", "PeriodIndex" };
        private string[] _ParamTypes = { "DateTime", "DateTime", "Number" };
        public DateTime StartDate
        {
            set { dateStart.Value = value; }
            get { return dateStart.Value; }
        }
        public DateTime EndDate
        {
            set { dateEnd.Value = value; }
            get { return dateEnd.Value; }
        }
        public UCDateRangePeriodParameters()
        {
            InitializeComponent();
        }
        public void InitDefault()
        {
            _ParamTable.Clear();
            dateStart.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
            dateEnd.Value = dateStart.Value.AddDays(7);
            _ParamTable.Add("StartDate", new ReportParameter("StartDate", VWA4Common.VWACommon.DateToString(dateStart.Value), VWA4Common.VWACommon.DateToWesternFormat(dateStart.Value), "DateTime"));
            _ParamTable.Add("EndDate", new ReportParameter("EndDate", VWA4Common.VWACommon.DateToString(dateEnd.Value), VWA4Common.VWACommon.DateToWesternFormat(dateEnd.Value), "DateTime"));

            cbCompareWeek.SelectedIndex = 0;
            _IsEndCalculated = false;
            _ParamTable.Add("PeriodIndex", new ReportParameter("PeriodIndex", "0", "0", "Number"));
        }
        public void SetFirstDayOfWeek(DayOfWeek day)
        {
            int diff = day - dateStart.Value.DayOfWeek;
            dateStart.Value = dateStart.Value.AddDays(diff);
            dateEnd.Value = dateEnd.Value.AddDays(diff);
        }
        public void HashLoad(Hashtable paramlist)
        {
            foreach (string name in _ParamNames)
            {
                ReportParameter param = (ReportParameter)paramlist[name];
                if (param != null)
                {
                    param = (ReportParameter)paramlist[name];
                    _ParamTable[name] = param;
                }
            }
            dateEnd.Value = DateTime.Parse(((ReportParameter)_ParamTable["EndDate"]).ParamValue, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
            dateStart.Value = DateTime.Parse(((ReportParameter)_ParamTable["StartDate"]).ParamValue, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
            cbCompareWeek.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["PeriodIndex"]).ParamValue);
            //mila: is it needed? or for some reports only?
            if (dateStart.Value.DayOfWeek.ToString() != VWA4Common.GlobalSettings.FirstDayOfWeek && (dateEnd.Value.Subtract(dateStart.Value).Days % 7 == 0))
            {
                int diff = (DayOfWeek)DayOfWeek.Parse(typeof(DayOfWeek), VWA4Common.GlobalSettings.FirstDayOfWeek) - dateStart.Value.DayOfWeek;
                dateStart.Value = dateStart.Value.AddDays(diff);
                dateEnd.Value = dateEnd.Value.AddDays(diff);
            }
        }
        public bool IsValid()
        {
            return dateStart.Value <= dateEnd.Value;
        }
        public string GetValue(string name)
        {
            switch (name)
            {
                case "StartDate":
                    return VWA4Common.VWACommon.DateToString(dateStart.Value);
                case "EndDate":
                    return VWA4Common.VWACommon.DateToString(dateEnd.Value);
                case "PeriodIndex":
                    return cbCompareWeek.SelectedIndex.ToString();
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
            if (_ParamTable["StartDate"] == null)
                _ParamTable.Add("StartDate", new ReportParameter("StartDate"));
            if (_ParamTable["EndDate"] == null)
                _ParamTable.Add("EndDate", new ReportParameter("EndDate"));
            ((ReportParameter)_ParamTable["StartDate"]).ParamValue = VWA4Common.VWACommon.DateToString(dateStart.Value);
            ((ReportParameter)_ParamTable["StartDate"]).DisplayValue = VWA4Common.VWACommon.DateToWesternFormat(dateStart.Value);
            ((ReportParameter)_ParamTable["EndDate"]).ParamValue = VWA4Common.VWACommon.DateToString(dateEnd.Value);
            ((ReportParameter)_ParamTable["EndDate"]).DisplayValue = VWA4Common.VWACommon.DateToWesternFormat(dateEnd.Value);

            ((ReportParameter)_ParamTable["PeriodIndex"]).ParamValue = cbCompareWeek.SelectedIndex.ToString();
            ((ReportParameter)_ParamTable["PeriodIndex"]).DisplayValue = cbCompareWeek.SelectedIndex.ToString();
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
        public delegate void StartDateChangedEventHandler(object sender, VWA4Common.VWACommon.DateEventArgs e);
        private StartDateChangedEventHandler startDateChanged;
        public event StartDateChangedEventHandler StartDateChanged
        {
            add { startDateChanged += value; }
            remove { startDateChanged -= value; }
        }
        public void SetStartDateChanged()
        {
            OnStartDateChanged(new VWA4Common.VWACommon.DateEventArgs(dateStart.Value));
        }
        protected virtual void OnStartDateChanged(VWA4Common.VWACommon.DateEventArgs e)
        {
            if (startDateChanged != null)
                startDateChanged(this, e);
        }

        private void dateStart_ValueChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (sender != null)
                OnStartDateChanged(e);
        }

        public delegate void EndDateChangedEventHandler(object sender, VWA4Common.VWACommon.DateEventArgs e);
        private EndDateChangedEventHandler endDateChanged;
        public event EndDateChangedEventHandler EndDateChanged
        {
            add { endDateChanged += value; }
            remove { endDateChanged -= value; }
        }
        public void SetEndDateChanged()
        {
            OnEndDateChanged(new VWA4Common.VWACommon.DateEventArgs(dateEnd.Value));
        }
        protected virtual void OnEndDateChanged(VWA4Common.VWACommon.DateEventArgs e)
        {
            if (endDateChanged != null)
                endDateChanged(this, e);
        }
        private void dateEnd_ValueChanged(object sender, VWA4Common.VWACommon.DateEventArgs e)
        {
            if (sender != null)
                OnEndDateChanged(e);
        }
        private bool _IsStartSelected = true;
        private void cbCompareWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsStartSelected)
                SetEndDate();
            else
                SetStartDate();
        }

        private bool _IsStartCalculated = false;
        private void SetEndDate()
        {
            _IsEndCalculated = true;
            if (cbCompareWeek.SelectedItem != null)
                switch (cbCompareWeek.SelectedItem.ToString())
                {

                    case "Week":
                        dateEnd.Value = dateStart.Value.AddDays(7);
                        break;
                    case "2 Weeks":
                        dateEnd.Value = dateStart.Value.AddDays(14);
                        break;
                    case "3 Weeks":
                        dateEnd.Value = dateStart.Value.AddDays(21);
                        break;
                    case "4 Weeks":
                        dateEnd.Value = dateStart.Value.AddDays(28);
                        break;
                    case "Month":
                        dateEnd.Value = dateStart.Value.AddMonths(1);
                        break;
                    case "2 Months":
                        dateEnd.Value = dateStart.Value.AddMonths(2);
                        break;
                    case "3 Months":
                        dateEnd.Value = dateStart.Value.AddMonths(3);
                        break;
                    default:
                        break;
                }
            
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (!_IsStartCalculated)
            {
                SetEndDate();
                _IsStartSelected = true;
            }
            _IsStartCalculated = false;
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!_IsEndCalculated)
            {
                SetStartDate();
                _IsStartSelected = false;
            }
            _IsEndCalculated = false;
        }

        private bool _IsEndCalculated = false;
        private void SetStartDate()
        {
            _IsStartCalculated = true;
            if (cbCompareWeek.SelectedItem != null)
                switch (cbCompareWeek.SelectedItem.ToString())
                {

                    case "Week":
                        dateStart.Value = dateEnd.Value.AddDays(-7);
                        break;
                    case "2 Weeks":
                        dateStart.Value = dateEnd.Value.AddDays(-14);
                        break;
                    case "3 Weeks":
                        dateStart.Value = dateEnd.Value.AddDays(-21);
                        break;
                    case "4 Weeks":
                        dateStart.Value = dateEnd.Value.AddDays(-28);
                        break;
                    case "Month":
                        dateStart.Value = dateEnd.Value.AddMonths(-1);
                        break;
                    case "2 Months":
                        dateStart.Value = dateEnd.Value.AddMonths(-2);
                        break;
                    case "3 Months":
                        dateStart.Value = dateEnd.Value.AddMonths(-3);
                        break;
                    default:
                        break;
                }
            
        }
    }
}
