namespace VWA4Common.DataObject
{
    public class GoalReportModel
    {
        public int DaysWorking { get; set; }
        public decimal BaselineWeekAmt { get; set; }
        public decimal PercentComplete { get; set; }
        public decimal Amount { get; set; }
		public decimal GaptoGoal { get; set; }
    }
}
