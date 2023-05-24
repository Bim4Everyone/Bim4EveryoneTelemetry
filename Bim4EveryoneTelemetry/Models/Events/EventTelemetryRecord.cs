using Bim4EveryoneTelemetry.Models.Scripts;

namespace Bim4EveryoneTelemetry.Models.Events; 

public record EventTelemetryRecord(
    RecordMeta Meta,
    DateTimeOffset TimeStamp,
    Guid HandlerId,
    string EventType,
    Dictionary<string, object> EventArgs,
    string UserName,
    string HostUserName,
    Version RevitVersion,
    Version RevitBuild,
    bool Cancellable,
    bool Cancelled,
    int DocumentId,
    string DocumentType,
    string DocumentTemplate,
    string DocumentName,
    string DocumentPath,
    string ProjectNumber,
    string ProjectName);