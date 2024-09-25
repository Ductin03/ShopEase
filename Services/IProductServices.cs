using ClothingStore.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public interface IProductServices
    {
        Task CreateProduct(CreateProductRequestModel model);
        Task<List<Products>> GetAllProductAsync();
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(UpdateProductRequestModel model);
    }
}
