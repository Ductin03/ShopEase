using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface ICartRepository
    {
        public Task AddCart(Cart addCart);
        public Task<CartSumResponseModel> GetCart(Guid userId);
        public Task UpdateCart(Cart updateCart);
        public Task<Cart> GetByProductId(Guid id);
    }
}
