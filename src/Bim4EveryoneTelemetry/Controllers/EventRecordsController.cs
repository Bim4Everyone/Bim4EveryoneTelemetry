using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Events;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers; 

/// <summary>
/// Event records controller.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/events")]
public class EventRecordsController : ControllerBase {
    private readonly ILogger<EventRecordsController> _logger;
    private readonly IRepository<EventRecord> _eventRepository;

    /// <summary>
    /// Creates script records controller.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="eventRepository">Event repository.</param>
    public EventRecordsController(ILogger<EventRecordsController> logger, IRepository<EventRecord> eventRepository) {
        _logger = logger;
        _eventRepository = eventRepository;
    }

    /// <summary>
    /// Adds event record to DB.
    /// </summary>
    /// <param name="eventRecord">Adding event records.</param>
    /// <returns>Returns adding event records task.</returns>
    [HttpPost]
    public Task Post(EventRecord eventRecord) {
        return _eventRepository.CreateAsync(eventRecord);
    }
}