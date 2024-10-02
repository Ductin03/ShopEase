using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Repository
{
    public interface IRatingRepository
    {
        public Task CreateRating(Rating rating);
        public Task UpdateRating(Rating rating);    
        public Task<Rating> GetByRatingId(Guid ratingId);
    }
}
