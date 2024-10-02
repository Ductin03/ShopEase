using ClothingStore.Entities;
using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateProduct(CreateProductRequestModel model)
        {
            var categories= await _unitOfWork.categoryRepository.GetByCategoryId(model.CategoryId);
            if(categories == null) {
                throw new Exception("KHông tồn tại danh mục");
            }
            var seller = await _unitOfWork.userRepository.GetByUserId(model.SellerId);
            if(seller == null)
            {
                throw new Exception("Người bán không tồn tại");
            }

            var product = new Product();
            product.Id = Guid.NewGuid();
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.quantity = model.Quantity;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.SellerId = model.SellerId;
            product.CreatedBy = model.CreatedBy;
            product.CreatedOn = DateTime.UtcNow;
            product.IsDeleted = false;
            _unitOfWork.productRepository.CreateProduct(product);
            await _unitOfWork.SaveChangeAsync();

        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(productId);
            if(productExist == null)
            {
                throw new Exception("sản phẩm không tồn tại!");
            }
            productExist.IsDeleted = true;
            _unitOfWork.productRepository.DeleteProduct(productExist);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<BasePanigationResponModel<Product>> GetAllProductAsync(GetProductRequestModel model)
        {
           return await _unitOfWork.productRepository.GetAllProduct(model);
            
        }

        public async Task<List<Product>> GetByCategoryAsync(Guid categoryId)
        {
            var categoryExist=await _unitOfWork.categoryRepository.GetByCategoryId(categoryId);
            if(categoryExist == null)
            {
                throw new Exception("Category Not Exist");
            }
            return await _unitOfWork.productRepository.GetByCategory(categoryId);
        }

        public async Task<ProductDetailResponseModel> GetProductDetailAsync(Guid productId)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(productId);
            if(productExist == null)
            {
                throw new Exception("Product Not Exist!!!");
            }
            return await _unitOfWork.productRepository.GetProductDetails(productId);
        }

        public async Task UpdateProductAsync(UpdateProductRequestModel model)
        {
            var productExist = await _unitOfWork.productRepository.GetByIdProduct(model.ProductId);
            if (productExist == null)
            {
                throw new Exception("Sản phẩm không tồn tại!");
            }
            var categoryExist=await _unitOfWork.categoryRepository.GetByCategoryId(model.CategoryId);
            if (categoryExist == null)
            {
                throw new Exception("Danh mục không tồn tại!");
            }
            productExist.ProductName = model.ProductName;
            productExist.Price = model.Price;
            productExist.quantity = model.Quantity;
            productExist.Description = model.Description;
            productExist.CategoryId = model.CategoryId;
            productExist.SellerId = model.SellerId;
            productExist.UpdatedBy = model.UpdatedBy;
            productExist.UpdatedOn = DateTime.UtcNow;
            productExist.IsDeleted = false;
            _unitOfWork.productRepository.UpdateProduct(productExist);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
