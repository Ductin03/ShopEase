namespace ShopEase.Models.RequestModels
{
    public class UpdateRoleRequestModel
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }
    }
}
