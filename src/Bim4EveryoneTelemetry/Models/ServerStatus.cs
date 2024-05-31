namespace Bim4EveryoneTelemetry.Models;

/// <summary>
/// Server status information.
/// </summary>
/// <param name="Status">Connection status (pass or fail).</param>
/// <param name="ServiceId">Service unique id.</param>
/// <param name="Version">Service version.</param>
/// <param name="Checks">Check information.</param>
public record ServerStatus(string Status, Guid ServiceId, Version Version, Dictionary<string, ConnectionStatus> Checks);