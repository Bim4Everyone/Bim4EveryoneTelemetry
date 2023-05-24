using System.Reflection;

using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers;

[ApiController]
[Route("api/v2/scripts")]
public class ScriptRecordsController : ControllerBase {
    private readonly ILogger<ScriptRecordsController> _logger;
    private readonly IDBConnectionStatus _connectionStatus;

    public ScriptRecordsController(ILogger<ScriptRecordsController> logger, IDBConnectionStatus connectionStatus) {
        _logger = logger;
        _connectionStatus = connectionStatus;
    }

    [HttpPost]
    public Task Post(ScriptTelemetryRecord scriptTelemetryRecord) {
        _logger.LogDebug("Post script telemetry record {ScriptTelemetryRecord}", scriptTelemetryRecord);
        return Task.CompletedTask;
    }
}