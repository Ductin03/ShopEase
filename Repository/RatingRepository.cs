using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;

namespace ShopEase.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ShopEaseDbContext _context;
        public RatingRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public Task CreateRating(Rating rating)
        {
            _context.Add(rating);
            return Task.FromResult(true);
        }

        public async Task<Rating> GetByRatingId(Guid ratingId)
        {
            return await _context.Ratings.FirstOrDefaultAsync(x => x.Id == ratingId);
        }

        public Task UpdateRating(Rating rating)
        {
            _context.Update(rating);
            return Task.FromResult(true);
        }
    }
}
