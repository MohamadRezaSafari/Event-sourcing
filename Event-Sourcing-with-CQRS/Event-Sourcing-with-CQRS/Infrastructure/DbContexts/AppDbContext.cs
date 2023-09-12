using Event_Sourcing_with_CQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace Event_Sourcing_with_CQRS.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        public AppDbContext(
            //IConfiguration configuration,
            DbContextOptions<AppDbContext> options) : base(options)
        {
            //Configuration = configuration;  
        }

        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(Configuration.GetConnectionString("AppDbContext"));
        //    // options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"));
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure entity mappings and relationships
        //    // ...
        //}
    }
}
