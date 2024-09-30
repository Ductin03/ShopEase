using ClothingStore.UnitOfWork;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;
using ShopEase.Models.ResponseModel;
using ShopEase.Repository;

namespace ShopEase.Services
{
    public class CartServices : ICartServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCartAsync(AddCartRequestModel model)
        {
            var product = await _unitOfWork.productRepository.GetByIdProduct(model.ProductId);
            if (product == null)
            {
                throw new Exception("Product Not Exist!");
            }
            if (model.Quantity > product.quantity)
            {
                throw new Exception("không đủ số lượng");
            }
            var addCart = new AddCart();
            addCart.Id=Guid.NewGuid();
            addCart.ProductId = model.ProductId;
            addCart.Quantity = model.Quantity == 0 ? 1 : model.Quantity;
            addCart.Price= model.Price;
            addCart.UserId = model.UserId;
            addCart.CreateBy = model.CreateBy;
            addCart.CreateDate = DateTime.UtcNow;
            addCart.IsDeleted=false;
            _unitOfWork.cartRepository.AddCart(addCart);
             await _unitOfWork.SaveChangeAsync();

            
        }

        public async Task<CartSumResponseModel> GetCartAsync(Guid userId)
        {
             return await _unitOfWork.cartRepository.GetCart(userId);
        }

        public async Task SubmitCartAsync(SubmitCartRequestModel model)
        {
            foreach(var items in model.submitCartRequestModels)
            {
                var product= await _unitOfWork.productRepository.GetByIdProduct(items.ProductId);

                var productExist= await _unitOfWork.cartRepository.GetByProductId(items.ProductId);

                if (productExist != null)
                {
                    if (items.Quantity<product.quantity)
                    {
                        product.quantity -= items.Quantity;
                        await _unitOfWork.productRepository.UpdateProduct(product);
                    }
                    else
                    {
                        throw new Exception("Không đủ số lượng product");
                    }

                }
                else
                {
                    throw new Exception("Khong ton tai product");
                }
            }
            await _unitOfWork.SaveChangeAsync();
            }

        public async Task UpdateCartAsync(UpdateCartRequestModel model)
        {
            foreach(var items in model.updateCartRequestModels)
            {
                var productExist = await _unitOfWork.cartRepository.GetByProductId(items.ProductId);
                if (productExist == null)
                {
                    throw new Exception("Product Not Exist");
                }
                productExist.Quantity = items.Quantity;
                await _unitOfWork.cartRepository.UpdateCart(productExist);
            }
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
