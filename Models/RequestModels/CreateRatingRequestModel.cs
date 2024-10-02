using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateRatingRequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [Range(0, 5)]
        public int Point { get; set; }
        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
