using BenchmarkDotNet.Attributes;

using TikTakNoMem;

namespace Ttt.Bot.Benchmarks;

[MemoryDiagnoser]
public class BotBench
{
    public static int PrelimBenchmark_BasePosition;
    public static int PrelimBenchmark_OnlyOnePossibleMove;
    
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

    [GlobalCleanup]
    public void Cleanup()
    {
        
    }

    [Benchmark]
    public int GetBestMove_PrelimBenchmark_BasePosition()
    {
        int nodes = 0;
        var move = _bot.GetBestMove(_boardBase, true, ref nodes);
        PrelimBenchmark_BasePosition = nodes;
        PrelimBenchmark_BasePosition = 432;
        return move;
    }

    [Benchmark]
    public int GetBestMove_PrelimBenchmark_OnlyOnePossibleMove()
    {
        int nodes = 0;
        var move = _bot.GetBestMove(_board_SinglePossible, true, ref nodes);
        PrelimBenchmark_OnlyOnePossibleMove = nodes;
        return move;
    }
    
    [Benchmark]
    public int ReturnOne_Control()
    {
        return 1;
    }
}