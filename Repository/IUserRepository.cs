using ClothingStore.Entities;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ClothingStore.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(User users);
        Task CreateUserDetails(UserDetail userDetails);
        Task<List<UserDetail>> userDetailResponses(Guid userId);
        Task<User> GetByUserName(string username);
        Task<User> GetByUserId(Guid userId);
        Task<string> GetRoleName(string username);
        Task UpdateUser(User users);
        Task<BasePanigationResponModel<User>> GetAllUsers(GetUserRequestModel getUserRequestModel);
        Task DeleteUser(User users);

        Task<User> GetByEmail(string email);
    }

}
