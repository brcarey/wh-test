using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace WH.BetEvaluator.Services
{
    public class BetReader : IDisposable
    {
        private readonly CsvReader _csvReader;

        public BetReader(TextReader sourceReader)
        {
            var config = new CsvConfiguration();
            config.RegisterClassMap<BetRowMap>();
            _csvReader = new CsvReader(sourceReader, config);
        }

        public IEnumerable<BetRow> Read()
        {
            return _csvReader.GetRecords<BetRow>();
        }

        public void Dispose()
        {
            _csvReader.Dispose();
        }

        private sealed class BetRowMap : CsvClassMap<BetRow>
        {
            public BetRowMap()
            {
                Map(m => m.CustomerId).Index(0);
                Map(m => m.EventId).Index(1);
                Map(m => m.ParticipantId).Index(2);
                Map(m => m.Stake).Index(3);
                Map(m => m.Win).Index(4);
            }
        }
    }
}
