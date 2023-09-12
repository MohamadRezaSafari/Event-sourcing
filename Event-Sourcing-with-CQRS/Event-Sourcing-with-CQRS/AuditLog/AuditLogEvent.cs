namespace Event_Sourcing_with_CQRS.AuditLog
{
    public class AuditLogEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string EventData { get; set; }
    }
}
