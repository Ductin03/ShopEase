using ClothingStore.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public interface IProductServices
    {
        Task CreateProduct(CreateProductRequestModel model);
        Task<BasePanigationResponModel<Product>> GetAllProductAsync(GetProductRequestModel model);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(UpdateProductRequestModel model);
        Task<List<Product>> GetByCategoryAsync(Guid categoryId);
        Task<ProductDetailResponseModel> GetProductDetailAsync(Guid productId);
    }
}
