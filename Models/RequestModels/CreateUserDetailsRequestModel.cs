using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ShopEase.Models.RequestModels
{
    public class CreateUserDetailsRequestModel
    {
        
        public string FullName { get; set; }    
        public string Phone { get; set; }
        public string Avatar { get; set; }

        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public string Position{ get; set; }
        public string Gender { get; set; }

        public Guid CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
