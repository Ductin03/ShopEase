namespace ShopEase.Models.RequestModels
{
    public class UpdateProductRequestModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Decimal Price { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid SellerId { get; set; }
    }
}
