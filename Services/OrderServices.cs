using ClothingStore.Entities;
using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderSumResponseRequestModel> getOrderAsync(Guid userId)
        {
            return await _unitOfWork.orderRepository.GetOrder(userId);
            
        }

        public async Task Order(OrderModel model)
        {
            foreach (var items in model.OrderModels)
            {
                var product = await _unitOfWork.productRepository.GetByIdProduct(items.ProductId);
                if (product != null)
                {
                    if (product.quantity < items.Quantity)
                    {
                        throw new Exception("Không đủ sổ lượng sản phẩm");
                    }
                }
                else
                {
                    throw new Exception("Không tồn tại sản phẩm");
                }
            }
            var Oder = new Order();
            Oder.Id= Guid.NewGuid();
            Oder.ODerId = Guid.NewGuid();
            Oder.Quantity= model.OrderModels.Count;
            Oder.UserId = model.UserId;
            Oder.Price=model.OrderModels.Sum(x => x.Price* x.Quantity);
            Oder.Status = "Pending";
            Oder.CreatedBy = model.UserId;
            Oder.CreatedOn = DateTime.UtcNow;
            await _unitOfWork.orderRepository.Oder(Oder);
            foreach(var item in model.OrderModels)
            {
                var orderDetails = new OrderDetail();
                orderDetails.OderId = Oder.Id;
                orderDetails.ProductId = item.ProductId;
                orderDetails.Quantity = item.Quantity;
                orderDetails.Price=item.Price;
                await _unitOfWork.orderRepository.OderDetail(orderDetails);
            }
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
