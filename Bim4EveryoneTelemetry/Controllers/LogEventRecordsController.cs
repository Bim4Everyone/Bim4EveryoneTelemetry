using Bim4EveryoneTelemetry.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers; 

/// <summary>
/// Logs records controller.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/logs")]
public class LogEventRecordsController {
    private readonly ILogger<LogEventRecordsController> _logger;
    private readonly IRepository<LogEventRecord> _logRepository;

    /// <summary>
    /// Creates log event records controller.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="logRepository">Log event repository.</param>
    public LogEventRecordsController(ILogger<LogEventRecordsController> logger, IRepository<LogEventRecord> logRepository) {
        _logger = logger;
        _logRepository = logRepository;
    }

    /// <summary>
    /// Adds log event record to DB.
    /// </summary>
    /// <param name="logEventRecord">Adding log event records.</param>
    /// <returns>Returns adding log event records task.</returns>
    [HttpPost]
    public Task Post(LogEventRecord logEventRecord) {
        return _logRepository.CreateAsync(logEventRecord);
    }
}