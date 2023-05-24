namespace Bim4EveryoneTelemetry.Models; 

public class MongoDBConnection : IDBConnectionStatus {
    public string ConnectionName => "mongodb";
    public ConnectionStatus GetConnectionStatus() {
        return new ConnectionStatus() {Status = "pass", Version = new Version("1.0.0")};
    }
}