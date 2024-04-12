using EventManager.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configurations
{
    public class TypeConfig : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasData(
                new EventType() { EventTypeId = 1, Name = "Wedding" },
                new EventType() { EventTypeId = 2, Name = "Birthday Party" },
                new EventType() { EventTypeId = 3, Name = "Conference" },
                new EventType() { EventTypeId = 4, Name = "Music Concert" },
                new EventType() { EventTypeId = 5, Name = "Charity Gala" },
                new EventType() { EventTypeId = 6, Name = "Product Launch" },
                new EventType() { EventTypeId = 7, Name = "Gathering" },
                new EventType() { EventTypeId = 8, Name = "Sports Event" });
        }
    }
}
