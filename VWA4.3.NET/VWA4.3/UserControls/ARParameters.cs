using System;
using System.Collections.Generic;
using System.Text;

namespace UserControls
{
    public class ARParameters
    {
        private DataDynamics.ActiveReports.Chart.ColorPalette _ColorPalette;

        private string _Title;
        private string _SubTitle;
        private string _Footer;

        private string _Filter;
        private string _DisplayFilter;
        private string _DisplayPeriod;
        private string _Where;

        private string _AggregatePeriod;
        private DayOfWeek _FirstDayOfWeek;

        private bool _ShowTransNum;
        private bool _ShowLbs;
        private bool _Is3D;
        private bool _IsHorizontal;

        private DateTime _StartDate;
        private DateTime _EndDate;
        private string _LogoPath;
        private string _DBPath;

        private string _ParamName;
        private string _ParamValue;
        private string _ParamDisplayValue;

        private int _NumShown;
        private string _Comparision;
        private DateTime _ComparisionStart;
        private DateTime _ComparisionEnd;

        private bool _IsOrderByWeight;
        private bool _IsShowSub;

        public string Title
        { 
            set { _Title = value; }
            get { return _Title; }
        }
        public string SubTitle
        { 
            set { _SubTitle = value; }
            get { return _SubTitle; }
        }
        public string Footer
        { 
            set { _Footer = value; }
            get { return _Footer; }
        }

        public string Filter
        { 
            set 
            { 
                _Filter = value;
                if (_Filter != null && _Filter != "")
                    _Where = " WHERE " + _Filter;
                else
                    _Where = "";
                if (VWA4Common.VWACommon.GetFilterStartDate(_Filter) != new DateTime(0))
                {
                    _DisplayPeriod = "from " + VWA4Common.VWACommon.GetFilterStartDate(_Filter) + " ";
                }
                _DisplayPeriod += "to " + VWA4Common.VWACommon.GetFilterEndDate(_Filter);
                
            }
            get { return _Filter; }
        }
        
        public string DisplayFilter
        {
            set { _DisplayFilter = value; }
            get { return _DisplayFilter; }
        }
        public string DisplayPeriod
        {
            set { _DisplayPeriod = value; }
            get { return _DisplayPeriod; }
        }
        public string Where
        { 
            get { return _Where; } 
        }
        public DataDynamics.ActiveReports.Chart.ColorPalette ColorPalette
        {
            set { _ColorPalette = value; }
            get { return _ColorPalette; }
        }

        public string ColorPaletteName
        {
            set
            {
                switch (value)
                {
                    case "Autumn":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Autumn;
                        break;
                    case "Cascade":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Cascade;
                        break;
                    case "Springtime":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Springtime;
                        break;
                    case "Iceberg":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Iceberg;
                        break;
                    case "Confetti":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Confetti;
                        break;
                    case "Greens":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Greens;
                        break;
                    case "Berries":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Berries;
                        break;
                    case "Murphy":
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Murphy;
                        break;
                    default:
                        _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Default;
                        break;
                }
            }
        }

        public string AggregatePeriod
            { 
                set { _AggregatePeriod = value; }
                get { return _AggregatePeriod; }
            }
            public string AccessAggregatePeriod
            {
                get
                {
                    switch (_AggregatePeriod)
                    {
                        case "Day":     return "yyyymmdd";
                        case "Week":    return "ww";
                        case "Month":   return "mm";
                        case "Quarter": return "q";
                        case "Year":    return "yyyy";
                        default:
                            throw new Exception("Dev Error - Aggregate period not handled.");
                    }
                }
            }
            public DayOfWeek FirstDayOfWeek
            { 
                set { _FirstDayOfWeek = value; }
                get { return _FirstDayOfWeek; } 
            }
            public bool ShowTransNum
            {
                set { _ShowTransNum = value; }
                get { return _ShowTransNum; }
            }
            public bool ShowLbs
            {
                set { _ShowLbs = value; }
                get { return _ShowLbs; }
            }
            public bool Is3D
            {
                set { _Is3D = value; }
                get { return _Is3D; }
            }
            public bool IsHorizontal
            {
                set { _IsHorizontal = value; }
                get { return _IsHorizontal; }
            }
            public DateTime StartDate
            {
                set { _StartDate = value; }
                get { return _StartDate; }
            }
            public DateTime EndDate
            {
                set { _EndDate = value; }
                get { return _EndDate; }
            }
            public string DBPath
            { 
                set { _DBPath = value; }
                get { return _DBPath; }
            }
            public string LogoPath
            { 
                set { _LogoPath = value; } 
                get { return _LogoPath; }
            }
            public string ParamName
            {
                set { _ParamName = value; }
                get { return _ParamName; }
            }
            public string ParamValue
            {
                set { _ParamValue = value; }
                get { return _ParamValue; }
            }
            public string ParamDisplayValue
            {
                set { _ParamDisplayValue = value; }
                get { return _ParamDisplayValue; }
            }
            public int NumShown
            {
                set { _NumShown = value; }
                get { return _NumShown; }
            }
            public string Comparison
            {
                set { _Comparision = value; }
                get { return _Comparision; }
            }
            public DateTime ComparisionStart
            {
                set { _ComparisionStart = value; }
                get { return _ComparisionStart; }
            }
            public DateTime ComparisionEnd
            {
                set { _ComparisionEnd = value; }
                get { return _ComparisionEnd; }
            }

            public bool IsOrderByWeight
            {
                set { _IsOrderByWeight = value; }
                get { return _IsOrderByWeight; }
            }
            public bool IsShowSub
            {
                set { _IsShowSub = value; }
                get { return _IsShowSub; }
            }

        public ARParameters()
        {
            _Filter = "";
            _ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.Default;
            _FirstDayOfWeek = VWA4Common.VWACommon.FirstDayOfWeek;
            _StartDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0);
            _AggregatePeriod = "ww";
            _DBPath = VWA4Common.AppContext.DBPathName;
            _NumShown = 0;
            _IsOrderByWeight = false;
            _IsShowSub = false;
        }
        public ARParameters(ARParameters parameters)
        {
            _ColorPalette = parameters._ColorPalette;
            _Title = parameters._Title;
            _SubTitle = parameters._SubTitle;
            _Footer = parameters._Footer;
            _Filter = parameters._Filter;
            _Where = parameters.Where;
            _FirstDayOfWeek = parameters.FirstDayOfWeek;
            _AggregatePeriod = parameters.AggregatePeriod;
            
            _ShowTransNum = parameters.ShowTransNum;
            _ShowLbs = parameters.ShowLbs;
            _Is3D = parameters.Is3D;

            _StartDate = parameters.StartDate;
            _EndDate = parameters.EndDate;
            _LogoPath = parameters.LogoPath;
            _DBPath = parameters.DBPath;

            _ParamName = parameters.ParamName;
            _ParamValue = parameters.ParamValue;
            _ParamDisplayValue = parameters.ParamDisplayValue;

            _NumShown = parameters._NumShown;
            _Comparision = parameters._Comparision;
            _ComparisionStart = parameters.ComparisionStart;
            _ComparisionEnd = parameters._ComparisionEnd;

            _IsOrderByWeight = parameters._IsOrderByWeight;
            _IsShowSub = parameters._IsShowSub;
        }
    }
}
