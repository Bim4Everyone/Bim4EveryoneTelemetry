using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;
using Bim4EveryoneTelemetry.Models.Scripts;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Events; 

public record EventRecord(
    RecordMeta Meta,
    string TimeStamp,
    string? Status,
    [property: JsonPropertyName("handler_id")] Guid HandlerId,
    [property: JsonPropertyName("type")]
    string EventType,
    [property: JsonPropertyName("args")]
    [property:JsonConverter(typeof(DynamicDataJsonConverter))]
    [property:BsonSerializer(typeof(DynamicDataBsonSerializer))]
    string? EventArgs,
    string UserName,
    [property: JsonPropertyName("host_user")] string? HostUserName,
    [property: JsonPropertyName("revit")] string RevitVersion,
    string RevitBuild,
    bool? Cancellable,
    bool? Cancelled,
    [property: JsonPropertyName("docid")] int DocumentId,
    [property: JsonPropertyName("doctype")] string? DocumentType,
    [property: JsonPropertyName("doctemplate")] string? DocumentTemplate,
    [property: JsonPropertyName("docname")] string? DocumentName,
    [property: JsonPropertyName("docpath")] string? DocumentPath,
    [property: JsonPropertyName("projectnum")] string? ProjectNumber,
    string? ProjectName);