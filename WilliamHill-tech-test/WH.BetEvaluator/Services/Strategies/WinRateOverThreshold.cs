using System.Collections.Generic;
using System.Linq;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinRateOverThreshold : IRiskStrategy
    {
        private readonly double _winPercentageThreshold;

        public WinRateOverThreshold(double winPercentageThreshold)
        {
            _winPercentageThreshold = winPercentageThreshold;
        }

        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            return unsettledBets.GroupBy(x => x.CustomerId)
                .Where(x => (x.Count(z => z.Win > 0) / x.Count() * 100) > _winPercentageThreshold)
                .Select(x => new Result
                {
                    IsFlagged = true,
                    Level = RiskLevel.Major,
                    Message = $"Customer {x.Key} win percentage is over threshold of {_winPercentageThreshold}%"
                });
        }
    }
}
