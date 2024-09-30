using ClothingStore.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public interface IProductServices
    {
        Task CreateProduct(CreateProductRequestModel model);
        Task<BasePanigationResponModel<Products>> GetAllProductAsync(GetProductRequestModel model);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(UpdateProductRequestModel model);
        Task<List<Products>> GetByCategoryAsync(Guid categoryId);
    }
}
