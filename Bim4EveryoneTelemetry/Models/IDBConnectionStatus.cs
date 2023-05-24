namespace Bim4EveryoneTelemetry.Models; 

public interface IDBConnectionStatus {
    string ConnectionName { get; }
    ConnectionStatus GetConnectionStatus();
}