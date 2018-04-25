using System;
using System.Collections.Generic;
using System.Text;

namespace VWA4Common.DataObject
{
    public class LossCategory
    {
        private int id = 0;
        private int parentCatID = 0;
        private string name = string.Empty;
        private string spanishName = string.Empty;
        private int rank = 0;
        private string description = string.Empty;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int ParentCatID
        {
            get { return this.parentCatID; }
            set { this.parentCatID = value; }
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
            get { return (id == 0) ? true : false; }
        }
    }
}
