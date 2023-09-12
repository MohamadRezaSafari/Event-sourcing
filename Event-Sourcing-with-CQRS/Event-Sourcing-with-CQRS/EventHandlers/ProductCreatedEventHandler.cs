using Event_Sourcing_with_CQRS.AuditLog;
using Event_Sourcing_with_CQRS.Events;
using MediatR;
using System.Text.Json;

namespace Event_Sourcing_with_CQRS.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly AuditLogDbContext _auditLogDbContext;

        public ProductCreatedEventHandler(AuditLogDbContext auditLogDbContext)
        {
            _auditLogDbContext = auditLogDbContext;
        }

        public async Task Handle(ProductCreatedEvent notification, 
            CancellationToken cancellationToken)
        {
            // Process the event logic
            // ...

            // Store the event in the audit log
            var auditLogEvent = new AuditLogEvent
            {
                EventType = "ProductCreated",
                Timestamp = DateTime.UtcNow,
                User = "MBARK",
                EventData = JsonSerializer.Serialize(notification)
            };

            _auditLogDbContext.AuditLogEvents.Add(auditLogEvent);
            await _auditLogDbContext.SaveChangesAsync();
        }
    }
}
