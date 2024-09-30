using ClothingStore.Entities;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface IProductRepository
    {
        Task CreateProduct(Products products);
        Task<BasePanigationResponModel<Products>> GetAllProduct(GetProductRequestModel getProductRequestModel);
        //Task CreateProductAttribute(ProductAttribute productAttribute);
        Task UpdateProduct(Products products);
        Task DeleteProduct(Products products);
        Task<Products> GetByIdProduct(Guid productId);
        Task<List<Products>> GetByCategory(Guid categoryId);
    }
}
