```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET 10.0.1, X64 NativeAOT x86-64-v4
  DefaultJob : .NET 10.0.1, X64 NativeAOT x86-64-v4


```
| Method                                          | Mean              | Error         | StdDev        | Median            | Nodes Visited | Allocated |
|------------------------------------------------ |------------------:|--------------:|--------------:|------------------:|--------------:|----------:|
| GetBestMove_PrelimBenchmark_BasePosition        | 3,620,257.7674 ns | 6,076.7677 ns | 5,074.3762 ns | 3,618,166.9922 ns |        549945 |       3 B |
| GetBestMove_PrelimBenchmark_OnlyOnePossibleMove |         6.6029 ns |     0.0114 ns |     0.0095 ns |         6.6049 ns |             1 |         - |
| ReturnOne_Control                               |         0.0004 ns |     0.0006 ns |     0.0006 ns |         0.0001 ns |             - |         - |
