using Bim4EveryoneTelemetry.Models.Events;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Bim4EveryoneTelemetry.Models.Connections.MongoDB;

internal class MongoDBConnection : IDBConnectionStatus, IRepository<ScriptRecord>, IRepository<EventRecord> {
    private readonly ILogger<MongoDBConnection> _logger;
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<EventRecord> _eventsCollection;
    private readonly IMongoCollection<ScriptRecord> _scriptCollection;

    public MongoDBConnection(ILogger<MongoDBConnection> logger, IOptions<MongoDBSettings> mongoDBSettings) {
        _logger = logger;
        
        _mongoClient = new MongoClient(
            mongoDBSettings.Value.ConnectionString + $"/?authSource={mongoDBSettings.Value.DatabaseName}");

        _mongoDatabase = _mongoClient.GetDatabase(
            mongoDBSettings.Value.DatabaseName);

        _eventsCollection = _mongoDatabase.GetCollection<EventRecord>(
            mongoDBSettings.Value.EventsCollectionName);
        
        _scriptCollection = _mongoDatabase.GetCollection<ScriptRecord>(
            mongoDBSettings.Value.ScriptsCollectionName);
    }

    public string ConnectionName => "mongodb";

    public ConnectionStatus GetConnectionStatus() {
        var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument() {{"buildInfo", 1}});
        var version = _mongoDatabase.RunCommand(command)["version"];
        return new ConnectionStatus(Status: "pass", Version: new Version(version.AsString));
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