using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
	// Delegate for event handler to handle the device events 
	public delegate void CommonEventsEventHandler(Object sender, EventArgs e);
	public delegate void ShowTaskSheetEventsEventHandler(Object sender, TaskSheetEventArgs e);
	public delegate void DisplayOptionsChangedEventHandler(Object sender, EventArgs e);
	public delegate void ShowTaskListEventHandler(Object sender, EventArgs e);
	public delegate void HideTaskListEventHandler(Object sender, EventArgs e);
	public delegate void UpdateProductUIDataEventHandler(Object sender, EventArgs e);
	public delegate void ProgressCancelledEventHandler(Object sender, EventArgs e);

	public class TaskSheetEventArgs : EventArgs
	{
		public string taskkey;
		public TaskSheetEventArgs(string taskkey)
		{
			this.taskkey = taskkey;
		}
	}
	public class CommonEvents
	{
		public event CommonEventsEventHandler TaskDataChanged;
		public event ShowTaskSheetEventsEventHandler ShowTaskSheet;
		public event DisplayOptionsChangedEventHandler DisplayOptionsChanged;
		public event ShowTaskListEventHandler ShowTaskList;
		public event HideTaskListEventHandler HideTaskList;
		public event UpdateProductUIDataEventHandler UpdateProductUIData;
		public event ProgressCancelledEventHandler ProgressCancelled;

		public bool TaskExplorerInvalidate
		{
			get { return true; }
			set
			{
				if (TaskDataChanged != null)
				{
					TaskDataChanged(this, EventArgs.Empty);
				}
			}
		}
		public bool DisplayOptionsInvalidate
		{
			get { return true; }
			set
			{
				if (DisplayOptionsChanged != null)
				{
					DisplayOptionsChanged(this, EventArgs.Empty);
				}
			}
		}

		public string TaskSheetKey
		{
			set
			{
				if (ShowTaskSheet != null)
				{
					TaskSheetEventArgs eventargs = new TaskSheetEventArgs(value);
					ShowTaskSheet(this,eventargs);
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ShowTaskListControl
		{
			set
			{
				if (ShowTaskList != null)
				{
					ShowTaskList(this, EventArgs.Empty);
				}
			}
		}
		public bool HideTaskListControl
		{
			set
			{
				if (HideTaskList != null)
				{
					HideTaskList(this, EventArgs.Empty);
				}
			}
		}
		public bool UpdateProductUI
		{
			set
			{
				if (UpdateProductUIData != null)
				{
					UpdateProductUIData(this, EventArgs.Empty);
				}
			}
		}
		public bool CancelProgress
		{
			set
			{
				if (ProgressCancelled != null)
				{
					ProgressCancelled(this, EventArgs.Empty);
				}
			}
		}

	
		// The single instance allowed
		private static CommonEvents theCommonEventsInstance = null;

		// Private constructor preventing creating an instance
		private CommonEvents()
		{
		}

		// The only way to get the object's instance
		public static CommonEvents GetEvents()
		{
			if (theCommonEventsInstance == null)
			{
				theCommonEventsInstance = new CommonEvents();
			}
			return theCommonEventsInstance;
		}
	}
}
