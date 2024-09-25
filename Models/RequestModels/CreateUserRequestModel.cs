using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class CreateUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid RoleId { get; set; }
        public string Avatar { get; set; }

        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
