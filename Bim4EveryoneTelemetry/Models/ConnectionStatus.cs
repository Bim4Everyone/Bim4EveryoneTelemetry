namespace Bim4EveryoneTelemetry.Models; 

public class ConnectionStatus {
    public required string Status { get; init; }
    public required Version Version { get; init; }
}