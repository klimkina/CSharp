using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class LossType
    {
        private string id = string.Empty;
        private int catId = 0;
        private LossCategory lossCategory = null;
        private string name = string.Empty;
        private string reportName = string.Empty;
        private string spanishName = string.Empty;
        private bool overProductionFlag = false;
        private bool trimWasteFlag = false;
        private bool handlingFlag = false;
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
        public LossCategory LossCategory
        {
            get
            {
                if (this.lossCategory == null && this.CatId != 0)
                    this.lossCategory = LossCategoryDAO.DAO.Load(this.CatId);
                return this.lossCategory;
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
        public bool OverProductionFlag
        {
            get { return this.overProductionFlag; }
            set { this.overProductionFlag = value; }
        }
        public bool TrimWasteFlag
        {
            get { return this.trimWasteFlag; }
            set { this.trimWasteFlag = value; }
        }
        public bool HandlingFlag
        {
            get { return this.handlingFlag; }
            set { this.handlingFlag = value; }
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
            get { return (id == string.Empty) ? true : false; }
        }
    }
}
