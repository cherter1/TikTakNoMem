```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET 10.0.1, X64 NativeAOT x86-64-v4
  DefaultJob : .NET 10.0.1, X64 NativeAOT x86-64-v4


```
| Method                                          | Mean     | Error     | StdDev    | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|----------:|
| GetBestMove_PrelimBenchmark_BasePosition        | 4.316 ms | 0.0862 ms | 0.1367 ms |       5 B |
| GetBestMove_PrelimBenchmark_OnlyOnePossibleMove | 4.277 ms | 0.0734 ms | 0.1029 ms |       5 B |
