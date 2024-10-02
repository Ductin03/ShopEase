using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class ForgetPasswordRequestModel
    {
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        public string OTP { get; set; }
    }
}
