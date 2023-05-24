namespace Bim4EveryoneTelemetry.Models;

public record ServerStatus {
    public required string Status { get; init; }
    public required Guid ServiceId { get; init; }
    public required Version Version { get; init; }
    public required Dictionary<string, ConnectionStatus> Checks { get; set; }
}