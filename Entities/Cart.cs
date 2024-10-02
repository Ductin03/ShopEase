using ClothingStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
