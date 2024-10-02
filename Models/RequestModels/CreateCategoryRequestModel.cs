using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateCategoryRequestModel
    {
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public Guid SubCategoryId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public Guid? UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
