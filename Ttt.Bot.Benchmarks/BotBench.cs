using BenchmarkDotNet.Attributes;

using TikTakNoMem;

namespace Ttt.Bot.Benchmarks;

[MemoryDiagnoser]
public class BotBench
{
    private TikTakNoMem.Bot _bot;
    private Board _board;

    [GlobalSetup]
    public void Setup()
    {
        _bot = new TikTakNoMem.Bot();
        _board = new Board(0,0);
    }

    [Benchmark]
    public int GetBotBestMove_PrelimBenchmark()
    {
        return _bot.GetBestMove(_board, true);
    }
}