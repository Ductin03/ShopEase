using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class CreateRoleRequestModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public bool IsDeleted { get; set; }

    }
}
