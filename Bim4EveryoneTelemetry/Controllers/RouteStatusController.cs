using System.Reflection;

using Bim4EveryoneTelemetry.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers;

[ApiController]
[Route("api/v2/status")]
public class RouteStatusController : ControllerBase {
    private readonly ILogger<RouteStatusController> _logger;
    private readonly IDBConnectionStatus _connectionStatus;

    public RouteStatusController(ILogger<RouteStatusController> logger, IDBConnectionStatus connectionStatus) {
        _logger = logger;
        _connectionStatus = connectionStatus;
    }

    [HttpGet]
    public ServerStatus Get() {
        return new ServerStatus(Status: "pass", ServiceId: Guid.NewGuid(),
            Version: Assembly.GetExecutingAssembly().GetName().Version ?? new Version(),
            Checks: new Dictionary<string, ConnectionStatus>() {
                {_connectionStatus.ConnectionName, _connectionStatus.GetConnectionStatus()}
            });
    }
}