using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class Site
    {
        private int id = 0;
        private string licensedSite = string.Empty;
        private int typeCatalogId = 0;
        private int customer = 0;
        private int businessUnit = 0;
        private int region = 0;
        private int district = 0;
        private int ltGroup = 0;
        private DateTime programStartDate = DateTime.Now;
        private DateTime startOfValidData = DateTime.Now;
        private double volumeAdjust = 0;
        private bool active = false;
        private DateTime modifiedDate = DateTime.Now;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string LicensedSite
        {
            get { return this.licensedSite; }
            set { this.licensedSite = value; }
        }
        public int TypeCatalogId
        {
            get { return this.typeCatalogId; }
            set { this.typeCatalogId = value; }
        }
        public int Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }
        public int BusinessUnit
        {
            get { return this.businessUnit; }
            set { this.businessUnit = value; }
        }
        public int Region
        {
            get { return this.region; }
            set { this.region = value; }
        }
        public int District
        {
            get { return this.district; }
            set { this.district = value; }
        }
        public int LTGroup
        {
            get { return this.ltGroup; }
            set { this.ltGroup = value; }
        }
        public DateTime ProgramStartDate
        {
            get { return this.programStartDate; }
            set { this.programStartDate = value; }
        }
        public DateTime StartOfValidData
        {
            get { return this.startOfValidData; }
            set { this.startOfValidData = value; }
        }
        public double VolumeAdjust
        {
            get { return this.volumeAdjust; }
            set { this.volumeAdjust = value; }
        }
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }
        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }
        public bool IsNew
        {
            get
            {
                if (this.Id == 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
