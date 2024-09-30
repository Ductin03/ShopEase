namespace ShopEase.Models.RequestModels
{
    public class OrderRequestModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime OderTime { get; set; }
        public string status { get; set; }
    }
}
