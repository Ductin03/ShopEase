using ClothingStore.Attributes;
using ClothingStore.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.RequestModels;
using ShopEase.Services;
using System.Security.Claims;

namespace ShopEase.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        /// <summary>
        /// HTTP GET: .../api/categoris/create-categories
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [AuthorizeRoles(RoleModels.Admin)]
        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestModel request)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.CreatedBy = result;
            await _categoryServices.CreateCategory(request);
            return Ok(request);
        }


        [AuthorizeRoles(RoleModels.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryServices.GetAllCategories());
        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpPatch("{categoryid}")]
        public async Task<IActionResult> UpdateCategories([FromRoute] Guid categoryid, [FromBody] UpdateCategoryRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.UpdatedBy = result;

            request.CategoryId = categoryid;

            await _categoryServices.UpdateCategory(request);
            return Ok(request);

        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpDelete("{categoryid}")]
        public async Task<IActionResult> DeleteCategories([FromRoute] Guid categoryid)
        {
            await _categoryServices.DeleteCategory(categoryid);
            return Ok(true);

        }
    }
}
