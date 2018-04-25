using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    /// <summary>
    /// User Control - customized combobox for selecting a Tracker.  Initialized from the database (Terminals),
    /// filtered by the Active field (MB true).
    /// This class was created by modifying UCSiteChooser (which is more complex than needed for Tracker choosing).
    /// </summary>
    public partial class UCTrackerPicker : UserControl
    {
        public UCTrackerPicker()
        {
            InitializeComponent();
        }
        public string TrackerID
        {
            get { return ((VWA4Common.VWACommon.MyListBoxItem)cbTracker.SelectedItem).ItemData.Trim(); }
            //set { SetSite(value); }  // not sure how this translates from UCSiteChooser.cs, if at all
        }
        public string TrackerName
        {
            get { return (cbTracker.Text.Trim()); }
        }
        // Build a combobox of the Trackers, with attached ID that we need for queries
		public void Init()
		{
			DataTable trackerDataTable = new DataTable();
            int i = 0;
            string sql = @"SELECT TermID, TermName, SiteID FROM Terminals WHERE Active = True";
            trackerDataTable = VWA4Common.DB.Retrieve(sql);
			cbTracker.Items.Clear();
            foreach (DataRow row in trackerDataTable.Rows)
            {
                // Put the TermName in the combobox - save the ID in the ItemData and the SiteID in Item2Data
                i = cbTracker.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(),
                    row.ItemArray[0].ToString(),row.ItemArray[2].ToString()));
            }
            // initialize to the first entry
			if (trackerDataTable.Rows.Count > 0)
			{
				cbTracker.SelectedIndex = 0;
			}
			SetTrackerChanged();
        }

        public class TrackerEventArgs : EventArgs
        {
			private string _TermID;
			private string _TermName;
			private string _SiteID;

			public string TermName
			{
				get { return _TermName; }
			}
			public string TermID
			{
				get { return _TermID; }
			}
			public string SiteID
			{
				get { return _SiteID; }
			}

            public TrackerEventArgs(string name,string key,string siteid)
            {
				_TermName = name;
                _TermID = key;
				_SiteID = siteid;
            }
        }

        public delegate void TrackerChangedEventHandler(object sender, TrackerEventArgs e);
        private TrackerChangedEventHandler trackerChanged;
        public event TrackerChangedEventHandler TrackerChanged
        {
            add { trackerChanged += value; }
            remove { trackerChanged -= value; }
        }
        public void SetTrackerChanged()
        {
            OnTrackerChanged(new TrackerEventArgs(cbTracker.Text,
				((VWA4Common.VWACommon.MyListBoxItem)cbTracker.SelectedItem).ItemData,
				((VWA4Common.VWACommon.MyListBoxItem)cbTracker.SelectedItem).Item2Data
				));
        }
        protected virtual void OnTrackerChanged(TrackerEventArgs e)
        {
            if (trackerChanged != null)
                trackerChanged(this, e);
        }

        private void cbTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // catch pressing enter key means user finished input
            if (sender != null)
                SetTrackerChanged();
        }
    }
}
