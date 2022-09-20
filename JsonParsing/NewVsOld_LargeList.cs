using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using Bogus;
using Bogus.DataSets;
using Newtonsoft.Json;

namespace JsonParsing;

[Obsolete("WARNING: This benchmark is REALLY SLOW (about 9 minutes)")]
[MarkdownExporterAttribute.GitHub]
public class NewVsOld_LargeList
{
    // |                 Method |       Mean |    Error |    StdDev | Ratio | RatioSD |
    // |----------------------- |-----------:|---------:|----------:|------:|--------:|
    // |          OldSerializer |   875.6 ms |  7.88 ms |   6.98 ms |  1.50 |    0.02 |
    // |        OldDeserializer | 2,815.9 ms | 29.42 ms |  27.52 ms |  4.83 |    0.07 |
    // |          NewSerializer |   583.6 ms |  4.15 ms |   3.68 ms |  1.00 |    0.00 |
    // |        NewDeserializer | 2,799.0 ms | 13.41 ms |  11.19 ms |  4.80 |    0.03 |
    // |   NewtonsoftSerializer | 1,987.1 ms | 23.02 ms |  20.41 ms |  3.41 |    0.05 |
    // | NewtonsoftDeserializer | 4,233.1 ms | 81.34 ms | 108.58 ms |  7.35 |    0.16 |
        
    private static Room _room = new();
    private static string _roomJson;

    #region Setup
    [GlobalSetup]
    public void Setup()
    {
        Console.WriteLine("Starting Setup");
        using (new TimedExecution("setup"))
        {
            _roomJson = File.ReadAllText(@"C:\Users\Googlelai\RiderProjects\BenchmarkCollection\JsonParsing\bin\Release\net6.0\data.json");
            _room = System.Text.Json.JsonSerializer.Deserialize<Room>(_roomJson);
        }
    }
    public static List<Person> GetFakePeopleData()
    {
        Faker<Person> personFaker = new Faker<Person>()
                                    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                                    .RuleFor(p => p.LastName, f => f.Person.LastName)
                                    .RuleFor(p => p.PhoneNumber, f => f.Person.LastName)
                                    .RuleFor(p => p.EmailAddress, f => f.Person.LastName)
                                    .RuleFor(p => p.Gender, f => f.Person.Gender == Name.Gender.Male)
                                    .RuleFor(p => p.Age, f => (int)f.Finance.Amount(0, 100))
                                    .RuleFor(p => p.Addresses, f => f.Make(3, () => f.Person.Address.Street));

        List<Person> people = new();
        for (int i = 0; i < 1_000_000; i++)
        {
            Person person = personFaker.Generate();
            people.Add(person);
            if (i % 10000 == 0)
            {
                Console.Write($"\r{i}");
            }
        }

        return people;
    }
    #endregion

    #region Old
    [BenchmarkCategory("Old"), Benchmark]
    public void OldSerializer()
    {
        string data = System.Text.Json.JsonSerializer.Serialize(_room);
    }
    [BenchmarkCategory("Old"), Benchmark]
    public void OldDeserializer()
    {
        Room data = System.Text.Json.JsonSerializer.Deserialize<Room>(_roomJson);
    }
    #endregion

    #region New
    [BenchmarkCategory("New"), Benchmark(Baseline = true)]
    public void NewSerializer()
    {
        string data = System.Text.Json.JsonSerializer.Serialize(_room, RoomJsonContext.Default.Room);
    }
    [BenchmarkCategory("New"), Benchmark]
    public void NewDeserializer()
    {
        Room data = System.Text.Json.JsonSerializer.Deserialize(_roomJson, RoomJsonContext.Default.Room);
    }
    #endregion

    #region Newtonsoft
    [BenchmarkCategory("Newtonsoft"), Benchmark]
    public void NewtonsoftSerializer()
    {
        string data = JsonConvert.SerializeObject(_room);
    }
    [BenchmarkCategory("Newtonsoft"), Benchmark]
    public void NewtonsoftDeserializer()
    {
        Room data = JsonConvert.DeserializeObject<Room>(_roomJson);
    }
    #endregion
}