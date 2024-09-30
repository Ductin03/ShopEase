namespace ShopEase.Models.ResponseModel
{
    public class CartSumResponseModel
    {      
        public List<CartResponseModel> CartResponseModels { get; set; }
        public Decimal TotalPrice { get; set; }
        
    }
}
