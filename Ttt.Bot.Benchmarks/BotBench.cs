using BenchmarkDotNet.Attributes;

using TikTakNoMem;

namespace Ttt.Bot.Benchmarks;

[MemoryDiagnoser]
public class BotBench
{
    private TikTakNoMem.Bot _bot;
    private Board _boardBase;
    private Board _board_SinglePossible;

    [GlobalSetup]
    public void Setup()
    {
        _bot = new TikTakNoMem.Bot();
        _boardBase = new Board(0,0);
        _board_SinglePossible = new Board(0b_110_000_101,0b_001_011_010);
    }

    [Benchmark]
    public int GetBestMove_PrelimBenchmark_BasePosition()
    {
        return _bot.GetBestMove(_boardBase, true);
    }

    [Benchmark]
    public int GetBestMove_PrelimBenchmark_OnlyOnePossibleMove()
    {
        return _bot.GetBestMove(_board_SinglePossible, true);
    }
    
    [Benchmark]
    public int ReturnOne_Control()
    {
        return 1;
    }
}