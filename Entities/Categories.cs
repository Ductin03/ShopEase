using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class Categories : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }
    }
}
