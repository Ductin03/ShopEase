using ShopEase.Entities;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface IOrderRepository
    {
        public Task Oder(Order oder);
        public Task OderDetail(OrderDetail oderDetails);
        public Task<OrderSumResponseRequestModel> GetOrder(Guid UserID);
    }

}
