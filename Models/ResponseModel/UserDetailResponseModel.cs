using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.ResponseModel
{
    public class UserDetailResponseModel
    {
        public Guid UserId { get; set; }
 
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Avartar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
