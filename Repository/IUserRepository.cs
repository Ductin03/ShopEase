using ClothingStore.Entities;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ClothingStore.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(Users users);
        Task CreateUserDetails(UserDetails userDetails);
        Task<List<UserDetails>> userDetailResponses(Guid userId);
        Task<Users> GetByUserName(string username);
        Task<Users> GetByUserId(Guid userId);
        Task<string> GetRoleName(string username);
        Task UpdateUser(Users users);
        Task<BasePanigationResponModel<Users>> GetAllUsers(GetUserRequestModel getUserRequestModel);
        Task DeleteUser(Users users);

        Task<Users> GetByEmail(string email);
    }

}
