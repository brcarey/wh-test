using System.Collections.Generic;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinRateOverThreshold : IRiskStrategy
    {
        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            throw new System.NotImplementedException();
        }
    }
}
