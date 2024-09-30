using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using ShopEase.Services;
using System.Security.Claims;

namespace ShopEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpPost]
        public async Task<IActionResult> Order(OderModel request)
        {
            var user= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(Guid.TryParse(user, out Guid userId))
            {
                request.UserId = userId;
            }
            await _orderServices.Order(request);
            return Ok(request);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
          
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid.TryParse(user, out Guid userId);
            return Ok(await _orderServices.getOrderAsync(userId));

        }

    }
}
