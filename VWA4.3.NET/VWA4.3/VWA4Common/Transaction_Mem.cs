using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common
{
	public class Transaction_Mem
	{

		///
		/// Transaction In-memory class
		/// 
		public int ID;
		public int TransKey;
		public DateTime Timestamp;
		public int IsPreconsumer;
		public decimal Weight;
		public decimal WasteCost;
		public string FoodTypeID;
		public decimal FoodTypeCost;
		public decimal FoodTypeDiscount;
		public string LossTypeID;
		public string ContainerTypeID;
		public decimal ContainerWeight;
		public decimal ContainerCost;
		public string StationTypeID;
		public string DispositionTypeID;
		public string DaypartTypeID;
		public string BEOTypeID;
		public string UserTypeID;
		public string UserQuestion;
		public int Nitems;
		public bool IsManualInput;
		public int IsMemorized;
		public string UnitUniqueName;
		public int ProducedID;
		public decimal UnitaryItemWeight;
		public decimal WasteAmountUserEntry;
		public string UnitsDisplayName;
		public DateTime StartTimestamp;
		public int DETID;
		public DateTime SaveTimestamp;
		public string QuantityString_DE;
		public int EachFormatID_DE;
		// Other useful fields
		public GlobalClasses.DataEntryTemplate DET;
		public string UserTypeName;
		public string FoodTypeName;
		public decimal FoodTypeVolumeWeight;
		public decimal FoodTypeVolumeUnits;
		public int FoodTypeVolumeUnitType;
		public string FoodTypeWasteClass;
		public string LossTypeName;
		public bool LossTypeOverproductionFlag;
		public bool LossTypeTrimWasteFlag;
		public bool LossTypeHandlingFlag;
		public string ContainerTypeName;
		public decimal ContainerTypeVolume;
		public int ContainerTypeVolumeUnitType;
		public string StationTypeName;
		public string DispositionTypeName;
		public string DaypartTypeName;
		public string BEOTypeName;
		public string BEOTypeClientName;
		public int BEOTypeGuestCount;
		public DateTime BEOTypeEventDate;
		public string BEOTypeBEONumber;
		public decimal BEOTypeMRatio;
        /// Misc stored info
		/// 
		public decimal dTotalWasteCost;	// Food waste cost + container waste cost
		public decimal dDiscount;		// Discount used for this transaction
		public decimal dTransactionWt;	// Total waste weight - food + containers
		public decimal dTotalFoodWeight; // Weight of food only
		public decimal dTotalFoodCost;	// Cost of food waste only
		public decimal dTotalContainerWeight; // Weight of food only
		public decimal dTotalContainerCost;	// Cost of food waste only
	}
}
