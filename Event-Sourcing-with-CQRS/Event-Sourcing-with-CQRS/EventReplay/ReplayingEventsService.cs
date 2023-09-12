using Event_Sourcing_with_CQRS.AuditLog;
using Event_Sourcing_with_CQRS.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event_Sourcing_with_CQRS.EventReplay
{
    public class ReplayingEventsService
    {
        private readonly AuditLogDbContext _auditLogDbContext;
        private readonly IMediator _mediator;

        public ReplayingEventsService(AuditLogDbContext auditLogDbContext, 
            IMediator mediator)
        {
            _auditLogDbContext = auditLogDbContext;
            _mediator = mediator;
        }

        public async Task ReplayEvents()
        {
            var events = await _auditLogDbContext.AuditLogEvents.ToListAsync();

            foreach (var auditLogEvent in events)
            {
                // Determine the event type and execute the corresponding event handler
                switch (auditLogEvent.EventType)
                {
                    case "ProductCreated":
                        var productCreatedEvent = new ProductCreatedEvent
                        {
                            // Populate the event properties based on the event data
                            // ...
                            IsReplay = true
                        };
                        await _mediator.Publish(productCreatedEvent);
                        break;

                    // Handle other event types...

                    default:
                        // Unknown event type
                        break;
                }
            }
        }
    }
}
