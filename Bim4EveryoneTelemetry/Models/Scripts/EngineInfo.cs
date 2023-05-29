using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

/// <summary>
/// Script engine information.
/// </summary>
public record EngineInfo {
    /// <summary>
    /// Engine type name.
    /// https://pyrevitlabs.notion.site/Engines-7973ca3328c34fd1a95462f5c655475b
    /// </summary>
    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    /// <summary>
    /// Engine version.
    /// https://pyrevitlabs.notion.site/Engines-7973ca3328c34fd1a95462f5c655475b
    /// </summary>
    [BsonElement("version")]
    [JsonPropertyName("version")]
    public string Version { get; init; } = null!;

    /// <summary>
    /// System paths using by script.
    /// </summary>
    [BsonElement("syspath")]
    [JsonPropertyName("syspath")]
    public string[]? SysPaths { get; init; }

    /// <summary>
    /// Dynamic script configs data.
    /// </summary>
    [BsonElement("configs")]
    [JsonPropertyName("configs")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? Configs { get; init; }
}