using ClothingStore.Entities;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public interface IProductRepository
    {
        Task CreateProduct(Product products);
        Task<BasePanigationResponModel<Product>> GetAllProduct(GetProductRequestModel getProductRequestModel);
        //Task CreateProductAttribute(ProductAttribute productAttribute);
        Task UpdateProduct(Product products);
        Task DeleteProduct(Product products);
        Task<Product> GetByIdProduct(Guid productId);
        Task<List<Product>> GetByCategory(Guid categoryId);
        Task<ProductDetailResponseModel> GetProductDetails(Guid productId);
    }
}
