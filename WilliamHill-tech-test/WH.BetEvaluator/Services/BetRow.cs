namespace WH.BetEvaluator.Services
{
    public class BetRow
    {
        public string CustomerId { get; set; }
        public string EventId { get; set; }
        public string ParticipantId { get; set; }
        public double Stake { get; set; }
        public double Win { get; set; }
    }
}
