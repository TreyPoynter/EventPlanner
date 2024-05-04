using EventManager.Data.Configurations;
using EventManager.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventInterest> UserEventInterests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new UserEventInterestConfig());
            modelBuilder.ApplyConfiguration(new TypeConfig());
        }
    }
}
