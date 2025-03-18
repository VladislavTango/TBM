using Microsoft.EntityFrameworkCore;
using QuarterService.Domain.Entities;

namespace QuarterService.DataPersistance.AppContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<FuturesDifference> FuturesDifference { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
