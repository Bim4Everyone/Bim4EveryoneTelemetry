using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

public record ScriptRecord {
    [BsonElement("sessionid")]
    [JsonPropertyName("sessionid")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid SessionId { get; init; }

    [BsonElement("meta")]
    [JsonPropertyName("meta")]
    public MetaRecord Meta { get; init; } = null!;

    [BsonElement("status")]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

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

    [BsonElement("pyrevit")]
    [JsonPropertyName("pyrevit")]
    public string PyRevitVersion { get; init; } = null!;

    [BsonElement("clone")]
    [JsonPropertyName("clone")]
    public string CloneName { get; init; } = null!;

    [BsonElement("debug")]
    [JsonPropertyName("debug")]
    public bool IsDebugMode { get; init; }

    [BsonElement("config")]
    [JsonPropertyName("config")]
    public bool IsConfigMode { get; init; }

    [BsonElement("from_gui")]
    [JsonPropertyName("from_gui")]
    public bool IsExecFromGUI { get; init; }

    [BsonElement("exec_id")]
    [JsonPropertyName("exec_id")]
    public string ExecId { get; init; } = null!;

    [BsonElement("exec_timestamp")]
    [JsonPropertyName("exec_timestamp")]
    public string ExecTimeStamp { get; init; } = null!;

    [BsonElement("commandbundle")]
    [JsonPropertyName("commandbundle")]
    public string BundleName { get; init; } = null!;

    [BsonElement("commandextension")]
    [JsonPropertyName("commandextension")]
    public string ExtensionName { get; init; } = null!;

    [BsonElement("commandname")]
    [JsonPropertyName("commandname")]
    public string CommandName { get; init; } = null!;

    [BsonElement("commanduniquename")]
    [JsonPropertyName("commanduniquename")]
    public string CommandUniqueName { get; init; } = null!;

    [BsonElement("docname")]
    [JsonPropertyName("docname")]
    public string DocumentName { get; init; } = null!;

    [BsonElement("docpath")]
    [JsonPropertyName("docpath")]
    public string DocumentPath { get; init; } = null!;

    [BsonElement("resultcode")]
    [JsonPropertyName("resultcode")]
    public int ResultCode { get; init; }

    [BsonElement("scriptpath")]
    [JsonPropertyName("scriptpath")]
    public string ScriptPath { get; init; } = null!;

    [BsonElement("trace")]
    [JsonPropertyName("trace")]
    public TraceInfo TraceInfo { get; init; } = null!;

    [BsonElement("commandresults")]
    [JsonPropertyName("commandresults")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? CommandResults { get; init; }
}