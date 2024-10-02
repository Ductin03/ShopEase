using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class MailRequest
    {
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250)]
        public string EmailBody { get; set; }
    }
}
