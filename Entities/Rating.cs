using ClothingStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Entities
{
    public class Rating : BaseEntity
    {
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

    }
}
