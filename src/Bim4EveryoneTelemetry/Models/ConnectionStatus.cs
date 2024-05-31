namespace Bim4EveryoneTelemetry.Models; 

/// <summary>
/// Connection status information.
/// </summary>
/// <param name="Status">Connection status (pass or fail).</param>
/// <param name="Version">Connection version.</param>
public record ConnectionStatus(string Status, Version Version);