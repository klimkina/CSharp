using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
    // Delegate for event handler to handle the device events 
    public delegate void DBDetectorEventHandler(Object sender, EventArgs e);
    public delegate void DBDetectorLoginEventHandler(Object sender, LoginEventArgs e);

    public class LoginEventArgs : EventArgs
    {
        private bool _IsSuper;

        public bool IsSuper
        {
            get { return _IsSuper; }
            set { _IsSuper = value; }
        }
        private bool _IsLogin;

        public bool IsLogin
        {
            get { return _IsLogin; }
            set { _IsLogin = value; }
        }
        public LoginEventArgs(bool isSuper, bool isLogin)
        {
            _IsSuper = isSuper;
            _IsLogin = isLogin;
        }
    }

    public class DBDetector
    {
        //public event DBDetectorEventHandler PathChanged;
        //public event DBDetectorEventHandler WeekChanged;
        public event DBDetectorEventHandler SiteChanged;
        //public event DBDetectorEventHandler FirstDayOfWeekChanged;
        public event DBDetectorEventHandler DBPathChanged;
        //public event DBDetectorEventHandler AdjustmentsChanged;
        public event DBDetectorLoginEventHandler UserLogin;

        //public bool FoodAdjustmentsChanged
        //{
        //    set
        //    {
        //        if (AdjustmentsChanged != null)
        //            AdjustmentsChanged(this, EventArgs.Empty);
        //    }
        //}
        private string _DBPath = "";

        public string DBPath
        {
            get { return _DBPath; }
            set 
            {
                if (_DBPath != value && DBPathChanged != null)
                {
                    if (_DBPath != "")
                    {
                        VWA4Common.GlobalSettings.CurrentSiteID = -1;
                        DBPathChanged(this, EventArgs.Empty);
                        if (SiteChanged != null)
                            SiteChanged(this, EventArgs.Empty);
                        
                        //if (FirstDayOfWeekChanged != null)
                        //    FirstDayOfWeekChanged(this, EventArgs.Empty);
                    }
                    VWADBUtils.MostRecents = new DateTime(0);//calculate new dates for last weights data
                }
                _DBPath = value; 
            }
        }

        private int _SiteID = -1;
        //private DayOfWeek _DayOfWeek = DayOfWeek.Monday;

        //public DayOfWeek StartDayOfWeek
        //{
        //    get { return _DayOfWeek; }
        //    set
        //    {
        //        if (_DayOfWeek != value && FirstDayOfWeekChanged != null)
        //        {
        //            FirstDayOfWeekChanged(this, EventArgs.Empty);
        //            _DayOfWeek = value;
        //        }
                
        //    }
        //}

        public int SiteID
        {
            get { return _SiteID; }
            set
            {
                if (_SiteID != value && SiteChanged != null)
                {
					VWA4Common.GlobalSettings.SiteChanged();
					SiteChanged(this, EventArgs.Empty);
                }
                //if (_SiteID != value && _DayOfWeek.ToString() != VWA4Common.GlobalSettings.FirstDayOfWeek && FirstDayOfWeekChanged != null)
                //    FirstDayOfWeekChanged(this, EventArgs.Empty);
                _SiteID = value;
            }
        }

		public bool SuperLogin
		{
			set
			{
				GlobalSettings.UserLevel = 2;
				//GlobalSettings.IsLogged = value;
				//GlobalSettings.IsSuper = value;
				if (UserLogin != null)
					UserLogin(this, new LoginEventArgs(true, value));
			}
		}
		
		public bool ManagerLogin
		{
			set
			{
				GlobalSettings.UserLevel = 1;
				//GlobalSettings.IsLogged = value;
				//GlobalSettings.IsSuper = false;
				if (UserLogin != null)
					UserLogin(this, new LoginEventArgs(false, value));
			}
		}


        public bool DBInvalidate
        {
            get { return true; }
            set
            {
                if (DBPathChanged != null)
                {
                    DBPathChanged(this, EventArgs.Empty);
                }
                //if (PathChanged != null)
                //{
                //    PathChanged(this, EventArgs.Empty);
                //}
                if (SiteChanged != null)
                {
                    SiteChanged(this, EventArgs.Empty);
                }
            }
        }

        // The single instance allowed
        private static DBDetector theDBDetectorInstance = null;

        // Private constructor preventing creating an instance
        private DBDetector()
        {
        }

        // The only way to get the object's instance
        public static DBDetector GetDBDetector()
        {
            if (theDBDetectorInstance == null)
            {
                theDBDetectorInstance = new DBDetector();
            }
            return theDBDetectorInstance;
        } 
    }
}
