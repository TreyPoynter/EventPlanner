using EventManager.Models.DomainModels;
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
                .WithMany()
                .HasForeignKey(eu => eu.UserId);

            builder
                .HasOne(i => i.Event)
                .WithMany()
                .HasForeignKey(ei => ei.EventId);

            builder.Property(e => e.InterestLevel).IsRequired();
        }
    }
}
