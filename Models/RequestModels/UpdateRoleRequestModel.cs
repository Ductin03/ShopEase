using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class UpdateRoleRequestModel
    {
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        [MaxLength(250)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }
    }
}
