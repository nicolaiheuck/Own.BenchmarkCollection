using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Bogus;
using Bogus.DataSets;
using Newtonsoft.Json;

namespace JsonParsing;

public class NewVsOld_MediumSizedList
{
    private static Room _room = new();
    private static string _roomJson;

    #region Setup
    [GlobalSetup]
    public void Setup()
    {
        _room = new()
        {
            RoomNumber = 42,
            People = GetFakePeopleData()
        };
        _roomJson = System.Text.Json.JsonSerializer.Serialize(_room);
    }
    private static List<Person> GetFakePeopleData()
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
        for (int i = 0; i < 1000; i++)
        {
            Person person = personFaker.Generate();
            people.Add(person);
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