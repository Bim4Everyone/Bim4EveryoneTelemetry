using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.Models.Scripts;

namespace Bim4EveryoneTelemetry.Models.Events; 

public record EventRecord(
    RecordMeta Meta,
    DateTimeOffset TimeStamp,
    [property: JsonPropertyName("handler_id")] Guid HandlerId,
    [property: JsonPropertyName("type")] string EventType,
    [property: JsonPropertyName("args")] Dictionary<string, object> EventArgs,
    string UserName,
    [property: JsonPropertyName("host_user")] string HostUserName,
    [property: JsonPropertyName("revit")] Version RevitVersion,
    Version RevitBuild,
    bool Cancellable,
    bool Cancelled,
    [property: JsonPropertyName("docid")] int DocumentId,
    [property: JsonPropertyName("doctype")] string DocumentType,
    [property: JsonPropertyName("doctemplate")] string DocumentTemplate,
    [property: JsonPropertyName("docname")] string DocumentName,
    [property: JsonPropertyName("docpath")] string DocumentPath,
    [property: JsonPropertyName("projectnum")] string ProjectNumber,
    string ProjectName);