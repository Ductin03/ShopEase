namespace ShopEase.Models.RequestModels
{
    public class BasePanigationRequestModel
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
