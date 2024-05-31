using System.Reflection;

using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers;

/// <summary>
/// Script records controller.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/scripts")]
public class ScriptRecordsController : ControllerBase {
    private readonly ILogger<ScriptRecordsController> _logger;
    private readonly IRepository<ScriptRecord> _scriptRepository;

    /// <summary>
    /// Creates script records controller.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="scriptRepository">Script records controller.</param>
    public ScriptRecordsController(ILogger<ScriptRecordsController> logger, IRepository<ScriptRecord> scriptRepository) {
        _logger = logger;
        _scriptRepository = scriptRepository;
    }

    /// <summary>
    /// Adds script record to DB.
    /// </summary>
    /// <param name="scriptRecord">Adding script records.</param>
    /// <returns>Returns adding script records task.</returns>
    [HttpPost]
    public Task Post(ScriptRecord scriptRecord) {
        return _scriptRepository.CreateAsync(scriptRecord);
    }
}