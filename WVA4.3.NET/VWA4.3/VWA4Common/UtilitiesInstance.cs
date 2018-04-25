using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VWA4Common
{
	public class UtilitiesInstance
	{
		private VWA4Common.CommonEvents commonEvents = null;

		public UtilitiesInstance()
		{
			commonEvents = CommonEvents.GetEvents();
		}
		public void setTaskCheck(DateTime weekstartdate, bool donestate, string taskuniquename)
		{
			// Look for a row that matches weekstart and current siteid	
			string wsdt = weekstartdate.Date.ToString("yyyyMMdd");
            string sql = "SELECT * FROM TaskStates ts LEFT  JOIN TaskItems ti ON (ti.UniqueName = ts.TaskUniqueName) " +
                        " WHERE (ts.TaskUniqueName = '" + taskuniquename + "') AND (Format(ts.WeekStartDate, 'yyyymmdd') = " + wsdt + ");";
			DataTable dtItemState = VWA4Common.DB.Retrieve(sql);
			if (dtItemState.Rows.Count == 0)
			{
				/// No rows found - this means that we need to insert a task state row
				// Add an entry into the database
				sql = "INSERT INTO TaskStates (TaskChecked, WeekStartDate, TaskUniqueName, SiteID) VALUES ("
					+ donestate.ToString() + ","
					+ "#" + DateToString(weekstartdate) + "#, '"
					+ taskuniquename + "', " + VWA4Common.GlobalSettings.CurrentSiteID.ToString() + ");";
				VWA4Common.DB.Insert(sql);
			}
			else
			{
				/// A row was found - if checkstate is different, then change it and update the database
				DataRow dri = dtItemState.Rows[0];
				int tsid = (int)dri["ts.ID"];
				if ((bool)dri["TaskChecked"] != donestate)
				{
					// Task is different - update the entry
					sql = "UPDATE TaskStates SET TaskChecked = " + donestate.ToString()
					+ " WHERE ID = " + tsid.ToString() + ";";
					VWA4Common.DB.Update(sql);
				}
				else
				{
					// no DB update is needed
				}

			}

			// Update the Task Control
			updateTaskControl();
		}

		private void updateTaskControl()
		{
			commonEvents.TaskExplorerInvalidate = true; // fire (cause) the event
		}

		public string DateToString(DateTime date)
		{
			return date.ToString("yyyy/MM/dd HH:mm:ss");
		}

	}
}
