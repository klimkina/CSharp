using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using VWA4Common.DataObject;

namespace VWA4Common.DAO
{
	public class GoalsDAO
	{
		public static readonly GoalsDAO DAO = new GoalsDAO();

		private GoalsDAO() { }

		public int GetNextId()
		{
			try
			{
				return Convert.ToInt32(DB.GetId(string.Format(@"SELECT MAX(ID) FROM Goals"))) + 1;
			}
			catch (InvalidCastException)
			{
				return 0;
			}
		}

		public List<Goal> GetAllGoals()
		{
			return this.getDataObjects(DB.Retrieve(@"SELECT * FROM Goals Order By TargetDate DESC"));
		}
		public List<Goal> GetAllGoals(int siteID)
		{
			return this.getDataObjects(DB.Retrieve(@"SELECT * FROM Goals WHERE Site="
			+ siteID.ToString() + " Order By TargetDate DESC"));
		}
		/// <summary>
		/// Return the goal with the supplied ID.
		/// </summary>
		/// <param name="id">ID of goal to return.</param>
		/// <returns>The goal contents, from the database.</returns>
		public Goal Load(int id)
		{
			return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM Goals WHERE ID={0}", id)).Rows[0]);
		}

		public bool Exists(string goalName)
		{
			if (DB.Retrieve(string.Format("select ID from Goals where GoalName='{0}'", goalName)).Rows.Count > 0)
			{
				return true;
			}
			return false;
		}

		public int Insert(Goal goal)
		{
			return this.Insert(goal.GoalName, goal.GoalType, goal.GoalMode,
				goal.TargetPercentage, goal.TargetAmount, goal.FilterType, goal.FilterID, goal.Site, goal.Priority,
				goal.StartDate, goal.TargetDate, goal.Description, goal.Enabled);
		}

		public int Insert(string goalName, int goalType, int goalMode,
			decimal targetPercentage, decimal targetAmount, int filterType, int filterID, int site, int priority,
			DateTime startDate, DateTime targetDate, string description, bool enabled)
		{
			string sql = "INSERT INTO Goals ";
			sql += "(GoalName, GoalType, GoalMode, TargetPercentage, TargetAmount, FilterType,"
						+ " FilterID, Site, Priority, StartDate, TargetDate, Description, Enabled";
			sql += ") VALUES (";
			sql += string.Format("'{0}', ", goalName);
			sql += string.Format("'{0}', ", goalType);
			sql += string.Format("{0}, ", goalMode);
			sql += string.Format("{0}, ", targetPercentage);
			sql += string.Format("{0}, ", targetAmount);
			sql += string.Format("{0}, ", filterType);
			sql += string.Format("{0}, ", filterID);
			sql += string.Format("{0}, ", site);
			sql += string.Format("{0}, ", priority);
			sql += string.Format("#{0}#, ", startDate);
			sql += string.Format("#{0}#, ", targetDate);
			sql += string.Format("'{0}',", description);
			sql += string.Format("{0}", enabled);
			sql += ")";

			return DB.Insert(sql);
		}

		public bool InsertOrUpdate(Goal goal)
		{
			if (goal.IsNew)
			{
				this.Insert(goal);
				return true;
			}
			else
			{
				return this.Update(goal);
			}
		}

		public bool Update(Goal goal)
		{
			string sql = "UPDATE Goals SET ";
			sql += string.Format("GoalName='{0}', ", goal.GoalName);
			sql += string.Format("GoalType={0}, ", goal.GoalType);
			sql += string.Format("GoalMode={0}, ", goal.GoalMode);
			sql += string.Format("TargetPercentage={0}, ", goal.TargetPercentage);
			sql += string.Format("TargetAmount={0}, ", goal.TargetAmount);
			sql += string.Format("FilterType={0}, ", goal.FilterType);
			sql += string.Format("FilterID={0}, ", goal.FilterID);
			sql += string.Format("Site={0}, ", goal.Site);
			sql += string.Format("Priority={0}, ", goal.Priority);
			sql += string.Format("StartDate=#{0}#, ", goal.StartDate);
			sql += string.Format("TargetDate=#{0}#, ", goal.TargetDate);
			sql += string.Format("Description='{0}', ", goal.Description);
			sql += string.Format("Enabled={0} ", goal.Enabled);

			sql += string.Format(" WHERE ID={0}", goal.ID);

			return DB.Update(sql);
		}

		public bool Delete(Goal goal)
		{
			return this.Delete(goal.ID);
		}

		public bool Delete(int id)
		{
			return DB.Delete(string.Format(@"DELETE FROM Goals WHERE ID={0}", id));
		}

		private List<Goal> getDataObjects(DataTable table)
		{
			List<Goal> l = new List<Goal>();
			foreach (DataRow row in table.Rows)
			{
				l.Add(this.getDataObject(row));
			}
			return l;
		}

		private Goal getDataObject(DataRow row)
		{
			Goal goal = new Goal();

			goal.ID = Convert.ToInt32(row[0].ToString());
			goal.GoalName = row["GoalName"].ToString();
			goal.GoalType = Convert.ToInt32(row["GoalType"]);
			goal.GoalMode = Convert.ToInt32(row["GoalMode"]);
			goal.TargetPercentage = Convert.ToDecimal(row["TargetPercentage"]);
			goal.TargetAmount = Convert.ToDecimal(row["TargetAmount"]);
			goal.FilterType = Convert.ToInt32(row["FilterType"]);
			goal.FilterID = Convert.ToInt32(row["FilterID"]);
			goal.Site = Convert.ToInt32(row["Site"]);
			goal.Priority = Convert.ToInt32(row["Priority"]);
			goal.StartDate = DateTime.Parse(row["StartDate"].ToString());
			goal.TargetDate = DateTime.Parse(row["TargetDate"].ToString());
			goal.Description = row["Description"].ToString();
			goal.Enabled = Convert.ToBoolean(row["Enabled"]);
			return goal;
		}

		private List<TagsFoodType> foodtypes;

        //public DataTable getBoundAmounts(Goal goal, DateTime from, DateTime to)
        //{
        //    string whereclause = "";
        //    var daysworking = 0;
        //    var percentcomplete = (decimal)0.0;
        //    var baselineweekamt = (decimal)0.0;
        //    decimal targetweeklyamount = (decimal)0.0;
        //    decimal desiredchangeamount = (decimal)0.0;
        //    decimal actualchangeamount = (decimal)0.0;


        //    Tag goaltag = new Tag();
        //    goaltag = TagsDAO.DAO.Load(goal.FilterID);
        //    // Get the food types that are tagged with this tag
        //    foodtypes = TagsFoodTypeDAO.DAO.GetAllByTagID(goaltag.ID);
        //    // Build the where clause
        //    if (foodtypes.Count > 0)
        //    {
        //        whereclause = " WHERE SiteID = " + goal.Site.ToString() + " AND (";
        //        string orme = "";
        //        for (int i = 0; i < foodtypes.Count; i++)
        //        {
        //            whereclause += orme + " (FoodTypeID = '" + foodtypes[i].FoodTypeID + "') ";
        //            orme = " OR ";
        //        }
        //        whereclause += ") ";
        //    }
        //    else
        //    { 
        //        return null;
        //    }

        //    string querybase = "SELECT SUM(Weight - NItems*ContainerWeight) AS totalweight, SUM(WasteCost) AS totalcost"
        //        + " FROM Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey  " + whereclause;

        //    string dateclause = " AND [Weights.Timestamp] >= #" + goal.StartDate.AddDays(-7).ToShortDateString()
        //    + "# AND [Weights.Timestamp] < #" + goal.StartDate.ToShortDateString() + "# ";
        //    ///
        //    string query = querybase + dateclause;
        //    DataTable dtbaseresult = VWA4Common.DB.Retrieve(query);
        //    if (goal.GoalType == 0)
        //    { // Dollar goal
        //        string totalcoststr = dtbaseresult.Rows[0][1].ToString();
        //        if (totalcoststr != string.Empty)
        //        {
        //            baselineweekamt = decimal.Parse(totalcoststr);
        //        }
        //    }
        //    else
        //    { // Weight goal
        //        string totalweightstr = dtbaseresult.Rows[0][0].ToString();
        //        if (totalweightstr != string.Empty)
        //        {
        //            baselineweekamt = decimal.Parse(totalweightstr);
        //        }
        //    }
        //    // Get target weekly amount for calculation purposes
        //    if (goal.GoalMode == 0)
        //    { // Target percentage
        //        targetweeklyamount = baselineweekamt - baselineweekamt * goal.TargetPercentage / 100;
        //    }
        //    else targetweeklyamount = baselineweekamt - goal.TargetAmount;
        //    desiredchangeamount = baselineweekamt - targetweeklyamount;

        //    query = querybase + dateclause;
        //    DataTable dtdataweekresult = VWA4Common.DB.Retrieve(query);

        //    return dtdataweekresult;
        //}

        public AvgActualData GetAvgActualData(int goalId)
        {
            var goal = GoalsDAO.DAO.Load(goalId);
            var goaltag = TagsDAO.DAO.Load(goal.FilterID);
            var whereclause = string.Empty;
            var query = string.Empty;
            var avg = (decimal) 0.00;
            var gap = (decimal) 0.00;

            foodtypes = TagsFoodTypeDAO.DAO.GetAllByTagID(goaltag.ID);
            if (foodtypes.Count > 0)
            {
                whereclause = " WHERE SiteID = " + goal.Site.ToString() + " AND (";
                var orme = "";
                for (var i = 0; i < foodtypes.Count; i++)
                {
                    whereclause += orme + " (FoodTypeID = '" + foodtypes[i].FoodTypeID + "') ";
                    orme = " OR ";
                }
                whereclause += ") ";
            }

            var querybase = string.Format("SELECT SUM(Weight - NItems*ContainerWeight) as TotalWeight, Avg(Weight - NItems*ContainerWeight) AS AvgWeight, SUM(WasteCost) as TotalCost, Avg(WasteCost) AS AvgCost from Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey {0}", whereclause);
            var dateclause = String.Format(" AND [Weights.Timestamp] >= #{0}# AND [Weights.Timestamp] < #{1}# ", DateTime.Now.Subtract(TimeSpan.FromDays(7 * 4)).ToShortDateString(), goal.StartDate.ToShortDateString());

            query = querybase + dateclause;
            var dtResults = DB.Retrieve(query);
            var buf = "";
            buf = goal.GoalType.Equals(0) ? dtResults.Rows[0][3].ToString() : dtResults.Rows[0][1].ToString();

            if (buf != string.Empty)
            {
                avg = decimal.Parse(buf);
            }

            buf = goal.GoalType.Equals(0) ? dtResults.Rows[0][2].ToString() : dtResults.Rows[0][0].ToString();
            if(buf != string.Empty)
            {
                gap = avg - decimal.Parse(buf);
            }
            return new AvgActualData {Avg = avg, GapOfAvg = gap};
        }
        
        public MaxMinModel Get52WkData(int goalId)
        {
            var goal = GoalsDAO.DAO.Load(goalId);
            var goaltag = TagsDAO.DAO.Load(goal.FilterID);
            var whereclause = string.Empty;
            var query = string.Empty;
            var max = (decimal) 0.00;
            var min = (decimal) 0.00;

            foodtypes = TagsFoodTypeDAO.DAO.GetAllByTagID(goaltag.ID);
            if (foodtypes.Count > 0)
            {
                whereclause = " WHERE SiteID = " + goal.Site.ToString() + " AND (";
                var orme = "";
                for (var i = 0; i < foodtypes.Count; i++)
                {
                    whereclause += orme + " (FoodTypeID = '" + foodtypes[i].FoodTypeID + "') ";
                    orme = " OR ";
                }
                whereclause += ") ";
            }

            var querybase = string.Format("SELECT MAX(WasteCost) AS MaxCost, MIN(WasteCost) as MinCost from Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey {0}", whereclause);
            var dateclause = String.Format(" AND [Weights.Timestamp] >= #{0}# AND [Weights.Timestamp] < #{1}# ", DateTime.Now.Subtract(TimeSpan.FromDays(7*52)).ToShortDateString(), goal.StartDate.ToShortDateString());

            query = querybase + dateclause;
            var dtResults = VWA4Common.DB.Retrieve(query);

            var buf = dtResults.Rows[0][0].ToString();
            if (buf != string.Empty)
            {
                max = decimal.Parse(buf);
            }
            buf = dtResults.Rows[0][1].ToString();
            if(buf != string.Empty)
            {
                min = decimal.Parse(buf);
            }

            return new MaxMinModel {Max = max, Min = min};
        }

		/// <summary>
		/// Return the amount of the specified goal for the week provided, along with some other
		/// reporting results.
		/// </summary>
		/// <param name="goal">Goal to query.</param>
		/// <param name="dataweek">Week to query.</param>
		/// <param name="daysworking">Days since beginning of goal to end of specified dataweek.</param>
		/// <param name="percentcomplete">Percent completion dataweek is, over starting week.</param>
		/// <returns>$ or weight for current goal, in lbs, for current week depending on goal type.</returns>
		public GoalReportModel getAmount(Goal goal, DateTime dataweek)
		{
			string whereclause = "";
			var daysworking = 0;
			var percentcomplete = (decimal)0.0;
			var baselineweekamt = (decimal)0.0;
			decimal targetweeklyamount = (decimal)0.0;
			decimal desiredchangeamount = (decimal)0.0;
			decimal actualchangeamount = (decimal)0.0;
			decimal gaptogoal = (decimal)0.0;
			/// First get daysworking sorted out
			/// 
			if (dataweek <= goal.StartDate)
			{
				return new GoalReportModel
				{
					Amount = 0,
					BaselineWeekAmt = baselineweekamt,
					DaysWorking = daysworking,
					PercentComplete = percentcomplete,
					GaptoGoal = 0
				};
			}
			TimeSpan ts = dataweek - goal.StartDate;
			daysworking = ts.Days;
			///****************************
			/// What type of filter is it? 
			///****************************
			if (goal.FilterType == 0)
			{ ///*********** Tag filter

				/// Build up the where based on tag
				// Get the tag for this goal
				Tag goaltag = new Tag();
				goaltag = TagsDAO.DAO.Load(goal.FilterID);
				// Get the food types that are tagged with this tag
				foodtypes = TagsFoodTypeDAO.DAO.GetAllByTagID(goaltag.ID);
				// Build the where clause
				if (foodtypes.Count > 0)
				{
					whereclause = " WHERE SiteID = " + goal.Site.ToString() + " AND (";
					string orme = "";
					for (int i = 0; i < foodtypes.Count; i++)
					{
						whereclause += orme + " (FoodTypeID = '" + foodtypes[i].FoodTypeID + "') ";
						orme = " OR ";
					}
					whereclause += ") ";
				}
				else
				{ // No food types for this tag
					percentcomplete = (decimal)0.0;
				    return new GoalReportModel
				               {
				                   Amount = 0,
				                   BaselineWeekAmt = baselineweekamt,
				                   DaysWorking = daysworking,
				                   PercentComplete = percentcomplete
				               };
				}
				///
				/// Query basics
				/// 
				string querybase = "SELECT SUM(Weight - NItems*ContainerWeight) AS totalweight, SUM(WasteCost) AS totalcost"
					+ " FROM Weights LEFT JOIN Transfers ON Transfers.TransKey = Weights.TransKey  " + whereclause;
				///
				/// Get the baseline amount data
				/// 
				// Start Date - 7 is the baseline week
				string dateclause = " AND [Weights.Timestamp] >= #" + goal.StartDate.AddDays(-7).ToShortDateString()
				+ "# AND [Weights.Timestamp] < #" + goal.StartDate.ToShortDateString() + "# ";
				///
				string query = querybase + dateclause;
				DataTable dtbaseresult = VWA4Common.DB.Retrieve(query);
				if (goal.GoalType == 0)
				{ // Dollar goal
					string totalcoststr = dtbaseresult.Rows[0][1].ToString();
					if (totalcoststr != string.Empty)
					{
						baselineweekamt = decimal.Parse(totalcoststr);
					}
				}
				else
				{ // Weight goal
					string totalweightstr = dtbaseresult.Rows[0][0].ToString();
					if (totalweightstr != string.Empty)
					{
						baselineweekamt = decimal.Parse(totalweightstr);
					}
				}
				// Get target weekly amount for calculation purposes
				if (goal.GoalMode == 0)
				{ // Target percentage
					targetweeklyamount = baselineweekamt - baselineweekamt * goal.TargetPercentage / 100;
				}
				else targetweeklyamount = baselineweekamt - goal.TargetAmount;
				desiredchangeamount = baselineweekamt - targetweeklyamount;
				///
				/// Get the selected week data
				/// 
				dateclause = " AND [Weights.Timestamp] >= #" + dataweek.ToShortDateString()
				+ "# AND [Weights.Timestamp] < #" + dataweek.AddDays(7).ToShortDateString() + "# ";
				/// 
				query = querybase + dateclause;
				DataTable dtdataweekresult = VWA4Common.DB.Retrieve(query);
				if (goal.GoalType == 0)
				{ // Dollar goal
					string totalcoststr = dtdataweekresult.Rows[0][1].ToString();
					decimal totalcost = (decimal)0.0;
					if (totalcoststr != string.Empty)
					{
						totalcost = decimal.Parse(totalcoststr);
						actualchangeamount = baselineweekamt - totalcost;
						if (actualchangeamount > 0 && desiredchangeamount > 0)
							percentcomplete = actualchangeamount / desiredchangeamount;
						gaptogoal = totalcost - targetweeklyamount;
					}
					return new GoalReportModel
							   {
								   Amount = totalcost,
								   BaselineWeekAmt = baselineweekamt,
								   DaysWorking = daysworking,
								   PercentComplete = percentcomplete,
								   GaptoGoal = gaptogoal
							   };
				}
				else
				{ // Weight goal
					string totalweightstr = dtdataweekresult.Rows[0][0].ToString();
					decimal totalwt = (decimal)0.0;
					if (totalweightstr != string.Empty)
					{
						totalwt = decimal.Parse(totalweightstr);
						actualchangeamount = baselineweekamt - totalwt;
						if (actualchangeamount > 0 && desiredchangeamount > 0)
							percentcomplete = actualchangeamount / desiredchangeamount;
						gaptogoal = totalwt - targetweeklyamount;
					}
				    return new GoalReportModel
				               {
				                   Amount = totalwt,
				                   BaselineWeekAmt = baselineweekamt,
				                   DaysWorking = daysworking,
				                   PercentComplete = percentcomplete,
								   GaptoGoal = gaptogoal
				               };
				}
			}
			else
			{ ///************* Advanced filter

			}

			percentcomplete = 0;
		    return new GoalReportModel
		               {
		                   Amount = 0,
		                   BaselineWeekAmt = baselineweekamt,
		                   DaysWorking = daysworking,
		                   PercentComplete = percentcomplete,
						   GaptoGoal = gaptogoal
		               };
		}
	}
}
