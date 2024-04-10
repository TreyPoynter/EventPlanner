using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(e => e.Type).WithMany(t => t.Events);
            builder.HasOne(e => e.User).WithMany(t => t.Events)
                .HasForeignKey(e => e.UserId);
        }
    }
}
