using System.Linq;
using NUnit.Framework;
using WH.BetEvaluator.Services;
using WH.BetEvaluator.Services.Strategies;

namespace WH.BetEvaluator.Test
{
    public class WinAmountOverThresholdTests
    {
        [Test]
        public void ShouldReturnResultWhenWinAmountIsOver1000()
        {
            var bets = new[]
            {
                new BetRow {CustomerId = "1", EventId = "1", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "2", ParticipantId = "1", Stake = 10, Win = 2000}
            };

            var strategy = new WinAmountOverThreshold();
            var result = strategy.Evaluate(Enumerable.Empty<BetRow>(), bets).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Message, Is.EqualTo("Customer 1 win amount for event 2 is over threshold of $1000"));
        }
    }
}
