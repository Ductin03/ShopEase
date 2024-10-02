using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class OrderRequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public DateTime OderTime { get; set; }
        [Required]
        [MaxLength(250)]
        public string status { get; set; }
    }
}
