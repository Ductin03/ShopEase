using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateCategoryRequestModel
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public Guid SubCategoryId { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
