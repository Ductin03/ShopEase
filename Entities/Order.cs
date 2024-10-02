using ClothingStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public Guid ODerId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Decimal Price { get; set; }
        public DateTime OderTime { get; set; }
        public string Status { get; set; }
    }
}
