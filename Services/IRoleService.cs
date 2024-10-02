using ClothingStore.Entities;
using ClothingStore.Models.RequestModels;
using ShopEase.Models.RequestModels;

namespace ClothingStore.Services
{
    public interface IRoleService
    {
        Task Role(CreateRoleRequestModel model);
        Task<List<Role>> GetAllRolesAsync();
        Task DeleteRoleAsync(Guid roleId);
        Task UpdateRoleAsync(UpdateRoleRequestModel model);
       
    }
}
