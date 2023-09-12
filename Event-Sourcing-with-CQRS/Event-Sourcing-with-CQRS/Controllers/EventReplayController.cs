using Event_Sourcing_with_CQRS.EventReplay;
using Microsoft.AspNetCore.Mvc;

namespace Event_Sourcing_with_CQRS.Controllers
{
    [ApiController]
    [Route("api/eventreplay")]
    public class EventReplayController : ControllerBase
    {
        private readonly ReplayingEventsService _replayingEventsService;

        public EventReplayController(ReplayingEventsService replayingEventsService)
        {
            _replayingEventsService = replayingEventsService;
        }

        [HttpPost]
        public async Task<IActionResult> ReplayEvents()
        {
            await _replayingEventsService.ReplayEvents();

            return Ok("Event replay initiated");
        }
    }
}
