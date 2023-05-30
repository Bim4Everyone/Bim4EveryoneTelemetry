using System.Reflection;

using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/scripts")]
public class ScriptRecordsController : ControllerBase {
    private readonly ILogger<ScriptRecordsController> _logger;
    private readonly IRepository<ScriptRecord> _scriptRepository;

    public ScriptRecordsController(ILogger<ScriptRecordsController> logger, IRepository<ScriptRecord> scriptRepository) {
        _logger = logger;
        _scriptRepository = scriptRepository;
    }

    [HttpPost]
    public Task Post(ScriptRecord scriptRecord) {
        return _scriptRepository.CreateAsync(scriptRecord);
    }
}