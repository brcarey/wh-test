using System.Collections.Generic;

namespace WH.BetEvaluator.Services.Strategies
{
    public class WinAmountOverThreshold : IRiskStrategy
    {
        public IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets)
        {
            throw new System.NotImplementedException();
        }
    }
}
