namespace ShopEase.Models.ResponseModel
{
    public class CartResponseModel
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
    }
}
