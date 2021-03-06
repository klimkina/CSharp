﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCBaseParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "ChartColor", "Is3D", "IsHorizontal", "IsShowLbs", "IsLeanPathLogo", "Title", "SubTitle", "IsCustomLogo", "Filter", "IsShowReport", "ReportID", "SiteID", "WasteClasses", "IsPercent" };
        private string[] _DefaultValues = { "Default", "False", "False", "False", "True", "", "", "False", "", "True", "-1", "0", "", "False", "False" };
        private string[] _ParamTypes = { "ChartColor", "Boolean", "Boolean", "Boolean", "Boolean", "String", "String", "Boolean", "String", "Boolean", "Number", "Number", "All", "Boolean", "Boolean" };
        
		/// <summary>
		/// Constructor
		/// </summary>
		public UCBaseParameters()
        {
            InitializeComponent();
        }

		/// <summary>
		/// SAR separated out the initialization to make the designer work.  This was in the constructor,
		/// which blew up the design time.
		/// </summary>
		public void InitRunTime()
		{
			if (!bool.Parse(VWA4Common.GlobalSettings.AdvancedFiltersOn))
			{
				btnFilter.Visible = false;
				btnLoad.Left = btnLoad.Left - (btnSave.Left - btnFilter.Left);
				btnSave.Left = btnFilter.Left;
			}
			InitDefault();
		}
		
		
		public void ShowWasteClasses(bool isShow)
        {
            lblWasteClasses.Visible = isShow;
            cbWasteClasses.Visible = isShow;
        }
        private void InitWasteLevelClasses()
        {

			//string wasteLevel = VWA4Common.GlobalSettings.VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes");
            cbWasteClasses.Items.Clear();
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM WasteClass "// + 
                //(wasteLevel == "-1" ? "" : "WHERE WasteProfile = '" + VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes") + "'") 
				+ " ORDER BY DisplayFullName");
            cbWasteClasses.Items.Add(new VWA4Common.VWACommon.MyListBoxItem("All", "-1"));
            if (dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                    cbWasteClasses.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row["DisplayFullName"].ToString(), row["UniqueName"].ToString()));
            cbWasteClasses.SetItemChecked(0, true);
        }
        public string GetWasteLevelClasses()
        {
            string res = "";
            if (cbWasteClasses.Visible)
            {
                //string wasteLevel = VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Allowed Waste Classes");
                if (cbWasteClasses.Text != "" && cbWasteClasses.Text != "All")
                    foreach (object item in cbWasteClasses.CheckedItems)
                    {
                        res += (res == "" ? "WasteClass = '" : " OR WasteClass = '") + ((VWA4Common.VWACommon.MyListBoxItem)item).ItemData + "'";

                    }
                else
                {
                    res = VWA4Common.VWACommon.GetWasteClasses();
                }
            }
            return res;
        }
        public string GetWasteLevelClassesDisplay()
        {
            return cbWasteClasses.Visible ? cbWasteClasses.Text : "";
        }
        public void InitDefault()
        {
            _ParamTable.Clear();
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DefaultValues[i], _ParamTypes[i]));
            }
            ((ReportParameter)_ParamTable["SiteID"]).ParamValue = VWA4Common.GlobalSettings.CurrentSiteID.ToString();
            ((ReportParameter)_ParamTable["SiteID"]).DisplayValue = VWA4Common.GlobalSettings.CurrentSiteName.ToString();
            cbPalette.SelectedIndex = 0;
            InitWasteLevelClasses();

            DisplayHashValues();
            
        }
        private void DisplayWasteClassFilter(string filter)
        {
            string[] arrWasteClasses = Regex.Split(filter, "OR");
            for (int i = 0; i < cbWasteClasses.Items.Count; i++)
                cbWasteClasses.SetItemChecked(i, false);
            if (arrWasteClasses.Length == 0 || arrWasteClasses[0] == "")
                cbWasteClasses.SetItemChecked(0, true);
            foreach (string wasteClass in arrWasteClasses)
                for (int i = 0; i < cbWasteClasses.Items.Count; i++)
                    if(Regex.IsMatch(wasteClass, @"\s*WasteClass\s*=\s*'" + ((VWA4Common.VWACommon.MyListBoxItem)cbWasteClasses.Items[i]).ItemData + @"'\s*"))
                        cbWasteClasses.SetItemChecked(i, true);
            toolTipWasteClasses.SetToolTip(lblWasteClasses, cbWasteClasses.Text);
        
        }
        private void DisplayHashValues()
        {
            for (int i = 0; i < cbPalette.Items.Count; i++)
            {
                if(cbPalette.Items[i].ToString() == ((ReportParameter)_ParamTable["ChartColor"]).ParamValue.ToString())
                    cbPalette.SelectedIndex = i;
            }
            chk3D.Checked = bool.Parse(((ReportParameter)_ParamTable["Is3D"]).ParamValue);
            chkHorizontal.Checked = bool.Parse(((ReportParameter)_ParamTable["IsHorizontal"]).ParamValue);
            chkLbs.Checked = bool.Parse(((ReportParameter)_ParamTable["IsShowLbs"]).ParamValue);
            chkLeanPath.Checked = bool.Parse(((ReportParameter)_ParamTable["IsLeanPathLogo"]).ParamValue); ;

            txtTitle.Text = ((ReportParameter)_ParamTable["Title"]).ParamValue.ToString();
            txtSubTitle.Text = ((ReportParameter)_ParamTable["SubTitle"]).ParamValue.ToString();
            chkCustomer.Checked =  bool.Parse(((ReportParameter)_ParamTable["IsCustomLogo"]).ParamValue.ToString());
            _strReportFilter = ((ReportParameter)_ParamTable["Filter"]).ParamValue.ToString();
            _strDisplayReportFilter = ((ReportParameter)_ParamTable["Filter"]).DisplayValue.ToString();

            DisplayWasteClassFilter(((ReportParameter)_ParamTable["WasteClasses"]).ParamValue.ToString());
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
                case "ChartColor":
                    return cbPalette.SelectedItem.ToString();
                case "Is3D":
                    return chk3D.Checked.ToString();
                case "IsHorizontal":
                    return chkHorizontal.Checked.ToString();
                case "IsShowLbs":
                    return chkLbs.Checked.ToString();
                case "IsLeanPathLogo":
                    return chkLeanPath.Checked.ToString();
                case "Title":
                    return txtTitle.Text;
                case "SubTitle":
                    return txtSubTitle.Text;
                case "IsCustomLogo":
                    return chkCustomer.Checked.ToString();
                case "Filter":
                    return _strReportFilter;
                case "IsShowReport":
                    return ((ReportParameter)_ParamTable["IsShowReport"]).ParamValue;
                case "ReportID":
                    return ((ReportParameter)_ParamTable["ReportID"]).ParamValue;
                case "SiteID":
                    return ((ReportParameter)_ParamTable["IsShowReport"]).ParamValue;
                case "WasteClasses":
                    return GetWasteLevelClasses();// cbWasteClasses.SQLString;
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
                case "ChartColor":
                    return new ReportParameter(name, cbPalette.SelectedItem.ToString(), cbPalette.SelectedItem.ToString(), "String");
                case "Is3D":
                    return new ReportParameter(name, chk3D.Checked.ToString(), chk3D.Checked.ToString(), "Boolean");
                case "IsHorizontal":
                    return new ReportParameter(name, chkHorizontal.Checked.ToString(), chkHorizontal.Checked.ToString(), "Boolean");
                case "IsShowLbs":
                    return new ReportParameter(name, chkLbs.Checked.ToString(), chkLbs.Checked.ToString(), "Boolean");
                case "IsLeanPathLogo":
                    return new ReportParameter(name, chkLeanPath.Checked.ToString(), chkLeanPath.Checked.ToString(), "Boolean");
                case "Title":
                    return new ReportParameter(name, txtTitle.Text, txtTitle.Text, "String");
                case "SubTitle":
                    return new ReportParameter(name, txtSubTitle.Text, txtSubTitle.Text, "String");
                case "IsCustomLogo":
                    return new ReportParameter(name, chkCustomer.Checked.ToString(), chkCustomer.Checked.ToString(), "Boolean");
                case "Filter":
                    return new ReportParameter(name, _strReportFilter, _strDisplayReportFilter, "String");
                case "IsShowReport":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["IsShowReport"]).ParamValue, ((ReportParameter)_ParamTable["IsShowReport"]).DisplayValue, "Boolean");
                case "ReportID":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["ReportID"]).ParamValue, ((ReportParameter)_ParamTable["ReportID"]).DisplayValue, "Number");
                case "SiteID":
                    return new ReportParameter(name, ((ReportParameter)_ParamTable["SiteID"]).ParamValue, ((ReportParameter)_ParamTable["SiteID"]).DisplayValue, "Number");
                case "WasteClasses":
                    return new ReportParameter(name, GetWasteLevelClasses(), cbWasteClasses.Text, "String");
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

        public delegate void ViewReportEventHandler(object sender, EventArgs e);
        private ViewReportEventHandler viewReport;
        public event ViewReportEventHandler ViewReport
        {
            add { viewReport += value; }
            remove { viewReport -= value; }
        }
        public void SetViewReport()
        {
            OnViewReport(EventArgs.Empty);
        }
        protected virtual void OnViewReport(EventArgs e)
        {
            if (viewReport != null)
                viewReport(this, e);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (IsValid())
                if (sender != null)
                    SetViewReport();
        }

        public delegate void ExportPDFEventHandler(object sender, EventArgs e);
        private ExportPDFEventHandler exportPDF;
        public event ExportPDFEventHandler ExportPDF
        {
            add { exportPDF += value; }
            remove { exportPDF -= value; }
        }
        public void SetExportPDF()
        {
            OnExportPDF(EventArgs.Empty);
        }
        protected virtual void OnExportPDF(EventArgs e)
        {
            if (exportPDF != null)
                exportPDF(this, e);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportPDF();
        }

        public class FilterEventArgs : EventArgs
        {
            private DateTime start;
            private DateTime end;
            private string reportFilter;

            public string ReportFilter
            {
              get { return reportFilter; }
              set { reportFilter = value; }
            }
            public FilterEventArgs(DateTime startDate, DateTime endDate, string reportFilter)
            {
                start = startDate;
                end = endDate;
                this.reportFilter = reportFilter;
            }
            public DateTime StartDate
            {
                get { return start; }
                set { start = value; }
            }
            public DateTime EndDate
            {
                get { return end; }
                set { end = value; }
            }
            public new bool Empty
            {
                get{ return (start == new DateTime(0) || end == new DateTime(0));}
            }
        }
        public delegate void FilterEventHandler(object sender, FilterEventArgs e);
        private FilterEventHandler filter;
        public event FilterEventHandler Filter
        {
            add { filter += value; }
            remove { filter -= value; }
        }
        public void SetFilter(DateTime start, DateTime end, string reportFilter)
        {
            OnFilter(new FilterEventArgs(start, end, reportFilter));
        }
        protected virtual void OnFilter(FilterEventArgs e)
        {
            if (filter != null)
                filter(this, e);
        }
        private string _strReportFilter = "", _strDisplayReportFilter = "";
        private string _strTreeFilters = "", _strDisplayTreeFilters = "", _siteID = "", _siteName = "";
        private string _strPreconsumerFilters = "", _strPreconsumerDisplayFilters = "";
        private DateTime _startDate, _endDate;
        private void btnFilter_Click(object sender, EventArgs e)
        {
            ViewWaste frm = new ViewWaste();
			
            if (_startDate != new DateTime(0) && _endDate != new DateTime(0))
                frm.AddPeriodFilter(_startDate, _endDate);


			///SAR - Remove waste classes 010311 ; Jira VWAAMWT-240
			//string wasteClasses = GetWasteLevelClasses();
			//if (wasteClasses != "")
			//frm.AddWasteClassFilter(wasteClasses, cbWasteClasses.Text);
            frm.AddFilter(_strTreeFilters, _strDisplayTreeFilters);
            if (_siteID == "")
            {
                _siteID = VWA4Common.GlobalSettings.CurrentSiteID.ToString();
                _siteName = VWA4Common.GlobalSettings.CurrentSiteName.ToString();
            }
            frm.SetSiteID(_siteID, _siteName);
            frm.HideSite();
            if(_strPreconsumerFilters != "")
                frm.SetDefaultPreconsumer(_strPreconsumerFilters, _strPreconsumerDisplayFilters);
            
            frm.Caption = "Filter Data for Report";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _strReportFilter = frm.GetFilters();
                _strDisplayReportFilter = frm.GetFiltersString();
                _startDate = VWA4Common.VWACommon.GetFilterStartDate(_strReportFilter);
                _endDate = VWA4Common.VWACommon.GetFilterEndDate(_strReportFilter);
                _strReportFilter = VWA4Common.VWACommon.RemoveFilterPeriod(_strReportFilter);
                _strDisplayReportFilter = VWA4Common.VWACommon.RemoveDisplayFilterPeriod(_strDisplayReportFilter);
                SetFilter(_startDate, _endDate, _strReportFilter);
                _strPreconsumerFilters = VWA4Common.VWACommon.ExtractStringPreconsumerFilter(_strReportFilter, out _strPreconsumerDisplayFilters);

                DisplayWasteClassFilter( VWA4Common.VWACommon.ExtractWasteClassFilter(_strReportFilter));
                _strReportFilter = VWA4Common.VWACommon.RemoveWasteClassFilter(_strReportFilter);
                _strDisplayReportFilter = VWA4Common.VWACommon.RemoveWasteClassDisplayFilter(_strDisplayReportFilter);
                
            }
        }
        public void SetTreeFilters(string filters, string displayFilters, string siteID, string siteName)
        {
            if (_siteID != siteID)
            {
                _strReportFilter = filters;
                _strDisplayReportFilter = displayFilters;
            }
            else if(VWA4Common.VWACommon.NotNullOrEmpty(_strTreeFilters))
            {
                if (_strTreeFilters != "" && _strReportFilter != "")
                {
                    _strReportFilter = Regex.Replace(_strReportFilter, _strTreeFilters.Replace("(", "\\(").Replace(")", "\\)"), filters);
                    _strDisplayReportFilter = Regex.Replace(_strDisplayReportFilter, _strDisplayTreeFilters.Replace("(", "\\(").Replace(")", "\\)"), displayFilters);
                }
                else
                {
                    if (_strReportFilter == "")
                    {
                        _strReportFilter = filters;
                        _strDisplayReportFilter = displayFilters;
                    }
                    else
                    {
                        _strReportFilter = "(" + _strReportFilter + ") AND (" + filters + ")";
                        _strDisplayReportFilter = "(" + _strDisplayReportFilter + ") AND (" + displayFilters + ")";
                    }
                }
            }
            _strTreeFilters = filters;
            _strDisplayTreeFilters = displayFilters;
            _siteID = siteID;
            _siteName = siteName;
            ((ReportParameter)_ParamTable["SiteID"]).ParamValue = siteID;
            ((ReportParameter)_ParamTable["SiteID"]).DisplayValue = siteName;
        }
        public void SetDefaultPreconsumer(string filters, string displayFilters, string siteID, string siteName)
        { 
            _strPreconsumerFilters = filters;
            _strPreconsumerDisplayFilters = displayFilters;
            SetSite(siteID, siteName);
        }
        public void SetSite(string siteID, string siteName)// to reflect changing of current site
        {
            //if (_siteID != siteID)
            //{
            //    _strReportFilter = "";
            //    _strDisplayReportFilter = "";
            //}
            _siteID = siteID;
            _siteName = siteName;
            ((ReportParameter)_ParamTable["SiteID"]).ParamValue = siteID;
            ((ReportParameter)_ParamTable["SiteID"]).DisplayValue = siteName;
        }
        public DateTime StartDate
        {
            get { return VWA4Common.VWACommon.GetFilterStartDate(_strReportFilter); }
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get { return VWA4Common.VWACommon.GetFilterEndDate(_strReportFilter); }
            set{ _endDate = value; }
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

        public delegate void SaveParametersEventHandler(object sender, EventArgs e);
        private SaveParametersEventHandler saveParameters;
        public event SaveParametersEventHandler SaveParameters
        {
            add { saveParameters += value; }
            remove { saveParameters -= value; }
        }
        public void SetSaveParameters()
        {
            OnSaveParameters(EventArgs.Empty);
        }
        protected virtual void OnSaveParameters(EventArgs e)
        {
            if (saveParameters != null)
                saveParameters(this, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetSaveParameters();
        }
        public delegate void LoadParametersEventHandler(object sender, EventArgs e);
        private LoadParametersEventHandler loadParameters;
        public event LoadParametersEventHandler LoadParameters
        {
            add { loadParameters += value; }
            remove { loadParameters -= value; }
        }
        public void SetLoadParameters()
        {
            OnLoadParameters(EventArgs.Empty);
        }
        protected virtual void OnLoadParameters(EventArgs e)
        {
            if (loadParameters != null)
                loadParameters(this, e);
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetLoadParameters();
        }

        public void HideLbs()
        {
            chkLbs.Visible = false;
        }
        public void Hide3D()
        {
            chk3D.Visible = false;
            chkHorizontal.Left = chk3D.Left;
            chkLbs.Left = chkHorizontal.Left;
        }
        public void HideHorisontal()
        {
            chkHorizontal.Visible = false;
            chkLbs.Left = chkHorizontal.Left;
        }

        public void HideColor()
        {
            cbPalette.Visible = false;
        }
        public void GoalHideAll()
        {
            btnFilter.Visible = false;
            groupBox2.Visible = false;
        }
        public void ShowAll()
        {
            chkLbs.Visible = true;
            chk3D.Visible = true;
            chkHorizontal.Visible = true;
            //chkLbs.Left = 413;
            //chk3D.Left = 207;
            //chkHorizontal.Left = 309;
        }
        public void HideAll()
        {
            chkLbs.Visible = false;
            chk3D.Visible = false;
            chkHorizontal.Visible = false;
        }


        public delegate void ExportRTFEventHandler(object sender, EventArgs e);
        private ExportRTFEventHandler exportRTF;
        public event ExportRTFEventHandler ExportRTF
        {
            add { exportRTF += value; }
            remove { exportRTF -= value; }
        }
        public void SetExportRTF()
        {
            OnExportRTF(EventArgs.Empty);
        }
        protected virtual void OnExportRTF(EventArgs e)
        {
            if (exportRTF != null)
                exportRTF(this, e);
        }

        private void btnRTF_Click(object sender, EventArgs e)
        {
            if (sender != null)
                SetExportRTF();
        }

        bool _IsInner = false;
        private void cbWasteClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(!_IsInner)
            {
                if (e.Index == 0)
                {
                    _IsInner = true;
                    for (int i = 1; i < cbWasteClasses.Items.Count; i++)
                        cbWasteClasses.SetItemChecked(i, e.NewValue == CheckState.Checked);
                    _IsInner = false;
                }
                else
                {
                    _IsInner = true;
                    cbWasteClasses.SetItemChecked(0, false);
                    _IsInner = false;
                }
                toolTipWasteClasses.SetToolTip(lblWasteClasses, cbWasteClasses.Text);
            }
        }
    }
}
