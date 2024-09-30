using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopEaseDbContext _context;
        public OrderRepository(ShopEaseDbContext context)
        {
            _context = context;
        }

        public async Task<OrderSumResponseRequestModel> GetOrder(Guid userId)
        {
            var viewOrders = await (from o in _context.Oders
                             join od in _context.OderDetails on o.Id equals od.OderId
                             join p in _context.Products on od.ProductId equals p.Id
                             where o.UserId == userId
                             select new
                             {
                                 ProductId = od.ProductId,
                                 ProductName = p.ProductName,
                                 Price = od.Price,
                                 Quantity = od.Quantity,
                                 TotalPrice= od.Price*od.Quantity
                             }).ToListAsync();

            List<OrderResponseModel> orders = new List<OrderResponseModel>();
            decimal totalPrice = 0;

            foreach (var items in viewOrders)
            {
                orders.Add(new OrderResponseModel
                {
                    ProductName= items.ProductName,
                    Price = items.Price,
                    Quantity = items.Quantity,
                    OrderId=items.ProductId,
                    ProductId=items.ProductId
                });
                totalPrice += items.TotalPrice;
            }

            var result = new OrderSumResponseRequestModel
            {
                Total = totalPrice,
                OrderResponse = orders
            };

            return result;

        }

        public  Task Oder(Oder oder)
        {
            _context.Oders.Add(oder);
            return  Task.FromResult(true);
            
        }

        public Task OderDetail(OderDetails oderDetails)
        {
            _context.OderDetails.Add(oderDetails);
            return Task.FromResult(true);
              
        }
    }
}
