using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using ShopEase.Services;
using System.Security.Claims;

namespace ShopEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingServices _ratingServices;
        public RatingsController(IRatingServices ratingServices)
        {
            _ratingServices = ratingServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRating(CreateRatingRequestModel request)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(Guid.TryParse(user, out Guid userId))
            {
                request.UserId = userId;
            }
            await _ratingServices.CreateRating(request);
            return Ok(request);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateRating(UpdateRatingRequestModel request)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(user, out Guid userId))
            {
                request.UpdatedBy=userId;
            }
            await _ratingServices.UpdateRating(request); 
            return Ok(request);
        }
    }
}
