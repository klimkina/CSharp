using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
	public class GlobalClasses
	{
		public class Tag
		{
			public int TagID;
			public string TagName;
			public string TagDescription;
		}
		public class DataEntryTemplate
		{
			public int DETID;					// Primary Key of the record
			public string DETName;				// Name of Data Entry Template (FormSet)
			public string DETDescription;		// Description of Data Entry Template (FormSet)
			public string FormSet_displayorder;	// Comma-delimited list of fields to show in order after Timestamp.  
												//	Can consist of one each from following list:
												//•	“Wastemode”
												//•	“User”
												//•	“Food”
												//•	“Loss”
												//•	“Container”
												//•	“Station”
												//•	“Disposition”
												//•	“Daypart”
												//•	“Eventorder”
			public int FormSet_BackColor;	// Setting of backcolor for the form set enclosing Formset panel.
			/// 
			public string FormSet_Wastemode;	// Setting of Waste mode for Form set:
												//•	“Pre”
												//•	“Post”
												//•	“Int”
			public int FormSet_Wastemode_BackColor;		//
			public int FormSet_Wastemode_ForeColor;		//
			public string FormSet_UserType;	// Setting of User type (via TypeID key) for Form set.
			public string FormSet_UserTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_UserType_BackColor;	// Setting of the backcolor of the User type field panel in the Form set.
			public int FormSet_UserType_ForeColor;	// Setting of the fontcolor of the User type field panel in the Form set.
			public string FormSet_FoodType;	// Setting of Food type (via TypeID key) for Form set.
			public string FormSet_FoodTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_FoodType_BackColor;	// Setting of the backcolor of the Food type field panel in the Form set.
			public int FormSet_FoodType_ForeColor;	// Setting of the fontcolor of the Food type field panel in the Form set.
			public string FormSet_LossType;	// Setting of Loss type (via TypeID key) for Form set.
			public string FormSet_LossTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_LossType_BackColor;	// Setting of the backcolor of the Loss type field panel in the Form set.
			public int FormSet_LossType_ForeColor;	// Setting of the fontcolor of the Loss type field panel in the Form set.
			public string FormSet_ContainerType;	// Setting of Container type (via TypeID key) for Form set.
			public string FormSet_ContainerTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_ContainerType_BackColor;	// Setting of the backcolor of the Container type field panel in the Form set.
			public int FormSet_ContainerType_ForeColor;	// Setting of the fontcolor of the Container type field panel in the Form set.
			public string FormSet_StationType;	// Setting of Station type (via TypeID key) for Form set.
			public string FormSet_StationTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_StationType_BackColor;	// Setting of the backcolor of the Station type field panel in the Form set.
			public int FormSet_StationType_ForeColor;	// Setting of the fontcolor of the Station type field panel in the Form set.
			public string FormSet_DispositionType;	// Setting of User type (via TypeID key) for Form set.
			public string FormSet_DispositionTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_DispositionType_BackColor;	// Setting of the backcolor of the Disposition type field panel in the Form set.
			public int FormSet_DispositionType_ForeColor;	// Setting of the fontcolor of the Disposition type field panel in the Form set.
			public string FormSet_DaypartType;	// Setting of Daypart type (via TypeID key) for Form set.
			public string FormSet_DaypartTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_DaypartType_BackColor;	// Setting of the backcolor of the Daypart type field panel in the Form set.
			public int FormSet_DaypartType_ForeColor;	// Setting of the fontcolor of the Daypart type field panel in the Form set.
			public string FormSet_EventOrderType;	// Setting of Eventorder type (via TypeID key) for Form set.
			public string FormSet_EventOrderTypeName;	// TypeName that corresponds to TypeID
			public int FormSet_EventOrderType_BackColor;	// Setting of the backcolor of the Eventorder type field panel in the Form set.
			public int FormSet_EventOrderType_ForeColor;	// Setting of the fontcolor of the Eventorder type field panel in the Form set.
			///
			public string Transaction_displayorder;	// Comma-delimited list of fields to show in order for Transaction  
												//	in order after Quantity.  Can consist of one each from following list:
												//•	“Wastemode”
												//•	“Food”
												//•	“Loss”
												//•	“Container”
												//•	“Station”
												//•	“Disposition”
												//•	“Daypart”
												//•	“Eventorder”
			public int Transaction_BackColor;	// Setting of backcolor for the form set enclosing  Transaction  panel. 
			public string Quantity_CTDefaultMode;	// Default Quantity Mode for Current Transaction:
												//•	“Wt” => Weight mode
												//•	“Each” => Each mode
												//•	“Vol” => Volume mode
												//•	“Prev” => Use mode from previous transaction
			public int Quantity_BackColor;		// Setting of the backcolor of the Quantity field panel in the Transaction UI.
			public int Quantity_ForeColor;		// Setting of the fontcolor of the Quantity field panel in the Transaction UI.
			public bool UserNotes_TShow;		// Show User Notes in Transaction?
			public int UserNotes_BackColor;		// Setting of the backcolor of the User Notes field panel in the Transaction UI.
			public int UserNotes_ForeColor;		// Setting of the fontcolor of the User Notes field panel in the Transaction UI.
			///
			public string Timestamp_NTPrefill;	// 
			public string Timestamp_TFormat;	//
			public int Timestamp_BackColor;		//
			public int Timestamp_ForeColor;		//
			public string Wastemode_CTDefaultMode;	// Default waste mode (pre/post/intermediate) for Current Transaction:
												//•	“Auto” => Pre-fill from Tracker Default 
												//•	“Prev” => Pre-fill from Previous Transaction
												//•	“Form” => Pre-fill from FormSet mode
												//•	“Null” => Pre-fill with null/empty
			public int Wastemode_BackColor;	// Setting of the backcolor of the Wastemode field panel in the Transaction UI.
			public int Wastemode_ForeColor;	// Setting of the fontcolor of the Wastemode field panel in the Transaction UI.
			public string User_CTDefaultMode;	// Default  User for Current Transaction:
												//•	“Prev” => Pre-fill from Previous Transaction
												//•	“Sess” => Pre-fill from Session User type
												//•	“Form” => Pre-fill from FormSet type
												//•	“Null” => Pre-fill with null/empty
			public int UserType_BackColor;	// Setting of the backcolor of the User type field panel in the Transaction UI.
			public int UserType_ForeColor;	// Setting of the fontcolor of the User type field panel in the Transaction UI.
 
			public string FoodType_CTDefaultMode;	// Default  FoodType for Current Transaction:
													//•	“Prev” => Pre-fill from Previous Transaction
													//•	“Form” => Pre-fill from FormSet FoodType
													//•	“Null” => Pre-fill with null/empty
			public int FoodType_BackColor;	// Setting of the backcolor of the Food type field panel in the Transaction UI.
			public int FoodType_ForeColor;	// Setting of the fontcolor of the Food type field panel in the Transaction UI.
			
			public string LossType_CTDefaultMode;	// Default  LossType for Current Transaction:
													//•	“Prev” => Pre-fill from Previous Transaction
													//•	“Form” => Pre-fill from FormSet FoodType
													//•	“Null” => Pre-fill with null/empty
			public int LossType_BackColor;	// Setting of the backcolor of the Loss type field panel in the Transaction UI.
			public int LossType_ForeColor;	// Setting of the fontcolor of the Loss type field panel in the Transaction UI.

			public string ContainerType_CTDefaultMode;	// Default  ContainerType for Current Transaction:
														//•	“Prev” => Pre-fill from Previous Transaction
														//•	“Form” => Pre-fill from FormSet ContainerType
														//•	“Null” => Pre-fill with null/empty
			public int ContainerType_BackColor;	// Setting of the backcolor of the Container type field panel in the Transaction UI.
			public int ContainerType_ForeColor;	// Setting of the fontcolor of the Container type field panel in the Transaction UI.
			
			public string StationType_CTDefaultMode;	// Default StationType for Current Transaction:
														//•	“Auto” => Pre-fill from Tracker Default 
														//•	“Prev” => Pre-fill from Previous Transaction
														//•	“Form” => Pre-fill from FormSet StationType
														//•	“Null” => Pre-fill with null/empty
			public int StationType_BackColor;	// Setting of the backcolor of the Station type field panel in the Transaction UI.
			public int StationType_ForeColor;	// Setting of the fon tcolor of the Station type field panel in the Transaction UI.

			public string DispositionType_CTDefaultMode;	// Default  DispositionType for Current Transaction:
														//•	“Auto” => Pre-fill from Tracker Default 
														//•	“Prev” => Pre-fill from Previous Transaction
														//•	“Form” => Pre-fill from FormSet DispositionType
														//•	“Null” => Pre-fill with null/empty			public int ContainerType_BackColor;	// Setting of the backcolor of the Container type field panel in the Transaction UI.
			public int DispositionType_BackColor;	// Setting of the Backcolor of the Disposition type field panel in the Transaction UI.
			public int DispositionType_ForeColor;	// Setting of the font color of the Disposition type field panel in the Transaction UI.

			public string DaypartType_CTDefaultMode;	// Default  DaypartType for Current Transaction:
														//•	“Auto” => Pre-fill from Tracker Default 
														//•	“Prev” => Pre-fill from Previous Transaction
														//•	“Form” => Pre-fill from FormSet DispositionType
														//•	“Null” => Pre-fill with null/empty			
			public int DaypartType_BackColor;	// Setting of the backcolor of the Daypart type field panel in the Transaction UI.
			public int DaypartType_ForeColor;	// Setting of the font color of the Daypart type field panel in the Transaction UI.
			
			public string EventOrderType_CTDefaultMode;	// Default  DaypartType for Current Transaction:
														//•	“Prev” => Pre-fill from Previous Transaction
														//•	“Form” => Pre-fill from FormSet DispositionType
														//•	“Null” => Pre-fill with null/empty			
			public int EventOrderType_BackColor;	// Setting of the backcolor of the EventOrder type field panel in the Transaction UI.
			public int EventOrderType_ForeColor;	// Setting of the font color of the EventOrder type field panel in the Transaction UI.

		}
		public class DataEntrySession
		{
			public int TransKey;			// PK of this session's Transfer record.
			public DateTime StartDateTime;	// Same as Timestamp
			public DateTime Timestamp;		// Same as StartDateTime
			public string TermID;			// Tracker associated with this session ("list")
			public int SiteID;				// SiteID of the waste data
			public int TypeCatalogID;		// TypeCatalogID for the types in this waste data (0 = master)
			public bool IsPrior;			// Always false for manual transactions - only for Tracker transfers
			public DateTime SessionEnd;		// Date/time when the session was last ended
			public string UserTypeID;		// User who conducted this data entry session
			public string SessionNotes;		// Notes that the User added to describe this session
			public bool ManualDESession;	// Is this a manual data entry Session?
			public DateTime DataFromDate;	// Date this session's data is for

			public string TermName;			// Name of Tracker/list
		}
		
		/// <summary>
		/// Stores empirical data regarding a VWA4 database.  Typically these values are read from a database
		/// for comparison against the maximum limits allowed by a license file.
		/// </summary>
		public class VWDBStats
		{
			public string DBVersion;		// Database version string 
			public int NumSites;			// Number of sites
			public int NumTrackers;			// Number of Trackers
			public int NumFoodTypes;		// Number of Food Types
			public int NumLossTypes;		// Number of Loss Types
			public int NumUserTypes;		// Number of User Types
			public int NumDETs;				// Number of Data Entry Templates
			public int NumReports;			// Number of Reports
			public bool FoodWasteClassUsed;	// Food Waste Class is Used
			public bool NonFoodWasteClassUsed;	// Non-Food Waste Class is Used
		}

	}
}
