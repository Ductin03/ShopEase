using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateUserDetailsRequestModel
    {
        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(250)]
        public string Avatar { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [MaxLength(250)]
        public string Position{ get; set; }
        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
