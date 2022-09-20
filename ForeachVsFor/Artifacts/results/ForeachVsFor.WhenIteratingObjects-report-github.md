``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|                      Method |     Mean |     Error |    StdDev | Allocated |
|---------------------------- |---------:|----------:|----------:|----------:|
| ForeachLoopIteratingObjects | 1.924 ms | 0.0309 ms | 0.0289 ms |         - |
|     ForLoopIteratingObjects | 1.915 ms | 0.0356 ms | 0.0333 ms |         - |
