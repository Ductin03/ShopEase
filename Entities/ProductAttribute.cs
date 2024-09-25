using ClothingStore.Entities;

namespace ShopEase.Entities
{
    public class ProductAttribute
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; } 
        public string AttributeName { get; set; } = string.Empty; 
        public string AttributeValue { get; set; } = string.Empty; 
    }
}
