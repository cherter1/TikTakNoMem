using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using TikTakNoMem;

namespace Ttt.Bot.Benchmarks.Columns;

public class NodesVisitedColumn : IColumn
{
    public string Id { get; }
    public string ColumnName { get; }

    public NodesVisitedColumn(string columnName, Func<string, string> getTag)
    {
        ColumnName = columnName;
        Id = nameof(NodesVisitedColumn) + "." + ColumnName;
    }

    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
    public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
    {
        var basePosBench = benchmarkCase.Descriptor.WorkloadMethod.Name.Contains("BasePosition");
        if (basePosBench)
        {
            int nodes = 0;
            var bot = new TikTakNoMem.Bot();
            bot.GetBestMove(new Board(0, 0), true, ref nodes);
            return nodes.ToString();
        }

        if (!benchmarkCase.Descriptor.WorkloadMethod.Name.Contains("OnlyOnePossibleMove"))
        {
            return "-";
        }

        {
            int nodes = 0;
            var bot = new TikTakNoMem.Bot();
            bot.GetBestMove(new Board(0b_110_000_101, 0b_001_011_010), true, ref nodes);
            return nodes.ToString();
        }

    }

    public bool IsAvailable(Summary summary) => true;
    public bool AlwaysShow => true;
    public ColumnCategory Category => ColumnCategory.Custom;
    public int PriorityInCategory => 0;
    public bool IsNumeric => true;
    public UnitType UnitType => UnitType.Dimensionless;
    public string Legend => $"Custom '{ColumnName}' tag column";
    public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) => GetValue(summary, benchmarkCase);
    public override string ToString() => ColumnName;
}