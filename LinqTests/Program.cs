using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace LinqTests;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<IEnumerableVsList>();
    }
}
[MemoryDiagnoser]
public class IEnumerableVsList
{
    private List<int> _intList = new();
    private IEnumerable<int> _intIEnumerable = new List<int>();
    private readonly List<int> _intListToAdd = new();
    private IEnumerable<int> _intIEnumerableToAdd = new List<int>();
    private int _result = 0;

    [GlobalSetup]
    public void Setup()
    {
        Random random = new Random();
        for (int i = 0; i < 10_000; i++)
        {
            int randomValue = random.Next(0, int.MaxValue);
            _intList.Add(randomValue);
        }

        _intIEnumerable = _intIEnumerable.Concat(_intList);
        _intListToAdd.AddRange(_intList.Take(10));
        _intIEnumerableToAdd = _intIEnumerable.Take(10);
    }


    #region SingleFiltering
    // [Benchmark]
    // public void SingleFilteringList()
    // {
    //     _result = (int)_intList.Where(i => i > 100)
    //                            .Average();
    // }
    // [Benchmark]
    // public void SingleFilteringIEnumerable()
    // {
    //     _result = (int)_intIEnumerable.Where(i => i > 100)
    //                                   .Average();
    // }
    #endregion

    #region MultipleFiltersList
    // [Benchmark]
    // public void MultipleFiltersList()
    // {
    //     _result = (int)_intList.Where(i => i > 100)
    //                            .Where(i => i < int.MaxValue - 2000)
    //                            .Select(i => i % 284747)
    //                            .Average();
    // }
    // [Benchmark]
    // public void MultipleFiltersIEnumerable()
    // {
    //     _result = (int)_intIEnumerable.Where(i => i > 100)
    //                                   .Where(i => i < int.MaxValue - 2000)
    //                                   .Select(i => i % 284747)
    //                                   .Average();
    // }
    #endregion

    #region IEnumerable.Concat vs List.AddRange
    // [Benchmark]
    // public void IEnumerableConcat_AddedList()
    // {
    //     _intIEnumerable = _intIEnumerable.Concat(_intListToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intListToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intListToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intListToAdd.ToList());
    //     _intIEnumerable = new List<int>(_intListToAdd);
    // }
    // [Benchmark]
    // public void ListAddRange_AddedList()
    // {
    //     _intList.AddRange(_intListToAdd.ToList());
    //     _intList.AddRange(_intListToAdd.ToList());
    //     _intList.AddRange(_intListToAdd.ToList());
    //     _intList.AddRange(_intListToAdd.ToList());
    //     _intList = new List<int>(_intListToAdd);
    // }
    // [Benchmark]
    // public void IEnumerableConcat_AddedIEnumerable()
    // {
    //     _intIEnumerable = _intIEnumerable.Concat(_intIEnumerableToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intIEnumerableToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intIEnumerableToAdd.ToList());
    //     _intIEnumerable = _intIEnumerable.Concat(_intIEnumerableToAdd.ToList());
    //     _intIEnumerable = new List<int>(_intListToAdd);
    // }
    // [Benchmark]
    // public void ListAddRange_AddedIEnumerable()
    // {
    //     _intList.AddRange(_intIEnumerableToAdd.ToList());
    //     _intList.AddRange(_intIEnumerableToAdd.ToList());
    //     _intList.AddRange(_intIEnumerableToAdd.ToList());
    //     _intList.AddRange(_intIEnumerableToAdd.ToList());
    //     _intList = new List<int>(_intListToAdd);
    // }
    #endregion

    #region Iteration
    [Benchmark]
    public void IteratingList()
    {
        int sum = 0;
        foreach (int i in _intList)
        {
            sum += i;
        }
    
        _result = sum;
    }
    [Benchmark]
    public void IteratingIEnumerable()
    {
        int sum = 0;
        foreach (int i in _intIEnumerable)
        {
            sum += i;
        }
    
        _result = sum;
    }
    [Benchmark]
    public void IteratingToListedIEnumerable()
    {
        int sum = 0;
        foreach (int i in _intIEnumerable.ToList())
        {
            sum += i;
        }
    
        _result = sum;
    }
    #endregion

    #region Concat IEnumerable vs List
    // [Benchmark]
    // public void IEnumerableConcat_AddedList()
    // {
    //     _intIEnumerable = _intIEnumerable.Concat(_intListToAdd)
    //                                      .Concat(_intListToAdd)
    //                                      .Concat(_intListToAdd)
    //                                      .Concat(_intListToAdd)
    //                                      .Concat(_intListToAdd)
    //                                      .ToList();
    //
    //     _intIEnumerable = new List<int>(_intListToAdd);
    // }
    // [Benchmark]
    // public void ListAddRange_AddedList()
    // {
    //     _intList = _intList.Concat(_intListToAdd)
    //                        .Concat(_intListToAdd)
    //                        .Concat(_intListToAdd)
    //                        .Concat(_intListToAdd)
    //                        .Concat(_intListToAdd)
    //                        .ToList();
    //
    //     _intList = new List<int>(_intListToAdd);
    // }
    #endregion
}