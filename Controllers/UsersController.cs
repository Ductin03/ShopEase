using ClothingStore.Attributes;
using ClothingStore.Models.RequestModels;
using ClothingStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using System.Security.Claims;

namespace ClothingStore.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        /// <summary>
        /// HTTP GET: .../api/users/getalluser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [AuthorizeRoles(RoleModels.Admin)]
        [HttpGet("")]
        public async Task<IActionResult> GetAllUser([FromQuery] GetUserRequestModel request)
        {
            return Ok(await _userServices.GetAllUsersAsync(request));
        }

        /// <summary>
        /// HTTP POST: .../api/products/create-user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        //[AuthorizeRoles(RoleModels.Admin)]
        [HttpPost("")]
        public async Task<IActionResult> CreateUser(CreateUserRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.CreateBy = result;

            await _userServices.CreateUser(request);
            return Ok(request);
        }
        /// <summary>
        /// HTTP GET: .../api/user/update-user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [AuthorizeRoles(RoleModels.Admin)]
        [HttpPatch("{userid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userid,UpdateUserRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.UpdateBy = result;

            request.UserId = userid;
            await _userServices.UpdateUser(request);
            return Ok(request);
        }
        [HttpDelete("{userid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userid)
        {
            await _userServices.DeleteUserAsync(userid);
            return Ok(userid);

        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetInfoUser([FromRoute] Guid userId)
        {

            return Ok(await _userServices.GetUsersDetails(userId));
            
        }
    }
}
