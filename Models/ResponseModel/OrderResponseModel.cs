using ShopEase.Entities;

namespace ShopEase.Models.ResponseModel
{
    public class OrderResponseModel
    { 
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }  
    }
}
