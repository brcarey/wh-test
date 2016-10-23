namespace WH.BetEvaluator.Services
{
    public class Result
    {
        public bool IsFlagged { get; set; }
        public string Message { get; set; }
        public RiskLevel Level { get; set; }
    }

    public enum RiskLevel
    {
        None,
        Minor,
        Major,
        Critical
    }
}
