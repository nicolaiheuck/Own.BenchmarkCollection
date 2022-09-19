using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace JsonParsing;

[MemoryDiagnoser, CategoriesColumn]
public class NewVsOld_SingleObject
{
    private Person _seedPerson;
    private Person2 _seedPerson2;

    [GlobalSetup]
    public void SetupSeedPerson()
    {
        _seedPerson = new()
        {
            Age = 5,
            Gender = false,
            EmailAddress = "firstName.LastName@Company_Name.extension",
            FirstName = "Test user testersen",
            LastName = "the third",
            PhoneNumber = "12398738383",
            Addresses = new()
            {
                "Localhost 19, 5.1, North Korea, Earth",
                "Some randomsens street 84, 3.7, United states, Earth",
                "Another randomsen street 5, Elon mushian, Mars",
            }
        };
        _seedPerson2 = new()
        {
            Msdfkj = 5,
            Pslkddslkf = false,
            Uskdjnkj = "fkjghdiurghe4983498gn",
            Asd = "39u84erjygo9i8ue435n",
            Askjds = "846846654511",
            Ksdlkfs = "6erd1fgv1g6er3",
            Isdlkf = new()
            {
                "4edsz5rgvb4se685gb41ser69h8b51serth869bsr",
                "6esrd8f4vgb635erf84bg6er35g418e63g4163sg45185e6g41",
                "96s8dr4gv1563ERDSFDSF468531651465Sdfsdfsdf651653sd56f1s65df1s6",
            }
        };
    }

    #region Old
    [BenchmarkCategory("Old"), Benchmark(Baseline = true)]
    public void OldSerializer()
    {
        string result = System.Text.Json.JsonSerializer.Serialize(_seedPerson2);
    }
    [BenchmarkCategory("Old"), Benchmark]
    public void OldDeserializer()
    {
        Person2 result = System.Text.Json.JsonSerializer.Deserialize<Person2>(JsonDataConstants.SinglePerson2);
    }
    #endregion

    #region Compiled json serialization
    [BenchmarkCategory("New"), Benchmark]
    public void NewSerializer()
    {
        string result = System.Text.Json.JsonSerializer.Serialize(_seedPerson, PersonJsonContext.Default.Person);
    }
    [BenchmarkCategory("New"), Benchmark]
    public void NewDeserializer()
    {
        Person result = System.Text.Json.JsonSerializer.Deserialize(JsonDataConstants.SinglePerson, PersonJsonContext.Default.Person);
    }
    #endregion

    #region Newtonsoft
    [BenchmarkCategory("Newtonsoft"), Benchmark]
    public void NewtonsoftSerializer()
    {
        string result = JsonConvert.SerializeObject(_seedPerson2);
    }
    [BenchmarkCategory("Newtonsoft"), Benchmark]
    public void NewtonsoftDeserializer()
    {
        Person result = JsonConvert.DeserializeObject<Person>(JsonDataConstants.SinglePerson2);
    }
    #endregion
}