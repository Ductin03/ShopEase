using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public class RatingServices : IRatingServices 
    {
        private readonly IUnitOfWork _unitOfWork;
        public RatingServices(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        public async Task CreateRating(CreateRatingRequestModel model)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(model.ProductId);
            if (productExist == null)
            {
                throw new Exception("Product Not Exist!!!");
            }
            var rating = new Rating();
            rating.Id = Guid.NewGuid();
            rating.ProductId = model.ProductId;
            rating.UserId= model.UserId;
            rating.Comment=model.Comment;
            rating.Point=model.Point;
            rating.CreatedOn = DateTime.UtcNow;
            rating.CreatedBy = model.CreatedBy;
            rating.IsDeleted = false;
            _unitOfWork.ratingRepository.CreateRating(rating);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateRating(UpdateRatingRequestModel model)
        {
            var rating = await _unitOfWork.ratingRepository.GetByRatingId(model.Id);
            if (rating == null)
            {
                throw new Exception("Rating Not Exist!!!");
            }
            rating.Point= model.Point;
            rating.Comment = model.Comment;
            rating.UpdatedBy = model.UpdatedBy;
            rating.UpdatedOn= DateTime.UtcNow;
            _unitOfWork.ratingRepository.UpdateRating(rating);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
