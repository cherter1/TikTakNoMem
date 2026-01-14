using BenchmarkDotNet.Running;

namespace Ttt.Bot.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<BotBench>();
    }
}