using ClothingStore.Entities;
using ClothingStore.Models.RequestModels;
using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ClothingStore.Services
{
    public interface IUserServices
    {
        Task CreateUser(CreateUserRequestModel model);
        Task<List<UserDetail>> GetUsersDetails(Guid userId);
        Task<string> Authentication(LoginRequestModel model);
        Task UpdateUser(UpdateUserRequestModel model);
        Task<BasePanigationResponModel<User>> GetAllUsersAsync(GetUserRequestModel model);
        Task DeleteUserAsync(Guid userid);
    }
}
