using System.Text.Json.Serialization;

using Bim4EveryoneTelemetry.JsonConverters;

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
    [BsonElement("render_message")]
    public string RenderMessage { get; init; } = null!;
    
    /// <summary>
    /// An exception associated with the event, or null.
    /// </summary>
    [BsonElement("exception")]
    public Exception? Exception { get; init; }
    
    /// <summary>
    /// Dynamic properties data.
    /// </summary>
    [BsonElement("properties")]
    [JsonConverter(typeof(DynamicDataJsonConverter))]
    [BsonSerializer(typeof(DynamicDataBsonSerializer))]
    public string LogEventProperties { get; init; } = null!;
}