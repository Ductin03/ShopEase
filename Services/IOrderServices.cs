using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public interface IOrderServices
    {
        public Task Order(OrderModel model);
        public Task<OrderSumResponseRequestModel> getOrderAsync(Guid userId);
    }
}
