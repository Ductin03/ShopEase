namespace ShopEase.Models.RequestModels
{
    public class UpdateCategoryRequestModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public Guid SubCategoryId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

    }
}
