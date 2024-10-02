using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models.RequestModels
{
    public class CreateRoleRequestModel
    {
        [Required]
        [MaxLength(250)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

    }
}
