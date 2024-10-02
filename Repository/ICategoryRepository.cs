using ClothingStore.Entities;

namespace ShopEase.Repository
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category categories);
        Task<Category> GetByCategoryId(Guid categoryId);
        Task<List<Category>> GetAllCategories();
        Task DeleteCategory(Category categories);
        Task UpdateCategory(Category categories);
    }

}
