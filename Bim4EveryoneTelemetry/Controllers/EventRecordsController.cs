using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Events;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers; 

[ApiController]
[Route("api/v2/events")]
public class EventRecordsController : ControllerBase {
    private readonly ILogger<EventRecordsController> _logger;
    private readonly IDBConnectionStatus _connectionStatus;

    public EventRecordsController(ILogger<EventRecordsController> logger, IDBConnectionStatus connectionStatus) {
        _logger = logger;
        _connectionStatus = connectionStatus;
    }

    [HttpPost]
    public Task Post(EventTelemetryRecord eventTelemetryRecord) {
        _logger.LogDebug("Post event telemetry record {ScriptTelemetryRecord}", eventTelemetryRecord);
        return Task.CompletedTask;
    }
}