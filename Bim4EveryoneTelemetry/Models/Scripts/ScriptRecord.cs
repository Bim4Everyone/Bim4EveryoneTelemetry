using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts; 

public record ScriptRecord(
    RecordMeta Meta,
    string TimeStamp,
    string? Status,
    string UserName,
    [property: JsonPropertyName("host_user")] string? HostUserName,
    [property: JsonPropertyName("revit")] string RevitVersion,
    string RevitBuild,
    Guid SessionId,
    [property: JsonPropertyName("pyrevit")] string PyRevitVersion,
    [property: JsonPropertyName("clone")] string CloneName,
    [property: JsonPropertyName("debug")] bool IsDebugMode,
    [property: JsonPropertyName("config")]bool IsConfigMode,
    [property: JsonPropertyName("from_gui")]bool IsExecFromGUI,
    [property: JsonPropertyName("exec_id")] string ExecId,
    [property: JsonPropertyName("exec_timestamp")] string ExecTimeStamp,
    string CommandName,
    string CommandUniqueName,
    [property: JsonPropertyName("commandbundle")] string BundleName,
    [property: JsonPropertyName("commandextension")] string ExtensionName,
    [property: JsonPropertyName("docname")] string DocumentName,
    [property: JsonPropertyName("docpath")] string DocumentPath,
    int ResultCode,
    [property:JsonConverter(typeof(DynamicDataJsonConverter))]
    [property:BsonSerializer(typeof(DynamicDataBsonSerializer))]
    string? CommandResults,
    string ScriptPath,
    [property: JsonPropertyName("trace")] TraceInfo TraceInfo);