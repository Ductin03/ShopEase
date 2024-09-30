using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

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

        public Task CreateUserDetails(UserDetails userDetails)
        {
            _context.UserDetails.Add(userDetails);
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

        public async Task<BasePanigationResponModel<Users>> GetAllUsers(GetUserRequestModel getUserRequestModel)
        {
            var query= _context.Users as IQueryable<Users>;
            if (!string.IsNullOrWhiteSpace(getUserRequestModel.Keyword))
            {
                query= query.Where(x=>x.UserName.Contains(getUserRequestModel.Keyword));
            }
            query = query.OrderByDescending(x => x.CreateDate);

            var total = await query.CountAsync();
            if (getUserRequestModel.PageSize > 0)
            {
                query=query.Skip(getUserRequestModel.PageIndex*getUserRequestModel.PageSize).Take(getUserRequestModel.PageSize);
            }
            var items = await query.ToListAsync();

            return new BasePanigationResponModel<Users>(getUserRequestModel.PageIndex,getUserRequestModel.PageSize,total,items);
                
        }

        public async Task<Users> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
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

        public async Task<List<UserDetails>> userDetailResponses(Guid userId)
        {
            return await _context.UserDetails.Where(x=>x.UserId==userId).ToListAsync();

        }
    }
}
