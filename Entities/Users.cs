using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class Users : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

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

        [MaxLength(250)]
        [Required]
        public string Avatar {  get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [MaxLength(250)]
        [Required]
        public string Address { get; set; }
    }
}
