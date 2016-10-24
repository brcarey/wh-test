using System.Linq;
using NUnit.Framework;
using WH.BetEvaluator.Services;
using WH.BetEvaluator.Services.Strategies;

namespace WH.BetEvaluator.Test
{
    public class StakeUnusuallyHighTests
    {
        [Test]
        public void ShouldReturnResultWhenStakeExceedsAverageByFactorOf10()
        {
            var settledBets = new[]
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

            var newBet = new BetRow {CustomerId = "1", EventId = "11", ParticipantId = "1", Stake = 200, Win = 2000};

            var strategy = new StakeUnusuallyHigh(10);
            var result = strategy.Evaluate(settledBets, new [] { newBet }).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Message, Is.EqualTo("Customer 1 stake for event 11 is over their average stake by a factor of 10"));
        }

        [Test]
        public void ShouldReturnResultWhenStakeExceedsAverageByFactorOf30()
        {
            var settledBets = new[]
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

            var newBet = new BetRow { CustomerId = "1", EventId = "11", ParticipantId = "1", Stake = 400, Win = 2000 };

            var strategy = new StakeUnusuallyHigh(30);
            var result = strategy.Evaluate(settledBets, new[] { newBet }).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Message, Is.EqualTo("Customer 1 stake for event 11 is over their average stake by a factor of 30"));
        }
    }
}
