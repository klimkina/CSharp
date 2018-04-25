using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class ContainerCategory
    {
        private int id = 0;
        private int parentCatId = 0;
        private ContainerCategory parentCategory = null;
        private string name = string.Empty;
        private string spanishName = string.Empty;
        private int rank = 0;
        private string description = string.Empty;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int ParentCatId
        {
            get { return this.parentCatId; }
            set { this.parentCatId = value; }
        }
        public ContainerCategory ParentCategory
        {
            get
            {
                if (this.parentCategory == null && this.ParentCatId != 0)
                    this.parentCategory = ContainerCategoryDAO.DAO.Load(this.ParentCatId);
                return this.parentCategory;
            }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string SpanishName
        {
            get { return this.spanishName; }
            set { this.spanishName = value; }
        }
        public int Rank
        {
            get { return this.rank; }
            set { this.rank = value; }
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
                if (this.Id == 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
