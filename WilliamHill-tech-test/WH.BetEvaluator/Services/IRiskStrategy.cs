using System.Collections.Generic;

namespace WH.BetEvaluator.Services
{
    public interface IRiskStrategy
    {
        IEnumerable<Result> Evaluate(IReadOnlyList<BetRow> settledBets, IReadOnlyList<BetRow> unsettledBets);
    }
}
