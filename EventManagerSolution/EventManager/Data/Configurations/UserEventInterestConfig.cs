using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configurations
{
    public class UserEventInterestConfig : IEntityTypeConfiguration<UserEventInterest>
    {
        public void Configure(EntityTypeBuilder<UserEventInterest> builder)
        {
            builder.HasKey(
                ei => new { ei.UserId, ei.EventId });

            builder
                .HasOne(e => e.User)
                .WithMany(u => u.EventInterests)
                .HasForeignKey(eu => eu.UserId);

            builder
                .HasOne(i => i.Event)
                .WithMany(e => e.InterestedUsers)
                .HasForeignKey(ei => ei.EventId);
        }
    }
}
