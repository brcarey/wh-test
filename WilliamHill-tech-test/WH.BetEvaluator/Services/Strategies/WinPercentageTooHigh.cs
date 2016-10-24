using System.Collections.Generic;
using System.Linq;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinPercentageTooHigh : IRiskStrategy
    {
        private readonly double _percentageThreshold;

        public WinPercentageTooHigh(double percentageThreshold = 60)
        {
            _percentageThreshold = percentageThreshold;
        }

        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            return settledBets.GroupBy(x => x.CustomerId)
                .Where(x => (x.Count(z => z.Win > 0) / x.Count() * 100) > _percentageThreshold)
                .Select(x => new Result
                {
                    Level = RiskLevel.Major,
                    CustomerId = x.Key,
                    Message = $"Customer {x.Key} win percentage is over threshold of {_percentageThreshold}%"
                });
        }
    }
}
