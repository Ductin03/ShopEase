using ClothingStore.Models.RequestModels;
using ClothingStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public LoginsController(IUserServices userServices)
        {
            _userServices = userServices;
        }/// <summary>
         /// HTTP GET: .../api/login
         /// </summary>
         /// <param name="request"></param>
         /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var token = await _userServices.Authentication(request);
            return Ok(new { Token = token });
        }
    }
}
