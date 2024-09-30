namespace ShopEase.Models.ResponseModel
{
    public class OrderSumResponseRequestModel
    {
        
        public List<OrderResponseModel> OrderResponse { get; set; }
        public decimal Total { get; set; }
    }
}
