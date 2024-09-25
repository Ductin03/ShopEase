namespace ShopEase.Models.RequestModels
{
    public class ProductAtributeRequestModel
    {
        public Guid ProductId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
