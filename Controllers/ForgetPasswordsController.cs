using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using ShopEase.Services;

namespace ShopEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordsController : ControllerBase
    {
        private readonly IForgetPasswordServices _forgetPasswordServices;
        public ForgetPasswordsController(IForgetPasswordServices forgetPasswordServices)
        {
            _forgetPasswordServices = forgetPasswordServices;
        }
        [HttpPost]
        public async Task<IActionResult> SendOtp([FromQuery]string email)
        {
            await _forgetPasswordServices.SendOtpMail(email);
            return Ok(email);
            
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ForgetPasswordRequestModel request)
        {
            return Ok(await _forgetPasswordServices.ResetPassword(request.Email,request.OTP,request.Password));
        }
    }
}
