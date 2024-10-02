using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class UpdateUserRequestModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Avatar { get; set; }
        public DateTime BirthDay { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
