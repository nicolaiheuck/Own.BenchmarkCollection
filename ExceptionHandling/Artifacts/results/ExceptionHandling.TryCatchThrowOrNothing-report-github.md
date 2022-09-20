``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|        Method |     Mean |    Error |   StdDev | Allocated |
|-------------- |---------:|---------:|---------:|----------:|
|       Nothing | 32.19 ns | 0.115 ns | 0.096 ns |         - |
| TryCatchThrow | 32.63 ns | 0.153 ns | 0.143 ns |         - |
