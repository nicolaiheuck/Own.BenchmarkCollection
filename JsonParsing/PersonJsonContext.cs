using System.Text.Json.Serialization;
using Bogus;

namespace JsonParsing;

[JsonSerializable(typeof(Person))]
public partial class PersonJsonContext : JsonSerializerContext
{
    
}