using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models.DomainModels
{
    public class EventViewModel : Event
    {
        [ValidateNever]
        public IFormFile BannerImage { get; set; }
        [ValidateNever]
        public IFormFile IconImage { get; set; }
    }
}
