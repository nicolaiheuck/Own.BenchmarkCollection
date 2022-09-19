using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace LinqTests;

[MemoryDiagnoser(true), CategoriesColumn]
public class FilterLambdaVsMethod
{
    private const string _a = "A";
    private const string _b = "B";
    private List<string> _list;
    public string C { get; set; }
    public List<string> Output { get; set; } = new();

    [GlobalSetup]
    public void SetupSeedData()
    {
        _list = Enumerable.Range(0, 200)
                          .Select(c => c.ToString())
                          .ToList();

        _predicate = a => a.StartsWith("1");
    }

    #region Method no method
    [Benchmark, BenchmarkCategory("Method no method")]
    public void Method()
    {
        C = Process(_a, _b);
    }
    [Benchmark, BenchmarkCategory("Method no method")]
    public void NoMethod()
    {
        C = _a + _b;
    }
    private string Process(string a, string b)
    {
        return a + b;
    }
    #endregion

    #region Filter Method vs lambda
    [Benchmark, BenchmarkCategory("Filter Method vs lambda")]
    public void FilterLambda()
    {
        C = _list.FirstOrDefault(a => a != "2");
    }
    [Benchmark, BenchmarkCategory("Filter Method vs lambda")]
    public void FilterMethod()
    {
        C = _list.FirstOrDefault(PrivateFilterMethod);
    }
    private static bool PrivateFilterMethod(string a)
    {
        return a != "2";
    }
    #endregion

    #region Predicate vs hard-coding
    [Benchmark, BenchmarkCategory("Predicate vs hard-coded")]
    public void HardCoded()
    {
        foreach (string item in _list)
        {
            if (item.StartsWith("1"))
            {
                Output.Add(item);
            }
        }
    }
    private Predicate<string> _predicate;
    [Benchmark, BenchmarkCategory("Predicate vs hard-coded")]
    public void Predicate()
    {
        foreach (string item in _list)
        {
            if (_predicate(item))
            {
                Output.Add(item);
            }
        }
    }
    
    #endregion
}