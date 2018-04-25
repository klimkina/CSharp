using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
    public enum AppVersionType
    {
        ReadOnly = 0,
        Manager = 5,
        SuperUser = 9
    }

    /// <summary>
    /// Application settings for use throughout the program.
    /// Globals.
    /// </summary>
    public static class AppContext
    {
        private const string ODC_CONNECTIONSTRING1 = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private const string ODC_CONNECTIONSTRING2 = @";User ID=Admin;";
 
        //******* Path name of the current database file
        private static string _DBPathName;
        public static string DBPathName
        {
            get { return AppContext._DBPathName; }
            set { 
                AppContext._DBPathName = value;
            }
        }

        //******* Current VWA4 version as installed
        private static AppVersionType _CurrentVersion;
        public static AppVersionType CurrentVersion
        {
            get { return _CurrentVersion; }
        }

        //******* The connection string for opening the database
        public static string WasteConnectionString
        {
            get
            { return ODC_CONNECTIONSTRING1 + AppContext.DBPathName + ODC_CONNECTIONSTRING2; }
        }

        //******* Last Task Explorer click - was it an image or text item?
        private static bool _TaskItemImageClicked;
        public static bool TaskItemImageClicked
        {
            get { return AppContext._TaskItemImageClicked; }
            set { AppContext._TaskItemImageClicked = value; }
        }


        //*******
        //******* Helper Methods
        //*******

		//====> removed from VWAMain.cs just after events setup
		////todo: how do we install a config file with the right application version key?
		//// todo: Load installed version information (Probably don't need this anymore)
		//VWA4Common.AppContext.SetCurrentAppVersion
		//	(VWA4.Properties.Settings.Default.ApplicationVersionKey);
		//====<
		//public static void SetCurrentAppVersion(string applicationKey)
		//{
		//    int level;
		//    string rightMostChar = applicationKey.Substring(applicationKey.Length-1, 1);
		//    if (Int32.TryParse(rightMostChar, out level))
		//    {
		//        AppContext._CurrentVersion = (AppVersionType)level;
		//    }
		//}

        private static string _CurrSheetName = "";

        public static string CurrSheetName
        {
            get { return AppContext._CurrSheetName; }
            set { AppContext._CurrSheetName = value; }
        }
/// The following is code created by Steve Severance (CSGPro)
///  It is being abandoned due to using a simpler approach of managing GlobalSettings - see GlobalSettings class

		// Steve Severance code - no longer needed since variables are initialized upon first use - see GlobalSettings class
		////Here's where we are maintaing all the global variables.

		//public class GlobalVar
		//{
		//    public string Name, Value, DefaultValue;
		//}

		//// Global settings are stored in a Dictionary
		//private static Dictionary<string, GlobalVar> GlobalSettings = new Dictionary<string, GlobalVar>();

		////******* Start Date of the currently selected week
		//private static DateTime _StartDateOfSelectedWeek;
		//public static DateTime StartDateOfSelectedWeek
		//{
		//    get { return AppContext._StartDateOfSelectedWeek; }
		//    set { AppContext._StartDateOfSelectedWeek = value; }
		//}

		//public static string GetGlobalValue(string globalName)
		//{
		//    //: return (in out var?) the "type" of the global variable
		//    //: trap and handle if var name is not in dictionary.
		//    return GlobalSettings[globalName].Value;
		//}

		//public static void SetGlobalValue(string globalName, string value)
		//{
		//    GlobalSettings[globalName].Value = value;
		//}

		//private static System.Xml.XmlTextReader _GlobalDefaultValues;

		//public static void InitAppContext()
		//{
		//    AppContext.LoadGlobalDefaults(); //load default values for global variables into mem from embedded xml file (resource)
		//    AppContext.InitGlobalVarsInDatabase(); //read global settings from db; use defaults & update db if not present
		//}
		//public static void InitGlobalVarsInDatabase()
		//{
		//    //hack: this should really be a name-value collection that is loaded from 
		//    //an embedded xml file
		//    string[] globalVarNames = new string[] { "StartDayOfWeek" };

		//    // get rid of string array of global vars -- var names should really come from xml file also.
		//    foreach (string var in globalVarNames)
		//    {


		//        GlobalVar global = new GlobalVar();
		//        global.Name = var;

		//        AppContext.GlobalSettings.Add(var, global);


		//        string value = Query.GetGlobalSetting(var); //try to get current value from db
		//        if (value == null || value == string.Empty)
		//        { //if not in db value will be null or empty
		//            //todo: find out how to read the default value from the xml file and add the code in here.
		//            if (var == "StartDayOfWeek") value = "Monday"; //hack: hardcoded this for now.
		//            Query.SaveGlobalSetting(var, value, "");
		//        }
		//        global.Value = value;
		//    }
		//}


		//public static void LoadGlobalDefaults()
		//{
		//    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
		//    System.Xml.XmlTextReader xml;
		//    try
		//    {
		//        System.IO.Stream stream = assembly.GetManifestResourceStream("VWA4Common.GlobalDefaults.xml");
		//        _GlobalDefaultValues = new System.Xml.XmlTextReader(stream);
		//    }
		//    catch (Exception ex)
		//    {
		//        System.Diagnostics.Debug.WriteLine(ex.Message);
		//    }
		//    //// find out how to read the correct value from the xml file and add the code in here.
		//    //AppContext._StartDayOfWeek = "Monday";

		//}






    }
}
