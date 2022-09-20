``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.978/21H2)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                                  Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|---------------------------------------- |---------:|---------:|---------:|-------:|----------:|
|               InitializationOfOneObject | 28.03 ns | 0.057 ns | 0.053 ns | 0.0038 |      24 B |
|             InitializationOfFiveObjects | 45.19 ns | 0.279 ns | 0.261 ns | 0.0191 |     120 B |
|   InitializationOfOneObjectSingleMethod | 27.50 ns | 0.254 ns | 0.237 ns | 0.0038 |      24 B |
| InitializationOfFiveObjectsSingleMethod | 44.94 ns | 0.269 ns | 0.252 ns | 0.0191 |     120 B |
