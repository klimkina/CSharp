using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
	public class Goal
	{
		private int _ID = 0;
		private string _GoalName = string.Empty;
		private int _GoalType = -1;
		private int _GoalMode = -1;
		private decimal _TargetPercentage = -1;
		private decimal _TargetAmount = -1;
		private int _FilterType = -1;
		private int _FilterID = 0;
		private int _Site = -1;
		private int _Priority = -1;
		private DateTime _StartDate = DateTime.MinValue;
		private DateTime _TargetDate = DateTime.MinValue;
		private string _Description = string.Empty;
		private bool _Enabled = false;

		public int ID
		{
			get { return this._ID; }
			set { this._ID = value; }
		}
		public string GoalName
		{
			get { return this._GoalName; }
			set { this._GoalName = value; }
		}
		public int GoalType
		{
			get { return this._GoalType; }
			set { this._GoalType = value; }
		}
		public int GoalMode
		{
			get { return this._GoalMode; }
			set { this._GoalMode = value; }
		}
		public decimal TargetPercentage
		{
			get { return this._TargetPercentage; }
			set { this._TargetPercentage = value; }
		}
		public decimal TargetAmount
		{
			get { return this._TargetAmount; }
			set { this._TargetAmount = value; }
		}
		public int FilterType
		{
			get { return this._FilterType; }
			set { this._FilterType = value; }
		}
		public int FilterID
		{
			get { return this._FilterID; }
			set { this._FilterID = value; }
		}
		public int Site
		{
			get { return this._Site; }
			set { this._Site = value; }
		}
		public int Priority
		{
			get { return this._Priority; }
			set { this._Priority = value; }
		}
		public DateTime StartDate
		{
			get { return this._StartDate; }
			set { this._StartDate = value; }
		}
		public DateTime TargetDate
		{
			get { return this._TargetDate; }
			set { this._TargetDate = value; }
		}
		public string Description
		{
			get { return this._Description; }
			set { this._Description = value; }
		}
		public bool Enabled
		{
			get { return this._Enabled; }
			set { this._Enabled = value; }
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
