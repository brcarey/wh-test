namespace WH.BetEvaluator.Services
{
    public class Result
    {
        public string Message { get; set; }
        public RiskLevel Level { get; set; }
        public string CustomerId { get; set; }
        public string EventId { get; set; }
    }

    public enum RiskLevel
    {
        None,
        Minor,
        Major,
        Critical
    }
}
