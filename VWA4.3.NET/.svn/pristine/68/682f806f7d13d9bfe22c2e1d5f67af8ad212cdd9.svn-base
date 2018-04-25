using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
    public delegate void TrackerDetectorEventHandler(Object sender, EventArgs e);
    public delegate void FirstDayOfWeekDetectorEventHandler(Object sender, TrackerDetector.FirstDayOfWeekEventArgs e);
    public delegate void WeekDetectorEventHandler(Object sender, TrackerDetector.WeekEventArgs e);

    public class TrackerDetector
    {
        public event TrackerDetectorEventHandler TrackerConfigOutofSync;
        
        private DateTime _LastChanges = new DateTime(0); // for changes from DB


        public DateTime LastChanges
        {
            get { return _LastChanges; }
            set 
            {
                DateTime oldChanges = _LastChanges;
                _LastChanges = value;
                if (oldChanges != value && value != new DateTime(0) && TrackerConfigOutofSync != null)
                    TrackerConfigOutofSync(this, EventArgs.Empty);
            }
        }


        public class FirstDayOfWeekEventArgs : EventArgs
        {
            private DayOfWeek _FirstDayOfWeek;

            public DayOfWeek FirstDayOfWeek
            {
                get { return _FirstDayOfWeek; }
                set { _FirstDayOfWeek = value; }
            }
            public FirstDayOfWeekEventArgs(DayOfWeek day)
            {
                _FirstDayOfWeek = day;
            }
        }

        public event FirstDayOfWeekDetectorEventHandler FirstDayOfWeekChanged;
        private DayOfWeek _FirstDayOfWeek = DayOfWeek.Monday;

        public DayOfWeek FirstDayOfWeek
        {
            get { return _FirstDayOfWeek; }
			set
			{
				if (FirstDayOfWeekChanged != null)
				{
					_FirstDayOfWeek = value;
					FirstDayOfWeekChanged(this, new FirstDayOfWeekEventArgs(value));
				}
			}
        }

        public class WeekEventArgs : EventArgs
        {
            private DateTime _WeekStart;

            public DateTime WeekStart
            {
              get { return _WeekStart; }
              set { _WeekStart = value; }
            }


            public WeekEventArgs(DateTime day)
            {
                _WeekStart = day;
            }
        }
        public event WeekDetectorEventHandler WeekChanged;
        private DateTime _WeekStart = new DateTime(0);

        public DateTime WeekStart
        {
            get { return _WeekStart; }
            set
            {
				if ((_WeekStart == new DateTime(0) || _WeekStart != value) && WeekChanged != null)
				{
					_WeekStart = value;
					FirstDayOfWeek = _WeekStart.DayOfWeek;
					WeekChanged(this, new WeekEventArgs(value));
				}
            }
        }

		public void FireWeekStart()
		{
			WeekChanged(this, new WeekEventArgs(_WeekStart));
		}


        // The single instance allowed
        private static TrackerDetector theTrackerDetectorInstance = null;

        // Private constructor preventing creating an instance
        private TrackerDetector()
        {
        }

        // The only way to get the object's instance
        public static TrackerDetector GetTrackerDetector()
        {
            if (theTrackerDetectorInstance == null)
            {
                theTrackerDetectorInstance = new TrackerDetector();
            }
            return theTrackerDetectorInstance;
        } 
    }
}

