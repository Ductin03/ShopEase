using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class UpdateRatingRequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Range(0, 5)]
        public int Point { get; set; }
        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
