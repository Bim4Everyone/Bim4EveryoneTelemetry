using System.Reflection;

using Bim4EveryoneTelemetry.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers;

/// <summary>
/// Route status controller.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/status")]
public class RouteStatusController : ControllerBase {
    private readonly ILogger<RouteStatusController> _logger;

    private readonly Guid _serviceId = Guid.NewGuid();
    private readonly IDBConnectionStatus _connectionStatus;

    /// <summary>
    /// Creates route status controller.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="connectionStatus">Connection status.</param>
    public RouteStatusController(ILogger<RouteStatusController> logger, IDBConnectionStatus connectionStatus) {
        _logger = logger;
        _connectionStatus = connectionStatus;
    }

    /// <summary>
    /// Returns connection status.
    /// </summary>
    /// <returns>Returns connection status.</returns>
    [HttpGet]
    public ServerStatus Get() {
        return new ServerStatus(Status: "pass", ServiceId: _serviceId,
            Version: Assembly.GetExecutingAssembly().GetName().Version ?? new Version(),
            Checks: new Dictionary<string, ConnectionStatus>() {
                {_connectionStatus.ConnectionName, _connectionStatus.GetConnectionStatus()}
            });
    }
}