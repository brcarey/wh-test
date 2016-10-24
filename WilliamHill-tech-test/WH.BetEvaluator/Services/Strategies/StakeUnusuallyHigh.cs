using System.Collections.Generic;
using System.Linq;

namespace WH.BetEvaluator.Services.Strategies
{
    public class StakeUnusuallyHigh : IRiskStrategy
    {
        private readonly int _stakeThresholdFactor;

        public StakeUnusuallyHigh(int stakeThresholdFactor)
        {
            _stakeThresholdFactor = stakeThresholdFactor;
        }

        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            var averageStakeByCustomer = settledBets
                .GroupBy(x => x.CustomerId)
                .Select(x => new { x.Key, AverageStake = x.Sum(z => z.Stake) / x.Count() })
                .ToDictionary(x => x.Key, x => x.AverageStake);

            return unsettledBets
                .Where(x => averageStakeByCustomer.ContainsKey(x.CustomerId) && x.Stake > (averageStakeByCustomer[x.CustomerId] * _stakeThresholdFactor))
                .Select(x => new Result
                {
                    IsFlagged = true,
                    Level = RiskLevel.Major,
                    Message = $"Customer {x.CustomerId} stake for event {x.EventId} is over their average stake by a factor of {_stakeThresholdFactor}"
                });
        }
    }
}
