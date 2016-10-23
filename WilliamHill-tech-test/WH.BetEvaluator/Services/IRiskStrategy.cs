using System.Collections.Generic;

namespace WH.BetEvaluator.Services
{
    public interface IRiskStrategy
    {
        IEnumerable<Result> Evaluate(IEnumerable<BetRow> settledBets, IEnumerable<BetRow> unsettledBets);
    }
}
