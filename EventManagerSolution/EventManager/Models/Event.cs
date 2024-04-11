using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public bool IsEveryoneInvited { get; set; }
        public string? EventBanner { get; set; }
        public string? EventIcon { get; set; }

        [Required]
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        [ValidateNever]
        [NotMapped]
        public EventType Type { get; set; } = null!;

        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        [NotMapped]
        public ApplicationUser Coordinator { get; set; } = null!;
    }
}
