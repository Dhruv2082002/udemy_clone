using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy_clone.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string Title { get; set; }

        public string? Thumbnail { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
        public int Duration { get; set; }

        public int Price { get; set; }

        //fk to application user
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}
