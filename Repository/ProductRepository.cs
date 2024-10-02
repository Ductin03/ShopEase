using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;
using System.Drawing;

namespace ShopEase.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopEaseDbContext _context;
        public ProductRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public Task CreateProduct(Product products)
        {
            _context.Products.Add(products);
            return Task.FromResult(true);
        }

        public Task DeleteProduct(Product products)
        {
            _context.Products.Update(products);
            return Task.FromResult(true);
        }

        public async Task<BasePanigationResponModel<Product>> GetAllProduct(GetProductRequestModel getProductRequestModel)
        {
            var query = _context.Products.AsNoTrackingWithIdentityResolution() as IQueryable<Product>;

            if (!string.IsNullOrWhiteSpace(getProductRequestModel.Keyword))
            {
                query = query.Where(x => x.ProductName.ToLower().Contains(getProductRequestModel.Keyword.ToLower())).AsNoTrackingWithIdentityResolution();
            }

            query = query.OrderByDescending(x => x.CreatedOn);

            var total = await query.CountAsync();

            if (getProductRequestModel.PageSize > 0)
            {
                query = query.Skip(getProductRequestModel.PageIndex * getProductRequestModel.PageSize).Take(getProductRequestModel.PageSize);
            }

            var items = await query.ToListAsync();

            return new BasePanigationResponModel<Product>(getProductRequestModel.PageIndex, getProductRequestModel.PageSize, total, items);
        }

        public async Task<List<Product>> GetByCategory(Guid categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        //public Task CreateProductAttribute(ProductAttribute productAttribute)
        //{
        //    _context.ProductAttributes.Add(productAttribute);
        //    return Task.FromResult(true);
        //}

        public async Task<Product> GetByIdProduct(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public Task UpdateProduct(Product products)
        {
            _context.Products.Update(products);
            return Task.FromResult(true);
        }

        public async Task<ProductDetailResponseModel> GetProductDetails(Guid productId)
        {
            var query = await (from p in _context.Products
                   join r in _context.Ratings on p.Id equals r.ProductId into ratings
                   from rt in ratings.DefaultIfEmpty()

                   join u in _context.UserDetails on p.SellerId equals u.UserId into sellers
                   from sl in sellers.DefaultIfEmpty()

                  
                   
                   select new ProductDetailResponseModel
                   {
                       ProductId=p.Id,
                       ProductName = p.ProductName,
                       Price = p.Price,
                       Description = p.Description,
                       Seller=sl.FullName
                   }).FirstOrDefaultAsync(x=>x.ProductId==productId);

            var ratingQuery = from r in _context.Ratings
                                join u in _context.UserDetails on r.UserId equals u.UserId into commenters
                                from cm in commenters.DefaultIfEmpty()
                                select new RatingReponseModel
                                {
                                    Commenter = cm.FullName,
                                    Point = r.Point,
                                    Comment = r.Comment
                                };
            var ratingRes = await ratingQuery.ToListAsync();

            query.Rating = ratingRes;

            return query;

            
        }
    }
}
