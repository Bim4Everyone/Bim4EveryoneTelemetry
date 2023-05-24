using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Events;

using Microsoft.AspNetCore.Mvc;

namespace Bim4EveryoneTelemetry.Controllers; 

[ApiController]
[Route("api/v2/events")]
public class EventRecordsController : ControllerBase {
    private readonly ILogger<EventRecordsController> _logger;
    private readonly IRepository<EventRecord> _eventRepository;

    public EventRecordsController(ILogger<EventRecordsController> logger, IRepository<EventRecord> eventRepository) {
        _logger = logger;
        _eventRepository = eventRepository;
    }

    [HttpPost]
    public Task Post(EventRecord eventRecord) {
        return _eventRepository.Create(eventRecord);
    }
}