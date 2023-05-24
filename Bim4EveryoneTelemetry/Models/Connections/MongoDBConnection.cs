using Bim4EveryoneTelemetry.Models.Events;
using Bim4EveryoneTelemetry.Models.Scripts;

namespace Bim4EveryoneTelemetry.Models.Connections;

public class MongoDBConnection : IDBConnectionStatus, IRepository<ScriptRecord>, IRepository<EventRecord> {
    private readonly ILogger<MongoDBConnection> _logger;

    public MongoDBConnection(ILogger<MongoDBConnection> logger) {
        _logger = logger;
    }

    public string ConnectionName => "mongodb";

    public ConnectionStatus GetConnectionStatus() {
        return new ConnectionStatus(Status: "pass", Version: new Version("1.0.0"));
    }

    public Task Create(ScriptRecord item) {
        return Task.CompletedTask;
    }

    public Task Create(EventRecord item) {
        return Task.CompletedTask;
    }

    public Task Save() {
        return Task.CompletedTask;
    }
}