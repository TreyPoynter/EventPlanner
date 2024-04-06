using EventManager.Data.Configurations;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventInterest> UserEventInterests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new UserEventInterestConfig());
            modelBuilder.ApplyConfiguration(new TypeConfig());
        }
    }
}
