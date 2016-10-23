using System.Linq;
using NUnit.Framework;
using WH.BetEvaluator.Services;
using WH.BetEvaluator.Services.Strategies;

namespace WH.BetEvaluator.Test
{
    public class WinPercentageTooHighTests
    {
        [Test]
        public void ShouldReturnResult()
        {
            var bets = new[]
            {
                new BetRow {CustomerId = "1", EventId = "1", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "2", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "3", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "4", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "5", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "6", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "7", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "8", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "9", ParticipantId = "1", Stake = 10, Win = 20},
                new BetRow {CustomerId = "1", EventId = "10", ParticipantId = "1", Stake = 10, Win = 20},
            };

            var strategy = new WinPercentageTooHigh();
            var result = strategy.Evaluate(bets, Enumerable.Empty<BetRow>()).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Message, Is.EqualTo("Customer 1 win percentage is over threshold of 60%"));
        }
    }
}
