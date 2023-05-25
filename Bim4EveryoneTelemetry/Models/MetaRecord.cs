using System.Text.Json.Serialization;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models;

public record MetaRecord {
    [BsonElement("schema")]
    [JsonPropertyName("schema")]
    public Version SchemaVersion { get; init; } = null!;
}