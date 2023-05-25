using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;
using Bim4EveryoneTelemetry.Models.Scripts;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Events;

public record EventRecord {
    [BsonElement("handler_id")]
    [JsonPropertyName("handler_id")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid HandlerId { get; init; }

    [BsonElement("meta")]
    [JsonPropertyName("meta")]
    public MetaRecord Meta { get; init; } = null!;

    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string EventType { get; init; } = null!;

    [BsonElement("status")]
    [JsonPropertyName("status")]
    public string? Status { get; init; } = null!;

    [BsonElement("timestamp")]
    [JsonPropertyName("timestamp")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTimeOffset TimeStamp { get; init; }

    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string UserName { get; init; } = null!;

    [BsonElement("host_user")]
    [JsonPropertyName("host_user")]
    public string? HostUserName { get; init; } = null!;

    [BsonElement("revitbuild")]
    [JsonPropertyName("revitbuild")]
    public string RevitBuild { get; init; } = null!;

    [BsonElement("revit")]
    [JsonPropertyName("revit")]
    public string RevitVersion { get; init; } = null!;

    [BsonElement("cancelled")]
    [JsonPropertyName("cancelled")]
    public bool? Cancelled { get; init; }

    [BsonElement("cancellable")]
    [JsonPropertyName("cancellable")]
    public bool? Cancellable { get; init; }

    [BsonElement("docid")]
    [JsonPropertyName("docid")]
    public int DocumentId { get; init; }

    [BsonElement("doctype")]
    [JsonPropertyName("doctype")]
    public string? DocumentType { get; init; } = null!;

    [BsonElement("doctemplate")]
    [JsonPropertyName("doctemplate")]
    public string? DocumentTemplate { get; init; } = null!;

    [BsonElement("docname")]
    [JsonPropertyName("docname")]
    public string? DocumentName { get; init; } = null!;

    [BsonElement("docpath")]
    [JsonPropertyName("docpath")]
    public string? DocumentPath { get; init; } = null!;

    [BsonElement("projectname")]
    [JsonPropertyName("projectname")]
    public string? ProjectName { get; init; }

    [BsonElement("projectnum")]
    [JsonPropertyName("projectnum")]
    public string? ProjectNumber { get; init; }

    [BsonElement("args")]
    [JsonPropertyName("args")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? EventArgs { get; init; } = null!;
}