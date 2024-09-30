namespace ShopEase.Models.RequestModels
{
    public class AddCartRequestModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreateBy { get; set; }  
        public bool IsDeleted { get; set; }
    }
}
