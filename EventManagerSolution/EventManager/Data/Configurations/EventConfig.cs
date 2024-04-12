using EventManager.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(e => e.Type).WithMany(t => t.Events);
            builder.HasOne(e => e.Coordinator).WithMany(t => t.Events)
                .HasForeignKey(e => e.UserId);
        }
    }
}
