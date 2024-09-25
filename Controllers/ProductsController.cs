﻿using Azure.Core;
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
                request.CreateBy= result;
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
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productServices.GetAllProductAsync());
        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid productId,[FromBody] UpdateProductRequestModel request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userIdClaim, out Guid result);

            request.UpdateBy = result;

            request.ProductId = productId;
           
            await _productServices.UpdateProductAsync(request);
            return Ok(request);
        }

        [AuthorizeRoles(RoleModels.Admin)]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            await _productServices.DeleteProductAsync(productId);
            return Ok(productId);
        }
    }
}
