using System.Text.Json.Serialization;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

/// <summary>
/// Script executed information.
/// </summary>
public record TraceInfo {
    /// <summary>
    /// Script executed message.
    /// https://www.revitapidocs.com/2022/ab42c8d3-d361-88d2-5043-2d427d1238fc.htm
    /// </summary>
    [BsonElement("message")]
    [JsonPropertyName("message")]
    public string Message { get; init; } = null!;

    /// <summary>
    /// Script engine information.
    /// </summary>
    [BsonElement("engine")]
    [JsonPropertyName("engine")]
    public EngineInfo Engine { get; init; } = null!;
}