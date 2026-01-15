```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET 10.0.1, X64 NativeAOT x86-64-v4
  DefaultJob : .NET 10.0.1, X64 NativeAOT x86-64-v4


```
| Method                                          | Mean              | Error          | StdDev        | Allocated |
|------------------------------------------------ |------------------:|---------------:|--------------:|----------:|
| GetBestMove_PrelimBenchmark_BasePosition        | 3,571,798.1520 ns | 10,877.5450 ns | 9,083.2428 ns |         - |
| GetBestMove_PrelimBenchmark_OnlyOnePossibleMove |         5.1653 ns |      0.0245 ns |     0.0229 ns |         - |
| ReturnOne_Control                               |         0.0029 ns |      0.0027 ns |     0.0024 ns |         - |
