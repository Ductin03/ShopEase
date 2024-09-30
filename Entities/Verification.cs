using System.ComponentModel.DataAnnotations;

namespace ShopEase.Entities
{
    public class Verification
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [MaxLength(50)]
        public string Otp { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
