using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace VWA4Common
{
    public class Query
    {

        /// <summary>
        /// Get a Global Setting from the database (GlobalVars table).
        /// </summary>
        /// <param name="var">Name of the variable to retrieve.</param>
		/// <param name="type">SiteID of Site that corresponds to this variable (0 = All Sites).</param>
		/// <returns>Value of variable, set from database.  Empty string means variable doesn't exist.</returns>
		/// 
		
		private static KeyValuePair<string, string>[] myKvP = {
		new KeyValuePair<string,string>("VWA4DelphiFileName", "VWA4DD.exe"),
		new KeyValuePair<string,string>("AdvancedFiltersOn", "true"),
		new KeyValuePair<string,string>("FirstDayOfWeek", "Monday"),
		new KeyValuePair<string,string>("PrimaryUserName", "(Primary User Name)"),
		new KeyValuePair<string,string>("PrimaryUserEmail", "(Primary User Email)"),
		new KeyValuePair<string,string>("BaselineWasteMethod", "Computed"),
		new KeyValuePair<string,string>("BaselineComputeMethod", "Average"),
		new KeyValuePair<string,string>("CycleTime", "1"),
		new KeyValuePair<string,string>("ShowEmptyReports", "true"),
		new KeyValuePair<string,string>("BaselineNumberofWeeks", "1"),
		new KeyValuePair<string,string>("BaselineWeeklyWasteCost_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineWeeklyWasteTrans_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyActualFoodCost_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyBudgetedFoodCost_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyActualFoodRevenue_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyBudgetedFoodRevenue_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyBudgetedMealCount_Stipulated", ""),
		new KeyValuePair<string,string>("BaselineMonthlyActualMealCount_Stipulated", ""),
		new KeyValuePair<string,string>("LogoUpperLeft", ""),
		new KeyValuePair<string,string>("LogoLowerRight", ""),
		new KeyValuePair<string,string>("StartDateOfSelectedWeek", ""),
		new KeyValuePair<string,string>("ActiveSyncTrackerTransfersOn", "false"),
		new KeyValuePair<string,string>("ActiveSyncTrackerTransferFolder", "\\FlashFX Disk\\VWT4Transfers"),
		new KeyValuePair<string,string>("SessionTracker_TermID", ""),
		new KeyValuePair<string,string>("SessionTracker_TermName", ""),
		new KeyValuePair<string,string>("SessStartDateTime", "")};

		public static Hashtable _ConstSettings = new Hashtable();

		static Query()
		{
			foreach (KeyValuePair<string, string> pair in myKvP)
				_ConstSettings.Add(pair.Key, pair.Value);
		}

        public static string GetGlobalSetting(string var, int siteid)
        {

			string sql = "SELECT GVValue FROM GlobalVars WHERE GVName = '" + var + "'"
				+ " AND SiteID = " + siteid.ToString();
				;

            DataTable dt = VWA4Common.DB.Retrieve(sql);
            if (dt.Rows.Count <= 0) //try to get default value for all sites
            {
				sql = "SELECT GVValue FROM GlobalVars WHERE GVName = '" + var + "'"
				+ " AND SiteID = 0";

				dt = VWA4Common.DB.Retrieve(sql);
            }
			if (dt.Rows.Count <= 0)
			{
				if (_ConstSettings[var] != null)
					return _ConstSettings[var].ToString();
				return string.Empty;
			}
            else
            {
                DataRow dr = dt.Rows[0];
                return dr["GVValue"].ToString();
                //return dt.Rows[0]["GVValue"].ToString(); //same as above 2 lines, but on one line.
            }
        }
        /// <summary>
        /// Save Global Setting to the database (GlobalVars table).
        /// </summary>
        /// <param name="var">Name of variable to save.</param>
        /// <param name="value">Value to set variable to.</param>
		/// <param name="type">Type of this variable.</param>
		/// <param name="type">SiteID of Site that corresponds to this variable (0 = All Sites).</param>
		public static void SaveGlobalSetting(string var, string value, string type, int siteid)
        {
            // do a select count(*) to see if global is already in table.
            //  if not, add it (insert statement)
            //  if so, update it.
            string sql = "SELECT * FROM GlobalVars WHERE GVName = '" + var + "'"
				+ " AND SiteID = " + siteid.ToString();
				;
			DataTable dt = DB.Retrieve(sql);
            if (dt.Rows.Count <= 0)
            { // No global variable exists in DB yet
                // insert a new global with the name
                sql = "INSERT INTO GlobalVars (GVName, GVValue, GVType, SiteID) VALUES('"
                    + var + "', '" + value + "', '" + type + "', " + siteid.ToString() + ")";
                DB.Insert(sql);
            }
            else
            { // global variable exists - update it
                sql = "UPDATE GlobalVars SET GVValue = '" + value
                    + "' WHERE GVName = '" + var + "'"
					+ " AND SiteID = " + siteid.ToString();
					;
				DB.Update(sql);
            }
        }
		/// <summary>
		/// Get the datetime of the newest weight record in Weights table.
		/// </summary>
		/// <returns></returns>
		public static DateTime GetNewestWeightDataDateTime()
		{
			string sql = "SELECT max(Timestamp) as  mostrecentts, count(*) as rownumber FROM Weights";
			DataTable dt = DB.Retrieve(sql);
			if (dt.Rows.Count > 0 && (int)dt.Rows[0]["rownumber"] > 0)
			{ // Found a record
				DateTime recent = DateTime.Parse(dt.Rows[0]["mostrecentts"].ToString());
				return new DateTime(recent.Year, recent.Month, recent.Day, 0, 0, 0, 0);// always set to the beginning of the day
			}
			else
			{ // Didn't find a record - return now
				return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);// always set to the beginning of the day
			}

		}
		/// <summary>
		/// Get the datetime of the oldest weight record in Weights table.
		/// </summary>
		/// <returns></returns>
		public static DateTime GetEarliestWeightDataDateTime()
		{
			string sql = "SELECT min(Timestamp) as  earliestts, count(*) as rownumber FROM Weights";
			DataTable dt = DB.Retrieve(sql);
			if (dt.Rows.Count > 0 && (int)dt.Rows[0]["rownumber"] > 0)
			{ // Found a record
				DateTime recent = DateTime.Parse(dt.Rows[0]["earliestts"].ToString());
				return new DateTime(recent.Year, recent.Month, recent.Day, 0, 0, 0, 0);// always set to the beginning of the day
			}
			else
			{ // Didn't find a record - return now
				return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);// always set to the beginning of the day
			}

		}
	}
}
