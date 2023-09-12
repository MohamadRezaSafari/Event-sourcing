using Microsoft.EntityFrameworkCore;

namespace Event_Sourcing_with_CQRS.Infrastructure.DbContexts
{
    public class AppReadDbContext : DbContext
    {
        public AppReadDbContext(DbContextOptions<AppReadDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductReadModel> ProductReadModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReadModel>()
                .Property(i => i.Id)
                .ValueGeneratedNever();
        }
    }
}
