``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT
  DefaultJob : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT


```
|                 Method |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|----------------------- |---------:|----------:|----------:|------:|-------:|----------:|
|                Default | 1.927 μs | 0.0108 μs | 0.0101 μs |  1.00 | 0.1907 |      1 KB |
| Default_DifferentOrder | 1.853 μs | 0.0260 μs | 0.0244 μs |  0.96 | 0.1926 |      1 KB |
|  Default_CombinedWhere | 1.770 μs | 0.0079 μs | 0.0074 μs |  0.92 | 0.1698 |      1 KB |
