using ClothingStore.Entities;

namespace ClothingStore.Repository
{
    public interface IRoleRepository
    {
        Task CreateRole(Role roles);
        Task<List<Role>> GetAllRoles();
        Task<Role> GetByRoleId(Guid RoleId);
        Task DeleteRole(Role role);
        Task UpdateRole(Role role);
        
    }
}
