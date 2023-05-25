using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

public record EngineInfo {
    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    [BsonElement("version")]
    [JsonPropertyName("version")]
    public string Version { get; init; } = null!;

    [BsonElement("syspath")]
    [JsonPropertyName("syspath")]
    public string[]? SysPaths { get; init; }

    [BsonElement("configs")]
    [JsonPropertyName("configs")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? Configs { get; init; }
}