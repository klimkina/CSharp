using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class FoodType
    {
        private string id = string.Empty;
        private int catId = 0;
        private FoodCategory foodCategory = null;        
        private string name = string.Empty;
        private string reportName = string.Empty;
        private string spanishName = string.Empty;
        private double cost = 0.00;
        private int rank = 0;
        private bool enabled = false;
        private DateTime modifiedDate = DateTime.Now;
        private string description = string.Empty;
        private int spareProperty1 = 0;
        private int spareProperty2 = 0;
        private int spareProperty3 = 0;
        private int volumeWeight = 0;
        private int volumeUnits = 0;
        private int volumeUnitType = 0;
        private string wasteClass = string.Empty;

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int CatId
        {
            get { return this.catId; }
            set { this.catId = value; }
        }
        public FoodCategory FoodCategory
        {
            get
            {
                if (this.foodCategory == null && this.CatId != 0)
                    this.foodCategory = FoodCategoryDAO.DAO.Load(this.CatId);
                return this.foodCategory;
            }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string ReportName
        {
            get { return this.reportName; }
            set { this.reportName = value; }
        }
        public string SpanishName
        {
            get { return this.spanishName; }
            set { this.spanishName = value; }
        }
        public double Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }
        public int Rank
        {
            get { return this.rank; }
            set { this.rank = value; }
        }
        public bool Enabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }
        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public int SpareProperty1
        {
            get { return this.spareProperty1; }
            set { this.spareProperty1 = value; }
        }
        public int SpareProperty2
        {
            get { return this.spareProperty2; }
            set { this.spareProperty2 = value; }
        }
        public int SpareProperty3
        {
            get { return this.spareProperty3; }
            set { this.spareProperty3 = value; }
        }
        public int VolumeWeight
        {
            get { return this.volumeWeight; }
            set { this.volumeWeight = value; }
        }
        public int VolumeUnits
        {
            get { return this.volumeUnits; }
            set { this.volumeUnits = value; }
        }
        public int VolumeUnitType
        {
            get { return this.volumeUnitType; }
            set { this.volumeUnitType = value; }
        }
        public string WasteClass
        {
            get { return this.wasteClass; }
            set { this.wasteClass = value; }
        }
        public bool IsNew
        {
            get { return (id == string.Empty) ? true : false; }
        }
    }
}
