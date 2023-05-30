using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Scripts;

/// <summary>
/// Script record information.
/// </summary>
public record ScriptRecord {
    /// <summary>
    /// Unique session id (created when revit is opened).
    /// </summary>
    [BsonElement("sessionid")]
    [JsonPropertyName("sessionid")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid SessionId { get; init; }

    /// <summary>
    /// Information about telemetry record.
    /// </summary>
    [BsonElement("meta")]
    [JsonPropertyName("meta")]
    public MetaRecord Meta { get; init; } = null!;

    /// <summary>
    /// When script started.
    /// </summary>
    [BsonElement("timestamp")]
    [JsonPropertyName("timestamp")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTimeOffset TimeStamp { get; init; }

    /// <summary>
    /// <a href="https://www.revitapidocs.com/2022/2a7c8664-de0d-7a43-e670-2e733e579609.htm">Username</a>
    /// who use Autodesk Revit (sets in options).
    /// </summary>
    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string UserName { get; init; } = null!;

    /// <summary>
    /// <a href="https://learn.microsoft.com/en-us/dotnet/api/system.environment.username">Username</a>
    /// who logged in Windows.
    /// </summary>
    [BsonElement("host_user")]
    [JsonPropertyName("host_user")]
    public string? HostUserName { get; init; } = null!;

    /// <summary>
    /// Internal
    /// <a href="https://www.revitapidocs.com/2022/c5963cab-c85b-561b-1ea2-b9d11b58050c.htm">build number</a>
    /// of the Autodesk Revit application.
    /// </summary>
    [BsonElement("revitbuild")]
    [JsonPropertyName("revitbuild")]
    public string RevitBuild { get; init; } = null!;

    /// <summary>
    /// Return the
    /// <a href="https://www.revitapidocs.com/2022/35b18b73-4c47-fee3-d2f9-21298f029f7f.htm">primary version</a>
    /// of the Revit application.
    /// </summary>
    [BsonElement("revit")]
    [JsonPropertyName("revit")]
    public string RevitVersion { get; init; } = null!;

    /// <summary>
    /// pyrevit build version.
    /// </summary>
    [BsonElement("pyrevit")]
    [JsonPropertyName("pyrevit")]
    public string PyRevitVersion { get; init; } = null!;

    /// <summary>
    /// pyrevit
    /// <a href="https://pyrevitlabs.notion.site/Manage-pyRevit-clones-e9f789f9431346b482021f2a87a6dabf">clone name</a>.
    /// </summary>
    [BsonElement("clone")]
    [JsonPropertyName("clone")]
    public string CloneName { get; init; } = null!;
    
    /// <summary>
    /// pyrevit
    /// <a href="https://pyrevitlabs.notion.site/Button-Click-Modes-c829c5a60ddb4c3e819bc93dfbc3c98b#a09dd3a1d0634d4eab964eec07d74286">debug mode</a>.
    /// </summary>
    [BsonElement("debug")]
    [JsonPropertyName("debug")]
    public bool IsDebugMode { get; init; }

    /// <summary>
    /// pyrevit
    /// <a href="https://pyrevitlabs.notion.site/Button-Click-Modes-c829c5a60ddb4c3e819bc93dfbc3c98b">config mode</a>.
    /// </summary>
    [BsonElement("config")]
    [JsonPropertyName("config")]
    public bool IsConfigMode { get; init; }

    /// <summary>
    /// If script was run from GUI (Click Revit Ribbon) <see langword="true" />, otherwise  <see langword="false" />.
    /// </summary>
    [BsonElement("from_gui")]
    [JsonPropertyName("from_gui")]
    public bool IsExecFromGUI { get; init; }

    /// <summary>
    /// Unique execution id.
    /// </summary>
    [BsonElement("exec_id")]
    [JsonPropertyName("exec_id")]
    public string ExecId { get; init; } = null!;

    /// <summary>
    /// When script executed.
    /// </summary>
    [BsonElement("exec_timestamp")]
    [JsonPropertyName("exec_timestamp")]
    [BsonRepresentation(BsonType.DateTime)]
    public string ExecTimeStamp { get; init; } = null!;

    /// <summary>
    /// Command bundle name.
    /// </summary>
    [BsonElement("commandbundle")]
    [JsonPropertyName("commandbundle")]
    public string BundleName { get; init; } = null!;

    /// <summary>
    /// Command extension name.
    /// </summary>
    [BsonElement("commandextension")]
    [JsonPropertyName("commandextension")]
    public string ExtensionName { get; init; } = null!;

    /// <summary>
    /// Command name.
    /// </summary>
    [BsonElement("commandname")]
    [JsonPropertyName("commandname")]
    public string CommandName { get; init; } = null!;

    /// <summary>
    /// Command unique name.
    /// </summary>
    [BsonElement("commanduniquename")]
    [JsonPropertyName("commanduniquename")]
    public string CommandUniqueName { get; init; } = null!;

    /// <summary>
    /// Document <a href="https://www.revitapidocs.com/2022/4cee7916-d799-fc83-daf3-97cb03900b72.htm">Title</a> property.
    /// </summary>
    [BsonElement("docname")]
    [JsonPropertyName("docname")]
    public string DocumentName { get; init; } = null!;

    /// <summary>
    /// Document <a href="https://www.revitapidocs.com/2022/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm">PathName</a> property.
    /// </summary>
    [BsonElement("docpath")]
    [JsonPropertyName("docpath")]
    public string DocumentPath { get; init; } = null!;

    /// <summary>
    /// Script executed result code.
    /// <br/><a href="https://www.revitapidocs.com/2022/e6cebb3c-0c3f-7dc4-2063-e5df0a00b2f5.htm">ResultCode</a> enumeration.
    /// </summary>
    [BsonElement("resultcode")]
    [JsonPropertyName("resultcode")]
    public int ResultCode { get; init; }

    /// <summary>
    /// Executed script path.
    /// </summary>
    [BsonElement("scriptpath")]
    [JsonPropertyName("scriptpath")]
    public string ScriptPath { get; init; } = null!;

    /// <summary>
    /// Information about execution.
    /// </summary>
    [BsonElement("trace")]
    [JsonPropertyName("trace")]
    public TraceInfo TraceInfo { get; init; } = null!;

    /// <summary>
    /// Additional command results.
    /// </summary>
    [BsonElement("commandresults")]
    [JsonPropertyName("commandresults")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? CommandResults { get; init; }
}