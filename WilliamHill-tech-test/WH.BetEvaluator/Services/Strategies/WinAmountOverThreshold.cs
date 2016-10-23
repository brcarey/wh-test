using System.Collections.Generic;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinAmountOverThreshold : IRiskStrategy
    {
        public IEnumerable<Result> Evaluate(IReadOnlyList<BetRow> settledBets, IReadOnlyList<BetRow> unsettledBets)
        {
            throw new System.NotImplementedException();
        }
    }
}
