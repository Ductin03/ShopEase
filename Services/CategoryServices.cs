using ClothingStore.Entities;
using ClothingStore.UnitOfWork;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateCategory(CreateCategoryRequestModel model)
        {
            var categories = new Categories();
            categories.Id=Guid.NewGuid();
            categories.CategoryName = model.CategoryName;
            categories.Description = model.Description;
            categories.SubCategoryId = model.SubCategoryId;
            categories.CreateDate = DateTime.UtcNow;
            categories.CreateBy = model.CreateBy;
            categories.IsDeleted = false;
            _unitOfWork.categoryRepository.CreateCategory(categories);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var categoryExist = await _unitOfWork.categoryRepository.GetByCategoryId(categoryId);
            if (categoryExist==null)
            {
                throw new Exception("Không tồn tại danh mục ");
                
            }
            categoryExist.IsDeleted = true;
            _unitOfWork.categoryRepository.DeleteCategory(categoryExist);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _unitOfWork.categoryRepository.GetAllCategories();
        }

        public async Task UpdateCategory(UpdateCategoryRequestModel model)
        {
            var categoryExist = await _unitOfWork.categoryRepository.GetByCategoryId(model.CategoryId);
            if(categoryExist==null) {
                throw new Exception("Khong ton tai category");
            }
            categoryExist.CategoryName= model.CategoryName;
            categoryExist.UpdateDate = DateTime.UtcNow;
            categoryExist.Description = model.Description;
            categoryExist.SubCategoryId = model.SubCategoryId;
            categoryExist.UpdateBy=model.UpdateBy;
            _unitOfWork.categoryRepository.UpdateCategory(categoryExist);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
