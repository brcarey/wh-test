using System.Collections.Generic;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinRateOverThreshold : IRiskStrategy
    {
        public IEnumerable<Result> Evaluate(IReadOnlyList<BetRow> settledBets, IReadOnlyList<BetRow> unsettledBets)
        {
            throw new System.NotImplementedException();
        }
    }
}
