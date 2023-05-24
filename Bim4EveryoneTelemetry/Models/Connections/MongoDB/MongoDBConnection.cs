using Bim4EveryoneTelemetry.Models.Events;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace Bim4EveryoneTelemetry.Models.Connections.MongoDB;

public class MongoDBConnection : IDBConnectionStatus, IRepository<ScriptRecord>, IRepository<EventRecord> {
    private readonly ILogger<MongoDBConnection> _logger;
    private readonly IMongoCollection<EventRecord> _eventsCollection;
    private readonly IMongoCollection<ScriptRecord> _scriptCollection;

    public MongoDBConnection(ILogger<MongoDBConnection> logger, IOptions<MongoDBSettings> mongoDBSettings) {
        _logger = logger;
        
        var mongoClient = new MongoClient(
            mongoDBSettings.Value.ConnectionString + $"/?authSource={mongoDBSettings.Value.DatabaseName}");

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDBSettings.Value.DatabaseName);

        _eventsCollection = mongoDatabase.GetCollection<EventRecord>(
            mongoDBSettings.Value.EventsCollectionName);
        
        _scriptCollection = mongoDatabase.GetCollection<ScriptRecord>(
            mongoDBSettings.Value.ScriptsCollectionName);
    }

    public string ConnectionName => "mongodb";

    public ConnectionStatus GetConnectionStatus() {
        return new ConnectionStatus(Status: "pass", Version: new Version("1.0.0"));
    }

    public async Task CreateAsync(ScriptRecord item) {
        await _scriptCollection.InsertOneAsync(item);
    }

    public async Task CreateAsync(EventRecord item) {
        await _eventsCollection.InsertOneAsync(item);
    }

    public Task Save() {
        return Task.CompletedTask;
    }
}