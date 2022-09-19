
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.978/21H2)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


|Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|-------------------------- |---------:|---------:|---------:|-------:|----------:|
| InitializationOfOneObject | 25.81 ns | 0.416 ns | 0.389 ns | 0.0038 |      24 B |
