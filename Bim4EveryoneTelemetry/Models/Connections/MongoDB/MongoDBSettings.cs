namespace Bim4EveryoneTelemetry.Models.Connections.MongoDB;

public class MongoDBSettings {
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string EventsCollectionName { get; set; } = null!;
    public string ScriptsCollectionName { get; set; } = null!;
}