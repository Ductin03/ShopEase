using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class BasePanigationRequestModel
    {
        [MaxLength(250)]
        public string? Keyword { get; set; }
        [Range(0, 100)]
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
