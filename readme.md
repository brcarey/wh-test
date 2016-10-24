# William Hill Technical test

Console implementation of the William Hill technical test. The program takes 2 command line arguments which are paths to the 2 CSV files containing settled and unsettled bet data. 
It will then run a series of risk strategies, as defined in the spec, over this data and output result information to the console.

## Usage

The program can be run by invoking the executable with the 2 command line arguments: 

`WH.BetEvaluator.exe <path to settled bets CSV> <path to unsettled bets CSV>`.

There is a copy of the executable in the dist folder in the root of the repository, though it can also be easily built from Visual Studio. 