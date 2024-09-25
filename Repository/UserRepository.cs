using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopEaseDbContext _context;
        public UserRepository(ShopEaseDbContext context)
        {
            _context = context;
        }

        public Task CreateUser(Users users)
        {
            _context.Users.Add(users);
            return Task.FromResult(true);
        }

        public Task DeleteUser(Users users)
        {
            _context.Users.Update(users);
            return Task.FromResult(true);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetByUserId(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<Users> GetByUserName(string username)
        {
           return await _context.Users.FirstOrDefaultAsync(x=>x.UserName == username);
        }

        public async Task<string> GetRoleName(string username)
        {
            return await _context.Users.Where(u => u.UserName == username).
                                        Select(u => _context.Roles.
                                        FirstOrDefault(r => r.Id == u.RoleId).RoleName).FirstOrDefaultAsync();
        }

        public Task UpdateUser(Users users)
        {
             _context.Users.Update(users);
            return Task.FromResult(true);
        }
    }
}
