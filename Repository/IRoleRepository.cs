using ClothingStore.Entities;

namespace ClothingStore.Repository
{
    public interface IRoleRepository
    {
        Task CreateRole(Roles roles);
        Task<List<Roles>> GetAllRoles();
        Task<Roles> GetByRoleId(Guid RoleId);
        Task DeleteRole(Roles role);
        Task UpdateRole(Roles role);
        
    }
}
