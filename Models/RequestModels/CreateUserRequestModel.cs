using ShopEase.Models.RequestModels;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class CreateUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid CreateBy { get; set; }

        public bool IsDeleted { get; set; }
        public List<CreateUserDetailsRequestModel> CreateUserDetailsRequestModel { get; set; }
  
    }
}
