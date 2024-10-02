using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        [Required]
        public Decimal Price { get; set; }



    }
}
