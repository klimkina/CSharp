using System;
using System.Collections.Generic;
using System.Text;

namespace UserControls
{
    public enum TaskSheetNames
    {
        Dashboard,
        ViewWaste,
        ImportWaste,
        ManageRecurringTransactions,
        ReviewReports,
        ManageReports,
		BaselineMgr,
        PrintSWAT,
        PrintPreShift,
        WeeklyReports,
		EnterFinancials,
		EnterSWATMinutes,
		AddUsers,
        RemoveUsers,
        CustomReports, //mila added
        StoredReports,
		TransferConfig,
		ManagePreferences,
		DatabaseInfo,
		EnterWasteData,
		ManageFoodCostAdjustments,
		ManageEventClients,
		ManageEventOrders,
		SetReportOptions,
		SetDisplayOptions,
        ManageLogForms,
		EnterWasteLogs,
		ManageDETemplates,
		ManageEachFormats,
		ManageTags,
		ManageGoals
	}

    public static class TaskSheets
    {
        //private static Dictionary<string, UserControls.IWVAUserControlBase> sheets;
		private static Dictionary<TaskSheetNames, UserControls.IVWAUserControlBase> sheets;
		private static Dictionary<TaskSheetNames, string> uniqueNames;
		private static Dictionary<TaskSheetNames, string> displayNames;

        static TaskSheets()
        {
			sheets = new Dictionary<TaskSheetNames, UserControls.IVWAUserControlBase>();
			uniqueNames = new Dictionary<TaskSheetNames, string>();
			displayNames = new Dictionary<TaskSheetNames, string>();
		}

		public static UserControls.IVWAUserControlBase GetTaskSheet(TaskSheetNames sheetName)
		{
			if (TaskSheets.sheets.ContainsKey(sheetName))
			{
				return TaskSheets.sheets[sheetName];
			}
			else
			{
				throw new Exception("The specified task sheet name did not exist in the collection.");
			}
		}

		public static string GetTaskSheetUniqueName(TaskSheetNames sheetName)
		{
			if (uniqueNames.ContainsKey(sheetName))
			{
				return uniqueNames[sheetName];
			}
			else
			{
				throw new Exception("The specified task sheet name did not exist in the collection.");
			}
		}
		
		public static string GetTaskSheetDisplayName(TaskSheetNames sheetName)
		{
			if (uniqueNames.ContainsKey(sheetName))
			{
				return displayNames[sheetName];
			}
			else
			{
				throw new Exception("The specified task sheet name did not exist in the collection.");
			}
		}

		public static void AddTaskSheet(TaskSheetNames sheetName, UserControls.IVWAUserControlBase sheet, 
			string uniqueName, string defaultdisplayname)
        {
            TaskSheets.sheets.Add(sheetName, sheet);
			uniqueNames.Add(sheetName, uniqueName);
			displayNames.Add(sheetName, defaultdisplayname);
        }
        
    }
}
