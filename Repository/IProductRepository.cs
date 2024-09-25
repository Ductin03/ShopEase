using ClothingStore.Entities;
using ShopEase.Entities;

namespace ShopEase.Repository
{
    public interface IProductRepository
    {
        Task CreateProduct(Products products);
        Task<List<Products>> GetAllProduct();
        //Task CreateProductAttribute(ProductAttribute productAttribute);
        Task UpdateProduct(Products products);
        Task DeleteProduct(Products products);
        Task<Products> GetByIdProduct(Guid productId);
    }
}
