using System.Diagnostics;

namespace TikTakNoMem;

public static class BaselineMetrics
{
    public static void RunWithMetrics(Action workload, string label = "Baseline")
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        var g0 = GC.CollectionCount(0);
        var g1 = GC.CollectionCount(1);
        var g2 = GC.CollectionCount(2);

        var startAllocated = GC.GetTotalAllocatedBytes(true);
        var proc = Process.GetCurrentProcess();
        var startWorkingSet = proc.WorkingSet64;

        var sw = Stopwatch.StartNew();
        workload();
        sw.Stop();

        proc.Refresh();
        var endWorkingSet = proc.WorkingSet64;
        var endAllocated = GC.GetTotalAllocatedBytes(true);

        Console.WriteLine($"""
                           [{label}]
                           Allocated (bytes): {endAllocated - startAllocated:N0}
                           GC: Gen2={GC.CollectionCount(0) - g0}, Gen1={GC.CollectionCount(1) - g1}, Gen2={GC.CollectionCount(2) - g2}
                           Managed Heap (bytes, after): {GC.GetGCMemoryInfo().HeapSizeBytes:N0}
                           Working Set (MB): {startWorkingSet / (1024 * 1024.0):F1} -> {endWorkingSet / (1024 * 1024.0):F1}
                           Elapsed: {sw.Elapsed}
                           """);
        using var streamWriter = new StreamWriter("baseline.log", true);
        streamWriter.WriteLine($"""
                                [{label}]
                                Allocated (bytes): {endAllocated - startAllocated:N0}
                                GC: Gen0={GC.CollectionCount(0) - g0}, Gen1={GC.CollectionCount(1) - g1}, Gen2={GC.CollectionCount(2) - g2}
                                Managed Heap (bytes, after): {GC.GetGCMemoryInfo().HeapSizeBytes:N0}
                                Working Set (MB): {startWorkingSet / (1024 * 1024.0):F1} -> {endWorkingSet / (1024 * 1024.0):F1}
                                Elapsed: {sw.Elapsed}
                                """);
        streamWriter.WriteLine();
    }
}
