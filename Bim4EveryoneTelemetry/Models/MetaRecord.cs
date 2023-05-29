using System.Text.Json.Serialization;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models;

/// <summary>
/// Record metadata.
/// </summary>
public record MetaRecord {
    /// <summary>
    /// Schema version.
    /// </summary>
    [BsonElement("schema")]
    [JsonPropertyName("schema")]
    public Version SchemaVersion { get; init; } = null!;
}