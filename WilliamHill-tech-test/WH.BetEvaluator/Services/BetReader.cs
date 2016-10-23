using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

        public IReadOnlyList<BetRow> Read()
        {
            var rows = _csvReader.GetRecords<BetRow>();
            return new ReadOnlyCollection<BetRow>(rows.ToList());
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
