using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class ProductAtributeRequestModel
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(250)]
        public string AttributeName { get; set; }
        [Required]
        [MaxLength(250)]
        public string AttributeValue { get; set; }
    }
}
