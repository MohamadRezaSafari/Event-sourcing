using Event_Sourcing_with_CQRS.AuditLog;

namespace Event_Sourcing_with_CQRS.EventReplay
{
    public class EventReplayService
    {
        private readonly AuditLogDbContext _auditLogDbContext;

        public EventReplayService(AuditLogDbContext auditLogDbContext)
        {
            _auditLogDbContext = auditLogDbContext;
        }

        public IEnumerable<AuditLogEvent> GetEvents()
        {
            return _auditLogDbContext.AuditLogEvents.ToList();
        }
    }
}
