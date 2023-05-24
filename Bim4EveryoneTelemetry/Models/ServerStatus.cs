namespace Bim4EveryoneTelemetry.Models;

public record ServerStatus(string Status, Guid ServiceId, Version Version, Dictionary<string, ConnectionStatus> Checks);