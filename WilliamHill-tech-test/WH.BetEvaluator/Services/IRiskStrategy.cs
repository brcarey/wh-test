using System.Collections.Generic;

namespace WH.BetEvaluator.Services
{
    public interface IRiskStrategy
    {
        Result Evaluate(IReadOnlyList<BetRow> settledBets, IReadOnlyList<BetRow> unsettledBets);
    }
}
