using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;
using Bim4EveryoneTelemetry.Models.Scripts;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bim4EveryoneTelemetry.Models.Events;

/// <summary>
/// Event record information.
/// </summary>
public record EventRecord {
    /// <summary>
    /// Unique event id.
    /// </summary>
    [BsonElement("handler_id")]
    [JsonPropertyName("handler_id")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid HandlerId { get; init; }

    /// <summary>
    /// Information about telemetry record.
    /// </summary>
    [BsonElement("meta")]
    [JsonPropertyName("meta")]
    public MetaRecord Meta { get; init; } = null!;

    /// <summary>
    /// Event type name.
    /// </summary>
    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string EventType { get; init; } = null!;

    /// <summary>
    /// Revit event
    /// <a href="https://www.revitapidocs.com/2022/a739b1f8-6b3b-a95b-b536-6e5d00d12e4e.htm">status</a>.
    /// </summary>
    [BsonElement("status")]
    [JsonPropertyName("status")]
    public string? Status { get; init; } = null!;

    /// <summary>
    /// When event started.
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
    /// If event was cancelled <see langword="true" />, otherwise  <see langword="false" />.
    /// <br/>RevitAPIEventArgs <a href="https://www.revitapidocs.com/2022/5627aeaa-9d9c-dcbe-b34f-db40f1c025be.htm">IsCancelled</a> method.
    /// </summary>
    [BsonElement("cancelled")]
    [JsonPropertyName("cancelled")]
    public bool? Cancelled { get; init; }

    /// <summary>
    /// If event can cancel <see langword="true" />, otherwise  <see langword="false" />.
    /// <br/>RevitAPIEventArgs <a href="https://www.revitapidocs.com/2022/a393138a-34b5-1724-aa69-92cef651482b.htm">Cancellable</a> property.
    /// 
    /// </summary>
    [BsonElement("cancellable")]
    [JsonPropertyName("cancellable")]
    public bool? Cancellable { get; init; }

    /// <summary>
    /// Id of the document that has just been closed.
    /// <br/>DocumentClosingEventArgs <a href="https://www.revitapidocs.com/2022/c1f2fa0f-0071-caef-34d7-b966458fc60b.htm">DocumentId</a> property.
    /// <br/>DocumentClosedEventArgs <a href="https://www.revitapidocs.com/2022/b9c0620b-817c-c85e-322e-c56cc942eda2.htm">DocumentId</a> property.
    /// </summary>
    [BsonElement("docid")]
    [JsonPropertyName("docid")]
    public int DocumentId { get; init; }

    /// <summary>
    /// Type of the document, e.g. Project or Template.
    /// <br/><a href="https://www.revitapidocs.com/2022/f980a45e-61f3-de6e-9af3-9277d5537b4b.htm">DocumentType</a> enumeration.
    /// <br/>DocumentOpeningEventArgs <a href="https://www.revitapidocs.com/2022/0d94b412-5685-dd91-7cae-e987e0e2ebbb.htm">DocumentType</a> property.
    /// <br/>DocumentCreatingEventArgs <a href="https://www.revitapidocs.com/2022/a7986733-b89f-3cb3-0e60-96c2a1beb1f5.htm">DocumentType</a> property.
    /// </summary>
    [BsonElement("doctype")]
    [JsonPropertyName("doctype")]
    public string? DocumentType { get; init; } = null!;

    /// <summary>
    /// Document template name.
    /// <br/>DocumentCreatingEventArgs <a href="https://www.revitapidocs.com/2022/634fd76a-8466-b705-b20d-b5a0c7303a80.htm">Template</a> property.
    /// </summary>
    [BsonElement("doctemplate")]
    [JsonPropertyName("doctemplate")]
    public string? DocumentTemplate { get; init; } = null!;

    /// <summary>
    /// Document <a href="https://www.revitapidocs.com/2022/4cee7916-d799-fc83-daf3-97cb03900b72.htm">Title</a> property.
    /// </summary>
    [BsonElement("docname")]
    [JsonPropertyName("docname")]
    public string? DocumentName { get; init; } = null!;

    /// <summary>
    /// Document <a href="https://www.revitapidocs.com/2022/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm">PathName</a> property.
    /// </summary>
    [BsonElement("docpath")]
    [JsonPropertyName("docpath")]
    public string? DocumentPath { get; init; } = null!;

    /// <summary>
    /// Project name
    /// <a href="https://www.revitapidocs.com/2022/fb011c91-be7e-f737-28c7-3f1e1917a0e0.htm">(BuiltInParameter.PROJECT_NAME)</a>.
    /// </summary>
    [BsonElement("projectname")]
    [JsonPropertyName("projectname")]
    public string? ProjectName { get; init; }

    /// <summary>
    /// Project number
    /// <a href="https://www.revitapidocs.com/2022/fb011c91-be7e-f737-28c7-3f1e1917a0e0.htm">(BuiltInParameter.PROJECT_NUMBER)</a>.
    /// </summary>
    [BsonElement("projectnum")]
    [JsonPropertyName("projectnum")]
    public string? ProjectNumber { get; init; }

    /// <summary>
    /// Dynamic event args data.
    /// </summary>
    [BsonElement("args")]
    [JsonPropertyName("args")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string? EventArgs { get; init; } = null!;
}