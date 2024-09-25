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
        public Task CreateRole(Roles roles)
        {
            _context.Roles.Add(roles);
            return Task.FromResult(true);
        }

        public Task DeleteRole(Roles role)
        {
            _context.Roles.Update(role);
            return Task.FromResult(true);
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Roles> GetByRoleId(Guid RoleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(x=>x.Id==RoleId);
        }

        public Task UpdateRole(Roles role)
        {
            _context.Roles.Update(role);
            return Task.FromResult(true);
        }
    }
}
