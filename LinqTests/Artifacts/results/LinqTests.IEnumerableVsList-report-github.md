``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                       Method |      Mean |     Error |    StdDev |  Gen 0 |  Gen 1 | Allocated |
|----------------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
|                IteratingList |  7.631 μs | 0.0621 μs | 0.0581 μs |      - |      - |         - |
|         IteratingIEnumerable | 93.851 μs | 0.9149 μs | 0.8558 μs |      - |      - |     136 B |
| IteratingToListedIEnumerable | 10.205 μs | 0.1381 μs | 0.1292 μs | 6.3629 | 0.7935 |  40,056 B |
