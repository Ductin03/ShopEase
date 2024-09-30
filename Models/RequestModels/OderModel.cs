namespace ShopEase.Models.RequestModels
{
    public class OderModel
    {
        public Guid UserId { get; set; }
        public List<OrderRequestModel> OrderModels { get; set; }
    }
}
