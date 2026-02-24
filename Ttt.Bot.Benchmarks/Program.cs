using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using TikTakNoMem;
using Ttt.Bot.Benchmarks.Columns;

namespace Ttt.Bot.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        var b = new Board(0b_110_000_101,0b_001_011_010);
        Console.WriteLine(b.ToString());

        BenchmarkRunner.Run<BotBench>(DefaultConfig.Instance.AddColumn(new NodesVisitedColumn("Nodes Visited")));
    }
}