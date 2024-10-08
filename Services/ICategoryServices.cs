﻿using ClothingStore.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public interface ICategoryServices
    {
        Task CreateCategory(CreateCategoryRequestModel model);
        Task<List<Category>> GetAllCategories();
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(UpdateCategoryRequestModel model);
    }
}
