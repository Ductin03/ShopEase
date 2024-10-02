using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ShopEaseDbContext _context;
        public RoleRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public Task CreateRole(Role roles)
        {
            _context.Roles.Add(roles);
            return Task.FromResult(true);
        }

        public Task DeleteRole(Role role)
        {
            _context.Roles.Update(role);
            return Task.FromResult(true);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByRoleId(Guid RoleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(x=>x.Id==RoleId);
        }

        public Task UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return Task.FromResult(true);
        }
    }
}
