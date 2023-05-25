using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts; 

public record EngineInfo(string Type, string Version, string[]? SysPaths, 
    [property:JsonConverter(typeof(DynamicDataJsonConverter))]
    [property:BsonSerializer(typeof(DynamicDataBsonSerializer))]
    string? Configs);