using System.Text.Json.Serialization;

namespace Bim4EveryoneTelemetry.Models.Scripts; 

public record ScriptRecord(
    RecordMeta Meta,
    DateTimeOffset TimeStamp,
    string UserName,
    [property: JsonPropertyName("host_user")] string HostUserName,
    [property: JsonPropertyName("revit")] Version RevitVersion,
    Version RevitBuild,
    Guid SessionId,
    [property: JsonPropertyName("pyrevit")] Version PyRevitVersion,
    [property: JsonPropertyName("clone")] string CloneName,
    [property: JsonPropertyName("debug")] bool IsDebugMode,
    [property: JsonPropertyName("config")]bool IsConfigMode,
    [property: JsonPropertyName("from_gui")]bool IsExecFromGUI,
    [property: JsonPropertyName("exec_id")] Guid ExecId,
    [property: JsonPropertyName("exec_timestamp")] DateTimeOffset ExecTimeStamp,
    string CommandName,
    string CommandUniqueName,
    [property: JsonPropertyName("commandbundle")] string BundleName,
    [property: JsonPropertyName("commandextension")] string ExtensionName,
    [property: JsonPropertyName("docname")] string DocumentName,
    [property: JsonPropertyName("docpath")] string DocumentPath,
    int ResultCode,
    Dictionary<string, object> CommandResults,
    string ScriptPath,
    [property: JsonPropertyName("trace")] TraceInfo TraceInfo);