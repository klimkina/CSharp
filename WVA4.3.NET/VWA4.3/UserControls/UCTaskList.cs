using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;

namespace UserControls
{
    public partial class UCTaskList : UserControl, IVWAUserControlBase
    {
        bool donot_updatecheck;

        VWA4Common.DBDetector dbDetector = null;
        private VWA4Common.TrackerDetector trackerDetector = null;
		private VWA4Common.CommonEvents commonEvents = null;
		Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem currentitem;
        Color labeltextcolor;
        /// <summary>
        /// Constructor
        /// </summary>
        public UCTaskList()
        {
            InitializeComponent();
			if (dbDetector == null)
			{
				dbDetector = VWA4Common.DBDetector.GetDBDetector();    // Get instance of event generator
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);  // hook up the WeekChanged event for UCTaskList
			}
			if (trackerDetector == null)
			{
				trackerDetector = VWA4Common.TrackerDetector.GetTrackerDetector();
				trackerDetector.WeekChanged += new VWA4Common.WeekDetectorEventHandler(trackerDetector_WeekChanged);
			} 
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			commonEvents.ShowTaskList += new VWA4Common.ShowTaskListEventHandler(commonEvents_ShowTaskList);
			commonEvents.HideTaskList += new VWA4Common.HideTaskListEventHandler(commonEvents_HideTaskList);
			commonEvents.UpdateProductUIData += new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			labeltextcolor = lHome.ForeColor;
		}
        /// Event Handler for WeekChanged event
        void trackerDetector_WeekChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        
        public void Init(DateTime firstDayOfWeek)
        {
            ultraExplorerBar1.GroupSettings.Style = GroupStyle.SmallImagesWithText;
			ultraExplorerBar1.ImageListSmall = ItemSmallCheckBoxes;
            //ultraExplorerBar1.GroupSettings.AppearancesSmall.Appearance.Image = 1;
			labeltextcolor = Color.FromArgb(5, 96, 192);
            currentitem = null;

            _IsActive = true;
        }

		/// <summary>
		/// Update the Task List Appearance based on current settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBarBackgroundColor;
			lTasks.BackColor = VWA4Common.GlobalSettings.ProductTaskBarBackgroundColor;
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.BackColor =
				VWA4Common.GlobalSettings.ProductMenuBackgroundColor;
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.BackColor2 =
				VWA4Common.GlobalSettings.ProductMenuBackgroundColor;
			ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance.ForeColor =
				VWA4Common.GlobalSettings.ProductTaskBarFontColor;
			ultraExplorerBar1.Appearance.BackColor =
				VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
		}	

        public int AutoRun(string param)
        {
            return 0;
        }

        private bool _IsActive = false;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public void LeaveSheet()
        {
            _IsActive = false;
        }

        /// <summary>
        /// Load up the Explorer Bar from the DB.
        /// </summary>
        public void LoadData()
        {
            string ssd = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek).Date.ToString("yyyyMMdd");
            // Get all checkmark data for this week and this site
            DataTable dtItemChecks = VWA4Common.DB.Retrieve("SELECT * FROM TaskStates WHERE (Format(WeekStartDate, 'yyyymmdd') = "
                + ssd + ") AND (SiteID=" + VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ");"
                );
            
            ultraExplorerBar1.Groups.Clear();
            // Assume the DB table is properly initialized
            //
            // Add Groups and Items (for those Groups that we find)
            //
            DataTable dtGroups = VWA4Common.DB.Retrieve("SELECT * FROM TaskItems WHERE ParentID = 0 ORDER BY Rank");
            foreach (DataRow row in dtGroups.Rows)
            {
                if (bool.Parse(row["Enabled"].ToString()))
				{
				// Add the next group
                UltraExplorerBarGroup aGroup = new UltraExplorerBarGroup();
				aGroup = ultraExplorerBar1.Groups.Add();
                aGroup.Text = row["DisplayName"].ToString();
                string sssss = row["UniqueName"].ToString();
				aGroup.Expanded = bool.Parse(row["Expanded"].ToString());
                aGroup.Key = sssss;
                int gpid = (int)row["ID"];
                // Add Items under this Group
                DataTable dtItems = VWA4Common.DB.Retrieve("SELECT * FROM TaskItems WHERE ParentID = "
                    + gpid.ToString() + " ORDER BY Rank");
                foreach (DataRow irow in dtItems.Rows)
                {
					if (bool.Parse(irow["Enabled"].ToString()))
					{ // This item is enabled - add it
						UltraExplorerBarItem anItem = new UltraExplorerBarItem();
						anItem.Text = irow["DisplayName"].ToString();
						anItem.Key = irow["UniqueName"].ToString();
						anItem.Checked = false; // initialize
						// Check DB to see if this item is checked
						foreach (DataRow icrow in dtItemChecks.Rows)
						{
							// Do we have an entry that matches the current item?
							//int icrowtest = (int)icrow["TaskID"];
							//int irowtest = (int)irow["ID"];
							if (icrow["TaskUniqueName"].ToString() == irow["UniqueName"].ToString())
							{
								// There is a task item check entry for this item
								anItem.Checked = (bool)icrow["TaskChecked"];
							}
						}
						if (anItem.Checked)
						{
							anItem.Settings.AppearancesSmall.Appearance.Image = 1;
						}
						else
						{
							anItem.Settings.AppearancesSmall.Appearance.Image = 0;
						}
						// Is this item the current task?

						aGroup.Items.Add(anItem);
					}
					else
					{ // This item is not enabled - don't add it

					}
                }
				}
			}
			this.ultraExplorerBar1.Update();
        }
        
        public void SaveData()
        { }
        
        public bool ValidateData()
        { return true; }


        public class TaskListCommandArgs
        {
            public string CommandText;
            public TaskListCommandArgs(string commandText)
            {
                this.CommandText = commandText;
            }
        }

        public delegate void TaskListCommandEventHandler(object sender, TaskListCommandArgs e);
        private TaskListCommandEventHandler taskListCommandEvent;
        public event TaskListCommandEventHandler TaskListCommandEvent
        {
            add { taskListCommandEvent += value; }
            remove { taskListCommandEvent -= value; }
        }
        protected virtual void OnTaskListCommand(TaskListCommandArgs e)
        {
            if (taskListCommandEvent != null)
                taskListCommandEvent(this, e);
        }

        
        /// ////////////////////////////////////////////////// MILA Sample /////////////////////////////////////////////////////
        public delegate void ExplorerBarEventHandler(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e);
        private ExplorerBarEventHandler explorerBar;
        public event ExplorerBarEventHandler ExplorerBar
        {
            add { explorerBar += value; }
            remove { explorerBar -= value; }
        }
        public void SetExplorerBar(Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
			if (!donot_updatecheck)
				OnExplorerBar(e);
        }
        protected virtual void OnExplorerBar(Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            if ((explorerBar != null))
                explorerBar(this, e);
        }


		///
		/// Event Routines
		/// 
		void commonEvents_ShowTaskList(object sender, EventArgs e)
		{
			donot_updatecheck = false;
			this.Visible = true;
		}
		void commonEvents_HideTaskList(object sender, EventArgs e)
		{
			donot_updatecheck = true;
			this.Visible = false;
		}
		


		/// <summary>
		/// Handle expanding and collapsing of Group items by updating database with current state for that item.
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanded(object sender, GroupEventArgs e)
		{
			string sql = "UPDATE TaskItems SET Expanded=" + e.Group.Expanded.ToString()
					+ " WHERE UniqueName='" + e.Group.Key + "';";
			VWA4Common.DB.Update(sql);
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			if (sender != null)
			{
				SetExplorerBar(e);

				foreach (UltraExplorerBarGroup ugroup in ultraExplorerBar1.Groups)
				{
					foreach (UltraExplorerBarItem uitem in ugroup.Items)
					{
						if (uitem.Key == e.Item.Key)
						{
							if (donot_updatecheck) return;
							// this is the item we want
							uitem.Active = true;
						}
						else
						{
							if (donot_updatecheck) return;
							uitem.Active = false;
						}
					}
				}
			}
		}

        /// <summary>
        /// Code (from Infragistics) to show how to see if the item or the image was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_MouseDown(object sender, MouseEventArgs e)
        {
            // return;
            Infragistics.Win.UIElement lastElementEntered = ultraExplorerBar1.UIElement.LastElementEntered;
            Infragistics.Win.ImageUIElement imgUIElement;
            if (lastElementEntered is Infragistics.Win.ImageUIElement)
            {
                imgUIElement = (Infragistics.Win.ImageUIElement)lastElementEntered;
            }
            else
            {
                imgUIElement = (Infragistics.Win.ImageUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.ImageUIElement));
            }
            // The actual subsequent Click event will use this property value
            // to determine how to act.
            if (imgUIElement == null)
            {
                //MessageBox.Show("Item Clicked");
                VWA4Common.AppContext.TaskItemImageClicked = false;
            }
            else
            {
                //MessageBox.Show("Image Clicked");
                VWA4Common.AppContext.TaskItemImageClicked = true;

                //this.ultraExplorerBar1.Groups[0].Items[0].Settings.AppearancesSmall.Appearance.Image =
                //    Image.FromFile(Application.StartupPath + "./Resources/arrow_black.gif");
            }
         }

        private void lTasks_Click(object sender, EventArgs e)
        {
            this.OnTaskListCommand(new TaskListCommandArgs("maindashboard"));
        }

		private void anyLabel_MouseDown(object sender, MouseEventArgs e)
		{
			Label lbl = (Label)sender;
			lbl.ForeColor = Color.Red;
		}

		private void anyLabel_MouseUp(object sender, MouseEventArgs e)
		{
			Label lbl = (Label)sender;
			lbl.ForeColor = labeltextcolor;
		}

		//private void lAnyNavLabel_MouseEnter(object sender, EventArgs e)
		//{

		//    lShowAllTasks.BorderStyle = BorderStyle.None;
		//    lHideAllTasks.BorderStyle = BorderStyle.None;

		//    Label lbl = (Label)sender;
		//    lbl.BorderStyle = BorderStyle.FixedSingle;
		//    resetlabelborders();
		//}

		//private void lAnyNavLabel_MouseLeave(object sender, EventArgs e)
		//{
		//    Label lbl = (Label)sender;
		//    lbl.BorderStyle = BorderStyle.None;
		//    resetlabelborders();
		//    resetlabelcolors();
		//}

		//private void resetlabelborders()
		//{
		//    lHome.BorderStyle = BorderStyle.None;
		//}
	
		private void resetlabelcolors()
		{
			lHome.ForeColor = labeltextcolor;
		}

		private void ShowAllTasks_Click(object sender, EventArgs e)
		{
			foreach (UltraExplorerBarGroup group in ultraExplorerBar1.Groups)
			{
				group.Expanded = true;
			}
		}

		private void HideAllTasks_Click(object sender, EventArgs e)
		{
			foreach (UltraExplorerBarGroup group in ultraExplorerBar1.Groups)
			{
				group.Expanded = false;
			}
		}

		private void lHome_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

    }

    //******************************************************
    // Example of creating event with parameters
    //***********
    //  
    //public class HideEventArgs : EventArgs
    //    {
    //        private int height;
    //        public int Height
    //        {
    //            get { return height; }
    //            set { height = value; }
    //        }
    //    }
    //public delegate void HideEventHandler(object sender, HideEventArgs e);
    //private HideEventHandler hideParams;
    //public event HideEventHandler HideParams
    //{
    //    add { hideParams += value; }
    //    remove { hideParams -= value; }
    //}
    //public void SetHide(int height)
    //{
    //    HideEventArgs e = new HideEventArgs();
    //    e.Height = height;
    //    OnHide(e);
    //}
    //protected virtual void OnHide(HideEventArgs e)
    //{
    //    if (hideParams != null)
    //        hideParams(this, e);
    //}
    //private void hideParametersToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    if (shown)
    //    {
    //       SetHide(16);
    //    }
    //    else
    //    {
    //        SetHide(214);
    //    }
    //}
    //******************************************************
    //******************************************************


    //******************************************************
    //******************************************************
    //
    // Example of how to create an event ViewReport that has no parameters
    //
    //public delegate void ViewReportEventHandler(object sender, EventArgs e);
    //        private ViewReportEventHandler viewReport;
    //        public event ViewReportEventHandler ViewReport
    //        {
    //            add { viewReport += value; }
    //            remove { viewReport -= value; }
    //        }
    //        public void SetViewReport()
    //        {
    //            OnViewReport(EventArgs.Empty);
    //        }
    //        protected virtual void OnViewReport(EventArgs e)
    //        {
    //            if (viewReport != null)
    //                viewReport(this, e);
    //        }
    //        private void btnViewReport_Click(object sender, EventArgs e)
    //        {
    //            if (sender != null)
    //                SetViewReport();
    //    
    //******************************************************
    //******************************************************

}

