using System.Collections.Generic;
using System.Linq;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinAmountOverThreshold : IRiskStrategy
    {
        private readonly double _winAmountThreshold;

        public WinAmountOverThreshold(double winAmountThreshold = 1000)
        {
            _winAmountThreshold = winAmountThreshold;
        }

        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            return unsettledBets
                .Where(x => x.Win > _winAmountThreshold)
                .Select(x => new Result
                {
                    IsFlagged = true,
                    Level = RiskLevel.Minor,
                    Message = $"Customer {x.CustomerId} win amount for event {x.EventId} is over threshold of ${_winAmountThreshold}"
                });
        }
    }
}
