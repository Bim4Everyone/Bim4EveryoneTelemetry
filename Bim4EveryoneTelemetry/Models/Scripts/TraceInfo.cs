using System.Text.Json.Serialization;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

public record TraceInfo {
    [BsonElement("message")]
    [JsonPropertyName("message")]
    public string Message { get; init; } = null!;

    [BsonElement("engine")]
    [JsonPropertyName("engine")]
    public EngineInfo Engine { get; init; } = null!;
}