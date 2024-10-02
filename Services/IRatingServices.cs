using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public interface IRatingServices
    {
        public Task CreateRating(CreateRatingRequestModel model);
        public Task UpdateRating(UpdateRatingRequestModel model);
    }
}
