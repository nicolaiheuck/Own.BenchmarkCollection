using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Denmark;

namespace LinqTests;

[MemoryDiagnoser]
public class LinqCount
{
    #region Setup
    [Params(100, 10000)]
    public int Size { get; set; }

    private List<Person> _people;
    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> personFaker = new Faker<Person>()
                                    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                                    .RuleFor(p => p.LastName, f => f.Person.LastName)
                                    .RuleFor(p => p.Age, f => (int)f.Finance.Amount(0, 100))
                                    .RuleFor(p => p.Address, f => $"{f.Person.Address.City}, {f.Person.Address.Street}")
                                    .RuleFor(p => p.Gender, f => f.Person.Gender == Name.Gender.Male)
                                    .RuleFor(p => p.CPR, f => f.Person.Cpr());

        _people = personFaker.Generate(Size);
        _people.Add(new()
        {
            Age = 42,
            Address = "localhost",
            Gender = true,
            FirstName = "Test",
            LastName = "User",
            CPR = "123456-7890"
        });
    }
    #endregion

    [Benchmark(Baseline = true)]
    public void DirectCount()
    {
        int total = _people.Count(p => p.Age > 30);
    }
    [Benchmark]
    public void Manual_CountUsingEnumerator()
    {
        int total = _people.ManualCountUsingEnumerator(p => p.Age > 30);
    }

    
    // [Benchmark]
    public void Manual_CountUsingToList()
    {
        int total = _people.ManualCountUsingToList(p => p.Age > 30);
    }
    
    #region Fast ones
    // [Benchmark]
    // public void WhereThenCount()
    // {
    //     int total = _people.Where(p => p.Age > 30)
    //                        .Count();
    // }
    [Benchmark]
    public void MyCount_Proxy()
    {
        int total = _people.FastCount(p => p.Age > 30);
    }
    #endregion
}