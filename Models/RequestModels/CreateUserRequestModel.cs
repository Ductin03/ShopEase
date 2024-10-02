using ShopEase.Models.RequestModels;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class CreateUserRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public List<CreateUserDetailsRequestModel> CreateUserDetailsRequestModel { get; set; }
  
    }
}
