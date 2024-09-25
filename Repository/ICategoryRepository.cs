using ClothingStore.Entities;

namespace ShopEase.Repository
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Categories categories);
        Task<Categories> GetByCategoryId(Guid categoryId);
        Task<List<Categories>> GetAllCategories();
        Task DeleteCategory(Categories categories);
        Task UpdateCategory(Categories categories);
    }

}
