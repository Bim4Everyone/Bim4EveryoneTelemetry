using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models;

/// <summary>
/// Log event record class.
/// </summary>
public record LogEventRecord {
    /// <summary>
    /// The time at which the event occurred.
    /// </summary>
    [BsonElement("timestamp")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>
    /// The level of the event.
    /// </summary>
    [BsonElement("log_level")]
    public string Level { get; init; } = null!;

    /// <summary>
    /// The message template describing the event.
    /// </summary>
    [BsonElement("message_template")]
    public string MessageTemplate { get; init; } = null!;

    /// <summary>
    /// The render message describing the event.
    /// </summary>
    [BsonElement("rendered_message")]
    public string RenderedMessage { get; init; } = null!;

    /// <summary>
    /// An exception associated with the event, or null.
    /// </summary>
    [BsonElement("exception")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? Exception { get; init; }

    /// <summary>
    /// Revit Session Id (unique revit start instance)
    /// </summary>
    [BsonElement("session_id")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid SessionId { get; init; }

    /// <summary>
    /// Revit plugin name.
    /// </summary>
    [BsonElement("plugin_name")]
    public string PluginName { get; init; } = null!;

    /// <summary>
    /// Revit Plugin Session Id  (unique revit plugin start instance)
    /// </summary>
    [BsonElement("plugin_session_id")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid PluginSessionId { get; init; }

    /// <summary>
    /// Environment UserName
    /// </summary>
    [BsonElement("environment_username")]
    public string EnvironmentUserName { get; init; } = null!;

    /// <summary>
    /// Environment MachineName
    /// </summary>
    [BsonElement("environment_machinename")]
    public string EnvironmentMachineName { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2017.1/04ef312a-e25a-cbcd-40c4-43fe6311e677.htm">VersionBuild</a> property.
    /// </summary>
    [BsonElement("revit_build")]
    public string RevitBuild { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2017.1/320391bf-2c21-98ca-192c-da1d9becff11.htm">VersionNumber</a> property.
    /// </summary>
    [BsonElement("revit_version")]
    public string RevitVersion { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2017.1/2b1d8b80-a11c-2a57-63bd-6c0d67691879.htm">Language</a> property.
    /// </summary>
    [BsonElement("revit_language")]
    public string RevitLanguage { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2017.1/2a7c8664-de0d-7a43-e670-2e733e579609.htm">Username</a> property.
    /// </summary>
    [BsonElement("revit_username")]
    public string? RevitUserName { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2017.1/4cee7916-d799-fc83-daf3-97cb03900b72.htm">Document.Title</a> property.
    /// </summary>
    [BsonElement("doc_title")]
    public string? RevitDocumentTitle { get; init; } = null!;

    /// <summary>
    /// Revit <a href="https://www.revitapidocs.com/2022/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm">Document.PathName</a> property.
    /// </summary>
    [BsonElement("doc_pathname")]
    public string? RevitDocumentPathName { get; init; } = null!;

    /// <summary>
    /// Revit ModelPath property.
    /// <br/>If <a href="https://www.revitapidocs.com/2020/e12f7980-ba6c-2e72-6687-f0bf807ff014.htm">Document.IsModelInCloud</a> is true <a href="https://www.revitapidocs.com/2020/087a7c14-1a6e-7022-c47b-923e90f4c5be.htm">Document.GetCloudModelPath()</a>.
    /// <br/>If <a href="https://www.revitapidocs.com/2017.1/7f368167-6543-9be9-67a3-c6e1696ae060.htm">Document.IsWorkshared</a> is true <a href="https://www.revitapidocs.com/2017.1/6d42ee05-5738-8685-2165-57f9809f3161.htm">Document.GetWorksharingCentralModelPath()</a>.
    /// </summary>
    [BsonElement("doc_modelpath")]
    public string? RevitDocumentModelPath { get; init; } = null!;

    /// <summary>
    /// Dynamic properties data.
    /// </summary>
    [BsonElement("log_event")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? LogEvent { get; init; } = null!;
}