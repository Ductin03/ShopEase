﻿using ClothingStore.Entities;
using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateProduct(CreateProductRequestModel model)
        {
            var categories= await _unitOfWork.categoryRepository.GetByCategoryId(model.CategoryId);
            if(categories == null) {
                throw new Exception("KHông tồn tại danh mục");
            }
            var seller = await _unitOfWork.userRepository.GetByUserId(model.SellerId);
            if(seller == null)
            {
                throw new Exception("Người bán không tồn tại");
            }

            var product = new Products();
            product.Id = Guid.NewGuid();
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.SellerId = model.SellerId;
            product.CreateBy = model.CreateBy;
            product.CreateDate = DateTime.UtcNow;
            product.IsDeleted = false;
            _unitOfWork.productRepository.CreateProduct(product);
            await _unitOfWork.SaveChangeAsync();

        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(productId);
            if(productExist == null)
            {
                throw new Exception("sản phẩm không tồn tại!");
            }
            productExist.IsDeleted = true;
            _unitOfWork.productRepository.DeleteProduct(productExist);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<Products>> GetAllProductAsync()
        {
           return await _unitOfWork.productRepository.GetAllProduct();
            
        }

        public async Task UpdateProductAsync(UpdateProductRequestModel model)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(model.ProductId);
            if (productExist == null)
            {
                throw new Exception("Sản phẩm không tồn tại!");
            }
            var categoryExist=await _unitOfWork.categoryRepository.GetByCategoryId(model.CategoryId);
            if (categoryExist == null)
            {
                throw new Exception("Danh mục không tồn tại!");
            }
            productExist.ProductName = model.ProductName;
            productExist.Price = model.Price;
            productExist.Description = model.Description;
            productExist.CategoryId = model.CategoryId;
            productExist.SellerId = model.SellerId;
            productExist.UpdateBy = model.UpdateBy;
            productExist.UpdateDate = DateTime.UtcNow;
            productExist.IsDeleted = false;
            _unitOfWork.productRepository.UpdateProduct(productExist);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
