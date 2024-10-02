using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class OrderModel
    {
        [Required]
        public Guid UserId { get; set; }
        public List<OrderRequestModel> OrderModels { get; set; }
    }
}
