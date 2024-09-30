using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

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

        public async Task<BasePanigationResponModel<Products>> GetAllProduct(GetProductRequestModel getProductRequestModel)
        {
            var query = _context.Products as IQueryable<Products>;

            if (!string.IsNullOrWhiteSpace(getProductRequestModel.Keyword))
            {
                query= query.Where(x=> x.ProductName.ToLower().Contains(getProductRequestModel.Keyword.ToLower()));
            }

            query= query.OrderByDescending(x=>x.CreateDate);

            var total = await query.CountAsync();

            if (getProductRequestModel.PageSize > 0)
            {
                query=query.Skip(getProductRequestModel.PageIndex*getProductRequestModel.PageSize).Take(getProductRequestModel.PageSize);
            }

            var items= await query.ToListAsync();

            return new BasePanigationResponModel<Products>(getProductRequestModel.PageIndex, getProductRequestModel.PageSize, total, items);
        }

        public async Task<List<Products>> GetByCategory(Guid categoryId)
        {
            return await _context.Products.Where(x=>x.CategoryId==categoryId).ToListAsync();
        }

        //public Task CreateProductAttribute(ProductAttribute productAttribute)
        //{
        //    _context.ProductAttributes.Add(productAttribute);
        //    return Task.FromResult(true);
        //}

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
