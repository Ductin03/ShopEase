using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public interface ICartServices
    {
        public Task AddCartAsync(AddCartRequestModel model);
        public Task<CartSumResponseModel> GetCartAsync(Guid userId);
        public Task UpdateCartAsync(UpdateCartRequestModel model);
        public Task SubmitCartAsync(SubmitCartRequestModel model);
    }
}
