using System;
using System.IO;
using AsciiImportExport;
using WH.BetEvaluator.Services;
using WH.BetEvaluator.Services.Strategies;

namespace WH.BetEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of command line arguments.");
                Console.WriteLine("Usage: WH.BetEvaluator.exe <settled bets path> <unsettled bets path>");
                return;
            }

            using (var settledBetsReader = new BetReader(new StreamReader(args[0])))
            using (var unsettledBetsReader = new BetReader(new StreamReader(args[1])))
            {

                var strategies = new IRiskStrategy[]
                {
                    new WinPercentageTooHigh(),
                    new StakeUnusuallyHigh(10),
                    new StakeUnusuallyHigh(30),
                    new WinAmountOverThreshold(),
                    new WinRateOverThreshold(50)
                };

                var evaluator = new Services.BetEvaluator(strategies);
                var results = evaluator.Evaluate(settledBetsReader.Read(), unsettledBetsReader.Read());

                Console.Write(GetResultFormatter().Export(results));
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
        }

        static IDocumentFormatDefinition<Result> GetResultFormatter()
        {
            return new DocumentFormatDefinitionBuilder<Result>("\t", true)
                .SetCommentString("#")
                .SetExportHeaderLine(true, "# ")
                .AddColumn(x => x.Level, x => x.SetHeader("Level"))                
                .AddColumn(x => x.CustomerId, x => x.SetHeader("Customer ID"))
                .AddColumn(x => x.EventId, x => x.SetHeader("Event ID"))
                .AddColumn(x => x.Message, x => x.SetHeader("Message"))
                .Build();
        } 
    }
}
