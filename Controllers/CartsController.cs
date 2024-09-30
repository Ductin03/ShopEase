using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using ShopEase.Services;
using System.Security.Claims;

namespace ShopEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartsController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCart() {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid.TryParse(user, out Guid userId);
            return Ok(await _cartServices.GetCartAsync(userId));
        }
        [HttpPost]
        public async Task<IActionResult> AddCart(AddCartRequestModel request)
        {
            var user= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(Guid.TryParse(user,out Guid userId)) { 
                request.UserId = userId;
            }
            await _cartServices.AddCartAsync(request);
            return Ok(request);

        }
        [HttpPatch]
        public async Task<IActionResult> UpdateCart(UpdateCartRequestModel request)
        {
            await _cartServices.UpdateCartAsync(request);
            return Ok(request); 
        }
        [HttpPost("check-out")]
        public async Task<IActionResult> SubmitCart(SubmitCartRequestModel request)
        {
            await _cartServices.SubmitCartAsync(request);
            return Ok(request);
        }
    }
}
