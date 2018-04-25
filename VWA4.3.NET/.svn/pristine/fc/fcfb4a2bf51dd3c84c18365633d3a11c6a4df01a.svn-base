using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class ContainerType
    {
        private string id = string.Empty;
        private int catId = 0;
        private ContainerCategory containerCategory = null;
        private string name = string.Empty;
        private string reportName = string.Empty;
        private string spanishName = string.Empty;
        private double tareWeight = 0;
        private double cost = 0.00;
        private double volume = 0;
        private int volumeUnitType = 0;
        private UnitsVolume unitsVolume = null;
        private int rank = 0;
        private bool enabled = false;
        private DateTime modifiedDate = DateTime.Now;
        private string description = string.Empty;

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
        public ContainerCategory ContainerCategory
        {
            get
            {
                if (this.containerCategory == null && this.CatId != 0)
                {
                    this.containerCategory = ContainerCategoryDAO.DAO.Load(this.CatId);
                }
                return this.containerCategory;
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
        public double TareWeight
        {
            get { return this.tareWeight; }
            set { this.tareWeight = value; }
        }
        public double Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }
        public double Volume
        {
            get { return this.volume; }
            set { this.volume = value; }
        }
        public int VolumeUnitType
        {
            get { return this.volumeUnitType; }
            set { this.volumeUnitType = value; }
        }
        public UnitsVolume UnitsVolume
        {
            get
            {
                if (this.unitsVolume == null && this.VolumeUnitType != 0)
                    this.unitsVolume = UnitsVolumeDAO.DAO.Load(this.VolumeUnitType);
                return this.unitsVolume;
            }
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
        public bool IsNew
        {
            get
            {
                if (this.Id.Equals(string.Empty))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
