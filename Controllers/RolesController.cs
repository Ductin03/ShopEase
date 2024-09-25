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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRolesAsync());

        }
        /// <summary>
        /// HTTP GET: .../api/roles/create-role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 

        //[AuthorizeRoles(RoleModels.Admin)]
        [HttpPost("")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.CreateBy = result;

            await _roleService.Role(request);
            return Ok(request);
        }
        [HttpPatch("{roleid}")]
        public async Task<IActionResult> UpdateRole([FromRoute] Guid roleid, [FromBody] UpdateRoleRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.UpdateBy = result;

            request.RoleId=roleid;
            await _roleService.UpdateRoleAsync(request);
            return Ok(request);
        }
        [HttpDelete("{roleid}")]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid roleid)
        {
            await _roleService.DeleteRoleAsync(roleid);
            return Ok(roleid);
        }
    }
}
