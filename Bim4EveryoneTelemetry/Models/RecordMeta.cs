using System.Text.Json.Serialization;

namespace Bim4EveryoneTelemetry.Models; 

public record RecordMeta(
    [property: JsonPropertyName("schema")] Version SchemaVersion);