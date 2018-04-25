using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class Tag
    {
        private int _ID = 0;
		private string _TagName = string.Empty;
		private string _TagDescription = string.Empty;

        public int ID
        {
			get { return this._ID; }
			set { this._ID = value; }
        }
        public string TagName
        {
            get { return this._TagName; }
			set { this._TagName = value; }
        }
        public string TagDescription
        {
			get { return this._TagDescription; }
			set { this._TagDescription = value; }
        }
 
        public bool IsNew
        {
            get
            {
                if (this.ID == 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
