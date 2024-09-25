using ClothingStore.Entities;
using ClothingStore.Models.RequestModels;
using ClothingStore.UnitOfWork;
using ShopEase.Models.RequestModels;

namespace ClothingStore.Services
{
    public interface IUserServices
    {
        Task CreateUser(CreateUserRequestModel model);
        Task<string> Authentication(LoginRequestModel model);
        Task UpdateUser(UpdateUserRequestModel model);
        Task<List<Users>> GetAllUsersAsync();
        Task DeleteUserAsync(Guid userid);
    }
}
