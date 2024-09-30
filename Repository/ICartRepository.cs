using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface ICartRepository
    {
        public Task AddCart(AddCart addCart);
        public Task<CartSumResponseModel> GetCart(Guid userId);
        public Task UpdateCart(AddCart updateCart);
        public Task<AddCart> GetByProductId(Guid id);
    }
}
