using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCCrossTabParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "NumShown", "CrossTabReport", "CrossTabOn", "Recent4Weeks"};
        private string[] _DefaultValues = { "0", "0", "1", "0"};
        private string[] _DisplayValues = { "0", VWA4Common.VWACommon.WasteProfile, "Loss", "0" };
		private string[] _ParamTypes = { "Number", "ReportValue", "ReportValue", "Number" };
        public UCCrossTabParameters()
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
            numShown.Value = int.Parse(((ReportParameter)_ParamTable["NumShown"]).ParamValue.ToString());
            cbCrossTabReport.SelectedItem = ((ReportParameter)_ParamTable["CrossTabReport"]).DisplayValue;
            cbCrossTabOn.SelectedItem = ((ReportParameter)_ParamTable["CrossTabOn"]).DisplayValue;
			cmbRecentWeeks.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["Recent4Weeks"]).ParamValue.ToString());
			if(cmbRecentWeeks.SelectedIndex != 0)
				SetRecentWeeksChecked();
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
                case "NumShown":
                    return numShown.Value.ToString();
                case "CrossTabReport":
                    return (cbCrossTabReport.SelectedItem.ToString() == "Event Order" ? 
                        (cbCrossTabReport.SelectedItem.ToString() == VWA4Common.VWACommon.WasteProfile ? "Food" : cbCrossTabReport.SelectedItem.ToString()) : 
                        "BEO");
                case "CrossTabOn":
                    return (cbCrossTabOn.SelectedItem.ToString() == "Event Order" ? 
                        (cbCrossTabReport.SelectedItem.ToString() == VWA4Common.VWACommon.WasteProfile ? "Food" : cbCrossTabReport.SelectedItem.ToString())
                        : "BEO");
				case "Recent4Weeks":
					return cmbRecentWeeks.SelectedIndex.ToString();
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
                case "NumShown":
                    return new ReportParameter(name, numShown.Value.ToString(), numShown.Value.ToString(), "Number");
                case "CrossTabReport":
                    {
                        ReportParameter temp = new ReportParameter(name, cbCrossTabReport.SelectedItem.ToString(), cbCrossTabReport.SelectedItem.ToString(), "ReportValue");
                        if(temp.DisplayValue == "Event Order")
                            temp.ParamValue = "BEO";
                        else if (temp.DisplayValue == VWA4Common.VWACommon.WasteProfile)
                            temp.ParamValue = "Food";
                        return temp;
                    }
                case "CrossTabOn":
                    {
                        ReportParameter temp = new ReportParameter(name, cbCrossTabOn.SelectedItem.ToString(), cbCrossTabOn.SelectedItem.ToString(), "ReportValue");
                        if (temp.DisplayValue == "Event Order")
                            temp.ParamValue = "BEO";
                        else //if (temp.DisplayValue == VWA4Common.VWACommon.WasteProfile)
                            temp.ParamValue = "Food";
                        return temp;
                    }
				case "Recent4Weeks":
					return new ReportParameter(name, cmbRecentWeeks.SelectedIndex.ToString(), cmbRecentWeeks.SelectedIndex.ToString(), "Number");
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

        private void cbCrossTabReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prev = VWA4Common.VWACommon.WasteProfile;
            if (cbCrossTabOn.SelectedIndex >= 0)
                prev = cbCrossTabOn.SelectedItem.ToString();
            cbCrossTabOn.Items.Clear();
            cbCrossTabOn.Items.AddRange(VWA4Common.VWACommon.ReportTypeNames);
            cbCrossTabOn.Items.RemoveAt(cbCrossTabReport.SelectedIndex);
            cbCrossTabOn.SelectedIndex = 0;
            for (int i = 0; i < cbCrossTabOn.Items.Count; i++)
            {
                if (cbCrossTabOn.Items[i].ToString() == prev)
                {
                    cbCrossTabOn.SelectedIndex = i;
                    break;
                }
                if (cbCrossTabOn.Items[i].ToString() == "Food")
                    cbCrossTabOn.Items[i] = VWA4Common.VWACommon.WasteProfile;
            }
            if (cbCrossTabOn.SelectedItem.ToString() != prev)
                if (sender != null)
                    SetCrossTabOnChanged();
        }

        public class CrossTabOnChangedEventArgs : EventArgs
        {
            private string _CrossTabOn;

            public string CrossTabOn
            {
                get { return _CrossTabOn; }
                set { _CrossTabOn = value; }
            }

            public CrossTabOnChangedEventArgs(string name)
            {
                _CrossTabOn = name;
            }

        }
        public delegate void CrossTabOnChangedEventHandler(object sender, CrossTabOnChangedEventArgs e);
        private CrossTabOnChangedEventHandler crossTabOnChanged;
        public event CrossTabOnChangedEventHandler CrossTabOnChanged
        {
            add { crossTabOnChanged += value; }
            remove { crossTabOnChanged -= value; }
        }
        public void SetCrossTabOnChanged()
        {
            string temp = cbCrossTabOn.SelectedItem.ToString();
            if (temp == "Event Order")
                temp = "BEO";
            else //if (temp == VWA4Common.VWACommon.WasteProfile)
                temp = "Food";
            OnCrossTabOnChanged(new CrossTabOnChangedEventArgs(temp));
        }
        protected virtual void OnCrossTabOnChanged(CrossTabOnChangedEventArgs e)
        {
            if (crossTabOnChanged != null)
                crossTabOnChanged(this, e);
        }
        
        private void cbCrossTabOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null)
                SetCrossTabOnChanged();
        }
        public string CrossTabOn
        { 
            get 
            {
                string temp = cbCrossTabOn.SelectedItem.ToString();
                if (temp == "Event Order")
                    temp = "BEO";
                else //if (temp == VWA4Common.VWACommon.WasteProfile)
                    temp = "Food";
                return temp; 
            } 
        }

		public class RecentWeeksCheckedEventArgs : EventArgs
		{
			private DateTime _EndDate;
			private DateTime _StartDate;

			public DateTime StartDate
			{
				get { return _StartDate; }
				set { _StartDate = value; }
			}

			public DateTime EndDate
			{
				get { return _EndDate; }
				set { _EndDate = value; }
			}

			public RecentWeeksCheckedEventArgs(DateTime start, DateTime end)
			{
				_EndDate = end;
				_StartDate = start;
			}

		}

		public delegate void RecentWeeksCheckedEventHandler(object sender, RecentWeeksCheckedEventArgs e);
        private RecentWeeksCheckedEventHandler recentWeeksChecked;
        public event RecentWeeksCheckedEventHandler RecentWeeksChecked
        {
            add { recentWeeksChecked += value; }
            remove { recentWeeksChecked -= value; }
        }
        public void SetRecentWeeksChecked()
        {
			DateTime startDate, endDate;
			GetPeriod(out startDate, out endDate);
			OnRecentWeeksChecked(new RecentWeeksCheckedEventArgs(startDate, endDate));
        }
		protected virtual void OnRecentWeeksChecked(RecentWeeksCheckedEventArgs e)
        {
            if (recentWeeksChecked != null)
                recentWeeksChecked(this, e);
        }

		//Current Week
		//Last Week
		//Last 2 Weeks
		//Last 3 Weeks
		//Last 4 Weeks
		//Last Month
		//Last 2 Months
		//Last 3 Months
		private void GetPeriod(out DateTime startDate, out DateTime endDate)
		{ 
			DateTime weekStart = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
			switch(cmbRecentWeeks.SelectedIndex)
			{
				case 1: 
					startDate = weekStart;
					endDate = DateTime.Now;
					break;
				case 2:
					startDate = weekStart.AddDays(-7);
					endDate = weekStart;
					break;
				case 3:
					startDate = weekStart.AddDays(-14);
					endDate = weekStart;
					break;
				case 4:
					startDate = weekStart.AddDays(-21);
					endDate = weekStart;
					break;
				case 5:
					startDate = weekStart.AddDays(-28);
					endDate = weekStart;
					break;
				case 6:
					endDate = new DateTime(weekStart.Year, weekStart.Month, 1, 0, 0, 0);
					startDate = endDate.AddMonths(-1);
					break;
				case 7:
					endDate = new DateTime(weekStart.Year, weekStart.Month, 1, 0, 0, 0);
					startDate = endDate.AddMonths(-2);
					break;
				case 8:
					endDate = new DateTime(weekStart.Year, weekStart.Month, 1, 0, 0, 0);
					startDate = endDate.AddMonths(-3);
					break;
				default:
					startDate = weekStart.AddDays(-7);
					endDate = weekStart;
					break;
			}
		}

		private void cmbRecentWeeks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender != null && cmbRecentWeeks.SelectedIndex != 0)
				SetRecentWeeksChecked();
		}
    }
}
