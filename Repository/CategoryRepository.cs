using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShopEase.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopEaseDbContext _context;
        public CategoryRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public Task CreateCategory(Categories categories)
        {
            _context.Categories.Add(categories);
            return Task.FromResult(true);
        }

        public Task DeleteCategory(Categories categories)
        {
            _context.Categories.Update(categories);
            return Task.FromResult(true);
        }

        public Task<List<Categories>> GetAllCategories()
        {
            return _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetByCategoryId(Guid categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(x=>x.Id==categoryId);
        }

        public Task UpdateCategory(Categories categories)
        {
            _context.Categories.Update(categories);
            return Task.FromResult(true);
        }
    }
}
