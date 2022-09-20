``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                 Method |       Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------- |-----------:|---------:|---------:|------:|--------:|
|          OldSerializer | 1,003.9 ms |  8.33 ms |  7.38 ms |  1.43 |    0.02 |
|        OldDeserializer | 2,941.3 ms | 12.77 ms | 11.95 ms |  4.19 |    0.06 |
|          NewSerializer |   702.7 ms |  9.73 ms |  9.11 ms |  1.00 |    0.00 |
|        NewDeserializer | 2,905.2 ms | 54.72 ms | 53.74 ms |  4.14 |    0.08 |
|   NewtonsoftSerializer | 2,090.7 ms | 13.04 ms | 12.20 ms |  2.98 |    0.04 |
| NewtonsoftDeserializer | 4,386.5 ms | 31.31 ms | 29.29 ms |  6.24 |    0.09 |
