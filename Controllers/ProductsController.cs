using Azure.Core;
using ClothingStore.Attributes;
using ClothingStore.Entities;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [AuthorizeRoles(RoleModels.Admin)]
        /// <summary>
        /// HTTP GET: .../api/products/create-product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(Guid.TryParse(userIdClaim, out Guid result))
            {
                request.SellerId = result;
                request.CreatedBy= result;
            }
            await _productServices.CreateProduct(request);
            return Ok(request);
        }
        /// <summary>
        /// HTTP GET: .../api/products/GetAllProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [AuthorizeRoles(RoleModels.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetProductRequestModel request)
        {
            return Ok(await _productServices.GetAllProductAsync(request));
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductDetail([FromRoute] Guid productId)
        {
            return Ok(await _productServices.GetProductDetailAsync(productId));
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetByCategory(Guid categoryid)
        {
            return Ok(await _productServices.GetByCategoryAsync(categoryid));
        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid productId,[FromBody] UpdateProductRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.UpdatedBy = result;

            request.ProductId = productId;
           
            await _productServices.UpdateProductAsync(request);
            return Ok(request);
        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            await _productServices.DeleteProductAsync(productId);
            return Ok(true);
        }
    }
}
