using System.IO;
using System.Linq;
using NUnit.Framework;
using WH.BetEvaluator.Services;

namespace WH.BetEvaluator.Test
{
    public class BetReaderTests
    { 

        [Test]
        public void ShouldReadSettledBetRows()
        {
            const string betText = @"
Customer,Event,Participant,Stake,Win
1,11,4,50,500
2,11,4,20,1000";
            
            var reader = new BetReader(new StringReader(betText));
            var rows = reader.Read().ToList();

            Assert.That(rows.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldReadUnsettledBetRows()
        {
            const string betText = @"
Customer,Event,Participant,Stake,To Win
1,11,4,50,500
2,11,4,20,1000";

            var reader = new BetReader(new StringReader(betText));
            var rows = reader.Read().ToList();

            Assert.That(rows.Count, Is.EqualTo(2));
        }
    }
}
