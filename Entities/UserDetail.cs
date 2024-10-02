using ClothingStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Entities
{
    public class UserDetail: BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }
        [MaxLength(250)]
        [Required]
        public string Address { get; set; }
        [MaxLength(250)]
        [Required]
        public string Position { get; set; }
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        public string Avartar { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
        [Required]
        public string Gender { get; set; }
        
    }
}
