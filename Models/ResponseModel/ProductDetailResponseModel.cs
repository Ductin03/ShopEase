namespace ShopEase.Models.ResponseModel
{
    public class ProductDetailResponseModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }     
        public Decimal Price { get; set; }
        public string Seller { get; set; }
        public string Description { get; set; }
        public List<RatingReponseModel> Rating { get; set; }
    }
}
