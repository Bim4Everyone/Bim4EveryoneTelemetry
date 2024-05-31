namespace Bim4EveryoneTelemetry.Models; 

/// <summary>
/// DB connection status interface.
/// </summary>
public interface IDBConnectionStatus {
    /// <summary>
    /// Returns connection name.
    /// </summary>
    string ConnectionName { get; }
    
    /// <summary>
    /// Returns connection status.
    /// </summary>
    /// <returns>Returns connection status.</returns>
    ConnectionStatus GetConnectionStatus();
}