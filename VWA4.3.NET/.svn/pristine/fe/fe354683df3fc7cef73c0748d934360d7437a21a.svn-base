using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class FormSeries
    {
        private int id = 0;
        private string name = string.Empty;
        private DateTime createDate = DateTime.Now;
        private DateTime modifiedDate = DateTime.Now;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
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
                if (this.Id == 0 || this.Id == -1)
                    return true;
                return false;
            }
        }
    }
}
