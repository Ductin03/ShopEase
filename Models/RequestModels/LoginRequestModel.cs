using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class LoginRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string username { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }
    }
}
