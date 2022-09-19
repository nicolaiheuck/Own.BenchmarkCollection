using System.Text.Json.Serialization;

namespace JsonParsing;

[JsonSerializable(typeof(Room))]
public partial class RoomJsonContext : JsonSerializerContext
{
    
}
