using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
	public class TagsFoodType
	{
		private int _ID = 0;
		private int _TagID = 0;
		private string _FoodTypeID = string.Empty;
		private string _TagName = string.Empty;
		private string _FoodTypeName = string.Empty;

		public int ID
		{
			get { return this._ID; }
			set { this._ID = value; }
		}
		public int TagID
		{
			get { return this._TagID; }
			set { this._TagID = value; }
		}
		public string TagName
		{
			get { return this._TagName; }
			set { this._TagName = value; }
		}
		public string FoodTypeID
		{
			get { return this._FoodTypeID; }
			set { this._FoodTypeID = value; }
		}
		public string FoodTypeName
		{
			get { return this._FoodTypeName; }
			set { this._FoodTypeName = value; }
		}
		public bool IsNew
		{
			get
			{
				if (this.ID == 0)
					return true;
				return false;
			}
		}
	}
}
