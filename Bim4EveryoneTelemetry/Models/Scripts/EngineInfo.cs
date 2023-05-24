namespace Bim4EveryoneTelemetry.Models.Scripts; 

public record EngineInfo(string Type, Version Version, string[] SysPaths, Dictionary<string, object> Configs);