using Microsoft.EntityFrameworkCore;

namespace Event_Sourcing_with_CQRS.AuditLog
{
    public class AuditLogDbContext : DbContext
    {
        public DbSet<AuditLogEvent> AuditLogEvents { get; set; }

        public AuditLogDbContext(DbContextOptions<AuditLogDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, constraints, etc.
        }
    }
}
