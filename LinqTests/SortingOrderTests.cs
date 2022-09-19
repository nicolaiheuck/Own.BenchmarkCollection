using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Denmark;

namespace LinqTests;

[MemoryDiagnoser]
public class SortingOrderTests
{
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

        _people = personFaker.Generate(10_000);
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

    [Benchmark(Baseline = true)]
    public void Default()
    {
        Person person = _people
                        .Where(p => p.CPR.Contains("0"))
                        .Where(p => p.Gender == true)
                        .Where(p => p.FirstName.Contains("T"))
                        .Where(p => p.Age > 30)
                        .Where(p => p.Age < 50)
                        .Where(p => p.LastName.Contains("U"))
                        .FirstOrDefault();
    }
    [Benchmark]
    public void Default_OneBigFirstOrDefault()
    {
        Person person = _people.FirstOrDefault(p => p.CPR.Contains("0") &&
                                               p.Gender == true &&
                                               p.FirstName.Contains("T") &&
                                               p.Age > 30 &&
                                               p.Age < 50 &&
                                               p.LastName.Contains("U"));
    }
    [Benchmark]
    public void Default_OneBigWhere()
    {
        Person person = _people
                        .Where(p => p.CPR.Contains("0") &&
                               p.Gender == true &&
                               p.FirstName.Contains("T") &&
                               p.Age > 30 &&
                               p.Age < 50 &&
                               p.LastName.Contains("U"))
                        .FirstOrDefault();
    }
    [Benchmark]
    public void Default_OneBigWhere_DifferentOrder()
    {
        Person person = _people
                        .Where(p => p.FirstName.Contains("T") &&
                               p.LastName.Contains("U") &&
                               p.Gender == true &&
                               p.CPR.Contains("0") &&
                               p.Age > 30 &&
                               p.Age < 50)
                        .FirstOrDefault();
    }
}