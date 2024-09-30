using ShopEase.Entities;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface IOrderRepository
    {
        public Task Oder(Oder oder);
        public Task OderDetail(OderDetails oderDetails);
        public Task<OrderSumResponseRequestModel> GetOrder(Guid UserID);
    }

}
