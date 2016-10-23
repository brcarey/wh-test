using System.Collections.Generic;
using System.Linq;

namespace WH.BetEvaluator.Services
{
    public class BetEvaluator
    {
        private readonly IEnumerable<IRiskStrategy> _riskStrategies;

        public BetEvaluator(IEnumerable<IRiskStrategy> riskStrategies)
        {
            _riskStrategies = riskStrategies;
        }

        public IEnumerable<Result> Evaluate(IReadOnlyList<BetRow> settledBets, IReadOnlyList<BetRow> unsettledBets)
        {
            return _riskStrategies.SelectMany(strategy => strategy.Evaluate(settledBets, unsettledBets));
        }
    }
}
