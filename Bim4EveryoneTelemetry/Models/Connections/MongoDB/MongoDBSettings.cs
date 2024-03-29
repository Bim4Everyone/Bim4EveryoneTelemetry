namespace Bim4EveryoneTelemetry.Models.Connections.MongoDB;

internal class MongoDBSettings {
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string EventsCollectionName { get; set; } = null!;
    public string ScriptsCollectionName { get; set; } = null!;
    public string LogEventsCollectionName { get; set; } = null!;
}