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

        public Task CreateUser(User users)
        {
            _context.Users.Add(users);
            return Task.FromResult(true);
        }

        public Task CreateUserDetails(UserDetail userDetails)
        {
            _context.UserDetails.Add(userDetails);
            return Task.FromResult(true);   
        }

        public Task DeleteUser(User users)
        {
            _context.Users.Update(users);
            return Task.FromResult(true);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<BasePanigationResponModel<User>> GetAllUsers(GetUserRequestModel getUserRequestModel)
        {
            var query= _context.Users as IQueryable<User>;
            if (!string.IsNullOrWhiteSpace(getUserRequestModel.Keyword))
            {
                query= query.Where(x=>x.UserName.Contains(getUserRequestModel.Keyword));
            }
            query = query.OrderByDescending(x => x.CreatedOn);

            var total = await query.CountAsync();
            if (getUserRequestModel.PageSize > 0)
            {
                query=query.Skip(getUserRequestModel.PageIndex*getUserRequestModel.PageSize).Take(getUserRequestModel.PageSize);
            }
            var items = await query.ToListAsync();

            return new BasePanigationResponModel<User>(getUserRequestModel.PageIndex,getUserRequestModel.PageSize,total,items);
                
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByUserId(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> GetByUserName(string username)
        {
           return await _context.Users.FirstOrDefaultAsync(x=>x.UserName == username);
        }

        public async Task<string> GetRoleName(string username)
        {
            return await _context.Users.Where(u => u.UserName == username).
                                        Select(u => _context.Roles.
                                        FirstOrDefault(r => r.Id == u.RoleId).RoleName).FirstOrDefaultAsync();
        }

        public Task UpdateUser(User users)
        {
             _context.Users.Update(users);
            return Task.FromResult(true);
        }

        public async Task<List<UserDetail>> userDetailResponses(Guid userId)
        {
            return await _context.UserDetails.Where(x=>x.UserId==userId).ToListAsync();

        }
    }
}
