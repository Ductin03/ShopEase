using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;

namespace ShopEase.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopEaseDbContext _context;
        public ProductRepository(ShopEaseDbContext context) { 
            _context = context;
        }
        public Task CreateProduct(Products products)
        {
           _context.Products.Add(products);
            return Task.FromResult(true);
        }

        public Task DeleteProduct(Products products)
        {
            _context.Products.Update(products);
            return Task.FromResult(true);
        }

        //public Task CreateProductAttribute(ProductAttribute productAttribute)
        //{
        //    _context.ProductAttributes.Add(productAttribute);
        //    return Task.FromResult(true);
        //}

        public async Task<List<Products>> GetAllProduct()
        {
           var query = _context.Products.Where(x => x.IsDeleted == false);
           var Items= await query.ToListAsync();
           return Items;
        }

        public async Task<Products> GetByIdProduct(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id==productId);
        }

        public Task UpdateProduct(Products products)
        {
            _context.Products.Update(products);
            return Task.FromResult(true);
        }
    }
}
