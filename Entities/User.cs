using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class User : BaseEntity
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
    }
}
